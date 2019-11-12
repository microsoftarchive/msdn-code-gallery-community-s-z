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

// Win32.cs : Provides the interop details for this sample app to call Win32 APIs.

using System;
using System.Runtime.InteropServices;

namespace Win7UIAClientManaged
{
    public class Win32
    {
        // FindWindow() is used by the LinkProcessor and SampleEventHandler to finds a browser window.

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String sClassName, String sAppName);

        // *** The remainder of this class is only used for Magnification. ***
        // This sample is not consistent in some of its interop action, (eg sometimes using
        // enums and sometimes using const ints.) A shipping app would want to be consistent
        // in its interop usage.

        [DllImport("Magnification.dll")] 
        public static extern bool MagInitialize();

        [DllImport("Magnification.dll")] 
        public static extern bool MagUninitialize();

        [DllImport("Magnification.dll")]
        public static extern bool MagSetWindowTransform(IntPtr hwnd, ref MagTransform pTransform);

        [DllImport("Magnification.dll")]
        public static extern bool MagSetWindowSource(IntPtr hwnd, RECT rect);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string strModuleName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.U2)]
        public static extern short RegisterClassEx([In] ref WNDCLASSEX lpwcx);

        [DllImport("user32.dll")]
        public static extern IntPtr CreateWindowEx(
           WindowStylesEx dwExStyle,
           string lpClassName,
           string lpWindowName,
           WindowStyles dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           IntPtr lpParam);

        [DllImport("user32.dll")]
        public static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

        [DllImport("user32.dll")]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll")]
        public static extern bool AdjustWindowRectEx(ref RECT lpRect, uint dwStyle, bool bMenu, uint dwExStyle);

        [DllImport("user32.dll")]
        public static extern System.UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, GetWindow_Cmd uCmd);

        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("user32.dll")]
        public static extern bool UpdateWindow(IntPtr hWnd);

        public const string WC_MAGNIFIER = "Magnifier";

        public const uint LWA_ALPHA = 0x00000002;
        
        public delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        public const int GWL_STYLE = -16;
        public const int GWL_EXSTYLE = -20;

        public const int SWP_NOZORDER = 0x0004;
        public const int SWP_NOREDRAW = 0x0008;
        public const int SWP_NOACTIVATE = 0x0010;

        public enum GetWindow_Cmd : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WNDCLASSEX
        {
            public uint cbSize;
            public uint style;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public WndProc lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
            public IntPtr hIconSm;
        }

        public enum WindowStyles : uint
        {
            WS_POPUP = 0x80000000,
            WS_THICKFRAME = 0x00040000,
            WS_CLIPCHILDREN = 0x02000000,
            WS_VISIBLE = 0x10000000,
            WS_CHILD = 0x40000000,
            MS_SHOWMAGNIFIEDCURSOR = 0x0001,
            MS_INVERTCOLORS = 0x0004
        }

        public enum WindowStylesEx : uint
        {
            WS_EX_TOPMOST = 0x00000008,
            WS_EX_LAYERED = 0x00080000,
            WS_EX_TOOLWINDOW = 0x00000080
        }

        public enum ShowWindowCommands : int
        {
            Hide = 0,
            Normal = 1,
            ShowMinimized = 2,
            ShowMaximized = 3,
            ShowNoActivate = 4,
            Show = 5,
            Minimize = 6,
            ShowMinNoActive = 7,
            ShowNA = 8,
            Restore = 9,
            ShowDefault = 10,
            ForceMinimize = 11
        }

        public struct MagTransform
        {
            private float m00;
            private float m10;
            private float m20;
            private float m01;
            private float m11;
            private float m21;
            private float m02;
            private float m12;
            private float m22;

            public MagTransform(float magnificationFactor)
            {
                m10 = 0;
                m20 = 0;
                m01 = 0;
                m21 = 0;
                m02 = 0;
                m12 = 0;

                m00 = magnificationFactor;
                m11 = magnificationFactor;
                m22 = 1.0f;
            }
        }
    }
}
