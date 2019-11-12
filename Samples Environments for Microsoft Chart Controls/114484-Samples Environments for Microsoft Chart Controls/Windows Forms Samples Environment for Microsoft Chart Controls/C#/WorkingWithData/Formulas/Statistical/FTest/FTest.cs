using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsChartSamples
{
	/// <summary>
	/// Summary description for Distributions.
	/// </summary>
	public class FTest : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label labelSampleComment;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FTest()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.labelSampleComment = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label16 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// chart1
			// 
			this.chart1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(211)), ((System.Byte)(223)), ((System.Byte)(240)));
			this.chart1.BackSecondaryColor = System.Drawing.Color.White;
			this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((System.Byte)(26)), ((System.Byte)(59)), ((System.Byte)(105)));
			this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			this.chart1.BorderlineWidth = 2;
			this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
			chartArea1.Area3DStyle.IsClustered = true;
			chartArea1.Area3DStyle.Perspective = 10;
			chartArea1.Area3DStyle.IsRightAngleAxes = false;
			chartArea1.Area3DStyle.WallWidth = 0;
			chartArea1.Area3DStyle.Inclination = 15;
			chartArea1.Area3DStyle.Rotation = 10;
			chartArea1.AxisX.LabelAutoFitStyle = (((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap);
			chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
			chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisY.LabelAutoFitStyle = (((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap);
			chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
			chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(165)), ((System.Byte)(191)), ((System.Byte)(228)));
			chartArea1.BackSecondaryColor = System.Drawing.Color.White;
			chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			chartArea1.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea1.Name = "Chart Area 2";
			chartArea1.ShadowColor = System.Drawing.Color.Transparent;
			chartArea2.AlignWithChartArea = "Chart Area 2";
			chartArea2.Area3DStyle.IsClustered = true;
			chartArea2.Area3DStyle.Perspective = 10;
			chartArea2.Area3DStyle.IsRightAngleAxes = false;
			chartArea2.Area3DStyle.WallWidth = 0;
			chartArea2.Area3DStyle.Inclination = 15;
			chartArea2.Area3DStyle.Rotation = 10;
			chartArea2.AxisX.LabelAutoFitStyle = (((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap);
			chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
			chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea2.AxisX.Title = "Distribution";
			chartArea2.AxisX.TitleFont = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			chartArea2.AxisY.LabelAutoFitStyle = (((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap);
			chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
			chartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(165)), ((System.Byte)(191)), ((System.Byte)(228)));
			chartArea2.BackSecondaryColor = System.Drawing.Color.White;
			chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			chartArea2.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea2.Name = "Default";
			chartArea2.ShadowColor = System.Drawing.Color.Transparent;
			this.chart1.ChartAreas.Add(chartArea1);
			this.chart1.ChartAreas.Add(chartArea2);
			legend1.Alignment = System.Drawing.StringAlignment.Far;
			legend1.IsTextAutoFit = false;
			legend1.BackColor = System.Drawing.Color.Transparent;
			legend1.Enabled = false;
			legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
			legend1.Name = "Default";
			legend1.Position.Auto = false;
			legend1.Position.Height = 15F;
			legend1.Position.Width = 30F;
			legend1.Position.X = 63F;
			legend1.Position.Y = 5F;
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(16, 48);
			this.chart1.Name = "chart1";
			this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
			series1.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(180)), ((System.Byte)(26)), ((System.Byte)(59)), ((System.Byte)(105)));
			series1.CustomProperties = "LabelStyle=\"down\"";
			series1.Name = "FirstGroup";
			series2.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(180)), ((System.Byte)(26)), ((System.Byte)(59)), ((System.Byte)(105)));
			series2.ChartArea = "Chart Area 2";
			series2.Name = "SecondGroup";
			series3.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(180)), ((System.Byte)(26)), ((System.Byte)(59)), ((System.Byte)(105)));
			series3.ChartArea = "Default";
            series3.ChartType = SeriesChartType.Area;
			series3.Name = "Distribution";
			series4.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(180)), ((System.Byte)(26)), ((System.Byte)(59)), ((System.Byte)(105)));
			series4.ChartArea = "";
			series4.Name = "Result";
			this.chart1.Series.Add(series1);
			this.chart1.Series.Add(series2);
			this.chart1.Series.Add(series3);
			this.chart1.Series.Add(series4);
			this.chart1.Size = new System.Drawing.Size(412, 296);
			this.chart1.TabIndex = 1;
			this.chart1.Click += new System.EventHandler(this.chart1_Click);
			// 
			// labelSampleComment
			// 
			this.labelSampleComment.Font = new System.Drawing.Font("Verdana", 11F);
			this.labelSampleComment.Location = new System.Drawing.Point(16, 8);
			this.labelSampleComment.Name = "labelSampleComment";
			this.labelSampleComment.Size = new System.Drawing.Size(702, 34);
			this.labelSampleComment.TabIndex = 0;
			this.labelSampleComment.Text = "This sample demonstrates the F-Test and F Distribution.";
			this.labelSampleComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.label14,
																				 this.label15,
																				 this.label12,
																				 this.label13,
																				 this.label10,
																				 this.label11,
																				 this.label8,
																				 this.label9,
																				 this.label6,
																				 this.label7,
																				 this.label4,
																				 this.label5,
																				 this.label3,
																				 this.label1,
																				 this.button1,
																				 this.label2,
																				 this.comboBox2});
			this.panel1.Location = new System.Drawing.Point(432, 56);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(292, 288);
			this.panel1.TabIndex = 2;
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label14.Location = new System.Drawing.Point(170, 184);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(104, 16);
			this.label14.TabIndex = 15;
			this.label14.Text = "label14";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label15.Location = new System.Drawing.Point(0, 184);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(160, 16);
			this.label15.TabIndex = 14;
			this.label15.Text = "label15";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label12.Location = new System.Drawing.Point(170, 160);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(104, 16);
			this.label12.TabIndex = 13;
			this.label12.Text = "label12";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label13.Location = new System.Drawing.Point(25, 160);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(136, 16);
			this.label13.TabIndex = 12;
			this.label13.Text = "label13";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.Location = new System.Drawing.Point(170, 136);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(104, 16);
			this.label10.TabIndex = 11;
			this.label10.Text = "label10";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.Location = new System.Drawing.Point(25, 136);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(136, 16);
			this.label11.TabIndex = 10;
			this.label11.Text = "label11";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(170, 112);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(104, 16);
			this.label8.TabIndex = 9;
			this.label8.Text = "label8";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(25, 112);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(136, 16);
			this.label9.TabIndex = 8;
			this.label9.Text = "label9";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(170, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 16);
			this.label6.TabIndex = 7;
			this.label6.Text = "label6";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(25, 88);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(136, 16);
			this.label7.TabIndex = 6;
			this.label7.Text = "label7";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(170, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "label4";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(25, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(136, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "label5";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(170, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "label3";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(25, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "label1";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.Location = new System.Drawing.Point(112, 208);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(168, 24);
			this.button1.TabIndex = 16;
			this.button1.Text = "&Random Data";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "&Probability:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.Items.AddRange(new object[] {
														   "20",
														   "40",
														   "60",
														   "80",
														   "90",
														   "95",
														   "99"});
			this.comboBox2.Location = new System.Drawing.Point(168, 8);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(112, 22);
			this.comboBox2.TabIndex = 1;
			this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("Verdana", 11F);
			this.label16.Location = new System.Drawing.Point(13, 352);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(702, 40);
			this.label16.TabIndex = 4;
			this.label16.Text = "The appearance of a red region in the Distribution chart area means that a hypoth" +
				"esis is rejected, while the appearance of a green region indicates that a hypoth" +
				"esis is accepted.";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FTest
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label16,
																		  this.panel1,
																		  this.labelSampleComment,
																		  this.chart1});
			this.Font = new System.Drawing.Font("Verdana", 9F);
			this.Name = "FTest";
			this.Size = new System.Drawing.Size(728, 480);
			this.Load += new System.EventHandler(this.TemplateSampleControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Fill Data points with values from F distribution
		/// </summary>
		private void FillFDistribution( int n, int m )
		{
			// Clear all data points
			chart1.Series[2].Points.Clear();

			// Set axis values
			chart1.ChartAreas[1].AxisX.Minimum = 0;
			chart1.ChartAreas[1].AxisX.Maximum = 6;
			chart1.ChartAreas[1].AxisY.Minimum = 0;
			chart1.ChartAreas[1].AxisY.Maximum = 1.0;
			
			// Calculate Beta function
			double beta = chart1.DataManipulator.Statistics.BetaFunction( n/2.0, m/2.0 );

			// Find coefficient
			double y;
			double coef = Math.Pow( (double)( n ) / (double)( m ), n / 2.0 ) / beta;
			double doubleX;

			// Go throw all data points and calculate values
			for( double x = 0.01; x <= 15; x += 0.1 )
			{
				doubleX = x;
				y = coef * Math.Pow( doubleX, n / 2.0 - 1.0 ) / Math.Pow(1.0 + n*doubleX/m,(n+m)/2.0);

				// Add data point
				chart1.Series[2].Points.AddXY( doubleX, y );
			}

			// Refresh chart
			chart1.Invalidate();
		}

				
		/// <summary>
		/// Selection mode for F Distribution
		/// </summary>
		private void SelectFDistribution( double fValue, double fValueDist )
		{
				// Go throw all data points and change color for selected data points
				foreach( DataPoint point in chart1.Series[2].Points )
				{
					if( point.XValue < fValue && point.XValue < fValueDist )
					{
						point.Color = Color.FromArgb(128, 252,180,65); // Yellow
					}
					else if( point.XValue > fValue && point.XValue > fValueDist )
					{
						point.Color = Color.FromArgb(128, 120,147,190); // Gray
					}
					else if(  point.XValue < fValue && point.XValue > fValueDist )
					{
						point.Color = Color.FromArgb(128, 224,64,10); // Red
					}
					else if(  point.XValue > fValue && point.XValue < fValueDist )
					{
						point.Color = Color.FromArgb(128, 0,92,219); // Blue
					}
				}
		}


		
		private void TemplateSampleControl_Load(object sender, System.EventArgs e)
		{
			FillData();
			this.comboBox2.SelectedIndex = 5;
			StartTest();
		}

		private void FillData()
		{
			// Fill data with random values
			Random rand = new Random();

			chart1.Series[0].Points.Clear();
			chart1.Series[1].Points.Clear();

			for( int i = 0; i <= 20; i++ )
			{
				chart1.Series[0].Points.AddXY(i,rand.Next(40));
			}

			for( int i = 0; i <= 20; i++ )
			{
				chart1.Series[1].Points.AddXY(i,rand.Next(40));
			}
		}

		private void StartTest()
		{
			// Calculate probability
			double probability = double.Parse( this.comboBox2.Text );
			probability = probability / 100.0;
			
			// Make FTest
			FTestResult result = chart1.DataManipulator.Statistics.FTest( probability, "FirstGroup", "SecondGroup" ); 

			// Fill labels with results
			this.label1.Text = "First series mean:";
			this.label3.Text = result.FirstSeriesMean.ToString("G4");
			this.label5.Text = "Second series mean:";
			this.label4.Text = result.SecondSeriesMean.ToString("G4");
			this.label7.Text = "First series variance:";
			this.label6.Text = result.FirstSeriesVariance.ToString("G4");
			this.label9.Text = "Second series variance:";
			this.label8.Text = result.SecondSeriesVariance.ToString("G4");
			this.label11.Text = "F Value:";
			this.label10.Text = result.FValue.ToString("G4");
			this.label13.Text = "P (F<=f) one-tail:";
			this.label12.Text = result.ProbabilityFOneTail.ToString("G4");
			this.label15.Text = "F Critical value one-tail:";
			this.label14.Text = result.FCriticalValueOneTail.ToString("G4");
			
			FillFDistribution( chart1.Series["FirstGroup"].Points.Count - 1, chart1.Series["SecondGroup"].Points.Count - 1 );

			// Select regions with different colors for distributions
			SelectFDistribution( result.FValue, result.FCriticalValueOneTail );

			// Refresh Chart
			chart1.Invalidate();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			FillData();
			StartTest();

			chart1.Invalidate();
		}

		private void label5_Click(object sender, System.EventArgs e)
		{
		
		}

		private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			StartTest();
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			StartTest();
		}

		private void chart1_Click(object sender, System.EventArgs e)
		{
		
		}
		
	}
}
