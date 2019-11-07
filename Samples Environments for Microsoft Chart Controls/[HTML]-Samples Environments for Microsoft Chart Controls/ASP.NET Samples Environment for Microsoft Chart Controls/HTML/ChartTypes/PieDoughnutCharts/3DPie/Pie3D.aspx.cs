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
	/// Summary description for Pie3D.
	/// </summary>
	public partial class Pie3D : System.Web.UI.Page
	{
		# region Fields

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;

		#endregion
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
				// Populate series data
				double[]	yValues = {65.62, 75.54, 60.45, 55.73, 70.42};
				string[]	xValues = {"France", "Canada", "UK", "USA", "Italy"};
				Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);
			

			if (this.ChartTypeList.SelectedItem.ToString() == "Pie")
                Chart1.Series["Default"].ChartType = SeriesChartType.Pie;

			else
				Chart1.Series["Default"].ChartType = SeriesChartType.Doughnut;

			if (this.ShowLegend.Checked)
				Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";

			else
                Chart1.Series["Default"]["PieLabelStyle"] = "Inside";

			// Set chart type and title
			Chart1.Series["Default"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), this.ChartTypeList.SelectedItem.ToString(), true );
			Chart1.Titles[0].Text = ChartTypeList.SelectedItem.ToString() + " Chart";

			// Set labels style
			Chart1.Series["Default"]["PieLabelStyle"] = this.LabelStyleList.SelectedItem.ToString();

			// Set Doughnut hole size
			Chart1.Series["Default"]["DoughnutRadius"] = this.HoleSizeList.SelectedItem.ToString();

			// Disable Doughnut hole size control for Pie chart
			this.HoleSizeList.Enabled = (this.ChartTypeList.SelectedItem.ToString() != "Pie");

			// Explode selected country
			foreach(DataPoint point in Chart1.Series["Default"].Points)
			{
				point["Exploded"] = "false";
				if(point.AxisLabel == this.ExplodedPointList.SelectedItem.ToString())
				{
					point["Exploded"] = "true";
				}
			}

			// Enable 3D
			Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = CheckboxShow3D.Checked;

			Chart1.Series[0]["PieDrawingStyle"] = this.Dropdownlist1.SelectedItem.ToString();

			// Pie drawing style
			if (this.CheckboxShow3D.Checked)
				this.Dropdownlist1.Enabled = false;
			
			else
				this.Dropdownlist1.Enabled = true;

            if (this.ShowLegend.Checked)
                this.Chart1.Legends[0].Enabled = true;
            else
                this.Chart1.Legends[0].Enabled = false;

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
