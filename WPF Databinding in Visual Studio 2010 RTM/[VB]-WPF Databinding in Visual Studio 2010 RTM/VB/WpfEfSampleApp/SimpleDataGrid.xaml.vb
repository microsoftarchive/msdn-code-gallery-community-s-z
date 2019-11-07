Imports WpfEfDAL

''' <summary>
''' This example shows one way to build a simple data grid using a ListView in WPF.
''' </summary>
''' <remarks></remarks>
Partial Public Class SimpleDataGrid

    Private db As New OMSEntities 'EF ObjectContext connects to database and tracks changes
    Private CustomerData As CustomerCollection 'inherits from ObservableCollection
    Private View As ListCollectionView 'provides currency to controls (position & movement in the collection)

    Private Sub SimpleDataGrid_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Dim query = From c In db.Customers _
                   Where c.City = "Seattle" _
                   Order By c.LastName, c.FirstName _
                   Select c

        Me.CustomerData = New CustomerCollection(query, db)

        Dim customerSource = CType(Me.FindResource("CustomerSource"), CollectionViewSource)
        customerSource.Source = Me.CustomerData

        Me.View = CType(customerSource.View, ListCollectionView)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnDelete.Click
        If Me.View.CurrentPosition > -1 Then
            Me.View.RemoveAt(Me.View.CurrentPosition)
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnAdd.Click
        Dim cust = CType(Me.View.AddNew, Customer)
        'Set form-specific defaults, or other UI logic...
        'cust.LastName = "[new]" 'Default property values are set in the WpfEfDAL.Customer partial class constructor
        Me.View.CommitNew()
        Me.ListView1.ScrollIntoView(cust)
        Me.ListView1.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnSave.Click
        Try
            db.SaveChanges()
            MessageBox.Show("Customer data saved.", Me.Title, MessageBoxButton.OK, MessageBoxImage.Information)
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub Item_GotFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        'This will keep the View position in sync with the selected 
        ' row even when a control is being edited in the ListViewItem
        Dim item = CType(sender, ListViewItem)
        Me.ListView1.SelectedItem = item.DataContext
    End Sub
End Class
