Imports Microsoft.Office


Public Class Form1
    Dim sFilesource As String
    Dim sName As String

    Private Sub setEmailSend(sSubject As String, sBody As String, _
                             sTo As String, sCC As String, _
                             sFilename As String, sDisplayname As String)
        Dim oApp As Interop.Outlook._Application
        oApp = New Interop.Outlook.Application

        Dim oMsg As Interop.Outlook._MailItem
        oMsg = oApp.CreateItem(Interop.Outlook.OlItemType.olMailItem)

        oMsg.Subject = sSubject
        oMsg.Body = sBody

        oMsg.To = sTo
        oMsg.CC = sCC


        Dim strS As String = sFilename
        Dim strN As String = sDisplayname
        If sFilename <> "" Then
            Dim sBodyLen As Integer = Int(sBody.Length)
            Dim oAttachs As Interop.Outlook.Attachments = oMsg.Attachments
            Dim oAttach As Interop.Outlook.Attachment

            oAttach = oAttachs.Add(strS, , sBodyLen, strN)

        End If

        oMsg.Send()
        MessageBox.Show("Email Send", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        txtBody.Text = ""
        txtTo.Text = ""
        txtCC.Text = ""
        txtFile.Text = ""
        txtSubject.Text = ""

        KillOutLookProcess()

    End Sub

    Private Sub KillOutLookProcess()
        Try
            Dim Xcel() As Process = Process.GetProcessesByName("OUTLOOK")
            For Each Process As Process In Xcel
                Process.Kill()
            Next
        Catch ex As Exception
        End Try
    End Sub
    Public Function AppPath()
        Return System.AppDomain.CurrentDomain.BaseDirectory
    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If txtTo.Text <> "" Then
            setEmailSend(txtSubject.Text, txtBody.Text, txtTo.Text, txtCC.Text, sFilesource, sName)
        Else
            MessageBox.Show("No Recipient", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        With OpenFileDialog1
            .Filter = "All Files(*.*)|*.*"
            .FileName = ""
            .ShowDialog()
            sFilesource = .FileName

            sName = .FileName

            Dim cCnt As Integer, iSlash As Integer, x As Integer, iStart As Integer, iLenght As Integer, iSlash1 As Integer
            For cCnt = 0 To sFilesource.Length - 1
                If sFilesource(cCnt) = "\" Then
                    iSlash = iSlash + 1
                End If
            Next

            For x = 0 To sFilesource.Length - 1
                If sFilesource(x) = "\" Then
                    iSlash1 = iSlash1 + 1
                    If iSlash = iSlash1 Then
                        iStart = x
                        iLenght = sFilesource.Length - x
                        Exit For
                    End If
                End If
            Next

            sName = sFilesource.Substring(iStart + 1, iLenght - 1)

            txtFile.Text = sName
        End With
    End Sub
End Class
