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
	/// Summary description for LegendCustomPosition.
	/// </summary>
	public partial class TitleCustomPosition : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Set custom legend position
			try
			{
				Chart1.Titles[0].Position.Auto = false;
				Chart1.Titles[0].Position.X = float.Parse(TextBoxX.Text);
				Chart1.Titles[0].Position.Y = float.Parse(TextBoxY.Text);
				Chart1.Titles[0].Position.Width = float.Parse(TextBoxWidth.Text);
				Chart1.Titles[0].Position.Height= float.Parse(TextBoxHeight.Text);
			}
			catch(Exception exception)
			{
				// Display exception message in chart title
				Chart1.Titles[0].Text = "ERROR: " + exception.Message;

				// Re-set legend coordinates
				Chart1.Titles[0].Position.X = 35;
				Chart1.Titles[0].Position.Y = 40;
				Chart1.Titles[0].Position.Width = 50;
				Chart1.Titles[0].Position.Height= 15;
			}

			// Set text fields values
			TextBoxX.Text = Chart1.Titles[0].Position.X.ToString();
			TextBoxY.Text = Chart1.Titles[0].Position.Y.ToString();
			TextBoxWidth.Text = Chart1.Titles[0].Position.Width.ToString();
			TextBoxHeight.Text = Chart1.Titles[0].Position.Height.ToString();

            // transfer of click coordinates. getCoordinates is a javascript function.
            this.Chart1.Attributes["onclick"] = ClientScript.GetPostBackEventReference(this.Chart1, "@").Replace("'@'", "_getCoord(event)");

            // set position to relative in order to get proper coordinates.
            this.Chart1.Style[HtmlTextWriterStyle.Position] = "relative";
            this.ClientScript.RegisterClientScriptBlock(
                typeof(Chart),
                "Chart",
                @"function _getCoord(event){if(typeof(event.x)=='undefined'){return event.layerX+','+event.layerY;}return event.x+','+event.y;}",
                true);


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
			this.Chart1.Click +=new ImageMapEventHandler(this.Chart1_Click);

		}
		#endregion

		private void Chart1_Click(object sender, System.Web.UI.WebControls.ImageMapEventArgs e)
		{

            // read coordinates from postback value
            Point point = (Point)(new PointConverter()).ConvertFromInvariantString(e.PostBackValue);

			// Conver pixels to percentage coordinates and set legend position
            Chart1.Titles[0].Position.X = point.X * 100F / ((float)(Chart1.Width.Value - 1));
            Chart1.Titles[0].Position.Y = point.Y * 100F / ((float)(Chart1.Height.Value - 1)); 

			AdjustLegendControls();

			// Set text fields values
			TextBoxX.Text = Chart1.Titles[0].Position.X.ToString();
			TextBoxY.Text = Chart1.Titles[0].Position.Y.ToString();
			TextBoxWidth.Text = Chart1.Titles[0].Position.Width.ToString();
			TextBoxHeight.Text = Chart1.Titles[0].Position.Height.ToString();
		}

		private void AdjustLegendControls()
		{
			if(Chart1.Titles[0].Position.X > 70)
				Chart1.Titles[0].Position.Width = 30;
				
			if(Chart1.Titles[0].Position.Y > 90)
				Chart1.Titles[0].Position.Height = 10;
		}


		protected void TextBoxWidth_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
