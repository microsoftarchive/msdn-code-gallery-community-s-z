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
	/// Summary description for LabelsTextStyle.
	/// </summary>
	public partial class LabelsTextStyle : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Disable axis labels text auto fitting
			Chart1.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = false;

			// Set axis labels font
			Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font(FontNameList.SelectedItem.Text, int.Parse(FontSizeList.SelectedItem.Text));

			// Set axis labels angle
			FontAngleList.Enabled = !OffsetLabels.Checked;
			Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = int.Parse(FontAngleList.SelectedItem.Text);

			// Set offset labels style
			Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsStaggered = OffsetLabels.Checked;

			// Disable X axis labels
			Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = EnableLabels.Checked;

			// Enable AntiAliasing for either Text and Graphics or just Graphics
			if(TextAntiAlias.Checked)
				Chart1.AntiAliasing = AntiAliasingStyles.All;
			else
				Chart1.AntiAliasing = AntiAliasingStyles.Graphics;
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
