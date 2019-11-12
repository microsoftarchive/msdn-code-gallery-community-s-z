using System;
using System.Web.Security;

namespace SamlIdPInitiated.ServiceProvider
{
    public partial class Default : System.Web.UI.Page
    {
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Signout.
            FormsAuthentication.SignOut();
            Response.Redirect("UserLogin.aspx");
        }
    }
}