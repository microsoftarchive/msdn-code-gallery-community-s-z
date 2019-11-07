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
	/// Summary description for PolarChart.
	/// </summary>
	public partial class PolarChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ExplodedPointList;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList HoleSizeList;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Fill series data
			for(double angle = 0.0; angle <= 360.0; angle += 10.0)
			{
				double yValue = (1.0 + Math.Sin(angle/180.0*Math.PI)) * 10.0;
				Chart1.Series["Series1"].Points.AddXY(angle + 90.0, yValue);
				Chart1.Series["Series2"].Points.AddXY(angle + 270.0, yValue);
			}

			// Set polar chart style
			Chart1.Series["Series1"]["PolarDrawingStyle"] = RadarStyleList.SelectedItem.Text;
			Chart1.Series["Series2"]["PolarDrawingStyle"] = RadarStyleList.SelectedItem.Text;

			// Set circular area drawing style
			Chart1.Series["Series1"]["AreaDrawingStyle"] = AreaDrawingStyleList.SelectedItem.Text;
			Chart1.Series["Series2"]["AreaDrawingStyle"] = AreaDrawingStyleList.SelectedItem.Text;

			// Set labels style
			Chart1.Series["Series1"]["CircularLabelsStyle"] = LabelStyleList.SelectedItem.Text;
			Chart1.Series["Series2"]["CircularLabelsStyle"] = LabelStyleList.SelectedItem.Text;

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
