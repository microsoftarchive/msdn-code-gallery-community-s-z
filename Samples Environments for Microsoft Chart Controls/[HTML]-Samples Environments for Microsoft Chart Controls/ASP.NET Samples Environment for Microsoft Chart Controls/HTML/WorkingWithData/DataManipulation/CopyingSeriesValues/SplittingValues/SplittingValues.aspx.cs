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
	/// Summary description for SplittingValues.
	/// </summary>
	public partial class SplittingValues : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data
			double[]	yValue1 = {68, 34, 65, 23, 87, 96, 56, 34, 56, 34};
			double[]	yValue2 = {25, 17, 21, 38, 40, 48, 39, 31, 26, 34};
			double[]	xValue = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
			Chart1.Series["Bubble"].Points.DataBindXY(xValue, yValue1, yValue2);
			
			// Split Bubble series with two Y values into two series with one Y value, 
			// first Column series will contain the bubble position and
			// second Line series will contain the bubble size
			if(ShowAsColumn.Checked)
			{
				// Split series data
				Chart1.DataManipulator.CopySeriesValues("Bubble:Y1,Bubble:Y2", "Column:Y1,Line:Y1");

				Chart1.Series["Bubble"].ChartArea = String.Empty;

				// Set Column chart attributes
				Chart1.Series["Column"].ChartArea = "ChartArea1";
				Chart1.Series["Column"].ChartType = SeriesChartType.Column;
				Chart1.Series["Column"].BorderColor = Color.FromArgb(180, 26, 59, 105);

				// Set Line chart attributes
				Chart1.Series["Line"].ChartArea = "ChartArea1";
				Chart1.Series["Line"].ChartType = SeriesChartType.Line;
				Chart1.Series["Line"].YAxisType = AxisType.Secondary;
				Chart1.Series["Line"].BorderWidth = 3;
				Chart1.Series["Line"].BorderColor = Color.FromArgb(64, 64, 64);
				Chart1.Series["Line"].ShadowOffset = 2;
				Chart1.Series["Line"].MarkerBorderColor = Color.FromArgb(64, 64, 64);
				Chart1.Series["Line"].MarkerStyle = MarkerStyle.Circle;
				Chart1.Series["Line"].MarkerColor = Color.FromArgb(224,64,10);
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
	}
}

