Imports Microsoft.VisualBasic
Imports System
Imports System.Web.Security
Imports ComponentPro.Saml2

Namespace SamlShibboleth.IdentityProvider
	Partial Public Class SingleSignOnService
		Inherits System.Web.UI.Page
		Private Const SsoAuthnStateSessionKey As String = "SsoAuthnStateSessionKey"

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)

			Try
				' Load the Single Sign On state from the Session state.
				' If the saved authentication state is a null reference, receive the authentication request from the query string and form data.
				Dim ssoState As SsoAuthnState = CType(Session(SsoAuthnStateSessionKey), SsoAuthnState)

				If ssoState Is Nothing OrElse (Not User.Identity.IsAuthenticated) Then
                    Dim authnRequest As AuthnRequest = Nothing
                    Dim relayState As String = Nothing

					' Receive the authentication request and relay state.
					Util.ProcessAuthnRequest(Me, authnRequest, relayState)

					' Check whether the provider MUST authenticate the presenter directly rather than rely on a previous security context.
					Dim forceAuthn As Boolean = authnRequest.ForceAuthn
					Dim allowCreate As Boolean = False

					If authnRequest.NameIdPolicy IsNot Nothing Then
						' Check whether the identity provider is allowed.
						allowCreate = authnRequest.NameIdPolicy.AllowCreate
					End If

					ssoState = New SsoAuthnState()
					ssoState.AuthnRequest = authnRequest
					ssoState.State = relayState

					' A boolean flag determining whether or not a local login is required.
					Dim requireLocalLogin As Boolean = False

					If forceAuthn Then
						requireLocalLogin = True
					Else
						If (Not User.Identity.IsAuthenticated) AndAlso allowCreate Then
							requireLocalLogin = True
						End If
					End If

					' Local login is required?
					If requireLocalLogin Then
						' Then save the session state.
						Session(SsoAuthnStateSessionKey) = ssoState
						' And redirect to the login page.
						FormsAuthentication.RedirectToLoginPage()

						Return
					End If
				End If

				' Create a new SAML 2 Response.
				Dim samlResponse As ComponentPro.Saml2.Response = Util.BuildResponse(Me, ssoState.AuthnRequest)

				' Send the SAML response to the service provider.
				Util.SendResponse(Me, samlResponse, ssoState.State)

			Catch exception As Exception
				Trace.Write("IdentityProvider", "An Error occurred", exception)
			End Try
		End Sub
	End Class
End Namespace