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
	/// Summary description for TimeScale.
	/// </summary>
	public partial class TimeScale : System.Web.UI.Page
	{
	
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
			this.Load += new System.EventHandler(this.TimeScale_Load);

		}
		#endregion

		protected void RandomData_Click(object sender, System.EventArgs e)
		{
			FillData();
		}
		
		private void FillData()
		{
			// Populate series data
			Random	random = new Random();
			DateTime date = DateTime.Now.Date;
			Chart1.Series["Series1"].Points.Clear();
			for(int pointIndex = 0; pointIndex < 8; pointIndex++)
			{
				Chart1.Series["Series1"].Points.AddXY(date, random.Next(15, 95));
				date = date.AddDays(random.Next(1, 5));
			}

			
			// databind series to grid
			this.DataGrid1.DataSource = GetSeriesValues();
			this.DataGrid1.DataBind();
		}

		protected void TimeScale_Load(object sender, System.EventArgs e)
		{

			if ( !this.IsPostBack )
			{
				FillData();
			}

			// Use point index instead of the X value
			if(UseIndex.Checked)
			{
				Chart1.Series["Series1"].IsXValueIndexed = true;

				// Show labels every day
				Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
                Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
                Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = 1;
			}
			else
			{
				Chart1.Series["Series1"].IsXValueIndexed = false;
                Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = Double.NaN;
                Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = Double.NaN;
                Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = Double.NaN;
			}
			// Set series tooltips
			Chart1.Series["Series1"].ToolTip = "#VALX";
		}


		/// <summary>
		/// Generates a DataSet from series
		/// </summary>
		/// <returns>Generated DataSet</returns>
		private DataSet GetSeriesValues()
		{

			Series ser = this.Chart1.Series["Series1"];

			DataSet	dataSet = new DataSet();
			DataTable seriesTable = new DataTable(ser.Name);
			
			seriesTable.Columns.Add( new DataColumn("No", typeof(int)));
			seriesTable.Columns.Add( new DataColumn("X", typeof(DateTime)));
			seriesTable.Columns.Add( new DataColumn("Y", typeof(double)));

			for( int count = 0; count < ser.Points.Count; count++)
			{
				DataPoint p = ser.Points[count];
				seriesTable.Rows.Add( new object[] { count, DateTime.FromOADate(p.XValue), p.YValues[0] });
			}
			
			dataSet.Tables.Add( seriesTable );
			return dataSet;
		}

	}
}
