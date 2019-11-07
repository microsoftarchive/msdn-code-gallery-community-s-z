using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for ImageMapCustom.
	/// </summary>
	public partial class DynamicAddData : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = Math.PI;
			Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "##.##";
			Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = Math.PI;
			Chart1.ChartAreas["ChartArea1"].AxisX.MinorGrid.Interval = Math.PI/4;
			Chart1.ChartAreas["ChartArea1"].AxisX.MinorTickMark.Interval = Math.PI/4;
			Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = Math.PI;
			Chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = 0.25;
			Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Interval = 0.5;
			Chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Interval = 0.5;
			

			double t;
			for(t = 0; t <= (2.5 * Math.PI); t += Math.PI/6)
			{
				double ch1 = Math.Sin(t);
				double ch2 = Math.Sin(t-Math.PI/2);
				Chart1.Series["Channel 1"].Points.AddXY(t, ch1);
				Chart1.Series["Channel 2"].Points.AddXY(t, ch2);
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
