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
	/// Summary description for LabelsNextToAxis.
	/// </summary>
	public partial class LabelsNextToAxis : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data with random data
			Random random = new Random();
			for(int pointIndex = 0; pointIndex < 15; pointIndex++)
			{
                foreach (Series series in Chart1.Series)
                {
                    series.Points.AddXY(random.Next(-100, 100), random.Next(-100, 100));
                }
			}

			// Set X and Y axis crossing
			Chart1.ChartAreas["ChartArea1"].AxisX.Crossing = 0;
			Chart1.ChartAreas["ChartArea1"].AxisY.Crossing = 0;

			// Position the X axis labels and tick marks to the area border
			if(XLabelsList.SelectedIndex == 1)
			{
				Chart1.ChartAreas["ChartArea1"].AxisX.IsMarksNextToAxis = false;
			}

			// Position the Y axis labels and tick marks to the area border
			if(YLabelsList.SelectedIndex == 1)
			{
				Chart1.ChartAreas["ChartArea1"].AxisY.IsMarksNextToAxis = false;
			}
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
