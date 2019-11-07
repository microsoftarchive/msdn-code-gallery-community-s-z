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

// Define a custom class to provide a way for the sample application
// to highlight where a hyperlink is on the screen.

class CHighlight
{
public:

    CHighlight();

    HRESULT Initialize(HINSTANCE hInstance);
    HRESULT Uninitialize();

    void HighlightRect(RECT rcBounds);
    void Clear();

private:

    // For this sample, the hyperlink will be highlighted using the 
    // windows Magnification API.
    BOOL CreateMagnifier(HINSTANCE hInstance);
    static LRESULT WINAPI HostWndProc(HWND hWnd, UINT Msg, WPARAM wParam, LPARAM lParam);

    HWND _hWndMag;  // A window of class WC_MAGNIFIER which presents the magnified visuals.
    HWND _hWndHost; // The parent window of _hWndMag, which is moved and sized based on the hyperlink being highlighted.
};  
