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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.RoomNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckInColumn = new CalendarColumn();
            this.TimeColumn = new TimeColumn();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cmdShowRow = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new CalendarColumn();
            this.timeColumn1 = new TimeColumn();
            this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomNumberColumn,
            this.CheckInColumn,
            this.TimeColumn});
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowTemplate.Height = 24;
            this.DataGridView1.Size = new System.Drawing.Size(373, 168);
            this.DataGridView1.TabIndex = 2;
            // 
            // RoomNumberColumn
            // 
            this.RoomNumberColumn.DataPropertyName = "RoomNumber";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RoomNumberColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.RoomNumberColumn.HeaderText = "Room";
            this.RoomNumberColumn.Name = "RoomNumberColumn";
            // 
            // CheckInColumn
            // 
            this.CheckInColumn.DataPropertyName = "CheckIn";
            this.CheckInColumn.HeaderText = "Check in Date";
            this.CheckInColumn.Name = "CheckInColumn";
            // 
            // TimeColumn
            // 
            this.TimeColumn.DataPropertyName = "CheckOut";
            this.TimeColumn.HeaderText = "Check out time";
            this.TimeColumn.Name = "TimeColumn";
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.cmdShowRow);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.cmdClose);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 168);
            this.Panel1.Margin = new System.Windows.Forms.Padding(2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(373, 50);
            this.Panel1.TabIndex = 3;
            // 
            // cmdShowRow
            // 
            this.cmdShowRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdShowRow.Location = new System.Drawing.Point(197, 12);
            this.cmdShowRow.Margin = new System.Windows.Forms.Padding(2);
            this.cmdShowRow.Name = "cmdShowRow";
            this.cmdShowRow.Size = new System.Drawing.Size(70, 28);
            this.cmdShowRow.TabIndex = 1;
            this.cmdShowRow.Text = "Show row";
            this.cmdShowRow.UseVisualStyleBackColor = true;
            this.cmdShowRow.Click += new System.EventHandler(this.cmdShowRow_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 20);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(13, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "0";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Location = new System.Drawing.Point(281, 12);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(2);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(70, 28);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // DataGridViewTextBoxColumn1
            // 
            this.DataGridViewTextBoxColumn1.DataPropertyName = "RoomNumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewTextBoxColumn1.HeaderText = "Room";
            this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.DataPropertyName = "CheckIn";
            this.calendarColumn1.HeaderText = "Check in Date";
            this.calendarColumn1.Name = "calendarColumn1";
            // 
            // timeColumn1
            // 
            this.timeColumn1.DataPropertyName = "CheckOut";
            this.timeColumn1.HeaderText = "Check out time";
            this.timeColumn1.Name = "timeColumn1";
            // 
            // DataGridViewTextBoxColumn2
            // 
            this.DataGridViewTextBoxColumn2.DataPropertyName = "CheckIn";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewTextBoxColumn2.HeaderText = "Check in Date";
            this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
            this.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 218);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button cmdShowRow;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNumberColumn;
        private CalendarColumn CheckInColumn;
        private TimeColumn TimeColumn;
        private CalendarColumn calendarColumn1;
        private TimeColumn timeColumn1;
    }
}

