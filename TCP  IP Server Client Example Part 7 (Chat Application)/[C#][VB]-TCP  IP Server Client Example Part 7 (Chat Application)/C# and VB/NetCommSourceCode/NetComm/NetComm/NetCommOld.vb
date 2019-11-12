Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Public Class Host
    Private Listens As Boolean = False
    ''' <summary>
    ''' Raised everytime data received.
    ''' </summary>
    ''' <param name="Data">Set of bytes received.</param>
    ''' <param name="ID">The sender ID.</param>
    ''' <remarks></remarks>
    Public Event DataReceived(ByVal ID As String, ByVal Data() As Byte)
    ''' <summary>
    ''' Raised everytime a client sent data to another client.
    ''' </summary>
    ''' <param name="Sender">The sender client ID.</param>
    ''' <param name="Recipient">The target client ID.</param>
    ''' <param name="Data">The data was sent.</param>
    ''' <remarks></remarks>
    Public Event DataTransferred(ByVal Sender As String, ByVal Recipient As String, ByVal Data() As Byte)
    ''' <summary>
    ''' Raised everytime an error had occured.
    ''' </summary>
    ''' <param name="ex">The exception occured.</param>
    ''' <remarks></remarks>
    Public Event errEncounter(ByVal ex As Exception)
    ''' <summary>
    ''' Raised everytime a client connected.
    ''' </summary>
    ''' <param name="id">The client connected ID.</param>
    ''' <remarks></remarks>
    Public Event onConnection(ByVal id As String)
    ''' <summary>
    ''' Raised everytime a client disconnected.
    ''' </summary>
    ''' <param name="id">The client disconnected ID.</param>
    ''' <remarks></remarks>
    Public Event lostConnection(ByVal id As String)
    ''' <summary>
    ''' Raised everytime the connection was closed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event ConnectionClosed()
    Private Clients As New List(Of TcpClientHandler)
    Private netStream As NetworkStream
    Private Context As SynchronizationContext
    Private T As Thread
    Private serverSocket As TcpListener
    Private clientSocket As TcpClient
    Private Structure DataPacket
        Dim Sender As String
        Dim Recipient As String
        Dim Data() As Byte
        Public Sub New(ByVal SenderID As String, ByVal RecipientID As String, ByVal DataBytes() As Byte)
            Sender = SenderID
            Recipient = RecipientID
            Data = DataBytes
        End Sub
    End Structure
    Private Enum EventPointer
        DataReceived = 0
        errEncounter = 1
        onConnection = 2
        lostConnection = 3
        ConnectionClosed = 4
        DataTransferred = 5
    End Enum
    Private Sub EventHandler(ByVal Args As EventArgs)
        Select Case Args.EventP
            Case EventPointer.DataReceived
                RaiseEvent DataReceived(Args.Arg.ID, Args.Arg.Data)
            Case EventPointer.DataTransferred
                RaiseEvent DataTransferred(Args.Arg.Sender, Args.Arg.Recipient, Args.Arg.Data)
            Case EventPointer.errEncounter
                RaiseEvent errEncounter(Args.Arg)
            Case EventPointer.onConnection
                RaiseEvent onConnection(Args.Arg)
            Case EventPointer.lostConnection
                RaiseEvent lostConnection(Args.Arg)
            Case EventPointer.ConnectionClosed
                RaiseEvent ConnectionClosed()
        End Select
    End Sub
    Private Sub EventRaise(ByVal EventPoint As EventPointer, Optional ByVal Arg As Object = Nothing)
        If Not Context Is Nothing Then
            Context.Post(AddressOf EventHandler, New EventArgs(EventPoint, Arg))
        Else
            EventHandler(New EventArgs(EventPoint, Arg))
        End If
    End Sub
    ''' <summary>
    ''' Initializing a new server with a port mentioned. To start the server use the StartConnection method.
    ''' </summary>
    ''' <param name="Port">The port the server will listen to.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Port As Integer)
        serverSocket = New TcpListener(Net.IPAddress.Any, Port)
        Context = SynchronizationContext.Current()
    End Sub
    ''' <summary>
    ''' The number of bytes to send.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SendBufferSize() As Integer
        Get
            Return serverSocket.Server.SendBufferSize
        End Get
        Set(ByVal value As Integer)
            serverSocket.Server.SendBufferSize = value
        End Set
    End Property
    ''' <summary>
    ''' The number of bytes to receive.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReceiveBufferSize() As Integer
        Get
            Return serverSocket.Server.ReceiveBufferSize
        End Get
        Set(ByVal value As Integer)
            serverSocket.Server.ReceiveBufferSize = value
        End Set
    End Property
    ''' <summary>
    ''' Determines if the server should wait an amount of time so more data will be added to the send data buffer, if set to true, the server will send the data immediatly.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NoDelay() As Boolean
        Get
            Return serverSocket.Server.NoDelay
        End Get
        Set(ByVal value As Boolean)
            serverSocket.Server.NoDelay = value
        End Set
    End Property
    ''' <summary>
    ''' Starts listening to clients.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartConnection()
        Try
            Listens = True
            T = New Thread(AddressOf Main)
            T.Start()
        Catch ex As Exception
            EventRaise(EventPointer.errEncounter, ex)
        End Try
    End Sub
    Private Sub DataReceivedHandler(ByVal Msg As ClientMsg)
        DecryptBytes(Msg)
    End Sub
    Private Sub DecryptBytes(ByVal Message As ClientMsg)
        Dim Disconnect As Boolean = True
        For b = 0 To Message.Data.Length - 1
            Dim Msg As ClientMsg = ClientMsg.FromBytes(Message.Data, b)
            If Not Msg.Data Is Nothing Then
                If Msg.ID = Nothing Then
                    EventRaise(EventPointer.DataReceived, New ClientMsg(Message.ID, Msg.Data))
                Else
                    TransferData(Msg, Message.ID)
                End If
                Disconnect = False
            End If
            If b >= Message.Data.Length - 1 Then Exit For
        Next
        If Disconnect Then DisconnectUser(Message.ID)
    End Sub
    Private Sub errEncounterHandler(ByVal ex As Exception)
        EventRaise(EventPointer.errEncounter, ex)
    End Sub
    Private Sub lostConnectionHandler(ByVal ID As String)
        EventRaise(EventPointer.lostConnection, ID)
        Dim Handler As TcpClientHandler = GetClientHandlerByID(ID)
        RemoveHandler Handler.DataReceived, AddressOf DataReceivedHandler
        RemoveHandler Handler.errEncounter, AddressOf errEncounterHandler
        Clients.Remove(Handler)
        RemoveHandler Handler.lostConnection, AddressOf lostConnectionHandler
    End Sub
    Private Function GetClientHandlerByID(ByVal ID As String) As TcpClientHandler
        For Each c As TcpClientHandler In Clients
            If c.ID = ID Then Return c
        Next
        Return Nothing
    End Function
    ''' <summary>
    ''' Sends a byte array to a specific client.
    ''' </summary>
    ''' <param name="ID">Target client ID.</param>
    ''' <param name="Data">A set of bytes to send.</param>
    ''' <remarks></remarks>
    Public Sub SendData(ByVal ID As String, ByVal Data() As Byte)
        Try
            Data = ClientMsg.GetBytes(New ClientMsg(Nothing, Data))
            Dim ClientHandler As TcpClientHandler = GetClientHandlerByID(ID)
            If Not ClientHandler Is Nothing Then ClientHandler.SendData(Data)
        Catch ex As Exception
            EventRaise(EventPointer.errEncounter, ex)
        End Try
    End Sub
    Private Sub TransferData(ByVal TargetClient As ClientMsg, ByVal Sender As String)
        Dim ClientHandler As TcpClientHandler = GetClientHandlerByID(TargetClient.ID)
        If Not ClientHandler Is Nothing Then ClientHandler.SendData(ClientMsg.GetBytes(New ClientMsg(Sender, TargetClient.Data)))
        EventRaise(EventPointer.DataTransferred, New DataPacket(Sender, TargetClient.ID, TargetClient.Data))
    End Sub
    ''' <summary>
    ''' Sends data to all of the connected clients.
    ''' </summary>
    ''' <param name="Data">The array of bytes to send.</param>
    ''' <remarks></remarks>
    Public Sub Brodcast(ByVal Data() As Byte)
        Try
            Data = ClientMsg.GetBytes(New ClientMsg(Nothing, Data))
            For Each c As TcpClientHandler In Clients
                c.SendData(Data)
            Next
        Catch ex As Exception
            EventRaise(EventPointer.errEncounter, ex)
        End Try
    End Sub
    ''' <summary>
    ''' Disconnect a specific user.
    ''' </summary>
    ''' <param name="ID">The client ID to disconnect.</param>
    ''' <remarks></remarks>
    Public Sub DisconnectUser(ByVal ID As String)
        Try
            GetClientHandlerByID(ID).Disconnect()
        Catch ex As Exception
            EventRaise(EventPointer.errEncounter, ex)
        End Try
    End Sub
    Private Sub Main()
        serverSocket.Start()
        Do
            Try
                clientSocket = serverSocket.AcceptTcpClient()
                netStream = clientSocket.GetStream()
                Dim bytes(CInt(clientSocket.ReceiveBufferSize)) As Byte
                netStream.Read(bytes, 0, CInt(clientSocket.ReceiveBufferSize))
                Dim ID2String As String = ConvertFromAscii(bytes)
                If Not GetClientHandlerByID(ID2String) Is Nothing Then
                    Dim OriginID As String = ID2String
                    Dim cnt As Integer = 1
                    ID2String = OriginID & cnt
                    While Not GetClientHandlerByID(ID2String) Is Nothing
                        cnt += 1
                        ID2String = OriginID & cnt
                    End While
                End If
                Dim TcpClientHandle As New TcpClientHandler(clientSocket, ID2String, Context)
                Clients.Add(TcpClientHandle)
                AddHandler TcpClientHandle.DataReceived, AddressOf DataReceivedHandler 'Handle all of the data received in all clients
                AddHandler TcpClientHandle.errEncounter, AddressOf errEncounterHandler 'Handle all clients errors
                AddHandler TcpClientHandle.lostConnection, AddressOf lostConnectionHandler 'Handle all clients lost connections
                EventRaise(EventPointer.onConnection, ID2String)
            Catch ex As Exception
                EventRaise(EventPointer.errEncounter, ex)
            End Try
        Loop Until Listens = False

        If Not Context Is Nothing Then
            Context.Post(AddressOf CloseConnection, Nothing)
        Else
            CloseConnection()
        End If
    End Sub
    ''' <summary>
    ''' Stops listening to connections and closes the server.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloseConnection()
        On Error Resume Next
        Listens = False
        If Not clientSocket Is Nothing Then clientSocket.Close()
        For Each c As TcpClientHandler In Clients
            c.Disconnect()
        Next
        If Not netStream Is Nothing Then netStream.Close()
        serverSocket.Stop()
        RaiseEvent ConnectionClosed()
    End Sub
    ''' <summary>
    ''' Returns the current listen state (true if server is listening)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Listening() As Boolean
        Get
            Return Listens
        End Get
    End Property
    ''' <summary>
    ''' Returns a list of all of the connected users.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Users() As List(Of String)
        Get
            Users = New List(Of String)
            For Each c As TcpClientHandler In Clients
                Users.Add(c.ID)
            Next
        End Get
    End Property
    ''' <summary>
    ''' Converts a set of bytes to a string.
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertFromAscii(ByVal bytes() As Byte) As String
        Dim str As String = ASCIIEncoding.GetEncoding("windows-1255").GetString(bytes)
        Dim findnull As Integer = InStr(str, Chr(0))
        If findnull > 0 Then str = Mid(str, 1, findnull - 1)
        Return str
    End Function
    ''' <summary>
    ''' Converts a string to a set of bytes.
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Convert2Ascii(ByVal str As String) As Byte()
        Return ASCIIEncoding.GetEncoding("windows-1255").GetBytes(str)
    End Function
    Private Class TcpClientHandler
        Private clientSocket As TcpClient
        Private netStream As NetworkStream
        Public ID As String
        Private Context As SynchronizationContext
        Private T As Thread
        Private Connected As Boolean = False
        Public Event DataReceived(ByVal Msg As ClientMsg)
        Public Event errEncounter(ByVal ex As Exception)
        Public Event lostConnection(ByVal ID As String)
        Public ReadOnly Property isConnected()
            Get
                Return Connected
            End Get
        End Property
        Public Sub New(ByVal cSocket As TcpClient, ByVal ClientID As String, ByVal SyncContext As SynchronizationContext)
            clientSocket = cSocket
            ID = ClientID
            Context = SyncContext
            Connected = True
            T = New Thread(AddressOf Main)
            T.Start()
        End Sub
        Private Sub EventHandler(ByVal Args As EventArgs)
            Select Case Args.EventP
                Case EventPointer.DataReceived
                    RaiseEvent DataReceived(New ClientMsg(ID, Args.Arg))
                Case EventPointer.errEncounter
                    RaiseEvent errEncounter(Args.Arg)
                Case EventPointer.lostConnection
                    RaiseEvent lostConnection(ID)
            End Select
        End Sub
        Private Sub EventRaise(ByVal EventPoint As EventPointer, Optional ByVal Arg As Object = Nothing)
            If Not Context Is Nothing Then
                Context.Post(AddressOf EventHandler, New EventArgs(EventPoint, Arg))
            Else
                EventHandler(New EventArgs(EventPoint, Arg))
            End If
        End Sub
        Private Enum EventPointer
            DataReceived = 0
            errEncounter = 1
            lostConnection = 2
        End Enum
        Private Sub Main()
            netStream = clientSocket.GetStream()
            Do While clientSocket.Connected And Connected
                Try
                    Dim GetBytes(CInt(clientSocket.ReceiveBufferSize)) As Byte
                    netStream.Read(GetBytes, 0, CInt(clientSocket.ReceiveBufferSize))
                    EventRaise(EventPointer.DataReceived, GetBytes)
                Catch ex As Exception
                    Exit Do
                End Try
            Loop
            If Not Context Is Nothing Then
                Context.Post(AddressOf Disconnect, Nothing)
            Else
                Disconnect()
            End If
        End Sub
        Public Sub SendData(ByVal Data() As Byte)
            Try
                netStream.Write(Data, 0, Data.Length)
                netStream.Flush()
            Catch ex As Exception
                EventRaise(EventPointer.errEncounter, ex)
            End Try
        End Sub
        Public Sub Disconnect()
            On Error Resume Next
            Connected = False
            If Not netStream Is Nothing Then netStream.Close()
            If Not clientSocket Is Nothing Then clientSocket.Close()
            RaiseEvent lostConnection(ID)
        End Sub
    End Class
End Class
Public Class Client
    Private IP As String
    Private Port As Integer
    Private ID As String
    Private ConnectedHost As Boolean
    Private Context As SynchronizationContext
    Private clientSocket As TcpClient
    Private netStream As NetworkStream
    Private T As Thread
    ''' <summary>
    ''' Raised everytime data received.
    ''' </summary>
    ''' <param name="Data">Set of bytes received.</param>
    ''' <param name="ID">The sender ID.</param>
    ''' <remarks></remarks>
    Public Event DataReceived(ByVal Data() As Byte, ByVal ID As String)
    ''' <summary>
    ''' Raised everytime an error had occured.
    ''' </summary>
    ''' <param name="ex">The exception occured.</param>
    ''' <remarks></remarks>
    Public Event errEncounter(ByVal ex As Exception)
    ''' <summary>
    ''' Raised when the client connected.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event Connected()
    ''' <summary>
    ''' Raiseed when the client disconnected.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event Disconnected()
    ''' <summary>
    ''' Initalizing a new client
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Context = SynchronizationContext.Current
        clientSocket = New TcpClient()
    End Sub
    ''' <summary>
    ''' The number of bytes to send.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SendBufferSize() As Integer
        Get
            Return clientSocket.SendBufferSize
        End Get
        Set(ByVal value As Integer)
            clientSocket.SendBufferSize = value
        End Set
    End Property
    ''' <summary>
    ''' The number of bytes to receive.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReceiveBufferSize() As Integer
        Get
            Return clientSocket.ReceiveBufferSize
        End Get
        Set(ByVal value As Integer)
            clientSocket.ReceiveBufferSize = value
        End Set
    End Property
    ''' <summary>
    ''' Determines if the server should wait an amount of time so more data will be added to the send data buffer, if set to true, the server will send the data immediatly.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NoDelay() As Boolean
        Get
            Return clientSocket.NoDelay
        End Get
        Set(ByVal value As Boolean)
            clientSocket.NoDelay = value
        End Set
    End Property
    Private Sub EventHandler(ByVal Args As EventArgs)
        Select Case Args.EventP
            Case EventPointer.Connected
                RaiseEvent Connected()
            Case EventPointer.Disconnected
                RaiseEvent Disconnected()
            Case EventPointer.DataReceived
                RaiseEvent DataReceived(Args.Arg.Data, Args.Arg.ID)
            Case EventPointer.errEncounter
                RaiseEvent errEncounter(Args.Arg)
        End Select
    End Sub
    Private Sub EventRaise(ByVal EventPoint As EventPointer, Optional ByVal Arg As Object = Nothing)
        If Not Context Is Nothing Then
            Context.Post(AddressOf EventHandler, New EventArgs(EventPoint, Arg))
        Else
            EventHandler(New EventArgs(EventPoint, Arg))
        End If
    End Sub
    Private Enum EventPointer
        DataReceived = 0
        errEncounter = 1
        Connected = 2
        Disconnected = 3
    End Enum
    ''' <summary>
    ''' Connects to a remote NetComm host with a specific client ID.
    ''' </summary>
    ''' <param name="HostIP">The remote host ip address.</param>
    ''' <param name="HostPort">The remote host port.</param>
    ''' <param name="ClientID">The client ID to be entered with.</param>
    ''' <remarks></remarks>
    Public Sub Connect(ByVal HostIP As String, ByVal HostPort As Integer, ByVal ClientID As String)
        IP = HostIP
        Port = HostPort
        ID = ClientID
        Try
            T = New Thread(AddressOf Main)
            T.Start()
        Catch ex As Exception
            EventRaise(EventPointer.errEncounter, ex)
        End Try
    End Sub
    ''' <summary>
    ''' Sends data to a client connected to the server.
    ''' </summary>
    ''' <param name="Data">An array of bytes to send.</param>
    ''' <param name="ID">The target client to send the data to, set null to send the data to the host.</param>
    ''' <remarks></remarks>
    Public Sub SendData(ByVal Data() As Byte, Optional ByVal ID As String = Nothing)
        Try
            Data = ClientMsg.GetBytes(New ClientMsg(ID, Data))
            netStream.Write(Data, 0, Data.Length)
            netStream.Flush()
        Catch ex As Exception
            EventRaise(EventPointer.errEncounter, ex)
        End Try
    End Sub
    Private Sub Main()
        Try
            clientSocket.Connect(IP, Port)
            If clientSocket.Connected Then
                'Send the client ID data
                netStream = clientSocket.GetStream()
                netStream.Write(Convert2Ascii(ID), 0, ID.Length)
                netStream.Flush()
                'Sending ends
                ConnectedHost = True
                EventRaise(EventPointer.Connected)
            End If
        Catch ex As Exception

        End Try
        While clientSocket.Connected And ConnectedHost
            Try
                Dim bytes(CInt(clientSocket.ReceiveBufferSize)) As Byte
                netStream.Read(bytes, 0, CInt(clientSocket.ReceiveBufferSize))
                DecryptBytes(bytes)
            Catch ex As Exception
                Exit While
            End Try
        End While
        If Not Context Is Nothing Then
            Context.Post(AddressOf Disconnect, Nothing)
        Else
            Disconnect()
        End If
    End Sub
    Private Sub DecryptBytes(ByVal Message() As Byte)
        Dim Disconnected As Boolean = True
        For b = 0 To Message.Length - 1
            Dim Msg As ClientMsg = ClientMsg.FromBytes(Message, b)
            If Not Msg.Data Is Nothing Then
                EventRaise(EventPointer.DataReceived, Msg)
                Disconnected = False
            End If
        Next b
        If Disconnected Then ConnectedHost = False
    End Sub
    ''' <summary>
    ''' Disconnects from the server.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Disconnect()
        On Error Resume Next
        ConnectedHost = False
        'Save the current client socket variable so we can redeclare it (Because it will be disposed)
        Dim SBufferSize, RBufferSize As Integer
        SBufferSize = clientSocket.SendBufferSize
        RBufferSize = clientSocket.ReceiveBufferSize
        Dim NDelay As Boolean = clientSocket.NoDelay
        If Not clientSocket Is Nothing Then clientSocket.Close()
        clientSocket = New TcpClient()
        clientSocket.SendBufferSize = SBufferSize
        clientSocket.ReceiveBufferSize = RBufferSize
        clientSocket.NoDelay = NDelay
        RaiseEvent Disconnected()
    End Sub
    ''' <summary>
    ''' Returns the current connection state (True if connected)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property isConnected() As Boolean
        Get
            Return ConnectedHost
        End Get
    End Property
    ''' <summary>
    ''' Converts a set of bytes to a string.
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertFromAscii(ByVal bytes() As Byte) As String
        Dim str As String = ASCIIEncoding.GetEncoding("windows-1255").GetString(bytes)
        Dim findnull As Integer = InStr(str, Chr(0))
        If findnull > 0 Then str = Mid(str, 1, findnull - 1)
        Return str
    End Function
    ''' <summary>
    ''' Converts a string to a set of bytes.
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Convert2Ascii(ByVal str As String) As Byte()
        Return ASCIIEncoding.GetEncoding("windows-1255").GetBytes(str)
    End Function
End Class
