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
	public partial class KagiChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// populate data series
			PopulateData();

			// read reversal amount
			string reversalAmount = comboReversalAmount.SelectedItem.Text;

			// set series chart type
			Chart1.Series["Default"].ChartType = SeriesChartType.Kagi;

			// set the PriceUpColor attribute	
			Chart1.Series["Default"]["PriceUpColor"] = "0, 128, 255";
			Chart1.Series["Default"].Color = Color.FromArgb(255,64,64);

			if ( reversalAmount == "Default")
			{
				// clear attribute, let the default BoxSize to be calculated
				Chart1.Series["Default"].DeleteCustomProperty("ReversalAmount");
			}
			else
			{
				// set the BoxSize attribute
				Chart1.Series["Default"]["ReversalAmount"] = reversalAmount;
			}
			
		}

		private void PopulateData() 
		{
			double[] points = {   35.750,37.250,39.000,38.375,37.750,37.750,37.375,36.250,35.750,35.250,36.250,35.250,34.500,
								  35.625,35.500,36.625,36.375,36.250,36.875,37.250,36.875,36.500,37.125,36.375,35.875,36.625,
								  37.125,36.250,37.000,37.250,37.500,38.500,39.500,38.875,38.500,39.000,38.500,38.500,39.000,
								  39.000,40.000,39.875,39.875,38.875,38.500,38.250,38.875,39.375,39.375,39.750,39.500,39.375,
								  38.500,37.750,37.625,37.500,36.500,35.000,36.625,36.000,35.875,35.000,35.250,35.125,35.050};

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
