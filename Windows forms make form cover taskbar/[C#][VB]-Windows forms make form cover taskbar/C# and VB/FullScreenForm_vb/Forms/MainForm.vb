Imports WindowsFormsMaxLibrary
Public Class frmMainForm

    Private Sub cmdChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChange.Click

        If cmdChange.Text = "Full" Then

            cmdChange.Text = "Normal"

            FullScreen(chkTaskbar.Checked)

            If chkTaskbar.Checked Then
                Me.FullScreen(True)
            End If
        Else
            cmdChange.Text = "Full"
            NormalMode()
        End If

    End Sub
    Private Sub cmdShowChildForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowChildForm.Click
        Dim f As New frmChildForm
        Dim TopMostSetting As Boolean = Me.TopMost

        Try
            Me.TopMost = False
            f.ShowDialog()
        Finally
            f.Dispose()
            Me.TopMost = TopMostSetting
        End Try
    End Sub
    Private Sub cmdDetect_Click(sender As Object, e As EventArgs) Handles cmdDetect.Click
        MessageBox.Show(Me.WindowState.ToString)
    End Sub
    Private Sub frmMainForm_StyleChanged(sender As Object, e As EventArgs) Handles Me.StyleChanged
        ListBox1.Items.Add(Me.WindowState.ToString)
        ListBox1.SelectedIndex = ListBox1.Items.Count - 1
    End Sub
    Private Sub cmdCloseForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseForm.Click
        Close()
    End Sub
End Class
