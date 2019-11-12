//#define ENCRYPTEDSAML

using System;
using System.Web.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Web;
using ComponentPro.Saml2;

namespace SamlIdPInitiated.IdentityProvider
{
    public partial class Service : System.Web.UI.Page
    {
        // Get consumer service URL from the application settings.
        private static readonly string ConsumerServiceUrl = WebConfigurationManager.AppSettings["ConsumerServiceUrl"];

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                // Extract the SP target url.
                string targetUrl = Request.QueryString["spUrl"];

                // Validate it.
                if (string.IsNullOrEmpty(targetUrl))
                {
                    return;
                }

                // Create a SAML response object.
                ComponentPro.Saml2.Response samlResponse = new ComponentPro.Saml2.Response();
                // Assign the consumer service url.
                samlResponse.Destination = ConsumerServiceUrl;
                Issuer issuer = new Issuer(GetAbsoluteUrl("~/"));
                samlResponse.Issuer = issuer;
                samlResponse.Status = new Status(SamlPrimaryStatusCode.Success, null);

                Assertion samlAssertion = new Assertion();
                samlAssertion.Issuer = issuer;

                // Use the local user's local identity.
                Subject subject = new Subject(new NameId(User.Identity.Name));
                SubjectConfirmation subjectConfirmation = new SubjectConfirmation(SamlSubjectConfirmationMethod.Bearer);
                SubjectConfirmationData subjectConfirmationData = new SubjectConfirmationData();
                subjectConfirmationData.Recipient = ConsumerServiceUrl;
                subjectConfirmation.SubjectConfirmationData = subjectConfirmationData;
                subject.SubjectConfirmations.Add(subjectConfirmation);
                samlAssertion.Subject = subject;

                // Create a new authentication statement.
                AuthnStatement authnStatement = new AuthnStatement();
                authnStatement.AuthnContext = new AuthnContext();
                authnStatement.AuthnContext.AuthnContextClassRef = new AuthnContextClassRef(SamlAuthenticateContext.Password);
                samlAssertion.Statements.Add(authnStatement);

                // If you need to add custom attributes, uncomment the following code
                // #region Custom Attributes
                // AttributeStatement attributeStatement = new AttributeStatement();
                // attributeStatement.Attributes.Add(new ComponentPro.Saml2.Attribute("email", SamlAttributeNameFormat.Basic, null,
                                                                                             // "john@test.com"));
                // attributeStatement.Attributes.Add(new ComponentPro.Saml2.Attribute("FirstName", SamlAttributeNameFormat.Basic, null,
                                                                                             // "John"));
                // attributeStatement.Attributes.Add(new ComponentPro.Saml2.Attribute("LastName", SamlAttributeNameFormat.Basic, null,
                                                                                             // "Smith"));

                // // Insert a custom token key to the SAML response.
                // attributeStatement.Attributes.Add(new ComponentPro.Saml2.Attribute("CustomTokenForVerification", SamlAttributeNameFormat.Basic, null,
                                                                                             // "YourEncryptedTokenHere"));

                // samlAssertion.Statements.Add(attributeStatement);
                // #endregion


                // Define ENCRYPTEDSAML preprocessor flag if you wish to encrypt the SAML response.
#if ENCRYPTEDSAML
                // Load the certificate for the encryption.
                // Please make sure the file is in the root directory.
                X509Certificate2 encryptingCert = new X509Certificate2(Path.Combine(HttpRuntime.AppDomainAppPath, "EncryptionX509Certificate.cer"), "password");

                // Create an encrypted SAML assertion from the SAML assertion we have created.
                EncryptedAssertion encryptedSamlAssertion = new EncryptedAssertion(samlAssertion, encryptingCert, new System.Security.Cryptography.Xml.EncryptionMethod(SamlKeyAlgorithm.TripleDesCbc));

                // Add encrypted assertion to the SAML response object.
                samlResponse.Assertions.Add(encryptedSamlAssertion);
#else
                // Add assertion to the SAML response object.
                samlResponse.Assertions.Add(samlAssertion);
#endif

                // Get the previously loaded certificate.
                X509Certificate2 x509Certificate = (X509Certificate2)Application[Global.CertKeyName];

                // Sign the SAML response with the certificate.
                samlResponse.Sign(x509Certificate);

                // Send the SAML response to the service provider.
                samlResponse.SendPostBindingForm(Response.OutputStream, ConsumerServiceUrl, targetUrl);
            }

            catch (Exception exception)
            {
                Trace.Write("IdentityProvider", "An Error occurred", exception);
            }
        }
        
        private string GetAbsoluteUrl(string relativeUrl)
        {
            Uri u = new Uri(Request.Url, ResolveUrl(relativeUrl));
            return u.ToString();
        }
    }
}