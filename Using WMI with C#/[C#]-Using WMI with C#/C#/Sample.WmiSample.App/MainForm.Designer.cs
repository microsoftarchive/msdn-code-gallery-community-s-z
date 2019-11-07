namespace Sample.WmiSample.App
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUseCurrentUser = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkUseCurrentComputer = new System.Windows.Forms.CheckBox();
            this.txtComputerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetServices = new System.Windows.Forms.Button();
            this.lstServices = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblErrors = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUseCurrentUser);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credentials";
            // 
            // chkUseCurrentUser
            // 
            this.chkUseCurrentUser.AutoSize = true;
            this.chkUseCurrentUser.Location = new System.Drawing.Point(10, 81);
            this.chkUseCurrentUser.Name = "chkUseCurrentUser";
            this.chkUseCurrentUser.Size = new System.Drawing.Size(150, 17);
            this.chkUseCurrentUser.TabIndex = 4;
            this.chkUseCurrentUser.Text = "Use current logged in user";
            this.chkUseCurrentUser.UseVisualStyleBackColor = true;
            this.chkUseCurrentUser.CheckedChanged += new System.EventHandler(this.ChangeCredentialState);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(68, 46);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(133, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(68, 20);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(133, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkUseCurrentComputer);
            this.groupBox2.Controls.Add(this.txtComputerName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Computer Details";
            // 
            // chkUseCurrentComputer
            // 
            this.chkUseCurrentComputer.AutoSize = true;
            this.chkUseCurrentComputer.Location = new System.Drawing.Point(9, 58);
            this.chkUseCurrentComputer.Name = "chkUseCurrentComputer";
            this.chkUseCurrentComputer.Size = new System.Drawing.Size(128, 17);
            this.chkUseCurrentComputer.TabIndex = 6;
            this.chkUseCurrentComputer.Text = "Use current computer";
            this.chkUseCurrentComputer.UseVisualStyleBackColor = true;
            this.chkUseCurrentComputer.CheckedChanged += new System.EventHandler(this.ChangeComputerState);
            // 
            // txtComputerName
            // 
            this.txtComputerName.Location = new System.Drawing.Point(68, 23);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.Size = new System.Drawing.Size(133, 20);
            this.txtComputerName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Computer";
            // 
            // btnGetServices
            // 
            this.btnGetServices.Location = new System.Drawing.Point(12, 235);
            this.btnGetServices.Name = "btnGetServices";
            this.btnGetServices.Size = new System.Drawing.Size(218, 30);
            this.btnGetServices.TabIndex = 2;
            this.btnGetServices.Text = "Get services";
            this.btnGetServices.UseVisualStyleBackColor = true;
            this.btnGetServices.Click += new System.EventHandler(this.GetServicesClick);
            // 
            // lstServices
            // 
            this.lstServices.FormattingEnabled = true;
            this.lstServices.Location = new System.Drawing.Point(237, 13);
            this.lstServices.Name = "lstServices";
            this.lstServices.Size = new System.Drawing.Size(835, 251);
            this.lstServices.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblErrors);
            this.groupBox3.Location = new System.Drawing.Point(12, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1060, 89);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Errors";
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Location = new System.Drawing.Point(7, 16);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(0, 13);
            this.lblErrors.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 367);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lstServices);
            this.Controls.Add(this.btnGetServices);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "WMI Sample";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkUseCurrentUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkUseCurrentComputer;
        private System.Windows.Forms.TextBox txtComputerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetServices;
        private System.Windows.Forms.ListBox lstServices;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblErrors;
    }
}

