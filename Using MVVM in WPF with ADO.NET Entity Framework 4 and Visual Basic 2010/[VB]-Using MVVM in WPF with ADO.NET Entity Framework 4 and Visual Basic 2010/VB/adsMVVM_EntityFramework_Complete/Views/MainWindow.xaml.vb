Imports DAL

Class MainWindow

    Private Sub MainWindow_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        Dim startupViewModel As New OrdersViewModel
        Me.MainGrid.DataContext = startupViewModel

        Application.Msn.Register(Application.VIEW_DETAILS_EXECUTE, Sub()
                                                                       Try
                                                                           Dim odv As New OrderDetailsView(CType(startupViewModel.CustomerOrdersViewSource.View.CurrentItem, Order).OrderID)
                                                                           odv.ShowDialog()
                                                                           odv = Nothing
                                                                       Catch ex As Exception
                                                                           MessageBox.Show(ex.Message)
                                                                       End Try
                                                                   End Sub)
    End Sub
End Class
