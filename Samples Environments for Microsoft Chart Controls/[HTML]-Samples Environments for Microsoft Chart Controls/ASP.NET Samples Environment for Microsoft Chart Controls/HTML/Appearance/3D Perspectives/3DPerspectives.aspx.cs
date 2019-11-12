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
	public partial class Perspectives3D : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Set the X Angle
			Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = int.Parse(Inclination.SelectedItem.Value);

			// Set the Y Angle
			Chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = int.Parse(Rotation.SelectedItem.Value);

			// Set Perspective
			Chart1.ChartAreas["ChartArea1"].Area3DStyle.Perspective = int.Parse(Perspective.SelectedItem.Value);
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

		protected void YAngle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Set the Y Angle
			Chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = int.Parse(Rotation.SelectedItem.Value);
		}

		protected void Perspective_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Set Perspective
			Chart1.ChartAreas["ChartArea1"].Area3DStyle.Perspective = int.Parse(Perspective.SelectedItem.Value);
		}

		protected void XAngle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Set the X Angle
			Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = int.Parse(Inclination.SelectedItem.Value);
		}

		
		
		
	
	}	
}
