

Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ConnectTable("select * from smpTable", "smpTable", DataGridView1)
    End Sub
End Class
