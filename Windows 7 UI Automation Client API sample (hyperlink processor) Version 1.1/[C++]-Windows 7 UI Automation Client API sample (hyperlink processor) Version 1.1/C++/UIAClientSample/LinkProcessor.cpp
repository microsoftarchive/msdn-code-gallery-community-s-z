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

// LinkProcessor.cpp : Retrieve and interact with a list of hyperlinks in a browser application.

#include "StdAfx.h"
#include "UIAutomation.h"
#include "UIAClientSample.h"
#include "LinkProcessor.h"
#include "Highlight.h"

extern CHighlight *g_pHighlight;

// This sample retrieves hyperlinks from an Internet Explorer window.
const WCHAR c_szBrowserWindowClass[] = L"IEFrame";

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// CLinkProcessor() - Constructor.
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
CLinkProcessor::CLinkProcessor() : _fRefreshInProgress(FALSE),
                                   _hLinkProcessorListenerReady(NULL),
                                   _hWndMainUI(NULL),
                                   _hThreadBackground(NULL),
                                   _idBackgroundThread(NULL),
                                   _pUIAutomation(NULL),
                                   _pElementArray(NULL)
{
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// Initialize()
//
// In order to prevent any possibility of the calls to UIA below leading to delays while a 
// a UIA event handler is also running, all calls below will run on a background MTA thread.
// This means that the app's main UI thread makes no calls to UIA at all.
//
// Ths method runs on the main UI thread.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
HRESULT CLinkProcessor::Initialize(HWND hDlg)
{
    HRESULT hr = E_FAIL; 

    // This sample doesn't expect to enter here with a background thread already initialized.
    if (_hThreadBackground != NULL)
    {
        return hr;
    }

    // The LinkProcessor's background thread will post notifications to the main UI window.
    _hWndMainUI = hDlg;

    // Create an event which will be signaled by the new thread when it's ready to start processing.
    _hLinkProcessorListenerReady = CreateEvent(NULL, TRUE /*Manual reset*/, FALSE /*Initial state*/, NULL);
    if (_hLinkProcessorListenerReady != NULL)
    {
        _hThreadBackground = CreateThread(NULL, 0, s_ListenerThreadProc, this, 0, &_idBackgroundThread);
        if (_hThreadBackground != NULL)
        {
            // Wait for the new background thread to signal the event used to indicate 
            // that the thread is ready to start processing. (Give it 2 seconds.)
            hr = WaitForSingleObject(_hLinkProcessorListenerReady, 2000);
        }
    }

    return 0;
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// Uninitialize()
//
// Close the background thread down.
//
// Runs on the main UI thread.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
void CLinkProcessor::Uninitialize()
{
    // Tell the background thread to close down.
    if (_idBackgroundThread != NULL)
    {
        PostThreadMessage(_idBackgroundThread, WM_UIASAMPLE_UITHREADTOBACKGROUNDTHREAD_CLOSEDOWN, 0, 0);

        // Give the thread a couple of seconds to close down gracefully.
        WaitForSingleObject(_hThreadBackground, 2000);
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// BuildListOfHyperlinksFromWindow()
//
// Signals the background thread that the list of hyperlinks needs to be refreshed.
// 
// Run on the main UI thread.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
void CLinkProcessor::BuildListOfHyperlinksFromWindow(BOOL fUseCache, BOOL fSearchLinkChildren)
{
    PostThreadMessage(_idBackgroundThread, WM_UIASAMPLE_UITHREADTOLINKPROCESSORTHREAD_BUILDLIST, 
                      fUseCache, fSearchLinkChildren);
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// HighlightLink()
//
// Signals the background thread that the a hyperlink needs to be highlighted.
// 
// Run on the main UI thread.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
void CLinkProcessor::HighlightLink(int idxLink, BOOL fUseCache)
{
    PostThreadMessage(_idBackgroundThread, WM_UIASAMPLE_UITHREADTOLINKPROCESSORTHREAD_HIGHLIGHTLINK, 
                      idxLink, fUseCache);
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// InvokeLink()
//
// Signals the background thread that a hyperlink needs to be invoked.
// 
// Run on the main UI thread.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
void CLinkProcessor::InvokeLink(int idxLink, BOOL fUseCache)
{
    PostThreadMessage(_idBackgroundThread, WM_UIASAMPLE_UITHREADTOLINKPROCESSORTHREAD_INVOKELINK, 
                      idxLink, fUseCache);
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// s_ListenerThreadProc()
//
// Entry point for the background thread on which the call to UIA will be made.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
DWORD WINAPI CLinkProcessor::s_ListenerThreadProc(LPVOID lpParameter)
{
    HRESULT hr = S_OK;

    CLinkProcessor *pThis = (CLinkProcessor*)lpParameter;

    // Make sure the thread's message queue is created.
    MSG msg;
    PeekMessage(&msg, NULL, WM_USER, WM_USER, PM_NOREMOVE);

    // *** Note: The thread on which the UIA calls are made below must be MTA.
    hr = CoInitializeEx(NULL, COINIT_MULTITHREADED);
    if (SUCCEEDED(hr))
    {
        // Retrieve a IUIAutomation interface pointer as a starting point for all UIA interaction.
        hr = CoCreateInstance(CLSID_CUIAutomation, NULL, CLSCTX_INPROC_SERVER, 
                              IID_PPV_ARGS(&pThis->_pUIAutomation));
        if (SUCCEEDED(hr))
        {
            // Let the main thread know this thread is ready to start processing.
            SetEvent(pThis->_hLinkProcessorListenerReady);

            BOOL bRet = FALSE;

            // The various WM_UIASAMPLE_UITHREADTO* messages we may receive below are posted 
            // from the app's main UI thread. In response to the messages the background thread
            // will call UIA and if necessary post a message back to the main UI thread later.
            // This means that no UIA calls are being made on the main UI thread.

            // Wait for a message to arrive at the thread message queue.
            while ((bRet = GetMessage( &msg, NULL, 0, 0 )) != 0)
            { 
                if (bRet == -1)
                {
                    // GetMessage() failed.
                    break;
                }
                else if(msg.message == WM_UIASAMPLE_UITHREADTOLINKPROCESSORTHREAD_BUILDLIST)
                {                   
                    pThis->BuildListOfHyperlinksFromWindowInternal((BOOL)msg.wParam, (BOOL)msg.lParam);

                    // Note: This method demonstrates an alternate approach to getting the hyperlinks from
                    // the browser window. (However, it does not allow hyperlink relatives to be gathered.)
                    //  pThis->BuildListOfHyperlinksFromWindowInternalAlternateApproach((BOOL)msg.wParam);
                }
                else if(msg.message == WM_UIASAMPLE_UITHREADTOLINKPROCESSORTHREAD_HIGHLIGHTLINK)
                {
                    pThis->HighlightLinkInternal((int)msg.wParam, (BOOL)msg.lParam);
                }
                else if(msg.message == WM_UIASAMPLE_UITHREADTOLINKPROCESSORTHREAD_INVOKELINK)
                {
                    pThis->InvokeLinkInternal((int)msg.wParam, (BOOL)msg.lParam);
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

            pThis->Cleanup();
        }

        CoUninitialize();
    }

    return 0;
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// Cleanup()
//
// Release anything set up by the background thread when the thread was started. 
// Do not  release anything set up on the main UI thread.
//
// Runs on the background thread.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
void CLinkProcessor::Cleanup()
{
    if (_pElementArray != NULL)
    {
        _pElementArray->Release();
        _pElementArray = NULL;
    }

    _pUIAutomation->Release();
    _pUIAutomation = NULL;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// BuildListOfHyperlinksFromWindow()
//
// Retrieve a list of hyperlinks from a browser window.
//
// Runs on the background thread.
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
void CLinkProcessor::BuildListOfHyperlinksFromWindowInternal(BOOL fUseCache, BOOL fSearchLinkChildren)
{
    // If we're already building up a list of links, ignore this request to refresh the list.
    // (A shipping app might consider queueing this request in order to refresh the list again 
    // once the in-progress refreshing action is complete.)
    if (_fRefreshInProgress)
    {
        return;
    }

    _fRefreshInProgress = TRUE;

    // Tell the main UI thread to clear the current list of hyperlinks in the UI.
    PostMessage(_hWndMainUI, WM_UIASAMPLE_LINKPROCESSORTHREADTOUITHREAD_CLEARLIST, 0, 0);

    // Find a browser window whose contents we'll examine.
    HWND hWndBrowser = FindWindow(c_szBrowserWindowClass, NULL);
    if (hWndBrowser != NULL)
    {
        // Get a UIAutomationElement associated with this browser window. Note that the IUIAutomation 
        // interface has other useful functions for retrieving automation elements. For example:
        //
        //   ElementFromPoint() - convenient when getting the UIA element beneath the mouse cursor.
        //   GetFocusedElement() - convenient when you need the UIA element for whatever control 
        //                         currently has keyboard focus.
        //
        // All these functions have cache-related equivalents which can reduce the 
        // time it takes to work with the element once it's been retrieved.

        IUIAutomationElement *pElementBrowser = NULL;
        HRESULT hr = _pUIAutomation->ElementFromHandle((UIA_HWND)hWndBrowser, &pElementBrowser);
        if (SUCCEEDED(hr))
        {
            // If all we needed to do is get a few properties of the element we now have, we could 
            // make the get_Current* calls such shown below.) But these would incur the time cost of 
            // additional cross-proc calls.)

            BSTR bstrName;
            hr = pElementBrowser->get_CurrentName(&bstrName);
            if (SUCCEEDED(hr)) 
            {
                // Do something with the name...

                // Now release the name bstr.
                SysFreeString(bstrName);
            }

            RECT rcBrowser;
            hr = pElementBrowser->get_CurrentBoundingRectangle(&rcBrowser);
            if (SUCCEEDED(hr)) 
            {
                // Do something with the bounding rect...
            }

            // Rather than doing the above, a shipping app might choose to request the name
            // and bounding rect of the browser when it retrieves the browser element. It
            // could do this by calling ElementFromHandleBuildCache() supplying a cache
            // request which included the properties it needs. By doing that, there would 
            // only be one cross-proc call rather than the three involved with the above steps.

            // For this sample, we'll build up a list of all hyperlinks in the browser window.
            BuildListOfHyperlinksFromElement(pElementBrowser, fUseCache, fSearchLinkChildren);

            pElementBrowser->Release();
            pElementBrowser = NULL;
        }
    }

    // Allow another refresh to be performed now.
    _fRefreshInProgress = FALSE;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// BuildListOfHyperlinksFromElement()
//
// Retrieve a list of hyperlinks from a UIAutomation element. Notifies the main 
// UI thread when it finds hyperlinks to be added to the app's list of hyperlinks.
//
// Runs on the background thread.
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
void CLinkProcessor::BuildListOfHyperlinksFromElement(IUIAutomationElement *pElementBrowser, 
                                                      BOOL fUseCache, BOOL fSearchLinkChildren)
{
    HRESULT hr = S_OK;

    // If _pElementArray is not NULL here, it contains the results of an earlier pass to
    // find all hyperlinks in the browser window. We keep the results around in case the 
    // background thread is told to invoke a link. Release any store array here, as it
    // will get built up and stored again below.

    // Note that releasing an IUIAutomationElementArray will automatically release all 
    // elements referenced in the array, (and any cached children of those elements.)
    if (_pElementArray != NULL)
    {
        _pElementArray->Release();
        _pElementArray = NULL;
    }

    IUIAutomationCacheRequest *pCacheRequest = NULL;
    IUIAutomationCondition    *pCondition = NULL;

    // If a cache is used, then for each of the elements returned to us after a search 
    // for elements, specific properties (and patterns), can be cached with the element. 
    // This means that when we access one of the properties later, a cross-proc call 
    // does not have to be made. (But it also means that when such a call is made, we
    // don't learn whether the original element still exists.)
    if (fUseCache)
    {
        // Create a cache request containing all the properties and patterns
        // we will need once we've retrieved the hyperlinks. By using this
        // cache, when can avoid time-consuming cross-process calls when
        // getting hyperlink properties later.
        hr = _pUIAutomation->CreateCacheRequest(&pCacheRequest);
        if (SUCCEEDED(hr))
        {
            // We'll need the hyperlink's name and bounding rectangle later.
            // A full list of Automation element properties can be found at 
            // http://msdn.microsoft.com/en-us/library/ee684017(v=VS.85).aspx.
            hr = pCacheRequest->AddProperty(UIA_NamePropertyId);
            if (SUCCEEDED(hr))
            {
                hr = pCacheRequest->AddProperty(UIA_BoundingRectanglePropertyId);
                if (SUCCEEDED(hr))
                {
                    // The target of the hyperlink might be stored in the Value property of 
                    // the hyperlink. The Value property is only avaliable if an element
                    // supports the Value pattern. This sample doesn't use the Value, but
                    // if it did, it would call the following here.
                    //  hr = pCacheRequest->AddProperty(UIA_ValueValuePropertyId);
                    // It's ok to attempt to cache a property on a pattern which might not 
                    // exist on the cached elements. In that case, the property just won't
                    // be available when we try to retrieve it from the cache later.

                    // Note that calling AddPattern() does not cache the properties 
                    // associated with a pattern. The pattern's properties must be
                    // added explicitly to the cache if required.
                }
            }

            if (SUCCEEDED(hr))
            {
                // Cache the Invoke pattern too. This means when we prepare to invoke a link later,
                // we won't need to make a cross-proc call during that preparation. (A cross-proc
                // call will occur at the time Invoke() is actually called.) A full list of patterns
                // can be found at http://msdn.microsoft.com/en-us/library/ee684023(v=VS.85).aspx.

                hr = pCacheRequest->AddPattern(UIA_InvokePatternId);
            }
        }

        if (SUCCEEDED(hr))
        {
            // The next step is to specify for which elements we want to have the properties, (and 
            // pattern) cached. By default, caching will occur on each element found in the search 
            // below. But we can also request that the data is  cached for direct children of the
            // elements found, or even all the descendants of the elements founds. (A scope of 
            // Parent or Ancestors cannot be used in a cached request.)

            // So in this sample, if TreeScope_Element is used as the scope here, (which is the 
            // default), then only properties for the found hyperlinks will be cached. The sample
            // optionally caches the properties for the direct children of the hyperlinks too. 
            // This means that if we find a hyperlink with no name, we can search the hyperlink's
            // children to see if one of the child elements has a name we can use. (Searching the 
            // children could be done without using the cache, but it would incur the time cost of
            // making cross-proc calls.) 

            TreeScope scope = TreeScope_Element;

            if (fSearchLinkChildren)
            {
                scope = (TreeScope)((int)scope | (int)TreeScope_Children);
            }

            hr = pCacheRequest->put_TreeScope(scope);
        }

        // Note: By default the cache request has a Mode of Full. This means a reference to the 
        // target element is included in the cache, as well as whatever properties and patterns
        // we specified should be in the cache. With a reference to the target element, we can:
        //
        // (i) Retrieve a property later for an element which we didn't request should be in 
        //     the cache. Eg we could call get_CurrentHasKeyboardFocus().
        //
        // (ii) We can call a method of a pattern that the element supports. Eg if Full mode was
        //      not used here, we would not be able to call Invoke() on the hyperlink later.
        
        // If we specified a Mode of None for the cache request here, then the results only include
        // cached data, with no connection at all after the call returns to the source elements. If 
        // only data is required, then it would be preference to use a Mode of None, as less work is 
        // required by UIA. (Also, if a reference to the element is returned in the cache and kept 
        // around for a non-trivial time, then it increases the chances that the target process 
        // attempts to free the element, but it can't do so in a clean manner as it would like, 
        // due to the client app here holding a reference to it.) To specify that we want a Mode of 
        // None, we'd make this call here:
        //  hr = pCacheRequest->put_AutomationElementMode(AutomationElementMode_None);
    }

    if (SUCCEEDED(hr))
    {
        // Now regardless of whether we're using a cache, we need to specify which elements
        // we're interested in during our search for elements. We do this by building up a
        // property condition. This property condition tells UIA which properties must be 
        // satisfied by an element for it to be included in the search results. We can 
        // combine a number of properties with AND and OR logic.

        // We shall first say that we're only interested in elements that exist in the Control view. 
        // By default, a property condition uses the Raw view, which means that every element in the 
        // target browser's UIA tree will be examined. The Control view is a subset of the Raw view, 
        // and only includes elements which present some useful UI. (The Raw view might include
        // container elements which simply group elements logically together, but the containers 
        // themselves might have no visual representation on the screen.)

        IUIAutomationCondition *pConditionControlView;  
        hr = _pUIAutomation->get_ControlViewCondition(&pConditionControlView);
        if (SUCCEEDED(hr))
        {
            // Now create a property condition specifying that we're interested in elements that
            // have a Control Type property of "hyperlink".
            VARIANT varProp;
            varProp.vt = VT_I4;
            varProp.lVal = UIA_HyperlinkControlTypeId;

            IUIAutomationCondition *pConditionHyperlink;  
            hr = _pUIAutomation->CreatePropertyCondition(UIA_ControlTypePropertyId, varProp, &pConditionHyperlink);
            if (SUCCEEDED(hr))
            {
                // Now combine these two properties such that the search results only contain
                // elements that are in the Control view AND are hyperlinks. We would get the
                // same results here if we didn't include the Control view clause, (as hyperlinks
                // won't exist only in the Raw view), but by specifying that we're only interested
                // in the Control view, UIA won't bother checking all the elements that only exist
                // in the Raw view to see if they're hyperlinks.

                hr = _pUIAutomation->CreateAndCondition(pConditionControlView, pConditionHyperlink, &pCondition);

                pConditionHyperlink->Release();
                pConditionHyperlink = NULL;
            }

            pConditionControlView->Release();
            pConditionControlView = NULL;
        }
    }

    if (SUCCEEDED(hr))
    {
        // Now retrieve all the hyperlinks in the browser. We must specify a scope in the Find calls here,
        // to control how far UIA will go in looking for elements to include in the search results. For
        // this sample, we must check all descendants of the browser window. 

        // *** Note: use TreeScope_Descendants with care, as depending on what you're searching for, UIA may
        // have to process potentially thousands of elements. For example, if you only need to find top level 
        // windows on your desktop, you would search for TreeScope_Children of the root of the UIA tree. (The 
        // root element can be found with a call to IUIAutomation::GetRootElement().)

        // *** Note: If the following searches included searching for elements in the client app's own UI,
        // then the calls must be made on a background thread. (ie not your main UI thread.)

        if (fUseCache)
        {
            hr = pElementBrowser->FindAllBuildCache(TreeScope_Descendants, pCondition, pCacheRequest, &_pElementArray);
        }
        else
        {
            hr = pElementBrowser->FindAll(TreeScope_Descendants, pCondition, &_pElementArray);
        }
    }

    if (SUCCEEDED(hr))
    {
        // Find the number of hyperlinks returned by the search. (The number of hyperlinks 
        // found might be zero if the browser window is minimized.)
        int cElements = 0;
        hr = _pElementArray->get_Length(&cElements);
        if (SUCCEEDED(hr) && (cElements > 0))
        {
            // Process each returned hyperlink element.
            for (int idxElement = 0; idxElement < cElements; idxElement++)
            {
                IUIAutomationElement *pElement = NULL;
                hr = _pElementArray->GetElement(idxElement, &pElement);
                if (FAILED(hr))
                {
                    break;
                }

                // Get the name property for the hyperlink element. How we get this depends
                // on whether we requested that the property should be cached or not.
                BSTR bstrName = NULL;

                if (fUseCache)
                {
                    hr = GetCachedDataFromElement(pElement, fSearchLinkChildren, &bstrName);
                }
                else
                {
                    hr = GetCurrentDataFromElement(pElement, fSearchLinkChildren, &bstrName);
                }

                // If we have non-null name, notify the main UI thread. (This sample does not check
                // for names that only contains whitespace.)
                if (SUCCEEDED(hr) && (bstrName != NULL))
                {
                    // The sample app notifies the main UI thread every time a link is found. This allows 
                    // the displayed list to begin to show links quickly when a refresh is requested. To
                    // reduce the number of messages that are posted, the background thread could build
                    // up a data struct containing information about all the links found, and notify the
                    // main UI thread once when the list has been fully built up. (The main UI thread
                    // would be responsible for freeing the memory used to store the full list's data.)

                    // The main UI thread is repsonsible for freeing the bstr later. Also, pass along
                    // the index of the link in the ElementArray. If  the UI thread requests that this 
                    // link is highlighted or invoked later, it will supply the index for the background 
                    // thread to use as an index in the stored ElementAraray.
                    PostMessage(_hWndMainUI, 
                                WM_UIASAMPLE_LINKPROCESSORTHREADTOUITHREAD_FOUNDLINK, 
                                (WPARAM)bstrName, 
                                idxElement);
                }
            }
        }
    }

    if (pCondition != NULL)
    {
        pCondition->Release();
        pCondition = NULL;
    }

    if (pCacheRequest != NULL)
    {
        pCacheRequest->Release();
        pCacheRequest = NULL;
    }
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// GetCachedDataFromElement()
//
// Get the cached name from a non-zero size UIA element. If the element doesn't have
// a name, optionally try to find a name from the cached children of the element.
//
// Runs on the background thread.
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
HRESULT CLinkProcessor::GetCachedDataFromElement(IUIAutomationElement *pElement, BOOL fSearchLinkChildren, BSTR *pbstrName)
{
    // (A shipping app would do parameter checking here.)

    *pbstrName = NULL;

    // Get the bounding rectangle for the hyperlink. By retrieving this from the 
    // cache, we avoid the time-consuming cross-process call to get the data. 
    RECT rcBounds;
    HRESULT hr = pElement->get_CachedBoundingRectangle(&rcBounds);
    if (SUCCEEDED(hr))
    {
        // If the hyperlink has a zero-size bounding rect, ignore the element. This 
        // might happen if the hyperlink has scrolled out of view. (We could also 
        // investigate whether using the IsOffscreen property tells us that the link 
        // can be ignored. In fact, if the IsOffscreen property is reliable, we could 
        // have included a property condition of IsOffcreen is FALSE in the original 
        // search, and not check whether the link's visible here.)
        if ((rcBounds.right > rcBounds.left) && (rcBounds.bottom > rcBounds.top))
        {
            // Get the name of the element. This will normally be the text shown on the screen. 
            // Note that the set of get_Cached* functions (or get_Current*), are convenient 
            // ways of retrieving the same data that could be retrieved through the functions 
            // GetCachedPropertyValue() (or GetCurrentPropertValue().) In the case of get_CachedName(), 
            // the alternative would be to call GetCachedPropertyValue() with UIA_NamePropertyId.

            BSTR bstrName;
            hr = pElement->get_CachedName(&bstrName);
            if (SUCCEEDED(hr))
            {
                if (SysStringLen(bstrName) > 0)
                {
                    // A shipping app would check for more than an empty string. (A link might
                    // just have " " for a name.) The BSTR will be freed by the caller.
                    *pbstrName = bstrName;
                }
                else
                {
                    // The hyperlink has no usable name. Free the name bstr if it's 
                    // an empty string. (SysFreeString() can accept NULL here.)
                    SysFreeString(bstrName);

                    // Should we consider using the name of a child element of the hyperlink?
                    if (fSearchLinkChildren)
                    {
                        // Given that hyperlink element has no name, use the name of first child 
                        // element that does have a name. (In some cases the hyperlink element might 
                        // contain an image or text element that does have a useful name.) We can take 
                        // this action here because we supplied TreeScope_Children as the scope of the 
                        // cache request that we passed in the call to FindAllBuildCache().

                        IUIAutomationElementArray *pElementArrayChildren;
                        hr = pElement->GetCachedChildren(&pElementArrayChildren);
                        if (SUCCEEDED(hr) && (pElementArrayChildren != NULL))
                        {
                            int cChildren;
                            hr = pElementArrayChildren->get_Length(&cChildren);
                            if (SUCCEEDED(hr))
                            {
                                // For each child element found...
                                for (int idxChild = 0; idxChild < cChildren; ++idxChild)
                                {
                                    IUIAutomationElement *pElementChild = NULL;
                                    hr = pElementArrayChildren->GetElement(idxChild, &pElementChild);
                                    if (SUCCEEDED(hr))
                                    {
                                        BSTR bstrNameChild;
                                        hr = pElementChild->get_CachedName(&bstrNameChild);
                                        if (SUCCEEDED(hr))
                                        {
                                            // Check the name of the child elements here. We don't 
                                            // care what type of element it is in this sample app.
                                            if (SysStringLen(bstrNameChild) > 0)
                                            {
                                                // We have a usable name. The BSTR will be freed by the caller.
                                                *pbstrName = bstrNameChild;
                                                break;
                                            }

                                            SysFreeString(bstrNameChild);
                                        }
                                    }

                                    // Try the next child element of the hyperlink...
                                }
                            }

                            pElementArrayChildren->Release();
                            pElementArrayChildren = NULL;
                        }
                    }
                }
            }
        }
    }

    return hr;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// GetCurrentDataFromElement()
//
// Get the current name from a non-zero size UIA element, (incurring the time cost of various a cross-proc
// calls). If the element doesn't have a name, optionally try to find a name from the children of the element
// by using a TreeWalker.
//
// Runs on the background thread.
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
HRESULT CLinkProcessor::GetCurrentDataFromElement(IUIAutomationElement *pElement, BOOL fSearchLinkChildren, BSTR *pbstrName)
{
    *pbstrName = NULL;

    // Call back to the target app to retrieve the bounds of the hyperlink element.
    RECT rcBounds;
    HRESULT hr = pElement->get_CurrentBoundingRectangle(&rcBounds);
    if (SUCCEEDED(hr))
    {
        // If we're the hyperlink has a zero-size bounding rect, ignore the element.
        if ((rcBounds.right > rcBounds.left) && (rcBounds.bottom > rcBounds.top))
        {
            // Get the name of the element. This will normally be the text shown on the screen.
            BSTR bstrName;
            hr = pElement->get_CurrentName(&bstrName);
            if (SUCCEEDED(hr))
            {
                if (SysStringLen(bstrName) > 0)
                {
                    // We have a usable name. The BSTR will be freed by the caller.
                    *pbstrName = bstrName;
                }
                else
                {
                    // The hyperlink has no usable name. 
                    SysFreeString(bstrName);

                    // Consider using the name of a child element of the hyperlink.
                    if (fSearchLinkChildren)
                    {
                        // Use a Tree Walker here to try to find a child element of the hyperlink 
                        // that has a name. Tree walking is a time consuming action, so would be
                        // avoided by a shipping app if alternatives like FindFirst, FindAll, or 
                        // BuildUpdatedCache could get the required data.

                        IUIAutomationTreeWalker *pControlWalker = NULL;
                        hr = _pUIAutomation->get_ControlViewWalker(&pControlWalker);
                        if (SUCCEEDED(hr))
                        {
                            IUIAutomationElement *pElementChild = NULL;
                            hr = pControlWalker->GetFirstChildElement(pElement, &pElementChild);                            
                            while (SUCCEEDED(hr) && (pElementChild != NULL))
                            {
                                // Does this child element have a name?
                                BSTR bstrNameChild;
                                hr = pElementChild->get_CurrentName(&bstrNameChild);
                                if (SUCCEEDED(hr))
                                {
                                    if (SysStringLen(bstrNameChild) > 0)
                                    {
                                        // Use the name of this child element.
                                        *pbstrName = bstrNameChild;
                                        break;
                                    }

                                    // Even if the string returned was an empty string, we must still free it.
                                    SysFreeString(bstrNameChild);

                                    // Continue to the next child element.
                                    IUIAutomationElement *pElementSibling;
                                    hr = pControlWalker->GetNextSiblingElement(pElementChild, &pElementSibling);
                                    if (SUCCEEDED(hr))
                                    {
                                        // We're done with the previous no-name child element.
                                        pElementChild->Release();

                                        // The sibling element (if it exists) has already been AddRef'd 
                                        // beneath GetNextSiblingElement().
                                        pElementChild = pElementSibling;
                                    }
                                }

                                // Try the next child element of the hyperlink...
                            }

                            if (pElementChild != NULL)
                            {
                                pElementChild->Release();
                                pElementChild = NULL;
                            }

                            pControlWalker->Release();
                            pControlWalker = NULL;
                        }
                    }
                }
            }

            // While this sample doesn't use the destination of the hyperlink, if it wanted 
            // to get the destination, that might be available as the Value property of the 
            // element. The Value property is part of the Value pattern, and so is accessed
            // through the Value pattern.
            if (SUCCEEDED(hr))
            {
                // Check first whether the element supports the Value pattern.
                IUIAutomationValuePattern *pUIAValuePattern;
                hr = pElement->GetCurrentPatternAs(UIA_ValuePatternId, IID_PPV_ARGS(&pUIAValuePattern));
                if (SUCCEEDED(hr) && (pUIAValuePattern != NULL))
                {
                    // Now get the Value property.
                    BSTR bstrValue;
                    hr = pUIAValuePattern->get_CurrentValue(&bstrValue);
                    if (SUCCEEDED(hr))
                    {
                        if (bstrValue != NULL)
                        {
                            // This is where the destination of the link would be used...
                        }

                        SysFreeString(bstrValue);
                    }

                    pUIAValuePattern->Release();
                    pUIAValuePattern = NULL;
                }
            }
        }
    }

    return hr;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// HighlightLink()
//
// Highlight the location of a hyperlink in the browser window on the screen.
//
// Runs on the background thread.
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
void CLinkProcessor::HighlightLinkInternal(int idxLink, BOOL fUseCache)
{
    // Do we have an ElementArray that was built up earlier with the hyperlink elements?
    if (_pElementArray == NULL)
    {
        return;
    }

    // Verify that the requested link index is valid for our stored ElementArray.
    int cLinks;
    HRESULT hr = _pElementArray->get_Length(&cLinks);
    if (FAILED(hr) || (idxLink < 0) || (idxLink >= cLinks))
    {
        return;
    }

    IUIAutomationElement *pElement;
    hr = _pElementArray->GetElement(idxLink, &pElement);
    if (SUCCEEDED(hr) && (pElement != NULL))
    {
        RECT rcBounds;

        if (fUseCache)
        {
            // This call should always succeed, as it's simply accessing cached data.
            // The call will not detect whether the original element's bounding rect 
            // has changed, or even if the original element no longer exists.
            hr = pElement->get_CachedBoundingRectangle(&rcBounds);
        }
        else
        {
            // This call will result in a cross-proc call to the target app. The call 
            // will fail if the original element no longer exists.
            hr = pElement->get_CurrentBoundingRectangle(&rcBounds);
        }

        if (SUCCEEDED(hr))
        {
            // UIA client applications should be declared to be "DPI Aware". If this is not 
            // done, then UIA functions that either accept or return coordinates will not 
            // return the correct data. An application can be made DPI Aware can either call 
            // SetProcessDPIAware() on startup, or declare in its manifest that it's DPI Aware. 
            // (This sample uses the manifest approach.) To learn more about UIA and DPI, see 
            // http://msdn.microsoft.com/en-us/library/ee671605(v=VS.85).aspx

            // Now show something on the screen to indicated where the hyperlink is.
            g_pHighlight->HighlightRect(rcBounds);
        }
    }
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// InvokeLink()
//
// Invoke a hyperlink in the browser window.
//
// Runs on the background thread.
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
void CLinkProcessor::InvokeLinkInternal(int idxLink, BOOL fUseCache)
{
    // Do we have an ElementArray that was built up earlier with the hyperlink elements?
    if (_pElementArray == NULL)
    {
        return;
    }

    // Verify that the requested link index is valid for our stored ElementArray.
    int cLinks;
    HRESULT hr = _pElementArray->get_Length(&cLinks);
    if (FAILED(hr) || (idxLink < 0) || (idxLink >= cLinks))
    {
        return;
    }

    IUIAutomationElement *pElement;
    hr = _pElementArray->GetElement(idxLink, &pElement);
    if (SUCCEEDED(hr) && (pElement != NULL))
    {
        HRESULT hr = S_OK;
        IUIAutomationInvokePattern *pPattern = NULL;

        // Will we be calling the Invoke() method through the Invoke pattern. So first
        // get the pattern for the hyperlink element.
        if (fUseCache)
        {
            // This does not result in a cross-proc call here, and should not fail.
            hr = pElement->GetCachedPatternAs(UIA_InvokePatternId, IID_PPV_ARGS(&pPattern));
        }
        else
        {
            // This will fail if the element no longer exists.
            hr = pElement->GetCurrentPatternAs(UIA_InvokePatternId, IID_PPV_ARGS(&pPattern));
        }

        if (SUCCEEDED(hr) && (pPattern != NULL))
        {
            // This will result in a cross-proc call regardless of whether a cache has been
            // used up to this point. The call here will fail if the element no longer exists.

            // In this sample, highlighting of the links will no longer work after this 
            // Invoke() until action has been taken to refresh the list of hyperlinks.

            hr = pPattern->Invoke();

            pPattern->Release();
            pPattern = NULL;
        }
    }
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// This function is not used by the sample, but it shows an alternative approach to building up 
// the cache of hyperlinks. Depending on the action taken by the target app when providing data
// to be stored in the cache of results, different approaches taken by the UIA client can have
// different performance benefits.
// 
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
void CLinkProcessor::BuildListOfHyperlinksFromWindowInternalAlternateApproach(BOOL fSearchLinkChildren)
{
    HRESULT hr = S_OK;

    // If we're already building up a list of links, ignore this request to refresh the list.
    // (A shipping app might consider queueing this request in order to refresh the list again 
    // once the in-progress refreshing action is complete.)
    if (_fRefreshInProgress)
    {
        return;
    }

    _fRefreshInProgress = TRUE;

    // Tell the main UI thread to clear the current list of hyperlinks in the UI.
    PostMessage(_hWndMainUI, WM_UIASAMPLE_LINKPROCESSORTHREADTOUITHREAD_CLEARLIST, 0, 0);

    // If _pElementArray is not NULL here, it contains the results of an earlier pass to
    // find all hyperlinks in the browser window. We keep the results around in case the 
    // background thread is told to invoke a link. Release any store array here, as it
    // will get built up and stored again below.

    // Note that releasing an IUIAutomationElementArray will automatically release all 
    // elements referenced in the array, (and any cached children of those elements.)
    if (_pElementArray != NULL)
    {
        _pElementArray->Release();
        _pElementArray = NULL;
    }

    IUIAutomationCacheRequest *pCacheRequest = NULL;
    IUIAutomationCondition    *pCondition = NULL;

    // First build a cache request in the same way as done elsewhere in the sample.
    // This means that for each element returned following the search, they will 
    // have their name, bounding rect and Invoke pattern cached.
    hr = _pUIAutomation->CreateCacheRequest(&pCacheRequest);
    if (SUCCEEDED(hr))
    {
        hr = pCacheRequest->AddProperty(UIA_NamePropertyId);
        if (SUCCEEDED(hr))
        {
            hr = pCacheRequest->AddProperty(UIA_BoundingRectanglePropertyId);
        }

        if (SUCCEEDED(hr))
        {
            hr = pCacheRequest->AddPattern(UIA_InvokePatternId);
        }
    }

    if (SUCCEEDED(hr))
    {
        // At this point elsewhere in the sample, we specified that we only wanted data
        // for the hyperlink elements (and optionally their children) cached. In this 
        // approach here, we will say that we want data for ALL descendants of the 
        // found elements cached.
        hr = pCacheRequest->put_TreeScope(TreeScope_Descendants);
    }

    if (SUCCEEDED(hr))
    {
        // Now create a property condition as we've done elsewhere, to say that we're only 
        // interested in elements which are in the Control view and are hyperlinks.
        IUIAutomationCondition *pConditionControlView;  
        hr = _pUIAutomation->get_ControlViewCondition(&pConditionControlView);
        if (SUCCEEDED(hr))
        {
            VARIANT varProp;
            varProp.vt = VT_I4;
            varProp.lVal = UIA_HyperlinkControlTypeId;

            IUIAutomationCondition *pConditionHyperlink;  
            hr = _pUIAutomation->CreatePropertyCondition(UIA_ControlTypePropertyId, varProp, &pConditionHyperlink);
            if (SUCCEEDED(hr))
            {
                hr = _pUIAutomation->CreateAndCondition(pConditionControlView, pConditionHyperlink, &pCondition);

                pConditionHyperlink->Release();
                pConditionHyperlink = NULL;                
            }

            pConditionControlView->Release();
            pConditionControlView = NULL;
        }
    }

    if (SUCCEEDED(hr))
    {
        // Now unlike steps we took elsewhere, specify that the cache request should 
        // have an additional filter of the property condition we just created.
        hr = pCacheRequest->put_TreeFilter(pCondition);
    }

    // Elsewhere in the sample, we called FindAllBuildCache(). This returned an array of hyperlink
    // elements with their data cached, (and optinally their children with cache data too.) This
    // CacheLinksFromWindow() function takes a different approach. The element that is returned 
    // from the call to BuildUpdatedCache() below is the browser element with some data cached. 
    // But the returned element will have an array of cached child elements, and each of those 
    // elements will by the hyperlinks we need. So the cache request here has specified through 
    // its tree filter that we're only interest in hyperlinks, whereas elsewhere in this sample, 
    // we supplied that condition in the search call we made. How much difference this makes to 
    // the performance of calls depends on the action taken by the target application.

    // *** Note, using this appoach, we can't also cache data for the direct children of the
    // hyperlinks as we did elsewhere in the sample. So whether this approach is practical
    // depends on the needs of the client application.

    // Note that with a property conditions, it's not possible to request that the set of elements 
    // returned from a search are all elements which have a control type of hyperlink OR whose parent
    // has a control type of hyperlink.

    IUIAutomationElement *pElementBrowser = NULL;

    if (SUCCEEDED(hr))
    {
        HWND hWndBrowser = FindWindow(c_szBrowserWindowClass, NULL);
        if (hWndBrowser != NULL)
        {
            hr = _pUIAutomation->ElementFromHandleBuildCache((UIA_HWND)hWndBrowser, pCacheRequest, &pElementBrowser);
        }
        else
        {
            // A browser needs to be running.
            hr = E_UNEXPECTED;
        }
    }

    if (SUCCEEDED(hr))
    {
        // Now get the array of children, which are all hyperlinks. 
        hr = pElementBrowser->GetCachedChildren(&_pElementArray);
    }

    if (SUCCEEDED(hr) && (_pElementArray != NULL))
    {
        int cElements = 0;
        hr = _pElementArray->get_Length(&cElements);
        if (SUCCEEDED(hr) && (cElements > 0))
        {
            // Process each returned hyperlink element.
            for (int idxElement = 0; idxElement < cElements; idxElement++)
            {
                IUIAutomationElement *pElement = NULL;
                hr = _pElementArray->GetElement(idxElement, &pElement);
                if (FAILED(hr))
                {
                    break;
                }

                // Take the same action elsewhere in the sample to present the hyperlink
                // in the sample app UI.
                BSTR bstrName = NULL;

                hr = GetCachedDataFromElement(pElement, fSearchLinkChildren, &bstrName);
                if (SUCCEEDED(hr) && (bstrName != NULL))
                {
                    // The main UI thread is repsonsible for freeing the bstr later. Also, pass along
                    // the index of the link in the ElementArray. If  the UI thread requests that this 
                    // link is highlighted or invoked later, it will supply the index for the background 
                    // thread to use as an index in the stored ElementAraray.
                    PostMessage(_hWndMainUI, 
                                WM_UIASAMPLE_LINKPROCESSORTHREADTOUITHREAD_FOUNDLINK, 
                                (WPARAM)bstrName, 
                                idxElement);
                }
            }
        }
    }

    if (pElementBrowser != NULL)
    {
        pElementBrowser->Release();
        pElementBrowser = NULL;
    }

    if (pCondition != NULL)
    {
        pCondition->Release();
        pCondition = NULL;
    }

    if (pCacheRequest != NULL)
    {
        pCacheRequest->Release();
        pCacheRequest = NULL;
    }

    // Allow another refresh to be performed now.
    _fRefreshInProgress = FALSE;
}
