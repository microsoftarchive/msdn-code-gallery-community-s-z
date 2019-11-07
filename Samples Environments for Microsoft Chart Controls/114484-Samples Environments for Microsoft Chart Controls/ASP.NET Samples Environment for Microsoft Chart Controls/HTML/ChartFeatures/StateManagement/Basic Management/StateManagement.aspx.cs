using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public partial class StateManagement : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            // enable or disable view state based on user selection.
            Chart1.EnableViewState = EnableStateManagement.Checked;

            // determine what content should be serialized in the browser.
            Chart1.ViewStateContent = SerializationContents.Default;

            if (Chart1.Series["Input"].Points.Count == 0)
            {
                // Generate random data and introduce a 2 second delay to 
                // simulate a long data retrieval time
                Chart1.Series["Input"].ChartType = SeriesChartType.Line;
                Data(Chart1.Series["Input"]);
            }

            // Add the other series to the chart
            AddOtherSeries();
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
			this.Init += new System.EventHandler(this.Form_Init);

		}
		#endregion

		
		

		/// <summary>
		/// This method adds additional series based on a the state of the web controls.  These
		/// series will not be persisted therefore their state will not be managed.
		/// </summary>
		private void AddOtherSeries()
		{

			// remove the Above series to avoid a duplication from one that was serialized and 
			// one that we may create now
			int index = Chart1.Series.IndexOf("Above");
			if(index >= 0)
				Chart1.Series.RemoveAt(index);

			// remove the Below series to avoid a duplication from one that was serialized and 
			// one that we may create now
            index = Chart1.Series.IndexOf("Below");
			if(index >= 0)
				Chart1.Series.RemoveAt(index);

			// Adds a duplicate series of the source shifted up by 5
			if(SeriesAbove.Checked)
			{
				Chart1.Series.Add("Above");
				Chart1.Series["Above"].ChartType = SeriesChartType.Line;
				foreach (DataPoint pt in Chart1.Series["Input"].Points)
				{
					Chart1.Series["Above"].Points.AddXY(pt.XValue,pt.YValues[0]+5);
				}
			}

			// Adds a duplicate series of the source shifted down by 5
			if(SeriesBelow.Checked)
			{
				Chart1.Series.Add("Below");
				Chart1.Series["Below"].ChartType = SeriesChartType.Line;
				foreach (DataPoint pt in Chart1.Series["Input"].Points)
				{
					Chart1.Series["Below"].Points.AddXY(pt.XValue,pt.YValues[0]-5);
				}
			}
		}

		/// <summary>
        /// This method generates random data and simulates a long data retrieval time of 2 seconds.
        /// </summary>
		/// <param name="series"></param>
		private void Data( Series series )
		{
			// clear any and all points that may exist in the points collection
			// so that they don't become appended to a previous set of data that
			// may have been serialized in another page load.
			series.Points.Clear();

			Random rand;
			// Use a number to calculate a starting value for 
			// the pseudo-random number sequence
			rand = new Random();

			// Generate 50 random y values.
			for( int index = 0; index < 25; index++ )
			{
				// Generate the first point
				series.Points.AddXY(index+1,0);
				series.Points[index].YValues[0] = 10;

				// Use previous point to calculate a next one.
				if( index > 0 )
					series.Points[index].YValues[0] = series.Points[index-1].YValues[0] + 4*rand.NextDouble() - 2;

			}
            
            // Simulate long data retrieval time of 2 seconds.
            System.Threading.Thread.Sleep(2000);
        }

		protected void LoadData_Click(object sender, System.EventArgs e)
		{
			// do nothing.... the Page_Load will be called and will
			// do all the work required.
		}

		protected void Form_Init(object sender, System.EventArgs e)
		{
            // Enabling or disabling the viewstate must be done very early in the loading of 
            // a web page which is why it is done in the Page.Init event.  The preferred
            // way to initialize the viewstate is done in the property browser so the 
            // property value is persisted in the ASPX page.
            Chart1.EnableViewState = true;
        }
	}
}
