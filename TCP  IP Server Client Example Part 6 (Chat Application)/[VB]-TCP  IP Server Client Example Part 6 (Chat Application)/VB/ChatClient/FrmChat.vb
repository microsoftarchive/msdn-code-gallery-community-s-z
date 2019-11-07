Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace ChatClient
	Partial Public Class FrmChat
		Inherits Form

		Private client As New NetComm.Client()
		Private cID As String = "-1" & Guid.NewGuid().ToString() ' Temporary Client ID - Replaced by Server on Successful Login
		Private ReadOnly ForServer As String = "0" ' Messages for the server only
		Private message As String = "" ' The Message We are sending to the Server or our Friends.

		Private username As String = Nothing
		Private password As String = Nothing

		Public Delegate Sub UpdateFormTitleDelegate(ByVal Title As String)
		Public Delegate Sub UpdateBtnConectEnabledDelegate(ByVal enabled As Boolean)
		Public Delegate Sub UpdateConnectionIconDelegate(ByVal img As Bitmap)
		Public Delegate Sub UpdateStatusMessageDelegate(ByVal message As String)

		''' <summary>
		''' Initializes a new instance of the <see cref="FrmClient"/> class.
		''' </summary>
		Public Sub New()
			InitializeComponent()
			SubscribeToClientEvents()
		End Sub

		''' <summary>
		''' Subscribes to client events.
		''' </summary>
		Private Sub SubscribeToClientEvents()
			AddHandler Me.client.Connected, AddressOf client_Connected
			AddHandler Me.client.DataReceived, AddressOf client_DataReceived
			AddHandler Me.client.Disconnected, AddressOf client_Disconnected
			AddHandler Me.client.errEncounter, AddressOf client_errEncounter
		End Sub

		''' <summary>
		''' Shows Client Errors to EU
		''' </summary>
		''' <param name="ex">The ex.</param>
		Private Sub client_errEncounter(ByVal ex As Exception)
			MessageBox.Show("Error: " & ex.Message)
		End Sub

		Private Sub client_Disconnected()
		   UpdateBtnConectEnabled(True)
		   UpdateConnectionIcon(My.Resources.red_x_icon)
		End Sub

		Private Sub client_DataReceived(ByVal Data() As Byte, ByVal ID As String)
			' ERROR:Login Details Not Recognized
			Dim message As String = ConvertBytesToString(Data)
			If Me.message.StartsWith("ERROR:") Then
				MessageBox.Show(Me.message.Replace("ERROR:", ""))
			ElseIf message.StartsWith("ID") Then ' New Client ID
				' Temporarily ignore these events
				RemoveHandler Me.client.Connected, AddressOf client_Connected
				RemoveHandler Me.client.Disconnected, AddressOf client_Disconnected
				Me.cID = message.Split(":"c)(1).ToString()
				UpdateFormTitle("Client: " & cID)
				SendCloseMessage()
				Me.client.Disconnect()
				Me.client.Connect("127.0.0.1", 3000, cID)

				' Start Listening for these events again
				AddHandler Me.client.Connected, AddressOf client_Connected
				AddHandler Me.client.Disconnected, AddressOf client_Disconnected
			End If
		End Sub

		''' <summary>
		''' Updates the Title of the Client
		''' </summary>
		''' <param name="p">
		''' String: The new Title of the Form
		''' </param>
		Private Sub UpdateFormTitle(ByVal p As String)
			If Me.InvokeRequired Then
				Dim d As New UpdateFormTitleDelegate(AddressOf UpdateFormTitle)
				Me.Invoke(d, New Object() { p })
			Else
				Me.Text = p

			End If
		End Sub

		''' <summary>
		''' Now we are connected we should log in.
		''' </summary>
		Private Sub client_Connected()
			If Me.username Is Nothing Then ' We haven't logged on this session
				Login()
			Else
				ReLogin()
			End If
		End Sub

		Private Sub ReLogin()
			Me.message = "RELOGIN:" & username & ":" & password ' Send the Login Details
			Me.client.SendData(ConvertStringToBytes(message), ForServer)
			UpdateConnectionIcon(My.Resources.green_tick)
			UpdateBtnConectEnabled(False)
			UpdateStatusMessage("Connected")

		End Sub

		Private Sub UpdateStatusMessage(ByVal p As String)
			If statusStrip1.InvokeRequired Then
				Dim d As New UpdateStatusMessageDelegate(AddressOf UpdateStatusMessage)
				statusStrip1.Invoke(d, New Object() { p })
			Else
				lblStatus.Text = p

			End If

		End Sub

		''' <summary>
		''' Log the EU in
		''' </summary>
		Private Sub Login()
'INSTANT VB NOTE: The variable login was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim login_Renamed As New FrmLogin()
			Dim dr As New DialogResult()
			dr = login_Renamed.ShowDialog()

			If dr = System.Windows.Forms.DialogResult.OK Then

				'  LOGIN:<USERNAME>:<PASSWORD>
				Me.message = "LOGIN:" & login_Renamed.EmailAddress & ":" & login_Renamed.Password ' Send the Login Details
				Me.username = login_Renamed.EmailAddress
				Me.password = login_Renamed.Password
				Me.client.SendData(ConvertStringToBytes(message), ForServer)
				lblStatus.Text = "Loging In"
			ElseIf login_Renamed.IsRegistered Then
				'  REGISTRATION:<USERNAME>:<PASSWORD>
				Me.message = "REGISTRATION:" & login_Renamed.EmailAddress & ":" & login_Renamed.Password ' Send the Registration Details
				Me.username = login_Renamed.EmailAddress
				Me.password = login_Renamed.Password
				Me.client.SendData(ConvertStringToBytes(message), ForServer)
				lblStatus.Text = "Registering"
			Else
				SendCloseMessage() ' Must have canceled the login
			End If
		End Sub

		Private Sub btnConnect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConnect.Click
			Me.client.Connect("127.0.0.1", 3000, cID.ToString())
			UpdateConnectionIcon(My.Resources.green_tick)
			UpdateBtnConectEnabled(False)
		   UpdateStatusMessage("Connected")
		End Sub

		''' <summary>
		''' Convert Messages from the Server into English
		''' </summary>
		''' <param name="bytes"></param>
		''' <returns></returns>
		Private Function ConvertBytesToString(ByVal bytes() As Byte) As String
			Return ASCIIEncoding.ASCII.GetString(bytes)
		End Function

		''' <summary>
		''' Convert English messages into Messages for the server
		''' </summary>
		''' <param name="str"></param>
		''' <returns></returns>
		Private Function ConvertStringToBytes(ByVal str As String) As Byte()
			Return ASCIIEncoding.ASCII.GetBytes(str)
		End Function

		Private Sub FrmClient_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
			SendCloseMessage()
		End Sub

		''' <summary>
		''' Tell the Server we are closing
		''' </summary>
		Private Sub SendCloseMessage()
			UpdateBtnConectEnabled(True)
			UpdateConnectionIcon(My.Resources.red_x_icon)

			Me.client.SendData(ConvertStringToBytes("CLOSING"), ForServer)
		End Sub

		Private Sub UpdateConnectionIcon(ByVal bitmap As Bitmap)
			If statusStrip1.InvokeRequired Then
				Dim d As New UpdateConnectionIconDelegate(AddressOf UpdateConnectionIcon)
				statusStrip1.Invoke(d, New Object() { bitmap })
			Else
				Me.lblConnectionStatus.Image = bitmap

			End If
		End Sub

		Private Sub UpdateBtnConectEnabled(ByVal p As Boolean)

			 If toolStrip1.InvokeRequired Then
				Dim d As New UpdateBtnConectEnabledDelegate(AddressOf UpdateBtnConectEnabled)
				toolStrip1.Invoke(d, New Object() { p })
			Else
				btnConnect.Enabled = p

			End If
		End Sub

		''' <summary>
		''' If the Icon in the bottom right of the Chat client is Green - and double clicked
		''' close the connection... Will be improved later.
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub lblConnectionStatus_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lblConnectionStatus.DoubleClick
			If lblConnectionStatus.Image Is My.Resources.green_tick Then
				UpdateBtnConectEnabled(True)
				UpdateConnectionIcon(My.Resources.red_x_icon)
				Me.client.SendData(ConvertStringToBytes("CLOSING"), ForServer)
			   UpdateStatusMessage("Connection Lost")
			End If
		End Sub

		''' <summary>
		''' Let the EU Add a Friend
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub btnAddFriend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddFriend.Click

		End Sub
	End Class
End Namespace
