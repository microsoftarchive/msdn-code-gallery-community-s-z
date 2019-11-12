Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Security.Cryptography.X509Certificates
Imports System.Xml
Imports ComponentPro.Saml
Imports ComponentPro.Saml.Binding
Imports ComponentPro.Saml2
Imports ComponentPro.Saml2.Binding

Namespace SamlShibboleth.IdentityProvider
	Public Class Util
		Public Const RedirectBinding As String = "redirect"
		Public Const PostBinding As String = "post"
		Public Const ArtifactBinding As String = "artifact"

		''' <summary>
		''' The SP to IdP binding type query string variable.
		''' </summary>
		Private Const SP2IdPBindingTypeVar As String = "binding"

		''' <summary>
		''' Processes the authentication request.
		''' </summary>
		''' <param name="authnRequest">The AuthnRequest object.</param>
		''' <param name="relayState">The relayState string.</param>
		Public Shared Sub ProcessAuthnRequest(ByVal page As Page, <System.Runtime.InteropServices.Out()> ByRef authnRequest As AuthnRequest, <System.Runtime.InteropServices.Out()> ByRef relayState As String)
			' Use a single endpoint and use a query string parameter to determine the Service Provider to Identity Provider binding type.
			Dim bindingType As String = page.Request.QueryString(SP2IdPBindingTypeVar)

			' Get the previously loaded certificate.
			Dim cert As X509Certificate2 = CType(page.Application([Global].SPCertKey), X509Certificate2)

			Select Case bindingType
				Case RedirectBinding
					authnRequest = AuthnRequest.Create(page.Request.RawUrl, cert.PublicKey.Key)
					relayState = authnRequest.RelayState

				Case PostBinding
					authnRequest = AuthnRequest.CreateFromHttpPost(page.Request)
					relayState = authnRequest.RelayState

				Case ArtifactBinding
					Dim httpArtifact As Saml2ArtifactType0004 = Saml2ArtifactType0004.CreateFromHttpArtifactHttpForm(page.Request)

					' Create an artifact resolve request.
					Dim artifactResolve As New ArtifactResolve()
					artifactResolve.Issuer = New Issuer(New Uri(page.Request.Url, page.ResolveUrl("~/")).ToString())
					artifactResolve.Artifact = New Artifact(httpArtifact.ToString())

					' Send the SAML Artifact Resolve Request and parse the received response.
					Dim artifactResponse As ArtifactResponse = ArtifactResponse.SendSamlMessageReceiveAftifactResponse([Global].ArtifactResolutionUrl, artifactResolve)

					' Extract the authentication request from the received artifact response.
					authnRequest = New AuthnRequest(artifactResponse.Message)
					relayState = httpArtifact.RelayState

				Case Else
					Throw New ApplicationException("Invalid binding type")
			End Select

			If authnRequest.IsSigned() Then
				If (Not authnRequest.Validate(cert)) Then
					Throw New ApplicationException("The authentication request signature failed to verify.")
				End If
			End If
		End Sub

		''' <summary>
		''' Gets an absolute URL from an application relative URL.
		''' </summary>
		Private Shared Function GetAbsoluteUrl(ByVal page As Page, ByVal relativeUrl As String) As String
			Return New Uri(page.Request.Url, page.ResolveUrl(relativeUrl)).ToString()
		End Function

		''' <summary>
		''' Builds the SAML response.
		''' </summary>
		''' <param name="authnRequest">The AuthnRequest object.</param>
		''' <returns>A SAML Response object.</returns>
		Public Shared Function BuildResponse(ByVal page As Page, ByVal authnRequest As AuthnRequest) As ComponentPro.Saml2.Response
			Dim samlResponse As New ComponentPro.Saml2.Response()
			samlResponse.Destination = [Global].AssertionServiceUrl
			Dim issuer As New Issuer(GetAbsoluteUrl(page, "~/"))
			samlResponse.Issuer = issuer

			If page.User.Identity.IsAuthenticated Then
				samlResponse.Status = New Status(SamlPrimaryStatusCode.Success, Nothing)

				Dim samlAssertion As New Assertion()
				samlAssertion.Issuer = issuer

				Dim subject As New Subject(New NameId(page.User.Identity.Name))
				Dim subjectConfirmation As New SubjectConfirmation(SamlSubjectConfirmationMethod.Bearer)
				Dim subjectConfirmationData As New SubjectConfirmationData()
				subjectConfirmationData.InResponseTo = authnRequest.Id
				subjectConfirmationData.Recipient = [Global].AssertionServiceUrl
				subjectConfirmation.SubjectConfirmationData = subjectConfirmationData
				subject.SubjectConfirmations.Add(subjectConfirmation)
				samlAssertion.Subject = subject

				Dim authnStatement As New AuthnStatement()
				authnStatement.AuthnContext = New AuthnContext()
				authnStatement.AuthnContext.AuthnContextClassRef = New AuthnContextClassRef(SamlAuthenticateContext.Password)
				samlAssertion.Statements.Add(authnStatement)

				samlResponse.Assertions.Add(samlAssertion)
			Else
				samlResponse.Status = New Status(SamlPrimaryStatusCode.Responder, SamlSecondaryStatusCode.AuthnFailed, "The user is not authenticated at the identity provider")
			End If

			Return samlResponse
		End Function

		''' <summary>
		''' Sends the SAML response to the Service Provider.
		''' </summary>
		''' <param name="samlResponse">The SAML response object.</param>
		''' <param name="relayState">The relay state.</param>
		Public Shared Sub SendResponse(ByVal page As Page, ByVal samlResponse As ComponentPro.Saml2.Response, ByVal relayState As String)
			' Sign the SAML response.
			Dim x509Certificate As X509Certificate2 = CType(page.Application([Global].IdPCertKey), X509Certificate2)
			samlResponse.Sign(x509Certificate)

			Select Case [Global].AssertionServiceSamlBinding
				Case SamlBinding.HttpPost
					' Send the SAML Response object.
					samlResponse.SendPostBindingForm(page.Response.OutputStream, [Global].AssertionServiceUrl, relayState)

				Case SamlBinding.HttpArtifact
					' Create the artifact.
					Dim identificationUrl As String = GetAbsoluteUrl(page, "~/")
					Dim httpArtifact As New Saml2ArtifactType0004(SamlArtifact.GetSourceId(identificationUrl), SamlArtifact.GetHandle())

					' Convert the authentication request to XML and save to the application Cache.
					SamlSettings.CacheProvider.Insert(httpArtifact.ToString(), samlResponse.GetXml(), New TimeSpan(1, 0, 0))

					' Send the artifact with POST form.
					httpArtifact.SendPostForm(page.Response.OutputStream, [Global].AssertionServiceUrl, relayState)

				Case Else
					Throw New ApplicationException("Invalid assertion consumer service binding.")
			End Select
		End Sub
	End Class
End Namespace