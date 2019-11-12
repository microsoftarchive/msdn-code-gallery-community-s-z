using System;
using System.Web.UI;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using ComponentPro.Saml;
using ComponentPro.Saml.Binding;
using ComponentPro.Saml2;
using ComponentPro.Saml2.Binding;

namespace SamlShibboleth.IdentityProvider
{
    public class Util
    {
        public const string RedirectBinding = "redirect";
        public const string PostBinding = "post";
        public const string ArtifactBinding = "artifact";

        /// <summary>
        /// The SP to IdP binding type query string variable.
        /// </summary>
        private const string SP2IdPBindingTypeVar = "binding";

        /// <summary>
        /// Processes the authentication request.
        /// </summary>
        /// <param name="authnRequest">The AuthnRequest object.</param>
        /// <param name="relayState">The relayState string.</param>
        public static void ProcessAuthnRequest(Page page, out AuthnRequest authnRequest, out string relayState)
        {
            // Use a single endpoint and use a query string parameter to determine the Service Provider to Identity Provider binding type.
            string bindingType = page.Request.QueryString[SP2IdPBindingTypeVar];

            // Get the previously loaded certificate.
            X509Certificate2 cert = (X509Certificate2)page.Application[Global.SPCertKey];

            switch (bindingType)
            {
                case RedirectBinding:
                    authnRequest = AuthnRequest.Create(page.Request.RawUrl, cert.PublicKey.Key);
                    relayState = authnRequest.RelayState;
                    break;

                case PostBinding:
                    authnRequest = AuthnRequest.CreateFromHttpPost(page.Request);
                    relayState = authnRequest.RelayState;
                    break;

                case ArtifactBinding:
                    Saml2ArtifactType0004 httpArtifact = Saml2ArtifactType0004.CreateFromHttpArtifactHttpForm(page.Request);

                    // Create an artifact resolve request.
                    ArtifactResolve artifactResolve = new ArtifactResolve();
                    artifactResolve.Issuer = new Issuer(new Uri(page.Request.Url, page.ResolveUrl("~/")).ToString());
                    artifactResolve.Artifact = new Artifact(httpArtifact.ToString());

                    // Send the SAML Artifact Resolve Request and parse the received response.
                    ArtifactResponse artifactResponse = ArtifactResponse.SendSamlMessageReceiveAftifactResponse(Global.ArtifactResolutionUrl, artifactResolve);

                    // Extract the authentication request from the received artifact response.
                    authnRequest = new AuthnRequest(artifactResponse.Message);
                    relayState = httpArtifact.RelayState;
                    break;

                default:
                    throw new ApplicationException("Invalid binding type");
            }

            if (authnRequest.IsSigned())
            {
                if (!authnRequest.Validate(cert))
                {
                    throw new ApplicationException("The authentication request signature failed to verify.");
                }
            }
        }

        /// <summary>
        /// Gets an absolute URL from an application relative URL.
        /// </summary>
        private static string GetAbsoluteUrl(Page page, string relativeUrl)
        {
            return new Uri(page.Request.Url, page.ResolveUrl(relativeUrl)).ToString();
        }

        /// <summary>
        /// Builds the SAML response.
        /// </summary>
        /// <param name="authnRequest">The AuthnRequest object.</param>
        /// <returns>A SAML Response object.</returns>
        public static ComponentPro.Saml2.Response BuildResponse(Page page, AuthnRequest authnRequest)
        {
            ComponentPro.Saml2.Response samlResponse = new ComponentPro.Saml2.Response();
            samlResponse.Destination = Global.AssertionServiceUrl;
            Issuer issuer = new Issuer(GetAbsoluteUrl(page, "~/"));
            samlResponse.Issuer = issuer;

            if (page.User.Identity.IsAuthenticated)
            {
                samlResponse.Status = new Status(SamlPrimaryStatusCode.Success, null);

                Assertion samlAssertion = new Assertion();
                samlAssertion.Issuer = issuer;

                Subject subject = new Subject(new NameId(page.User.Identity.Name));
                SubjectConfirmation subjectConfirmation = new SubjectConfirmation(SamlSubjectConfirmationMethod.Bearer);
                SubjectConfirmationData subjectConfirmationData = new SubjectConfirmationData();
                subjectConfirmationData.InResponseTo = authnRequest.Id;
                subjectConfirmationData.Recipient = Global.AssertionServiceUrl;
                subjectConfirmation.SubjectConfirmationData = subjectConfirmationData;
                subject.SubjectConfirmations.Add(subjectConfirmation);
                samlAssertion.Subject = subject;

                AuthnStatement authnStatement = new AuthnStatement();
                authnStatement.AuthnContext = new AuthnContext();
                authnStatement.AuthnContext.AuthnContextClassRef = new AuthnContextClassRef(SamlAuthenticateContext.Password);
                samlAssertion.Statements.Add(authnStatement);

                samlResponse.Assertions.Add(samlAssertion);
            }
            else
            {
                samlResponse.Status = new Status(SamlPrimaryStatusCode.Responder, SamlSecondaryStatusCode.AuthnFailed, "The user is not authenticated at the identity provider");
            }

            return samlResponse;
        }

        /// <summary>
        /// Sends the SAML response to the Service Provider.
        /// </summary>
        /// <param name="samlResponse">The SAML response object.</param>
        /// <param name="relayState">The relay state.</param>
        public static void SendResponse(Page page, ComponentPro.Saml2.Response samlResponse, string relayState)
        {
            // Sign the SAML response.
            X509Certificate2 x509Certificate = (X509Certificate2)page.Application[Global.IdPCertKey];
            samlResponse.Sign(x509Certificate);

            switch (Global.AssertionServiceSamlBinding)
            {
                case SamlBinding.HttpPost:
                    // Send the SAML Response object.
                    samlResponse.SendPostBindingForm(page.Response.OutputStream, Global.AssertionServiceUrl, relayState);
                    break;

                case SamlBinding.HttpArtifact:
                    // Create the artifact.
                    string identificationUrl = GetAbsoluteUrl(page, "~/");
                    Saml2ArtifactType0004 httpArtifact = new Saml2ArtifactType0004(SamlArtifact.GetSourceId(identificationUrl), SamlArtifact.GetHandle());

                    // Convert the authentication request to XML and save to the application Cache.
                    SamlSettings.CacheProvider.Insert(httpArtifact.ToString(), samlResponse.GetXml(), new TimeSpan(1, 0, 0));

                    // Send the artifact with POST form.
                    httpArtifact.SendPostForm(page.Response.OutputStream, Global.AssertionServiceUrl, relayState);
                    break;

                default:
                    throw new ApplicationException("Invalid assertion consumer service binding.");
            }
        }
    }
}