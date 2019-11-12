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
	/// Summary description for FindByValue.
	/// </summary>
	public class FindByValue : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label labelSampleComment;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxValueToFind;
		private System.Windows.Forms.ComboBox comboBoxPointValueToLookFor;
		private System.Windows.Forms.Button buttonRandomData;
		private System.Windows.Forms.Label label2;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FindByValue()
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
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem1 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindByValue));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelSampleComment = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRandomData = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxValueToFind = new System.Windows.Forms.ComboBox();
            this.comboBoxPointValueToLookFor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.PointGapDepth = 0;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LabelStyle.Interval = 2;
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.Maximum = 20;
            chartArea1.AxisX.Minimum = 0;
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.Maximum = 20;
            chartArea1.AxisY.Minimum = 0;
            chartArea1.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legendItem1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            legendItem1.ImageStyle = System.Windows.Forms.DataVisualization.Charting.LegendImageStyle.Marker;
            legendItem1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            legendItem1.Name = "Found Points";
            legendItem1.ShadowOffset = 2;
            legend1.CustomItems.Add(legendItem1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Default";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(16, 68);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.CustomProperties = "BubbleMaxSize=10";
            series1.Legend = "Default";
            series1.Name = "Series1";
            series1.ShadowOffset = 2;
            series1.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(412, 296);
            this.chart1.TabIndex = 1;
            // 
            // labelSampleComment
            // 
            this.labelSampleComment.Font = new System.Drawing.Font("Verdana", 11F);
            this.labelSampleComment.Location = new System.Drawing.Point(16, 0);
            this.labelSampleComment.Name = "labelSampleComment";
            this.labelSampleComment.Size = new System.Drawing.Size(702, 61);
            this.labelSampleComment.TabIndex = 0;
            this.labelSampleComment.Text = resources.GetString("labelSampleComment.Text");
            this.labelSampleComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRandomData);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBoxValueToFind);
            this.panel1.Controls.Add(this.comboBoxPointValueToLookFor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(432, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 288);
            this.panel1.TabIndex = 2;
            // 
            // buttonRandomData
            // 
            this.buttonRandomData.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRandomData.Location = new System.Drawing.Point(48, 72);
            this.buttonRandomData.Name = "buttonRandomData";
            this.buttonRandomData.Size = new System.Drawing.Size(208, 24);
            this.buttonRandomData.TabIndex = 4;
            this.buttonRandomData.Text = "Generate Random Data";
            this.buttonRandomData.UseVisualStyleBackColor = false;
            this.buttonRandomData.Click += new System.EventHandler(this.buttonRandomData_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Value to &Find:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxValueToFind
            // 
            this.comboBoxValueToFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxValueToFind.Items.AddRange(new object[] {
            "Min",
            "Max",
            "4",
            "8",
            "12",
            "16"});
            this.comboBoxValueToFind.Location = new System.Drawing.Point(168, 40);
            this.comboBoxValueToFind.Name = "comboBoxValueToFind";
            this.comboBoxValueToFind.Size = new System.Drawing.Size(122, 22);
            this.comboBoxValueToFind.TabIndex = 3;
            this.comboBoxValueToFind.SelectedIndexChanged += new System.EventHandler(this.comboBoxValueToFind_SelectedIndexChanged);
            // 
            // comboBoxPointValueToLookFor
            // 
            this.comboBoxPointValueToLookFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPointValueToLookFor.Items.AddRange(new object[] {
            "First Y Value",
            "Second Y Value (Bubble Size)",
            "X value"});
            this.comboBoxPointValueToLookFor.Location = new System.Drawing.Point(168, 8);
            this.comboBoxPointValueToLookFor.Name = "comboBoxPointValueToLookFor";
            this.comboBoxPointValueToLookFor.Size = new System.Drawing.Size(188, 22);
            this.comboBoxPointValueToLookFor.TabIndex = 1;
            this.comboBoxPointValueToLookFor.SelectedIndexChanged += new System.EventHandler(this.comboBoxValueToFind_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Point Value to &Examine:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 11F);
            this.label2.Location = new System.Drawing.Point(16, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(709, 64);
            this.label2.TabIndex = 3;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FindByValue
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSampleComment);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Name = "FindByValue";
            this.Size = new System.Drawing.Size(728, 480);
            this.Load += new System.EventHandler(this.TemplateSampleControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void UpdateChartSettings()
		{
			// Get which point value to use
			string	pointValueName = "Y";
			if(comboBoxPointValueToLookFor.Text == "Second Y Value (Bubble Size)")
			{
				pointValueName = "Y2";
			}
			else if(comboBoxPointValueToLookFor.Text == "X value")
			{
				pointValueName = "X";
			}

			// Clear all points color
			foreach(DataPoint point in chart1.Series["Series1"].Points)
			{
				point.Color = Color.Empty;
			}

			// Find all point with specified value and change their color
            Double valueToFind = 0;

            if(comboBoxValueToFind.Text == "Min")
			{
				// Find minimum
                DataPoint minPoint = chart1.Series["Series1"].Points.FindMinByValue(pointValueName);
                valueToFind = minPoint.GetValueByName(pointValueName);
    		}
			else if(comboBoxValueToFind.Text == "Max")
			{
                // Find maximum
                DataPoint maxPoint = chart1.Series["Series1"].Points.FindMaxByValue(pointValueName);
                valueToFind = maxPoint.GetValueByName(pointValueName);
            }
			else									
			{
				// Find by value
				valueToFind = double.Parse(comboBoxValueToFind.Text);
			}
            
            //Color all the points with the specified value
            foreach (DataPoint dataPoint in chart1.Series["Series1"].Points.FindAllByValue(valueToFind, pointValueName))
            {
                dataPoint.Color = Color.FromArgb(194, 224, 64, 10);
            }
        }

		public void FillData()
		{
			// Populate series data
			Random random = new Random();
			chart1.Series["Series1"].Points.Clear();
			for(int pointIndex = 0; pointIndex < 100; pointIndex++)
			{
				chart1.Series["Series1"].Points.AddXY(random.Next(1, 19), random.Next(1, 19), random.Next(1, 19));
			}
			chart1.Invalidate();
		}

		private void TemplateSampleControl_Load(object sender, System.EventArgs e)
		{
			FillData();

			// Set current selection
			comboBoxValueToFind.SelectedIndex = 0;
			comboBoxPointValueToLookFor.SelectedIndex = 0;
		}

		private void buttonRandomData_Click(object sender, System.EventArgs e)
		{
			FillData();		
			UpdateChartSettings();
		}

		private void comboBoxValueToFind_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateChartSettings();		
		}

	}
}
