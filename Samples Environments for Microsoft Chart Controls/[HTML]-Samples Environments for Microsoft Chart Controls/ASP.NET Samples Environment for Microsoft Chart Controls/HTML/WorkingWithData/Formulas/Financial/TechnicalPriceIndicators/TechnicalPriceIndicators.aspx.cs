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
	public partial class TechnicalPriceIndicators : System.Web.UI.Page
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

		
		/// <summary>
		/// This method calculates a different indicator if corresponding 
		/// item in the combo box is selected.
		/// </summary>
		private void Calculations()
		{
			// Set Formula Name
			string formulaName = FormulaName.SelectedItem.Value;
			FinancialFormula formula = (FinancialFormula)Enum.Parse(typeof(FinancialFormula),formulaName,true);
			// Formulas with one input value
			if( formulaName == "DetrendedPriceOscillator" || formulaName == "MovingAverageConvergenceDivergence" || formulaName == "Performance" || formulaName == "RateOfChange" 
                || formulaName == "TripleExponentialMovingAverage")
			{
				Chart1.DataManipulator.FinancialFormula(formula,"10","Input:Y4","Indicators");
			}

			// Relative Strength Index
			else if( formulaName == "RelativeStrengthIndex" )
			{
				Chart1.DataManipulator.FinancialFormula(formula,"10","Input:Y4","Indicators");

				// Set minimum and maximum for Y axis
				Chart1.ChartAreas["Indicator"].AxisY.Minimum = 0;
				Chart1.ChartAreas["Indicator"].AxisY.Maximum = 100;

				// Create strip lines used with Relative strength index.
				StripLine stripLine = new StripLine();
				Chart1.ChartAreas["Indicator"].AxisY.StripLines.Add(stripLine);
				stripLine.Interval = 70;
				stripLine.StripWidth = 30;
				stripLine.BackColor = Color.FromArgb(64, 165, 191, 228);
				
			}
			// Williams %R
			else if( formulaName == "WilliamsR" )
			{
				Chart1.DataManipulator.FinancialFormula(formula,"Input:Y,Input:Y2,Input:Y4","Indicators");

				// Set minimum and maximum for Y axis
				Chart1.ChartAreas["Indicator"].AxisY.Minimum = -100;
				Chart1.ChartAreas["Indicator"].AxisY.Maximum = 0;

				// Create strip lines used with Williams %R index.
				StripLine stripLine = new StripLine();
				Chart1.ChartAreas["Indicator"].AxisY.StripLines.Add(stripLine);
				stripLine.Interval = 80;
				stripLine.StripWidth = 20;
				stripLine.BackColor = Color.FromArgb(64, 165, 191, 228);
			}
			// Formulas with two input value
			else if( formulaName == "MassIndex" || formulaName == "VolatilityChaikins" || formulaName == "Performance" )
			{
				Chart1.DataManipulator.FinancialFormula(formula,"20","Input:Y,Input:Y2","Indicators");
			}
			// Standard deviation
			else if( formulaName == "StandardDeviation" )
			{
				Chart1.DataManipulator.FinancialFormula(formula,"15","Input:Y4","Indicators");
			}
			// StochasticIndicator
			else if( formulaName == "StochasticIndicator" )
			{
				Chart1.DataManipulator.FinancialFormula(formula,"15","Input:Y,Input:Y2,Input:Y4","Indicators,SMA");

				// Set attributes for Simple moving average series.
				Chart1.Series["SMA"].ChartType = SeriesChartType.Line;
				Chart1.Series["SMA"].Color = Color.FromArgb(252,180,65);
				Chart1.Series["SMA"].ChartArea = "Indicator";
				Chart1.Series["SMA"].BorderWidth = 2;
			}
			// All other formulas.
			else
			{
				Chart1.DataManipulator.FinancialFormula(formula,"Input:Y,Input:Y2,Input:Y4","Indicators");
			}

			// Set minimum for X axis
			Chart1.ChartAreas["Indicator"].AxisX.Minimum = DateTime.Parse("1/1/2002").ToOADate();
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

		protected void Random_Click(object sender, System.EventArgs e)
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
