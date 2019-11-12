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
	/// Summary description for CombinatorialChart.
	/// </summary>
	public partial class CombinatorialChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data with random data
			Random	random = new Random();
			for(int pointIndex = 0; pointIndex < 10; pointIndex++)
			{
				Chart1.Series["Series1"].Points.AddY(random.Next(5, 95));
				Chart1.Series["Series2"].Points.AddY(random.Next(5, 95));
				Chart1.Series["Series3"].Points.AddY(random.Next(5, 95));
			}

			// Set series chart types
			Chart1.Series["Series1"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), Series1TypeList.SelectedItem.Text, true );
			Chart1.Series["Series2"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), Series2TypeList.SelectedItem.Text, true );
			Chart1.Series["Series3"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), Series3TypeList.SelectedItem.Text, true );

			// Disable/enable X axis margin
			Chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = ShowMargins.Checked;

			// Adjust all series appearance depending on the chart type
			foreach(Series series in Chart1.Series)
			{
				// Adjust border width 
				series.BorderWidth = 1;
				if(!Show3D.Checked)
				{
					if( series.ChartType == SeriesChartType.Line || series.ChartType == SeriesChartType.Spline || series.ChartType == SeriesChartType.StepLine )
					{
						series.BorderWidth = 3;
					}
				}

				// Disable shadow in area charts
				series.ShadowOffset = 2;
				if(series.ChartType == SeriesChartType.Area || series.ChartType == SeriesChartType.StackedArea || series.ChartType == SeriesChartType.SplineArea )
				{
					series.ShadowOffset = 0;
				}
			}
			
			// Show as 2D or 3D
			if(Show3D.Checked)
			{
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
			}
			else
			{
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
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
