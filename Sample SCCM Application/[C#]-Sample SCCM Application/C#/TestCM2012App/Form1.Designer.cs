namespace TestCM2012App
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMSILocation = new System.Windows.Forms.TextBox();
            this.btnCreateMSI = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSCCMApplicationName = new System.Windows.Forms.TextBox();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.txtSoftwareVersion = new System.Windows.Forms.TextBox();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCreateInstallerandDt = new System.Windows.Forms.Button();
            this.txtInstallCommandLine = new System.Windows.Forms.TextBox();
            this.txtUninstallCommandLine = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSupersedeApplication = new System.Windows.Forms.Button();
            this.cmbSuperseded = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbDependency = new System.Windows.Forms.ComboBox();
            this.btnAddDependency = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmbConditions = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRequirementValue = new System.Windows.Forms.TextBox();
            this.btnAddRequirement = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnDistribute = new System.Windows.Forms.Button();
            this.cmbDPGNames = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cmbCollection = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnDeploy = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtProductCode);
            this.groupBox1.Controls.Add(this.txtManufacturer);
            this.groupBox1.Controls.Add(this.txtSoftwareVersion);
            this.groupBox1.Controls.Add(this.txtAppName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMSILocation);
            this.groupBox1.Controls.Add(this.btnCreateMSI);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 160);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Read MSI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "MSI Location";
            // 
            // txtMSILocation
            // 
            this.txtMSILocation.Location = new System.Drawing.Point(116, 19);
            this.txtMSILocation.Name = "txtMSILocation";
            this.txtMSILocation.Size = new System.Drawing.Size(342, 20);
            this.txtMSILocation.TabIndex = 3;
            this.txtMSILocation.Text = "\\\\cm2012machine\\TestPackages\\TestPackage\\ultimate_finalizer.msi";
            // 
            // btnCreateMSI
            // 
            this.btnCreateMSI.Location = new System.Drawing.Point(468, 19);
            this.btnCreateMSI.Name = "btnCreateMSI";
            this.btnCreateMSI.Size = new System.Drawing.Size(75, 23);
            this.btnCreateMSI.TabIndex = 2;
            this.btnCreateMSI.Text = "ReadMSI";
            this.btnCreateMSI.UseVisualStyleBackColor = true;
            this.btnCreateMSI.Click += new System.EventHandler(this.btnMSI_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtSCCMApplicationName);
            this.groupBox2.Location = new System.Drawing.Point(13, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(555, 57);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create Application";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(467, 19);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 2;
            this.button7.Text = "Create App";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Application Name:";
            // 
            // txtSCCMApplicationName
            // 
            this.txtSCCMApplicationName.Location = new System.Drawing.Point(115, 19);
            this.txtSCCMApplicationName.Name = "txtSCCMApplicationName";
            this.txtSCCMApplicationName.Size = new System.Drawing.Size(342, 20);
            this.txtSCCMApplicationName.TabIndex = 0;
            // 
            // txtAppName
            // 
            this.txtAppName.Location = new System.Drawing.Point(115, 57);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.ReadOnly = true;
            this.txtAppName.Size = new System.Drawing.Size(342, 20);
            this.txtAppName.TabIndex = 8;
            // 
            // txtSoftwareVersion
            // 
            this.txtSoftwareVersion.Location = new System.Drawing.Point(115, 83);
            this.txtSoftwareVersion.Name = "txtSoftwareVersion";
            this.txtSoftwareVersion.ReadOnly = true;
            this.txtSoftwareVersion.Size = new System.Drawing.Size(342, 20);
            this.txtSoftwareVersion.TabIndex = 9;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(115, 109);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.ReadOnly = true;
            this.txtManufacturer.Size = new System.Drawing.Size(342, 20);
            this.txtManufacturer.TabIndex = 10;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(115, 134);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Size = new System.Drawing.Size(342, 20);
            this.txtProductCode.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Software Version";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Manufacturer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Product Code";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtUninstallCommandLine);
            this.groupBox3.Controls.Add(this.txtInstallCommandLine);
            this.groupBox3.Controls.Add(this.btnCreateInstallerandDt);
            this.groupBox3.Location = new System.Drawing.Point(13, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(555, 100);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create Installer and Deployment Type";
            // 
            // btnCreateInstallerandDt
            // 
            this.btnCreateInstallerandDt.Location = new System.Drawing.Point(467, 71);
            this.btnCreateInstallerandDt.Name = "btnCreateInstallerandDt";
            this.btnCreateInstallerandDt.Size = new System.Drawing.Size(75, 23);
            this.btnCreateInstallerandDt.TabIndex = 3;
            this.btnCreateInstallerandDt.Text = "Create";
            this.btnCreateInstallerandDt.UseVisualStyleBackColor = true;
            this.btnCreateInstallerandDt.Click += new System.EventHandler(this.btnCreateInstallerandDt_Click);
            // 
            // txtInstallCommandLine
            // 
            this.txtInstallCommandLine.Location = new System.Drawing.Point(115, 20);
            this.txtInstallCommandLine.Name = "txtInstallCommandLine";
            this.txtInstallCommandLine.Size = new System.Drawing.Size(342, 20);
            this.txtInstallCommandLine.TabIndex = 4;
            // 
            // txtUninstallCommandLine
            // 
            this.txtUninstallCommandLine.Location = new System.Drawing.Point(115, 47);
            this.txtUninstallCommandLine.Name = "txtUninstallCommandLine";
            this.txtUninstallCommandLine.Size = new System.Drawing.Size(343, 20);
            this.txtUninstallCommandLine.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Install Command:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Uninstall Command:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbSuperseded);
            this.groupBox4.Controls.Add(this.btnSupersedeApplication);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(13, 350);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(555, 57);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Supersede Application";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Supersed Name:";
            // 
            // btnSupersedeApplication
            // 
            this.btnSupersedeApplication.Location = new System.Drawing.Point(468, 19);
            this.btnSupersedeApplication.Name = "btnSupersedeApplication";
            this.btnSupersedeApplication.Size = new System.Drawing.Size(75, 23);
            this.btnSupersedeApplication.TabIndex = 10;
            this.btnSupersedeApplication.Text = "Create";
            this.btnSupersedeApplication.UseVisualStyleBackColor = true;
            this.btnSupersedeApplication.Click += new System.EventHandler(this.btnSupersedeApplication_Click);
            // 
            // cmbSuperseded
            // 
            this.cmbSuperseded.FormattingEnabled = true;
            this.cmbSuperseded.Location = new System.Drawing.Point(115, 19);
            this.cmbSuperseded.Name = "cmbSuperseded";
            this.cmbSuperseded.Size = new System.Drawing.Size(342, 21);
            this.cmbSuperseded.TabIndex = 12;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.btnAddDependency);
            this.groupBox5.Controls.Add(this.cmbDependency);
            this.groupBox5.Location = new System.Drawing.Point(13, 414);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(555, 55);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Add Dependency";
            // 
            // cmbDependency
            // 
            this.cmbDependency.FormattingEnabled = true;
            this.cmbDependency.Location = new System.Drawing.Point(115, 19);
            this.cmbDependency.Name = "cmbDependency";
            this.cmbDependency.Size = new System.Drawing.Size(342, 21);
            this.cmbDependency.TabIndex = 13;
            // 
            // btnAddDependency
            // 
            this.btnAddDependency.Location = new System.Drawing.Point(468, 17);
            this.btnAddDependency.Name = "btnAddDependency";
            this.btnAddDependency.Size = new System.Drawing.Size(75, 23);
            this.btnAddDependency.TabIndex = 11;
            this.btnAddDependency.Text = "Create";
            this.btnAddDependency.UseVisualStyleBackColor = true;
            this.btnAddDependency.Click += new System.EventHandler(this.btnAddDependency_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Dependency Name:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnAddRequirement);
            this.groupBox6.Controls.Add(this.txtRequirementValue);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.cmbConditions);
            this.groupBox6.Location = new System.Drawing.Point(13, 476);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(555, 58);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Add Requirement";
            // 
            // cmbConditions
            // 
            this.cmbConditions.FormattingEnabled = true;
            this.cmbConditions.Location = new System.Drawing.Point(65, 20);
            this.cmbConditions.Name = "cmbConditions";
            this.cmbConditions.Size = new System.Drawing.Size(190, 21);
            this.cmbConditions.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Condition:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(261, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Equals";
            // 
            // txtRequirementValue
            // 
            this.txtRequirementValue.Location = new System.Drawing.Point(318, 20);
            this.txtRequirementValue.Name = "txtRequirementValue";
            this.txtRequirementValue.Size = new System.Drawing.Size(139, 20);
            this.txtRequirementValue.TabIndex = 14;
            // 
            // btnAddRequirement
            // 
            this.btnAddRequirement.Location = new System.Drawing.Point(468, 17);
            this.btnAddRequirement.Name = "btnAddRequirement";
            this.btnAddRequirement.Size = new System.Drawing.Size(75, 23);
            this.btnAddRequirement.TabIndex = 12;
            this.btnAddRequirement.Text = "Create";
            this.btnAddRequirement.UseVisualStyleBackColor = true;
            this.btnAddRequirement.Click += new System.EventHandler(this.btnAddRequirement_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.cmbDPGNames);
            this.groupBox7.Controls.Add(this.btnDistribute);
            this.groupBox7.Location = new System.Drawing.Point(13, 541);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(555, 50);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Distribute";
            // 
            // btnDistribute
            // 
            this.btnDistribute.Location = new System.Drawing.Point(467, 17);
            this.btnDistribute.Name = "btnDistribute";
            this.btnDistribute.Size = new System.Drawing.Size(74, 23);
            this.btnDistribute.TabIndex = 0;
            this.btnDistribute.Text = "Distribute";
            this.btnDistribute.UseVisualStyleBackColor = true;
            this.btnDistribute.Click += new System.EventHandler(this.btnDistribute_Click);
            // 
            // cmbDPGNames
            // 
            this.cmbDPGNames.FormattingEnabled = true;
            this.cmbDPGNames.Location = new System.Drawing.Point(74, 21);
            this.cmbDPGNames.Name = "cmbDPGNames";
            this.cmbDPGNames.Size = new System.Drawing.Size(383, 21);
            this.cmbDPGNames.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "DPG Name:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnDeploy);
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.cmbCollection);
            this.groupBox8.Location = new System.Drawing.Point(13, 597);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(555, 54);
            this.groupBox8.TabIndex = 13;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Deploy";
            // 
            // cmbCollection
            // 
            this.cmbCollection.FormattingEnabled = true;
            this.cmbCollection.Location = new System.Drawing.Point(74, 19);
            this.cmbCollection.Name = "cmbCollection";
            this.cmbCollection.Size = new System.Drawing.Size(383, 21);
            this.cmbCollection.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Collection";
            // 
            // btnDeploy
            // 
            this.btnDeploy.Location = new System.Drawing.Point(467, 14);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(74, 23);
            this.btnDeploy.TabIndex = 2;
            this.btnDeploy.Text = "Deploy";
            this.btnDeploy.UseVisualStyleBackColor = true;
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnDelete);
            this.groupBox9.Location = new System.Drawing.Point(12, 657);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(556, 54);
            this.groupBox9.TabIndex = 14;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Delete";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(17, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(525, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete Application";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 715);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreateMSI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMSILocation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSCCMApplicationName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.TextBox txtSoftwareVersion;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCreateInstallerandDt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUninstallCommandLine;
        private System.Windows.Forms.TextBox txtInstallCommandLine;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSupersedeApplication;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbSuperseded;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddDependency;
        private System.Windows.Forms.ComboBox cmbDependency;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnAddRequirement;
        private System.Windows.Forms.TextBox txtRequirementValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbConditions;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbDPGNames;
        private System.Windows.Forms.Button btnDistribute;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnDeploy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbCollection;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnDelete;
    }
}

