using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for BindExcelData .
	/// </summary>
	public partial class BindExcelData : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// resolve the address to the XML document
			string fileNameString = this.MapPath(".");
			fileNameString += "..\\..\\..\\..\\data\\ExcelData.xls";

			// Create connection object by using the preceding connection string.
			string sConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + 
				fileNameString + ";Extended Properties=\"Excel 8.0;HDR=YES\"";
			OleDbConnection myConnection = new OleDbConnection( sConn );
			myConnection.Open();

			// The code to follow uses a SQL SELECT command to display the data from the worksheet.
			// Create new OleDbCommand to return data from worksheet.
			OleDbCommand myCommand = new OleDbCommand( "Select * From [data1$A1:E25]", myConnection );

			// create a database reader	
			OleDbDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			// Populate the chart with data from the Excel file. 
			Chart1.DataBindTable(myReader, "HOUR");

			// close the reader and the connection
			myReader.Close();
			myConnection.Close();

			// Set series appearance
			foreach(Series ser in Chart1.Series)
			{
				ser.ShadowOffset = 1;
				ser.BorderWidth = 3;
				ser.ChartType = SeriesChartType.Line;
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
