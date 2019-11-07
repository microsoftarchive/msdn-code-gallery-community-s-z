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
		Private message As String = "" ' The Message We are sending to the Server or our Friends.

		Private username As String = Nothing
		Private password As String = Nothing

		#Region "CONSTNANTS"
		Private Const RegistrationCommand As String = "REGISTRATION:" ' I want to Register
		Private Const ErrorCommand As String = "ERROR:" ' Eeek there is an Error
		Private Const IDCommand As String = "ID:" ' My Unique ID
		Private Const SuccessLoggedOnCommand As String = "SUCCESS:Logged On" ' Yay! I have logged on
		Private Const ClientCommand As String = "Client: "
		Private Const LoginCommand As String = "LOGIN:" ' I want to Login please
		Private Const ClosingCommand As String = "CLOSING" ' Bye bye Server
		Private Const ForServer As String = "0" ' The Server's ClientID
		Private Const AddFriendCommand As String = "AddFriend:" ' Messages for the server only
		Private Const NoSuchUserCommand As String = "NoSuchUser:" ' The User requested friend does not exist
		Private Const FriendAddedCommand As String = "FriendAdded:"
		Private Const GetFriendListCommand As String = "GetFriendsList:"
		Private Const YourLastCommandIsNotImplementedYetCommand As String = "Your last command is not Implemented Yet" ' The user's friend exists and has been added to their friends list
		#End Region

		#Region "Threading Delegates"

		Public Delegate Sub UpdateFormTitleDelegate(ByVal Title As String)
		Public Delegate Sub UpdateBtnConectEnabledDelegate(ByVal enabled As Boolean)
		Public Delegate Sub UpdateConnectionIconDelegate(ByVal img As Bitmap)
		Public Delegate Sub UpdateStatusMessageStringDelegate(ByVal message As String)
		Public Delegate Sub UpdateToolStripMessageBoolDelegate(ByVal message As Boolean)

		#End Region

		''' <summary>
		''' Initializes a new instance of the <see cref="FrmClient"/> class.
		''' </summary>
		Public Sub New()
			InitializeComponent()
			SubscribeToClientEvents()
		End Sub


		#Region "Client Events"

		''' <summary>
		''' Now we are connected we should log in. Or if we are logging in with a valid ID then Relogin
		''' </summary>
		Private Sub client_Connected()
			If Me.username Is Nothing Then ' We haven't logged on this session
				Login()
			Else
				ReLogin()
			End If
			UpdateAddFriendButton(True)
			UpdateStatusMessage(My.Resources.Connected)
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
			MessageBox.Show(My.Resources.Error & ex.Message)
		End Sub

		''' <summary>
		''' We have Disconnected 
		''' TODO: Not sure why we disconnected - need to add checks for this later
		''' </summary>
		Private Sub client_Disconnected()
			UpdateBtnConectEnabled(True)
			UpdateConnectionIcon(My.Resources.red_x_icon)
			UpdateAddFriendButton(False)
		End Sub

		''' <summary>
		''' We have recieved information from either the Server or, a friend!
		''' </summary>
		''' <param name="Data">
		''' Bye[]: The Raw data we have received
		''' </param>
		''' <param name="ID">
		''' String: The ID of the person who sent it to us
		''' </param>
		Private Sub client_DataReceived(ByVal Data() As Byte, ByVal ID As String)
			' ERROR:Login Details Not Recognized
			Dim message As String = ConvertBytesToString(Data)
			If Me.message.StartsWith(ErrorCommand) Then
				MessageBox.Show(My.Resources.Error, "") ' ??
			ElseIf message.StartsWith(IDCommand) Then ' New Client ID
				RestartWithNewID(message)
			ElseIf message.StartsWith(SuccessLoggedOnCommand) Then
				btnAddFriend.Enabled = True

			ElseIf message.StartsWith(NoSuchUserCommand) Then
				MessageBox.Show(My.Resources.SorryTheEmailAddress + message.Split(":"c)(1).ToString() & My.Resources.WasNotFound)
			ElseIf message.StartsWith(FriendAddedCommand) Then
				GetFriendsList()
			ElseIf message.StartsWith(YourLastCommandIsNotImplementedYetCommand) Then
				MessageBox.Show(message)
			End If
		End Sub

		''' <summary>
		''' Asks the server to send my friends list
		''' </summary>
		Private Sub GetFriendsList()
			SendMessage(GetFriendListCommand, ForServer)
		End Sub

		#End Region

		#Region "Main Form Events"

		''' <summary>
		''' Send the Closing command When window is closed
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub FrmClient_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
			SendCloseMessage()

		End Sub

		#End Region

		#Region "Utilities"

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

		''' <summary>
		''' Updates the Title of the Client
		''' </summary>
		''' <param name="NewTitle">
		''' String: The new Title of the Form
		''' </param>
		Private Sub UpdateFormTitle(ByVal NewTitle As String)
			If Me.InvokeRequired Then
				Dim d As New UpdateFormTitleDelegate(AddressOf UpdateFormTitle)
				Me.Invoke(d, New Object() { NewTitle })
			Else
				Me.Text = NewTitle

			End If
		End Sub

		#End Region

		#Region "Send Messages"

		''' <summary>
		''' Tell the Server we are closing
		''' </summary>
		Private Sub SendCloseMessage()
			UpdateBtnConectEnabled(True)
			UpdateConnectionIcon(My.Resources.red_x_icon)
			SendMessage(ClosingCommand, ForServer)
			UpdateStatusMessage(My.Resources.ConnectionLost)
		End Sub

		''' <summary>
		''' Send a Message to a named recipient
		''' </summary>
		''' <param name="message">
		''' String: The message to be formatted and sent
		''' </param>
		''' <param name="SendTo">
		''' String: The Recipients ID
		''' </param>
		Private Sub SendMessage(ByVal message As String, ByVal SendTo As String)
			Me.client.SendData(ConvertStringToBytes(message), SendTo)
		End Sub

		#End Region

		#Region "Login"

		''' <summary>
		''' Tell Server we are Re-Logging in with New ID
		''' </summary>
		Private Sub ReLogin()
			Me.message = My.Resources.RELOGIN & username & ":" & password ' Send the Login Details
			Me.client.SendData(ConvertStringToBytes(message), ForServer)
			UpdateConnectionIcon(My.Resources.green_tick)
			UpdateBtnConectEnabled(False)
			UpdateStatusMessage(My.Resources.Connected)
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
				Me.message = LoginCommand & login_Renamed.EmailAddress & ":" & login_Renamed.Password ' Send the Login Details
				Me.username = login_Renamed.EmailAddress
				Me.password = login_Renamed.Password
				SendMessage(message, ForServer)
				lblStatus.Text = My.Resources.LoggingIn
			ElseIf login_Renamed.IsRegistered Then
				'  REGISTRATION:<USERNAME>:<PASSWORD>
				Me.message = RegistrationCommand & login_Renamed.EmailAddress & ":" & login_Renamed.Password ' Send the Registration Details
				Me.username = login_Renamed.EmailAddress
				Me.password = login_Renamed.Password
				SendMessage(message, ForServer)
				lblStatus.Text = My.Resources.Registering
			Else
				SendCloseMessage() ' Must have canceled the login
			End If
		End Sub

		''' <summary>
		''' Reconnects to the Server with our official ID
		''' </summary>
		''' <param name="message">
		''' String: Our New Valid Unique cID
		''' </param>
		Private Sub RestartWithNewID(ByVal message As String)
			' Temporarily ignore these events
			RemoveHandler Me.client.Connected, AddressOf client_Connected
			RemoveHandler Me.client.Disconnected, AddressOf client_Disconnected
			Me.cID = message.Split(":"c)(1).ToString()
			UpdateFormTitle(ClientCommand & cID)
			SendCloseMessage()
			Me.client.Disconnect()
			Me.client.Connect("127.0.0.1", 3000, cID)

			' Start Listening for these events again
			AddHandler Me.client.Connected, AddressOf client_Connected
			AddHandler Me.client.Disconnected, AddressOf client_Disconnected

		End Sub

		#End Region

		#Region "ToolStrip"

		''' <summary>
		''' Update the Connection Button's Enable Property
		''' </summary>
		''' <param name="IsEnabled">
		''' Bool: True if the Button is to be enabled
		'''         False if the button is not to be enabled
		''' </param>
		Private Sub UpdateBtnConectEnabled(ByVal IsEnabled As Boolean)

			If toolStrip1.InvokeRequired Then
				Dim d As New UpdateBtnConectEnabledDelegate(AddressOf UpdateBtnConectEnabled)
				toolStrip1.Invoke(d, New Object() { IsEnabled })
			Else
				btnConnect.Enabled = IsEnabled
			End If
		End Sub

		''' <summary>
		''' Let the EU Add a Friend
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub btnAddFriend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddFriend.Click
			UpdateAddFriendButton(False)
			Dim AddFriend As New FrmAddFriend()
			AddFriend.MyEmailAddress = username
			Dim dr As DialogResult = AddFriend.ShowDialog()
			If dr = System.Windows.Forms.DialogResult.OK Then
				SendMessage(AddFriendCommand & AddFriend.FriendsEmailAddress,ForServer)
			End If
			UpdateAddFriendButton(True)
		End Sub

		''' <summary>
		''' Connect to the Chat Server
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub btnConnect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConnect.Click
			Me.client.Connect("127.0.0.1", 3000, cID.ToString())
			UpdateConnectionIcon(My.Resources.green_tick)
			UpdateBtnConectEnabled(False)
			UpdateStatusMessage(My.Resources.Connected)
		End Sub

		''' <summary>
		''' Update the AddFriend Button to a new Enabled State
		''' </summary>
		''' <param name="IsEnabled">
		''' Bool: True enabled the button
		'''         False Disables the button
		''' </param>
		Private Sub UpdateAddFriendButton(ByVal IsEnabled As Boolean)
			If statusStrip1.InvokeRequired Then
				Dim d As New UpdateToolStripMessageBoolDelegate(AddressOf UpdateAddFriendButton)
				statusStrip1.Invoke(d, New Object() { IsEnabled })
			Else
				btnAddFriend.Enabled = IsEnabled
			End If
		End Sub

		#End Region

		#Region "StatusStrip"

		''' <summary>
		''' If the Icon in the bottom right of the Chat client is Green - and double clicked
		''' close the connection... Will be improved later.
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub lblConnectionStatus_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lblConnectionStatus.DoubleClick
			If lblConnectionStatus.Image Is My.Resources.green_tick Then
				SendCloseMessage()
			End If
		End Sub

		''' <summary>
		''' Change the Connection Icon
		''' </summary>
		''' <param name="bitmap">
		''' Bitmap: The New Icon to display located in the Resources File
		''' </param>
		Private Sub UpdateConnectionIcon(ByVal bitmap As Bitmap)
			If statusStrip1.InvokeRequired Then
				Dim d As New UpdateConnectionIconDelegate(AddressOf UpdateConnectionIcon)
				statusStrip1.Invoke(d, New Object() { bitmap })
			Else
				Me.lblConnectionStatus.Image = bitmap
			End If
		End Sub

		''' <summary>
		''' Update the EU's Status Message
		''' </summary>
		''' <param name="Message">
		''' String: The status message to show the user
		''' </param>
		Private Sub UpdateStatusMessage(ByVal Message As String)
			If statusStrip1.InvokeRequired Then
				Dim d As New UpdateStatusMessageStringDelegate(AddressOf UpdateStatusMessage)
				statusStrip1.Invoke(d, New Object() { Message })
			Else
				lblStatus.Text = Message

			End If

		End Sub

		#End Region
	End Class
End Namespace
