//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: NativeMethods.cs
//
//  Description: Win32 P/Invoke methods and values
// 
//--------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
{
	/// <summary>P/Invoke methods and values.</summary>
	[SuppressUnmanagedCodeSecurity]
	internal static class NativeMethods
	{
		/// <summary>The GetWindowPlacement function retrieves the show state and the restored, minimized, and maximized positions of the specified window.</summary>
		/// <param name="hWnd">Handle to the window.</param>
		/// <param name="placement">Pointer to the WINDOWPLACEMENT structure that receives the show state and position information.</param>
		/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
		[DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetWindowPlacement(HandleRef hWnd, ref WINDOWPLACEMENT placement);

		/// <summary>The WINDOWPLACEMENT structure contains information about the placement of a window on the screen.</summary>
		[StructLayout(LayoutKind.Sequential)]
			internal struct WINDOWPLACEMENT
		{
			/// <summary>Specifies the length, in bytes, of the structure.</summary>
			public int length;
			/// <summary>Specifies flags that control the position of the minimized window and the method by which the window is restored.</summary>
			public int flags;
			/// <summary>Specifies the current show state of the window.</summary>
			public int showCmd;
			/// <summary>Specifies the X coordinate of the window's upper-left corner when the window is minimized.</summary>
			public int ptMinPosition_x;
			/// <summary>Specifies the Y coordinate of the window's upper-left corner when the window is minimized.</summary>
			public int ptMinPosition_y;
			/// <summary>Specifies the X coordinate of the window's upper-left corner when the window is maximized.</summary>
			public int ptMaxPosition_x;
			/// <summary>Specifies the Y coordinate of the window's upper-left corner when the window is maximized.</summary>
			public int ptMaxPosition_y;
			/// <summary>Specifies the window's left coordinate when the window is in the restored position.</summary>
			public int rcNormalPosition_left;
			/// <summary>Specifies the window's top coordinate when the window is in the restored position.</summary>
			public int rcNormalPosition_top;
			/// <summary>Specifies the window's right coordinate when the window is in the restored position.</summary>
			public int rcNormalPosition_right;
			/// <summary>Specifies the window's bottom coordinate when the window is in the restored position.</summary>
			public int rcNormalPosition_bottom;
		}

        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int Left;
            public int Right;
            public int Top;
            public int Bottom;
        }

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(
           IntPtr hWnd,
           ref MARGINS pMarInset
        );

        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern bool DwmIsCompositionEnabled();
	}
}