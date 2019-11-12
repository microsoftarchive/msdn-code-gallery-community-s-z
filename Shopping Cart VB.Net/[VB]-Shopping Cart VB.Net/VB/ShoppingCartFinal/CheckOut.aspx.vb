Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.Security


'--------------------------------------------------------------------------------------------------------------------------------------------------+
' TODO: In a "real"  On Line Store we would implement Shipping qand Payment Processes
'--------------------------------------------------------------------------------------------------------------------------------------------------+

Partial Public Class CheckOut
    Inherits System.Web.UI.Page
    Private _CartTotal As Decimal = 0

    '------------------------------------------------------------------------------------------------------------------------------------------+
    Protected Sub Page_Load(sender As Object, e As EventArgs)
        CheckOutHeader.InnerText = "Your Shopping Cart is Empty"
        LabelCartHeader.Text = ""
        CheckoutBtn.Visible = False
    End Sub

    '------------------------------------------------------------------------------------------------------------------------------------------+
    Protected Sub CheckoutBtn_Click(sender As Object, e As ImageClickEventArgs)
        Dim usersShoppingCart As New MyShoppingCart()
        If usersShoppingCart.SubmitOrder(User.Identity.Name) = True Then
            CheckOutHeader.InnerText = "Thank You - Your Order is Complete."
            Message.Visible = False
            CheckoutBtn.Visible = False
        Else
            CheckOutHeader.InnerText = "Order Submission Failed - Please try again. "
        End If

    End Sub

    '------------------------------------------------------------------------------------------------------------------------------------------+
    Protected Sub MyList_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim myCart As ViewCart = New ViewCart()
            myCart = DirectCast(e.Row.DataItem, ViewCart)
            _CartTotal += myCart.UnitCost * myCart.Quantity
        ElseIf e.Row.RowType = DataControlRowType.Footer Then

            If _CartTotal > 0 Then
                CheckOutHeader.InnerText = "Review and Submit Your Order"
                LabelCartHeader.Text = "Please check all the information below to be sure it&#39;s correct."
                CheckoutBtn.Visible = True
                e.Row.Cells(5).Text = "Total: " & _CartTotal.ToString("C")
            End If
        End If
    End Sub
End Class
