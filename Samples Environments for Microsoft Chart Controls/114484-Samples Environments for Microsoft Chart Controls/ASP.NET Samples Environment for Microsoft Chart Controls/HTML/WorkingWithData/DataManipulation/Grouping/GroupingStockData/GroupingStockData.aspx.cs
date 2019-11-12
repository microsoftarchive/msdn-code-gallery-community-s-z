using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for GroupingDates.
	/// </summary>
	public partial class GroupingDates : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate chart series data
			if(!this.IsPostBack)
			{
				PopulateData();
			}
		}

		protected void GroupingTypeList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PopulateData();
		}

		protected void StockSymbolList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PopulateData();
		}

		private void PopulateData()
		{
			// Prepare data base connection and query strings
			string fileNameString = this.MapPath(".");
			fileNameString += "..\\..\\..\\..\\..\\data\\chartdata.mdb";
			string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileNameString;
			string mySelectQuery="SELECT * FROM STOCKDATA WHERE SymbolName = '" + StockSymbolList.SelectedItem.Text + "' ORDER BY Date";

			// Open data base connection
			OleDbConnection myConnection = new OleDbConnection(myConnectionString);
			OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);
			myCommand.Connection.Open();
			
			// Create a database reader	
			OleDbDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			
			// Data bind to the reader
			Chart1.Series["StockPrice"].Points.DataBindXY(myReader, "Date", myReader, "High,Low,Open,Close");
			
			// Group series data points by interval. Different formulas are used for each Y value:
			//   Y1 (High) - maximum of all Y1 points values in the group
			//   Y2 (Low) - minimum of all Y2 points values in the group
			//   Y3 (Open) - Y3 value of the first point in the group
			//   Y4 (Close) - Y4 value of the last point in the group
			if(GroupingTypeList.SelectedItem.Text == "Week")
				Chart1.DataManipulator.Group("Y1:MAX,Y2:MIN,Y3:FIRST,Y4:LAST", 1, IntervalType.Weeks, "StockPrice", "GroupedStockPrice");
			else if(GroupingTypeList.SelectedItem.Text == "Month")
				Chart1.DataManipulator.Group("Y1:MAX,Y2:MIN,Y3:FIRST,Y4:LAST", 1, IntervalType.Months, "StockPrice", "GroupedStockPrice");
			else if(GroupingTypeList.SelectedItem.Text == "Quarter")
				Chart1.DataManipulator.Group("Y1:MAX,Y2:MIN,Y3:FIRST,Y4:LAST", 3, IntervalType.Months, "StockPrice", "GroupedStockPrice");

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
