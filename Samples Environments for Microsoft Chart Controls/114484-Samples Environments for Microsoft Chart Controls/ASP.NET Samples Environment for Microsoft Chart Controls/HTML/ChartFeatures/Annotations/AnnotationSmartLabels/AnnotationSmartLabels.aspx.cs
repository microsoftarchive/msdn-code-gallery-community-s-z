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
	/// Summary description for LegendCustomPosition.
	/// </summary>
	public partial class AnnotationSmartLabels : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// determine what content should be serialized in the browser.
			// By default all appearance and data is serialized thereby
			// preventing us from having to re-access the source data for
			// all other series that exist.
			Chart1.ViewStateContent = SerializationContents.Default;

			if(!this.IsPostBack)
			{
				FillData();
			}

			Chart1.Series["Default"].SmartLabelStyle.Enabled = true;

			foreach(Annotation annotation in Chart1.Annotations)
				annotation.SmartLabelStyle.Enabled = EnableSmartLabels.Checked;

			foreach(Annotation annotation in Chart1.Annotations)
				annotation.SmartLabelStyle.IsOverlappedHidden = IsOverlappedHidden.Checked;

			if(EnableSmartLabels.Checked)
				IsOverlappedHidden.Enabled = true;
			else
				IsOverlappedHidden.Enabled = false;

		}

		/// <summary>
		/// Fill Data Points
		/// </summary>
		private void FillData()
		{
			// Set initial number of data points.
			int numOfPoints = 5;

			// Initialize random nubers.
			Random rand = new Random();

			// Series loop
			foreach(Series series in Chart1.Series)
			{
				// Remove all data points from collection.
				series.Points.Clear();

				// Data points loop
				for( int index = 0; index <= numOfPoints; index++ )
				{
					series.Points.Add( new DataPoint( 0, rand.NextDouble() * 50 ) );
				}
			}

			Chart1.Annotations[0].AnchorDataPoint = Chart1.Series[0].Points[3];
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
						this.Init += new System.EventHandler(this.AnnotationSmartLabels_Init);

					}
		#endregion

		protected void AnnotationSmartLabels_Init(object sender, System.EventArgs e)
		{
			// enable or disable the view state
			Chart1.EnableViewState = true;
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			FillData();
		
		}

	}
}
