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
	public partial class RangeBarChart : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data
			DateTime	currentData = DateTime.Now.Date;
			Chart1.Series["Tasks"].Points.AddXY(1, currentData, currentData.AddDays(5));
			Chart1.Series["Tasks"].Points.AddXY(2, currentData.AddDays(5), currentData.AddDays(7));
			Chart1.Series["Tasks"].Points.AddXY(3, currentData.AddDays(7), currentData.AddDays(10));
			Chart1.Series["Tasks"].Points.AddXY(1, currentData.AddDays(10), currentData.AddDays(15));
			Chart1.Series["Tasks"].Points.AddXY(4, currentData.AddDays(15), currentData.AddDays(20));
			Chart1.Series["Tasks"].Points.AddXY(2, currentData.AddDays(20), currentData.AddDays(27));

			Chart1.Series["Progress"].Points.AddXY(1, currentData, currentData.AddDays(5));
			Chart1.Series["Progress"].Points.AddXY(2, currentData.AddDays(5), currentData.AddDays(7));
			Chart1.Series["Progress"].Points.AddXY(3, currentData.AddDays(7), currentData.AddDays(10));
			Chart1.Series["Progress"].Points.AddXY(1, currentData.AddDays(10), currentData.AddDays(13));

			// Set axis labels
			Chart1.Series["Tasks"].Points[0].AxisLabel = "Task 1";
			Chart1.Series["Tasks"].Points[1].AxisLabel = "Task 2";
			Chart1.Series["Tasks"].Points[2].AxisLabel = "Task 3";
			Chart1.Series["Tasks"].Points[4].AxisLabel = "Task 4";

			// Set Range Bar chart type
			Chart1.Series["Tasks"].ChartType = SeriesChartType.RangeBar;
			Chart1.Series["Progress"].ChartType = SeriesChartType.RangeBar;

			// Set point width
			Chart1.Series["Tasks"]["PointWidth"] = "0.7";
			Chart1.Series["Progress"]["PointWidth"] = "0.2";

			// Set Y axis Minimum and Maximum
			Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = currentData.AddDays(-1).ToOADate();
			Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = currentData.AddDays(28).ToOADate();
			Chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "MMM dd";

			// Show as 2D or 3D
			if(checkBoxShow3D.Checked)
			{
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
				Chart1.Series["Progress"]["DrawSideBySide"] = "true";
				Chart1.Series["Tasks"]["DrawSideBySide"] = "true";
			}
			else
			{
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
				Chart1.Series["Progress"]["DrawSideBySide"] = "false";
				Chart1.Series["Tasks"]["DrawSideBySide"] = "false";
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
			this.Chart1.PostPaint +=new EventHandler<ChartPaintEventArgs>(this.Chart1_PostPaint);
		}
		#endregion

		private void Chart1_PostPaint(object sender, EventArgs e1)
		{
            ChartPaintEventArgs e = e1 as ChartPaintEventArgs;
			if(sender is ChartArea)
			{
				Series series = Chart1.Series["Tasks"];
				// Take Graphics object from chart
				Graphics graph = e.ChartGraphics.Graphics;

				for(int i = 0; i < series.Points.Count; i++)
				{
					if((i+1) < series.Points.Count && i != 1 && i != 3)
					{
						double p1X, p2X, p1Y, p2Y;
						
						p1X = series.Points[i].XValue;
						p2X = series.Points[i+1].XValue;
						p1Y = series.Points[i].YValues[1];
						p2Y = series.Points[i+1].YValues[0];

						float pixelX1 = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.Y,p1Y);
						float pixelY1 = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.X,p1X);
						float pixelX2 = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.Y,p2Y);
						float pixelY2 = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.X,p2X);

						PointF point1 = PointF.Empty;
						PointF point2 = PointF.Empty;
						PointF point3 = PointF.Empty;

						point1.X = pixelX1;
						point1.Y = pixelY1;
						point2.X = pixelX2;
						point2.Y = pixelY2;

						// make the middle right-angle point
						point3.X = pixelX2;
						point3.Y = pixelY1;

						// If 3D, we need to transform the 3D points into 2D points
						if(checkBoxShow3D.Checked)
						{							
							// Get Z position for this series, and add half of series depth so that
							//   custom drawing occurs at front of series, instead of middle
							float ZPosition = Chart1.ChartAreas["ChartArea1"].GetSeriesZPosition(series);
							ZPosition = ZPosition + (float)0.5*(Chart1.ChartAreas["ChartArea1"].GetSeriesDepth(series));
							// Create 3D points for the 2D points
							Point3D[] My3DPoint = new Point3D[3];								
							My3DPoint[0] = new Point3D(point1.X,point1.Y,ZPosition);
							My3DPoint[1] = new Point3D(point2.X,point2.Y,ZPosition);
							My3DPoint[2] = new Point3D(point3.X,point3.Y,ZPosition);								
							// Transform so that new 2D points has new X and Y values that take into account the Z position
							Chart1.ChartAreas["ChartArea1"].TransformPoints(My3DPoint);
							point1 = My3DPoint[0].PointF;
							point2 = My3DPoint[1].PointF;
							point3 = My3DPoint[2].PointF;								
						}

						// Convert relative coordinates to absolute coordinates.
						point1 = e.ChartGraphics.GetAbsolutePoint(point1);
						point2 = e.ChartGraphics.GetAbsolutePoint(point2);
						point3 = e.ChartGraphics.GetAbsolutePoint(point3);

						// Draw connection line
						graph.DrawLine(new Pen(Color.Black,2), point1,point3);
						graph.DrawLine(new Pen(Color.Black,2), point3,point2);

						DrawArrow(graph, Color.Black, point2, point3, 22.5);
					}
				}
				
			}
		}
		
		/// <summary>
		/// This Method will draw an arrow head on at the end of a line segment
		/// as defined by two points, p1 and p2
		/// </summary>
		private void DrawArrow(Graphics graph, Color brushcolor, PointF p1, PointF p2, double angle_deg)
		{
			// using the two points, p1 and p2, we must first calculate the two
			// other points to use for the triangular arrow.  The provided angle
			// must be in degrees and be converted to radians.

			double rad = angle_deg * Math.PI / 180;

			// to simplify calcuations find dx and dy for points p1 and p2
			double dx = p1.X-p2.X;
			double dy = p1.Y-p2.Y;

			double c = Math.Sqrt((Math.Pow(dx,2) + Math.Pow(dy,2)));

			// to create an approximately 7px arrow, we need c to be 70 and a line_legnth of 0.1
			// There are instances where c will be less causing the 10% scale to be such that
			// the arrow head will be invisible. Similarly, when c is really large the arrow 
			// head can be huge.
			double pixels = 12;
			double line_length = (1 / ( c / pixels));

			PointF arrow_segment1 = Point.Empty;
			PointF arrow_segment2 = Point.Empty;

			arrow_segment1.X = p1.X - (float)((dx*Math.Cos(rad) - dy*Math.Sin(rad))* line_length);
			arrow_segment1.Y = p1.Y - (float)((dy*Math.Cos(rad) + dx*Math.Sin(rad))* line_length);

			arrow_segment2.X = p1.X - (float)((dx*Math.Cos(-rad) - dy*Math.Sin(-rad))* line_length);
			arrow_segment2.Y = p1.Y - (float)((dy*Math.Cos(-rad) + dx*Math.Sin(-rad))* line_length);

			PointF[] arrowhead =	{
										p1,
										arrow_segment1,
										arrow_segment2
									};

			SolidBrush brush = new SolidBrush(brushcolor);
			graph.FillPolygon(brush, arrowhead);

		}

	}
}
