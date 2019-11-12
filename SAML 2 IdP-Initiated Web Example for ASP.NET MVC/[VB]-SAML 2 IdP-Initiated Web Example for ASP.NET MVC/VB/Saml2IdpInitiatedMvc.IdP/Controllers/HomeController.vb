Imports System.Web.Mvc

Namespace Saml2IdpInitiatedMvc.Controllers
	<HandleError> _
	Public Class HomeController
		Inherits Controller
		<Authorize> _
		Public Function Index() As ActionResult
			ViewData("Message") = "Welcome to SAML SSO Idp-Initiated IdP Example for ASP.NET MVC!"

			Dim serviceProviderUrl As String = System.Web.Configuration.WebConfigurationManager.AppSettings("ServiceProviderUrl")
			ViewData("NavigateUrl") = System.Web.VirtualPathUtility.ToAbsolute(String.Format("~/Service?spUrl={0}", HttpUtility.UrlEncode(serviceProviderUrl)))

			Return View()
		End Function

		Public Function About() As ActionResult
			Return View()
		End Function
	End Class
End Namespace
