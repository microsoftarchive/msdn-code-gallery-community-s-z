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
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for InsertingEmptyPoints.
	/// </summary>
	public partial class InsertingEmptyPoints : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if ( this.ViewState["Data"] == null )
			{
				// Populate series data
				double[]	yValues = {23, 56, 67, 98, 45, 67, 23, 29, 87, 65, 49, 77, 56, 34, 76};
				DateTime	currentDate = DateTime.Now.Date;
				Random		random = new Random();
				for(int pointIndex = 0; pointIndex < 15; pointIndex++)
				{
					Chart1.Series["Series1"].Points.AddXY(currentDate, yValues[pointIndex]);
					currentDate = currentDate.AddDays(random.Next(1, 5));
				}
				this.ViewState["Data"] = GetSeriesValues();
			}
			else
			{
				Chart1.Series["Series1"].Points.DataBind( ((DataSet)this.ViewState["Data"]).Tables[0].Rows, "X", "Y", String.Empty);
			}

			Chart1.Series["Series1"]["EmptyPointValue"] = EmptyValueList.SelectedItem.Value;
			Chart1.Series["Series1"].EmptyPointStyle.MarkerSize = 7;
			Chart1.Series["Series1"].EmptyPointStyle.MarkerStyle = MarkerStyle.Diamond;

			// Check point existance for every day
			if(EmptyPointIntervalList.SelectedItem.Text == "Every Day")
			{
				Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Days, "Series1");
			}

			// Check point existance for every 12 hours
			else if(EmptyPointIntervalList.SelectedItem.Text == "Every 12 Hours")
			{
				Chart1.Series["Series1"].EmptyPointStyle.MarkerSize = 3;
				Chart1.DataManipulator.InsertEmptyPoints(12, IntervalType.Hours, "Series1");
			}

			// Check point existance for every week day
			else if(EmptyPointIntervalList.SelectedItem.Text == "Every Week Day")
			{
				Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Weeks, 1, IntervalType.Days, "Series1");
				Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Weeks, 2, IntervalType.Days, "Series1");
				Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Weeks, 3, IntervalType.Days, "Series1");
				Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Weeks, 4, IntervalType.Days, "Series1");
				Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Weeks, 5, IntervalType.Days, "Series1");
			}

			// Check point existance for every Monday
			else if(EmptyPointIntervalList.SelectedItem.Text == "Every Monday")
			{
				Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Weeks, 1, IntervalType.Days, "Series1");
			}

			// Use point index instead of the X value
			if(ShowAsIndexedList.SelectedItem.Text == "True")
			{
				Chart1.Series["Series1"].IsXValueIndexed = true;
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

		/// <summary>
		/// Generates a DataSet from series
		/// </summary>
		/// <returns>Generated DataSet</returns>
		private DataSet GetSeriesValues()
		{

			Series ser = this.Chart1.Series["Series1"];

			DataSet	dataSet = new DataSet();
			DataTable seriesTable = new DataTable(ser.Name);
			
			seriesTable.Columns.Add( new DataColumn("X", typeof(DateTime)));
			seriesTable.Columns.Add( new DataColumn("Y", typeof(double)));

			for( int count = 0; count < ser.Points.Count; count++)
			{
				DataPoint p = ser.Points[count];
				seriesTable.Rows.Add( new object[] { DateTime.FromOADate(p.XValue), p.YValues[0] });
			}
			
			dataSet.Tables.Add( seriesTable );
			return dataSet;
		}

	}
}
