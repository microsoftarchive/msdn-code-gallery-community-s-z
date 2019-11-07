Imports WpfEfDAL

''' <summary>
''' This sample demonstrates Master-Detail data binding to CollectionViewSources and how
'''  work with master-detail entity collections. See the WpfEfDAL.Order and WpfEfDAL.OrderDetail 
'''  partial classes and the OrdersCollection to see one way to manage this.
''' 1. - Declare the CollectionViewSources in XAML Window.Resources section
''' 2. - Query the Orders and specify the Include("OrderDetails") to pull down the order details
''' 3. - Set the Source property of the CollectionViewSource
''' </summary>
''' <remarks></remarks>
Partial Public Class MasterDetailBinding

    Private db As New OMSEntities 'EF ObjectContext connects to database and tracks changes
    Private OrderData As OrdersCollection 'inherits from ObservableCollection

    Private MasterViewSource As CollectionViewSource
    Private DetailViewSource As CollectionViewSource

    'provides currency to controls (position & movement in the collections)
    Private WithEvents MasterView As ListCollectionView
    Private DetailsView As BindingListCollectionView

    Private Sub MasterDetailBinding_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded

        Dim query = From o In db.Orders.Include("OrderDetails") _
                    Where o.OrderDate >= #1/1/2009# _
                    Order By o.OrderDate Descending, o.Customer.LastName _
                    Select o

        Me.OrderData = New OrdersCollection(query, db)

        'Make sure the lookup lists are pulled from the same ObjectContext 
        ' (OMSEntities) that the order query uses above.
        'Also have to make sure you return a list of whole entites and not a 
        ' projection of just a few fields otherwise the binding won't work.
        Dim customerList = From c In db.Customers _
                           Where c.Orders.Count > 0 _
                           Order By c.LastName, c.FirstName _
                           Select c

        Dim productList = From p In db.Products _
                          Order By p.Name _
                          Select p

        Me.MasterViewSource = CType(Me.FindResource("MasterViewSource"), CollectionViewSource)
        Me.DetailViewSource = CType(Me.FindResource("DetailsViewSource"), CollectionViewSource)
        Me.MasterViewSource.Source = Me.OrderData

        Dim customerSource = CType(Me.FindResource("CustomerLookup"), CollectionViewSource)
        customerSource.Source = customerList.ToList() 'A simple list is OK here since we are not editing Customers
        Dim productSource = CType(Me.FindResource("ProductLookup"), CollectionViewSource)
        productSource.Source = productList.ToList() 'A simple list is OK here since we are not editing Products

        Me.MasterView = CType(Me.MasterViewSource.View, ListCollectionView)
        Me.DetailsView = CType(Me.DetailViewSource.View, BindingListCollectionView)
    End Sub

    Private Sub MasterView_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MasterView.CurrentChanged
        'We need to grab the new child view when the master's position changes
        Me.DetailsView = CType(Me.DetailViewSource.View, BindingListCollectionView)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnSave.Click
        Try
            db.SaveChanges()
            MessageBox.Show("Order data saved.", Me.Title, MessageBoxButton.OK, MessageBoxImage.Information)
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnDelete.Click
        If Me.MasterView.CurrentPosition > -1 Then
            Me.MasterView.RemoveAt(Me.MasterView.CurrentPosition)
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnAdd.Click
        Me.MasterView.AddNew()
        Me.MasterView.CommitNew()
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnPrevious.Click
        If Me.MasterView.CurrentPosition > 0 Then
            Me.MasterView.MoveCurrentToPrevious()
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnNext.Click
        If Me.MasterView.CurrentPosition < Me.MasterView.Count - 1 Then
            Me.MasterView.MoveCurrentToNext()
        End If
    End Sub

    Private Sub btnAddDetail_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnAddDetail.Click
        Me.DetailsView.AddNew()
        Me.DetailsView.CommitNew()
    End Sub

    Private Sub btnDeleteDetail_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnDeleteDetail.Click
        If Me.DetailsView.CurrentPosition > -1 Then
            Me.DetailsView.RemoveAt(Me.DetailsView.CurrentPosition)
        End If
    End Sub

    Private Sub Item_GotFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        'This will keep the View position in sync with the selected 
        ' row even when a control is being edited in the ListViewItem
        Dim item = CType(sender, ListViewItem)
        Me.ListView1.SelectedItem = item.DataContext
    End Sub

   
End Class
