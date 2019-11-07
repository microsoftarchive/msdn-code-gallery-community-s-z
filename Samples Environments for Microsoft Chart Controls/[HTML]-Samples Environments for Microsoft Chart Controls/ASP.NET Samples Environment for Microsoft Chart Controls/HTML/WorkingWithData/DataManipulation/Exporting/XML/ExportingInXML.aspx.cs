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
	/// Summary description for ExportingInXML.
	/// </summary>
	public partial class ExportingInXML : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate chart with random data
			Random random = new Random();
			for(int pointIndex = 0; pointIndex < 7; pointIndex++)
			{
				Chart1.Series["Series1"].Points.AddXY(DateTime.Now.Date.AddDays(pointIndex), random.Next(1, 1000));
			}

			// Export chart series values into the data set
			DataSet dataSet = Chart1.DataManipulator.ExportSeriesValues("Series1");

			// Get XML data and schema from data set
			XMLTextBox.Text = dataSet.GetXml();
			SchemaTextBox.Text = dataSet.GetXmlSchema();
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
	}
}
