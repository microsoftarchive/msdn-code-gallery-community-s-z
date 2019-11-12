Imports Microsoft.VisualBasic
Imports System
Imports System.Web.Security

Namespace SamlShibboleth.IdentityProvider
	Partial Public Class UserLogin
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Form.DefaultFocus = txtPassword.ClientID
			Form.DefaultButton = btnLogin.UniqueID
		End Sub

		Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs)
			If FormsAuthentication.Authenticate(txtUserName.Text, txtPassword.Text) Then
				FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, False)
			Else
				lblErrorMessage.Text = "The user name and password should be ""iuser"" and ""password""."
			End If
		End Sub
	End Class
End Namespace