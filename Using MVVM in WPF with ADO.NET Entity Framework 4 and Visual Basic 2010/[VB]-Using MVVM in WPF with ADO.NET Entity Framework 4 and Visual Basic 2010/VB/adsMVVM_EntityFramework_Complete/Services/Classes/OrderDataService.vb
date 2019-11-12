Imports System.Data, System.Windows.Data
Imports System.Data.Objects
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports DAL

Public Class OrderDataService
    Implements IOrderDataService

    Public Function GetOrderDetailsByOrderID(ByVal ID As Integer) As ObservableCollection(Of Order_Detail) Implements IOrderDataService.GetOrderDetailsByOrderId
        Dim OrderDetailsQuery As System.Data.Objects.ObjectQuery(Of Order_Detail) = CType((From det In Northwind.Order_Details
                                                                                   Where det.OrderID = ID
                                                                                   Select det),
                                                                                   Global.System.Data.Objects.ObjectQuery(Of Order_Detail))

        Return New ObservableCollection(Of Order_Detail)(OrderDetailsQuery)
    End Function

    Public Sub Insert(ByVal dataSource As Object, ByVal customer As Customer) Implements IOrderDataService.Insert
        Dim newOrder As Order
        Dim tp = dataSource.GetType

        Select Case tp.Name
            Case Is = "ListCollectionView"
                Dim source = CType(dataSource, ListCollectionView)

                newOrder = CType(source.AddNew, Order)
                newOrder.Customer = customer

                'Aggiunge il nuovo ordine cosicchè il binding
                'faccia sì che l'ErrorTemplate venga richiamato
                source.CommitNew()
            Case Is = "BindingListCollectionView"
                Dim source = CType(dataSource, BindingListCollectionView)

                newOrder = CType(source.AddNew, Order)
                newOrder.Customer = customer

                'Aggiunge il nuovo ordine cosicchè il binding
                'faccia sì che l'ErrorTemplate venga richiamato
                source.CommitNew()
            Case Else
                Throw New InvalidOperationException("Data source is of a type CollectionView which does not support adding items")
        End Select

    End Sub

    Public Sub Save() Implements IOrderDataService.Save
        Try
            Northwind.SaveChanges()
        Catch ex As OptimisticConcurrencyException
            'Gestione concorrenza
            Northwind.Refresh(Objects.RefreshMode.ClientWins,
                                        Northwind.Orders)
            Northwind.SaveChanges()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetAllOrders() As IQueryable(Of Order) Implements IOrderDataService.GetAllOrders
        Return Northwind.Orders
    End Function

    Public Function GetAllOrders(ByVal customerID As String) As ObservableCollection(Of Order) Implements IOrderDataService.GetAllOrders
        Dim query = From ord In Northwind.Orders.Include("Customer")
                  Where ord.CustomerID = customerID
                  Select ord

        Return New ObservableCollection(Of Order)(query)
    End Function

    Public Sub MoveToNext(ByVal dataSource As Object) Implements IOrderDataService.MoveToNext
        CType(dataSource, CollectionViewSource).View.MoveCurrentToNext()
    End Sub

    Public Sub MoveToPrevious(ByVal dataSource As Object) Implements IOrderDataService.MoveToPrevious
        CType(dataSource, CollectionViewSource).View.MoveCurrentToPrevious()
    End Sub

    Public Sub Delete(ByVal dataSource As Object) Implements IOrderDataService.Delete
        Dim tp = dataSource.GetType

        Select Case tp.Name
            Case Is = "ListCollectionView"
                Dim source = CType(dataSource, ListCollectionView)
                source.Remove(source.CurrentItem)
            Case Is = "BindingListCollectionView"
                Dim source = CType(dataSource, BindingListCollectionView)
                source.Remove(source.CurrentItem)
            Case Else
                Throw New InvalidOperationException("Data source is of a type that does not support removing items")
        End Select

    End Sub
End Class

