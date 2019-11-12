Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.ComponentModel

Public Class MainForm

    Private Shared listenPort As Integer
    Private Shared HostIP As IPAddress

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub


    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("DucNN", "Author", MessageBoxButtons.OK)
    End Sub

    Private Sub Button_start_Click(sender As Object, e As EventArgs) Handles Button_start.Click
        If (Button_start.Text = "Start") Then
            listenPort = CInt(TextBox_port.Text)
            If Not (TextBox_ipaddr.Text = "Any") Then
                Try
                    HostIP = IPAddress.Parse(TextBox_ipaddr.Text)
                Catch ex As Exception
                    MsgBox("error")
                End Try

            End If

            ToolStripStatusLabel_status.Text = "Capturing ..."
            Button_start.Text = "STOP"

            RichTextBox1.AppendText("Start : " & Now & ":" & Now.Millisecond & " - IP:" & HostIP.ToString & vbNewLine)

            If Not BackgroundWorker1.IsBusy = True Then
                BackgroundWorker1.RunWorkerAsync()
            End If

        Else
            Button_start.Text = "Start"
            ToolStripStatusLabel_status.Text = "Stopped"
            BackgroundWorker1.CancelAsync()
            BackgroundWorker1.CancelAsync()
            RichTextBox1.AppendText("End : " & Now & ":" & Now.Millisecond & vbNewLine)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)

        Dim done As Boolean = False
        Dim listener As New UdpClient(listenPort)
        Dim groupEP As New IPEndPoint(HostIP, listenPort)
        Dim mystring As String

        Try
            While Not done
                If BackgroundWorker1.CancellationPending = True Then
                    e.Cancel = True
                    listener.Close()
                    Exit While
                Else
                    If (listener.Available > 0) Then
                        Dim bytes As Byte() = listener.Receive(groupEP)
                        mystring = Now & ":" & Now.Millisecond & " - From " & groupEP.ToString() & " : " & Encoding.ASCII.GetString(bytes, 0, bytes.Length)
                        worker.ReportProgress(0, mystring)
                    End If

                End If
            End While

        Catch ex As Exception

        Finally
            listener.Close()
        End Try

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        If (BackgroundWorker1.CancellationPending = False) Then
            RichTextBox1.AppendText(e.UserState.ToString)
        End If
        Update()
    End Sub

    Private Sub Button_default_Click(sender As Object, e As EventArgs) Handles Button_default.Click
        TextBox_ipaddr.Text = "Any"
        HostIP = IPAddress.Any
    End Sub
End Class
