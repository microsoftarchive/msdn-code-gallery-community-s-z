Imports System.Web.Mvc

Namespace Saml2IdPInitiatedMvc.SP.Controllers
	<HandleError> _
	Public Class HomeController
		Inherits Controller
		<Authorize> _
		Public Function Index() As ActionResult
			ViewData("Message") = "Welcome to SAML SSO Idp-Initiated SP Example for ASP.NET MVC!"

			Return View()
		End Function
	End Class
End Namespace
