
Imports System.Collections.ObjectModel
Imports DAL

Public Class OrderDetailsViewModel
    Inherits ViewModelBase

#Region " Declarations "

    Private _cmdSaveCommand As ICommand
    Private _cmdCloseCommand As ICommand

    Private _objOrder_Detail As Order_Detail
    Private _orderDetails As ObservableCollection(Of Order_Detail)
    Dim _selection As Order_Detail

    Private _orderDetailsViewSource As CollectionViewSource
    Private _orderDetailsView As ListCollectionView

    Private dataAccess As IOrderDataService
#End Region

#Region " Properties "

    Public Property OrderDetailsViewSource As CollectionViewSource
        Get
            Return Me._orderDetailsViewSource
        End Get
        Set(ByVal value As CollectionViewSource)
            Me._orderDetailsViewSource = value
            OnPropertyChanged("OrderDetailsViewSource")
        End Set
    End Property

    Public Property OrderDetailsView As ListCollectionView
        Get
            Return Me._orderDetailsView
        End Get
        Set(ByVal value As ListCollectionView)
            Me._orderDetailsView = value
            OnPropertyChanged("OrderDetailsView")
        End Set
    End Property

    Public Property Order_Detail() As Order_Detail
        Get
            Return _objOrder_Detail
        End Get
        Set(ByVal Value As Order_Detail)
            _objOrder_Detail = Value
            OnPropertyChanged("Order_Detail")
        End Set
    End Property

    Public Property Order_Details As ObservableCollection(Of Order_Detail)
        Get
            Return Me._orderDetails
        End Get
        Set(ByVal value As ObservableCollection(Of Order_Detail))
            Me._orderDetails = value
            OnPropertyChanged("Order_Details")
        End Set
    End Property


    Public Property Selection As Order_Detail
        Get
            Return Me._selection
        End Get
        Set(ByVal value As Order_Detail)
            If value Is _selection Then
                Return
            End If
            _selection = value
            MyBase.OnPropertyChanged("Selection")
        End Set
    End Property

#End Region

#Region " Command Properties "

    Public ReadOnly Property SaveCommand() As ICommand
        Get
            If _cmdSaveCommand Is Nothing Then
                _cmdSaveCommand = New RelayCommand(Of Order_Detail)(AddressOf SaveExecute, AddressOf CanSaveExecute)
            End If
            Return _cmdSaveCommand
        End Get
    End Property

    Public ReadOnly Property CloseCommand As ICommand
        Get
            If _cmdCloseCommand Is Nothing Then
                _cmdCloseCommand = New RelayCommand(Of Order_Detail)(AddressOf CloseExecute, AddressOf CanCloseExecute)
            End If
            Return _cmdCloseCommand
        End Get
    End Property
#End Region

#Region " Constructors "

    Public Sub New(ByVal OrderID As Integer)
        Me._orderDetails = New ObservableCollection(Of Order_Detail)

        ServiceLocator.RegisterService(Of IOrderDataService)(New OrderDataService)

        Me.dataAccess = GetService(Of IOrderDataService)()

        Me._orderDetails = dataAccess.GetOrderDetailsByOrderId(OrderID)
        Me._orderDetailsViewSource = New CollectionViewSource
        Me.OrderDetailsViewSource.Source = Me.Order_Details
        Me.OrderDetailsView = CType(Me.OrderDetailsViewSource.View, ListCollectionView)

    End Sub
#End Region

#Region " Command Methods "

    Private Function CanSaveExecute(ByVal param As Order_Detail) As Boolean
        Return True
    End Function

    Private Sub SaveExecute(ByVal param As Order_Detail)
        Me.dataAccess.Save()
    End Sub

    Private Sub CloseExecute(ByVal param As Order_Detail)
        Application.Msn.NotifyColleagues(Application.VIEW_DETAILS_CLOSE)
    End Sub

    Private Function CanCloseExecute(ByVal param As Order_Detail) As Boolean
        Return True
    End Function

#End Region
End Class
