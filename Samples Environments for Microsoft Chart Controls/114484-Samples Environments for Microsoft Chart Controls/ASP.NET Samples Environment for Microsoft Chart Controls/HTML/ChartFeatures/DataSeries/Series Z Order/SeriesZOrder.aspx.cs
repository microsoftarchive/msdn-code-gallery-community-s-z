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
	public partial class SeriesZOrder : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			// Create references to series
			Series [] series = new Series[3];
			series[0] = Chart1.Series["Series1"];
			series[1] = Chart1.Series["Series2"];
			series[2] = Chart1.Series["Series3"];

			// Remove all series from the collection
			Chart1.Series.Clear();

			// Add chart series into the collection in selected order
			switch( SeriesOrder.SelectedItem.Text )
			{
				case "Bar-Spline-Area":
					Chart1.Series.Add(series[0]);
					Chart1.Series.Add(series[1]);
					Chart1.Series.Add(series[2]);
					break;
				case "Bar-Area-Spline":
					Chart1.Series.Add(series[0]);
					Chart1.Series.Add(series[2]);
					Chart1.Series.Add(series[1]);
					break;
				case "Spline-Bar-Area":
					Chart1.Series.Add(series[1]);
					Chart1.Series.Add(series[0]);
					Chart1.Series.Add(series[2]);
					break;
				case "Spline-Area-Bar":
					Chart1.Series.Add(series[1]);
					Chart1.Series.Add(series[2]);
					Chart1.Series.Add(series[0]);
					break;
				case "Area-Bar-Spline":
					Chart1.Series.Add(series[2]);
					Chart1.Series.Add(series[0]);
					Chart1.Series.Add(series[1]);
					break;
				case "Area-Spline-Bar":
					Chart1.Series.Add(series[2]);
					Chart1.Series.Add(series[1]);
					Chart1.Series.Add(series[0]);
					break;
			}

			// Set non-transparent colors
			if(SolidColors.Checked)
			{
				foreach(Series ser in Chart1.Series)
				{
					ser.Color = Color.Empty;
				}
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

		}
		#endregion


		
	
	}	
}
