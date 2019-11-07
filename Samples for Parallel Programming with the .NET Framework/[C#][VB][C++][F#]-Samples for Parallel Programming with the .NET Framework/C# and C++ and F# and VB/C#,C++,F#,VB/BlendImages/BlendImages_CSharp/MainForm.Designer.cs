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
            this.components = new System.ComponentModel.Container();
            this.btnSequential = new System.Windows.Forms.Button();
            this.btnParallel = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbInput1 = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pbInput2 = new System.Windows.Forms.PictureBox();
            this.pbOutput = new System.Windows.Forms.PictureBox();
            this.lblSpeedup = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInput1)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSequential
            // 
            this.btnSequential.Enabled = false;
            this.btnSequential.Location = new System.Drawing.Point(12, 12);
            this.btnSequential.Name = "btnSequential";
            this.btnSequential.Size = new System.Drawing.Size(75, 23);
            this.btnSequential.TabIndex = 0;
            this.btnSequential.Text = "Sequential";
            this.btnSequential.UseVisualStyleBackColor = true;
            this.btnSequential.Click += new System.EventHandler(this.btnBlendImages_Click);
            // 
            // btnParallel
            // 
            this.btnParallel.Enabled = false;
            this.btnParallel.Location = new System.Drawing.Point(93, 12);
            this.btnParallel.Name = "btnParallel";
            this.btnParallel.Size = new System.Drawing.Size(75, 23);
            this.btnParallel.TabIndex = 1;
            this.btnParallel.Text = "Parallel";
            this.btnParallel.UseVisualStyleBackColor = true;
            this.btnParallel.Click += new System.EventHandler(this.btnBlendImages_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(174, 17);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 13);
            this.lblTime.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbInput1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(860, 269);
            this.splitContainer1.SplitterDistance = 286;
            this.splitContainer1.TabIndex = 3;
            // 
            // pbInput1
            // 
            this.pbInput1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbInput1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbInput1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbInput1.Location = new System.Drawing.Point(0, 0);
            this.pbInput1.Name = "pbInput1";
            this.pbInput1.Size = new System.Drawing.Size(286, 269);
            this.pbInput1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbInput1.TabIndex = 0;
            this.pbInput1.TabStop = false;
            this.toolTip1.SetToolTip(this.pbInput1, "Double-click to load new image");
            this.pbInput1.DoubleClick += new System.EventHandler(this.pbInput_DoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pbInput2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pbOutput);
            this.splitContainer2.Size = new System.Drawing.Size(570, 269);
            this.splitContainer2.SplitterDistance = 285;
            this.splitContainer2.TabIndex = 0;
            // 
            // pbInput2
            // 
            this.pbInput2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbInput2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbInput2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbInput2.Location = new System.Drawing.Point(0, 0);
            this.pbInput2.Name = "pbInput2";
            this.pbInput2.Size = new System.Drawing.Size(285, 269);
            this.pbInput2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbInput2.TabIndex = 1;
            this.pbInput2.TabStop = false;
            this.toolTip1.SetToolTip(this.pbInput2, "Double-click to load new image");
            this.pbInput2.DoubleClick += new System.EventHandler(this.pbInput_DoubleClick);
            // 
            // pbOutput
            // 
            this.pbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbOutput.Location = new System.Drawing.Point(0, 0);
            this.pbOutput.Name = "pbOutput";
            this.pbOutput.Size = new System.Drawing.Size(281, 269);
            this.pbOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOutput.TabIndex = 1;
            this.pbOutput.TabStop = false;
            this.pbOutput.DoubleClick += new System.EventHandler(this.pbOutput_DoubleClick);
            // 
            // lblSpeedup
            // 
            this.lblSpeedup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpeedup.AutoSize = true;
            this.lblSpeedup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeedup.ForeColor = System.Drawing.Color.Green;
            this.lblSpeedup.Location = new System.Drawing.Point(869, 17);
            this.lblSpeedup.Name = "lblSpeedup";
            this.lblSpeedup.Size = new System.Drawing.Size(0, 13);
            this.lblSpeedup.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 322);
            this.Controls.Add(this.lblSpeedup);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnParallel);
            this.Controls.Add(this.btnSequential);
            this.Name = "MainForm";
            this.Text = "Blend Images";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInput1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSequential;
        private System.Windows.Forms.Button btnParallel;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pbInput1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pbInput2;
        private System.Windows.Forms.PictureBox pbOutput;
        private System.Windows.Forms.Label lblSpeedup;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

