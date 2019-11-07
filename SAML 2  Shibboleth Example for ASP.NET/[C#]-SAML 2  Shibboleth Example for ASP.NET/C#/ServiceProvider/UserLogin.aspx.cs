using System;
using System.Security.Cryptography.X509Certificates;
using System.Web.Security;
using System.Xml;
using ComponentPro.Saml;
using ComponentPro.Saml.Binding;
using ComponentPro.Saml2;
using ComponentPro.Saml2.Binding;

namespace SamlShibboleth.ServiceProvider
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected string NavigateUrl;

        private const string errorQueryParameter = "error";

        protected void Page_Load(object sender, EventArgs e)
        {
            Form.DefaultFocus = txtPassword.ClientID;
            Form.DefaultButton = btnLogin.UniqueID;

            // Display any error message resulting from a failed login.
            lblErrorMessage.Text = !String.IsNullOrEmpty(Request.QueryString[errorQueryParameter]) ? Request.QueryString[errorQueryParameter] : String.Empty;
        }

        protected void btnIdPLogin_Click(object sender, EventArgs e)
        {
            // Get the authentication request.
            AuthnRequest authnRequest = Util.GetAuthnRequest(this);

            // Get SP Resource URL.
            string spResourceUrl = Util.GetAbsoluteUrl(this, FormsAuthentication.GetRedirectUrl("", false));
            // Create relay state.
            string relayState = Guid.NewGuid().ToString();
            // Save the SP Resource URL to the cache.
            SamlSettings.CacheProvider.Insert(relayState, spResourceUrl, new TimeSpan(1, 0, 0));

            switch (Global.SingleSignOnServiceBinding)
            {
                case SamlBinding.HttpRedirect:
                    X509Certificate2 x509Certificate = (X509Certificate2)Application[Global.SpCertKey];

                    // Send authentication request using HTTP Redirect.
                    authnRequest.Redirect(Response, Global.SingleSignOnServiceURL, relayState, x509Certificate.PrivateKey);
                    break;

                case SamlBinding.HttpPost:
                    // Send authentication request using HTTP POST form.
                    authnRequest.SendHttpPost(Response, Global.SingleSignOnServiceURL, relayState);

                    // End the response.
                    Response.End();
                    break;

                case SamlBinding.HttpArtifact:
                    // Create a new http artifact.
                    string identificationUrl = Util.GetAbsoluteUrl(this, "~/");
                    Saml2ArtifactType0004 httpArtifact = new Saml2ArtifactType0004(SamlArtifact.GetSourceId(identificationUrl), SamlArtifact.GetHandle());

                    // Save the authentication request for subsequent sending using the artifact resolution protocol.
                    SamlSettings.CacheProvider.Insert(httpArtifact.ToString(), authnRequest.GetXml(), new TimeSpan(1, 0, 0));

                    // Send the artifact using HTTP POST form.
                    httpArtifact.SendPostForm(Response.OutputStream, Global.SingleSignOnServiceURL, relayState);

                    // End the response.
                    Response.End();
                    break;

                default:
                    throw new ApplicationException("Invalid binding type");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(txtUserName.Text, txtPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
            }
            else
            {
                lblErrorMessage.Text = "The user name and password should be \"suser\" and \"password\".";
            }
        }
    }
}