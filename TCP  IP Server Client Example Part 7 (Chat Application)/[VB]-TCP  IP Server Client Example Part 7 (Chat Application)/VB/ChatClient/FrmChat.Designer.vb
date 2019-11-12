Namespace ChatClient
	Partial Public Class FrmChat
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmChat))
			Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
			Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
			Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
			Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
			Me.lblConnectionStatus = New System.Windows.Forms.ToolStripStatusLabel()
			Me.btnConnect = New System.Windows.Forms.ToolStripButton()
			Me.btnAddFriend = New System.Windows.Forms.ToolStripButton()
			Me.toolStrip1.SuspendLayout()
			Me.statusStrip1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' toolStrip1
			' 
			Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.btnConnect, Me.btnAddFriend})
			Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
			Me.toolStrip1.Name = "toolStrip1"
			Me.toolStrip1.Size = New System.Drawing.Size(287, 25)
			Me.toolStrip1.TabIndex = 2
			Me.toolStrip1.Text = "toolStrip1"
			' 
			' statusStrip1
			' 
			Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.toolStripStatusLabel1, Me.lblStatus, Me.lblConnectionStatus})
			Me.statusStrip1.Location = New System.Drawing.Point(0, 459)
			Me.statusStrip1.Name = "statusStrip1"
			Me.statusStrip1.Size = New System.Drawing.Size(287, 25)
			Me.statusStrip1.TabIndex = 3
			Me.statusStrip1.Text = "statusStrip1"
			' 
			' lblStatus
			' 
			Me.lblStatus.Name = "lblStatus"
			Me.lblStatus.Size = New System.Drawing.Size(210, 20)
			Me.lblStatus.Spring = True
			Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' toolStripStatusLabel1
			' 
			Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
			Me.toolStripStatusLabel1.Size = New System.Drawing.Size(42, 20)
			Me.toolStripStatusLabel1.Text = "Status:"
			' 
			' lblConnectionStatus
			' 
			Me.lblConnectionStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
			Me.lblConnectionStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.lblConnectionStatus.Image = My.Resources.red_x_icon
			Me.lblConnectionStatus.Name = "lblConnectionStatus"
			Me.lblConnectionStatus.Size = New System.Drawing.Size(20, 20)
'			Me.lblConnectionStatus.DoubleClick += New System.EventHandler(Me.lblConnectionStatus_DoubleClick)
			' 
			' btnConnect
			' 
			Me.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.btnConnect.Image = My.Resources.Connect
			Me.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.btnConnect.Name = "btnConnect"
			Me.btnConnect.Size = New System.Drawing.Size(23, 22)
			Me.btnConnect.ToolTipText = "Connect To Server"
'			Me.btnConnect.Click += New System.EventHandler(Me.btnConnect_Click)
			' 
			' btnAddFriend
			' 
			Me.btnAddFriend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.btnAddFriend.Enabled = False
			Me.btnAddFriend.Image = My.Resources.NewUser
			Me.btnAddFriend.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.btnAddFriend.Name = "btnAddFriend"
			Me.btnAddFriend.Size = New System.Drawing.Size(23, 22)
			Me.btnAddFriend.ToolTipText = "Add Friend"
'			Me.btnAddFriend.Click += New System.EventHandler(Me.btnAddFriend_Click)
			' 
			' FrmChat
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(287, 484)
			Me.Controls.Add(Me.statusStrip1)
			Me.Controls.Add(Me.toolStrip1)
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.Name = "FrmChat"
			Me.Text = "Chat :"
			Me.toolStrip1.ResumeLayout(False)
			Me.toolStrip1.PerformLayout()
			Me.statusStrip1.ResumeLayout(False)
			Me.statusStrip1.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private toolStrip1 As System.Windows.Forms.ToolStrip
		Private WithEvents btnConnect As System.Windows.Forms.ToolStripButton
		Private statusStrip1 As System.Windows.Forms.StatusStrip
		Private lblStatus As System.Windows.Forms.ToolStripStatusLabel
		Private WithEvents lblConnectionStatus As System.Windows.Forms.ToolStripStatusLabel
		Private toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
		Private WithEvents btnAddFriend As System.Windows.Forms.ToolStripButton
	End Class
End Namespace

