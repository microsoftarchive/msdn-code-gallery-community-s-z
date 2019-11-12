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
	public partial class Forecasting : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList FormulaName;
	
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
		/// This method calculates Time series.
		/// </summary>
		private void Calculations()
		{
			string typeRegression;

			if( Type.SelectedItem.Value != "Polynomial" )
				Order.Enabled = false;
			else
				Order.Enabled = true;

			if( Type.SelectedItem.Value != "Polynomial" )
				typeRegression = Type.SelectedItem.Value;
			else
				typeRegression = Order.SelectedItem.Value;

			// The number of days for Forecasting
			int forecasting = int.Parse( ForecastPeriod.SelectedItem.Value );

			// Show Error as a range chart
			string error = Error1.Checked.ToString();

			// Show Error as a range chart
			string forecastingError = ForecastingError.Checked.ToString();

			// Formula parameters
			string parameters = typeRegression + ',' + forecasting + ',' + error + ',' + forecastingError;

            Chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, parameters, "Input:Y", "Forecasting:Y,Range:Y,Range:Y2");

            Chart1.Series["Range"].Enabled = Error1.Checked || ForecastingError.Checked;			
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
			if( high <= 0 )
			{
				high = -1 * high + 1;
			}

			// The first Close value
			double close = high - rand.NextDouble();

			// The first Low value
			double low = close - rand.NextDouble();

			// The first Volume value
			double volume = 100 + 15 * rand.NextDouble();
						
			// The first day X and Y values
			Chart1.Series["Input"].Points.AddXY(DateTime.Parse("1/2/2002"), high);
			Chart1.Series["Input"].Points[0].YValues[1] = low;

			// The Open value is not used.
			Chart1.Series["Input"].Points[0].YValues[2] = close;
			Chart1.Series["Input"].Points[0].YValues[3] = close;
			
			// Days loop
			for( int day = 1; day <= period; day++ )
			{
			
				// Calculate High, Low and Close values
				high = Chart1.Series["Input"].Points[day-1].YValues[2]+rand.NextDouble();
				if( high <= 0 )
				{
					high = -1 * high + 1;
				}
				close = high - rand.NextDouble();
				low = close - rand.NextDouble();
				
				// The low cannot be less than yesterday close value.
				if( low > Chart1.Series["Input"].Points[day-1].YValues[2])
					low = Chart1.Series["Input"].Points[day-1].YValues[2];
							
				// Set data points values
				Chart1.Series["Input"].Points.AddXY(day, high);
				Chart1.Series["Input"].Points[day].XValue = Chart1.Series["Input"].Points[day-1].XValue+1;
				Chart1.Series["Input"].Points[day].YValues[1] = low;
				Chart1.Series["Input"].Points[day].YValues[2] = close;
				Chart1.Series["Input"].Points[day].YValues[3] = close;
			}
		}

		protected void Type_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		protected void Random3_Click(object sender, System.EventArgs e)
		{
			Random rand = new Random();
			Random3.CommandArgument = rand.Next().ToString();
		}		

		public void AfterLoad()
		{
			if( Type.SelectedItem.Value == "Linear" )
				Order.Enabled = false;
			else
				Order.Enabled = true;

			// Set random data
			Data( Chart1.Series["Input"] );

			// Initialize values.
			Calculations();
		}

	}
}
