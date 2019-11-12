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
	public partial class SerStateManagement : System.Web.UI.Page
	{


        // determine what content should be serialized in the browser.
        private SerializationContents Content;

        protected void Page_Load(object sender, System.EventArgs e)
		{
            // enable or disable the control based on the selection of the check box
			Persist.Enabled = EnableStateManagement.Checked;

			// if no state managment is desired, reset the listbox to persist both
			// appearance and data for when the enable SM checkbox is checked. This
			// will prevent an exception from being thrown.
			if(!Persist.Enabled)
				Persist.SelectedIndex = 0;

			if(Persist.SelectedItem.Value == "Default")
				Content = SerializationContents.Default;
			else
				Content = SerializationContents.Data;

			// if this is not a postback or if state management is not selected, then
			// add the source chart data to the chart.
			if(!EnableStateManagement.Checked || !IsPostBack)
			{
				// Generate random data.  This routine will add 50 points to the chart
				// and will have a 2 second delay to simulate a long data retrieval time.
				Data( Chart1.Series["Input"] );
			}
			else
			{
                // Read the persisted data from the browser.  Reading is only required when
				// data has been explicitly written.
                LoadChartState();
			}

			// Set chart types for input data series.  If this is not specified AND only
			// Data is selected to be state managed, there will be no chart type set
			// causing the default chart type, Column Chart, to be displayed.  When Data
			// and Appearance is set, this is unneccessary.
			if(Persist.SelectedItem.Value == "Data")
				Chart1.Series["Input"].ChartType = SeriesChartType.Line;

			// Add other series to the chart
			AddOtherSeries();

		}

        /// <summary>
        /// Loads the state of the chart.
        /// </summary>
        private void LoadChartState()
        {
            // Read the persisted data from the browser.  Reading is only required when
            // data has been explicitly written.
            if (this.ViewState["Chart"] is String)
            {
                StringReader sr = new StringReader(this.ViewState["Chart"] as String);
                Chart1.Serializer.Content = Content;
                if (Content == SerializationContents.Default)
                {
                    Chart1.Serializer.IsResetWhenLoading = false;
                }
                Chart1.Serializer.Load(sr);
                
            }
            if (Chart1.Series["Input"].Points.Count == 0)
            {
                Data(Chart1.Series["Input"]);
            }
        }

        /// <summary>
        /// Saves the state of the chart.
        /// </summary>
        private void SaveChartState()
        {
            // create a string writer to serialize only the data source series.
            // If a selective serialization writing is used, a reader must also be
            // used. If no selective serialization is required (all series data and 
            // appearance), remove the reading and writing code.            
            StringWriter sw = new StringWriter();
            Chart1.Serializer.Content = Content;
            Chart1.Serializer.Save(sw);

            // Writing the content in page ViewState 

            this.ViewState["Chart"] = sw.ToString();
        }

        /// <summary>
        /// Raises the Page.PreRenderComplete event before the page is rendered and 
        /// saves the chart state, if applicable.
        /// </summary>
        protected override void OnPreRenderComplete(EventArgs e)
        {

            if (EnableStateManagement.Checked)
                SaveChartState();
            else
            {
                this.ViewState.Remove("Chart");
            }
            base.OnPreRenderComplete(e);
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
			// Adds a duplicate series of the source shifted up by 5
            if (SeriesAbove.Checked)
			{
                // This series may be deserialized from the state.
                if (Chart1.Series.IndexOf("Above") == -1)
                {
                    Chart1.Series.Add("Above");
				    Chart1.Series["Above"].BorderWidth = 4;
				    foreach (DataPoint pt in Chart1.Series["Input"].Points)
				    {
					    Chart1.Series["Above"].Points.AddXY(pt.XValue,pt.YValues[0]+5);
				    }
                }
                Chart1.Series["Above"].ChartType = SeriesChartType.Line;
			}
            else if (Chart1.Series.IndexOf("Above") > -1)
            {
                Chart1.Series.Remove(Chart1.Series["Above"]);
            }

			// Adds a duplicate series of the source shifted down by 5
            if (SeriesBelow.Checked )
			{
                // This series may be deserialized from the state.
                if (Chart1.Series.IndexOf("Below") == -1)
                {
                    Chart1.Series.Add("Below");
                    Chart1.Series["Below"].BorderWidth = 4;
                    foreach (DataPoint pt in Chart1.Series["Input"].Points)
                    {
                        Chart1.Series["Below"].Points.AddXY(pt.XValue, pt.YValues[0] - 5);
                    }
                }
                Chart1.Series["Below"].ChartType = SeriesChartType.Line;
            }
            else if (Chart1.Series.IndexOf("Below") > -1)
            {
                Chart1.Series.Remove(Chart1.Series["Below"]);
            }
		}

		/// <summary>
		/// This method generates random data and introduces a delay of 2 seconds.
		/// </summary>
		/// <param name="series"></param>
		private void Data( Series series )
		{
			Random rand;
			// Use a number to calculate a starting value for 
			// the pseudo-random number sequence
			rand = new Random(100);

			// Generate 50 random y values.
			for( int index = 0; index < 50; index++ )
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
            Chart1.EnableViewState = false;
        }

	}
}
