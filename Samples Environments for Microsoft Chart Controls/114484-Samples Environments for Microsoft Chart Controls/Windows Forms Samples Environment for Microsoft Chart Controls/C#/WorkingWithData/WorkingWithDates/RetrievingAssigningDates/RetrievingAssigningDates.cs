using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace WinFormsChartSamples
{
	public class RetrievingAssigningDates : System.Windows.Forms.UserControl
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
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox Mon1;
		private System.Windows.Forms.ComboBox Day1;
		private System.Windows.Forms.ComboBox Year1;
		private System.Windows.Forms.ComboBox Mon2;
		private System.Windows.Forms.ComboBox Day2;
		private System.Windows.Forms.ComboBox Year2;		
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label10;		

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private int RandomInit = 1;

		#endregion

		public RetrievingAssigningDates()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Initialize combo boxes
			Mon1.SelectedIndex = 0;
			Day1.SelectedIndex = 0;
			Year1.SelectedIndex = 0;
			Mon2.SelectedIndex = 0;
			Day2.SelectedIndex = 0;
			Year2.SelectedIndex = 1;
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
			this.label9 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.Year2 = new System.Windows.Forms.ComboBox();
			this.Day2 = new System.Windows.Forms.ComboBox();
			this.Mon2 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Year1 = new System.Windows.Forms.ComboBox();
			this.Day1 = new System.Windows.Forms.ComboBox();
			this.Mon1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label10 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label9.Font = new System.Drawing.Font("Verdana", 11F);
			this.label9.Location = new System.Drawing.Point(16, 8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(702, 34);
			this.label9.TabIndex = 0;
			this.label9.Text = "This sample shows how to set Minimum and Maximum axis values using Dates. ";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.button1,
																				 this.label8,
																				 this.label7,
																				 this.Year2,
																				 this.Day2,
																				 this.Mon2,
																				 this.label2,
																				 this.Year1,
																				 this.Day1,
																				 this.Mon1,
																				 this.label1,
																				 this.label6,
																				 this.label5,
																				 this.label4,
																				 this.label3,
																				 this.label15});
			this.panel1.Location = new System.Drawing.Point(432, 56);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(292, 288);
			this.panel1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.Location = new System.Drawing.Point(48, 152);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(160, 24);
			this.button1.TabIndex = 10;
			this.button1.Text = "Random &Data";
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// label8
			// 
			this.label8.ForeColor = System.Drawing.Color.Red;
			this.label8.Location = new System.Drawing.Point(48, 125);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(240, 16);
			this.label8.TabIndex = 9;
			this.label8.Text = "Max Value";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(48, 104);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(224, 23);
			this.label7.TabIndex = 8;
			this.label7.Text = "Maximum Y value occurs on:";
			// 
			// Year2
			// 
			this.Year2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Year2.Items.AddRange(new object[] {
													   "2004",
													   "2005",
													   "2006"});
			this.Year2.Location = new System.Drawing.Point(144, 72);
			this.Year2.Name = "Year2";
			this.Year2.Size = new System.Drawing.Size(64, 22);
			this.Year2.TabIndex = 7;
			this.Year2.SelectedIndexChanged += new System.EventHandler(this.Combo_Click);
			// 
			// Day2
			// 
			this.Day2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Day2.Items.AddRange(new object[] {
													  "1",
													  "2",
													  "3",
													  "4",
													  "5",
													  "6",
													  "7",
													  "8",
													  "9",
													  "10",
													  "11",
													  "12",
													  "13",
													  "14",
													  "15",
													  "16",
													  "17",
													  "18",
													  "19",
													  "20",
													  "21",
													  "22",
													  "23",
													  "24",
													  "25",
													  "26",
													  "27"});
			this.Day2.Location = new System.Drawing.Point(104, 72);
			this.Day2.Name = "Day2";
			this.Day2.Size = new System.Drawing.Size(40, 22);
			this.Day2.TabIndex = 6;
			this.Day2.SelectedIndexChanged += new System.EventHandler(this.Combo_Click);
			// 
			// Mon2
			// 
			this.Mon2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Mon2.Items.AddRange(new object[] {
													  "Jan",
													  "Feb",
													  "Mar",
													  "Apr",
													  "May",
													  "Jun",
													  "Jul",
													  "Aug",
													  "Sep",
													  "Oct",
													  "Nov",
													  "Dec"});
			this.Mon2.Location = new System.Drawing.Point(48, 72);
			this.Mon2.Name = "Mon2";
			this.Mon2.Size = new System.Drawing.Size(56, 22);
			this.Mon2.TabIndex = 5;
			this.Mon2.SelectedIndexChanged += new System.EventHandler(this.Combo_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(48, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Ma&ximum Date:";
			// 
			// Year1
			// 
			this.Year1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Year1.Items.AddRange(new object[] {
													   "2002",
													   "2003"});
			this.Year1.Location = new System.Drawing.Point(144, 24);
			this.Year1.Name = "Year1";
			this.Year1.Size = new System.Drawing.Size(64, 22);
			this.Year1.TabIndex = 3;
			this.Year1.SelectedIndexChanged += new System.EventHandler(this.Combo_Click);
			// 
			// Day1
			// 
			this.Day1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Day1.Items.AddRange(new object[] {
													  "1",
													  "2",
													  "3",
													  "4",
													  "5",
													  "6",
													  "7",
													  "8",
													  "9",
													  "10",
													  "11",
													  "12",
													  "13",
													  "14",
													  "15",
													  "16",
													  "17",
													  "18",
													  "19",
													  "20",
													  "21",
													  "22",
													  "23",
													  "24",
													  "25",
													  "26",
													  "27"});
			this.Day1.Location = new System.Drawing.Point(104, 24);
			this.Day1.Name = "Day1";
			this.Day1.Size = new System.Drawing.Size(40, 22);
			this.Day1.TabIndex = 2;
			this.Day1.SelectedIndexChanged += new System.EventHandler(this.Combo_Click);
			// 
			// Mon1
			// 
			this.Mon1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Mon1.Items.AddRange(new object[] {
													  "Jan",
													  "Feb",
													  "Mar",
													  "Apr",
													  "May",
													  "Jun",
													  "Jul",
													  "Aug",
													  "Sep",
													  "Oct",
													  "Nov",
													  "Dec"});
			this.Mon1.Location = new System.Drawing.Point(48, 24);
			this.Mon1.Name = "Mon1";
			this.Mon1.Size = new System.Drawing.Size(56, 22);
			this.Mon1.TabIndex = 1;
			this.Mon1.SelectedIndexChanged += new System.EventHandler(this.Combo_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mi&nimum Date:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(64, 403);
			this.label6.Name = "label6";
			this.label6.TabIndex = 14;
			this.label6.Text = "Border Size:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(64, 380);
			this.label5.Name = "label5";
			this.label5.TabIndex = 13;
			this.label5.Text = "Border Color:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(64, 357);
			this.label4.Name = "label4";
			this.label4.TabIndex = 12;
			this.label4.Text = "Hatch Style:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(64, 334);
			this.label3.Name = "label3";
			this.label3.TabIndex = 11;
			this.label3.Text = "Gradient:";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(64, 426);
			this.label15.Name = "label15";
			this.label15.TabIndex = 5;
			this.label15.Text = "Border Size:";
			// 
			// Chart1
			// 
			this.Chart1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Chart1.BackSecondaryColor = System.Drawing.Color.White;
			this.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.Chart1.BorderlineColor = System.Drawing.Color.FromArgb(((System.Byte)(26)), ((System.Byte)(59)), ((System.Byte)(105)));
			this.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			this.Chart1.BorderlineWidth = 2;
			this.Chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
			chartArea1.Area3DStyle.IsClustered = true;
			chartArea1.Area3DStyle.Perspective = 10;
			chartArea1.Area3DStyle.IsRightAngleAxes = false;
			chartArea1.Area3DStyle.WallWidth = 0;
			chartArea1.Area3DStyle.Inclination = 15;
			chartArea1.Area3DStyle.Rotation = 10;
			chartArea1.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;;
			chartArea1.AxisX.LabelAutoFitStyle = (((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap);
			chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
			chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
			chartArea1.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;;
			chartArea1.AxisY.LabelAutoFitStyle = (((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap);
			chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
			chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
			chartArea1.BackColor = System.Drawing.Color.Gainsboro;
			chartArea1.BackSecondaryColor = System.Drawing.Color.White;
			chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			chartArea1.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea1.Name = "Default";
			chartArea1.ShadowColor = System.Drawing.Color.Transparent;
			this.Chart1.ChartAreas.Add(chartArea1);
			legend1.IsTextAutoFit = false;
			legend1.BackColor = System.Drawing.Color.Transparent;
			legend1.Enabled = false;
			legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
			legend1.Name = "Default";
			this.Chart1.Legends.Add(legend1);
			this.Chart1.Location = new System.Drawing.Point(16, 48);
			this.Chart1.Name = "Chart1";
			this.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
			series1.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(180)), ((System.Byte)(26)), ((System.Byte)(59)), ((System.Byte)(105)));
			series1.ChartArea = "Default";
			series1.ChartType = SeriesChartType.Line;
			series1.Color = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(99)), ((System.Byte)(129)));
			series1.CustomProperties = "LabelsRadialLineSize=1, LabelStyle=outside";
			series1.Name = "Series1";
			series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
			this.Chart1.Series.Add(series1);
			this.Chart1.Size = new System.Drawing.Size(412, 296);
			this.Chart1.TabIndex = 1;
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label10.Font = new System.Drawing.Font("Verdana", 11F);
			this.label10.Location = new System.Drawing.Point(16, 360);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(696, 40);
			this.label10.TabIndex = 3;
			this.label10.Text = "It also demonstrates how to convert X values of type Double (that represent a dat" +
				"e) to a string by displaying the date the maximum Y value occurred.";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// RetrievingAssigningDates
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label10,
																		  this.Chart1,
																		  this.panel1,
																		  this.label9});
			this.Font = new System.Drawing.Font("Verdana", 9F);
			this.Name = "RetrievingAssigningDates";
			this.Size = new System.Drawing.Size(728, 480);
			this.Load += new System.EventHandler(this.RetrievingAssigningDates_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// Create random data
		/// </summary>
		private void RandomData()
		{
			if( Year1.SelectedItem == null ||
				Mon1.SelectedItem == null ||
				Day1.SelectedItem == null ||
				Year2.SelectedItem == null ||
				Mon2.SelectedItem == null ||
				Day2.SelectedItem == null )
			{
				return;
			}

			// Declare local variables
			Random rand = new Random();
			int pointIndx = 1;

			// Get strings from combo boxes
			string startDateString = MonthToNum(Mon1.SelectedItem.ToString())+"/"+Day1.SelectedItem.ToString()+"/"+Year1.SelectedItem.ToString();
			string endDateString = MonthToNum(Mon2.SelectedItem.ToString())+"/"+Day2.SelectedItem.ToString()+"/"+Year2.SelectedItem.ToString();

			// Parse the combo box strings to form a start and end date
			IFormatProvider culture = new CultureInfo("en-US");
			DateTime startDate = DateTime.Parse(startDateString, culture);
			DateTime endDate = DateTime.Parse(endDateString, culture);
			
			// Add points based on start date specified
			Chart1.Series["Series1"].Points.Clear();
			Chart1.Series["Series1"].Points.AddXY(startDate.ToOADate(), rand.Next(100) );

			for( int point = 1; startDate.ToOADate() + point <= endDate.ToOADate(); point++ )
			{
				Chart1.Series["Series1"].Points.AddXY(startDate.ToOADate() + point, Chart1.Series["Series1"].Points[pointIndx-1].YValues[0] + rand.NextDouble()*6 - 3 );
				pointIndx++;
			}
		}

		/// <summary>
		/// Find maximum Y value
		/// </summary>
		/// <param name="point">index of a data point which have maximum Y value</param>
		private void FindMaximum( out int point )
		{
			double maxY = double.MinValue;

			point = 0;
			int pointIndex = -1;
			foreach( DataPoint dataPoint in Chart1.Series["Series1"].Points )
			{
				pointIndex++;

				if( dataPoint.XValue < Chart1.ChartAreas["Default"].AxisX.Minimum )
					continue;

				if( dataPoint.XValue > Chart1.ChartAreas["Default"].AxisX.Maximum )
					continue;

				if( maxY < dataPoint.YValues[0] )
				{
					maxY = dataPoint.YValues[0];
					point = pointIndex;
				}
			}
		}

		public void AfterLoad()
		{
			if( Year1.SelectedItem == null ||
				Mon1.SelectedItem == null ||
				Day1.SelectedItem == null ||
				Year2.SelectedItem == null ||
				Mon2.SelectedItem == null ||
				Day2.SelectedItem == null )
			{
				return;
			}

			// Create random data
			RandomData();

			int year;
			int month;
			int day;

			// Parse string values from a drop down list to an integer value.
			year = int.Parse( Year1.GetItemText(Year1.SelectedItem) );
			month = MonthToNum(Mon1.GetItemText(Mon1.SelectedItem) );
			day = int.Parse( Day1.GetItemText(Day1.SelectedItem) );

			// Set Minimum value for X axis
			try
			{
				Chart1.ChartAreas["Default"].AxisX.Minimum = new DateTime( year, month, day ).ToOADate();
			}
			catch
			{
				Chart1.ChartAreas["Default"].AxisX.Minimum = new DateTime( 1998, 1, 1 ).ToOADate();
				Year1.SelectedIndex = 0;
				Mon1.SelectedIndex = 0;
				Day1.SelectedIndex = 0;
			}


			// Parse string values from a drop down list to an integer value.
			year = int.Parse( Year2.GetItemText(Year2.SelectedItem) );
			month = MonthToNum( Mon2.GetItemText(Mon2.SelectedItem) );
			day = int.Parse( Day2.GetItemText(Day2.SelectedItem) );

			// Set Maximum value for X axis
			try
			{
				Chart1.ChartAreas["Default"].AxisX.Maximum = new DateTime( year, month, day ).ToOADate();
			}
			catch
			{
				Chart1.ChartAreas["Default"].AxisX.Maximum = new DateTime( 2002, 1, 1 ).ToOADate();
				Year2.SelectedIndex = 0;
				Mon2.SelectedIndex = 0;
				Day2.SelectedIndex = 0;
			}

			int point;

			// X value of the maximum Y value.
			FindMaximum( out point );

			// Convert Double to DateTime.
			DateTime dateTime = DateTime.FromOADate( Chart1.Series["Series1"].Points[point].XValue );

			// Convert DateTime to string.
			label8.Text = dateTime.ToLongDateString();
									
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Random rand = new Random();
			RandomInit = rand.Next();
			AfterLoad();
		}

		/// <summary>
		/// Converts Month name to month index
		/// </summary>
		/// <param name="month"></param>
		/// <returns></returns>
		private int MonthToNum( string month )
		{
			switch( month )
			{
				case "Jan":
					return 1;
				case "Feb":
					return 2;
				case "Mar":
					return 3;
				case "Apr":
					return 4;
				case "May":
					return 5;
				case "Jun":
					return 6;
				case "Jul":
					return 7;
				case "Aug":
					return 8;
				case "Sep":
					return 9;
				case "Oct":
					return 10;
				case "Nov":
					return 11;
				case "Dec":
					return 12;
				default:
					return -1;

			}
		}

		private void RetrievingAssigningDates_Load(object sender, System.EventArgs e)
		{
			AfterLoad();
		}

		private void Combo_Click(object sender, System.EventArgs e)
		{
			AfterLoad();
		}		
	}
}
