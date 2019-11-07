Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Net
Imports Proshot.CommandClient
Imports Proshot.UtilityLib.CommonDialogs



Public Partial Class frmMain
	Inherits Form
	Private client As Proshot.CommandClient.CMDClient
	Private privateWindowsList As System.Collections.Generic.List(Of frmPrivate)
	Public Sub New()
		InitializeComponent()
		Me.privateWindowsList = New List(Of frmPrivate)()
		Me.client = New Proshot.CommandClient.CMDClient(IPAddress.Parse("127.0.0.1"), 8000, "None")
	End Sub

	Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
		If keyData = Keys.Enter Then
			Me.SendMessage()
		End If
		If Me.txtMessages.Focused AndAlso Not ShareUtils.IsValidKeyForReadOnlyFields(keyData) Then
			Return True
		End If
		Return MyBase.ProcessCmdKey(msg, keyData)
	End Function
	Private Function IsPrivateWindowOpened(remoteName As String) As Boolean
		For Each privateWindow As frmPrivate In Me.privateWindowsList
			If privateWindow.RemoteName = remoteName Then
				Return True
			End If
		Next
		Return False
	End Function
	Private Function FindPrivateWindow(remoteName As String) As frmPrivate
		For Each privateWindow As frmPrivate In Me.privateWindowsList
			If privateWindow.RemoteName = remoteName Then
				Return privateWindow
			End If
		Next
		Return Nothing
	End Function
	Private Sub client_CommandReceived(sender As Object, e As CommandEventArgs)
		Select Case e.Command.CommandType
			Case (CommandType.Message)
				If e.Command.Target.Equals(IPAddress.Broadcast) Then
					Me.txtMessages.Text += Convert.ToString(e.Command.SenderName) & ": " & Convert.ToString(e.Command.MetaData) & Environment.NewLine
				ElseIf Not Me.IsPrivateWindowOpened(e.Command.SenderName) Then
					Me.OpenPrivateWindow(e.Command.SenderIP, e.Command.SenderName, e.Command.MetaData)
					ShareUtils.PlaySound(ShareUtils.SoundType.NewMessageWithPow)
				End If
				Exit Select

			Case (CommandType.FreeCommand)
				Dim newInfo As String() = e.Command.MetaData.Split(New Char() {":"C})
				Me.AddToList(newInfo(0), newInfo(1))
				ShareUtils.PlaySound(ShareUtils.SoundType.NewClientEntered)
				Exit Select
			Case (CommandType.SendClientList)
				Dim clientInfo As String() = e.Command.MetaData.Split(New Char() {":"C})
				Me.AddToList(clientInfo(0), clientInfo(1))
				Exit Select
			Case (CommandType.ClientLogOffInform)
				Me.RemoveFromList(e.Command.SenderName)
				Exit Select
		End Select
	End Sub

	Private Sub RemoveFromList(name As String)
		Dim item As ListViewItem = Me.lstViwUsers.FindItemWithText(name)
		If item.Text <> Me.client.IP.ToString() Then
			Me.lstViwUsers.Items.Remove(item)
			ShareUtils.PlaySound(ShareUtils.SoundType.ClientExit)
		End If

		Dim target As frmPrivate = Me.FindPrivateWindow(name)
		If target IsNot Nothing Then
			target.Close()
		End If
	End Sub

	Private Sub mniEnter_Click(sender As Object, e As EventArgs)
		If Me.mniEnter.Text = "Login" Then
			Dim dlg As New frmLogin(IPAddress.Parse("127.0.0.1"), 8000)
			dlg.ShowDialog()
			Me.client = dlg.Client

			If Me.client.Connected Then
                AddHandler Me.client.CommandReceived, AddressOf client_CommandReceived
                Me.client.SendCommand(New Command(CommandType.FreeCommand, IPAddress.Broadcast, Convert.ToString(Me.client.IP) & ":" & Convert.ToString(Me.client.NetworkName)))
				Me.client.SendCommand(New Proshot.CommandClient.Command(Proshot.CommandClient.CommandType.SendClientList, Me.client.ServerIP))
				Me.AddToList(Me.client.IP.ToString(), Me.client.NetworkName)
				Me.mniEnter.Text = "Log Off"
			End If
		Else
			Me.mniEnter.Text = "Login"
			Me.privateWindowsList.Clear()
			Me.client.Disconnect()
			Me.lstViwUsers.Items.Clear()
			Me.txtNewMessage.Clear()
			Me.txtNewMessage.Focus()
		End If
	End Sub


	Private Sub mniExit_Click(sender As Object, e As EventArgs)
		Me.Close()
	End Sub

	Private Sub btnSend_Click(sender As Object, e As EventArgs)
		Me.SendMessage()
	End Sub

	Private Sub SendMessage()
		If Me.client.Connected AndAlso Me.txtNewMessage.Text.Trim() <> "" Then
			Me.client.SendCommand(New Proshot.CommandClient.Command(Proshot.CommandClient.CommandType.Message, IPAddress.Broadcast, Me.txtNewMessage.Text))
			Me.txtMessages.Text += Convert.ToString(Me.client.NetworkName) & ": " & Me.txtNewMessage.Text.Trim() & Environment.NewLine
			Me.txtNewMessage.Text = ""
			Me.txtNewMessage.Focus()
		End If
	End Sub

	Private Sub AddToList(ip As String, name As String)
		Dim newItem As ListViewItem = Me.lstViwUsers.Items.Add(ip)
		newItem.ImageKey = "Smiely.png"
		newItem.SubItems.Add(name)
	End Sub

	Private Sub OpenPrivateWindow(remoteClientIP As IPAddress, clientName As String)
		If Me.client.Connected Then
			If Not Me.IsPrivateWindowOpened(clientName) Then
				Dim privateWindow As New frmPrivate(Me.client, remoteClientIP, clientName)
				Me.privateWindowsList.Add(privateWindow)
				AddHandler privateWindow.FormClosed, New FormClosedEventHandler(AddressOf privateWindow_FormClosed)
				privateWindow.StartPosition = FormStartPosition.CenterParent
				privateWindow.Show(Me)
			End If
		End If
	End Sub

	Private Sub OpenPrivateWindow(remoteClientIP As IPAddress, clientName As String, initialMessage As String)
		If Me.client.Connected Then
			Dim privateWindow As New frmPrivate(Me.client, remoteClientIP, clientName, initialMessage)
			Me.privateWindowsList.Add(privateWindow)
			AddHandler privateWindow.FormClosed, New FormClosedEventHandler(AddressOf privateWindow_FormClosed)
			privateWindow.Show(Me)
		End If
	End Sub

	Private Sub privateWindow_FormClosed(sender As Object, e As FormClosedEventArgs)
		Me.privateWindowsList.Remove(DirectCast(sender, frmPrivate))
	End Sub

	Private Sub btnPrivate_Click(sender As Object, e As EventArgs)
		Me.StartPrivateChat()
	End Sub

	Private Sub StartPrivateChat()
		If Me.lstViwUsers.SelectedItems.Count <> 0 Then
			Me.OpenPrivateWindow(IPAddress.Parse(Me.lstViwUsers.SelectedItems(0).Text), Me.lstViwUsers.SelectedItems(0).SubItems(1).Text)
		End If
	End Sub

	Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs)
		Proshot.LanguageManager.LanguageActions.ChangeLanguageToEnglish()
		Me.client.Disconnect()
	End Sub

	Private Sub mniSave_Click(sender As Object, e As EventArgs)
		Dim saveDlg As New SaveFileDialog()
		saveDlg.Filter = "HTML Files(*.HTML;*.HTM)|*.html;*.htm"
		saveDlg.FilterIndex = 0
		saveDlg.RestoreDirectory = True
		saveDlg.CheckPathExists = True
		saveDlg.OverwritePrompt = True
		saveDlg.FileName = Me.Text
		If saveDlg.ShowDialog() = DialogResult.OK Then
			ShareUtils.SaveAsHTML(saveDlg.FileName, Me.txtMessages.Lines, Me.Text)
		End If
	End Sub

	Private Sub mniCopy_Click(sender As Object, e As EventArgs)
		Me.txtNewMessage.Copy()
	End Sub

	Private Sub mniPaste_Click(sender As Object, e As EventArgs)
		Me.txtNewMessage.Paste()
	End Sub

	Private Sub mniCopyText_Click(sender As Object, e As EventArgs)
		Me.txtMessages.Copy()
	End Sub

	Private Sub mniPrivate_Click(sender As Object, e As EventArgs)
		Me.StartPrivateChat()
	End Sub

End Class
