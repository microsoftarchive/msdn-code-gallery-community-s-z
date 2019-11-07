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
	public partial class ZOrder : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList Series1;
		protected System.Web.UI.WebControls.DropDownList Series2;
		protected System.Web.UI.WebControls.DropDownList Series3;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            ReorderChart();
		}

        protected override void OnLoadComplete(EventArgs e)
        {
            //AfterLoad();
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
			this.Chart1.Click +=new ImageMapEventHandler(this.Chart1_Click);

		}
		#endregion

		public void ReorderChart()
		{
			// Create references to chart areas.
			ChartArea [] areas = new ChartArea[3];
			areas[0] = Chart1.ChartAreas["Chart Area 1"];
			areas[1] = Chart1.ChartAreas["Chart Area 2"];
			areas[2] = Chart1.ChartAreas["Chart Area 3"];

			// Remove all chart areas from the collection
			Chart1.ChartAreas.Clear();

			// Create references to series
			Series [] series = new Series[6];
			series[0] = Chart1.Series["Series1"];
			series[1] = Chart1.Series["Series2"];
			series[2] = Chart1.Series["Series3"];
			series[3] = Chart1.Series["Series4"];
			series[4] = Chart1.Series["Series5"];
			series[5] = Chart1.Series["Series6"];

			// Remove all series from the collection
			Chart1.Series.Clear();

			// Selected item from check box
			switch( AreaOrder.SelectedItem.Value )
			{
				case "1-2-3":
					// Add chart areas to the collection in selected order
					Chart1.ChartAreas.Add(areas[0]);
					Chart1.ChartAreas.Add(areas[1]);
					Chart1.ChartAreas.Add(areas[2]);
					break;
				case "1-3-2":
					Chart1.ChartAreas.Add(areas[0]);
					Chart1.ChartAreas.Add(areas[2]);
					Chart1.ChartAreas.Add(areas[1]);
					break;
				case "2-1-3":
					Chart1.ChartAreas.Add(areas[1]);
					Chart1.ChartAreas.Add(areas[0]);
					Chart1.ChartAreas.Add(areas[2]);
					break;
				case "2-3-1":
					Chart1.ChartAreas.Add(areas[1]);
					Chart1.ChartAreas.Add(areas[2]);
					Chart1.ChartAreas.Add(areas[0]);
					break;
				case "3-1-2":
					Chart1.ChartAreas.Add(areas[2]);
					Chart1.ChartAreas.Add(areas[0]);
					Chart1.ChartAreas.Add(areas[1]);
					break;
				case "3-2-1":
					Chart1.ChartAreas.Add(areas[2]);
					Chart1.ChartAreas.Add(areas[1]);
					Chart1.ChartAreas.Add(areas[0]);
					break;
			}

			// Add series to the collection in selected order
			if( SeriesOrder.SelectedItem.Value == "1-2" )
			{
				Chart1.Series.Add(series[0]);
				Chart1.Series.Add(series[1]);
				Chart1.Series.Add(series[2]);
				Chart1.Series.Add(series[3]);
				Chart1.Series.Add(series[4]);
				Chart1.Series.Add(series[5]);
			}
			else
			{
				Chart1.Series.Add(series[3]);
				Chart1.Series.Add(series[4]);
				Chart1.Series.Add(series[5]);
				Chart1.Series.Add(series[0]);
				Chart1.Series.Add(series[1]);
				Chart1.Series.Add(series[2]);
			}
		}

		private void Chart1_Click(object sender, System.Web.UI.WebControls.ImageMapEventArgs e)
		{
            if (!String.IsNullOrEmpty(e.PostBackValue))
            {
                // Change selected item from combo box.
                if (e.PostBackValue == "Chart Area 1")
                    AreaOrder.SelectedIndex = 5;
                else if (e.PostBackValue == "Chart Area 2")
                    AreaOrder.SelectedIndex = 1;
                else if (e.PostBackValue == "Chart Area 3")
                    AreaOrder.SelectedIndex = 0;
                this.ReorderChart();
            }
		}


        protected void Chart1_PostPaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement == Chart1)
            {
                for (Int32 i = Chart1.ChartAreas.Count-1; i >= 0; i--)
                {
                    ChartArea area = Chart1.ChartAreas[i];
                    MapArea mapArea = new MapArea(area.Name, String.Empty, String.Empty, area.Name, area.Position.ToRectangleF(), null);
                    Chart1.MapAreas.Add(mapArea);
                }
            }
        }
    }	
}
