namespace FullScreenForm_cs
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cmdCloseForm = new System.Windows.Forms.Button();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.cmdDetect = new System.Windows.Forms.Button();
            this.chkTaskbar = new System.Windows.Forms.CheckBox();
            this.cmdShowChildForm = new System.Windows.Forms.Button();
            this.cmdChange = new System.Windows.Forms.Button();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.cmdCloseForm);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 297);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(359, 39);
            this.Panel1.TabIndex = 6;
            // 
            // cmdCloseForm
            // 
            this.cmdCloseForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCloseForm.Location = new System.Drawing.Point(281, 13);
            this.cmdCloseForm.Name = "cmdCloseForm";
            this.cmdCloseForm.Size = new System.Drawing.Size(75, 23);
            this.cmdCloseForm.TabIndex = 0;
            this.cmdCloseForm.Text = "E&xit";
            this.cmdCloseForm.UseVisualStyleBackColor = true;
            this.cmdCloseForm.Click += new System.EventHandler(this.cmdCloseForm_Click);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Location = new System.Drawing.Point(0, 336);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(359, 22);
            this.StatusStrip1.TabIndex = 7;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ListBox1
            // 
            this.ListBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(0, 228);
            this.ListBox1.Margin = new System.Windows.Forms.Padding(2);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(359, 69);
            this.ListBox1.TabIndex = 5;
            // 
            // cmdDetect
            // 
            this.cmdDetect.Location = new System.Drawing.Point(12, 71);
            this.cmdDetect.Name = "cmdDetect";
            this.cmdDetect.Size = new System.Drawing.Size(75, 23);
            this.cmdDetect.TabIndex = 3;
            this.cmdDetect.Text = "Detect";
            this.cmdDetect.UseVisualStyleBackColor = true;
            this.cmdDetect.Click += new System.EventHandler(this.cmdDetect_Click);
            // 
            // chkTaskbar
            // 
            this.chkTaskbar.AutoSize = true;
            this.chkTaskbar.Checked = true;
            this.chkTaskbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTaskbar.Location = new System.Drawing.Point(93, 17);
            this.chkTaskbar.Name = "chkTaskbar";
            this.chkTaskbar.Size = new System.Drawing.Size(65, 17);
            this.chkTaskbar.TabIndex = 1;
            this.chkTaskbar.Text = "Taskbar";
            this.chkTaskbar.UseVisualStyleBackColor = true;
            // 
            // cmdShowChildForm
            // 
            this.cmdShowChildForm.Location = new System.Drawing.Point(12, 42);
            this.cmdShowChildForm.Name = "cmdShowChildForm";
            this.cmdShowChildForm.Size = new System.Drawing.Size(75, 23);
            this.cmdShowChildForm.TabIndex = 2;
            this.cmdShowChildForm.Text = "Show form";
            this.cmdShowChildForm.UseVisualStyleBackColor = true;
            this.cmdShowChildForm.Click += new System.EventHandler(this.cmdShowChildForm_Click);
            // 
            // cmdChange
            // 
            this.cmdChange.Location = new System.Drawing.Point(12, 13);
            this.cmdChange.Name = "cmdChange";
            this.cmdChange.Size = new System.Drawing.Size(75, 23);
            this.cmdChange.TabIndex = 0;
            this.cmdChange.Text = "Full";
            this.cmdChange.UseVisualStyleBackColor = true;
            this.cmdChange.Click += new System.EventHandler(this.cmdChange_Click);
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Checked = global::FullScreenForm_cs.Properties.Settings.Default.MainFormFullScreen;
            this.chkRemember.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::FullScreenForm_cs.Properties.Settings.Default, "MainFormFullScreen", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkRemember.Location = new System.Drawing.Point(12, 100);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(128, 17);
            this.chkRemember.TabIndex = 4;
            this.chkRemember.Text = "Remember full screen";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 358);
            this.Controls.Add(this.chkRemember);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.cmdDetect);
            this.Controls.Add(this.chkTaskbar);
            this.Controls.Add(this.cmdShowChildForm);
            this.Controls.Add(this.cmdChange);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button cmdCloseForm;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ListBox ListBox1;
        internal System.Windows.Forms.Button cmdDetect;
        internal System.Windows.Forms.CheckBox chkTaskbar;
        internal System.Windows.Forms.Button cmdShowChildForm;
        internal System.Windows.Forms.Button cmdChange;
        private System.Windows.Forms.CheckBox chkRemember;
    }
}

