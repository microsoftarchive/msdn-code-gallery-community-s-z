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
	/// Summary description for LegendAppearance.
	/// </summary>
	public partial class LegendAppearance : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Update legend colors
			UpdateColor();
		}

		public void UpdateColor()
		{
			// Set Legend visual attributes
			Chart1.Legends["Default"].BackColor = Color.FromName(BackColorList.SelectedItem.Text);
			Chart1.Legends["Default"].BackSecondaryColor = Color.FromName(EndColorList.SelectedItem.Text);
			Chart1.Legends["Default"].BorderColor = Color.FromName(BorderColorList.SelectedItem.Text);
			Chart1.Legends["Default"].BackGradientStyle = (GradientStyle)GradientStyle.Parse(typeof(GradientStyle), GradientList.SelectedItem.Text);
			Chart1.Legends["Default"].BackHatchStyle = (ChartHatchStyle)ChartHatchStyle.Parse(typeof(ChartHatchStyle), HatchingList.SelectedItem.Text);
			Chart1.Legends["Default"].BorderWidth = int.Parse(BorderSizeList.SelectedItem.Text);
			Chart1.Legends["Default"].BorderDashStyle = (ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), BorderDashStyleList.SelectedItem.Text);
			Chart1.Legends["Default"].ShadowOffset = int.Parse(ShadowOffsetList.SelectedItem.Text);

			// Disable fore color control if gradient or hatching are not used
			if(HatchingList.SelectedItem.Text == "None" && GradientList.SelectedItem.Text == "None")
			{
				EndColorList.Enabled = false;
			}
			else
			{
				EndColorList.Enabled = true;
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

		protected void GradientList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Disable hatching when gradient is changed
			HatchingList.SelectedIndex = -1;
			HatchingList.Items.FindByText("None").Selected = true;

			// Update legend colors
			UpdateColor();

		}

		protected void HatchingList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Disable gradient when hatching is changed
			GradientList.SelectedIndex = -1;
			GradientList.Items.FindByText("None").Selected = true;

			// Update legend colors
			UpdateColor();
		}
	}
}
