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
	/// Summary description for ImageMapDrillDown.
	/// </summary>
	public partial class ImageMapDrillDown : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populating series data
			Random	random = new Random();
			for(int pointIndex = 1; pointIndex < 15; pointIndex++)
			{
				Chart1.Series["Brand1"].Points.AddXY(1990 + pointIndex, random.Next(1000, 10000));
				Chart1.Series["Brand2"].Points.AddXY(1990 + pointIndex, random.Next(1000, 10000));
				Chart1.Series["Brand3"].Points.AddXY(1990 + pointIndex, random.Next(1000, 10000));
				Chart1.Series["Brand4"].Points.AddXY(1990 + pointIndex, random.Next(1000, 10000));
			}

			UpdateChart();
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

		protected void UpdateChartButton_Click(object sender, System.EventArgs e)
		{
			UpdateChart();
		}

		protected void CheckBoxNewWindow_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateChart();
		}

		public void UpdateChart()
		{
			// Set a web site link for all series
			Chart1.Series["Brand1"].Url = TextBoxFord.Text;
			Chart1.Series["Brand2"].Url = TextBoxToyota.Text;
			Chart1.Series["Brand3"].Url = TextBoxMazda.Text;
			Chart1.Series["Brand4"].Url = TextBoxPontiac.Text;

			// Set a web site link for all series legend items
			Chart1.Series["Brand1"].LegendUrl = TextBoxFord.Text;
			Chart1.Series["Brand2"].LegendUrl = TextBoxToyota.Text;
			Chart1.Series["Brand3"].LegendUrl = TextBoxMazda.Text;
			Chart1.Series["Brand4"].LegendUrl = TextBoxPontiac.Text;

			// Setting attribute to "TARGET='_blanc'" will open a link in the new window
			string attrib = "";
			if(CheckBoxNewWindow.Checked)
			{
				attrib = "target=\"_blank\"";
			}

			// Set series and series legend item map area attribute which will determine
			// if the web site is opened in existing or new window
			foreach(Series series in Chart1.Series)
			{
				series.MapAreaAttributes = attrib;
				series.LegendMapAreaAttributes = attrib;
			}
		}

	}
}
