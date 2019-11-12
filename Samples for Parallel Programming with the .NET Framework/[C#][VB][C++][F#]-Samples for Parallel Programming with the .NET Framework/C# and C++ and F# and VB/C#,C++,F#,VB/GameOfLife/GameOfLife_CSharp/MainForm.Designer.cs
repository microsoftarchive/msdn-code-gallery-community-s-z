namespace GameOfLife
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.chkParallel = new System.Windows.Forms.CheckBox();
            this.tbDensity = new System.Windows.Forms.TrackBar();
            this.lblDensity = new System.Windows.Forms.Label();
            this.lblFramesPerSecond = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDensity)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(464, 413);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 12);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Start";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // chkParallel
            // 
            this.chkParallel.AutoSize = true;
            this.chkParallel.Location = new System.Drawing.Point(93, 16);
            this.chkParallel.Name = "chkParallel";
            this.chkParallel.Size = new System.Drawing.Size(66, 17);
            this.chkParallel.TabIndex = 2;
            this.chkParallel.Text = "Parallel?";
            this.chkParallel.UseVisualStyleBackColor = true;
            this.chkParallel.CheckedChanged += new System.EventHandler(this.chkParallel_CheckedChanged);
            // 
            // tbDensity
            // 
            this.tbDensity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDensity.Location = new System.Drawing.Point(325, 12);
            this.tbDensity.Maximum = 1000;
            this.tbDensity.Minimum = 1;
            this.tbDensity.Name = "tbDensity";
            this.tbDensity.Size = new System.Drawing.Size(151, 45);
            this.tbDensity.TabIndex = 3;
            this.tbDensity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbDensity.Value = 100;
            // 
            // lblDensity
            // 
            this.lblDensity.AutoSize = true;
            this.lblDensity.Location = new System.Drawing.Point(250, 16);
            this.lblDensity.Name = "lblDensity";
            this.lblDensity.Size = new System.Drawing.Size(69, 13);
            this.lblDensity.TabIndex = 4;
            this.lblDensity.Text = "Initial Density";
            // 
            // lblFramesPerSecond
            // 
            this.lblFramesPerSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFramesPerSecond.AutoSize = true;
            this.lblFramesPerSecond.Location = new System.Drawing.Point(13, 457);
            this.lblFramesPerSecond.Name = "lblFramesPerSecond";
            this.lblFramesPerSecond.Size = new System.Drawing.Size(77, 13);
            this.lblFramesPerSecond.TabIndex = 5;
            this.lblFramesPerSecond.Text = "Frames / Sec: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 482);
            this.Controls.Add(this.lblFramesPerSecond);
            this.Controls.Add(this.lblDensity);
            this.Controls.Add(this.chkParallel);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbDensity);
            this.Name = "MainForm";
            this.Text = "Conway\'s Game Of Life";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDensity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.CheckBox chkParallel;
        private System.Windows.Forms.TrackBar tbDensity;
        private System.Windows.Forms.Label lblDensity;
        private System.Windows.Forms.Label lblFramesPerSecond;
    }
}

