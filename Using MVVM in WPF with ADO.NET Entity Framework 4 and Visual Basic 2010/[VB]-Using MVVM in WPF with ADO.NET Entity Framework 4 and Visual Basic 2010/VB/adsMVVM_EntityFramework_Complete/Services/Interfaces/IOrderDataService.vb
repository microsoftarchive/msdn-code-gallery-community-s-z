Imports System.Collections.ObjectModel
Imports DAL

Public Interface IOrderDataService

    'Function GetOrderDetailsByOrderId(ByVal ID As Integer) As System.Data.Objects.ObjectQuery(Of Order_Detail)
    Function GetOrderDetailsByOrderId(ByVal ID As Integer) As ObservableCollection(Of Order_Detail)

    Function GetAllOrders() As IQueryable(Of Order)
    Function GetAllOrders(ByVal customerID As String) As ObservableCollection(Of Order)
    Sub Save()

    Sub Delete(ByVal dataSource As Object)
    Sub Insert(ByVal dataSource As Object, ByVal selectedCustomer As Customer)
    Sub MoveToNext(ByVal dataSource As Object)
    Sub MoveToPrevious(ByVal dataSource As Object)
End Interface
