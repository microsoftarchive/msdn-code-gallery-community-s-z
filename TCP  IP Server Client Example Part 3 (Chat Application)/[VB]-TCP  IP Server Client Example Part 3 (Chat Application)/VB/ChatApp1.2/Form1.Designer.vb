Namespace ChatApp1._2
	Partial Public Class FrmChatMain
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmChatMain))
			Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
			Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.menuConnect = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
			Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
			Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.editToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.undoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.redoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
			Me.cutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.copyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.pasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
			Me.selectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.customizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.contentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.indexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.searchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
			Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
			Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
			Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
			Me.lblFriendsOnline = New System.Windows.Forms.ToolStripStatusLabel()
			Me.lblOnlineStatusImage = New System.Windows.Forms.ToolStripStatusLabel()
			Me.flowPanel = New System.Windows.Forms.FlowLayoutPanel()
			Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
			Me.btnConnect = New System.Windows.Forms.ToolStripButton()
			Me.openToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.saveToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.printToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
			Me.cutToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.copyToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.pasteToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
			Me.helpToolStripButton = New System.Windows.Forms.ToolStripButton()
			Me.menuStrip1.SuspendLayout()
			Me.toolStripContainer1.BottomToolStripPanel.SuspendLayout()
			Me.toolStripContainer1.ContentPanel.SuspendLayout()
			Me.toolStripContainer1.TopToolStripPanel.SuspendLayout()
			Me.toolStripContainer1.SuspendLayout()
			Me.statusStrip1.SuspendLayout()
			Me.toolStrip1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' menuStrip1
			' 
			Me.menuStrip1.Dock = System.Windows.Forms.DockStyle.None
			Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.fileToolStripMenuItem, Me.editToolStripMenuItem, Me.toolsToolStripMenuItem, Me.helpToolStripMenuItem})
			Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
			Me.menuStrip1.Name = "menuStrip1"
			Me.menuStrip1.Size = New System.Drawing.Size(257, 24)
			Me.menuStrip1.TabIndex = 0
			Me.menuStrip1.Text = "menuStrip1"
			' 
			' fileToolStripMenuItem
			' 
			Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.menuConnect, Me.toolStripSeparator, Me.toolStripSeparator1, Me.exitToolStripMenuItem})
			Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
			Me.fileToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
			Me.fileToolStripMenuItem.Text = "ChatApp"
			' 
			' menuConnect
			' 
			Me.menuConnect.Image = My.Resources.Illustration_of_a_yellow_smiley_face2
			Me.menuConnect.ImageTransparentColor = System.Drawing.Color.Transparent
			Me.menuConnect.Name = "menuConnect"
			Me.menuConnect.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys))
			Me.menuConnect.Size = New System.Drawing.Size(162, 22)
			Me.menuConnect.Text = "&Connect"
'			Me.menuConnect.Click += New System.EventHandler(Me.MenuConnectClick)
			' 
			' toolStripSeparator
			' 
			Me.toolStripSeparator.Name = "toolStripSeparator"
			Me.toolStripSeparator.Size = New System.Drawing.Size(159, 6)
			' 
			' toolStripSeparator1
			' 
			Me.toolStripSeparator1.Name = "toolStripSeparator1"
			Me.toolStripSeparator1.Size = New System.Drawing.Size(159, 6)
			' 
			' exitToolStripMenuItem
			' 
			Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
			Me.exitToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
			Me.exitToolStripMenuItem.Text = "E&xit"
			' 
			' editToolStripMenuItem
			' 
			Me.editToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.undoToolStripMenuItem, Me.redoToolStripMenuItem, Me.toolStripSeparator3, Me.cutToolStripMenuItem, Me.copyToolStripMenuItem, Me.pasteToolStripMenuItem, Me.toolStripSeparator4, Me.selectAllToolStripMenuItem})
			Me.editToolStripMenuItem.Name = "editToolStripMenuItem"
			Me.editToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
			Me.editToolStripMenuItem.Text = "&Edit"
			' 
			' undoToolStripMenuItem
			' 
			Me.undoToolStripMenuItem.Name = "undoToolStripMenuItem"
			Me.undoToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys))
			Me.undoToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
			Me.undoToolStripMenuItem.Text = "&Undo"
			' 
			' redoToolStripMenuItem
			' 
			Me.redoToolStripMenuItem.Name = "redoToolStripMenuItem"
			Me.redoToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys))
			Me.redoToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
			Me.redoToolStripMenuItem.Text = "&Redo"
			' 
			' toolStripSeparator3
			' 
			Me.toolStripSeparator3.Name = "toolStripSeparator3"
			Me.toolStripSeparator3.Size = New System.Drawing.Size(141, 6)
			' 
			' cutToolStripMenuItem
			' 
			Me.cutToolStripMenuItem.Image = (DirectCast(resources.GetObject("cutToolStripMenuItem.Image"), System.Drawing.Image))
			Me.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.cutToolStripMenuItem.Name = "cutToolStripMenuItem"
			Me.cutToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys))
			Me.cutToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
			Me.cutToolStripMenuItem.Text = "Cu&t"
			' 
			' copyToolStripMenuItem
			' 
			Me.copyToolStripMenuItem.Image = (DirectCast(resources.GetObject("copyToolStripMenuItem.Image"), System.Drawing.Image))
			Me.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.copyToolStripMenuItem.Name = "copyToolStripMenuItem"
			Me.copyToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys))
			Me.copyToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
			Me.copyToolStripMenuItem.Text = "&Copy"
			' 
			' pasteToolStripMenuItem
			' 
			Me.pasteToolStripMenuItem.Image = (DirectCast(resources.GetObject("pasteToolStripMenuItem.Image"), System.Drawing.Image))
			Me.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem"
			Me.pasteToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys))
			Me.pasteToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
			Me.pasteToolStripMenuItem.Text = "&Paste"
			' 
			' toolStripSeparator4
			' 
			Me.toolStripSeparator4.Name = "toolStripSeparator4"
			Me.toolStripSeparator4.Size = New System.Drawing.Size(141, 6)
			' 
			' selectAllToolStripMenuItem
			' 
			Me.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem"
			Me.selectAllToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
			Me.selectAllToolStripMenuItem.Text = "Select &All"
			' 
			' toolsToolStripMenuItem
			' 
			Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.customizeToolStripMenuItem, Me.optionsToolStripMenuItem})
			Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
			Me.toolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
			Me.toolsToolStripMenuItem.Text = "&Tools"
			' 
			' customizeToolStripMenuItem
			' 
			Me.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem"
			Me.customizeToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
			Me.customizeToolStripMenuItem.Text = "&Customize"
			' 
			' optionsToolStripMenuItem
			' 
			Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
			Me.optionsToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
			Me.optionsToolStripMenuItem.Text = "&Options"
			' 
			' helpToolStripMenuItem
			' 
			Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.contentsToolStripMenuItem, Me.indexToolStripMenuItem, Me.searchToolStripMenuItem, Me.toolStripSeparator5, Me.aboutToolStripMenuItem})
			Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
			Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
			Me.helpToolStripMenuItem.Text = "&Help"
			' 
			' contentsToolStripMenuItem
			' 
			Me.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem"
			Me.contentsToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
			Me.contentsToolStripMenuItem.Text = "&Contents"
			' 
			' indexToolStripMenuItem
			' 
			Me.indexToolStripMenuItem.Name = "indexToolStripMenuItem"
			Me.indexToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
			Me.indexToolStripMenuItem.Text = "&Index"
			' 
			' searchToolStripMenuItem
			' 
			Me.searchToolStripMenuItem.Name = "searchToolStripMenuItem"
			Me.searchToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
			Me.searchToolStripMenuItem.Text = "&Search"
			' 
			' toolStripSeparator5
			' 
			Me.toolStripSeparator5.Name = "toolStripSeparator5"
			Me.toolStripSeparator5.Size = New System.Drawing.Size(119, 6)
			' 
			' aboutToolStripMenuItem
			' 
			Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
			Me.aboutToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
			Me.aboutToolStripMenuItem.Text = "&About..."
			' 
			' toolStripContainer1
			' 
			' 
			' toolStripContainer1.BottomToolStripPanel
			' 
			Me.toolStripContainer1.BottomToolStripPanel.Controls.Add(Me.statusStrip1)
			' 
			' toolStripContainer1.ContentPanel
			' 
			Me.toolStripContainer1.ContentPanel.Controls.Add(Me.flowPanel)
			Me.toolStripContainer1.ContentPanel.Size = New System.Drawing.Size(257, 543)
			Me.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.toolStripContainer1.Location = New System.Drawing.Point(0, 0)
			Me.toolStripContainer1.Name = "toolStripContainer1"
			Me.toolStripContainer1.Size = New System.Drawing.Size(257, 614)
			Me.toolStripContainer1.TabIndex = 1
			Me.toolStripContainer1.Text = "toolStripContainer1"
			' 
			' toolStripContainer1.TopToolStripPanel
			' 
			Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.menuStrip1)
			Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.toolStrip1)
			' 
			' statusStrip1
			' 
			Me.statusStrip1.Dock = System.Windows.Forms.DockStyle.None
			Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.toolStripStatusLabel1, Me.lblFriendsOnline, Me.lblOnlineStatusImage})
			Me.statusStrip1.Location = New System.Drawing.Point(0, 0)
			Me.statusStrip1.Name = "statusStrip1"
			Me.statusStrip1.Size = New System.Drawing.Size(257, 22)
			Me.statusStrip1.TabIndex = 0
			' 
			' toolStripStatusLabel1
			' 
			Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
			Me.toolStripStatusLabel1.Size = New System.Drawing.Size(86, 17)
			Me.toolStripStatusLabel1.Text = "Friends Online:"
			' 
			' lblFriendsOnline
			' 
			Me.lblFriendsOnline.Name = "lblFriendsOnline"
			Me.lblFriendsOnline.Size = New System.Drawing.Size(140, 17)
			Me.lblFriendsOnline.Spring = True
			Me.lblFriendsOnline.Text = "0"
			Me.lblFriendsOnline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' lblOnlineStatusImage
			' 
			Me.lblOnlineStatusImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.lblOnlineStatusImage.Image = My.Resources.red_47690_640
			Me.lblOnlineStatusImage.Name = "lblOnlineStatusImage"
			Me.lblOnlineStatusImage.Size = New System.Drawing.Size(16, 17)
			Me.lblOnlineStatusImage.Text = "toolStripStatusLabel2"
			' 
			' flowPanel
			' 
			Me.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me.flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
			Me.flowPanel.Location = New System.Drawing.Point(0, 0)
			Me.flowPanel.Name = "flowPanel"
			Me.flowPanel.Size = New System.Drawing.Size(257, 543)
			Me.flowPanel.TabIndex = 0
			' 
			' toolStrip1
			' 
			Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
			Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.btnConnect, Me.openToolStripButton, Me.saveToolStripButton, Me.printToolStripButton, Me.toolStripSeparator6, Me.cutToolStripButton, Me.copyToolStripButton, Me.pasteToolStripButton, Me.toolStripSeparator7, Me.helpToolStripButton})
			Me.toolStrip1.Location = New System.Drawing.Point(3, 24)
			Me.toolStrip1.Name = "toolStrip1"
			Me.toolStrip1.Size = New System.Drawing.Size(208, 25)
			Me.toolStrip1.TabIndex = 1
			' 
			' btnConnect
			' 
			Me.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.btnConnect.Image = My.Resources.Illustration_of_a_yellow_smiley_face2
			Me.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.btnConnect.Name = "btnConnect"
			Me.btnConnect.Size = New System.Drawing.Size(23, 22)
			Me.btnConnect.Text = "&New"
'			Me.btnConnect.Click += New System.EventHandler(Me.BtnConnectClick)
			' 
			' openToolStripButton
			' 
			Me.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.openToolStripButton.Image = (DirectCast(resources.GetObject("openToolStripButton.Image"), System.Drawing.Image))
			Me.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.openToolStripButton.Name = "openToolStripButton"
			Me.openToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.openToolStripButton.Text = "&Open"
			' 
			' saveToolStripButton
			' 
			Me.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.saveToolStripButton.Image = (DirectCast(resources.GetObject("saveToolStripButton.Image"), System.Drawing.Image))
			Me.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.saveToolStripButton.Name = "saveToolStripButton"
			Me.saveToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.saveToolStripButton.Text = "&Save"
			' 
			' printToolStripButton
			' 
			Me.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.printToolStripButton.Image = (DirectCast(resources.GetObject("printToolStripButton.Image"), System.Drawing.Image))
			Me.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.printToolStripButton.Name = "printToolStripButton"
			Me.printToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.printToolStripButton.Text = "&Print"
			' 
			' toolStripSeparator6
			' 
			Me.toolStripSeparator6.Name = "toolStripSeparator6"
			Me.toolStripSeparator6.Size = New System.Drawing.Size(6, 25)
			' 
			' cutToolStripButton
			' 
			Me.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.cutToolStripButton.Image = (DirectCast(resources.GetObject("cutToolStripButton.Image"), System.Drawing.Image))
			Me.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.cutToolStripButton.Name = "cutToolStripButton"
			Me.cutToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.cutToolStripButton.Text = "C&ut"
			' 
			' copyToolStripButton
			' 
			Me.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.copyToolStripButton.Image = (DirectCast(resources.GetObject("copyToolStripButton.Image"), System.Drawing.Image))
			Me.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.copyToolStripButton.Name = "copyToolStripButton"
			Me.copyToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.copyToolStripButton.Text = "&Copy"
			' 
			' pasteToolStripButton
			' 
			Me.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.pasteToolStripButton.Image = (DirectCast(resources.GetObject("pasteToolStripButton.Image"), System.Drawing.Image))
			Me.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.pasteToolStripButton.Name = "pasteToolStripButton"
			Me.pasteToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.pasteToolStripButton.Text = "&Paste"
			' 
			' toolStripSeparator7
			' 
			Me.toolStripSeparator7.Name = "toolStripSeparator7"
			Me.toolStripSeparator7.Size = New System.Drawing.Size(6, 25)
			' 
			' helpToolStripButton
			' 
			Me.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.helpToolStripButton.Image = (DirectCast(resources.GetObject("helpToolStripButton.Image"), System.Drawing.Image))
			Me.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.helpToolStripButton.Name = "helpToolStripButton"
			Me.helpToolStripButton.Size = New System.Drawing.Size(23, 22)
			Me.helpToolStripButton.Text = "He&lp"
			' 
			' FrmChatMain
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(257, 614)
			Me.Controls.Add(Me.toolStripContainer1)
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.MainMenuStrip = Me.menuStrip1
			Me.Name = "FrmChatMain"
			Me.Text = "ChatApp"
			Me.menuStrip1.ResumeLayout(False)
			Me.menuStrip1.PerformLayout()
			Me.toolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
			Me.toolStripContainer1.BottomToolStripPanel.PerformLayout()
			Me.toolStripContainer1.ContentPanel.ResumeLayout(False)
			Me.toolStripContainer1.TopToolStripPanel.ResumeLayout(False)
			Me.toolStripContainer1.TopToolStripPanel.PerformLayout()
			Me.toolStripContainer1.ResumeLayout(False)
			Me.toolStripContainer1.PerformLayout()
			Me.statusStrip1.ResumeLayout(False)
			Me.statusStrip1.PerformLayout()
			Me.toolStrip1.ResumeLayout(False)
			Me.toolStrip1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private menuStrip1 As System.Windows.Forms.MenuStrip
		Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents menuConnect As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator As System.Windows.Forms.ToolStripSeparator
		Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
		Private exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private editToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private undoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private redoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
		Private cutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private copyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private pasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
		Private selectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private customizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private contentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private indexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private searchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
		Private aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripContainer1 As System.Windows.Forms.ToolStripContainer
		Private statusStrip1 As System.Windows.Forms.StatusStrip
		Private toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
		Private toolStrip1 As System.Windows.Forms.ToolStrip
		Private WithEvents btnConnect As System.Windows.Forms.ToolStripButton
		Private openToolStripButton As System.Windows.Forms.ToolStripButton
		Private saveToolStripButton As System.Windows.Forms.ToolStripButton
		Private printToolStripButton As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
		Private cutToolStripButton As System.Windows.Forms.ToolStripButton
		Private copyToolStripButton As System.Windows.Forms.ToolStripButton
		Private pasteToolStripButton As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
		Private helpToolStripButton As System.Windows.Forms.ToolStripButton
		Private lblFriendsOnline As System.Windows.Forms.ToolStripStatusLabel
		Private flowPanel As System.Windows.Forms.FlowLayoutPanel
		Private lblOnlineStatusImage As System.Windows.Forms.ToolStripStatusLabel
	End Class
End Namespace

