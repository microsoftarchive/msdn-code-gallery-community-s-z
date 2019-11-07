namespace ThreadSleepTaskDelayDemo
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
            this.btnThreadSleep = new System.Windows.Forms.Button();
            this.btnTaskDelay = new System.Windows.Forms.Button();
            this.btnCancelTaskDelay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnThreadSleep
            // 
            this.btnThreadSleep.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThreadSleep.Location = new System.Drawing.Point(123, 107);
            this.btnThreadSleep.Name = "btnThreadSleep";
            this.btnThreadSleep.Size = new System.Drawing.Size(247, 49);
            this.btnThreadSleep.TabIndex = 0;
            this.btnThreadSleep.Text = "Thread Sleep";
            this.btnThreadSleep.UseVisualStyleBackColor = true;
            this.btnThreadSleep.Click += new System.EventHandler(this.btnThreadSleep_Click);
            // 
            // btnTaskDelay
            // 
            this.btnTaskDelay.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskDelay.Location = new System.Drawing.Point(123, 162);
            this.btnTaskDelay.Name = "btnTaskDelay";
            this.btnTaskDelay.Size = new System.Drawing.Size(247, 49);
            this.btnTaskDelay.TabIndex = 1;
            this.btnTaskDelay.Text = "Task Delay";
            this.btnTaskDelay.UseVisualStyleBackColor = true;
            this.btnTaskDelay.Click += new System.EventHandler(this.btnTaskDelay_Click);
            // 
            // btnCancelTaskDelay
            // 
            this.btnCancelTaskDelay.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelTaskDelay.Location = new System.Drawing.Point(123, 217);
            this.btnCancelTaskDelay.Name = "btnCancelTaskDelay";
            this.btnCancelTaskDelay.Size = new System.Drawing.Size(247, 49);
            this.btnCancelTaskDelay.TabIndex = 2;
            this.btnCancelTaskDelay.Text = "Cancel Task Delay";
            this.btnCancelTaskDelay.UseVisualStyleBackColor = true;
            this.btnCancelTaskDelay.Click += new System.EventHandler(this.btnCancelTaskDelay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 387);
            this.Controls.Add(this.btnCancelTaskDelay);
            this.Controls.Add(this.btnTaskDelay);
            this.Controls.Add(this.btnThreadSleep);
            this.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThreadSleep;
        private System.Windows.Forms.Button btnTaskDelay;
        private System.Windows.Forms.Button btnCancelTaskDelay;
    }
}

