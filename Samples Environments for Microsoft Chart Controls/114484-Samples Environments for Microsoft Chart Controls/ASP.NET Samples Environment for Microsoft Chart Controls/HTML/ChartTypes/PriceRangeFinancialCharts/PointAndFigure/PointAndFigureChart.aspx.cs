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
	public partial class PointAndFigureChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			PopulateData();

			string reversalAmount = comboReversalAmount.SelectedItem.Text;
			string boxSize		  = comboBoxSize.SelectedItem.Text;
			string propSymbols    = checkPropSymbols.Checked.ToString();

			// set series type
			Chart1.Series["Default"].ChartType = SeriesChartType.PointAndFigure;

			// set the PriceUpColor attribute			
			Chart1.Series["Default"]["PriceUpColor"] = "Blue";
			
			// set the Color attribute			
			Chart1.Series["Default"].Color = Color.Red;

			if ( reversalAmount == "Default")
			{
				// clear attribute, let the default ReversalAmount to be calculated
				Chart1.Series["Default"].DeleteCustomProperty("ReversalAmount");
			}
			else
			{
				// set the ReversalAmount attribute
				Chart1.Series["Default"]["ReversalAmount"] = reversalAmount;
			}

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
			// set the ProportionalSymbols attribute
			Chart1.Series["Default"]["ProportionalSymbols"] = propSymbols;
			
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
			
			for( int days = 0; days < points.Length; days++) 
			{
				Chart1.Series["Default"].Points.AddXY( date.AddDays( days), points[days] + 0.500 , points[days]);
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
