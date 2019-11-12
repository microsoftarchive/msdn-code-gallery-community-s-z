'Public Class Login
'    Inherits System.Web.UI.Page

'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
'    End Sub

'End Class

Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security


Partial Public Class Login
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs)
        If Not Page.IsPostBack Then
            If Page.Request.UrlReferrer IsNot Nothing Then
                Session("LoginReferrer") = Page.Request.UrlReferrer.ToString()
            End If
        End If

        If User.Identity.IsAuthenticated Then
            FormsAuthentication.SignOut()

            Response.Redirect("~/")
        End If

    End Sub

    Protected Sub LoginUser_LoggedIn(sender As Object, e As EventArgs)
        Dim usersShoppingCart As New MyShoppingCart()
        Dim cartId As [String] = usersShoppingCart.GetShoppingCartId()
        usersShoppingCart.MigrateCart(cartId, LoginUser.UserName)

        If Session("LoginReferrer") IsNot Nothing Then
            Response.Redirect(Session("LoginReferrer").ToString())
        End If

        Session("UserName") = LoginUser.UserName
    End Sub

    Protected Sub LoginButton_Click(sender As Object, e As EventArgs)

    End Sub
End Class