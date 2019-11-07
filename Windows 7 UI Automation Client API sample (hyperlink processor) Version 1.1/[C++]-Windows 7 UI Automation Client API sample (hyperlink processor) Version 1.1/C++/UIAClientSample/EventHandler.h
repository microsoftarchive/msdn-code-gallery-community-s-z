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

// Define a custom class to implement a UIA event handler.

class CEventHandler : public IUIAutomationStructureChangedEventHandler 
{
public: 

    CEventHandler();
    ~CEventHandler();

    HRESULT StartEventHandler(HWND hDlg);
    void    Uninitialize();

    // IUnknown methods.
    IFACEMETHODIMP QueryInterface(__in REFIID riid, __out PVOID *ppvObj);
    IFACEMETHODIMP_(ULONG) AddRef();
    IFACEMETHODIMP_(ULONG) Release();

    // IUIAutomationStructureChangedEventHandler methods.
    IFACEMETHODIMP HandleStructureChangedEvent(IUIAutomationElement *sender, StructureChangeType changeType, SAFEARRAY *runtimeId);

private:

    static DWORD WINAPI s_ListenerThreadProc(__in LPVOID lpParameter);
    void    CleanUp();
    HRESULT RegisterStructureChangeListener();
    void    RemoveSampleEventHandler();

    ULONG                 _cRef; // Reference count of the CEventHandler object.
    IUIAutomation        *_pUIAutomation; // IUIAutomation interface used to add the event handler.
    IUIAutomationElement *_pElementBrowser; // IUIAutomationElement for the browser window raising the events.
    HWND                  _hWndMainUI; // Handle to sample's main UI window.
    HANDLE                _hThreadBackground; // handle to background MTA thread on which the event handler runs.
    DWORD                 _idBackgroundThread; // Id of background thread.
    HANDLE                _hEventListenerReady; // Event used by background thread to indicate that it's ready to start processing messages.
    BOOL                  _fAddedEventHandler; // Flag indicating that an event handler has been added and is ready for use.
};
