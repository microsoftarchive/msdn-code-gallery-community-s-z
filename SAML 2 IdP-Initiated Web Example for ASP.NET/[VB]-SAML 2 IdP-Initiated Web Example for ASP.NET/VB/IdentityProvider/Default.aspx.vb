Imports System.Web.Security

Namespace SamlIdPInitiated.IdentityProvider
	Partial Public Class [Default]
		Inherits System.Web.UI.Page
		Private Shared ReadOnly ServiceProviderUrl As String = System.Web.Configuration.WebConfigurationManager.AppSettings("ServiceProviderUrl")
		Protected NavigateUrl As String

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			' Set the navigate URL to the SSO service page. "spUrl" parameter is the target URL of the Service Provider.
			NavigateUrl = Page.ResolveUrl(String.Format("~/Service.aspx?spUrl={0}", HttpUtility.UrlEncode(ServiceProviderUrl)))
		End Sub

		Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As EventArgs)
			' Sign out
			FormsAuthentication.SignOut()
			' Redirect to the login page.
			Response.Redirect("UserLogin.aspx")
		End Sub
	End Class
End Namespace