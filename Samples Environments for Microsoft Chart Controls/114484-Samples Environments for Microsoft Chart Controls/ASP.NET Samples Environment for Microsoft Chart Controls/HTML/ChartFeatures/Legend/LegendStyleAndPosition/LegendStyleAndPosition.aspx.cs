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
	/// Summary description for LegendStyleAndPosition.
	/// </summary>
	public partial class LegendStyleAndPosition : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			SetupChart();
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

		protected void LegendStyleList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Avoid the undesirable setting where we have a column legend
			// to the left or to the right and the text is microscopically
			// small to read
//			if (!InsideChartArea.Checked)
//			{
//				if ((LegendStyleList.SelectedItem.Text == "Row" ||
//					LegendStyleList.SelectedItem.Text == "Table") &&
//					(LegendDockingList.SelectedItem.Text == "Left" ||
//					LegendDockingList.SelectedItem.Text == "Right"))
//				{
//					// Dock on top or bottom
//					if (LegendAlinmentList.SelectedItem.Text == "Far")
//						LegendDockingList.SelectedIndex = LegendDockingList.Items.IndexOf(LegendDockingList.Items.FindByText("Bottom"));
//					else
//						LegendDockingList.SelectedIndex = LegendDockingList.Items.IndexOf(LegendDockingList.Items.FindByText("Top"));
//					
//					SetupChart();
//				}
//			}
		}

		protected void LegendDockingList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Avoid the undesirable setting where we have a column legend
			// to the left or to the right and the text is microscopically
			// small to read
//			if (!InsideChartArea.Checked)
//			{
//				if ((LegendStyleList.SelectedItem.Text == "Row" ||
//					LegendStyleList.SelectedItem.Text == "Table") &&
//					(LegendDockingList.SelectedItem.Text == "Left" ||
//					LegendDockingList.SelectedItem.Text == "Right"))
//				{
//					// Make the legend style a column
//					LegendStyleList.SelectedIndex = LegendStyleList.Items.IndexOf(LegendStyleList.Items.FindByText("Column"));
//					
//					SetupChart();
//				}
//			}		
		}

		protected void InsideChartArea_CheckedChanged(object sender, System.EventArgs e)
		{
			// Avoid the undesirable setting where we have a column legend
			// to the left or to the right and the text is microscopically
			// small to read
//			if (!InsideChartArea.Checked)
//			{
//				if ((LegendStyleList.SelectedItem.Text == "Row" ||
//					LegendStyleList.SelectedItem.Text == "Table") &&
//					(LegendDockingList.SelectedItem.Text == "Left" ||
//					LegendDockingList.SelectedItem.Text == "Right"))
//				{
//					// Make the legend style a column
//					LegendStyleList.SelectedIndex = LegendStyleList.Items.IndexOf(LegendStyleList.Items.FindByText("Column"));
//					
//					SetupChart();
//				}
//			}
		}

		private void SetupChart()
		{
			// Set legend style
			Chart1.Legends["Default"].LegendStyle = (LegendStyle)LegendStyle.Parse(typeof(LegendStyle), LegendStyleList.SelectedItem.Text);
			
			// Set legend docking
            Chart1.Legends["Default"].Docking = (Docking)Docking.Parse(typeof(Docking), LegendDockingList.SelectedItem.Text);

			// Set legend alignment
			Chart1.Legends["Default"].Alignment = (StringAlignment)StringAlignment.Parse(typeof(StringAlignment), LegendAlinmentList.SelectedItem.Text);

			// Set whether the legend is reversed
			if (this.Reversed.Checked)
                Chart1.Legends["Default"].LegendItemOrder = LegendItemOrder.ReversedSeriesOrder;

			else
                Chart1.Legends["Default"].LegendItemOrder = LegendItemOrder.SameAsSeriesOrder;

			// Display legend in the "Default" chart area
			if(InsideChartArea.Checked)
			{
				Chart1.Legends["Default"].InsideChartArea = "ChartArea1";
			}						
			
			// Set table style
			this.Chart1.Legends["Default"].TableStyle = (LegendTableStyle)LegendTableStyle.Parse(typeof(LegendTableStyle),this.TheTableStyle.SelectedItem.ToString());

			if (this.LegendStyleList.SelectedItem.ToString() == "Table" && !this.LegendDisabled.Checked)  
			{
				this.TheTableStyle.Enabled = true;		
			}

			else 
			{
				this.TheTableStyle.Enabled = false;
			}			
		}

		protected void LegendDisabled_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!this.LegendDisabled.Checked) 
			{
				// Enable legend
				Chart1.Legends["Default"].Enabled = true;

				// Enable controls
				this.LegendAlinmentList.Enabled = true;
				this.LegendDockingList.Enabled = true;
				this.TheTableStyle.Enabled = true;
				this.LegendStyleList.Enabled = true;
				this.InsideChartArea.Enabled = true;
				this.Reversed.Enabled = true;
			}

			else
			{
				// Disable legend
				Chart1.Legends["Default"].Enabled = false;
				
				// Disable controls
				this.LegendAlinmentList.Enabled = false;
				this.LegendDockingList.Enabled = false;
				this.TheTableStyle.Enabled = false;
				this.LegendStyleList.Enabled = false;
				this.InsideChartArea.Enabled = false;
				this.Reversed.Enabled = false;
			}		
		}
	}
}
