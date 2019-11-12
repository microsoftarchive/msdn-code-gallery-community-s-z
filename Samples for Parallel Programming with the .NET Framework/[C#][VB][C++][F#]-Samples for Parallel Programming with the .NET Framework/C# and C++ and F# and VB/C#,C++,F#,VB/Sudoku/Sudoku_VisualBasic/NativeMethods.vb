'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: NativeMethods.vb
'
'  Description: Win32 P/Invoke methods and values
' 
'--------------------------------------------------------------------------

Imports System.Runtime.InteropServices
Imports System.Security

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
	''' <summary>P/Invoke methods and values.</summary>
	<SuppressUnmanagedCodeSecurity>
	Friend NotInheritable Class NativeMethods
		''' <summary>The GetWindowPlacement function retrieves the show state and the restored, minimized, and maximized positions of the specified window.</summary>
		''' <param name="hWnd">Handle to the window.</param>
		''' <param name="placement">Pointer to the WINDOWPLACEMENT structure that receives the show state and position information.</param>
		''' <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
		<DllImport("user32.dll", CharSet:=CharSet.Auto, ExactSpelling:=True)>
		Friend Shared Function GetWindowPlacement(ByVal hWnd As HandleRef, ByRef placement As WINDOWPLACEMENT) As <MarshalAs(UnmanagedType.Bool)> Boolean
		End Function

		''' <summary>The WINDOWPLACEMENT structure contains information about the placement of a window on the screen.</summary>
		<StructLayout(LayoutKind.Sequential)>
		Friend Structure WINDOWPLACEMENT
			''' <summary>Specifies the length, in bytes, of the structure.</summary>
			Public length As Integer
			''' <summary>Specifies flags that control the position of the minimized window and the method by which the window is restored.</summary>
			Public flags As Integer
			''' <summary>Specifies the current show state of the window.</summary>
			Public showCmd As Integer
			''' <summary>Specifies the X coordinate of the window's upper-left corner when the window is minimized.</summary>
			Public ptMinPosition_x As Integer
			''' <summary>Specifies the Y coordinate of the window's upper-left corner when the window is minimized.</summary>
			Public ptMinPosition_y As Integer
			''' <summary>Specifies the X coordinate of the window's upper-left corner when the window is maximized.</summary>
			Public ptMaxPosition_x As Integer
			''' <summary>Specifies the Y coordinate of the window's upper-left corner when the window is maximized.</summary>
			Public ptMaxPosition_y As Integer
			''' <summary>Specifies the window's left coordinate when the window is in the restored position.</summary>
			Public rcNormalPosition_left As Integer
			''' <summary>Specifies the window's top coordinate when the window is in the restored position.</summary>
			Public rcNormalPosition_top As Integer
			''' <summary>Specifies the window's right coordinate when the window is in the restored position.</summary>
			Public rcNormalPosition_right As Integer
			''' <summary>Specifies the window's bottom coordinate when the window is in the restored position.</summary>
			Public rcNormalPosition_bottom As Integer
		End Structure

		<StructLayout(LayoutKind.Sequential)>
		Public Structure MARGINS
			Public Left As Integer
			Public Right As Integer
			Public Top As Integer
			Public Bottom As Integer
		End Structure

		<DllImport("dwmapi.dll")>
		Public Shared Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarInset As MARGINS) As Integer
		End Function

		<DllImport("dwmapi.dll", PreserveSig := False)>
		Public Shared Function DwmIsCompositionEnabled() As Boolean
		End Function
	End Class
End Namespace