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
	public partial class SeriesAxis : System.Web.UI.Page
	{


	
		protected void Page_Load(object sender, System.EventArgs e)
		{ 
            Chart1.Series["Series1"].XAxisType = (AxisType)AxisType.Parse(typeof(AxisType), Series1X.SelectedItem.Text);
            Chart1.Series["Series1"].YAxisType = (AxisType)AxisType.Parse(typeof(AxisType), Series1Y.SelectedItem.Text);
            Chart1.Series["Series2"].XAxisType = (AxisType)AxisType.Parse(typeof(AxisType), Series2X.SelectedItem.Text);
            Chart1.Series["Series2"].YAxisType = (AxisType)AxisType.Parse(typeof(AxisType), Series2Y.SelectedItem.Text);
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
