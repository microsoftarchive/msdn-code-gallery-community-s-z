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
	/// Summary description for FindByMaxMinValues.
	/// </summary>
	public partial class FindByMaxMinValues : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data
			Random random = new Random();
			for(int pointIndex = 0; pointIndex < 20; pointIndex++)
			{
				Chart1.Series["Series1"].Points.AddY(random.Next(50, 950));
			}

			// Find point with maximum Y value and change color
			DataPoint maxValuePoint = Chart1.Series["Series1"].Points.FindMaxByValue();
			maxValuePoint.Color = Color.FromArgb(224,64,10);

																										
			// Find point with minimum Y value and change color
			DataPoint minValuePoint = Chart1.Series["Series1"].Points.FindMinByValue();
			minValuePoint.Color = Color.FromArgb(252,180,65);

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
