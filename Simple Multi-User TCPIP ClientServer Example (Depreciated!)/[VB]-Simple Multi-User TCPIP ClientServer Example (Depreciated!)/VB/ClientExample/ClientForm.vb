Imports System.Net
Imports System.Net.Sockets

Public Class ClientForm
    Private _Connection As ConnectionInfo
    Private _ServerAddress As IPAddress

    Private Sub ClientForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ValidateChildren()
    End Sub

    Private Sub ConnectButton_CheckedChanged(sender As Object, e As System.EventArgs) Handles ConnectButton.CheckedChanged
        If ConnectButton.Checked Then
            If _ServerAddress IsNot Nothing Then
                ConnectButton.Text = "Disconnect"
                ConnectButton.Image = My.Resources.Disconnect
                Try
                    _Connection = New ConnectionInfo(_ServerAddress, CInt(PortTextBox.Text), AddressOf InvokeAppendOutput)
                    _Connection.AwaitData()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error Connecting to Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ConnectButton.Checked = False
                End Try
            Else
                MessageBox.Show("Invalid server name or address.", "Cannot Connect to Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ConnectButton.Checked = False
            End If
        Else
            ConnectButton.Text = "Connect"
            ConnectButton.Image = My.Resources.Connect
            If _Connection IsNot Nothing Then _Connection.Close()
            _Connection = Nothing
        End If
    End Sub

    Private Sub SendButton_Click(sender As System.Object, e As System.EventArgs) Handles SendButton.Click
        If _Connection IsNot Nothing AndAlso _Connection.Client.Connected AndAlso _Connection.Stream IsNot Nothing Then
            Dim buffer() As Byte = System.Text.Encoding.ASCII.GetBytes(InputTextBox.Text)
            _Connection.Stream.Write(buffer, 0, buffer.Length)
        End If
    End Sub

    Private Sub ServerTextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ServerTextBox.Validating
        _ServerAddress = Nothing
        Dim remoteHost As IPHostEntry = Dns.GetHostEntry(ServerTextBox.Text)
        If remoteHost IsNot Nothing AndAlso remoteHost.AddressList.Length > 0 Then
            For Each deltaAddress As IPAddress In remoteHost.AddressList
                If deltaAddress.AddressFamily = AddressFamily.InterNetwork Then
                    _ServerAddress = deltaAddress
                    Exit For
                End If
            Next
        End If
        If _ServerAddress Is Nothing Then
            MessageBox.Show("Cannot resolove server address.", "Invalid Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ServerTextBox.SelectAll()
            e.Cancel = True
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

    'The InvokeAppendOutput method could easily be replaced with a lambda method passed
    'to the ConnectionInfo contstructor in the ConnectButton_CheckChanged event handler
    Private Sub InvokeAppendOutput(message As String)
        Dim doAppendOutput As New Action(Of String)(AddressOf AppendOutput)
        Me.Invoke(doAppendOutput, message)
    End Sub

    Private Sub AppendOutput(message As String)
        If RichTextBox1.TextLength > 0 Then
            RichTextBox1.AppendText(ControlChars.NewLine)
        End If
        RichTextBox1.AppendText(message)
        RichTextBox1.ScrollToCaret()
    End Sub
End Class

'Encapuslates the client connection and provides a state object for async read operations
Public Class ConnectionInfo
    Private _AppendMethod As Action(Of String)
    Public ReadOnly Property AppendMethod As Action(Of String)
        Get
            Return _AppendMethod
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

    Private _LastReadLength As Integer
    Public ReadOnly Property LastReadLength As Integer
        Get
            Return _LastReadLength
        End Get
    End Property

    Private _Buffer(63) As Byte

    Public Sub New(address As IPAddress, port As Integer, append As Action(Of String))
        _AppendMethod = append
        _Client = New TcpClient
        _Client.Connect(address, port)
        _Stream = _Client.GetStream
    End Sub

    Public Sub AwaitData()
        _Stream.BeginRead(_Buffer, 0, _Buffer.Length, AddressOf DoReadData, Me)
    End Sub

    Public Sub Close()
        If _Client IsNot Nothing Then _Client.Close()
        _Client = Nothing
        _Stream = Nothing
    End Sub

    Private Sub DoReadData(result As IAsyncResult)
        Dim info As ConnectionInfo = CType(result.AsyncState, ConnectionInfo)
        Try
            If info._Stream IsNot Nothing AndAlso info._Stream.CanRead Then
                info._LastReadLength = info._Stream.EndRead(result)
                If info._LastReadLength > 0 Then
                    Dim message As String = System.Text.Encoding.ASCII.GetString(info._Buffer)
                    info._AppendMethod(message)
                End If
                info.AwaitData()
            End If
        Catch ex As Exception
            info._LastReadLength = -1
            info._AppendMethod(ex.Message)
        End Try
    End Sub
End Class