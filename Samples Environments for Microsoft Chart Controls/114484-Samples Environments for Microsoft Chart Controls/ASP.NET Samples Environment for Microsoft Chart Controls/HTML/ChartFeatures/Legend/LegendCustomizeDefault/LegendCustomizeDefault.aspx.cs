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
	/// Summary description for LegendCustomizeDefault.
	/// </summary>
	public partial class LegendCustomizeDefault : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate chart with data
			double[]	yValues1 = {12, 56, 87, 39, 27};
			double[]	yValues2 = {55, 89, 34, 67, 55};
			double[]	yValues3 = {19, 55, 45, 78, 16};
			Chart1.Series["Series1"].Points.DataBindY(yValues1);
			Chart1.Series["Series2"].Points.DataBindY(yValues2);
			Chart1.Series["Series3"].Points.DataBindY(yValues3);
		}


        /// <summary>
        /// Handles the CustomizeLegend event of the Chart1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.DataVisualization.Charting.CustomizeLegendEventArgs"/> instance containing the event data.</param>
        protected void Chart1_CustomizeLegend(object sender, CustomizeLegendEventArgs e)
        {
            // Loop through all default legend items
            if (e.LegendName == "Default")
            {
                foreach (LegendItem item in e.LegendItems)
                {
                    // Check item series name
                    if (item.SeriesName == SeriesNameList.SelectedItem.Text)
                    {
                        // Remove the shadow effect
                        if (CustomizationList.SelectedItem.Text == "Set Shadow")
                        {
                            item.ShadowColor = Color.FromArgb(128, 64, 64, 64);
                            item.ShadowOffset = 2;
                        }
                        // Change item style
                        else if (CustomizationList.SelectedItem.Text == "Set Line Style")
                        {
                            item.ImageStyle = LegendImageStyle.Line;
                            item.BorderWidth = 2;
                            item.BorderColor = Color.Black;
                        }
                        // Change item text
                        else if (CustomizationList.SelectedItem.Text == "Change Text")
                        {
                            item.Cells[1].Text = "My Name";
                        }
                        // Change item color
                        else if (CustomizationList.SelectedItem.Text == "Change Color")
                        {
                            item.Color = Color.Green;
                        }
                    }
                }

            }

        }
    }
}
