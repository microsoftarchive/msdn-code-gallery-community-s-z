namespace TablesAndCharts
{
    partial class TableAndChartPane
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListObjectCheckBox = new System.Windows.Forms.CheckBox();
            this.ListObjectHeaders = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GreenStyle = new System.Windows.Forms.RadioButton();
            this.GrayStyle = new System.Windows.Forms.RadioButton();
            this.OrangeStyle = new System.Windows.Forms.RadioButton();
            this.BlueStyle = new System.Windows.Forms.RadioButton();
            this.BlackStyle = new System.Windows.Forms.RadioButton();
            this.chartDataSourceComboBox = new System.Windows.Forms.ComboBox();
            this.ChartStyleComboBox = new System.Windows.Forms.ComboBox();
            this.ChartColorThemeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListObjectCheckBox
            // 
            this.ListObjectCheckBox.AutoSize = true;
            this.ListObjectCheckBox.Location = new System.Drawing.Point(16, 94);
            this.ListObjectCheckBox.Name = "ListObjectCheckBox";
            this.ListObjectCheckBox.Size = new System.Drawing.Size(205, 17);
            this.ListObjectCheckBox.TabIndex = 8;
            this.ListObjectCheckBox.Text = "Show price history for selected symbol";
            this.ListObjectCheckBox.Click += new System.EventHandler(this.ListObject_Check);
            // 
            // ListObjectHeaders
            // 
            this.ListObjectHeaders.CheckOnClick = true;
            this.ListObjectHeaders.FormattingEnabled = true;
            this.ListObjectHeaders.Location = new System.Drawing.Point(15, 31);
            this.ListObjectHeaders.Name = "ListObjectHeaders";
            this.ListObjectHeaders.Size = new System.Drawing.Size(166, 139);
            this.ListObjectHeaders.TabIndex = 11;
            this.ListObjectHeaders.Click += new System.EventHandler(this.ListObjectHeaders_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GreenStyle);
            this.groupBox1.Controls.Add(this.GrayStyle);
            this.groupBox1.Controls.Add(this.OrangeStyle);
            this.groupBox1.Controls.Add(this.BlueStyle);
            this.groupBox1.Controls.Add(this.BlackStyle);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(21, 331);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change the table color theme";
            // 
            // GreenStyle
            // 
            this.GreenStyle.AutoSize = true;
            this.GreenStyle.Location = new System.Drawing.Point(98, 44);
            this.GreenStyle.Name = "GreenStyle";
            this.GreenStyle.Size = new System.Drawing.Size(54, 17);
            this.GreenStyle.TabIndex = 4;
            this.GreenStyle.TabStop = true;
            this.GreenStyle.Text = "Green";
            this.GreenStyle.UseVisualStyleBackColor = true;
            this.GreenStyle.CheckedChanged += new System.EventHandler(this.Green_CheckedChanged);
            // 
            // GrayStyle
            // 
            this.GrayStyle.AutoSize = true;
            this.GrayStyle.Location = new System.Drawing.Point(98, 20);
            this.GrayStyle.Name = "GrayStyle";
            this.GrayStyle.Size = new System.Drawing.Size(47, 17);
            this.GrayStyle.TabIndex = 3;
            this.GrayStyle.TabStop = true;
            this.GrayStyle.Text = "Gray";
            this.GrayStyle.UseVisualStyleBackColor = true;
            this.GrayStyle.CheckedChanged += new System.EventHandler(this.Gray_CheckedChanged);
            // 
            // OrangeStyle
            // 
            this.OrangeStyle.AutoSize = true;
            this.OrangeStyle.Location = new System.Drawing.Point(7, 68);
            this.OrangeStyle.Name = "OrangeStyle";
            this.OrangeStyle.Size = new System.Drawing.Size(60, 17);
            this.OrangeStyle.TabIndex = 2;
            this.OrangeStyle.TabStop = true;
            this.OrangeStyle.Text = "Orange";
            this.OrangeStyle.UseVisualStyleBackColor = true;
            this.OrangeStyle.CheckedChanged += new System.EventHandler(this.OrangeStyle_CheckedChanged);
            // 
            // BlueStyle
            // 
            this.BlueStyle.AutoSize = true;
            this.BlueStyle.Location = new System.Drawing.Point(7, 44);
            this.BlueStyle.Name = "BlueStyle";
            this.BlueStyle.Size = new System.Drawing.Size(46, 17);
            this.BlueStyle.TabIndex = 1;
            this.BlueStyle.TabStop = true;
            this.BlueStyle.Text = "Blue";
            this.BlueStyle.UseVisualStyleBackColor = true;
            this.BlueStyle.CheckedChanged += new System.EventHandler(this.BlueStyle_CheckedChanged);
            // 
            // BlackStyle
            // 
            this.BlackStyle.AutoSize = true;
            this.BlackStyle.Location = new System.Drawing.Point(7, 20);
            this.BlackStyle.Name = "BlackStyle";
            this.BlackStyle.Size = new System.Drawing.Size(52, 17);
            this.BlackStyle.TabIndex = 0;
            this.BlackStyle.TabStop = true;
            this.BlackStyle.Text = "Black";
            this.BlackStyle.UseVisualStyleBackColor = true;
            this.BlackStyle.CheckedChanged += new System.EventHandler(this.BlackStyle_CheckedChanged);
            // 
            // chartDataSourceComboBox
            // 
            this.chartDataSourceComboBox.FormattingEnabled = true;
            this.chartDataSourceComboBox.Items.AddRange(new object[] {
            "Open",
            "High",
            "Low",
            "Close",
            "Volume",
            "Adj_Close"});
            this.chartDataSourceComboBox.Location = new System.Drawing.Point(15, 44);
            this.chartDataSourceComboBox.Name = "chartDataSourceComboBox";
            this.chartDataSourceComboBox.Size = new System.Drawing.Size(121, 21);
            this.chartDataSourceComboBox.TabIndex = 14;
            this.chartDataSourceComboBox.Text = "Close";
            this.chartDataSourceComboBox.SelectedIndexChanged += new System.EventHandler(this.chartDataSourceComboBox_SelectedIndexChanged);
            // 
            // ChartStyleComboBox
            // 
            this.ChartStyleComboBox.FormattingEnabled = true;
            this.ChartStyleComboBox.Items.AddRange(new object[] {
            "Line",
            "Column",
            "Area"});
            this.ChartStyleComboBox.Location = new System.Drawing.Point(15, 96);
            this.ChartStyleComboBox.Name = "ChartStyleComboBox";
            this.ChartStyleComboBox.Size = new System.Drawing.Size(121, 21);
            this.ChartStyleComboBox.TabIndex = 15;
            this.ChartStyleComboBox.Text = "Line";
            this.ChartStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.ChartStyleComboBox_SelectedIndexChanged);
            // 
            // ChartColorThemeComboBox
            // 
            this.ChartColorThemeComboBox.FormattingEnabled = true;
            this.ChartColorThemeComboBox.Items.AddRange(new object[] {
            "Gray background",
            "Blue background",
            "White background"});
            this.ChartColorThemeComboBox.Location = new System.Drawing.Point(15, 154);
            this.ChartColorThemeComboBox.Name = "ChartColorThemeComboBox";
            this.ChartColorThemeComboBox.Size = new System.Drawing.Size(121, 21);
            this.ChartColorThemeComboBox.TabIndex = 16;
            this.ChartColorThemeComboBox.Text = "White background";
            this.ChartColorThemeComboBox.SelectedIndexChanged += new System.EventHandler(this.ChartColorThemeComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Choose Starting Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 49);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ListObjectHeaders);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(21, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 177);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Show / hide table columns";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.chartDataSourceComboBox);
            this.groupBox3.Controls.Add(this.ChartStyleComboBox);
            this.groupBox3.Controls.Add(this.ChartColorThemeComboBox);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(21, 448);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 195);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Change chart settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Color theme";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Style";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Data source";
            // 
            // TableAndChartPane
            // 
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ListObjectCheckBox);
            this.Name = "TableAndChartPane";
            this.Size = new System.Drawing.Size(284, 664);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ChartColorThemeComboBox;
        private System.Windows.Forms.ComboBox ChartStyleComboBox;
        private System.Windows.Forms.ComboBox chartDataSourceComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton GreenStyle;
        private System.Windows.Forms.RadioButton GrayStyle;
        private System.Windows.Forms.RadioButton OrangeStyle;
        private System.Windows.Forms.RadioButton BlueStyle;
        private System.Windows.Forms.RadioButton BlackStyle;
        private System.Windows.Forms.CheckedListBox ListObjectHeaders;
        internal System.Windows.Forms.CheckBox ListObjectCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
