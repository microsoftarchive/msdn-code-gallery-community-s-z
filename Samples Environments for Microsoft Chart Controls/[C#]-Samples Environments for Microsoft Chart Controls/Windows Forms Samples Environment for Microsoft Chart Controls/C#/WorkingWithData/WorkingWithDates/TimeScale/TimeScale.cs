using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsChartSamples
{
	public class TimeScale : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataVisualization.Charting.Chart Chart1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label15;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox UseIndex;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;


		public TimeScale()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.label9 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.button1 = new System.Windows.Forms.Button();
			this.UseIndex = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label9.Font = new System.Drawing.Font("Verdana", 11F);
			this.label9.Location = new System.Drawing.Point(16, 14);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(702, 34);
			this.label9.TabIndex = 0;
			this.label9.Text = "This sample demonstrates a real time scale, where data point positions depend on " +
				"DateTime X values. ";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.label2,
																				 this.dataGrid1,
																				 this.button1,
																				 this.UseIndex,
																				 this.label6,
																				 this.label5,
																				 this.label4,
																				 this.label3,
																				 this.label15});
			this.panel1.Location = new System.Drawing.Point(432, 68);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(292, 288);
			this.panel1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(48, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Series Data:";
			// 
			// dataGrid1
			// 
			this.dataGrid1.AllowNavigation = false;
			this.dataGrid1.AllowSorting = false;
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.BackgroundColor = System.Drawing.Color.White;
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(48, 96);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeadersVisible = false;
			this.dataGrid1.Size = new System.Drawing.Size(168, 184);
			this.dataGrid1.TabIndex = 6;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Series1";
			this.dataGridTableStyle1.RowHeadersVisible = false;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "#";
			this.dataGridTextBoxColumn1.MappingName = "No";
			this.dataGridTextBoxColumn1.Width = 30;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "MM/dd/yyyy";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "X";
			this.dataGridTextBoxColumn2.MappingName = "X";
			this.dataGridTextBoxColumn2.Width = 80;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Y";
			this.dataGridTextBoxColumn3.MappingName = "Y";
			this.dataGridTextBoxColumn3.Width = 50;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.Location = new System.Drawing.Point(48, 40);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(168, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "Random &Data";
			this.button1.Click += new System.EventHandler(this.Button_Click);
			// 
			// UseIndex
			// 
			this.UseIndex.Location = new System.Drawing.Point(48, 8);
			this.UseIndex.Name = "UseIndex";
			this.UseIndex.Size = new System.Drawing.Size(192, 24);
			this.UseIndex.TabIndex = 0;
			this.UseIndex.Text = "X Values &Indexed";
			this.UseIndex.CheckedChanged += new System.EventHandler(this.UseIndex_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(64, 403);
			this.label6.Name = "label6";
			this.label6.TabIndex = 5;
			this.label6.Text = "Border Size:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(64, 380);
			this.label5.Name = "label5";
			this.label5.TabIndex = 4;
			this.label5.Text = "Border Color:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(64, 357);
			this.label4.Name = "label4";
			this.label4.TabIndex = 3;
			this.label4.Text = "Hatch Style:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(64, 334);
			this.label3.Name = "label3";
			this.label3.TabIndex = 2;
			this.label3.Text = "Gradient:";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(64, 426);
			this.label15.Name = "label15";
			this.label15.TabIndex = 5;
			this.label15.Text = "Border Size:";
			// 
			// Chart1
			// 
			this.Chart1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(243)), ((System.Byte)(223)), ((System.Byte)(193)));
			this.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.Chart1.BorderlineColor = System.Drawing.Color.FromArgb(((System.Byte)(181)), ((System.Byte)(64)), ((System.Byte)(1)));
			this.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			this.Chart1.BorderlineWidth = 2;
			this.Chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
			chartArea1.Area3DStyle.IsClustered = true;
			chartArea1.Area3DStyle.Perspective = 10;
			chartArea1.Area3DStyle.IsRightAngleAxes = false;
			chartArea1.Area3DStyle.WallWidth = 0;
			chartArea1.Area3DStyle.Inclination = 15;
			chartArea1.Area3DStyle.Rotation = 10;
			chartArea1.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;;
			chartArea1.AxisX.LabelAutoFitStyle = (((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap);
			chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
			chartArea1.AxisX.LabelStyle.Format = "MMM dd";
			chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
			chartArea1.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;;
			chartArea1.AxisY.LabelAutoFitStyle = (((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap);
			chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
			chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
			chartArea1.BackColor = System.Drawing.Color.OldLace;
			chartArea1.BackSecondaryColor = System.Drawing.Color.White;
			chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			chartArea1.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea1.Name = "Default";
			chartArea1.ShadowColor = System.Drawing.Color.Transparent;
			this.Chart1.ChartAreas.Add(chartArea1);
			legend1.IsTextAutoFit = false;
			legend1.BackColor = System.Drawing.Color.Transparent;
			legend1.Enabled = false;
			legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
			legend1.Name = "Default";
			this.Chart1.Legends.Add(legend1);
			this.Chart1.Location = new System.Drawing.Point(16, 60);
			this.Chart1.Name = "Chart1";
			this.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
			series1.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(180)), ((System.Byte)(26)), ((System.Byte)(59)), ((System.Byte)(105)));
			series1.ChartArea = "Default";
			series1.Color = System.Drawing.Color.FromArgb(((System.Byte)(194)), ((System.Byte)(65)), ((System.Byte)(140)), ((System.Byte)(240)));
			series1.CustomProperties = "LabelsRadialLineSize=1, LabelStyle=outside";
			series1.Name = "Series1";
			series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
			this.Chart1.Series.Add(series1);
			this.Chart1.Size = new System.Drawing.Size(412, 296);
			this.Chart1.TabIndex = 1;
			this.Chart1.Click += new System.EventHandler(this.Chart1_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label1.Font = new System.Drawing.Font("Verdana", 11F);
			this.label1.Location = new System.Drawing.Point(16, 360);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(702, 68);
			this.label1.TabIndex = 3;
			this.label1.Text = "When \"X Values Indexed\" is checked the data point index (i.e the point\'s position" +
				" in the points collection), instead of the DateTime X value, determines the posi" +
				"tion of the data points along the x-axis.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TimeScale
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.Chart1,
																		  this.panel1,
																		  this.label9});
			this.Font = new System.Drawing.Font("Verdana", 9F);
			this.Name = "TimeScale";
			this.Size = new System.Drawing.Size(728, 480);
			this.Load += new System.EventHandler(this.TimeScale_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		
		public void AfterLoad()
		{
			
			if ( Chart1.Series["Series1"].Points.Count == 0)
			{
				// Populate series data
				Random	random = new Random();
				DateTime date = DateTime.Now.Date;
				Chart1.Series["Series1"].Points.Clear();
				for(int pointIndex = 0; pointIndex < 8; pointIndex++)
				{
					Chart1.Series["Series1"].Points.AddXY(date, random.Next(15, 95));
					date = date.AddDays(random.Next(1, 5));
				}
				
				// visualize into grid
				dataGrid1.DataMember = "Series1";
				dataGrid1.DataSource = GetSeriesValues();

			}
			
			// Use point index instead of the X value
			if(UseIndex.Checked)
			{
				Chart1.Series["Series1"].IsXValueIndexed = true;

				// Show labels every day
				Chart1.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
				Chart1.ChartAreas["Default"].AxisX.MajorGrid.Interval = 1;
				Chart1.ChartAreas["Default"].AxisX.MajorTickMark.Interval = 1;

				Chart1.ChartAreas["Default"].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Days;
				Chart1.ChartAreas["Default"].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Days;
				Chart1.ChartAreas["Default"].AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Days;
			}
			else
			{
				Chart1.Series["Series1"].IsXValueIndexed = false;

				// Auto Interval
				Chart1.ChartAreas["Default"].AxisX.LabelStyle.Interval = 0;
				Chart1.ChartAreas["Default"].AxisX.MajorGrid.Interval = 0;
				Chart1.ChartAreas["Default"].AxisX.MajorTickMark.Interval = 0;

				Chart1.ChartAreas["Default"].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Auto;
				Chart1.ChartAreas["Default"].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Auto;
				Chart1.ChartAreas["Default"].AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Auto;
			}

			// Set series tooltips
			Chart1.Series["Series1"].ToolTip = "#VALX";
									
		}

		private void Button_Click(object sender, System.EventArgs e)
		{
			Chart1.Series["Series1"].Points.Clear();
			AfterLoad();
		}

		private void TimeScale_Load(object sender, System.EventArgs e)
		{
			AfterLoad();
		}

		private void UseIndex_CheckedChanged(object sender, System.EventArgs e)
		{
			AfterLoad();
		}

		private void Chart1_Click(object sender, System.EventArgs e)
		{
		
		}
	
		/// <summary>
		/// Generates a DataSet from series
		/// </summary>
		/// <returns>Generated DataSet</returns>
		private DataSet GetSeriesValues()
		{

			Series ser = this.Chart1.Series["Series1"];

			DataSet	dataSet = new DataSet();
			DataTable seriesTable = new DataTable(ser.Name);
			
			seriesTable.Columns.Add( new DataColumn("No", typeof(int)));
			seriesTable.Columns.Add( new DataColumn("X", typeof(DateTime)));
			seriesTable.Columns.Add( new DataColumn("Y", typeof(double)));

			for( int count = 0; count < ser.Points.Count; count++)
			{
				DataPoint p = ser.Points[count];
				seriesTable.Rows.Add( new object[] { count, DateTime.FromOADate(p.XValue), p.YValues[0] });
			}
			
			dataSet.Tables.Add( seriesTable );
			return dataSet;
		}

	}
}
