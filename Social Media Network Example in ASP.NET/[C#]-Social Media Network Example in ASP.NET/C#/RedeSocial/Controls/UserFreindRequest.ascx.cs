using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;

public partial class Controls_UserFreindRequest : System.Web.UI.UserControl
{
    DataBaseClass dbClass = new DataBaseClass();
    public DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetUserFriendsRequest(int.Parse(Request.QueryString["Id"].ToString()));
        }
    }

    public void GetUserFriendsRequest(int Id)
    {
        string getFriendRequestQuery = "Select * FROM [User] where Id IN (SELECT MyId as Id FROM Friends WHERE FriendId='" + Id + "' AND FriendStatus=0) ";
        dt = dbClass.ConnectDataBaseReturnDT(getFriendRequestQuery);
        if (dt.Rows.Count > 0)
        {
            FreindRequestList.DataSource = dt;
            FreindRequestList.DataBind();
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
    protected void FreindRequestList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (!object.Equals(Session["UserId"], null))
        {
            if (e.CommandName == "Accept")
            {
                string SenderFriendId = ((HtmlInputHidden)e.Item.FindControl("hiddenId")).Value;
                string MyID = Session["UserId"].ToString();
                string AcceptFriendQuery = "Update Friends set FriendStatus=1 where MyId='" + SenderFriendId + "' AND FriendId='" + MyID + "'";
                dbClass.ConnectDataBaseToInsert(AcceptFriendQuery);
                Response.Redirect("UserDetails.aspx?Id=" + Request.QueryString["Id"].ToString());
            }
            if (e.CommandName == "Deny")
            {
                string SenderFriendId = ((HtmlInputHidden)e.Item.FindControl("hiddenId")).Value;
                string MyID = Session["UserId"].ToString();
                string AcceptFriendQuery = "Update Friends set FriendStatus=2 where MyId='" + SenderFriendId + "' AND FriendId='" + MyID + "'";
                dbClass.ConnectDataBaseToInsert(AcceptFriendQuery);
                Response.Redirect("UserDetails.aspx?Id=" + Request.QueryString["Id"].ToString());
            }
        }
    }
}
