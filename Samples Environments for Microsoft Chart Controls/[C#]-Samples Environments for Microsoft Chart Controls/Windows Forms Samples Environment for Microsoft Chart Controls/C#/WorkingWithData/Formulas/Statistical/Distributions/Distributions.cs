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
	public class Distributions : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label labelSampleComment;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label ResultValue;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Distributions()
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelSampleComment = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ResultValue = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart1.BackSecondaryColor = System.Drawing.Color.White;
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderlineWidth = 2;
            this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.Inclination = 15;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.BackColor = System.Drawing.Color.Gainsboro;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea1.BackImageTransparentColor = System.Drawing.Color.White;
            chartArea1.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 87.62751F;
            chartArea1.InnerPlotPosition.Width = 88.8228F;
            chartArea1.InnerPlotPosition.X = 9.4162F;
            chartArea1.InnerPlotPosition.Y = 2.99507F;
            chartArea1.Name = "Default";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 87.64407F;
            chartArea1.Position.Width = 89.43796F;
            chartArea1.Position.X = 4.824818F;
            chartArea1.Position.Y = 5.542373F;
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            legend1.Position.Auto = false;
            legend1.Position.Height = 15F;
            legend1.Position.Width = 30F;
            legend1.Position.X = 63F;
            legend1.Position.Y = 5F;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(16, 56);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.CustomProperties = "LabelStyle=\"down\"";
            series1.Legend = "Default";
            series1.Name = "Distributions";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(412, 296);
            this.chart1.TabIndex = 1;
            // 
            // labelSampleComment
            // 
            this.labelSampleComment.Font = new System.Drawing.Font("Verdana", 11F);
            this.labelSampleComment.Location = new System.Drawing.Point(16, 8);
            this.labelSampleComment.Name = "labelSampleComment";
            this.labelSampleComment.Size = new System.Drawing.Size(702, 40);
            this.labelSampleComment.TabIndex = 0;
            this.labelSampleComment.Text = "This sample demonstrates three statistical distribution formulas: normal distribu" +
                "tion, t-distribution (also called Student’s t-distribution) and F-distribution. " +
                "";
            this.labelSampleComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ResultValue);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox4);
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(432, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 288);
            this.panel1.TabIndex = 2;
            // 
            // ResultValue
            // 
            this.ResultValue.ForeColor = System.Drawing.Color.Red;
            this.ResultValue.Location = new System.Drawing.Point(168, 152);
            this.ResultValue.Name = "ResultValue";
            this.ResultValue.Size = new System.Drawing.Size(112, 22);
            this.ResultValue.TabIndex = 11;
            this.ResultValue.Text = "Result";
            this.ResultValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(62, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "Result Value:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(216, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "&M:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(136, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "&N:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-8, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Degree of Freedom:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(78, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Probability:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distribution &Name:";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "8",
            "10",
            "15",
            "20",
            "30"});
            this.comboBox4.Location = new System.Drawing.Point(240, 120);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(40, 22);
            this.comboBox4.TabIndex = 9;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "8",
            "10",
            "15",
            "20",
            "30"});
            this.comboBox3.Location = new System.Drawing.Point(168, 120);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(40, 22);
            this.comboBox3.TabIndex = 7;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(79, 88);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 24);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "One &Tail:";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Items.AddRange(new object[] {
            "10",
            "20",
            "40",
            "60",
            "80",
            "90",
            "95",
            "99"});
            this.comboBox2.Location = new System.Drawing.Point(168, 56);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(112, 22);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "Normal Distribution",
            "T Distribution",
            "F Distribution"});
            this.comboBox1.Location = new System.Drawing.Point(8, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(272, 22);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Distributions
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSampleComment);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Distributions";
            this.Size = new System.Drawing.Size(728, 480);
            this.Load += new System.EventHandler(this.TemplateSampleControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Fill data points with values from Normal distribution
		/// </summary>
		private void FillNormalDistribution( )
		{
			
			// Remove all data points from series
			chart1.Series[0].Points.Clear();

			// Disable combo boxes for degree of freedom
			this.comboBox3.Enabled = false;
			this.comboBox4.Enabled = false;
			this.checkBox1.Enabled = true;

			// Set formula background image
			chart1.ChartAreas[0].BackImage = GetImage( "Normal.gif" );

			// Set axis values
			chart1.ChartAreas[0].AxisX.Minimum = -5;
			chart1.ChartAreas[0].AxisX.Maximum = 5;
			chart1.ChartAreas[0].AxisY.Minimum = 0;
			chart1.ChartAreas[0].AxisY.Maximum = 0.5;
			chart1.ChartAreas[0].AxisX.Interval = 2;
			chart1.ChartAreas[0].AxisX.IntervalOffset = 1;
			
			// Calculate coefficient
			double y;
			double coef = 1.0 / Math.Sqrt( 2 * Math.PI );
			double doubleX;

			// Fill data points with values from Normal distribution
			for( int x = -50; x <= 50; x ++ )
			{
				doubleX = x / 10.0;
				y = coef * Math.Exp( doubleX * doubleX / -2 );
				chart1.Series[0].Points.AddXY( doubleX - 0.05, y );
			}

			// Selection mode for normal distribution
			this.SelectNormalDistribution();

			// Refresh chart
			chart1.Invalidate();
		}

		/// <summary>
		/// Fill Data points with values from F distribution
		/// </summary>
		private void FillFDistribution( )
		{
			// Clear all data points
			chart1.Series[0].Points.Clear();

			// Disable or enable necessary controls
			this.comboBox4.Enabled = true;
			this.comboBox3.Enabled = true;
			this.checkBox1.Enabled = false;

			// Set background formula image
			chart1.ChartAreas[0].BackImage = GetImage( "FDist.gif" );

			// Set axis values
			chart1.ChartAreas[0].AxisX.Minimum = 0;
			chart1.ChartAreas[0].AxisX.Maximum = 15;
			chart1.ChartAreas[0].AxisY.Minimum = 0;
			chart1.ChartAreas[0].AxisY.Maximum = 1.2;
			chart1.ChartAreas[0].AxisX.Interval = 2;
			chart1.ChartAreas[0].AxisX.IntervalOffset = 0;

			// Set degrees of freedom
			double n = double.Parse(this.comboBox3.Text);
			double m = double.Parse(this.comboBox4.Text);
			
			// Calculate Beta function
			double beta = chart1.DataManipulator.Statistics.BetaFunction( n/2.0, m/2.0 );

			// Find coefficient
			double y;
			double coef = Math.Pow( n / m, n / 2.0 ) / beta;
			double doubleX;

			// Go through all data points and calculate values
			for( double x = 0.01; x <= 15; x += 0.1 )
			{
				doubleX = x;
				y = coef * Math.Pow( doubleX, n / 2.0 - 1.0 ) / Math.Pow(1.0 + n*doubleX/m,(n+m)/2.0);

				// Add data points
				chart1.Series[0].Points.AddXY( doubleX, y );
			}

			// Selection mode for F distribution
			SelectFDistribution( );

			// Refresh chart
			chart1.Invalidate();
		}

		/// <summary>
		/// Fill Data points with T Distribution
		/// </summary>
		private void FillTDistribution( )
		{
			// Clear all existing data points
			chart1.Series[0].Points.Clear();

			// Enable or disable controls
			this.comboBox4.Enabled = false;
			this.comboBox3.Enabled = true;
			this.checkBox1.Enabled = true;

			// Set back formula color image
			chart1.ChartAreas[0].BackImage = GetImage( "TDist.gif" );

			// Set Axis values
			chart1.ChartAreas[0].AxisX.Minimum = -12;
			chart1.ChartAreas[0].AxisX.Maximum = 12;
			chart1.ChartAreas[0].AxisY.Minimum = 0;
			chart1.ChartAreas[0].AxisY.Maximum = 0.5;
			chart1.ChartAreas[0].AxisX.Interval = 4;
			chart1.ChartAreas[0].AxisX.IntervalOffset = 0;
			
			// Calculate Beta function
			double n = double.Parse( this.comboBox3.Text );
			double beta = chart1.DataManipulator.Statistics.BetaFunction( 0.5, n/2.0 );

			// Calculate coefficient of T Distribution
			double y;
			double coef = Math.Pow( n , -0.5 ) / beta;
			double doubleX;

			// Calculate Data Points
			for( int x = -120; x <= 120; x ++ )
			{
				doubleX = x / 10.0;
				y = coef / Math.Pow( 1.0 + doubleX * doubleX / n , ( n + 1.0 ) / 2.0 );

				// Add X and Y values to data points
				chart1.Series[0].Points.AddXY( doubleX, y );
			}

			// Call selection method.
			SelectTDistribution( );

			// Refresh chart
			chart1.Invalidate();
		}

		/// <summary>
		/// Selection mode for Normal Distribution
		/// </summary>
		private void SelectNormalDistribution( )
		{
			// One tailed normal distribution or two tails
			bool oneTail = this.checkBox1.Checked;

			// Colors for selected and non-selected data points
			Color AlphaSelected = Color.FromArgb(94, 65,140,240);
			Color AlphaNotSelected = Color.FromArgb(64, 224,64,10);

			// Probability value
			double probability;
			if( comboBox2.Text == "" )
				probability = 0.90;
			else
				probability = double.Parse( comboBox2.Text ) / 100.0;

			// Change probability for two tail Students distribution
			if( !oneTail )
			{
				probability = ( probability + 1.0 ) / 2.0;
			}

			// Calculate students distribution
			double zValue;
			zValue = chart1.DataManipulator.Statistics.InverseNormalDistribution( probability );

			ResultValue.Text = zValue.ToString("G5");

			// Go through all data points and change color for selected points.
			foreach( DataPoint point in chart1.Series[0].Points )
			{
				// Different selection for one tail and two tailed
				if( oneTail )
				{
					if( zValue < point.XValue )
					{
						point.Color = AlphaSelected;
					}
					else
					{
						point.Color = AlphaNotSelected;
					}
				}
				else
				{
					if( zValue < Math.Abs( point.XValue ) )
					{
						point.Color = AlphaSelected;
					}
					else
					{
						point.Color = AlphaNotSelected;
					}
				}
			}
		}

		/// <summary>
		/// Selection mode for students distribution
		/// </summary>
		private void SelectTDistribution( )
		{
			// One tailed normal distribution or two tails
			bool oneTail = this.checkBox1.Checked;

			// Colors for selected and not selected data points
			Color AlphaSelected = Color.FromArgb(94, 65,140,240);
			Color AlphaNotSelected = Color.FromArgb(64, 224,64,10);

			// Probability value
			double probability;
			if( comboBox2.Text == "" )
				probability = 0.90;
			else
				probability = double.Parse( comboBox2.Text ) / 100.0;

			// Special case if probability is less then 50% with one tail
			bool probabilityLess50 = probability < 0.5 && oneTail;

			if( oneTail )
			{
				if( probabilityLess50 )
				{
					probability = 1 - ( 0.5 - probability) * 2;
				}
				else
				{
					probability = ( 1 - probability) * 2;
				}
			}
			else
			{
				probability = ( 1 - probability);
			}
			
			// Calculate Inverse students distribution
			double zValue = chart1.DataManipulator.Statistics.InverseTDistribution( probability, int.Parse(this.comboBox3.Text) );

			if( probabilityLess50 )
			{
				zValue *= -1.0;
			}

			ResultValue.Text = zValue.ToString("G5");

			// Go throw all data points and change color for selected data points
			foreach( DataPoint point in chart1.Series[0].Points )
			{
				if( oneTail )
				{
					if( zValue < point.XValue )
					{
						point.Color = AlphaSelected;
					}
					else
					{
						point.Color = AlphaNotSelected;
					}
				}
				else
				{
					if( zValue < Math.Abs( point.XValue ) )
					{
						point.Color = AlphaSelected;
					}
					else
					{
						point.Color = AlphaNotSelected;
					}
				}
			}
		}


		/// <summary>
		/// Selection mode for F distribution
		/// </summary>
		private void SelectFDistribution( )
		{
			// Set colors for selected and not selected data points
			Color AlphaSelected = Color.FromArgb(94, 65,140,240);
			Color AlphaNotSelected = Color.FromArgb(64, 224,64,10);

			// Probability value
			double probability;
			if( comboBox2.Text == "" )
				probability = 0.90;
			else
				probability = double.Parse( comboBox2.Text ) / 100.0;


			// Calculate Inverse F distribution
			double fValue;
			fValue = chart1.DataManipulator.Statistics.InverseFDistribution( 1-probability, int.Parse(this.comboBox3.Text), int.Parse(this.comboBox4.Text) );

			ResultValue.Text = fValue.ToString("G5");

			// Go through all data points and change color for selected points
			foreach( DataPoint point in chart1.Series[0].Points )
			{
				if( fValue < point.XValue )
				{
					point.Color = AlphaSelected;
				}
				else
				{
					point.Color = AlphaNotSelected;
				}
			}
		}

		private void TemplateSampleControl_Load(object sender, System.EventArgs e)
		{
			// Set default values for combo boxes
			comboBox3.Text = "4";
			comboBox4.Text = "4";
			comboBox2.SelectedIndex = 5;
			comboBox1.SelectedIndex = 0;
			
			SetDistribution();
		}
		
		private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SelectDistribution();
		}

		private void SelectDistribution()
		{
			// Change color of data points which are not selected
			if( comboBox1.Text == "Normal Distribution" )
			{
				SelectNormalDistribution();
			}
			else if( comboBox1.Text == "T Distribution" )
			{
				SelectTDistribution();
			}
			else
			{
				SelectFDistribution( );
			}
			
		}

		private void SetDistribution()
		{
			// Fill data points with values from distributions
			if( comboBox1.Text == "Normal Distribution" )
			{
				FillNormalDistribution( );
			}
			else if( comboBox1.Text == "T Distribution" )
			{
				FillTDistribution( );
			}
			else
			{
				FillFDistribution( );
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetDistribution();
		}

		private string GetImage( string fileName )
		{
			System.Windows.Forms.DataVisualization.Charting.Utilities.SampleMain.MainForm mainForm = (System.Windows.Forms.DataVisualization.Charting.Utilities.SampleMain.MainForm)this.ParentForm;
			string imageFileName = mainForm.applicationPath + "\\";
			imageFileName += "Images\\";
			imageFileName += fileName;

			return imageFileName;
		}
		
		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			SetDistribution();
		}

		private void comboBox3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if( comboBox4.Text != "" )
				SetDistribution();
		}

		private void comboBox4_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if( comboBox3.Text != "" )
				SetDistribution();
		}
	}
}
