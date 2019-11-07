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
	/// Summary description for FilterTopN.
	/// </summary>
	public partial class FilterTopN : System.Web.UI.Page
	{
	
		private void PopulateData()
		{
			// Populate series with random data
			double[]	yValues = {945.62, 545.54, 760.45, 834.73, 1385.42, 932.12, 855.18, 1207.15, 1299.24, 1023.65, 956.56, 1455.85};
			double[]	xValues = {1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999, 2000, 2001};
			Chart1.Series["Sales"].Points.DataBindXY(xValues, yValues);

			// Show data points using point's index
			if(ShowAsIndexedList.SelectedItem.Text == "True")
			{
				Chart1.Series["TopSales"].IsXValueIndexed = true;

				// Reset X axis scale and labels
				Chart1.ChartAreas["FilteredData"].AxisX.Minimum = double.NaN;
				Chart1.ChartAreas["FilteredData"].AxisX.Maximum = double.NaN;
				Chart1.ChartAreas["FilteredData"].AxisX.LabelStyle.Interval = 1;
				Chart1.ChartAreas["FilteredData"].AxisX.MajorTickMark.Interval = 1;
			}
			else
			{
				// Filter only marks points as empty
				Chart1.DataManipulator.FilterSetEmptyPoints = true;
			}

			// Filter Top/Bottom N points
			bool leaveTop = true;
			if(PointsToLeaveList.SelectedItem.Value == "Bottom")
			{
				leaveTop = false;
			}
			Chart1.DataManipulator.FilterTopN(int.Parse(PointNumberList.SelectedItem.Value), "Sales", "TopSales", "Y", leaveTop);
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			PopulateData();
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
