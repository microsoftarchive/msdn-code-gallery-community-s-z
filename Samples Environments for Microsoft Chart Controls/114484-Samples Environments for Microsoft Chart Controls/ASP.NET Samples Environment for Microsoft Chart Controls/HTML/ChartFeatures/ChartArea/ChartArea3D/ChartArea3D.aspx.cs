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
	/// Summary description for ChartArea3D.
	/// </summary>
	public partial class ChartArea3D : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label2;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Check if 3D option is checked
			Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = ShowIn3D.Checked;
			if(ShowIn3D.Checked)
			{
				Chart1.Titles[0].Text = "3D Chart";
			}
			else
			{
				Chart1.Titles[0].Text = "2D Chart";
			}
			RightAngleAxis.Enabled = ShowIn3D.Checked;
			WallWidth.Enabled = ShowIn3D.Checked;
			RotateX.Enabled = ShowIn3D.Checked;
			RotateY.Enabled = ShowIn3D.Checked;

			// Set right angle axis flag
			Chart1.ChartAreas["ChartArea1"].Area3DStyle.IsRightAngleAxes = RightAngleAxis.Checked;

			// Set chart area wall width
			if(WallWidth.SelectedItem.Text != "")
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.WallWidth = int.Parse(WallWidth.SelectedItem.Text);

			// Set chart area 3D rotation
			if(RotateX.SelectedItem.Text != "")
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = int.Parse(RotateX.SelectedItem.Text);
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
