Partial Class frmMain
	''' <summary>
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary>
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(disposing As Boolean)
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
		Me.components = New System.ComponentModel.Container()
		Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
		Me.txtNewMessage = New Proshot.UtilityLib.TextBox()
		Me.cnxMnuEdit = New Proshot.UtilityLib.ContextMenuStrip()
		Me.mniCopy = New System.Windows.Forms.ToolStripMenuItem()
		Me.mniPaste = New System.Windows.Forms.ToolStripMenuItem()
		Me.lblNewMessage = New Proshot.UtilityLib.Label()
		Me.btnSend = New Proshot.UtilityLib.Button()
		Me.imgList = New System.Windows.Forms.ImageList(Me.components)
		Me.btnPrivate = New Proshot.UtilityLib.Button()
		Me.mnuMain = New Proshot.UtilityLib.MenuStrip()
		Me.mniChat = New System.Windows.Forms.ToolStripMenuItem()
		Me.mniEnter = New System.Windows.Forms.ToolStripMenuItem()
		Me.mniPrivate = New System.Windows.Forms.ToolStripMenuItem()
		Me.mniSave = New System.Windows.Forms.ToolStripMenuItem()
		Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
		Me.mniExit = New System.Windows.Forms.ToolStripMenuItem()
		Me.splitContainer = New System.Windows.Forms.SplitContainer()
		Me.lstViwUsers = New Proshot.UtilityLib.ListView()
		Me.colIcon = New System.Windows.Forms.ColumnHeader()
		Me.colUserName = New System.Windows.Forms.ColumnHeader()
		Me.txtMessages = New System.Windows.Forms.RichTextBox()
		Me.cnxMniCopy = New Proshot.UtilityLib.ContextMenuStrip()
		Me.mniCopyText = New System.Windows.Forms.ToolStripMenuItem()
		Me.cnxMnuEdit.SuspendLayout()
		Me.mnuMain.SuspendLayout()
		Me.splitContainer.Panel1.SuspendLayout()
		Me.splitContainer.Panel2.SuspendLayout()
		Me.splitContainer.SuspendLayout()
		Me.cnxMniCopy.SuspendLayout()
		Me.SuspendLayout()
		' 
		' txtNewMessage
		' 
		Me.txtNewMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtNewMessage.BorderWidth = 1F
		Me.txtNewMessage.ContextMenuStrip = Me.cnxMnuEdit
		Me.txtNewMessage.FloatValue = 0
		Me.txtNewMessage.Location = New System.Drawing.Point(204, 427)
		Me.txtNewMessage.Name = "txtNewMessage"
		Me.txtNewMessage.Size = New System.Drawing.Size(353, 21)
		Me.txtNewMessage.TabIndex = 1
		' 
		' cnxMnuEdit
		' 
		Me.cnxMnuEdit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniCopy, Me.mniPaste})
		Me.cnxMnuEdit.Name = "cnxMnuEdit"
		Me.cnxMnuEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.cnxMnuEdit.Size = New System.Drawing.Size(130, 48)
		' 
		' mniCopy
		' 
		Me.mniCopy.Name = "mniCopy"
		Me.mniCopy.Size = New System.Drawing.Size(129, 22)
		Me.mniCopy.Text = "کپی متن"
		AddHandler Me.mniCopy.Click, New System.EventHandler(AddressOf Me.mniCopy_Click)
		' 
		' mniPaste
		' 
		Me.mniPaste.Name = "mniPaste"
		Me.mniPaste.Size = New System.Drawing.Size(129, 22)
		Me.mniPaste.Text = "انداختن متن"
		AddHandler Me.mniPaste.Click, New System.EventHandler(AddressOf Me.mniPaste_Click)
		' 
		' lblNewMessage
		' 
		Me.lblNewMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblNewMessage.AutoSize = True
		Me.lblNewMessage.BorderWidth = 1F
		Me.lblNewMessage.Location = New System.Drawing.Point(137, 430)
		Me.lblNewMessage.Name = "lblNewMessage"
		Me.lblNewMessage.Size = New System.Drawing.Size(56, 13)
		Me.lblNewMessage.TabIndex = 2
		Me.lblNewMessage.Text = "Message :"
		' 
		' btnSend
		' 
		Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnSend.ImageKey = "SendMessage.ico"
		Me.btnSend.ImageList = Me.imgList
		Me.btnSend.Location = New System.Drawing.Point(563, 426)
		Me.btnSend.Name = "btnSend"
		Me.btnSend.Size = New System.Drawing.Size(67, 23)
		Me.btnSend.TabIndex = 3
		Me.btnSend.Text = "Send"
		Me.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnSend.UseVisualStyleBackColor = True
		AddHandler Me.btnSend.Click, New System.EventHandler(AddressOf Me.btnSend_Click)
		' 
		' imgList
		' 
		Me.imgList.ImageStream = DirectCast(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imgList.TransparentColor = System.Drawing.Color.Transparent
		Me.imgList.Images.SetKeyName(0, "Smiely.png")
		Me.imgList.Images.SetKeyName(1, "Private.ico")
		Me.imgList.Images.SetKeyName(2, "SendMessage.ico")
		Me.imgList.Images.SetKeyName(3, "Enter.ico")
		Me.imgList.Images.SetKeyName(4, "Exit.ico")
		' 
		' btnPrivate
		' 
		Me.btnPrivate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnPrivate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnPrivate.ImageKey = "Private.ico"
		Me.btnPrivate.ImageList = Me.imgList
		Me.btnPrivate.Location = New System.Drawing.Point(6, 424)
		Me.btnPrivate.Name = "btnPrivate"
		Me.btnPrivate.Size = New System.Drawing.Size(123, 23)
		Me.btnPrivate.TabIndex = 6
		Me.btnPrivate.Text = "Private Chat"
		Me.btnPrivate.UseVisualStyleBackColor = True
		AddHandler Me.btnPrivate.Click, New System.EventHandler(AddressOf Me.btnPrivate_Click)
		' 
		' mnuMain
		' 
		Me.mnuMain.BackgroundImage = DirectCast(resources.GetObject("mnuMain.BackgroundImage"), System.Drawing.Image)
		Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniChat})
		Me.mnuMain.Location = New System.Drawing.Point(0, 0)
		Me.mnuMain.Name = "mnuMain"
		Me.mnuMain.Size = New System.Drawing.Size(635, 24)
		Me.mnuMain.TabIndex = 7
		' 
		' mniChat
		' 
		Me.mniChat.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniEnter, Me.mniPrivate, Me.mniSave, Me.toolStripMenuItem1, Me.mniExit})
		Me.mniChat.Name = "mniChat"
		Me.mniChat.Size = New System.Drawing.Size(42, 20)
		Me.mniChat.Text = "Chat"
		' 
		' mniEnter
		' 
		Me.mniEnter.Image = DirectCast(resources.GetObject("mniEnter.Image"), System.Drawing.Image)
		Me.mniEnter.Name = "mniEnter"
		Me.mniEnter.Size = New System.Drawing.Size(152, 22)
		Me.mniEnter.Text = "Login"
		AddHandler Me.mniEnter.Click, New System.EventHandler(AddressOf Me.mniEnter_Click)
		' 
		' mniPrivate
		' 
		Me.mniPrivate.Image = DirectCast(resources.GetObject("mniPrivate.Image"), System.Drawing.Image)
		Me.mniPrivate.Name = "mniPrivate"
		Me.mniPrivate.Size = New System.Drawing.Size(152, 22)
		Me.mniPrivate.Text = "Private"
		AddHandler Me.mniPrivate.Click, New System.EventHandler(AddressOf Me.mniPrivate_Click)
		' 
		' mniSave
		' 
		Me.mniSave.Image = DirectCast(resources.GetObject("mniSave.Image"), System.Drawing.Image)
		Me.mniSave.Name = "mniSave"
		Me.mniSave.Size = New System.Drawing.Size(152, 22)
		Me.mniSave.Text = "Save"
		AddHandler Me.mniSave.Click, New System.EventHandler(AddressOf Me.mniSave_Click)
		' 
		' toolStripMenuItem1
		' 
		Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
		Me.toolStripMenuItem1.Size = New System.Drawing.Size(149, 6)
		' 
		' mniExit
		' 
		Me.mniExit.Image = DirectCast(resources.GetObject("mniExit.Image"), System.Drawing.Image)
		Me.mniExit.Name = "mniExit"
		Me.mniExit.Size = New System.Drawing.Size(152, 22)
		Me.mniExit.Text = "Exit"
		AddHandler Me.mniExit.Click, New System.EventHandler(AddressOf Me.mniExit_Click)
		' 
		' splitContainer
		' 
		Me.splitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.splitContainer.Location = New System.Drawing.Point(3, 24)
		Me.splitContainer.Name = "splitContainer"
		' 
		' splitContainer.Panel1
		' 
		Me.splitContainer.Panel1.Controls.Add(Me.lstViwUsers)
		Me.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.splitContainer.Panel1MinSize = 130
		' 
		' splitContainer.Panel2
		' 
		Me.splitContainer.Panel2.Controls.Add(Me.txtMessages)
		Me.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.splitContainer.Size = New System.Drawing.Size(627, 394)
		Me.splitContainer.SplitterDistance = 130
		Me.splitContainer.TabIndex = 8
		' 
		' lstViwUsers
		' 
		Me.lstViwUsers.Activation = System.Windows.Forms.ItemActivation.OneClick
		Me.lstViwUsers.Alignment = System.Windows.Forms.ListViewAlignment.[Default]
		Me.lstViwUsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIcon, Me.colUserName})
		Me.lstViwUsers.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lstViwUsers.FullRowSelect = True
		Me.lstViwUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
		Me.lstViwUsers.HideSelection = False
		Me.lstViwUsers.LabelWrap = False
		Me.lstViwUsers.Location = New System.Drawing.Point(0, 0)
		Me.lstViwUsers.MultiSelect = False
		Me.lstViwUsers.Name = "lstViwUsers"
		Me.lstViwUsers.RightToLeftLayout = True
		Me.lstViwUsers.Size = New System.Drawing.Size(130, 394)
		Me.lstViwUsers.SmallImageList = Me.imgList
		Me.lstViwUsers.TabIndex = 8
		Me.lstViwUsers.UseCompatibleStateImageBehavior = False
		Me.lstViwUsers.View = System.Windows.Forms.View.Details
		AddHandler Me.lstViwUsers.DoubleClick, New System.EventHandler(AddressOf Me.btnPrivate_Click)
		' 
		' colIcon
		' 
		Me.colIcon.Text = ""
		Me.colIcon.Width = 23
		' 
		' colUserName
		' 
		Me.colUserName.Text = ""
		Me.colUserName.Width = 85
		' 
		' txtMessages
		' 
		Me.txtMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtMessages.ContextMenuStrip = Me.cnxMniCopy
		Me.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill
		Me.txtMessages.Location = New System.Drawing.Point(0, 0)
		Me.txtMessages.Name = "txtMessages"
		Me.txtMessages.Size = New System.Drawing.Size(493, 394)
		Me.txtMessages.TabIndex = 9
		Me.txtMessages.Text = ""
		' 
		' cnxMniCopy
		' 
		Me.cnxMniCopy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniCopyText})
		Me.cnxMniCopy.Name = "cnxMniCopy"
		Me.cnxMniCopy.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.cnxMniCopy.Size = New System.Drawing.Size(116, 26)
		' 
		' mniCopyText
		' 
		Me.mniCopyText.Name = "mniCopyText"
		Me.mniCopyText.Size = New System.Drawing.Size(115, 22)
		Me.mniCopyText.Text = "کپی متن"
		AddHandler Me.mniCopyText.Click, New System.EventHandler(AddressOf Me.mniCopyText_Click)
		' 
		' frmMain
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(635, 459)
		Me.Controls.Add(Me.splitContainer)
		Me.Controls.Add(Me.btnPrivate)
		Me.Controls.Add(Me.txtNewMessage)
		Me.Controls.Add(Me.btnSend)
		Me.Controls.Add(Me.lblNewMessage)
		Me.Controls.Add(Me.mnuMain)
		Me.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(177))
		Me.MinimumSize = New System.Drawing.Size(643, 493)
		Me.Name = "frmMain"
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.RightToLeftLayout = True
		Me.ShowIcon = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Public Room"
		AddHandler Me.FormClosing, New System.Windows.Forms.FormClosingEventHandler(AddressOf Me.frmMain_FormClosing)
		Me.cnxMnuEdit.ResumeLayout(False)
		Me.mnuMain.ResumeLayout(False)
		Me.mnuMain.PerformLayout()
		Me.splitContainer.Panel1.ResumeLayout(False)
		Me.splitContainer.Panel2.ResumeLayout(False)
		Me.splitContainer.ResumeLayout(False)
		Me.cnxMniCopy.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private txtNewMessage As Proshot.UtilityLib.TextBox
	Private lblNewMessage As Proshot.UtilityLib.Label
	Private btnSend As Proshot.UtilityLib.Button
	Private btnPrivate As Proshot.UtilityLib.Button
	Private imgList As System.Windows.Forms.ImageList
	Private mnuMain As Proshot.UtilityLib.MenuStrip
	Private mniChat As System.Windows.Forms.ToolStripMenuItem
	Private mniEnter As System.Windows.Forms.ToolStripMenuItem
	Private mniSave As System.Windows.Forms.ToolStripMenuItem
	Private toolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
	Private mniExit As System.Windows.Forms.ToolStripMenuItem
	Private mniPrivate As System.Windows.Forms.ToolStripMenuItem
	Private splitContainer As System.Windows.Forms.SplitContainer
	Private lstViwUsers As Proshot.UtilityLib.ListView
	Private colIcon As System.Windows.Forms.ColumnHeader
	Private colUserName As System.Windows.Forms.ColumnHeader
	Private txtMessages As System.Windows.Forms.RichTextBox
	Private cnxMnuEdit As Proshot.UtilityLib.ContextMenuStrip
	Private mniCopy As System.Windows.Forms.ToolStripMenuItem
	Private mniPaste As System.Windows.Forms.ToolStripMenuItem
	Private cnxMniCopy As Proshot.UtilityLib.ContextMenuStrip
	Private mniCopyText As System.Windows.Forms.ToolStripMenuItem
End Class

