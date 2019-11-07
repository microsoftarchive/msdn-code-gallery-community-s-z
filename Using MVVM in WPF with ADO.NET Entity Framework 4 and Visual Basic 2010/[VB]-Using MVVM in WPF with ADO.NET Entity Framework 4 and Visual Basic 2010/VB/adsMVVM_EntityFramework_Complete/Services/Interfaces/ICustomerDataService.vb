Imports DAL

Public Interface ICustomerDataService

    Function GetAllCustomers() As IQueryable(Of Customer)
End Interface
