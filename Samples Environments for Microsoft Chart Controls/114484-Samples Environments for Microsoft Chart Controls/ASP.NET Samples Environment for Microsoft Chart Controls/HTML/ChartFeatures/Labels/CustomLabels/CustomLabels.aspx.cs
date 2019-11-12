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
	/// Summary description for CustomLabels.
	/// </summary>
	public partial class CustomLabels : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data
			Random		random = new Random();
			for(int pointIndex = 0; pointIndex < 5; pointIndex++)
			{
				Chart1.Series["Series1"].Points.AddXY(pointIndex+1, random.Next(10, 90));
			}
			

			// Set X axis custom labels
            CustomLabel element = Chart1.ChartAreas["ChartArea1"].AxisY.CustomLabels.Add(0, 30, "Low");
			element = Chart1.ChartAreas["ChartArea1"].AxisY.CustomLabels.Add(30, 70, "Medium");
			element = Chart1.ChartAreas["ChartArea1"].AxisY.CustomLabels.Add(70,100,"High");

			StripLine stripLow = new StripLine();
			stripLow.IntervalOffset = 0;
			stripLow.StripWidth = 30;
			stripLow.BackColor = Color.FromArgb(128, Color.Green);

			StripLine stripMed = new StripLine();
			stripMed.IntervalOffset = 30;
			stripMed.StripWidth = 40;
			stripMed.BackColor = Color.FromArgb(128, Color.Orange);

			StripLine stripHigh = new StripLine();
			stripHigh.IntervalOffset = 70;
			stripHigh.StripWidth = 30;
			stripHigh.BackColor = Color.FromArgb(128, Color.Red);

			Chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(stripLow);
			Chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(stripMed);
			Chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(stripHigh);

			// Set Y axis custom labels
			element = Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0.5, 1.5, "A");
			element.GridTicks = GridTickTypes.All;

			element = Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(1.5, 2.5, "B");
			element.GridTicks = GridTickTypes.TickMark;

			element = Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(2.5, 3.5, "C");
			element.GridTicks = GridTickTypes.All;

			element = Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(3.5, 4.5, "D");
			element.GridTicks = GridTickTypes.TickMark;

			element = Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(4.5, 5.5, "E");
			element.GridTicks = GridTickTypes.All;

			// set second row of labels
			Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0.5, 3.5, "Group 1", 1, LabelMarkStyle.LineSideMark);
			Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(3.5, 5.5, "Group 2", 1, LabelMarkStyle.LineSideMark);

			// One more row of labels
			Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0.5, 5.5, "All Groups", 2, LabelMarkStyle.LineSideMark);
		
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
