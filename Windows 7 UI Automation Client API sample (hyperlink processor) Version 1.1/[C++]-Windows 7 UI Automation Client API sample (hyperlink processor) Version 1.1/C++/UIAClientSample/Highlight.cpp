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

// Highlight.cpp : Provides a way for the sample application to highlight where a hyperlink
// is on the screen. For this sample, the Windows Magnification API is used to apply a %400
// magnification to the hyperlink, and to apply colour inversion.

#include "stdafx.h"
#include "Magnification.h"
#include "UIAutomation.h"
#include "UIAClientSample.h"
#include "LinkProcessor.h"
#include "EventHandler.h"
#include "Highlight.h"
#include "resource.h"

const float c_MagFactor = 4.0;

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// CHighlight() - Constructor.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
CHighlight::CHighlight() : _hWndHost(NULL), _hWndMag(NULL)
{
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// Initialize()
//
// Create the various magnification-related windows.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
HRESULT CHighlight::Initialize(HINSTANCE hInstance)
{
    HRESULT hr = S_OK;

    BOOL fSuccess = FALSE;

    // For shipping applications, this CHighlight object would be a singleton, as
    // the various magnifier components should only be created once per process.

    // Initialize the Magnifier components.
    if (MagInitialize())
    {
        // Now create the windows required to show magnified results.
        fSuccess = CreateMagnifier(hInstance);
    }
    
    if (!fSuccess)
    {
        hr = HRESULT_FROM_WIN32(GetLastError());
    }

    return hr;
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// Uninitialize()
//
// Release the various magnification-related objects created on startup.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
HRESULT CHighlight::Uninitialize()
{
    HRESULT hr = S_OK;

    if (_hWndHost != NULL)
    {
        // _hWndMag is a child of _hWndHost and will automatically get destroyed.
        DestroyWindow(_hWndHost);
        _hWndHost = NULL;
    }

    // Uninitialize the Magnifier components.
    if (!MagUninitialize())
    {
        hr = HRESULT_FROM_WIN32(GetLastError());
    }

    return hr;
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// CreateMagnifier()
//
// Create the two windows required to show portions of the screen magnified.
// These windows are the WC_MAGNIFIER class window which presents magnified
// results, and all a host window which will be moved around the screen to
// highlight the hyperlink of interest.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
BOOL CHighlight::CreateMagnifier(HINSTANCE hInstance)
{
    BOOL fSuccess = FALSE;

    WCHAR WindowClassName[] = L"UIASampleHighlightClass";

   // First register the host window class.
    WNDCLASSEX wcex = {0};
    wcex.cbSize         = sizeof(WNDCLASSEX); 
    wcex.lpfnWndProc    = HostWndProc;
    wcex.hInstance      = hInstance;
    wcex.hCursor        = LoadCursor(NULL, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(1 + COLOR_BTNFACE);
    wcex.lpszClassName  = WindowClassName;
    
    if (RegisterClassEx(&wcex) != 0)
    {
        // Now create the host window. This window name will be exposed 
        // through UIA as the element name for the host window.
        _hWndHost = CreateWindowEx(WS_EX_TOPMOST | WS_EX_LAYERED | WS_EX_TOOLWINDOW,  
                                   WindowClassName, L"UIASample Highlight Host Window",
                                   WS_POPUP | WS_THICKFRAME | WS_CLIPCHILDREN, 
                                   0, 0, 0, 0, NULL, NULL, hInstance, NULL);
        if (_hWndHost != NULL)
        {
            SetLayeredWindowAttributes(_hWndHost, 0, 0xFF, LWA_ALPHA);

            // Create a magnifier control that fills the client area of the host window. 
            _hWndMag = CreateWindow(WC_MAGNIFIER, L"UIASample Highlight Magnification Window", 
                                    MS_SHOWMAGNIFIEDCURSOR | MS_INVERTCOLORS | WS_CHILD | WS_VISIBLE, 
                                    0, 0, 0, 0, _hWndHost, NULL, hInstance, NULL );
            if (_hWndMag != NULL)
            {
                // For this sample, the magnification factor is fixed at 400%. So we need to
                // apply that transform only once. If the sample allowed the magnification 
                // factor to change, then MagSetWindowTransform() would need to be called 
                // whenever the factor changed.

                MAGTRANSFORM matrix;
                memset(&matrix, 0, sizeof(matrix));
                matrix.v[0][0] = c_MagFactor;
                matrix.v[1][1] = c_MagFactor;
                matrix.v[2][2] = 1.0f;

                if (MagSetWindowTransform(_hWndMag, &matrix))
                {
                    fSuccess = TRUE;
                }
            }
        }
    }

    return TRUE;
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// HostWndProc()
//
// Window proc for the custom host window.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
LRESULT WINAPI CHighlight::HostWndProc(HWND hWnd, UINT Msg, WPARAM wParam, LPARAM lParam)
{
    return DefWindowProc(hWnd, Msg, wParam, lParam);
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// Clear()
//
// Remove the current highlighting.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
void CHighlight::Clear()
{
    // All we need to do is hide the host window.
    ShowWindow(_hWndHost, SW_HIDE);
}

/////////////////////////////////////////////////////////////////////////////////////////////////
//
// HighlightRect()
//
// Highlight a specific rectangle on the screen.
//
/////////////////////////////////////////////////////////////////////////////////////////////////
void CHighlight::HighlightRect(RECT rcBounds)
{
    // Always make sure the magnifier window is visible.
    ShowWindow(_hWndHost, SW_SHOWNOACTIVATE);

    // Tell the Magnification API which part of the screen we want magnified.
    MagSetWindowSource(_hWndMag, rcBounds);

    // Determine the size of the client area of the window required to show the magnified results.
    int cxHostClient = (int)(c_MagFactor * (rcBounds.right  - rcBounds.left));
    int cyHostClient = (int)(c_MagFactor * (rcBounds.bottom - rcBounds.top));

    // Determine the size of the window hosting the window showing the magnified 
    // results. (This accounts for the sytle of the host window frame.)
    RECT rcHost;                
    rcHost.left   = rcBounds.left;
    rcHost.top    = rcBounds.top;
    rcHost.right  = rcHost.left + cxHostClient;
    rcHost.bottom = rcHost.top + cyHostClient;

    AdjustWindowRectEx(&rcHost, 
                        GetWindowLong(_hWndHost, GWL_STYLE), 
                        FALSE, 
                        GetWindowLong(_hWndHost, GWL_EXSTYLE));

    int cxHostWindow = rcHost.right  - rcHost.left;
    int cyHostWindow = rcHost.bottom - rcHost.top;

    // When running a 64-bit Magnifier on a 64-bit machine, the following steps are 
    // required to generate the most reliable results. (Running a 32-bit Magnifier 
    // on a 64-bit machine often shows only blackness in the lens.)

    // Move and size the host window.
    SetWindowPos(_hWndHost, HWND_TOPMOST, 
                 (rcBounds.left   + rcBounds.right - cxHostWindow) / 2, 
                 (rcBounds.bottom + rcBounds.top   - cyHostWindow) / 2, 
                 cxHostWindow,  cyHostWindow, SWP_NOREDRAW | SWP_NOACTIVATE);

    // Resize the magnifier window. (It's always positioned as 0,0 as that's relative to the host window.)
    SetWindowPos(_hWndMag, NULL, 0, 0, cxHostClient, cyHostClient, SWP_NOZORDER | SWP_NOREDRAW | SWP_NOACTIVATE);

    // Refresh a child window of the Magnifier. This window is not 
    // created explicitly by the client of the Magnifier API.

    HWND hWndMagChild = GetWindow(_hWndMag, GW_CHILD);
    SetWindowPos(hWndMagChild, NULL, 0, 0, cxHostClient, cyHostClient, SWP_NOZORDER | SWP_NOREDRAW | SWP_NOACTIVATE);
    InvalidateRect(hWndMagChild, NULL, FALSE);
    UpdateWindow(hWndMagChild);

    // Finally refresh the Magnifier window now.
    InvalidateRect(_hWndMag, NULL, FALSE);    
}
