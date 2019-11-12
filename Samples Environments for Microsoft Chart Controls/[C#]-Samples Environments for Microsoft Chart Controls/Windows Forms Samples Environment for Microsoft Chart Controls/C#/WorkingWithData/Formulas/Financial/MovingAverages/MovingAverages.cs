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
	/// Summary description for MovingAverages.
	/// </summary>
	public class MovingAverages : System.Windows.Forms.UserControl
	{
		private	int		randomSeed = 0;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label labelSampleComment;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBoxStartFromFirst;
		private System.Windows.Forms.CheckBox checkBoxFilterHistoricalData;
		private System.Windows.Forms.Button buttonRandomData;
		private System.Windows.Forms.ComboBox comboBoxPeriod;
		private System.Windows.Forms.Label label3;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MovingAverages()
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
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell1 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell2 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell3 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem2 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell4 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell5 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell6 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem3 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell7 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell8 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell9 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem4 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell10 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell11 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell12 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem5 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell13 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell14 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.LegendCell legendCell15 = new System.Windows.Forms.DataVisualization.Charting.LegendCell();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelSampleComment = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRandomData = new System.Windows.Forms.Button();
            this.checkBoxFilterHistoricalData = new System.Windows.Forms.CheckBox();
            this.checkBoxStartFromFirst = new System.Windows.Forms.CheckBox();
            this.comboBoxPeriod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.BackColor = System.Drawing.Color.OldLace;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            legendItem1.BorderWidth = 2;
            legendCell1.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.Image;
            legendCell1.Name = "Cell1";
            legendCell2.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.SeriesSymbol;
            legendCell2.Name = "Cell2";
            legendCell3.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            legendCell3.Name = "Cell3";
            legendCell3.Text = "Input";
            legendItem1.Cells.Add(legendCell1);
            legendItem1.Cells.Add(legendCell2);
            legendItem1.Cells.Add(legendCell3);
            legendItem1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            legendItem1.ImageStyle = System.Windows.Forms.DataVisualization.Charting.LegendImageStyle.Line;
            legendItem1.MarkerSize = 10;
            legendItem1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            legendItem1.Name = "Input";
            legendItem2.BorderWidth = 2;
            legendCell4.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.Image;
            legendCell4.Name = "Cell1";
            legendCell5.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.SeriesSymbol;
            legendCell5.Name = "Cell2";
            legendCell6.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            legendCell6.Name = "Cell3";
            legendCell6.Text = "Simple";
            legendItem2.Cells.Add(legendCell4);
            legendItem2.Cells.Add(legendCell5);
            legendItem2.Cells.Add(legendCell6);
            legendItem2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            legendItem2.ImageStyle = System.Windows.Forms.DataVisualization.Charting.LegendImageStyle.Line;
            legendItem2.MarkerSize = 10;
            legendItem2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            legendItem2.Name = "Simple";
            legendItem3.BorderWidth = 2;
            legendCell7.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.Image;
            legendCell7.Name = "Cell1";
            legendCell8.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.SeriesSymbol;
            legendCell8.Name = "Cell2";
            legendCell9.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            legendCell9.Name = "Cell3";
            legendCell9.Text = "Exponential";
            legendItem3.Cells.Add(legendCell7);
            legendItem3.Cells.Add(legendCell8);
            legendItem3.Cells.Add(legendCell9);
            legendItem3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            legendItem3.ImageStyle = System.Windows.Forms.DataVisualization.Charting.LegendImageStyle.Line;
            legendItem3.MarkerSize = 10;
            legendItem3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            legendItem3.Name = "Exponential";
            legendItem4.BorderWidth = 2;
            legendCell10.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.Image;
            legendCell10.Name = "Cell1";
            legendCell11.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.SeriesSymbol;
            legendCell11.Name = "Cell2";
            legendCell12.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            legendCell12.Name = "Cell3";
            legendCell12.Text = "Triangular";
            legendItem4.Cells.Add(legendCell10);
            legendItem4.Cells.Add(legendCell11);
            legendItem4.Cells.Add(legendCell12);
            legendItem4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(100)))), ((int)(((byte)(146)))));
            legendItem4.ImageStyle = System.Windows.Forms.DataVisualization.Charting.LegendImageStyle.Line;
            legendItem4.MarkerSize = 10;
            legendItem4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            legendItem4.Name = "Triangular";
            legendItem5.BorderWidth = 2;
            legendCell13.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.Image;
            legendCell13.Name = "Cell1";
            legendCell14.CellType = System.Windows.Forms.DataVisualization.Charting.LegendCellType.SeriesSymbol;
            legendCell14.Name = "Cell2";
            legendCell15.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            legendCell15.Name = "Cell3";
            legendCell15.Text = "Weighted";
            legendItem5.Cells.Add(legendCell13);
            legendItem5.Cells.Add(legendCell14);
            legendItem5.Cells.Add(legendCell15);
            legendItem5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            legendItem5.ImageStyle = System.Windows.Forms.DataVisualization.Charting.LegendImageStyle.Line;
            legendItem5.MarkerSize = 10;
            legendItem5.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            legendItem5.Name = "Weighted";
            legend1.CustomItems.Add(legendItem1);
            legend1.CustomItems.Add(legendItem2);
            legend1.CustomItems.Add(legendItem3);
            legend1.CustomItems.Add(legendItem4);
            legend1.CustomItems.Add(legendItem5);
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8F, System.Drawing.FontStyle.Bold);
            legend1.HeaderSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.Line;
            legend1.HeaderSeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            legend1.IsTextAutoFit = false;
            legend1.ItemColumnSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.Line;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            legend1.Name = "Default";
            legend1.TitleFont = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            legend1.TitleSeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(16, 56);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.BorderWidth = 2;
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Default";
            series1.Name = "Input";
            series1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series1.ShadowOffset = 1;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(412, 296);
            this.chart1.TabIndex = 1;
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDown);
            // 
            // labelSampleComment
            // 
            this.labelSampleComment.Font = new System.Drawing.Font("Verdana", 11F);
            this.labelSampleComment.Location = new System.Drawing.Point(16, 8);
            this.labelSampleComment.Name = "labelSampleComment";
            this.labelSampleComment.Size = new System.Drawing.Size(702, 40);
            this.labelSampleComment.TabIndex = 0;
            this.labelSampleComment.Text = "This sample displays four different types of moving averages. The main difference" +
                " between these averages is how weights are applied to different portions of the " +
                "data.";
            this.labelSampleComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRandomData);
            this.panel1.Controls.Add(this.checkBoxFilterHistoricalData);
            this.panel1.Controls.Add(this.checkBoxStartFromFirst);
            this.panel1.Controls.Add(this.comboBoxPeriod);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(432, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 296);
            this.panel1.TabIndex = 2;
            // 
            // buttonRandomData
            // 
            this.buttonRandomData.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRandomData.Location = new System.Drawing.Point(48, 113);
            this.buttonRandomData.Name = "buttonRandomData";
            this.buttonRandomData.Size = new System.Drawing.Size(184, 28);
            this.buttonRandomData.TabIndex = 8;
            this.buttonRandomData.Text = "&Generate Random Data";
            this.buttonRandomData.UseVisualStyleBackColor = false;
            this.buttonRandomData.Click += new System.EventHandler(this.buttonRandomData_Click);
            // 
            // checkBoxFilterHistoricalData
            // 
            this.checkBoxFilterHistoricalData.Enabled = false;
            this.checkBoxFilterHistoricalData.Location = new System.Drawing.Point(48, 81);
            this.checkBoxFilterHistoricalData.Name = "checkBoxFilterHistoricalData";
            this.checkBoxFilterHistoricalData.Size = new System.Drawing.Size(224, 24);
            this.checkBoxFilterHistoricalData.TabIndex = 7;
            this.checkBoxFilterHistoricalData.Text = "Filter &Historical Data";
            this.checkBoxFilterHistoricalData.CheckStateChanged += new System.EventHandler(this.checkBoxFilterHistoricalData_CheckStateChanged);
            // 
            // checkBoxStartFromFirst
            // 
            this.checkBoxStartFromFirst.Checked = true;
            this.checkBoxStartFromFirst.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStartFromFirst.Location = new System.Drawing.Point(48, 49);
            this.checkBoxStartFromFirst.Name = "checkBoxStartFromFirst";
            this.checkBoxStartFromFirst.Size = new System.Drawing.Size(224, 24);
            this.checkBoxStartFromFirst.TabIndex = 6;
            this.checkBoxStartFromFirst.Text = "Start From &First";
            this.checkBoxStartFromFirst.CheckStateChanged += new System.EventHandler(this.checkBoxFilterHistoricalData_CheckStateChanged);
            // 
            // comboBoxPeriod
            // 
            this.comboBoxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPeriod.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20"});
            this.comboBoxPeriod.Location = new System.Drawing.Point(93, 17);
            this.comboBoxPeriod.Name = "comboBoxPeriod";
            this.comboBoxPeriod.Size = new System.Drawing.Size(123, 22);
            this.comboBoxPeriod.TabIndex = 5;
            this.comboBoxPeriod.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeriod_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(29, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "&Period:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 11F);
            this.label3.Location = new System.Drawing.Point(24, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(672, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Select or clear the appropriate legend item to enable or disable a moving average" +
                ".";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MovingAverages
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSampleComment);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Name = "MovingAverages";
            this.Size = new System.Drawing.Size(728, 480);
            this.Load += new System.EventHandler(this.TemplateSampleControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void TemplateSampleControl_Load(object sender, System.EventArgs e)
		{
			// Generate rundom data
			GenerateRandomData( chart1.Series["Input"] );

			// Set chart types for output data
			chart1.Series["Input"].ChartType = SeriesChartType.Line;

			// Set current selection
			comboBoxPeriod.SelectedIndex = 0;

			// Set all cells image transp color to red
			for (int i = 1; i < 5; i++) 
			{
				chart1.Legends["Default"].CustomItems[i].Cells[0].ImageTransparentColor = Color.Red;
			}

			System.Windows.Forms.DataVisualization.Charting.Utilities.SampleMain.MainForm mainForm = (System.Windows.Forms.DataVisualization.Charting.Utilities.SampleMain.MainForm)this.ParentForm;
			
			// Set image for all custom items
			chart1.Legends["Default"].CustomItems[1].Cells[0].Image = mainForm.CurrentSamplePath + @"\chk_checked.png";
			chart1.Legends["Default"].CustomItems[2].Cells[0].Image = mainForm.CurrentSamplePath + @"\chk_checked.png";
			chart1.Legends["Default"].CustomItems[3].Cells[0].Image = mainForm.CurrentSamplePath + @"\chk_checked.png";
			chart1.Legends["Default"].CustomItems[4].Cells[0].Image = mainForm.CurrentSamplePath + @"\chk_checked.png";

			// Set tag property for all custom items to appropriate series
			chart1.Legends["Default"].CustomItems[1].Tag = chart1.Series["Simple"];
			chart1.Legends["Default"].CustomItems[2].Tag = chart1.Series["Exponential"];
			chart1.Legends["Default"].CustomItems[3].Tag = chart1.Series["Triangular"];
			chart1.Legends["Default"].CustomItems[4].Tag = chart1.Series["Weighted"];			
		}

		# region Methods

		// Helper method for setting series appearance
		private void SetSeriesAppearance(string seriesName) 
		{
			chart1.Series[seriesName].ChartArea = "Default";
			chart1.Series[seriesName].ChartType = SeriesChartType.Line;
			chart1.Series[seriesName].BorderWidth = 2;
			chart1.Series[seriesName].ShadowOffset = 1;				
			chart1.Series[seriesName].IsVisibleInLegend = false;
		}

		/// <summary>
		/// This method calculates different Moving Averages.
		/// </summary>
		private void UpdateChart()
		{
			string period = comboBoxPeriod.Text;

			// Start from first property is true by default.
			chart1.DataManipulator.IsStartFromFirst = checkBoxStartFromFirst.Checked;

			// Calculates simple moving average			
			chart1.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage,period,"Input","Simple");
			SetSeriesAppearance("Simple");

			// Calculates exponential moving average	
			chart1.DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage,period,"Input","Exponential");
			SetSeriesAppearance("Exponential");
		
			// Calculates triangular moving average	
			chart1.DataManipulator.FinancialFormula(FinancialFormula.TriangularMovingAverage,period,"Input","Triangular");
			SetSeriesAppearance("Triangular");

			// Calculates weighted moving average	
			chart1.DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage,period,"Input","Weighted");
			SetSeriesAppearance("Weighted");

			
			// Remove historical data
			if( checkBoxFilterHistoricalData.Checked && !checkBoxStartFromFirst.Checked )
			{
				chart1.DataManipulator.Filter( CompareMethod.LessThanOrEqualTo, Double.Parse(period)-1.0, "Input", "Input", "X" );
                chart1.DataManipulator.Filter(CompareMethod.LessThanOrEqualTo, Double.Parse(period) - 1.0, "Triangular", "Triangular", "X");
			}

			chart1.Invalidate();
		}

		/// <summary>
		/// This method generates random data.
		/// </summary>
		/// <param name="series"></param>
		private void GenerateRandomData( Series series )
		{
			Random rand = new Random(randomSeed);

			// Generate 30 random y values.
			series.Points.Clear();
			for( int index = 0; index < 30; index++ )
			{
				// Generate the first point
				series.Points.AddXY(index+1,0);
				series.Points[index].YValues[0] = 10;

				// Use previous point to calculate a next one.
				if( index > 0 )
				{
					series.Points[index].YValues[0] = series.Points[index-1].YValues[0] + 4*rand.NextDouble() - 2;
				}
			}

			chart1.Invalidate();
		}
		#endregion

		# region UI Event Handlers
		private void checkBoxSimpleMovingAverage_CheckedChanged(object sender, System.EventArgs e)
		{
			// Calculate Moving Averages
			UpdateChart();
		}

		private void comboBoxPeriod_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Calculate Moving Averages
			UpdateChart();
		}

		private void buttonRandomData_Click(object sender, System.EventArgs e)
		{
			Random rand = new Random();
			randomSeed = rand.Next();

			// Generate rundom data
			GenerateRandomData( chart1.Series["Input"] );

			// Calculate Moving Averages
			UpdateChart();
		}

		private void checkBoxSimpleMovingAverage_CheckStateChanged(object sender, System.EventArgs e)
		{
			// Calculate Moving Averages
			UpdateChart();
		}

		private void checkBoxFilterHistoricalData_CheckStateChanged(object sender, System.EventArgs e)
		{
			checkBoxFilterHistoricalData.Enabled = !checkBoxStartFromFirst.Checked;

			// Generate rundom data
			GenerateRandomData( chart1.Series["Input"] );

			// Calculate Moving Averages
			UpdateChart();
		}

		private void chart1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			HitTestResult result = chart1.HitTest(e.X, e.Y);
			if(result != null && result.Object != null)
			{					
				// When user hits the LegendItem
				if (result.Object is LegendItem) 
				{
					// Legend item result
					LegendItem legendItem = (LegendItem)result.Object;
					
					// series item selected
					Series selectedSeries = (Series)legendItem.Tag;

					if (selectedSeries !=null) 
					{

                        System.Windows.Forms.DataVisualization.Charting.Utilities.SampleMain.MainForm mainForm = (System.Windows.Forms.DataVisualization.Charting.Utilities.SampleMain.MainForm)this.ParentForm;
			
						if (selectedSeries.Enabled) 
						{
							selectedSeries.Enabled = false;
							legendItem.Cells[0].Image = string.Format(mainForm.CurrentSamplePath + @"\chk_unchecked.png");
							legendItem.Cells[0].ImageTransparentColor = Color.Red;
						}

						else 
						{
							selectedSeries.Enabled = true;
							legendItem.Cells[0].Image = string.Format(mainForm.CurrentSamplePath + @"\chk_checked.png");
							legendItem.Cells[0].ImageTransparentColor = Color.Red;
						}
					}
				}
			}

			#endregion
		}
	}
}
