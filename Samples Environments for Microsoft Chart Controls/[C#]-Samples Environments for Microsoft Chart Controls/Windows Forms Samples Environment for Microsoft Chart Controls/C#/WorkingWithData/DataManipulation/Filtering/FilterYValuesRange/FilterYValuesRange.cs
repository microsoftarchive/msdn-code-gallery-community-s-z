using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.DataVisualization.Charting.Utilities;

namespace WinFormsChartSamples
{
	/// <summary>
	/// Summary description for FilterYValuesRange.
	/// </summary>
	public class FilterYValuesRange : System.Windows.Forms.UserControl
	{
		private bool	updateChart = false;

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label labelSampleComment;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxCriteriaUsage;
		private System.Windows.Forms.ComboBox comboBoxValueMoreThan;
		private System.Windows.Forms.ComboBox comboBoxPointValueUsed;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FilterYValuesRange()
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
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelSampleComment = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxValueMoreThan = new System.Windows.Forms.ComboBox();
            this.comboBoxCriteriaUsage = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPointValueUsed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            chartArea1.Area3DStyle.PointGapDepth = 0;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LabelStyle.Interval = 200;
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.Interval = 200;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorTickMark.Interval = 200;
            chartArea1.AxisX.Maximum = 1000;
            chartArea1.AxisX.Minimum = 0;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LabelStyle.Interval = 200;
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.Interval = 200;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorTickMark.Interval = 200;
            chartArea1.AxisY.Maximum = 1000;
            chartArea1.AxisY.Minimum = 0;
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY2.LabelStyle.Enabled = false;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.Title = "Original Data";
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Trebuchet MS", 8.25F);
            chartArea1.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 43F;
            chartArea1.Position.Width = 90F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 7F;
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            chartArea2.AlignWithChartArea = "Default";
            chartArea2.Area3DStyle.Inclination = 15;
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.Area3DStyle.IsRightAngleAxes = false;
            chartArea2.Area3DStyle.Perspective = 10;
            chartArea2.Area3DStyle.PointGapDepth = 0;
            chartArea2.Area3DStyle.Rotation = 10;
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisX.LabelStyle.Interval = 200;
            chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX.MajorGrid.Interval = 200;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX.MajorTickMark.Interval = 200;
            chartArea2.AxisX.Maximum = 1000;
            chartArea2.AxisX.Minimum = 0;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.LabelStyle.Interval = 200;
            chartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.MajorGrid.Interval = 200;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.MajorTickMark.Interval = 200;
            chartArea2.AxisY.Maximum = 1000;
            chartArea2.AxisY.Minimum = 0;
            chartArea2.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisY2.LabelStyle.Enabled = false;
            chartArea2.AxisY2.MajorGrid.Enabled = false;
            chartArea2.AxisY2.MajorTickMark.Enabled = false;
            chartArea2.AxisY2.Title = "Filtered Data";
            chartArea2.AxisY2.TitleFont = new System.Drawing.Font("Trebuchet MS", 8.25F);
            chartArea2.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "FilteredData";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 43F;
            chartArea2.Position.Width = 90F;
            chartArea2.Position.X = 3F;
            chartArea2.Position.Y = 48F;
            chartArea2.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(16, 48);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.Transparent;
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.BorderWidth = 0;
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.Legend = "Default";
            series1.Name = "Series Input";
            series1.ShadowOffset = 2;
            series2.BorderColor = System.Drawing.Color.Transparent;
            series2.BorderWidth = 0;
            series2.ChartArea = "FilteredData";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            series2.Legend = "Default";
            series2.Name = "Series Output";
            series2.ShadowOffset = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(412, 296);
            this.chart1.TabIndex = 1;
            // 
            // labelSampleComment
            // 
            this.labelSampleComment.Font = new System.Drawing.Font("Verdana", 11F);
            this.labelSampleComment.Location = new System.Drawing.Point(16, 8);
            this.labelSampleComment.Name = "labelSampleComment";
            this.labelSampleComment.Size = new System.Drawing.Size(702, 34);
            this.labelSampleComment.TabIndex = 0;
            this.labelSampleComment.Text = "This sample demonstrates how to filter data points by their X or Y values.";
            this.labelSampleComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.comboBoxPointValueUsed);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(432, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 288);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxValueMoreThan);
            this.groupBox1.Controls.Add(this.comboBoxCriteriaUsage);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(16, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 112);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtering Criteria:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Filtering Criteria Usage:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxValueMoreThan
            // 
            this.comboBoxValueMoreThan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxValueMoreThan.Items.AddRange(new object[] {
            "800",
            "600",
            "400",
            "200"});
            this.comboBoxValueMoreThan.Location = new System.Drawing.Point(144, 24);
            this.comboBoxValueMoreThan.Name = "comboBoxValueMoreThan";
            this.comboBoxValueMoreThan.Size = new System.Drawing.Size(122, 22);
            this.comboBoxValueMoreThan.TabIndex = 1;
            this.comboBoxValueMoreThan.SelectedIndexChanged += new System.EventHandler(this.comboBoxValueMoreThan_SelectedIndexChanged);
            // 
            // comboBoxCriteriaUsage
            // 
            this.comboBoxCriteriaUsage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCriteriaUsage.Items.AddRange(new object[] {
            "Remove matching points",
            "Remove non-matching points"});
            this.comboBoxCriteriaUsage.Location = new System.Drawing.Point(20, 80);
            this.comboBoxCriteriaUsage.Name = "comboBoxCriteriaUsage";
            this.comboBoxCriteriaUsage.Size = new System.Drawing.Size(246, 22);
            this.comboBoxCriteriaUsage.TabIndex = 3;
            this.comboBoxCriteriaUsage.SelectedIndexChanged += new System.EventHandler(this.comboBoxValueMoreThan_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "&Value is more than:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxPointValueUsed
            // 
            this.comboBoxPointValueUsed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPointValueUsed.Items.AddRange(new object[] {
            "Y",
            "X"});
            this.comboBoxPointValueUsed.Location = new System.Drawing.Point(168, 8);
            this.comboBoxPointValueUsed.Name = "comboBoxPointValueUsed";
            this.comboBoxPointValueUsed.Size = new System.Drawing.Size(112, 22);
            this.comboBoxPointValueUsed.TabIndex = 1;
            this.comboBoxPointValueUsed.SelectedIndexChanged += new System.EventHandler(this.comboBoxValueMoreThan_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Point Value &Used:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Verdana", 11F);
            this.label5.Location = new System.Drawing.Point(16, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(702, 56);
            this.label5.TabIndex = 3;
            this.label5.Text = "Filtering criteria is defined by comparing the selected X or Y value against a sp" +
                "ecified constant value. Points can be removed if they match or do not match the " +
                "filtering criteria. ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FilterYValuesRange
            // 
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSampleComment);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Name = "FilterYValuesRange";
            this.Size = new System.Drawing.Size(728, 480);
            this.Load += new System.EventHandler(this.TemplateSampleControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void UpdateChartSettings()
		{
			// Get filtering criteria constant
			double criteriaValue = double.Parse(comboBoxValueMoreThan.Text);

			// Create strip line which covers the area with filtered values
			StripLine stripLine = new StripLine();
			stripLine.BackColor = Color.FromArgb(120, 241,185,168);
			stripLine.IntervalOffset = criteriaValue;
			stripLine.StripWidth = 1000;
			chart1.ChartAreas["Default"].AxisY.StripLines.Clear();
			chart1.ChartAreas["Default"].AxisX.StripLines.Clear();
			if(comboBoxPointValueUsed.Text == "Y")
			{
				chart1.ChartAreas["Default"].AxisY.StripLines.Add(stripLine);
			}
			else
			{
				chart1.ChartAreas["Default"].AxisX.StripLines.Add(stripLine);
			}

			// Points that do not match the criteria will be removed
			if(comboBoxCriteriaUsage.Text == "Remove matching points")
			{
				chart1.DataManipulator.FilterMatchedPoints = false;

				// Update the strip line which covers filtered area
				stripLine.IntervalOffset = 0;
				stripLine.StripWidth = criteriaValue;
			}
			else
			{
				chart1.DataManipulator.FilterMatchedPoints = true;
			}

			// Filter series data by point's values
			chart1.DataManipulator.Filter(CompareMethod.MoreThan, criteriaValue, "Series Input", "Series Output", comboBoxPointValueUsed.Text);
		}

		private void TemplateSampleControl_Load(object sender, System.EventArgs e)
		{
			// Populate chart with random data
			Random random = new Random();
			for(int pointIndex = 0; pointIndex < 100; pointIndex++)
			{
				chart1.Series["Series Input"].Points.AddXY(random.Next(50,950), random.Next(50,950));
			}
		
			// Set current selection
			comboBoxValueMoreThan.SelectedIndex = 0;
			comboBoxPointValueUsed.SelectedIndex = 1;
			comboBoxCriteriaUsage.SelectedIndex = 0;

			// Update chart settings
            updateChart = true;
			UpdateChartSettings();
		}

		private void comboBoxValueMoreThan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(updateChart)
			{
				UpdateChartSettings();
			}
		}
	}
}
