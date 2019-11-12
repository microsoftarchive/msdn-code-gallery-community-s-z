Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Windows.Forms

Namespace ClientApp
	Partial Public Class Form1
		Inherits Form

		Private myMessage As String = ""
	   Private client As New TcpClient()
		Private serverEndPoint As New IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000)

		Public Sub New()
			InitializeComponent()
			client.Connect(serverEndPoint)

		End Sub

		Private Sub RtbClientKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles rtbClient.KeyDown
			If e.KeyData <> Keys.Enter OrElse e.KeyData <> Keys.Return Then
				myMessage &= ChrW(e.KeyValue)
			Else
				SendMessage(myMessage)
				myMessage = ""

			End If
		End Sub

		Private Sub SendMessage(ByVal msg As String)
			Dim clientStream As NetworkStream = client.GetStream()

			Dim encoder As New ASCIIEncoding()
			Dim buffer() As Byte = encoder.GetBytes(msg)

			clientStream.Write(buffer, 0, buffer.Length)
			clientStream.Flush()

			' Receive the TcpServer.response.

			' Buffer to store the response bytes.
			Dim data(255) As Byte

			' String to store the response ASCII representation.
			Dim responseData As String = String.Empty

			' Read the first batch of the TcpServer response bytes.
			Dim bytes As Int32 = clientStream.Read(data, 0, data.Length)
			responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes)

			rtbClient.AppendText(Environment.NewLine & "From Server: " & responseData)
		End Sub


	End Class
End Namespace
