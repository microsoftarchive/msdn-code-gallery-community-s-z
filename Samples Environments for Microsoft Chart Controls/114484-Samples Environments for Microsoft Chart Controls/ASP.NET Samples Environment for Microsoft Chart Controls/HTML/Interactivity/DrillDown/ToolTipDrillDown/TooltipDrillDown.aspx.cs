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
	public partial class TooltipDrillDown : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// load the chart with values

			// resolve the address to the Access database
			string fileNameString = this.MapPath(".");
			fileNameString += "..\\..\\..\\..\\data\\chartdata.mdb";

			// initialize a connection string	
			string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileNameString;
			
			// define the database query	
			string mySelectQuery;
			mySelectQuery = "SELECT REGIONS.RegionName, Sum(REPS_SALES.Sales) AS SumOfSales ";
			mySelectQuery +="FROM REPS_SALES INNER JOIN REGIONS ON REPS_SALES.RegionID = REGIONS.RegionID ";
			mySelectQuery +="GROUP BY REGIONS.RegionName;";

			// create a database connection object using the connection string	
			OleDbConnection myConnection = new OleDbConnection(myConnectionString);
			
			// create a database command on the connection using query	
			OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);
			
			// open the connection	
			myCommand.Connection.Open();
			
			// create a database reader	
			OleDbDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			
			// since the reader implements and IEnumerable, pass the reader directly into
			// the DataBind method with the name of the Column selected in the query	
			Chart1.Series["Sales"].Points.DataBindXY(myReader, "RegionName", myReader, "SumOfSales");

			// close the reader and the connection
			myReader.Close();
			myConnection.Close();   



			UpdateAttrib();
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion


		public void UpdateAttrib()
		{

			// Set series tooltips
			foreach(Series series in Chart1.Series)
			{
				for(int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
				{
					string toolTip = "";

					toolTip = "<img src=RegionChart.aspx?region=" + series.Points[pointIndex].AxisLabel + " />";
					series.Points[pointIndex].MapAreaAttributes = "onmouseover=\"DisplayTooltip('" + toolTip + "');\" onmouseout=\"DisplayTooltip('');\"";
					series.Points[pointIndex].Url = "DetailedRegionChart.aspx?region=" + series.Points[pointIndex].AxisLabel;
				}
			}			

		}
	}
}
