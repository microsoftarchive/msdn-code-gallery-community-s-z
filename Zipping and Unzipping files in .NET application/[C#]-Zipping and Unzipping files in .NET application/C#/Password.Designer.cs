namespace ArchiveManager
{
    partial class Password
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
            this.txtReenter = new System.Windows.Forms.TextBox();
            this.lblRetype = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboEncryption = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbPass
            // 
            this.grbPass.Controls.Add(this.txtReenter);
            this.grbPass.Controls.Add(this.lblRetype);
            this.grbPass.Controls.Add(this.txtPassword);
            this.grbPass.Controls.Add(this.lblPassword);
            this.grbPass.Location = new System.Drawing.Point(5, 2);
            this.grbPass.Name = "grbPass";
            this.grbPass.Size = new System.Drawing.Size(335, 68);
            this.grbPass.TabIndex = 0;
            this.grbPass.TabStop = false;
            // 
            // txtReenter
            // 
            this.txtReenter.Location = new System.Drawing.Point(107, 39);
            this.txtReenter.Name = "txtReenter";
            this.txtReenter.PasswordChar = '*';
            this.txtReenter.Size = new System.Drawing.Size(218, 20);
            this.txtReenter.TabIndex = 3;
            // 
            // lblRetype
            // 
            this.lblRetype.AutoSize = true;
            this.lblRetype.Location = new System.Drawing.Point(12, 42);
            this.lblRetype.Name = "lblRetype";
            this.lblRetype.Size = new System.Drawing.Size(48, 13);
            this.lblRetype.TabIndex = 2;
            this.lblRetype.Text = "Reenter:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(107, 13);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(218, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 16);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Password:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(17, 79);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(87, 13);
            this.Label1.TabIndex = 22;
            this.Label1.Text = "Encryption Type:";
            // 
            // cboEncryption
            // 
            this.cboEncryption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEncryption.Items.AddRange(new object[] {
            "PkzipClassic",
            "Aes128Bit",
            "Aes192Bit",
            "Aes256Bit"});
            this.cboEncryption.Location = new System.Drawing.Point(112, 76);
            this.cboEncryption.Name = "cboEncryption";
            this.cboEncryption.Size = new System.Drawing.Size(109, 21);
            this.cboEncryption.TabIndex = 21;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(184, 104);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(265, 104);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            // 
            // Password
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(348, 137);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cboEncryption);
            this.Controls.Add(this.grbPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password";
            this.grbPass.ResumeLayout(false);
            this.grbPass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPass;
        private System.Windows.Forms.TextBox txtReenter;
        private System.Windows.Forms.Label lblRetype;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cboEncryption;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}