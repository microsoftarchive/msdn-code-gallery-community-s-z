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
	public partial class Borders : System.Web.UI.Page
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

				// Add Chart Gradient types to control.
				foreach(string colorName in Enum.GetNames(typeof(GradientStyle)))
				{
					Gradient.Items.Add(colorName);
				}
				Gradient.Items.FindByValue("None").Selected = true;

				// Add Chart Line styles to control.
				foreach(string skinStyle in Enum.GetNames(typeof(BorderSkinStyle)))
				{
					SkinStyle.Items.Add(skinStyle);
				}

				SkinStyle.Items.FindByValue("Emboss").Selected = true;

				
				// Add Border styles to control.
				foreach(string colorName in Enum.GetNames(typeof(ChartDashStyle)))
				{
					BorderDashStyle.Items.Add(colorName);
				}
				BorderDashStyle.Items.FindByValue("Solid").Selected = true;

				// Add Colors to controls.
				foreach(String colorName in KnownColor.GetNames(typeof(KnownColor)))
				{
					BackColor.Items.Add(colorName);
					ForeColor.Items.Add(colorName);
					BorderColor.Items.Add(colorName);
				}
				BackColor.Items.FindByValue("PeachPuff").Selected = true;
				ForeColor.Items.FindByValue("White").Selected = true;
				BorderColor.Items.FindByValue("Maroon").Selected = true;
				
			}

			// Set Border Skin
			Chart1.BorderSkin.SkinStyle = (BorderSkinStyle)ChartHatchStyle.Parse(typeof(BorderSkinStyle), SkinStyle.SelectedItem.Text);
			
			// disable controls
			this.ForeColor.Enabled = this.IsFrameStyle();
			this.BackColor.Enabled = this.IsFrameStyle();



			// set default appearance
			Chart1.BorderSkin.BorderDashStyle = ChartDashStyle.NotSet;
			Chart1.BorderSkin.BorderColor = Color.Empty;
			Chart1.BorderSkin.BorderWidth = 1;

            Chart1.BorderlineDashStyle = ChartDashStyle.NotSet;
			Chart1.BorderColor = Color.Empty;
			Chart1.BorderWidth = 1;

			if ( this.IsFrameStyle() )
			{
				// Set Back Color
				Chart1.BorderSkin.BackColor = Color.FromName(BackColor.SelectedItem.Value);

				// Set Back Gradient End Color
				Chart1.BorderSkin.BackSecondaryColor = Color.FromName(ForeColor.SelectedItem.Value);

				// Set Hatch Style
				Chart1.BorderSkin.BackHatchStyle = (ChartHatchStyle)ChartHatchStyle.Parse(typeof(ChartHatchStyle), HatchStyle.SelectedItem.Text);

				// Set Gradient Type
				Chart1.BorderSkin.BackGradientStyle = (GradientStyle)GradientStyle.Parse(typeof(GradientStyle), Gradient.SelectedItem.Text);

				// Set Border Color
				Chart1.BorderSkin.BorderColor = Color.FromName(BorderColor.SelectedItem.Value);

				// Set Border Style
				Chart1.BorderSkin.BorderDashStyle = (ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), BorderDashStyle.SelectedItem.Text);

				// Set Border Width
				Chart1.BorderSkin.BorderWidth = int.Parse(BorderSize.SelectedItem.Value);
			}
			else
			{
				// Set Border Line Color
				Chart1.BorderColor = Color.FromName(BorderColor.SelectedItem.Value);
				// Set Border Line Style
                Chart1.BorderlineDashStyle = (ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), BorderDashStyle.SelectedItem.Text);
				// Set Border Line Width
				Chart1.BorderWidth = int.Parse(BorderSize.SelectedItem.Value);
			}

			// Disable hatch if gradient is active
			if( this.IsFrameStyle() && Chart1.BorderSkin.BackGradientStyle == GradientStyle.None )
				HatchStyle.Enabled =true;
			else
				HatchStyle.Enabled =false;
			

			// Disable gradient if hatch style is active
			if( this.IsFrameStyle() && Chart1.BorderSkin.BackHatchStyle == ChartHatchStyle.None )
				Gradient.Enabled = true;
			else
				Gradient.Enabled = false;

		}

		private bool IsFrameStyle()
		{
			return Chart1.BorderSkin.SkinStyle.ToString().IndexOf("Frame") != -1;
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
