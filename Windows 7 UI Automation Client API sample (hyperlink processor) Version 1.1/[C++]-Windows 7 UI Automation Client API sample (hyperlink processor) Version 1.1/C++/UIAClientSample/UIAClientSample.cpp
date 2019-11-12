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

///////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// UI Automation Client Sample.
// 
// This sample application demonstrates some of the more commonly used parts of the 
// Windows 7 UI Automation client API. The sample retrieves a list of hyperlinks shown 
// in an already-running browser application and presents those hyperlinks in its own UI. 
// When a hyperlink is selected in the sample application's UI, the sample will highlight 
// the link shown in the browser window, (using the Windows Magnification API.) The sample 
// can also invoke the hyperlinks in the browser window and react to notifications sent by 
// the browser to have the sample's list of hyperlinks automatically refreshed.
//
// This include use of the following interfaces:
//     IUIAutomation
//     IUIAutomationElement
//     IUIAutomationCacheRequest
//     IUIAutomationCondition   
//     IUIAutomationElementArray
//     IUIAutomationTreeWalker
//
// The sample does not make use of any of the following:
//     IUIAutomationRegistrar or custom client-side proxies
//     Text Patterns
//     Virtualized items
//     LegacyIAccessible
//
// *** Note: Threading issues are important to the implementation of a UIA client.
// For example, if a UIA client interacts with its own UI, then UIA client calls must
// be made from a background MTA thread which does not own any windows. This sample
// does not interact with its own UI, and so all the UIA calls made in this file 
// are made on the sample's main UI thread. Also, all UIA event handlers must run
// in a background MTA thread, (and a call to remove a handler must be made on the
// same thread that on which the matching add-related call was made.) The following 
// link relates to how threading affects the use of UIAutomation:
//     http://msdn.microsoft.com/en-us/library/ee671692(v=VS.85).aspx
//
// Other UIA sample code can be found at:
//     http://msdn.microsoft.com/en-us/library/ff625919(v=VS.85).aspx
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Notes on Version 1.1.
//
// *** Important thread-related change.
//
// After releasing the first version of the UIA Client Sample, it was found that once a UIA event handler
// was created, the performance of the app could slow down considerably. This was happening despite the 
// fact that the event handler was running on a background MTA thread, and the UIA calls being made on 
// the main UI thread did not involve interacting with the sample app's own UI. So in order to avoid any 
// possibility of the event handler impacting the performance, all UIA calls have been moved off the main 
// UI thread. The LinkProcessor object now creates a background MTA thread, (similar to the existing action 
// taken by the EventHandler object).
//
// In response to user action in the main UIA thread, (for example Refresh, Highlight, Invoke), the main 
// UI thread posts a message to the LinkProcessor's background thread to have the necesssary UIA action
// taken. If any of the app's UI needs to be updated in response to this action, the background thread 
// posts a message back to the main UI thread in order to have that action taken. While the sample now 
// demonstrates all the expected behavior, a shipping application could optimize some of this action to 
// reduce the number of calls to PostMessage() between the threads.
//
// *** A change to how elements are released.
//
// The original sample explicitly released the elements in IUIAutomationElement arrays that had been 
// returned from calls to UIA. In fact UIA itelf will release all elements referenced in an array when 
// the array is released. (Similary if the elements have cached relatives, those relatives will also be
// released.) So typically a single release of the ElementArray will be sufficient. If the client 
// specifically needs some of the elements to be available after the array has been released, then 
// the client must AddRef() the elements befor the array is released, and then Release() the elements
// when appropriate later.
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////

// UIAClientSample.cpp : Defines the entry point for the application and control the sample's own UI.

#include "stdafx.h"
#include "UIAutomation.h"
#include "strsafe.h"
#include "UIAClientSample.h"
#include "LinkProcessor.h"
#include "EventHandler.h"
#include "Highlight.h"
#include "resource.h"

// Global variables used between the .cpp files in this sample.
CLinkProcessor *g_pLinkProcessor = NULL;
CEventHandler  *g_pEventHandler = NULL;
CHighlight     *g_pHighlight = NULL;

#define UIASAMPLE_TIMERID      2000
#define UIASAMPLE_TIMEINTERVAL 1000 

// Functions local to this file.
HRESULT InitializeSample(HINSTANCE hInstance);
void UninitializeSample();
INT_PTR CALLBACK SampleDlgProc(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam);
void PopulateListOfLinks(HWND hDlg);

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// wWinMain()
//
// The main entry point into the sample application.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
int APIENTRY wWinMain(HINSTANCE hInstance, HINSTANCE /*hPrevInstance*/, LPWSTR /*pszCmdLine*/, int /*nCmdShow*/)
{
    // Initialize COM in order to use the UI Automation API.
    HRESULT hr = CoInitialize(NULL);
    if (SUCCEEDED(hr))
    {
        // Create all the main objects used by the sample.
        hr = InitializeSample(hInstance);
        if (SUCCEEDED(hr))
        {
            // Now present the UI for the app.
            DialogBox(hInstance, MAKEINTRESOURCE(IDD_UIACLIENT_SAMPLE), NULL, SampleDlgProc);
        }

        UninitializeSample();

        CoUninitialize();
    }

	return 0;
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// InitializeSample()
//
// Create all the main objects used by this sample.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
HRESULT InitializeSample(HINSTANCE hInstance)
{
    HRESULT hr = S_OK;

    // Create an instance of a sample class which finds all the hyperlinks we're interested in.
    g_pLinkProcessor = new CLinkProcessor();
    if (g_pLinkProcessor == NULL)
    {
        hr = E_OUTOFMEMORY;
    }

    if (SUCCEEDED(hr))
    {
        // Create a sample class which shows where a hyperlink is on the screen.
        g_pHighlight = new CHighlight();
        if (g_pHighlight != NULL)
        {
            hr = g_pHighlight->Initialize(hInstance);
        }
    }

    if (SUCCEEDED(hr))
    {
        // Create an instance of our own class which implements a UIA event handler.
        g_pEventHandler = new CEventHandler();
        if (g_pEventHandler == NULL)
        {
            hr = E_OUTOFMEMORY;
        }
    }

    return hr;
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// UninitializeSample()
//
// Release all the objects created when the sample started.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
void UninitializeSample()
{
    HRESULT hr = S_OK;

    if (g_pEventHandler != NULL)
    {
        // Give the event handler a chance to close down its background thread.
        g_pEventHandler->Uninitialize();

        g_pEventHandler->Release();
        g_pEventHandler = NULL;
    }

    if (g_pHighlight != NULL)
    {
        g_pHighlight->Uninitialize();

        delete g_pHighlight;
        g_pHighlight = NULL;
    }

    if (g_pLinkProcessor != NULL)
    {
        // Give the link processor a chance to close down its background thread.
        g_pLinkProcessor->Uninitialize();

        delete g_pLinkProcessor;
        g_pLinkProcessor = NULL;
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// SampleDlgProc()
//
// The dialog proc for the main UI presented by the sample.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
INT_PTR CALLBACK SampleDlgProc(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    INT_PTR iRetVal = 1;

	switch (message)
	{
	case WM_INITDIALOG:
    {
        // Horizontally center the window somewhere near the bottom of the primary monitor.
        int cxScreen = GetSystemMetrics(SM_CXSCREEN);
        int cyScreen = GetSystemMetrics(SM_CYSCREEN);

        RECT rcDlg;
        GetWindowRect(hDlg, &rcDlg);

        SetWindowPos(hDlg, NULL, 
                     (cxScreen - (rcDlg.right - rcDlg.left)) / 2,
                      cyScreen - (rcDlg.bottom - rcDlg.top) - 64,
                     0, 0,
                     SWP_NOZORDER | SWP_NOSIZE);

        // Now that we have a UI window, initialize the background thread on which all UIA calls
        // will be made. The background thread will post messages back to the UI window when the
        // UI needs to be populated with the results of the UIA calls made on the background thread.
        if (SUCCEEDED(g_pLinkProcessor->Initialize(hDlg)))
        {
            // Populate the list of hyperlinks shown in the UIA client.
            PopulateListOfLinks(hDlg);
        }

        break;
    }
	case WM_COMMAND:
    {
        HWND hWndList  = GetDlgItem(hDlg, IDC_LIST_HYPERLINKS);
        BOOL fUseCache = (BOOL)SendDlgItemMessage(hDlg, IDC_CHECK_CACHEDATA, BM_GETCHECK, 0, 0);

        iRetVal = 0;

		switch LOWORD(wParam)
        {
        case IDC_CLOSE:
		
            // Close the sample app down.
			EndDialog(hDlg, 0);
			break;

        case IDC_CHECK_ALWAYSONTOP:

            // Allow the user to control whether the app window is to be topmost.
            if (HIWORD(wParam) == BN_CLICKED)
            {
                BOOL fAlwaysOnTop = (BOOL)SendDlgItemMessage(hDlg, IDC_CHECK_ALWAYSONTOP, BM_GETCHECK, 0, 0);
                
                LONG_PTR lptrExStyle = GetWindowLong(hDlg, GWL_EXSTYLE);

                HWND hWndAfter;

                if (fAlwaysOnTop)
                {
                    lptrExStyle |= WS_EX_TOPMOST;

                    hWndAfter = HWND_TOPMOST;
                }
                else
                {
                    lptrExStyle &= ~WS_EX_TOPMOST;

                    hWndAfter = HWND_NOTOPMOST;
                }

                SetWindowLongPtr(hDlg, GWL_EXSTYLE, lptrExStyle);

                SetWindowPos(hDlg, hWndAfter, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE); 
            }

            break;

        case IDC_CHECK_CACHEDATA:

            // If the the checkbox related to the use of UIA caching been clicked, refresh the
            // background thread's stored list of elements in case an element needs to be highlighted 
            // or invoked before an explicit refresh of the list is done through the UI.
            if (HIWORD(wParam) == BN_CLICKED)
            {
                // Deselect whatever link is currently selected.
                g_pHighlight->Clear();

                // Refresh the list of hyperlinks.
                PopulateListOfLinks(hDlg);
            }

            break;

        case IDC_LIST_HYPERLINKS:

            if (HIWORD(wParam) == LBN_SELCHANGE)
            {
                // The selection has changed in the list showing hyperlinks. Move
                // the current highlight over to the newly selected hyperlink.
                HWND hWndList = GetDlgItem(hDlg, IDC_LIST_HYPERLINKS);
                int iSel = (int)SendMessage(hWndList, LB_GETCURSEL, 0, 0);
                if (iSel != LB_ERR)
                {
                    // The ElementArray index of this link in the background thread's 
                    // stored list of elements is stored as itemdata in the list.
                    int idxLink = (int)SendMessage(hWndList, LB_GETITEMDATA, iSel, 0);
                    if (idxLink != LB_ERR)
                    {
                        g_pLinkProcessor->HighlightLink(idxLink, fUseCache);
                    }
                }
            }

            break;

        case IDC_REFRESH:

            // Deselect whatever link is currently selected.
            g_pHighlight->Clear();

            // Refresh the list of hyperlinks.
            PopulateListOfLinks(hDlg);

            break;

        case IDC_INVOKE:
        {
            // Deselect whatever link is currently selected.
            g_pHighlight->Clear();

            // Invoke the current hyperlink selected in the list of hyperlinks.
            HWND hWndList = GetDlgItem(hDlg, IDC_LIST_HYPERLINKS);
            int iSel = (int)SendMessage(hWndList, LB_GETCURSEL, 0, 0);
            if (iSel != LB_ERR)
            {
                int idxLink = (int)SendMessage(hWndList, LB_GETITEMDATA, iSel, 0);
                if (idxLink != LB_ERR)
                {
                    g_pLinkProcessor->InvokeLink(idxLink, fUseCache);
                }
            }

            break;
        }
        case IDC_ADDEVENTHANDLER:

            // Add an UIA event handler to allow the list of hyperlinks to be automatically refreshed.
            if (g_pEventHandler != NULL)
            {
                HRESULT hr = g_pEventHandler->StartEventHandler(hDlg);
                if (SUCCEEDED(hr))
                {
                    // Disable the "Add event handler" button now that we have an event handler set up.
                    EnableWindow( GetDlgItem(hDlg, IDC_ADDEVENTHANDLER), FALSE);
                }
            }

            break;

        default:

            iRetVal = 1;
            break;
        }

		break;
    }
    case WM_UIASAMPLE_LINKPROCESSORTHREADTOUITHREAD_CLEARLIST:
            
        // The background thread is about to start building up a list of hyperlinks 
        // and it will notify the main UI thread whenever it has found a link to be
        // added to the list in the UI. So clear the current displayed list first.
        SendDlgItemMessage(hDlg, IDC_LIST_HYPERLINKS, LB_RESETCONTENT, 0, 0);

        break;
        
    case WM_UIASAMPLE_LINKPROCESSORTHREADTOUITHREAD_FOUNDLINK:
    {
        // The background thread has found a hyperlink to be added to the UI.
        BSTR bstrName = (BSTR)wParam;
        if (bstrName != NULL)
        {
            HWND hWndList = GetDlgItem(hDlg, IDC_LIST_HYPERLINKS);

            LRESULT lResult = SendMessage(hWndList, LB_ADDSTRING, 0, (LPARAM)bstrName);
            if (lResult != LB_ERR)
            {
                // The lParam supplied by the background thread is an index into
                // an ElementArray of hyperlinks stored by the background thread. 
                SendMessage(hWndList, LB_SETITEMDATA, (WPARAM)lResult, lParam);
            }

            SysFreeString(bstrName);

            // Show the current count of links added to the list.
            int cElements = (int)SendMessage(hWndList, LB_GETCOUNT, 0, 0);
            WCHAR szDetails[256];
            StringCchPrintf(szDetails, ARRAYSIZE(szDetails), L"Number of hyperlinks found: %d", cElements);
            SetDlgItemText(hDlg, IDC_STATIC_LINKCOUNT, szDetails);
        }

        break;
    }
    case WM_UIASAMPLE_EVENTHANDLERTOUITHREAD_NEWSTRUCTURECHANGEDEVENT:

        // This custom message was sent by our UIA event handler to notify us that 
        // we should refresh the list of hyperlinks. Given that we might receive
        // multiple notifications in quick succession, rather than refreshing the 
        // list on every noitifcation, start (or reset) a timer when we receive a
        // notification. When the timer fires, we will perform the refresh.

        // Note that the structure changed event handler in this sample had supplied to 
        // us the UIA element sender of event as the lParam here, then we would call 
        // CoGetInterfaceAndReleaseStream() to get a pointer that we can use in this 
        // UI thread. For example:
        //
        //  IStream *pstmSender = reinterpret_cast<IStream*>(lParam);
        //  IUIAutomationElement *pElementStructureChanged = NULL;
        //  HRESULT hr = CoGetInterfaceAndReleaseStream(pstmSender, IID_PPV_ARGS(&pElementStructureChanged));

        SetTimer(hDlg, UIASAMPLE_TIMERID, UIASAMPLE_TIMEINTERVAL, NULL);

        break;
    
    case WM_TIMER:
    
        // Refresh the list of hyperlinks following an earlier notification 
        // from our UIA structure changed event handler .
        if (wParam == UIASAMPLE_TIMERID)
        {
            KillTimer(hDlg, UIASAMPLE_TIMERID);

            // Deselect whatever link is currently selected.
            g_pHighlight->Clear();

            PopulateListOfLinks(hDlg);

            iRetVal = 0;
        }

        break;
    
    case WM_CLOSE:

		EndDialog(hDlg, 0);

        iRetVal = 0;
		break;

    default:

        // Message unhandled;
        iRetVal = 0;
        break;
	}

	return iRetVal;
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// PopulateListOfLinks()
//
// Refresh the list of hyperlinks shown in the sample UI.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
void PopulateListOfLinks(HWND hDlg)
{
    HWND hWndList = GetDlgItem(hDlg, IDC_LIST_HYPERLINKS);

    // Check whether we should use UIA's caching functionality.
    BOOL fUseCache = (BOOL)SendDlgItemMessage(hDlg, IDC_CHECK_CACHEDATA, BM_GETCHECK, 0, 0);

    // Check whether we should search for a name to use in the hyperlink's 
    // child elements, if the hyperlink itself has no name.
    BOOL fSearchLinkChildren = (BOOL)SendDlgItemMessage(hDlg, IDC_CHECK_SEARCHLINKCHILDREN, BM_GETCHECK, 0, 0);

    // Now gather all the hyperlinks' details, and populate our list UI. Note that if
    // the browser is currently switching pages, no hyperlinks might be shown in the
    // browser window. As such, the list of links shown in the app's UI will be empty.
    g_pLinkProcessor->BuildListOfHyperlinksFromWindow(fUseCache, fSearchLinkChildren);
}
