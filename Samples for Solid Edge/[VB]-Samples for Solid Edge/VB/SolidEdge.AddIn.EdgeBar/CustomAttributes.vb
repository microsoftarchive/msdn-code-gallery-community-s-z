Namespace SolidEdge.AddIn.EdgeBar
	''' <summary>
	''' Set AutoConnect DWORD flag. If true, addin be enabled by default.
	''' </summary>
	<AttributeUsage(AttributeTargets.Class, AllowMultiple := False)> _
	Public Class AddInAutoConnectAttribute
		Inherits System.Attribute

		Private _autoConnect As Boolean = True

		Public Sub New()
			Me.New(True)
		End Sub

		Public Sub New(ByVal autoConnect As Boolean)
			_autoConnect = autoConnect
		End Sub

		Public ReadOnly Property AutoConnect() As Boolean
			Get
				Return _autoConnect
			End Get
		End Property
	End Class

	''' <summary>
	''' Environment Categories the addin is registered to.
	''' </summary>
	<AttributeUsage(AttributeTargets.Class, AllowMultiple := True)> _
	Public Class AddInEnvironmentCategoryAttribute
		Inherits System.Attribute

		Private _guid As Guid = Guid.Empty

		Public Sub New(ByVal guid As String)
			Me.New(New Guid(guid))
		End Sub

		Public Sub New(ByVal guid As Guid)
			_guid = guid
		End Sub

		Public ReadOnly Property Guid() As Guid
			Get
				Return _guid
			End Get
		End Property
	End Class

	''' <summary>
	''' Information about the addin.
	''' </summary>
	<AttributeUsage(AttributeTargets.Class, AllowMultiple := False)> _
	Public Class AddInInfoAttribute
		Inherits System.Attribute

		Private _title As String = String.Empty
		Private _summary As String = String.Empty

		Public Sub New(ByVal title As String, ByVal summary As String)
			_title = title
			_summary = summary
		End Sub

		Public ReadOnly Property Title() As String
			Get
				Return _title
			End Get
		End Property
		Public ReadOnly Property Summary() As String
			Get
				Return _summary
			End Get
		End Property
	End Class
End Namespace
