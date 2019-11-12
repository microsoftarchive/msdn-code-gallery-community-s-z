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
	/// Summary description for PriceIndicators.
	/// </summary>
	public class PriceIndicators : System.Windows.Forms.UserControl
	{
		private	int	randomSeed = 0;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label labelSampleComment;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonRandomData;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxNumberOfDays;
		private System.Windows.Forms.CheckBox checkBoxWeightedClose;
		private System.Windows.Forms.CheckBox checkBoxMedianPrice;
		private System.Windows.Forms.CheckBox checkBoxTypicalPrice;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PriceIndicators()
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
            this.buttonRandomData = new System.Windows.Forms.Button();
            this.comboBoxNumberOfDays = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxWeightedClose = new System.Windows.Forms.CheckBox();
            this.checkBoxMedianPrice = new System.Windows.Forms.CheckBox();
            this.checkBoxTypicalPrice = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
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
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.DockedToChartArea = "Default";
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(16, 56);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Stock;
            series1.Legend = "Default";
            series1.Name = "Input";
            series1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series1.ShadowOffset = 1;
            series1.YValuesPerPoint = 4;
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
            this.labelSampleComment.Text = "This sample displays various price indicators, which provide technical analysis o" +
                "n daily market prices that have open and close values.  ";
            this.labelSampleComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRandomData);
            this.panel1.Controls.Add(this.comboBoxNumberOfDays);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBoxWeightedClose);
            this.panel1.Controls.Add(this.checkBoxMedianPrice);
            this.panel1.Controls.Add(this.checkBoxTypicalPrice);
            this.panel1.Location = new System.Drawing.Point(432, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 288);
            this.panel1.TabIndex = 2;
            // 
            // buttonRandomData
            // 
            this.buttonRandomData.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRandomData.Location = new System.Drawing.Point(72, 136);
            this.buttonRandomData.Name = "buttonRandomData";
            this.buttonRandomData.Size = new System.Drawing.Size(168, 26);
            this.buttonRandomData.TabIndex = 5;
            this.buttonRandomData.Text = "Generate Random Data";
            this.buttonRandomData.UseVisualStyleBackColor = false;
            this.buttonRandomData.Click += new System.EventHandler(this.buttonRandomData_Click);
            // 
            // comboBoxNumberOfDays
            // 
            this.comboBoxNumberOfDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumberOfDays.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.comboBoxNumberOfDays.Location = new System.Drawing.Point(168, 104);
            this.comboBoxNumberOfDays.Name = "comboBoxNumberOfDays";
            this.comboBoxNumberOfDays.Size = new System.Drawing.Size(112, 22);
            this.comboBoxNumberOfDays.TabIndex = 4;
            this.comboBoxNumberOfDays.SelectedIndexChanged += new System.EventHandler(this.comboBoxNumberOfDays_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of &days:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxWeightedClose
            // 
            this.checkBoxWeightedClose.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxWeightedClose.Checked = true;
            this.checkBoxWeightedClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWeightedClose.Location = new System.Drawing.Point(13, 72);
            this.checkBoxWeightedClose.Name = "checkBoxWeightedClose";
            this.checkBoxWeightedClose.Size = new System.Drawing.Size(168, 24);
            this.checkBoxWeightedClose.TabIndex = 2;
            this.checkBoxWeightedClose.Text = "&Weighted Close:";
            this.checkBoxWeightedClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxWeightedClose.CheckStateChanged += new System.EventHandler(this.checkBoxWeightedClose_CheckStateChanged);
            // 
            // checkBoxMedianPrice
            // 
            this.checkBoxMedianPrice.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxMedianPrice.Checked = true;
            this.checkBoxMedianPrice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMedianPrice.Location = new System.Drawing.Point(13, 40);
            this.checkBoxMedianPrice.Name = "checkBoxMedianPrice";
            this.checkBoxMedianPrice.Size = new System.Drawing.Size(168, 24);
            this.checkBoxMedianPrice.TabIndex = 1;
            this.checkBoxMedianPrice.Text = "&Median Price:";
            this.checkBoxMedianPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxMedianPrice.CheckStateChanged += new System.EventHandler(this.checkBoxWeightedClose_CheckStateChanged);
            // 
            // checkBoxTypicalPrice
            // 
            this.checkBoxTypicalPrice.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxTypicalPrice.Checked = true;
            this.checkBoxTypicalPrice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTypicalPrice.Location = new System.Drawing.Point(13, 8);
            this.checkBoxTypicalPrice.Name = "checkBoxTypicalPrice";
            this.checkBoxTypicalPrice.Size = new System.Drawing.Size(168, 24);
            this.checkBoxTypicalPrice.TabIndex = 0;
            this.checkBoxTypicalPrice.Text = "&Typical Price:";
            this.checkBoxTypicalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxTypicalPrice.CheckStateChanged += new System.EventHandler(this.checkBoxWeightedClose_CheckStateChanged);
            // 
            // PriceIndicators
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSampleComment);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Name = "PriceIndicators";
            this.Size = new System.Drawing.Size(728, 480);
            this.Load += new System.EventHandler(this.TemplateSampleControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void TemplateSampleControl_Load(object sender, System.EventArgs e)
		{
			comboBoxNumberOfDays.SelectedIndex = 1;

			// Set random data
			Data( chart1.Series["Input"] );

			SetChartSettings();
		}

		private void checkBoxWeightedClose_CheckStateChanged(object sender, System.EventArgs e)
		{
			SetChartSettings();
		}

		private void comboBoxNumberOfDays_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Random rand = new Random(randomSeed);
			randomSeed = rand.Next();

			// Set random data
			Data( chart1.Series["Input"] );

			SetChartSettings();
		}

		private void buttonRandomData_Click(object sender, System.EventArgs e)
		{
			Random rand = new Random(randomSeed);
			randomSeed = rand.Next();

			// Set random data
			Data( chart1.Series["Input"] );
		
			SetChartSettings();
		}

		/// <summary>
		/// This method calculates Price indicators if 
		/// corresponding check box is selected.
		/// </summary>
		private void SetChartSettings()
		{
			// Calculates Typical Price
			if(checkBoxTypicalPrice.Checked)
			{
				chart1.DataManipulator.FinancialFormula(FinancialFormula.TypicalPrice,"Input:Y,Input:Y2,Input:Y3","Typical");
				chart1.Series["Typical"].ChartArea = "Default";
				chart1.Series["Typical"].Color = Color.FromArgb(252,180,65);
				chart1.Series["Typical"].ChartType = SeriesChartType.Line;
				chart1.Series["Typical"].ShadowOffset = 1;
			}
			else
			{
				chart1.Series["Typical"].ChartArea = "";
			}

			// Calculates Median Price
			if(checkBoxMedianPrice.Checked)
			{
				chart1.DataManipulator.FinancialFormula(FinancialFormula.MedianPrice,"Input:Y,Input:Y2","Median");
				chart1.Series["Median"].ChartArea = "Default";
				chart1.Series["Median"].Color = Color.FromArgb(224,64,10);
				chart1.Series["Median"].ChartType = SeriesChartType.Line;
				chart1.Series["Median"].ShadowOffset = 1;
			}
			else
			{
				chart1.Series["Median"].ChartArea = "";
			}

			// Calculates Weighted Close Price
			if(checkBoxWeightedClose.Checked)
			{
				chart1.DataManipulator.FinancialFormula(FinancialFormula.WeightedClose,"Input:Y,Input:Y2,Input:Y3","Weighted");
				chart1.Series["Weighted"].ChartArea = "Default";
				chart1.Series["Weighted"].Color = Color.FromArgb(5,100,146);
				chart1.Series["Weighted"].ChartType = SeriesChartType.Line;
				chart1.Series["Weighted"].ShadowOffset = 1;
			}
			else
			{
				chart1.Series["Weighted"].ChartArea = "";
			}
			
		}

		/// <summary>
		/// Random Stock Data Generator
		/// </summary>
		/// <param name="series">Data series</param>
		private void Data( Series series )
		{
			Random rand;
			// Use a number to calculate a starting value for 
			// the pseudo-random number sequence
			rand = new Random(randomSeed);
			
			// The number of days for stock data
			int period = int.Parse( comboBoxNumberOfDays.Text );

			chart1.Series["Input"].Points.Clear();

			// The first High value
			double high = rand.NextDouble() * 40;

			// The first Close value
			double close = high - rand.NextDouble();

			// The first Low value
			double low = close - rand.NextDouble();

			// The first Open value
			double open = ( high - low ) * rand.NextDouble() + low;
						
			// The first day X and Y values
			chart1.Series["Input"].Points.AddXY(DateTime.Parse("1/1/2002"), high);
			chart1.Series["Input"].Points[0].YValues[1] = low;

			// The Open value is not used.
			chart1.Series["Input"].Points[0].YValues[2] = open;
			chart1.Series["Input"].Points[0].YValues[3] = close;
			
			// Days loop
			for( int day = 1; day < period; day++ )
			{
			
				// Calculate High, Low and Close values
				high = chart1.Series["Input"].Points[day-1].YValues[2]+rand.NextDouble();
				close = high - rand.NextDouble();
				low = close - rand.NextDouble();
				open = ( high - low ) * rand.NextDouble() + low;
				
				// The low cannot be less than yesterday close value.
				if( low > chart1.Series["Input"].Points[day-1].YValues[2])
					low = chart1.Series["Input"].Points[day-1].YValues[2];
							
				// Set data points values
				chart1.Series["Input"].Points.AddXY(day, high);
				chart1.Series["Input"].Points[day].XValue = chart1.Series["Input"].Points[day-1].XValue+1;
				chart1.Series["Input"].Points[day].YValues[1] = low;
				chart1.Series["Input"].Points[day].YValues[2] = open;
				chart1.Series["Input"].Points[day].YValues[3] = close;
			}

			chart1.Invalidate();
		}


	}
}
