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
	public partial class AxisTitle : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				// Add Font Family styles to control.
				foreach(FontFamily fontName in FontFamily.Families)
				{
					Font1.Items.Add(fontName.Name);
				}
			}

			// Set selected axis
			Chart1.ChartAreas["ChartArea1"].Axes[int.Parse( Position.SelectedItem.Value )].Title = TitleText.Text;

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

			try
			{
				// Set Title font
				Chart1.ChartAreas["ChartArea1"].Axes[int.Parse( Position.SelectedItem.Value )].TitleFont = new Font(Font1.SelectedItem.Text, float.Parse(TitleSize.SelectedItem.Text), fontStyle);
			}
			catch
			{
				Chart1.ChartAreas["ChartArea1"].Axes[int.Parse( Position.SelectedItem.Value )].TitleFont = new Font("Arial", float.Parse(TitleSize.SelectedItem.Text), fontStyle);
			}

			// Set Title color
			Chart1.ChartAreas["ChartArea1"].Axes[int.Parse( Position.SelectedItem.Value )].TitleForeColor = Color.FromName(Color1.SelectedItem.Value);

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
