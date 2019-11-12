Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Public Class Form1
    'define the UI controls needed by the sample form
    Friend layoutSplit As New SplitContainer With {.Dock = DockStyle.Fill, .FixedPanel = FixedPanel.Panel1}
    Friend layoutTable As New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = 1, .RowCount = 4}
    Friend WithEvents startButton As New Button With {.AutoSize = True, .Text = "Start"}
    Friend outputTextBox As New RichTextBox With {.Anchor = 15, .ReadOnly = True}
    Friend inputTextBox As New RichTextBox With {.Anchor = 15}
    Friend WithEvents sendButton As New Button With {.AutoSize = True, .Text = "Send"}
    Friend clientListBox As New ListBox With {.Dock = DockStyle.Fill, .IntegralHeight = False}
    Friend WithEvents clientBindingSource As New BindingSource

    'specificy the TCP/IP Port number that the server will listen on
    Private portNumber As Integer = 55001

    'create the collection instance to store connected clients
    Private clients As New ConnectedClientCollection
    'declare a variable to hold the listener instance
    Private listener As TcpListener
    'declare a variable to hold the cancellation token source instance
    Private tokenSource As CancellationTokenSource
    'create a list to hold any processing tasks started when clients connect
    Private clientTasks As New List(Of Task)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'setup the sample's user interface
        Me.Text = "Server Example"
        Controls.Add(layoutSplit)
        layoutSplit.Panel1.Controls.Add(clientListBox)
        layoutSplit.Panel2.Controls.Add(layoutTable)
        layoutTable.RowStyles.Add(New RowStyle(SizeType.Absolute, startButton.Height + 8))
        layoutTable.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
        layoutTable.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
        layoutTable.RowStyles.Add(New RowStyle(SizeType.Absolute, sendButton.Height + 8))
        layoutTable.Controls.Add(startButton)
        layoutTable.Controls.Add(outputTextBox)
        layoutTable.Controls.Add(inputTextBox)
        layoutTable.Controls.Add(sendButton)
        'use databinding to facilitate displaying received data for each connected client
        clientBindingSource.DataSource = clients
        clientListBox.DataSource = clientBindingSource
        outputTextBox.DataBindings.Add("Text", clientBindingSource, "Text")
    End Sub

    Private Async Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        'this example uses the button text as a state indicator for the server; your real
        'application may wish to provide a local boolean or enum field to indicate the server's operational state 
        If startButton.Text = "Start" Then
            'indicate that the server is running
            startButton.Text = "Stop"

            'create a new cancellation token source instance
            tokenSource = New CancellationTokenSource
            'create a new listener instance bound to the desired address and port
            listener = New TcpListener(IPAddress.Any, portNumber)
            'start the listener
            listener.Start()
            'begin accepting clients until the listener is closed; closing the listener while
            'it is waiting for a client connection causes an ObjectDisposedException which can
            'be trapped and used to exit the listening routine
            While True
                Try
                    'wait for a client
                    Dim socketClient As TcpClient = Await listener.AcceptTcpClientAsync
                    'record the new client connection
                    Dim client As New ConnectedClient(socketClient)
                    clientBindingSource.Add(client)
                    'begin executing an async task to process the client's data stream
                    client.Task = ProcessClientAsync(client, tokenSource.Token)
                    'store the task so that we can wait for any existing connections to close
                    'while performing a server shutdown
                    clientTasks.Add(client.Task)
                Catch odex As ObjectDisposedException
                    'listener stopped, so server is shutting down
                    Exit While
                End Try
            End While
            'since NetworkStream.ReadAsync does not honor the cancellation signal we
            'must manually close all connected clients
            For i As Integer = clients.Count - 1 To 0 Step -1
                clients(i).TcpClient.Close()
            Next
            'wait for all of the clients to finish closing
            Await Task.WhenAll(clientTasks)
            'clean up the cancelation token
            tokenSource.Dispose()
            'reset the start button text, allowing the server to be started again
            startButton.Text = "Start"
        Else
            'signal any processing of current clients to cancel (if listening)
            tokenSource.Cancel()
            'abort the current listening operation/prevent any new connections
            listener.Stop()
        End If
    End Sub

    Private Async Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendButton.Click
        'ensure a client is selected in the UI
        If clientBindingSource.Current IsNot Nothing Then
            'disable send button and input text until the current message is sent
            sendButton.Enabled = False
            inputTextBox.Enabled = False
            'get the current client, stream, and data to write
            Dim client As ConnectedClient = CType(clientBindingSource.Current, ConnectedClient)
            Dim stream As NetworkStream = client.TcpClient.GetStream

            Dim message As New XProtocol.XMessage(<TextMessage text1=<%= inputTextBox.Text %>/>)
            Dim buffer() As Byte = message.ToByteArray

            'wait for the data to be sent to the remote client
            Await stream.WriteAsync(buffer, 0, buffer.Length)
            'reset and re-enable the input button and text
            inputTextBox.Clear()
            inputTextBox.Enabled = True
            sendButton.Enabled = True
        End If
    End Sub

    Private Async Function ProcessClientAsync(client As ConnectedClient, cancel As CancellationToken) As Task
        Try
            'begin reading from the client's data stream
            Using stream As NetworkStream = client.TcpClient.GetStream
                Dim buffer(client.TcpClient.ReceiveBufferSize - 1) As Byte
                'loop exits when read = 0 which occurs when the client closes the socket,
                'or it exits on ReadAsync exception when the connection terminates; exception type indicates termination cause
                Dim read As Integer = 1
                While read > 0
                    'wait for data to be read; depending on how you choose to read the data, the cancelation token
                    'may or may not be honored by the particular method implementation on the chosen stream implementation
                    read = Await stream.ReadAsync(buffer, 0, buffer.Length, cancel)
                    'process the received data; in this case the data is simply appended to a StringBuilder; any light
                    'work (that is, code which does not require a lot of CPU time) can be performed directly within
                    'the current while loop:
                    client.AppendData(buffer, read)

                    '*NOTE: A real application may require significantly more processing of the received data. If lengthy, 
                    'CPU-bound processing is required, a secondary worker method could be started on the thread pool;
                    'if the processing is I/O-bound, you could continue to await calls to async methods.  The following code
                    'demonstrates the handling of a CPU-bound processing routine (see additional comments in DoHeavyWork):

                    'Dim workResult As Integer = Await Task.Run(Function() DoHeavyWork(buffer, read, client))
                    ''a real application would likely upate the UI at this point, based on the workResult value (which could
                    ''be an object containing the UI data to update).
                    ''TO TEST: uncomment this block; comment-out client.AppendData(buffer, read) above
                End While
                'client gracefully closed the connection on the remote end
            End Using
        Catch ocex As OperationCanceledException
            'the expected exception if this routines's async method calls honor signaling of the cancelation token
            '*NOTE: NetworkStream.ReadAsync() will not honor the cancelation signal
        Catch odex As ObjectDisposedException
            'server disconnected client while reading
        Catch ioex As IOException
            'client terminated (remote application terminated without socket close) while reading
        Finally
            'ensure the client is closed - this is typically a redundant call, but in the
            'case of an unhandled exception it may be necessary
            client.TcpClient.Close()
            'remove the client from the list of connected clients
            clientBindingSource.Remove(client)
            'remove the client's task from the list of running tasks
            clientTasks.Remove(client.Task)
        End Try
    End Function

    'this method is a rough example of how you would implement secondary threading to handle
    'client processing which requires significant CPU time
    Private Function DoHeavyWork(buffer() As Byte, read As Integer, client As ConnectedClient) As Integer
        'function return type is some kind of status indicator that the caller can use to determine
        'if the processing was successful, or just an empty object if no return value is needed (that is,
        'if you want to treat the function as a subroutine); although this sample uses Integer, you could
        'use any type of your choosing

        'function parameters are whatever is required for your program to process the receieved data

        'due to the fact that AppendData will raise the notify property changed event, we need to
        'ensure that the method is called from the UI thread; in your real application, the UI
        'update would likely occur after this method returns, perhaps based on the result value
        'returned by this method
        Invoke(Sub()
                   client.AppendData(buffer, read)
               End Sub)
        'put the thread to sleep to simulate some long-running CPU-bound processing
        System.Threading.Thread.Sleep(500)
        Return 0
    End Function
End Class

