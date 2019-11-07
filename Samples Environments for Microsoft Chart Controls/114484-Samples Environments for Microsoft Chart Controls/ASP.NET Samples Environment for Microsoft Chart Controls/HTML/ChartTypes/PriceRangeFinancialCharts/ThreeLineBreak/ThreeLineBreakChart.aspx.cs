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
	/// Summary description for WebForm1.
	/// </summary>
	public partial class ThreeLineBreakChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList comboReversalAmount;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// populate data series
			PopulateData();

			string numberOfLines = comboNumberOfLines.SelectedItem.Text;

			// set series type
			Chart1.Series["Default"].ChartType = SeriesChartType.ThreeLineBreak;

			// set the PriceUpColor attribute			
			Chart1.Series["Default"]["PriceUpColor"] = "White";

			// set the default color
			Chart1.Series["Default"].Color = Color.Black;

			if ( numberOfLines == "Default")
			{
				// clear attribute, let the default NumberOfLinesInBreak to be calculated
				Chart1.Series["Default"].DeleteCustomProperty("NumberOfLinesInBreak");
			}
			else
			{
				// set the NumberOfLinesInBreak attribute
				Chart1.Series["Default"]["NumberOfLinesInBreak"] = numberOfLines;
			}
			
			
		}

		private void PopulateData() 
		{
			double[] points = {   27.375,26.375,26.062,25.750,26.125,25.875,25.750,25.250,24.375,24.000, 
								  23.625,23.875,26.500,26.750,27.375,27.375,26.825,27.000,26.875,26.625,
								  27.627,28.000,27.125,25.875,27.250,25.500,24.875,24.875,24.125,25.000,
								  26.250,27.375,27.500,28.000,27.625,27.125,26.250,26.250,26.250,26.375,
								  26.625,27.375,28.500,27.250,26.250,26.500,26.125,25.750,26.000,26.625,
								  26.125,26.250,25.750,25.375,25.375,24.750,23.500,24.062,23.250,23.500,24.125,24.625,24.625};

			DateTime date   = DateTime.Today.AddDays( -points.Length);
			
			Chart1.Series["Default"].Points.Clear();
			
			for( int day = 0; day < points.Length; day++) 
			{
				Chart1.Series["Default"].Points.AddXY( date.AddDays( day), points[day]);
			}
		}



		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
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
