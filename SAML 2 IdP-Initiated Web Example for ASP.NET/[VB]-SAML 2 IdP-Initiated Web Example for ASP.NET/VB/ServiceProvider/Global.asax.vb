Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security
Imports System.Net

Namespace SamlIdPInitiated.ServiceProvider
	Public Class [Global]
		Inherits System.Web.HttpApplication
		Public Const CertKeyName As String = "Cert"

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
		''' <param name="fileName">The certificate file name.</param>
		''' <param name="password">The password for this certificate file.</param>
		Private Sub LoadCertificate(ByVal fileName As String, ByVal password As String)
			Dim cert As New X509Certificate2(fileName, password, X509KeyStorageFlags.MachineKeySet)

			Application(CertKeyName) = cert
		End Sub

		Private Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
			' Set server certificate validation callback.
			ServicePointManager.ServerCertificateValidationCallback = AddressOf ValidateRemoteServerCertificate

			' Load the certificate.
			Dim fileName As String = Path.Combine(HttpRuntime.AppDomainAppPath, "X509Certificate.cer")
			LoadCertificate(fileName, "password")
		End Sub
	End Class
End Namespace