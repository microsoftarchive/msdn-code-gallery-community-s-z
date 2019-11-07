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
	/// Summary description for EmptyPointAppearance.
	/// </summary>
	public class EmptyPointAppearance : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataVisualization.Charting.Chart Chart1;
		private System.Windows.Forms.ComboBox Appearance;
		private System.Windows.Forms.ComboBox EmptyPointValue;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox LineDashStyle;
		private System.Windows.Forms.ComboBox LineColor;
		private System.Windows.Forms.ComboBox MarkerColor;
		private System.Windows.Forms.ComboBox MarkerSize;
		private System.Windows.Forms.ComboBox LineSize;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox MarkerStyleCombo;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private bool initializing = true;

		public EmptyPointAppearance()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();


			// Bind Series1 to the array. Points with double.NaN values will be marked as empty
			double[]	yValues = {12, 67, 45, double.NaN, 67, 89, 35, 12, 78, 54};
			double[]	xValues = {1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999};
			Chart1.Series[0].Points.DataBindXY(xValues, yValues);

			foreach( string name in Enum.GetNames(typeof(ChartDashStyle)))
			{
				this.LineDashStyle.Items.Add(name);
			}

			foreach( string name in Enum.GetNames(typeof(MarkerStyle)))
			{
				this.MarkerStyleCombo.Items.Add(name);
			}

			this.EmptyPointValue.SelectedIndex = 1;
			this.Appearance.SelectedIndex = 1;
			this.LineSize.SelectedIndex = 0;
			this.LineColor.SelectedIndex = this.LineColor.Items.IndexOf("Navy");
			this.LineDashStyle.SelectedIndex = this.LineDashStyle.Items.IndexOf("Dash");
			this.MarkerStyleCombo.SelectedIndex = this.MarkerStyleCombo.Items.IndexOf("Diamond");
			this.MarkerColor.SelectedIndex = 0;
			this.MarkerSize.SelectedIndex = this.MarkerSize.Items.IndexOf("9");

			this.initializing = false;
			this.ControlChange( this, EventArgs.Empty);

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
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 400);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 600);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 1700);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 3000);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 950);
            this.Appearance = new System.Windows.Forms.ComboBox();
            this.EmptyPointValue = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LineSize = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.MarkerSize = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.MarkerColor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LineColor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MarkerStyleCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LineDashStyle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // Appearance
            // 
            this.Appearance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Appearance.Items.AddRange(new object[] {
            "Transparent",
            "Line",
            "Marker",
            "Line and Marker"});
            this.Appearance.Location = new System.Drawing.Point(168, 40);
            this.Appearance.Name = "Appearance";
            this.Appearance.Size = new System.Drawing.Size(121, 22);
            this.Appearance.TabIndex = 3;
            this.Appearance.SelectedIndexChanged += new System.EventHandler(this.ControlChange);
            // 
            // EmptyPointValue
            // 
            this.EmptyPointValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmptyPointValue.Items.AddRange(new object[] {
            "Zero",
            "Average"});
            this.EmptyPointValue.Location = new System.Drawing.Point(168, 8);
            this.EmptyPointValue.Name = "EmptyPointValue";
            this.EmptyPointValue.Size = new System.Drawing.Size(121, 22);
            this.EmptyPointValue.TabIndex = 1;
            this.EmptyPointValue.SelectedIndexChanged += new System.EventHandler(this.ControlChange);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(56, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "&Appearance:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(32, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Empty Point &Value:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(702, 43);
            this.label9.TabIndex = 0;
            this.label9.Text = "This sample demonstrates one method of setting empty points, and also shows how t" +
                "o set the visual attributes of the empty points.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LineSize);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.MarkerSize);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.MarkerColor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.LineColor);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.MarkerStyleCombo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LineDashStyle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.EmptyPointValue);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Appearance);
            this.panel1.Location = new System.Drawing.Point(432, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 288);
            this.panel1.TabIndex = 2;
            // 
            // LineSize
            // 
            this.LineSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LineSize.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.LineSize.Location = new System.Drawing.Point(168, 144);
            this.LineSize.Name = "LineSize";
            this.LineSize.Size = new System.Drawing.Size(121, 22);
            this.LineSize.TabIndex = 17;
            this.LineSize.SelectedIndexChanged += new System.EventHandler(this.ControlChange);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(32, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = " Line S&ize:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MarkerSize
            // 
            this.MarkerSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MarkerSize.Items.AddRange(new object[] {
            "5",
            "9",
            "14",
            "18"});
            this.MarkerSize.Location = new System.Drawing.Point(168, 216);
            this.MarkerSize.Name = "MarkerSize";
            this.MarkerSize.Size = new System.Drawing.Size(121, 22);
            this.MarkerSize.TabIndex = 15;
            this.MarkerSize.SelectedIndexChanged += new System.EventHandler(this.ControlChange);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(32, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Marker &Size:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MarkerColor
            // 
            this.MarkerColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MarkerColor.Items.AddRange(new object[] {
            "Red",
            "DarkGray",
            "Navy",
            "Blue",
            "Black"});
            this.MarkerColor.Location = new System.Drawing.Point(168, 248);
            this.MarkerColor.Name = "MarkerColor";
            this.MarkerColor.Size = new System.Drawing.Size(121, 22);
            this.MarkerColor.TabIndex = 13;
            this.MarkerColor.SelectedIndexChanged += new System.EventHandler(this.ControlChange);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(32, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "M&arker Color:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LineColor
            // 
            this.LineColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LineColor.Items.AddRange(new object[] {
            "DarkGray",
            "Red",
            "Navy",
            "Blue",
            "Black"});
            this.LineColor.Location = new System.Drawing.Point(168, 112);
            this.LineColor.Name = "LineColor";
            this.LineColor.Size = new System.Drawing.Size(121, 22);
            this.LineColor.TabIndex = 11;
            this.LineColor.SelectedIndexChanged += new System.EventHandler(this.ControlChange);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(32, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = " Line &Color:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MarkerStyleCombo
            // 
            this.MarkerStyleCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MarkerStyleCombo.Location = new System.Drawing.Point(168, 184);
            this.MarkerStyleCombo.Name = "MarkerStyleCombo";
            this.MarkerStyleCombo.Size = new System.Drawing.Size(121, 22);
            this.MarkerStyleCombo.TabIndex = 7;
            this.MarkerStyleCombo.SelectedIndexChanged += new System.EventHandler(this.ControlChange);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "&Marker Style:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LineDashStyle
            // 
            this.LineDashStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LineDashStyle.Location = new System.Drawing.Point(168, 80);
            this.LineDashStyle.Name = "LineDashStyle";
            this.LineDashStyle.Size = new System.Drawing.Size(121, 22);
            this.LineDashStyle.TabIndex = 5;
            this.LineDashStyle.SelectedIndexChanged += new System.EventHandler(this.ControlChange);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(32, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = " &Line Style:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Chart1
            // 
            this.Chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.Chart1.BackSecondaryColor = System.Drawing.Color.White;
            this.Chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.Chart1.BorderlineWidth = 2;
            this.Chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
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
            chartArea1.AxisX.LabelStyle.Format = "#";
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisX2.MajorGrid.Enabled = false;
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.BackColor = System.Drawing.Color.Gainsboro;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
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
            this.Chart1.Location = new System.Drawing.Point(16, 65);
            this.Chart1.Name = "Chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.BorderWidth = 2;
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Default";
            series1.Name = "Default";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.ShadowOffset = 1;
            this.Chart1.Series.Add(series1);
            this.Chart1.Size = new System.Drawing.Size(412, 296);
            this.Chart1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(702, 43);
            this.label1.TabIndex = 3;
            this.label1.Text = "The custom attribute EmptyPointValue determines if empty points are treated as ze" +
                "ros or as an average value between neighboring points.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EmptyPointAppearance
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Chart1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EmptyPointAppearance";
            this.Size = new System.Drawing.Size(728, 480);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		private void EmptyPointAppearance_Load(object sender, System.EventArgs e)
		{ 
		}

		private void ControlChange(object sender, System.EventArgs e)
		{

			if(!this.initializing )
			{
				string appeanceType = Appearance.SelectedItem.ToString();

				this.LineColor.Enabled = appeanceType.IndexOf("Line") != -1;
				this.LineSize.Enabled = this.LineColor.Enabled;
				this.LineDashStyle.Enabled = this.LineColor.Enabled;

				this.MarkerColor.Enabled = appeanceType.IndexOf("Marker") != -1;
				this.MarkerSize.Enabled = this.MarkerColor.Enabled;
				this.MarkerStyleCombo.Enabled = this.MarkerColor.Enabled;

				// Loop through all series
				foreach(Series series in Chart1.Series)
				{
					// Set empty points visual appearance attributes
					series.EmptyPointStyle.Color = Color.Gray;
					series.EmptyPointStyle.BorderWidth = 2;
					series.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash;
					series.EmptyPointStyle.MarkerSize = 7;
					series.EmptyPointStyle.MarkerStyle = MarkerStyle.Cross;
					series.EmptyPointStyle.MarkerBorderColor = Color.Black;
					series.EmptyPointStyle.MarkerColor = Color.LightGray;

					// Adjust visual appearance attributes depending on the user selection
					if(Appearance.SelectedItem.ToString() == "Transparent")
					{
						series.EmptyPointStyle.BorderWidth = 0;
						series.EmptyPointStyle.MarkerStyle = MarkerStyle.None;
					}
					else if(Appearance.SelectedItem.ToString() == "Line")
					{
						series.EmptyPointStyle.BorderDashStyle = (ChartDashStyle) Enum.Parse( typeof(ChartDashStyle), LineDashStyle.Text, true);
						series.EmptyPointStyle.BorderWidth = int.Parse( LineSize.Text);
						series.EmptyPointStyle.Color = Color.FromName( LineColor.Text);
						series.EmptyPointStyle.MarkerStyle = MarkerStyle.None;
					}
					else if(Appearance.SelectedItem.ToString() == "Marker")
					{
						series.EmptyPointStyle.BorderWidth = 0;
						series.EmptyPointStyle.MarkerSize = int.Parse(MarkerSize.Text);
						series.EmptyPointStyle.MarkerStyle = (MarkerStyle) Enum.Parse( typeof(MarkerStyle), MarkerStyleCombo.Text, true);
						series.EmptyPointStyle.MarkerColor = Color.FromName(MarkerColor.Text);
					}
					else if(Appearance.SelectedItem.ToString() == "Line and Marker")
					{
						series.EmptyPointStyle.BorderDashStyle = (ChartDashStyle) Enum.Parse( typeof(ChartDashStyle), LineDashStyle.Text, true);
						series.EmptyPointStyle.BorderWidth = int.Parse( LineSize.Text);
						series.EmptyPointStyle.Color = Color.FromName( LineColor.Text);
						series.EmptyPointStyle.MarkerSize = int.Parse(MarkerSize.Text);
						series.EmptyPointStyle.MarkerStyle = (MarkerStyle) Enum.Parse( typeof(MarkerStyle), MarkerStyleCombo.Text, true);
						series.EmptyPointStyle.MarkerColor = Color.FromName(MarkerColor.Text);
					}

					// Set empty points values to zero or average value of the neighbor points
					series["EmptyPointValue"] = EmptyPointValue.SelectedItem.ToString();
				}

			}
		}
	}
}
