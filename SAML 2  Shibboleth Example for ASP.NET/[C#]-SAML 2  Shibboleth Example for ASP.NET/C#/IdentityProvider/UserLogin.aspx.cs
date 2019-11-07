using System;
using System.Web.Security;

namespace SamlShibboleth.IdentityProvider
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Form.DefaultFocus = txtPassword.ClientID;
            Form.DefaultButton = btnLogin.UniqueID;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(txtUserName.Text, txtPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
            }
            else
            {
                lblErrorMessage.Text = "The user name and password should be \"iuser\" and \"password\".";
            }
        }
    }
}