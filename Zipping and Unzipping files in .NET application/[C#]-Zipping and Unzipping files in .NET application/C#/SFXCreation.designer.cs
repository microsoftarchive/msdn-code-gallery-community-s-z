namespace ArchiveManager
{
    partial class SFXCreation
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
            this.lbl = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lblSfx = new System.Windows.Forms.Label();
            this.txtSfx = new System.Windows.Forms.TextBox();
            this.btnBrowseSfx = new System.Windows.Forms.Button();
            this.btnStubFile = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(7, 21);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(83, 16);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "SFX Stub File:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(107, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(204, 20);
            this.txtName.TabIndex = 1;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.lblSfx);
            this.groupBox.Controls.Add(this.txtSfx);
            this.groupBox.Controls.Add(this.btnBrowseSfx);
            this.groupBox.Controls.Add(this.btnStubFile);
            this.groupBox.Controls.Add(this.lbl);
            this.groupBox.Location = new System.Drawing.Point(6, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(342, 81);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // lblSfx
            // 
            this.lblSfx.Location = new System.Drawing.Point(7, 49);
            this.lblSfx.Name = "lblSfx";
            this.lblSfx.Size = new System.Drawing.Size(88, 16);
            this.lblSfx.TabIndex = 5;
            this.lblSfx.Text = "SFX Output File:";
            // 
            // txtSfx
            // 
            this.txtSfx.Location = new System.Drawing.Point(101, 46);
            this.txtSfx.Name = "txtSfx";
            this.txtSfx.Size = new System.Drawing.Size(204, 20);
            this.txtSfx.TabIndex = 3;
            // 
            // btnBrowseSfx
            // 
            this.btnBrowseSfx.Location = new System.Drawing.Point(308, 44);
            this.btnBrowseSfx.Name = "btnBrowseSfx";
            this.btnBrowseSfx.Size = new System.Drawing.Size(25, 23);
            this.btnBrowseSfx.TabIndex = 4;
            this.btnBrowseSfx.Text = "...";
            this.btnBrowseSfx.Click += new System.EventHandler(this.btnBrowseSfx_Click);
            // 
            // btnStubFile
            // 
            this.btnStubFile.Location = new System.Drawing.Point(308, 17);
            this.btnStubFile.Name = "btnStubFile";
            this.btnStubFile.Size = new System.Drawing.Size(25, 23);
            this.btnStubFile.TabIndex = 2;
            this.btnStubFile.Text = "...";
            this.btnStubFile.Click += new System.EventHandler(this.btnStubFile_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(193, 90);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "&OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(273, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            // 
            // SFXCreation
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(355, 121);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFXCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create SFX";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStubFile;
        private System.Windows.Forms.Label lblSfx;
        private System.Windows.Forms.TextBox txtSfx;
        private System.Windows.Forms.Button btnBrowseSfx;
    }
}