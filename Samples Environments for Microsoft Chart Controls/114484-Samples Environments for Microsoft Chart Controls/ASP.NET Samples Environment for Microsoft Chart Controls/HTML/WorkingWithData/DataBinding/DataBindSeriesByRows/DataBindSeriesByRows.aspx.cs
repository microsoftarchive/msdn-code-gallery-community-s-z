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
	public partial class DataBindSeriesByRows : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// resolve the address to the Access database
			string fileNameString = this.MapPath(".");
			fileNameString += "..\\..\\..\\..\\data\\chartdata.mdb";

			// initialize a connection string    
			string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileNameString;
	
			// define the database query	
			string mySelectQuery="SELECT * FROM SALESCOUNTS;";

			// create a database connection object using the connection string	
			OleDbConnection myConnection = new OleDbConnection(myConnectionString);
			
			// create a database command on the connection using query	
			OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);
			
			// open the connection	
			myCommand.Connection.Open();
			
			// Initializes a new instance of the OleDbDataAdapter class
			OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();
			myDataAdapter.SelectCommand = myCommand;

			// Initializes a new instance of the DataSet class
			DataSet myDataSet = new DataSet();

			// Adds rows in the DataSet
			myDataAdapter.Fill(myDataSet, "Query");
			
			
			foreach(DataRow row in myDataSet.Tables["Query"].Rows)
			{
				// for each Row, add a new series
				string seriesName = row["SalesRep"].ToString();
				Chart1.Series.Add(seriesName);
				Chart1.Series[seriesName].ChartType = SeriesChartType.Line;
				Chart1.Series[seriesName].BorderWidth = 2;
				Chart1.Series[seriesName].ShadowOffset = 2;


				for(int colIndex = 1; colIndex < myDataSet.Tables["Query"].Columns.Count; colIndex++)
				{
					// for each column (column 1 and onward), add the value as a point
					string columnName = myDataSet.Tables["Query"].Columns[colIndex].ColumnName;
					int YVal = (int) row[columnName];

					Chart1.Series[seriesName].Points.AddXY(columnName, YVal);
				}
			}

			DataGrid.DataSource = myDataSet;
			DataGrid.DataBind();

			// Closes the connection to the data source. This is the preferred 
			// method of closing any open connection.
			myCommand.Connection.Close();

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
