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
using System.Drawing.Drawing2D;
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public partial class ChartAppearance : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!this.IsPostBack)
			{
				// Add Hatch styles to control.
				foreach(string colorName in Enum.GetNames(typeof(ChartHatchStyle)))
				{
					HatchStyle.Items.Add(colorName);
				}
				HatchStyle.Items[0].Selected = true;
		
				// Add Chart Gradient types to control.
				foreach(string colorName in Enum.GetNames(typeof(GradientStyle)))
				{
					Gradient.Items.Add(colorName);
				}

				// Add Chart Line styles to control.
				foreach(string colorName in Enum.GetNames(typeof(ChartDashStyle)))
				{
					BorderDashStyle.Items.Add(colorName);
				}

				BorderDashStyle.Items.FindByValue("Solid").Selected = true;

				// Add Image Mode
				foreach(string item in Enum.GetNames(typeof(ChartImageWrapMode)))
				{
					ImageMode.Items.Add(item);
				}
				ImageMode.SelectedIndex = 5;

				// Add Image Aligne
				foreach(string item in Enum.GetNames(typeof(ChartImageAlignmentStyle)))
				{
					ImageAlign1.Items.Add(item);
				}
				ImageAlign1.SelectedIndex = 2;
			}

			// Set Back Color
			Chart1.BackColor = Color.FromName(BackColor.SelectedItem.Value);

			// Set Back Gradient End Color
			Chart1.BackSecondaryColor = Color.FromName(ForeColor.SelectedItem.Value);

			// Set Hatch Style
			Chart1.BackHatchStyle = (ChartHatchStyle)ChartHatchStyle.Parse(typeof(ChartHatchStyle), HatchStyle.SelectedItem.Text);

			// Set Gradient Type
			Chart1.BackGradientStyle = (GradientStyle)GradientStyle.Parse(typeof(GradientStyle), Gradient.SelectedItem.Text);

			// Set Border Color
			Chart1.BorderColor = Color.FromName(BorderColor.SelectedItem.Value);

			// Set Border Style
			Chart1.BorderlineDashStyle = (ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), BorderDashStyle.SelectedItem.Text);

			// Set Border Width
			Chart1.BorderWidth = int.Parse(BorderSize.SelectedItem.Value);

			// Chart Image Mode
			Chart1.BackImageWrapMode = (ChartImageWrapMode)ChartImageWrapMode.Parse(typeof(ChartImageWrapMode), ImageMode.SelectedItem.Text);

			// Chart Image Align
			Chart1.BackImageAlignment = (ChartImageAlignmentStyle)ChartImageAlignmentStyle.Parse(typeof(ChartImageAlignmentStyle), ImageAlign1.SelectedItem.Text);

			// Disable secondary back color if gradient and hatching are not used
			ForeColor.Enabled = (HatchStyle.SelectedIndex != 0 || Gradient.SelectedIndex != 0);

			// Set Image
			ImageAlign1.Enabled = false;
			ImageMode.Enabled = Image1.Checked;
			if( Image1.Checked )
			{
				Chart1.BackImage = "Flag.gif";
				Chart1.BackImageTransparentColor = Color.White;
				if( ImageMode.SelectedItem.Value == "Unscaled" )
				{
					ImageAlign1.Enabled = true;
				}
			}
			else
			{
				Chart1.BackImage = "";
			}

			// Enable/disable border attributes
			BorderColor.Enabled = (BorderDashStyle.SelectedIndex != 0);
			BorderSize.Enabled = (BorderDashStyle.SelectedIndex != 0);
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

		protected void Gradient_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			HatchStyle.SelectedIndex = 0;

			// Set Gradient Type
			Chart1.BackGradientStyle = (GradientStyle)GradientStyle.Parse(typeof(GradientStyle), Gradient.SelectedItem.Text);
			Chart1.BackHatchStyle = ChartHatchStyle.None;
		}

		protected void HatchStyle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Gradient.SelectedIndex = 0;

			// Set Hatch Style
			Chart1.BackHatchStyle = (ChartHatchStyle)ChartHatchStyle.Parse(typeof(ChartHatchStyle), HatchStyle.SelectedItem.Text);
			Chart1.BackGradientStyle = GradientStyle.None;
		}

	}	
}
