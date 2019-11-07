Imports System.Runtime.InteropServices

Namespace SolidEdge.Part.FiniteExtrudedProtrusion
	''' <summary>
	''' Provides COM servers and applications with the ability to selectively handle incoming and outgoing COM
	''' messages while waiting for responses from synchronous calls.
	''' </summary>
	''' <remarks>http://msdn.microsoft.com/library/windows/desktop/ms693740.aspx</remarks>
	<ComImport, Guid("00000016-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
	Friend Interface IMessageFilter
		''' <summary>
		''' Provides a single entry point for incoming calls.
		''' </summary>
		''' <remarks>http://msdn.microsoft.com/library/windows/desktop/ms687237.aspx</remarks>
		<PreserveSig> _
		Function HandleInComingCall(ByVal dwCallType As Integer, ByVal hTaskCaller As IntPtr, ByVal dwTickCount As Integer, ByVal lpInterfaceInfo As IntPtr) As Integer

		''' <summary>
		''' Indicates that a message has arrived while COM is waiting to respond to a remote call.
		''' </summary>
		''' <remarks>http://msdn.microsoft.com/library/windows/desktop/ms694352.aspx</remarks>
		<PreserveSig> _
		Function MessagePending(ByVal hTaskCallee As IntPtr, ByVal dwTickCount As Integer, ByVal dwPendingType As Integer) As Integer

		''' <summary>
		''' Provides applications with an opportunity to display a dialog box offering retry, cancel, or task-switching options.
		''' </summary>
		''' <remarks>http://msdn.microsoft.comlibrary/windows/desktop/ms680739.aspx</remarks>
		<PreserveSig> _
		Function RetryRejectedCall(ByVal hTaskCallee As IntPtr, ByVal dwTickCount As Integer, ByVal dwRejectType As Integer) As Integer
	End Interface
End Namespace
