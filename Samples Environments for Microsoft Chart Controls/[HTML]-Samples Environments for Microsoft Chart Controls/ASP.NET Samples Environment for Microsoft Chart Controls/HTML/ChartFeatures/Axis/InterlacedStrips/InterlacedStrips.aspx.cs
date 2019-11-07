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
	/// Summary description for InterlacedStrips.
	/// </summary>
	public partial class InterlacedStrips : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Enable interlaced strip lines
			Chart1.ChartAreas["ChartArea1"].AxisY.IsInterlaced = enableInterlaced.Checked;
			KnownColors.Enabled = enableInterlaced.Checked;

			// Set strips color
			Chart1.ChartAreas["ChartArea1"].AxisY.InterlacedColor = Color.FromName(KnownColors.SelectedItem.ToString());
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
