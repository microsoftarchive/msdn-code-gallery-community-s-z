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
	/// Summary description for Cylinder3D.
	/// </summary>
	public partial class Cylinder3D : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Set Cylinder drawing style attribute
			Chart1.Series["Series1"]["DrawingStyle"] = "Cylinder";
			Chart1.Series["Series2"]["DrawingStyle"] = "Cylinder";
			Chart1.Series["Series3"]["DrawingStyle"] = "Cylinder";

			// Set series chart type
			if(Bar.Checked)
			{
				Chart1.Series["Series1"].ChartType = SeriesChartType.Bar;
				Chart1.Series["Series2"].ChartType = SeriesChartType.Bar;
				Chart1.Series["Series3"].ChartType = SeriesChartType.Bar;
				Chart1.Titles[0].Text = "3D Bar Cylinder";
			}
			else if (Column.Checked)
			{
				Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
				Chart1.Series["Series2"].ChartType = SeriesChartType.Column;
				Chart1.Series["Series3"].ChartType = SeriesChartType.Column;
				Chart1.Titles[0].Text = "3D Column Cylinder";
			}

			// Set clustered flag
			Chart1.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = !Clustered.Checked;

			// Set points depth
			if(pointDepth.SelectedItem.Text != "")
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.PointDepth = int.Parse(pointDepth.SelectedItem.Text);

			if(gapDepth.SelectedItem.Text != "")
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.PointGapDepth = int.Parse(gapDepth.SelectedItem.Text);

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
