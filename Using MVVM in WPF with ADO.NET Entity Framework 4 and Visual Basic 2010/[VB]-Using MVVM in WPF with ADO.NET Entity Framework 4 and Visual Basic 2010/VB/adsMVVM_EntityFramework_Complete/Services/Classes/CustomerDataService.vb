Imports DAL

Public Class CustomerDataService
    Implements ICustomerDataService

    Public Function GetAllCustomers() As IQueryable(Of Customer) Implements ICustomerDataService.GetAllCustomers
        Return Northwind.Customers.Include("Orders")
    End Function
End Class
