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
	/// Summary description for Range3D.
	/// </summary>
	public partial class Range3D : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data with data
			double[]	yValue11 = {56, 74, 45, 59, 34, 87, 50, 87, 64, 34};
			double[]	yValue12 = {42, 65, 30, 42, 25, 47, 40, 70, 34, 20};
			Chart1.Series["Series1"].Points.DataBindY(yValue11, yValue12);

			double[]	yValue21 = {46, 64, 55, 69, 34, 57, 20, 67, 64, 34};
			double[]	yValue22 = {12, 45, 50, 12, 15, 27, 10, 40, 24, 30};
			Chart1.Series["Series2"].Points.DataBindY(yValue21, yValue22);

			// Set chart type 
			Chart1.Series["Series1"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), ChartTypeList.SelectedItem.Text.Replace(" ", ""), true );
            Chart1.Series["Series2"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), ChartTypeList.SelectedItem.Text.Replace(" ", ""), true);

			// Disable/enable X axis margin
			Chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = ShowMargins.Checked;

			// Set Spline Range line tension
			if(ChartTypeList.SelectedItem.Text == "SplineRange")
			{
				LineTensionList.Enabled = true;
				Chart1.Series["Series1"]["LineTension"] = LineTensionList.SelectedItem.Text;
				Chart1.Series["Series2"]["LineTension"] = LineTensionList.SelectedItem.Text;
			}
			else
			{
				LineTensionList.Enabled = false;
			}

			// Set Show of marker Lines
			Chart1.Series["Series1"]["ShowMarkerLines"] = ShowMarkers.Checked.ToString();
			Chart1.Series["Series2"]["ShowMarkerLines"] = ShowMarkers.Checked.ToString();
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
