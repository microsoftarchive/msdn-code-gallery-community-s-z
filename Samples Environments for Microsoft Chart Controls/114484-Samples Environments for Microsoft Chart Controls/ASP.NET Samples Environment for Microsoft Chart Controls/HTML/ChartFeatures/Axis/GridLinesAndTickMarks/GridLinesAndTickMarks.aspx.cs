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
	public partial class GridLinesAndTickMarks : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Panel Panel2;
		

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
			
				// Add Chart Line styles to control.
				foreach(string styleName in Enum.GetNames(typeof(ChartDashStyle)))
				{
					MStyle.Items.Add(styleName);
					NStyle.Items.Add(styleName);
				}
				MStyle.Items[5].Selected = true;
				NStyle.Items[5].Selected = true;
				
			}

			// Disable all elements
			Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
			Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Enabled = false;
			Chart1.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = false;
			Chart1.ChartAreas["ChartArea1"].AxisX.MinorTickMark.Enabled = false;

			// Enable Major selected element
			switch( MType.SelectedItem.Value )
			{
				case "Grid":
					Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
					break;
				case "Tickmark":
					Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Enabled = true;
					break;
			}

			// Enable Minor selected element
			switch( NType.SelectedItem.Value )
			{
				case "Grid":
					Chart1.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = true;
					break;
				case "Tickmark":
					Chart1.ChartAreas["ChartArea1"].AxisX.MinorTickMark.Enabled = true;
					break;
			}

			// Set Grid lines and tick marks interval
			Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = double.Parse( MInterval.SelectedItem.Value );
			Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = double.Parse( MInterval.SelectedItem.Value );
			Chart1.ChartAreas["ChartArea1"].AxisX.MinorGrid.Interval = double.Parse( NInterval.SelectedItem.Value );
			Chart1.ChartAreas["ChartArea1"].AxisX.MinorTickMark.Interval = double.Parse( NInterval.SelectedItem.Value );

			// Set Line Color
			Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.FromName(MColor1.SelectedItem.Value);
			Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.LineColor = Color.FromName(MColor1.SelectedItem.Value);
			Chart1.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = Color.FromName(NColor1.SelectedItem.Value);
			Chart1.ChartAreas["ChartArea1"].AxisX.MinorTickMark.LineColor = Color.FromName(NColor1.SelectedItem.Value);

			// Set Line Style
			Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineDashStyle = (ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), MStyle.SelectedItem.Text);
			Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.LineDashStyle = (ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), MStyle.SelectedItem.Text);
			Chart1.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineDashStyle = (ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), NStyle.SelectedItem.Text);
			Chart1.ChartAreas["ChartArea1"].AxisX.MinorTickMark.LineDashStyle = (ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), NStyle.SelectedItem.Text);

			// Set Line Width
			Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = int.Parse(MWidth.SelectedItem.Value);
			Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.LineWidth = int.Parse(MWidth.SelectedItem.Value);
			Chart1.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineWidth = int.Parse(NWidth.SelectedItem.Value);
			Chart1.ChartAreas["ChartArea1"].AxisX.MinorTickMark.LineWidth = int.Parse(NWidth.SelectedItem.Value);

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

		protected void MStyle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}	
}
