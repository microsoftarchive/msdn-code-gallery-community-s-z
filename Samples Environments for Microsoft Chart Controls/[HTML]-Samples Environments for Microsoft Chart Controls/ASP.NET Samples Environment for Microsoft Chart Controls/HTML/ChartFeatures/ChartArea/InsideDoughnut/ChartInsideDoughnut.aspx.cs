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
	/// Summary description for ChartInsideDoughnut.
	/// </summary>
	public partial class ChartInsideDoughnut : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			CreateChartArea(0, "Area1", true);
			Chart1.Series["Series1"].ChartArea = "Area1";
			Chart1.Series["Series1"]["DoughnutRadius"] = "25";

			if(Series2CheckBox.Checked)
			{
				CreateChartArea(1, "Area2", false);
				Chart1.Series["Series2"].ChartArea = "Area2";
				Chart1.Series["Series2"].Enabled = true;
				Chart1.Series["Series2"]["DoughnutRadius"] = "37";
				Series3CheckBox.Enabled = true;
			}
			else
			{
				Series3CheckBox.Enabled = false;
				Chart1.Series["Series2"].Enabled = false;
			}

			if(Series2CheckBox.Checked && Series3CheckBox.Checked)
			{
				CreateChartArea(2, "Area3", false);
				Chart1.Series["Series3"].ChartArea = "Area3";
				Chart1.Series["Series3"].Enabled = true;
				Chart1.Series["Series3"]["DoughnutRadius"] = "49";
			}
			else
			{
				Chart1.Series["Series3"].Enabled = false;
			}

		}

		/// <summary>
		/// This method will create a ChartArea with a given name at a certain level
		/// </summary>
		private void CreateChartArea(int level, string AreaName, bool ShowBorder)
		{
			Chart1.ChartAreas.Add(AreaName);
			Chart1.ChartAreas[AreaName].BackColor = Color.Transparent;
			
			if(ShowBorder)
				Chart1.ChartAreas[AreaName].BorderWidth = 1;
			else
				Chart1.ChartAreas[AreaName].BorderWidth = 0;

			Chart1.ChartAreas[AreaName].InnerPlotPosition.Auto = false;
			Chart1.ChartAreas[AreaName].InnerPlotPosition.Height = 100;
			Chart1.ChartAreas[AreaName].InnerPlotPosition.Width = 100;
			Chart1.ChartAreas[AreaName].InnerPlotPosition.X = 0;
			Chart1.ChartAreas[AreaName].InnerPlotPosition.Y = 0;

			Chart1.ChartAreas[AreaName].Position.X = 2 + level * 15;
			Chart1.ChartAreas[AreaName].Position.Y = 2 + level * 15;
			Chart1.ChartAreas[AreaName].Position.Height = 96 - level * 30;
			Chart1.ChartAreas[AreaName].Position.Width = 96 - level * 30;

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
