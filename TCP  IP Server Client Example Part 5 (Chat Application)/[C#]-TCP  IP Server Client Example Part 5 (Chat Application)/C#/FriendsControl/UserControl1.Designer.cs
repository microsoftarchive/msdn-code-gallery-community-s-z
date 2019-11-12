namespace FriendsControl
{
    partial class Friends
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
            this.pbFriendsImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFriendsImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFriendsImage
            // 
            this.pbFriendsImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbFriendsImage.Location = new System.Drawing.Point(0, 0);
            this.pbFriendsImage.Name = "pbFriendsImage";
            this.pbFriendsImage.Size = new System.Drawing.Size(38, 34);
            this.pbFriendsImage.TabIndex = 0;
            this.pbFriendsImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.Location = new System.Drawing.Point(88, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(169, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "...";
            // 
            // Friends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbFriendsImage);
            this.Name = "Friends";
            this.Size = new System.Drawing.Size(260, 34);
            ((System.ComponentModel.ISupportInitialize)(this.pbFriendsImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFriendsImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
    }
}
