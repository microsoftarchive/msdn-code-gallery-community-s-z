using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace GDISample
{
	/// <summary>
	/// User control that defines a graph area for an arbitrary integer array.  Displays
	/// both bar and pie charts.
	/// </summary>
	public class GraphDisplay : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private const int degreesInCircle = 360;
		private int brushCount;

		/// <summary>
		/// Used to enumerate graphing options.
		/// </summary>
		public enum GraphMode
		{
			PieChart,
			BarGraph
		}

		private GraphMode graphType = GraphMode.PieChart;
		/// <summary>
		/// Exposed by control to allow parent to control the GraphMode to
		/// use.  When this property is assigned to, the control is invalidated and thus 
		/// redrawn.
		/// </summary>
		public GraphMode GraphType
		{
			get{ return graphType;}

			set
			{
				graphType = value;
				this.Refresh();
			}
		}

		private int[] graphValues;
		/// <summary>
		/// Exposed to allow parent to define the values to graph.  When this property
		/// is assigned to, the control is invalidated and thus redrawn.
		/// </summary>
		public int[] GraphValues
		{
			get{ return graphValues; }

			set
			{
				graphValues = value;
				this.Refresh();
			}
		}

		private int barGraphWidth = 20;
		/// <summary>
		/// Exposed to allow parent to define the width of the bars in the BarGraph.
		/// Invalidates the control when assigned.
		/// </summary>
		public int BarGraphWidth
		{
			get{ return barGraphWidth; }

			set
			{
				barGraphWidth = value;
				this.Refresh();
			}
		}

		private Brush[] graphBrushes = {};
		/// <summary>
		/// Exposed to allow parent to define what brushes to use to draw data items.
		/// This array should be as long as the data array to avoid repeating colors.
		/// </summary>
		public Brush[] GraphBrushes
		{
			get{ return graphBrushes; }

			set
			{
				graphBrushes = value;
				this.Refresh();
			}
		}

		/// <summary>
		/// Default constructor creates a GraphDisplay control with a GraphType of PieChart.
		/// </summary>
		public GraphDisplay()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Constructor creates a GraphDisplay with parent's choice of GraphType.
		/// </summary>
		/// <param name="DefaultGraphType">The GraphMode to use by default.</param>
		public GraphDisplay(GraphMode DefaultGraphType)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			this.GraphType = DefaultGraphType;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		protected override void OnPaint( PaintEventArgs e )
		{
			Graphics g = e.Graphics;

			//create a white background for the graph area
			g.FillRectangle(Brushes.White, 0, 0, this.Width, this.Height);

			//give the graph area a border
			Pen borderPen = new Pen(Color.Black, 2);
			g.DrawRectangle(borderPen, 0, 0, this.Width, this.Height);

			brushCount = 0;

			//check which graph to draw (set by container)
			switch( graphType )
			{
				case GraphMode.BarGraph :
                    DrawBarGraph( g );
					break;
				case GraphMode.PieChart :
					DrawPieChart( g );
					break;
				default :
					//draw nothing
					break;
			}
		}

		/// <summary>
		/// Called by the OnPaint handler, this function uses the control's Graphics
		/// object to draw a bar graph of the data supplied to the GraphValues property.
		/// </summary>
		/// <param name="g">The PaintEventArgs.Graphics object from the OnPaint handler.</param>
		private void DrawBarGraph(Graphics g)
		{
			//check if values exist
			if(graphValues == null)
			{
				return;
			} 
			else if(graphValues.Length == 0) 
			{
				return;
			}

			//define bars

			int total = 0;
			float percentage;
			int barSpacing;
			int currentHorizontalPosition = 0;  //start at edge of control
			Rectangle bar;
			int barHeight;
			int barY;

			foreach(int dataPoint in graphValues) {	total += dataPoint;	}

			//determine bar spacing (edges of graph and bars all evenly spaced)
			barSpacing = (this.Width - (barGraphWidth * (graphValues.Length + 2))) / graphValues.Length + 2;

			foreach(int dataPoint in graphValues)
			{
				currentHorizontalPosition += barSpacing;
				percentage = (float)dataPoint / total;

				barHeight = (int)(percentage * this.Height);
				barY = this.Height - barHeight - 1;  //ends just before the drawing area

				bar = new Rectangle(currentHorizontalPosition, barY, barGraphWidth, barHeight);

				g.DrawRectangle(Pens.Black, bar);
				g.FillRectangle(GetBrush(), bar);

				currentHorizontalPosition += barGraphWidth;
			}

		}

		/// <summary>
		/// Called by the OnPaint handler, this function uses the control's Graphics
		/// object to draw a pie chart of the data supplied to the GraphValues property.
		/// </summary>
		/// <param name="g">The PaintEventArgs.Graphics object from the OnPaint handler.</param>
		private void DrawPieChart(Graphics g)
		{
			//check if values exist
			if(graphValues == null)
			{
				return;
			} 
			else if(graphValues.Length == 0) 
			{
				return;
			}

			//define center of circle
			Point origin = new Point(this.Width / 2, this.Height / 2);

			//define radius of circle (must be smaller than smallest dimension)
			int radius = (origin.X > origin.Y) ? origin.Y - 1 : origin.X - 1 ;

			//define bounding square
			Rectangle boundingBox = new Rectangle(origin.X - radius, origin.Y - radius,
													radius * 2, radius * 2);

			//define slices
			
			int total = 0;
			float percentage;
			float cummulativePercentage = 0;
			double degreesToRadiansFactor = Math.PI / 180;  //sin & cos take angle in radians
			float currentAngle;
			
			//declare the slice
			GraphicsPath gPath;

			//define point on circle to draw to at 3 o'clock, initially
			//(since AddArc draws clockwise, this makes the math easy)
			Point lastPointOnCircle = new Point(origin.X + radius, origin.Y);

			foreach(int dataPoint in graphValues) { total += dataPoint; }
			foreach(int dataPoint in graphValues)
			{
				//create a new graphics path to define "slice"
				gPath = new GraphicsPath();

				//determine percentage of total for slice
				percentage = (float)dataPoint / total;

				//draw line from origin to last point on circle
				gPath.AddLine(origin, lastPointOnCircle);

				//draw arc
				currentAngle = degreesInCircle * cummulativePercentage;
				gPath.AddArc(boundingBox, currentAngle,	degreesInCircle * percentage);
				
				//set new last point on circle
				lastPointOnCircle.X -= (int)Math.Cos(degreesToRadiansFactor * currentAngle) * radius;
				lastPointOnCircle.Y -= (int)Math.Sin(degreesToRadiansFactor * currentAngle) * radius;
				
				//update percentage of circle drawn so far
				cummulativePercentage += percentage;

				//close path
				gPath.CloseAllFigures();

				//fill
				g.FillPath(GetBrush(), gPath);

			}

			//draw a border around the circle
			Pen borderPen = new Pen(Color.Black, 1);
			g.DrawEllipse(borderPen, boundingBox);

		}

		/// <summary>
		/// This method provides access to various types (colors) of brushes
		/// for the internal drawing methods.
		/// </summary>
		/// <returns>Brush object</returns>
		private Brush GetBrush()
		{
			//if owner has not defined an array of brushes to use
			//then get a "random" brush
			if(graphBrushes.Length < 1)
			{
				return GetRandomBrush();
			}
			//if the owner has defined an array of brushes to use,
			//then get the next one
			else 
			{
				return graphBrushes[brushCount++];
			}
		}

		/// <summary>
		/// Called by GetBrush to return a "random" brush.  This method
		/// really keeps track of which brushes have been used of LimeGreen,
		/// Gold, and FireBrick.  Truly random brushes wouldn't not mesh well
		/// aesthetically.
		/// </summary>
		/// <returns></returns>
		private Brush GetRandomBrush()
		{
			brushCount++;
			if(brushCount == 1)
			{
				return Brushes.LimeGreen;
			} 
			else if(brushCount == 2)
			{
				return Brushes.Gold;
			}
			else if(brushCount == 3)
			{
				return Brushes.Firebrick;
			}
			else
			{
				brushCount = 1;
				return Brushes.LimeGreen;
			}
		}

	}

}