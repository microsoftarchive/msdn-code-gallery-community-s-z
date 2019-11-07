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
	/// Summary description for WebForm1.
	/// </summary>
	public partial class StackedChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;


	
		protected void Page_Load(object sender, System.EventArgs e)
		{ 
			// Populate series data
			Random	random = new Random();
			for(int pointIndex = 0; pointIndex < 10; pointIndex++)
			{
				Chart1.Series["Series1"].Points.AddY(Math.Round((double)random.Next(45, 95),0));
				Chart1.Series["Series2"].Points.AddY(Math.Round((double)random.Next(5, 75),0));
				Chart1.Series["Series3"].Points.AddY(Math.Round((double)random.Next(5, 95),0));
				Chart1.Series["Series4"].Points.AddY(Math.Round((double)random.Next(35, 95),0));
			}			

			// Set chart type
			string	chartTypeName = ChartTypeList.SelectedItem.Text;
			if(HundredPercentStacked.Checked)
			{
				chartTypeName = chartTypeName + "100";
			}

			// Grouping cannot be done using stacked area charts
			if (chartTypeName == "StackedArea" || chartTypeName == "StackedArea100") 
				this.checkBoxGrouped.Enabled = false;

			else
				this.checkBoxGrouped.Enabled = true;

			Chart1.Series["Series1"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), chartTypeName, true );
			Chart1.Series["Series2"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), chartTypeName, true );
			Chart1.Series["Series3"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), chartTypeName, true );
			Chart1.Series["Series4"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), chartTypeName, true );

			// Show point labels
			if(ShowLabels.Checked)
			{
				Chart1.Series["Series1"].IsValueShownAsLabel = true;
				Chart1.Series["Series2"].IsValueShownAsLabel = true;
				Chart1.Series["Series3"].IsValueShownAsLabel = true;
				Chart1.Series["Series4"].IsValueShownAsLabel = true;
			}

			// Set X axis margin for the area chart
			Chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = ShowMargins.Checked;
			
			// Show as 2D or 3D
			if(checkBoxShow3D.Checked)
			{
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
			}
			else
			{
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
			}

			if (checkBoxGrouped.Checked) 
			{
				Chart1.Series["Series1"]["StackedGroupName"] = "Group1";
				Chart1.Series["Series2"]["StackedGroupName"] = "Group1";
				Chart1.Series["Series3"]["StackedGroupName"] = "Group2";
				Chart1.Series["Series4"]["StackedGroupName"] = "Group2";

				Chart1.ResetAutoValues();
			}

			else 
			{
				foreach (Series series in Chart1.Series) 
				{
					series["StackedGroupName"] = "";
				}

				Chart1.ResetAutoValues();
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
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
