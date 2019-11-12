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
	public partial class Appearance : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Enable Secondary Y axis
			if( Enabled.SelectedItem.Value == "True" )
			{
				// Enable Secondary Y axis
				Chart1.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.True;

				// Enable controls
				Color1.Enabled = true;
				Width1.Enabled = true;
				LineStyle1.Enabled = true;
				Arrow1.Enabled = true;
			}
			else 
			{
				// Disable Secondary Y axis
				Chart1.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.False;

				// Disable controls
				Color1.Enabled = false;
				Width1.Enabled = false;
				LineStyle1.Enabled = false;
				Arrow1.Enabled = false;
			}

			// Set Axis Color
			switch( Color1.SelectedItem.Value )
			{
				case "Red":
					Chart1.ChartAreas["ChartArea1"].AxisY2.LineColor = Color.Red;
					break;
				case "Yellow":
					Chart1.ChartAreas["ChartArea1"].AxisY2.LineColor = Color.Yellow;
					break;
				case "Blue":
					Chart1.ChartAreas["ChartArea1"].AxisY2.LineColor = Color.Blue;
					break;
				case "Green":
					Chart1.ChartAreas["ChartArea1"].AxisY2.LineColor = Color.Green;
					break;
			}

			// Set Axis Line Style
			switch( LineStyle1.SelectedItem.Value )
			{
				case "Solid":
					Chart1.ChartAreas["ChartArea1"].AxisY2.LineDashStyle = ChartDashStyle.Solid;
					break;
				case "Dot":
					Chart1.ChartAreas["ChartArea1"].AxisY2.LineDashStyle = ChartDashStyle.Dot;
					break;
				case "DashDotDot":
					Chart1.ChartAreas["ChartArea1"].AxisY2.LineDashStyle = ChartDashStyle.DashDotDot;
					break;
				case "DashDot":
					Chart1.ChartAreas["ChartArea1"].AxisY2.LineDashStyle = ChartDashStyle.DashDot;
					break;
				case "Dash":
					Chart1.ChartAreas["ChartArea1"].AxisY2.LineDashStyle = ChartDashStyle.Dash;
					break;
			}

			// Set Arrow Style
			switch( Arrow1.SelectedItem.Value )
			{
				case "None":
                    Chart1.ChartAreas["ChartArea1"].AxisY2.ArrowStyle = AxisArrowStyle.None;
					break;
				case "Triangle":
                    Chart1.ChartAreas["ChartArea1"].AxisY2.ArrowStyle = AxisArrowStyle.Triangle;
					break;
				case "SharpTriangle":
                    Chart1.ChartAreas["ChartArea1"].AxisY2.ArrowStyle = AxisArrowStyle.SharpTriangle;
					break;
				case "Lines":
                    Chart1.ChartAreas["ChartArea1"].AxisY2.ArrowStyle = AxisArrowStyle.Lines;
					break;
			}

			// Set Line Width
			Chart1.ChartAreas["ChartArea1"].AxisY2.LineWidth = int.Parse( Width1.SelectedItem.Value );

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

		protected void Enabled_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Disable/Enable controls
			Color1.Enabled = (Enabled.SelectedIndex == 0);
			Width1.Enabled = (Enabled.SelectedIndex == 0);
			LineStyle1.Enabled = (Enabled.SelectedIndex == 0);
			Arrow1.Enabled = (Enabled.SelectedIndex == 0);
		}
	}	
}
