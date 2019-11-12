'#define ENCRYPTEDSAML

Imports System.Web.Configuration
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports ComponentPro.Saml2

Namespace SamlIdPInitiated.IdentityProvider
	Partial Public Class Service
		Inherits System.Web.UI.Page
		' Get consumer service URL from the application settings.
		Private Shared ReadOnly ConsumerServiceUrl As String = WebConfigurationManager.AppSettings("ConsumerServiceUrl")

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)

			Try
				' Extract the SP target url.
				Dim targetUrl As String = Request.QueryString("spUrl")

				' Validate it.
				If String.IsNullOrEmpty(targetUrl) Then
					Return
				End If

				' Create a SAML response object.
				Dim samlResponse As New ComponentPro.Saml2.Response()
				' Assign the consumer service url.
				samlResponse.Destination = ConsumerServiceUrl
				Dim issuer As New Issuer(GetAbsoluteUrl("~/"))
				samlResponse.Issuer = issuer
				samlResponse.Status = New Status(SamlPrimaryStatusCode.Success, Nothing)

				Dim samlAssertion As New Assertion()
				samlAssertion.Issuer = issuer

				' Use the local user's local identity.
				Dim subject As New Subject(New NameId(User.Identity.Name))
				Dim subjectConfirmation As New SubjectConfirmation(SamlSubjectConfirmationMethod.Bearer)
				Dim subjectConfirmationData As New SubjectConfirmationData()
				subjectConfirmationData.Recipient = ConsumerServiceUrl
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
				Dim x509Certificate As X509Certificate2 = CType(Application([Global].CertKeyName), X509Certificate2)

				' Sign the SAML response with the certificate.
				samlResponse.Sign(x509Certificate)

				' Send the SAML response to the service provider.
				samlResponse.SendPostBindingForm(Response.OutputStream, ConsumerServiceUrl, targetUrl)

			Catch exception As Exception
				Trace.Write("IdentityProvider", "An Error occurred", exception)
			End Try
		End Sub

		Private Function GetAbsoluteUrl(ByVal relativeUrl As String) As String
			Dim u As New Uri(Request.Url, ResolveUrl(relativeUrl))
			Return u.ToString()
		End Function
	End Class
End Namespace