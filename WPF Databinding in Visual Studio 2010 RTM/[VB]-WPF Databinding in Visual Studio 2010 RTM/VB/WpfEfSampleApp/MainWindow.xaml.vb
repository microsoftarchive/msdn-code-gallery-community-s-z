Partial Public Class MainWindow

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Dim frm As New ListBoxBinding
        frm.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        Dim frm As New SimpleDataEntry
        frm.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button3.Click
        Dim frm As New SimpleDataGrid
        frm.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button4.Click
        Dim frm As New SimpleValidation
        frm.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button5.Click
        Dim frm As New LookupComboboxBinding
        frm.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button6.Click
        Dim frm As New MasterDetailBinding
        frm.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button7.Click
        Dim frm As New FormattingAndValidation
        frm.Show()
    End Sub

End Class
