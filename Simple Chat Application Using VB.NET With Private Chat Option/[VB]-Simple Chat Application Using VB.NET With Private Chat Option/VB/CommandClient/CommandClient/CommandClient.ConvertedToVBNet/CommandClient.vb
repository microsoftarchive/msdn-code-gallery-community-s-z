Imports System.Collections.Generic
Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.ComponentModel
Imports System.Windows.Forms

''' <summary>
''' The command client command class.
''' </summary>
Public Class CMDClient
	Private clientSocket As Socket
	Private networkStream As NetworkStream
	Private bwReceiver As BackgroundWorker
	Private serverEP As IPEndPoint
	Private m_networkName As String

	''' <summary>
	''' [Gets] The value that specifies the current client is connected or not.
	''' </summary>
	Public ReadOnly Property Connected() As Boolean
		Get
			If Me.clientSocket IsNot Nothing Then
				Return Me.clientSocket.Connected
			Else
				Return False
			End If
		End Get
	End Property
	''' <summary>
	''' [Gets] The IP address of the remote server.If this client is disconnected,this property returns IPAddress.None.
	''' </summary>
	Public ReadOnly Property ServerIP() As IPAddress
		Get
			If Me.Connected Then
				Return Me.serverEP.Address
			Else
				Return IPAddress.None
			End If
		End Get
	End Property

	''' <summary>
	''' [Gets] The comunication port of the remote server.If this client is disconnected,this property returns -1.
	''' </summary>
	Public ReadOnly Property ServerPort() As Integer
		Get
			If Me.Connected Then
				Return Me.serverEP.Port
			Else
				Return -1
			End If
		End Get
	End Property
	''' <summary>
	''' [Gets] The IP address of this client.If this client is disconnected,this property returns IPAddress.None.
	''' </summary>
	Public ReadOnly Property IP() As IPAddress
		Get
			If Me.Connected Then
				Return DirectCast(Me.clientSocket.LocalEndPoint, IPEndPoint).Address
			Else
				Return IPAddress.None
			End If
		End Get
	End Property
	''' <summary>
	''' [Gets] The comunication port of this client.If this client is disconnected,this property returns -1.
	''' </summary>
	Public ReadOnly Property Port() As Integer
		Get
			If Me.Connected Then
				Return DirectCast(Me.clientSocket.LocalEndPoint, IPEndPoint).Port
			Else
				Return -1
			End If
		End Get
	End Property
	''' <summary>
	''' [Gets/Sets] The string that will sent to the server and then to other clients, to identify this client to them.
	''' </summary>
	Public Property NetworkName() As String
		Get
			Return m_networkName
		End Get
		Set
			m_networkName = value
		End Set
	End Property

	#Region "Contsructors"
	''' <summary>
	''' Cretaes a command client instance.
	''' </summary>
	''' <param name="server">The remote server to connect.</param>
	''' <param name="netName">The string that will send to the server and then to other clients, to identify this client to all clients.</param>
	Public Sub New(server As IPEndPoint, netName As String)
		Me.serverEP = server
		Me.m_networkName = netName
		AddHandler System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged, New System.Net.NetworkInformation.NetworkAvailabilityChangedEventHandler(AddressOf NetworkChange_NetworkAvailabilityChanged)
	End Sub

	''' <summary>
	''' Cretaes a command client instance.
	''' </summary>
	'''<param name="serverIP">The IP of remote server.</param>
	'''<param name="port">The port of remote server.</param>
	''' <param name="netName">The string that will send to the server and then to other clients, to identify this client to all clients.</param>
	Public Sub New(serverIP As IPAddress, port As Integer, netName As String)
		Me.serverEP = New IPEndPoint(serverIP, port)
		Me.m_networkName = netName
		AddHandler System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged, New System.Net.NetworkInformation.NetworkAvailabilityChangedEventHandler(AddressOf NetworkChange_NetworkAvailabilityChanged)
	End Sub

	#End Region

	#Region "Private Methods"

	Private Sub NetworkChange_NetworkAvailabilityChanged(sender As Object, e As System.Net.NetworkInformation.NetworkAvailabilityEventArgs)
		If Not e.IsAvailable Then
			Me.OnNetworkDead(New EventArgs())
			Me.OnDisconnectedFromServer(New EventArgs())
		Else
			Me.OnNetworkAlived(New EventArgs())
		End If
	End Sub

	Private Sub StartReceive(sender As Object, e As DoWorkEventArgs)
		While Me.clientSocket.Connected
			'Read the command's Type.
			Dim buffer As Byte() = New Byte(3) {}
			Dim readBytes As Integer = Me.networkStream.Read(buffer, 0, 4)
			If readBytes = 0 Then
				Exit While
			End If
			Dim cmdType As CommandType = CType(BitConverter.ToInt32(buffer, 0), CommandType)

			'Read the command's sender ip size.
			buffer = New Byte(3) {}
			readBytes = Me.networkStream.Read(buffer, 0, 4)
			If readBytes = 0 Then
				Exit While
			End If
			Dim senderIPSize As Integer = BitConverter.ToInt32(buffer, 0)

			'Read the command's sender ip.
			buffer = New Byte(senderIPSize - 1) {}
			readBytes = Me.networkStream.Read(buffer, 0, senderIPSize)
			If readBytes = 0 Then
				Exit While
			End If
			Dim senderIP As IPAddress = IPAddress.Parse(System.Text.Encoding.ASCII.GetString(buffer))

			'Read the command's sender name size.
			buffer = New Byte(3) {}
			readBytes = Me.networkStream.Read(buffer, 0, 4)
			If readBytes = 0 Then
				Exit While
			End If
			Dim senderNameSize As Integer = BitConverter.ToInt32(buffer, 0)

			'Read the command's sender name.
			buffer = New Byte(senderNameSize - 1) {}
			readBytes = Me.networkStream.Read(buffer, 0, senderNameSize)
			If readBytes = 0 Then
				Exit While
			End If
			Dim senderName As String = System.Text.Encoding.Unicode.GetString(buffer)

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
			cmd.SenderIP = senderIP
			cmd.SenderName = senderName
			Me.OnCommandReceived(New CommandEventArgs(cmd))
		End While
		Me.OnServerDisconnected(New ServerEventArgs(Me.clientSocket))
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
		e.Result = Me.SendCommandToServer(cmd)
	End Sub

	'This Semaphor is to protect the critical section from concurrent access of sender threads.
	Private semaphor As New System.Threading.Semaphore(1, 1)
	Private Function SendCommandToServer(cmd As Command) As Boolean
		Try
			semaphor.WaitOne()
			If cmd.MetaData Is Nothing OrElse cmd.MetaData = "" Then
				Me.SetMetaDataIfIsNull(cmd)
			End If
			'CommandType
			Dim buffer As Byte() = New Byte(3) {}
			buffer = BitConverter.GetBytes(CInt(cmd.CommandType))
			Me.networkStream.Write(buffer, 0, 4)
			Me.networkStream.Flush()
			'Command Target
			Dim ipBuffer As Byte() = Encoding.ASCII.GetBytes(cmd.Target.ToString())
			buffer = New Byte(3) {}
			buffer = BitConverter.GetBytes(ipBuffer.Length)
			Me.networkStream.Write(buffer, 0, 4)
			Me.networkStream.Flush()
			Me.networkStream.Write(ipBuffer, 0, ipBuffer.Length)
			Me.networkStream.Flush()
			'Command MetaData
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

	Private Sub SetMetaDataIfIsNull(cmd As Command)
		Select Case cmd.CommandType
			Case (CommandType.ClientLoginInform)
				cmd.MetaData = Me.IP.ToString() & ":" & Me.m_networkName
				Exit Select
			Case (CommandType.PCLockWithTimer), (CommandType.PCLogOFFWithTimer), (CommandType.PCRestartWithTimer), (CommandType.PCShutDownWithTimer), (CommandType.UserExitWithTimer)
				cmd.MetaData = "60000"
				Exit Select
			Case Else
				cmd.MetaData = vbLf
				Exit Select
		End Select
	End Sub

	#End Region

	#Region "Public Methods"
	''' <summary>
    ''' Connect the current instance of command client to the server.This method throws ServerNotFoundException on failure.Run this method and handle the 'ConnectingSuccessed' and 'ConnectingFailed' to get the connection state.
	''' </summary>
	Public Sub ConnectToServer()
		Dim bwConnector As New BackgroundWorker()
		AddHandler bwConnector.DoWork, New DoWorkEventHandler(AddressOf bwConnector_DoWork)
		AddHandler bwConnector.RunWorkerCompleted, New RunWorkerCompletedEventHandler(AddressOf bwConnector_RunWorkerCompleted)
		bwConnector.RunWorkerAsync()
	End Sub

	Private Sub bwConnector_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
		If Not CBool(e.Result) Then
			Me.OnConnectingFailed(New EventArgs())
		Else
			Me.OnConnectingSuccessed(New EventArgs())
		End If

		DirectCast(sender, BackgroundWorker).Dispose()
	End Sub

	Private Sub bwConnector_DoWork(sender As Object, e As DoWorkEventArgs)
		Try
			Me.clientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
			Me.clientSocket.Connect(Me.serverEP)
			e.Result = True
			Me.networkStream = New NetworkStream(Me.clientSocket)
			Me.bwReceiver = New BackgroundWorker()
			Me.bwReceiver.WorkerSupportsCancellation = True
			AddHandler Me.bwReceiver.DoWork, New DoWorkEventHandler(AddressOf StartReceive)
			Me.bwReceiver.RunWorkerAsync()

			'Inform to all clients that this client is now online.
			Dim informToAllCMD As New Command(CommandType.ClientLoginInform, IPAddress.Broadcast, Me.IP.ToString() & ":" & Me.m_networkName)
			Me.SendCommand(informToAllCMD)
		Catch
			e.Result = False
		End Try
	End Sub
	''' <summary>
	''' Sends a command to the server if the connection is alive.
	''' </summary>
	''' <param name="cmd">The command to send.</param>
	Public Sub SendCommand(cmd As Command)
		If Me.clientSocket IsNot Nothing AndAlso Me.clientSocket.Connected Then
			Dim bwSender As New BackgroundWorker()
			AddHandler bwSender.DoWork, New DoWorkEventHandler(AddressOf bwSender_DoWork)
			AddHandler bwSender.RunWorkerCompleted, New RunWorkerCompletedEventHandler(AddressOf bwSender_RunWorkerCompleted)
			bwSender.WorkerSupportsCancellation = True
			bwSender.RunWorkerAsync(cmd)
		Else
			Me.OnCommandFailed(New EventArgs())
		End If
	End Sub

	''' <summary>
	''' Disconnect the client from the server and returns true if the client had been disconnected from the server.
	''' </summary>
	''' <returns>True if the client had been disconnected from the server,otherwise false.</returns>
	Public Function Disconnect() As Boolean
		If Me.clientSocket IsNot Nothing AndAlso Me.clientSocket.Connected Then
			Try
				Me.clientSocket.Shutdown(SocketShutdown.Both)
				Me.clientSocket.Close()
				Me.bwReceiver.CancelAsync()
				Me.OnDisconnectedFromServer(New EventArgs())
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
    ''' <param name="e">The received command.</param>
    Protected Overridable Sub OnCommandReceived(e As CommandEventArgs)
        'If CommandReceived IsNot Nothing Then
        '    Dim target As Control = TryCast(CommandReceived.Target, Control)
        '    If target IsNot Nothing AndAlso target.InvokeRequired Then
        '        target.Invoke(CommandReceived, New Object() {Me, e})
        '    Else
        RaiseEvent CommandReceived(Me, e)
        '    End If
        'End If
    End Sub


	''' <summary>
	''' Occurs when a command had been sent to the the remote server Successfully.
	''' </summary>
	Public Event CommandSent As CommandSentEventHandler
	''' <summary>
	''' Occurs when a command had been sent to the the remote server Successfully.
	''' </summary>
	''' <param name="e">The sent command.</param>
	Protected Overridable Sub OnCommandSent(e As EventArgs)
        'If CommandSent IsNot Nothing Then
        'Dim target As Control = TryCast(CommandSent.Target, Control)
        'If target IsNot Nothing AndAlso target.InvokeRequired Then
        'target.Invoke(CommandSent, New Object() {Me, e})
        'Else
        RaiseEvent CommandSent(Me, e)
        'End If
        'End If
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
        'If CommandFailed IsNot Nothing Then
        '	Dim target As Control = TryCast(CommandFailed.Target, Control)
        '	If target IsNot Nothing AndAlso target.InvokeRequired Then
        '		target.Invoke(CommandFailed, New Object() {Me, e})
        '	Else
        RaiseEvent CommandFailed(Me, e)
        '	End If
        'End If
	End Sub

	''' <summary>
	''' Occurs when the client disconnected.
	''' </summary>
	Public Event ServerDisconnected As ServerDisconnectedEventHandler
	''' <summary>
	''' Occurs when the server disconnected.
	''' </summary>
	''' <param name="e">Server information.</param>
	Protected Overridable Sub OnServerDisconnected(e As ServerEventArgs)
        'If ServerDisconnected IsNot Nothing Then
        '	Dim target As Control = TryCast(ServerDisconnected.Target, Control)
        '	If target IsNot Nothing AndAlso target.InvokeRequired Then
        '		target.Invoke(ServerDisconnected, New Object() {Me, e})
        '	Else
        RaiseEvent ServerDisconnected(Me, e)
        '	End If
        'End If
	End Sub

	''' <summary>
	''' Occurs when this client disconnected from the remote server.
	''' </summary>
	Public Event DisconnectedFromServer As DisconnectedEventHandler
	''' <summary>
	''' Occurs when this client disconnected from the remote server.
	''' </summary>
	''' <param name="e">EventArgs.</param>
	Protected Overridable Sub OnDisconnectedFromServer(e As EventArgs)
        'If DisconnectedFromServer IsNot Nothing Then
        '	Dim target As Control = TryCast(DisconnectedFromServer.Target, Control)
        '	If target IsNot Nothing AndAlso target.InvokeRequired Then
        '		target.Invoke(DisconnectedFromServer, New Object() {Me, e})
        '	Else
        RaiseEvent DisconnectedFromServer(Me, e)
        '	End If
        'End If
	End Sub

	''' <summary>
	''' Occurs when this client connected to the remote server Successfully.
	''' </summary>
	Public Event ConnectingSuccessed As ConnectingSuccessedEventHandler
	''' <summary>
	''' Occurs when this client connected to the remote server Successfully.
	''' </summary>
	''' <param name="e">EventArgs.</param>
	Protected Overridable Sub OnConnectingSuccessed(e As EventArgs)
        'If ConnectingSuccessed IsNot Nothing Then
        '	Dim target As Control = TryCast(ConnectingSuccessed.Target, Control)
        '	If target IsNot Nothing AndAlso target.InvokeRequired Then
        '		target.Invoke(ConnectingSuccessed, New Object() {Me, e})
        '	Else
        RaiseEvent ConnectingSuccessed(Me, e)
        '	End If
        'End If
	End Sub

	''' <summary>
	''' Occurs when this client failed on connecting to server.
	''' </summary>
	Public Event ConnectingFailed As ConnectingFailedEventHandler
	''' <summary>
	''' Occurs when this client failed on connecting to server.
	''' </summary>
	''' <param name="e">EventArgs.</param>
	Protected Overridable Sub OnConnectingFailed(e As EventArgs)
        'If ConnectingFailed IsNot Nothing Then
        '	Dim target As Control = TryCast(ConnectingFailed.Target, Control)
        '	If target IsNot Nothing AndAlso target.InvokeRequired Then
        '		target.Invoke(ConnectingFailed, New Object() {Me, e})
        '	Else
        RaiseEvent ConnectingFailed(Me, e)
        '	End If
        'End If
	End Sub

	''' <summary>
	''' Occurs when the network had been failed.
	''' </summary>
	Public Event NetworkDead As NetworkDeadEventHandler
	''' <summary>
	''' Occurs when the network had been failed.
	''' </summary>
	''' <param name="e">EventArgs.</param>
	Protected Overridable Sub OnNetworkDead(e As EventArgs)
        'If NetworkDead IsNot Nothing Then
        '	Dim target As Control = TryCast(NetworkDead.Target, Control)
        '	If target IsNot Nothing AndAlso target.InvokeRequired Then
        '		target.Invoke(NetworkDead, New Object() {Me, e})
        '	Else
        RaiseEvent NetworkDead(Me, e)
        '	End If
        'End If
	End Sub

	''' <summary>
	''' Occurs when the network had been started to work.
	''' </summary>
	Public Event NetworkAlived As NetworkAlivedEventHandler
	''' <summary>
	''' Occurs when the network had been started to work.
	''' </summary>
	''' <param name="e">EventArgs.</param>
	Protected Overridable Sub OnNetworkAlived(e As EventArgs)
        'If NetworkAlived IsNot Nothing Then
        '	Dim target As Control = TryCast(NetworkAlived.Target, Control)
        '	If target IsNot Nothing AndAlso target.InvokeRequired Then
        '		target.Invoke(NetworkAlived, New Object() {Me, e})
        '	Else
        RaiseEvent NetworkAlived(Me, e)
        '	End If
        'End If
	End Sub

	#End Region
End Class
