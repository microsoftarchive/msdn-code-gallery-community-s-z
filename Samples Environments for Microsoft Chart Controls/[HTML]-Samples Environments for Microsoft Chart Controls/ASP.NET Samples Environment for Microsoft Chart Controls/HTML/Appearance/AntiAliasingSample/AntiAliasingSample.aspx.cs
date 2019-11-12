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
	public partial class AntiAliasingSample : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList Rotation;
		protected System.Web.UI.WebControls.DropDownList Perspective;
		protected System.Web.UI.WebControls.DropDownList Inclination;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Set Antialiasing mode
            Chart1.AntiAliasing = (AntiAliasingStyles)Enum.Parse(typeof(AntiAliasingStyles), this.GraphicsAntiAliasing.SelectedItem.Value, true);			
			Chart1.TextAntiAliasingQuality = (TextAntiAliasingQuality) Enum.Parse( typeof(TextAntiAliasingQuality), this.TextAntiAliasing.SelectedItem.Value, true );

			// Enable or disable control Antialiasing for text 
			if( this.GraphicsAntiAliasing.SelectedItem.Value == "Graphics" || this.GraphicsAntiAliasing.SelectedItem.Value == "None" )
			{
				this.TextAntiAliasing.Enabled = false;
			}
			else
			{
				this.TextAntiAliasing.Enabled = true;
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
