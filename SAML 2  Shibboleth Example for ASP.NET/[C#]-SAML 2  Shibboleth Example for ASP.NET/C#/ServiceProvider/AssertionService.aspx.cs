using System;

namespace SamlShibboleth.ServiceProvider
{
    public partial class AssertionService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentPro.Saml2.Response samlResponse = null;
                string relayState = null;

                // Get and process the SAML response.
                Util.ProcessResponse(this, out samlResponse, out relayState);

                // If the SAML response indicates success.
                if (samlResponse.IsSuccess())
                {
                    Util.SamlSuccessRedirect(this, samlResponse, relayState);
                }
                else
                {
                    Util.SamlErrorRedirect(this, samlResponse);
                }
            }

            catch (Exception exception)
            {
                Trace.Write("ServiceProvider", "An Error occurred", exception);
            }
        }
    }
}