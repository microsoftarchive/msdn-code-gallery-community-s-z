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
	/// Summary description for FilterDateRange.
	/// </summary>
	public class FilterDateRange : System.Windows.Forms.UserControl
	{
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label labelSampleComment;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxNumberOfDays;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxPointsFilter;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxShowAsIndexed;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FilterDateRange()
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
            this.comboBoxShowAsIndexed = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPointsFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxNumberOfDays = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LabelStyle.Format = "ddd, MMM d";
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX2.IsLabelAutoFit = false;
            chartArea1.AxisX2.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.IsStartedFromZero = false;
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
            chartArea1.BackColor = System.Drawing.Color.Gainsboro;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 43F;
            chartArea1.Position.Width = 90F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 5F;
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            chartArea2.AlignWithChartArea = "Default";
            chartArea2.Area3DStyle.Inclination = 15;
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.Area3DStyle.IsRightAngleAxes = false;
            chartArea2.Area3DStyle.Perspective = 10;
            chartArea2.Area3DStyle.Rotation = 10;
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisX.LabelStyle.Format = "ddd, MMM d";
            chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.IsStartedFromZero = false;
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
            chartArea2.BackColor = System.Drawing.Color.Gainsboro;
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
            series1.BorderWidth = 0;
            series1.ChartArea = "Default";
            series1.CustomProperties = "MinPixelPointWidth=3, PointWidth=0.7";
            series1.Legend = "Default";
            series1.Name = "Series Input";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series2.BorderWidth = 0;
            series2.ChartArea = "FilteredData";
            series2.CustomProperties = "MinPixelPointWidth=3, PointWidth=0.7";
            series2.Legend = "Default";
            series2.Name = "Series Output";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
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
            this.labelSampleComment.Text = "This sample demonstrates how to filter data points using date/time ranges.";
            this.labelSampleComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxShowAsIndexed);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxPointsFilter);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxNumberOfDays);
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
            this.comboBoxShowAsIndexed.SelectedIndexChanged += new System.EventHandler(this.comboBoxShowAsIndexed_SelectedIndexChanged);
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
            // comboBoxPointsFilter
            // 
            this.comboBoxPointsFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPointsFilter.Items.AddRange(new object[] {
            "Weekends",
            "Weekdays",
            "Except 15",
            "Except 1-15"});
            this.comboBoxPointsFilter.Location = new System.Drawing.Point(168, 40);
            this.comboBoxPointsFilter.Name = "comboBoxPointsFilter";
            this.comboBoxPointsFilter.Size = new System.Drawing.Size(121, 22);
            this.comboBoxPointsFilter.TabIndex = 3;
            this.comboBoxPointsFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxShowAsIndexed_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Points to Filter:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxNumberOfDays
            // 
            this.comboBoxNumberOfDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumberOfDays.Items.AddRange(new object[] {
            "30",
            "50",
            "70"});
            this.comboBoxNumberOfDays.Location = new System.Drawing.Point(168, 8);
            this.comboBoxNumberOfDays.Name = "comboBoxNumberOfDays";
            this.comboBoxNumberOfDays.Size = new System.Drawing.Size(121, 22);
            this.comboBoxNumberOfDays.TabIndex = 1;
            this.comboBoxNumberOfDays.SelectedIndexChanged += new System.EventHandler(this.comboBoxNumberOfDays_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Days in Series:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FilterDateRange
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSampleComment);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Name = "FilterDateRange";
            this.Size = new System.Drawing.Size(728, 480);
            this.Load += new System.EventHandler(this.TemplateSampleControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void UpdateChartSettings()
		{
			// Show data points using point's index
			if(comboBoxShowAsIndexed.Text == "True")
			{
				chart1.Series["Series Output"].IsXValueIndexed = true;
				chart1.DataManipulator.FilterSetEmptyPoints = false;
				chart1.ResetAutoValues();
			}
			else
			{
				chart1.Series["Series Output"].IsXValueIndexed = false;
				chart1.DataManipulator.FilterSetEmptyPoints = true;
				chart1.ResetAutoValues();
				chart1.ChartAreas["FilteredData"].AxisY.Minimum = 0;
				chart1.ChartAreas["FilteredData"].AxisY.Maximum = 1000;
			}
			
			// Filter series data 
			if(comboBoxPointsFilter.Text == "Weekends")
			{
				chart1.DataManipulator.Filter(DateRangeType.DayOfWeek, "0,6", "Series Input", "Series Output");
			}
			else if(comboBoxPointsFilter.Text == "Weekdays")
			{
				chart1.DataManipulator.Filter(DateRangeType.DayOfWeek, "1-5", "Series Input", "Series Output");
			}
			else if(comboBoxPointsFilter.Text == "Except 15")
			{
				chart1.DataManipulator.Filter(DateRangeType.DayOfMonth, "1-14,16-31", "Series Input", "Series Output");
			}
			else if(comboBoxPointsFilter.Text == "Except 1-15")
			{
				chart1.DataManipulator.Filter(DateRangeType.DayOfMonth, "16-31", "Series Input", "Series Output");
			}
		}

		private void FillData()
		{
			// Populate chart with random sales data
			Random		random = new Random();
			DateTime	xTime = new DateTime(2000, 8, 1, 0, 0, 0);
			chart1.Series["Series Input"].Points.Clear();
			for(int pointIndex = 0; pointIndex < int.Parse(comboBoxNumberOfDays.Text); pointIndex++)
			{
				// Simulate lower sales on the weekends	
				double	yValue = random.Next(600, 950);
				if(xTime.DayOfWeek == DayOfWeek.Sunday || xTime.DayOfWeek == DayOfWeek.Saturday)
				{
					yValue = random.Next(100, 400);
				}
				chart1.Series["Series Input"].Points.AddXY(xTime, yValue);
				xTime = xTime.AddDays(1);
			}

			chart1.Invalidate();
		}

		private void TemplateSampleControl_Load(object sender, System.EventArgs e)
		{
			// Set current selection
			comboBoxNumberOfDays.SelectedIndex = 1;
			comboBoxPointsFilter.SelectedIndex = 0;
			comboBoxShowAsIndexed.SelectedIndex = 0;

			// Fill chart data
			FillData();

			// Set settings
			UpdateChartSettings();

			// Create strip lines on the weekends
			StripLine stripLine = new StripLine();
			stripLine.BackColor = Color.FromArgb(120, Color.Gray);
			stripLine.IntervalOffset = -1.5;
			stripLine.IntervalOffsetType = DateTimeIntervalType.Days; 
			stripLine.Interval = 1;
			stripLine.IntervalType = DateTimeIntervalType.Weeks; 
			stripLine.StripWidth = 2;
			stripLine.StripWidthType =  DateTimeIntervalType.Days; 
			chart1.ChartAreas["Default"].AxisX.StripLines.Add(stripLine);

		}

		private void comboBoxShowAsIndexed_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateChartSettings();
		}

		private void comboBoxNumberOfDays_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Fill chart data
			FillData();		
			UpdateChartSettings();
		}
	}
}
