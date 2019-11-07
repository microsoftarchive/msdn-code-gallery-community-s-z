namespace ParallelMorph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pbMorphStatus = new System.Windows.Forms.ProgressBar();
            this.btnMorph = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.outputSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputSizeToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aviOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sizeModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processingModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequentialProcessingModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parallelProcessingModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.pbInProgressMorph = new System.Windows.Forms.PictureBox();
            this.morphInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.pbStartImage = new ParallelMorph.LinedPictureBox();
            this.pbEndImage = new ParallelMorph.LinedPictureBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMorphStatus
            // 
            this.pbMorphStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMorphStatus.Location = new System.Drawing.Point(12, 350);
            this.pbMorphStatus.Name = "pbMorphStatus";
            this.pbMorphStatus.Size = new System.Drawing.Size(492, 23);
            this.pbMorphStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbMorphStatus.TabIndex = 8;
            this.pbMorphStatus.Visible = false;
            // 
            // btnMorph
            // 
            this.btnMorph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMorph.Enabled = false;
            this.btnMorph.Location = new System.Drawing.Point(510, 350);
            this.btnMorph.Name = "btnMorph";
            this.btnMorph.Size = new System.Drawing.Size(127, 23);
            this.btnMorph.TabIndex = 4;
            this.btnMorph.Text = "Morph";
            this.btnMorph.UseVisualStyleBackColor = true;
            this.btnMorph.Click += new System.EventHandler(this.btnMorph_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.pbStartImage);
            this.splitContainer1.Panel1.DoubleClick += new System.EventHandler(this.splitContainer1_Panel1_DoubleClick);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.pbEndImage);
            this.splitContainer1.Panel2.DoubleClick += new System.EventHandler(this.splitContainer1_Panel2_DoubleClick);
            this.splitContainer1.Size = new System.Drawing.Size(625, 317);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(649, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.outputSizeToolStripMenuItem,
            this.outputToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sizeModeToolStripMenuItem,
            this.processingModeToolStripMenuItem,
            this.toolStripMenuItem3,
            this.morphInfoToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(162, 6);
            // 
            // outputSizeToolStripMenuItem
            // 
            this.outputSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputSizeToolStripTextBox});
            this.outputSizeToolStripMenuItem.Name = "outputSizeToolStripMenuItem";
            this.outputSizeToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.outputSizeToolStripMenuItem.Text = "Output Size";
            // 
            // outputSizeToolStripTextBox
            // 
            this.outputSizeToolStripTextBox.MaxLength = 3;
            this.outputSizeToolStripTextBox.Name = "outputSizeToolStripTextBox";
            this.outputSizeToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.outputSizeToolStripTextBox.Text = "100";
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagesOutputToolStripMenuItem,
            this.aviOutputToolStripMenuItem});
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.outputToolStripMenuItem.Text = "Output Type";
            // 
            // imagesOutputToolStripMenuItem
            // 
            this.imagesOutputToolStripMenuItem.Checked = true;
            this.imagesOutputToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.imagesOutputToolStripMenuItem.Name = "imagesOutputToolStripMenuItem";
            this.imagesOutputToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.imagesOutputToolStripMenuItem.Text = "Images";
            this.imagesOutputToolStripMenuItem.Click += new System.EventHandler(this.outputModeToolStripMenuItem_Click);
            // 
            // aviOutputToolStripMenuItem
            // 
            this.aviOutputToolStripMenuItem.Name = "aviOutputToolStripMenuItem";
            this.aviOutputToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.aviOutputToolStripMenuItem.Text = "AVI";
            this.aviOutputToolStripMenuItem.Click += new System.EventHandler(this.outputModeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
            // 
            // sizeModeToolStripMenuItem
            // 
            this.sizeModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoSizeToolStripMenuItem,
            this.zoomToolStripMenuItem});
            this.sizeModeToolStripMenuItem.Name = "sizeModeToolStripMenuItem";
            this.sizeModeToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.sizeModeToolStripMenuItem.Text = "View Mode";
            // 
            // autoSizeToolStripMenuItem
            // 
            this.autoSizeToolStripMenuItem.Name = "autoSizeToolStripMenuItem";
            this.autoSizeToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.autoSizeToolStripMenuItem.Text = "AutoSize";
            this.autoSizeToolStripMenuItem.Click += new System.EventHandler(this.autoSizeToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Checked = true;
            this.zoomToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            this.zoomToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
            // 
            // processingModeToolStripMenuItem
            // 
            this.processingModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sequentialProcessingModeToolStripMenuItem,
            this.parallelProcessingModeToolStripMenuItem});
            this.processingModeToolStripMenuItem.Name = "processingModeToolStripMenuItem";
            this.processingModeToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.processingModeToolStripMenuItem.Text = "Processing Mode";
            // 
            // sequentialProcessingModeToolStripMenuItem
            // 
            this.sequentialProcessingModeToolStripMenuItem.Checked = true;
            this.sequentialProcessingModeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sequentialProcessingModeToolStripMenuItem.Name = "sequentialProcessingModeToolStripMenuItem";
            this.sequentialProcessingModeToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.sequentialProcessingModeToolStripMenuItem.Text = "Sequential";
            this.sequentialProcessingModeToolStripMenuItem.Click += new System.EventHandler(this.parallelModeToolStripMenuItem_Click);
            // 
            // parallelProcessingModeToolStripMenuItem
            // 
            this.parallelProcessingModeToolStripMenuItem.Name = "parallelProcessingModeToolStripMenuItem";
            this.parallelProcessingModeToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.parallelProcessingModeToolStripMenuItem.Text = "Parallel";
            this.parallelProcessingModeToolStripMenuItem.Click += new System.EventHandler(this.parallelModeToolStripMenuItem_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(509, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbInProgressMorph
            // 
            this.pbInProgressMorph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbInProgressMorph.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbInProgressMorph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbInProgressMorph.Location = new System.Drawing.Point(12, 27);
            this.pbInProgressMorph.Name = "pbInProgressMorph";
            this.pbInProgressMorph.Size = new System.Drawing.Size(625, 317);
            this.pbInProgressMorph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbInProgressMorph.TabIndex = 12;
            this.pbInProgressMorph.TabStop = false;
            this.pbInProgressMorph.Visible = false;
            // 
            // morphInfoToolStripMenuItem
            // 
            this.morphInfoToolStripMenuItem.Name = "morphInfoToolStripMenuItem";
            this.morphInfoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.morphInfoToolStripMenuItem.Text = "Morph Info...";
            this.morphInfoToolStripMenuItem.Click += new System.EventHandler(this.morphInfoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(162, 6);
            // 
            // pbStartImage
            // 
            this.pbStartImage.ImageNumber = 0;
            this.pbStartImage.LinePairs = null;
            this.pbStartImage.Location = new System.Drawing.Point(0, 0);
            this.pbStartImage.Name = "pbStartImage";
            this.pbStartImage.Size = new System.Drawing.Size(310, 315);
            this.pbStartImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbStartImage.TabIndex = 0;
            this.pbStartImage.TabStop = false;
            this.pbStartImage.DoubleClick += new System.EventHandler(this.LoadPictureBoxImage);
            this.pbStartImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbAnyImage_MouseDown);
            this.pbStartImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbAnyImage_MouseMove);
            this.pbStartImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbAnyImage_MouseUp);
            // 
            // pbEndImage
            // 
            this.pbEndImage.ImageNumber = 0;
            this.pbEndImage.LinePairs = null;
            this.pbEndImage.Location = new System.Drawing.Point(0, 0);
            this.pbEndImage.Name = "pbEndImage";
            this.pbEndImage.Size = new System.Drawing.Size(307, 315);
            this.pbEndImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbEndImage.TabIndex = 0;
            this.pbEndImage.TabStop = false;
            this.pbEndImage.DoubleClick += new System.EventHandler(this.LoadPictureBoxImage);
            this.pbEndImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbAnyImage_MouseDown);
            this.pbEndImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbAnyImage_MouseMove);
            this.pbEndImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbAnyImage_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 385);
            this.Controls.Add(this.pbInProgressMorph);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnMorph);
            this.Controls.Add(this.pbMorphStatus);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Parallel Morph";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMainForm_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMorph;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ProgressBar pbMorphStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private ParallelMorph.LinedPictureBox pbStartImage;
        private ParallelMorph.LinedPictureBox pbEndImage;
        private System.Windows.Forms.ToolStripMenuItem sizeModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem processingModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequentialProcessingModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parallelProcessingModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aviOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagesOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputSizeToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbInProgressMorph;
        private System.Windows.Forms.ToolStripTextBox outputSizeToolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem morphInfoToolStripMenuItem;
    }
}

