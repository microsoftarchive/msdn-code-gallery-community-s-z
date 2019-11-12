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
	/// Summary description for PointWidthAndDepth1.
	/// </summary>
	public partial class PointWidthAndDepth: System.Web.UI.Page
	{


		private void UpdateChartData()
		{
			// Set 3D chart area flag if required
			Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = CheckBox3D.Checked;
			DropDownListDepth.Enabled = CheckBox3D.Checked;
			DropDownListGap.Enabled = CheckBox3D.Checked;
			CheckBoxClustered.Enabled = CheckBox3D.Checked;

			// Set 3D clustered series
			Chart1.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = !CheckBoxClustered.Checked;

			// Loop through all series
			foreach(Series ser in Chart1.Series)
			{
				ser["PixelPointWidth"] = DropDownListWidth.SelectedItem.Text;
				ser["PixelPointDepth"] = DropDownListDepth.SelectedItem.Text;
				ser["PixelPointGapDepth"] = DropDownListGap.SelectedItem.Text;
			}
		}
	
		protected void Page_Load(object sender, System.EventArgs e)
		{ 
			UpdateChartData();
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

		protected void DropDownListWidth_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateChartData();
		}

		protected void CheckBox3D_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateChartData();
		}

		protected void CheckBoxClustered_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateChartData();
		}

		protected void DropDownListDepth_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateChartData();
		}

		protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateChartData();
		}

	}
}
