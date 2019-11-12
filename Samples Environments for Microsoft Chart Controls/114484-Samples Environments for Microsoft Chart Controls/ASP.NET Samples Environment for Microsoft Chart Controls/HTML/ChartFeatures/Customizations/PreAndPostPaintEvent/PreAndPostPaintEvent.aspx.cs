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
	public partial class PreAndPostPaintEvent : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			
		}

		private void RandomData(Series series, int numOfPoints)
		{
			Random rand;
			// Use a number to calculate a starting value for 
			// the pseudo-random number sequence
			rand = new Random(int.Parse(Random1.CommandArgument));

			// Generate random Y values
			for( int point = 0; point < numOfPoints; point++ )
			{
				series.Points.AddXY( point+1, rand.NextDouble()*41.0+6 );
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
			this.Chart1.PostPaint += new EventHandler<ChartPaintEventArgs>(this.Chart1_PostPaint);
			this.Chart1.PrePaint += new EventHandler<ChartPaintEventArgs>(this.Chart1_PrePaint);
		}
		#endregion

		
		public void AfterLoad()
		{
			// Number of data points
			int numOfPoints = int.Parse( Num.SelectedItem.Value );

			// Generate rundom data
			RandomData( Chart1.Series["Default"], numOfPoints );
									
		}


		private void FindMaxMin( out double max, out double min, out double xMax, out double xMin )
		{

			max = double.MinValue;
			min = double.MaxValue;

			xMax = 0;
			xMin = 0;

			// Find Minimum and Maximum Y values and corresponding X positions
			foreach( DataPoint point in Chart1.Series["Default"].Points )
			{
				if( point.YValues[0] > max )
				{
					max = point.YValues[0];
					xMax = point.XValue;
				}

				if( point.YValues[0] < min )
				{
					min = point.YValues[0];
					xMin = point.XValue;
				}
			}
		}

		protected void Random1_Click(object sender, System.EventArgs e)
		{
			Random rand = new Random();
			Random1.CommandArgument = rand.Next().ToString();
		}

		private void Chart1_PostPaint(object sender, System.Web.UI.DataVisualization.Charting.ChartPaintEventArgs e)
		{
			if(e.ChartElement is ChartArea)
			{

                ChartArea area = (ChartArea)e.ChartElement;
				if(area.Name == "Default")
				{
					// If Connection line is not checked return
					if( !ConnectionLine.Checked )
						return;

					double max;
					double min;
					double xMax;
					double xMin;

					// Find Minimum and Maximum values
					FindMaxMin( out max, out min, out xMax, out xMin );

					// Take Graphics object from chart
					Graphics graph = e.ChartGraphics.Graphics;

					// Convert X and Y values to screen position
					float pixelYMax = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.Y,max);
					float pixelXMax = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.X,xMax);
					float pixelYMin = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.Y,min);
					float pixelXMin = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.X,xMin);

					PointF point1 = PointF.Empty;
					PointF point2 = PointF.Empty;

					// Set Maximum and minimum points
					point1.X = pixelXMax;
					point1.Y = pixelYMax;
					point2.X = pixelXMin;
					point2.Y = pixelYMin;

					// Convert relative coordinates to absolute coordinates.
					point1 = e.ChartGraphics.GetAbsolutePoint(point1);
					point2 = e.ChartGraphics.GetAbsolutePoint(point2);

					// Draw connection line
					graph.DrawLine(new Pen(Color.FromArgb(26, 59, 105), 2), point1,point2);
				}
			}
		
		}

		private void Chart1_PrePaint(object sender, System.Web.UI.DataVisualization.Charting.ChartPaintEventArgs e)
		{
			if(e.ChartElement is ChartArea)
			{

                ChartArea area = (ChartArea)e.ChartElement;
				if(area.Name == "Default")
				{
					

					double max;
					double min;
					double xMax;
					double xMin;

					// Find Minimum and Maximum values
					FindMaxMin( out max, out min, out xMax, out xMin );
					
					// Take Graphics object from chart
					Graphics graph = e.ChartGraphics.Graphics;

					// Convert X and Y values to screen position
					float pixelYMax = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.Y,max);
					float pixelXMax = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.X,xMax);
					float pixelYMin = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.Y,min);
					float pixelXMin = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.X,xMin);

					float XMin = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.X, area.AxisX.Minimum);
					float XMax = (float)e.ChartGraphics.GetPositionFromAxis("Default",AxisName.X, area.AxisX.Maximum);

					// Specify with of triangle
					float width = 2;

					// Set Maximum points
					PointF [] points = new PointF[3];
					points[0].X = pixelXMax - width;
					points[0].Y = pixelYMax - width - 2;
					points[1].X = pixelXMax + width;
					points[1].Y = pixelYMax - width - 2;
					points[2].X = pixelXMax;
					points[2].Y = pixelYMax - 1;

					// Convert relative coordinates to absolute coordinates.
					points[0] = e.ChartGraphics.GetAbsolutePoint(points[0]);
					points[1] = e.ChartGraphics.GetAbsolutePoint(points[1]);
					points[2] = e.ChartGraphics.GetAbsolutePoint(points[2]);

					// Draw Maximum trangle
					Pen darkPen = new Pen(Color.FromArgb(26, 59, 105), 1);
					graph.FillPolygon(new SolidBrush(Color.FromArgb(220, 252, 180, 65)), points);
					graph.DrawPolygon(darkPen, points);

					points[0].X = XMin;
					points[1].X = XMax;
					points[0].Y = points[1].Y = pixelYMax;

					// Convert relative coordinates to absolute coordinates.
					points[0] = e.ChartGraphics.GetAbsolutePoint(points[0]);
					points[1] = e.ChartGraphics.GetAbsolutePoint(points[1]);

					graph.DrawLine(darkPen, points[0], points[1]);

					// Set Minimum points
					points = new PointF[3];
					points[0].X = pixelXMin - width;
					points[0].Y = pixelYMin + width + 2;
					points[1].X = pixelXMin + width;
					points[1].Y = pixelYMin + width + 2;
					points[2].X = pixelXMin;
					points[2].Y = pixelYMin + 1;

					// Convert relative coordinates to absolute coordinates.
					points[0] = e.ChartGraphics.GetAbsolutePoint(points[0]);
					points[1] = e.ChartGraphics.GetAbsolutePoint(points[1]);
					points[2] = e.ChartGraphics.GetAbsolutePoint(points[2]);

					// Draw Minimum trangle
					graph.FillPolygon(new SolidBrush(Color.FromArgb(220, 224, 64, 10)), points);
					graph.DrawPolygon(darkPen, points);

					points[0].X = XMin;
					points[1].X = XMax;
					points[0].Y = points[1].Y = pixelYMin;

					// Convert relative coordinates to absolute coordinates.
					points[0] = e.ChartGraphics.GetAbsolutePoint(points[0]);
					points[1] = e.ChartGraphics.GetAbsolutePoint(points[1]);

					graph.DrawLine(darkPen, points[0], points[1]);
				}
			}
		
		}
	}	
}
