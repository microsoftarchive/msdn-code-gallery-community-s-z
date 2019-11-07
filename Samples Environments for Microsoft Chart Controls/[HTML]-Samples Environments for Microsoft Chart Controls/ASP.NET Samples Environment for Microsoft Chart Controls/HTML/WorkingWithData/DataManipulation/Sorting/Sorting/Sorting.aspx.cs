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
	/// Summary description for Sorting.
	/// </summary>
	public partial class Sorting : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data
			double[]	valueY = {120, 530, 670, 430, 860, 240, 350, 870, 540, 120 };
			double[]	valueY2 = {58, 94, 24, 56, 99, 12, 25};
			Chart1.Series["Series1"].Points.DataBindY(valueY, valueY2);

			// Use point index for drawing the chart
			Chart1.Series["Series1"].IsXValueIndexed = true;

			// Get sorting order
			PointSortOrder order = PointSortOrder.Ascending;
			if(SortOrderList.SelectedItem.Text == "Descending")
			{
				order = PointSortOrder.Descending;
			}

			// Sort series data points
			if(SortList.SelectedItem.Text == "Y Value")
			{
				Chart1.DataManipulator.Sort(order, "Y", "Series1");
			}
			if(SortList.SelectedItem.Text == "Y2 Value (Radius)")
			{
				Chart1.DataManipulator.Sort(order, "Y2", "Series1");
			}

			// Enable sort order control
			if(SortList.SelectedItem.Text != "Unsorted")
			{
				SortOrderList.Enabled = true;
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
