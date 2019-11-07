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
	/// Summary description for CustomSortingOrder.
	/// </summary>
	public partial class DescriptiveStatistics : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList SortList;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			FillData();
		}

		private void FillData()
		{
			// Fill data with random values
			Random rand = new Random();

			Chart1.Series[0].Points.Clear();
			
			for( int i = 0; i <= 10; i++ )
			{
				Chart1.Series[0].Points.AddXY(i,rand.Next(15));
			}
			StartTest();
	
		}

		private void StartTest()
		{
			// Calculate descriptive statistics
			double mean = Chart1.DataManipulator.Statistics.Mean("Series1");
			double median = Chart1.DataManipulator.Statistics.Median("Series1");
			double variance = Chart1.DataManipulator.Statistics.Variance("Series1",true);
		
			// Set Strip line item
			Chart1.ChartAreas["ChartArea1"].AxisY.StripLines[0].IntervalOffset = mean - Math.Sqrt( variance );
			Chart1.ChartAreas["ChartArea1"].AxisY.StripLines[0].StripWidth = 2.0 * Math.Sqrt( variance );
			
			// Set Strip line item
			Chart1.ChartAreas["ChartArea1"].AxisY.StripLines[1].IntervalOffset = mean;

			// Set Strip line item
			Chart1.ChartAreas["ChartArea1"].AxisY.StripLines[2].IntervalOffset  = median;
			
			// Fill labels
			TableResults.Rows[0].Cells[1].Text = mean.ToString("G5");
			TableResults.Rows[1].Cells[1].Text = Math.Sqrt( variance ).ToString("G5");
			double stdeviation = Math.Sqrt( variance );
			TableResults.Rows[2].Cells[1].Text = median.ToString("G5");
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

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			Random rand = new Random();
			Button1.CommandArgument = rand.Next().ToString();

			FillData();
			StartTest();
		}
	}

}
