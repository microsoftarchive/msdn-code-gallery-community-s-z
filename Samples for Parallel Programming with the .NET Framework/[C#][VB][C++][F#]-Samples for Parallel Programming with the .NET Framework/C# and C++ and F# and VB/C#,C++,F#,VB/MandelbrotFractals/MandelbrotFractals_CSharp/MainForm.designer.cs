namespace Microsoft.Pcp.Pfx.InteractiveFractal
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
            this.mandelbrotPb = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.mandelbrotPb)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mandelbrotPb
            // 
            this.mandelbrotPb.BackColor = System.Drawing.Color.Black;
            this.mandelbrotPb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mandelbrotPb.Location = new System.Drawing.Point(0, 0);
            this.mandelbrotPb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mandelbrotPb.Name = "mandelbrotPb";
            this.mandelbrotPb.Size = new System.Drawing.Size(521, 452);
            this.mandelbrotPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mandelbrotPb.TabIndex = 0;
            this.mandelbrotPb.TabStop = false;
            this.mandelbrotPb.VisibleChanged += new System.EventHandler(this.mandelbrotPb_VisibleChanged);
            this.mandelbrotPb.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mandelbrotPb_MouseDoubleClick);
            this.mandelbrotPb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mandelbrotPb_MouseDown);
            this.mandelbrotPb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mandelbrotPb_MouseMove);
            this.mandelbrotPb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mandelbrotPb_MouseUp);
            this.mandelbrotPb.Resize += new System.EventHandler(this.mandelbrotPb_Resize);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 427);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(521, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(386, 20);
            this.toolStripStatusLabel1.Text = "P: parallel mode, S: sequential mode, Double-click: zoom";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 452);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mandelbrotPb);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Mandelbrot Fractals";
            ((System.ComponentModel.ISupportInitialize)(this.mandelbrotPb)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mandelbrotPb;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

