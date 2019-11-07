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
	/// Summary description for PointChart.
	/// </summary>
	public partial class PointChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data with random data
			Random	random = new Random();
			for(int pointIndex = 0; pointIndex < 10; pointIndex++)
			{
				Chart1.Series["Series1"].Points.AddY(random.Next(5, 60));
				Chart1.Series["Series2"].Points.AddY(random.Next(50, 95));
			}

			// Set point chart type
			Chart1.Series["Series1"].ChartType = SeriesChartType.Point;
			Chart1.Series["Series2"].ChartType = SeriesChartType.Point;

			// Enable data points labels
			if(PointLabelsList.SelectedItem.Text != "None")
			{
				Chart1.Series["Series1"].IsValueShownAsLabel = true;
				Chart1.Series["Series2"].IsValueShownAsLabel = true;
				Chart1.Series["Series1"]["LabelStyle"] = PointLabelsList.SelectedItem.Text;
				Chart1.Series["Series2"]["LabelStyle"] = PointLabelsList.SelectedItem.Text;
			}

			// Set marker size
			Chart1.Series["Series1"].MarkerSize = int.Parse(MarkerSizeList.SelectedItem.Text);
			Chart1.Series["Series2"].MarkerSize = int.Parse(MarkerSizeList.SelectedItem.Text);

			// Set marker shape
			if(MarkerShapeList.SelectedIndex == 1)	
			{
				Chart1.Series["Series1"].MarkerStyle = MarkerStyle.Diamond;
				Chart1.Series["Series2"].MarkerStyle = MarkerStyle.Triangle;
			}
			else if(MarkerShapeList.SelectedIndex == 2)	
			{
				Chart1.Series["Series1"].MarkerStyle = MarkerStyle.Cross;
				Chart1.Series["Series2"].MarkerImage = "..\\Bubble\\Face.bmp";
				Chart1.Series["Series2"].MarkerImageTransparentColor = Color.White;
			}

			// Set X and Y axis scale
			Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 100.0;
			Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0.0;

			// Show as 2D or 3D
			if(checkBoxShow3D.Checked)
			{
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
			}
			else
			{
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
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
