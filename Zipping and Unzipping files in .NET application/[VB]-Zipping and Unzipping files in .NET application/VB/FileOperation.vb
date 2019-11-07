Imports ComponentPro.IO

Namespace ArchiveManager
	''' <summary>
	''' A form that shows issues and let user decide what to do while uploading or download multiple files.
	''' </summary>
	Partial Public Class FileOperation
		Inherits Form
		Private _btns As Dictionary(Of System.Windows.Forms.Button, TransferConfirmNextActions) ' A list of Button with transfer action pair.
		Private ReadOnly _skipTypes As New Dictionary(Of TransferConfirmReason, Object)() ' Skipped transfer problem types.
		Private _oldEvt As TransferConfirmEventArgs ' Maintain the last event arguments.

		Private _overwriteAll As Boolean ' Overwrite all files?
		Private _overwriteOlder As Boolean ' Overwrite older files?
		Private _overwriteDifferentSize As Boolean ' Overwrite files that have different file size?

		''' <summary>
		''' Initializes a new instance of the class.
		''' </summary>
		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Initializes the form.
		''' </summary>
		Public Sub Init()
			If _btns Is Nothing Then
				_btns = New Dictionary(Of System.Windows.Forms.Button, TransferConfirmNextActions)()
				_btns.Add(btnOverwrite, TransferConfirmNextActions.Overwrite)
				_btns.Add(btnOverwriteAll, TransferConfirmNextActions.Overwrite)
				_btns.Add(btnOverwriteDiffSize, TransferConfirmNextActions.CheckAndOverwriteFilesWithDifferentSizes)
				_btns.Add(btnOverwriteOlder, TransferConfirmNextActions.CheckAndOverwriteOlderFiles)
				_btns.Add(btnRename, TransferConfirmNextActions.Rename)
				_btns.Add(btnSkip, TransferConfirmNextActions.Skip)
				_btns.Add(btnSkipAll, TransferConfirmNextActions.Skip)
				_btns.Add(btnFollowLink, TransferConfirmNextActions.FollowLink)
				_btns.Add(btnRetry, TransferConfirmNextActions.Retry)
				_btns.Add(btnCancel, TransferConfirmNextActions.Cancel)
			End If

			_skipTypes.Clear()
			_overwriteAll = False
			_overwriteOlder = False
			_overwriteDifferentSize = False
		End Sub

		''' <summary>
		''' Shows the form.
		''' </summary>
		''' <param name="parent">The parent form.</param>
		''' <param name="evt">The event arguments.</param>
		Public Overloads Sub Show(ByVal parent As Form, ByVal evt As TransferConfirmEventArgs)
			' If it's in the skipped type list, skip it.
			If _skipTypes.ContainsKey(evt.ConfirmReason) Then
				evt.NextAction = TransferConfirmNextActions.Skip
				Return
			End If

			' If the problem is file already exists?
			If evt.ConfirmReason = TransferConfirmReason.FileAlreadyExists Then
				' Overwrite all?
				If _overwriteAll Then
					evt.NextAction = TransferConfirmNextActions.Overwrite
					Return
				End If

				' Overwrite if files have different sizes?
				If _overwriteDifferentSize Then
					evt.NextAction = TransferConfirmNextActions.CheckAndOverwriteFilesWithDifferentSizes
					Return
				End If

				' Overwrite older files?
				If _overwriteOlder Then
					evt.NextAction = TransferConfirmNextActions.CheckAndOverwriteOlderFiles
					Return
				End If

				' format the text according to TransferState (Downloading or Uploading)
				Const messageFormat As String = Messages.OverwriteFileConfirm
				txtMessage.Text = String.Format(messageFormat, evt.DestinationFileInfo.FullName, evt.DestinationFileInfo.Length, evt.DestinationFileInfo.LastWriteTime, evt.SourceFileInfo.FullName, evt.SourceFileInfo.Length, evt.SourceFileInfo.LastWriteTime)
			Else
				' Show the exception message.
				txtMessage.Text = evt.Exception.Message

				If evt.Exception.InnerException IsNot Nothing Then
					txtMessage.Text &= vbCrLf & "Reason: " & evt.Exception.InnerException.Message
				End If
			End If

			_oldEvt = evt

			' Only show available action buttons.
			ArrangeButtons(evt)

			ShowDialog(parent)
		End Sub

		''' <summary>
		''' Arranges buttons.
		''' </summary>
		''' <param name="evt">The event arguments.</param>
		Private Sub ArrangeButtons(ByVal evt As TransferConfirmEventArgs)
			Dim buttonHeight As Integer = 0
			Dim y As Integer = txtMessage.Top

			For Each en As KeyValuePair(Of System.Windows.Forms.Button, TransferConfirmNextActions) In _btns
				Dim b As Boolean = evt.CanPerform(en.Value)
				en.Key.Visible = b
				If buttonHeight = 0 Then
					buttonHeight = en.Key.Height
				End If
				If Not b Then
					Continue For
				End If
				en.Key.Top = y
				y += buttonHeight + 3
			Next en
		End Sub

		''' <summary>
		''' Handles the Cancel button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
			_oldEvt.NextAction = TransferConfirmNextActions.Cancel
			Close()
		End Sub

		''' <summary>
		''' Handles the Skip button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnSkip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSkip.Click
			_oldEvt.NextAction = TransferConfirmNextActions.Skip
			Close()
		End Sub

		''' <summary>
		''' Handles the Skip All button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnSkipAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSkipAll.Click
			_skipTypes.Add(_oldEvt.ConfirmReason, Nothing)

			_oldEvt.NextAction = TransferConfirmNextActions.Skip
			Close()
		End Sub

		''' <summary>
		''' Handles the Retry button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnRetry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRetry.Click
			_oldEvt.NextAction = TransferConfirmNextActions.Retry
			Close()
		End Sub

		''' <summary>
		''' Handles the Rename button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnRename_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRename.Click
			Dim oldName As String = _oldEvt.DestinationFileSystem.GetFileName(_oldEvt.DestinationFileInfo.Name)
			Dim formNewName As New NewNamePrompt(oldName)

			Dim result As DialogResult = formNewName.ShowDialog(Me)

			Dim newName As String = formNewName.NewName

			If result <> System.Windows.Forms.DialogResult.OK OrElse newName.Length = 0 OrElse newName = oldName Then
				Return
			End If

			_oldEvt.NextAction = TransferConfirmNextActions.Rename
			_oldEvt.NewName = newName
			Close()
		End Sub

		''' <summary>
		''' Handles the Overwrite button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnOverwrite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOverwrite.Click
			_oldEvt.NextAction = TransferConfirmNextActions.Overwrite
			Close()
		End Sub

		''' <summary>
		''' Handles the OverwriteAll button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnOverwriteAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOverwriteAll.Click
			_oldEvt.NextAction = TransferConfirmNextActions.Overwrite
			_overwriteAll = True
			Close()
		End Sub

		''' <summary>
		''' Handles the OverwriteOlder button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnOverwriteOlder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOverwriteOlder.Click
			_oldEvt.NextAction = TransferConfirmNextActions.CheckAndOverwriteOlderFiles
			_overwriteOlder = True
			Close()
		End Sub

		''' <summary>
		''' Handles the OverwriteDiffSize button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnOverwriteDiffSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOverwriteDiffSize.Click
			_oldEvt.NextAction = TransferConfirmNextActions.CheckAndOverwriteFilesWithDifferentSizes
			_overwriteDifferentSize = True
			Close()
		End Sub

		''' <summary>
		''' Handles the Follow Link button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnFollowLink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFollowLink.Click
			_oldEvt.NextAction = TransferConfirmNextActions.FollowLink
			Close()
		End Sub
	End Class
End Namespace