Namespace ArchiveManager
	Partial Public Class ArchiveManager
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
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(ArchiveManager))
			Me.listView = New System.Windows.Forms.ListView()
			Me.colName = New System.Windows.Forms.ColumnHeader()
			Me.colModified = New System.Windows.Forms.ColumnHeader()
			Me.colSize = New System.Windows.Forms.ColumnHeader()
			Me.colRatio = New System.Windows.Forms.ColumnHeader()
			Me.colPacked = New System.Windows.Forms.ColumnHeader()
			Me.colTypeName = New System.Windows.Forms.ColumnHeader()
			Me.colAttributes = New System.Windows.Forms.ColumnHeader()
			Me.colPath = New System.Windows.Forms.ColumnHeader()
			Me.colCrc = New System.Windows.Forms.ColumnHeader()
			Me.listContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
			Me.addFilesContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.addFolderContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.extractContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.createDirectoryContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.calculateTotalSizeContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.deleteContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.moveContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.viewContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.viewWithInternalViewerContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.renameContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.fileCommentContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
			Me.refreshContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.imglist = New System.Windows.Forms.ImageList(Me.components)
			Me.statusStrip = New System.Windows.Forms.StatusStrip()
			Me.toolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
			Me.progressBarTotal = New System.Windows.Forms.ToolStripProgressBar()
			Me.toolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar()
			Me.toolStripStatusSelectionLabel = New System.Windows.Forms.ToolStripStatusLabel()
			Me.tsbNewArchive = New System.Windows.Forms.ToolStripButton()
			Me.tsbOpenArchive = New System.Windows.Forms.ToolStripButton()
			Me.tsbClose = New System.Windows.Forms.ToolStripButton()
			Me.tsbTestArchive = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
			Me.tsbAddFiles = New System.Windows.Forms.ToolStripButton()
			Me.tsbAddFolder = New System.Windows.Forms.ToolStripButton()
			Me.tsbExtract = New System.Windows.Forms.ToolStripButton()
			Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
			Me.tsbView = New System.Windows.Forms.ToolStripButton()
			Me.tsbAbort = New System.Windows.Forms.ToolStripButton()
			Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
			Me.tsbSettings = New System.Windows.Forms.ToolStripButton()
			Me.newArchiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.openArchiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.closeArchiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.testArchiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.passwordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.archiveCommentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
			Me.selectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.invertSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
			Me.quitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
			Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
			Me.refreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.menuStrip = New System.Windows.Forms.MenuStrip()
			Me.fileMenu = New System.Windows.Forms.ToolStripMenuItem()
			Me.commandsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.createDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.addFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.addFolderToArchiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.extractToFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.calculateDirectorySizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
			Me.viewFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.viewWithInternalViewerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.deleteFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.renameFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.fileCommentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.moveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
			Me.updateArchiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.archiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.createSFXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolbarMain = New System.Windows.Forms.ToolStrip()
			Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
			Me.addressBar = New System.Windows.Forms.Panel()
			Me.txtAddress = New System.Windows.Forms.TextBox()
			Me.btnUpOneLevel = New System.Windows.Forms.Button()
			Me.listContextMenu.SuspendLayout()
			Me.statusStrip.SuspendLayout()
			Me.menuStrip.SuspendLayout()
			Me.toolbarMain.SuspendLayout()
			Me.addressBar.SuspendLayout()
			Me.SuspendLayout()
			' 
			' listView
			' 
			Me.listView.AllowDrop = True
			Me.listView.BackColor = System.Drawing.SystemColors.Window
			Me.listView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.colName, Me.colModified, Me.colSize, Me.colRatio, Me.colPacked, Me.colTypeName, Me.colAttributes, Me.colPath, Me.colCrc})
			Me.listView.ContextMenuStrip = Me.listContextMenu
			Me.listView.Dock = System.Windows.Forms.DockStyle.Fill
			Me.listView.Enabled = False
			Me.listView.FullRowSelect = True
			Me.listView.GridLines = True
			Me.listView.LabelEdit = True
			Me.listView.Location = New System.Drawing.Point(0, 105)
			Me.listView.Name = "listView"
			Me.listView.Size = New System.Drawing.Size(721, 355)
			Me.listView.SmallImageList = Me.imglist
			Me.listView.TabIndex = 2
			Me.listView.UseCompatibleStateImageBehavior = False
			Me.listView.View = System.Windows.Forms.View.Details
'			Me.listView.AfterLabelEdit += New System.Windows.Forms.LabelEditEventHandler(Me.listView_AfterLabelEdit)
'			Me.listView.SelectedIndexChanged += New System.EventHandler(Me.lvwArchive_SelectedIndexChanged)
'			Me.listView.DoubleClick += New System.EventHandler(Me.lvwArchive_DoubleClick)
'			Me.listView.ColumnClick += New System.Windows.Forms.ColumnClickEventHandler(Me.listView_ColumnClick)
'			Me.listView.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.listView_KeyDown)
			' 
			' colName
			' 
			Me.colName.Text = "Name"
			Me.colName.Width = 120
			' 
			' colModified
			' 
			Me.colModified.Text = "Modified"
			Me.colModified.Width = 120
			' 
			' colSize
			' 
			Me.colSize.Text = "Size"
			Me.colSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			' 
			' colRatio
			' 
			Me.colRatio.Text = "Ratio"
			Me.colRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			Me.colRatio.Width = 40
			' 
			' colPacked
			' 
			Me.colPacked.Text = "Packed"
			Me.colPacked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			' 
			' colTypeName
			' 
			Me.colTypeName.Text = "Type"
			Me.colTypeName.Width = 120
			' 
			' colAttributes
			' 
			Me.colAttributes.Text = "Attributes"
			' 
			' colPath
			' 
			Me.colPath.Text = "Path"
			Me.colPath.Width = 120
			' 
			' colCrc
			' 
			Me.colCrc.Text = "CRC32"
			' 
			' listContextMenu
			' 
			Me.listContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.addFilesContextMenuItem, Me.addFolderContextMenuItem, Me.extractContextMenuItem, Me.createDirectoryContextMenuItem, Me.calculateTotalSizeContextMenuItem, Me.deleteContextMenuItem, Me.moveContextMenuItem, Me.viewContextMenuItem, Me.viewWithInternalViewerContextMenuItem, Me.renameContextMenuItem, Me.fileCommentContextMenuItem, Me.toolStripSeparator2, Me.refreshContextMenuItem})
			Me.listContextMenu.Name = "listContextMenu"
			Me.listContextMenu.Size = New System.Drawing.Size(196, 296)
			' 
			' addFilesContextMenuItem
			' 
			Me.addFilesContextMenuItem.Image = (CType(resources.GetObject("addFilesContextMenuItem.Image"), System.Drawing.Image))
			Me.addFilesContextMenuItem.Name = "addFilesContextMenuItem"
			Me.addFilesContextMenuItem.Size = New System.Drawing.Size(195, 22)
			Me.addFilesContextMenuItem.Text = "Add Files..."
'			Me.addFilesContextMenuItem.Click += New System.EventHandler(Me.addFilesContextMenuItem_Click)
			' 
			' addFolderContextMenuItem
			' 
			Me.addFolderContextMenuItem.Image = (CType(resources.GetObject("addFolderContextMenuItem.Image"), System.Drawing.Image))
			Me.addFolderContextMenuItem.Name = "addFolderContextMenuItem"
			Me.addFolderContextMenuItem.Size = New System.Drawing.Size(195, 22)
			Me.addFolderContextMenuItem.Text = "Add Folder..."
'			Me.addFolderContextMenuItem.Click += New System.EventHandler(Me.addFolderContextMenuItem_Click)
			' 
			' extractContextMenuItem
			' 
			Me.extractContextMenuItem.Image = (CType(resources.GetObject("extractContextMenuItem.Image"), System.Drawing.Image))
			Me.extractContextMenuItem.Name = "extractContextMenuItem"
			Me.extractContextMenuItem.Size = New System.Drawing.Size(195, 22)
			Me.extractContextMenuItem.Text = "Extract..."
'			Me.extractContextMenuItem.Click += New System.EventHandler(Me.extractContextMenuItem_Click)
			' 
			' createDirectoryContextMenuItem
			' 
			Me.createDirectoryContextMenuItem.Name = "createDirectoryContextMenuItem"
			Me.createDirectoryContextMenuItem.Size = New System.Drawing.Size(195, 22)
			Me.createDirectoryContextMenuItem.Text = "Create Directory..."
'			Me.createDirectoryContextMenuItem.Click += New System.EventHandler(Me.createDirectoryToolStripMenuItem_Click)
			' 
			' calculateTotalSizeContextMenuItem
			' 
			Me.calculateTotalSizeContextMenuItem.Name = "calculateTotalSizeContextMenuItem"
			Me.calculateTotalSizeContextMenuItem.Size = New System.Drawing.Size(195, 22)
			Me.calculateTotalSizeContextMenuItem.Text = "Calculate Total Size"
'			Me.calculateTotalSizeContextMenuItem.Click += New System.EventHandler(Me.calculateTotalSizeToolStripMenuItem_Click)
			' 
			' deleteContextMenuItem
			' 
			Me.deleteContextMenuItem.Image = (CType(resources.GetObject("deleteContextMenuItem.Image"), System.Drawing.Image))
			Me.deleteContextMenuItem.Name = "deleteContextMenuItem"
			Me.deleteContextMenuItem.Size = New System.Drawing.Size(195, 22)
			Me.deleteContextMenuItem.Text = "Delete"
'			Me.deleteContextMenuItem.Click += New System.EventHandler(Me.deleteContextMenuItem_Click)
			' 
			' moveContextMenuItem
			' 
			Me.moveContextMenuItem.Name = "moveContextMenuItem"
			Me.moveContextMenuItem.Size = New System.Drawing.Size(195, 22)
			Me.moveContextMenuItem.Text = "Move..."
'			Me.moveContextMenuItem.Click += New System.EventHandler(Me.moveToolStripMenuItem_Click)
			' 
			' viewContextMenuItem
			' 
			Me.viewContextMenuItem.Image = (CType(resources.GetObject("viewContextMenuItem.Image"), System.Drawing.Image))
			Me.viewContextMenuItem.Name = "viewContextMenuItem"
			Me.viewContextMenuItem.Size = New System.Drawing.Size(195, 22)
			Me.viewContextMenuItem.Text = "View"
'			Me.viewContextMenuItem.Click += New System.EventHandler(Me.viewContextMenuItem_Click)
			' 
			' viewWithInternalViewerContextMenuItem
			' 
			Me.viewWithInternalViewerContextMenuItem.Name = "viewWithInternalViewerContextMenuItem"
			Me.viewWithInternalViewerContextMenuItem.Size = New System.Drawing.Size(195, 22)
			Me.viewWithInternalViewerContextMenuItem.Text = "View with Internal Viewer"
'			Me.viewWithInternalViewerContextMenuItem.Click += New System.EventHandler(Me.viewWithInternalViewerContextMenuItem_Click)
			' 
			' renameContextMenuItem
			' 
			Me.renameContextMenuItem.Name = "renameContextMenuItem"
			Me.renameContextMenuItem.Size = New System.Drawing.Size(195, 22)
			Me.renameContextMenuItem.Text = "Rename"
'			Me.renameContextMenuItem.Click += New System.EventHandler(Me.renameContextMenuItem_Click)
			' 
			' fileCommentContextMenuItem
			' 
			Me.fileCommentContextMenuItem.Name = "fileCommentContextMenuItem"
			Me.fileCommentContextMenuItem.Size = New System.Drawing.Size(195, 22)
			Me.fileCommentContextMenuItem.Text = "File Comment..."
'			Me.fileCommentContextMenuItem.Click += New System.EventHandler(Me.fileCommentToolStripMenuItem_Click)
			' 
			' toolStripSeparator2
			' 
			Me.toolStripSeparator2.Name = "toolStripSeparator2"
			Me.toolStripSeparator2.Size = New System.Drawing.Size(192, 6)
			' 
			' refreshContextMenuItem
			' 
			Me.refreshContextMenuItem.Image = (CType(resources.GetObject("refreshContextMenuItem.Image"), System.Drawing.Image))
			Me.refreshContextMenuItem.Name = "refreshContextMenuItem"
			Me.refreshContextMenuItem.Size = New System.Drawing.Size(195, 22)
			Me.refreshContextMenuItem.Text = "Refresh"
'			Me.refreshContextMenuItem.Click += New System.EventHandler(Me.refreshContextMenuItem_Click)
			' 
			' imglist
			' 
			Me.imglist.ImageStream = (CType(resources.GetObject("imglist.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imglist.TransparentColor = System.Drawing.Color.Transparent
			Me.imglist.Images.SetKeyName(0, "UpFolder.gif")
			' 
			' statusStrip
			' 
			Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.toolStripStatusLabel, Me.progressBarTotal, Me.toolStripProgressBar, Me.toolStripStatusSelectionLabel})
			Me.statusStrip.Location = New System.Drawing.Point(0, 460)
			Me.statusStrip.Name = "statusStrip"
			Me.statusStrip.Size = New System.Drawing.Size(721, 22)
			Me.statusStrip.TabIndex = 138
			Me.statusStrip.Text = "statusStrip1"
			' 
			' toolStripStatusLabel
			' 
			Me.toolStripStatusLabel.Name = "toolStripStatusLabel"
			Me.toolStripStatusLabel.Size = New System.Drawing.Size(38, 17)
			Me.toolStripStatusLabel.Text = "Ready"
			' 
			' progressBarTotal
			' 
			Me.progressBarTotal.Name = "progressBarTotal"
			Me.progressBarTotal.Size = New System.Drawing.Size(100, 16)
			Me.progressBarTotal.Visible = False
			' 
			' toolStripProgressBar
			' 
			Me.toolStripProgressBar.Name = "toolStripProgressBar"
			Me.toolStripProgressBar.Size = New System.Drawing.Size(100, 16)
			Me.toolStripProgressBar.Visible = False
			' 
			' toolStripStatusSelectionLabel
			' 
			Me.toolStripStatusSelectionLabel.Name = "toolStripStatusSelectionLabel"
			Me.toolStripStatusSelectionLabel.Size = New System.Drawing.Size(146, 17)
			Me.toolStripStatusSelectionLabel.Text = "toolStripStatusSelectionLabel"
			Me.toolStripStatusSelectionLabel.Visible = False
			' 
			' tsbNewArchive
			' 
			Me.tsbNewArchive.AutoSize = False
			Me.tsbNewArchive.Image = (CType(resources.GetObject("tsbNewArchive.Image"), System.Drawing.Image))
			Me.tsbNewArchive.Name = "tsbNewArchive"
			Me.tsbNewArchive.Size = New System.Drawing.Size(49, 49)
			Me.tsbNewArchive.Text = "New"
			Me.tsbNewArchive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbNewArchive.Click += New System.EventHandler(Me.tsbNewArchive_Click)
			' 
			' tsbOpenArchive
			' 
			Me.tsbOpenArchive.AutoSize = False
			Me.tsbOpenArchive.Image = (CType(resources.GetObject("tsbOpenArchive.Image"), System.Drawing.Image))
			Me.tsbOpenArchive.Name = "tsbOpenArchive"
			Me.tsbOpenArchive.Size = New System.Drawing.Size(49, 49)
			Me.tsbOpenArchive.Text = "Open"
			Me.tsbOpenArchive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbOpenArchive.Click += New System.EventHandler(Me.tsbOpenArchive_Click)
			' 
			' tsbClose
			' 
			Me.tsbClose.AutoSize = False
			Me.tsbClose.Enabled = False
			Me.tsbClose.Image = (CType(resources.GetObject("tsbClose.Image"), System.Drawing.Image))
			Me.tsbClose.Name = "tsbClose"
			Me.tsbClose.Size = New System.Drawing.Size(49, 49)
			Me.tsbClose.Text = "Close"
			Me.tsbClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbClose.Click += New System.EventHandler(Me.tsbClose_Click)
			' 
			' tsbTestArchive
			' 
			Me.tsbTestArchive.AutoSize = False
			Me.tsbTestArchive.Enabled = False
			Me.tsbTestArchive.Image = (CType(resources.GetObject("tsbTestArchive.Image"), System.Drawing.Image))
			Me.tsbTestArchive.Name = "tsbTestArchive"
			Me.tsbTestArchive.Size = New System.Drawing.Size(49, 49)
			Me.tsbTestArchive.Text = "Test"
			Me.tsbTestArchive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbTestArchive.Click += New System.EventHandler(Me.tsbTestArchive_Click)
			' 
			' toolStripSeparator1
			' 
			Me.toolStripSeparator1.Name = "toolStripSeparator1"
			Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 39)
			' 
			' tsbAddFiles
			' 
			Me.tsbAddFiles.Enabled = False
			Me.tsbAddFiles.Image = (CType(resources.GetObject("tsbAddFiles.Image"), System.Drawing.Image))
			Me.tsbAddFiles.Name = "tsbAddFiles"
			Me.tsbAddFiles.Size = New System.Drawing.Size(54, 49)
			Me.tsbAddFiles.Text = "Add Files"
			Me.tsbAddFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbAddFiles.Click += New System.EventHandler(Me.tsbAddFiles_Click)
			' 
			' tsbAddFolder
			' 
			Me.tsbAddFolder.Enabled = False
			Me.tsbAddFolder.Image = (CType(resources.GetObject("tsbAddFolder.Image"), System.Drawing.Image))
			Me.tsbAddFolder.Name = "tsbAddFolder"
			Me.tsbAddFolder.Size = New System.Drawing.Size(63, 49)
			Me.tsbAddFolder.Text = "Add Folder"
			Me.tsbAddFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbAddFolder.Click += New System.EventHandler(Me.tsbAddFolder_Click)
			' 
			' tsbExtract
			' 
			Me.tsbExtract.AutoSize = False
			Me.tsbExtract.Enabled = False
			Me.tsbExtract.Image = (CType(resources.GetObject("tsbExtract.Image"), System.Drawing.Image))
			Me.tsbExtract.Name = "tsbExtract"
			Me.tsbExtract.Size = New System.Drawing.Size(49, 49)
			Me.tsbExtract.Text = "Extract"
			Me.tsbExtract.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbExtract.Click += New System.EventHandler(Me.tsbExtract_Click)
			' 
			' tsbDelete
			' 
			Me.tsbDelete.AutoSize = False
			Me.tsbDelete.Enabled = False
			Me.tsbDelete.Image = (CType(resources.GetObject("tsbDelete.Image"), System.Drawing.Image))
			Me.tsbDelete.Name = "tsbDelete"
			Me.tsbDelete.Size = New System.Drawing.Size(49, 49)
			Me.tsbDelete.Text = "Delete"
			Me.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbDelete.Click += New System.EventHandler(Me.tsbDelete_Click)
			' 
			' tsbView
			' 
			Me.tsbView.AutoSize = False
			Me.tsbView.Enabled = False
			Me.tsbView.Image = (CType(resources.GetObject("tsbView.Image"), System.Drawing.Image))
			Me.tsbView.Name = "tsbView"
			Me.tsbView.Size = New System.Drawing.Size(49, 49)
			Me.tsbView.Text = "View"
			Me.tsbView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbView.Click += New System.EventHandler(Me.tsbView_Click)
			' 
			' tsbAbort
			' 
			Me.tsbAbort.AutoSize = False
			Me.tsbAbort.Enabled = False
			Me.tsbAbort.Image = (CType(resources.GetObject("tsbAbort.Image"), System.Drawing.Image))
			Me.tsbAbort.Name = "tsbAbort"
			Me.tsbAbort.Size = New System.Drawing.Size(49, 49)
			Me.tsbAbort.Text = "Abort"
			Me.tsbAbort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbAbort.Click += New System.EventHandler(Me.tsbAbort_Click)
			' 
			' tsbRefresh
			' 
			Me.tsbRefresh.AutoSize = False
			Me.tsbRefresh.Enabled = False
			Me.tsbRefresh.Image = (CType(resources.GetObject("tsbRefresh.Image"), System.Drawing.Image))
			Me.tsbRefresh.Name = "tsbRefresh"
			Me.tsbRefresh.Size = New System.Drawing.Size(49, 49)
			Me.tsbRefresh.Text = "Refresh"
			Me.tsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbRefresh.Click += New System.EventHandler(Me.tsbRefresh_Click)
			' 
			' toolStripSeparator7
			' 
			Me.toolStripSeparator7.Name = "toolStripSeparator7"
			Me.toolStripSeparator7.Size = New System.Drawing.Size(6, 39)
			' 
			' tsbSettings
			' 
			Me.tsbSettings.AutoSize = False
			Me.tsbSettings.Image = (CType(resources.GetObject("tsbSettings.Image"), System.Drawing.Image))
			Me.tsbSettings.Name = "tsbSettings"
			Me.tsbSettings.Size = New System.Drawing.Size(49, 49)
			Me.tsbSettings.Text = "Settings"
			Me.tsbSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
'			Me.tsbSettings.Click += New System.EventHandler(Me.tsbSettings_Click)
			' 
			' newArchiveToolStripMenuItem
			' 
			Me.newArchiveToolStripMenuItem.Image = (CType(resources.GetObject("newArchiveToolStripMenuItem.Image"), System.Drawing.Image))
			Me.newArchiveToolStripMenuItem.Name = "newArchiveToolStripMenuItem"
			Me.newArchiveToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys))
			Me.newArchiveToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
			Me.newArchiveToolStripMenuItem.Text = "New Archive..."
'			Me.newArchiveToolStripMenuItem.Click += New System.EventHandler(Me.newArchiveToolStripMenuItem_Click)
			' 
			' openArchiveToolStripMenuItem
			' 
			Me.openArchiveToolStripMenuItem.Image = (CType(resources.GetObject("openArchiveToolStripMenuItem.Image"), System.Drawing.Image))
			Me.openArchiveToolStripMenuItem.Name = "openArchiveToolStripMenuItem"
			Me.openArchiveToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys))
			Me.openArchiveToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
			Me.openArchiveToolStripMenuItem.Text = "Open Archive..."
'			Me.openArchiveToolStripMenuItem.Click += New System.EventHandler(Me.openArchiveToolStripMenuItem_Click)
			' 
			' closeArchiveToolStripMenuItem
			' 
			Me.closeArchiveToolStripMenuItem.Enabled = False
			Me.closeArchiveToolStripMenuItem.Image = (CType(resources.GetObject("closeArchiveToolStripMenuItem.Image"), System.Drawing.Image))
			Me.closeArchiveToolStripMenuItem.Name = "closeArchiveToolStripMenuItem"
			Me.closeArchiveToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys))
			Me.closeArchiveToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
			Me.closeArchiveToolStripMenuItem.Text = "Close Archive"
'			Me.closeArchiveToolStripMenuItem.Click += New System.EventHandler(Me.closeArchiveToolStripMenuItem_Click)
			' 
			' testArchiveToolStripMenuItem
			' 
			Me.testArchiveToolStripMenuItem.Enabled = False
			Me.testArchiveToolStripMenuItem.Image = (CType(resources.GetObject("testArchiveToolStripMenuItem.Image"), System.Drawing.Image))
			Me.testArchiveToolStripMenuItem.Name = "testArchiveToolStripMenuItem"
			Me.testArchiveToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys))
			Me.testArchiveToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
			Me.testArchiveToolStripMenuItem.Text = "Test Archive"
'			Me.testArchiveToolStripMenuItem.Click += New System.EventHandler(Me.testArchiveToolStripMenuItem_Click)
			' 
			' passwordToolStripMenuItem
			' 
			Me.passwordToolStripMenuItem.Enabled = False
			Me.passwordToolStripMenuItem.Name = "passwordToolStripMenuItem"
			Me.passwordToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
			Me.passwordToolStripMenuItem.Text = "Password..."
'			Me.passwordToolStripMenuItem.Click += New System.EventHandler(Me.passwordToolStripMenuItem_Click)
			' 
			' archiveCommentToolStripMenuItem
			' 
			Me.archiveCommentToolStripMenuItem.Enabled = False
			Me.archiveCommentToolStripMenuItem.Name = "archiveCommentToolStripMenuItem"
			Me.archiveCommentToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
			Me.archiveCommentToolStripMenuItem.Text = "Comment..."
'			Me.archiveCommentToolStripMenuItem.Click += New System.EventHandler(Me.archiveCommentToolStripMenuItem_Click)
			' 
			' toolStripSeparator3
			' 
			Me.toolStripSeparator3.Name = "toolStripSeparator3"
			Me.toolStripSeparator3.Size = New System.Drawing.Size(188, 6)
			' 
			' selectAllToolStripMenuItem
			' 
			Me.selectAllToolStripMenuItem.Enabled = False
			Me.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem"
			Me.selectAllToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
			Me.selectAllToolStripMenuItem.Text = "Select All"
'			Me.selectAllToolStripMenuItem.Click += New System.EventHandler(Me.selectAllToolStripMenuItem_Click)
			' 
			' invertSelectionToolStripMenuItem
			' 
			Me.invertSelectionToolStripMenuItem.Enabled = False
			Me.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem"
			Me.invertSelectionToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
			Me.invertSelectionToolStripMenuItem.Text = "Invert Selection"
'			Me.invertSelectionToolStripMenuItem.Click += New System.EventHandler(Me.invertSelectionToolStripMenuItem_Click)
			' 
			' toolStripSeparator4
			' 
			Me.toolStripSeparator4.Name = "toolStripSeparator4"
			Me.toolStripSeparator4.Size = New System.Drawing.Size(224, 6)
			' 
			' quitToolStripMenuItem
			' 
			Me.quitToolStripMenuItem.Name = "quitToolStripMenuItem"
			Me.quitToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
			Me.quitToolStripMenuItem.Text = "Quit"
'			Me.quitToolStripMenuItem.Click += New System.EventHandler(Me.quitToolStripMenuItem_Click)
			' 
			' optionsToolStripMenuItem
			' 
			Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
			Me.optionsToolStripMenuItem.ShortcutKeys = (CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys))
			Me.optionsToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
			Me.optionsToolStripMenuItem.Text = "&Options"
'			Me.optionsToolStripMenuItem.Click += New System.EventHandler(Me.optionsToolStripMenuItem_Click)
			' 
			' toolStripSeparator5
			' 
			Me.toolStripSeparator5.Name = "toolStripSeparator5"
			Me.toolStripSeparator5.Size = New System.Drawing.Size(188, 6)
			' 
			' toolStripSeparator6
			' 
			Me.toolStripSeparator6.Name = "toolStripSeparator6"
			Me.toolStripSeparator6.Size = New System.Drawing.Size(188, 6)
			' 
			' refreshToolStripMenuItem
			' 
			Me.refreshToolStripMenuItem.Enabled = False
			Me.refreshToolStripMenuItem.Image = (CType(resources.GetObject("refreshToolStripMenuItem.Image"), System.Drawing.Image))
			Me.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem"
			Me.refreshToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
			Me.refreshToolStripMenuItem.Text = "Refresh"
'			Me.refreshToolStripMenuItem.Click += New System.EventHandler(Me.refreshToolStripMenuItem_Click)
			' 
			' menuStrip
			' 
			Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.fileMenu, Me.optionsToolStripMenuItem, Me.commandsToolStripMenuItem, Me.archiveToolStripMenuItem})
			Me.menuStrip.Location = New System.Drawing.Point(0, 0)
			Me.menuStrip.Name = "menuStrip"
			Me.menuStrip.Size = New System.Drawing.Size(721, 24)
			Me.menuStrip.TabIndex = 140
			' 
			' fileMenu
			' 
			Me.fileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.newArchiveToolStripMenuItem, Me.openArchiveToolStripMenuItem, Me.closeArchiveToolStripMenuItem, Me.testArchiveToolStripMenuItem, Me.passwordToolStripMenuItem, Me.archiveCommentToolStripMenuItem, Me.toolStripSeparator3, Me.selectAllToolStripMenuItem, Me.invertSelectionToolStripMenuItem, Me.toolStripSeparator5, Me.refreshToolStripMenuItem, Me.toolStripSeparator6, Me.quitToolStripMenuItem})
			Me.fileMenu.Name = "fileMenu"
			Me.fileMenu.Size = New System.Drawing.Size(35, 20)
			Me.fileMenu.Text = "&File"
			' 
			' commandsToolStripMenuItem
			' 
			Me.commandsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.createDirectoryToolStripMenuItem, Me.addFilesToolStripMenuItem, Me.addFolderToArchiveToolStripMenuItem, Me.extractToFolderToolStripMenuItem, Me.calculateDirectorySizeToolStripMenuItem, Me.toolStripSeparator8, Me.viewFileToolStripMenuItem, Me.viewWithInternalViewerToolStripMenuItem, Me.deleteFilesToolStripMenuItem, Me.renameFileToolStripMenuItem, Me.fileCommentToolStripMenuItem, Me.moveToolStripMenuItem, Me.toolStripSeparator9, Me.updateArchiveToolStripMenuItem})
			Me.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem"
			Me.commandsToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
			Me.commandsToolStripMenuItem.Text = "&Commands"
			' 
			' createDirectoryToolStripMenuItem
			' 
			Me.createDirectoryToolStripMenuItem.Enabled = False
			Me.createDirectoryToolStripMenuItem.Name = "createDirectoryToolStripMenuItem"
			Me.createDirectoryToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
			Me.createDirectoryToolStripMenuItem.Text = "&Create Directory..."
'			Me.createDirectoryToolStripMenuItem.Click += New System.EventHandler(Me.createDirectoryToolStripMenuItem_Click)
			' 
			' addFilesToolStripMenuItem
			' 
			Me.addFilesToolStripMenuItem.Enabled = False
			Me.addFilesToolStripMenuItem.Image = (CType(resources.GetObject("addFilesToolStripMenuItem.Image"), System.Drawing.Image))
			Me.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem"
			Me.addFilesToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys))
			Me.addFilesToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
			Me.addFilesToolStripMenuItem.Text = "Add Files to Archive..."
'			Me.addFilesToolStripMenuItem.Click += New System.EventHandler(Me.addFilesToolStripMenuItem_Click)
			' 
			' addFolderToArchiveToolStripMenuItem
			' 
			Me.addFolderToArchiveToolStripMenuItem.Enabled = False
			Me.addFolderToArchiveToolStripMenuItem.Image = (CType(resources.GetObject("addFolderToArchiveToolStripMenuItem.Image"), System.Drawing.Image))
			Me.addFolderToArchiveToolStripMenuItem.Name = "addFolderToArchiveToolStripMenuItem"
			Me.addFolderToArchiveToolStripMenuItem.ShortcutKeys = (CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys))
			Me.addFolderToArchiveToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
			Me.addFolderToArchiveToolStripMenuItem.Text = "Add Folder to Archive..."
'			Me.addFolderToArchiveToolStripMenuItem.Click += New System.EventHandler(Me.addFolderToArchiveToolStripMenuItem_Click)
			' 
			' extractToFolderToolStripMenuItem
			' 
			Me.extractToFolderToolStripMenuItem.Enabled = False
			Me.extractToFolderToolStripMenuItem.Image = (CType(resources.GetObject("extractToFolderToolStripMenuItem.Image"), System.Drawing.Image))
			Me.extractToFolderToolStripMenuItem.Name = "extractToFolderToolStripMenuItem"
			Me.extractToFolderToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys))
			Me.extractToFolderToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
			Me.extractToFolderToolStripMenuItem.Text = "Extract to Folder..."
'			Me.extractToFolderToolStripMenuItem.Click += New System.EventHandler(Me.extractToFolderToolStripMenuItem_Click)
			' 
			' calculateDirectorySizeToolStripMenuItem
			' 
			Me.calculateDirectorySizeToolStripMenuItem.Enabled = False
			Me.calculateDirectorySizeToolStripMenuItem.Name = "calculateDirectorySizeToolStripMenuItem"
			Me.calculateDirectorySizeToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
			Me.calculateDirectorySizeToolStripMenuItem.Text = "Calculate Total Size"
'			Me.calculateDirectorySizeToolStripMenuItem.Click += New System.EventHandler(Me.calculateDirectorySizeToolStripMenuItem_Click)
			' 
			' toolStripSeparator8
			' 
			Me.toolStripSeparator8.Name = "toolStripSeparator8"
			Me.toolStripSeparator8.Size = New System.Drawing.Size(256, 6)
			' 
			' viewFileToolStripMenuItem
			' 
			Me.viewFileToolStripMenuItem.Enabled = False
			Me.viewFileToolStripMenuItem.Image = (CType(resources.GetObject("viewFileToolStripMenuItem.Image"), System.Drawing.Image))
			Me.viewFileToolStripMenuItem.Name = "viewFileToolStripMenuItem"
			Me.viewFileToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
			Me.viewFileToolStripMenuItem.Text = "View File..."
'			Me.viewFileToolStripMenuItem.Click += New System.EventHandler(Me.viewFileToolStripMenuItem_Click)
			' 
			' viewWithInternalViewerToolStripMenuItem
			' 
			Me.viewWithInternalViewerToolStripMenuItem.Enabled = False
			Me.viewWithInternalViewerToolStripMenuItem.Name = "viewWithInternalViewerToolStripMenuItem"
			Me.viewWithInternalViewerToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
			Me.viewWithInternalViewerToolStripMenuItem.Text = "View with Internal Viewer..."
'			Me.viewWithInternalViewerToolStripMenuItem.Click += New System.EventHandler(Me.viewWithInternalViewerToolStripMenuItem_Click)
			' 
			' deleteFilesToolStripMenuItem
			' 
			Me.deleteFilesToolStripMenuItem.Enabled = False
			Me.deleteFilesToolStripMenuItem.Image = (CType(resources.GetObject("deleteFilesToolStripMenuItem.Image"), System.Drawing.Image))
			Me.deleteFilesToolStripMenuItem.Name = "deleteFilesToolStripMenuItem"
			Me.deleteFilesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
			Me.deleteFilesToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
			Me.deleteFilesToolStripMenuItem.Text = "Delete Files"
'			Me.deleteFilesToolStripMenuItem.Click += New System.EventHandler(Me.deleteFilesToolStripMenuItem_Click)
			' 
			' renameFileToolStripMenuItem
			' 
			Me.renameFileToolStripMenuItem.Enabled = False
			Me.renameFileToolStripMenuItem.Name = "renameFileToolStripMenuItem"
			Me.renameFileToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
			Me.renameFileToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
			Me.renameFileToolStripMenuItem.Text = "Rename File"
'			Me.renameFileToolStripMenuItem.Click += New System.EventHandler(Me.renameFileToolStripMenuItem_Click)
			' 
			' fileCommentToolStripMenuItem
			' 
			Me.fileCommentToolStripMenuItem.Enabled = False
			Me.fileCommentToolStripMenuItem.Name = "fileCommentToolStripMenuItem"
			Me.fileCommentToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
			Me.fileCommentToolStripMenuItem.Text = "File Comment..."
'			Me.fileCommentToolStripMenuItem.Click += New System.EventHandler(Me.fileCommentToolStripMenuItem_Click)
			' 
			' moveToolStripMenuItem
			' 
			Me.moveToolStripMenuItem.Enabled = False
			Me.moveToolStripMenuItem.Name = "moveToolStripMenuItem"
			Me.moveToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
			Me.moveToolStripMenuItem.Text = "Move..."
'			Me.moveToolStripMenuItem.Click += New System.EventHandler(Me.moveToolStripMenuItem_Click)
			' 
			' toolStripSeparator9
			' 
			Me.toolStripSeparator9.Name = "toolStripSeparator9"
			Me.toolStripSeparator9.Size = New System.Drawing.Size(256, 6)
			' 
			' updateArchiveToolStripMenuItem
			' 
			Me.updateArchiveToolStripMenuItem.Enabled = False
			Me.updateArchiveToolStripMenuItem.Name = "updateArchiveToolStripMenuItem"
			Me.updateArchiveToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
			Me.updateArchiveToolStripMenuItem.Text = "Update Archive..."
'			Me.updateArchiveToolStripMenuItem.Click += New System.EventHandler(Me.updateArchiveToolStripMenuItem_Click)
			' 
			' archiveToolStripMenuItem
			' 
			Me.archiveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.createSFXToolStripMenuItem})
			Me.archiveToolStripMenuItem.Name = "archiveToolStripMenuItem"
			Me.archiveToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
			Me.archiveToolStripMenuItem.Text = "&Archive"
			' 
			' createSFXToolStripMenuItem
			' 
			Me.createSFXToolStripMenuItem.Enabled = False
			Me.createSFXToolStripMenuItem.Name = "createSFXToolStripMenuItem"
			Me.createSFXToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
			Me.createSFXToolStripMenuItem.Text = "&Create SFX..."
'			Me.createSFXToolStripMenuItem.Click += New System.EventHandler(Me.createSFXToolStripMenuItem_Click)
			' 
			' toolbarMain
			' 
			Me.toolbarMain.ImageScalingSize = New System.Drawing.Size(32, 32)
			Me.toolbarMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.tsbNewArchive, Me.tsbOpenArchive, Me.tsbClose, Me.tsbTestArchive, Me.tsbSettings, Me.toolStripSeparator, Me.tsbDelete, Me.tsbRefresh, Me.tsbAbort, Me.tsbView, Me.tsbExtract, Me.tsbAddFolder, Me.tsbAddFiles})
			Me.toolbarMain.Location = New System.Drawing.Point(0, 24)
			Me.toolbarMain.Name = "toolbarMain"
			Me.toolbarMain.Size = New System.Drawing.Size(721, 52)
			Me.toolbarMain.TabIndex = 139
			' 
			' toolStripSeparator
			' 
			Me.toolStripSeparator.Name = "toolStripSeparator"
			Me.toolStripSeparator.Size = New System.Drawing.Size(6, 52)
			' 
			' addressBar
			' 
			Me.addressBar.Controls.Add(Me.txtAddress)
			Me.addressBar.Controls.Add(Me.btnUpOneLevel)
			Me.addressBar.Dock = System.Windows.Forms.DockStyle.Top
			Me.addressBar.Enabled = False
			Me.addressBar.Location = New System.Drawing.Point(0, 76)
			Me.addressBar.Name = "addressBar"
			Me.addressBar.Size = New System.Drawing.Size(721, 29)
			Me.addressBar.TabIndex = 141
			' 
			' txtAddress
			' 
			Me.txtAddress.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txtAddress.BackColor = System.Drawing.Color.White
			Me.txtAddress.Location = New System.Drawing.Point(41, 4)
			Me.txtAddress.Name = "txtAddress"
			Me.txtAddress.ReadOnly = True
			Me.txtAddress.Size = New System.Drawing.Size(675, 20)
			Me.txtAddress.TabIndex = 1
			' 
			' btnUpOneLevel
			' 
			Me.btnUpOneLevel.Image = (CType(resources.GetObject("btnUpOneLevel.Image"), System.Drawing.Image))
			Me.btnUpOneLevel.Location = New System.Drawing.Point(5, 3)
			Me.btnUpOneLevel.Name = "btnUpOneLevel"
			Me.btnUpOneLevel.Size = New System.Drawing.Size(32, 23)
			Me.btnUpOneLevel.TabIndex = 0
			Me.btnUpOneLevel.TabStop = False
			Me.btnUpOneLevel.UseVisualStyleBackColor = True
'			Me.btnUpOneLevel.Click += New System.EventHandler(Me.btnUpOneLevel_Click)
			' 
			' ArchiveManager
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(721, 482)
			Me.Controls.Add(Me.listView)
			Me.Controls.Add(Me.addressBar)
			Me.Controls.Add(Me.statusStrip)
			Me.Controls.Add(Me.toolbarMain)
			Me.Controls.Add(Me.menuStrip)
			Me.Name = "ArchiveManager"
			Me.Text = "UltimateZip ArchiveManager"
			Me.listContextMenu.ResumeLayout(False)
			Me.statusStrip.ResumeLayout(False)
			Me.statusStrip.PerformLayout()
			Me.menuStrip.ResumeLayout(False)
			Me.menuStrip.PerformLayout()
			Me.toolbarMain.ResumeLayout(False)
			Me.toolbarMain.PerformLayout()
			Me.addressBar.ResumeLayout(False)
			Me.addressBar.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents listView As System.Windows.Forms.ListView
		Private colName As System.Windows.Forms.ColumnHeader
		Private colModified As System.Windows.Forms.ColumnHeader
		Private colSize As System.Windows.Forms.ColumnHeader
		Private colRatio As System.Windows.Forms.ColumnHeader
		Private colPacked As System.Windows.Forms.ColumnHeader
		Private colAttributes As System.Windows.Forms.ColumnHeader
		Private colPath As System.Windows.Forms.ColumnHeader
		Private WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbSettings As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbView As System.Windows.Forms.ToolStripButton
		Private menuStrip As System.Windows.Forms.MenuStrip
		Private WithEvents newArchiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private statusStrip As System.Windows.Forms.StatusStrip
		Private toolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
		Private WithEvents openArchiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents closeArchiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents passwordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents selectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents invertSelectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents quitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents archiveCommentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
		Private toolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
		Private toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents refreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents tsbNewArchive As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbOpenArchive As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbClose As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbTestArchive As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbAddFiles As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbAddFolder As System.Windows.Forms.ToolStripButton
		Private WithEvents tsbExtract As System.Windows.Forms.ToolStripButton
		Private WithEvents testArchiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private listContextMenu As System.Windows.Forms.ContextMenuStrip
		Private WithEvents addFilesContextMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents addFolderContextMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents extractContextMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents deleteContextMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents viewContextMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents renameContextMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents refreshContextMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripStatusSelectionLabel As System.Windows.Forms.ToolStripStatusLabel
		Public imglist As System.Windows.Forms.ImageList
		Private WithEvents tsbAbort As System.Windows.Forms.ToolStripButton
		Private toolbarMain As System.Windows.Forms.ToolStrip
		Private fileMenu As ToolStripMenuItem
		Private toolStripSeparator As ToolStripSeparator
		Private commandsToolStripMenuItem As ToolStripMenuItem
		Private WithEvents addFilesToolStripMenuItem As ToolStripMenuItem
		Private WithEvents addFolderToArchiveToolStripMenuItem As ToolStripMenuItem
		Private WithEvents extractToFolderToolStripMenuItem As ToolStripMenuItem
		Private toolStripSeparator8 As ToolStripSeparator
		Private WithEvents viewFileToolStripMenuItem As ToolStripMenuItem
		Private WithEvents deleteFilesToolStripMenuItem As ToolStripMenuItem
		Private WithEvents renameFileToolStripMenuItem As ToolStripMenuItem
		Private addressBar As Panel
		Private txtAddress As TextBox
		Private WithEvents btnUpOneLevel As Button
		Private colTypeName As ColumnHeader
		Private colCrc As ColumnHeader
		Private WithEvents createDirectoryToolStripMenuItem As ToolStripMenuItem
		Private WithEvents moveToolStripMenuItem As ToolStripMenuItem
		Private WithEvents createDirectoryContextMenuItem As ToolStripMenuItem
		Private toolStripSeparator9 As ToolStripSeparator
		Private WithEvents updateArchiveToolStripMenuItem As ToolStripMenuItem
		Private WithEvents fileCommentToolStripMenuItem As ToolStripMenuItem
		Private WithEvents fileCommentContextMenuItem As ToolStripMenuItem
		Private WithEvents moveContextMenuItem As ToolStripMenuItem
		Private progressBarTotal As ToolStripProgressBar
		Private WithEvents calculateDirectorySizeToolStripMenuItem As ToolStripMenuItem
		Private WithEvents calculateTotalSizeContextMenuItem As ToolStripMenuItem
		Private archiveToolStripMenuItem As ToolStripMenuItem
		Private WithEvents createSFXToolStripMenuItem As ToolStripMenuItem
		Private WithEvents viewWithInternalViewerContextMenuItem As ToolStripMenuItem
		Private WithEvents viewWithInternalViewerToolStripMenuItem As ToolStripMenuItem
	End Class
End Namespace

