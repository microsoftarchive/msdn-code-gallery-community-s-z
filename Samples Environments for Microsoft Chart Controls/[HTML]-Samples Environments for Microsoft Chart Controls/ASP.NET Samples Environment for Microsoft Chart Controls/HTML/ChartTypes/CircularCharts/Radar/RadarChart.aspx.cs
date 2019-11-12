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
	/// Summary description for RadarChart.
	/// </summary>
	public partial class RadarChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ExplodedPointList;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList HoleSizeList;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data
			double[]	yValues = {65.62, 75.54, 60.45, 34.73, 85.42, 55.9, 63.6, 55.1, 77.2};
			double[]	yValues2 = {76.45, 23.78, 86.45, 30.76, 23.79, 35.67, 89.56, 67.45, 38.98};
			string[]	xValues = {"France", "Canada", "Germany", "USA", "Italy", "Spain", "Russia", "Sweden", "Japan"};
			Chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
			Chart1.Series["Series2"].Points.DataBindXY(xValues, yValues2);

			// Set radar chart style
			Chart1.Series["Series1"]["RadarDrawingStyle"] = RadarStyleList.SelectedItem.Text;
			Chart1.Series["Series2"]["RadarDrawingStyle"] = RadarStyleList.SelectedItem.Text;
			if(RadarStyleList.SelectedItem.Text == "Area")
			{
				Chart1.Series["Series1"].BorderColor = Color.FromArgb(100,100,100);
				Chart1.Series["Series1"].BorderWidth = 1;
				Chart1.Series["Series2"].BorderColor = Color.FromArgb(100,100,100);
				Chart1.Series["Series2"].BorderWidth = 1;
			}
			else if(RadarStyleList.SelectedItem.Text == "Line")
			{
				Chart1.Series["Series1"].BorderColor = Color.Empty;
				Chart1.Series["Series1"].BorderWidth = 2;
				Chart1.Series["Series2"].BorderColor = Color.Empty;
				Chart1.Series["Series2"].BorderWidth = 2;
			}
			else if(RadarStyleList.SelectedItem.Text == "Marker")
			{
				Chart1.Series["Series1"].BorderColor = Color.Empty;
				Chart1.Series["Series2"].BorderColor = Color.Empty;
			}

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
