namespace ArchiveManager
{
    partial class AskPassword
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
            this.grbPass = new System.Windows.Forms.GroupBox();
            this.chkUpdateArchivePassword = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnSkip = new System.Windows.Forms.Button();
            this.grbPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbPass
            // 
            this.grbPass.Controls.Add(this.chkUpdateArchivePassword);
            this.grbPass.Controls.Add(this.txtPassword);
            this.grbPass.Controls.Add(this.lblPassword);
            this.grbPass.Location = new System.Drawing.Point(5, 35);
            this.grbPass.Name = "grbPass";
            this.grbPass.Size = new System.Drawing.Size(335, 69);
            this.grbPass.TabIndex = 0;
            this.grbPass.TabStop = false;
            // 
            // chkUpdateArchivePassword
            // 
            this.chkUpdateArchivePassword.AutoSize = true;
            this.chkUpdateArchivePassword.Location = new System.Drawing.Point(15, 43);
            this.chkUpdateArchivePassword.Name = "chkUpdateArchivePassword";
            this.chkUpdateArchivePassword.Size = new System.Drawing.Size(212, 17);
            this.chkUpdateArchivePassword.TabIndex = 26;
            this.chkUpdateArchivePassword.Text = "Use this password for the entire archive";
            this.chkUpdateArchivePassword.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(107, 17);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(218, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 20);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Password:";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(109, 111);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(265, 111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(5, 5);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(182, 13);
            this.lbl.TabIndex = 25;
            this.lbl.Text = "Enter password for the encrypted file:";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(5, 22);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(23, 13);
            this.lblFile.TabIndex = 26;
            this.lblFile.Text = "File";
            // 
            // btnSkip
            // 
            this.btnSkip.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSkip.Location = new System.Drawing.Point(186, 111);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 23);
            this.btnSkip.TabIndex = 27;
            this.btnSkip.Text = "Skip";
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // AskPassword
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(348, 145);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grbPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AskPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password";
            this.grbPass.ResumeLayout(false);
            this.grbPass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPass;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.CheckBox chkUpdateArchivePassword;
        private System.Windows.Forms.Button btnSkip;
    }
}