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

// Custom window message to allow the app's UI thread to tell its LinkProcessor 
// background thread and EventHandler background thread to close down gracefully.
#define WM_UIASAMPLE_UITHREADTOBACKGROUNDTHREAD_CLOSEDOWN         (WM_USER + 100)

// Custom window messages that the main UI thread will post to the LinkProcessor's background thread.
#define WM_UIASAMPLE_UITHREADTOLINKPROCESSORTHREAD_BUILDLIST      (WM_USER + 200)
#define WM_UIASAMPLE_UITHREADTOLINKPROCESSORTHREAD_HIGHLIGHTLINK  (WM_USER + 201)
#define WM_UIASAMPLE_UITHREADTOLINKPROCESSORTHREAD_INVOKELINK     (WM_USER + 202)
#define WM_UIASAMPLE_UITHREADTOLINKPROCESSORTHREAD_RELEASEELEMENT (WM_USER + 203)

// Custom window messages that the LinkProcessor's background thread will post to the main UI thread.
#define WM_UIASAMPLE_LINKPROCESSORTHREADTOUITHREAD_FOUNDLINK      (WM_USER + 301)
#define WM_UIASAMPLE_LINKPROCESSORTHREADTOUITHREAD_CLEARLIST      (WM_USER + 302)

// Custom window message to allow the UIA event handler to notify the main 
// sample UI that the list of hyperlinks needs to be refreshed.
#define WM_UIASAMPLE_EVENTHANDLERTOUITHREAD_NEWSTRUCTURECHANGEDEVENT (WM_USER + 400)

// Custom window message that the main UI thread will post to the EventProcessor's background thread.
#define WM_UIASAMPLE_UITHREADTOEVENTHANDLERTHREAD_REGISTEREVENTHANDLER (WM_USER + 500)
