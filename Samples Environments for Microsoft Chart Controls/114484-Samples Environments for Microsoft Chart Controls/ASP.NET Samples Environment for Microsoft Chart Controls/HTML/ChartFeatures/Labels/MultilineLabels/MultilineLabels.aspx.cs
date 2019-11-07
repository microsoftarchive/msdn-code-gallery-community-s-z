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
	/// Summary description for MultilineLabels.
	/// </summary>
	public partial class MultilineLabels : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			// Show data points values as labels
			if(ShowValueLabels.Checked)
			{
				Chart1.Series["Series1"].IsValueShownAsLabel = true;
			}
			else
			{
				Chart1.Series["Series1"].IsValueShownAsLabel = false;
			}

			// Set axis label 
			Chart1.Series["Series1"].Points[2].AxisLabel = AxisLabel.Text;

			// Set data point label
			Chart1.Series["Series1"].Points[2].Label = PointLabel.Text;

			// Change point color
			Chart1.Series["Series1"].Points[2].Color = Color.FromArgb(120, 222, 0, 0);
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
