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
	/// Summary description for LabelsKeywords.
	/// </summary>
	public partial class LabelsKeywords : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			// Populate series data
			DateTime	dateCurrent = DateTime.Now.Date;
			int pointIndex = 0;
			foreach( DataPoint p in Chart1.Series["Series1"].Points)
			{
				p.XValue = dateCurrent.AddDays(pointIndex++).ToOADate();
			}
			
			Chart1.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont | LabelAutoFitStyles.StaggeredLabels | LabelAutoFitStyles.LabelsAngleStep90;
			Chart1.ChartAreas["ChartArea1"].AxisY.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont | LabelAutoFitStyles.StaggeredLabels | LabelAutoFitStyles.LabelsAngleStep90;

			// Set axis labels
			Chart1.Series["Series1"].AxisLabel = AxisLabelsList.SelectedItem.Value;

			// Set series point's labels
			Chart1.Series["Series1"].Label = PointLabelsList.SelectedItem.Value;
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
