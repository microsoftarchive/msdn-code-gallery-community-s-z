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
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.rbLINQ = new System.Windows.Forms.RadioButton();
            this.rbPLINQ = new System.Windows.Forms.RadioButton();
            this.btnRender = new System.Windows.Forms.Button();
            this.lbTimeToComplete = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImage.BackColor = System.Drawing.Color.Black;
            this.pbImage.Location = new System.Drawing.Point(13, 13);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(359, 352);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // rbLINQ
            // 
            this.rbLINQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbLINQ.AutoSize = true;
            this.rbLINQ.Location = new System.Drawing.Point(12, 374);
            this.rbLINQ.Name = "rbLINQ";
            this.rbLINQ.Size = new System.Drawing.Size(75, 17);
            this.rbLINQ.TabIndex = 1;
            this.rbLINQ.TabStop = true;
            this.rbLINQ.Text = "Sequential";
            this.rbLINQ.UseVisualStyleBackColor = true;
            // 
            // rbPLINQ
            // 
            this.rbPLINQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbPLINQ.AutoSize = true;
            this.rbPLINQ.Location = new System.Drawing.Point(93, 374);
            this.rbPLINQ.Name = "rbPLINQ";
            this.rbPLINQ.Size = new System.Drawing.Size(59, 17);
            this.rbPLINQ.TabIndex = 2;
            this.rbPLINQ.TabStop = true;
            this.rbPLINQ.Text = "Parallel";
            this.rbPLINQ.UseVisualStyleBackColor = true;
            // 
            // btnRender
            // 
            this.btnRender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRender.Location = new System.Drawing.Point(158, 371);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(75, 23);
            this.btnRender.TabIndex = 3;
            this.btnRender.Text = "Render";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // lbTimeToComplete
            // 
            this.lbTimeToComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTimeToComplete.AutoSize = true;
            this.lbTimeToComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeToComplete.Location = new System.Drawing.Point(240, 376);
            this.lbTimeToComplete.Name = "lbTimeToComplete";
            this.lbTimeToComplete.Size = new System.Drawing.Size(0, 13);
            this.lbTimeToComplete.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 401);
            this.Controls.Add(this.lbTimeToComplete);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.rbPLINQ);
            this.Controls.Add(this.rbLINQ);
            this.Controls.Add(this.pbImage);
            this.Name = "MainForm";
            this.Text = "LINQ Ray Tracer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.RadioButton rbLINQ;
        private System.Windows.Forms.RadioButton rbPLINQ;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.Label lbTimeToComplete;
    }
}