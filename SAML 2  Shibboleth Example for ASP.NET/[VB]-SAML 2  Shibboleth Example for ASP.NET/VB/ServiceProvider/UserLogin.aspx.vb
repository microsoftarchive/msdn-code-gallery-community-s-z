Imports Microsoft.VisualBasic
Imports System
Imports System.Security.Cryptography.X509Certificates
Imports System.Web.Security
Imports System.Xml
Imports ComponentPro.Saml
Imports ComponentPro.Saml.Binding
Imports ComponentPro.Saml2
Imports ComponentPro.Saml2.Binding

Namespace SamlShibboleth.ServiceProvider
	Partial Public Class UserLogin
		Inherits System.Web.UI.Page
		Protected NavigateUrl As String

		Private Const errorQueryParameter As String = "error"

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Form.DefaultFocus = txtPassword.ClientID
			Form.DefaultButton = btnLogin.UniqueID

			' Display any error message resulting from a failed login.
			If (Not String.IsNullOrEmpty(Request.QueryString(errorQueryParameter))) Then
				lblErrorMessage.Text = Request.QueryString(errorQueryParameter)
			Else
				lblErrorMessage.Text = String.Empty
			End If
		End Sub

		Protected Sub btnIdPLogin_Click(ByVal sender As Object, ByVal e As EventArgs)
			' Get the authentication request.
			Dim authnRequest As AuthnRequest = Util.GetAuthnRequest(Me)

			' Get SP Resource URL.
			Dim spResourceUrl As String = Util.GetAbsoluteUrl(Me, FormsAuthentication.GetRedirectUrl("", False))
			' Create relay state.
			Dim relayState As String = Guid.NewGuid().ToString()
			' Save the SP Resource URL to the cache.
			SamlSettings.CacheProvider.Insert(relayState, spResourceUrl, New TimeSpan(1, 0, 0))

			Select Case [Global].SingleSignOnServiceBinding
				Case SamlBinding.HttpRedirect
					Dim x509Certificate As X509Certificate2 = CType(Application([Global].SpCertKey), X509Certificate2)

					' Send authentication request using HTTP Redirect.
					authnRequest.Redirect(Response, [Global].SingleSignOnServiceURL, relayState, x509Certificate.PrivateKey)

				Case SamlBinding.HttpPost
					' Send authentication request using HTTP POST form.
					authnRequest.SendHttpPost(Response, [Global].SingleSignOnServiceURL, relayState)

					' End the response.
					Response.End()

				Case SamlBinding.HttpArtifact
					' Create a new http artifact.
					Dim identificationUrl As String = Util.GetAbsoluteUrl(Me, "~/")
					Dim httpArtifact As New Saml2ArtifactType0004(SamlArtifact.GetSourceId(identificationUrl), SamlArtifact.GetHandle())

					' Save the authentication request for subsequent sending using the artifact resolution protocol.
					SamlSettings.CacheProvider.Insert(httpArtifact.ToString(), authnRequest.GetXml(), New TimeSpan(1, 0, 0))

					' Send the artifact using HTTP POST form.
					httpArtifact.SendPostForm(Response.OutputStream, [Global].SingleSignOnServiceURL, relayState)

					' End the response.
					Response.End()

				Case Else
					Throw New ApplicationException("Invalid binding type")
			End Select
		End Sub

		Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs)
			If FormsAuthentication.Authenticate(txtUserName.Text, txtPassword.Text) Then
				FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, False)
			Else
				lblErrorMessage.Text = "The user name and password should be ""suser"" and ""password""."
			End If
		End Sub
	End Class
End Namespace