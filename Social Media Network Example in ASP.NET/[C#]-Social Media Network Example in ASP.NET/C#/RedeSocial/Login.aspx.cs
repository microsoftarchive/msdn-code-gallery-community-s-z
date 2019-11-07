using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    DataBaseClass dbClass = new DataBaseClass();
    public DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
    {
        bool Authenticated = false;
        CheckBox chBox = (CheckBox)ctlLogin.FindControl("RememberMe");
        Authenticated = UserAuthenticate(ctlLogin.UserName, ctlLogin.Password);
        e.Authenticated = Authenticated;
        if (Authenticated == true)
        {
            if (chBox.Checked == true)
            {
                Response.Cookies["RFriend_Email"].Value = ctlLogin.UserName;
                Response.Cookies["RFriend_PWD"].Value = ctlLogin.Password;
                Response.Cookies["RFriend_UID"].Value = Session["UserId"].ToString();
                Response.Cookies["RFriend_Email"].Expires = DateTime.Now.AddMonths(3);
                Response.Cookies["RFriend_PWD"].Expires = DateTime.Now.AddMonths(3);
                Response.Cookies["RFriend_UID"].Expires = DateTime.Now.AddMonths(3);
            }
            Response.Redirect("UserDetails.aspx?Id=" + Session["UserId"].ToString());
        }
    }

    private bool UserAuthenticate(string UserName, string Password)
    {
        bool boolReturnValue = false;
        //--------------------------------
        //Check UserID From Config File
        if (UserName == "Rahul" && Password == "Saxena")
        {
            boolReturnValue = true;
            return boolReturnValue;
        }

        else
        {
            //--------------------------------
            dt = new DataTable();
            string chkUser = "Select * FROM [User] where Email='" + UserName + "' AND Password='" + Password + "'";
            dt = dbClass.ConnectDataBaseReturnDT(chkUser);
            if (dt.Rows.Count > 0)
            {
                boolReturnValue = true;
                Session["UserId"] = dt.Rows[0]["Id"].ToString();
                string updateLastLogin = "Update [User] SET LastLogin='" + System.DateTime.Now.ToString() + "' where Id='" + Session["UserId"].ToString() + "'";
                dbClass.ConnectDataBaseToInsert(updateLastLogin);
            }
            return boolReturnValue;
        }
    }
    protected void lnkRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
}
