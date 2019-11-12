Imports System.Runtime.InteropServices

Namespace SolidEdge.Assembly.Relations3d
	''' <summary>
	''' Static class containing PInvoke signatures.
	''' </summary>
	Friend NotInheritable Class NativeMethods

		Private Sub New()
		End Sub
		#Region "ObjIdl.h"

		Friend Enum SERVERCALL
			SERVERCALL_ISHANDLED = 0
			SERVERCALL_REJECTED = 1
			SERVERCALL_RETRYLATER = 2
		End Enum

		Friend Enum PENDINGMSG
			PENDINGMSG_CANCELCALL = 0
			PENDINGMSG_WAITNOPROCESS = 1
			PENDINGMSG_WAITDEFPROCESS = 2
		End Enum

		#End Region

		#Region "WinError.h"

		Friend Const MK_E_UNAVAILABLE As Integer = CInt(&H800401E3L - &H100000000)
		Friend Const CO_E_NOT_SUPPORTED As Integer = CInt(&H80004021L - &H100000000)

		#End Region

		<DllImport("Ole32.dll")> _
		Friend Shared Function CoRegisterMessageFilter(ByVal newFilter As IMessageFilter, ByRef oldFilter As IMessageFilter) As Integer
		End Function
	End Class

	<Guid("00020400-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
	Public Interface IDispatch
		Function GetIDsOfNames(ByRef riid As Guid, ByVal rgsNames() As String, ByVal cNames As Integer, ByVal lcid As Integer, ByVal rgDispId() As Integer) As Integer
		Function GetTypeInfo(ByVal iTInfo As Integer, ByVal lcid As Integer) As System.Runtime.InteropServices.ComTypes.ITypeInfo
		Function GetTypeInfoCount() As Integer
		Function Invoke() As Integer
	End Interface
End Namespace
