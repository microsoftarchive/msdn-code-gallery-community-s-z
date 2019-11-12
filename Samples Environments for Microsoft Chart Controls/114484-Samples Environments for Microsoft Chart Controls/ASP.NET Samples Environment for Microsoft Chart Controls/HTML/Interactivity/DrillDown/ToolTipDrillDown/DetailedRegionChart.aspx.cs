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
	/// Summary description for CountryChart.
	/// </summary>
	public partial class DetailedRegionChart : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string region = "";
			if(this.Page.Request["region"] != null)
			{
				region = (string)this.Page.Request["region"];  
				Chart1.Titles[0].Text = region + " Region Sales";
			}

			// load the chart with values

			// resolve the address to the Access database
			string fileNameString = this.MapPath(".");
			fileNameString += "..\\..\\..\\..\\data\\chartdata.mdb";

			// initialize a connection string	
			string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileNameString;
			
			// define the database query	
			string mySelectQuery;
			mySelectQuery = "SELECT REPS_SALES.Name, REPS_SALES.Sales ";
			mySelectQuery +="FROM REGIONS INNER JOIN REPS_SALES ON REGIONS.RegionID = REPS_SALES.RegionID ";
			mySelectQuery +="WHERE (((REGIONS.RegionName)='"+region+"'));";

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
			Chart1.Series["Sales"].Points.DataBindXY(myReader, "Name", myReader, "Sales");

			// close the reader and the connection
			myReader.Close();
			myConnection.Close();   

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
	}
}
