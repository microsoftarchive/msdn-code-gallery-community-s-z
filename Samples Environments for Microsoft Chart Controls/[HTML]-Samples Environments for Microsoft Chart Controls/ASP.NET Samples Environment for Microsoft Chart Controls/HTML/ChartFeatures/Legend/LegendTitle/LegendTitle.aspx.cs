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
	/// Summary description for LegendTitle.
	/// </summary>
	public partial class LegendTitle : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList FontSizeList;
		protected System.Web.UI.WebControls.DropDownList ForeColorList;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Load these settings the first time the chart is displayed
			if (!this.IsPostBack) 
			{
				this.TextBox1.Text = @"Chart";
				this.TitleSeparator.SelectedIndex = 0;

				foreach(string sepTypes in Enum.GetNames(typeof(LegendSeparatorStyle)))
				{
					this.TitleSeparator.Items.Add(sepTypes);
				}

				foreach(string alignmentTypes in Enum.GetNames(typeof(StringAlignment)))
				{
					this.TextAlignment.Items.Add(alignmentTypes);
				}

				this.SeparatorColor.SelectedIndex = 0;
				this.TitleSeparator.SelectedIndex = 3;
				this.TextAlignment.SelectedIndex = 1;
				this.LegendDocking.SelectedIndex = 2;
			}

			// Set legend title text
			string legendTitleText = this.TextBox1.Text;
			this.Chart1.Legends["Default"].Title = legendTitleText;

			// If there is no text, disable all other controls
			if (legendTitleText == String.Empty) 
			{
				this.TextAlignment.Enabled = false;
				this.TitleSeparator.Enabled = false;
				this.ForeColor.Enabled = false;
			}

			else
			{
				this.TextAlignment.Enabled = true;
				this.TitleSeparator.Enabled = true;			
				this.ForeColor.Enabled = true;
			}

			// Set title separator
			this.Chart1.Legends["Default"].TitleSeparator = (LegendSeparatorStyle)LegendSeparatorStyle.Parse(typeof(LegendSeparatorStyle), this.TitleSeparator.SelectedItem.ToString());
			
			// If no title separator, disable separtor color control
			if ((this.TitleSeparator.SelectedItem.ToString() == "None") ||(legendTitleText == String.Empty))
				SeparatorColor.Enabled = false;
			else 
				SeparatorColor.Enabled = true;

			// Set title color
			this.Chart1.Legends["Default"].TitleForeColor = Color.FromName(this.ForeColor.SelectedItem.ToString());

			// Set title separator color
			this.Chart1.Legends["Default"].TitleSeparatorColor = Color.FromName(this.SeparatorColor.SelectedItem.ToString());		
		
			// Set title alignment
			this.Chart1.Legends["Default"].TitleAlignment = (StringAlignment)StringAlignment.Parse(typeof(StringAlignment), this.TextAlignment.SelectedItem.ToString());
		
			// Set title docking
			this.Chart1.Legends["Default"].Docking = (Docking)Docking.Parse(typeof(Docking), this.LegendDocking.SelectedItem.Text);
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
