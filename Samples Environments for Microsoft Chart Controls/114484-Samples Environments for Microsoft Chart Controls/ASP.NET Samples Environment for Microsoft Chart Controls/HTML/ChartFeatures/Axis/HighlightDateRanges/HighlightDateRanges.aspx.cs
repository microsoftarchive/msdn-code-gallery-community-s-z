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
	public partial class HighlightDateRanges : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate chart with random sales data
			Random		random = new Random();
			DateTime	xTime = DateTime.Today;
			for(int pointIndex = 0; pointIndex < 21; pointIndex++)
			{
				// Simulate lower sales on the weekends	
				double	yValue = random.Next(600, 950);
				if(xTime.DayOfWeek == DayOfWeek.Sunday || xTime.DayOfWeek == DayOfWeek.Saturday)
				{
					yValue = random.Next(100, 400);
				}
				Chart1.Series["Default"].Points.AddXY(xTime, yValue);
				xTime = xTime.AddDays(1);
			}

			double offset = -1.5;
			double width = 2;

			if(HighlightValuesList.SelectedItem.Text == "Weekends")
			{
				offset = -1.5;
				width = 2;
			}
			else if(HighlightValuesList.SelectedItem.Text == "Weekdays")
			{
				offset = 0.5;
				width = 5;
			}
			else if(HighlightValuesList.SelectedItem.Text == "Mondays")
			{
				offset = 0.5;
				width = 1;
			}
			else if(HighlightValuesList.SelectedItem.Text == "Wednesdays")
			{
				offset = 2.5;
				width = 1;
			}
			else if(HighlightValuesList.SelectedItem.Text == "Fridays")
			{
				offset = 4.5;
				width = 1;
			}
			else if(HighlightValuesList.SelectedItem.Text == "Mondays and Fridays")
			{
				// Create a re-occurring strip line for the monday
				StripLine strip = new StripLine();
				strip.BackColor = Color.FromArgb(120, Color.Gray);
				strip.IntervalOffset = 0.5;
				strip.IntervalOffsetType = DateTimeIntervalType.Days; 
				strip.Interval = 1;
				strip.IntervalType = DateTimeIntervalType.Weeks; 
				strip.StripWidth = 1;
				strip.StripWidthType =  DateTimeIntervalType.Days; 
				Chart1.ChartAreas["ChartArea1"].AxisX.StripLines.Add(strip);

				offset = 4.5;
				width = 1;
			}


			// Create a re-occurring strip line for the selected range or 
			// just the firday if monday and friday is the selection
			StripLine stripLine = new StripLine();
			stripLine.BackColor = Color.FromArgb(120, Color.Gray);
			stripLine.IntervalOffset = offset;
			stripLine.IntervalOffsetType = DateTimeIntervalType.Days; 
			stripLine.Interval = 1;
			stripLine.IntervalType = DateTimeIntervalType.Weeks; 
			stripLine.StripWidth = width;
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
