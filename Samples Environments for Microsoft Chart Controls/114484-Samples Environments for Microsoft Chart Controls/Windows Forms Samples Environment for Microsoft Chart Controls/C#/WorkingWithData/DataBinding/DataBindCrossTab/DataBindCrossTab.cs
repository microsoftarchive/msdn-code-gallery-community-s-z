using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.OleDb;

namespace WinFormsChartSamples
{
	/// <summary>
	/// Summary description for AxisAppearance.
	/// </summary>
	public class DataBindCrosstab : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataVisualization.Charting.Chart Chart1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxGroupBy;
		private System.Windows.Forms.DataGrid dataGrid;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DataBindCrosstab()
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
			this.label9 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dataGrid = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.comboBoxGroupBy = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
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
			this.label9.Size = new System.Drawing.Size(702, 40);
			this.label9.TabIndex = 0;
			this.label9.Text = "This sample demonstrates how to bind to a data source by grouping values in a ser" +
				"ies, using unique values from a specified field.";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.dataGrid,
																				 this.comboBoxGroupBy,
																				 this.label1,
																				 this.label15});
			this.panel1.Location = new System.Drawing.Point(432, 64);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(292, 288);
			this.panel1.TabIndex = 2;
			// 
			// dataGrid
			// 
			this.dataGrid.BackgroundColor = System.Drawing.Color.White;
			this.dataGrid.CaptionText = "Original Data:";
			this.dataGrid.DataMember = "";
			this.dataGrid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid.Location = new System.Drawing.Point(32, 40);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.Size = new System.Drawing.Size(248, 206);
			this.dataGrid.TabIndex = 2;
			this.dataGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								 this.dataGridTableStyle1});
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4});
			this.dataGridTableStyle1.HeaderFont = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			this.dataGridTableStyle1.PreferredColumnWidth = 50;
			this.dataGridTableStyle1.RowHeadersVisible = false;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Name";
			this.dataGridTextBoxColumn1.MappingName = "Name";
			this.dataGridTextBoxColumn1.Width = 50;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Year";
			this.dataGridTextBoxColumn2.MappingName = "Year";
			this.dataGridTextBoxColumn2.Width = 40;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "#0.00";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Sales";
			this.dataGridTextBoxColumn3.MappingName = "Sales";
			this.dataGridTextBoxColumn3.Width = 70;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "#0.00";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "Commission";
			this.dataGridTextBoxColumn4.MappingName = "Commissions";
			this.dataGridTextBoxColumn4.Width = 84;
			// 
			// comboBoxGroupBy
			// 
			this.comboBoxGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxGroupBy.Items.AddRange(new object[] {
																 "Name",
																 "Year"});
			this.comboBoxGroupBy.Location = new System.Drawing.Point(168, 8);
			this.comboBoxGroupBy.Name = "comboBoxGroupBy";
			this.comboBoxGroupBy.Size = new System.Drawing.Size(112, 22);
			this.comboBoxGroupBy.TabIndex = 1;
			this.comboBoxGroupBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroupBy_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Group &Series By:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.Chart1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(243)), ((System.Byte)(223)), ((System.Byte)(193)));
			this.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.Chart1.BorderlineColor = System.Drawing.Color.FromArgb(((System.Byte)(181)), ((System.Byte)(64)), ((System.Byte)(1)));
			this.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			this.Chart1.BorderlineWidth = 2;
			this.Chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
			chartArea1.Area3DStyle.IsClustered = true;
			chartArea1.Area3DStyle.Perspective = 10;
			chartArea1.Area3DStyle.IsRightAngleAxes = false;
			chartArea1.Area3DStyle.WallWidth = 0;
			chartArea1.Area3DStyle.Inclination = 15;
			chartArea1.Area3DStyle.Rotation = 10;
			chartArea1.AxisX.LabelAutoFitStyle = (((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap);
			chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
			chartArea1.AxisX.LabelStyle.Interval = 1;
			chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisX.MajorGrid.Interval = 0;
			chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisX.MajorTickMark.Enabled = false;
			chartArea1.AxisX.MajorTickMark.Interval = 1;
			chartArea1.AxisY.LabelAutoFitStyle = (((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
				| System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap);
			chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
			chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisY.MajorGrid.Interval = 0;
			chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.AxisY.MajorTickMark.Enabled = false;
			chartArea1.AxisY.MajorTickMark.Interval = 1;
			chartArea1.AxisY.IsStartedFromZero = false;
			chartArea1.BackColor = System.Drawing.Color.Transparent;
			chartArea1.BackSecondaryColor = System.Drawing.Color.White;
			chartArea1.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea1.Name = "Default";
			chartArea1.Position.Auto = false;
			chartArea1.Position.Height = 73F;
			chartArea1.Position.Width = 89.43796F;
			chartArea1.Position.X = 4.824818F;
			chartArea1.Position.Y = 10F;
			chartArea1.ShadowColor = System.Drawing.Color.Transparent;
			this.Chart1.ChartAreas.Add(chartArea1);
			legend1.Alignment = System.Drawing.StringAlignment.Center;
			legend1.IsTextAutoFit = false;
			legend1.BackColor = System.Drawing.Color.Transparent;
			legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
			legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
			legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
			legend1.Name = "Default";
			this.Chart1.Legends.Add(legend1);
			this.Chart1.Location = new System.Drawing.Point(16, 56);
			this.Chart1.Name = "Chart1";
			this.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
			this.Chart1.Size = new System.Drawing.Size(412, 296);
			this.Chart1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.label2.Font = new System.Drawing.Font("Verdana", 11F);
			this.label2.Location = new System.Drawing.Point(24, 360);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(702, 34);
			this.label2.TabIndex = 3;
			this.label2.Text = "Series are created automatically, based on the number of unique values in the gro" +
				"uping field.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DataBindCrosstab
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label2,
																		  this.Chart1,
																		  this.panel1,
																		  this.label9});
			this.Font = new System.Drawing.Font("Verdana", 9F);
			this.Name = "DataBindCrosstab";
			this.Size = new System.Drawing.Size(728, 480);
			this.Load += new System.EventHandler(this.ArrayBinding_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void ArrayBinding_Load(object sender, System.EventArgs e)
		{
			comboBoxGroupBy.SelectedIndex = 0;
		}

		private void comboBoxGroupBy_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataBind();
		}

		private void DataBind()
		{
			try
			{

				// Remove all series
				Chart1.Series.Clear();

				// Access database
				System.Windows.Forms.DataVisualization.Charting.Utilities.SampleMain.MainForm mainForm = (System.Windows.Forms.DataVisualization.Charting.Utilities.SampleMain.MainForm)this.ParentForm;
                string fileNameString = mainForm.applicationPath + "\\data\\chartdata.mdb";
						
				// initialize a connection string	
				string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileNameString;
			
				// define the database query	
				string mySelectQuery="SELECT * FROM REPSALES;";

				// create a database connection object using the connection string	
				OleDbConnection myConnection = new OleDbConnection(myConnectionString);
			
				// create a database command on the connection using query	
				OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);
			
				// open the connection	
				myCommand.Connection.Open();

				// Bind grid to the original data 
				OleDbDataAdapter custDA = new OleDbDataAdapter();
				custDA.SelectCommand = myCommand;
				DataSet custDS = new DataSet();
				custDA.Fill(custDS, "Customers");
				this.dataGrid.SetDataBinding(custDS, "Customers");
				this.dataGrid.TableStyles[0].MappingName = "Customers";

				// create a database reader	
				OleDbDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			
				// data bind chart to a table where all rows are grouped by the "Name" column
				Chart1.DataBindCrossTable(
					myReader,
					(comboBoxGroupBy.SelectedIndex == 0) ? "Name" : "Year",
					(comboBoxGroupBy.SelectedIndex == 0) ? "Year" : "Name",
					"Sales", 
					"Label=Commissions{C0}");

				// close the reader and the connection
				myReader.Close();
				myConnection.Close();

				// Set series appearance
				MarkerStyle marker = MarkerStyle.Star4;
				foreach(Series ser in Chart1.Series)
				{
					ser.ShadowOffset = 1;
					ser.BorderWidth = 3;
					ser.ChartType = SeriesChartType.Line;
					ser.MarkerSize = 12;
					ser.MarkerStyle = marker;
					ser.MarkerBorderColor = Color.FromArgb(64, 64, 64);
					ser.Font = new Font("Trebuchet MS", 8, FontStyle.Bold);
					marker++;
				}	
			}
			catch(Exception )
			{

			}
		
		}

	}
}
