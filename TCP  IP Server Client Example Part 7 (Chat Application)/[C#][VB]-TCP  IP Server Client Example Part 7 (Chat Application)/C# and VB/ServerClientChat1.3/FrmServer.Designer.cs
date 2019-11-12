namespace ServerClientChat1._3
{
    partial class FrmServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServer));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblConnectionState = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalLoggedInUsers = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalConnectedUsers = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotalRegisteredUsers = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbConOut = new System.Windows.Forms.RichTextBox();
            this.btnCloseDown = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Progress,
            this.toolStripStatusLabel1,
            this.lblConnectionState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 377);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(884, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Progress
            // 
            this.Progress.ForeColor = System.Drawing.Color.Lime;
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(100, 19);
            this.Progress.Step = 1;
            this.Progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(751, 20);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // lblConnectionState
            // 
            this.lblConnectionState.Image = global::ServerClientChat1._3.Properties.Resources.database_blue;
            this.lblConnectionState.Name = "lblConnectionState";
            this.lblConnectionState.Size = new System.Drawing.Size(16, 20);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCloseDown);
            this.groupBox1.Controls.Add(this.lblPort);
            this.groupBox1.Controls.Add(this.lblIPAddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Location = new System.Drawing.Point(614, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 365);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controller";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(74, 43);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(37, 13);
            this.lblPort.TabIndex = 4;
            this.lblPort.Text = "00000";
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Location = new System.Drawing.Point(74, 30);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(88, 13);
            this.lblIPAddress.TabIndex = 3;
            this.lblIPAddress.Text = "000.000.000.000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP Address:";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.ForeColor = System.Drawing.Color.Yellow;
            this.btnStop.Location = new System.Drawing.Point(177, 336);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblTotalLoggedInUsers);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblTotalConnectedUsers);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(595, 188);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logged On Users";
            // 
            // lblTotalLoggedInUsers
            // 
            this.lblTotalLoggedInUsers.AutoSize = true;
            this.lblTotalLoggedInUsers.Location = new System.Drawing.Point(131, 42);
            this.lblTotalLoggedInUsers.Name = "lblTotalLoggedInUsers";
            this.lblTotalLoggedInUsers.Size = new System.Drawing.Size(13, 13);
            this.lblTotalLoggedInUsers.TabIndex = 5;
            this.lblTotalLoggedInUsers.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Total Logged in Users:";
            // 
            // lblTotalConnectedUsers
            // 
            this.lblTotalConnectedUsers.AutoSize = true;
            this.lblTotalConnectedUsers.Location = new System.Drawing.Point(131, 29);
            this.lblTotalConnectedUsers.Name = "lblTotalConnectedUsers";
            this.lblTotalConnectedUsers.Size = new System.Drawing.Size(13, 13);
            this.lblTotalConnectedUsers.TabIndex = 3;
            this.lblTotalConnectedUsers.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total Connected Users:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblTotalRegisteredUsers);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(13, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(595, 63);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Registered Users";
            // 
            // lblTotalRegisteredUsers
            // 
            this.lblTotalRegisteredUsers.AutoSize = true;
            this.lblTotalRegisteredUsers.Location = new System.Drawing.Point(131, 25);
            this.lblTotalRegisteredUsers.Name = "lblTotalRegisteredUsers";
            this.lblTotalRegisteredUsers.Size = new System.Drawing.Size(13, 13);
            this.lblTotalRegisteredUsers.TabIndex = 1;
            this.lblTotalRegisteredUsers.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Registered Users:";
            // 
            // rtbConOut
            // 
            this.rtbConOut.BackColor = System.Drawing.SystemColors.Control;
            this.rtbConOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbConOut.DetectUrls = false;
            this.rtbConOut.Location = new System.Drawing.Point(13, 281);
            this.rtbConOut.Name = "rtbConOut";
            this.rtbConOut.ReadOnly = true;
            this.rtbConOut.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbConOut.ShowSelectionMargin = true;
            this.rtbConOut.Size = new System.Drawing.Size(595, 96);
            this.rtbConOut.TabIndex = 0;
            this.rtbConOut.Text = "";
            // 
            // btnCloseDown
            // 
            this.btnCloseDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseDown.BackColor = System.Drawing.Color.Red;
            this.btnCloseDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseDown.ForeColor = System.Drawing.Color.Yellow;
            this.btnCloseDown.Location = new System.Drawing.Point(10, 336);
            this.btnCloseDown.Name = "btnCloseDown";
            this.btnCloseDown.Size = new System.Drawing.Size(75, 23);
            this.btnCloseDown.TabIndex = 5;
            this.btnCloseDown.Text = "Close";
            this.btnCloseDown.UseVisualStyleBackColor = false;
            this.btnCloseDown.Click += new System.EventHandler(this.btnCloseDown_Click);
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 402);
            this.ControlBox = false;
            this.Controls.Add(this.rtbConOut);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmServer";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmServer_FormClosing);
            this.Load += new System.EventHandler(this.FrmServer_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar Progress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTotalConnectedUsers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalRegisteredUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalLoggedInUsers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionState;
        private System.Windows.Forms.RichTextBox rtbConOut;
        private System.Windows.Forms.Button btnCloseDown;
    }
}

