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
	/// Summary description for WebForm1.
	/// </summary>
	public partial class AddingSeries : System.Web.UI.Page
	{

		private string [] charts = {"Column", "Spline", "StepLine", "Spline" };
		


	
		protected void Page_Load(object sender, System.EventArgs e)
		{ 

			// determine what content should be serialized in the browser.
			// By default all appearance and data is serialized thereby
			// preventing us from having to re-access the source data for
			// all other series that exist.
			Chart1.ViewStateContent = SerializationContents.Default;


			if(!this.IsPostBack)
			{
				this.AddButton_Click( this, EventArgs.Empty);
			}

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

		protected void Form_Init(object sender, System.EventArgs e)
		{
			// enable or disable the view state
			Chart1.EnableViewState = true;
		}

		protected void AddButton_Click(object sender, System.EventArgs e)
		{
			Random rnd = new Random();

			// add a series to the chart
			Series series = Chart1.Series.Add("Series " + (Chart1.Series.Count+1).ToString());
			series.ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), charts[Chart1.Series.Count-1], true );
			series.BorderWidth = 2;
			series.BorderColor = Color.FromArgb(120,147,190);
			series.ShadowColor = Color.FromArgb(64,0,0,0);
			series.ShadowOffset = 2;

			int j = 0;
			int MaxPoints = 10;
			while(j++ < MaxPoints)
			{
				series.Points.Add(rnd.Next(5,20));
			}
			
			RemoveButton.Enabled = Chart1.Series.Count > 1;
			AddButton.Enabled = Chart1.Series.Count < charts.Length;
		}

		protected void RemoveButton_Click(object sender, System.EventArgs e)
		{
			// remove the last series in the list of the series
			Chart1.Series.RemoveAt(Chart1.Series.Count-1);

			RemoveButton.Enabled = Chart1.Series.Count > 1;
			AddButton.Enabled = Chart1.Series.Count < charts.Length;
		}
		
		
		

	}
}
