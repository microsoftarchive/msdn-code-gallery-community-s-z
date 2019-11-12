using System;
using System.Web.Security;

namespace SamlShibboleth.IdentityProvider
{
    public partial class Default : System.Web.UI.Page
    {
        private static readonly string ServiceProviderUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["ServiceProviderUrl"];
        protected string NavigateUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Construct a URL to the local SSO service and specifying the target URL of the SP.
            NavigateUrl = ServiceProviderUrl;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("UserLogin.aspx");
        }
    }
}