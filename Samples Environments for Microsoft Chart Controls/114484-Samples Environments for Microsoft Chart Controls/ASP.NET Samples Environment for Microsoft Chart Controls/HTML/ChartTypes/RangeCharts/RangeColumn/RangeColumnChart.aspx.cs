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
	/// Summary description for RangeColumnChart.
	/// </summary>
	public partial class RangeColumnChart : System.Web.UI.Page
	{
		# region Fields
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList LabelStyleList;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ExplodedPointList;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList HoleSizeList;
		protected System.Web.UI.WebControls.DropDownList AreaDrawingStyleList;
		protected System.Web.UI.WebControls.DropDownList RadarStyleList;
		protected System.Web.UI.WebControls.CheckBox ShowMargins;
		protected System.Web.UI.WebControls.DropDownList ChartTypeList;
	
		# endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack) 
			{
                this.DrawingStyleList.SelectedIndex = 0;
				this.checkBoxShow3D.Checked = false;
			}

			foreach (Series s in Chart1.Series) 
			{				
				// Set range column chart type
				s.ChartType = SeriesChartType.RangeColumn;
				
				// Set the side-by-side drawing style
				s["DrawSideBySide"] = (CheckboxShowSideBySide.Checked) ? "true" : "false";
			
				// Show as 2D or 3D
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = checkBoxShow3D.Checked;

				// Show columns as cylinders in 3D
				s["DrawingStyle"] = this.DrawingStyleList.SelectedItem.ToString();
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
