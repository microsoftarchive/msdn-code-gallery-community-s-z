Imports Microsoft.VisualBasic
Imports System
Imports System.Web.Security

Namespace SamlShibboleth.IdentityProvider
	Partial Public Class [Default]
		Inherits System.Web.UI.Page
		Private Shared ReadOnly ServiceProviderUrl As String = System.Web.Configuration.WebConfigurationManager.AppSettings("ServiceProviderUrl")
		Protected NavigateUrl As String

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			' Construct a URL to the local SSO service and specifying the target URL of the SP.
			NavigateUrl = ServiceProviderUrl
		End Sub

		Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As EventArgs)
			FormsAuthentication.SignOut()
			Response.Redirect("UserLogin.aspx")
		End Sub
	End Class
End Namespace