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
    /// Summary description for CallbackEvent.
    /// </summary>
	public partial class CallbackEvent : System.Web.UI.Page
	{
        /// <summary>
        /// Page Load event handler.
        /// </summary>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Note that special keywords were used to represent series name and data point index.
            foreach (Series series in this.Chart1.Series)
            {
                series.PostBackValue = "#SERIESNAME;#INDEX";
            }
        }

        /// <summary>
        /// Handles the Click event of the Chart1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.ImageMapEventArgs"/> instance containing the event data.</param>
        protected void Chart1_Click(object sender, ImageMapEventArgs e)
        {
            // get series name and point index
            string[] pointData = e.PostBackValue.Split(';');
            Series series = Chart1.Series[pointData[0]];
            DataPoint point = series.Points[Int32.Parse(pointData[1])];

            this.PointData.Value = e.PostBackValue;
            this.PointValue.Text = point.YValues[0].ToString();
            
            // show the input panel and focus to text box
            this.InputPanel.Visible = true;
            this.PointValue.Focus();
        
        }

        /// <summary>
        /// Handles the Click event of the Button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            // get series name and point index
            string[] pointData = this.PointData.Value.Split(';');
            Series series = Chart1.Series[pointData[0]];
            DataPoint point = series.Points[Int32.Parse(pointData[1])];
            // update point value
            point.YValues[0] = Double.Parse(this.PointValue.Text);
            // hide the input panel
            this.InputPanel.Visible = false;
        }

    }
}
