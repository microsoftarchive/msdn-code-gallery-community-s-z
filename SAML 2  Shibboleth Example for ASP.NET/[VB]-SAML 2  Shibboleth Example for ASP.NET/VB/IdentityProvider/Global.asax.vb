Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Web.Configuration
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security
Imports System.IO
Imports System.Net
Imports ComponentPro.Saml2

Namespace SamlShibboleth.IdentityProvider
	Public Class [Global]
		Inherits HttpApplication
		Private Const IdPKeyFile As String = "IdpKey.pfx"
		Private Const IdPKeyPassword As String = "password"

		Private Const SPCertFile As String = "SPCertificate.cer"

		Public Const IdPCertKey As String = "IdPCertKey"
		Public Const SPCertKey As String = "SPCert"

		''' <summary>
		''' Verifies the remote Secure Sockets Layer (SSL) certificate used for authentication.
		''' </summary>
		''' <param name="sender">An object that contains state information for this validation.</param>
		''' <param name="certificate">The certificate used to authenticate the remote party.</param>
		''' <param name="chain">The chain of certificate authorities associated with the remote certificate.</param>
		''' <param name="sslPolicyErrors">One or more errors associated with the remote certificate.</param>
		''' <returns>A System.Boolean value that determines whether the specified certificate is accepted for authentication.</returns>
		Private Shared Function ValidateRemoteServerCertificate(ByVal sender As Object, ByVal certificate As X509Certificate, ByVal chain As X509Chain, ByVal sslPolicyErrors As SslPolicyErrors) As Boolean
			' NOTE: This is a test application with self-signed certificates, so all certificates are trusted.
			Return True
		End Function

		''' <summary>
		''' Loads the certificate file.
		''' </summary>
		''' <param name="cacheKey">The cache key.</param>
		''' <param name="fileName">The certificate file name.</param>
		''' <param name="password">The password for this certificate file.</param>
		Private Sub LoadCertificate(ByVal cacheKey As String, ByVal fileName As String, ByVal password As String)
			Dim cert As New X509Certificate2(fileName, password, X509KeyStorageFlags.MachineKeySet)

			Application(cacheKey) = cert
		End Sub

		Private Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
			' Set server certificate validation callback.
			ServicePointManager.ServerCertificateValidationCallback = AddressOf ValidateRemoteServerCertificate

			' Load the IdP key file.
			LoadCertificate(IdPCertKey, Path.Combine(HttpRuntime.AppDomainAppPath, IdPKeyFile), IdPKeyPassword)

			' Load the IdP key file.
			LoadCertificate(SPCertKey, Path.Combine(HttpRuntime.AppDomainAppPath, SPCertFile), Nothing)
		End Sub

		#Region "Config"

		Private Const AssertionServiceSamlBindingKey As String = "AssertionServiceSamlBinding"
		Private Const AssertionServiceUrlHttpPostKey As String = "AssertionServiceUrlHttpPost"
		Private Const AssertionServiceUrlHttpArtifactKey As String = "AssertionServiceUrlHttpArtifact"
		Private Const ArtifactResolutionUrlKey As String = "ArtifactResolutionUrl"

		Public Shared ReadOnly Property AssertionServiceSamlBinding() As SamlBinding
			Get
				Return SamlBindingUri.UriToBinding(WebConfigurationManager.AppSettings(AssertionServiceSamlBindingKey))
			End Get
		End Property

		Public Shared ReadOnly Property AssertionServiceUrl() As String
			Get
				Select Case AssertionServiceSamlBinding
					Case SamlBinding.HttpPost
						Return AssertionServiceUrlHttpPost

					Case SamlBinding.HttpArtifact
						Return AssertionServiceUrlHttpArtifact

					Case Else
						Throw New ArgumentException("Invalid assertion consumer service binding")
				End Select
			End Get
		End Property

		Public Shared ReadOnly Property AssertionServiceUrlHttpPost() As String
			Get
				Return WebConfigurationManager.AppSettings(AssertionServiceUrlHttpPostKey)
			End Get
		End Property

		Public Shared ReadOnly Property AssertionServiceUrlHttpArtifact() As String
			Get
				Return WebConfigurationManager.AppSettings(AssertionServiceUrlHttpArtifactKey)
			End Get
		End Property

		Public Shared ReadOnly Property ArtifactResolutionUrl() As String
			Get
				Return WebConfigurationManager.AppSettings(ArtifactResolutionUrlKey)
			End Get
		End Property

		#End Region
	End Class
End Namespace