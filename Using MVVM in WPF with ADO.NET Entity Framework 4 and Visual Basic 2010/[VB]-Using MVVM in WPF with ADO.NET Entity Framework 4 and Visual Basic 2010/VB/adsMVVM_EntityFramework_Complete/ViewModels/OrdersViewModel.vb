
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports DAL


Public Class OrdersViewModel
    Inherits ViewModelBase

    Implements IDataErrorInfo

#Region " Declarations "

    'Serie di comandi necessari
    Private _cmdDeleteCommand As ICommand
    Private _cmdInsertCommand As ICommand
    Private _cmdNextCommand As ICommand
    Private _cmdPreviousCommand As ICommand
    Private _cmdSaveCommand As ICommand
    Private _cmdViewDetails As ICommand

    'Un singolo ordine
    Private _objOrder As Order
    'Rappresenta l'istanza del cliente selezionato
    Private _selection As Customer

    'Espone i dati nel modo classico
    Private _orders As ObservableCollection(Of Order)
    Private _customers As ObservableCollection(Of Customer)

    'Un "ponte" tra View e dati
    Private _customerViewSource As New CollectionViewSource
    Private _customerOrdersViewSource As New CollectionViewSource

    'Liste di oggetti modificabili, per clienti e ordini
    Private WithEvents _customersView As ListCollectionView
    Private WithEvents _customerOrdersView As ListCollectionView

    'REFACTOR
    'Otterrà l'istanza della classe di servizio
    Private orderAccess As IOrderDataService
    Private dataAccess As ICustomerDataService

#End Region

#Region " Properties "


    Public ReadOnly Property CustomerViewSource As CollectionViewSource
        Get
            Return Me._customerViewSource
        End Get
    End Property

    Public Property CustomerOrdersViewSource As CollectionViewSource
        Get
            Return Me._customerOrdersViewSource
        End Get
        Set(ByVal value As CollectionViewSource)
            Me._customerOrdersViewSource = value
            OnPropertyChanged("CustomerOrdersViewSource")
        End Set
    End Property

    Public Property CustomersView As ListCollectionView
        Get
            Return Me._customersView
        End Get
        Set(ByVal value As ListCollectionView)
            Me._customersView = value
            OnPropertyChanged("CustomersView")
        End Set
    End Property

    Public Property CustomerOrdersView As ListCollectionView
        Get
            Return Me._customerOrdersView
        End Get
        Set(ByVal value As ListCollectionView)
            Me._customerOrdersView = value
            OnPropertyChanged("CustomerOrdersView")
        End Set
    End Property

    'Rappresenta l'istanza del cliente selezionato
    Public Property Selection As Customer
        Get
            Return Me._selection
        End Get
        Set(ByVal value As Customer)
            If value Is _selection Then
                Return
            End If
            _selection = value
            MyBase.OnPropertyChanged("Selection")
        End Set
    End Property

    Public Property Customers As ObservableCollection(Of Customer)
        Get
            Return Me._customers
        End Get
        Set(ByVal value As ObservableCollection(Of Customer))
            Me._customers = value
            OnPropertyChanged("Customers")
        End Set
    End Property

    Public Property Orders As ObservableCollection(Of Order)
        Get
            Return Me._orders
        End Get
        Set(ByVal value As ObservableCollection(Of Order))
            Me._orders = value
            OnPropertyChanged("Orders")
        End Set
    End Property

    Public Property Order() As Order
        Get
            Return _objOrder
        End Get
        Set(ByVal Value As Order)
            _objOrder = Value
            OnPropertyChanged("Order")
        End Set
    End Property

    Public Property Customer() As Customer
        Get
            Return _objOrder.Customer
        End Get
        Set(ByVal Value As Customer)
            _objOrder.Customer = Value
            OnPropertyChanged("Customer")
        End Set
    End Property


#End Region

    'REFACTOR
#Region " Command Properties "

    Public ReadOnly Property DeleteCommand() As ICommand
        Get
            If _cmdDeleteCommand Is Nothing Then
                _cmdDeleteCommand = New RelayCommand(Of Order)(AddressOf DeleteExecute, AddressOf CanDeleteExecute)
            End If
            Return _cmdDeleteCommand
        End Get
    End Property

    Public ReadOnly Property InsertCommand() As ICommand
        Get
            If _cmdInsertCommand Is Nothing Then
                _cmdInsertCommand = New RelayCommand(Of Order)(AddressOf InsertExecute, AddressOf CanInsertExecute)
            End If
            Return _cmdInsertCommand
        End Get
    End Property

    Public ReadOnly Property NextCommand() As ICommand
        Get
            If _cmdNextCommand Is Nothing Then
                _cmdNextCommand = New RelayCommand(Of Order)(AddressOf NextExecute, AddressOf CanNextExecute)
            End If
            Return _cmdNextCommand
        End Get
    End Property

    Public ReadOnly Property PreviousCommand() As ICommand
        Get
            If _cmdPreviousCommand Is Nothing Then
                _cmdPreviousCommand = New RelayCommand(Of Order)(AddressOf PreviousExecute, AddressOf CanPreviousExecute)
            End If
            Return _cmdPreviousCommand
        End Get
    End Property

    Public ReadOnly Property SaveCommand() As ICommand
        Get
            If _cmdSaveCommand Is Nothing Then
                _cmdSaveCommand = New RelayCommand(Of Order)(AddressOf SaveExecute, AddressOf CanSaveExecute)
            End If
            Return _cmdSaveCommand
        End Get
    End Property

    Public ReadOnly Property ViewDetailsCommand() As ICommand
        Get
            If _cmdViewDetails Is Nothing Then
                _cmdViewDetails = New RelayCommand(Of Order)(AddressOf ViewDetailsExecute, AddressOf CanViewDetailsExecute)
            End If
            Return _cmdViewDetails
        End Get
    End Property

#End Region

    Private Function GetAllCustomers() As IQueryable(Of Customer)
        Return Me.dataAccess.GetAllCustomers
    End Function

#Region " Constructors "

    Public Sub New()
        Me._customers = New ObservableCollection(Of Customer)

        'Registra l'istanza della classe di servizio relativa ai clienti
        ServiceLocator.RegisterService(Of ICustomerDataService)(New CustomerDataService)
        'Registra l'istanza della classe di servizio relativa agli ordini
        ServiceLocator.RegisterService(Of IOrderDataService)(New OrderDataService)

        'Ottiene l'istanza delle due classi
        'REFACTOR
        Me.dataAccess = GetService(Of ICustomerDataService)()
        Me.orderAccess = GetService(Of IOrderDataService)()

        'Cicla l'elenco dei clienti ottenuto e lo aggiunge
        'alla collezione
        'REFACTOR
        For Each element In Me.GetAllCustomers
            Me._customers.Add(element)
        Next

        'Imposta la CollectionViewSource
        _customerViewSource.Source = Me.Customers

        'Ottiene la View della CollectionViewSource e la converte
        'in una ListCollectionView con supporto alla modifica
        Me.CustomersView = CType(Me.CustomerViewSource.View, ListCollectionView)
        Me.CustomersView.MoveCurrentToFirst()
    End Sub

#End Region

#Region " Command Methods "

    Private Function CanDeleteExecute(ByVal param As Order) As Boolean
        If Me.CustomerOrdersView Is Nothing Then Return False
        Return Me.CustomerOrdersView.CurrentPosition > -1
    End Function

    Private Sub DeleteExecute(ByVal param As Order)
        Me.orderAccess.Delete(Me.CustomerOrdersView)
    End Sub

    Private Function CanInsertExecute(ByVal param As Order) As Boolean
        Return True
    End Function

    Private Sub InsertExecute(ByVal param As Order)
        Me.orderAccess.Insert(Me.CustomerOrdersView, Me.Selection)
    End Sub

    Private Function CanNextExecute(ByVal param As Order) As Boolean
        If Me.CustomerOrdersViewSource.View Is Nothing Then Return False
        Return Me.CustomerOrdersViewSource.View.CurrentPosition <
            CType(Me.CustomerOrdersViewSource.View, CollectionView).Count - 1
    End Function

    Private Sub NextExecute(ByVal param As Order)
        If Me.CanNextExecute(param) Then
            Me.orderAccess.MoveToNext(Me.CustomerOrdersViewSource)
        End If
    End Sub

    Private Function CanPreviousExecute(ByVal param As Order) As Boolean
        If Me.CustomerOrdersViewSource.View Is Nothing Then Return False
        Return Me.CustomerOrdersViewSource.View.CurrentPosition > 0
    End Function

    Private Sub PreviousExecute(ByVal param As Order)
        If Me.CanPreviousExecute(param) Then
            Me.orderAccess.MoveToPrevious(Me.CustomerOrdersViewSource)
        End If
    End Sub

    Private Function CanSaveExecute(ByVal param As Order) As Boolean
        Try
            If CType(Me.CustomerOrdersView.CurrentItem, Order).HasErrors Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub SaveExecute(ByVal param As Order)
        Me.orderAccess.Save()
    End Sub

    Private Function CanViewDetailsExecute(ByVal param As Order) As Boolean
        Return Me.Selection IsNot Nothing
    End Function

    Private Sub ViewDetailsExecute(ByVal param As Order)
        Application.Msn.NotifyColleagues(Application.VIEW_DETAILS_EXECUTE)
    End Sub

#End Region

#Region " IDataErrorInfo members "
    Public ReadOnly Property [Error] As String Implements System.ComponentModel.IDataErrorInfo.Error
        Get
            Return TryCast(Me.Order, IDataErrorInfo).Error
        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal columnName As String) As String Implements System.ComponentModel.IDataErrorInfo.Item
        Get
            Dim [error] As String = Nothing

            [error] = (TryCast(Me.Order, IDataErrorInfo))(columnName)
            ' Dirty the commands registered with CommandManager,
            ' such as our Save command, so that they are queried
            ' to see if they can execute now.
            CommandManager.InvalidateRequerySuggested()

            Return [error]
        End Get
    End Property
#End Region

#Region " Event handlers"
    '_customersView è il backing field per la proprietà CustomersView
    'REFACTOR
    Private Sub _customersView_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _customersView.CurrentChanged
        Me.UpdateOrdersViewAfterCustomerChanged(CType(Me.CustomersView.CurrentItem, Customer))
    End Sub

    Private Function UpdateOrdersViewAfterCustomerChanged(ByVal currentCustomer As Customer) As Boolean
        Try
            Me.Orders = orderAccess.GetAllOrders(currentCustomer.CustomerID)
            Me.CustomerOrdersViewSource.Source = Me.Orders
            Me.CustomerOrdersView = CType(Me.CustomerOrdersViewSource.View, ListCollectionView)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region


End Class
