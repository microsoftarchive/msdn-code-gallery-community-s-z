using System;
using System.Web;
using System.Web.Security;

namespace SamlIdPInitiated.IdentityProvider
{
    public partial class Default : System.Web.UI.Page
    {
        private static readonly string ServiceProviderUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["ServiceProviderUrl"];
        protected string NavigateUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Set the navigate URL to the SSO service page. "spUrl" parameter is the target URL of the Service Provider.
            NavigateUrl = Page.ResolveUrl(string.Format("~/Service.aspx?spUrl={0}", HttpUtility.UrlEncode(ServiceProviderUrl)));
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Sign out
            FormsAuthentication.SignOut();
            // Redirect to the login page.
            Response.Redirect("UserLogin.aspx");
        }
    }
}