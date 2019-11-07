#pragma once

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

// Define a custom class to provide retrieve and interact with hyperlinks in a browser application.

class CLinkProcessor 
{
public:
    CLinkProcessor();

    // The Initialize() and Uninitialize() methods are responsible for the 
    // management of the background thread which makes all the calls to UIA.
    HRESULT Initialize(HWND hDlg);
    void    Uninitialize();

    // The following methods are called on the main UI thread in response to 
    // user action at the sample app's UI.
    void BuildListOfHyperlinksFromWindow(BOOL fUseCache, BOOL fSearchLinkChildren);
    void HighlightLink(int idxLink, BOOL fUseCache);
    void InvokeLink(int idxLink, BOOL fUseCache);

private:

    // s_ListenerThreadProc is the thread proc for the background MTA thread
    // on which calls to UIA are made.
    static DWORD WINAPI s_ListenerThreadProc(__in LPVOID lpParameter);

    // Cleanup() is called to release any objects which were set up when the 
    // background thread started. It does not release anything which was set
    // up on the main UI thread.
    void Cleanup();

    // The following methods get called on the background thread 
    // to prevent any UIA calls being made on the main UI thread.
    void BuildListOfHyperlinksFromWindowInternal(BOOL fUseCache, BOOL fSearchLinkChildren);
    void HighlightLinkInternal(int idxLink, BOOL fUseCache);
    void InvokeLinkInternal(int idxLink, BOOL fUseCache);

    // The following method is not called in the sample by default. It demonstrates
    // an alternative way to find all the hyperlink elements in the browser window.
    void BuildListOfHyperlinksFromWindowInternalAlternateApproach(BOOL fSearchLinkChildren);

    // The following are helper methods.
    void BuildListOfHyperlinksFromElement(IUIAutomationElement *pElementBrowser, BOOL fUseCache, BOOL fSearchLinkChildren);
    HRESULT GetCachedDataFromElement(IUIAutomationElement *pElement, BOOL fSearchLinkChildren, BSTR *pbstrName);
    HRESULT GetCurrentDataFromElement(IUIAutomationElement *pElement, BOOL fSearchLinkChildren, BSTR *pbstrName);

    // To not attempt to refresh the list of hyperlinks if a refresh is already in progress.
    BOOL _fRefreshInProgress;

    // The following are used as part of managing the LinkProcessor's background thread.
    IUIAutomation *_pUIAutomation; // IUIAutomation interface used to add the LinkProcessor's background thread.
    HWND           _hWndMainUI; // Handle to sample's main UI window.
    HANDLE         _hThreadBackground; // Handle to background MTA thread.
    DWORD          _idBackgroundThread; // Id of background thread.
    HANDLE         _hLinkProcessorListenerReady; // Event used by background thread to indicate that it's ready to start processing messages.

    // The background thread will keep a reference to an ElementArray related to the hyperlinks found.
    // This array is released prior to a refresh of the list, and when the app is closed down. When the
    // UI thread requests that a link in the UI is highlighted or invoked, the UI thread passes an index
    // into the array of the link to be acted on. The background thread will use this index and access
    // the required IUIAutomationElement from the ElementArray.
    IUIAutomationElementArray *_pElementArray;
};
