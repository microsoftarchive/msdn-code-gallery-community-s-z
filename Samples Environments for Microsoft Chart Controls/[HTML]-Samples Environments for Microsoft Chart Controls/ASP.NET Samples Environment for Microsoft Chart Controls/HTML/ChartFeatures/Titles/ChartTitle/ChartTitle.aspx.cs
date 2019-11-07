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
	/// Summary description for ChartTitle.
	/// </summary>
	public partial class ChartTitle : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Set chart title
			Chart1.Titles[0].Text = TitleText.Text;

			// Set chart title font
			FontStyle fontStyle = FontStyle.Regular;
			Chart1.Titles[0].Font = new Font(FontNameList.SelectedItem.Text, int.Parse(FontSizeList.SelectedItem.Text), fontStyle);
			
			// Set chart title color
			Chart1.Titles[0].ForeColor = Color.FromName(ForeColorList.SelectedItem.Text);

			// Set chart title back color
			Chart1.Titles[0].BackColor = Color.FromName(this.BackColor.SelectedItem.Text);

			// Set chart title border color
			Chart1.Titles[0].BorderColor = Color.FromName(this.BorderColor.SelectedItem.Text);

			// Set chart title Tooltips color
			Chart1.Titles[0].ToolTip = this.Tooltip.Text;

			// Set Title alignment
			if( this.Alignment.SelectedIndex == 0 )
			{
				Chart1.Titles[0].Alignment = ContentAlignment.MiddleLeft;
			}
			else if( this.Alignment.SelectedIndex == 1 )
			{
				Chart1.Titles[0].Alignment = ContentAlignment.MiddleCenter;
			}
			else
			{
				Chart1.Titles[0].Alignment = ContentAlignment.MiddleRight;
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
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
