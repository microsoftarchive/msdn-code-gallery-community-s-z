Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security
Imports System.Net
Imports System.Web.Mvc
Imports System.Web.Routing

Namespace Saml2IdPInitiatedMvc.SP
	' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	' visit http://go.microsoft.com/?LinkId=9394801

	Public Class MvcApplication
		Inherits System.Web.HttpApplication
		Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

			routes.MapRoute("Default", "{controller}/{action}/{id}", New With {Key .controller = "Home", Key .action = "Index", Key .id = UrlParameter.Optional}) ' Parameter defaults -  URL with parameters -  Route name

		End Sub

		Protected Sub Application_Start()
			AreaRegistration.RegisterAllAreas()

			RegisterRoutes(RouteTable.Routes)

			' Set server certificate validation callback.
			ServicePointManager.ServerCertificateValidationCallback = AddressOf ValidateRemoteServerCertificate

			' Load the certificate.
			Dim fileName As String = Path.Combine(HttpRuntime.AppDomainAppPath, "X509Certificate.cer")
			LoadCertificate(fileName, "password")
		End Sub

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
	End Class
End Namespace