Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Proshot.CommandClient
Imports System.Net
Imports System.Runtime.InteropServices


Friend Enum FlashMode
	FLASHW_CAPTION = &H1
	FLASHW_TRAY = &H2
	FLASHW_ALL = FLASHW_CAPTION Or FLASHW_TRAY
End Enum

Friend Structure FlashInfo
	Public cdSize As Integer
	Public hwnd As System.IntPtr
	Public dwFlags As Integer
	Public uCount As Integer
	Public dwTimeout As Integer

End Structure

Public Partial Class frmPrivate
	Inherits Form

	Private remoteClient As CMDClient
	Private targetIP As IPAddress
	Private m_remoteName As String
    Private activated As Boolean
	Public ReadOnly Property RemoteName() As String
		Get
			Return Me.m_remoteName
		End Get
	End Property
	Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
		If keyData = Keys.Enter Then
			Me.SendMessage()
		End If
		If Me.txtMessages.Focused AndAlso Not ShareUtils.IsValidKeyForReadOnlyFields(keyData) Then
			Return True
		End If
		Return MyBase.ProcessCmdKey(msg, keyData)
	End Function
	Public Sub New(cmdClient As CMDClient, friendIP As IPAddress, name As String, initialMessage As String)
		InitializeComponent()
		Me.remoteClient = cmdClient
		Me.targetIP = friendIP
		Me.m_remoteName = name
		Me.Text += " With " & name
		Me.txtMessages.Text = Me.m_remoteName & ": " & initialMessage & Environment.NewLine
        AddHandler remoteClient.CommandReceived, AddressOf private_CommandReceived
	End Sub

	Public Sub New(cmdClient As CMDClient, friendIP As IPAddress, name As String)
		InitializeComponent()
		Me.remoteClient = cmdClient
		Me.targetIP = friendIP
		Me.m_remoteName = name
		Me.Text += " With " & name
        AddHandler Me.remoteClient.CommandReceived, AddressOf private_CommandReceived
	End Sub

	Private Sub private_CommandReceived(sender As Object, e As CommandEventArgs)
		Select Case e.Command.CommandType
			Case (CommandType.Message)
				If Not e.Command.Target.Equals(IPAddress.Broadcast) AndAlso e.Command.SenderIP.Equals(Me.targetIP) Then
					Me.txtMessages.Text += Convert.ToString(e.Command.SenderName) & ": " & Convert.ToString(e.Command.MetaData) & Environment.NewLine
					If Not Me.activated Then
						If Me.WindowState = FormWindowState.Normal OrElse Me.WindowState = FormWindowState.Maximized Then
							ShareUtils.PlaySound(ShareUtils.SoundType.NewMessageReceived)
						Else
							ShareUtils.PlaySound(ShareUtils.SoundType.NewMessageWithPow)
						End If
						Me.Flash(Me.Handle, FlashMode.FLASHW_ALL, 3)
					End If
				End If
				Exit Select
		End Select
	End Sub

	<DllImport("user32.dll")> _
	Private Shared Function FlashWindowEx(ByRef pfwi As FlashInfo) As Integer
	End Function
	Private Sub Flash(hwnd As System.IntPtr, flashMode As FlashMode, times As Integer)
		Dim FlashInf As New FlashInfo()
        FlashInf.cdSize = Marshal.SizeOf(New FlashInfo())
		FlashInf.dwFlags = CInt(flashMode)
		FlashInf.dwTimeout = 0
		FlashInf.hwnd = hwnd
		FlashInf.uCount = times
		FlashWindowEx(FlashInf)
	End Sub

	Private Sub btnSend_Click(sender As Object, e As EventArgs)
		Me.SendMessage()
	End Sub

	Private Sub SendMessage()
		If Me.remoteClient.Connected AndAlso Me.txtNewMessage.Text.Trim() <> "" Then
			Me.remoteClient.SendCommand(New Proshot.CommandClient.Command(Proshot.CommandClient.CommandType.Message, Me.targetIP, Me.txtNewMessage.Text))
			Me.txtMessages.Text += Convert.ToString(Me.remoteClient.NetworkName) & ": " & Me.txtNewMessage.Text.Trim() & Environment.NewLine
			Me.txtNewMessage.Text = ""
			Me.txtNewMessage.Focus()
		End If
	End Sub

	Private Sub frmPrivate_FormClosing(sender As Object, e As FormClosingEventArgs)
        AddHandler Me.remoteClient.CommandReceived, AddressOf private_CommandReceived
	End Sub

	Private Sub mniExit_Click(sender As Object, e As EventArgs)
		Me.Close()
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

	Private Sub frmPrivate_Load(sender As Object, e As EventArgs)
		Me.Location = New Point(Screen.PrimaryScreen.Bounds.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.DesktopBounds.Height)
	End Sub

	Private Sub frmPrivate_Activated(sender As Object, e As EventArgs)
		Me.activated = True
	End Sub

	Private Sub frmPrivate_Deactivate(sender As Object, e As EventArgs)
		Me.activated = False
	End Sub

End Class
