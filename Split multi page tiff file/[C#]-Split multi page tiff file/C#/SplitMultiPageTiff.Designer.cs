namespace SplitMultiPageTiff
{
    partial class SplitMultiPageTiff
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
            this.btnSplitTiff = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtTiffFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutPutDir = new System.Windows.Forms.TextBox();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.btnReadProperties = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSplitTiff
            // 
            this.btnSplitTiff.Location = new System.Drawing.Point(107, 177);
            this.btnSplitTiff.Name = "btnSplitTiff";
            this.btnSplitTiff.Size = new System.Drawing.Size(127, 23);
            this.btnSplitTiff.TabIndex = 1;
            this.btnSplitTiff.Text = "Split Tiff File";
            this.btnSplitTiff.UseVisualStyleBackColor = true;
            this.btnSplitTiff.Click += new System.EventHandler(this.btnSplitTiff_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(414, 74);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(37, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtTiffFilePath
            // 
            this.txtTiffFilePath.Location = new System.Drawing.Point(110, 77);
            this.txtTiffFilePath.Name = "txtTiffFilePath";
            this.txtTiffFilePath.Size = new System.Drawing.Size(298, 20);
            this.txtTiffFilePath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input File Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Out File Path:";
            // 
            // txtOutPutDir
            // 
            this.txtOutPutDir.Location = new System.Drawing.Point(110, 119);
            this.txtOutPutDir.Name = "txtOutPutDir";
            this.txtOutPutDir.Size = new System.Drawing.Size(298, 20);
            this.txtOutPutDir.TabIndex = 6;
            this.txtOutPutDir.Text = "D:\\SplittedTiffs";
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(414, 116);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(37, 23);
            this.btnBrowseFolder.TabIndex = 5;
            this.btnBrowseFolder.Text = "...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // btnReadProperties
            // 
            this.btnReadProperties.Location = new System.Drawing.Point(281, 177);
            this.btnReadProperties.Name = "btnReadProperties";
            this.btnReadProperties.Size = new System.Drawing.Size(127, 23);
            this.btnReadProperties.TabIndex = 8;
            this.btnReadProperties.Text = "Read Properties";
            this.btnReadProperties.UseVisualStyleBackColor = true;
            this.btnReadProperties.Click += new System.EventHandler(this.btnReadProperties_Click);
            // 
            // SplitMultiPageTiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 357);
            this.Controls.Add(this.btnReadProperties);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOutPutDir);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTiffFilePath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnSplitTiff);
            this.Name = "SplitMultiPageTiff";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSplitTiff;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtTiffFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutPutDir;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Button btnReadProperties;
    }
}

