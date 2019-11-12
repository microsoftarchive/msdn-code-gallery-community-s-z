Imports System
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports ChatApp1._2.Forms
Imports NetComm

Namespace ChatApp1._2
	Partial Public Class FrmChatMain
		Inherits Form

		Private client As NetComm.Client = New Client()
		Private cID As Integer = 0
		Private message As String = ""

		Public Sub New()
			InitializeComponent()
			AddHandler client.Connected, AddressOf ClientConnected
			AddHandler client.DataReceived, AddressOf ClientDataReceived
			AddHandler client.Disconnected, AddressOf ClientDisconnected
			AddHandler client.errEncounter, AddressOf ClientErrEncounter
		End Sub

		Private Sub ClientErrEncounter(ByVal ex As Exception)
			Throw New NotImplementedException()
		End Sub

		Private Sub ClientDisconnected()
			lblOnlineStatusImage.Image = My.Resources.red_47690_640
		End Sub

		Private Sub ClientDataReceived(ByVal data() As Byte, ByVal iD As String)
			Dim message As String = ConvertBytesToString(data)

			If iD Is Nothing Then ' Message from the server
				If message = "ERROR:That email is already registered." Then
					MessageBox.Show(message)
				ElseIf message = "ERROR:Login Details Not Recognized" Then
					MessageBox.Show(message)
				ElseIf message = "SUCCESS:Logged On" Then
					' SendFriendsList();
					' GetMyID();
					' 
				End If
			Else
				' Message from a friend
			End If
		End Sub

		Private Sub ClientConnected()
			lblOnlineStatusImage.Image = My.Resources.green_circle_md

			'  LOGIN:<USERNAME>:<PASSWORD>
			client.SendData(ConvertStringToBytes(message))
		End Sub

		' Connect to the Service
		Private Sub BtnConnectClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnConnect.Click
			Connect()
		End Sub

		Private Sub MenuConnectClick(ByVal sender As Object, ByVal e As EventArgs) Handles menuConnect.Click
			Connect()
		End Sub

		Private Sub Connect()
			Dim login As New FrmLogin()
			Dim dr As New DialogResult()
			dr = login.ShowDialog()

			If dr = System.Windows.Forms.DialogResult.OK Then
				client.Connect("127.0.0.1", 3333, cID.ToString())
				'  LOGIN:<USERNAME>:<PASSWORD>
				message = "LOGIN:" & login.EmailAddress & ":" & login.Password

			ElseIf login.IsRegistered Then
				client.Connect("127.0.0.1", 3333, cID.ToString())
				'  REGISTRATION:<USERNAME>:<PASSWORD>
				message = "REGISTRATION:" & login.EmailAddress & ":" & login.Password
			End If
		End Sub

		Private Function ConvertBytesToString(ByVal bytes() As Byte) As String
			Return ASCIIEncoding.ASCII.GetString(bytes)
		End Function

		Private Function ConvertStringToBytes(ByVal str As String) As Byte()
			Return ASCIIEncoding.ASCII.GetBytes(str)
		End Function


	End Class
End Namespace
