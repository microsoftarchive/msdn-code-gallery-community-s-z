namespace SerialPortSample
{
    partial class serialPortSettingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comPortComboBox1 = new SerialPortExample.ComPortComboBox();
            this.dataBits1 = new SerialPortExample.DataBits();
            this.handShakeComboBox1 = new SerialPortExample.HandShakeComboBox();
            this.stopBitsComboBox1 = new SerialPortExample.StopBitsComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.baudRateUpDown2 = new SerialPortExample.BaudRateUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataBits1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baudRateUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // comPortComboBox1
            // 
            this.comPortComboBox1.FormattingEnabled = true;
            this.comPortComboBox1.Location = new System.Drawing.Point(118, 20);
            this.comPortComboBox1.Name = "comPortComboBox1";
            this.comPortComboBox1.Size = new System.Drawing.Size(121, 21);
            this.comPortComboBox1.TabIndex = 0;
            // 
            // dataBits1
            // 
            this.dataBits1.Location = new System.Drawing.Point(118, 75);
            this.dataBits1.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.dataBits1.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.dataBits1.Name = "dataBits1";
            this.dataBits1.Size = new System.Drawing.Size(120, 20);
            this.dataBits1.TabIndex = 2;
            this.dataBits1.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // handShakeComboBox1
            // 
            this.handShakeComboBox1.FormattingEnabled = true;
            this.handShakeComboBox1.Location = new System.Drawing.Point(118, 102);
            this.handShakeComboBox1.Name = "handShakeComboBox1";
            this.handShakeComboBox1.Size = new System.Drawing.Size(121, 21);
            this.handShakeComboBox1.TabIndex = 3;
            // 
            // stopBitsComboBox1
            // 
            this.stopBitsComboBox1.FormattingEnabled = true;
            this.stopBitsComboBox1.Location = new System.Drawing.Point(118, 130);
            this.stopBitsComboBox1.Name = "stopBitsComboBox1";
            this.stopBitsComboBox1.Size = new System.Drawing.Size(121, 21);
            this.stopBitsComboBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Communications Port:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Baud Rate:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Data bits:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Stopbits:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Handshake:";
            // 
            // baudRateUpDown2
            // 
            this.baudRateUpDown2.Location = new System.Drawing.Point(119, 48);
            this.baudRateUpDown2.Maximum = new decimal(new int[] {
            128000,
            0,
            0,
            0});
            this.baudRateUpDown2.Minimum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.baudRateUpDown2.Name = "baudRateUpDown2";
            this.baudRateUpDown2.Size = new System.Drawing.Size(120, 20);
            this.baudRateUpDown2.TabIndex = 10;
            this.baudRateUpDown2.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            // 
            // serialPortSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.baudRateUpDown2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopBitsComboBox1);
            this.Controls.Add(this.handShakeComboBox1);
            this.Controls.Add(this.dataBits1);
            this.Controls.Add(this.comPortComboBox1);
            this.Name = "serialPortSettingsControl";
            this.Size = new System.Drawing.Size(255, 170);
            ((System.ComponentModel.ISupportInitialize)(this.dataBits1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baudRateUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SerialPortExample.ComPortComboBox comPortComboBox1;
        private SerialPortExample.DataBits dataBits1;
        private SerialPortExample.HandShakeComboBox handShakeComboBox1;
        private SerialPortExample.StopBitsComboBox stopBitsComboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private SerialPortExample.BaudRateUpDown baudRateUpDown2;
    }
}
