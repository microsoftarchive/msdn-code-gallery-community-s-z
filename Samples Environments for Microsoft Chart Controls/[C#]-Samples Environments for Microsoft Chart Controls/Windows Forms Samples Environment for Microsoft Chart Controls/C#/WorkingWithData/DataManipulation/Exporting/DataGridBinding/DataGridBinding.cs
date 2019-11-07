using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinFormsChartSamples
{
	/// <summary>
	/// Summary description for TemplateSampleControl.
	/// </summary>
	public class DataGridBinding : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label labelSampleComment;
		private System.Windows.Forms.Panel panel1;

		private System.Windows.Forms.DataVisualization.Charting.Chart Chart1;
		private System.Windows.Forms.DataGrid SeriesValuesDataGrid;
		private System.Data.DataSet dataSet1;
		private System.Windows.Forms.Label label4;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DataGridBinding()
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGridBinding));
            this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelSampleComment = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SeriesValuesDataGrid = new System.Windows.Forms.DataGrid();
            this.dataSet1 = new System.Data.DataSet();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeriesValuesDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // Chart1
            // 
            this.Chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            this.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.Chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.Chart1.BorderlineWidth = 2;
            this.Chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 15;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.PointDepth = 300;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LabelStyle.IsStaggered = true;
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.Chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            this.Chart1.Legends.Add(legend1);
            this.Chart1.Location = new System.Drawing.Point(16, 48);
            this.Chart1.Name = "Chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            series1.Legend = "Default";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.Chart1.Series.Add(series1);
            this.Chart1.Size = new System.Drawing.Size(412, 296);
            this.Chart1.TabIndex = 0;
            title1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            title1.Name = "Title1";
            title1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title1.ShadowOffset = 3;
            title1.Text = "Databind to Dataset";
            this.Chart1.Titles.Add(title1);
            this.Chart1.Click += new System.EventHandler(this.Chart1_Click);
            // 
            // labelSampleComment
            // 
            this.labelSampleComment.Font = new System.Drawing.Font("Verdana", 11F);
            this.labelSampleComment.Location = new System.Drawing.Point(16, 8);
            this.labelSampleComment.Name = "labelSampleComment";
            this.labelSampleComment.Size = new System.Drawing.Size(702, 34);
            this.labelSampleComment.TabIndex = 2;
            this.labelSampleComment.Text = "This sample demonstrates exporting series values and data binding.";
            this.labelSampleComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SeriesValuesDataGrid);
            this.panel1.Location = new System.Drawing.Point(432, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 288);
            this.panel1.TabIndex = 1;
            // 
            // SeriesValuesDataGrid
            // 
            this.SeriesValuesDataGrid.CaptionVisible = false;
            this.SeriesValuesDataGrid.DataMember = "";
            this.SeriesValuesDataGrid.DataSource = this.dataSet1;
            this.SeriesValuesDataGrid.FlatMode = true;
            this.SeriesValuesDataGrid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeriesValuesDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.SeriesValuesDataGrid.Location = new System.Drawing.Point(16, 0);
            this.SeriesValuesDataGrid.Name = "SeriesValuesDataGrid";
            this.SeriesValuesDataGrid.RowHeadersVisible = false;
            this.SeriesValuesDataGrid.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.SeriesValuesDataGrid.Size = new System.Drawing.Size(172, 280);
            this.SeriesValuesDataGrid.TabIndex = 0;
            this.SeriesValuesDataGrid.CurrentCellChanged += new System.EventHandler(this.SeriesValuesDataGrid_CurrentCellChanged);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 11F);
            this.label4.Location = new System.Drawing.Point(13, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(702, 64);
            this.label4.TabIndex = 4;
            this.label4.Text = resources.GetString("label4.Text");
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DataGridBinding
            // 
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSampleComment);
            this.Controls.Add(this.Chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Name = "DataGridBinding";
            this.Size = new System.Drawing.Size(728, 480);
            this.Load += new System.EventHandler(this.DataGridBinding_Load);
            this.Leave += new System.EventHandler(this.DataGridBinding_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SeriesValuesDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		
	
		private void DataGridBinding_Load(object sender, System.EventArgs e)
		{
			// Populate series data using random data
			double[]	yValues = {23.67, 75.45, 60.45, 34.54, 85.62, 32.43, 55.98, 67.23, 56.34, 23.14, 45.24, 67.41, 13.45, 56.36, 45.29};
			for(int pointIndex = 0; pointIndex < yValues.Length; pointIndex++)
			{
				Chart1.Series["Series1"].Points.AddXY(1990 + pointIndex, yValues[pointIndex]);
			}
			
			//dataSet1 = Chart1.DataManipulator.ExportSeriesValues("Series1");
			// Export series values into DataSet object
			dataSet1 = Chart1.DataManipulator.ExportSeriesValues("Series1");

			// Data bind DataGrid control. 
			SeriesValuesDataGrid.DataSource = dataSet1;

			// Set Series Name for data
			SeriesValuesDataGrid.DataMember = "Series1";

		}
		

		private void SeriesValuesDataGrid_CurrentCellChanged(object sender, System.EventArgs e)
		{
			// Initializes a new instance of the DataView class
			DataView firstView = new DataView(dataSet1.Tables[0]);

			// since the DataView implements IEnumerable, pass the reader directly into
			//   the DataBind method with the name of the Columns selected in the query    
			Chart1.Series["Series1"].Points.DataBindXY(firstView,"X",firstView,"Y");

			// Invalidate Chart
			Chart1.Invalidate();

		}

		private void Chart1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void DataGridBinding_Leave(object sender, System.EventArgs e)
		{
			Chart1.Focus();
		}
	}

}
