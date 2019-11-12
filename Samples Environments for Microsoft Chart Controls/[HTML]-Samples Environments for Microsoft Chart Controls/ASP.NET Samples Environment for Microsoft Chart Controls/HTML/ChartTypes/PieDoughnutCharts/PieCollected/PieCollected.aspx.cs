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
	/// Summary description for PieCollected.
	/// </summary>
	public partial class PieCollected : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList LabelStyleList;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ChartTypeList;
		protected System.Web.UI.WebControls.CheckBox Collect;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.CheckBox checkBoxCollectPieSlices;
		protected System.Web.UI.WebControls.TextBox text_Legend;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack) 
			{
				// Set series font
				Chart1.Series[0].Font = new Font("Trebuchet MS", 8, FontStyle.Bold);
            
				// Set current selection
				this.chk_Pie.Checked = false;
				comboBoxChartType.SelectedIndex = 0;
				comboBoxCollectedColor.SelectedIndex = 0;
				comboBoxCollectedThreshold.SelectedIndex = 0;
				textBoxCollectedLabel.Text = "Other";
				textBoxCollectedLegend.Text = "Other";

				Chart1.Series[0]["CollectedToolTip"] = "Other";
			}
			
			Series series1 = Chart1.Series[0];

			if (this.chk_Pie.Checked) 
			{
				comboBoxChartType.Enabled = true;
				comboBoxCollectedColor.Enabled = true;
				comboBoxCollectedThreshold.Enabled = true;
				textBoxCollectedLabel.Enabled = true;
				textBoxCollectedLegend.Enabled = true;
				this.ShowExplode.Enabled = true;

				// Set the threshold under which all points will be collected
				series1["CollectedThreshold"] = comboBoxCollectedThreshold.SelectedItem.ToString();
				
				// Set the label of the collected pie slice
				series1["CollectedLabel"] = textBoxCollectedLabel.Text;
				
				// Set the legend text of the collected pie slice
				series1["CollectedLegendText"] = textBoxCollectedLegend.Text;

				// Set the collected pie slice to be exploded
				series1["CollectedSliceExploded"]= this.ShowExplode.Checked.ToString();

				// Set collected color
				series1["CollectedColor"] = comboBoxCollectedColor.SelectedItem.ToString();

				// Set chart type
				series1.ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), comboBoxChartType.SelectedItem.ToString(), true );
			}

			else 
			{
				series1["CollectedThreshold"] = "0";
				comboBoxChartType.Enabled = false;
				comboBoxCollectedColor.Enabled = false;
				comboBoxCollectedThreshold.Enabled = false;
				textBoxCollectedLabel.Enabled = false;
				textBoxCollectedLegend.Enabled = false;
				this.ShowExplode.Enabled = false;
			}

			if (this.comboBoxChartType.SelectedItem.ToString() == "Doughnut") 
			{
				Chart1.Series[0]["DoughnutRadius"] = "50";
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

		public void UpdateChartSettings()
		{			
		}
	}
}
