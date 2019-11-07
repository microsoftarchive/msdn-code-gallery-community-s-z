//#define ENCRYPTEDSAML

using System;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Security.Cryptography.X509Certificates;
using ComponentPro.Saml2;

namespace SamlIdPInitiated.ServiceProvider
{
    public partial class ConsumerService : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                #region Receive SAML Response

                // Create a SAML response from the HTTP request.
                ComponentPro.Saml2.Response samlResponse = ComponentPro.Saml2.Response.Create(Request);

                // Is it signed?
                if (samlResponse.IsSigned())
                {
                    // Loaded the previously loaded certificate.
                    X509Certificate2 x509Certificate = (X509Certificate2)Application[Global.CertKeyName];

                    // Validate the SAML response with the certificate.
                    if (!samlResponse.Validate(x509Certificate))
                    {
                        throw new ApplicationException("SAML response signature is not valid.");
                    }
                }

                #endregion

                #region Process the response

                // Success?
                if (!samlResponse.IsSuccess())
                {
                    throw new ApplicationException("SAML response is not success");
                }

                Assertion samlAssertion;

                // Define ENCRYPTEDSAML preprocessor flag if you wish to decrypt the SAML response.
#if ENCRYPTEDSAML
                if (samlResponse.GetEncryptedAssertions().Count > 0)
                {
                    EncryptedAssertion encryptedAssertion = samlResponse.GetEncryptedAssertions()[0];

                    // Load the private key.
                    // Consider caching the loaded key in production environment for better performance.
                    X509Certificate2 decryptionKey = new X509Certificate2(Path.Combine(HttpRuntime.AppDomainAppPath, "EncryptionKey.pfx"), "password");

                    // Decrypt the encrypted assertion.
                    samlAssertion = encryptedAssertion.Decrypt(decryptionKey.PrivateKey, null);
                }
                else
                {
                    throw new ApplicationException("No encrypted assertions found in the SAML response");
                }
#else
                // Get the asserted identity.
                if (samlResponse.GetAssertions().Count > 0)
                {
                    samlAssertion = samlResponse.GetAssertions()[0];
                }
                else
                {
                    throw new ApplicationException("No assertions found in the SAML response");
                }
#endif

                // Get the subject name identifier.
                string userName;

                if (samlAssertion.Subject.NameId != null)
                {
                    userName = samlAssertion.Subject.NameId.NameIdentifier;
                }
                else
                {
                    throw new ApplicationException("Name identifier not found in subject");
                }

                #region Extract Custom Attributes

                // If you need to add custom attributes, uncomment the following code
                //if (samlAssertion.AttributeStatements.Count > 0)
                //{
                //    foreach (AttributeStatement attributeStatement in samlAssertion.AttributeStatements)
                //    {
                //        // If you need to decrypt encrypted attributes, refer to this topic: http://www.samlcomponent.net/encrypting-and-decrypting-saml-response-xml
                //        foreach (ComponentPro.Saml2.Attribute attribute in attributeStatement.Attributes)
                //        {
                //            // Process your custom attribute here.
                //            // ...
                //        }
                //    }
                //}

                #endregion

                // Set authentication cookie.
                FormsAuthentication.SetAuthCookie(userName, false);

                // Redirect to the requested URL.
                Response.Redirect(samlResponse.RelayState, false);

                #endregion
            }

            catch (Exception exception)
            {
                Trace.Write("ServiceProvider", "An Error occurred", exception);
            }
        }
    }
}