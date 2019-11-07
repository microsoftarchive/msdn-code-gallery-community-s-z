Namespace ServerClientChat1._3
	Partial Public Class FrmServer
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmServer))
			Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
			Me.Progress = New System.Windows.Forms.ToolStripProgressBar()
			Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
			Me.lblConnectionState = New System.Windows.Forms.ToolStripStatusLabel()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.lblPort = New System.Windows.Forms.Label()
			Me.lblIPAddress = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.btnStop = New System.Windows.Forms.Button()
			Me.groupBox2 = New System.Windows.Forms.GroupBox()
			Me.lblTotalLoggedInUsers = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.lblTotalConnectedUsers = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.groupBox3 = New System.Windows.Forms.GroupBox()
			Me.lblTotalRegisteredUsers = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.rtbConOut = New System.Windows.Forms.RichTextBox()
			Me.btnCloseDown = New System.Windows.Forms.Button()
			Me.statusStrip1.SuspendLayout()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' statusStrip1
			' 
			Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.Progress, Me.toolStripStatusLabel1, Me.lblConnectionState})
			Me.statusStrip1.Location = New System.Drawing.Point(0, 377)
			Me.statusStrip1.Name = "statusStrip1"
			Me.statusStrip1.ShowItemToolTips = True
			Me.statusStrip1.Size = New System.Drawing.Size(884, 25)
			Me.statusStrip1.TabIndex = 0
			Me.statusStrip1.Text = "statusStrip1"
			' 
			' Progress
			' 
			Me.Progress.ForeColor = System.Drawing.Color.Lime
			Me.Progress.Name = "Progress"
			Me.Progress.Size = New System.Drawing.Size(100, 19)
			Me.Progress.Step = 1
			Me.Progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee
			' 
			' toolStripStatusLabel1
			' 
			Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
			Me.toolStripStatusLabel1.Size = New System.Drawing.Size(751, 20)
			Me.toolStripStatusLabel1.Spring = True
			' 
			' lblConnectionState
			' 
			Me.lblConnectionState.Image = My.Resources.database_blue
			Me.lblConnectionState.Name = "lblConnectionState"
			Me.lblConnectionState.Size = New System.Drawing.Size(16, 20)
			' 
			' groupBox1
			' 
			Me.groupBox1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.groupBox1.Controls.Add(Me.btnCloseDown)
			Me.groupBox1.Controls.Add(Me.lblPort)
			Me.groupBox1.Controls.Add(Me.lblIPAddress)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.btnStop)
			Me.groupBox1.Location = New System.Drawing.Point(614, 12)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(258, 365)
			Me.groupBox1.TabIndex = 1
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Controller"
			' 
			' lblPort
			' 
			Me.lblPort.AutoSize = True
			Me.lblPort.Location = New System.Drawing.Point(74, 43)
			Me.lblPort.Name = "lblPort"
			Me.lblPort.Size = New System.Drawing.Size(37, 13)
			Me.lblPort.TabIndex = 4
			Me.lblPort.Text = "00000"
			' 
			' lblIPAddress
			' 
			Me.lblIPAddress.AutoSize = True
			Me.lblIPAddress.Location = New System.Drawing.Point(74, 30)
			Me.lblIPAddress.Name = "lblIPAddress"
			Me.lblIPAddress.Size = New System.Drawing.Size(88, 13)
			Me.lblIPAddress.TabIndex = 3
			Me.lblIPAddress.Text = "000.000.000.000"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(39, 43)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(29, 13)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Port:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(7, 30)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(61, 13)
			Me.label2.TabIndex = 1
			Me.label2.Text = "IP Address:"
			' 
			' btnStop
			' 
			Me.btnStop.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnStop.BackColor = System.Drawing.Color.Red
			Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup
			Me.btnStop.ForeColor = System.Drawing.Color.Yellow
			Me.btnStop.Location = New System.Drawing.Point(177, 336)
			Me.btnStop.Name = "btnStop"
			Me.btnStop.Size = New System.Drawing.Size(75, 23)
			Me.btnStop.TabIndex = 0
			Me.btnStop.Text = "Stop"
			Me.btnStop.UseVisualStyleBackColor = False
			' 
			' groupBox2
			' 
			Me.groupBox2.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.groupBox2.Controls.Add(Me.lblTotalLoggedInUsers)
			Me.groupBox2.Controls.Add(Me.label6)
			Me.groupBox2.Controls.Add(Me.lblTotalConnectedUsers)
			Me.groupBox2.Controls.Add(Me.label4)
			Me.groupBox2.Location = New System.Drawing.Point(13, 13)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(595, 188)
			Me.groupBox2.TabIndex = 2
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Logged On Users"
			' 
			' lblTotalLoggedInUsers
			' 
			Me.lblTotalLoggedInUsers.AutoSize = True
			Me.lblTotalLoggedInUsers.Location = New System.Drawing.Point(131, 42)
			Me.lblTotalLoggedInUsers.Name = "lblTotalLoggedInUsers"
			Me.lblTotalLoggedInUsers.Size = New System.Drawing.Size(13, 13)
			Me.lblTotalLoggedInUsers.TabIndex = 5
			Me.lblTotalLoggedInUsers.Text = "0"
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(10, 42)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(114, 13)
			Me.label6.TabIndex = 4
			Me.label6.Text = "Total Logged in Users:"
			' 
			' lblTotalConnectedUsers
			' 
			Me.lblTotalConnectedUsers.AutoSize = True
			Me.lblTotalConnectedUsers.Location = New System.Drawing.Point(131, 29)
			Me.lblTotalConnectedUsers.Name = "lblTotalConnectedUsers"
			Me.lblTotalConnectedUsers.Size = New System.Drawing.Size(13, 13)
			Me.lblTotalConnectedUsers.TabIndex = 3
			Me.lblTotalConnectedUsers.Text = "0"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(6, 29)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(119, 13)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Total Connected Users:"
			' 
			' groupBox3
			' 
			Me.groupBox3.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.groupBox3.Controls.Add(Me.lblTotalRegisteredUsers)
			Me.groupBox3.Controls.Add(Me.label1)
			Me.groupBox3.Location = New System.Drawing.Point(13, 212)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(595, 63)
			Me.groupBox3.TabIndex = 3
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Registered Users"
			' 
			' lblTotalRegisteredUsers
			' 
			Me.lblTotalRegisteredUsers.AutoSize = True
			Me.lblTotalRegisteredUsers.Location = New System.Drawing.Point(131, 25)
			Me.lblTotalRegisteredUsers.Name = "lblTotalRegisteredUsers"
			Me.lblTotalRegisteredUsers.Size = New System.Drawing.Size(13, 13)
			Me.lblTotalRegisteredUsers.TabIndex = 1
			Me.lblTotalRegisteredUsers.Text = "0"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(6, 25)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(118, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Total Registered Users:"
			' 
			' rtbConOut
			' 
			Me.rtbConOut.BackColor = System.Drawing.SystemColors.Control
			Me.rtbConOut.BorderStyle = System.Windows.Forms.BorderStyle.None
			Me.rtbConOut.DetectUrls = False
			Me.rtbConOut.Location = New System.Drawing.Point(13, 281)
			Me.rtbConOut.Name = "rtbConOut"
			Me.rtbConOut.ReadOnly = True
			Me.rtbConOut.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
			Me.rtbConOut.ShowSelectionMargin = True
			Me.rtbConOut.Size = New System.Drawing.Size(595, 96)
			Me.rtbConOut.TabIndex = 0
			Me.rtbConOut.Text = ""
			' 
			' btnCloseDown
			' 
			Me.btnCloseDown.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnCloseDown.BackColor = System.Drawing.Color.Red
			Me.btnCloseDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup
			Me.btnCloseDown.ForeColor = System.Drawing.Color.Yellow
			Me.btnCloseDown.Location = New System.Drawing.Point(10, 336)
			Me.btnCloseDown.Name = "btnCloseDown"
			Me.btnCloseDown.Size = New System.Drawing.Size(75, 23)
			Me.btnCloseDown.TabIndex = 5
			Me.btnCloseDown.Text = "Close"
			Me.btnCloseDown.UseVisualStyleBackColor = False
'			Me.btnCloseDown.Click += New System.EventHandler(Me.btnCloseDown_Click)
			' 
			' FrmServer
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(884, 402)
			Me.ControlBox = False
			Me.Controls.Add(Me.rtbConOut)
			Me.Controls.Add(Me.groupBox3)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.statusStrip1)
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.Name = "FrmServer"
			Me.Text = "Server"
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.FrmServer_FormClosing)
'			Me.Load += New System.EventHandler(Me.FrmServer_Load)
			Me.statusStrip1.ResumeLayout(False)
			Me.statusStrip1.PerformLayout()
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			Me.groupBox3.ResumeLayout(False)
			Me.groupBox3.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private statusStrip1 As System.Windows.Forms.StatusStrip
		Private Progress As System.Windows.Forms.ToolStripProgressBar
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private btnStop As System.Windows.Forms.Button
		Private groupBox2 As System.Windows.Forms.GroupBox
		Private groupBox3 As System.Windows.Forms.GroupBox
		Private lblTotalConnectedUsers As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private lblTotalRegisteredUsers As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private lblPort As System.Windows.Forms.Label
		Private lblIPAddress As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private lblTotalLoggedInUsers As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
		Private lblConnectionState As System.Windows.Forms.ToolStripStatusLabel
		Private rtbConOut As System.Windows.Forms.RichTextBox
		Private WithEvents btnCloseDown As System.Windows.Forms.Button
	End Class
End Namespace

