Imports System.Data.Services
Imports System.Linq
Imports System.ServiceModel.Web

Public Class Northwind
    Inherits DataService(Of NorthwindEntities)

    ' This method is called only once to initialize service-wide policies.
    Public Shared Sub InitializeService(ByVal config As IDataServiceConfiguration)
        ' Make certain entity sets writable.
        config.SetEntitySetAccessRule("Customers", EntitySetRights.All)
        config.SetEntitySetAccessRule("Employees", EntitySetRights.All)
        config.SetEntitySetAccessRule("Orders", EntitySetRights.All)
        config.SetEntitySetAccessRule("Order_Details", EntitySetRights.All)
        config.SetEntitySetAccessRule("Products", EntitySetRights.All)

        ' Make the remaining entity sets read-only.
        config.SetEntitySetAccessRule("*", EntitySetRights.AllRead)
    End Sub

End Class
