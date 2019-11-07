namespace WebCamCapture
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ImgWebCam = new System.Windows.Forms.PictureBox();
            this.tmrRefrashFrame = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ImgWebCam)).BeginInit();
            this.SuspendLayout();
            // 
            // ImgWebCam
            // 
            this.ImgWebCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImgWebCam.Location = new System.Drawing.Point(0, 0);
            this.ImgWebCam.Name = "ImgWebCam";
            this.ImgWebCam.Size = new System.Drawing.Size(150, 150);
            this.ImgWebCam.TabIndex = 0;
            this.ImgWebCam.TabStop = false;
            // 
            // tmrRefrashFrame
            // 
            this.tmrRefrashFrame.Tick += new System.EventHandler(this.tmrRefrashFrame_Tick);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ImgWebCam);
            this.Name = "UserControl1";
            ((System.ComponentModel.ISupportInitialize)(this.ImgWebCam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ImgWebCam;
        private System.Windows.Forms.Timer tmrRefrashFrame;
    }
}
