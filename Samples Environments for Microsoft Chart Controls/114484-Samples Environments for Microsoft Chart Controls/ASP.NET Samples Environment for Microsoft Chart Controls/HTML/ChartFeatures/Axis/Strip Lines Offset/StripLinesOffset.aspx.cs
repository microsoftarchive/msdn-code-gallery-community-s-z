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
	public partial class StripLinesOffset : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			if ( !this.IsPostBack )
			{
				this.FillData();
			}
			

			// Get a strip line reference
			StripLine stripLine = Chart1.ChartAreas["ChartArea1"].AxisX.StripLines[0];
			
			// Set strip line interval
			stripLine.Interval = double.Parse( Interval.SelectedItem.Value );

			// Set strip line offset
			stripLine.IntervalOffset = double.Parse( IntervalOffset.SelectedItem.Value );

			// Set Strip Width
			stripLine.StripWidth = double.Parse( StripWidth.SelectedItem.Value );

			// Set strip line interval type
			stripLine.IntervalType = ( DateTimeIntervalType )Enum.Parse( typeof( DateTimeIntervalType ), IntervalType.SelectedItem.Value, true );

			// Set strip line offset type
			stripLine.IntervalOffsetType = ( DateTimeIntervalType )Enum.Parse( typeof( DateTimeIntervalType ), IntervalOffsetType.SelectedItem.Value, true );

			// Set strip line width
			stripLine.StripWidthType = ( DateTimeIntervalType )Enum.Parse( typeof( DateTimeIntervalType ), StripWidthType.SelectedItem.Value, true );

			
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

		private void FillData()
		{
			Random rand;
			// Use a number to calculate a starting value for 
			// the pseudo-random number sequence
			rand = new Random();
			
			// The number of days for stock data
			int period = 120;

			// The first High value
			double high = rand.NextDouble() * 40;

			// The first Close value
			double close = high - rand.NextDouble();

			// The first Low value
			double low = close - rand.NextDouble();

			// The first Open value
			double open = ( high - low ) * rand.NextDouble() + low;

			// The first day X and Y values
			Chart1.Series[0].Points.AddXY(DateTime.Parse("1/2/2002"), high);
			Chart1.Series[0].Points[0].YValues[1] = low;

			// The Open value is not used.
			Chart1.Series[0].Points[0].YValues[2] = open;
			Chart1.Series[0].Points[0].YValues[3] = close;
			
			// Days loop
			for( int day = 1; day <= period; day++ )
			{
			
				// Calculate High, Low and Close values
				high = Chart1.Series[0].Points[day-1].YValues[2]+rand.NextDouble();
				close = high - rand.NextDouble();
				low = close - rand.NextDouble();
				open = ( high - low ) * rand.NextDouble() + low;
				
				// The low cannot be less than yesterday close value.
				if( low > Chart1.Series[0].Points[day-1].YValues[2])
					low = Chart1.Series[0].Points[day-1].YValues[2];
							
				// Set data points values
				Chart1.Series[0].Points.AddXY(day, high);
				Chart1.Series[0].Points[day].XValue = Chart1.Series[0].Points[day-1].XValue+1;
				Chart1.Series[0].Points[day].YValues[1] = low;
				Chart1.Series[0].Points[day].YValues[2] = open;
				Chart1.Series[0].Points[day].YValues[3] = close;

			}
		}


	}	
}
