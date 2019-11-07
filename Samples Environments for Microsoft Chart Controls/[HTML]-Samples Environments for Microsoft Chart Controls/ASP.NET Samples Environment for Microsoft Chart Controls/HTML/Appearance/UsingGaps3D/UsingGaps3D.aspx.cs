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
	/// Summary description for UsingGaps3D.
	/// </summary>
	public partial class UsingGaps3D : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Set chart area point depth
			if(PointDepth.SelectedItem.Text != "")
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.PointDepth = int.Parse(PointDepth.SelectedItem.Text);

			// Set chart area point gap depth
			if(PointDepth.SelectedItem.Text != "")
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.PointGapDepth = int.Parse(PointGapDepth.SelectedItem.Text);

			// Set chart area 3D rotation
			if(RotateY.SelectedItem.Text != "")
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = int.Parse(RotateY.SelectedItem.Text);

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
