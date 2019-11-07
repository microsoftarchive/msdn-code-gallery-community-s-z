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
	/// Summary description for ScaleBreaks.
	/// </summary>
	public partial class ScaleBreaks : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Interval;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList StripWidth;
		protected System.Web.UI.WebControls.DropDownList StripWidthType;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{		
			if (!this.IsPostBack) 
			{
				foreach (string breakTypes in Enum.GetNames(typeof(BreakLineStyle)))
				{
					this.BreakType.Items.Add(breakTypes);
				}

				this.BreakType.SelectedIndex = 3;
				this.ScaleBreakColor.SelectedIndex = 0;
			}

			if (this.chk_Enable.Checked) 
			{
				this.Chart1.ChartAreas["ChartArea1"].AxisY.ScaleBreakStyle.Enabled = true;
				this.BreakType.Enabled = true;
				this.Spacing.Enabled = true;
				this.ScaleBreakColor.Enabled = true;
			}

			else 
			{
				this.Chart1.ChartAreas["ChartArea1"].AxisY.ScaleBreakStyle.Enabled = false;
				this.BreakType.Enabled = false;
				this.Spacing.Enabled = false;
				this.ScaleBreakColor.Enabled = false;
			}
			
			// Set the scale break type
			Chart1.ChartAreas["ChartArea1"].AxisY.ScaleBreakStyle.BreakLineStyle = (BreakLineStyle)BreakLineStyle.Parse(typeof(BreakLineStyle), this.BreakType.SelectedItem.ToString());

			// Set the spacing 
			Chart1.ChartAreas["ChartArea1"].AxisY.ScaleBreakStyle.Spacing = double.Parse(this.Spacing.SelectedItem.ToString());
		
			// Set the line color
			Chart1.ChartAreas["ChartArea1"].AxisY.ScaleBreakStyle.LineColor = Color.FromName(this.ScaleBreakColor.SelectedItem.ToString());
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

		protected void chk_Enable_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}

	}	
}
