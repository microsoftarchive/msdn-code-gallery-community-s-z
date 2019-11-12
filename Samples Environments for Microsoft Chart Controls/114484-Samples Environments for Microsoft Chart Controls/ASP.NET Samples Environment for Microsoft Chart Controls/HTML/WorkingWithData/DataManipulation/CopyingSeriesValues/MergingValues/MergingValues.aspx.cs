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
	/// Summary description for MergingValues.
	/// </summary>
	public partial class MergingValues : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Prepare data base connection and query strings
			string fileNameString = this.MapPath(".");
			fileNameString += "..\\..\\..\\..\\..\\data\\chartdata.mdb";
			string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileNameString;
			string mySelectQuery="SELECT * FROM STOCKDATA WHERE SymbolName = 'ABC' ORDER BY Date";

			// Open data base connection
			OleDbConnection myConnection = new OleDbConnection(myConnectionString);
			OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);
			myCommand.Connection.Open();
			
			// Fill data set object
			OleDbDataAdapter custDA = new OleDbDataAdapter();
			custDA.SelectCommand = myCommand;
			DataSet custDS = new DataSet();
			custDA.Fill(custDS, "Customers");
			myCommand.Connection.Close();

			// Initializes a new instance of the DataView class
			DataView dataView = new DataView(custDS.Tables[0]);	
		
			// Data bind to the reader
			Chart1.Series["High"].Points.DataBindXY(dataView, "Date", dataView, "High");
			Chart1.Series["Low"].Points.DataBindXY(dataView, "Date", dataView, "Low");
			Chart1.Series["Open"].Points.DataBindXY(dataView, "Date", dataView, "Open");
			Chart1.Series["Close"].Points.DataBindXY(dataView, "Date", dataView, "Close");

			// Remove all data points before 10/1/2001
			DateTime date = new DateTime(2001, 10, 1, 0, 0, 0);
			Chart1.DataManipulator.Filter(CompareMethod.LessThan, date.ToOADate(), "High", "High", "X");
			Chart1.DataManipulator.Filter(CompareMethod.LessThan, date.ToOADate(), "Low", "Low", "X");
			Chart1.DataManipulator.Filter(CompareMethod.LessThan, date.ToOADate(), "Open", "Open", "X");
			Chart1.DataManipulator.Filter(CompareMethod.LessThan, date.ToOADate(), "Close", "Close", "X");
				
			// Group data by week
			Chart1.DataManipulator.Group("AVE", 1, IntervalType.Weeks, "High");
			Chart1.DataManipulator.Group("AVE", 1, IntervalType.Weeks, "Low");
			Chart1.DataManipulator.Group("AVE", 1, IntervalType.Weeks, "Open");
			Chart1.DataManipulator.Group("AVE", 1, IntervalType.Weeks, "Close");

			// Show/Hide series
			Chart1.Series["High"].Enabled = !ShowAsStockChart.Checked;
			Chart1.Series["Low"].Enabled = !ShowAsStockChart.Checked;
			Chart1.Series["Open"].Enabled = !ShowAsStockChart.Checked;
			Chart1.Series["Close"].Enabled = !ShowAsStockChart.Checked;

			// Show data as stock chart
			if(ShowAsStockChart.Checked)
			{
				// Merge data from 4 different series in to one with 4 Y values
				Chart1.DataManipulator.CopySeriesValues("High:Y,Low:Y,Open:Y,Close:Y", "Stock:Y1,Stock:Y2,Stock:Y3,Stock:Y4");

				// Set stock series attributes
				Chart1.Series["Stock"].ChartType = SeriesChartType.Stock;
				Chart1.Series["Stock"].BorderWidth = 1;
				Chart1.Series["Stock"].ShadowOffset = 1;
			    Chart1.Series["Stock"].Color = Color.Navy;
			}
			DateTime max = DateTime.FromOADate(Chart1.Series["High"].Points[Chart1.Series["High"].Points.Count-1].XValue);
			max = new DateTime(max.Year, max.Month+1, 1);	
			Chart1.ChartAreas["ChartArea1"].AxisX.Maximum = max.ToOADate();
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
