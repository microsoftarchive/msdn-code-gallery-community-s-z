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
	/// Summary description for FilterDateRange.
	/// </summary>
	public partial class FilterDateRange : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate chart with random sales data
			Random		random = new Random();
			DateTime	xTime = new DateTime(2000, 8, 1, 0, 0, 0);
			for(int pointIndex = 0; pointIndex < int.Parse(DayNumberLst.SelectedItem.Value); pointIndex++)
			{
				// Simulate lower sales on the weekends	
				double	yValue = random.Next(600, 950);
				if(xTime.DayOfWeek == DayOfWeek.Sunday || xTime.DayOfWeek == DayOfWeek.Saturday)
				{
					yValue = random.Next(100, 400);
				}
				Chart1.Series["Series Input"].Points.AddXY(xTime, yValue);
				xTime = xTime.AddDays(1);
			}

			// Show data points using point's index
			if(ShowAsIndexedList.SelectedItem.Text == "True")
			{
				Chart1.Series["Series Output"].IsXValueIndexed = true;
				Chart1.ChartAreas["FilteredData"].AxisX.Minimum = double.NaN;
				Chart1.ChartAreas["FilteredData"].AxisX.Maximum = double.NaN;
			}
			else
			{
				Chart1.DataManipulator.FilterSetEmptyPoints = true;
			}
			
			// Filter series data 
			if(FilterValuesList.SelectedItem.Value == "Weekends")
			{
				Chart1.DataManipulator.Filter(DateRangeType.DayOfWeek, "0,6", "Series Input", "Series Output");
			}
			else if(FilterValuesList.SelectedItem.Value == "Weekdays")
			{
				Chart1.DataManipulator.Filter(DateRangeType.DayOfWeek, "1-5", "Series Input", "Series Output");
			}
			else if(FilterValuesList.SelectedItem.Value == "Except 15")
			{
				Chart1.DataManipulator.Filter(DateRangeType.DayOfMonth, "1-14,16-31", "Series Input", "Series Output");
			}
			else if(FilterValuesList.SelectedItem.Value == "Except 1-15")
			{
				Chart1.DataManipulator.Filter(DateRangeType.DayOfMonth, "16-31", "Series Input", "Series Output");
			}

			// Create strip lines on the weekends
			StripLine stripLine = new StripLine();
			stripLine.BackColor = Color.FromArgb(120, Color.Gray);
			stripLine.IntervalOffset = -1.5;
			stripLine.IntervalOffsetType = DateTimeIntervalType.Days; 
			stripLine.Interval = 1;
			stripLine.IntervalType = DateTimeIntervalType.Weeks; 
			stripLine.StripWidth = 2;
			stripLine.StripWidthType =  DateTimeIntervalType.Days; 
			Chart1.ChartAreas["ChartArea1"].AxisX.StripLines.Add(stripLine);
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
