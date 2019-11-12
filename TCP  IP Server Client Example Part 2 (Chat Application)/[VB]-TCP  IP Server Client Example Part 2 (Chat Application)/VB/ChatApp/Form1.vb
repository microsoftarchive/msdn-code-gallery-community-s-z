Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports ChatApp.Forms

Imports NetComm

Namespace ChatApp
	Partial Public Class Form1
		Inherits Form

		Private server As NetComm.Host = New Host(3330) ' Listens on port 3330.
		Private activeConnections As Integer = 0
		Private Delegate Sub DisplayInformationDelegate(ByVal s As String)
		Private clientList As New ArrayList() ' Share amongst all instances of the Clients

		Public Sub New()
			InitializeComponent()
			AddHandler server.ConnectionClosed, AddressOf Server_ConnectionClosed
			AddHandler server.DataReceived, AddressOf Server_DataReceived
			AddHandler server.DataTransferred, AddressOf Server_DataTransferred
			AddHandler server.errEncounter, AddressOf ServerErrEncounter
			AddHandler server.lostConnection, AddressOf ServerLostConnection
			AddHandler server.onConnection, AddressOf ServerOnConnection
			server.StartConnection()
			rtbConOut.AppendText(Environment.NewLine)
		End Sub

		Private Sub ServerOnConnection(ByVal id As String)
			activeConnections += 1
			lblConnections.Text = activeConnections.ToString()
			DisplayInformation(String.Format("Client {0} Connected", id))
			clientList.Add(id)
			SendClientList()
		End Sub

		Private Sub SendClientList()
			DisplayInformation("Sending All Clients a list of currently available clients") ' This is not how we would normally do this
			For Each cid As String In clientList
				For Each cid2 As String In clientList
					Dim d() As Byte = ConvertStringToBytes("CList::" & cid)
					server.SendData(cid2, d)
				Next cid2
			Next cid
		End Sub

		Private Sub ServerLostConnection(ByVal id As String)
			activeConnections -= 1
			lblConnections.Text = activeConnections.ToString()
			DisplayInformation(String.Format("Client {0} Lost Connection", id))
			clientList.Remove(id)
		End Sub

		Private Sub ServerErrEncounter(ByVal ex As Exception)
			DisplayInformation("Server Error " & ex.Message)
		End Sub

		Private Sub Server_DataTransferred(ByVal sender As String, ByVal recipient As String, ByVal data() As Byte)
			Dim senderId As String = CStr(sender)
			If recipient = "0" Then
				DisplayInformation("Received Command From Client " & senderId & " for this Server")
				Select Case ConvertBytesToString(data)
					Case "CLOSING"
						activeConnections -= 1
						lblConnections.Text = activeConnections.ToString()
						DisplayInformation("Client " & senderId & " is Closing")
						clientList.Remove(senderId)
						SendClientList()

					Case Else
						For Each id As String In clientList
							If id <> senderId Then ' Don't send this message to the client that sent the message in the first place
								server.SendData(id, data)
							End If
						Next id
				End Select
			Else
				DisplayInformation("Received Command From Client " & senderId & " for Client " & recipient)
			End If
		End Sub

		Private Sub Server_DataReceived(ByVal iD As String, ByVal data() As Byte)
			If ConvertBytesToString(data) = "CLOSING" Then
				DisplayInformation("Client " & iD & " has closed")
			End If
		End Sub

		Private Sub Server_ConnectionClosed()
			DisplayInformation("Connection Was Closed")
		End Sub

		Private Sub BtnNewClient_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNewClient.Click
			Dim client As New FrmClient()
			client.Name = (activeConnections + 1).ToString()
			client.Show()
		End Sub

		Private Function ConvertBytesToString(ByVal bytes() As Byte) As String
			Return ASCIIEncoding.ASCII.GetString(bytes)
		End Function

		Private Function ConvertStringToBytes(ByVal str As String) As Byte()
			Return ASCIIEncoding.ASCII.GetBytes(str)
		End Function

		Private Sub DisplayInformation(ByVal s As String)
			If Me.rtbConOut.InvokeRequired Then
				Dim d As New DisplayInformationDelegate(AddressOf DisplayInformation)
				Me.rtbConOut.Invoke(d, New Object() { s })
			Else
				Me.rtbConOut.AppendText(s & Environment.NewLine)
			End If
		End Sub
	End Class
End Namespace
