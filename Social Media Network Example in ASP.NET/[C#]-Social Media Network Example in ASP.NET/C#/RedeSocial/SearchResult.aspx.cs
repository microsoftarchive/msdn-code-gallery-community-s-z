using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SearchResult : System.Web.UI.Page
{
    DataBaseClass dbClass = new DataBaseClass();
    public DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetSearchResult(Request.QueryString["SearchText"].ToString());
        }
    }

    public void GetSearchResult(string searchText)
    {
        string GetSearchResult = "Select * FROM [User] where Name like '" + searchText + "%'";
        dt = dbClass.ConnectDataBaseReturnDT(GetSearchResult);
        if (dt.Rows.Count > 0)
        {
            SearchResultList.DataSource = dt;
            SearchResultList.DataBind();
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
