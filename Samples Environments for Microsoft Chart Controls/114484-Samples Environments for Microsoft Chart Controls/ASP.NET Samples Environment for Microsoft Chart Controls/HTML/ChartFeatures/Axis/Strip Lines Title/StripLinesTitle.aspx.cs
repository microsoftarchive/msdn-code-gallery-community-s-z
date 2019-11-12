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
	public partial class StripLinesTitle : System.Web.UI.Page
	{
		

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				// Add String Alignments styles to control.
				foreach(string item in Enum.GetNames(typeof(StringAlignment)))
				{
					TextAlignment.Items.Add(item);
					TextLineAlignment.Items.Add(item);
				}

				// Add Colors to controls.
				foreach(String colorName in KnownColor.GetNames(typeof(KnownColor)))
				{
					Color1.Items.Add(colorName);
				}
				
				Color1.Items.FindByText("Black").Selected = true;
				
				// Add Font Family styles to control.
				foreach(FontFamily fontName in FontFamily.Families)
				{
					Font1.Items.Add(fontName.Name);
				}
			}

			StripLine stripLine = Chart1.ChartAreas["ChartArea1"].AxisX.StripLines[0];


			// Set Strip Lines Title Alignment
			stripLine.TextAlignment = (StringAlignment) StringAlignment.Parse(typeof(StringAlignment), TextAlignment.SelectedItem.Text);

			// Set Strip Lines Title Line Alignment
			stripLine.TextLineAlignment = (StringAlignment) StringAlignment.Parse(typeof(StringAlignment), TextLineAlignment.SelectedItem.Text);

			// Set Strip Lines Title text
			stripLine.Text = Title.Text;

			// Set Strip Lines Title Angle
            stripLine.TextOrientation = (System.Web.UI.DataVisualization.Charting.TextOrientation)
                System.Web.UI.DataVisualization.Charting.TextOrientation.Parse(
                typeof(System.Web.UI.DataVisualization.Charting.TextOrientation),
                TextOrientation.SelectedItem.Value);

			// Set Strip Lines Title Color
			stripLine.ForeColor = Color.FromName(Color1.SelectedItem.Value);

			// Set Font style.
			FontStyle fontStyle = FontStyle.Regular;
			if( Italic.Checked )
				fontStyle = (FontStyle)FontStyle.Italic;
			if( Bold.Checked )
				fontStyle |= (FontStyle)FontStyle.Bold;
			if( Underline.Checked )
				fontStyle |= (FontStyle)FontStyle.Underline;
			if( Strikeout.Checked )
				fontStyle |= (FontStyle)FontStyle.Strikeout;

			// Set Strip Lines Title Font
			try
			{
				stripLine.Font = new Font(Font1.SelectedItem.Text, float.Parse(TitleSize.SelectedItem.Text), fontStyle);
			}
			catch
			{
				stripLine.Font = new Font("Arial", float.Parse(TitleSize.SelectedItem.Text), fontStyle);
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
