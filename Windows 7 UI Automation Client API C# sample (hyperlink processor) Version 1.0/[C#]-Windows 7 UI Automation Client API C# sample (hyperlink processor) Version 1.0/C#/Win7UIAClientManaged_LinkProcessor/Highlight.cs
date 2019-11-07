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

// Highlight.cs: Provides a way for the sample application to highlight where a hyperlink
// is on the screen. For this sample, the Windows Magnification API is used to apply a %400
// magnification to the hyperlink, and to apply colour inversion.

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Win7UIAClientManaged
{
    class Highlight
    {
        IntPtr _hwndHost = IntPtr.Zero;
        IntPtr _hwndMag  = IntPtr.Zero;

        private float c_MagFactor = 4.0F; 

        // Use a static member for the Magnification window wndproc to prevent the delegate from getting garbage collected.
        private static Win32.WndProc _wndProc = new Win32.WndProc(HostWndProc);

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Initialize()
        //
        // Create the magnification window.
        //
        // Runs on the main UI thread.
        //
        /////////////////////////////////////////////////////////////////////////////////////////////////
        public void Initialize()
        {
            // Initialize the Magnifier components.
            if (Win32.MagInitialize())
            {
                // Now create the windows required to show magnified results.
                CreateMagnifier();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Uninitialize()
        //
        // Release all objects created on startup.
        //
        // Runs on the main UI thread.
        //
        /////////////////////////////////////////////////////////////////////////////////////////////////
        public void Uninitialize()
        {
            if (_hwndHost != IntPtr.Zero)
            {
                // _hwndMag is a child of _hWndHost and will automatically get destroyed.
                Win32.DestroyWindow(_hwndHost);
                _hwndHost = IntPtr.Zero;
            }

            // Uninitialize the Magnifier components.
            Win32.MagUninitialize();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // HostWndProc()
        //
        // WndProc for the Magnification window.
        //
        // Runs on the main UI thread.
        //
        /////////////////////////////////////////////////////////////////////////////////////////////////
        public static IntPtr HostWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            return Win32.DefWindowProc(hWnd, msg, wParam, lParam);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // CreateMagnifier()
        //
        // Create the magnification window which will present the magnified results.
        //
        // Runs on the main UI thread.
        //
        /////////////////////////////////////////////////////////////////////////////////////////////////
        private void CreateMagnifier()
        {
            // First we create a regular window which will host the window showing the magnified results.
            string strWindowClassName = "UIASampleHighlightClass";

            // First register the host window class.
            Win32.WNDCLASSEX wcex = new Win32.WNDCLASSEX();
            wcex.cbSize         = (uint)Marshal.SizeOf(wcex);
            wcex.lpfnWndProc    = _wndProc;
            wcex.hInstance      = Win32.GetModuleHandle(null);
            wcex.lpszClassName  = strWindowClassName;
            wcex.hCursor        = IntPtr.Zero; // A shipping app would use a known cursor here.
            wcex.hbrBackground  = IntPtr.Zero;

            wcex.style = 0;
            wcex.cbClsExtra = 0;
            wcex.cbWndExtra = 0;
            wcex.hIcon = IntPtr.Zero;
            wcex.lpszMenuName = null;
            wcex.hIconSm = IntPtr.Zero;

            if (Win32.RegisterClassEx(ref wcex) != 0)
            {
                // Now create the host window. (Note that if a UIA client were to access the window itself, 
                // the window name will be exposed through UIA as the element name for the host window.)
                _hwndHost = Win32.CreateWindowEx(Win32.WindowStylesEx.WS_EX_TOPMOST | Win32.WindowStylesEx.WS_EX_LAYERED | Win32.WindowStylesEx.WS_EX_TOOLWINDOW,  
                                                 strWindowClassName, 
                                                 "UIASample Highlight Host Window",
                                                 Win32.WindowStyles.WS_POPUP | Win32.WindowStyles.WS_THICKFRAME | Win32.WindowStyles.WS_CLIPCHILDREN,
                                                 0, 0, 0, 0, 
                                                 IntPtr.Zero, 
                                                 IntPtr.Zero,
                                                 wcex.hInstance, 
                                                 IntPtr.Zero);
                if (_hwndHost != IntPtr.Zero)
                {
                    Win32.SetLayeredWindowAttributes(_hwndHost, 0, 0xFF, Win32.LWA_ALPHA);

                    // Create a magnifier control that fills the client area of the host window. 
                    _hwndMag = Win32.CreateWindowEx(0, 
                                                    Win32.WC_MAGNIFIER, "UIASample Highlight Magnification Window", 
                                                    Win32.WindowStyles.MS_SHOWMAGNIFIEDCURSOR | Win32.WindowStyles.MS_INVERTCOLORS | 
                                                        Win32.WindowStyles.WS_CHILD | Win32.WindowStyles.WS_VISIBLE,
                                                    0, 0, 0, 0, _hwndHost, IntPtr.Zero, wcex.hInstance, IntPtr.Zero);
                    if (_hwndMag != IntPtr.Zero)
                    {
                        // For this sample, the magnification factor is fixed at 400%. So we need to
                        // apply that transform only once. If the sample allowed the magnification 
                        // factor to change, then MagSetWindowTransform() would need to be called 
                        // whenever the factor changed.
                        Win32.MagTransform magTransform = new Win32.MagTransform(c_MagFactor);
                        Win32.MagSetWindowTransform(_hwndMag, ref magTransform);
                    }
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Clear()
        //
        // Remove any current highlighting.
        //
        // Runs on the whatever thread is's called on.
        //
        /////////////////////////////////////////////////////////////////////////////////////////////////
        public void Clear()
        {
            // Simply hide the host window.
            Win32.ShowWindow(_hwndHost, Win32.ShowWindowCommands.Hide);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // HighlightRect()
        //
        // Highlight a specific reactngle on the screen.
        //
        // Runs on the whatever thread is's called on.
        //
        /////////////////////////////////////////////////////////////////////////////////////////////////
        public void HighlightRect(Rectangle rectHighlight)
        {
            Win32.RECT rcHighlight;
            rcHighlight.left   = rectHighlight.Left;
            rcHighlight.top    = rectHighlight.Top;
            rcHighlight.right  = rectHighlight.Right;
            rcHighlight.bottom = rectHighlight.Bottom;

            // Always make sure the magnifier window is visible.
            Win32.ShowWindow(_hwndHost, Win32.ShowWindowCommands.ShowNoActivate);

            // Tell the Magnification API which part of the screen we want magnified.
            Win32.MagSetWindowSource(_hwndMag, rcHighlight);

            // Determine the size of the client area of the window required to show the magnified results.
            int cxHostClient = (int)(c_MagFactor * (rcHighlight.right  - rcHighlight.left));
            int cyHostClient = (int)(c_MagFactor * (rcHighlight.bottom - rcHighlight.top));

            // Determine the size of the window hosting the window showing the magnified 
            // results. (This accounts for the sytle of the host window frame.)
            Win32.RECT rcHost;
            rcHost.left   = rcHighlight.left;
            rcHost.top    = rcHighlight.top;
            rcHost.right  = rcHost.left + cxHostClient;
            rcHost.bottom = rcHost.top + cyHostClient;

            Win32.AdjustWindowRectEx(ref rcHost, 
                                     Win32.GetWindowLong(_hwndHost, Win32.GWL_STYLE), 
                                     false,
                                     Win32.GetWindowLong(_hwndHost, Win32.GWL_EXSTYLE));

            int cxHostWindow = rcHost.right  - rcHost.left;
            int cyHostWindow = rcHost.bottom - rcHost.top;

            // When running a 64-bit Magnifier on a 64-bit machine, the following steps are 
            // required to generate the most reliable results. (Running a 32-bit Magnifier 
            // on a 64-bit machine often shows only blackness in the lens.)

            // First move and size the host window.
            IntPtr ipHwndTopMost = (IntPtr)(-1);

            Win32.SetWindowPos(_hwndHost, ipHwndTopMost, 
                         (rcHighlight.left   + rcHighlight.right - cxHostWindow) / 2, 
                         (rcHighlight.bottom + rcHighlight.top   - cyHostWindow) / 2, 
                         cxHostWindow,  cyHostWindow,
                         Win32.SWP_NOREDRAW | Win32.SWP_NOACTIVATE);

            // Resize the magnifier window. (It's always positioned as 0,0 as that's relative to the host window.)
            Win32.SetWindowPos(_hwndMag, IntPtr.Zero, 0, 0, cxHostClient, cyHostClient, 
                               Win32.SWP_NOZORDER | Win32.SWP_NOREDRAW | Win32.SWP_NOACTIVATE);

            // Refresh a child window of the Magnifier. This window is not 
            // created explicitly by the client of the Magnifier API.

            IntPtr hwndMagChild = Win32.GetWindow(_hwndMag, Win32.GetWindow_Cmd.GW_CHILD);
            Win32.SetWindowPos(hwndMagChild, IntPtr.Zero, 0, 0, cxHostClient, cyHostClient, 
                               Win32.SWP_NOZORDER | Win32.SWP_NOREDRAW | Win32.SWP_NOACTIVATE);
            Win32.InvalidateRect(hwndMagChild, IntPtr.Zero, false);
            Win32.UpdateWindow(hwndMagChild);

            // Finally refresh the Magnifier window now.
            Win32.InvalidateRect(_hwndMag, IntPtr.Zero, false);    
        }
    }
}
