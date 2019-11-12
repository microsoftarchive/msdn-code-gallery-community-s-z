Namespace SolidEdge.UnitsOfMeasure
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
			Dim listViewItem19 As New System.Windows.Forms.ListViewItem(New String() { "Distance", "Meter"}, -1)
			Dim listViewItem20 As New System.Windows.Forms.ListViewItem(New String() { "Angle", "Radian"}, -1)
			Dim listViewItem21 As New System.Windows.Forms.ListViewItem(New String() { "Mass", "Kilogram"}, -1)
			Dim listViewItem22 As New System.Windows.Forms.ListViewItem(New String() { "Time", "Second"}, -1)
			Dim listViewItem23 As New System.Windows.Forms.ListViewItem(New String() { "Temperature", "Kelvin"}, -1)
			Dim listViewItem24 As New System.Windows.Forms.ListViewItem(New String() { "Charge", "Ampere"}, -1)
			Dim listViewItem25 As New System.Windows.Forms.ListViewItem(New String() { "Luminous Intensity", "Candela"}, -1)
			Dim listViewItem26 As New System.Windows.Forms.ListViewItem(New String() { "Amount of Substance", "Mole"}, -1)
			Dim listViewItem27 As New System.Windows.Forms.ListViewItem(New String() { "Solid Angle", "Steradian"}, -1)
			Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
			Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.externalPropertyGrid = New System.Windows.Forms.PropertyGrid()
			Me.internalPropertyGrid = New System.Windows.Forms.PropertyGrid()
			Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.listView1 = New System.Windows.Forms.ListView()
			Me.columnHeader1 = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
			Me.columnHeader2 = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
			Me.label3 = New System.Windows.Forms.Label()
			Me.menuStrip1.SuspendLayout()
			CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.splitContainer1.Panel1.SuspendLayout()
			Me.splitContainer1.Panel2.SuspendLayout()
			Me.splitContainer1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' menuStrip1
			' 
			Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.fileToolStripMenuItem})
			Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
			Me.menuStrip1.Name = "menuStrip1"
			Me.menuStrip1.Size = New System.Drawing.Size(784, 24)
			Me.menuStrip1.TabIndex = 3
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
			' externalPropertyGrid
			' 
			Me.externalPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
			Me.externalPropertyGrid.Location = New System.Drawing.Point(0, 23)
			Me.externalPropertyGrid.Name = "externalPropertyGrid"
			Me.externalPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort
			Me.externalPropertyGrid.Size = New System.Drawing.Size(388, 305)
			Me.externalPropertyGrid.TabIndex = 5
			Me.externalPropertyGrid.ToolbarVisible = False
'			Me.externalPropertyGrid.PropertyValueChanged += New System.Windows.Forms.PropertyValueChangedEventHandler(Me.externalPropertyGrid_PropertyValueChanged)
			' 
			' internalPropertyGrid
			' 
			Me.internalPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
			Me.internalPropertyGrid.Location = New System.Drawing.Point(0, 23)
			Me.internalPropertyGrid.Name = "internalPropertyGrid"
			Me.internalPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort
			Me.internalPropertyGrid.Size = New System.Drawing.Size(392, 305)
			Me.internalPropertyGrid.TabIndex = 7
			Me.internalPropertyGrid.ToolbarVisible = False
'			Me.internalPropertyGrid.PropertyValueChanged += New System.Windows.Forms.PropertyValueChangedEventHandler(Me.internalPropertyGrid_PropertyValueChanged)
			' 
			' splitContainer1
			' 
			Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.splitContainer1.Location = New System.Drawing.Point(0, 24)
			Me.splitContainer1.Name = "splitContainer1"
			' 
			' splitContainer1.Panel1
			' 
			Me.splitContainer1.Panel1.Controls.Add(Me.internalPropertyGrid)
			Me.splitContainer1.Panel1.Controls.Add(Me.label2)
			' 
			' splitContainer1.Panel2
			' 
			Me.splitContainer1.Panel2.Controls.Add(Me.externalPropertyGrid)
			Me.splitContainer1.Panel2.Controls.Add(Me.label1)
			Me.splitContainer1.Size = New System.Drawing.Size(784, 328)
			Me.splitContainer1.SplitterDistance = 392
			Me.splitContainer1.TabIndex = 8
			' 
			' label1
			' 
			Me.label1.BackColor = System.Drawing.Color.LightSteelBlue
			Me.label1.Dock = System.Windows.Forms.DockStyle.Top
			Me.label1.Font = New System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label1.Location = New System.Drawing.Point(0, 0)
			Me.label1.Name = "label1"
			Me.label1.Padding = New System.Windows.Forms.Padding(5)
			Me.label1.Size = New System.Drawing.Size(388, 23)
			Me.label1.TabIndex = 6
			Me.label1.Text = "External Units --> Internal Units"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' label2
			' 
			Me.label2.BackColor = System.Drawing.Color.LightSteelBlue
			Me.label2.Dock = System.Windows.Forms.DockStyle.Top
			Me.label2.Font = New System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label2.Location = New System.Drawing.Point(0, 0)
			Me.label2.Name = "label2"
			Me.label2.Padding = New System.Windows.Forms.Padding(5)
			Me.label2.Size = New System.Drawing.Size(392, 23)
			Me.label2.TabIndex = 8
			Me.label2.Text = "Internal Units --> External Units"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' listView1
			' 
			Me.listView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.columnHeader1, Me.columnHeader2})
			Me.listView1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.listView1.FullRowSelect = True
			Me.listView1.Items.AddRange(New System.Windows.Forms.ListViewItem() { listViewItem19, listViewItem20, listViewItem21, listViewItem22, listViewItem23, listViewItem24, listViewItem25, listViewItem26, listViewItem27})
			Me.listView1.Location = New System.Drawing.Point(0, 375)
			Me.listView1.MultiSelect = False
			Me.listView1.Name = "listView1"
			Me.listView1.Size = New System.Drawing.Size(784, 186)
			Me.listView1.TabIndex = 9
			Me.listView1.UseCompatibleStateImageBehavior = False
			Me.listView1.View = System.Windows.Forms.View.Details
			' 
			' columnHeader1
			' 
			Me.columnHeader1.Text = "Unit Type"
			Me.columnHeader1.Width = 128
			' 
			' columnHeader2
			' 
			Me.columnHeader2.Text = "Internal Units"
			Me.columnHeader2.Width = 90
			' 
			' label3
			' 
			Me.label3.BackColor = System.Drawing.Color.LightSteelBlue
			Me.label3.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.label3.Font = New System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label3.Location = New System.Drawing.Point(0, 352)
			Me.label3.Name = "label3"
			Me.label3.Padding = New System.Windows.Forms.Padding(5)
			Me.label3.Size = New System.Drawing.Size(784, 23)
			Me.label3.TabIndex = 10
			Me.label3.Text = "Internal (Database) Unit Reference"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(784, 561)
			Me.Controls.Add(Me.splitContainer1)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.listView1)
			Me.Controls.Add(Me.menuStrip1)
			Me.Font = New System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.MainMenuStrip = Me.menuStrip1
			Me.Name = "MainForm"
			Me.Text = "Units of Measure"
'			Me.Load += New System.EventHandler(Me.MainForm_Load)
			Me.menuStrip1.ResumeLayout(False)
			Me.menuStrip1.PerformLayout()
			Me.splitContainer1.Panel1.ResumeLayout(False)
			Me.splitContainer1.Panel2.ResumeLayout(False)
			CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.splitContainer1.ResumeLayout(False)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private menuStrip1 As System.Windows.Forms.MenuStrip
		Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents externalPropertyGrid As System.Windows.Forms.PropertyGrid
		Private WithEvents internalPropertyGrid As System.Windows.Forms.PropertyGrid
		Private splitContainer1 As System.Windows.Forms.SplitContainer
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private listView1 As System.Windows.Forms.ListView
		Private columnHeader1 As System.Windows.Forms.ColumnHeader
		Private columnHeader2 As System.Windows.Forms.ColumnHeader
		Private label3 As System.Windows.Forms.Label
	End Class
End Namespace

