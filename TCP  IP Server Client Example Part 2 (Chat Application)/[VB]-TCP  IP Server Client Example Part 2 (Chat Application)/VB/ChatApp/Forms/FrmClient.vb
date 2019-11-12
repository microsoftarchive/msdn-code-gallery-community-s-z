Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Imports NetComm

Namespace ChatApp.Forms
	Partial Public Class FrmClient
		Inherits Form

		Public Overloads Property Name() As String
		Private client As NetComm.Client = New Client()
		Private clientList As New ArrayList()


		Public Sub New()
			InitializeComponent()

		End Sub

		Private Sub FrmClient_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			AddHandler client.Connected, AddressOf ClientConnected
			AddHandler client.DataReceived, AddressOf ClientDataReceived
			AddHandler client.Disconnected, AddressOf ClientDisconnected
			AddHandler client.errEncounter, AddressOf ClientErrEncounter
			client.Connect("127.0.0.1", 3330, Name) ' Port needs to match the Server's port as does the IP Address.
			Me.Text = Name
		End Sub

		Private Sub ClientErrEncounter(ByVal ex As Exception)
			MessageBox.Show("Error: " & ex.Message)
		End Sub

		Private Sub ClientDisconnected()
			MessageBox.Show("You have been Disconnected")
		End Sub

		Private Sub ClientDataReceived(ByVal data() As Byte, ByVal iD As String)
			'CList::
			Dim msg As String = ConvertBytesToString(data)
			If msg.StartsWith("CList::") Then
				Dim msgs As String = msg.Replace("CList::","")
				rtbConOut.AppendText("Clients online Now are " & msgs & Environment.NewLine)
			Else
				rtbConOut.AppendText(msg & Environment.NewLine)
			End If
		End Sub

		Private Sub ClientConnected()
			rtbConOut.AppendText("Connected " & Environment.NewLine)
		End Sub

		Private Function ConvertBytesToString(ByVal bytes() As Byte) As String
			Return ASCIIEncoding.ASCII.GetString(bytes)
		End Function

		Private Function ConvertStringToBytes(ByVal str As String) As Byte()
			Return ASCIIEncoding.ASCII.GetBytes(str)
		End Function

		Private Sub FrmClient_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			client.SendData(ConvertStringToBytes("CLOSING"), "0")
			client.Disconnect()
		End Sub

		Private Sub TbInputKeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles tbInput.KeyUp
			If e.KeyData = Keys.Enter OrElse e.KeyData = Keys.Return Then ' If the user has pressed the enter key
				If tbInput.Text.Length > 0 Then ' If there is something to send
					client.SendData(ConvertStringToBytes(tbInput.Text), "0")
					rtbConOut.AppendText(tbInput.Text & Environment.NewLine)
					tbInput.Text = ""
				End If
			End If
		End Sub

		Private Sub BtnSendClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSend.Click
			If tbInput.Text.Length > 0 Then ' If there is something to send
				client.SendData(ConvertStringToBytes(tbInput.Text), "0")
				rtbConOut.AppendText(tbInput.Text & Environment.NewLine)
				tbInput.Text = ""
			End If
		End Sub
	End Class
End Namespace
