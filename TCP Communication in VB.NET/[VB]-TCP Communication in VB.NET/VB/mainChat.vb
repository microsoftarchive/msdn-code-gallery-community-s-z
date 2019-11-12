Option Strict On
Option Infer On

Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Net.NetworkInformation
''' <summary>
''' TCP Chat . 
''' Ellen Ramcke 2010 - 2011
''' update 10.5.2011 show remote Endpoint
''' update 24.6.2011 enable DNS name
''' </summary>
''' <remarks></remarks>
Public Class mainChat

    Private WithEvents myChat As New TCPChat
    Private myAdapterName, myPhysicalAddress, myGateway, myDNS, strHostName As String
    Private addr() As IPAddress

#Region "form"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '// Getting Ip address of local machine...
        '// First get the host name of local machine.
        strHostName = Dns.GetHostName()
        Dim ipEntry As IPHostEntry = Dns.GetHostEntry(strHostName)
        addr = ipEntry.AddressList
        Dim i As Integer
        For i = 0 To addr.Length - 1

            If addr(i).AddressFamily = AddressFamily.InterNetwork Then
                StatusLabel_adapter.Text = "host " & strHostName & _
                                           String.Format(" IP: {0}", addr(i).ToString)
                Exit For
            End If
        Next

        tbx_remoteIP.Text = "127.0.0.1"
        tbx_remotePort.Text = "5000"
        tbx_hostIP.Text = addr(i).ToString
        tbx_hostPort.Text = "5000"
        tbx_remoteIP.Text = addr(i).ToString

    End Sub
    ' 
    ' clear socket connection
    '
    Private Sub mainChat_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        myChat.disconnect()
    End Sub
    '
    '  input from Textbox
    '
    Private Sub tbinKD(ByVal sender As Object, _
                       ByVal e As KeyEventArgs) Handles tbin.KeyDown
        If e.KeyCode = Keys.Enter Then
            With CType(sender, TextBox)
                If .Text.Length > 0 Then
                    StatusLabel_send.Image = My.Resources.ledCornerGray
                    myChat.SendData(.Text, tbx_remoteIP.Text, CInt(tbx_remotePort.Text))
                    txtOutSend(.Text)
                    .Text = String.Empty
                End If
            End With
        End If
    End Sub
    '
    ' output to listbox
    '
    Public Sub txtOut(ByVal txt As String) Handles myChat.Datareceived
        lbout.Items.Add("< " & txt)
    End Sub
    Private Sub txtOutSend(ByVal txt As String)
        lbout.Items.Add("> " & txt)
    End Sub
    '
    '  senda data OK NOK
    '
    Private Sub sendata(ByVal sendStatus As Boolean) Handles myChat.sendOK
        If sendStatus Then
            StatusLabel_send.Image = My.Resources.ledCornerGreen
        Else
            StatusLabel_send.Image = My.Resources.ledCornerRed
        End If
    End Sub
    '
    ' receive data OK NOK
    '
    Private Sub rdata(ByVal receiveStatus As Boolean) Handles myChat.recOK
        If receiveStatus Then
            StatusLabel_receive.Image = My.Resources.ledCornerGreen
            StatusLabel_adapter.Text = "local " & myChat.Local.ToString & _
                                       " remote" & myChat.Remote.ToString

        Else
            StatusLabel_receive.Image = My.Resources.ledCornerRed
        End If
    End Sub
    '
    ' connect
    '
    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Connect.Click

        myChat.connect(tbx_hostIP.Text, CInt(tbx_hostPort.Text))
    End Sub
    '
    ' connection status
    '
    Private Sub connection(ByVal status As Boolean) Handles myChat.connection
        If status Then
            tbx_remoteIP.Enabled = False
            tbx_remotePort.Enabled = False
            tbx_hostIP.Enabled = False
            tbx_hostPort.Enabled = False
            StatusLabel_adapter.Image = My.Resources.ledCornerGreen
            StatusLabel_receive.Image = My.Resources.ledCornerOrange
        Else
            tbx_remoteIP.Enabled = True
            tbx_remotePort.Enabled = True
            tbx_hostIP.Enabled = True
            tbx_hostPort.Enabled = True
            StatusLabel_adapter.Image = My.Resources.ledCornerGray
            StatusLabel_receive.Image = My.Resources.ledCornerGray
            StatusLabel_send.Image = My.Resources.ledCornerGray
        End If
    End Sub
    '
    '  disconnect socket
    '
    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Disconnect.Click
        myChat.disconnect()
    End Sub
    '
    '  clear listbox
    '
    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        lbout.Items.Clear()
    End Sub

#End Region

 
End Class

''' <summary>
''' TCP sevices. Ellen Ramcke 2010
''' sends and receives Encoding.ASCII data
''' the max length of one data frame is 8196 bytes
''' last update: 8.1.2011
''' 10.5.2011 - remote/local  IP Endpoint
''' update 24.6.2011 DNS 
''' </summary>
''' <remarks></remarks>
Public Class TCPChat
    ''' <summary>
    ''' Event data send back to calling form
    ''' </summary>
    Public Event Datareceived(ByVal txt As String)
    ''' <summary>
    ''' connection status back to form True: ok
    ''' </summary>
    Public Event connection(ByVal cStatus As Boolean)
    ''' <summary>
    ''' data send successfull (True)
    ''' </summary>
    Public Event sendOK(ByVal sStatus As Boolean)
    ''' <summary>
    ''' data receive successfull (True)
    ''' </summary>
    Public Event recOK(ByVal sReceive As Boolean)

    Private serverRuns As Boolean
    Private server As TcpListener
    Private sc As SynchronizationContext
    Private isConnected, receiveStatus, sendStatus As Boolean
    Private iRemote, pLocal As EndPoint

    ''' <summary>
    ''' reads endpoints
    ''' </summary>
    Public ReadOnly Property Remote() As EndPoint
        Get
            Return iRemote
        End Get
    End Property
    ''' <summary>
    ''' reads local point
    ''' </summary>
    Public ReadOnly Property Local() As EndPoint
        Get
            Return pLocal
        End Get
    End Property
    ''' <summary>
    ''' TCP connect with server
    ''' </summary>
    Public Sub connect(ByVal hostAdress As String, ByVal hostPort As Integer)

        sc = SynchronizationContext.Current

        Try
            server = New TcpListener(IPAddress.Parse(hostAdress), hostPort)
        Catch ex As Exception
            MsgBox("server create: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

        Try
            With server
                .Start()
                .BeginAcceptTcpClient(New AsyncCallback(AddressOf DoAccept), server)
                isConnected = True
            End With
        Catch ex As Exception
            MsgBox("server listen: " & ex.Message, MsgBoxStyle.Exclamation)
            isConnected = False
        Finally
            RaiseEvent connection(isConnected)
        End Try

    End Sub
    ''' <summary>
    ''' disConnect server
    ''' </summary>
    Public Sub disconnect()
        Try
            isConnected = False
            server.Stop()
        Catch ex As Exception
            MsgBox("disConnect server: " & ex.Message, MsgBoxStyle.Exclamation)
            isConnected = True
        Finally
            RaiseEvent connection(isConnected)
        End Try
    End Sub
    ''' <summary>
    ''' TCP send data
    ''' </summary>
    Public Sub SendData(ByVal txt As String, ByVal remoteAddress As String, ByVal remotePort As Integer)

        Dim clientSocket = New TcpClient
        Dim iP As IPAddress = IPAddress.Any
        Dim isIp As Boolean = IPAddress.TryParse(remoteAddress, iP)

        With clientSocket
            Try
                If isIp Then    ' ip address
                    .Connect(IPAddress.Parse(remoteAddress), remotePort)
                Else            ' DNS name
                    .Connect(remoteAddress, remotePort)
                End If

                Dim data() As Byte = Encoding.ASCII.GetBytes(txt)
                .NoDelay = True
                .GetStream().Write(data, 0, data.Length)
                .GetStream().Close()

                .Close()
                sendStatus = True
            Catch ex As Exception
                MsgBox("sendData: " & ex.Message, MsgBoxStyle.Exclamation)
                sendStatus = False
            Finally
                RaiseEvent sendOK(sendStatus)
            End Try

        End With
    End Sub
    ''' <summary>
    ''' TCP asynchronous receive on secondary thread
    ''' last update 10.5.2011
    ''' </summary>
    Private Sub DoAccept(ByVal ar As IAsyncResult)

        Dim sb As New StringBuilder
        Dim buf() As Byte
        Dim datalen As Integer

        Dim listener As TcpListener
        Dim clientSocket As TcpClient
        If Not isConnected Then Exit Sub
        Try
            listener = CType(ar.AsyncState, TcpListener)
            clientSocket = listener.EndAcceptTcpClient(ar)
            clientSocket.ReceiveTimeout = 5000
            'update 10.5.2011
            iRemote = clientSocket.Client.RemoteEndPoint
            pLocal = clientSocket.Client.LocalEndPoint

        Catch ex As ObjectDisposedException
            MsgBox("DoAccept ObjectDisposedException " & ex.Message, MsgBoxStyle.Exclamation)
            ' after server.stop() AsyncCallback is also active, but the object server is disposed
            Exit Sub
        End Try

        Try
            With clientSocket
                datalen = 0
                ' somtimes it occurs that .available returns the value 0 also data in buffer exists
                While datalen = 0
                    ' data in read Buffer
                    datalen = .Available
                End While
                buf = New Byte(datalen - 1) {}
                'get entire bytes at once
                .GetStream().Read(buf, 0, buf.Length)
                sb.Append(Encoding.ASCII.GetString(buf, 0, buf.Length))
                .Close()
            End With
            receiveStatus = True
        Catch ex As TimeoutException
            MsgBox("doAcceptData timeout: " & ex.Message, MsgBoxStyle.Exclamation)
            receiveStatus = False
            clientSocket.Close()
            Exit Sub
        Catch ex As Exception
            MsgBox("doAcceptData: " & ex.Message, MsgBoxStyle.Exclamation)
            receiveStatus = False
            clientSocket.Close()
            Exit Sub
        Finally
            RaiseEvent recOK(receiveStatus)
        End Try
        ' post data
        sc.Post(New SendOrPostCallback(AddressOf OnDatareceived), sb.ToString)
        ' start new read
        server.BeginAcceptTcpClient(New AsyncCallback(AddressOf DoAccept), server)
    End Sub
    '
    ' now data to calling class and UI thread
    '
    Private Sub OnDatareceived(ByVal state As Object)
        RaiseEvent Datareceived(state.ToString)
    End Sub

End Class

