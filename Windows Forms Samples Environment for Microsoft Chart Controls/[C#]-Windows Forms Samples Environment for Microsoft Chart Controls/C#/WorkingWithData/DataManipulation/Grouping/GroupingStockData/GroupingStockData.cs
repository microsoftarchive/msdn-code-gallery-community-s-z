using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsChartSamples
{
	/// <summary>
	/// Summary description for GroupingStockData.
	/// </summary>
	public class GroupingStockData : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label labelSampleComment;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox comboBoxGroupingInterval;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxStockSymbol;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
        private Label label4;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GroupingStockData()
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupingStockData));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelSampleComment = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxGroupingInterval = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxStockSymbol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            chartArea3.Area3DStyle.Inclination = 15;
            chartArea3.Area3DStyle.IsClustered = true;
            chartArea3.Area3DStyle.IsRightAngleAxes = false;
            chartArea3.Area3DStyle.Perspective = 10;
            chartArea3.Area3DStyle.Rotation = 10;
            chartArea3.Area3DStyle.WallWidth = 0;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea3.AxisX.LabelStyle.Format = "MMM\\\'yy";
            chartArea3.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea3.AxisX.MajorTickMark.Size = 2F;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.IsStartedFromZero = false;
            chartArea3.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea3.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea3.BackColor = System.Drawing.Color.Gainsboro;
            chartArea3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea3.BackSecondaryColor = System.Drawing.Color.White;
            chartArea3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.Name = "Default";
            chartArea3.ShadowColor = System.Drawing.Color.Transparent;
            chartArea4.AlignWithChartArea = "Default";
            chartArea4.Area3DStyle.Inclination = 15;
            chartArea4.Area3DStyle.IsClustered = true;
            chartArea4.Area3DStyle.IsRightAngleAxes = false;
            chartArea4.Area3DStyle.Perspective = 10;
            chartArea4.Area3DStyle.Rotation = 10;
            chartArea4.Area3DStyle.WallWidth = 0;
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea4.AxisX.LabelStyle.Format = "MMM\\\'yy";
            chartArea4.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.AxisX.MajorTickMark.Size = 2F;
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.IsStartedFromZero = false;
            chartArea4.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea4.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.BackColor = System.Drawing.Color.Gainsboro;
            chartArea4.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea4.BackSecondaryColor = System.Drawing.Color.White;
            chartArea4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.Name = "GroupedData";
            chartArea4.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.ChartAreas.Add(chartArea4);
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Enabled = false;
            legend2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend2.IsTextAutoFit = false;
            legend2.Name = "Default";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(16, 56);
            this.chart1.Name = "chart1";
            series3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series3.ChartArea = "Default";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Stock;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series3.Legend = "Default";
            series3.Name = "StockPrice";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YValuesPerPoint = 4;
            series4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series4.BorderWidth = 2;
            series4.ChartArea = "GroupedData";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Stock;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            series4.Legend = "Default";
            series4.Name = "GroupedStockPrice";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.YValuesPerPoint = 4;
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(500, 296);
            this.chart1.TabIndex = 1;
            // 
            // labelSampleComment
            // 
            this.labelSampleComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSampleComment.Font = new System.Drawing.Font("Verdana", 11F);
            this.labelSampleComment.Location = new System.Drawing.Point(16, 14);
            this.labelSampleComment.Name = "labelSampleComment";
            this.labelSampleComment.Size = new System.Drawing.Size(696, 34);
            this.labelSampleComment.TabIndex = 0;
            this.labelSampleComment.Text = "This sample demonstrates how to group stock Hi-Low-Open-Close prices using date i" +
                "ntervals.";
            this.labelSampleComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxGroupingInterval);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxStockSymbol);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(520, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 288);
            this.panel1.TabIndex = 2;
            // 
            // comboBoxGroupingInterval
            // 
            this.comboBoxGroupingInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroupingInterval.Items.AddRange(new object[] {
            "Week",
            "Month",
            "Quarter"});
            this.comboBoxGroupingInterval.Location = new System.Drawing.Point(120, 40);
            this.comboBoxGroupingInterval.Name = "comboBoxGroupingInterval";
            this.comboBoxGroupingInterval.Size = new System.Drawing.Size(80, 22);
            this.comboBoxGroupingInterval.TabIndex = 3;
            this.comboBoxGroupingInterval.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroupingInterval_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Grouping &Interval:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxStockSymbol
            // 
            this.comboBoxStockSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStockSymbol.Items.AddRange(new object[] {
            "ABC",
            "JIGY",
            "EJIT",
            "LUKY",
            "OLDG",
            "BLL"});
            this.comboBoxStockSymbol.Location = new System.Drawing.Point(120, 8);
            this.comboBoxStockSymbol.Name = "comboBoxStockSymbol";
            this.comboBoxStockSymbol.Size = new System.Drawing.Size(80, 22);
            this.comboBoxStockSymbol.TabIndex = 1;
            this.comboBoxStockSymbol.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroupingInterval_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock &Symbol:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Verdana", 11F);
            this.label3.Location = new System.Drawing.Point(16, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(696, 59);
            this.label3.TabIndex = 3;
            this.label3.Text = resources.GetString("label3.Text");
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Verdana", 11F);
            this.label4.Location = new System.Drawing.Point(16, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(696, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "This sample also uses data binding.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GroupingStockData
            // 
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSampleComment);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GroupingStockData";
            this.Size = new System.Drawing.Size(728, 480);
            this.Load += new System.EventHandler(this.TemplateSampleControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void PopulateData()
		{
			// Prepare data base connection and query strings
			System.Windows.Forms.DataVisualization.Charting.Utilities.SampleMain.MainForm mainForm = (System.Windows.Forms.DataVisualization.Charting.Utilities.SampleMain.MainForm)this.ParentForm;
            string fileNameString = mainForm.applicationPath + "\\";
			fileNameString += "data\\chartdata.mdb";
			string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileNameString;
			string mySelectQuery="SELECT * FROM STOCKDATA WHERE SymbolName = '" + comboBoxStockSymbol.Text + "' ORDER BY Date";

			// Open data base connection
			OleDbConnection myConnection = new OleDbConnection(myConnectionString);
			OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);
			myCommand.Connection.Open();
			
			// Create a database reader	
			OleDbDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			
			// Data bind to the reader
			chart1.Series["StockPrice"].Points.Clear();
			chart1.Series["StockPrice"].Points.DataBindXY(myReader, "Date", myReader, "High,Low,Open,Close");
			
			// Group series data points by interval. Different formulas are used for each Y value:
			//   Y1 (High) - maximum of all Y1 points values in the group
			//   Y2 (Low) - minimum of all Y2 points values in the group
			//   Y3 (Open) - Y3 value of the first point in the group
			//   Y4 (Close) - Y4 value of the last point in the group
			chart1.Series["GroupedStockPrice"].Points.Clear();
			if(comboBoxGroupingInterval.Text == "Week")
				chart1.DataManipulator.Group("Y1:MAX,Y2:MIN,Y3:FIRST,Y4:LAST", 1, IntervalType.Weeks, "StockPrice", "GroupedStockPrice");
			else if(comboBoxGroupingInterval.Text == "Month")
				chart1.DataManipulator.Group("Y1:MAX,Y2:MIN,Y3:FIRST,Y4:LAST", 1, IntervalType.Months, "StockPrice", "GroupedStockPrice");
			else if(comboBoxGroupingInterval.Text == "Quarter")
				chart1.DataManipulator.Group("Y1:MAX,Y2:MIN,Y3:FIRST,Y4:LAST", 3, IntervalType.Months, "StockPrice", "GroupedStockPrice");

			// close the reader and the connection
			myReader.Close();
			myConnection.Close();   

			chart1.ResetAutoValues();
			chart1.Invalidate();
		}

		private void TemplateSampleControl_Load(object sender, System.EventArgs e)
		{
			comboBoxStockSymbol.SelectedIndex = 0;
			comboBoxGroupingInterval.SelectedIndex = 0;
		}

		private void comboBoxGroupingInterval_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PopulateData();		
		}
	}
}
