Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.AddIn.EdgeBar
	Friend NotInheritable Class NativeMethods

		Private Sub New()
		End Sub
		<DllImport("user32.dll", SetLastError := True)> _
		Friend Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
		End Function

		<DllImport("user32.dll")> _
		Friend Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As ShowWindowCommands) As <MarshalAs(UnmanagedType.Bool)> Boolean
		End Function
	End Class

	<Guid("00020400-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
	Public Interface IDispatch
		Function GetIDsOfNames(ByRef riid As Guid, ByVal rgsNames() As String, ByVal cNames As Integer, ByVal lcid As Integer, ByVal rgDispId() As Integer) As Integer
		Function GetTypeInfo(ByVal iTInfo As Integer, ByVal lcid As Integer) As System.Runtime.InteropServices.ComTypes.ITypeInfo
		Function GetTypeInfoCount() As Integer
		Function Invoke() As Integer
	End Interface

	Friend Enum ShowWindowCommands As Integer
		''' <summary>
		''' Hides the window and activates another window.
		''' </summary>
		Hide = 0
		''' <summary>
		''' Activates and displays a window. If the window is minimized or 
		''' maximized, the system restores it to its original size and position.
		''' An application should specify this flag when displaying the window 
		''' for the first time.
		''' </summary>
		Normal = 1
		''' <summary>
		''' Activates the window and displays it as a minimized window.
		''' </summary>
		ShowMinimized = 2
		''' <summary>
		''' Maximizes the specified window.
		''' </summary>
		Maximize = 3 ' is this the right value?
		''' <summary>
		''' Activates the window and displays it as a maximized window.
		''' </summary>       
		ShowMaximized = 3
		''' <summary>
		''' Displays a window in its most recent size and position. This value 
		''' is similar to <see cref="Win32.ShowWindowCommand.Normal"/>, except 
		''' the window is not activated.
		''' </summary>
		ShowNoActivate = 4
		''' <summary>
		''' Activates the window and displays it in its current size and position. 
		''' </summary>
		Show = 5
		''' <summary>
		''' Minimizes the specified window and activates the next top-level 
		''' window in the Z order.
		''' </summary>
		Minimize = 6
		''' <summary>
		''' Displays the window as a minimized window. This value is similar to
		''' <see cref="Win32.ShowWindowCommand.ShowMinimized"/>, except the 
		''' window is not activated.
		''' </summary>
		ShowMinNoActive = 7
		''' <summary>
		''' Displays the window in its current size and position. This value is 
		''' similar to <see cref="Win32.ShowWindowCommand.Show"/>, except the 
		''' window is not activated.
		''' </summary>
		ShowNA = 8
		''' <summary>
		''' Activates and displays the window. If the window is minimized or 
		''' maximized, the system restores it to its original size and position. 
		''' An application should specify this flag when restoring a minimized window.
		''' </summary>
		Restore = 9
		''' <summary>
		''' Sets the show state based on the SW_* value specified in the 
		''' STARTUPINFO structure passed to the CreateProcess function by the 
		''' program that started the application.
		''' </summary>
		ShowDefault = 10
		''' <summary>
		'''  <b>Windows 2000/XP:</b> Minimizes a window, even if the thread 
		''' that owns the window is not responding. This flag should only be 
		''' used when minimizing windows from a different thread.
		''' </summary>
		ForceMinimize = 11
	End Enum
End Namespace
