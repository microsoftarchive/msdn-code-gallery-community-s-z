Imports WpfEfDAL

''' <summary>
''' This example shows how to properly bind entity references to lookup comboboxes
'''  as well as how to notify the UI when the entity reference changes. 
''' 1. - Handle the CustomerReference.AssociationChanged Event on the Order (See WpfEfDAL.Order partial class)
''' 2. - XAML for Combobox binds the SelectedItem property to the Customer entity
''' 3. - The lookup list of customers is pulled from the same ObjectContext (OMSEntities) that the order query uses 
''' 4. - The lookup list of customers are entire Customer entites and not a projection of just a few fields
''' </summary>
''' <remarks></remarks>
Partial Public Class LookupComboboxBinding

    Private db As New OMSEntities 'EF ObjectContext connects to database and tracks changes
    Private OrderData As OrdersCollection 'inherits from ObservableCollection
    Private View As ListCollectionView 'provides currency to controls (position & movement in the collection)

    Private Sub LookupComboboxBinding_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded

        Dim query = From o In db.Orders _
                    Where o.OrderDate >= #1/1/2009# _
                    Order By o.OrderDate Descending, o.Customer.LastName _
                    Select o

        Me.OrderData = New OrdersCollection(query, db)

        'Make sure the lookup list is pulled from the same ObjectContext 
        ' (OMSEntities) that the order query uses above.
        'Also have to make sure you return a list of Customer entites and not a 
        ' projection of just a few fields otherwise the binding won't work).
        Dim customerList = From c In db.Customers _
                           Where c.Orders.Count > 0 _
                           Order By c.LastName, c.FirstName _
                           Select c

        Dim orderSource = CType(Me.FindResource("OrdersSource"), CollectionViewSource)
        orderSource.Source = Me.OrderData

        Dim customerSource = CType(Me.FindResource("CustomerLookup"), CollectionViewSource)
        customerSource.Source = customerList.ToList() 'A simple list is OK here since we are not editing Customers

        Me.View = CType(orderSource.View, ListCollectionView)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnDelete.Click
        If Me.View.CurrentPosition > -1 Then
            Me.View.RemoveAt(Me.View.CurrentPosition)
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnAdd.Click
        Me.View.AddNew()
        Me.View.CommitNew()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnSave.Click
        Try
            db.SaveChanges()
            MessageBox.Show("Order data saved.", Me.Title, MessageBoxButton.OK, MessageBoxImage.Information)
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

End Class
