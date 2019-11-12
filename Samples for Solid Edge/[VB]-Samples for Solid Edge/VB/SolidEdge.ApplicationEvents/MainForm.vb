Imports System.ComponentModel
Imports System.Text
Imports System.Runtime.InteropServices.ComTypes
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Reflection

Namespace SolidEdge.ApplicationEvents
	Partial Public Class MainForm
		Inherits Form
		Implements SolidEdgeFramework.ISEApplicationEvents

		Private _application As SolidEdgeFramework.Application = Nothing
		Private _connectionPoints As New Dictionary(Of IConnectionPoint, Integer)()

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Register with OLE to handle concurrency issues on the current thread.
			OleMessageFilter.Register()
		End Sub

		Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			' Unhook events.
			UnhookEvents()
			_application = Nothing
		End Sub

		Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
			Close()
		End Sub

		Private Sub eventButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles eventButton.Click
			Try
				If eventButton.Checked Then
					If _application Is Nothing Then
						_application = SolidEdgeUtils.Connect(True)
						_application.Visible = True
					End If

					HookEvents(_application, GetType(SolidEdgeFramework.ISEApplicationEvents).GUID)
				Else
					UnhookEvents()
					_application = Nothing
				End If
			Catch ex As System.Exception
				MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub clearButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearButton.Click
			eventLogTextBox.Clear()
		End Sub

		#Region "SolidEdgeFramework.ISEApplicationEvents"

		' Note: Events are fired in a background thread. You cannot update the UI
		' "directly" from a background thread. See ControlExtensions.Do().
		' Thread.CurrentThread.GetApartmentState() will always be ApartmentState.MTA.
		' OleMessageFilter is not in effect in this thread for two reasons. 1) It's a
		' different thread. 2) It can't be because the ApartmentState = MTA.

		Public Sub AfterActiveDocumentChange(ByVal theDocument As Object) Implements SolidEdgeFramework.ISEApplicationEvents.AfterActiveDocumentChange
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theDocument)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		Public Sub AfterCommandRun(ByVal theCommandID As Integer) Implements SolidEdgeFramework.ISEApplicationEvents.AfterCommandRun
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theCommandID)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		Public Sub AfterDocumentOpen(ByVal theDocument As Object) Implements SolidEdgeFramework.ISEApplicationEvents.AfterDocumentOpen
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theDocument)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		Public Sub AfterDocumentPrint(ByVal theDocument As Object, ByVal hDC As Integer, ByRef ModelToDC As Double, ByRef Rect As Integer) Implements SolidEdgeFramework.ISEApplicationEvents.AfterDocumentPrint
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1}, {2}, {3}, {4})", MethodBase.GetCurrentMethod().Name, theDocument, hDC, ModelToDC, Rect)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		Public Sub AfterDocumentSave(ByVal theDocument As Object) Implements SolidEdgeFramework.ISEApplicationEvents.AfterDocumentSave
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theDocument)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		Public Sub AfterEnvironmentActivate(ByVal theEnvironment As Object) Implements SolidEdgeFramework.ISEApplicationEvents.AfterEnvironmentActivate
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theEnvironment)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		Public Sub AfterNewDocumentOpen(ByVal theDocument As Object) Implements SolidEdgeFramework.ISEApplicationEvents.AfterNewDocumentOpen
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theDocument)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		Public Sub AfterNewWindow(ByVal theWindow As Object) Implements SolidEdgeFramework.ISEApplicationEvents.AfterNewWindow
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theWindow)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		Public Sub AfterWindowActivate(ByVal theWindow As Object) Implements SolidEdgeFramework.ISEApplicationEvents.AfterWindowActivate
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theWindow)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		Public Sub BeforeCommandRun(ByVal theCommandID As Integer) Implements SolidEdgeFramework.ISEApplicationEvents.BeforeCommandRun
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theCommandID)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		Public Sub BeforeDocumentClose(ByVal theDocument As Object) Implements SolidEdgeFramework.ISEApplicationEvents.BeforeDocumentClose
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theDocument)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		Public Sub BeforeDocumentPrint(ByVal theDocument As Object, ByVal hDC As Integer, ByRef ModelToDC As Double, ByRef Rect As Integer) Implements SolidEdgeFramework.ISEApplicationEvents.BeforeDocumentPrint
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1}, {2}, {3}, {4})", MethodBase.GetCurrentMethod().Name, theDocument, hDC, ModelToDC, Rect)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		Public Sub BeforeDocumentSave(ByVal theDocument As Object) Implements SolidEdgeFramework.ISEApplicationEvents.BeforeDocumentSave
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theDocument)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		Public Sub BeforeEnvironmentDeactivate(ByVal theEnvironment As Object) Implements SolidEdgeFramework.ISEApplicationEvents.BeforeEnvironmentDeactivate
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theEnvironment)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		Public Sub BeforeQuit() Implements SolidEdgeFramework.ISEApplicationEvents.BeforeQuit
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}()", MethodBase.GetCurrentMethod().Name)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))

			UnhookEvents()
			_application = Nothing
		End Sub

		Public Sub BeforeWindowDeactivate(ByVal theWindow As Object) Implements SolidEdgeFramework.ISEApplicationEvents.BeforeWindowDeactivate
			Dim sb As New StringBuilder()
			sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theWindow)
			sb.AppendLine()

			eventLogTextBox.Do(Sub(ctl) ctl.AppendText(sb.ToString()))
		End Sub

		#End Region

		#region "Event hooking-unhooking"

		Private Sub HookEvents(ByVal source As Object, ByVal eventGuid As Guid)
			Dim connectionPointContainer As IConnectionPointContainer = Nothing
			Dim connectionPoint As IConnectionPoint = Nothing
			Dim cookie As Integer = 0

			connectionPointContainer = TryCast(source, IConnectionPointContainer)
			If connectionPointContainer IsNot Nothing Then
				connectionPointContainer.FindConnectionPoint(eventGuid, connectionPoint)
				If connectionPoint IsNot Nothing Then
					connectionPoint.Advise(Me, cookie)
					If cookie <> 0 Then
						_connectionPoints.Add(connectionPoint, cookie)
					Else
						Throw New System.Exception("Advisory connection between the connection point and the caller's sink object failed.")
					End If
				Else
					Throw New System.Exception(String.Format("Connection point '{0}' not found.", eventGuid))
				End If
			Else
				Throw New System.Exception("Source does not implement IConnectionPointContainer.")
			End If

		End Sub

		Private Sub UnhookEvents()
			Dim enumerator As Dictionary(Of IConnectionPoint, Integer).Enumerator = _connectionPoints.GetEnumerator()

			Do While enumerator.MoveNext()
				enumerator.Current.Key.Unadvise(enumerator.Current.Value)
			Loop

			_connectionPoints.Clear()
		End Sub

		#End Region
	End Class
End Namespace
