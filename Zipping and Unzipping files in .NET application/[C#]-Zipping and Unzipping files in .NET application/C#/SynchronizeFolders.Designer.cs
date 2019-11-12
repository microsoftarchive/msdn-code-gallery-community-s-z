namespace ArchiveManager
{
    partial class SynchronizeFolders
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSearchPattern = new System.Windows.Forms.TextBox();
            this.lblPattern = new System.Windows.Forms.Label();
            this.cbxComparisonType = new System.Windows.Forms.ComboBox();
            this.lblCompare = new System.Windows.Forms.Label();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.chkResumability = new System.Windows.Forms.CheckBox();
            this.txtSourceDir = new System.Windows.Forms.TextBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.btnSourceDir = new System.Windows.Forms.Button();
            this.chkUpdateTime = new System.Windows.Forms.CheckBox();
            this.chkUpdateAttributes = new System.Windows.Forms.CheckBox();
            this.chkDeleteFiles = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(194, 173);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "&OK";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(275, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "&Cancel";
            // 
            // txtSearchPattern
            // 
            this.txtSearchPattern.Location = new System.Drawing.Point(75, 12);
            this.txtSearchPattern.Name = "txtSearchPattern";
            this.txtSearchPattern.Size = new System.Drawing.Size(275, 20);
            this.txtSearchPattern.TabIndex = 1;
            // 
            // lblPattern
            // 
            this.lblPattern.Location = new System.Drawing.Point(5, 15);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(55, 13);
            this.lblPattern.TabIndex = 73;
            this.lblPattern.Text = "File Mask:";
            // 
            // cbxComparisonType
            // 
            this.cbxComparisonType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxComparisonType.FormattingEnabled = true;
            this.cbxComparisonType.Items.AddRange(new object[] {
            "Date Time",
            "File Content",
            "Name Only"});
            this.cbxComparisonType.Location = new System.Drawing.Point(75, 142);
            this.cbxComparisonType.Name = "cbxComparisonType";
            this.cbxComparisonType.Size = new System.Drawing.Size(176, 21);
            this.cbxComparisonType.TabIndex = 8;
            this.cbxComparisonType.SelectedIndexChanged += new System.EventHandler(this.cbxComparisonType_SelectedIndexChanged);
            // 
            // lblCompare
            // 
            this.lblCompare.Location = new System.Drawing.Point(8, 146);
            this.lblCompare.Name = "lblCompare";
            this.lblCompare.Size = new System.Drawing.Size(66, 13);
            this.lblCompare.TabIndex = 70;
            this.lblCompare.Text = "Compare by:";
            // 
            // chkRecursive
            // 
            this.chkRecursive.Location = new System.Drawing.Point(76, 64);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(74, 21);
            this.chkRecursive.TabIndex = 4;
            this.chkRecursive.Text = "Recursive";
            // 
            // chkResumability
            // 
            this.chkResumability.Location = new System.Drawing.Point(11, 169);
            this.chkResumability.Name = "chkResumability";
            this.chkResumability.Size = new System.Drawing.Size(139, 26);
            this.chkResumability.TabIndex = 9;
            this.chkResumability.Text = "Check for resumability";
            // 
            // txtSourceDir
            // 
            this.txtSourceDir.Location = new System.Drawing.Point(75, 38);
            this.txtSourceDir.Name = "txtSourceDir";
            this.txtSourceDir.Size = new System.Drawing.Size(245, 20);
            this.txtSourceDir.TabIndex = 2;
            // 
            // lblSource
            // 
            this.lblSource.Location = new System.Drawing.Point(5, 41);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(64, 13);
            this.lblSource.TabIndex = 75;
            this.lblSource.Text = "Source Dir:";
            // 
            // btnSourceDir
            // 
            this.btnSourceDir.Location = new System.Drawing.Point(324, 36);
            this.btnSourceDir.Name = "btnSourceDir";
            this.btnSourceDir.Size = new System.Drawing.Size(26, 23);
            this.btnSourceDir.TabIndex = 3;
            this.btnSourceDir.Text = "...";
            this.btnSourceDir.Click += new System.EventHandler(this.btnSourceDir_Click);
            // 
            // chkUpdateTime
            // 
            this.chkUpdateTime.Location = new System.Drawing.Point(177, 64);
            this.chkUpdateTime.Name = "chkUpdateTime";
            this.chkUpdateTime.Size = new System.Drawing.Size(143, 21);
            this.chkUpdateTime.TabIndex = 5;
            this.chkUpdateTime.Text = "Update Last Write Time";
            // 
            // chkUpdateAttributes
            // 
            this.chkUpdateAttributes.Location = new System.Drawing.Point(76, 91);
            this.chkUpdateAttributes.Name = "chkUpdateAttributes";
            this.chkUpdateAttributes.Size = new System.Drawing.Size(143, 21);
            this.chkUpdateAttributes.TabIndex = 6;
            this.chkUpdateAttributes.Text = "Update File Attributes";
            // 
            // chkDeleteFiles
            // 
            this.chkDeleteFiles.Location = new System.Drawing.Point(76, 117);
            this.chkDeleteFiles.Name = "chkDeleteFiles";
            this.chkDeleteFiles.Size = new System.Drawing.Size(143, 21);
            this.chkDeleteFiles.TabIndex = 7;
            this.chkDeleteFiles.Text = "Delete Files In Archive";
            // 
            // SynchronizeFolders
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(357, 205);
            this.Controls.Add(this.chkDeleteFiles);
            this.Controls.Add(this.chkUpdateAttributes);
            this.Controls.Add(this.chkUpdateTime);
            this.Controls.Add(this.btnSourceDir);
            this.Controls.Add(this.txtSourceDir);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.chkResumability);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.txtSearchPattern);
            this.Controls.Add(this.lblPattern);
            this.Controls.Add(this.cbxComparisonType);
            this.Controls.Add(this.lblCompare);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SynchronizeFolders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update/Synchronize files and directories";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSearchPattern;
        private System.Windows.Forms.Label lblPattern;
        private System.Windows.Forms.ComboBox cbxComparisonType;
        private System.Windows.Forms.Label lblCompare;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.CheckBox chkResumability;
        private System.Windows.Forms.TextBox txtSourceDir;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Button btnSourceDir;
        private System.Windows.Forms.CheckBox chkUpdateTime;
        private System.Windows.Forms.CheckBox chkUpdateAttributes;
        private System.Windows.Forms.CheckBox chkDeleteFiles;
    }
}