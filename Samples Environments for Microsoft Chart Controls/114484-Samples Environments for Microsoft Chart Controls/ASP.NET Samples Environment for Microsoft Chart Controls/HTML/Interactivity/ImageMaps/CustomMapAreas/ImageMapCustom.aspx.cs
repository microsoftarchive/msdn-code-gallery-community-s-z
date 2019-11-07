using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for ImageMapCustom.
	/// </summary>
	public partial class ImageMapCustom : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
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
			this.Chart1.PostPaint += new EventHandler<ChartPaintEventArgs>(Chart1_PostPaint);

		}
		#endregion

		private void Chart1_PostPaint(object sender, ChartPaintEventArgs e)
		{
			// Painting series object
			if(e.ChartElement is Series)
			{
				// Add custom painting only to the series with name "Series2"
                Series series = (Series)e.ChartElement;
				if(series.Name == "Series2" && series.Tag == null)
				{
					// Find data point with maximum Y value
					DataPoint	dataPoint = series.Points.FindMaxByValue();
					
					// Load bitmap from file 
					System.Drawing.Image bitmap = Bitmap.FromFile(this.Page.MapPath("money.png"));

					// Set White color as transparent
					ImageAttributes attrib = new ImageAttributes();
                    attrib.SetColorKey(Color.White, Color.White, ColorAdjustType.Default);

					// Calculates marker position depending on the data point X and Y values
					RectangleF	imagePosition = RectangleF.Empty;
					imagePosition.X = (float)e.ChartGraphics.GetPositionFromAxis(
                        "Chart Area 1", AxisName.X, dataPoint.XValue);
					imagePosition.Y = (float)e.ChartGraphics.GetPositionFromAxis(
                        "Chart Area 1", AxisName.Y, dataPoint.YValues[0]);
					imagePosition = e.ChartGraphics.GetAbsoluteRectangle(imagePosition);
					imagePosition.Width = bitmap.Width;
					imagePosition.Height = bitmap.Height;
					imagePosition.Y -= bitmap.Height;
					imagePosition.X -= bitmap.Width /2;

					// Draw image
					e.ChartGraphics.Graphics.DrawImage(bitmap, 
						Rectangle.Round(imagePosition),
						0, 0, bitmap.Width, bitmap.Height,
						GraphicsUnit.Pixel, 
						attrib);

					// Add a custom map area in the coordinates of the image
					RectangleF	rect = e.ChartGraphics.GetRelativeRectangle(imagePosition);
                    
                    MapArea area = new MapArea("Maximum Y value marker. Y = " + dataPoint.YValues[0], "money.htm", "target=\"_blank\"", String.Empty, rect, null);
                    Chart1.MapAreas.Add(area);
					// Dispose image object
					bitmap.Dispose();

                    series.Tag = true;
				}
			}
		}
	}
}
