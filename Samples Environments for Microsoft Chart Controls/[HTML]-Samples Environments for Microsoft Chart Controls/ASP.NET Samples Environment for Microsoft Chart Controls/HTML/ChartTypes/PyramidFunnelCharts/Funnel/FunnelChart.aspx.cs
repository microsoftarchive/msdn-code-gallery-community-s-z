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
	/// Summary description for FunnelChart.
	/// </summary>
	public partial class FunnelChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ExplodedPointList;
		protected System.Web.UI.WebControls.DropDownList HoleSizeList;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Bind chart data
			double[]	yValues1 = new double[] { 216.1, 125.8, 2.6, 97.3, 45.7, 25.3 };
			double[]	yValues2 = new double[] { 232.8, 195.4, 172.9, 100.3, 45.7, 25.3 };
			Chart1.Series["Default"].Points.DataBindY( (FunnelStyleList.SelectedIndex == 0) ? yValues1 : yValues2);
			
			// Set funnel style
			Chart1.Series["Default"]["FunnelStyle"] = FunnelStyleList.SelectedItem.Text;

			// Set funnel data point labels style
			Chart1.Series["Default"]["FunnelLabelStyle"] = LabelStyleList.SelectedItem.Text;

			// Set labels placement
			if(LabelStyleList.SelectedIndex == 0 ||
				LabelStyleList.SelectedIndex == 1)
			{
				Chart1.Series["Default"]["FunnelOutsideLabelPlacement"] = LabelPlacementList.SelectedItem.Text;
			}
			else
			{
				Chart1.Series["Default"]["FunnelInsideLabelAlignment"] = LabelPlacementList.SelectedItem.Text;
			}

			// Set gap between points
			Chart1.Series["Default"]["FunnelPointGap"] = PointGapList.SelectedItem.Text;

			// Set minimum point height
			Chart1.Series["Default"]["FunnelMinPointHeight"] = MinPointHeight.SelectedItem.Text;
			
			// Set 3D mode
			Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = checkBoxShow3D.Checked;

			// Set 3D angle
			Chart1.Series["Default"]["Funnel3DRotationAngle"] = RotationAngleList.SelectedItem.Text;

			// Set 3D drawing style
			Chart1.Series["Default"]["Funnel3DDrawingStyle"] = DrawingstyleList.SelectedItem.Text;

			// Disable/Enable controls
			RotationAngleList.Enabled = checkBoxShow3D.Checked;
			DrawingstyleList.Enabled = checkBoxShow3D.Checked;
			LabelPlacementList.Enabled = LabelStyleList.SelectedIndex != 3;
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

		protected void LabelStyleList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(LabelStyleList.SelectedIndex == 0 ||
				LabelStyleList.SelectedIndex == 1)
			{
				LabelPlacementList.Items.Clear();
				LabelPlacementList.Items.Add("Right");
				LabelPlacementList.Items.Add("Left");
				LabelPlacementList.Items[0].Selected = true;
				Chart1.Series["Default"]["FunnelOutsideLabelPlacement"] = LabelPlacementList.SelectedItem.Text;
			}
			else
			{
				LabelPlacementList.Items.Clear();
				LabelPlacementList.Items.Add("Center");
				LabelPlacementList.Items.Add("Top");
				LabelPlacementList.Items.Add("Bottom");
				LabelPlacementList.Items[0].Selected = true;
				Chart1.Series["Default"]["FunnelInsideLabelAlignment"] = LabelPlacementList.SelectedItem.Text;
			}
		}
	}
}
