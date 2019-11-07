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
using System.Drawing.Drawing2D;
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for ChartInDataPoint.
	/// </summary>
	public partial class ChartInDataPoint : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;


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
			this.Chart1.PrePaint +=new EventHandler<ChartPaintEventArgs>(this.Chart1_PrePaint);
		}
		#endregion
	
	
		/// <summary>
		/// Creates a mini-chart in the data points of the original Point or Bubble chart.
		/// </summary>
		/// <param name="chart">Chart object.</param>
		/// <param name="series">Original data series.</param>
		/// <param name="chartType">Mini-chart type.</param>
		public void CreateChartInSeriesPoints(Chart chart, Series series, string chartType)
		{
			//****************************************************
			//** Create chart area for each data point
			//****************************************************
			int	pointIndex = 0;
			Random	random = new Random();
			foreach(DataPoint point in series.Points)
			{
				// Skip empty points
				if(!point.IsEmpty)
				{
					//****************************************************
					//** Create chart area and set visual attributes
					//****************************************************
					ChartArea areaPoint = chart.ChartAreas.Add(series.Name + "_" + pointIndex.ToString());
					areaPoint.BackColor = Color.Transparent;
					areaPoint.BorderWidth = 0;
					areaPoint.AxisX.LineWidth = 0;
					areaPoint.AxisY.LineWidth = 0;
					areaPoint.AxisX.MajorGrid.Enabled = false;
					areaPoint.AxisX.MajorTickMark.Enabled = false;
					areaPoint.AxisX.LabelStyle.Enabled = false;
					areaPoint.AxisY.MajorGrid.Enabled = false;
					areaPoint.AxisY.MajorTickMark.Enabled = false;
					areaPoint.AxisY.LabelStyle.Enabled = false;
					areaPoint.Position.Auto = false;

					//****************************************************
					//** Create data series in the chart area
					//****************************************************
					Series seriesPoint = chart.Series.Add(series.Name + "_" + pointIndex.ToString());
					seriesPoint.ChartArea = areaPoint.Name;
					seriesPoint.ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), chartType, true );
					seriesPoint.IsVisibleInLegend = false;
					seriesPoint.BorderColor = Color.FromArgb(64,64,64);
					seriesPoint.ShadowOffset = 2;
					seriesPoint.Palette = ChartColorPalette.Pastel;

					//****************************************************
					//** Populate data series.
					//** TODO: For this sample each series is populated
					//** with random data. Do your own series population
					//** here.
					//****************************************************
					for(int sliceIndex = 0; sliceIndex < 5; sliceIndex++)
					{
						seriesPoint.Points.AddY(random.Next(2,20));
					}

					// Increase point index
					++pointIndex;
				}
			}
		}

		/// <summary>
		/// Position new chart areas with mini-chart over the data points
		/// </summary>
		/// <param name="chart">Chart object.</param>
		/// <param name="series">Original data series.</param>
		public void PositionChartAreas(Chart chart, Series series)
		{
			//****************************************************
			//** Check if series uses X values or they all set
			//** to zeros (in this case use point index as X value)
			//****************************************************
			bool	zeroXValues = true;
			foreach(DataPoint point in series.Points)
			{
				if(point.XValue != 0.0)
				{
					zeroXValues = false;
					break;
				}
			}

			//****************************************************
			//** Calculate bubble scaling variables required to
			//** for the bubble size calculations.
			//****************************************************
			bool	bubbleChart = false;

			// Minimum/Maximum bubble size
			double	maxPossibleBubbleSize = 15F;
			double	minPossibleBubbleSize = 3F;
			float	maxBubleSize = 0f;
			float	minBubleSize = -20f;

			// Current min/max size of the bubble size
			double	minAll = double.MaxValue;
			double	maxAll = double.MinValue;

			// Bubble size difference value
			double	valueDiff = 0;
			double	valueScale = 1;

			// Check for the Bubble chart type
			if( series.ChartType == SeriesChartType.Bubble )
			{
				bubbleChart = true;

				// Check if custom attributes are set to specify scale
				if(series.IsCustomPropertySet("BubbleScaleMin"))
				{
					minAll = Math.Min(minAll, Double.Parse(series["BubbleScaleMin"]));
				}
				if(series.IsCustomPropertySet("BubbleScaleMax"))
				{
					maxAll = Math.Max(maxAll, Double.Parse(series["BubbleScaleMax"]));
				}

				// Calculate bubble scale
				double	minSer = double.MaxValue;
				double	maxSer = double.MinValue;
				foreach( Series ser in chart.Series )
				{
					if( ser.ChartType == SeriesChartType.Bubble && ser.ChartArea == series.ChartArea )
					{
						foreach(DataPoint point in ser.Points)
						{
							minSer = Math.Min(minSer, point.YValues[1]);
							maxSer = Math.Max(maxSer, point.YValues[1]);
						}
					}
				}
				if(minAll == double.MaxValue)
				{
					minAll = minSer;
				}
				if(maxAll == double.MinValue)
				{
					maxAll = maxSer;
				}

				// Calculate maximum bubble size
				SizeF areaSize = chart.ChartAreas[series.ChartArea].Position.Size;

				// Convert relative coordinates to absolute coordinates
				areaSize.Width = (float)(areaSize.Width * (chart.Width.Value - 1)) / 100F; 
				areaSize.Height = (float)(areaSize.Height * (chart.Height.Value - 1)) / 100F; 
				maxBubleSize = (float)(Math.Min(areaSize.Width, areaSize.Height) / (100.0/maxPossibleBubbleSize));
				minBubleSize = (float)(Math.Min(areaSize.Width, areaSize.Height) / (100.0/minPossibleBubbleSize));

				// Calculate scaling variables depending on the Min/Max values
				if(maxAll == minAll)
				{
					valueScale = 1;
					valueDiff = minAll - (maxBubleSize - minBubleSize)/2f;
				}
				else
				{
					valueScale = (maxBubleSize - minBubleSize) / (maxAll - minAll);
					valueDiff = minAll;
				}
			}


			//****************************************************
			//** Create chart area for each data point
			//****************************************************
			int	pointIndex = 0;
			Random	random = new Random();
			foreach(DataPoint point in series.Points)
			{
				// Get chart area
				ChartArea areaPoint = chart.ChartAreas[series.Name + "_" + pointIndex.ToString()];


				//****************************************************
				//** Set chart area position and inner plot position
				//****************************************************

				// Set chart area inner plot position
				areaPoint.InnerPlotPosition = new ElementPosition(3, 3, 94, 94);
				
				// Position chart area over the data point
				PointF position = PointF.Empty;
				position.X = (float)chart.ChartAreas[series.ChartArea].AxisX.GetPosition(zeroXValues ? (pointIndex + 1) : point.XValue);
				position.Y = (float)chart.ChartAreas[series.ChartArea].AxisY.GetPosition(point.YValues[0]);

				float pieSize = (point.MarkerSize < 15) ? 15 : point.MarkerSize;;
				if(bubbleChart)
				{
					pieSize = (float)((point.YValues[1] - valueDiff) * valueScale) + minBubleSize;
				}
				pieSize = pieSize * 100F / ((float)(chart.Width.Value - 1)); 
				areaPoint.Position = new ElementPosition(position.X - pieSize/2f, position.Y - pieSize/2f, pieSize, pieSize);

				// Increase point index
				++pointIndex;
			}
		}

		private void Chart1_PrePaint(object sender, System.Web.UI.DataVisualization.Charting.ChartPaintEventArgs e)
		{
            if (e.ChartElement is Chart)
            {
                // Creare mini-chart inside each series
                if (Series2.SelectedItem.Value != "None")
                {
                    // Position new chart areas with mini-chart over the data points
                    PositionChartAreas(Chart1, Chart1.Series["Default"]);
                }
            }
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Set original series chart type
			Chart1.Series["Default"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), Series1.SelectedItem.Value, true );

			// Show as 2D or 3D
			if(Show3D.Checked)
			{
				foreach(ChartArea myChartArea in Chart1.ChartAreas)
				{
					if(myChartArea.Name=="Default")
					{
						myChartArea.BackColor = Color.LightGray;
						myChartArea.BorderColor = Color.Gray;
					}
					myChartArea.Area3DStyle.Enable3D = true;					
				}
				foreach(Series mySeries in Chart1.Series)
				{
					mySeries.Color = Color.Transparent;
					mySeries.BorderColor = Color.Transparent;
				}
				CheckBoxHideOriginal.Enabled = false;
			
			}
			else
			{
				foreach(ChartArea myChartArea in Chart1.ChartAreas)
				{
					myChartArea.Area3DStyle.Enable3D = false;
				}
				CheckBoxHideOriginal.Enabled = true;
			}

			// Creare mini-chart inside each series
			if(Series2.SelectedItem.Value != "None")
			{
				// Create charts for each data point
				CreateChartInSeriesPoints(Chart1, Chart1.Series["Default"], Series2.SelectedItem.Value);

				// Hide original series
				if(CheckBoxHideOriginal.Checked)
				{
					Chart1.Series["Default"].Color = Color.Transparent;
					Chart1.Series["Default"].ShadowOffset = 0;
					Chart1.Series["Default"].BorderColor = Color.Transparent;
				}
			}


		}
	

	}	

}
