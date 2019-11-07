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
	/// Summary description for Forecasting.
	/// </summary>
	public class Forecasting : System.Windows.Forms.UserControl
	{
		private	bool	doCalculations = false;
		private	int		randSeed = 0;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label labelSampleComment;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox checkBoxForecastingError;
		private System.Windows.Forms.CheckBox checkBoxError;
		private System.Windows.Forms.ComboBox comboBoxForecasting;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxPeriod;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxOrder;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonRandomData;
		private System.Windows.Forms.ComboBox comboBoxRegressionType;
		private System.Windows.Forms.Label label1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Forecasting()
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelSampleComment = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxForecastingError = new System.Windows.Forms.CheckBox();
            this.checkBoxError = new System.Windows.Forms.CheckBox();
            this.comboBoxForecasting = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPeriod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxOrder = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRandomData = new System.Windows.Forms.Button();
            this.comboBoxRegressionType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
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
            chartArea1.AxisX.LabelStyle.Format = "dd MMM";
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
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsDockedInsideChartArea = false;
            legend1.IsTextAutoFit = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Default";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(16, 65);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.Legend = "Default";
            series1.Name = "Range";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValuesPerPoint = 2;
            series2.BorderWidth = 2;
            series2.ChartArea = "Default";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            series2.Legend = "Default";
            series2.Name = "Forecasting";
            series2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series2.ShadowOffset = 1;
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.BorderWidth = 2;
            series3.ChartArea = "Default";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            series3.Legend = "Default";
            series3.Name = "Input";
            series3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series3.ShadowOffset = 1;
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(412, 296);
            this.chart1.TabIndex = 1;
            // 
            // labelSampleComment
            // 
            this.labelSampleComment.Font = new System.Drawing.Font("Verdana", 11F);
            this.labelSampleComment.Location = new System.Drawing.Point(16, 14);
            this.labelSampleComment.Name = "labelSampleComment";
            this.labelSampleComment.Size = new System.Drawing.Size(702, 43);
            this.labelSampleComment.TabIndex = 0;
            this.labelSampleComment.Text = "This chart demonstrates the Forecasting formula and also displays upper and lower" +
                " errors as a Range chart.";
            this.labelSampleComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxForecastingError);
            this.panel1.Controls.Add(this.checkBoxError);
            this.panel1.Controls.Add(this.comboBoxForecasting);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxPeriod);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBoxOrder);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonRandomData);
            this.panel1.Controls.Add(this.comboBoxRegressionType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(432, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 288);
            this.panel1.TabIndex = 2;
            // 
            // checkBoxForecastingError
            // 
            this.checkBoxForecastingError.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxForecastingError.Location = new System.Drawing.Point(-9, 168);
            this.checkBoxForecastingError.Name = "checkBoxForecastingError";
            this.checkBoxForecastingError.Size = new System.Drawing.Size(192, 24);
            this.checkBoxForecastingError.TabIndex = 9;
            this.checkBoxForecastingError.Text = "Show Fore&casting Error:";
            this.checkBoxForecastingError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxForecastingError.CheckStateChanged += new System.EventHandler(this.checkBoxForecastingError_CheckStateChanged_1);
            // 
            // checkBoxError
            // 
            this.checkBoxError.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxError.Location = new System.Drawing.Point(47, 136);
            this.checkBoxError.Name = "checkBoxError";
            this.checkBoxError.Size = new System.Drawing.Size(136, 24);
            this.checkBoxError.TabIndex = 8;
            this.checkBoxError.Text = "Show &Error:";
            this.checkBoxError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxError.CheckStateChanged += new System.EventHandler(this.checkBoxForecastingError_CheckStateChanged_1);
            // 
            // comboBoxForecasting
            // 
            this.comboBoxForecasting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxForecasting.Items.AddRange(new object[] {
            "10",
            "20",
            "30"});
            this.comboBoxForecasting.Location = new System.Drawing.Point(169, 104);
            this.comboBoxForecasting.Name = "comboBoxForecasting";
            this.comboBoxForecasting.Size = new System.Drawing.Size(122, 22);
            this.comboBoxForecasting.TabIndex = 7;
            this.comboBoxForecasting.SelectedIndexChanged += new System.EventHandler(this.comboBoxForecasting_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(44, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "&Forecasting:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxPeriod
            // 
            this.comboBoxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPeriod.Items.AddRange(new object[] {
            "75",
            "100",
            "150",
            "200"});
            this.comboBoxPeriod.Location = new System.Drawing.Point(169, 72);
            this.comboBoxPeriod.Name = "comboBoxPeriod";
            this.comboBoxPeriod.Size = new System.Drawing.Size(122, 22);
            this.comboBoxPeriod.TabIndex = 5;
            this.comboBoxPeriod.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeriod_SelectedIndexChanged_1);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(44, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "&Period:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxOrder
            // 
            this.comboBoxOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrder.Items.AddRange(new object[] {
            "3",
            "4",
            "5"});
            this.comboBoxOrder.Location = new System.Drawing.Point(169, 40);
            this.comboBoxOrder.Name = "comboBoxOrder";
            this.comboBoxOrder.Size = new System.Drawing.Size(122, 22);
            this.comboBoxOrder.TabIndex = 3;
            this.comboBoxOrder.SelectedIndexChanged += new System.EventHandler(this.comboBoxForecasting_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(44, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Order:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonRandomData
            // 
            this.buttonRandomData.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRandomData.Location = new System.Drawing.Point(72, 200);
            this.buttonRandomData.Name = "buttonRandomData";
            this.buttonRandomData.Size = new System.Drawing.Size(192, 26);
            this.buttonRandomData.TabIndex = 10;
            this.buttonRandomData.Text = "&Generate Random Data";
            this.buttonRandomData.UseVisualStyleBackColor = false;
            this.buttonRandomData.Click += new System.EventHandler(this.buttonRandomData_Click_1);
            // 
            // comboBoxRegressionType
            // 
            this.comboBoxRegressionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegressionType.Items.AddRange(new object[] {
            "Linear",
            "Polynomial",
            "Exponential",
            "Logarithmic",
            "Power"});
            this.comboBoxRegressionType.Location = new System.Drawing.Point(169, 8);
            this.comboBoxRegressionType.Name = "comboBoxRegressionType";
            this.comboBoxRegressionType.Size = new System.Drawing.Size(122, 22);
            this.comboBoxRegressionType.TabIndex = 1;
            this.comboBoxRegressionType.SelectedIndexChanged += new System.EventHandler(this.comboBoxForecasting_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(44, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Regression Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Forecasting
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSampleComment);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Name = "Forecasting";
            this.Size = new System.Drawing.Size(728, 480);
            this.Load += new System.EventHandler(this.TemplateSampleControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		} 
		#endregion


		/// <summary>
		/// This method calculates Time series.
		/// </summary>
		private void Calculations()
		{
			if( comboBoxRegressionType.Text != "Polynomial" )
				comboBoxOrder.Enabled = false;
			else
				comboBoxOrder.Enabled = true;

			string typeRegression;

			if( comboBoxRegressionType.Text != "Polynomial" )
				typeRegression = comboBoxRegressionType.Text;
			else
				typeRegression = comboBoxOrder.Text;

			// The number of days for Forecasting
			int forecasting = int.Parse( comboBoxForecasting.Text );

			// Show Error as a range chart
			string error = checkBoxError.Checked.ToString();

			// Show Error as a range chart
			string forecastingError = checkBoxForecastingError.Checked.ToString();

			//  Formula parameters
			string parameters = typeRegression + ',' + forecasting + ',' + error + ',' + forecastingError;
						
            chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, parameters, "Input:Y", "Forecasting:Y,Range:Y,Range:Y2");
            chart1.Series["Range"].Enabled = checkBoxError.Checked || checkBoxForecastingError.Checked;

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
			if( high <= 0 )
			{
				high = -1 * high + 1;
			}

			// The first Close value
			double close = high - rand.NextDouble();
			
			// The first Low value
			double low = close - rand.NextDouble();
			
			// The first Volume value
			double volume = 100 + 15 * rand.NextDouble();
						
			// The first day X and Y values
			chart1.Series["Input"].Points.AddXY(DateTime.Parse("1/2/2002"), high);
			chart1.Series["Input"].Points[0].YValues[1] = low;

			// The Open value is not used.
			chart1.Series["Input"].Points[0].YValues[2] = close;
			chart1.Series["Input"].Points[0].YValues[3] = close;
			
			// Days loop
			for( int day = 1; day <= period; day++ )
			{
			
				// Calculate High, Low and Close values
				high = chart1.Series["Input"].Points[day-1].YValues[2]+rand.NextDouble();
				close = high - rand.NextDouble();
				low = close - rand.NextDouble();
				
				// The low cannot be less than yesterday close value.
				if( low > chart1.Series["Input"].Points[day-1].YValues[2])
					low = chart1.Series["Input"].Points[day-1].YValues[2];
							
				// Set data points values
				if( high <= 0 )
				{
					high = -1 * high + 1;
				}
				chart1.Series["Input"].Points.AddXY(day, high);
				chart1.Series["Input"].Points[day].XValue = chart1.Series["Input"].Points[day-1].XValue+1;
				chart1.Series["Input"].Points[day].YValues[1] = low;
				chart1.Series["Input"].Points[day].YValues[2] = close;
				chart1.Series["Input"].Points[day].YValues[3] = close;

			}
		
			chart1.Invalidate();
		}

		private void TemplateSampleControl_Load(object sender, System.EventArgs e)
		{
			comboBoxOrder.SelectedIndex = 0;
			comboBoxRegressionType.SelectedIndex = 0;
			comboBoxForecasting.SelectedIndex = 0;
			comboBoxPeriod.SelectedIndex = 0;
			doCalculations = true;

			// Set random data
			Data( chart1.Series["Input"] );

			// Initialize values.
			Calculations();
		}

		private void comboBoxOrder_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(doCalculations)
			{
				// Initialize values.
				Calculations();
			}
		}

		private void buttonRandomData_Click_1(object sender, System.EventArgs e)
		{
			Random rand  = new Random();
			randSeed = rand.Next();

			// Set random data
			Data( chart1.Series["Input"] );

			// Initialize values.
			Calculations();
		}

		private void checkBoxForecastingError_CheckStateChanged_1(object sender, System.EventArgs e)
		{
			if(doCalculations)
			{
				// Initialize values.
				Calculations();
			}
		}

		private void comboBoxPeriod_SelectedIndexChanged_1(object sender, System.EventArgs e)
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

		private void comboBoxForecasting_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			if(doCalculations)
			{
				// Initialize values.
				Calculations();
			}
		}

	}
}
