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
	/// Summary description for MultipleLegends.
	/// </summary>
	public partial class MultipleLegendsWithCheckBox : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (this.IsPostBack)
			{
				if (this.CheckBox1.Checked)
				{
					// Add a second legend
					Legend secondLegend = new Legend("Second");
					secondLegend.BackColor = Color.FromArgb(((System.Byte)(220)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
					secondLegend.BorderColor = Color.Gray;
					secondLegend.Font = this.Chart1.Legends["Default"].Font;

					this.Chart1.Legends.Add(secondLegend);

					// Associate Series 2 with the second legend 
					this.Chart1.Series["Series 2"].Legend = "Second";

					// Dock the default legend inside the first chart area
					this.Chart1.Legends["Default"].IsDockedInsideChartArea = true;
					this.Chart1.Legends["Default"].DockedToChartArea = "ChartArea1";

					// Dock the second legend inside the second chart area
					secondLegend.IsDockedInsideChartArea = true;
					secondLegend.DockedToChartArea = "Chart Area 2";
				}
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
