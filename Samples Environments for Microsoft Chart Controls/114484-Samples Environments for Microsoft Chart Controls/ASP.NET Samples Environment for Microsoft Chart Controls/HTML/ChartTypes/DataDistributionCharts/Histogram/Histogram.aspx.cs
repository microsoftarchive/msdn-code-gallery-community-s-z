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
using System.Web.UI.DataVisualization.Charting.Utilities;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for Histogram.
	/// </summary>
	public partial class Histogram: System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate chart with random data
			Random rand = new Random();
			for(int index = 1; index < 70; index++) 
			{
				int maxValue = (int)Math.Pow(rand.Next(100, 1000) / 100.0 , 2.0);
				double newVal = 100 + rand.Next(0, (int)maxValue);
				Chart1.Series["RawData"].Points.AddY(newVal);
				newVal = 100 + rand.Next(-(int)maxValue, 0);
				Chart1.Series["RawData"].Points.AddY(newVal);
			}

			// Populate single axis data distribution series. Show Y value of the
			// data series as X value and set all Y values to 1.
			foreach(DataPoint dataPoint in Chart1.Series["RawData"].Points)
			{
				Chart1.Series["DataDistribution"].Points.AddXY(dataPoint.YValues[0], 1);
			}

			// Create a histogram series
			HistogramChartHelper histogramHelper = new HistogramChartHelper();
			histogramHelper.SegmentIntervalNumber = int.Parse(CollectedPercentage.SelectedItem.Text);
			histogramHelper.ShowPercentOnSecondaryYAxis = checkBoxPercent.Checked;
			// NOTE: Interval width may be specified instead of interval number
			//histogramHelper.SegmentIntervalWidth = 15;
			histogramHelper.CreateHistogram(Chart1, "RawData", "Histogram");

			// Set same X axis scale and interval in the single axis data distribution 
			// chart area as in the histogram chart area.
			Chart1.ChartAreas["ChartArea1"].AxisX.Minimum = Chart1.ChartAreas["HistogramArea"].AxisX.Minimum;
			Chart1.ChartAreas["ChartArea1"].AxisX.Maximum = Chart1.ChartAreas["HistogramArea"].AxisX.Maximum;
			Chart1.ChartAreas["ChartArea1"].AxisX.Interval = Chart1.ChartAreas["HistogramArea"].AxisX.Interval;
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
