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
    /// Summary description for ClickEvent.
	/// </summary>
	public partial class ClickEvent : System.Web.UI.Page
	{
        /// <summary>
        /// Page Load event handler.
        /// </summary>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.Chart1.Click += new ImageMapEventHandler(Chart1_Click);
            
            // direct using of PostBackValue
            foreach (Series series in this.Chart1.Series)
            {
                series.PostBackValue = "series:" + series.Name + ",#INDEX";
            }

            // transfer of click coordinates. getCoordinates is a javascript function.
            this.Chart1.Attributes["onclick"] = ClientScript.GetPostBackEventReference(this.Chart1, "@").Replace("'@'", "'chart:'+_getCoord(event)");

            // set position to relative in order to get proper coordinates.
            this.Chart1.Style[HtmlTextWriterStyle.Position] = "relative";
            this.ClientScript.RegisterClientScriptBlock(
                typeof(Chart),
                "Chart",
                @"function _getCoord(event){if(typeof(event.x)=='undefined'){return event.layerX+','+event.layerY;}return event.x+','+event.y;}",
                true);

        }


        /// <summary>
        /// Handles the Click event of the Chart1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.ImageMapEventArgs"/> instance containing the event data.</param>
        protected void Chart1_Click(object sender, ImageMapEventArgs e)
        {
            this.Chart1.Titles["ClickedElement"].Text = "Nothing";

            string[] input = e.PostBackValue.Split(':');
            if (input.Length == 2)
            {
                string[] seriesData = input[1].Split(',');
                if (input[0].Equals("series"))
                {
                    this.Chart1.Titles["ClickedElement"].Text = "Last Clicked Element: " + seriesData[0] + " - Data Point #" + seriesData[1];
                }
                else if (input[0].Equals("chart"))
                {
                    // hit test of X and Y click point
                    HitTestResult hitTestResult = this.Chart1.HitTest(Int32.Parse(seriesData[0]), Int32.Parse(seriesData[1]));
                    if (hitTestResult != null)
                    {
                        this.Chart1.Titles["ClickedElement"].Text = "Last Clicked Element: " + hitTestResult.ChartElementType.ToString();
                    }
                }
            }
        }
}
}
