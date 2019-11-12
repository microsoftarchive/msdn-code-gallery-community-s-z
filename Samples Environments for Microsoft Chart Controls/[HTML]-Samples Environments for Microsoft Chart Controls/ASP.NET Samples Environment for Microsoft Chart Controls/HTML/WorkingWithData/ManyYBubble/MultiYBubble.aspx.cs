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

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for ImageMapCustom.
	/// </summary>
	public partial class MultiYBubble : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Create a new random number generator
			Random rnd = new Random();

			// Data points X value is using current date
			DateTime	date = DateTime.Now.Date;

			// Add points to the stock chart series
			for(int index = 0; index < 10; index++)
			{
				Chart1.Series["Series 1"].Points.AddXY(
					date,				// X value is a date
					rnd.Next(40, 50),	// High Y value
					rnd.Next(10, 20),	// Low Y value
					rnd.Next(20, 40),	// Open Y value
					rnd.Next(20, 40) );	// Close Y value

				// Add 1 day to our X value
				date = date.AddDays(1);
			}
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
