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
	/// Summary description for BasicChart.
	/// </summary>
	public partial class BasicChart : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			

			// Create new data series and set it's visual attributes
			Series series = new Series("Spline");
			series.ChartType = SeriesChartType.Spline;
			series.BorderWidth = 3;
			series.ShadowOffset = 2;

			// Populate new series with data
			series.Points.AddY(67);
			series.Points.AddY(57);
			series.Points.AddY(83);
			series.Points.AddY(23);
			series.Points.AddY(70);
			series.Points.AddY(60);
			series.Points.AddY(90);
			series.Points.AddY(20);

			// Add series into the chart's series collection
			Chart1.Series.Add(series);
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
