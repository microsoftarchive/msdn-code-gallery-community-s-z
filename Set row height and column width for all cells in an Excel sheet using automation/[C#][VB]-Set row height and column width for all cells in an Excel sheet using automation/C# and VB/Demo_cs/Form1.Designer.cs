namespace Demo_cs
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NumericUpDownColumn = new System.Windows.Forms.NumericUpDown();
            this.Label2 = new System.Windows.Forms.Label();
            this.NumericUpDownRowHeight = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.setRowColumnButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownRowHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // NumericUpDownColumn
            // 
            this.NumericUpDownColumn.Location = new System.Drawing.Point(104, 94);
            this.NumericUpDownColumn.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericUpDownColumn.Name = "NumericUpDownColumn";
            this.NumericUpDownColumn.Size = new System.Drawing.Size(69, 20);
            this.NumericUpDownColumn.TabIndex = 9;
            this.NumericUpDownColumn.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(26, 96);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(70, 13);
            this.Label2.TabIndex = 8;
            this.Label2.Text = "Column width";
            // 
            // NumericUpDownRowHeight
            // 
            this.NumericUpDownRowHeight.Location = new System.Drawing.Point(104, 59);
            this.NumericUpDownRowHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericUpDownRowHeight.Name = "NumericUpDownRowHeight";
            this.NumericUpDownRowHeight.Size = new System.Drawing.Size(69, 20);
            this.NumericUpDownRowHeight.TabIndex = 7;
            this.NumericUpDownRowHeight.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(26, 61);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(61, 13);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Row height";
            // 
            // setRowColumnButton
            // 
            this.setRowColumnButton.Location = new System.Drawing.Point(20, 20);
            this.setRowColumnButton.Name = "setRowColumnButton";
            this.setRowColumnButton.Size = new System.Drawing.Size(197, 23);
            this.setRowColumnButton.TabIndex = 5;
            this.setRowColumnButton.Text = "Set row height and column width";
            this.setRowColumnButton.UseVisualStyleBackColor = true;
            this.setRowColumnButton.Click += new System.EventHandler(this.setRowColumnButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 134);
            this.Controls.Add(this.NumericUpDownColumn);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.NumericUpDownRowHeight);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.setRowColumnButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownRowHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.NumericUpDown NumericUpDownColumn;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.NumericUpDown NumericUpDownRowHeight;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button setRowColumnButton;
    }
}

