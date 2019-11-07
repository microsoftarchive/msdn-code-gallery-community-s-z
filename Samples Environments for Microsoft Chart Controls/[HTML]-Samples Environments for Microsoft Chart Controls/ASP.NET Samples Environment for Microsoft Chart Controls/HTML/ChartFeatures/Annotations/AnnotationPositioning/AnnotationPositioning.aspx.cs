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
	public partial class AnnotationPositioning : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button Button1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			// Set ImageTag rendering type
			Chart1.RenderType = RenderType.ImageTag;

			CreateChart();

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
		
		private void CreateChart()
		{
			// Populate chart with random data
			Random	random = new Random();
			Chart1.Series[0].Points.Clear();
			for(int pointIndex = 0; pointIndex < 10; pointIndex++)
			{
				foreach(Series series in Chart1.Series)
				{
					series.Points.AddY(random.Next(50, 99));
				}
			}

			// Set annotation position
			try
			{
				Chart1.Annotations[0].IsSizeAlwaysRelative = true;
				// to attach the annotation to the X and Y axis

				Chart1.Annotations[0].X = float.Parse(TextBoxX.Text);
				Chart1.Annotations[0].Y = float.Parse(TextBoxY.Text);

				if(Chart1.Annotations[0].X < 0)
					Chart1.Annotations[0].X = 0;
				
				if(Chart1.Annotations[0].X >100)
					Chart1.Annotations[0].X = 95;

				if(Chart1.Annotations[0].Y < 0)
					Chart1.Annotations[0].Y = 0;
				
				if(Chart1.Annotations[0].Y >100)
					Chart1.Annotations[0].Y = 95;
				

				Chart1.Annotations[0].Width = float.Parse(TextBoxWidth.Text);
				Chart1.Annotations[0].Height= float.Parse(TextBoxHeight.Text);

				if(Chart1.Annotations[0].Width < 10)
					Chart1.Annotations[0].Width = 10;
				
				if(Chart1.Annotations[0].Width > 100)
					Chart1.Annotations[0].Width = 100;

				if(Chart1.Annotations[0].Height < 10)
					Chart1.Annotations[0].Height = 10;
				
				if(Chart1.Annotations[0].Height > 100)
					Chart1.Annotations[0].Height = 100;

			}
			catch(Exception exception)
			{
				// Display exception message in chart title
				Chart1.Titles[0].Text = "ERROR: " + exception.Message;

				// Re-set legend coordinates
				Chart1.Annotations[0].X = 35;
				Chart1.Annotations[0].Y = 40;
				Chart1.Annotations[0].Width = 40;
				Chart1.Annotations[0].Height= 15;
			}

			SetEditBoxes();


		}


		private void SetEditBoxes()
		{
			// Set text fields values
			string formatter = "#" + System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator + "#";
			
			TextBoxX.Text = Chart1.Annotations[0].X.ToString(formatter);
			TextBoxY.Text = Chart1.Annotations[0].Y.ToString(formatter);
			TextBoxWidth.Text = Chart1.Annotations[0].Width.ToString(formatter);
			TextBoxHeight.Text = Chart1.Annotations[0].Height.ToString(formatter);

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
			this.Chart1.Click += new ImageMapEventHandler(this.Chart1_Click);
		}
		#endregion

        private void Chart1_Click(object sender, System.Web.UI.WebControls.ImageMapEventArgs e)
		{

            // read coordinates from postback value
            Point point = (Point)(new PointConverter()).ConvertFromInvariantString(e.PostBackValue);
			// Conver pixels to percentage coordinates and set legend position
            Chart1.Annotations[0].X = point.X * 100F / ((float)(Chart1.Width.Value - 1));
            Chart1.Annotations[0].Y = point.Y * 100F / ((float)(Chart1.Height.Value - 1)); 

			AdjustAnnotationControls();

			SetEditBoxes();
		}
		
		private void AdjustAnnotationControls()
		{
			if(Chart1.Annotations[0].X > 80)
				Chart1.Annotations[0].Width = 40;
				
			if(Chart1.Annotations[0].Y > 88)
				Chart1.Annotations[0].Height = 15;
		}


	}
}
