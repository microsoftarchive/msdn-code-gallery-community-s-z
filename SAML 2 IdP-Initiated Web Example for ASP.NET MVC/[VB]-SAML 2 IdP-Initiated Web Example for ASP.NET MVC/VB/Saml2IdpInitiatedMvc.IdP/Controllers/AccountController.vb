Imports System.Diagnostics.CodeAnalysis
Imports System.Security.Principal
Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Web.Security
Imports Saml2IdpInitiatedMvc.Models

Namespace Saml2IdpInitiatedMvc.Controllers

	<HandleError> _
	Public Class AccountController
		Inherits Controller

		Public Property FormsService() As IFormsAuthenticationService
		Public Property MembershipService() As IMembershipService

		Protected Overrides Sub Initialize(ByVal requestContext As RequestContext)
			If FormsService Is Nothing Then
				FormsService = New FormsAuthenticationService()
			End If
			If MembershipService Is Nothing Then
				MembershipService = New AccountMembershipService()
			End If

			MyBase.Initialize(requestContext)
		End Sub

		' **************************************
		' URL: /Account/LogOn
		' **************************************

		Public Function LogOn() As ActionResult
			Return View()
		End Function

		<HttpPost> _
		Public Function LogOn(ByVal model As LogOnModel, ByVal returnUrl As String) As ActionResult
			If ModelState.IsValid Then
				If MembershipService.ValidateUser(model.UserName, model.Password) Then
					FormsService.SignIn(model.UserName, model.RememberMe)
					If Not String.IsNullOrEmpty(returnUrl) Then
						Return Redirect(returnUrl)
					Else
						Return RedirectToAction("Index", "Home")
					End If
				Else
					ModelState.AddModelError("", "The user name or password provided is incorrect.")
				End If
			End If

			' If we got this far, something failed, redisplay form
			Return View(model)
		End Function

		' **************************************
		' URL: /Account/LogOff
		' **************************************

		Public Function LogOff() As ActionResult
			FormsService.SignOut()

			Return RedirectToAction("Index", "Home")
		End Function
	End Class
End Namespace
