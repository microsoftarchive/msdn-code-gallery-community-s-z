Imports System
Imports System.Collections.Generic
Imports System.IO
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

		Private Delegate Sub DisplayConnectionsDelegate(ByVal s As String)

		Private registeredUsers As New Dictionary(Of String, String)()
		Private loggedInUsers As New Dictionary(Of String, String)()

		Private startupPath As String = Application.StartupPath.ToString()

		Public Sub New()
			InitializeComponent()
			startupPath = Path.Combine(startupPath, "users.db")
			LoadRegisteredUsers() ' for very large FlatFile databases this should be done on a separate thread. But really you should use a Database
			AddHandler server.ConnectionClosed, AddressOf Server_ConnectionClosed
			AddHandler server.DataReceived, AddressOf Server_DataReceived
			AddHandler server.DataTransferred, AddressOf Server_DataTransferred
			AddHandler server.errEncounter, AddressOf ServerErrEncounter
			AddHandler server.lostConnection, AddressOf ServerLostConnection
			AddHandler server.onConnection, AddressOf ServerOnConnection
			AddHandler Me.FormClosing, AddressOf FrmServer_FormClosing
		End Sub

		Private Sub FrmServer_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
			SaveRegisteredUsers()
		End Sub

		Private Sub SaveRegisteredUsers()
			' Not the best way to save the users.
			Dim fs As FileStream = Nothing
			Dim sw As StreamWriter = Nothing
			Try
				fs = New FileStream(startupPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Inheritable)
				sw = New StreamWriter(fs)

				sw.WriteLine("# Updated Last on: " & Date.UtcNow.ToString())
				For Each entry As KeyValuePair(Of String, String) In registeredUsers
					Dim line As String = entry.Key & "," & entry.Value ' longer appendings to string should be done through StringBuilder as it is so much faster!
					sw.WriteLine(line)
				Next entry

				sw.Close()
				fs.Close()
			Catch ex As Exception
				MessageBox.Show("SaveRegisteredUsers: Failed to load registered users" & Environment.NewLine & ex.Message)
				If sw IsNot Nothing Then
					sw.Close()
				End If
				If fs IsNot Nothing Then
					fs.Close()
				End If
			End Try
		End Sub

		Private Sub LoadRegisteredUsers()
			Dim fs As FileStream = Nothing
			Dim sr As StreamReader = Nothing

			Try
				fs = New FileStream(startupPath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Inheritable)
				sr = New StreamReader(fs)
				Do While Not sr.EndOfStream ' While there is something to read.
					Dim line As String = sr.ReadLine()
					If line.StartsWith("#") Then
						' Ignore comments for just now
					ElseIf String.IsNullOrWhiteSpace(line) Then
						' ignore blank lines
					Else
						' Process the line.
						Dim parts() As String = line.Split(","c) ' separate each value in the line into their respective parts.
						' Part[0] is always the user's email address
						' Part[1] is always the password for the user
						Try
							registeredUsers.Add(parts(0).ToString(), parts(1).ToString())
						Catch ex As Exception
							' If we get here the database is probably corrupt!
							MessageBox.Show("LoadRegisteredUsers: User's Database may be corrupt!" & Environment.NewLine & ex.Message)
						End Try
					End If
				Loop
				sr.Close()
				fs.Close()
			Catch ex As Exception
				MessageBox.Show("LoadRegisteredUsers: Failed to load registered users" & Environment.NewLine & ex.Message)
				If sr IsNot Nothing Then
					sr.Close()
				End If
				If fs IsNot Nothing Then
					fs.Close()
				End If
			End Try
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
					DisplayConnection(loggedInUsers.Count.ToString())
					DisplayInformation("Client " & iD & " is Closing")
				ElseIf message.StartsWith("REGISTRATION") Then
					' Message = REGISTRATION:<USERNAME>:<PASSWORD>
					If registeredUsers.ContainsKey(message.Split(":"c)(1).ToString()) Then
						server.SendData(iD, ConvertStringToBytes("ERROR:That email is already registered."))
						DisplayInformation("Client " & iD & "ERROR:That email is already registered.")
					Else
						registeredUsers.Add(message.Split(":"c)(1).ToString(), message.Split(":"c)(2).ToString())
						loggedInUsers.Add(iD, Date.Now.ToString())
						DisplayConnection(loggedInUsers.Count.ToString())
						server.SendData(iD, ConvertStringToBytes("SUCCESS:Logged On"))
						DisplayInformation("Client " & iD & "SUCCESS registered.")
					End If
				ElseIf message.StartsWith("LOGIN") Then
					' Message = LOGIN:<USERNAME>:<PASSWORD>
					Dim parts() As String = message.Split(":"c)
					If registeredUsers.ContainsKey(parts(1).ToString()) Then
						Dim res As String = ""
						If registeredUsers.TryGetValue(parts(1).ToString(), res) Then
							If res = parts(2) Then
								' Successfully logged in
								Dim newSenderId As Integer = (loggedInUsers.Count + 1)
								server.SendData(iD, ConvertStringToBytes("ID:" & newSenderId.ToString()))
								loggedInUsers.Add(newSenderId.ToString(), Date.Now.ToString())
								DisplayConnection(loggedInUsers.Count.ToString())
								DisplayInformation("Client " & parts(1).ToString() & " SUCCESS Logged in.")


							Else
								server.SendData(iD, ConvertStringToBytes("ERROR:Login Details Not Recognized"))
								DisplayInformation("Client " & iD & "ERROR:Login Details Not Recognized")
							End If
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

		Private Sub DisplayConnection(ByVal s As String)
			If Me.toolStrip1.InvokeRequired Then
				Dim d As New DisplayConnectionsDelegate(AddressOf DisplayConnection)
				Me.toolStrip1.Invoke(d, New Object() { s })
			Else
				lblConnections.Text = s
			End If

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
