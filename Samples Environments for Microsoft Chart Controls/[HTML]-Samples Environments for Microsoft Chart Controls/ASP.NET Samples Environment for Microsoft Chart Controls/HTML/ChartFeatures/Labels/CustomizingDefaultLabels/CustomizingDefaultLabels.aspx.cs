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
	/// Summary description for CustomizingDefaultLabels.
	/// </summary>
	public partial class CustomizingDefaultLabels : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data
			Random		random = new Random();
			DateTime	dateCurrent = DateTime.Now.Date;
			for(int pointIndex = 0; pointIndex < 7; pointIndex++)
			{
				foreach( Series series in Chart1.Series)
				{
					series.Points.AddXY(dateCurrent.AddDays(pointIndex), random.Next( 1000, 9000)/100.0);
				}
				//Chart1.Series["Series1"].Points.AddXY(dateCurrent.AddDays(pointIndex), random.Next(30, 9000)/100.0);
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
			this.Chart1.Customize +=new EventHandler(this.Chart1_Customize); 
		}
		#endregion

		private void Chart1_Customize(Object sender, EventArgs args)
		{
			// Get X and Y axis labels collections
			CustomLabelsCollection xAxisLabels = Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels;
			CustomLabelsCollection yAxisLabels = Chart1.ChartAreas["ChartArea1"].AxisY.CustomLabels;

			// Change text of the first Y axis label
			yAxisLabels[0].Text = "Zero";

			// Change Y axis labels
			for(int labelIndex = 1; labelIndex < yAxisLabels.Count; labelIndex++)
			{
				yAxisLabels[labelIndex].Text = yAxisLabels[labelIndex].Text + "°. 00'";
			}


			// Remove each second X axis label
			for(int labelIndex = 0; labelIndex < xAxisLabels.Count; labelIndex++)
			{
				// Adjust position of the previous label
				if(labelIndex > 0)
				{
					xAxisLabels[labelIndex - 1].ToPosition += (xAxisLabels[labelIndex].ToPosition - xAxisLabels[labelIndex].FromPosition) / 2.0;
					xAxisLabels[labelIndex - 1].FromPosition -= (xAxisLabels[labelIndex].ToPosition - xAxisLabels[labelIndex].FromPosition) / 2.0;
				}

				// Remove label
				xAxisLabels.RemoveAt(labelIndex);
			}
		}
	}
}
