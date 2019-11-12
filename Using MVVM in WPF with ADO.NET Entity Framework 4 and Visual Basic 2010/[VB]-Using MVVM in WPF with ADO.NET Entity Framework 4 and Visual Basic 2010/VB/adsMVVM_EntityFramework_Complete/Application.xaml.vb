Class Application

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.
    Friend Const VIEW_DETAILS_EXECUTE As String = "ViewDetailsExecute"
    Friend Const VIEW_DETAILS_CLOSE As String = "ViewDetailsClose"

    Shared ReadOnly _messenger As New Messenger()

    Friend Shared ReadOnly Property Msn As Messenger
        Get
            Return _messenger
        End Get
    End Property

    Private Sub Application_DispatcherUnhandledException(ByVal sender As System.Object, ByVal e As System.Windows.Threading.DispatcherUnhandledExceptionEventArgs)
        MessageBox.Show(e.Exception.Message)
        e.Handled = True
    End Sub
End Class
