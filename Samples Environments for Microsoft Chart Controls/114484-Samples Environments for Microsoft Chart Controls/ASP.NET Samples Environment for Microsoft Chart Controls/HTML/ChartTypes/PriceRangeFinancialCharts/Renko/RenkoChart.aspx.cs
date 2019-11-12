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
	public partial class RenkoChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList comboReversalAmount;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// populate data series
			PopulateData();

			string boxSize = comboBoxSize.SelectedItem.Text;

			// set series type
			Chart1.Series["Default"].ChartType = SeriesChartType.Renko;

			// set the PriceUpColor attribute			
			Chart1.Series["Default"]["PriceUpColor"] = "White";

			// set the default color
			Chart1.Series["Default"].Color = Color.Black;


			if ( boxSize == "Default")
			{
				// clear attribute, let the default BoxSize to be calculated
				Chart1.Series["Default"].DeleteCustomProperty("BoxSize");
			}
			else
			{
				// set the BoxSize attribute
				Chart1.Series["Default"]["BoxSize"] = boxSize;
			}
			
		}

		private void PopulateData() 
		{
			double[] points = {	  47.625,47.750,47.500,46.125,45.125,45.250,44.500,45.000,45.250,44.875,44.250,43.375,42.500,42.750,
								  42.000,41.375,40.000,39.875,40.125,41.250,42.250,42.625,43.375,45.250,47.500,47.625,46.500,46.125,
								  46.250,45.750,45.125,45.250,43.500,43.625,44.125,43.750,44.000,44.875,44.625,45.250,45.250,45.250,
								  45.125,45.500,45.625,45.500,45.625,45.000,44.750,44.875,45.250,45.250,45.125,45.125,45.625,45.500,
								  45.375,46.500,47.000,46.125,45.125,45.375,45.875,45.250,45.250,44.625,45.125,45.250,46.125,46.750};

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
			this.Chart1.PrePaint +=new EventHandler<ChartPaintEventArgs>(this.Chart1_PrePaint);
		}
		#endregion		

		private void Chart1_PrePaint(object sender, EventArgs e)
		{
			string calculatedBoxSize = Chart1.Series["Default"]["CurrentBoxSize"].ToString();
			// update chart title
			Chart1.Titles[0].Text = "Renko chart, Box Size = " + calculatedBoxSize;
		}

		
		
	}
}
