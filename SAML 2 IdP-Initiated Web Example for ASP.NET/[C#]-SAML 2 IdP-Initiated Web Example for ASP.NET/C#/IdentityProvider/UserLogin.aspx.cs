using System;
using System.Web.Security;

namespace SamlIdPInitiated.IdentityProvider
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set default focus.
            Form.DefaultFocus = txtPassword.ClientID;
            Form.DefaultButton = btnLogin.UniqueID;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Authenticate the user.
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