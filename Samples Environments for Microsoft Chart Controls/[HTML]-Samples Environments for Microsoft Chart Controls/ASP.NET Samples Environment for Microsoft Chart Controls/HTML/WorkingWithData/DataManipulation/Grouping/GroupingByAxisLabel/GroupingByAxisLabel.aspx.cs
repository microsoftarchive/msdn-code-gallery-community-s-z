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

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for GroupingByAxisLabel.
	/// </summary>
	public partial class GroupingByAxisLabel : System.Web.UI.Page
	{
	
		private void PopulateData()
		{
			// Populate series data
			double[]	yValues = {645.62, 745.54, 360.45, 534.73, 585.42, 832.12, 455.18, 667.15, 256.24, 523.65, 356.56, 575.85, 156.78, 450.67};
			string[]	xValues = {"John", "Peter", "Dave", "Alex", "Scott", "Peter", "Alex", "Dave", "John", "Peter", "Dave", "Scott", "Alex", "Peter"};
			Chart1.Series["Sales"].Points.DataBindXY(xValues, yValues);

			// Group series data points by Axis Label (sales person name)
			Chart1.DataManipulator.GroupByAxisLabel(GroupingFormulaList.SelectedItem.Value, "Sales", "Total by Person");
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

		protected void GroupingFormulaList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PopulateData();
		}
	}
}
