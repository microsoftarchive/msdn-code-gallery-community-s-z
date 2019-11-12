using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GoogleMaps
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable("Tabela");

                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Latitude", typeof(string));
                dt.Columns.Add("Longitude", typeof(string));
                dt.Columns.Add("Description", typeof(string));

                dt.Rows.Add("São Paulo", "-23.59872", "-46.67651", "Faculdade Insper <br /><br /> R. Quatá, 300 - Itaim Bibi <br /> São Paulo - SP");

                rptMarkers.DataSource = dt;
                rptMarkers.DataBind();
            }
        }
    }
}
