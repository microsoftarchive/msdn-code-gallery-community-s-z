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
	/// Summary description for BoxPlotChart.
	/// </summary>
	public partial class BoxPlotChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList LabelStyleList;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ExplodedPointList;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList HoleSizeList;
		protected System.Web.UI.WebControls.CheckBox checkBoxShow3D;
		protected System.Web.UI.WebControls.DropDownList AreaDrawingStyleList;
		protected System.Web.UI.WebControls.DropDownList RadarStyleList;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.DropDownList WhiskerList;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data
			double[]	yValues = {55.62, 45.54, 73.45, 9.73, 88.42, 45.9, 63.6, 85.1, 67.2, 23.6};
			Chart1.Series["DataSeries"].Points.DataBindY(yValues);

			// Specify data series name for the Box Plot
			Chart1.Series["BoxPlotSeries"]["BoxPlotSeries"] = "DataSeries";

			// Set whiskers percentile
			Chart1.Series["BoxPlotSeries"]["BoxPlotWhiskerPercentile"] = WhiskerPercentileList.SelectedItem.Value;

			// Show/Hide Average line
			Chart1.Series["BoxPlotSeries"]["BoxPlotShowAverage"] = (CheckBoxShowAverage.Checked) ? "true" : "false";

			// Show/Hide Median line
			Chart1.Series["BoxPlotSeries"]["BoxPlotShowMedian"] = (CheckboxShowMedian.Checked) ? "true" : "false";
			
			// Show/Hide Unusual points
			Chart1.Series["BoxPlotSeries"]["BoxPlotShowUnusualValues"] = (CheckboxShowUnusual.Checked) ? "true" : "false";
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
			this.Chart1.PrePaint +=new EventHandler<ChartPaintEventArgs>(this.Chart1_PrePaint);
		}
		#endregion

		private void Chart1_PrePaint(object sender, EventArgs e)
		{
			if(sender is Chart)
			{
				// Position point chart type series on the points of the box plot to display labels
				Chart1.Series["BoxPlotLabels"].Points[0].YValues[0] = Chart1.Series["BoxPlotSeries"].Points[0].YValues[0];
				Chart1.Series["BoxPlotLabels"].Points[1].YValues[0] = Chart1.Series["BoxPlotSeries"].Points[0].YValues[1];
				Chart1.Series["BoxPlotLabels"].Points[2].YValues[0] = Chart1.Series["BoxPlotSeries"].Points[0].YValues[2];
				Chart1.Series["BoxPlotLabels"].Points[3].YValues[0] = Chart1.Series["BoxPlotSeries"].Points[0].YValues[3];
				Chart1.Series["BoxPlotLabels"].Points[4].YValues[0] = Chart1.Series["BoxPlotSeries"].Points[0].YValues[4];
				Chart1.Series["BoxPlotLabels"].Points[5].YValues[0] = Chart1.Series["BoxPlotSeries"].Points[0].YValues[5];

				Chart1.Series["BoxPlotLabels"].Points[6].Label = "";
				Chart1.Series["BoxPlotLabels"].Points[7].Label = "";
				if(CheckboxShowUnusual.Checked)
				{
					if(Chart1.Series["BoxPlotSeries"].Points[0].YValues.Length > 6)
					{
						Chart1.Series["BoxPlotLabels"].Points[6].YValues[0] = Chart1.Series["BoxPlotSeries"].Points[0].YValues[6] - 3;
						Chart1.Series["BoxPlotLabels"].Points[6].Label = "Unusual data point";
						}
					if(Chart1.Series["BoxPlotSeries"].Points[0].YValues.Length > 8)
					{
						Chart1.Series["BoxPlotLabels"].Points[7].YValues[0] = Chart1.Series["BoxPlotSeries"].Points[0].YValues[8] + 3;
						Chart1.Series["BoxPlotLabels"].Points[7].Label = "Unusual data point";
					}
					else if(Chart1.Series["BoxPlotSeries"].Points[0].YValues.Length > 7)
					{
						Chart1.Series["BoxPlotLabels"].Points[7].YValues[0] = Chart1.Series["BoxPlotSeries"].Points[0].YValues[7] + 3;
						Chart1.Series["BoxPlotLabels"].Points[7].Label = "Unusual data point";
					}
				}
				

				// Define labels
				int	whiskerPercentile = int.Parse(WhiskerPercentileList.SelectedItem.Value);
				Chart1.Series["BoxPlotLabels"].Points[0].Label = whiskerPercentile.ToString() + "th Percentile";
				Chart1.Series["BoxPlotLabels"].Points[1].Label = (100 - whiskerPercentile).ToString() + "th Percentile";
				if(whiskerPercentile == 0)
				{
					Chart1.Series["BoxPlotLabels"].Points[0].Label = "Minimum";
					Chart1.Series["BoxPlotLabels"].Points[1].Label = "Maximum";
				}
				Chart1.Series["BoxPlotLabels"].Points[2].Label = "25th Percentile (LQ)";
				Chart1.Series["BoxPlotLabels"].Points[3].Label = "75th Percentile (UQ)";
				Chart1.Series["BoxPlotLabels"].Points[4].Label = (CheckBoxShowAverage.Checked) ? "Average/Mean" : "";
				Chart1.Series["BoxPlotLabels"].Points[5].Label = (CheckboxShowMedian.Checked) ? "Median" : "";

				// Add strip lines
				StripLine stripLine = new StripLine();
				stripLine.BackColor = Color.FromArgb(220, Color.DarkKhaki);
				stripLine.IntervalOffset = Chart1.Series["BoxPlotLabels"].Points[2].YValues[0];
				stripLine.StripWidth = Chart1.Series["BoxPlotLabels"].Points[3].YValues[0] - stripLine.IntervalOffset;
				stripLine.Text = "data points\n50% of";
				stripLine.Font = new Font("Microsoft Sans Serif", 7);
				stripLine.TextOrientation = TextOrientation.Rotated270;
				stripLine.TextLineAlignment = StringAlignment.Center;
				stripLine.TextAlignment = StringAlignment.Near;
				Chart1.ChartAreas["Data Chart Area"].AxisY.StripLines.Add(stripLine);

				stripLine = new StripLine();
				stripLine.BackColor = Color.FromArgb(100, Color.DarkKhaki);
				stripLine.IntervalOffset = Chart1.Series["BoxPlotLabels"].Points[0].YValues[0];
				stripLine.StripWidth = Chart1.Series["BoxPlotLabels"].Points[1].YValues[0] - stripLine.IntervalOffset;
				stripLine.ForeColor = Color.FromArgb(120, Color.Black);
                stripLine.Text = (100 - whiskerPercentile * 2).ToString() + "% of data points";
				stripLine.Font = new Font("Microsoft Sans Serif", 7);
                stripLine.TextOrientation = TextOrientation.Rotated270;
				stripLine.TextLineAlignment = StringAlignment.Center;
				Chart1.ChartAreas["Data Chart Area"].AxisY.StripLines.Add(stripLine);


			}
		}
	}
}
