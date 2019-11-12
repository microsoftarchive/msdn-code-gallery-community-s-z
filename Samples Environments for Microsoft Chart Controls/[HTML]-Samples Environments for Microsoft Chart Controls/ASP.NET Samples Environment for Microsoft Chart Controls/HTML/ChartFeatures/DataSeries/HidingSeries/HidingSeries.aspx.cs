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
	public partial class HidingSeries : System.Web.UI.Page
	{


	
		protected void Page_Load(object sender, System.EventArgs e)
		{ 
			// Show/Hide series
			Chart1.Series["Series 1"].Enabled = !HideSeries1.Checked;
			Chart1.Series["Series 2"].Enabled = !HideSeries2.Checked;
			Chart1.Series["Series 3"].Enabled = !HideSeries3.Checked;
			Chart1.Series["Series 4"].Enabled = !HideSeries4.Checked;
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
