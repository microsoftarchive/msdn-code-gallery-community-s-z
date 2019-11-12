using System;
using System.Collections.Generic;
using LDAPLibrary;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnValidate_OnClick(object sender, EventArgs e)
    {
        lblValidity.Text = LDAP.IsAuthenticated(txtUsername.Text, txtPassword.Text).ToString();
    }

    protected void btnUsers_OnClick(object sender, EventArgs e)
    {
        HashSet<User> user = LDAP.GetActiveDirectoryUsers();

        lbUsers.DataSource = user;
        lbUsers.DataBind();

    }
}
