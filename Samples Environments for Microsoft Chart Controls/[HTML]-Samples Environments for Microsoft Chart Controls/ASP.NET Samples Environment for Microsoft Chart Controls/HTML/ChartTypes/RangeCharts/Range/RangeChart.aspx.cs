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
	/// Summary description for RangeChart.
	/// </summary>
	public partial class RangeChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data with data
			double[]	yValue1 = {56, 74, 45, 59, 34, 87, 50, 87, 64, 34};
			double[]	yValue2 = {42, 65, 30, 42, 25, 47, 40, 70, 34, 20};
			Chart1.Series["Default"].Points.DataBindY(yValue1, yValue2);
			double[]	yValue21 = {26, 54, 35, 79, 64, 37, 70, 67, 34, 74};
			double[]	yValue22 = {12, 6, 23, 34, 15, 27, 60, 30, 24, 50};
			Chart1.Series["Series2"].Points.DataBindY(yValue21, yValue22);

			// Set chart type 
			Chart1.Series["Default"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), ChartTypeList.SelectedItem.Value, true );

			// Disable/enable X axis margin
			Chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = ShowMargins.Checked;

			// Set Spline Range line tension
			if(ChartTypeList.SelectedItem.Value == "SplineRange")
			{
				LineTensionList.Enabled = true;
				Chart1.Series["Default"]["LineTension"] = LineTensionList.SelectedItem.Text;
			}
			else
			{
				LineTensionList.Enabled = false;
			}
			
			// Show as 2D or 3D
			if(checkBoxShow3D.Checked)
			{
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
			}
			else
			{
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
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
