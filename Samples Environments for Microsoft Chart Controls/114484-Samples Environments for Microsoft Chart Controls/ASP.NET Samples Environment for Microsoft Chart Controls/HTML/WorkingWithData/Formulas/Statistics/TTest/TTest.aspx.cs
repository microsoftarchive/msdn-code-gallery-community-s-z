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
	public partial class TTest : System.Web.UI.Page
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
	
			for( int i = 0; i <= 10; i++ )
			{
				Chart1.Series[0].Points.AddXY(i,rand.Next(15));
				Chart1.Series[1].Points.AddXY(i,rand.Next(15));
			}
	
		}

		private void StartTest()
		{
			// Calculate probability
			double probability = double.Parse( DropDownListProbability.SelectedItem.Text );
			probability = probability / 100.0;
			
			TTestResult result;

			// Find T Test Type
			if( DropDownList1.SelectedIndex == 0 )
			{
				// Make TTest
				result = Chart1.DataManipulator.Statistics.TTestEqualVariances( 0, probability, "FirstGroup", "SecondGroup" ); 
			}
			else if( DropDownList1.SelectedIndex == 1 )
			{
				// Make TTest
				result = Chart1.DataManipulator.Statistics.TTestUnequalVariances( 0, probability, "FirstGroup", "SecondGroup" ); 
			}
			else
			{
				// Make TTest
				result = Chart1.DataManipulator.Statistics.TTestPaired( 0, probability, "FirstGroup", "SecondGroup" ); 
			}

			// Fill labels with results
			TableResults.Rows[0].Cells[1].Text = result.FirstSeriesMean.ToString("G4");
			TableResults.Rows[1].Cells[1].Text = result.SecondSeriesMean.ToString("G4");
			TableResults.Rows[2].Cells[1].Text = result.FirstSeriesVariance.ToString("G4");
			TableResults.Rows[3].Cells[1].Text = result.SecondSeriesVariance.ToString("G4");
			TableResults.Rows[4].Cells[1].Text = result.TValue.ToString("G4");
			TableResults.Rows[5].Cells[1].Text = result.DegreeOfFreedom.ToString("G4");
			TableResults.Rows[6].Cells[1].Text = result.ProbabilityTOneTail.ToString("G4");
			TableResults.Rows[7].Cells[1].Text = result.TCriticalValueOneTail.ToString("G4");
			TableResults.Rows[8].Cells[1].Text = result.ProbabilityTTwoTail.ToString("G4");
			TableResults.Rows[9].Cells[1].Text = result.TCriticalValueTwoTail.ToString("G4");
			
			FillTDistribution( result.DegreeOfFreedom );

			// Select regions with different colors for distributions
			SelectTDistribution( result.TValue, result.TCriticalValueOneTail );
		}
		
		/// <summary>
		/// Selection mode for T Distribution
		/// </summary>
		private void SelectTDistribution( double tValue, double tValueDist )
		{
		
			// Go throw all data points and change color for selected data points
			foreach( DataPoint point in Chart1.Series[2].Points )
			{
				if( point.XValue < tValue && point.XValue < tValueDist )
				{
					point.Color = Color.FromArgb(128, 252,180,65); // Yellow
				}
				else if( point.XValue > tValue && point.XValue > tValueDist )
				{
					point.Color = Color.FromArgb(128, 120,147,190); // Gray
				}
				else if(  point.XValue > tValue && point.XValue < tValueDist )
				{
					point.Color =  Color.FromArgb(128, 224,64,10); // Red
				}
				else if(  point.XValue < tValue && point.XValue > tValueDist )
				{
					point.Color = Color.FromArgb(128, 0,92,219); // Blue
				}
			}
		}

		/// <summary>
		/// Fill Data points with T Distribution
		/// </summary>
		private void FillTDistribution( double n )
		{
			// Clear all existing data points
			Chart1.Series[2].Points.Clear();
			
			// Set Axis values
			Chart1.ChartAreas[1].AxisX.Minimum = -5;
			Chart1.ChartAreas[1].AxisX.Maximum = 5;
			Chart1.ChartAreas[1].AxisY.Minimum = 0;
			Chart1.ChartAreas[1].AxisY.Maximum = 0.5;
			Chart1.ChartAreas[1].AxisX.LabelStyle.Interval = 2;
			Chart1.ChartAreas[1].AxisX.MajorTickMark.Interval = 2;
			
			// Calculate Beta function
			double beta = Chart1.DataManipulator.Statistics.BetaFunction( 0.5, n/2.0 );

			// Calculate coefficient of T Distribution
			double y;
			double coef = Math.Pow( n , -0.5 ) / beta;
			double doubleX;

			// Calculate Data Points
			for( int x = -120; x <= 120; x ++ )
			{
				doubleX = x / 10.0;
				y = coef / Math.Pow( 1.0 + doubleX * doubleX / n , ( n + 1.0 ) / 2.0 );

				// Add X and Y values to data points
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
