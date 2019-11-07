using System;
using System.Xml;
using ComponentPro.Saml;
using ComponentPro.Saml2;
using ComponentPro.Saml2.Binding;

namespace SamlShibboleth.IdentityProvider
{
    public partial class ArtifactService : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                // Create a new Artifact Resolve from the request stream.
                ArtifactResolve artifactResolve = ArtifactResolve.Create(Request);

                // Get the ArtifactType0004.
                Saml2ArtifactType0004 httpArtifact = new Saml2ArtifactType0004(artifactResolve.Artifact.ArtifactValue);

                // Remove the saved http artifact from the cache.
                XmlElement samlResponseXml = (XmlElement)SamlSettings.CacheProvider.Remove(httpArtifact.ToString());

                if (samlResponseXml == null)
                {
                    throw new ApplicationException("Invalid artifact.");
                }

                // Create an ArtifactResponse.
                ArtifactResponse artifactResponse = new ArtifactResponse();
                Uri uri = new Uri(Request.Url, ResolveUrl("~/"));

                artifactResponse.Issuer = new Issuer(uri.ToString());
                // Add the SAML response XML to the artifact response.
                artifactResponse.Message = samlResponseXml;

                // Send the artifact response.
                artifactResponse.Send(Response);
            }

            catch (Exception exception)
            {
                Trace.Write("IdentityProvider", "An Error occurred", exception);
            }
        }
    }
}