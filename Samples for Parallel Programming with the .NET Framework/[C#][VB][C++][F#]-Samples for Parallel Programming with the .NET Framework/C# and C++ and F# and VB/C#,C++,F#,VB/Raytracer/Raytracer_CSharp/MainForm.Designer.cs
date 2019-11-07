namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
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
            this.chkParallel = new System.Windows.Forms.CheckBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.pbRenderedImage = new System.Windows.Forms.PictureBox();
            this.chkShowThreads = new System.Windows.Forms.CheckBox();
            this.tbNumProcs = new System.Windows.Forms.TrackBar();
            this.lblNumProcs = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbRenderedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNumProcs)).BeginInit();
            this.SuspendLayout();
            // 
            // chkParallel
            // 
            this.chkParallel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkParallel.AutoSize = true;
            this.chkParallel.Location = new System.Drawing.Point(108, 426);
            this.chkParallel.Name = "chkParallel";
            this.chkParallel.Size = new System.Drawing.Size(60, 17);
            this.chkParallel.TabIndex = 20;
            this.chkParallel.Text = "Parallel";
            this.chkParallel.UseVisualStyleBackColor = true;
            this.chkParallel.CheckedChanged += new System.EventHandler(this.chkParallel_CheckedChanged);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartStop.Location = new System.Drawing.Point(13, 421);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(88, 23);
            this.btnStartStop.TabIndex = 19;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // pbRenderedImage
            // 
            this.pbRenderedImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbRenderedImage.BackColor = System.Drawing.Color.Black;
            this.pbRenderedImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbRenderedImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbRenderedImage.Location = new System.Drawing.Point(13, 15);
            this.pbRenderedImage.Name = "pbRenderedImage";
            this.pbRenderedImage.Size = new System.Drawing.Size(469, 400);
            this.pbRenderedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbRenderedImage.TabIndex = 18;
            this.pbRenderedImage.TabStop = false;
            // 
            // chkShowThreads
            // 
            this.chkShowThreads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowThreads.AutoSize = true;
            this.chkShowThreads.Enabled = false;
            this.chkShowThreads.Location = new System.Drawing.Point(174, 426);
            this.chkShowThreads.Name = "chkShowThreads";
            this.chkShowThreads.Size = new System.Drawing.Size(95, 17);
            this.chkShowThreads.TabIndex = 21;
            this.chkShowThreads.Text = "Show Threads";
            this.chkShowThreads.UseVisualStyleBackColor = true;
            // 
            // tbNumProcs
            // 
            this.tbNumProcs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNumProcs.Enabled = false;
            this.tbNumProcs.Location = new System.Drawing.Point(304, 421);
            this.tbNumProcs.Maximum = 24;
            this.tbNumProcs.Minimum = 1;
            this.tbNumProcs.Name = "tbNumProcs";
            this.tbNumProcs.Size = new System.Drawing.Size(178, 45);
            this.tbNumProcs.TabIndex = 22;
            this.tbNumProcs.Value = 1;
            this.tbNumProcs.ValueChanged += new System.EventHandler(this.tbNumProcs_ValueChanged);
            // 
            // lblNumProcs
            // 
            this.lblNumProcs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumProcs.AutoSize = true;
            this.lblNumProcs.Enabled = false;
            this.lblNumProcs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumProcs.Location = new System.Drawing.Point(295, 431);
            this.lblNumProcs.Name = "lblNumProcs";
            this.lblNumProcs.Size = new System.Drawing.Size(14, 13);
            this.lblNumProcs.TabIndex = 23;
            this.lblNumProcs.Text = "1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 459);
            this.Controls.Add(this.lblNumProcs);
            this.Controls.Add(this.tbNumProcs);
            this.Controls.Add(this.chkShowThreads);
            this.Controls.Add(this.chkParallel);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.pbRenderedImage);
            this.Name = "MainForm";
            this.Text = "Ray Tracer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbRenderedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNumProcs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox chkParallel;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.PictureBox pbRenderedImage;
        internal System.Windows.Forms.CheckBox chkShowThreads;
        private System.Windows.Forms.TrackBar tbNumProcs;
        private System.Windows.Forms.Label lblNumProcs;
    }
}

