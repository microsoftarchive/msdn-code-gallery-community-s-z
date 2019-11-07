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
	public partial class VolumeIndicators : System.Web.UI.Page
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

		
		
		private void Calculations()
		{
			// Set Formula Name
			string formulaName = FormulaName.SelectedItem.Value;
			FinancialFormula formula = (FinancialFormula) Enum.Parse(typeof(FinancialFormula),formulaName,true);


			// Easy of movement
			if( formulaName == "EaseOfMovement" )
			{
				Chart1.DataManipulator.FinancialFormula(formula,"Input:Y,Input:Y2,Volume","Indicators");
			}
			// Money Flow
			else if( formulaName == "MoneyFlow" )
			{
				Chart1.DataManipulator.FinancialFormula(formula,"20","Input:Y,Input:Y2,Input:Y4,Volume","Indicators");
				Chart1.ChartAreas["Indicator"].AxisX.Minimum = DateTime.Parse("1/1/2002").ToOADate();
				
			}
			// Chaikin Oscillator
			else if( formulaName == "ChaikinOscillator" )
			{
				Chart1.DataManipulator.FinancialFormula(formula,"5,12","Input:Y,Input:Y2,Input:Y4,Volume","Indicators");
				Chart1.ChartAreas["Indicator"].AxisX.Minimum = DateTime.Parse("1/1/2002").ToOADate();
				
			}
			// Formulas which use one price and volume.
			else if( formulaName == "NegativeVolumeIndex" || formulaName == "OnBalanceVolume" || formulaName == "PositiveVolumeIndex" || formulaName == "PriceVolumeTrend" )
			{
				Chart1.DataManipulator.FinancialFormula(formula,"100","Input:Y4,Volume","Indicators");
			}
			// All other formulas.
			else
			{
				Chart1.DataManipulator.FinancialFormula(formula,"Input:Y,Input:Y2,Input:Y4,Volume","Indicators");
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

			// The first Volume value
			double volume = 100 + 15 * rand.NextDouble();
						
			// The first day X and Y values
			Chart1.Series["Input"].Points.AddXY(DateTime.Parse("1/2/2002"), high);
			Chart1.Series["Volume"].Points.AddXY(DateTime.Parse("1/2/2002"), volume);
			Chart1.Series["Input"].Points[0].YValues[1] = low;

			// The Open value is not used.
			Chart1.Series["Input"].Points[0].YValues[2] = open;
			Chart1.Series["Input"].Points[0].YValues[3] = close;
			
			// Days loop
			for( int day = 1; day <= period; day++ )
			{
			
				// Calculate High, Low and Close values
				high = Chart1.Series["Input"].Points[day-1].YValues[2]+rand.NextDouble();
				close = high - rand.NextDouble();
				low = close - rand.NextDouble();
				open = ( high - low ) * rand.NextDouble() + low;
				
				// Calculate volume
				volume = Chart1.Series["Volume"].Points[day-1].YValues[0] + 10 * rand.NextDouble() - 5;

				// The low cannot be less than yesterday close value.
				if( low > Chart1.Series["Input"].Points[day-1].YValues[2])
					low = Chart1.Series["Input"].Points[day-1].YValues[2];
							
				// Set data points values
				Chart1.Series["Input"].Points.AddXY(day, high);
				Chart1.Series["Input"].Points[day].XValue = Chart1.Series["Input"].Points[day-1].XValue+1;
				Chart1.Series["Input"].Points[day].YValues[1] = low;
				Chart1.Series["Input"].Points[day].YValues[2] = open;
				Chart1.Series["Input"].Points[day].YValues[3] = close;

				// Set volume values
				Chart1.Series["Volume"].Points.AddXY(day, volume);
				Chart1.Series["Volume"].Points[day].XValue = Chart1.Series["Volume"].Points[day-1].XValue+1;
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
			Calculations();
		}
	}
}
