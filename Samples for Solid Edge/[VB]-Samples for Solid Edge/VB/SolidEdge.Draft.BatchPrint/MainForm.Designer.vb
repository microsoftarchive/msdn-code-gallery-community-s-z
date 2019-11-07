Namespace SolidEdge.Draft.BatchPrint
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
			Me.menuStrip = New System.Windows.Forms.MenuStrip()
			Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStrip = New System.Windows.Forms.ToolStrip()
			Me.buttonOpen = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
			Me.buttonPrint = New System.Windows.Forms.ToolStripButton()
			Me.statusStrip = New System.Windows.Forms.StatusStrip()
			Me.toolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
			Me.splitContainer = New System.Windows.Forms.SplitContainer()
			Me.propertyGrid = New System.Windows.Forms.PropertyGrid()
			Me.label1 = New System.Windows.Forms.Label()
			Me.customListView = New SolidEdge.Draft.BatchPrint.CustomListView()
			Me.columnHeader1 = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
			Me.menuStrip.SuspendLayout()
			Me.toolStrip.SuspendLayout()
			Me.statusStrip.SuspendLayout()
			CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.splitContainer.Panel1.SuspendLayout()
			Me.splitContainer.Panel2.SuspendLayout()
			Me.splitContainer.SuspendLayout()
			Me.SuspendLayout()
			' 
			' menuStrip
			' 
			Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.fileToolStripMenuItem})
			Me.menuStrip.Location = New System.Drawing.Point(0, 0)
			Me.menuStrip.Name = "menuStrip"
			Me.menuStrip.Size = New System.Drawing.Size(784, 24)
			Me.menuStrip.TabIndex = 0
			Me.menuStrip.Text = "menuStrip1"
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
			Me.exitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
			Me.exitToolStripMenuItem.Text = "&Exit"
'			Me.exitToolStripMenuItem.Click += New System.EventHandler(Me.exitToolStripMenuItem_Click)
			' 
			' toolStrip
			' 
			Me.toolStrip.Enabled = False
			Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.buttonOpen, Me.toolStripSeparator1, Me.buttonPrint})
			Me.toolStrip.Location = New System.Drawing.Point(0, 24)
			Me.toolStrip.Name = "toolStrip"
			Me.toolStrip.Size = New System.Drawing.Size(784, 25)
			Me.toolStrip.TabIndex = 1
			' 
			' buttonOpen
			' 
			Me.buttonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.buttonOpen.Image = My.Resources.FolderOpen_16x16_72
			Me.buttonOpen.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.buttonOpen.Name = "buttonOpen"
			Me.buttonOpen.Size = New System.Drawing.Size(23, 22)
			Me.buttonOpen.Text = "Select from folder"
'			Me.buttonOpen.Click += New System.EventHandler(Me.buttonOpen_Click)
			' 
			' toolStripSeparator1
			' 
			Me.toolStripSeparator1.Name = "toolStripSeparator1"
			Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
			' 
			' buttonPrint
			' 
			Me.buttonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.buttonPrint.Image = My.Resources.Print_16x16
			Me.buttonPrint.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.buttonPrint.Name = "buttonPrint"
			Me.buttonPrint.Size = New System.Drawing.Size(23, 22)
			Me.buttonPrint.Text = "Print"
'			Me.buttonPrint.Click += New System.EventHandler(Me.buttonPrint_Click)
			' 
			' statusStrip
			' 
			Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.toolStripStatusLabel})
			Me.statusStrip.Location = New System.Drawing.Point(0, 539)
			Me.statusStrip.Name = "statusStrip"
			Me.statusStrip.Size = New System.Drawing.Size(784, 22)
			Me.statusStrip.TabIndex = 2
			Me.statusStrip.Text = "statusStrip1"
			' 
			' toolStripStatusLabel
			' 
			Me.toolStripStatusLabel.Name = "toolStripStatusLabel"
			Me.toolStripStatusLabel.Size = New System.Drawing.Size(769, 17)
			Me.toolStripStatusLabel.Spring = True
			Me.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' splitContainer
			' 
			Me.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
			Me.splitContainer.Location = New System.Drawing.Point(0, 49)
			Me.splitContainer.Name = "splitContainer"
			' 
			' splitContainer.Panel1
			' 
			Me.splitContainer.Panel1.Controls.Add(Me.customListView)
			' 
			' splitContainer.Panel2
			' 
			Me.splitContainer.Panel2.Controls.Add(Me.propertyGrid)
			Me.splitContainer.Panel2.Controls.Add(Me.label1)
			Me.splitContainer.Size = New System.Drawing.Size(784, 490)
			Me.splitContainer.SplitterDistance = 534
			Me.splitContainer.TabIndex = 4
			' 
			' propertyGrid
			' 
			Me.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
			Me.propertyGrid.Location = New System.Drawing.Point(0, 23)
			Me.propertyGrid.Name = "propertyGrid"
			Me.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
			Me.propertyGrid.Size = New System.Drawing.Size(246, 467)
			Me.propertyGrid.TabIndex = 0
			Me.propertyGrid.ToolbarVisible = False
			' 
			' label1
			' 
			Me.label1.BackColor = System.Drawing.SystemColors.ActiveCaption
			Me.label1.Dock = System.Windows.Forms.DockStyle.Top
			Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label1.ForeColor = System.Drawing.Color.White
			Me.label1.Location = New System.Drawing.Point(0, 0)
			Me.label1.Name = "label1"
			Me.label1.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
			Me.label1.Size = New System.Drawing.Size(246, 23)
			Me.label1.TabIndex = 1
			Me.label1.Text = "DraftPrintUtilityOptions"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' customListView
			' 
			Me.customListView.AllowDrop = True
			Me.customListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.columnHeader1})
			Me.customListView.Dock = System.Windows.Forms.DockStyle.Fill
			Me.customListView.Enabled = False
			Me.customListView.Location = New System.Drawing.Point(0, 0)
			Me.customListView.Name = "customListView"
			Me.customListView.Size = New System.Drawing.Size(534, 490)
			Me.customListView.TabIndex = 3
			Me.customListView.UseCompatibleStateImageBehavior = False
			Me.customListView.UseExplorerTheme = True
			Me.customListView.View = System.Windows.Forms.View.Details
'			Me.customListView.SelectedIndexChanged += New System.EventHandler(Me.customListView_SelectedIndexChanged)
			' 
			' columnHeader1
			' 
			Me.columnHeader1.Text = "File"
			Me.columnHeader1.Width = 780
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(784, 561)
			Me.Controls.Add(Me.splitContainer)
			Me.Controls.Add(Me.statusStrip)
			Me.Controls.Add(Me.toolStrip)
			Me.Controls.Add(Me.menuStrip)
			Me.Font = New System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.MainMenuStrip = Me.menuStrip
			Me.Name = "MainForm"
			Me.Text = "Batch Print"
'			Me.Load += New System.EventHandler(Me.MainForm_Load)
			Me.menuStrip.ResumeLayout(False)
			Me.menuStrip.PerformLayout()
			Me.toolStrip.ResumeLayout(False)
			Me.toolStrip.PerformLayout()
			Me.statusStrip.ResumeLayout(False)
			Me.statusStrip.PerformLayout()
			Me.splitContainer.Panel1.ResumeLayout(False)
			Me.splitContainer.Panel2.ResumeLayout(False)
			CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).EndInit()
			Me.splitContainer.ResumeLayout(False)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private menuStrip As System.Windows.Forms.MenuStrip
		Private toolStrip As System.Windows.Forms.ToolStrip
		Private statusStrip As System.Windows.Forms.StatusStrip
		Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents buttonPrint As System.Windows.Forms.ToolStripButton
		Private WithEvents customListView As CustomListView
		Private columnHeader1 As System.Windows.Forms.ColumnHeader
		Private WithEvents buttonOpen As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
		Private splitContainer As System.Windows.Forms.SplitContainer
		Private propertyGrid As System.Windows.Forms.PropertyGrid
		Private toolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
		Private label1 As System.Windows.Forms.Label
	End Class
End Namespace

