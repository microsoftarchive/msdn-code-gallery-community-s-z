Imports System.Web.Security

Namespace SamlIdPInitiated.IdentityProvider
	Partial Public Class UserLogin
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			' Set default focus.
			Form.DefaultFocus = txtPassword.ClientID
			Form.DefaultButton = btnLogin.UniqueID
		End Sub

		Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs)
			' Authenticate the user.
			If FormsAuthentication.Authenticate(txtUserName.Text, txtPassword.Text) Then
				FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, False)
			Else
				lblErrorMessage.Text = "The user name and password should be ""iuser"" and ""password""."
			End If
		End Sub
	End Class
End Namespace