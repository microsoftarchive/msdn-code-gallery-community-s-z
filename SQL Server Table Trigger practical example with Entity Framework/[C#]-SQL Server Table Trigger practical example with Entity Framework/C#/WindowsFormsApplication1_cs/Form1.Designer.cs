namespace WindowsFormsApplication1_cs
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.updateCurrentButton = new System.Windows.Forms.Button();
            this.changeStatusButton = new System.Windows.Forms.Button();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CompanyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderApprovalDateTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderStatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1StatusGrouped = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1StatusGrouped);
            this.panel1.Controls.Add(this.updateCurrentButton);
            this.panel1.Controls.Add(this.changeStatusButton);
            this.panel1.Controls.Add(this.statusComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 157);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 64);
            this.panel1.TabIndex = 1;
            // 
            // updateCurrentButton
            // 
            this.updateCurrentButton.Location = new System.Drawing.Point(276, 12);
            this.updateCurrentButton.Name = "updateCurrentButton";
            this.updateCurrentButton.Size = new System.Drawing.Size(111, 40);
            this.updateCurrentButton.TabIndex = 4;
            this.updateCurrentButton.Text = "Edit Current";
            this.updateCurrentButton.UseVisualStyleBackColor = true;
            this.updateCurrentButton.Click += new System.EventHandler(this.updateCurrentButton_Click);
            // 
            // changeStatusButton
            // 
            this.changeStatusButton.Location = new System.Drawing.Point(177, 23);
            this.changeStatusButton.Name = "changeStatusButton";
            this.changeStatusButton.Size = new System.Drawing.Size(75, 23);
            this.changeStatusButton.TabIndex = 2;
            this.changeStatusButton.Text = "Set";
            this.changeStatusButton.UseVisualStyleBackColor = true;
            this.changeStatusButton.Click += new System.EventHandler(this.changeStatusButton_Click);
            // 
            // statusComboBox
            // 
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new System.Drawing.Point(18, 23);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(121, 21);
            this.statusComboBox.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyNameColumn,
            this.FirstNameColumn,
            this.LastNameColumn,
            this.OrderDateColumn,
            this.OrderApprovalDateTimeColumn,
            this.OrderStatusColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(545, 157);
            this.dataGridView1.TabIndex = 0;
            // 
            // CompanyNameColumn
            // 
            this.CompanyNameColumn.DataPropertyName = "CompanyName";
            this.CompanyNameColumn.HeaderText = "Company";
            this.CompanyNameColumn.Name = "CompanyNameColumn";
            // 
            // FirstNameColumn
            // 
            this.FirstNameColumn.DataPropertyName = "FirstName";
            this.FirstNameColumn.HeaderText = "First";
            this.FirstNameColumn.Name = "FirstNameColumn";
            // 
            // LastNameColumn
            // 
            this.LastNameColumn.DataPropertyName = "LastName";
            this.LastNameColumn.HeaderText = "Last";
            this.LastNameColumn.Name = "LastNameColumn";
            // 
            // OrderDateColumn
            // 
            this.OrderDateColumn.DataPropertyName = "OrderDate";
            this.OrderDateColumn.HeaderText = "Ordered on";
            this.OrderDateColumn.Name = "OrderDateColumn";
            this.OrderDateColumn.ReadOnly = true;
            // 
            // OrderApprovalDateTimeColumn
            // 
            this.OrderApprovalDateTimeColumn.DataPropertyName = "OrderApprovalDateTime";
            this.OrderApprovalDateTimeColumn.HeaderText = "Approved on";
            this.OrderApprovalDateTimeColumn.Name = "OrderApprovalDateTimeColumn";
            // 
            // OrderStatusColumn
            // 
            this.OrderStatusColumn.DataPropertyName = "OrderStatus";
            this.OrderStatusColumn.HeaderText = "Status";
            this.OrderStatusColumn.Name = "OrderStatusColumn";
            this.OrderStatusColumn.ReadOnly = true;
            // 
            // button1StatusGrouped
            // 
            this.button1StatusGrouped.Location = new System.Drawing.Point(458, 23);
            this.button1StatusGrouped.Name = "button1StatusGrouped";
            this.button1StatusGrouped.Size = new System.Drawing.Size(75, 23);
            this.button1StatusGrouped.TabIndex = 5;
            this.button1StatusGrouped.Text = "Grouped";
            this.button1StatusGrouped.UseVisualStyleBackColor = true;
            this.button1StatusGrouped.Click += new System.EventHandler(this.button1StatusGrouped_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "->";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 221);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderApprovalDateTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderStatusColumn;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Button changeStatusButton;
        private System.Windows.Forms.Button updateCurrentButton;
        private System.Windows.Forms.Button button1StatusGrouped;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

