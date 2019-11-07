Imports WpfEfDAL

Partial Public Class ListBoxBinding

    Private db As New OMSEntities

    Private Sub ListBoxBinding_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded

        Dim result = From c In db.Customers _
                     Where c.City = "Seattle" _
                     Order By c.LastName, c.FirstName _
                     Select c

        Dim custViewSource = CType(Me.Resources("CustomerSource"), CollectionViewSource)
        custViewSource.Source = result.ToList()

    End Sub
End Class
