Imports System.Collections.Generic
Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Imports Proshot.CommandServer
Imports System.ComponentModel

Class Program
	Private clients As System.Collections.Generic.List(Of ClientManager)
	Private bwListener As BackgroundWorker
	Private listenerSocket As Socket
	Private serverIP As IPAddress
	Private serverPort As Integer

	''' <summary>
	''' Start the console server.
	''' </summary>
	''' <param name="args">These are optional arguments.Pass the local ip address of the server as the first argument and the local port as the second argument.</param>
	Friend Shared Sub Main(args As String())
		Dim progDomain As New Program()
		progDomain.clients = New List(Of ClientManager)()

		If args.Length = 0 Then
			progDomain.serverPort = 8000
			progDomain.serverIP = IPAddress.Any
		End If
		If args.Length = 1 Then
			progDomain.serverIP = IPAddress.Parse(args(0))
			progDomain.serverPort = 8000
		End If
		If args.Length = 2 Then
			progDomain.serverIP = IPAddress.Parse(args(0))
			progDomain.serverPort = Integer.Parse(args(1))
		End If

		progDomain.bwListener = New BackgroundWorker()
		progDomain.bwListener.WorkerSupportsCancellation = True
		AddHandler progDomain.bwListener.DoWork, New DoWorkEventHandler(AddressOf progDomain.StartToListen)
		progDomain.bwListener.RunWorkerAsync()

		Console.WriteLine("*** Listening on port {0}{1}{2} started.Press ENTER to shutdown server. ***" & vbLf, progDomain.serverIP.ToString(), ":", progDomain.serverPort.ToString())

		Console.ReadLine()

		progDomain.DisconnectServer()
	End Sub

	Private Sub StartToListen(sender As Object, e As DoWorkEventArgs)
        Try
            Me.listenerSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Me.listenerSocket.Bind(New IPEndPoint(Me.serverIP, Me.serverPort))
            Me.listenerSocket.Listen(200)
            While True
                Me.CreateNewClientManager(Me.listenerSocket.Accept())
            End While
        Catch

        End Try
    End Sub
	
	Private Sub CreateNewClientManager(socket As Socket)
        Dim newClientManager As New ClientManager(socket)
        AddHandler newClientManager.CommandReceived, AddressOf CommandReceived
        AddHandler newClientManager.Disconnected, AddressOf ClientDisconnected
		Me.CheckForAbnormalDC(newClientManager)
		Me.clients.Add(newClientManager)
		Me.UpdateConsole("Connected.", newClientManager.IP, newClientManager.Port)
	End Sub

	Private Sub CheckForAbnormalDC(mngr As ClientManager)
		If Me.RemoveClientManager(mngr.IP) Then
			Me.UpdateConsole("Disconnected.", mngr.IP, mngr.Port)
		End If
	End Sub

	Private Sub ClientDisconnected(sender As Object, e As ClientEventArgs)
		If Me.RemoveClientManager(e.IP) Then
			Me.UpdateConsole("Disconnected.", e.IP, e.Port)
		End If
	End Sub

	Private Function RemoveClientManager(ip As IPAddress) As Boolean
		SyncLock Me
			Dim index As Integer = Me.IndexOfClient(ip)
			If index <> -1 Then
				Dim name As String = Me.clients(index).ClientName
				Me.clients.RemoveAt(index)

				'Inform all clients that a client had been disconnected.
				Dim cmd As New Command(CommandType.ClientLogOffInform, IPAddress.Broadcast)
				cmd.SenderName = name
				cmd.SenderIP = ip
				Me.BroadCastCommand(cmd)
				Return True
			End If
			Return False
		End SyncLock
	End Function

	Private Function IndexOfClient(ip As IPAddress) As Integer
		Dim index As Integer = -1
		For Each cMngr As ClientManager In Me.clients
			index += 1
			If cMngr.IP.Equals(ip) Then
				Return index
			End If
		Next
		Return -1
	End Function

	Private Sub CommandReceived(sender As Object, e As CommandEventArgs) 
		'When a client connects to the server sends a 'ClientLoginInform' command with a MetaData in this format :
		'"RemoteClientIP:RemoteClientName". With this information we should set the name of ClientManager and then
		'Send the command to all other remote clients.
		If e.Command.CommandType = CommandType.ClientLoginInform Then
			Me.SetManagerName(e.Command.SenderIP, e.Command.MetaData)
		End If

		'If the client asked for existance of a name,answer to it's question.
		If e.Command.CommandType = CommandType.IsNameExists Then
			Dim isExixsts As Boolean = Me.IsNameExists(e.Command.SenderIP, e.Command.MetaData)
			Me.SendExistanceCommand(e.Command.SenderIP, isExixsts)
			Return
		'If the client asked for list of a logged in clients,replay to it's request.
		ElseIf e.Command.CommandType = CommandType.SendClientList Then
			Me.SendClientListToNewClient(e.Command.SenderIP)
			Return
		End If

		If e.Command.Target.Equals(IPAddress.Broadcast) Then
			Me.BroadCastCommand(e.Command)
		Else
			Me.SendCommandToTarget(e.Command)
		End If

	End Sub

	Private Sub SendExistanceCommand(targetIP As IPAddress, isExists As Boolean)
		Dim cmdExistance As New Command(CommandType.IsNameExists, targetIP, isExists.ToString())
		cmdExistance.SenderIP = Me.serverIP
		cmdExistance.SenderName = "Server"
		Me.SendCommandToTarget(cmdExistance)
	End Sub

	Private Sub SendClientListToNewClient(newClientIP As IPAddress)
		For Each mngr As ClientManager In Me.clients
			If mngr.Connected AndAlso Not mngr.IP.Equals(newClientIP) Then
				Dim cmd As New Command(CommandType.SendClientList, newClientIP)
				cmd.MetaData = (mngr.IP.ToString() & ":") + mngr.ClientName
				cmd.SenderIP = Me.serverIP
				cmd.SenderName = "Server"
				Me.SendCommandToTarget(cmd)
			End If
		Next
	End Sub

	Private Function SetManagerName(remoteClientIP As IPAddress, nameString As String) As String
		Dim index As Integer = Me.IndexOfClient(remoteClientIP)
		If index <> -1 Then
			Dim name As String = nameString.Split(New Char() {":"C})(1)
			Me.clients(index).ClientName = name
			Return name
		End If
		Return ""
	End Function
	Private Function IsNameExists(remoteClientIP As IPAddress, nameToFind As String) As Boolean
		For Each mngr As ClientManager In Me.clients
			If mngr.ClientName = nameToFind AndAlso Not mngr.IP.Equals(remoteClientIP) Then
				Return True
			End If
		Next
		Return False
	End Function

	Private Sub BroadCastCommand(cmd As Command)
		For Each mngr As ClientManager In Me.clients
			If Not mngr.IP.Equals(cmd.SenderIP) Then
				mngr.SendCommand(cmd)
			End If
		Next
	End Sub

	Private Sub SendCommandToTarget(cmd As Command)
		For Each mngr As ClientManager In Me.clients
			If mngr.IP.Equals(cmd.Target) Then
				mngr.SendCommand(cmd)
				Return
			End If
		Next
	End Sub
	Private Sub UpdateConsole(status As String, IP As IPAddress, port As Integer)
		Console.WriteLine("Client {0}{1}{2} has been {3} ( {4}|{5} )", IP.ToString(), ":", port.ToString(), status, DateTime.Now.ToShortDateString(), _
			DateTime.Now.ToLongTimeString())
	End Sub
	Public Sub DisconnectServer()
		If Me.clients IsNot Nothing Then
			For Each mngr As ClientManager In Me.clients
				mngr.Disconnect()
			Next

			Me.bwListener.CancelAsync()
			Me.bwListener.Dispose()
			Me.listenerSocket.Close()
			GC.Collect()
		End If
	End Sub
End Class
