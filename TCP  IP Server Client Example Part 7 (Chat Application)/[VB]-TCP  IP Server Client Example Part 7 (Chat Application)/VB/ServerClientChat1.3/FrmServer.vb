Imports NetComm
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Imports ServerClientChat1._3.Classes
Imports ServerClientChat1._3.Forms

Namespace ServerClientChat1._3
	Partial Public Class FrmServer
		Inherits Form

		Private Shared ReadOnly OurPort As Integer = 3000 ' The Server's Port
		Private server As NetComm.Host = New Host(OurPort) ' Listens on port 3330.
		Private pip As New PublicIP() ' Class to get Server's Public IP Address
		Private AzureDB As New AzureSQL() ' Class for communicating with Azure Database

		Private TotalConnectedUsers As Integer = 0 ' In production you may want to use longs instead of ints.
		Private TotalRegisteredUsers As Integer = 0 ' In production you may want to use longs instead of ints.
		Private TotalLoggedInUsers As Integer = 0 ' In production you may want to use longs instead of ints.

		#Region "CONSTANTS"
		Private Const NoSuchUserCommand As String = "NoSuchUser:"
		Private Const ErrorPublicIPCommand As String = "Error Public IP: "
		Private Const CLOSINGCommand As String = "CLOSING"
		Private Const REGISTRATIONCommand As String = "REGISTRATION"
		Private Const LOGINCommand As String = "LOGIN"
		Private Const RELOGINCommand As String = "RELOGIN"
		Private Const AddFriendCommand As String = "AddFriend"
		Private Const FriendAddedCommand As String = "FriendAdded:"
		Private Const GetFriendsList As String = "GetFriendsList:"
		#End Region





		Private Delegate Sub UpdateConnectedUsersDelegate(ByVal s As String)
		Public Delegate Sub UpdateLogDelegate(ByVal txt As String)
		Public Delegate Sub IPAddressDelegate(ByVal ip As String)
		Public Delegate Sub UpdateTotalLoggedInUsersDelegate(ByVal number As String)
		Public Delegate Sub UpdateTotalRegisteredUsersDelegate(ByVal number As Integer)

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Start The server and Setup initial variables and connections
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub FrmServer_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Get Azure Server Name, Table Name, User name and Password

			Dim AzureLogin As New FrmAzureDatabaseLogin()
			Dim dr As DialogResult = AzureLogin.ShowDialog()
			If dr = System.Windows.Forms.DialogResult.OK Then

				AddHandler AzureDB.SQLInfoMessage, AddressOf AzureDB_SQLInfoMessage ' Get any messages from the SQL Database
				AddHandler AzureDB.SQLStateChanged, AddressOf AzureDB_SQLStateChanged ' Keep track of Database Connection Changes

				AzureDB.ConnectionString = "Server=tcp:" & AzureLogin.ServerName & ";Database=ChatApp;User ID=" & AzureLogin.UserName & ";Password=" & AzureLogin.Password & ";Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"
				If AzureDB.Connect() Then
					' Display our Public IP Address and the port we are listening to.
					pip = New PublicIP()
					AddHandler pip.PublicIPKnown, AddressOf pip_PublicIPKnown ' Get's the Public IP Address of the Server (Event)
					AddHandler pip.PublicIPError, AddressOf pip_PublicIPError ' Notifies us of any Errors Getting the Public IP
					pip.GetPublicIpAddress() ' Will Raise the above event
					lblPort.Text = OurPort.ToString()

					' Subscribe to Server Events
					AddHandler server.ConnectionClosed, AddressOf server_ConnectionClosed
					AddHandler server.DataReceived, AddressOf server_DataReceived
					AddHandler server.DataTransferred, AddressOf server_DataTransferred
					AddHandler server.errEncounter, AddressOf server_errEncounter
					AddHandler server.lostConnection, AddressOf server_lostConnection
					AddHandler server.onConnection, AddressOf server_onConnection
					server.StartConnection() ' Don't forget to start your server !!

					' Now get total number of Registered Users.
					TotalRegisteredUsers = AzureDB.GetRegisteredUsers()
					UpdateTotalRegisteredUsers(TotalRegisteredUsers)
				Else
					MessageBox.Show(My.Resources.AzureDatabaseError & AzureDB.LastError)
					lblConnectionState.Image = My.Resources.database_red
				End If

			Else
				MessageBox.Show(My.Resources.TheServerCannotRunUnlessConnectedToTheServerSAzureSQLDatabaseClosingApplication)
				Me.Close()
			End If
		End Sub



		Private Sub pip_PublicIPError(ByVal Message As String)
			Log(ErrorPublicIPCommand & Message)
		End Sub

		Private Sub server_onConnection(ByVal id As String)
			Me.TotalConnectedUsers += 1
			UpdateConnectedUser(TotalConnectedUsers.ToString("N0"))

		End Sub

		Private Sub UpdateConnectedUser(ByVal s As String)
			If Me.lblTotalConnectedUsers.InvokeRequired Then
				Dim d As New UpdateConnectedUsersDelegate(AddressOf UpdateConnectedUser)
				Me.lblTotalConnectedUsers.Invoke(d, New Object() { s })
			Else
				Me.lblTotalConnectedUsers.Text = s

			End If
		End Sub

		Private Sub UpdateTotalRegisteredUsers(ByVal TotalRegisteredUsers As Integer)
			If Me.lblTotalRegisteredUsers.InvokeRequired Then
				Dim d As New UpdateTotalRegisteredUsersDelegate(AddressOf UpdateTotalRegisteredUsers)
				Me.lblTotalConnectedUsers.Invoke(d, New Object() { TotalRegisteredUsers })
			Else
				Me.lblTotalRegisteredUsers.Text = TotalRegisteredUsers.ToString("N0")

			End If
		End Sub

		''' <summary>
		''' Someone has disconnected - update stats and their Online status if applicable
		''' </summary>
		''' <param name="id">
		''' String: The ID of the Client who has disconnected
		''' </param>
		Private Sub server_lostConnection(ByVal id As String)
			TotalConnectedUsers -= 1
			UpdateConnectedUser(TotalConnectedUsers.ToString("N0"))

			If AzureDB.ClientIsLoggedIn(id) Then
				TotalLoggedInUsers -= 1
				UpdateLoggedInUsers(TotalLoggedInUsers.ToString("N0")) ' Only update this is we need to
				AzureDB.LogOffClient(id) ' Log This dropped client off
			End If
		End Sub

		Private Sub server_errEncounter(ByVal ex As Exception)
			Log("Server Error: " & ex.Message)
		End Sub

		''' <summary>
		''' Data Received from connected Clients
		''' </summary>
		''' <param name="Sender">
		''' String: The Sender's Unique ID
		''' </param>
		''' <param name="Recipient">
		''' String: The Recipient's Unique ID. If 0, then it is for the Server
		'''         Otherwise it is to be redirected to another Client
		''' </param>
		''' <param name="Data">
		''' String: The message to process or forward
		''' </param>
		Private Sub server_DataTransferred(ByVal Sender As String, ByVal Recipient As String, ByVal Data() As Byte)
			Dim message As String = ConvertBytesToString(Data)
			If Recipient = "0" Then ' The Server's ID
				Log(My.Resources.ReceivedCommandFromClient & Sender & My.Resources.ForThisServer)


				If message.StartsWith(CLOSINGCommand) Then
					DoClientClosing(Sender)
				ElseIf message.StartsWith(REGISTRATIONCommand) Then
					DoRegistration(Sender, message)
				ElseIf message.StartsWith(LOGINCommand) Then
					DoLogin(Sender, message)
				ElseIf message.StartsWith(RELOGINCommand) Then
					DoRelogin(Sender, message)
				ElseIf message.StartsWith(AddFriendCommand) Then
					DoAddFriend(Sender, message)
				ElseIf message.StartsWith(GetFriendsList) Then
					' Get the list of friends from the database and Their Online Status and send to the calling client

				Else
					SendNotImplementedYet(Sender, message)
					Me.Log(My.Resources.ReceivedCommandFromClient & Sender & My.Resources.ForThisServer_ & message)
				End If


			Else
				server.SendData(Recipient, Data) ' Just forward the message to the correct Recipient.
			End If
		End Sub

		Private Sub DoAddFriend(ByVal Sender As String, ByVal message As String)
			' Awww they have a friend, that's nice
			' See if the Friend exists!
			If DoesUserEmailExist(Sender, message) > 0 Then ' If we get an ID then the user exists

				' Add Friend to the database
				If AzureDB.AddFriend(Sender, message.Split(":"c)(1).ToString()) Then
					SendFriendAdded(Sender, message)
					Log(My.Resources.FriendWasSuccessfullyAdded)
				Else
					Log(My.Resources.ErrorFriendWasNotAddedSuccessfully)
				End If
			Else
				SendNoSuchUser(Sender, message)
			End If
		End Sub

		''' <summary>
		''' Tell the client that this feature is not implemented yet - should never happen in production
		''' </summary>
		''' <param name="Sender">
		''' String: The Client who has sent a command that does not exist
		''' </param>
		''' <param name="message">
		''' String: The Original message sent by the Client
		''' </param>
		Private Sub SendNotImplementedYet(ByVal Sender As String, ByVal message As String)
			Dim m As String = My.Resources.YourLastCommandIsNotImplementedYet & " " & message
			server.SendData(Sender, ConvertStringToBytes(m))
		End Sub

		''' <summary>
		''' Tell the calling (sender) client that the friend has been added to their friends list
		''' </summary>
		''' <param name="Sender">
		''' string: The client who needs to know that their friend has been added
		''' </param>
		''' <param name="message">
		''' The Original message which contains the email address that was added as a friend
		''' </param>
		Private Sub SendFriendAdded(ByVal Sender As String, ByVal message As String)
			Dim m As String = FriendAddedCommand & message.Split(":"c)(1)
			server.SendData(Sender, ConvertStringToBytes(m))
		End Sub

		''' <summary>
		''' Tell the calling (sender) client that no such user exists
		''' </summary>
		''' <param name="Sender">
		''' string: The Client who needs to know the user Does not exist
		''' </param>
		''' <param name="message">
		''' The Original message which contains the email address that was not found
		''' </param>
		Private Sub SendNoSuchUser(ByVal Sender As String, ByVal message As String)
			Dim m As String = NoSuchUserCommand & message.Split(":"c)(1).ToString() ' Convert Message to Byte[]
			server.SendData(Sender, ConvertStringToBytes(m))
		End Sub

		''' <summary>
		''' Checks to see if a User Email exists
		''' </summary>
		''' <param name="Sender">
		''' String: Who asked for this?
		''' </param>
		''' <param name="message">
		''' String: The message containing the Email address to lookup
		''' </param>
		''' <returns>
		''' Int: The User's ID
		''' </returns>
		Private Function DoesUserEmailExist(ByVal Sender As String, ByVal message As String) As Integer
			Return AzureDB.GetUsersID(message.Split(":"c)(1).ToString())
		End Function

		Private Sub DoClientClosing(ByVal Sender As String)
			Me.TotalConnectedUsers -= 1
			UpdateConnectedUser(TotalConnectedUsers.ToString("N0"))
			AzureDB.LogOffClient(Sender)
		End Sub

		Private Sub DoRegistration(ByVal Sender As String, ByVal message As String)
			' Message = REGISTRATION:<USERNAME>:<PASSWORD>

			If Not AzureDB.RegisterUser(message.Split(":"c)(1).ToString(), message.Split(":"c)(2).ToString()) Then
				Me.server.SendData(Sender, ConvertStringToBytes("ERROR:That email is already registered."))
				Me.Log("Client " & Sender & "ERROR:That email is already registered.")
			Else
				Dim cID As Integer = AzureDB.GetUsersID(message.Split(":"c)(1).ToString())
				Me.TotalLoggedInUsers += 1 ' Add this user to the logged in user count
				Me.TotalRegisteredUsers += 1
				UpdateTotalRegisteredUsers(TotalRegisteredUsers)
				Me.server.SendData(Sender, ConvertStringToBytes("SUCCESS:Logged On " & cID))
				Me.Log("Client " & Sender & "SUCCESS registered.")
			End If
		End Sub

		Private Sub DoRelogin(ByVal Sender As String, ByVal message As String)
			' Message = RELOGIN:<USERNAME>:<PASSWORD>
			Dim parts() As String = message.Split(":"c)
			If AzureDB.LoginUser(message.Split(":"c)(1).ToString(), message.Split(":"c)(2).ToString()) Then
				' Successfully logged in With Correct User ID
				Me.TotalLoggedInUsers += 1
				UpdateLoggedInUsers(TotalLoggedInUsers.ToString("N0"))

				Me.Log("Client " & parts(1).ToString() & " SUCCESS Logged in.")
			Else
				Me.server.SendData(Sender, ConvertStringToBytes("ERROR:Login Details Not Recognized"))
				Me.Log("Client " & Sender & "ERROR:Login Details Not Recognized")
			End If
		End Sub

		Private Sub DoLogin(ByVal Sender As String, ByVal message As String)
			' Message = LOGIN:<USERNAME>:<PASSWORD>
			Dim parts() As String = message.Split(":"c)
			If AzureDB.RegisterUserExists(parts(1).ToString()) Then

				If AzureDB.LoginUser(message.Split(":"c)(1).ToString(), message.Split(":"c)(2).ToString()) Then
					' Successfully logged in
					Dim newSenderId As Integer = AzureDB.GetUsersID(message.Split(":"c)(1).ToString()) ' Get this user's client ID
					Me.server.SendData(Sender, ConvertStringToBytes("ID:" & newSenderId.ToString())) ' Send the correct ID to the Client
					Me.TotalLoggedInUsers += 1
					UpdateLoggedInUsers(TotalLoggedInUsers.ToString("N0"))

					Me.Log("Client " & parts(1).ToString() & " SUCCESS Logged in.")
				Else
					Me.server.SendData(Sender, ConvertStringToBytes("ERROR:Login Details Not Recognized"))
					Me.Log("Client " & Sender & "ERROR:Login Details Not Recognized")
				End If
			Else
				Me.server.SendData(Sender, ConvertStringToBytes("ERROR:Login Details Not Recognized"))
				Me.Log("Client " & Sender & "ERROR:Login Details Not Recognized")
			End If
		End Sub



		Private Sub server_DataReceived(ByVal ID As String, ByVal Data() As Byte)
			Throw New NotImplementedException()
		End Sub

		Private Sub server_ConnectionClosed()
			Throw New NotImplementedException()
		End Sub

		''' <summary>
		''' The Azure Database Connection has changed.
		''' </summary>
		''' <param name="State"></param>
		Private Sub AzureDB_SQLStateChanged(ByVal State As ConnectionState)
			Select Case State
				Case ConnectionState.Broken
					lblConnectionState.Image = My.Resources.database_red ' Show Database connection is off
					lblConnectionState.ToolTipText = "Connection to Azure DB is " & State.ToString()
					Progress.Enabled = False
				Case ConnectionState.Closed
					lblConnectionState.Image = My.Resources.database_red ' Show Database connection is off
					lblConnectionState.ToolTipText = "Connection to Azure DB is " & State.ToString()
					Progress.Enabled = False
				Case ConnectionState.Connecting
					lblConnectionState.Image = My.Resources.database_blue ' Show Database connection is Connecting
					lblConnectionState.ToolTipText = "Connection to Azure DB is " & State.ToString()
					Progress.Enabled = True
				Case ConnectionState.Executing
					lblConnectionState.Image = My.Resources.database_blue ' Show Database connection is Connecting
					lblConnectionState.ToolTipText = "Connection to Azure DB is " & State.ToString()
					Progress.Enabled = True
				Case ConnectionState.Fetching
					lblConnectionState.Image = My.Resources.database_blue ' Show Database connection is Connecting
					lblConnectionState.ToolTipText = "Connection to Azure DB is " & State.ToString()
					Progress.Enabled = True
				Case ConnectionState.Open
					lblConnectionState.Image = My.Resources.database_green ' Show Database connection is Connected
					lblConnectionState.ToolTipText = "Connection to Azure DB is " & State.ToString()
					Progress.Enabled = True
				Case Else
					lblConnectionState.Image = My.Resources.database_red ' Show Database connection is off
					lblConnectionState.ToolTipText = "Connection to Azure DB is " & State.ToString()
					Progress.Enabled = False
			End Select
		End Sub

		''' <summary>
		''' We have a new MEssage from the Azure Database
		''' </summary>
		''' <param name="Message"></param>
		Private Sub AzureDB_SQLInfoMessage(ByVal Message As String)
			Log(Message)
		End Sub

		''' <summary>
		''' Display Logging Messages to Admin
		''' </summary>
		''' <param name="Message"></param>
		Private Sub Log(ByVal Message As String)
			If Me.rtbConOut.InvokeRequired Then
				Dim d As New UpdateLogDelegate(AddressOf Log)
				Me.rtbConOut.Invoke(d, New Object() { Message })
			Else
				rtbConOut.AppendText(Message & Environment.NewLine)
				rtbConOut.Focus()
			End If
		End Sub

		Private Sub UpdateLoggedInUsers(ByVal p As String)
			If Me.lblTotalLoggedInUsers.InvokeRequired Then
				Dim d As New UpdateTotalLoggedInUsersDelegate(AddressOf UpdateLoggedInUsers)
				Me.lblTotalLoggedInUsers.Invoke(d, New Object() { p })
			Else
				lblTotalLoggedInUsers.Text = p

			End If
		End Sub

		''' <summary>
		''' Sets the Public IP Address Label
		''' </summary>
		''' <param name="PublicIP">
		''' String: The public IP Address that the Server is showing the world
		''' </param>
		Private Sub pip_PublicIPKnown(ByVal PublicIP As String)
			If Me.lblIPAddress.InvokeRequired Then
				Dim d As New IPAddressDelegate(AddressOf pip_PublicIPKnown)
				Me.lblIPAddress.Invoke(d, New Object() { PublicIP })
			Else
				lblIPAddress.Text = PublicIP
			End If
		End Sub

		''' <summary>
		''' Do house maintenance before closing.
		''' Including Notifying all users if possible
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub FrmServer_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			' No longer needed now we have a manual Close Down button
			'  CloseServerDown(); // Causes a StackOverFlow of course!
		End Sub

		Private Sub CloseServerDown()
			Try
				' Unsubscribe to Server Events
				RemoveHandler server.ConnectionClosed, AddressOf server_ConnectionClosed
				RemoveHandler server.DataReceived, AddressOf server_DataReceived
				RemoveHandler server.DataTransferred, AddressOf server_DataTransferred
				RemoveHandler server.errEncounter, AddressOf server_errEncounter
				RemoveHandler server.lostConnection, AddressOf server_lostConnection
				RemoveHandler server.onConnection, AddressOf server_onConnection

				' Unsubscribe to PublicIP Events
				RemoveHandler pip.PublicIPKnown, AddressOf pip_PublicIPKnown
				RemoveHandler pip.PublicIPError, AddressOf pip_PublicIPError

				' Unsubscribe to AzureDB Events
				RemoveHandler AzureDB.SQLInfoMessage, AddressOf AzureDB_SQLInfoMessage
				RemoveHandler AzureDB.SQLStateChanged, AddressOf AzureDB_SQLStateChanged
			Catch ex As Exception
				MessageBox.Show(My.Resources.CloseDownError & ex.Message)
				' Later add this error to the external log
			End Try

			Me.Close()
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

		''' <summary>
		''' Close the Server Down
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub btnCloseDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCloseDown.Click
			CloseServerDown()
		End Sub
	End Class
End Namespace
