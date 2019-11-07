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
	/// Summary description for LegendFont.
	/// </summary>
	public partial class LegendFont : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				// Add Font Family styles to control.
				foreach(FontFamily fontName in FontFamily.Families)
				{
					if (FontNameList.Items.FindByText(fontName.Name) == null)
						FontNameList.Items.Add(fontName.Name);
				}
			}

			// Disable auto-fitting of the legend text
			Chart1.Legends["Default"].IsTextAutoFit = false;

			// Set new legend text font
			FontStyle fontStyle = FontStyle.Regular;
			if( Italic.Checked )
				fontStyle = FontStyle.Italic;
			if( Bold.Checked )
				fontStyle |= FontStyle.Bold;
			if( Underline.Checked )
				fontStyle |= FontStyle.Underline;
			if( Strikeout.Checked )
				fontStyle |= FontStyle.Strikeout;

			try
			{
				Chart1.Legends["Default"].Font = new Font(FontNameList.SelectedItem.Text, int.Parse(FontSizeList.SelectedItem.Text), fontStyle);
			}
			catch
			{
				Chart1.Legends["Default"].Font = new Font("Arial", int.Parse(FontSizeList.SelectedItem.Text), fontStyle);
			}
			
			// Set legend text color
			Chart1.Legends["Default"].ForeColor = Color.FromName(ForeColorList.SelectedItem.Text);
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
