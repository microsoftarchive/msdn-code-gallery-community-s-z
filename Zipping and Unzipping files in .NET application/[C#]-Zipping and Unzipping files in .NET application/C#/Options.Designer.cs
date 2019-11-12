namespace ArchiveManager
{
    partial class Options
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
            this.lblLevel = new System.Windows.Forms.Label();
            this.cbxLevel = new System.Windows.Forms.ComboBox();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxPath = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCompressionMethod = new System.Windows.Forms.ComboBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(6, 9);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(99, 13);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "Compression Level:";
            // 
            // cbxLevel
            // 
            this.cbxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel.FormattingEnabled = true;
            this.cbxLevel.Items.AddRange(new object[] {
            "0 (Fastest)",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9 (Optimized for File Size)"});
            this.cbxLevel.Location = new System.Drawing.Point(114, 6);
            this.cbxLevel.Name = "cbxLevel";
            this.cbxLevel.Size = new System.Drawing.Size(183, 21);
            this.cbxLevel.TabIndex = 1;
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Location = new System.Drawing.Point(114, 66);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(74, 17);
            this.chkRecursive.TabIndex = 3;
            this.chkRecursive.Text = "Recursive";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(141, 139);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(222, 139);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            // 
            // cbxPath
            // 
            this.cbxPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPath.FormattingEnabled = true;
            this.cbxPath.Items.AddRange(new object[] {
            "Do not store paths",
            "Store relative paths",
            "Store full paths",
            "Store full paths incl. the driver letter"});
            this.cbxPath.Location = new System.Drawing.Point(114, 88);
            this.cbxPath.Name = "cbxPath";
            this.cbxPath.Size = new System.Drawing.Size(183, 21);
            this.cbxPath.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Path Storing Mode:";
            // 
            // cbxCompressionMethod
            // 
            this.cbxCompressionMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCompressionMethod.FormattingEnabled = true;
            this.cbxCompressionMethod.Items.AddRange(new object[] {
            "None",
            "Deflate",
            "BZIP2",
            "PPMd"});
            this.cbxCompressionMethod.Location = new System.Drawing.Point(114, 33);
            this.cbxCompressionMethod.Name = "cbxCompressionMethod";
            this.cbxCompressionMethod.Size = new System.Drawing.Size(183, 21);
            this.cbxCompressionMethod.TabIndex = 2;
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(6, 36);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(109, 13);
            this.lblMethod.TabIndex = 9;
            this.lblMethod.Text = "Compression Method:";
            // 
            // Options
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(307, 174);
            this.Controls.Add(this.cbxCompressionMethod);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.cbxPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.cbxLevel);
            this.Controls.Add(this.lblLevel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZIP Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.ComboBox cbxLevel;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbxPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCompressionMethod;
        private System.Windows.Forms.Label lblMethod;
    }
}