using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace GDISample
{
	/// <summary>
	/// Creates a Form that contains a GraphDisplay (user-defined) control.  The Form is 
	/// a circle and is textured using GDI+.
	/// </summary>
	public class CircForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button Exit;
		private System.Windows.Forms.TextBox FirstValue;
		private System.Windows.Forms.TextBox SecondValue;
		private System.Windows.Forms.TextBox ThirdValue;
		private System.Windows.Forms.Button Graph;
		private System.Windows.Forms.RadioButton GraphTypePie;
		private System.Windows.Forms.RadioButton GraphTypeBar;

		private MouseEventHandler MouseMoveHandler;
		private int mouseDownX;
		private int mouseDownY;
		private GraphDisplay graphDisplay1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CircForm()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

			
			//setup mouse event delegates
			this.MouseDown += new MouseEventHandler(this.MouseDownHandler);
			this.MouseUp += new MouseEventHandler(this.MouseUpHandler);
			MouseMoveHandler = new MouseEventHandler(this.MoveForm);
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CircForm));
			this.Exit = new System.Windows.Forms.Button();
			this.FirstValue = new System.Windows.Forms.TextBox();
			this.SecondValue = new System.Windows.Forms.TextBox();
			this.ThirdValue = new System.Windows.Forms.TextBox();
			this.Graph = new System.Windows.Forms.Button();
			this.GraphTypePie = new System.Windows.Forms.RadioButton();
			this.GraphTypeBar = new System.Windows.Forms.RadioButton();
			this.graphDisplay1 = new GraphDisplay();
			this.SuspendLayout();
			// 
			// Exit
			// 
			this.Exit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(24)), ((System.Byte)(87)), ((System.Byte)(252)));
			this.Exit.BackgroundImage = ((System.Drawing.Bitmap)(resources.GetObject("Exit.BackgroundImage")));
			this.Exit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Exit.Location = new System.Drawing.Point(240, 48);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(21, 16);
			this.Exit.TabIndex = 100;
			this.Exit.Text = "X";
			this.Exit.Click += new System.EventHandler(this.Exit_Click);
			// 
			// FirstValue
			// 
			this.FirstValue.Location = new System.Drawing.Point(88, 48);
			this.FirstValue.Name = "FirstValue";
			this.FirstValue.Size = new System.Drawing.Size(32, 20);
			this.FirstValue.TabIndex = 1;
			this.FirstValue.Text = "34";
			this.FirstValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// SecondValue
			// 
			this.SecondValue.Location = new System.Drawing.Point(136, 48);
			this.SecondValue.Name = "SecondValue";
			this.SecondValue.Size = new System.Drawing.Size(32, 20);
			this.SecondValue.TabIndex = 2;
			this.SecondValue.Text = "33";
			this.SecondValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// ThirdValue
			// 
			this.ThirdValue.Location = new System.Drawing.Point(184, 48);
			this.ThirdValue.Name = "ThirdValue";
			this.ThirdValue.Size = new System.Drawing.Size(32, 20);
			this.ThirdValue.TabIndex = 3;
			this.ThirdValue.Text = "33";
			this.ThirdValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Graph
			// 
			this.Graph.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(24)), ((System.Byte)(87)), ((System.Byte)(252)));
			this.Graph.BackgroundImage = ((System.Drawing.Bitmap)(resources.GetObject("Graph.BackgroundImage")));
			this.Graph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Graph.Location = new System.Drawing.Point(120, 80);
			this.Graph.Name = "Graph";
			this.Graph.TabIndex = 4;
			this.Graph.Text = "Graph";
			this.Graph.Click += new System.EventHandler(this.Graph_Click);
			// 
			// GraphTypePie
			// 
			this.GraphTypePie.BackColor = System.Drawing.Color.Transparent;
			this.GraphTypePie.Checked = true;
			this.GraphTypePie.Location = new System.Drawing.Point(184, 240);
			this.GraphTypePie.Name = "GraphTypePie";
			this.GraphTypePie.Size = new System.Drawing.Size(72, 24);
			this.GraphTypePie.TabIndex = 5;
			this.GraphTypePie.TabStop = true;
			this.GraphTypePie.Text = "Pie Chart";
			this.GraphTypePie.CheckedChanged += new System.EventHandler(this.GraphTypePie_CheckedChanged);
			// 
			// GraphTypeBar
			// 
			this.GraphTypeBar.BackColor = System.Drawing.Color.Transparent;
			this.GraphTypeBar.Location = new System.Drawing.Point(72, 240);
			this.GraphTypeBar.Name = "GraphTypeBar";
			this.GraphTypeBar.Size = new System.Drawing.Size(80, 24);
			this.GraphTypeBar.TabIndex = 6;
			this.GraphTypeBar.Text = "Bar Graph";
			this.GraphTypeBar.CheckedChanged += new System.EventHandler(this.GraphTypeBar_CheckedChanged);
			// 
			// graphDisplay1
			// 
			this.graphDisplay1.BarGraphWidth = 20;
			this.graphDisplay1.GraphType = GraphDisplay.GraphMode.PieChart;
			this.graphDisplay1.GraphValues = new int[0];
			this.graphDisplay1.Location = new System.Drawing.Point(64, 112);
			this.graphDisplay1.Name = "graphDisplay1";
			this.graphDisplay1.Size = new System.Drawing.Size(200, 128);
			this.graphDisplay1.TabIndex = 101;
			// 
			// CircForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.ClientSize = new System.Drawing.Size(336, 312);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.graphDisplay1,
																		  this.GraphTypeBar,
																		  this.GraphTypePie,
																		  this.Graph,
																		  this.ThirdValue,
																		  this.SecondValue,
																		  this.FirstValue,
																		  this.Exit});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "CircForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CircForm";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new CircForm());
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			//get a reference to the GDI+ drawing surface for the form
			Graphics g = e.Graphics;

			//set rendering quality to high
			g.SmoothingMode = SmoothingMode.HighQuality;

			//create a new graphics path to define the shape of the form
			GraphicsPath gPath = new GraphicsPath();

			//create a new Rectangle shape primitive to define our circle
			//NOTE: by using an rectangle with equal sides (square) the AddEllipse
			//function will create a circle
			Rectangle boundingBox = new Rectangle(10, 0, 300, 300);

			//create the circle
			gPath.AddEllipse( boundingBox );

			//set the visible area (clipping region)
			g.SetClip(gPath, CombineMode.Replace);
		
			//add skin
			try
			{
				g.DrawImage(Image.FromFile("lbluetex.jpg"), boundingBox);
			}
			//if it isn't in the build folder (with the executable) 
			//then alert the user and close the application
			catch( System.IO.FileNotFoundException ex )
			{
				MessageBox.Show("Copy Misc\\lbluetex.jpg to the build folder!");
				Application.Exit();
			}
			
			//draw a border around the circle
			Pen borderPen = new Pen(Color.Black, 5);
			g.DrawPath(borderPen, gPath);

			//reset the cliping area to infinite
			g.ResetClip();
	
			//restore the window after drawing
			this.WindowState = FormWindowState.Normal;
		}

		#region Mouse Event Handlers
		private void MouseDownHandler(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				this.MouseMove += MouseMoveHandler;
				mouseDownX = e.X;
				mouseDownY = e.Y;
			}
		}

		private void MouseUpHandler(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				this.MouseMove -= MouseMoveHandler;
			}
		}

		private void MoveForm(object sender, MouseEventArgs e)
		{
			this.Location = new Point(this.Location.X + (e.X - mouseDownX),
										this.Location.Y + (e.Y - mouseDownY));
		}
		#endregion

		//handles the clicking of the "X" button and closes the form
		private void Exit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// handles the clicking of the Graph button, and resets the values for
		/// the graph (causing it to redraw)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Graph_Click(object sender, System.EventArgs e)
		{

			graphDisplay1.GraphValues = new int[] {int.Parse( this.FirstValue.Text ),
													int.Parse( this.SecondValue.Text ),
													int.Parse( this.ThirdValue.Text )};

		}

		/// <summary>
		/// Tracks when the GraphTypeBar radio button is changed and
		/// set the GraphType value of the graph to the appropriate mode.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GraphTypeBar_CheckedChanged(object sender, System.EventArgs e)
		{
			if(graphDisplay1.GraphType != GraphDisplay.GraphMode.BarGraph)
			{
				graphDisplay1.GraphType = GraphDisplay.GraphMode.BarGraph;
			}
		}

		/// <summary>
		/// Tracks when the GraphTypePie radio button is changed and
		/// set the GraphType value of the graph to the appropriate mode.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GraphTypePie_CheckedChanged(object sender, System.EventArgs e)
		{
			if(graphDisplay1.GraphType != GraphDisplay.GraphMode.PieChart)
			{
				graphDisplay1.GraphType = GraphDisplay.GraphMode.PieChart;
			}
		}

	}

}

