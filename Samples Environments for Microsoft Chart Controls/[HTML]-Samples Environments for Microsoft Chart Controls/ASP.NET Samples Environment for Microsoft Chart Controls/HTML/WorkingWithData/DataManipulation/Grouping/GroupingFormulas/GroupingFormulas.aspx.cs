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
	/// Summary description for GroupingFormulas.
	/// </summary>
	public partial class GroupingFormulas : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			PopulateData();
		}

		private void PopulateData()
		{
			// Prepare data base connection and query strings
			string fileNameString = this.MapPath(".");
			fileNameString += "..\\..\\..\\..\\..\\data\\chartdata.mdb";
			string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileNameString;
			string mySelectQuery="SELECT * FROM DETAILEDSALES ORDER BY SaleDate";

			// Open data base connection
			OleDbConnection myConnection = new OleDbConnection(myConnectionString);
			OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);
			myCommand.Connection.Open();
			
			// Create a database reader	
			OleDbDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			
			// Data bind to the reader
			Chart1.Series["Sales"].Points.DataBindXY(myReader, "SaleDate", myReader, "Net");
			
			// close the reader and the connection
			myReader.Close();
			myConnection.Close();   

			// Group series data points by interval. Different formulas are used for each Y value:

			string formula = GroupingFormulaList.SelectedItem.Value + 
					", X:" + GroupingXFormulaList.SelectedItem.Value;

			if(GroupingTypeList.SelectedItem.Text == "Week")
				Chart1.DataManipulator.Group(formula, 1, IntervalType.Weeks, "Sales", "Grouped Sales");
			else if(GroupingTypeList.SelectedItem.Text == "2 Weeks")
				Chart1.DataManipulator.Group(formula, 2, IntervalType.Weeks, "Sales", "Grouped Sales");
			else if(GroupingTypeList.SelectedItem.Text == "Month")
				Chart1.DataManipulator.Group(formula, 1, IntervalType.Months, "Sales", "Grouped Sales");

			// Change chart type and appearance attributes of the grouped series
			Chart1.Series["Grouped Sales"].ShadowOffset = 0;
			Chart1.Series["Grouped Sales"].BorderWidth = 1;

			if(GroupingFormulaList.SelectedItem.Value == "HiLoOpCl")
			{
				Chart1.Series["Grouped Sales"].ChartType = SeriesChartType.Stock;
				Chart1.Series["Grouped Sales"].Color = Color.FromArgb(224,64,10);
				Chart1.Series["Grouped Sales"].BorderWidth = 2;
				Chart1.Series["Grouped Sales"].ShadowOffset = 1;
			}
			else if(GroupingFormulaList.SelectedItem.Value == "HiLo")
			{
				Chart1.Series["Grouped Sales"].ChartType = SeriesChartType.SplineRange;
				Chart1.Series["Grouped Sales"].Color = Color.FromArgb(128, 252,180,65);
			}
			else
			{
				Chart1.Series["Grouped Sales"].ChartType = SeriesChartType.Column;
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

		protected void List_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PopulateData();
		}
	}
}
