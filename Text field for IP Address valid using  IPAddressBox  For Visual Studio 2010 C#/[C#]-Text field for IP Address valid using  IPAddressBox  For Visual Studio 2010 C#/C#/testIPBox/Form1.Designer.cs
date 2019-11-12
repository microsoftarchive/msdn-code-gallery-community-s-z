namespace testIPBox
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
            this.ipAddressControl1 = new IPAddressBox.IPAddressBoxs.IPAddressControl();
            this.ipAddressControl2 = new IPAddressBox.IPAddressBoxs.IPAddressControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ipAddressControl3 = new IPAddressBox.IPAddressBoxs.IPAddressControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipAddressControl1
            // 
            this.ipAddressControl1.Location = new System.Drawing.Point(140, 27);
            this.ipAddressControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ipAddressControl1.Name = "ipAddressControl1";
            this.ipAddressControl1.Size = new System.Drawing.Size(136, 20);
            this.ipAddressControl1.TabIndex = 0;
            this.ipAddressControl1.Text = "0.0.0.0";
            // 
            // ipAddressControl2
            // 
            this.ipAddressControl2.Location = new System.Drawing.Point(140, 59);
            this.ipAddressControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ipAddressControl2.Name = "ipAddressControl2";
            this.ipAddressControl2.Size = new System.Drawing.Size(136, 20);
            this.ipAddressControl2.TabIndex = 1;
            this.ipAddressControl2.Text = "0.0.0.0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ipAddressControl3);
            this.groupBox1.Controls.Add(this.ipAddressControl1);
            this.groupBox1.Controls.Add(this.ipAddressControl2);
            this.groupBox1.Location = new System.Drawing.Point(16, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(371, 134);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP Address Text Box";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Default getway :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Subnet mask :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP Address :";
            // 
            // ipAddressControl3
            // 
            this.ipAddressControl3.Location = new System.Drawing.Point(140, 91);
            this.ipAddressControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ipAddressControl3.Name = "ipAddressControl3";
            this.ipAddressControl3.Size = new System.Drawing.Size(136, 20);
            this.ipAddressControl3.TabIndex = 2;
            this.ipAddressControl3.Text = "0.0.0.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 151);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP Address Text Box";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IPAddressBox.IPAddressBoxs.IPAddressControl ipAddressControl1;
        private IPAddressBox.IPAddressBoxs.IPAddressControl ipAddressControl2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private IPAddressBox.IPAddressBoxs.IPAddressControl ipAddressControl3;

    }
}

