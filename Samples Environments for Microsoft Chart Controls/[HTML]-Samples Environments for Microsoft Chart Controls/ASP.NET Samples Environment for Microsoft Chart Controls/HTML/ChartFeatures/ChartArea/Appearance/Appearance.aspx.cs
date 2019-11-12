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
	public partial class ChartAreaAppearance : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!this.IsPostBack)
			{
				// Add Hatch styles to control.
				foreach(string colorName in Enum.GetNames(typeof(ChartHatchStyle)))
				{
					HatchStyle.Items.Add(colorName);
				}
		
				// Add Chart Gradient types to control.
				foreach(string colorName in Enum.GetNames(typeof(GradientStyle)))
				{
					Gradient.Items.Add(colorName);
				}

				// Add Chart Line styles to control.
				foreach(string colorName in Enum.GetNames(typeof(ChartDashStyle)))
				{
					BorderDashStyle.Items.Add(colorName);
				}
				BorderDashStyle.SelectedIndex = 5;
			}

			// Set Back Color
			Chart1.ChartAreas["ChartArea1"].BackColor = Color.FromName(BackColor.SelectedItem.Value);

			// Set Back Gradient End Color
			Chart1.ChartAreas["ChartArea1"].BackSecondaryColor = Color.FromName(ForeColor.SelectedItem.Value);

			// Set Hatch Style
			Chart1.ChartAreas["ChartArea1"].BackHatchStyle = (ChartHatchStyle)ChartHatchStyle.Parse(typeof(ChartHatchStyle), HatchStyle.SelectedItem.Text);

			// Set Gradient Type
			Chart1.ChartAreas["ChartArea1"].BackGradientStyle = (GradientStyle)GradientStyle.Parse(typeof(GradientStyle), Gradient.SelectedItem.Text);

			// Set Border Color
			Chart1.ChartAreas["ChartArea1"].BorderColor = Color.FromName(BorderColor.SelectedItem.Value);

			// Set Border Style
			Chart1.ChartAreas["ChartArea1"].BorderDashStyle = (ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), BorderDashStyle.SelectedItem.Text);

			// Set Border Width
			Chart1.ChartAreas["ChartArea1"].BorderWidth = int.Parse(BorderSize.SelectedItem.Value);

			// Disable hatch if gradient is active
			if( Chart1.ChartAreas["ChartArea1"].BackGradientStyle != GradientStyle.None )
				HatchStyle.Enabled =false;
			else
				HatchStyle.Enabled =true;
			

			// Disable gradient if hatch style is active
			if( Chart1.ChartAreas["ChartArea1"].BackHatchStyle != ChartHatchStyle.None )
				Gradient.Enabled =false;
			else
				Gradient.Enabled =true;
			
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
