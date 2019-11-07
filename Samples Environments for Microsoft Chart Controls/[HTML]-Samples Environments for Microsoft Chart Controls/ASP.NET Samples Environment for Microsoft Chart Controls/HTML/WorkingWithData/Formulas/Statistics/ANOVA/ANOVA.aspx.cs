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
	public partial class ANOVA : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			FillData();
			StartTest();
		}

		private void FillData()
		{
			// Fill data with random values
			Random rand = new Random(int.Parse(ButtonRandomData.CommandArgument));

			Chart1.Series[0].Points.Clear();
			Chart1.Series[1].Points.Clear();
			Chart1.Series[2].Points.Clear();

			for( int i = 0; i <= rand.Next(5) + 5; i++ )
			{
				Chart1.Series[0].Points.AddXY(i,rand.Next(15) + 3);
				Chart1.Series[1].Points.AddXY(i,rand.Next(15) + 3);
				Chart1.Series[2].Points.AddXY(i,rand.Next(15) + 3);
			}
		}

		private void StartTest()
		{
			// Calculate probability
			double probability = double.Parse( DropDownListProbability.SelectedItem.Text );
			probability = 1.0 - probability / 100.0;
			
			// Make Anova function call
			AnovaResult result = Chart1.DataManipulator.Statistics.Anova( probability, "Group1,Group2,Group3" );

			// Fill labels with results
			TableResults.Rows[1].Cells[1].Text = result.SumOfSquaresBetweenGroups.ToString("G3");
			TableResults.Rows[1].Cells[2].Text = result.DegreeOfFreedomBetweenGroups.ToString("G3");
			TableResults.Rows[1].Cells[3].Text = result.MeanSquareVarianceBetweenGroups.ToString("G3");
			TableResults.Rows[2].Cells[1].Text = result.SumOfSquaresWithinGroups.ToString("G3");
			TableResults.Rows[2].Cells[2].Text = result.DegreeOfFreedomWithinGroups.ToString("G3");
			TableResults.Rows[2].Cells[3].Text = result.MeanSquareVarianceWithinGroups.ToString("G3");
			TableResults.Rows[3].Cells[1].Text = result.SumOfSquaresTotal.ToString("G3");
			TableResults.Rows[3].Cells[2].Text = result.DegreeOfFreedomTotal.ToString("G3");

			TableFValues.Rows[0].Cells[1].Text = result.FRatio.ToString("G3");;
			TableFValues.Rows[1].Cells[1].Text = result.FCriticalValue.ToString("G3");
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

		protected void ButtonRandomData_Click(object sender, System.EventArgs e)
		{
			Random rand = new Random();
			ButtonRandomData.CommandArgument = rand.Next().ToString();

			FillData();
			StartTest();
		}

		protected void DropDownListProbability_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillData();
			StartTest();
		}
	}

}
