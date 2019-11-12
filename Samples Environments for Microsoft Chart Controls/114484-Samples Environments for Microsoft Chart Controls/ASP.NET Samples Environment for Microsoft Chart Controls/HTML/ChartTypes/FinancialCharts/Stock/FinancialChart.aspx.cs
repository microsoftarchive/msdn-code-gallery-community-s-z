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
	/// Summary description for FinancialChart.
	/// </summary>
	public partial class FinancialChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			
			ChartTypeList.Enabled = true;
			ShowCloseOnly.Enabled = true;
			OpenCloseMarks.Enabled = true;

			if ( !this.IsPostBack )
			{
				
				// Add custom legend items
				LegendItem legendItem = new LegendItem(); 
				legendItem.Name = "Dividend";
				legendItem.ImageStyle = LegendImageStyle.Marker;
				legendItem.MarkerImageTransparentColor = Color.White;
				legendItem.MarkerImage = "DividentLegend.bmp";
				Chart1.Legends[0].CustomItems.Add(legendItem);

				legendItem = new LegendItem(); 
				legendItem.Name = "Split";
				legendItem.ImageStyle = LegendImageStyle.Marker;
				legendItem.MarkerImageTransparentColor = Color.White;
				legendItem.MarkerImage = "SplitLegend.bmp";
				Chart1.Legends[0].CustomItems.Add(legendItem);
				
				// Populate series data
				FillData();
			}

			// Set series chart type
			Chart1.Series["Price"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), ChartTypeList.SelectedItem.Text, true );

			// Set stock chart attributes
			if(ChartTypeList.SelectedItem.Text == "Stock")
			{
				OpenCloseMarks.Enabled = true;
				ShowCloseOnly.Enabled = true;
				Chart1.Series["Price"]["OpenCloseStyle"] = OpenCloseMarks.SelectedItem.Text;
				if(ShowCloseOnly.Checked)
				{
					Chart1.Series["Price"]["ShowOpenClose"] = "Close";
				}
				else
				{
					Chart1.Series["Price"]["ShowOpenClose"] = "true";
				}

				Chart1.Series["Price"]["PointWidth"] = "1.0";
			}
			else
			{
				Chart1.Series["Price"]["PointWidth"] = "0.8";
				OpenCloseMarks.Enabled = false;
				ShowCloseOnly.Enabled = false;
			}

			Chart1.Series["Volume"]["PointWidth"] = "0.5";

		}

		/// <summary>
		/// Random Stock Data Generator
		/// </summary>
		private void FillData()
		{
			Random rand;
			// Use a number to calculate a starting value for 
			// the pseudo-random number sequence
			rand = new Random();
			
			// The number of days for stock data
			int period = 60;

			// The first High value
			double high = rand.NextDouble() * 40;
			if(high <  1)
				high += 1;

			// The first Close value
			double close = high - rand.NextDouble();

			// The first Low value
			double low = close - rand.NextDouble();

			// The first Open value
			double open = ( high - low ) * rand.NextDouble() + low;

			// The first Volume value
			double volume = 100 + 15 * rand.NextDouble();
						
			// The first day X and Y values
			Chart1.Series["Price"].Points.AddXY(DateTime.Parse("1/2/2002"), high);
			Chart1.Series["Volume"].Points.AddXY(DateTime.Parse("1/2/2002"), volume);
			Chart1.Series["Price"].Points[0].YValues[1] = low;

			// The Open value is not used.
			Chart1.Series["Price"].Points[0].YValues[2] = open;
			Chart1.Series["Price"].Points[0].YValues[3] = close;
			
			// Days loop
			for( int day = 1; day <= period; day++ )
			{
			
				// Calculate High, Low and Close values
				high = Chart1.Series["Price"].Points[day-1].YValues[2]+rand.NextDouble();
				close = high - rand.NextDouble();
				low = close - rand.NextDouble();
				open = ( high - low ) * rand.NextDouble() + low;
				
				// Calculate volume
				volume = Chart1.Series["Volume"].Points[day-1].YValues[0] + 10 * rand.NextDouble() - 5;

				// The low cannot be less than yesterday close value.
				if( low > Chart1.Series["Price"].Points[day-1].YValues[2])
					low = Chart1.Series["Price"].Points[day-1].YValues[2];
							
				// Set data points values
				Chart1.Series["Price"].Points.AddXY(day, high);
				Chart1.Series["Price"].Points[day].XValue = Chart1.Series["Price"].Points[day-1].XValue+1;
				Chart1.Series["Price"].Points[day].YValues[1] = low;
				Chart1.Series["Price"].Points[day].YValues[2] = open;
				Chart1.Series["Price"].Points[day].YValues[3] = close;

				// Set volume values
				Chart1.Series["Volume"].Points.AddXY(day, volume);
				Chart1.Series["Volume"].Points[day].XValue = Chart1.Series["Volume"].Points[day-1].XValue+1;
			}

			// Randomly set dividend and split markers
			Random	random = new Random();
			
				
			for(int index = 0; index < 2; index ++)
			{
				
				int pointIndex = random.Next(0, Chart1.Series["Price"].Points.Count);
				
				Chart1.Series["Price"].Points[pointIndex].MarkerImage = "DividentMarker.bmp";
				Chart1.Series["Price"].Points[pointIndex].MarkerImageTransparentColor = Color.White;
				Chart1.Series["Price"].Points[pointIndex].ToolTip = "#VALX{D}\n0.15 - dividend per share";

				pointIndex = random.Next(0, Chart1.Series["Price"].Points.Count);
				
				Chart1.Series["Price"].Points[pointIndex].MarkerImage = "SplitMarker.bmp";
				Chart1.Series["Price"].Points[pointIndex].MarkerImageTransparentColor = Color.White;
				Chart1.Series["Price"].Points[pointIndex].ToolTip = "#VALX{D}\n2 for 1 split";
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
	}
}
