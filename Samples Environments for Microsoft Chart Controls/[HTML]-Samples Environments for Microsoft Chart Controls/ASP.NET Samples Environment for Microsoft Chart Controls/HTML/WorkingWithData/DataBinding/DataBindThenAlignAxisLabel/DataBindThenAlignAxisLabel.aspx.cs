using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data.OleDb;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for ImageMapCustom.
	/// </summary>
	public partial class DataBindThenAlignAxisLabel : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			LoadData();

			if(AlignSeries.Checked)
			{
				Chart1.AlignDataPointsByAxisLabel();
			}
		}

		private void LoadData()
		{
			// clear out the old points
			foreach(Series ser in Chart1.Series)
			{
				ser.Points.Clear();
				ser.IsXValueIndexed = false;

				// show data point Axis Labels as data point label
				ser.Label = "#AXISLABEL";
			}

			// initialize arrays for series 1
			double [] yval1 = { 2,6,5};
			string [] xval1 = { "Peter", "Andrew", "Julie"};

			// initialize arrays for series 2
			double [] yval2 = { 4,5,3};
			string [] xval2 = { "Peter", "Andrew", "Dave"};

			// initialize arrays for series 3
			double [] yval3 = { 6,5};
			string [] xval3 = { "Julie", "Mary"};

			// bind the arrays to each data series
			Chart1.Series["Series1"].Points.DataBindXY(xval1,yval1);
			Chart1.Series["Series2"].Points.DataBindXY(xval2,yval2);
			Chart1.Series["Series3"].Points.DataBindXY(xval3,yval3);
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
