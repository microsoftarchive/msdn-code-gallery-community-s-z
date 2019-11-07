Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Web
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security
Imports System.Net
Imports System.Web.Configuration
Imports ComponentPro.Saml2

Namespace SamlShibboleth.ServiceProvider
	Public Class [Global]
		Inherits HttpApplication
		Private Const SpCertFile As String = "SPKey.pfx"
		Private Const SpCertPass As String = "password"
		Public Const SpCertKey As String = "spX509Certificate"

		Private Const IdPCertFile As String = "IdpCertificate.cer"
		Public Const IdPCertKey As String = "idpX509Certificate"

		''' <summary>
		''' Verifies the remote Secure Sockets Layer (SSL) certificate used for authentication.
		''' </summary>
		''' <param name="sender">An object that contains state information for this validation.</param>
		''' <param name="certificate">The certificate used to authenticate the remote party.</param>
		''' <param name="chain">The chain of certificate authorities associated with the remote certificate.</param>
		''' <param name="sslPolicyErrors">One or more errors associated with the remote certificate.</param>
		''' <returns>A System.Boolean value that determines whether the specified certificate is accepted for authentication.</returns>
		Private Shared Function ValidateServerCertificate(ByVal sender As Object, ByVal certificate As X509Certificate, ByVal chain As X509Chain, ByVal sslPolicyErrors As SslPolicyErrors) As Boolean
			Return True
		End Function

		''' <summary>
		''' Loads the certificate file.
		''' </summary>
		''' <param name="cacheKey">The cache key.</param>
		''' <param name="fileName">The certificate file name.</param>
		''' <param name="password">The password for this certificate file.</param>
		Private Shared Function LoadCertificate(ByVal fileName As String, ByVal password As String) As X509Certificate2
			If (Not File.Exists(fileName)) Then
				Throw New ArgumentException("The certificate file " & fileName & " doesn't exist.")
			End If

			Try
				Return New X509Certificate2(fileName, password, X509KeyStorageFlags.MachineKeySet)

			Catch exception As Exception
				Throw New ArgumentException("The certificate file " & fileName & " couldn't be loaded - " & exception.Message)
			End Try
		End Function

		Private Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
			' In a test environment, trust all certificates.
			ServicePointManager.ServerCertificateValidationCallback = AddressOf ValidateServerCertificate

			' Load the SP certificate.
			Dim fileName As String = Path.Combine(HttpRuntime.AppDomainAppPath, SpCertFile)
			Application(SpCertKey) = LoadCertificate(fileName, SpCertPass)

			' Load the IdP certificate.
			fileName = Path.Combine(HttpRuntime.AppDomainAppPath, IdPCertFile)
			Application(IdPCertKey) = LoadCertificate(fileName, Nothing)
		End Sub

		#Region "Config"

		Public Shared ReadOnly Property SingleSignOnServiceBinding() As SamlBinding
			Get
				Return SamlBindingUri.UriToBinding(WebConfigurationManager.AppSettings("SingleSignOnServiceBinding"))
			End Get
		End Property

		Public Shared ReadOnly Property SingleSignOnServiceURL() As String
			Get
				Select Case SingleSignOnServiceBinding
					Case SamlBinding.HttpPost
						Return SingleSignOnServiceUrlHttpPost

					Case SamlBinding.HttpRedirect
						Return SingleSignOnServiceUrlHttpRedirect

					Case SamlBinding.HttpArtifact
						Return SingleSignOnServiceUrlHttpArtifact

					Case Else
						Throw New ArgumentException("Unknown SSO Service Binding")
				End Select
			End Get
		End Property

		Public Shared ReadOnly Property SingleSignOnServiceUrlHttpPost() As String
			Get
				Return WebConfigurationManager.AppSettings("SingleSignOnServiceUrlHttpPost")
			End Get
		End Property

		Public Shared ReadOnly Property SingleSignOnServiceUrlHttpRedirect() As String
			Get
				Return WebConfigurationManager.AppSettings("SingleSignOnServiceUrlHttpRedirect")
			End Get
		End Property

		Public Shared ReadOnly Property SingleSignOnServiceUrlHttpArtifact() As String
			Get
				Return WebConfigurationManager.AppSettings("SingleSignOnServiceUrlHttpArtifact")
			End Get
		End Property

		Public Shared ReadOnly Property ArtifactServiceUrl() As String
			Get
				Return WebConfigurationManager.AppSettings("ArtifactServiceUrl")
			End Get
		End Property

		#End Region
	End Class
End Namespace