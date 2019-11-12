Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices.ComTypes
Imports System.Text

Namespace SolidEdge.AddIn.EdgeBar
	''' <summary>
	''' Base EdgeBar control. Provides core functionality.
	''' </summary>
	''' <remarks>
	''' Not intended to be directly created but rather inherited from.
	''' </remarks>
	Public Class EdgeBarControl
		Inherits System.Windows.Forms.UserControl
		Implements SolidEdgeFramework.ISEDocumentEvents

		Private _edgeBarPage As EdgeBarPage
		Private _connectionPointDictionary As New Dictionary(Of IConnectionPoint, Integer)()
		Private _tooltip As String = String.Empty
		Private _bitmapID As Integer

		Public Sub New()
			MyBase.New()
			InitializeComponent()
		End Sub

		Protected Overrides Sub Finalize()
			Dispose(False)
		End Sub

		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			MyBase.Dispose(disposing)

			If Not DesignMode Then
				UnhookAllEvents()
			End If
		End Sub

		Private Sub InitializeComponent()
			Me.SuspendLayout()
			' 
			' EdgeBarControl
			' 
			Me.Name = "EdgeBarControl"
			Me.Size = New System.Drawing.Size(256, 248)
			Me.ResumeLayout(False)

		End Sub

		Protected Overrides Sub OnCreateControl()
			MyBase.OnCreateControl()
			DoubleBuffered = True
		End Sub

		#Region "SolidEdgeFramework.ISEDocumentEvents"

		''' <summary>
		''' Virtual implementation of SolidEdgeFramework.ISEDocumentEvents.AfterSave().
		''' </summary>
		''' <remarks>
		''' Override in implementing class if you want to handle this event.
		''' </remarks>
		Public Overridable Sub AfterSave() Implements SolidEdgeFramework.ISEDocumentEvents.AfterSave
		End Sub

		''' <summary>
		''' Virtual implementation of SolidEdgeFramework.ISEDocumentEvents.BeforeClose().
		''' </summary>
		''' <remarks>
		''' Override in implementing class if you want to handle this event.
		''' </remarks>
		Public Overridable Sub BeforeClose() Implements SolidEdgeFramework.ISEDocumentEvents.BeforeClose
			UnhookAllEvents()
		End Sub

		''' <summary>
		''' Virtual implementation of SolidEdgeFramework.ISEDocumentEvents.BeforeSave().
		''' </summary>
		''' <remarks>
		''' Override in implementing class if you want to handle this event.
		''' </remarks>
		Public Overridable Sub BeforeSave() Implements SolidEdgeFramework.ISEDocumentEvents.BeforeSave
		End Sub

		''' <summary>
		''' Virtual implementation of SolidEdgeFramework.ISEDocumentEvents.SelectSetChanged().
		''' </summary>
		''' <remarks>
		''' Override in implementing class if you want to handle this event.
		''' </remarks>
		Public Overridable Sub SelectSetChanged(ByVal SelectSet As Object) Implements SolidEdgeFramework.ISEDocumentEvents.SelectSetChanged
		End Sub

		#End Region

		#Region "IConnectionPoint helpers"

		Private Sub HookEvents(ByVal eventSource As Object, ByVal eventGuid As Guid)
'INSTANT VB NOTE: The variable container was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim container_Renamed As IConnectionPointContainer = Nothing
			Dim connectionPoint As IConnectionPoint = Nothing
			Dim cookie As Integer = 0

			container_Renamed = CType(eventSource, IConnectionPointContainer)
			container_Renamed.FindConnectionPoint(eventGuid, connectionPoint)

			If connectionPoint IsNot Nothing Then
				connectionPoint.Advise(Me, cookie)
				_connectionPointDictionary.Add(connectionPoint, cookie)
			End If
		End Sub

		Private Sub UnhookAllEvents()
			Dim enumerator As Dictionary(Of IConnectionPoint, Integer).Enumerator = _connectionPointDictionary.GetEnumerator()
			Do While enumerator.MoveNext()
				enumerator.Current.Key.Unadvise(enumerator.Current.Value)
			Loop

			_connectionPointDictionary.Clear()
		End Sub

		#End Region

		#Region "Properties"

		<Browsable(False)> _
		Public Property EdgeBarPage() As EdgeBarPage
			Get
				Return _edgeBarPage
			End Get
			Set(ByVal value As EdgeBarPage)
				_edgeBarPage = value

				If (_edgeBarPage IsNot Nothing) AndAlso (_edgeBarPage.Document IsNot Nothing) Then
					If _edgeBarPage.Document IsNot Nothing Then
						HookEvents(_edgeBarPage.Document.DocumentEvents, GetType(SolidEdgeFramework.ISEDocumentEvents).GUID)
					End If
				End If
			End Set
		End Property

		<Browsable(False)> _
		Public ReadOnly Property Application() As SolidEdgeFramework.Application
			Get
				Return _edgeBarPage.Application
			End Get
		End Property

		<Browsable(False)> _
		Public ReadOnly Property Document() As SolidEdgeFramework.SolidEdgeDocument
			Get
				Return _edgeBarPage.Document
			End Get
		End Property

		''' <summary>
		''' The ID of the Bitmap to be used in the EdgeBarPage.
		''' </summary>
		''' <remarks>
		''' Win32 resources are located in the Resources.res file.
		''' </remarks>
		<Browsable(True)> _
		Public Property BitmapID() As Integer
			Get
				Return _bitmapID
			End Get
			Set(ByVal value As Integer)
				_bitmapID = value
			End Set
		End Property

		''' <summary>
		''' The string to be used in the EdgeBarPage caption and tooltip.
		''' </summary>
		<Browsable(True)> _
		Public Property ToolTip() As String
			Get
				Return _tooltip
			End Get
			Set(ByVal value As String)
				_tooltip = value
			End Set
		End Property

		#End Region
	End Class
End Namespace
