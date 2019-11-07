//*******************************************************************************
//   Copyright 2011 Guy Barker
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//*******************************************************************************

// EventHandler.cpp : Implement a UIA event handler.

#include "stdafx.h"
#include "UIAutomation.h"
#include "UIAClientSample.h"
#include "EventHandler.h"

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// CEventHandler() - Constructor.
//
// Runs on the main UI thread.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
CEventHandler::CEventHandler() : _cRef(1),  
                                 _hEventListenerReady(NULL),
                                 _hWndMainUI(NULL),
                                 _hThreadBackground(NULL),
                                 _idBackgroundThread(NULL),
                                 _pUIAutomation(NULL),
                                 _pElementBrowser(NULL),
                                 _fAddedEventHandler(FALSE)
{
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// ~CEventHandler() - Destructor.
//
// Runs on the main UI thread.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
CEventHandler::~CEventHandler()
{
    CleanUp();
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// Uninitialize()
//
// Called on main UI thread to close the background thread down.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
void CEventHandler::Uninitialize()
{
    // Tell the background thread to close down.
    if (_idBackgroundThread != NULL)
    {
        PostThreadMessage(_idBackgroundThread, WM_UIASAMPLE_UITHREADTOBACKGROUNDTHREAD_CLOSEDOWN, 0, 0);

        // Give the thread a couple of seconds to close down gracefully.
        WaitForSingleObject(_hThreadBackground, 2000);
    }

    // Release all the objects created on startup now.
    CleanUp();
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// CleanUp()
//
// Runs on main UI thread.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
void CEventHandler::CleanUp()
{
    // Release all the objects that were allocated on the same thread 
    // that the CEventHandler's StartEventHandler() was called on.

    // *** Note: Do not remove the UIA event handler on this thread. 
    // The UIA event handler must be removed on the same thread as
    // that which added it.

    // The only object we created on this thread at startup is the event used
    // to synchronize the operations when the background thread was created.
    if (_hEventListenerReady != NULL)
    {
        CloseHandle(_hEventListenerReady);
        _hEventListenerReady = NULL;
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// StartEventHandler()
//
// Create the background thread on which the UIA event handler must run.
//
// This function runs on the main UIA thread.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
HRESULT CEventHandler::StartEventHandler(HWND hDlg)
{
    HRESULT hr = E_FAIL; 

    // This sample doesn't expect to enter here with a background thread already initialized.
    if (_hThreadBackground != NULL)
    {
        return hr;
    }

    // The event handler will post notifications to the main UI window.
    _hWndMainUI = hDlg;

    // Create an event which will be signaled by the new thread when it's ready to start processing.
    _hEventListenerReady = CreateEvent(NULL, TRUE /*Manual reset*/, FALSE /*Initial state*/, NULL);
    if (_hEventListenerReady != NULL)
    {
        // *** Note: A UIA event handler must run on a background MTA thread.
        _hThreadBackground = CreateThread(NULL, 0, s_ListenerThreadProc, this, 0, &_idBackgroundThread);
        if (_hThreadBackground != NULL)
        {
            // Wait for the new background thread to signal the event used to indicate 
            // that the thread is ready to start processing. (Give it 2 seconds.)
            hr = WaitForSingleObject(_hEventListenerReady, 2000);
        }

        if (SUCCEEDED(hr))
        {
            // Let the thread know that it should now create the UIA event handler.
            PostThreadMessage(_idBackgroundThread, WM_UIASAMPLE_UITHREADTOEVENTHANDLERTHREAD_REGISTEREVENTHANDLER, 0, 0);
        }
    }

    return 0;
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// s_ListenerThreadProc()
//
// Entry point for the background thread on which the UIA event handler will run.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
DWORD WINAPI CEventHandler::s_ListenerThreadProc(LPVOID lpParameter)
{
    CEventHandler *pThis = (CEventHandler*)lpParameter;

    // Make sure the thread's message queue is created.
    MSG msg;
    PeekMessage(&msg, NULL, WM_USER, WM_USER, PM_NOREMOVE);

    // *** Note: The thread on which the UIA event handler runs must be MTA.
    CoInitializeEx(NULL, COINIT_MULTITHREADED);

    // Let the main thread know this thread is ready to start processing.
    SetEvent(pThis->_hEventListenerReady);

    BOOL bRet = FALSE;

    // Wait for a message to arrive at the thread message queue.
    while ((bRet = GetMessage( &msg, NULL, 0, 0 )) != 0)
    { 
        if (bRet == -1)
        {
            // GetMessage() failed.
            break;
        }
        else if(msg.message == WM_UIASAMPLE_UITHREADTOEVENTHANDLERTHREAD_REGISTEREVENTHANDLER)
        {
            // The main thread has requested that the UIA event handler is set up now.
            HRESULT hr = pThis->RegisterStructureChangeListener();
            if (FAILED(hr))
            {
                break;
            }
        }
        else if(msg.message == WM_UIASAMPLE_UITHREADTOBACKGROUNDTHREAD_CLOSEDOWN)
        {
            // The main thread wants this thread to close down.
            break;
        }
        else
        {
            TranslateMessage(&msg); 
            DispatchMessage(&msg); 
        }
    }

    // Remove the UIA event handler now if it was succeesfully added earlier.
    pThis->RemoveSampleEventHandler();

    CoUninitialize();

    return 0;
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// RegisterStructureChangeListener()
//
// Add a UIA event handler to react to structure change events sent from the browser window.
//
// Runs on the background thread.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
HRESULT CEventHandler::RegisterStructureChangeListener()
{
    HRESULT hr = E_FAIL;

    // This sample assumes we know which window we want to gets events from.

    // *** Note: We must get a pointer to the element we're interested in, in this thread. Do 
    // not have the UI thread get the element and supply it through to the background thread.

    HWND hWndBrowser = FindWindow(L"IEFrame", NULL);
    if (hWndBrowser != NULL)
    {
        // Retrieve a IUIAutomation interface pointer through which we'll add the event handler.
        hr = CoCreateInstance(CLSID_CUIAutomation, NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&_pUIAutomation));
        if (SUCCEEDED(hr))
        {
            // Get a UIAutomation element representing the browser window. We will request below
            // that we get structure change events whenever a structure change event is raised 
            // by the browser window element or any of its descendants in the UIA tree. 

            hr = _pUIAutomation->ElementFromHandle((UIA_HWND)hWndBrowser, &_pElementBrowser);
            if (SUCCEEDED(hr))
            {
                // In general it is not the IEFrame element itself which throws the structure change 
                // events which we will receive in the handler, but rather various decendants elements. 
                // It is these descendants which are the "senders" in the event handler later.

                // AddStructureChangedEventHandler() can take a cache request as other UIA methods do.
                // So if an event handler wanted to retrieve properties from the event sender without
                // having to incur the time cost for a cross-proc call, it would use a cache request
                // here. (For this sample, the event handler doesn't need that.)

                // Other types of UIA event handler can be set up with the following calls:
                //   AddFocusChangeEventHandler()
                //   AddAutomationEventHandler()
                //   AddPropertyChangeEventHandler() - note that some providers might not raise all 
                //                                     the expected propety change events.

                hr = _pUIAutomation->AddStructureChangedEventHandler(_pElementBrowser, TreeScope_Descendants, NULL, this);
                if (SUCCEEDED(hr))
                {
                    _fAddedEventHandler = TRUE;
                }
            }
        }
    }

    if (FAILED(hr))
    {
        CleanUp();
    }

    return hr;
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// RemoveSampleEventHandler()
//
// Perform all cleanup of objects that we initialized on startup in the background thread.
//
// Runs on the background thread.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
void CEventHandler::RemoveSampleEventHandler()
{
    if (_pElementBrowser != NULL)
    {
        // If we successfully added an event handler earlier, remove it now. The
        // handler must be removed on the same thread on which it was added.
        if (_fAddedEventHandler)
        {
            // Depending on the timing of events generated around the time we remove 
            // the event handler, an event can arrive at the handler after a successful 
            // call to remove the event handler. So set the flag here to prevent our 
            // event handler from taking any more action if futher calls to our event 
            // handler are made.
            _fAddedEventHandler = FALSE;

            _pUIAutomation->RemoveStructureChangedEventHandler(_pElementBrowser, this);
        }

        _pElementBrowser->Release();
        _pElementBrowser = NULL;
    }

    if (_pUIAutomation != NULL)
    {
        _pUIAutomation->Release();
        _pUIAutomation = NULL;
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// HandleStructureChangedEvent()
//
// Sample application's handler for UIA StructureChanged events.
//
// Runs on background thread.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
IFACEMETHODIMP CEventHandler::HandleStructureChangedEvent(IUIAutomationElement *pSender, StructureChangeType changeType, SAFEARRAY *runtimeId)
{
    // A structure changed event has been sent by the browser window element or some descendant of it.

    // Check that this event hasn't arrived around the time we're removing the event handler on shutdown.
    if (!_fAddedEventHandler)
    {
        return S_OK;
    }

    // Some event handlers might include a check so see if the event was generated by the UIA client app's own
    // UI. But in this app, the event can only have been generated by the browser app we're interested in.
    // (If the process is was examined here, then the sender's get_CurrentProcessId() would return the id.)

    // The sender event will be probably be some descendant of the main browser UIA element and
    // isn't of particular interest to this sample event handler. If the element was of interest, 
    // and it was necessary to pass a reference to this element to the main UI thread of the client 
    // app, then we would need to marshal the interface for a thread transfer, as shown here:
    //
    //  IStream* pstmSender;
    //  HRESULT hr = CoMarshalInterThreadInterfaceInStream(__uuidof(IUIAutomationElement), pSender, &pstmSender);
    //  if (SUCCEEDED(hr))
    //  {
    //      // The UI thread would get a usable pointer from the lParam by calling CoGetInterfaceAndReleaseStream().
    //      PostMessage(_hWndMainUI, WM_UIASAMPLE_NEWSTRUCTURECHANGEDEVENT, 0, reinterpret_cast<LPARAM>(pstmSender));
    //  }

    // For this sample, all the event handler needs to do is notify the main UI thread that the 
    // list of hyperlinks should be refreshed to make sure it's showing the most current list.
    PostMessage(_hWndMainUI, WM_UIASAMPLE_EVENTHANDLERTOUITHREAD_NEWSTRUCTURECHANGEDEVENT, 0, 0);

    return S_OK;
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// Typical IUnknown implementation.
// 
/////////////////////////////////////////////////////////////////////////////////////////////////
IFACEMETHODIMP CEventHandler::QueryInterface(__in REFIID riid, __out PVOID *ppvObj)
{
    if (ppvObj == NULL)
    {
        return E_POINTER;
    }

    *ppvObj = NULL;

    HRESULT hr = E_NOINTERFACE;

    if ((riid == __uuidof(IUnknown)) || (riid == __uuidof(IUIAutomationStructureChangedEventHandler)))
    {
        *ppvObj = static_cast<IUIAutomationStructureChangedEventHandler*>(this);
    }

    if (NULL != *ppvObj)
    {
        AddRef();

        hr = S_OK;
    }

    return hr;
}

// Given that CEventHandler is running in an MTA thread, we must use InterlockedIncrement() 
// and InterlockedDecrement() below. This if necessary in case the methods get run on multiple 
// threads simultaneously.

IFACEMETHODIMP_(ULONG) CEventHandler::AddRef()
{
    return InterlockedIncrement(&_cRef);
}

IFACEMETHODIMP_(ULONG) CEventHandler::Release()
{
    ULONG cRef = InterlockedDecrement(&_cRef);
    if (cRef == 0)
    {
        delete this;
    }

    return cRef;
}
