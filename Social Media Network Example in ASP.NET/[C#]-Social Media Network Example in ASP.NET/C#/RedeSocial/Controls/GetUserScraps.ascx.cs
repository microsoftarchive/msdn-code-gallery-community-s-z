using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Controls_GetUserScraps : System.Web.UI.UserControl
{
    DataBaseClass dbClass = new DataBaseClass();
    public DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetUserScraps(int.Parse(Request.QueryString["Id"].ToString()));
        }
    }
    public void GetUserScraps(int Id)
    {
        string getUserScraps = "SELECT u.Id as UserId,u.Name,u.ImageName,s.FromId,s.ToId,s.Message,s.SendDate,s.ID as ScrapId FROM [User] as u, Scrap as s WHERE u.Id=s.FromId AND s.ToId='" + Request.QueryString["Id"].ToString() + "'";
        dt = dbClass.ConnectDataBaseReturnDT(getUserScraps);
        if (dt.Rows.Count > 0)
        {
            GridViewUserScraps.DataSource = dt;
            GridViewUserScraps.DataBind();
        }
    }

    public string getUserHREF(object sURL)
    {
        DataRowView dRView = (DataRowView)sURL;
        string Id = dRView["UserId"].ToString();
        return ResolveUrl("~/UserDetails.aspx?Id=" + Id);
    }

    public string getSRC(object imgSRC)
    {
        DataRowView dRView = (DataRowView)imgSRC;
        string ImageName = dRView["ImageName"].ToString();
        if (ImageName == "NoImage")
        {
            return ResolveUrl(@"~/Site_Images/image_missing.jpg");
        }
        else
        {
            return ResolveUrl("~/UserImage/" + dRView["ImageName"].ToString());
        }
    }
}
