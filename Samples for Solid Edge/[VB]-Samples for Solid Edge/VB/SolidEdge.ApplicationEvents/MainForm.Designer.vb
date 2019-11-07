Namespace SolidEdge.ApplicationEvents
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
			Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
			Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
			Me.eventButton = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
			Me.clearButton = New System.Windows.Forms.ToolStripButton()
			Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
			Me.eventLogTextBox = New System.Windows.Forms.TextBox()
			Me.menuStrip1.SuspendLayout()
			Me.toolStrip1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' menuStrip1
			' 
			Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.fileToolStripMenuItem})
			Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
			Me.menuStrip1.Name = "menuStrip1"
			Me.menuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
			Me.menuStrip1.Size = New System.Drawing.Size(541, 24)
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
			Me.exitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
			Me.exitToolStripMenuItem.Text = "&Exit"
'			Me.exitToolStripMenuItem.Click += New System.EventHandler(Me.exitToolStripMenuItem_Click)
			' 
			' toolStrip1
			' 
			Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.eventButton, Me.toolStripSeparator1, Me.clearButton})
			Me.toolStrip1.Location = New System.Drawing.Point(0, 24)
			Me.toolStrip1.Name = "toolStrip1"
			Me.toolStrip1.Size = New System.Drawing.Size(541, 25)
			Me.toolStrip1.TabIndex = 1
			Me.toolStrip1.Text = "toolStrip1"
			' 
			' eventButton
			' 
			Me.eventButton.CheckOnClick = True
			Me.eventButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.eventButton.Image = My.Resources.Event_16x16
			Me.eventButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.eventButton.Name = "eventButton"
			Me.eventButton.Size = New System.Drawing.Size(23, 22)
			Me.eventButton.Text = "Events"
			Me.eventButton.ToolTipText = "Toggles event connections"
'			Me.eventButton.Click += New System.EventHandler(Me.eventButton_Click)
			' 
			' toolStripSeparator1
			' 
			Me.toolStripSeparator1.Name = "toolStripSeparator1"
			Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
			' 
			' clearButton
			' 
			Me.clearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.clearButton.Image = My.Resources.Clear_16x16
			Me.clearButton.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.clearButton.Name = "clearButton"
			Me.clearButton.Size = New System.Drawing.Size(23, 22)
			Me.clearButton.Text = "toolStripButton1"
'			Me.clearButton.Click += New System.EventHandler(Me.clearButton_Click)
			' 
			' statusStrip1
			' 
			Me.statusStrip1.Location = New System.Drawing.Point(0, 384)
			Me.statusStrip1.Name = "statusStrip1"
			Me.statusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
			Me.statusStrip1.Size = New System.Drawing.Size(541, 22)
			Me.statusStrip1.TabIndex = 2
			Me.statusStrip1.Text = "statusStrip1"
			' 
			' eventLogTextBox
			' 
			Me.eventLogTextBox.AcceptsReturn = True
			Me.eventLogTextBox.AcceptsTab = True
			Me.eventLogTextBox.BackColor = System.Drawing.Color.White
			Me.eventLogTextBox.Dock = System.Windows.Forms.DockStyle.Fill
			Me.eventLogTextBox.Font = New System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.eventLogTextBox.Location = New System.Drawing.Point(0, 49)
			Me.eventLogTextBox.MaxLength = 0
			Me.eventLogTextBox.Multiline = True
			Me.eventLogTextBox.Name = "eventLogTextBox"
			Me.eventLogTextBox.ReadOnly = True
			Me.eventLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
			Me.eventLogTextBox.Size = New System.Drawing.Size(541, 335)
			Me.eventLogTextBox.TabIndex = 3
			Me.eventLogTextBox.WordWrap = False
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(7F, 15F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(541, 406)
			Me.Controls.Add(Me.eventLogTextBox)
			Me.Controls.Add(Me.statusStrip1)
			Me.Controls.Add(Me.toolStrip1)
			Me.Controls.Add(Me.menuStrip1)
			Me.Font = New System.Drawing.Font("Segoe UI", 9F)
			Me.MainMenuStrip = Me.menuStrip1
			Me.Name = "MainForm"
			Me.Text = "Solid Edge Events Demo"
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.MainForm_FormClosing)
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
		Private WithEvents eventButton As System.Windows.Forms.ToolStripButton
		Private eventLogTextBox As System.Windows.Forms.TextBox
		Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents clearButton As System.Windows.Forms.ToolStripButton
	End Class
End Namespace

