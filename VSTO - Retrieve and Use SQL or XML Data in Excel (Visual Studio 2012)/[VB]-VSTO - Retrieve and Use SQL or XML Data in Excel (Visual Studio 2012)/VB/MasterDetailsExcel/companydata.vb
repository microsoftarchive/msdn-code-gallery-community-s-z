' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports System.Data
Public Class CompanyData
    Inherits System.Data.DataSet

    Partial Public Class StatusDataTable

        Public Function FindByStatus(ByVal Status As String) As StatusRow
            Dim statusTableRows As DataRow() = Me.Select(String.Format("Status ='{0}'", Status))
            System.Diagnostics.Debug.Assert(statusTableRows.Length = 1, "Status table data is invalid.")
            Return TryCast(statusTableRows(0), StatusRow)
        End Function

    End Class



    Partial Public Class ProductsDataTable

        Public Function FindByName(ByVal Name As String) As ProductsRow
            Dim productsTableRows As DataRow() = Me.Select(String.Format("ProductName ='{0}'", Name))
            System.Diagnostics.Debug.Assert(productsTableRows.Length = 1, "Products table data is invalid.")
            Return TryCast(productsTableRows(0), ProductsRow)
        End Function

    End Class

End Class
