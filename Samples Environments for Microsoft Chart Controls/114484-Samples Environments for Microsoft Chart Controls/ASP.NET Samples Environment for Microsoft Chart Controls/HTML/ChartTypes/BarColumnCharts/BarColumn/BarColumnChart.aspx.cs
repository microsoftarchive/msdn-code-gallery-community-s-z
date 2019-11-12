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
	public partial class BarColumnChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Set series chart type
			if(ChartType.SelectedItem.ToString() == "Bar")
			{
				Chart1.Series["Series1"].ChartType = SeriesChartType.Bar;
				Chart1.Series["Series2"].ChartType = SeriesChartType.Bar;
				Chart1.Titles[0].Text = "Bar Chart";
			}
			else
			{
				Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
				Chart1.Series["Series2"].ChartType = SeriesChartType.Column;
				Chart1.Titles[0].Text = "Column Chart";
			}

			// Set point width of the series
			Chart1.Series["Series1"]["PointWidth"] = BarWidthList.SelectedItem.Text;
			Chart1.Series["Series2"]["PointWidth"] = BarWidthList.SelectedItem.Text;

			// Set drawing style
			Chart1.Series["Series1"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;
			Chart1.Series["Series2"]["DrawingStyle"] = this.DrawingStyle.SelectedItem.Text;

			// Show as 2D or 3D
			if(Show3D.Checked)
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

			else
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
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
