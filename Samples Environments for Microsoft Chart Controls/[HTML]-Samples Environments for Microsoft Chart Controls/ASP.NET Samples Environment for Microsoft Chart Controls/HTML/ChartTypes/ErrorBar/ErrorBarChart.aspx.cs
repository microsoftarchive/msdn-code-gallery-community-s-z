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
	/// Summary description for ErrorBarChart.
	/// </summary>
	public partial class ErrorBarChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList LabelStyleList;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ExplodedPointList;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList HoleSizeList;
		protected System.Web.UI.WebControls.CheckBox checkBoxShow3D;
		protected System.Web.UI.WebControls.DropDownList AreaDrawingStyleList;
		protected System.Web.UI.WebControls.DropDownList RadarStyleList;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series with data
			double[]	yValues = {32.4, 56.9, 89.7, 98.5, 59.3, 33.8, 78.8, 44.6, 76.4, 68.9};
			Chart1.Series["DataSeries"].Points.DataBindY(yValues);
			
			// Link error bar series with data series
			Chart1.Series["ErrorBar"]["ErrorBarSeries"] = "DataSeries";

			// Set error calculation type
			Chart1.Series["ErrorBar"]["ErrorBarType"] = ErrorCalculationList.SelectedItem.Value;

			// Set error bar upper & lower error style
			Chart1.Series["ErrorBar"]["ErrorBarStyle"] = ErrorStyleList.SelectedItem.Value;

			// Set error bar center marker style
			Chart1.Series["ErrorBar"]["ErrorBarCenterMarkerStyle"] = CenterMarkerStyleList.SelectedItem.Value;

			// Set error bar marker style
			Chart1.Series["ErrorBar"]["PointWidth"] = "0.4";
			if(MarkersStyleList.SelectedItem.Value == "Line")
			{
				Chart1.Series["ErrorBar"].MarkerStyle = MarkerStyle.None;
			}
			else if(MarkersStyleList.SelectedItem.Value == "None")
			{
				Chart1.Series["ErrorBar"]["PointWidth"] = "0";
				Chart1.Series["ErrorBar"].MarkerStyle = MarkerStyle.None;
			}
			else
			{
				Chart1.Series["ErrorBar"].MarkerStyle = (MarkerStyle)Enum.Parse(typeof(MarkerStyle), MarkersStyleList.SelectedItem.Value);
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
