namespace WindowsFormsApplication1
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
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cmdAddNewRow = new System.Windows.Forms.Button();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowTemplate.Height = 24;
            this.DataGridView1.Size = new System.Drawing.Size(323, 136);
            this.DataGridView1.TabIndex = 0;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.cmdAddNewRow);
            this.Panel1.Controls.Add(this.txtCompanyName);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 136);
            this.Panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(323, 49);
            this.Panel1.TabIndex = 1;
            // 
            // cmdAddNewRow
            // 
            this.cmdAddNewRow.Location = new System.Drawing.Point(151, 14);
            this.cmdAddNewRow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdAddNewRow.Name = "cmdAddNewRow";
            this.cmdAddNewRow.Size = new System.Drawing.Size(56, 19);
            this.cmdAddNewRow.TabIndex = 1;
            this.cmdAddNewRow.Text = "Add";
            this.cmdAddNewRow.UseVisualStyleBackColor = true;
            this.cmdAddNewRow.Click += new System.EventHandler(this.cmdAddNewRow_Click);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(9, 14);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(138, 20);
            this.txtCompanyName.TabIndex = 0;
            this.txtCompanyName.Text = "Carl\'s Burgers";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 185);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.Panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button cmdAddNewRow;
        internal System.Windows.Forms.TextBox txtCompanyName;
    }
}

