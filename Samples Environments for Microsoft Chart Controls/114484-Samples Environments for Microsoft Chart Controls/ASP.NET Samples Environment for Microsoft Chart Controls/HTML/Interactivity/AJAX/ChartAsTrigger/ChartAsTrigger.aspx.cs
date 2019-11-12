using System;
using System.Data.OleDb;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for ImageMapCustomTooltip.
	/// </summary>
	public partial class ChartAsTrigger : System.Web.UI.Page
	{

        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.Chart1.Series[0].PostBackValue = "#AXISLABEL";
            this.Chart1.Series[0].ToolTip = "#AXISLABEL Region: #VAL{C}"; 
        }



        protected void Chart1_Click(object sender, ImageMapEventArgs e)
        {
            this.DetailSource.SelectParameters["RegionName"].DefaultValue = e.PostBackValue;
            this.GridView.Caption = String.Format("{0} Region", e.PostBackValue);
        }
    }
}
