namespace ClientApp
{
    partial class Form1
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
            this.rtbClient = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbClient
            // 
            this.rtbClient.BackColor = System.Drawing.Color.RoyalBlue;
            this.rtbClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbClient.Location = new System.Drawing.Point(0, 0);
            this.rtbClient.Name = "rtbClient";
            this.rtbClient.Size = new System.Drawing.Size(557, 283);
            this.rtbClient.TabIndex = 2;
            this.rtbClient.Text = "";
            this.rtbClient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RtbClientKeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 283);
            this.Controls.Add(this.rtbClient);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbClient;
    }
}

