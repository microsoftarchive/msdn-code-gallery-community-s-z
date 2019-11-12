Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Namespace ServerApp
	Partial Public Class Form1
		Inherits Form

		Private tcpListener As TcpListener
		Private listenThread As Thread
		Private connectedClients As Integer = 0
		Private Delegate Sub WriteMessageDelegate(ByVal msg As String)

		Public Sub New()
			InitializeComponent()
			Server()
		End Sub

		Private Sub Server()
			Me.tcpListener = New TcpListener(IPAddress.Loopback, 3000) ' Change to IPAddress.Any for internet wide Communication
			Me.listenThread = New Thread(New ThreadStart(AddressOf ListenForClients))
			Me.listenThread.Start()
		End Sub

		Private Sub ListenForClients()
			Me.tcpListener.Start()

			Do ' Never ends until the Server is closed.
				'blocks until a client has connected to the server
				Dim client As TcpClient = Me.tcpListener.AcceptTcpClient()

				'create a thread to handle communication 
				'with connected client
				connectedClients += 1 ' Increment the number of clients that have communicated with us.
				lblNumberOfConnections.Text = connectedClients.ToString()

				Dim clientThread As New Thread(New ParameterizedThreadStart(AddressOf HandleClientComm))
				clientThread.Start(client)
			Loop
		End Sub

		Private Sub HandleClientComm(ByVal client As Object)
			Dim tcpClient As TcpClient = DirectCast(client, TcpClient)
			Dim clientStream As NetworkStream = tcpClient.GetStream()

			Dim message(4095) As Byte
			Dim bytesRead As Integer

			Do
				bytesRead = 0

				Try
					'blocks until a client sends a message
					bytesRead = clientStream.Read(message, 0, 4096)
				Catch
					'a socket error has occured
					Exit Do
				End Try

				If bytesRead = 0 Then
					'the client has disconnected from the server
					connectedClients -= 1
					lblNumberOfConnections.Text = connectedClients.ToString()
					Exit Do
				End If

				'message has successfully been received
				Dim encoder As New ASCIIEncoding()

				' Convert the Bytes received to a string and display it on the Server Screen
				Dim msg As String = encoder.GetString(message, 0, bytesRead)
				WriteMessage(msg)

				' Now Echo the message back

				Echo(msg, encoder, clientStream)
			Loop

			tcpClient.Close()
		End Sub

		Private Sub WriteMessage(ByVal msg As String)
			If Me.rtbServer.InvokeRequired Then
				Dim d As New WriteMessageDelegate(AddressOf WriteMessage)
				Me.rtbServer.Invoke(d, New Object() { msg })
			Else
				Me.rtbServer.AppendText(msg & Environment.NewLine)
			End If
		End Sub

		''' <summary>
		''' Echo the message back to the sending client
		''' </summary>
		''' <param name="msg">
		''' String: The Message to send back
		''' </param>
		''' <param name="encoder">
		''' Our ASCIIEncoder
		''' </param>
		''' <param name="clientStream">
		''' The Client to communicate to
		''' </param>
		Private Sub Echo(ByVal msg As String, ByVal encoder As ASCIIEncoding, ByVal clientStream As NetworkStream)
			' Now Echo the message back
			Dim buffer() As Byte = encoder.GetBytes(msg)

			clientStream.Write(buffer, 0, buffer.Length)
			clientStream.Flush()
		End Sub
	End Class
End Namespace
