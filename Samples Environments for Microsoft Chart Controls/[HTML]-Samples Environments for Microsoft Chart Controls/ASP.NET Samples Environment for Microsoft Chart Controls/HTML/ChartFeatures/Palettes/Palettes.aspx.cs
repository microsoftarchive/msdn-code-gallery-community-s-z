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
    /// Summary description for Palettes.
	/// </summary>
	public partial class Palettes : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (this.FontNameList.SelectedItem.ToString() == "Custom") 
            {
                this.Dropdownlist1.Enabled = true;
                Chart1.Palette = ChartColorPalette.None;
                UpdateCustomPalette();
            }

            else 
            {
                this.Dropdownlist1.Enabled = false;
                Chart1.PaletteCustomColors = new Color[0];
                this.Chart1.Palette = (ChartColorPalette)ChartColorPalette.Parse(typeof(ChartColorPalette), this.FontNameList.SelectedItem.ToString());
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

        private void UpdateCustomPalette()
        {
            Color[] colorSet;
            if (this.Dropdownlist1.SelectedItem.ToString() == "CorporateGold")
            {
                colorSet = new Color[4] { Color.FromArgb(224, 131, 10), Color.FromArgb(255, 227, 130), Color.FromArgb(251, 197, 65), Color.FromArgb(251, 180, 65) };
                Chart1.PaletteCustomColors = colorSet;
            }

            else if (Dropdownlist1.SelectedItem.ToString() == "CorporateBlue")
            {
                colorSet = new Color[4] { Color.FromArgb(5, 100, 146), Color.FromArgb(144, 218, 255), Color.FromArgb(149, 193, 254), Color.FromArgb(65, 140, 240) };
                Chart1.PaletteCustomColors = colorSet;
            }

            else
            {
                colorSet = new Color[4] { Color.FromArgb(120, 147, 190), Color.FromArgb(241, 185, 168), Color.FromArgb(128, 184, 209), Color.FromArgb(243, 210, 136) };
                Chart1.PaletteCustomColors = colorSet;
            }
        }

	}
}
