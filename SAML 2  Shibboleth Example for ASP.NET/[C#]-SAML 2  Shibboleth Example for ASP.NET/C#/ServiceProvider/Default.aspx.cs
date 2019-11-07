using System;
using System.Web.Security;

namespace SamlShibboleth.ServiceProvider
{
    public partial class Default : System.Web.UI.Page
    {
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("UserLogin.aspx");
        }
    }
}