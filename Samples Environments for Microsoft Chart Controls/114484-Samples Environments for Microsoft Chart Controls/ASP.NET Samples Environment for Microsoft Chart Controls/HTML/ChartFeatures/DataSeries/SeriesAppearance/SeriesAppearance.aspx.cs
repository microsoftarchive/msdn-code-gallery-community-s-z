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
	/// Summary description for Series["Default"]Appearance.
	/// </summary>
	public partial class SeriesAppearance : System.Web.UI.Page
	{
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			Chart1.Serializer.SerializableContent = "*.*";
			Chart1.Serializer.NonSerializableContent = "*.Size";
			
			if ( !this.IsPostBack )
			{
				UpdateColor();
				System.IO.MemoryStream defaultChartView = new System.IO.MemoryStream();
				// save current settings as default
				Chart1.Serializer.Save( defaultChartView );
				this.ViewState["savedView"] = defaultChartView;
			}
			else
			{
				System.IO.MemoryStream defaultChartView = (System.IO.MemoryStream)this.ViewState["savedView"];
				// load default settings
				defaultChartView.Position = 0;
				Chart1.Serializer.Load( defaultChartView );
				// Update legend colors
				UpdateColor();
			}
		}

		public void UpdateColor()
		{
			if(!ApplyToPoint.Checked)
			{
				// Set Series["Default"] visual attributes
				Chart1.Series["Default"].Color = Color.FromName(ColorList.SelectedItem.Text);
				Chart1.Series["Default"].BackSecondaryColor = Color.FromName(EndColorList.SelectedItem.Text);
				Chart1.Series["Default"].BorderColor = Color.FromName(BorderColorList.SelectedItem.Text);
				Chart1.Series["Default"].BackGradientStyle = (GradientStyle)GradientStyle.Parse(typeof(GradientStyle), GradientList.SelectedItem.Text);
				Chart1.Series["Default"].BackHatchStyle = (ChartHatchStyle)ChartHatchStyle.Parse(typeof(ChartHatchStyle), HatchingList.SelectedItem.Text);
				Chart1.Series["Default"].BorderWidth = int.Parse(BorderSizeList.SelectedItem.Text);
				Chart1.Series["Default"].BorderDashStyle = (ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), BorderDashStyleList.SelectedItem.Text);
				Chart1.Series["Default"].ShadowOffset = int.Parse(ShadowOffsetList.SelectedItem.Text);

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
			else
			{
				// Set Series["Default"] visual attributes
				Chart1.Series["Default"].Points[2].Color = Color.FromName(ColorList.SelectedItem.Text);
				Chart1.Series["Default"].Points[2].BackSecondaryColor = Color.FromName(EndColorList.SelectedItem.Text);
				Chart1.Series["Default"].Points[2].BorderColor = Color.FromName(BorderColorList.SelectedItem.Text);
				Chart1.Series["Default"].Points[2].BackGradientStyle = (GradientStyle)GradientStyle.Parse(typeof(GradientStyle), GradientList.SelectedItem.Text);
				Chart1.Series["Default"].Points[2].BackHatchStyle = (ChartHatchStyle)ChartHatchStyle.Parse(typeof(ChartHatchStyle), HatchingList.SelectedItem.Text);
				Chart1.Series["Default"].Points[2].BorderWidth = int.Parse(BorderSizeList.SelectedItem.Text);
				Chart1.Series["Default"].Points[2].BorderDashStyle = (ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), BorderDashStyleList.SelectedItem.Text);
				Chart1.Series["Default"].ShadowOffset = int.Parse(ShadowOffsetList.SelectedItem.Text);

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
