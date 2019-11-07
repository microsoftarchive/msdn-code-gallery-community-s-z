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
	/// Summary description for LabelsFormatting.
	/// </summary>
	public partial class LabelsFormatting : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data
			Random		random = new Random(7259);
			DateTime	dateCurrent = DateTime.Now.Date;
			for(int pointIndex = 0; pointIndex < 7; pointIndex++)
			{
				Chart1.Series[0].Points.AddXY(dateCurrent.AddDays(pointIndex), random.Next(1000, 9000)/100.0);
			}
			
			// Disable end labels for the X axis
			if(!IsEndLabelVisible.Checked)
			{
				Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsEndLabelVisible = false;
			}

			Chart1.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle ^= LabelAutoFitStyles.IncreaseFont;
			Chart1.ChartAreas["ChartArea1"].AxisY.LabelAutoFitStyle ^= LabelAutoFitStyles.IncreaseFont;

			// Set X axis labels format
			Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = XAxisFormat.SelectedItem.Value;

			// Set Y axis labels format
			Chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = YAxisFormat.SelectedItem.Value;

			// Set series point labels format
			Chart1.Series[0].LabelFormat = SeriesPointFormat.SelectedItem.Value;

			// Set series point labels color
			Chart1.Series[0].Color = Color.Navy;

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
