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
	public partial class StripLines : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList BackColor;
		protected System.Web.UI.WebControls.DropDownList StripLineStyles;
		

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
			
				// Add Chart Line styles to control.
				foreach(string styleName in Enum.GetNames(typeof(ChartDashStyle)))
				{
					StripLinesStyle.Items.Add(styleName);
					
				}
				StripLinesStyle.Items[5].Selected = true;
		

				// Add Chart Gradient types to control.
				foreach(string name in Enum.GetNames(typeof(System.Web.UI.DataVisualization.Charting.GradientStyle)))
				{
					this.Gradient.Items.Add(name);
				}
				this.Gradient.Items[1].Selected = true;

				// Add Chart Hatching types to control.
				foreach(string name in Enum.GetNames(typeof(System.Web.UI.DataVisualization.Charting.ChartHatchStyle)))
				{
					this.Hatching.Items.Add(name);
				}
				this.Hatching.Items[0].Selected = true;

				this.StripColor.SelectedIndex = 0;
				this.StripEndColor.SelectedIndex = 0;
				this.LineColor.SelectedIndex = 0;
				this.LineWidth.SelectedIndex = 0;
				this.Interval.SelectedIndex = 1;
			}

			UpadteChart();
		}
		private void UpadteChart()
		{
			StripLine stripLine = this.Chart1.ChartAreas["ChartArea1"].AxisX.StripLines[0];

			// Set Strip lines interval
			stripLine.Interval = double.Parse( Interval.SelectedItem.Value );
			
			// Set Strip Border Line Color
			stripLine.BorderColor = Color.FromName( LineColor.SelectedItem.Value );
			
			// Set Strip Border Line Style
			stripLine.BorderDashStyle = (ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), StripLinesStyle.SelectedItem.Text);
			
			// Set Strip Border Line Width
			stripLine.BorderWidth = int.Parse( LineWidth.SelectedItem.Value );

			// Set Strip Width
			stripLine.StripWidth = double.Parse( StripWidth.SelectedItem.Value );
			
			// Set Strip Back Color
			stripLine.BackColor = Color.FromName( StripColor.SelectedItem.Value );

			// Set Strip End Color
			stripLine.BackSecondaryColor = Color.FromName( StripEndColor.SelectedItem.Value );

			// Enable/Disable appearance controls
			LineWidth.Enabled = (StripLinesStyle.SelectedIndex != 0);
			LineColor.Enabled = (StripLinesStyle.SelectedIndex != 0);
			StripEndColor.Enabled = (Hatching.SelectedIndex != 0 || Gradient.SelectedIndex != 0);
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

		protected void Gradient_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Set Strip Gradient
			StripLine stripLine = this.Chart1.ChartAreas["ChartArea1"].AxisX.StripLines[0];
			stripLine.BackGradientStyle = (GradientStyle)ChartDashStyle.Parse(typeof(GradientStyle), Gradient.SelectedItem.Text);
			stripLine.BackHatchStyle = ChartHatchStyle.None;
			Hatching.SelectedIndex = 0;

			UpadteChart();
		}

		protected void Hatching_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Set Strip Hatching
			StripLine stripLine = this.Chart1.ChartAreas["ChartArea1"].AxisX.StripLines[0];
			stripLine.BackHatchStyle = (ChartHatchStyle)ChartDashStyle.Parse(typeof(ChartHatchStyle), Hatching.SelectedItem.Text);
			stripLine.BackGradientStyle = GradientStyle.None;
			Gradient.SelectedIndex = 0;

			UpadteChart();
		}

	}	
}
