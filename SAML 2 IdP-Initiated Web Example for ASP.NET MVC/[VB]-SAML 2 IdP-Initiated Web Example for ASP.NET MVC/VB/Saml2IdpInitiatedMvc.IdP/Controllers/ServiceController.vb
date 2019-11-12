Imports System.Web.Mvc
Imports System.Security.Cryptography.X509Certificates
Imports ComponentPro.Saml2

Namespace Saml2IdpInitiatedMvc.Controllers
	Public Class ServiceController
		Inherits Controller
		'
		' GET: /Service/

		Public Function Index(ByVal spUrl As String) As ActionResult
			Dim consumerServiceUrl As String = System.Web.Configuration.WebConfigurationManager.AppSettings("ConsumerServiceUrl")

			Try
				' Extract the SP target url.
				Dim targetUrl As String = spUrl

				' Validate it.
				If String.IsNullOrEmpty(targetUrl) Then
					Return View()
				End If

				' Create a SAML response object.
				Dim samlResponse As New ComponentPro.Saml2.Response()
				' Assign the consumer service url.
				samlResponse.Destination = consumerServiceUrl
				Dim issuer As New Issuer(System.Web.VirtualPathUtility.ToAbsolute("~/"))
				samlResponse.Issuer = issuer
				samlResponse.Status = New Status(SamlPrimaryStatusCode.Success, Nothing)

				Dim samlAssertion As New Assertion()
				samlAssertion.Issuer = issuer

				' Use the local user's local identity.
				Dim subject As New Subject(New NameId(User.Identity.Name))
				Dim subjectConfirmation As New SubjectConfirmation(SamlSubjectConfirmationMethod.Bearer)
				Dim subjectConfirmationData As New SubjectConfirmationData()
				subjectConfirmationData.Recipient = consumerServiceUrl
				subjectConfirmation.SubjectConfirmationData = subjectConfirmationData
				subject.SubjectConfirmations.Add(subjectConfirmation)
				samlAssertion.Subject = subject

				' Create a new authentication statement.
				Dim authnStatement As New AuthnStatement()
				authnStatement.AuthnContext = New AuthnContext()
				authnStatement.AuthnContext.AuthnContextClassRef = New AuthnContextClassRef(SamlAuthenticateContext.Password)
				samlAssertion.Statements.Add(authnStatement)

				' If you need to add custom attributes, uncomment the following code
				' #region Custom Attributes
				' AttributeStatement attributeStatement = new AttributeStatement();
				' attributeStatement.Attributes.Add(new ComponentPro.Saml2.Attribute("email", SamlAttributeNameFormat.Basic, null,
				' "john@test.com"));
				' attributeStatement.Attributes.Add(new ComponentPro.Saml2.Attribute("FirstName", SamlAttributeNameFormat.Basic, null,
				' "John"));
				' attributeStatement.Attributes.Add(new ComponentPro.Saml2.Attribute("LastName", SamlAttributeNameFormat.Basic, null,
				' "Smith"));

				' // Insert a custom token key to the SAML response.
				' attributeStatement.Attributes.Add(new ComponentPro.Saml2.Attribute("CustomTokenForVerification", SamlAttributeNameFormat.Basic, null,
				' "YourEncryptedTokenHere"));

				' samlAssertion.Statements.Add(attributeStatement);
				' #endregion


				' Define ENCRYPTEDSAML preprocessor flag if you wish to encrypt the SAML response.
#If ENCRYPTEDSAML Then
				' Load the certificate for the encryption.
				' Please make sure the file is in the root directory.
				Dim encryptingCert As New X509Certificate2(Path.Combine(HttpRuntime.AppDomainAppPath, "EncryptionX509Certificate.cer"), "password")

				' Create an encrypted SAML assertion from the SAML assertion we have created.
				Dim encryptedSamlAssertion As New EncryptedAssertion(samlAssertion, encryptingCert, New System.Security.Cryptography.Xml.EncryptionMethod(SamlKeyAlgorithm.TripleDesCbc))

				' Add encrypted assertion to the SAML response object.
				samlResponse.Assertions.Add(encryptedSamlAssertion)
#Else
				' Add assertion to the SAML response object.
				samlResponse.Assertions.Add(samlAssertion)
#End If

				' Get the previously loaded certificate.
				Dim x509Certificate As X509Certificate2 = CType(System.Web.HttpContext.Current.Application(MvcApplication.CertKeyName), X509Certificate2)

				' Sign the SAML response with the certificate.
				samlResponse.Sign(x509Certificate)

				' Send the SAML response to the service provider.
				samlResponse.SendPostBindingForm(Response.OutputStream, consumerServiceUrl, targetUrl)

			Catch exception As Exception
				System.Diagnostics.Trace.Write("An Error occurred: " & exception.ToString())
			End Try

			Return View()
		End Function
	End Class
End Namespace
