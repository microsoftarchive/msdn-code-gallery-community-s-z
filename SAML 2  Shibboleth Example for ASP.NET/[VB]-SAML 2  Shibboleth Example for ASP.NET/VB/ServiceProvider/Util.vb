Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Security.Cryptography.X509Certificates
Imports ComponentPro.Saml
Imports ComponentPro.Saml2
Imports ComponentPro.Saml2.Binding

Namespace SamlShibboleth.ServiceProvider
	Public Class Util
		''' <summary>
		''' Processes the SAML response received from the IdP.
		''' </summary>
		''' <param name="page">The page object.</param>
		''' <param name="relayState">The relay state</param>
		''' <param name="samlResponse">The SAML response object.</param>
		Public Shared Sub ProcessResponse(ByVal page As Page, <System.Runtime.InteropServices.Out()> ByRef samlResponse As ComponentPro.Saml2.Response, <System.Runtime.InteropServices.Out()> ByRef relayState As String)
			' Extract the binding type from the query string.
			Dim bindingType As String = page.Request.QueryString("binding")

			Select Case bindingType
				Case "artifact"
					' Create an artifact from the query string.
					Dim httpArtifact As Saml2ArtifactType0004 = Saml2ArtifactType0004.CreateFromHttpArtifactQueryString(page.Request)

					' Create an artifact resolve request.
					Dim artifactResolve As New ArtifactResolve()
					artifactResolve.Issuer = New Issuer(GetAbsoluteUrl(page, "~/"))
					artifactResolve.Artifact = New Artifact(httpArtifact.ToString())

					' Send the artifact resolve request and create an artifact response from the received XML.
					Dim artifactResponse As ArtifactResponse = ArtifactResponse.SendSamlMessageReceiveAftifactResponse([Global].ArtifactServiceUrl, artifactResolve)

					' Get the SAML Response from the artifact response.
					samlResponse = New ComponentPro.Saml2.Response(artifactResponse.Message)
					relayState = httpArtifact.RelayState

				Case "post"
					' Create a SAML response from the form data.
					samlResponse = ComponentPro.Saml2.Response.Create(page.Request)
					relayState = samlResponse.RelayState

				Case Else
					Throw New ApplicationException("Unknown binding type")
			End Select

			' Is the SAML response signed?
			If samlResponse.IsSigned() Then
				' Get the previously loaded certificate.
				Dim x509Certificate As X509Certificate2 = CType(page.Application([Global].IdPCertKey), X509Certificate2)

				' Validate the certificate.
				If (Not samlResponse.Validate(x509Certificate)) Then
					Throw New ApplicationException("The SAML response signature failed to verify.")
				End If
			End If
		End Sub

		''' <summary>
		''' Processes a successful SAML response and redirect to the requested URL.
		''' </summary>
		''' <param name="page">The page object.</param>
		''' <param name="samlResponse">The SAML response object.</param>
		''' <param name="relayState">The relay state.</param>
		Public Shared Sub SamlSuccessRedirect(ByVal page As Page, ByVal samlResponse As ComponentPro.Saml2.Response, ByVal relayState As String)
			' Get the previously loaded certificate.
			Dim x509Certificate As X509Certificate2 = CType(page.Application([Global].SpCertKey), X509Certificate2)

			Dim samlAssertion As Assertion

			' Check assertions.
			If samlResponse.GetAssertions().Count > 0 Then
				' Extract the first assertion.
				samlAssertion = samlResponse.GetAssertions()(0)
			ElseIf samlResponse.GetEncryptedAssertions().Count > 0 Then
				' Extract the first assertion.
				samlAssertion = samlResponse.GetEncryptedAssertions()(0).Decrypt(x509Certificate.PrivateKey, Nothing)
			Else
				Throw New ApplicationException("No assertions in response")
			End If

			Dim userName As String

			' Get the subject name identifier.
			If samlAssertion.Subject.NameId IsNot Nothing Then
				userName = samlAssertion.Subject.NameId.NameIdentifier
			ElseIf samlAssertion.Subject.EncryptedId IsNot Nothing Then
				Dim nameId As NameId = samlAssertion.Subject.EncryptedId.Decrypt(x509Certificate.PrivateKey, Nothing)
				userName = nameId.NameIdentifier
			Else
				Throw New ApplicationException("No name in subject")
			End If

			' Get the originally requested resource URL from the relay state.
			Dim resourceUrl As String = CStr(SamlSettings.CacheProvider.Remove(relayState))
			If resourceUrl Is Nothing Then
				Throw New ApplicationException("Invalid relay state")
			End If

			' Create a login context for the asserted identity.
			FormsAuthentication.SetAuthCookie(userName, False)

			' Redirect to the originally requested resource URL.
			page.Response.Redirect(resourceUrl, False)
		End Sub

		''' <summary>
		''' Processes an error SAML response and redirect to the requested URL.
		''' </summary>
		''' <param name="page">The page object.</param>
		''' <param name="samlResponse">The SAML response object.</param>
		''' <param name="relayState">The relay state.</param>
		Public Shared Sub SamlErrorRedirect(ByVal page As Page, ByVal samlResponse As ComponentPro.Saml2.Response)
			Dim errorMessage As String = Nothing

			If samlResponse.Status.StatusMessage IsNot Nothing Then
				errorMessage = samlResponse.Status.StatusMessage.Message
			End If

			Dim redirectUrl As String = String.Format("~/UserLogin.aspx?error={0}", HttpUtility.UrlEncode(errorMessage))

			page.Response.Redirect(redirectUrl, False)
		End Sub

		''' <summary>
		''' Gets the authentication request.
		''' </summary>
		''' <param name="page">The page object.</param>
		''' <returns>The authentication request object.</returns>
		Public Shared Function GetAuthnRequest(ByVal page As Page) As AuthnRequest
			' Create the authentication request.
			Dim authnRequest As New AuthnRequest()
			authnRequest.Destination = [Global].SingleSignOnServiceURL
			authnRequest.Issuer = New Issuer(GetAbsoluteUrl(page, "~/"))
			authnRequest.ForceAuthn = False
			authnRequest.NameIdPolicy = New NameIdPolicy(Nothing, Nothing, True)

            If [Global].SingleSignOnServiceBinding <> SamlBinding.HttpRedirect Then
                ' Sign the authentication request if the SSO service binding is not HTTP Redirect.
                ' Get the certificate.
                Dim x509Certificate As X509Certificate2 = CType(page.Application([Global].SpCertKey), X509Certificate2)

                ' Sign the SAML request.
                authnRequest.Sign(x509Certificate)
            End If

			Return authnRequest
		End Function

		''' <summary>
		''' Gets absolute URL.
		''' </summary>
		''' <param name="page">The page object.</param>
		''' <param name="relativeUrl">The relative URL.</param>
		''' <returns>The absolute URL.</returns>
		Public Shared Function GetAbsoluteUrl(ByVal page As Page, ByVal relativeUrl As String) As String
			Return New Uri(page.Request.Url, page.ResolveUrl(relativeUrl)).ToString()
		End Function
	End Class
End Namespace