Imports WpfEfDAL

''' <summary>
''' This form demonstrates simple data validation error display.
''' - 1. XAML data bindings specify ValidatesOnDataErrors=True
''' - 2. WpfEfDAL.Customer implements IDataErrorInfo and specifies a validation rule on the LastName property
''' - 3. Application.xaml defines an ErrorTemplate for displaying validation errors
''' </summary>
''' <remarks></remarks>
Partial Public Class SimpleValidation

    Private db As New OMSEntities 'EF ObjectContext connects to database and tracks changes
    Private CustomerData As CustomerCollection 'inherits from ObservableCollection
    Private View As ListCollectionView 'provides currency to controls (position & movement in the collection)

    Private Sub Validation_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded

        Dim query = From c In db.Customers _
                    Where c.City = "Seattle" _
                    Order By c.LastName, c.FirstName _
                    Select c

        Me.CustomerData = New CustomerCollection(query, db)

        Dim customerSource = CType(Me.FindResource("CustomerSource"), CollectionViewSource)
        customerSource.Source = Me.CustomerData

        Me.View = CType(customerSource.View, ListCollectionView)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnAdd.Click
        Me.View.AddNew()
        Me.View.CommitNew()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnSave.Click
        Try
            If Not Me.CustomerData.HasErrors Then
                db.SaveChanges()
                MessageBox.Show("Customer data saved.", Me.Title, MessageBoxButton.OK, MessageBoxImage.Information)
            Else
                MessageBox.Show("Please correct the errors on this form before saving.", Me.Title, MessageBoxButton.OK, MessageBoxImage.Stop)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub


End Class
