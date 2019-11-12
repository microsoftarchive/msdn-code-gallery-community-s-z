' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Public Class CustomersOrdersControl

    Public Sub New()
        Me.InitializeComponent()

        Me.selectCustomer.DataSource = Globals.ThisWorkbook.CustomersBindingSource
        Me.selectCustomer.DisplayMember = "ContactName"
        Me.selectCustomer.ValueMember = "CustomerID"

        Me.contactName.DataBindings.Add("Text", Globals.ThisWorkbook.CustomersBindingSource, "ContactName")
        Me.phoneNumber.DataBindings.Add("Text", Globals.ThisWorkbook.CustomersBindingSource, "Phone")
        Me.faxNumber.DataBindings.Add("Text", Globals.ThisWorkbook.CustomersBindingSource, "Fax")

        Me.unfulfilledOrders.DataSource = Globals.ThisWorkbook.CustomerOrdersBindingSource
        Me.unfulfilledOrders.DisplayMember = "OrderID"
    End Sub

End Class
