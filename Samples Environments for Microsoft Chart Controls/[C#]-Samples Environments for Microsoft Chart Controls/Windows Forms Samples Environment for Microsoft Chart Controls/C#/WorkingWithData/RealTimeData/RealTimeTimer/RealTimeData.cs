using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.OleDb;

namespace WinFormsChartSamples
{
	/// <summary>
	/// Summary description for RealTimeData
	/// </summary>
	public class RealTimeData : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label labelSampleComment;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Timer timerRealTimeData;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxUpdateInterval;
		private System.Windows.Forms.ComboBox comboBoxVisiblePoints;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxPointsRemoved;
        private System.Windows.Forms.Label label4;
		private System.ComponentModel.IContainer components;

		public RealTimeData()
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelSampleComment = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxPointsRemoved = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxVisiblePoints = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxUpdateInterval = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timerRealTimeData = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(223)))), ((int)(((byte)(193)))));
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(64)))), ((int)(((byte)(1)))));
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderlineWidth = 2;
            this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.Inclination = 15;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.Maximum = 5000;
            chartArea1.AxisY.Minimum = 1000;
            chartArea1.BackColor = System.Drawing.Color.OldLace;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(16, 40);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Default";
            series1.Name = "Default";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(412, 296);
            this.chart1.TabIndex = 1;
            // 
            // labelSampleComment
            // 
            this.labelSampleComment.Font = new System.Drawing.Font("Verdana", 11F);
            this.labelSampleComment.Location = new System.Drawing.Point(16, 8);
            this.labelSampleComment.Name = "labelSampleComment";
            this.labelSampleComment.Size = new System.Drawing.Size(704, 24);
            this.labelSampleComment.TabIndex = 0;
            this.labelSampleComment.Text = "This sample demonstrates how to create a real-time chart using a Timer object.";
            this.labelSampleComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxPointsRemoved);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBoxVisiblePoints);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxUpdateInterval);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Location = new System.Drawing.Point(432, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 288);
            this.panel1.TabIndex = 2;
            // 
            // comboBoxPointsRemoved
            // 
            this.comboBoxPointsRemoved.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPointsRemoved.Items.AddRange(new object[] {
            "1",
            "25",
            "50",
            "75"});
            this.comboBoxPointsRemoved.Location = new System.Drawing.Point(168, 88);
            this.comboBoxPointsRemoved.Name = "comboBoxPointsRemoved";
            this.comboBoxPointsRemoved.Size = new System.Drawing.Size(80, 22);
            this.comboBoxPointsRemoved.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Points &Removed:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxVisiblePoints
            // 
            this.comboBoxVisiblePoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVisiblePoints.Items.AddRange(new object[] {
            "100",
            "150",
            "200",
            "300"});
            this.comboBoxVisiblePoints.Location = new System.Drawing.Point(168, 48);
            this.comboBoxVisiblePoints.Name = "comboBoxVisiblePoints";
            this.comboBoxVisiblePoints.Size = new System.Drawing.Size(80, 22);
            this.comboBoxVisiblePoints.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Number of Visible Points:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxUpdateInterval
            // 
            this.comboBoxUpdateInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUpdateInterval.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "200",
            "300"});
            this.comboBoxUpdateInterval.Location = new System.Drawing.Point(168, 8);
            this.comboBoxUpdateInterval.Name = "comboBoxUpdateInterval";
            this.comboBoxUpdateInterval.Size = new System.Drawing.Size(80, 22);
            this.comboBoxUpdateInterval.TabIndex = 1;
            this.comboBoxUpdateInterval.SelectedIndexChanged += new System.EventHandler(this.comboBoxUpdateInterval_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update &Interval (mS):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.Control;
            this.buttonStart.Location = new System.Drawing.Point(80, 120);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(144, 23);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "&Stop Real Time Data";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timerRealTimeData
            // 
            this.timerRealTimeData.Enabled = true;
            this.timerRealTimeData.Interval = 200;
            this.timerRealTimeData.Tick += new System.EventHandler(this.timerRealTimeData_Tick);
            // 
            // RealTimeData
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSampleComment);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Name = "RealTimeData";
            this.Size = new System.Drawing.Size(728, 480);
            this.Load += new System.EventHandler(this.RealTimeData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private Random	random = new Random();
		private	int		pointIndex = 0;

		private void timerRealTimeData_Tick(object sender, System.EventArgs e)
		{
			// Define some variables
			int numberOfPointsInChart = int.Parse(comboBoxVisiblePoints.Text);
			int numberOfPointsAfterRemoval = numberOfPointsInChart - int.Parse(comboBoxPointsRemoved.Text);

			// Simulate adding new data points
			int numberOfPointsAddedMin = 5;
			int numberOfPointsAddedMax = 10;
			for(int pointNumber = 0; pointNumber <
				random.Next(numberOfPointsAddedMin, numberOfPointsAddedMax); pointNumber++)
			{
				chart1.Series[0].Points.AddXY(pointIndex + 1, random.Next(1000, 5000));
				++pointIndex;
			}

			// Adjust Y & X axis scale
			chart1.ResetAutoValues();
			if(chart1.ChartAreas["Default"].AxisX.Maximum < pointIndex)
			{
				chart1.ChartAreas["Default"].AxisX.Maximum = pointIndex;
			}

			// Keep a constant number of points by removing them from the left
			while(chart1.Series[0].Points.Count > numberOfPointsInChart)
			{
				// Remove data points on the left side
				while(chart1.Series[0].Points.Count > numberOfPointsAfterRemoval)
				{
					chart1.Series[0].Points.RemoveAt(0);
				}
		
				// Adjust X axis scale
				chart1.ChartAreas["Default"].AxisX.Minimum = pointIndex - numberOfPointsAfterRemoval;
				chart1.ChartAreas["Default"].AxisX.Maximum = chart1.ChartAreas["Default"].AxisX.Minimum + numberOfPointsInChart;
			}

			// Redraw chart
			chart1.Invalidate();
		}

		private void buttonStart_Click(object sender, System.EventArgs e)
		{
			if(this.timerRealTimeData.Enabled)
			{
				this.timerRealTimeData.Enabled = false;
				buttonStart.Text = "&Start Real Time Data";
			}
			else
			{
				this.timerRealTimeData.Enabled = true;
				buttonStart.Text = "&Stop Real Time Data";
			}
		}

		private void comboBoxUpdateInterval_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.timerRealTimeData.Interval = int.Parse(comboBoxUpdateInterval.Text);
		}

		private void RealTimeData_Load(object sender, System.EventArgs e)
		{
			comboBoxUpdateInterval.SelectedIndex = 2;
			comboBoxVisiblePoints.SelectedIndex = 2;
			comboBoxPointsRemoved.SelectedIndex = 0;
		}

	}
}
