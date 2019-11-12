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
	/// The Price indicator sample.
	/// </summary>
	public partial class PriceIndicators : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
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

		protected void TypicalPrice_CheckedChanged(object sender, System.EventArgs e)
		{
			Checked();
		}

		protected void MedianPrice_CheckedChanged(object sender, System.EventArgs e)
		{
			Checked();
		}
		
		protected void WeightedClose_CheckedChanged(object sender, System.EventArgs e)
		{
			Checked();
		}

		protected void NumberOfDays_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Checked();
		}

		private void Random_CheckedChanged(object sender, System.EventArgs e)
		{
			Checked();
		}

		/// <summary>
		/// This method calculates Price indicators if 
		/// corresponding check box is selected.
		/// </summary>
		private void Checked()
		{
			// Calculates Typical Price
			if(TypicalPrice.Checked)
			{
				Chart1.DataManipulator.FinancialFormula(FinancialFormula.TypicalPrice,"Input:Y,Input:Y2,Input:Y3","Typical");
				Chart1.Series["Typical"].ChartType = SeriesChartType.Line;
				Chart1.Series["Typical"].Color = Color.FromArgb(252,180,65);
				Chart1.Series["Typical"].ShadowOffset = 1;
			}

			// Calculates Median Price
			if(MedianPrice.Checked)
			{
				Chart1.DataManipulator.FinancialFormula(FinancialFormula.MedianPrice,"Input:Y,Input:Y2","Median");
				Chart1.Series["Median"].ChartType = SeriesChartType.Line;
				Chart1.Series["Median"].Color = Color.FromArgb(224,64,10);
				Chart1.Series["Median"].ShadowOffset = 1;
			}

			// Calculates Weighted Close Price
			if(WeightedClose.Checked)
			{
				Chart1.DataManipulator.FinancialFormula(FinancialFormula.WeightedClose,"Input:Y,Input:Y2,Input:Y3","Weighted");
				Chart1.Series["Weighted"].ChartType = SeriesChartType.Line;
				Chart1.Series["Weighted"].Color = Color.FromArgb(5,100,146);
				Chart1.Series["Weighted"].ShadowOffset = 1;
			}
			
		}

		/// <summary>
		/// Random Stock Data Generator
		/// </summary>
		/// <param name="series">Data series</param>
		private void Data( Series series )
		{
			Random rand;
			// Use a number to calculate a starting value for 
			// the pseudo-random number sequence
			rand = new Random(int.Parse(Random3.CommandArgument));
			
			// The number of days for stock data
			int period = int.Parse( NumberOfDays.SelectedItem.Value );

			// The first High value
			double high = rand.NextDouble() * 40;

			// The first Close value
			double close = high - rand.NextDouble();

			// The first Low value
			double low = close - rand.NextDouble();

			// The first Open value
			double open = ( high - low ) * rand.NextDouble() + low;
						
			// The first day X and Y values
			Chart1.Series["Input"].Points.AddXY(DateTime.Parse("1/1/2002"), high);
			Chart1.Series["Input"].Points[0].YValues[1] = low;

			// The Open value is not used.
			Chart1.Series["Input"].Points[0].YValues[2] = open;
			Chart1.Series["Input"].Points[0].YValues[3] = close;
			
			// Days loop
			for( int day = 1; day < period; day++ )
			{
			
				// Calculate High, Low and Close values
				high = Chart1.Series["Input"].Points[day-1].YValues[2]+rand.NextDouble();
				close = high - rand.NextDouble();
				low = close - rand.NextDouble();
				open = ( high - low ) * rand.NextDouble() + low;
				
				// The low cannot be less than yesterday close value.
				if( low > Chart1.Series["Input"].Points[day-1].YValues[2])
					low = Chart1.Series["Input"].Points[day-1].YValues[2];
							
				// Set data points values
				Chart1.Series["Input"].Points.AddXY(day, high);
				Chart1.Series["Input"].Points[day].XValue = Chart1.Series["Input"].Points[day-1].XValue+1;
				Chart1.Series["Input"].Points[day].YValues[1] = low;
				Chart1.Series["Input"].Points[day].YValues[2] = open;
				Chart1.Series["Input"].Points[day].YValues[3] = close;
			}
		}

		protected void Random3_Click(object sender, System.EventArgs e)
		{
			Random rand = new Random();
			Random3.CommandArgument = rand.Next().ToString();
		}	
		
		public void AfterLoad()
		{
			// Set random data
			Data( Chart1.Series["Input"] );

			// Initialize values.
			Checked();
		}
	}
}
