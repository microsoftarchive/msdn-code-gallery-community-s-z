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
    /// Summary description for SelectingChartTypes.
	/// </summary>
    public partial class SelectingChartTypes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                this.Chart1.ViewStateContent = SerializationContents.All;
                this.Chart1.EnableViewState = true;

                this.Chart1.Legends[0].CustomItems[0].Cells[0].PostBackValue = "LegendClick/0";
                this.Chart1.Legends[0].CustomItems[1].Cells[0].PostBackValue = "LegendClick/1";
                this.Chart1.Legends[0].CustomItems[2].Cells[0].PostBackValue = "LegendClick/2";
                
                // Initialize chart settings
                Series series = Chart1.Series[0];

                // Fill data
                this.FillStockData(series, 50, 100, DateTime.Now);


                // Format axes
                this.Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "F0";
                this.Chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MMM dd";
                this.Chart1.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;

                // Set axis marks to be on bottom
                this.Chart1.ChartAreas[0].AxisX.IsMarksNextToAxis = false;

                // Show end labels for Y axis
                this.Chart1.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = true;

                // Set initial properties for border and shadows
                series.BorderWidth = 1;
                series.ShadowOffset = 1;
                series.ShadowColor = Color.FromArgb(240, 64, 64, 64);

            }
        }

        protected void Chart1_Click(object sender, ImageMapEventArgs e)
        {
            // If user clicks on the map area attribute that corresponds to a legend item
            if (e.PostBackValue.StartsWith("LegendClick"))
            {
                string args = e.PostBackValue.Split('/')[1];
                // Identify which legend item was clicked
                int index = int.Parse(args);

                // Legend item result
                LegendItem legendItem = this.Chart1.Legends[0].CustomItems[index];

                // Resets all radio button images to be unchecked
                foreach (LegendItem item in this.Chart1.Legends[0].CustomItems)
                {
                    item.Cells[0].ImageTransparentColor = Color.Black;
                    item.Cells[0].Image = "radio_button_unchecked.gif";
                }

                this.Chart1.Series[0].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), legendItem.Cells[1].Text, true);
                this.Chart1.Series[0].BorderWidth = this.Chart1.Series[0].ChartType == SeriesChartType.Line ? 3 : 1;
                legendItem.Cells[0].Image = "radio_button_checked.gif";
                legendItem.Cells[0].ImageTransparentColor = Color.Green;
            }
        }


        /// <summary>
        /// Random Stock Data Generator
        /// </summary>
        private void FillStockData(Series series, int period, double high, DateTime firstDay)
        {
            Random rand;

            // Use a number to calculate a starting value for the pseudo-random number sequence
            rand = new Random(3221);

            if (high < 1)
                high += 1;

            // The first Close value
            double close = high - rand.NextDouble();

            // The first Low value
            double low = close - rand.NextDouble();

            // The first Open value
            double open = (high - low) * rand.NextDouble() + low;

            // The first Volume value
            double volume = 100 + 15 * rand.NextDouble();

            // The first day X and Y values
            series.Points.AddXY(firstDay, high);
            series.Points[0].YValues[1] = low;

            // The Open value is not used.
            series.Points[0].YValues[2] = open;
            series.Points[0].YValues[3] = close;

            // Days loop
            for (int day = 1; day <= period; day++)
            {

                // Calculate High, Low and Close values
                high = series.Points[day - 1].YValues[2] + rand.NextDouble();
                close = high - rand.NextDouble();
                low = close - rand.NextDouble();
                open = (high - low) * rand.NextDouble() + low;

                // The low cannot be less than yesterday close value.
                if (low > series.Points[day - 1].YValues[2])
                    low = series.Points[day - 1].YValues[2];

                // Set data points values
                series.Points.AddXY(day, high);
                series.Points[day].XValue = Chart1.Series[0].Points[day - 1].XValue + 1;
                series.Points[day].YValues[1] = low;
                series.Points[day].YValues[2] = open;
                series.Points[day].YValues[3] = close;
            }
        }
    }
}
