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
	public partial class Distributions : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList SortList;
	
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
		/// Fill data points with values from Normal distribution
		/// </summary>
		private void FillNormalDistribution( )
		{
			
			// Remove all data points from series
			Chart1.Series[0].Points.Clear();

			// Disable combo boxes for degree of freedom
			DropDownList2.Enabled = false;
			DropDownList3.Enabled = false;
			CheckBox1.Enabled = true;
			
			// Set formula background image
			Chart1.ChartAreas["ChartArea1"].BackImage = "Normal.gif";

			// Set vaxis values
			Chart1.ChartAreas["ChartArea1"].AxisX.Minimum = -5;
			Chart1.ChartAreas["ChartArea1"].AxisX.Maximum = 5;
			Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
			Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 0.5;
			
			// Calculate coefficient
			double y;
			double coef = 1.0 / Math.Sqrt( 2 * Math.PI );
			double doubleX;

			// Fill data points with values from Normal distribution
			for( int x = -50; x <= 50; x ++ )
			{
				doubleX = x / 10.0;
				y = coef * Math.Exp( doubleX * doubleX / -2 );
				Chart1.Series[0].Points.AddXY( doubleX - 0.05, y );
			}

			// Selection mode for normal distribution
			this.SelectNormalDistribution();

		}

		/// <summary>
		/// Fill Data points with values from F distribution
		/// </summary>
		private void FillFDistribution( )
		{
			// Clear all data points
			Chart1.Series[0].Points.Clear();

			// Disable or enable nececery controls
			DropDownList2.Enabled = true;
			DropDownList3.Enabled = true;
			CheckBox1.Enabled = false;

			// Set background formula image
			Chart1.ChartAreas["ChartArea1"].BackImage = "FDist.gif";

			// Set axis values
			Chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
			Chart1.ChartAreas["ChartArea1"].AxisX.Maximum = 15;
			Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
			Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 1.2;

			// Take degree of freedoms
			double n = double.Parse(DropDownList2.SelectedItem.Text);
			double m = double.Parse(DropDownList3.SelectedItem.Text);
			
			// Calculate Beta function
			double beta = Chart1.DataManipulator.Statistics.BetaFunction( n/2.0, m/2.0 );

			// Find coefficient
			double y;
			double coef = Math.Pow( n / m, n / 2.0 ) / beta;
			double doubleX;

			// Go throw all data points and calculate values
			for( double x = 0.01; x <= 15; x += 0.1 )
			{
				doubleX = x;
				y = coef * Math.Pow( doubleX, n / 2.0 - 1.0 ) / Math.Pow(1.0 + n*doubleX/m,(n+m)/2.0);

				// Add data point
				Chart1.Series[0].Points.AddXY( doubleX, y );
			}

			// Selection mode for F distribution
			SelectFDistribution( );

		}

		/// <summary>
		/// Fill Data points with T Distribution
		/// </summary>
		private void FillTDistribution( )
		{
			// Clear all existing data points
			Chart1.Series[0].Points.Clear();

			// Enable or disable controls
			DropDownList2.Enabled = true;
			DropDownList3.Enabled = false;
			CheckBox1.Enabled = true;

			// Set back formula color image
			Chart1.ChartAreas["ChartArea1"].BackImage = "TDist.gif";

			// Set Axis values
			Chart1.ChartAreas["ChartArea1"].AxisX.Minimum = -12;
			Chart1.ChartAreas["ChartArea1"].AxisX.Maximum = 12;
			Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
			Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 0.5;
			Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 2;
			Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = 2;
			
			// Calculate Beta function
			double n = double.Parse( DropDownList2.SelectedItem.Text );
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
				Chart1.Series[0].Points.AddXY( doubleX, y );
			}

			// Call selection method.
			SelectTDistribution( );

		}

		/// <summary>
		/// Selection mode for Normal Distribution
		/// </summary>
		private void SelectNormalDistribution( )
		{
			// One tailed normal distribution or two tails
			bool oneTail = CheckBox1.Checked;

			// Colors for selected and non selected data points
			Color AlphaSelected = Color.FromArgb(94, 65,140,240);
			Color AlphaNotSelected = Color.FromArgb(64, 224,64,10);

			// Probability value
			double probability;
			if( DropDownList1.SelectedItem.Text == "" )
				probability = 0.90;
			else
				probability = double.Parse( DropDownList1.SelectedItem.Text ) / 100.0;

			// Change probabiliti for two tail Students distribution
			if( !oneTail )
			{
				probability = ( probability + 1.0 ) / 2.0;
			}

			// Calculate students distribution
			double zValue;
			zValue = Chart1.DataManipulator.Statistics.InverseNormalDistribution( probability );

			ResultValue.Text = zValue.ToString("G5");

			// Go throw all data points and change color for selected points.
			foreach( DataPoint point in Chart1.Series[0].Points )
			{
				// Different selection for one tail and two tailes
				if( oneTail )
				{
					if( zValue < point.XValue )
					{
						point.Color = AlphaSelected;
					}
					else
					{
						point.Color = AlphaNotSelected;
					}
				}
				else
				{
					if( zValue < Math.Abs( point.XValue ) )
					{
						point.Color = AlphaSelected;
					}
					else
					{
						point.Color = AlphaNotSelected;
					}
				}
			}
		}

		/// <summary>
		/// Selection mode for students distribution
		/// </summary>
		private void SelectTDistribution( )
		{
			// One tailed normal distribution or two tails
			bool oneTail = CheckBox1.Checked;

			// Colors for selected and not selected data points
			Color AlphaSelected = Color.FromArgb(94, 65,140,240);
			Color AlphaNotSelected = Color.FromArgb(64, 224,64,10);


			// Probability value
			double probability;
			if( DropDownList1.SelectedItem.Text == "" )
				probability = 0.90;
			else
				probability = double.Parse( DropDownList1.SelectedItem.Text ) / 100.0;

			// Special case id probability is less then 50% with one tail
			bool probabilityLess50 = probability < 0.5 && oneTail;

			if( oneTail )
			{
				if( probabilityLess50 )
				{
					probability = 1 - ( 0.5 - probability) * 2;
				}
				else
				{
					probability = ( 1 - probability) * 2;
				}
			}
			else
			{
				probability = ( 1 - probability);
			}
			
			// Calculate Inverse students distribution
			double zValue = Chart1.DataManipulator.Statistics.InverseTDistribution( probability, int.Parse(DropDownList2.SelectedItem.Text) );

			if( probabilityLess50 )
			{
				zValue *= -1.0;
			}

			ResultValue.Text = zValue.ToString("G5");

			// Go throw all data points and change color for selected data points
			foreach( DataPoint point in Chart1.Series[0].Points )
			{
				if( oneTail )
				{
					if( zValue < point.XValue )
					{
						point.Color = AlphaSelected;
					}
					else
					{
						point.Color = AlphaNotSelected;
					}
				}
				else
				{
					if( zValue < Math.Abs( point.XValue ) )
					{
						point.Color = AlphaSelected;
					}
					else
					{
						point.Color = AlphaNotSelected;
					}
				}
			}
		}


		/// <summary>
		/// Selection mode for F distribution
		/// </summary>
		private void SelectFDistribution( )
		{
			// Set colors for selected and not selected data points
			Color AlphaSelected = Color.FromArgb(94, 65,140,240);
			Color AlphaNotSelected = Color.FromArgb(64, 224,64,10);

			// Probability value
			double probability;
			if( DropDownList1.SelectedItem.Text == "" )
				probability = 0.90;
			else
				probability = double.Parse( DropDownList1.SelectedItem.Text ) / 100.0;


			// Calculate Inverse F distribution
			double fValue;
			fValue = Chart1.DataManipulator.Statistics.InverseFDistribution( 1-probability, int.Parse(DropDownList2.SelectedItem.Text), int.Parse(DropDownList2.SelectedItem.Text) );

			ResultValue.Text = fValue.ToString("G5");

			// Go trow all data points and change color for selected points
			foreach( DataPoint point in Chart1.Series[0].Points )
			{
				if( fValue < point.XValue )
				{
					point.Color = AlphaSelected;
				}
				else
				{
					point.Color = AlphaNotSelected;
				}
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SelectDistribution();
		}

		private void SelectDistribution()
		{
			// Change color of data points which are not selected
			if( DropDownList.SelectedItem.Text == "Normal Distribution" )
			{
				SelectNormalDistribution();
			}
			else if( DropDownList.SelectedItem.Text == "T Distribution" )
			{
				SelectTDistribution();
			}
			else
			{
				SelectFDistribution( );
			}
			
		}

		private void SetDistribution()
		{
			// Fill data points with values from distributions
			if( DropDownList.SelectedItem.Text == "Normal Distribution" )
			{
				FillNormalDistribution( );
			}
			else if( DropDownList.SelectedItem.Text == "T Distribution" )
			{
				FillTDistribution( );
			}
			else
			{
				FillFDistribution( );
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetDistribution();
		}

		

		protected void Chart1_Load(object sender, System.EventArgs e)
		{
			
			SetDistribution();
		}
	}

}
