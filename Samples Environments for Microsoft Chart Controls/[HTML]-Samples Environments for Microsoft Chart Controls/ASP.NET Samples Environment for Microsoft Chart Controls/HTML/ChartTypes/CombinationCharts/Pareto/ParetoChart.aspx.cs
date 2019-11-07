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
	/// Summary description for ParetoChart.
	/// </summary>
	public partial class ParetoChart : System.Web.UI.Page
	{
	
		private void RandomData(Series series, int numOfPoints)
		{
			Random rand;
			// Use a number to calculate a starting value for 
			// the pseudo-random number sequence
			rand = new Random(int.Parse(Random1.CommandArgument));

			// Generate random Y values
			for( int point = 0; point < numOfPoints; point++ )
			{
				series.Points.AddY( rand.Next(49)+1 );
			}
		}

		public void AfterLoad()
		{
			// Number of data points
			int numOfPoints = int.Parse( Num.SelectedItem.Value );

			// Generate rundom data
			RandomData( Chart1.Series["Default"], numOfPoints );

			// Make Pareto Chart
			MakeParetoChart( Chart1, "Default", "Pareto" );
						
			// Set chart types for output data
			Chart1.Series["Pareto"].ChartType = SeriesChartType.Line;

			// set the markers for each point of the Pareto Line
			Chart1.Series["Pareto"].IsValueShownAsLabel = true;
			Chart1.Series["Pareto"].MarkerColor = Color.Red;
			Chart1.Series["Pareto"].MarkerBorderColor = Color.MidnightBlue;
			Chart1.Series["Pareto"].MarkerStyle = MarkerStyle.Circle;
			Chart1.Series["Pareto"].MarkerSize = 8;
			Chart1.Series["Pareto"].LabelFormat = "0.#";  // format with one decimal and leading zero

			// Set Color of line Pareto chart
			Chart1.Series["Pareto"].Color = Color.FromArgb(252, 180, 65);

			// Show as 2D or 3D
			if(checkBoxShow3D.Checked)
			{
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

				// Set Color of line Pareto chart
				Chart1.Series["Pareto"].BorderWidth = 1;
				Chart1.Series["Pareto"]["ShowMarkerLines"] = "True";
			}
			else
			{
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
			}
		}

		void MakeParetoChart(Chart chart, string srcSeriesName, string destSeriesName)
		{

			// get name of the ChartAre of the source series
			string strChartArea = chart.Series[srcSeriesName].ChartArea;

			// ensure the source series is a column chart type
			chart.Series[srcSeriesName].ChartType = SeriesChartType.Column;

			// sort the data in the series to be by values in descending order
			chart.DataManipulator.Sort(PointSortOrder.Descending, srcSeriesName);

			// find the total of all points in the source series
			double total = 0.0;
			foreach (DataPoint pt in chart.Series[srcSeriesName].Points)
				total += pt.YValues[0];

			// set the max value on the primary axis to total
			chart.ChartAreas[strChartArea].AxisY.Maximum = total;

			// create the destination series and add it to the chart
			Series destSeries = new Series(destSeriesName);
			chart.Series.Add(destSeries);

			// ensure the destination series is a Line or Spline chart type
			destSeries.ChartType = SeriesChartType.Line;

			destSeries.BorderWidth = 3;

			// assign the series to the same chart area as the column chart
			destSeries.ChartArea = chart.Series[srcSeriesName].ChartArea;

			// assign this series to use the secondary axis and set it maximum to be 100%
			destSeries.YAxisType = AxisType.Secondary;
			chart.ChartAreas[strChartArea].AxisY2.Maximum = 100; 

			// locale specific percentage format with no decimals
			chart.ChartAreas[strChartArea].AxisY2.LabelStyle.Format = "P0";

			// turn off the end point values of the primary X axis
			chart.ChartAreas[strChartArea].AxisX.LabelStyle.IsEndLabelVisible = false;

			// for each point in the source series find % of total and assign to series
			double percentage = 0.0;

			foreach(DataPoint pt in chart.Series[srcSeriesName].Points)
			{
				percentage += (pt.YValues[0] / total * 100.0);
				destSeries.Points.Add(Math.Round(percentage,2));
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

		protected void Random1_Click(object sender, System.EventArgs e)
		{
			Random rand = new Random();
			Random1.CommandArgument = rand.Next().ToString();
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
		
		}

		protected void checkBoxShow3D_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
