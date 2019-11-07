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
	/// Summary description for SeriesAlignment.
	/// </summary>
	public partial class SeriesAlignment : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate Series1 data
			Random		random = new Random();
			DateTime	dateSeries1 = DateTime.Now.Date;
			for(int pointIndex = 0; pointIndex < 5; pointIndex++)
			{
				dateSeries1 = dateSeries1.AddDays(random.Next(1, 4));
				Chart1.Series["Series1"].Points.AddXY(dateSeries1, random.Next(5, 95));
			}

			// Populate Series2 data
			DateTime	dateSeries2 = DateTime.Now.Date;
			for(int pointIndex = 0; pointIndex < 5; pointIndex++)
			{
				dateSeries2 = dateSeries2.AddDays(random.Next(1, 3));
				Chart1.Series["Series2"].Points.AddXY(dateSeries2, random.Next(5, 95));
			}

			// Copy series data
			Chart1.DataManipulator.CopySeriesValues("Series1:Y1", "Series3:Y1");
			Chart1.DataManipulator.CopySeriesValues("Series2:Y1", "Series4:Y1");

			// Align series data by grouping and inserting empty points
			// Group data by day 
			Chart1.DataManipulator.Group("AVE", 1, IntervalType.Days, "Series1, Series2", "Series3, Series4");

			// Insert Empty Points daily if point do not exsits
			Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Days, "Series3, Series4");
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
