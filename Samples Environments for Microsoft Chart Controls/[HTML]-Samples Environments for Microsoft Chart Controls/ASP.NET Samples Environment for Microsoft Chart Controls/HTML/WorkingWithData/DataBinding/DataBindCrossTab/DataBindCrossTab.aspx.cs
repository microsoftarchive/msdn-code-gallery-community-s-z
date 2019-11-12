using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data.OleDb;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for ImageMapCustom.
	/// </summary>
	public partial class DataBindCrossTable : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// resolve the address to the Access database
			string fileNameString = this.MapPath(".");
			fileNameString += "..\\..\\..\\..\\data\\chartdata.mdb";

			// initialize a connection string    
			string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileNameString;
	
			// define the database query	
			string mySelectQuery="SELECT * FROM REPSALES;";

			// create a database connection object using the connection string	
			OleDbConnection myConnection = new OleDbConnection(myConnectionString);
	
			// create a database command on the connection using query	
			OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);
	
			// open the connection	
			myCommand.Connection.Open();

			// Bind grid to the original data 
			OleDbDataAdapter custDA = new OleDbDataAdapter();
			custDA.SelectCommand = myCommand;
			DataSet custDS = new DataSet();
			custDA.Fill(custDS, "Customers");
			this.DataGrid.DataSource = custDS;
			this.DataGrid.DataBind();
	
			// create a database reader	
			OleDbDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
	
			// data bind chart to a table where all rows are grouped in series by the "Name" column
			Chart1.DataBindCrossTable(
				myReader, 
				(DropDownListGroupBy.SelectedIndex == 0) ? "Name" : "Year",
				(DropDownListGroupBy.SelectedIndex == 0) ? "Year" : "Name",
				"Sales", 
				"Label=Commissions{C}");

			// close the reader and the connection
			myReader.Close();
			myConnection.Close();

			// Set series appearance
			MarkerStyle marker = MarkerStyle.Star4;
			foreach(Series ser in Chart1.Series)
			{
				ser.ShadowOffset = 2;
				ser.BorderWidth = 3;
				ser.ChartType = SeriesChartType.Line;
				ser.MarkerSize = 12;
				ser.MarkerStyle = marker;
				ser.MarkerBorderColor = Color.FromArgb(64, 64, 64);
				ser.Font = new Font("Trebuchet MS", 8, FontStyle.Bold);
				marker++;
			}		

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
