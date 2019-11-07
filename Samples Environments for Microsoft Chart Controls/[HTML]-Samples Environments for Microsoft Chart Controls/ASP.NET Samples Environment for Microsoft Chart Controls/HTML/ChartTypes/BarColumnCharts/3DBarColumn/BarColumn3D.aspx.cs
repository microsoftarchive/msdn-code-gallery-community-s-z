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
	/// Summary description for BarColumn3D.
	/// </summary>
	public partial class BarColumn3D : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Set series chart type
			if(Bar.Checked)
			{
				Chart1.Series["Series1"].ChartType = SeriesChartType.Bar;
				Chart1.Series["Series2"].ChartType = SeriesChartType.Bar;
				Chart1.Series["Series3"].ChartType = SeriesChartType.Bar;
				Chart1.Titles[0].Text = "3D Bar Chart";
			}
			else if (Column.Checked)
			{
				Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
				Chart1.Series["Series2"].ChartType = SeriesChartType.Column;
				Chart1.Series["Series3"].ChartType = SeriesChartType.Column;
				Chart1.Titles[0].Text = "3D Column Chart";
			}

			// Show/Hide X axis end labels
			Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsEndLabelVisible = IsEndLabelVisible.Checked;

			// Set point width of the series
			Chart1.Series["Series1"]["PointWidth"] = BarWidthList.SelectedItem.Text;
			Chart1.Series["Series2"]["PointWidth"] = BarWidthList.SelectedItem.Text;
			Chart1.Series["Series3"]["PointWidth"] = BarWidthList.SelectedItem.Text;

			Chart1.ChartAreas["ChartArea1"].Area3DStyle.IsRightAngleAxes = RightAngledAxis.Checked;
			Chart1.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = !Clustered.Checked;

			// Set chart area 3D rotation
			if(RotateX.SelectedItem.Text != "")
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = int.Parse(RotateX.SelectedItem.Text);

			if(RotateY.SelectedItem.Text != "")
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = int.Parse(RotateY.SelectedItem.Text);

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
