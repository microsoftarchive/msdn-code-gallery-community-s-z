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
	/// Summary description for PieCollectedData.
	/// </summary>
	public partial class PieCollectedData: System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.CheckBox HideSupplemental;
	
		PieCollectedDataHelper pieHelper = null;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Create pie chart helper class
			pieHelper = new PieCollectedDataHelper(Chart1);
			pieHelper.CollectedLabel = String.Empty;

			// Set chart type 
			Chart1.Series["Default"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), ChartTypeList.SelectedItem.Text, true );

			// Populate series data
			double[]	yValues = {65.62,  2.1, 85.73, 11.42, 34.45,  75.54, 5.7, 4.1};
			string[]	xValues = {"France", "Japan",  "USA", "Italy", "Germany", "Canada",  "Russia", "Spain"};
			Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

			// Remove supplemental series and chart area if they already exsist
			if(Chart1.Series.Count > 1)
			{
				Chart1.Series.RemoveAt(1);
				Chart1.ChartAreas.RemoveAt(1);

				// Reset automatic position for the default chart area
				Chart1.ChartAreas["ChartArea1"].Position.Auto = true;
			}
			Chart1.Series[0].Points[Chart1.Series[0].Points.Count - 1].Color = Color.FromArgb(202, 107, 75);

			// Check if supplemental chart should be shown
			if(!HideSupp.Checked)
			{

				Chart1.Series["Default"]["PieLabelStyle"] = "Inside";
				
				// Set the percentage of the total series values. This value determines 
				// if the data point value is a "small" value and should be shown as collected.
				pieHelper.CollectedPercentage = double.Parse(CollectedPercentage.SelectedItem.Text);

				// Indicates if small segments should be shown as one "collected" segment in 
				// the original series.
				pieHelper.ShowCollectedDataAsOneSlice = checkBoxCollect.Checked;

				// Size ratio between the original and supplemental chart areas.
				// Value of 1.0f indicates that same area size will be used.
				if(SupplementalChartSize.SelectedIndex == 0)
				{
					pieHelper.SupplementedAreaSizeRatio = 0.9f;
				}
				else if(SupplementalChartSize.SelectedIndex == 1)
				{
					pieHelper.SupplementedAreaSizeRatio = 1.0f;
				}
				else if(SupplementalChartSize.SelectedIndex == 2)
				{
					pieHelper.SupplementedAreaSizeRatio = 1.1f;
				}

				// Set position in relative coordinates ( 0,0 - top left corner; 100,100 - bottom right corner)
				// where original and supplemental pie charts should be placed.
				pieHelper.ChartAreaPosition = new RectangleF(3f, 3f, 93f, 96f);

				// Show supplemental pie for the "Default" series
				pieHelper.ShowSmallSegmentsAsSupplementalPie("Default");
			}
			else
			{
				Chart1.Series["Default"]["PieLabelStyle"] = "Ellipse";
				Chart1.Series["Default"].LabelBackColor = Color.Empty;

			}

			// Enable/Disable controls
			ChartTypeList.Enabled = !HideSupp.Checked;
			CollectedPercentage.Enabled = !HideSupp.Checked;
			SupplementalChartSize.Enabled = !HideSupp.Checked;
			checkBoxCollect.Enabled = !HideSupp.Checked;
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
