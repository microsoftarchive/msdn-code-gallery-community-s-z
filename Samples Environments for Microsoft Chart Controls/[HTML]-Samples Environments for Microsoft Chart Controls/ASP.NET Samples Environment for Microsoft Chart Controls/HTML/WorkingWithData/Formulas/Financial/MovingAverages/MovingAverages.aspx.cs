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
    public partial class MovingAverages : System.Web.UI.Page
	{	
		protected void Page_Load(object sender, System.EventArgs e)
		{

            if (!this.IsPostBack)
            {
                // Set all cells image transp color to red
                for (int i = 1; i < 5; i++)
                {
                    Chart1.Legends["Default"].CustomItems[i].Cells[0].ImageTransparentColor = Color.Red;
                }

                // Set image for all custom items
                Chart1.Legends["Default"].CustomItems[1].Cells[0].Image = @"chk_checked.png";
                Chart1.Legends["Default"].CustomItems[2].Cells[0].Image = @"chk_checked.png";
                Chart1.Legends["Default"].CustomItems[3].Cells[0].Image = @"chk_checked.png";
                Chart1.Legends["Default"].CustomItems[4].Cells[0].Image = @"chk_checked.png";
                
                Chart1.Legends["Default"].CustomItems[1].PostBackValue = "LegendClick/1";
                Chart1.Legends["Default"].CustomItems[2].PostBackValue = "LegendClick/2";
                Chart1.Legends["Default"].CustomItems[3].PostBackValue = "LegendClick/3";
                Chart1.Legends["Default"].CustomItems[4].PostBackValue = "LegendClick/4";
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
        
		/// <summary>
		/// This method calculates different Moving Averages.
		/// </summary>
		private void Calculate()
		{
			string period = Period.SelectedItem.Value;
			
			Chart1.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage,period,"Input","Simple");
            SetSeriesAppearance("Simple");
		
			Chart1.DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage,period,"Input","Exponential");
            SetSeriesAppearance("Exponential");
		
			Chart1.DataManipulator.FinancialFormula(FinancialFormula.TriangularMovingAverage,period,"Input","Triangular");
            SetSeriesAppearance("Triangular");

			// Remove historical data
			if( HistoricalData.Checked && !IsStartedFromFirst.Checked )
				Chart1.DataManipulator.Filter( CompareMethod.LessThanOrEqualTo, Double.Parse(period)-1.0, "Triangular", "Triangular", "X" );
		
			Chart1.DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage,period,"Input","Weighted");
            SetSeriesAppearance("Weighted");
						
			// Remove historical data
			if( HistoricalData.Checked && !IsStartedFromFirst.Checked )
				Chart1.DataManipulator.Filter( CompareMethod.LessThanOrEqualTo, Double.Parse(period)-1.0, "Input", "Input", "X" );
		}

		/// <summary>
		/// This method generates random data.
		/// </summary>
		/// <param name="series"></param>
		private void Data( Series series )
		{
			Random rand;
			// Use a number to calculate a starting value for 
			// the pseudo-random number sequence
			rand = new Random(int.Parse(Random3.CommandArgument));

			// Generate 30 random y values.
			for( int index = 0; index < 30; index++ )
			{
				// Generate the first point
				series.Points.AddXY(index+1,0);
				series.Points[index].YValues[0] = 10;

				// Use previous point to calculate a next one.
				if( index > 0 )
					series.Points[index].YValues[0] = series.Points[index-1].YValues[0] + 4*rand.NextDouble() - 2;
			}
		}

		protected void Random3_Click(object sender, System.EventArgs e)
		{
			Random rand = new Random();
			Random3.CommandArgument = rand.Next().ToString();
            this.Prepare();
		}

		public void Prepare()
		{
            foreach (Series series in Chart1.Series)
                series.Points.Clear();

			// Generate rundom data
			Data( Chart1.Series["Input"] );

			// Set chart types for output data
			Chart1.Series["Input"].ChartType = SeriesChartType.Line;

			// Start from first property is true by default.
			Chart1.DataManipulator.IsStartFromFirst = IsStartedFromFirst.Checked;

			// Calculate Moving Averages
			Calculate();
		}

        // Helper method for setting series appearance
        private void SetSeriesAppearance(string seriesName)
        {
            Chart1.Series[seriesName].ChartArea = "Default";
            Chart1.Series[seriesName].ChartType = SeriesChartType.Line;
            Chart1.Series[seriesName].BorderWidth = 2;
            Chart1.Series[seriesName].ShadowOffset = 1;
            Chart1.Series[seriesName].ShadowColor = Color.FromArgb(254,64,64,64);
            Chart1.Series[seriesName].IsVisibleInLegend = false;
        }

        protected void Chart1_Click(object sender, ImageMapEventArgs e)
        {
            if (e.PostBackValue.StartsWith("LegendClick"))
            {
                int index = int.Parse(e.PostBackValue.Split('/')[1]);

                // Legend item result
                LegendItem legendItem = this.Chart1.Legends["Default"].CustomItems[index];

                // series item selected
                Series selectedSeries = this.Chart1.Series[index];

                if (selectedSeries.Enabled)
                {
                    selectedSeries.Enabled = false;
                    legendItem.Cells[0].Image = string.Format(@"chk_unchecked.png");
                    legendItem.Cells[0].ImageTransparentColor = Color.Red;
                }

                else
                {
                    selectedSeries.Enabled = true;
                    legendItem.Cells[0].Image = string.Format(@"chk_checked.png");
                    legendItem.Cells[0].ImageTransparentColor = Color.Red;
                }
                this.Prepare();
            }
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {
            this.Prepare();
        }
}
}
