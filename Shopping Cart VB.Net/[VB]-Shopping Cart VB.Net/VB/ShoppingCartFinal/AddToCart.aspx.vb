'Public Class AddToCart
'    Inherits System.Web.UI.Page

'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

'    End Sub

'End Class

Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Diagnostics




Partial Public Class AddToCart
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs)
        Dim rawId As String = Request.QueryString("ProductID")
        Dim productId As Integer
        If Not [String].IsNullOrEmpty(rawId) AndAlso Int32.TryParse(rawId, productId) Then
            Dim usersShoppingCart As New MyShoppingCart()
            Dim cartId As [String] = usersShoppingCart.GetShoppingCartId()
            usersShoppingCart.AddItem(cartId, productId, 1)
        Else
            Debug.Fail("ERROR : We should never get to AddToCart.aspx without a ProductId.")
            Throw New Exception("ERROR : It is illegal to load AddToCart.aspx without setting a ProductId.")
        End If
        Response.Redirect("MyShoppingCart.aspx")
    End Sub
End Class
