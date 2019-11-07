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
	public partial class CrossingAndReverse : System.Web.UI.Page
	{
		

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			System.Web.UI.DataVisualization.Charting.Axis AxisX;
			System.Web.UI.DataVisualization.Charting.Axis AxisY;

			AxisX = Chart1.ChartAreas["ChartArea1"].AxisX;
			AxisY = Chart1.ChartAreas["ChartArea1"].AxisY;


			// Set Crossing value for X axis
			switch ( CrossingX.SelectedItem.Value )
			{
				case "Auto":
					AxisX.Crossing = Double.NaN;
					break;
				case "Maximum":
					AxisX.Crossing = Double.MaxValue;
					break;
				case "Minimum":
					AxisX.Crossing = Double.MinValue;
					break;
				default:
					AxisX.Crossing = Double.Parse( CrossingX.SelectedItem.Value );
					break;
			}

			// Set Reverse value for X axis
			AxisX.IsReversed = ReverseXAxis.Checked;

			// Set Crossing value for Y axis
			switch ( CrossingY.SelectedItem.Value )
			{
				case "Auto":
					AxisY.Crossing = Double.NaN;
					break;
				case "Maximum":
					AxisY.Crossing = Double.MaxValue;
					break;
				case "Minimum":
					AxisY.Crossing = Double.MinValue;
					break;
				default:
					AxisY.Crossing = Double.Parse( CrossingY.SelectedItem.Value );
					break;
			}

			// Set Reverse value for Y axis
			AxisY.IsReversed = ReverseYAxis.Checked;

			// Set Chart type
			foreach( Series series in Chart1.Series)
			{
				if(this.ChartType.SelectedIndex >= 0)
				{
					series.ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), this.ChartType.SelectedItem.ToString(), true );
				}
				else
				{
					series.ChartType = SeriesChartType.Column;
				}
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

		
	
	}	
}
