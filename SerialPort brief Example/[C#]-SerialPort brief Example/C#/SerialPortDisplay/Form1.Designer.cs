namespace SerialPortExample
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.serialPortSettingsControl1 = new SerialPortSample.serialPortSettingsControl();
            this.ReceivedText = new System.Windows.Forms.TextBox();
            this.SendText = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(174, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // serialPortSettingsControl1
            // 
            this.serialPortSettingsControl1.Location = new System.Drawing.Point(12, 12);
            this.serialPortSettingsControl1.Name = "serialPortSettingsControl1";
            this.serialPortSettingsControl1.Size = new System.Drawing.Size(255, 170);
            this.serialPortSettingsControl1.TabIndex = 0;
            this.serialPortSettingsControl1.WorkingObject = null;
            // 
            // ReceivedText
            // 
            this.ReceivedText.Enabled = false;
            this.ReceivedText.Location = new System.Drawing.Point(261, 31);
            this.ReceivedText.Multiline = true;
            this.ReceivedText.Name = "ReceivedText";
            this.ReceivedText.Size = new System.Drawing.Size(342, 139);
            this.ReceivedText.TabIndex = 3;
            // 
            // SendText
            // 
            this.SendText.Location = new System.Drawing.Point(261, 176);
            this.SendText.Name = "SendText";
            this.SendText.Size = new System.Drawing.Size(287, 20);
            this.SendText.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(554, 173);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 210);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.SendText);
            this.Controls.Add(this.ReceivedText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.serialPortSettingsControl1);
            this.Name = "Form1";
            this.Text = "Serial Port Sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SerialPortSample.serialPortSettingsControl serialPortSettingsControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox ReceivedText;
        private System.Windows.Forms.TextBox SendText;
        private System.Windows.Forms.Button button3;


    }
}

