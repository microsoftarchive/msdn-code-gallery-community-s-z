Imports System.Collections.Specialized
Imports System.Collections.Generic
Imports System.Collections
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


Partial Public Class MyShoppingCart
    Inherits System.Web.UI.Page
    '------------------------------------------------------------------------------------------------------------------------------------------+
    Protected Sub Page_Load(sender As Object, e As EventArgs)
        Dim usersShoppingCart As New MyShoppingCart()
        Dim cartId As [String] = usersShoppingCart.GetShoppingCartId()
        Dim cartTotal As Decimal = 0
        cartTotal = usersShoppingCart.GetTotal(cartId)
        If cartTotal > 0 Then
            lblTotal.Text = [String].Format("{0:c}", usersShoppingCart.GetTotal(cartId))
        Else
            LabelTotalText.Text = ""
            lblTotal.Text = ""
            ShoppingCartTitle.InnerText = "Shopping Cart is Empty"
            UpdateBtn.Visible = False
            CheckoutBtn.Visible = False
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------------------------------------+
    Protected Sub UpdateBtn_Click(sender As Object, e As ImageClickEventArgs)
        Dim usersShoppingCart As New MyShoppingCart()
        Dim cartId As [String] = usersShoppingCart.GetShoppingCartId()

        Dim cartUpdates As ShoppingCartUpdates() = New ShoppingCartUpdates(MyList.Rows.Count - 1) {}
        For i As Integer = 0 To MyList.Rows.Count - 1
            Dim rowValues As IOrderedDictionary = New OrderedDictionary()
            rowValues = GetValues(MyList.Rows(i))
            cartUpdates(i).ProductId = Convert.ToInt32(rowValues("ProductID"))
            cartUpdates(i).PurchaseQuantity = Convert.ToInt32(rowValues("Quantity"))

            Dim cbRemove As New CheckBox()
            cbRemove = DirectCast(MyList.Rows(i).FindControl("Remove"), CheckBox)
            cartUpdates(i).RemoveItem = cbRemove.Checked
        Next

        usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates)
        MyList.DataBind()
        lblTotal.Text = [String].Format("{0:c}", usersShoppingCart.GetTotal(cartId))
    End Sub

    '------------------------------------------------------------------------------------------------------------------------------------------+
    Public Shared Function GetValues(row As GridViewRow) As IOrderedDictionary
        Dim values As IOrderedDictionary = New OrderedDictionary()
        For Each cell As DataControlFieldCell In row.Cells
            If cell.Visible Then
                ' Extract values from the cell
                cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, True)
            End If
        Next
        Return values
    End Function

End Class
