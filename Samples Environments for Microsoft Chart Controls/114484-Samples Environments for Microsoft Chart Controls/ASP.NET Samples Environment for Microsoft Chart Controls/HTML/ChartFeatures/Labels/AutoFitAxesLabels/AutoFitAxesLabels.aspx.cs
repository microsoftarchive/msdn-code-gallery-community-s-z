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
	/// Summary description for AutoFitAxesLabels.
	/// </summary>
	public partial class AutoFitAxesLabels: System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
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

		private void UpdateAutoFitStyle()
		{
			Chart1.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;

			// Set X axis auto fit style
			Chart1.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.None;
			if(CheckBoxFontSize.Checked)
			{
				Chart1.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle |= 
					LabelAutoFitStyles.DecreaseFont | LabelAutoFitStyles.IncreaseFont;
			}
			if(CheckBoxOffset.Checked)
			{
				Chart1.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle |= 
					LabelAutoFitStyles.StaggeredLabels;
			}
			if(checkBoxWordWrap.Checked)
			{
				Chart1.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle |= 
					LabelAutoFitStyles.WordWrap;
			}
			if(DropDownListAngles.SelectedIndex == 1)
			{
				Chart1.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle |= 
					LabelAutoFitStyles.LabelsAngleStep30;
			}
			if(DropDownListAngles.SelectedIndex == 2)
			{
				Chart1.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle |= 
					LabelAutoFitStyles.LabelsAngleStep45;
			}
			if(DropDownListAngles.SelectedIndex == 3)
			{
				Chart1.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle |= 
					LabelAutoFitStyles.LabelsAngleStep90;
			}

		}

		protected void checkBoxAutoFit_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBoxFontSize.Enabled = checkBoxAutoFit.Checked;
			CheckBoxOffset.Enabled = checkBoxAutoFit.Checked;
			checkBoxWordWrap.Enabled = checkBoxAutoFit.Checked;
			DropDownListAngles.Enabled = checkBoxAutoFit.Checked;

			// Enable/disable X axis labels automatic fitting
			Chart1.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = checkBoxAutoFit.Checked;
		
		}

		protected void CheckBoxFontSize_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateAutoFitStyle();
		}

		protected void CheckBoxOffset_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateAutoFitStyle();
		}

		protected void checkBoxWordWrap_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateAutoFitStyle();
		}

		protected void DropDownListAngles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateAutoFitStyle();
		}
	}
}
