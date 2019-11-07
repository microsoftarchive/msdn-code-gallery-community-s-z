using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!object.Equals(Request.Cookies["RFriend_Email"], null)) && (!object.Equals(Request.Cookies["RFriend_PWD"], null)) && (!object.Equals(Request.Cookies["RFriend_UID"], null)))
        {
            if ((!object.Equals(Request.Cookies["RFriend_Email"].Value, "")) && (!object.Equals(Request.Cookies["RFriend_PWD"].Value, "")) && (!object.Equals(Request.Cookies["RFriend_UID"], "")))
            {
                Session["UserEmail"] = Request.Cookies["RFriend_Email"].Value;
                Session["Password"] = Request.Cookies["RFriend_PWD"].Value;
                Session["UserId"] = Request.Cookies["RFriend_UID"].Value;
            }
            else
            {
            }
        }
        if (!object.Equals(Session["UserId"], null))
        {
            Login.Visible = false;
            Logout.Visible = true;
            MyProfile.Visible = true;
        }
        else
        {
            Login.Visible = true;
            Logout.Visible = false;
            MyProfile.Visible = false;
        }
    }
    protected void Login_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }
    protected void Logout_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Cookies["RFriend_Email"].Value = null;
        Response.Cookies["RFriend_UID"].Value = null;
        Response.Cookies["RFriend_PWD"].Value = null;
        Session.Abandon();
        System.Web.Security.FormsAuthentication.SignOut();
        Response.Redirect(ResolveUrl("~/Login.aspx"));
    }
    protected void MyProfile_Click(object sender, EventArgs e)
    {
        if (!object.Equals(Session["UserId"], null))
        {
            Response.Redirect("~/UserDetails.aspx?Id=" + Session["UserId"].ToString());
        }
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SearchResult.aspx?SearchText=" + txtSearch.Text);
    }
}
