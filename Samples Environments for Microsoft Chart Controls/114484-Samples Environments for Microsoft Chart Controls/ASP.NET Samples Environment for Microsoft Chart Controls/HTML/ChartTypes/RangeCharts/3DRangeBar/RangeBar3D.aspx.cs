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
	public partial class RangeBar3D : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		private double dToday = 4;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			double dStartDate = DateTime.Today.ToOADate();
			Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = dStartDate-1;
			Chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Interval = 3;
			Chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.IntervalType = DateTimeIntervalType.Days;


			string [] task = { "Task 1", 
								 "Task 2", "Task 2",
								 "Task 3",
								 "Task 4",
								 "Task 5", "Task 5",
								 "Task 6",
								 "Task 7" };

			double [] start = {3, 1, 6, 0, 3, 2, 5.5, 2, 4 };
			double [] end = {5, 3.5, 8, 5.5, 4, 3.5, 8, 5, 5 };

			Series ser = Chart1.Series[0];
			int pos = 1;
			string lastValue = "";
			for(int i = 0; i < start.Length-1; i++)
			{
                    
				string xValue = task[i];
				if(lastValue != xValue)
					pos++;

				string yValues = (dStartDate+start[i]).ToString()+","+(dStartDate+end[i]).ToString();
				DataPoint pt = new DataPoint(pos, yValues);
				pt.AxisLabel = xValue;
				ser.Points.Add(pt);

				lastValue = xValue;
			}
			

			double [] actualStart = {3, 1, 6, 0, 3, 2, 5.5, 2, 4 };
			double [] actualEnd = {4.5, 4.5, 6, 4.5, 4, 3.5, 5.5, 4.5, 4.5 };
			ser = Chart1.Series[1];
			pos = 1;
			lastValue = "";
			for(int i = 0; i < start.Length-1; i++)
			{                   
				string xValue = task[i];
				if(lastValue != xValue)
					pos++;

				string yValues = (dStartDate+actualStart[i]).ToString()+","+(dStartDate+actualEnd[i]).ToString();
				DataPoint pt = new DataPoint(pos, yValues);
				pt.AxisLabel = xValue;
				ser.Points.Add(pt);

				if(dStartDate+dToday > actualStart[i])
				{
					if(start[i] < actualStart[i] || end[i] < actualEnd[i])
						pt.Color = Color.Red;
					else if(dStartDate+dToday < end[i])
						pt.Color = Color.Lime;
					else if(end[i] == actualEnd[i])
						pt.Color = Color.Gray;
				}

				lastValue = xValue;
			}

			StripLine stripLine = new StripLine();
			stripLine.StripWidth = 1;
			stripLine.Font = new Font("Arial", 8.25F, FontStyle.Bold);
			stripLine.ForeColor = Color.Gray;
			stripLine.Text = "Today";
			stripLine.TextOrientation = TextOrientation.Rotated90;
			stripLine.BorderColor = Color.Black;
			stripLine.BackColor = Color.PaleTurquoise;
			stripLine.IntervalOffset = dStartDate+dToday;
			stripLine.TextAlignment = StringAlignment.Center;
			stripLine.TextLineAlignment = StringAlignment.Near;

			Chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(stripLine);

			LegendItem legendItem = new LegendItem();
			legendItem.Color = Color.Red;
			legendItem.Name = "Late";
			Chart1.Legends[0].CustomItems.Add(legendItem);

			foreach(DataPoint pt in Chart1.Series["Actual"].Points)
			{
				if(pt.YValues[0] == pt.YValues[1])
					pt.Color = Color.Transparent;
			}

			// Set chart area 3D rotation
			if(RotateX.SelectedItem.Text != "")
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = int.Parse(RotateX.SelectedItem.Text);

			if(RotateY.SelectedItem.Text != "")
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = int.Parse(RotateY.SelectedItem.Text);

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
				ChartArea area = (ChartArea)sender;
				if(area.Name == "Default")
				{
					Point3D [] pt3d = new Point3D[4];
					pt3d[0] = new Point3D();
					pt3d[1] = new Point3D();
					pt3d[2] = new Point3D();
					pt3d[3] = new Point3D();
					
					float depth = (float)area.GetSeriesDepth(Chart1.Series[0]);
					float zpos = (float)area.GetSeriesZPosition(Chart1.Series[0]);

					pt3d[0].Y = (float)area.AxisX.ValueToPosition(Chart1.Series["Estimated"].Points[7].XValue);
					pt3d[0].X = (float)area.AxisY.ValueToPosition(Chart1.Series["Estimated"].Points[7].YValues[1]);
					pt3d[0].Z = depth;

					pt3d[1].Y = (float)area.AxisX.ValueToPosition(Chart1.Series["Estimated"].Points[6].XValue);
					pt3d[1].X = (float)area.AxisY.ValueToPosition(Chart1.Series["Estimated"].Points[6].YValues[0]);
					pt3d[1].Z = depth;
					
					pt3d[2].Y = (float)area.AxisX.ValueToPosition(Chart1.Series["Estimated"].Points[3].XValue);
					pt3d[2].X = (float)area.AxisY.ValueToPosition(Chart1.Series["Estimated"].Points[3].YValues[1]);
					pt3d[2].Z = depth;

					pt3d[3].Y = (float)area.AxisX.ValueToPosition(Chart1.Series["Estimated"].Points[2].XValue);
					pt3d[3].X = (float)area.AxisY.ValueToPosition(Chart1.Series["Estimated"].Points[2].YValues[0]);
					pt3d[3].Z = depth;


					area.TransformPoints(pt3d);
					
					PointF ptF1 = new PointF();
					PointF ptF2 = new PointF();
					PointF ptF3 = new PointF();
					PointF ptF4 = new PointF();
					PointF ptF5 = new PointF();
					PointF ptF6 = new PointF();

					ptF1 = e.ChartGraphics.GetAbsolutePoint(pt3d[0].PointF);
					ptF3 = e.ChartGraphics.GetAbsolutePoint(pt3d[1].PointF);
					ptF4 = e.ChartGraphics.GetAbsolutePoint(pt3d[2].PointF);
					ptF6 = e.ChartGraphics.GetAbsolutePoint(pt3d[3].PointF);

					ptF2.X = ptF3.X;
					ptF2.Y = ptF1.Y;

					ptF5.X = ptF6.X;
					ptF5.Y = ptF4.Y;

					// Take Graphics object from chart
					Graphics graph = e.ChartGraphics.Graphics;

					graph.DrawLine(new Pen(Color.Black,1), ptF1,ptF2);
					graph.DrawLine(new Pen(Color.Black,1), ptF2,ptF3);
					graph.DrawLine(new Pen(Color.Black,1), ptF4,ptF5);
					graph.DrawLine(new Pen(Color.Black,1), ptF5,ptF6);

					DrawArrow(graph, Color.Black, ptF3, ptF2, 22.5);
					DrawArrow(graph, Color.Black, ptF6, ptF5, 22.5);
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

		private void RotateX_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void RotateY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
