Imports System.Net
Imports System.Net.Sockets

Public Class Form1
    Friend layoutTable As New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = 1, .RowCount = 4}
    Friend WithEvents connectButton As New Button With {.AutoSize = True, .Text = "Connect"}
    Friend outputTextBox As New RichTextBox With {.Anchor = 15, .ReadOnly = True}
    Friend inputTextBox As New RichTextBox With {.Anchor = 15}
    Friend WithEvents sendButton As New Button With {.AutoSize = True, .Text = "Send"}

    Private portNumber As Integer = 55001
    Private client As TcpClient
    Private received As New List(Of Byte)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Client Example"
        Controls.Add(layoutTable)
        layoutTable.RowStyles.Add(New RowStyle(SizeType.Absolute, connectButton.Height + 8))
        layoutTable.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
        layoutTable.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
        layoutTable.RowStyles.Add(New RowStyle(SizeType.Absolute, sendButton.Height + 8))
        layoutTable.Controls.Add(connectButton)
        layoutTable.Controls.Add(outputTextBox)
        layoutTable.Controls.Add(inputTextBox)
        layoutTable.Controls.Add(sendButton)
    End Sub

    Private Async Sub connectButton_Click(sender As Object, e As EventArgs) Handles connectButton.Click
        If connectButton.Text = "Connect" Then
            client = New TcpClient
            Try
                'The server and client examples are assumed to be running on the same computer;
                'in your real client application you would allow the user to specify the
                'server's address and then use that value here instead of GetLocalIP()
                Await client.ConnectAsync(GetLocalIP, portNumber)
                connectButton.Text = "Disconnect"
                If client.Connected Then
                    'get the client's data stream
                    Dim stream As NetworkStream = client.GetStream
                    'while the client is connected, continue to wait for and read data
                    While client.Connected
                        Dim buffer(client.ReceiveBufferSize - 1) As Byte
                        Dim read As Integer = Await stream.ReadAsync(buffer, 0, buffer.Length)
                        If read > 0 Then
                            received.AddRange(buffer.Take(read))
                            If XProtocol.XMessage.IsMessageComplete(received) Then
                                Dim message As XProtocol.XMessage = XProtocol.XMessage.FromByteArray(received.ToArray)
                                received.Clear()
                                Select Case message.Element.Name
                                    Case "TextMessage"
                                        outputTextBox.AppendText(message.Element.@text1)
                                        outputTextBox.AppendText(ControlChars.NewLine)
                                End Select
                            End If
                        Else
                            'server terminated connection
                            Exit While
                        End If
                    End While
                End If
            Catch odex As ObjectDisposedException
                'client terminated connection
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                client.Close()
            End Try
            connectButton.Text = "Connect"
        Else
            client.Close()
        End If
    End Sub

    'send message to server
    Private Async Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendButton.Click
        If client IsNot Nothing AndAlso client.Connected Then
            Dim stream As NetworkStream = client.GetStream
            Dim message As New XProtocol.XMessage(<TextMessage text1=<%= inputTextBox.Text %>/>)
            Dim buffer() As Byte = message.ToByteArray
            Try
                Await stream.WriteAsync(buffer, 0, buffer.Length)
            Catch ioex As System.IO.IOException
                'server terminated connection
            Catch odex As ObjectDisposedException
                'client terminated connection
            Catch ex As Exception
                'unknown error occured
                MessageBox.Show(ex.Message)
            End Try
            inputTextBox.Clear()
        End If
    End Sub

    'helper method for getting local IPv4 address
    Private Function GetLocalIP() As IPAddress
        For Each adapter In NetworkInformation.NetworkInterface.GetAllNetworkInterfaces
            If adapter.OperationalStatus = NetworkInformation.OperationalStatus.Up AndAlso
                adapter.Supports(NetworkInformation.NetworkInterfaceComponent.IPv4) AndAlso
                adapter.NetworkInterfaceType <> NetworkInformation.NetworkInterfaceType.Loopback Then
                Dim props As NetworkInformation.IPInterfaceProperties = adapter.GetIPProperties
                For Each address In props.UnicastAddresses
                    If address.Address.AddressFamily = AddressFamily.InterNetwork Then Return address.Address
                Next
            End If
        Next
        Return IPAddress.None
    End Function
End Class
