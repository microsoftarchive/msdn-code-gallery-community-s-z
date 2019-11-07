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
	public partial class CovarianceAndCorrelation : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList SortList;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Chart1.Series.Add("SecondGroup");
			FillData();
		}

		private void FillData()
		{
			
			// Fill data with random values
			Random rand = new Random(int.Parse(Button1.CommandArgument));

			Chart1.Series["FirstGroup"].Points.Clear();

			Chart1.ChartAreas["ChartArea1"].AxisX.RoundAxisValues();

			double x;
			for( int i = 0; i <= 10; i++ )
			{
				x = i+rand.NextDouble();
				Chart1.Series["FirstGroup"].Points.AddXY(x,x * 5.0 * rand.NextDouble() + rand.NextDouble());
			}

			StartTest();
		}

		private void StartTest()
		{
			
			Chart1.Series["SecondGroup"].Points.Clear();
			Chart1.Series["SecondGroup"].Enabled = false;
			foreach( DataPoint point in Chart1.Series["FirstGroup"].Points )
			{
				Chart1.Series["SecondGroup"].Points.AddXY( point.XValue, point.XValue );
			}
				
			// Calculate Covariance
			double result = Chart1.DataManipulator.Statistics.Covariance( "FirstGroup", "SecondGroup" ); 

			// Fill labels with results
			TableResults.Rows[0].Cells[1].Text = result.ToString("G4");

			// Calculate Correlation
			result = Chart1.DataManipulator.Statistics.Correlation( "FirstGroup", "SecondGroup" ); 
			
			TableResults.Rows[1].Cells[1].Text = result.ToString("G4");

			Chart1.Series["Result"].Points.Clear();

            Series rangeSeries = Chart1.Series.Add("Range");
            rangeSeries.ChartType = SeriesChartType.Range;
			
            // Calculate Best Fit
			Chart1.DataManipulator.FinancialFormula( FinancialFormula.Forecasting, "2,0", "FirstGroup","Result:Y,Range:Y,Range:Y2" );

            Chart1.Series.Remove(rangeSeries);

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
