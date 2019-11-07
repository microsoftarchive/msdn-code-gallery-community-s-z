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
	/// Summary description for SpikeRemoval.
	/// </summary>
	public class SpikeRemoval : System.Windows.Forms.UserControl
    {
        # region Fields
        private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataVisualization.Charting.Chart Chart1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private NumericUpDown nUD_Tolerance;
        private NumericUpDown nUD_range;
        private ComboBox MarkerStyle;
        private CheckBox chk_ShowCutPointLabels;
        private Button buttonRandomData;
        #endregion
        private Label label2;

        # region Constructor
        /// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public SpikeRemoval()
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

        #endregion

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
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRandomData = new System.Windows.Forms.Button();
            this.chk_ShowCutPointLabels = new System.Windows.Forms.CheckBox();
            this.nUD_Tolerance = new System.Windows.Forms.NumericUpDown();
            this.nUD_range = new System.Windows.Forms.NumericUpDown();
            this.MarkerStyle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Tolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_range)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Verdana", 11F);
            this.label9.Location = new System.Drawing.Point(16, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(712, 34);
            this.label9.TabIndex = 0;
            this.label9.Text = "This sample demonstrates how to remove data spikes.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRandomData);
            this.panel1.Controls.Add(this.chk_ShowCutPointLabels);
            this.panel1.Controls.Add(this.nUD_Tolerance);
            this.panel1.Controls.Add(this.nUD_range);
            this.panel1.Controls.Add(this.MarkerStyle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(432, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 288);
            this.panel1.TabIndex = 19;
            // 
            // buttonRandomData
            // 
            this.buttonRandomData.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRandomData.Location = new System.Drawing.Point(62, 149);
            this.buttonRandomData.Name = "buttonRandomData";
            this.buttonRandomData.Size = new System.Drawing.Size(224, 24);
            this.buttonRandomData.TabIndex = 5;
            this.buttonRandomData.Text = "&Generate Random Data";
            this.buttonRandomData.UseVisualStyleBackColor = false;
            this.buttonRandomData.Click += new System.EventHandler(this.buttonRandomData_Click);
            // 
            // chk_ShowCutPointLabels
            // 
            this.chk_ShowCutPointLabels.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_ShowCutPointLabels.Checked = true;
            this.chk_ShowCutPointLabels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ShowCutPointLabels.Location = new System.Drawing.Point(3, 108);
            this.chk_ShowCutPointLabels.Name = "chk_ShowCutPointLabels";
            this.chk_ShowCutPointLabels.Size = new System.Drawing.Size(184, 24);
            this.chk_ShowCutPointLabels.TabIndex = 4;
            this.chk_ShowCutPointLabels.Text = "&Show Cut Point Labels:";
            this.chk_ShowCutPointLabels.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_ShowCutPointLabels.CheckedChanged += new System.EventHandler(this.chk_ShowCutPointLabels_CheckedChanged);
            // 
            // nUD_Tolerance
            // 
            this.nUD_Tolerance.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUD_Tolerance.Location = new System.Drawing.Point(172, 46);
            this.nUD_Tolerance.Name = "nUD_Tolerance";
            this.nUD_Tolerance.Size = new System.Drawing.Size(58, 22);
            this.nUD_Tolerance.TabIndex = 2;
            this.nUD_Tolerance.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUD_Tolerance.ValueChanged += new System.EventHandler(this.nUD_Tolerance_ValueChanged);
            // 
            // nUD_range
            // 
            this.nUD_range.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUD_range.Location = new System.Drawing.Point(172, 13);
            this.nUD_range.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_range.Name = "nUD_range";
            this.nUD_range.Size = new System.Drawing.Size(58, 22);
            this.nUD_range.TabIndex = 1;
            this.nUD_range.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nUD_range.ValueChanged += new System.EventHandler(this.nUD_range_ValueChanged);
            // 
            // MarkerStyle
            // 
            this.MarkerStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MarkerStyle.Location = new System.Drawing.Point(172, 78);
            this.MarkerStyle.Name = "MarkerStyle";
            this.MarkerStyle.Size = new System.Drawing.Size(115, 22);
            this.MarkerStyle.TabIndex = 3;
            this.MarkerStyle.SelectedIndexChanged += new System.EventHandler(this.MarkerStyle_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "&Marker Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(24, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "&Tolerance:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(15, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "&Range:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(64, 403);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Border Size:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(64, 380);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Border Color:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(64, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hatch Style:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(64, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gradient:";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(64, 426);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 23);
            this.label15.TabIndex = 5;
            this.label15.Text = "Border Size:";
            // 
            // Chart1
            // 
            this.Chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(223)))), ((int)(((byte)(193)))));
            this.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.Chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(64)))), ((int)(((byte)(1)))));
            this.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.Chart1.BorderlineWidth = 2;
            this.Chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.AlignWithChartArea = "Default";
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX2.IsLabelAutoFit = false;
            chartArea1.AxisX2.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 8;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY2.IsLabelAutoFit = false;
            chartArea1.AxisY2.LabelStyle.Enabled = false;
            chartArea1.AxisY2.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY2.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.Title = "Original Data";
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "Chart Area 2";
            chartArea2.Area3DStyle.Inclination = 15;
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.Area3DStyle.IsRightAngleAxes = false;
            chartArea2.Area3DStyle.Perspective = 10;
            chartArea2.Area3DStyle.Rotation = 10;
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY.LabelAutoFitMinFontSize = 8;
            chartArea2.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisY2.LabelStyle.Enabled = false;
            chartArea2.AxisY2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY2.MajorGrid.Enabled = false;
            chartArea2.AxisY2.MajorTickMark.Enabled = false;
            chartArea2.AxisY2.Title = "Spike Removed";
            chartArea2.AxisY2.TitleFont = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.BackColor = System.Drawing.Color.OldLace;
            chartArea2.BackSecondaryColor = System.Drawing.Color.White;
            chartArea2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "Default";
            chartArea2.ShadowColor = System.Drawing.Color.Transparent;
            this.Chart1.ChartAreas.Add(chartArea1);
            this.Chart1.ChartAreas.Add(chartArea2);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.DockedToChartArea = "Default";
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            this.Chart1.Legends.Add(legend1);
            this.Chart1.Location = new System.Drawing.Point(16, 56);
            this.Chart1.Name = "Chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "Chart Area 2";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.Legend = "Default";
            series1.Name = "InputSeries";
            series1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series1.ShadowOffset = 2;
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series2.BorderWidth = 3;
            series2.ChartArea = "Default";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Default";
            series2.Name = "OutputSeries";
            series2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series2.ShadowOffset = 1;
            series2.YValuesPerPoint = 4;
            this.Chart1.Series.Add(series1);
            this.Chart1.Series.Add(series2);
            this.Chart1.Size = new System.Drawing.Size(412, 296);
            this.Chart1.TabIndex = 0;
            title1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            title1.Name = "Title1";
            title1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title1.ShadowOffset = 3;
            title1.Text = "Using Multiple Y Values";
            title1.Visible = false;
            this.Chart1.Titles.Add(title1);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Verdana", 11F);
            this.label2.Location = new System.Drawing.Point(16, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(712, 34);
            this.label2.TabIndex = 20;
            this.label2.Text = "You can find the source code for spike removal in %SampleHome%\\Utilities\\SpikeRem" +
                "oval.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SpikeRemoval
            // 
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Chart1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Name = "SpikeRemoval";
            this.Size = new System.Drawing.Size(738, 448);
            this.Load += new System.EventHandler(this.SpikeRemoval_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Tolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_range)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        # region Private Methods

        /// <summary>
        /// Generates the data.
        /// </summary>
        private void GenerateData(Series inputSeries)
        {
            Random random = new Random();
            int count = 0;

            // Clear points
            inputSeries.Points.Clear();

            // Fill data
            for (int i = 0; i < 30; i++)
            {
                // only add 2 or less spikes
                if (count < 2)
                {
                    // Add a spike if random dictates it.
                    if (random.Next(0, 10) == 5)
                    {
                        count++;
                        inputSeries.Points.AddY(random.Next(-200, 200));
                    }
                    else
                        inputSeries.Points.AddY(random.Next(1, 5));
                }

                else
                    inputSeries.Points.AddY(random.Next(1, 5));
            }

            this.Chart1.Invalidate();
        }

        private void RemoveSpikes(Series spikedSeries)
        {
            System.Windows.Forms.DataVisualization.Charting.Utilities.SpikeRemoval spikeRemover = new System.Windows.Forms.DataVisualization.Charting.Utilities.SpikeRemoval();
            
            // Clear all points
            spikedSeries.Points.Clear();

            // Add points
            for (int i = 0; i < Chart1.Series["InputSeries"].Points.Count; i++)
                spikedSeries.Points.Add(Chart1.Series["InputSeries"].Points[i].Clone());

            // Declare variables for spike removal
            int range = (int)this.nUD_range.Value;
            int tolerance = (int)this.nUD_Tolerance.Value;

            // Set labels to show or hide for spike removal
            spikeRemover.SetCutoffLabels = this.chk_ShowCutPointLabels.Checked;

            // Set marker style of spike removal
            spikeRemover.RemovedPointStyle = (MarkerStyle)Enum.Parse(typeof(MarkerStyle), MarkerStyle.SelectedItem.ToString());

            // Set marker size of spike removal
            spikeRemover.RemovedPointSize = 10;
            
            // Remove all spikes
            spikeRemover.RemoveSpikes(spikedSeries, range, tolerance);
        }

        #endregion

        # region Event Handlers

        private void SpikeRemoval_Load(object sender, EventArgs e)
        {
            // Generate input data
            GenerateData(this.Chart1.Series["InputSeries"]);

            // Add markers
            foreach (string name in Enum.GetNames(typeof(MarkerStyle)))
            {
                this.MarkerStyle.Items.Add(name);
            }

            this.MarkerStyle.SelectedIndex = 3;

            // Remove spikes
            RemoveSpikes(this.Chart1.Series["OutputSeries"]);
        }

        private void buttonRandomData_Click(object sender, EventArgs e)
        {
            // Generate input data
            GenerateData(this.Chart1.Series["InputSeries"]);

            // Remove spikes
            RemoveSpikes(this.Chart1.Series["OutputSeries"]);
        }

        private void nUD_range_ValueChanged(object sender, EventArgs e)
        {
            RemoveSpikes(this.Chart1.Series["OutputSeries"]);
            this.Chart1.Invalidate();
        }

        private void nUD_Tolerance_ValueChanged(object sender, EventArgs e)
        {
            RemoveSpikes(this.Chart1.Series["OutputSeries"]); 
            this.Chart1.Invalidate();
        }

        private void MarkerStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveSpikes(this.Chart1.Series["OutputSeries"]);
            this.Chart1.Invalidate();
        }

        private void chk_ShowCutPointLabels_CheckedChanged(object sender, EventArgs e)
        {
            RemoveSpikes(this.Chart1.Series["OutputSeries"]);
            this.Chart1.Invalidate();
        }

        #endregion
    }
}
