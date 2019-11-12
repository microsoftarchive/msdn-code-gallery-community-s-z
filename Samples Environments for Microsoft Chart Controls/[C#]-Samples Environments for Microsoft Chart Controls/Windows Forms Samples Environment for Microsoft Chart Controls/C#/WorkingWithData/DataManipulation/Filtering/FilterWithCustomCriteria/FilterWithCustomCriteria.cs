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
	/// Summary description for FilterWithCustomCriteria.
	/// </summary>
	public class FilterWithCustomCriteria : System.Windows.Forms.UserControl
	{
		private	bool	enableEvents = false;

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label labelSampleComment;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox comboBoxShowAsIndexed;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxOffset;
		private System.Windows.Forms.ComboBox comboBoxWidth;
		private System.Windows.Forms.Label label4;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FilterWithCustomCriteria()
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
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 1);
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterWithCustomCriteria));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelSampleComment = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxShowAsIndexed = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxOffset = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxWidth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LabelStyle.Interval = 20;
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.Interval = 20;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorTickMark.Interval = 20;
            chartArea1.AxisX.Maximum = 100;
            chartArea1.AxisX.Minimum = 0;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.Maximum = 50;
            chartArea1.AxisY.Minimum = 0;
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY2.LabelStyle.Enabled = false;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.Title = "Original Data";
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Trebuchet MS", 8F);
            chartArea1.BackColor = System.Drawing.Color.OldLace;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
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
            chartArea2.Area3DStyle.Rotation = 10;
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisX.LabelStyle.Interval = 20;
            chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX.MajorGrid.Interval = 20;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX.MajorTickMark.Interval = 20;
            chartArea2.AxisX.Maximum = 100;
            chartArea2.AxisX.Minimum = 0;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.Maximum = 50;
            chartArea2.AxisY.Minimum = 0;
            chartArea2.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisY2.LabelStyle.Enabled = false;
            chartArea2.AxisY2.MajorGrid.Enabled = false;
            chartArea2.AxisY2.MajorTickMark.Enabled = false;
            chartArea2.AxisY2.Title = "Filtered Data";
            chartArea2.AxisY2.TitleFont = new System.Drawing.Font("Trebuchet MS", 8F);
            chartArea2.BackColor = System.Drawing.Color.OldLace;
            chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
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
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.Legend = "Default";
            series1.Name = "Series Input";
            series1.Points.Add(dataPoint1);
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series2.ChartArea = "FilteredData";
            series2.Legend = "Default";
            series2.Name = "Series Output";
            series2.Points.Add(dataPoint2);
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
            this.labelSampleComment.Text = "This sample demonstrates how to filter data points using custom filtering criteri" +
                "a.";
            this.labelSampleComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxShowAsIndexed);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxOffset);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxWidth);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(432, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 288);
            this.panel1.TabIndex = 2;
            // 
            // comboBoxShowAsIndexed
            // 
            this.comboBoxShowAsIndexed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShowAsIndexed.Items.AddRange(new object[] {
            "False",
            "True"});
            this.comboBoxShowAsIndexed.Location = new System.Drawing.Point(168, 72);
            this.comboBoxShowAsIndexed.Name = "comboBoxShowAsIndexed";
            this.comboBoxShowAsIndexed.Size = new System.Drawing.Size(121, 22);
            this.comboBoxShowAsIndexed.TabIndex = 5;
            this.comboBoxShowAsIndexed.SelectedIndexChanged += new System.EventHandler(this.comboBoxWidth_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Show as &Indexed:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxOffset
            // 
            this.comboBoxOffset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOffset.Items.AddRange(new object[] {
            "0",
            "10",
            "20"});
            this.comboBoxOffset.Location = new System.Drawing.Point(168, 40);
            this.comboBoxOffset.Name = "comboBoxOffset";
            this.comboBoxOffset.Size = new System.Drawing.Size(121, 22);
            this.comboBoxOffset.TabIndex = 3;
            this.comboBoxOffset.SelectedIndexChanged += new System.EventHandler(this.comboBoxWidth_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Interval &Offset:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxWidth
            // 
            this.comboBoxWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWidth.Items.AddRange(new object[] {
            "5",
            "10",
            "20"});
            this.comboBoxWidth.Location = new System.Drawing.Point(168, 8);
            this.comboBoxWidth.Name = "comboBoxWidth";
            this.comboBoxWidth.Size = new System.Drawing.Size(121, 22);
            this.comboBoxWidth.TabIndex = 1;
            this.comboBoxWidth.SelectedIndexChanged += new System.EventHandler(this.comboBoxWidth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Interval &Width:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 11F);
            this.label4.Location = new System.Drawing.Point(16, 360);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(702, 56);
            this.label4.TabIndex = 3;
            this.label4.Text = resources.GetString("label4.Text");
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FilterWithCustomCriteria
            // 
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSampleComment);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Name = "FilterWithCustomCriteria";
            this.Size = new System.Drawing.Size(728, 480);
            this.Load += new System.EventHandler(this.TemplateSampleControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void FillData()
		{
			// Populate chart with random data
			Random	random = new Random();
			double	xValue = 2;
			chart1.Series["Series Input"].Points.Clear();
			for(int pointIndex = 0; pointIndex < 50; pointIndex++)
			{
				chart1.Series["Series Input"].Points.AddXY(xValue, random.Next(2, 47));
				xValue += 2;
			}
		}

		private void UpdateChartSettings()
		{
			// Create strip lines which cover the areas with filtered values
			chart1.ChartAreas["Default"].AxisX.StripLines.Clear();
			StripLine stripLine = new StripLine();
			stripLine.BackColor = Color.FromArgb(120, 241,185,168);
			stripLine.IntervalOffset = double.Parse(comboBoxOffset.Text);
			stripLine.Interval = double.Parse(comboBoxWidth.Text) * 2.0;
			stripLine.StripWidth = double.Parse(comboBoxWidth.Text);
			chart1.ChartAreas["Default"].AxisX.StripLines.Add(stripLine);

			// Filter series data using custom filtering criteria
			chart1.DataManipulator.Filter(new CustomFilter(stripLine.IntervalOffset, stripLine.StripWidth), "Series Input", "Series Output");

			// Show data points using point's index
			if(comboBoxShowAsIndexed.Text == "True")
			{
				chart1.Series["Series Output"].IsXValueIndexed = true;
				chart1.ChartAreas["FilteredData"].AxisX.Minimum = double.NaN;
				chart1.ChartAreas["FilteredData"].AxisX.Maximum = double.NaN;
				chart1.ChartAreas["FilteredData"].AxisX.LabelStyle.Interval = 2;
				chart1.ChartAreas["FilteredData"].AxisX.MajorTickMark.Interval = 2;
				chart1.ChartAreas["FilteredData"].AxisX.MajorGrid.Interval = 2;
			}
			else
			{
				chart1.Series["Series Output"].IsXValueIndexed = false;
				chart1.ChartAreas["FilteredData"].AxisX.Minimum = 0;
				chart1.ChartAreas["FilteredData"].AxisX.Maximum = 100;
				chart1.ChartAreas["FilteredData"].AxisX.LabelStyle.Interval = 0;
				chart1.ChartAreas["FilteredData"].AxisX.MajorTickMark.Interval = 0;
				chart1.ChartAreas["FilteredData"].AxisX.MajorGrid.Interval = 0;
				
			}
		}

		private void TemplateSampleControl_Load(object sender, System.EventArgs e)
		{
			FillData();
			
			// set current selection
			comboBoxOffset.SelectedIndex = 0;
			comboBoxShowAsIndexed.SelectedIndex = 0;
			comboBoxWidth.SelectedIndex = 1;

			enableEvents = true;
			
			UpdateChartSettings();
		}

		private void comboBoxWidth_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(enableEvents)
			{
				UpdateChartSettings();
			}
		}

	}

	/// <summary>
	/// Class define custom filtering criteria
	/// </summary>
	public class CustomFilter : IDataPointFilter
	{
		private double offset = 0;		// interval offset
		private double interval = 0;	// interval size

		// Public constructor
		public CustomFilter(double offset, double interval)
		{
			this.offset = offset;
			this.interval = interval;
		}

		// Filtering method
		public bool FilterDataPoint(DataPoint dataPoint, Series series, int pointIndex)
		{
			// Check if point's X value is in one of the intervals
			for(double val = offset; val < 100; val += 2.0 * interval)
			{
				if(dataPoint.XValue >= val && dataPoint.XValue <= (val + interval))
				{
					return true;	// Return true to remove the point
				}
			}
			return false;	// Return false to keep the point
		}
	}

}
