namespace WindowsFormsApplication1
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
            this.sendHtmlMessageButton = new System.Windows.Forms.Button();
            this.sendPlainTextMessageButton = new System.Windows.Forms.Button();
            this.chkSendToPickupFolder = new System.Windows.Forms.CheckBox();
            this.pickupFolderCleaner = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendHtmlMessageButton
            // 
            this.sendHtmlMessageButton.Location = new System.Drawing.Point(12, 24);
            this.sendHtmlMessageButton.Name = "sendHtmlMessageButton";
            this.sendHtmlMessageButton.Size = new System.Drawing.Size(157, 23);
            this.sendHtmlMessageButton.TabIndex = 0;
            this.sendHtmlMessageButton.Text = "Send html message";
            this.sendHtmlMessageButton.UseVisualStyleBackColor = true;
            this.sendHtmlMessageButton.Click += new System.EventHandler(this.sendHtmlMessageButton_Click);
            // 
            // sendPlainTextMessageButton
            // 
            this.sendPlainTextMessageButton.Location = new System.Drawing.Point(12, 53);
            this.sendPlainTextMessageButton.Name = "sendPlainTextMessageButton";
            this.sendPlainTextMessageButton.Size = new System.Drawing.Size(157, 23);
            this.sendPlainTextMessageButton.TabIndex = 2;
            this.sendPlainTextMessageButton.Text = "Send plain message";
            this.sendPlainTextMessageButton.UseVisualStyleBackColor = true;
            this.sendPlainTextMessageButton.Click += new System.EventHandler(this.sendPlainTextMessageButton_Click);
            // 
            // chkSendToPickupFolder
            // 
            this.chkSendToPickupFolder.AutoSize = true;
            this.chkSendToPickupFolder.Location = new System.Drawing.Point(201, 42);
            this.chkSendToPickupFolder.Name = "chkSendToPickupFolder";
            this.chkSendToPickupFolder.Size = new System.Drawing.Size(127, 17);
            this.chkSendToPickupFolder.TabIndex = 1;
            this.chkSendToPickupFolder.Text = "Send to pickup folder";
            this.chkSendToPickupFolder.UseVisualStyleBackColor = true;
            // 
            // pickupFolderCleaner
            // 
            this.pickupFolderCleaner.Location = new System.Drawing.Point(12, 82);
            this.pickupFolderCleaner.Name = "pickupFolderCleaner";
            this.pickupFolderCleaner.Size = new System.Drawing.Size(157, 23);
            this.pickupFolderCleaner.TabIndex = 3;
            this.pickupFolderCleaner.Text = "Clean pickup folder";
            this.pickupFolderCleaner.UseVisualStyleBackColor = true;
            this.pickupFolderCleaner.Click += new System.EventHandler(this.pickupFolderCleaner_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 131);
            this.Controls.Add(this.pickupFolderCleaner);
            this.Controls.Add(this.chkSendToPickupFolder);
            this.Controls.Add(this.sendPlainTextMessageButton);
            this.Controls.Add(this.sendHtmlMessageButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendHtmlMessageButton;
        private System.Windows.Forms.Button sendPlainTextMessageButton;
        private System.Windows.Forms.CheckBox chkSendToPickupFolder;
        private System.Windows.Forms.Button pickupFolderCleaner;
    }
}

