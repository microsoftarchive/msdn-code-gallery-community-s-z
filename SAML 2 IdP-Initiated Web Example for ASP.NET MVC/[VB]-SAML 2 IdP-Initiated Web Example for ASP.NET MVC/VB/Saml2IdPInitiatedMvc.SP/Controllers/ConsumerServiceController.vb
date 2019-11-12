Imports System.Web.Mvc
Imports System.Security.Cryptography.X509Certificates
Imports ComponentPro.Saml2

Namespace Saml2IdPInitiatedMvc.SP.Controllers
	Public Class ConsumerServiceController
		Inherits Controller
		'
		' GET: /ConsumerService/

		Public Function Index() As ActionResult
			Try
'				#Region "Receive SAML Response"

				' Create a SAML response from the HTTP request.
				Dim samlResponse As ComponentPro.Saml2.Response = ComponentPro.Saml2.Response.Create(Request)

				' Is it signed?
				If samlResponse.IsSigned() Then
					' Loaded the previously loaded certificate.
					Dim x509Certificate As X509Certificate2 = CType(System.Web.HttpContext.Current.Application(MvcApplication.CertKeyName), X509Certificate2)

					' Validate the SAML response with the certificate.
					If Not samlResponse.Validate(x509Certificate) Then
						Throw New ApplicationException("SAML response signature is not valid.")
					End If
				End If

'				#End Region

'				#Region "Process the response"

				' Success?
				If Not samlResponse.IsSuccess() Then
					Throw New ApplicationException("SAML response is not success")
				End If

				Dim samlAssertion As Assertion

				' Define ENCRYPTEDSAML preprocessor flag if you wish to decrypt the SAML response.
#If ENCRYPTEDSAML Then
				If samlResponse.GetEncryptedAssertions().Count > 0 Then
					Dim encryptedAssertion As EncryptedAssertion = samlResponse.GetEncryptedAssertions()(0)

					' Load the private key.
					' Consider caching the loaded key in production environment for better performance.
					Dim decryptionKey As New X509Certificate2(Path.Combine(HttpRuntime.AppDomainAppPath, "EncryptionKey.pfx"), "password")

					' Decrypt the encrypted assertion.
					samlAssertion = encryptedAssertion.Decrypt(decryptionKey.PrivateKey, Nothing)
				Else
					Throw New ApplicationException("No encrypted assertions found in the SAML response")
				End If
#Else
				' Get the asserted identity.
				If samlResponse.GetAssertions().Count > 0 Then
					samlAssertion = samlResponse.GetAssertions()(0)
				Else
					Throw New ApplicationException("No assertions found in the SAML response")
				End If
#End If

				' Get the subject name identifier.
				Dim userName As String

				If samlAssertion.Subject.NameId IsNot Nothing Then
					userName = samlAssertion.Subject.NameId.NameIdentifier
				Else
					Throw New ApplicationException("Name identifier not found in subject")
				End If

'				#Region "Extract Custom Attributes"

				' If you need to add custom attributes, uncomment the following code
				'if (samlAssertion.AttributeStatements.Count > 0)
				'{
				'    foreach (AttributeStatement attributeStatement in samlAssertion.AttributeStatements)
				'    {
				'        // If you need to decrypt encrypted attributes, refer to this topic: http://www.samlcomponent.net/encrypting-and-decrypting-saml-response-xml
				'        foreach (ComponentPro.Saml2.Attribute attribute in attributeStatement.Attributes)
				'        {
				'            // Process your custom attribute here.
				'            // ...
				'        }
				'    }
				'}

'				#End Region

				' Set authentication cookie.
				System.Web.Security.FormsAuthentication.SetAuthCookie(userName, False)

				' Redirect to the requested URL.
				Response.Redirect(samlResponse.RelayState, False)

'				#End Region

			Catch exception As Exception
				System.Diagnostics.Trace.Write("ServiceProvider - An Error occurred: " & exception.ToString())
			End Try

			Return View()
		End Function

	End Class
End Namespace
