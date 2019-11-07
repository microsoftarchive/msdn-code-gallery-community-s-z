using System;
using System.Xml;
using ComponentPro.Saml;
using ComponentPro.Saml2;
using ComponentPro.Saml2.Binding;

namespace SamlShibboleth.ServiceProvider
{
    public partial class ArtifactService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Get the artifact resolve request.
                ArtifactResolve artifactResolve = ArtifactResolve.Create(Request);

                // Create a new artifact.
                Saml2ArtifactType0004 httpArtifact = new Saml2ArtifactType0004(artifactResolve.Artifact.ArtifactValue);

                // Remove the artifact state from the cache.
                XmlElement samlResponseXml = (XmlElement)SamlSettings.CacheProvider.Remove(httpArtifact.ToString());
                if (samlResponseXml == null)
                {
                    throw new ApplicationException("Invalid artifact.");
                }

                // Create an artifact response containing the cached SAML message.
                ArtifactResponse artifactResponse = new ArtifactResponse();
                artifactResponse.Issuer = new Issuer(Util.GetAbsoluteUrl(this, "~/"));
                artifactResponse.Message = samlResponseXml;

                // Send the artifact response.
                artifactResponse.Send(Response);
            }

            catch (Exception exception)
            {
                Trace.Write("ServiceProvider", "An Error occurred", exception);
            }
        }
    }
}