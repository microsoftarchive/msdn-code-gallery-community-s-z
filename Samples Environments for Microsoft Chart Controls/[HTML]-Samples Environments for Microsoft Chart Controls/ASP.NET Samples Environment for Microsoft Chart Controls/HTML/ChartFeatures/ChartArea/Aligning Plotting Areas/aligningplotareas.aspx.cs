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
	public partial class AligningPlotAreas : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Vertical Alignment
			if( Alignment.SelectedItem.Value == "Vertical Alignment" )
			{
				// Set the chart area alignmnet.  This will cause the axes to align vertically.
				Chart1.ChartAreas["Chart Area 2"].AlignmentOrientation = AreaAlignmentOrientations.Vertical;

				// Disable X Axis Labels for the first chart area.
				Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
				
				// Disable the tick marks of the X axis.
				Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Enabled = false;
				Chart1.ChartAreas["ChartArea1"].AxisX.MinorTickMark.Enabled = false;
				
				// Disable End labels for Y axes.
				Chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.IsEndLabelVisible = false;
				Chart1.ChartAreas["Chart Area 2"].AxisY.LabelStyle.IsEndLabelVisible = false;

				// Set the chart area position for the first chart area.
				Chart1.ChartAreas["ChartArea1"].Position.X = 5;
				Chart1.ChartAreas["ChartArea1"].Position.Y = 10;
				Chart1.ChartAreas["ChartArea1"].Position.Width = 90;
				Chart1.ChartAreas["ChartArea1"].Position.Height = 40;

				// Set the chart area position for the second chart area.
				Chart1.ChartAreas["Chart Area 2"].Position.X = 5;
				Chart1.ChartAreas["Chart Area 2"].Position.Y = 50;
				Chart1.ChartAreas["Chart Area 2"].Position.Width = 90;
				Chart1.ChartAreas["Chart Area 2"].Position.Height = 40;
			}
			// Horizontal Alignment
			else
			{
				// Set the chart area alignmnet.  This will cause the axes to align horizontally.
				Chart1.ChartAreas["Chart Area 2"].AlignmentOrientation =  AreaAlignmentOrientations.Horizontal;

				// Disable Y axis for the second chart area
				Chart1.ChartAreas["Chart Area 2"].AxisY.Enabled = AxisEnabled.False;

				// Enable Y2 axis for the second chart area
				Chart1.ChartAreas["Chart Area 2"].AxisY2.Enabled = AxisEnabled.True;

				// Set axis maximum for Y axes 
				Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 10;
				Chart1.ChartAreas["Chart Area 2"].AxisY.Maximum = 10;
				
				// Disable end labels for X axes
				Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsEndLabelVisible = false;
				Chart1.ChartAreas["Chart Area 2"].AxisX.LabelStyle.IsEndLabelVisible = false;

				// Set the chart area position for the first chart area.
				Chart1.ChartAreas["ChartArea1"].Position.X = 5;
				Chart1.ChartAreas["ChartArea1"].Position.Y = 10;
				Chart1.ChartAreas["ChartArea1"].Position.Width = 45;
				Chart1.ChartAreas["ChartArea1"].Position.Height = 80;

				// Set the chart area position for the second chart area.
				Chart1.ChartAreas["Chart Area 2"].Position.X = 50;
				Chart1.ChartAreas["Chart Area 2"].Position.Y = 10;
				Chart1.ChartAreas["Chart Area 2"].Position.Width = 45;
				Chart1.ChartAreas["Chart Area 2"].Position.Height = 80;
			}
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
