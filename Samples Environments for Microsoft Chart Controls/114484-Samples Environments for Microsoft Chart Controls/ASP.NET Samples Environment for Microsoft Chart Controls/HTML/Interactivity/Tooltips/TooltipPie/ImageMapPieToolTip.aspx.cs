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


namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for ImageMapPieToolTip.
	/// </summary>
	public partial class ImageMapPieToolTip : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Add series to the chart
			Series series = Chart1.Series.Add("My series");

			// Set series visual attributes
			series.ChartType = SeriesChartType.Pie;
			series.ShadowOffset = 2;
			series.Font = new Font("Times New Format", 7f );
			series.BorderColor = Color.DarkGray;
			//series.CustomAttributes = "LabelStyle=Outside";

			// Set series and legend tooltips
			series.ToolTip = "#LEGENDTEXT: #VAL{C} million";
			series.LegendToolTip = "#PERCENT";
			series.PostBackValue = "#INDEX";
			series.LegendPostBackValue = "#INDEX";
			Chart1.Titles[0].Text = "National Expenditures";
			
			// Populate series data
			double[]	yValues = {65.62, 75.54, 60.45, 34.73, 85.42, 32.12, 55.18, 67.15, 56.24, 23.65};
			string[]	xValues = {"France", "Canada", "Germany", "USA", "Italy", "Russia", "China", "Japan", "Sweden", "Spain" };
			series.Points.DataBindY(yValues);

			for( int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++ )
			{
				series.Points[ pointIndex ].LegendText = xValues[ pointIndex ];
			}
            
            if (!this.IsPostBack)
            {
                series.Points[0].CustomProperties += "Exploded=true";
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

        protected void Chart1_Click(object sender, ImageMapEventArgs e)
        {
            int pointIndex = int.Parse(e.PostBackValue);
            Series series = Chart1.Series["My series"];
            if (pointIndex >= 0 && pointIndex < series.Points.Count)
            {
                series.Points[pointIndex].CustomProperties += "Exploded=true";
            }
        }
    }
}
