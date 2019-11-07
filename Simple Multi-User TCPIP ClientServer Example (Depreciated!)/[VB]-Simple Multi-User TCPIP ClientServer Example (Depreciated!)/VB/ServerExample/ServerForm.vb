Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Threading.Tasks

Public Class ServerForm
    Private _Listener As TcpListener
    Private _Connections As New List(Of ConnectionInfo)
    Private _ConnectionMontior As Task

    Private Sub StartStopButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles StartStopButton.CheckedChanged
        If StartStopButton.Checked Then
            StartStopButton.Text = "Stop"
            StartStopButton.Image = My.Resources.Resources.StopServer
            _Listener = New TcpListener(IPAddress.Any, CInt(PortTextBox.Text))
            _Listener.Start()
            Dim monitor As New MonitorInfo(_Listener, _Connections)
            ListenForClient(monitor)
            _ConnectionMontior = Task.Factory.StartNew(AddressOf DoMonitorConnections, monitor, TaskCreationOptions.LongRunning)
        Else
            StartStopButton.Text = "Start"
            StartStopButton.Image = My.Resources.Resources.StartServer
            CType(_ConnectionMontior.AsyncState, MonitorInfo).Cancel = True
            _Listener.Stop()
            _Listener = Nothing
        End If
    End Sub

    Private Sub PortTextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PortTextBox.Validating
        Dim deltaPort As Integer
        If Not Integer.TryParse(PortTextBox.Text, deltaPort) OrElse deltaPort < 1 OrElse deltaPort > 65535 Then
            MessageBox.Show("Port number must be an integer between 1 and 65535.", "Invalid Port Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            PortTextBox.SelectAll()
            e.Cancel = True
        End If
    End Sub

    Private Sub ListenForClient(monitor As MonitorInfo)
        Dim info As New ConnectionInfo(monitor)
        _Listener.BeginAcceptTcpClient(AddressOf DoAcceptClient, info)
    End Sub

    Private Sub DoAcceptClient(result As IAsyncResult)
        Dim monitorInfo As MonitorInfo = CType(_ConnectionMontior.AsyncState, MonitorInfo)
        If monitorInfo.Listener IsNot Nothing AndAlso Not monitorInfo.Cancel Then
            Dim info As ConnectionInfo = CType(result.AsyncState, ConnectionInfo)
            monitorInfo.Connections.Add(info)
            info.AcceptClient(result)
            ListenForClient(monitorInfo)
            info.AwaitData()
            Dim doUpdateConnectionCountLabel As New Action(AddressOf UpdateConnectionCountLabel)
            Invoke(doUpdateConnectionCountLabel)
        End If
    End Sub

    Private Sub DoMonitorConnections()
        'Create delegate for updating output display
        Dim doAppendOutput As New Action(Of String)(AddressOf AppendOutput)
        'Create delegate for updating connection count label
        Dim doUpdateConnectionCountLabel As New Action(AddressOf UpdateConnectionCountLabel)

        'Get MonitorInfo instance from thread-save Task instance
        Dim monitorInfo As MonitorInfo = CType(_ConnectionMontior.AsyncState, MonitorInfo)

        'Report progress
        Me.Invoke(doAppendOutput, "Monitor Started.")

        'Implement client connection processing loop
        Do
            'Create temporary list for recording closed connections
            Dim lostCount As Integer = 0
            'Examine each connection for processing
            For index As Integer = monitorInfo.Connections.Count - 1 To 0 Step -1
                Dim info As ConnectionInfo = monitorInfo.Connections(index)
                If info.Client.Connected Then
                    'Process connected client
                    If info.DataQueue.Count > 0 Then
                        'The code in this If-Block should be modified to build 'message' objects
                        'according to the protocol you defined for your data transmissions.
                        'This example simply sends all pending message bytes to the output textbox.
                        'Without a protocol we cannot know what constitutes a complete message, so
                        'with multiple active clients we could see part of client1's first message,
                        'then part of a message from client2, followed by the rest of client1's
                        'first message (assuming client1 sent more than 64 bytes).
                        Dim messageBytes As New List(Of Byte)
                        While info.DataQueue.Count > 0
                            Dim value As Byte
                            If info.DataQueue.TryDequeue(value) Then
                                messageBytes.Add(value)
                            End If
                        End While
                        Me.Invoke(doAppendOutput, System.Text.Encoding.ASCII.GetString(messageBytes.ToArray))
                    End If
                Else
                    'Clean-up any closed client connections
                    monitorInfo.Connections.Remove(info)
                    lostCount += 1
                End If
            Next
            If lostCount > 0 Then
                Invoke(doUpdateConnectionCountLabel)
            End If

            'Throttle loop to avoid wasting CPU time
            _ConnectionMontior.Wait(1)
        Loop While Not monitorInfo.Cancel

        'Close all connections before exiting monitor
        For Each info As ConnectionInfo In monitorInfo.Connections
            info.Client.Close()
        Next
        monitorInfo.Connections.Clear()

        'Update the connection count label and report status
        Invoke(doUpdateConnectionCountLabel)
        Me.Invoke(doAppendOutput, "Monitor Stopped.")
    End Sub

    Private Sub AppendOutput(message As String)
        If RichTextBox1.TextLength > 0 Then
            RichTextBox1.AppendText(ControlChars.NewLine)
        End If
        RichTextBox1.AppendText(message)
        RichTextBox1.ScrollToCaret()
    End Sub

    Private Sub UpdateConnectionCountLabel()
        ConnectionCountLabel.Text = String.Format("{0} Connections", _Connections.Count)
    End Sub
End Class

'Provides a simple container object to be used for the state object passed to the connection monitoring thread
Public Class MonitorInfo
    Public Property Cancel As Boolean

    Private _Connections As List(Of ConnectionInfo)
    Public ReadOnly Property Connections As List(Of ConnectionInfo)
        Get
            Return _Connections
        End Get
    End Property

    Private _Listener As TcpListener
    Public ReadOnly Property Listener As TcpListener
        Get
            Return _Listener
        End Get
    End Property

    Public Sub New(tcpListener As TcpListener, connectionInfoList As List(Of ConnectionInfo))
        _Listener = tcpListener
        _Connections = connectionInfoList
    End Sub
End Class

'Provides a container object to serve as the state object for async client and stream operations
Public Class ConnectionInfo
    'hold a reference to entire monitor instead of just the listener
    Private _Monitor As MonitorInfo
    Public ReadOnly Property Monitor As MonitorInfo
        Get
            Return _Monitor
        End Get
    End Property

    Private _Client As TcpClient
    Public ReadOnly Property Client As TcpClient
        Get
            Return _Client
        End Get
    End Property

    Private _Stream As NetworkStream
    Public ReadOnly Property Stream As NetworkStream
        Get
            Return _Stream
        End Get
    End Property

    Private _DataQueue As System.Collections.Concurrent.ConcurrentQueue(Of Byte)
    Public ReadOnly Property DataQueue As System.Collections.Concurrent.ConcurrentQueue(Of Byte)
        Get
            Return _DataQueue
        End Get
    End Property

    Private _LastReadLength As Integer
    Public ReadOnly Property LastReadLength As Integer
        Get
            Return _LastReadLength
        End Get
    End Property

    'The buffer size is an arbitrary value which should be selected based on the
    'amount of data you need to transmit, the rate of transmissions, and the
    'anticipalted number of clients. These are the considerations for designing
    'the communicaition protocol for data transmissions, and the size of the read
    'buffer must be based upon the needs of the protocol.
    Private _Buffer(63) As Byte

    Public Sub New(monitor As MonitorInfo)
        _Monitor = monitor
        _DataQueue = New System.Collections.Concurrent.ConcurrentQueue(Of Byte)
    End Sub

    Public Sub AcceptClient(result As IAsyncResult)
        _Client = _Monitor.Listener.EndAcceptTcpClient(result)
        If _Client IsNot Nothing AndAlso _Client.Connected Then
            _Stream = _Client.GetStream
        End If
    End Sub

    Public Sub AwaitData()
        _Stream.BeginRead(_Buffer, 0, _Buffer.Length, AddressOf DoReadData, Me)
    End Sub

    Private Sub DoReadData(result As IAsyncResult)
        Dim info As ConnectionInfo = CType(result.AsyncState, ConnectionInfo)
        Try
            'If the stream is valid for reading, get the current data and then
            'begin another async read
            If info.Stream IsNot Nothing AndAlso info.Stream.CanRead Then
                info._LastReadLength = info.Stream.EndRead(result)
                For index As Integer = 0 To _LastReadLength - 1
                    info._DataQueue.Enqueue(info._Buffer(index))
                Next

                'The example responds to all data reception with the number of bytes received;
                'you would likely change this behavior when implementing your own protocol.
                info.SendMessage("Received " & info._LastReadLength & " Bytes")

                For Each otherInfo As ConnectionInfo In info.Monitor.Connections
                    If Not otherInfo Is info Then
                        otherInfo.SendMessage(System.Text.Encoding.ASCII.GetString(info._Buffer))
                    End If
                Next

                info.AwaitData()
            Else
                'If we cannot read from the stream, the example assumes the connection is
                'invalid and closes the client connection. You might modify this behavior
                'when implementing your own protocol.
                info.Client.Close()
            End If
        Catch ex As Exception
            info._LastReadLength = -1
        End Try
    End Sub

    Private Sub SendMessage(message As String)
        If _Stream IsNot Nothing Then
            Dim messageData() As Byte = System.Text.Encoding.ASCII.GetBytes(message)
            Stream.Write(messageData, 0, messageData.Length)
        End If
    End Sub
End Class
