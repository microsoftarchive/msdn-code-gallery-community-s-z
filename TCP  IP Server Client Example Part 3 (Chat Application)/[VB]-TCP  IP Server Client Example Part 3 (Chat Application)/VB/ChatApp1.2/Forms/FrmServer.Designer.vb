Namespace ChatApp1._2.Forms
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
			Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
			Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.newToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
			Me.saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.saveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
			Me.printToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.printPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
			Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
			Me.lblConnections = New System.Windows.Forms.ToolStripStatusLabel()
			Me.lblConnectionStatusImage = New System.Windows.Forms.ToolStripStatusLabel()
			Me.rtbConOut = New System.Windows.Forms.RichTextBox()
			Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
			Me.btnConnect = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
			Me.BtnNewClient = New System.Windows.Forms.ToolStripButton()
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
			Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.fileToolStripMenuItem, Me.toolsToolStripMenuItem, Me.helpToolStripMenuItem})
			Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
			Me.menuStrip1.Name = "menuStrip1"
			Me.menuStrip1.Size = New System.Drawing.Size(298, 24)
			Me.menuStrip1.TabIndex = 0
			Me.menuStrip1.Text = "menuStrip1"
			' 
			' fileToolStripMenuItem
			' 
			Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.newToolStripMenuItem, Me.openToolStripMenuItem, Me.toolStripSeparator, Me.saveToolStripMenuItem, Me.saveAsToolStripMenuItem, Me.toolStripSeparator1, Me.printToolStripMenuItem, Me.printPreviewToolStripMenuItem, Me.toolStripSeparator2, Me.exitToolStripMenuItem})
			Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
			Me.fileToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
			Me.fileToolStripMenuItem.Text = "&Server"
			' 
			' newToolStripMenuItem
			' 
			Me.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.newToolStripMenuItem.Name = "newToolStripMenuItem"
			Me.newToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys))
			Me.newToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
			Me.newToolStripMenuItem.Text = "Start"
'			Me.newToolStripMenuItem.Click += New System.EventHandler(Me.NewToolStripMenuItemClick)
			' 
			' openToolStripMenuItem
			' 
			Me.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
			Me.openToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys))
			Me.openToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
			Me.openToolStripMenuItem.Text = "Stop"
'			Me.openToolStripMenuItem.Click += New System.EventHandler(Me.OpenToolStripMenuItemClick)
			' 
			' toolStripSeparator
			' 
			Me.toolStripSeparator.Name = "toolStripSeparator"
			Me.toolStripSeparator.Size = New System.Drawing.Size(140, 6)
			' 
			' saveToolStripMenuItem
			' 
			Me.saveToolStripMenuItem.Image = (DirectCast(resources.GetObject("saveToolStripMenuItem.Image"), System.Drawing.Image))
			Me.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.saveToolStripMenuItem.Name = "saveToolStripMenuItem"
			Me.saveToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys))
			Me.saveToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
			Me.saveToolStripMenuItem.Text = "&Save"
			' 
			' saveAsToolStripMenuItem
			' 
			Me.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem"
			Me.saveAsToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
			Me.saveAsToolStripMenuItem.Text = "Save &As"
			' 
			' toolStripSeparator1
			' 
			Me.toolStripSeparator1.Name = "toolStripSeparator1"
			Me.toolStripSeparator1.Size = New System.Drawing.Size(140, 6)
			' 
			' printToolStripMenuItem
			' 
			Me.printToolStripMenuItem.Image = (DirectCast(resources.GetObject("printToolStripMenuItem.Image"), System.Drawing.Image))
			Me.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.printToolStripMenuItem.Name = "printToolStripMenuItem"
			Me.printToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys))
			Me.printToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
			Me.printToolStripMenuItem.Text = "&Print"
			' 
			' printPreviewToolStripMenuItem
			' 
			Me.printPreviewToolStripMenuItem.Image = (DirectCast(resources.GetObject("printPreviewToolStripMenuItem.Image"), System.Drawing.Image))
			Me.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem"
			Me.printPreviewToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
			Me.printPreviewToolStripMenuItem.Text = "Print Pre&view"
			' 
			' toolStripSeparator2
			' 
			Me.toolStripSeparator2.Name = "toolStripSeparator2"
			Me.toolStripSeparator2.Size = New System.Drawing.Size(140, 6)
			' 
			' exitToolStripMenuItem
			' 
			Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
			Me.exitToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
			Me.exitToolStripMenuItem.Text = "E&xit"
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
			Me.toolStripContainer1.ContentPanel.Controls.Add(Me.rtbConOut)
			Me.toolStripContainer1.ContentPanel.Size = New System.Drawing.Size(298, 525)
			Me.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.toolStripContainer1.Location = New System.Drawing.Point(0, 0)
			Me.toolStripContainer1.Name = "toolStripContainer1"
			Me.toolStripContainer1.Size = New System.Drawing.Size(298, 596)
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
			Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.toolStripStatusLabel1, Me.lblConnections, Me.lblConnectionStatusImage})
			Me.statusStrip1.Location = New System.Drawing.Point(0, 0)
			Me.statusStrip1.Name = "statusStrip1"
			Me.statusStrip1.Size = New System.Drawing.Size(298, 22)
			Me.statusStrip1.SizingGrip = False
			Me.statusStrip1.TabIndex = 0
			' 
			' toolStripStatusLabel1
			' 
			Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
			Me.toolStripStatusLabel1.Size = New System.Drawing.Size(77, 17)
			Me.toolStripStatusLabel1.Text = "Connections:"
			' 
			' lblConnections
			' 
			Me.lblConnections.Name = "lblConnections"
			Me.lblConnections.Size = New System.Drawing.Size(190, 17)
			Me.lblConnections.Spring = True
			Me.lblConnections.Text = "0"
			Me.lblConnections.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' lblConnectionStatusImage
			' 
			Me.lblConnectionStatusImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.lblConnectionStatusImage.Image = My.Resources.red_47690_640
			Me.lblConnectionStatusImage.Name = "lblConnectionStatusImage"
			Me.lblConnectionStatusImage.Size = New System.Drawing.Size(16, 17)
			Me.lblConnectionStatusImage.Text = "toolStripStatusLabel2"
			' 
			' rtbConOut
			' 
			Me.rtbConOut.BackColor = System.Drawing.Color.RoyalBlue
			Me.rtbConOut.BorderStyle = System.Windows.Forms.BorderStyle.None
			Me.rtbConOut.DetectUrls = False
			Me.rtbConOut.Dock = System.Windows.Forms.DockStyle.Fill
			Me.rtbConOut.ForeColor = System.Drawing.Color.Yellow
			Me.rtbConOut.Location = New System.Drawing.Point(0, 0)
			Me.rtbConOut.Name = "rtbConOut"
			Me.rtbConOut.ShowSelectionMargin = True
			Me.rtbConOut.Size = New System.Drawing.Size(298, 525)
			Me.rtbConOut.TabIndex = 0
			Me.rtbConOut.Text = ""
			Me.rtbConOut.WordWrap = False
			' 
			' toolStrip1
			' 
			Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
			Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.btnConnect, Me.toolStripSeparator3, Me.BtnNewClient})
			Me.toolStrip1.Location = New System.Drawing.Point(3, 24)
			Me.toolStrip1.Name = "toolStrip1"
			Me.toolStrip1.Size = New System.Drawing.Size(95, 25)
			Me.toolStrip1.TabIndex = 1
			' 
			' btnConnect
			' 
			Me.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.btnConnect.Image = My.Resources.Illustration_of_a_yellow_smiley_face2
			Me.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.btnConnect.Name = "btnConnect"
			Me.btnConnect.Size = New System.Drawing.Size(23, 22)
			Me.btnConnect.Text = "toolStripButton1"
			' 
			' toolStripSeparator3
			' 
			Me.toolStripSeparator3.Name = "toolStripSeparator3"
			Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
			' 
			' BtnNewClient
			' 
			Me.BtnNewClient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.BtnNewClient.Image = My.Resources.company_overview_careers
			Me.BtnNewClient.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.BtnNewClient.Name = "BtnNewClient"
			Me.BtnNewClient.Size = New System.Drawing.Size(23, 22)
'			Me.BtnNewClient.Click += New System.EventHandler(Me.BtnNewClient_Click)
			' 
			' FrmServer
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(298, 596)
			Me.Controls.Add(Me.toolStripContainer1)
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.MainMenuStrip = Me.menuStrip1
			Me.Name = "FrmServer"
			Me.Text = "Server"
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
		Private WithEvents newToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator As System.Windows.Forms.ToolStripSeparator
		Private saveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private saveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
		Private printToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private printPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
		Private exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
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
		Private lblConnections As System.Windows.Forms.ToolStripStatusLabel
		Private lblConnectionStatusImage As System.Windows.Forms.ToolStripStatusLabel
		Private toolStrip1 As System.Windows.Forms.ToolStrip
		Private btnConnect As System.Windows.Forms.ToolStripButton
		Private WithEvents BtnNewClient As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
		Private rtbConOut As System.Windows.Forms.RichTextBox
	End Class
End Namespace