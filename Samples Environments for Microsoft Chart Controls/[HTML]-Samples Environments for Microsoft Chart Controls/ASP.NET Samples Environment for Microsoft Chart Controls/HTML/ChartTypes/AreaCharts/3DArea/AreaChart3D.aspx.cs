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
	/// Summary description for AreaChart3D3D.
	/// </summary>
	public partial class AreaChart3D : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Area.Checked)
			{
				// Set chart type to Area
				Chart1.Series["Series1"].ChartType = SeriesChartType.Area;
				Chart1.Series["Series2"].ChartType = SeriesChartType.Area;
				LineTensionList.Enabled = false;
			}
			else if (SplineArea.Checked)
			{
				// Set chart type to SplineArea and set line tension
				LineTensionList.Enabled = true;
				Chart1.Series["Series1"].ChartType = SeriesChartType.SplineArea;
				Chart1.Series["Series1"]["LineTension"] = LineTensionList.SelectedItem.Text;
				Chart1.Series["Series2"].ChartType = SeriesChartType.SplineArea;
				Chart1.Series["Series2"]["LineTension"] = LineTensionList.SelectedItem.Text;
			}

			// Set Show of marker Lines
			Chart1.Series["Series1"]["ShowMarkerLines"] = ShowMarkers.Checked.ToString();
			Chart1.Series["Series2"]["ShowMarkerLines"] = ShowMarkers.Checked.ToString();


			// Disable/enable X axis margin
			Chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = ShowMargins.Checked;

			// set the lighting choice
			if(LightingType.SelectedItem.Text != "")
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.LightStyle = (LightStyle)LightStyle.Parse(typeof(LightStyle), LightingType.SelectedItem.Text);
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

		
		
	}
}
