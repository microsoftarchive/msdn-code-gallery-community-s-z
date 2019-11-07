Namespace SolidEdge.Assembly.BOM
	Partial Public Class MainForm
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
			Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
			Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.editToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.copyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
			Me.selectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.refreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
			Me.buttonRefresh = New System.Windows.Forms.ToolStripButton()
			Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
			Me.lvBOM = New System.Windows.Forms.ListView()
			Me.chLevel = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
			Me.chDocumentNumber = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
			Me.chRevision = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
			Me.chTitle = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
			Me.chQuantity = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
			Me.chFileName = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
			Me.imlListView = New System.Windows.Forms.ImageList(Me.components)
			Me.menuStrip1.SuspendLayout()
			Me.toolStrip1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' menuStrip1
			' 
			Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.fileToolStripMenuItem, Me.editToolStripMenuItem, Me.viewToolStripMenuItem})
			Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
			Me.menuStrip1.Name = "menuStrip1"
			Me.menuStrip1.Size = New System.Drawing.Size(699, 24)
			Me.menuStrip1.TabIndex = 0
			Me.menuStrip1.Text = "menuStrip1"
			' 
			' fileToolStripMenuItem
			' 
			Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.exitToolStripMenuItem})
			Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
			Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
			Me.fileToolStripMenuItem.Text = "&File"
			' 
			' exitToolStripMenuItem
			' 
			Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
			Me.exitToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys))
			Me.exitToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
			Me.exitToolStripMenuItem.Text = "&Exit"
'			Me.exitToolStripMenuItem.Click += New System.EventHandler(Me.exitToolStripMenuItem_Click)
			' 
			' editToolStripMenuItem
			' 
			Me.editToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.copyToolStripMenuItem, Me.toolStripMenuItem1, Me.selectAllToolStripMenuItem})
			Me.editToolStripMenuItem.Name = "editToolStripMenuItem"
			Me.editToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
			Me.editToolStripMenuItem.Text = "&Edit"
			' 
			' copyToolStripMenuItem
			' 
			Me.copyToolStripMenuItem.Name = "copyToolStripMenuItem"
			Me.copyToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys))
			Me.copyToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
			Me.copyToolStripMenuItem.Text = "&Copy"
'			Me.copyToolStripMenuItem.Click += New System.EventHandler(Me.copyToolStripMenuItem_Click)
			' 
			' toolStripMenuItem1
			' 
			Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
			Me.toolStripMenuItem1.Size = New System.Drawing.Size(161, 6)
			' 
			' selectAllToolStripMenuItem
			' 
			Me.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem"
			Me.selectAllToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys))
			Me.selectAllToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
			Me.selectAllToolStripMenuItem.Text = "Select &All"
'			Me.selectAllToolStripMenuItem.Click += New System.EventHandler(Me.selectAllToolStripMenuItem_Click)
			' 
			' viewToolStripMenuItem
			' 
			Me.viewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.refreshToolStripMenuItem})
			Me.viewToolStripMenuItem.Name = "viewToolStripMenuItem"
			Me.viewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
			Me.viewToolStripMenuItem.Text = "&View"
			' 
			' refreshToolStripMenuItem
			' 
			Me.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem"
			Me.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
			Me.refreshToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
			Me.refreshToolStripMenuItem.Text = "&Refresh"
'			Me.refreshToolStripMenuItem.Click += New System.EventHandler(Me.refreshToolStripMenuItem_Click)
			' 
			' toolStrip1
			' 
			Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.buttonRefresh})
			Me.toolStrip1.Location = New System.Drawing.Point(0, 24)
			Me.toolStrip1.Name = "toolStrip1"
			Me.toolStrip1.Size = New System.Drawing.Size(699, 25)
			Me.toolStrip1.TabIndex = 1
			Me.toolStrip1.Text = "toolStrip1"
			' 
			' buttonRefresh
			' 
			Me.buttonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.buttonRefresh.Image = My.Resources.Refresh_16x16
			Me.buttonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.buttonRefresh.Name = "buttonRefresh"
			Me.buttonRefresh.Size = New System.Drawing.Size(23, 22)
			Me.buttonRefresh.Text = "Refresh"
'			Me.buttonRefresh.Click += New System.EventHandler(Me.buttonRefresh_Click)
			' 
			' statusStrip1
			' 
			Me.statusStrip1.Location = New System.Drawing.Point(0, 436)
			Me.statusStrip1.Name = "statusStrip1"
			Me.statusStrip1.Size = New System.Drawing.Size(699, 22)
			Me.statusStrip1.TabIndex = 2
			Me.statusStrip1.Text = "statusStrip1"
			' 
			' lvBOM
			' 
			Me.lvBOM.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.chLevel, Me.chDocumentNumber, Me.chRevision, Me.chTitle, Me.chQuantity, Me.chFileName})
			Me.lvBOM.Dock = System.Windows.Forms.DockStyle.Fill
			Me.lvBOM.FullRowSelect = True
			Me.lvBOM.HideSelection = False
			Me.lvBOM.Location = New System.Drawing.Point(0, 49)
			Me.lvBOM.Name = "lvBOM"
			Me.lvBOM.Size = New System.Drawing.Size(699, 387)
			Me.lvBOM.SmallImageList = Me.imlListView
			Me.lvBOM.TabIndex = 3
			Me.lvBOM.UseCompatibleStateImageBehavior = False
			Me.lvBOM.View = System.Windows.Forms.View.Details
			' 
			' chLevel
			' 
			Me.chLevel.Text = "Level"
			' 
			' chDocumentNumber
			' 
			Me.chDocumentNumber.Text = "Document Number"
			' 
			' chRevision
			' 
			Me.chRevision.Text = "Revision"
			' 
			' chTitle
			' 
			Me.chTitle.Text = "Title"
			' 
			' chQuantity
			' 
			Me.chQuantity.Text = "Quantity"
			' 
			' chFileName
			' 
			Me.chFileName.Text = "File Name"
			' 
			' imlListView
			' 
			Me.imlListView.ImageStream = (CType(resources.GetObject("imlListView.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imlListView.TransparentColor = System.Drawing.Color.Transparent
			Me.imlListView.Images.SetKeyName(0, "SubAssembly_16x16.png")
			Me.imlListView.Images.SetKeyName(1, "SubPart_16x16.png")
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(699, 458)
			Me.Controls.Add(Me.lvBOM)
			Me.Controls.Add(Me.statusStrip1)
			Me.Controls.Add(Me.toolStrip1)
			Me.Controls.Add(Me.menuStrip1)
			Me.DoubleBuffered = True
			Me.MainMenuStrip = Me.menuStrip1
			Me.Name = "MainForm"
			Me.Text = "Assembly BOM"
'			Me.Load += New System.EventHandler(Me.MainForm_Load)
			Me.menuStrip1.ResumeLayout(False)
			Me.menuStrip1.PerformLayout()
			Me.toolStrip1.ResumeLayout(False)
			Me.toolStrip1.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private menuStrip1 As System.Windows.Forms.MenuStrip
		Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStrip1 As System.Windows.Forms.ToolStrip
		Private statusStrip1 As System.Windows.Forms.StatusStrip
		Private lvBOM As System.Windows.Forms.ListView
		Private WithEvents buttonRefresh As System.Windows.Forms.ToolStripButton
		Private viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents refreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private editToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents copyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private toolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents selectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private chLevel As System.Windows.Forms.ColumnHeader
		Private chDocumentNumber As System.Windows.Forms.ColumnHeader
		Private chRevision As System.Windows.Forms.ColumnHeader
		Private chTitle As System.Windows.Forms.ColumnHeader
		Private chQuantity As System.Windows.Forms.ColumnHeader
		Private chFileName As System.Windows.Forms.ColumnHeader
		Private imlListView As System.Windows.Forms.ImageList
	End Class
End Namespace

