Namespace SolidEdge.GlobalParameters
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
			Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
			Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
			Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
			Me.refreshButton = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
			Me.booleanToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
			Me.textToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
			Me.editButton = New System.Windows.Forms.ToolStripButton()
			Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
			Me.lvGlobalParameters = New SolidEdge.GlobalParameters.ExplorerListView()
			Me.columnHeader1 = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
			Me.columnHeader2 = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
			Me.columnHeader3 = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
			Me.columnHeader4 = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
			Me.menuStrip1.SuspendLayout()
			Me.toolStrip1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' imageList1
			' 
			Me.imageList1.ImageStream = (CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
			Me.imageList1.Images.SetKeyName(0, "EnumItem_16x16.png")
			' 
			' menuStrip1
			' 
			Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.fileToolStripMenuItem})
			Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
			Me.menuStrip1.Name = "menuStrip1"
			Me.menuStrip1.Size = New System.Drawing.Size(784, 24)
			Me.menuStrip1.TabIndex = 1
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
			Me.exitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
			Me.exitToolStripMenuItem.Text = "&Exit"
'			Me.exitToolStripMenuItem.Click += New System.EventHandler(Me.exitToolStripMenuItem_Click)
			' 
			' statusStrip1
			' 
			Me.statusStrip1.Location = New System.Drawing.Point(0, 540)
			Me.statusStrip1.Name = "statusStrip1"
			Me.statusStrip1.Size = New System.Drawing.Size(784, 22)
			Me.statusStrip1.TabIndex = 2
			Me.statusStrip1.Text = "statusStrip1"
			' 
			' refreshButton
			' 
			Me.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.refreshButton.Image = My.Resources.Refresh_16x16
			Me.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.refreshButton.Name = "refreshButton"
			Me.refreshButton.Size = New System.Drawing.Size(23, 22)
			Me.refreshButton.Text = "Refresh"
'			Me.refreshButton.Click += New System.EventHandler(Me.refreshButton_Click)
			' 
			' toolStripSeparator1
			' 
			Me.toolStripSeparator1.Name = "toolStripSeparator1"
			Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
			' 
			' booleanToolStripComboBox
			' 
			Me.booleanToolStripComboBox.AutoSize = False
			Me.booleanToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.booleanToolStripComboBox.DropDownWidth = 50
			Me.booleanToolStripComboBox.Name = "booleanToolStripComboBox"
			Me.booleanToolStripComboBox.Size = New System.Drawing.Size(50, 23)
			' 
			' textToolStripTextBox
			' 
			Me.textToolStripTextBox.Name = "textToolStripTextBox"
			Me.textToolStripTextBox.Size = New System.Drawing.Size(200, 25)
			' 
			' editButton
			' 
			Me.editButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.editButton.Enabled = False
			Me.editButton.Image = My.Resources.Edit_16x16
			Me.editButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.editButton.Name = "editButton"
			Me.editButton.Size = New System.Drawing.Size(23, 22)
			Me.editButton.Text = "Edit"
'			Me.editButton.Click += New System.EventHandler(Me.editButton_Click)
			' 
			' toolStrip1
			' 
			Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.refreshButton, Me.toolStripSeparator1, Me.booleanToolStripComboBox, Me.textToolStripTextBox, Me.editButton})
			Me.toolStrip1.Location = New System.Drawing.Point(0, 24)
			Me.toolStrip1.Name = "toolStrip1"
			Me.toolStrip1.Size = New System.Drawing.Size(784, 25)
			Me.toolStrip1.TabIndex = 3
			Me.toolStrip1.Text = "toolStrip1"
			' 
			' lvGlobalParameters
			' 
			Me.lvGlobalParameters.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader4})
			Me.lvGlobalParameters.Dock = System.Windows.Forms.DockStyle.Fill
			Me.lvGlobalParameters.FullRowSelect = True
			Me.lvGlobalParameters.HideSelection = False
			Me.lvGlobalParameters.Location = New System.Drawing.Point(0, 49)
			Me.lvGlobalParameters.MultiSelect = False
			Me.lvGlobalParameters.Name = "lvGlobalParameters"
			Me.lvGlobalParameters.SelectedItem = Nothing
			Me.lvGlobalParameters.Size = New System.Drawing.Size(784, 491)
			Me.lvGlobalParameters.SmallImageList = Me.imageList1
			Me.lvGlobalParameters.TabIndex = 0
			Me.lvGlobalParameters.UseCompatibleStateImageBehavior = False
			Me.lvGlobalParameters.View = System.Windows.Forms.View.Details
'			Me.lvGlobalParameters.SelectedIndexChanged += New System.EventHandler(Me.lvGlobalParameters_SelectedIndexChanged)
			' 
			' columnHeader1
			' 
			Me.columnHeader1.Text = "Constant Friendly Name"
			' 
			' columnHeader2
			' 
			Me.columnHeader2.Text = "Value"
			Me.columnHeader2.Width = 307
			' 
			' columnHeader3
			' 
			Me.columnHeader3.Text = "Value Type"
			Me.columnHeader3.Width = 219
			' 
			' columnHeader4
			' 
			Me.columnHeader4.Text = "Constant"
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(784, 562)
			Me.Controls.Add(Me.lvGlobalParameters)
			Me.Controls.Add(Me.toolStrip1)
			Me.Controls.Add(Me.statusStrip1)
			Me.Controls.Add(Me.menuStrip1)
			Me.DoubleBuffered = True
			Me.MainMenuStrip = Me.menuStrip1
			Me.Name = "MainForm"
			Me.Text = "Solid Edge Global Parameters"
'			Me.Load += New System.EventHandler(Me.MainForm_Load)
			Me.menuStrip1.ResumeLayout(False)
			Me.menuStrip1.PerformLayout()
			Me.toolStrip1.ResumeLayout(False)
			Me.toolStrip1.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents lvGlobalParameters As ExplorerListView
		Private menuStrip1 As System.Windows.Forms.MenuStrip
		Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private statusStrip1 As System.Windows.Forms.StatusStrip
		Private columnHeader1 As System.Windows.Forms.ColumnHeader
		Private columnHeader2 As System.Windows.Forms.ColumnHeader
		Private columnHeader3 As System.Windows.Forms.ColumnHeader
		Private imageList1 As System.Windows.Forms.ImageList
		Private WithEvents refreshButton As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
		Private booleanToolStripComboBox As System.Windows.Forms.ToolStripComboBox
		Private textToolStripTextBox As System.Windows.Forms.ToolStripTextBox
		Private WithEvents editButton As System.Windows.Forms.ToolStripButton
		Private toolStrip1 As System.Windows.Forms.ToolStrip
		Private columnHeader4 As System.Windows.Forms.ColumnHeader
	End Class
End Namespace

