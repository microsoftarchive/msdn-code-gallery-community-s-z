Public Class ThisAddIn

    Private Sub ThisAddIn_Startup() Handles Me.Startup
        System.Windows.Forms.MessageBox.Show("Add-in has successfully loaded")
    End Sub

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

    End Sub

End Class
