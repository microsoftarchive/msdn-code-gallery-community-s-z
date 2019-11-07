Imports Microsoft.VisualBasic
Imports System
Imports System.Web.Security

Namespace SamlShibboleth.ServiceProvider
	Partial Public Class [Default]
		Inherits System.Web.UI.Page
		Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As EventArgs)
			FormsAuthentication.SignOut()
			Response.Redirect("UserLogin.aspx")
		End Sub
	End Class
End Namespace