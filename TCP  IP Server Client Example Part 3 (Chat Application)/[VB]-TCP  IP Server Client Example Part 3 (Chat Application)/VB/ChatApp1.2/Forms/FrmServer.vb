Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports NetComm

Namespace ChatApp1._2.Forms
	Partial Public Class FrmServer
		Inherits Form

		Private server As NetComm.Host = New Host(3333) ' Listens on port 3330.
		Private activeConnections As Integer = 0
		Private Delegate Sub DisplayInformationDelegate(ByVal s As String)
		Private registeredUsers As New Dictionary(Of String, String)()
		Private loggedInUsers As New Dictionary(Of String, String)()


		Public Sub New()
			InitializeComponent()
			AddHandler server.ConnectionClosed, AddressOf Server_ConnectionClosed
			AddHandler server.DataReceived, AddressOf Server_DataReceived
			AddHandler server.DataTransferred, AddressOf Server_DataTransferred
			AddHandler server.errEncounter, AddressOf ServerErrEncounter
			AddHandler server.lostConnection, AddressOf ServerLostConnection
			AddHandler server.onConnection, AddressOf ServerOnConnection

		End Sub

		Private Sub ServerOnConnection(ByVal id As String)
			lblConnections.Text = loggedInUsers.Count.ToString()
			DisplayInformation(String.Format("Client {0} Connected", id))
		End Sub

		Private Sub ServerLostConnection(ByVal id As String)
			lblConnections.Text = loggedInUsers.Count.ToString()
			DisplayInformation(String.Format("Client {0} Lost Connection", id))
		End Sub

		Private Sub ServerErrEncounter(ByVal ex As Exception)
			DisplayInformation("Server Error " & ex.Message)
		End Sub

		Private Sub Server_DataTransferred(ByVal sender As String, ByVal recipient As String, ByVal data() As Byte)

		End Sub

		Private Sub Server_DataReceived(ByVal iD As String, ByVal data() As Byte)
			Dim message As String = ConvertBytesToString(data)
			If iD = "0" Then
				DisplayInformation("Received Command From Client " & iD & " for this Server")


				If message.StartsWith("CLOSING") Then
					loggedInUsers.Remove(iD)
					lblConnections.Text = loggedInUsers.Count.ToString()
					DisplayInformation("Client " & iD & " is Closing")
				ElseIf message.StartsWith("REGISTRATION") Then
					' Message = REGISTRATION:<USERNAME>:<PASSWORD>
					If registeredUsers.ContainsKey(message.Split(":"c)(1).ToString()) Then
						server.SendData(iD, ConvertStringToBytes("ERROR:That email is already registered."))
						DisplayInformation("Client " & iD & "ERROR:That email is already registered.")
					Else
						registeredUsers.Add(message.Split(":"c)(1).ToString(), message.Split(":"c)(2).ToString())
						loggedInUsers.Add(iD, Date.Now.ToString())
						lblConnections.Text = loggedInUsers.Count.ToString()
						server.SendData(iD, ConvertStringToBytes("SUCCESS"))
						DisplayInformation("Client " & iD & "SUCCESS registered.")
					End If
				ElseIf message.StartsWith("LOGIN") Then
					' Message = LOGIN:<USERNAME>:<PASSWORD>
					If registeredUsers.ContainsKey(message.Split(":"c)(1).ToString()) Then
						Dim res As String = ""
						If registeredUsers.TryGetValue(iD, res) Then
							' Successfully logged in
							Dim newSenderId As Integer = (loggedInUsers.Count + 1)
							server.SendData(iD, ConvertStringToBytes("ID:" & newSenderId.ToString()))
							loggedInUsers.Add(newSenderId.ToString(), Date.Now.ToString())
							lblConnections.Text = loggedInUsers.Count.ToString()
							DisplayInformation("Client " & iD & "SUCCESS Logged in.")
						End If
					Else
						server.SendData(iD, ConvertStringToBytes("ERROR:Login Details Not Recognized"))
						DisplayInformation("Client " & iD & "ERROR:Login Details Not Recognized")
					End If
				Else
					DisplayInformation("Received Command From Client " & iD & " for this Server: " & message)
				End If


			Else
				DisplayInformation("Received Command From Client " & iD & " for this Server: " & message)
			End If
		End Sub

		Private Sub Server_ConnectionClosed()
			DisplayInformation("Connection Was Closed")
		End Sub

		Private Sub NewToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles newToolStripMenuItem.Click
			server.StartConnection()
			lblConnectionStatusImage.Image = My.Resources.green_circle_md
		End Sub

		Private Sub DisplayInformation(ByVal s As String)
			If Me.rtbConOut.InvokeRequired Then
				Dim d As New DisplayInformationDelegate(AddressOf DisplayInformation)
				Me.rtbConOut.Invoke(d, New Object() { s })
			Else
				Me.rtbConOut.AppendText(Environment.NewLine & s)
				Me.rtbConOut.Focus()
			End If
		End Sub

		Private Function ConvertBytesToString(ByVal bytes() As Byte) As String
			Return ASCIIEncoding.ASCII.GetString(bytes)
		End Function

		Private Function ConvertStringToBytes(ByVal str As String) As Byte()
			Return ASCIIEncoding.ASCII.GetBytes(str)
		End Function

		Private Sub OpenToolStripMenuItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles openToolStripMenuItem.Click
			server.CloseConnection()
			lblConnectionStatusImage.Image = My.Resources.red_47690_640
		End Sub

		Private Sub BtnNewClient_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNewClient.Click
			Dim chat As New FrmChatMain()
			chat.Show()
		End Sub
	End Class
End Namespace
