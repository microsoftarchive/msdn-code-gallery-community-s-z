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
	/// Summary description for AxisAppearance.
	/// </summary>
	public class InsertingEmptyPoints : System.Windows.Forms.UserControl
	{
		
		private System.Data.DataSet seriesData = null;
		
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataVisualization.Charting.Chart Chart1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox ShowAsIndexedList;
        private System.Windows.Forms.ComboBox EmptyPointIntervalList;
		private System.Windows.Forms.ComboBox EmptyPointValue;
		private System.Windows.Forms.Label label6;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InsertingEmptyPoints()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Initialize combo boxes
			EmptyPointValue.SelectedIndex = 1;
			ShowAsIndexedList.SelectedIndex = 0;
			EmptyPointIntervalList.SelectedIndex = 1;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem2 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EmptyPointValue = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ShowAsIndexedList = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.EmptyPointIntervalList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(702, 34);
            this.label9.TabIndex = 0;
            this.label9.Text = "This sample uses the InsertEmptyPoints method to repeatedly check for missing dat" +
                "a points for a given time interval and inserts empty points. ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.EmptyPointValue);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ShowAsIndexedList);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.EmptyPointIntervalList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(432, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 292);
            this.panel1.TabIndex = 2;
            // 
            // EmptyPointValue
            // 
            this.EmptyPointValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmptyPointValue.Items.AddRange(new object[] {
            "Zero",
            "Average"});
            this.EmptyPointValue.Location = new System.Drawing.Point(168, 40);
            this.EmptyPointValue.Name = "EmptyPointValue";
            this.EmptyPointValue.Size = new System.Drawing.Size(121, 22);
            this.EmptyPointValue.TabIndex = 5;
            this.EmptyPointValue.SelectedIndexChanged += new System.EventHandler(this.Combo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(32, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Empty Point &Value:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ShowAsIndexedList
            // 
            this.ShowAsIndexedList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShowAsIndexedList.Items.AddRange(new object[] {
            "False",
            "True"});
            this.ShowAsIndexedList.Location = new System.Drawing.Point(168, 72);
            this.ShowAsIndexedList.Name = "ShowAsIndexedList";
            this.ShowAsIndexedList.Size = new System.Drawing.Size(120, 22);
            this.ShowAsIndexedList.TabIndex = 3;
            this.ShowAsIndexedList.SelectedIndexChanged += new System.EventHandler(this.Combo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(4, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Show as &Indexed:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EmptyPointIntervalList
            // 
            this.EmptyPointIntervalList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmptyPointIntervalList.Items.AddRange(new object[] {
            "No Empty Points",
            "Every Day",
            "Every Week Day",
            "Every Monday",
            "Every 12 Hours"});
            this.EmptyPointIntervalList.Location = new System.Drawing.Point(168, 8);
            this.EmptyPointIntervalList.Name = "EmptyPointIntervalList";
            this.EmptyPointIntervalList.Size = new System.Drawing.Size(120, 22);
            this.EmptyPointIntervalList.TabIndex = 1;
            this.EmptyPointIntervalList.SelectedIndexChanged += new System.EventHandler(this.Combo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "&Check for Empty Points:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Chart1
            // 
            this.Chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            this.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.Chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.Chart1.BorderlineWidth = 2;
            this.Chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea2.Area3DStyle.Inclination = 15;
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.Area3DStyle.IsRightAngleAxes = false;
            chartArea2.Area3DStyle.Perspective = 10;
            chartArea2.Area3DStyle.Rotation = 10;
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisX.LabelStyle.Format = "M";
            chartArea2.AxisX.LabelStyle.IsStaggered = true;
            chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
            chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea2.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.Name = "Default";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 76.2929F;
            chartArea2.Position.Width = 89.43796F;
            chartArea2.Position.X = 4.824818F;
            chartArea2.Position.Y = 16.89354F;
            chartArea2.ShadowColor = System.Drawing.Color.Transparent;
            this.Chart1.ChartAreas.Add(chartArea2);
            legend2.Alignment = System.Drawing.StringAlignment.Far;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legendItem2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            legendItem2.ImageStyle = System.Windows.Forms.DataVisualization.Charting.LegendImageStyle.Marker;
            legendItem2.MarkerSize = 7;
            legendItem2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;
            legendItem2.Name = "Empty Point";
            legend2.CustomItems.Add(legendItem2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend2.IsTextAutoFit = false;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend2.Name = "Default";
            this.Chart1.Legends.Add(legend2);
            this.Chart1.Location = new System.Drawing.Point(16, 60);
            this.Chart1.Name = "Chart1";
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series2.ChartArea = "Default";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            series2.CustomProperties = "DrawingStyle=Emboss";
            series2.EmptyPointStyle.Color = System.Drawing.Color.Transparent;
            series2.EmptyPointStyle.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            series2.EmptyPointStyle.MarkerSize = 7;
            series2.EmptyPointStyle.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;
            series2.LabelFormat = "M";
            series2.Legend = "Default";
            series2.LegendText = "Data";
            series2.Name = "Series1";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.Chart1.Series.Add(series2);
            this.Chart1.Size = new System.Drawing.Size(412, 296);
            this.Chart1.TabIndex = 1;
            // 
            // InsertingEmptyPoints
            // 
            this.Controls.Add(this.Chart1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "InsertingEmptyPoints";
            this.Size = new System.Drawing.Size(728, 480);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		
		private void Combo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			EmptyPoints();
		}

		private void EmptyPoints()
		{
			// Inserting empty points changes 
			// the series data so we have to store the original data.
			if ( seriesData == null )
			{
				// Populate series data
				double[]	yValues = {23, 56, 67, 98, 45, 67, 23, 29, 87, 65, 49, 77, 56, 34, 76};
				DateTime	currentDate = DateTime.Now.Date;
				Random		random = new Random();
				Chart1.Series["Series1"].Points.Clear();
				for(int pointIndex = 0; pointIndex < 15; pointIndex++)
				{
					Chart1.Series["Series1"].Points.AddXY(currentDate, yValues[pointIndex]);
					currentDate = currentDate.AddDays(random.Next(1, 5));
				}
				seriesData = GetSeriesValues();
			}
			else
			{
				Chart1.Series["Series1"].Points.DataBind( seriesData.Tables[0].Rows, "X", "Y", String.Empty);
			}
			
			Chart1.Series["Series1"]["EmptyPointValue"] = EmptyPointValue.SelectedItem.ToString();
			Chart1.Series["Series1"].EmptyPointStyle.MarkerSize = 7;
			Chart1.Series["Series1"].EmptyPointStyle.MarkerStyle = MarkerStyle.Diamond;

			// Check point existance for every day
			if(EmptyPointIntervalList.GetItemText(EmptyPointIntervalList.SelectedItem) == "Every Day")
			{
				Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Days, "Series1");
			}

				// Check point existance for every 12 hours
			else if(EmptyPointIntervalList.GetItemText(EmptyPointIntervalList.SelectedItem) == "Every 12 Hours")
			{
				Chart1.Series["Series1"].EmptyPointStyle.MarkerSize = 3;
				Chart1.DataManipulator.InsertEmptyPoints(12, IntervalType.Hours, "Series1");
			}

				// Check point existance for every week day
			else if(EmptyPointIntervalList.GetItemText(EmptyPointIntervalList.SelectedItem) == "Every Week Day")
			{
				Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Weeks, 1, IntervalType.Days, "Series1");
				Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Weeks, 2, IntervalType.Days, "Series1");
				Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Weeks, 3, IntervalType.Days, "Series1");
				Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Weeks, 4, IntervalType.Days, "Series1");
				Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Weeks, 5, IntervalType.Days, "Series1");
			}

				// Check point existance for every Monday
			else if(EmptyPointIntervalList.GetItemText(EmptyPointIntervalList.SelectedItem) == "Every Monday")
			{
				Chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Weeks, 1, IntervalType.Days, "Series1");
			}

			// Use point index instead of the X value
			if(ShowAsIndexedList.GetItemText(ShowAsIndexedList.SelectedItem) == "True")
			{
				Chart1.Series["Series1"].IsXValueIndexed = true;
				Chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
				Chart1.ChartAreas[0].AxisX.MajorTickMark.Interval = 1;
				Chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
			}
			else
			{
				Chart1.Series["Series1"].IsXValueIndexed = false;
				Chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 0;
				Chart1.ChartAreas[0].AxisX.MajorTickMark.Interval = 0;
				Chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 0;
			}
		}

		/// <summary>
		/// Generates a DataSet from series
		/// </summary>
		/// <returns>Generated DataSet</returns>
		private DataSet GetSeriesValues()
		{

			Series ser = this.Chart1.Series["Series1"];

			DataSet	dataSet = new DataSet();
			DataTable seriesTable = new DataTable(ser.Name);
			
			seriesTable.Columns.Add( new DataColumn("X", typeof(DateTime)));
			seriesTable.Columns.Add( new DataColumn("Y", typeof(double)));

			for( int count = 0; count < ser.Points.Count; count++)
			{
				DataPoint p = ser.Points[count];
				seriesTable.Rows.Add( new object[] { DateTime.FromOADate(p.XValue), p.YValues[0] });
			}
			
			dataSet.Tables.Add( seriesTable );
			return dataSet;
		}

		
		
	}
}
