using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography.X509Certificates;
using ComponentPro.Saml2;

namespace Saml2IdpInitiatedMvc.Controllers
{
    public class ServiceController : Controller
    {
        //
        // GET: /Service/

        public ActionResult Index(string spUrl)
        {
            string consumerServiceUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["ConsumerServiceUrl"];

            try
            {
                // Extract the SP target url.
                string targetUrl = spUrl;

                // Validate it.
                if (string.IsNullOrEmpty(targetUrl))
                {
                    return View();
                }

                // Create a SAML response object.
                ComponentPro.Saml2.Response samlResponse = new ComponentPro.Saml2.Response();
                // Assign the consumer service url.
                samlResponse.Destination = consumerServiceUrl;
                Issuer issuer = new Issuer(System.Web.VirtualPathUtility.ToAbsolute("~/"));
                samlResponse.Issuer = issuer;
                samlResponse.Status = new Status(SamlPrimaryStatusCode.Success, null);

                Assertion samlAssertion = new Assertion();
                samlAssertion.Issuer = issuer;

                // Use the local user's local identity.
                Subject subject = new Subject(new NameId(User.Identity.Name));
                SubjectConfirmation subjectConfirmation = new SubjectConfirmation(SamlSubjectConfirmationMethod.Bearer);
                SubjectConfirmationData subjectConfirmationData = new SubjectConfirmationData();
                subjectConfirmationData.Recipient = consumerServiceUrl;
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
                X509Certificate2 x509Certificate = (X509Certificate2)System.Web.HttpContext.Current.Application[MvcApplication.CertKeyName];

                // Sign the SAML response with the certificate.
                samlResponse.Sign(x509Certificate);

                // Send the SAML response to the service provider.
                samlResponse.SendPostBindingForm(Response.OutputStream, consumerServiceUrl, targetUrl);
            }

            catch (Exception exception)
            {
                System.Diagnostics.Trace.Write("An Error occurred: " + exception.ToString());
            }

            return View();
        }
    }
}
