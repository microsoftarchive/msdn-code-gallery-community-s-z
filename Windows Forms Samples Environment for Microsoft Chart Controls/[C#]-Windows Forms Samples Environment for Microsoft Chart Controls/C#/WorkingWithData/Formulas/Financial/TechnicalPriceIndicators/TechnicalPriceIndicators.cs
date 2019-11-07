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
	/// Summary description for TechnicalPriceIndicators.
	/// </summary>
	public class TechnicalPriceIndicators : System.Windows.Forms.UserControl
	{
		private	int		randSeed = 0;
		private	bool	doCalculations = false;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label labelSampleComment;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox comboBoxPeriod;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonRandomData;
		private System.Windows.Forms.ComboBox comboBoxFormulaName;
		private System.Windows.Forms.Label label1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TechnicalPriceIndicators()
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
            this.comboBoxPeriod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRandomData = new System.Windows.Forms.Button();
            this.comboBoxFormulaName = new System.Windows.Forms.ComboBox();
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
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LabelStyle.IsEndLabelVisible = false;
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 96.45609F;
            chartArea1.InnerPlotPosition.Width = 85.8878F;
            chartArea1.InnerPlotPosition.X = 8.242199F;
            chartArea1.Name = "Default";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 40F;
            chartArea1.Position.Width = 89.43796F;
            chartArea1.Position.X = 4.824818F;
            chartArea1.Position.Y = 7F;
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
            chartArea2.AxisX.LabelStyle.Format = "MMM dd";
            chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.LabelStyle.IsEndLabelVisible = false;
            chartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.BackSecondaryColor = System.Drawing.Color.White;
            chartArea2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 83.51225F;
            chartArea2.InnerPlotPosition.Width = 85.8878F;
            chartArea2.InnerPlotPosition.X = 8.242199F;
            chartArea2.Name = "Indicator";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 40F;
            chartArea2.Position.Width = 89.43796F;
            chartArea2.Position.X = 4.824818F;
            chartArea2.Position.Y = 46F;
            chartArea2.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.DockedToChartArea = "Indicator";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsDockedInsideChartArea = false;
            legend1.IsTextAutoFit = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Default";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(16, 48);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Stock;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.Legend = "Default";
            series1.Name = "Input";
            series1.YValuesPerPoint = 4;
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series2.ChartArea = "Indicator";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            series2.Legend = "Default";
            series2.MarkerStep = 10;
            series2.Name = "Indicators";
            series2.ShadowOffset = 1;
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(412, 296);
            this.chart1.TabIndex = 1;
            // 
            // labelSampleComment
            // 
            this.labelSampleComment.Font = new System.Drawing.Font("Verdana", 11F);
            this.labelSampleComment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelSampleComment.Location = new System.Drawing.Point(16, 8);
            this.labelSampleComment.Name = "labelSampleComment";
            this.labelSampleComment.Size = new System.Drawing.Size(702, 34);
            this.labelSampleComment.TabIndex = 0;
            this.labelSampleComment.Text = "This sample demonstrates the various technical price indicators.";
            this.labelSampleComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxPeriod);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonRandomData);
            this.panel1.Controls.Add(this.comboBoxFormulaName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(432, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 288);
            this.panel1.TabIndex = 2;
            // 
            // comboBoxPeriod
            // 
            this.comboBoxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPeriod.Items.AddRange(new object[] {
            "200",
            "150",
            "100",
            "75"});
            this.comboBoxPeriod.Location = new System.Drawing.Point(168, 8);
            this.comboBoxPeriod.Name = "comboBoxPeriod";
            this.comboBoxPeriod.Size = new System.Drawing.Size(122, 22);
            this.comboBoxPeriod.TabIndex = 1;
            this.comboBoxPeriod.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeriod_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(72, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "&Period:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonRandomData
            // 
            this.buttonRandomData.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRandomData.Location = new System.Drawing.Point(72, 96);
            this.buttonRandomData.Name = "buttonRandomData";
            this.buttonRandomData.Size = new System.Drawing.Size(216, 24);
            this.buttonRandomData.TabIndex = 4;
            this.buttonRandomData.Text = "&Generate Random Data";
            this.buttonRandomData.UseVisualStyleBackColor = false;
            this.buttonRandomData.Click += new System.EventHandler(this.buttonRandomData_Click);
            // 
            // comboBoxFormulaName
            // 
            this.comboBoxFormulaName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormulaName.Items.AddRange(new object[] {
            "AverageTrueRange",
            "CommodityChannelIndex",
            "DetrendedPriceOscillator",
            "MassIndex",
            "MovingAverageConvergenceDivergence",
            "Performance",
            "RateOfChange",
            "RelativeStrengthIndex",
            "StandardDeviation",
            "StochasticIndicator",
            "TripleExponentialMovingAverage",
            "VolatilityChaikins",
            "WilliamsR"});
            this.comboBoxFormulaName.Location = new System.Drawing.Point(72, 64);
            this.comboBoxFormulaName.Name = "comboBoxFormulaName";
            this.comboBoxFormulaName.Size = new System.Drawing.Size(216, 22);
            this.comboBoxFormulaName.TabIndex = 3;
            this.comboBoxFormulaName.SelectedIndexChanged += new System.EventHandler(this.comboBoxFormulaName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(48, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Formula Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TechnicalPriceIndicators
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSampleComment);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Name = "TechnicalPriceIndicators";
            this.Size = new System.Drawing.Size(728, 480);
            this.Load += new System.EventHandler(this.TemplateSampleControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// This method calculates a different indicator if corresponding 
		/// item in the combo box is selected.
		/// </summary>
		private void Calculations()
		{
			// Set defaults
			chart1.ChartAreas["Indicator"].AxisY.StripLines.Clear();
			chart1.ChartAreas["Indicator"].AxisY.Minimum = double.NaN;
			chart1.ChartAreas["Indicator"].AxisY.Maximum = double.NaN;
			try
			{
				chart1.Series["SMA"].ChartArea = "";
			}
			catch{}

			// Set Formula Name
			string formulaName = comboBoxFormulaName.Text;
			FinancialFormula formula = (FinancialFormula) Enum.Parse(typeof(FinancialFormula),formulaName,true);

			// Formulas with one input value
            if (formulaName == "DetrendedPriceOscillator" || formulaName == "MovingAverageConvergenceDivergence" || formulaName == "Performance" || formulaName == "RateOfChange"
                || formulaName == "TripleExponentialMovingAverage")
			{
				chart1.DataManipulator.FinancialFormula(formula,"10","Input:Y4","Indicators");
			}

				// Relative Strength Index
			else if( formulaName == "RelativeStrengthIndex" )
			{
				chart1.DataManipulator.FinancialFormula(formula,"10","Input:Y4","Indicators");

				// Set minimum and maximum for Y axis
				chart1.ChartAreas["Indicator"].AxisY.Minimum = 0;
				chart1.ChartAreas["Indicator"].AxisY.Maximum = 100;

				// Create strip lines used with Relative strength index.
				StripLine stripLine = new StripLine();
				chart1.ChartAreas["Indicator"].AxisY.StripLines.Add(stripLine);
				stripLine.Interval = 70;
				stripLine.StripWidth = 30;
				stripLine.BackColor = Color.FromArgb(64, 165, 191, 228);
				
			}
				// Williams %R
			else if( formulaName == "WilliamsR" )
			{
				chart1.DataManipulator.FinancialFormula(formula,"Input:Y,Input:Y2,Input:Y4","Indicators");

				// Set minimum and maximum for Y axis
				chart1.ChartAreas["Indicator"].AxisY.Minimum = -100;
				chart1.ChartAreas["Indicator"].AxisY.Maximum = 0;

				// Create strip lines used with Williams %R index.
				StripLine stripLine = new StripLine();
				chart1.ChartAreas["Indicator"].AxisY.StripLines.Add(stripLine);
				stripLine.Interval = 80;
				stripLine.StripWidth = 20;
				stripLine.BackColor = Color.FromArgb(64, 165, 191, 228);
			}
				// Formulas with two input value
			else if( formulaName == "MassIndex" || formulaName == "VolatilityChaikins" || formulaName == "Performance" )
			{
				chart1.DataManipulator.FinancialFormula(formula,"20","Input:Y,Input:Y2","Indicators");
			}
				// Standard deviation
			else if( formulaName == "StandardDeviation" )
			{
				chart1.DataManipulator.FinancialFormula(formula,"15","Input:Y4","Indicators");
			}
				// StochasticIndicator
			else if( formulaName == "StochasticIndicator" )
			{
				chart1.DataManipulator.FinancialFormula(formula,"15","Input:Y,Input:Y2,Input:Y4","Indicators,SMA");

				// Set attributes for Simple moving average series.
				chart1.Series["SMA"].ChartType = SeriesChartType.Line;
				chart1.Series["SMA"].Color = Color.FromArgb(252,180,65);
				chart1.Series["SMA"].ChartArea = "Indicator";
				chart1.Series["SMA"].BorderWidth = 2;
			}
				// All other formulas.
			else
			{
				chart1.DataManipulator.FinancialFormula(formula,"Input:Y,Input:Y2,Input:Y4","Indicators");
			}

			// Set minimum for X axis
			chart1.ChartAreas["Indicator"].AxisX.Minimum = DateTime.Parse("1/1/2002").ToOADate();

			chart1.Invalidate();
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
			rand = new Random(randSeed);
			
			// The number of days for stock data
			int period = int.Parse( comboBoxPeriod.Text );

			chart1.Series["Input"].Points.Clear();

			// The first High value
			double high = rand.NextDouble() * 40;

			// The first Close value
			double close = high - rand.NextDouble();

			// The first Low value
			double low = close - rand.NextDouble();

			// The first Open value
			double open = ( high - low ) * rand.NextDouble() + low;

			// The first Volume value
			double volume = 100 + 15 * rand.NextDouble();
						
			// The first day X and Y values
			chart1.Series["Input"].Points.AddXY(DateTime.Parse("1/2/2002"), high);
			chart1.Series["Input"].Points[0].YValues[1] = low;

			// The Open value is not used.
			chart1.Series["Input"].Points[0].YValues[2] = open;
			chart1.Series["Input"].Points[0].YValues[3] = close;
			
			// Days loop
			for( int day = 1; day <= period; day++ )
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

		private void TemplateSampleControl_Load(object sender, System.EventArgs e)
		{
			comboBoxPeriod.SelectedIndex = 1;
			comboBoxFormulaName.SelectedIndex = 0;
			doCalculations = true;

			// Set random data
			Data( chart1.Series["Input"] );

			// Initialize values.
			Calculations();
		}

		private void comboBoxFormulaName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(doCalculations)
			{
				// Initialize values.
				Calculations();
			}
		}

		private void comboBoxPeriod_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(doCalculations)
			{
				Random rand  = new Random();
				randSeed = rand.Next();
		
				// Set random data
				Data( chart1.Series["Input"] );

				// Initialize values.
				Calculations();
			}
		}

		private void buttonRandomData_Click(object sender, System.EventArgs e)
		{
			Random rand  = new Random();
			randSeed = rand.Next();
		
			// Set random data
			Data( chart1.Series["Input"] );

			// Initialize values.
			Calculations();
		}
	}
}
