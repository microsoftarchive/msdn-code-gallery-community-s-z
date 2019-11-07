' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Public Class Sheet1

    Private productListColumnHeaders As String() = {"ProductName", "Quantity", "Inventory"}

    Private Const productNameColumn As Integer = 1
    Private Const quantityOrderedColumn As Integer = 2
    Private Const currentInventoryColumn As Integer = 3
    Private Const quantityOrderedChartSeries As String = """Quantity Ordered"""
    Private Const inventoryChartSeries As String = """Inventory"""
    Private Const noOrderSelectedTitle As String = "No Order Selected"
    Private Const canFulfillOrderTitle As String = "Order Can Be Fulfilled"
    Private Const cannotFulfillOrderTitle As String = "Order Not Ready for Fulfillment"

    Private Sub Sheet1_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup

        ' Set the column headers for the ProductList.
        Me.ProductList.HeaderRowRange.Value2 = productListColumnHeaders

        ' Set the captions for the Chart.
        CType(Me.OrdersChart.SeriesCollection(1), Excel.Series).Name = quantityOrderedChartSeries
        CType(Me.OrdersChart.SeriesCollection(2), Excel.Series).Name = inventoryChartSeries
        Me.OrdersChart.ChartTitle.Text = noOrderSelectedTitle

        ' Bind the ProductList to the order details of the currently selected order.
        Me.ProductList.SetDataBinding(Globals.ThisWorkbook.OrderDetailsBindingSource, _
            Nothing, productListColumnHeaders)

        ' Bind the Status named range to the status of the currently selected order.
        Me.Status.DataBindings.Add("Value2", Globals.ThisWorkbook.StatusBindingSource, "Status")

    End Sub

    Private Sub Sheet1_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

    Private Sub UpdateChart()
        If (Globals.ThisWorkbook.CustomerOrdersBindingSource.Count = 0) Then
            Me.OrdersChart.ChartTitle.Text = noOrderSelectedTitle
        ElseIf (Me.CanFulfillOrder()) Then
            Me.OrdersChart.ChartTitle.Text = canFulfillOrderTitle
        Else
            Me.OrdersChart.ChartTitle.Text = cannotFulfillOrderTitle
        End If
    End Sub

    Private Function CanFulfillOrder() As Boolean

        Dim listRange As Excel.Range = Me.ProductList.DataBodyRange

        For i As Integer = 1 To listRange.Rows.Count
            ' Get the values within the ListRow.
            Dim values As Object(,) = CType(CType(listRange.Rows.Item(i), Excel.Range).Value2, Object(,))

            ' Determine what product the row is representing.
            If (values(1, productNameColumn) Is Nothing) Then
                Continue For
            End If
            Dim product As String = values(1, productNameColumn).ToString()

            ' If there is a product n this row, determine the available quantity of that product.
            If (Not String.IsNullOrEmpty(product)) Then
                Dim quantity As Integer = CInt(values(1, quantityOrderedColumn))
                Dim productRow As CompanyData.ProductsRow = _
                    Globals.ThisWorkbook.CurrentCompanyData.Products.FindByName(product)

                ' Check to see if there is enough inventory for the quantity being ordered.
                If ((productRow.Inventory - quantity) < 0) Then
                    Return False
                End If
            End If
        Next

        Return True
    End Function

    Private Sub Status_Change(ByVal Target As Microsoft.Office.Interop.Excel.Range) Handles Status.Change
        ' Get the StatusID for the Status just set on the Status named range.
        Debug.Assert(TryCast(Globals.ThisWorkbook.CustomerOrdersBindingSource.Current, DataRowView) IsNot Nothing)
        Dim currentRow As DataRowView = CType(Globals.ThisWorkbook.CustomerOrdersBindingSource.Current, DataRowView)
        Debug.Assert(TryCast(currentRow.Row, CompanyData.OrdersRow) IsNot Nothing)
        Dim orderRow As CompanyData.OrdersRow = CType(currentRow.Row, CompanyData.OrdersRow)
        Dim newStatus As Integer = Globals.ThisWorkbook.currentCompanyData.Status.FindByStatus( _
            Me.Status.Value2.ToString()).StatusId

        ' Check to see if the status was set to Fulfilled when it could not
        ' actually be fulfilled.  If so, alert the user that the order cannot be fulfilled.
        If ((newStatus = 0) AndAlso (orderRow.StatusID <> 0) AndAlso (Not Me.CanFulfillOrder())) Then
            MessageBox.Show("Order cannot be fulfilled with current inventory levels.")
            Return
        ElseIf ((newStatus = 0) AndAlso (orderRow.StatusID <> 0)) Then
            ' The order was changed to be fulfilled, so the inventory needs
            ' to be updated to remove the quantities that were shipped.
            Me.UpdateInventory()
        End If

        ' Update the order to reflect the new status.
        orderRow.StatusID = newStatus
    End Sub

    Private Sub UpdateInventory()
        Dim listRange As Excel.Range = Me.ProductList.DataBodyRange

        For i As Integer = 1 To listRange.Rows.Count
            ' Get the values within the ListRow.
            Dim values As Object(,) = CType(CType(listRange.Rows.Item(i), Excel.Range).Value2, Object(,))

            ' Determine what product the row is representing.
            If (values(1, productNameColumn) Is Nothing) Then
                Continue For
            End If
            Dim product As String = values(1, productNameColumn).ToString()

            ' If there is a product n this row, determine the available quantity of that product.
            If (Not String.IsNullOrEmpty(product)) Then
                Dim quantity As Integer = CInt(values(1, quantityOrderedColumn))
                Dim productRow As CompanyData.ProductsRow = _
                    Globals.ThisWorkbook.CurrentCompanyData.Products.FindByName(product)


                ' Update the ProductRow to reflect the new inventory level.
                productRow.Inventory = productRow.Inventory - quantity
            End If
        Next

        ' Save changes to the DataSet.
        Globals.ThisWorkbook.currentCompanyData.AcceptChanges()
    End Sub

    Private Sub ProductList_Change(ByVal targetRange As Microsoft.Office.Interop.Excel.Range, ByVal changedRanges As Microsoft.Office.Tools.Excel.ListRanges) Handles ProductList.Change
        Me.UpdateChart()
    End Sub
End Class
