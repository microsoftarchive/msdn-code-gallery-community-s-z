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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bwColorize = new System.ComponentModel.BackgroundWorker();
            this.tmRefresh = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.btnLoadImage = new System.Windows.Forms.ToolStripButton();
            this.btnSaveImage = new System.Windows.Forms.ToolStripButton();
            this.separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbEpsilon = new Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.ToolStripTrackBar();
            this.separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnParallel = new System.Windows.Forms.ToolStripButton();
            this.btnInk = new System.Windows.Forms.ToolStripButton();
            this.btnEraser = new System.Windows.Forms.ToolStripButton();
            this.pbColorizing = new System.Windows.Forms.ToolStripProgressBar();
            this.lblHuesSelected = new System.Windows.Forms.ToolStripLabel();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // bwColorize
            // 
            this.bwColorize.WorkerReportsProgress = true;
            this.bwColorize.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwColorize_DoWork);
            this.bwColorize.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwColorize_RunWorkerCompleted);
            this.bwColorize.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwColorize_ProgressChanged);
            // 
            // tmRefresh
            // 
            this.tmRefresh.Interval = 1000;
            this.tmRefresh.Tick += new System.EventHandler(this.tmRefresh_Tick);
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.pbImage);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(619, 397);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(619, 422);
            this.toolStripContainer.TabIndex = 10;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStripMain);
            // 
            // pbImage
            // 
            this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbImage.Location = new System.Drawing.Point(3, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(613, 391);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 10;
            this.pbImage.TabStop = false;
            this.pbImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbImage_DragDrop);
            this.pbImage.Resize += new System.EventHandler(this.pbImage_Resize);
            this.pbImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseClick);
            this.pbImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbImage_DragEnter);
            // 
            // toolStripMain
            // 
            this.toolStripMain.AllowItemReorder = true;
            this.toolStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadImage,
            this.btnSaveImage,
            this.separator1,
            this.tbEpsilon,
            this.separator2,
            this.btnParallel,
            this.btnInk,
            this.btnEraser,
            this.pbColorizing,
            this.lblHuesSelected});
            this.toolStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripMain.Location = new System.Drawing.Point(3, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(616, 25);
            this.toolStripMain.TabIndex = 9;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Image = global::Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Properties.Resources.InsertPictureHS;
            this.btnLoadImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(89, 22);
            this.btnLoadImage.Text = "&Load Image";
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Image = global::Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Properties.Resources.saveHS;
            this.btnSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(87, 22);
            this.btnSaveImage.Text = "&Save Image";
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbEpsilon
            // 
            this.tbEpsilon.BackColor = System.Drawing.SystemColors.Control;
            this.tbEpsilon.Maximum = 180;
            this.tbEpsilon.Name = "tbEpsilon";
            this.tbEpsilon.Size = new System.Drawing.Size(150, 22);
            this.tbEpsilon.Text = "toolStripTrackBar1";
            this.tbEpsilon.Value = 15;
            this.tbEpsilon.ValueChanged += new System.EventHandler(this.tbEpsilon_ValueChanged);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnParallel
            // 
            this.btnParallel.CheckOnClick = true;
            this.btnParallel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnParallel.Image = ((System.Drawing.Image)(resources.GetObject("btnParallel.Image")));
            this.btnParallel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnParallel.Name = "btnParallel";
            this.btnParallel.Size = new System.Drawing.Size(23, 22);
            this.btnParallel.Text = "btnParallel";
            this.btnParallel.CheckedChanged += new System.EventHandler(this.btnParallel_CheckedChanged);
            // 
            // btnInk
            // 
            this.btnInk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInk.Enabled = false;
            this.btnInk.Image = global::Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Properties.Resources.pen;
            this.btnInk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInk.Name = "btnInk";
            this.btnInk.Size = new System.Drawing.Size(23, 22);
            this.btnInk.Text = "btnInk";
            this.btnInk.Click += new System.EventHandler(this.btnInk_Click);
            // 
            // btnEraser
            // 
            this.btnEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEraser.Enabled = false;
            this.btnEraser.Image = global::Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Properties.Resources.eraser;
            this.btnEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(23, 22);
            this.btnEraser.Text = "btnEraser";
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_Click);
            // 
            // pbColorizing
            // 
            this.pbColorizing.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pbColorizing.Name = "pbColorizing";
            this.pbColorizing.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.pbColorizing.Size = new System.Drawing.Size(140, 22);
            this.pbColorizing.Visible = false;
            // 
            // lblHuesSelected
            // 
            this.lblHuesSelected.Name = "lblHuesSelected";
            this.lblHuesSelected.Size = new System.Drawing.Size(81, 15);
            this.lblHuesSelected.Text = "Hues Selected";
            this.lblHuesSelected.Click += new System.EventHandler(this.lblHuesSelected_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 422);
            this.Controls.Add(this.toolStripContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Image Colorizer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bwColorize;
        private System.Windows.Forms.Timer tmRefresh;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton btnLoadImage;
        private System.Windows.Forms.ToolStripButton btnSaveImage;
        private System.Windows.Forms.ToolStripSeparator separator1;
        private ToolStripTrackBar tbEpsilon;
        private System.Windows.Forms.ToolStripSeparator separator2;
        private System.Windows.Forms.ToolStripButton btnInk;
        private System.Windows.Forms.ToolStripButton btnEraser;
        private System.Windows.Forms.ToolStripProgressBar pbColorizing;
        private System.Windows.Forms.ToolStripLabel lblHuesSelected;
        private System.Windows.Forms.ToolStripButton btnParallel;
    }
}

