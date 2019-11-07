using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Controls_UserFriends : System.Web.UI.UserControl
{
    DataBaseClass dbClass = new DataBaseClass();
    public DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetUserFriends(int.Parse(Request.QueryString["Id"].ToString()));
        }
    }

    public void GetUserFriends(int Id)
    {
        string getFriendQuery = "Select * FROM [User] where Id IN (SELECT MyId as Id FROM Friends WHERE FriendId='" + Id + "' AND FriendStatus=1 UNION SELECT FriendId as Id FROM Friends WHERE MyId='" + Id + "' AND FriendStatus=1) ";
        dt = dbClass.ConnectDataBaseReturnDT(getFriendQuery);
        if (dt.Rows.Count > 0)
        {
            FreindList.DataSource = dt;
            FreindList.DataBind();
        }
    }

    public string getHREF(object sURL)
    {
        DataRowView dRView = (DataRowView)sURL;
        string Id = dRView["Id"].ToString();
        return ResolveUrl("~/UserDetails.aspx?Id=" + Id);
    }

    public string getSRC(object imgSRC)
    {
        DataRowView dRView = (DataRowView)imgSRC;
        string ImageName = dRView["ImageName"].ToString();
        if (ImageName == "NoImage")
        {
            return ResolveUrl(@"~/UserImage/missing.jpg");
        }
        else
        {
            return ResolveUrl("~/UserImage/" + dRView["ImageName"].ToString());
        }
    }
}
