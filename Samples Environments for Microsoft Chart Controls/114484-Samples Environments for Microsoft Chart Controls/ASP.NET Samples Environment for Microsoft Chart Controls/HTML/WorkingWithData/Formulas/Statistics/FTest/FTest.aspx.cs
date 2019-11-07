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
	/// Summary description for CustomSortingOrder.
	/// </summary>
	public partial class FTest : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			FillData();
			StartTest();
		}

		private void FillData()
		{
			// Fill data with random values
			Random rand = new Random(int.Parse(ButtonRandomData.CommandArgument));

			Chart1.Series[0].Points.Clear();
			Chart1.Series[1].Points.Clear();

			for( int i = 0; i <= 20; i++ )
			{
				Chart1.Series[0].Points.AddXY(i,rand.Next(40));
			}

			for( int i = 0; i <= 20; i++ )
			{
				Chart1.Series[1].Points.AddXY(i,rand.Next(40));
			}
		}

		private void StartTest()
		{
			// Calculate probability
			double probability = double.Parse( DropDownListProbability.SelectedItem.Text );
			probability = probability / 100.0;
			
			// Make FTest
			FTestResult result = Chart1.DataManipulator.Statistics.FTest( probability, "FirstGroup", "SecondGroup" ); 

			// Fill labels with results
			TableResults.Rows[0].Cells[1].Text = result.FirstSeriesMean.ToString("G4");
			TableResults.Rows[1].Cells[1].Text = result.SecondSeriesMean.ToString("G4");
			TableResults.Rows[2].Cells[1].Text = result.FirstSeriesVariance.ToString("G4");
			TableResults.Rows[3].Cells[1].Text = result.SecondSeriesVariance.ToString("G4");
			TableResults.Rows[4].Cells[1].Text = result.FValue.ToString("G4");
			TableResults.Rows[5].Cells[1].Text = result.ProbabilityFOneTail.ToString("G4");
			TableResults.Rows[6].Cells[1].Text = result.FCriticalValueOneTail.ToString("G4");
			
			FillFDistribution( Chart1.Series["FirstGroup"].Points.Count - 1, Chart1.Series["SecondGroup"].Points.Count - 1 );

			// Select regions with different colors for distributions
			SelectFDistribution( result.FValue, result.FCriticalValueOneTail );
		}

		/// <summary>
		/// Selection mode for F Distribution
		/// </summary>
		private void SelectFDistribution( double fValue, double fValueDist )
		{
		
				// Go throw all data points and change color for selected data points
				foreach( DataPoint point in Chart1.Series[2].Points )
				{
					if( point.XValue < fValue && point.XValue < fValueDist )
					{
						point.Color = Color.FromArgb(128, 252,180,65); // Yellow
					}
					else if( point.XValue > fValue && point.XValue > fValueDist )
					{
						point.Color = Color.FromArgb(128, 120,147,190); // Gray
					}
					else if(  point.XValue < fValue && point.XValue > fValueDist )
					{
						point.Color = Color.FromArgb(128, 224,64,10); // Red
					}
					else if(  point.XValue > fValue && point.XValue < fValueDist )
					{
						point.Color = Color.FromArgb(128, 0,92,219); // Blue
					}
				}
			}


		/// <summary>
		/// Fill Data points with values from F distribution
		/// </summary>
		private void FillFDistribution( int n, int m )
		{
			// Clear all data points
			Chart1.Series[2].Points.Clear();

			// Set axis values
			Chart1.ChartAreas[1].AxisX.Minimum = 0;
			Chart1.ChartAreas[1].AxisX.Maximum = 6;
			Chart1.ChartAreas[1].AxisY.Minimum = 0;
			Chart1.ChartAreas[1].AxisY.Maximum = 1.0;
			
			// Calculate Beta function
			double beta = Chart1.DataManipulator.Statistics.BetaFunction( n/2.0, m/2.0 );

			// Find coefficient
			double y;
			double coef = Math.Pow( (double)( n ) / (double)( m ), n / 2.0 ) / beta;
			double doubleX;

			// Go throw all data points and calculate values
			for( double x = 0.01; x <= 15; x += 0.1 )
			{
				doubleX = x;
				y = coef * Math.Pow( doubleX, n / 2.0 - 1.0 ) / Math.Pow(1.0 + n*doubleX/m,(n+m)/2.0);

				// Add data point
				Chart1.Series[2].Points.AddXY( doubleX, y );
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

		protected void DropDownListProbability_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillData();
			StartTest();
		}

		protected void ButtonRandomData_Click(object sender, System.EventArgs e)
		{
			Random rand = new Random();
			ButtonRandomData.CommandArgument = rand.Next().ToString();

			FillData();
			StartTest();
		}
	}

}
