Imports System.Collections.Generic
Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Imports System.ComponentModel

''' <summary>
''' The class that contains some methods and properties to manage the remote clients.
''' </summary>
Public Class ClientManager
	''' <summary>
	''' Gets the IP address of connected remote client.This is 'IPAddress.None' if the client is not connected.
	''' </summary>
	Public ReadOnly Property IP() As IPAddress
		Get
			If Me.socket IsNot Nothing Then
				Return DirectCast(Me.socket.RemoteEndPoint, IPEndPoint).Address
			Else
				Return IPAddress.None
			End If
		End Get
	End Property
	''' <summary>
	''' Gets the port number of connected remote client.This is -1 if the client is not connected.
	''' </summary>
	Public ReadOnly Property Port() As Integer
		Get
			If Me.socket IsNot Nothing Then
				Return DirectCast(Me.socket.RemoteEndPoint, IPEndPoint).Port
			Else
				Return -1
			End If
		End Get
	End Property
	''' <summary>
	''' [Gets] The value that specifies the remote client is connected to this server or not.
	''' </summary>
	Public ReadOnly Property Connected() As Boolean
		Get
			If Me.socket IsNot Nothing Then
				Return Me.socket.Connected
			Else
				Return False
			End If
		End Get
	End Property

	Private socket As Socket
	Private m_clientName As String
	''' <summary>
	''' The name of remote client.
	''' </summary>
	Public Property ClientName() As String
		Get
			Return Me.m_clientName
		End Get
		Set
			Me.m_clientName = value
		End Set
	End Property
	Private networkStream As NetworkStream
	Private bwReceiver As BackgroundWorker

	#Region "Constructor"
	''' <summary>
	''' Creates an instance of ClientManager class to comunicate with remote clients.
	''' </summary>
	''' <param name="clientSocket">The socket of ClientManager.</param>
	Public Sub New(clientSocket As Socket)
		Me.socket = clientSocket
		Me.networkStream = New NetworkStream(Me.socket)
		Me.bwReceiver = New BackgroundWorker()
		AddHandler Me.bwReceiver.DoWork, New DoWorkEventHandler(AddressOf StartReceive)
		Me.bwReceiver.RunWorkerAsync()
	End Sub
	#End Region

	#Region "Private Methods"
	Private Sub StartReceive(sender As Object, e As DoWorkEventArgs)
		While Me.socket.Connected
			'Read the command's Type.
			Dim buffer As Byte() = New Byte(3) {}
			Dim readBytes As Integer = Me.networkStream.Read(buffer, 0, 4)
			If readBytes = 0 Then
				Exit While
			End If
			Dim cmdType As CommandType = CType(BitConverter.ToInt32(buffer, 0), CommandType)

			'Read the command's target size.
			Dim cmdTarget As String = ""
			buffer = New Byte(3) {}
			readBytes = Me.networkStream.Read(buffer, 0, 4)
			If readBytes = 0 Then
				Exit While
			End If
			Dim ipSize As Integer = BitConverter.ToInt32(buffer, 0)

			'Read the command's target.
			buffer = New Byte(ipSize - 1) {}
			readBytes = Me.networkStream.Read(buffer, 0, ipSize)
			If readBytes = 0 Then
				Exit While
			End If
			cmdTarget = System.Text.Encoding.ASCII.GetString(buffer)

			'Read the command's MetaData size.
			Dim cmdMetaData As String = ""
			buffer = New Byte(3) {}
			readBytes = Me.networkStream.Read(buffer, 0, 4)
			If readBytes = 0 Then
				Exit While
			End If
			Dim metaDataSize As Integer = BitConverter.ToInt32(buffer, 0)

			'Read the command's Meta data.
			buffer = New Byte(metaDataSize - 1) {}
			readBytes = Me.networkStream.Read(buffer, 0, metaDataSize)
			If readBytes = 0 Then
				Exit While
			End If
			cmdMetaData = System.Text.Encoding.Unicode.GetString(buffer)

			Dim cmd As New Command(cmdType, IPAddress.Parse(cmdTarget), cmdMetaData)
			cmd.SenderIP = Me.IP
			If cmd.CommandType = CommandType.ClientLoginInform Then
				cmd.SenderName = cmd.MetaData.Split(New Char() {":"C})(1)
			Else
				cmd.SenderName = Me.ClientName
			End If
			Me.OnCommandReceived(New CommandEventArgs(cmd))
		End While
		Me.OnDisconnected(New ClientEventArgs(Me.socket))
		Me.Disconnect()
	End Sub

	Private Sub bwSender_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
		If Not e.Cancelled AndAlso e.[Error] Is Nothing AndAlso CBool(e.Result) Then
			Me.OnCommandSent(New EventArgs())
		Else
			Me.OnCommandFailed(New EventArgs())
		End If

		DirectCast(sender, BackgroundWorker).Dispose()
		GC.Collect()
	End Sub

	Private Sub bwSender_DoWork(sender As Object, e As DoWorkEventArgs)
		Dim cmd As Command = DirectCast(e.Argument, Command)
		e.Result = Me.SendCommandToClient(cmd)
	End Sub

	'This Semaphor is to protect the critical section from concurrent access of sender threads.
	Private semaphor As New System.Threading.Semaphore(1, 1)
	Private Function SendCommandToClient(cmd As Command) As Boolean

		Try
			semaphor.WaitOne()
			'Type
			Dim buffer As Byte() = New Byte(3) {}
			buffer = BitConverter.GetBytes(CInt(cmd.CommandType))
			Me.networkStream.Write(buffer, 0, 4)
			Me.networkStream.Flush()

			'Sender IP
			Dim senderIPBuffer As Byte() = Encoding.ASCII.GetBytes(cmd.SenderIP.ToString())
			buffer = New Byte(3) {}
			buffer = BitConverter.GetBytes(senderIPBuffer.Length)
			Me.networkStream.Write(buffer, 0, 4)
			Me.networkStream.Flush()
			Me.networkStream.Write(senderIPBuffer, 0, senderIPBuffer.Length)
			Me.networkStream.Flush()

			'Sender Name
			Dim senderNameBuffer As Byte() = Encoding.Unicode.GetBytes(cmd.SenderName.ToString())
			buffer = New Byte(3) {}
			buffer = BitConverter.GetBytes(senderNameBuffer.Length)
			Me.networkStream.Write(buffer, 0, 4)
			Me.networkStream.Flush()
			Me.networkStream.Write(senderNameBuffer, 0, senderNameBuffer.Length)
			Me.networkStream.Flush()

			'Target
			Dim ipBuffer As Byte() = Encoding.ASCII.GetBytes(cmd.Target.ToString())
			buffer = New Byte(3) {}
			buffer = BitConverter.GetBytes(ipBuffer.Length)
			Me.networkStream.Write(buffer, 0, 4)
			Me.networkStream.Flush()
			Me.networkStream.Write(ipBuffer, 0, ipBuffer.Length)
			Me.networkStream.Flush()

			'Meta Data.
			If cmd.MetaData Is Nothing OrElse cmd.MetaData = "" Then
				cmd.MetaData = vbLf
			End If

			Dim metaBuffer As Byte() = Encoding.Unicode.GetBytes(cmd.MetaData)
			buffer = New Byte(3) {}
			buffer = BitConverter.GetBytes(metaBuffer.Length)
			Me.networkStream.Write(buffer, 0, 4)
			Me.networkStream.Flush()
			Me.networkStream.Write(metaBuffer, 0, metaBuffer.Length)
			Me.networkStream.Flush()

			semaphor.Release()
			Return True
		Catch
			semaphor.Release()
			Return False
		End Try
	End Function
	#End Region

	#Region "Public Methods"
	''' <summary>
	''' Sends a command to the remote client if the connection is alive.
	''' </summary>
	''' <param name="cmd">The command to send.</param>
	Public Sub SendCommand(cmd As Command)
		If Me.socket IsNot Nothing AndAlso Me.socket.Connected Then
			Dim bwSender As New BackgroundWorker()
			AddHandler bwSender.DoWork, New DoWorkEventHandler(AddressOf bwSender_DoWork)
			AddHandler bwSender.RunWorkerCompleted, New RunWorkerCompletedEventHandler(AddressOf bwSender_RunWorkerCompleted)
			bwSender.RunWorkerAsync(cmd)
		Else
			Me.OnCommandFailed(New EventArgs())
		End If
	End Sub



	''' <summary>
	''' Disconnect the current client manager from the remote client and returns true if the client had been disconnected from the server.
	''' </summary>
	''' <returns>True if the remote client had been disconnected from the server,otherwise false.</returns>
	Public Function Disconnect() As Boolean
		If Me.socket IsNot Nothing AndAlso Me.socket.Connected Then
			Try
				Me.socket.Shutdown(SocketShutdown.Both)
				Me.socket.Close()
				Return True
			Catch
				Return False
			End Try
		Else
			Return True
		End If
	End Function
	#End Region

	#Region "Events"
	''' <summary>
	''' Occurs when a command received from a remote client.
	''' </summary>
	Public Event CommandReceived As CommandReceivedEventHandler
	''' <summary>
	''' Occurs when a command received from a remote client.
	''' </summary>
	''' <param name="e">Received command.</param>
	Protected Overridable Sub OnCommandReceived(e As CommandEventArgs)
		RaiseEvent CommandReceived(Me, e)
	End Sub

	''' <summary>
	''' Occurs when a command had been sent to the remote client successfully.
	''' </summary>
	Public Event CommandSent As CommandSentEventHandler
	''' <summary>
	''' Occurs when a command had been sent to the remote client successfully.
	''' </summary>
	''' <param name="e">The sent command.</param>
	Protected Overridable Sub OnCommandSent(e As EventArgs)
		RaiseEvent CommandSent(Me, e)
	End Sub

	''' <summary>
	''' Occurs when a command sending action had been failed.This is because disconnection or sending exception.
	''' </summary>
	Public Event CommandFailed As CommandSendingFailedEventHandler
	''' <summary>
	''' Occurs when a command sending action had been failed.This is because disconnection or sending exception.
	''' </summary>
	''' <param name="e">The sent command.</param>
	Protected Overridable Sub OnCommandFailed(e As EventArgs)
		RaiseEvent CommandFailed(Me, e)
	End Sub

	''' <summary>
	''' Occurs when a client disconnected from this server.
	''' </summary>
	Public Event Disconnected As DisconnectedEventHandler
	''' <summary>
	''' Occurs when a client disconnected from this server.
	''' </summary>
	''' <param name="e">Client information.</param>
	Protected Overridable Sub OnDisconnected(e As ClientEventArgs)
		RaiseEvent Disconnected(Me, e)
	End Sub

	#End Region
End Class
