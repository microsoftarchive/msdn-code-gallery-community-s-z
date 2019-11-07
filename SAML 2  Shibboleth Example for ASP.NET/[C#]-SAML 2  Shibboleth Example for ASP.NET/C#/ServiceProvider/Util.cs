using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Security.Cryptography.X509Certificates;
using ComponentPro.Saml;
using ComponentPro.Saml2;
using ComponentPro.Saml2.Binding;

namespace SamlShibboleth.ServiceProvider
{
    public class Util
    {
        /// <summary>
        /// Processes the SAML response received from the IdP.
        /// </summary>
        /// <param name="page">The page object.</param>
        /// <param name="relayState">The relay state</param>
        /// <param name="samlResponse">The SAML response object.</param>
        public static void ProcessResponse(Page page, out ComponentPro.Saml2.Response samlResponse, out string relayState)
        {
            // Extract the binding type from the query string.
            string bindingType = page.Request.QueryString["binding"];

            switch (bindingType)
            {
                case "artifact":
                    // Create an artifact from the query string.
                    Saml2ArtifactType0004 httpArtifact = Saml2ArtifactType0004.CreateFromHttpArtifactQueryString(page.Request);

                    // Create an artifact resolve request.
                    ArtifactResolve artifactResolve = new ArtifactResolve();
                    artifactResolve.Issuer = new Issuer(GetAbsoluteUrl(page, "~/"));
                    artifactResolve.Artifact = new Artifact(httpArtifact.ToString());

                    // Send the artifact resolve request and create an artifact response from the received XML.
                    ArtifactResponse artifactResponse = ArtifactResponse.SendSamlMessageReceiveAftifactResponse(Global.ArtifactServiceUrl, artifactResolve);

                    // Get the SAML Response from the artifact response.
                    samlResponse = new ComponentPro.Saml2.Response(artifactResponse.Message);
                    relayState = httpArtifact.RelayState;
                    break;

                case "post":
                    // Create a SAML response from the form data.
                    samlResponse = ComponentPro.Saml2.Response.Create(page.Request);
                    relayState = samlResponse.RelayState;
                    break;                

                default:
                    throw new ApplicationException("Unknown binding type");
            }

            // Is the SAML response signed?
            if (samlResponse.IsSigned())
            {
                // Get the previously loaded certificate.
                X509Certificate2 x509Certificate = (X509Certificate2)page.Application[Global.IdPCertKey];

                // Validate the certificate.
                if (!samlResponse.Validate(x509Certificate))
                {
                    throw new ApplicationException("The SAML response signature failed to verify.");
                }
            }
        }

        /// <summary>
        /// Processes a successful SAML response and redirect to the requested URL.
        /// </summary>
        /// <param name="page">The page object.</param>
        /// <param name="samlResponse">The SAML response object.</param>
        /// <param name="relayState">The relay state.</param>
        public static void SamlSuccessRedirect(Page page, ComponentPro.Saml2.Response samlResponse, string relayState)
        {
            // Get the previously loaded certificate.
            X509Certificate2 x509Certificate = (X509Certificate2)page.Application[Global.SpCertKey];

            Assertion samlAssertion;

            // Check assertions.
            if (samlResponse.GetAssertions().Count > 0)
            {
                // Extract the first assertion.
                samlAssertion = samlResponse.GetAssertions()[0];
            }
            else if (samlResponse.GetEncryptedAssertions().Count > 0)
            {
                // Extract the first assertion.
                samlAssertion = samlResponse.GetEncryptedAssertions()[0].Decrypt(x509Certificate.PrivateKey, null);
            }
            else
            {
                throw new ApplicationException("No assertions in response");
            }

            string userName;

            // Get the subject name identifier.
            if (samlAssertion.Subject.NameId != null)
            {
                userName = samlAssertion.Subject.NameId.NameIdentifier;
            }
            else if (samlAssertion.Subject.EncryptedId != null)
            {
                NameId nameId = samlAssertion.Subject.EncryptedId.Decrypt(x509Certificate.PrivateKey, null);
                userName = nameId.NameIdentifier;
            }
            else
            {
                throw new ApplicationException("No name in subject");
            }

            // Get the originally requested resource URL from the relay state.
            string resourceUrl = (string)SamlSettings.CacheProvider.Remove(relayState);
            if (resourceUrl == null)
            {
                throw new ApplicationException("Invalid relay state");
            }

            // Create a login context for the asserted identity.
            FormsAuthentication.SetAuthCookie(userName, false);

            // Redirect to the originally requested resource URL.
            page.Response.Redirect(resourceUrl, false);
        }

        /// <summary>
        /// Processes an error SAML response and redirect to the requested URL.
        /// </summary>
        /// <param name="page">The page object.</param>
        /// <param name="samlResponse">The SAML response object.</param>
        /// <param name="relayState">The relay state.</param>
        public static void SamlErrorRedirect(Page page, ComponentPro.Saml2.Response samlResponse)
        {
            string errorMessage = null;

            if (samlResponse.Status.StatusMessage != null)
            {
                errorMessage = samlResponse.Status.StatusMessage.Message;
            }

            string redirectUrl = String.Format("~/UserLogin.aspx?error={0}", HttpUtility.UrlEncode(errorMessage));

            page.Response.Redirect(redirectUrl, false);
        }

        /// <summary>
        /// Gets the authentication request.
        /// </summary>
        /// <param name="page">The page object.</param>
        /// <returns>The authentication request object.</returns>
        public static AuthnRequest GetAuthnRequest(Page page)
        {
            // Create the authentication request.
            AuthnRequest authnRequest = new AuthnRequest();
            authnRequest.Destination = Global.SingleSignOnServiceURL;
            authnRequest.Issuer = new Issuer(GetAbsoluteUrl(page, "~/"));
            authnRequest.ForceAuthn = false;
            authnRequest.NameIdPolicy = new NameIdPolicy(null, null, true);

            if (Global.SingleSignOnServiceBinding != SamlBinding.HttpRedirect)
            {
                // Sign the authentication request if the SSO service binding is not HTTP Redirect.
                // Get the certificate.
                X509Certificate2 x509Certificate = (X509Certificate2)page.Application[Global.SpCertKey];

                // Sign the SAML request.
                authnRequest.Sign(x509Certificate);
            }

            return authnRequest;
        }

        /// <summary>
        /// Gets absolute URL.
        /// </summary>
        /// <param name="page">The page object.</param>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <returns>The absolute URL.</returns>
        public static string GetAbsoluteUrl(Page page, string relativeUrl)
        {
            return new Uri(page.Request.Url, page.ResolveUrl(relativeUrl)).ToString();
        }
    }
}