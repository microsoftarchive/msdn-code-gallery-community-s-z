Namespace ChatApp
	Partial Public Class Form1
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
			Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
			Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
			Me.lblConnections = New System.Windows.Forms.ToolStripStatusLabel()
			Me.toolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
			Me.rtbConOut = New System.Windows.Forms.RichTextBox()
			Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
			Me.BtnNewClient = New System.Windows.Forms.ToolStripButton()
			Me.statusStrip1.SuspendLayout()
			Me.toolStripContainer1.ContentPanel.SuspendLayout()
			Me.toolStripContainer1.TopToolStripPanel.SuspendLayout()
			Me.toolStripContainer1.SuspendLayout()
			Me.toolStrip1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' statusStrip1
			' 
			Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.toolStripStatusLabel1, Me.lblConnections})
			Me.statusStrip1.Location = New System.Drawing.Point(0, 572)
			Me.statusStrip1.Name = "statusStrip1"
			Me.statusStrip1.Size = New System.Drawing.Size(284, 22)
			Me.statusStrip1.TabIndex = 0
			Me.statusStrip1.Text = "statusStrip1"
			' 
			' toolStripStatusLabel1
			' 
			Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
			Me.toolStripStatusLabel1.Size = New System.Drawing.Size(74, 17)
			Me.toolStripStatusLabel1.Text = "Connections"
			' 
			' lblConnections
			' 
			Me.lblConnections.Name = "lblConnections"
			Me.lblConnections.Size = New System.Drawing.Size(13, 17)
			Me.lblConnections.Text = "0"
			' 
			' toolStripContainer1
			' 
			' 
			' toolStripContainer1.ContentPanel
			' 
			Me.toolStripContainer1.ContentPanel.Controls.Add(Me.rtbConOut)
			Me.toolStripContainer1.ContentPanel.Size = New System.Drawing.Size(284, 547)
			Me.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.toolStripContainer1.Location = New System.Drawing.Point(0, 0)
			Me.toolStripContainer1.Name = "toolStripContainer1"
			Me.toolStripContainer1.Size = New System.Drawing.Size(284, 572)
			Me.toolStripContainer1.TabIndex = 2
			Me.toolStripContainer1.Text = "toolStripContainer1"
			' 
			' toolStripContainer1.TopToolStripPanel
			' 
			Me.toolStripContainer1.TopToolStripPanel.Controls.Add(Me.toolStrip1)
			' 
			' rtbConOut
			' 
			Me.rtbConOut.BackColor = System.Drawing.Color.RoyalBlue
			Me.rtbConOut.BorderStyle = System.Windows.Forms.BorderStyle.None
			Me.rtbConOut.Dock = System.Windows.Forms.DockStyle.Fill
			Me.rtbConOut.ForeColor = System.Drawing.Color.Yellow
			Me.rtbConOut.Location = New System.Drawing.Point(0, 0)
			Me.rtbConOut.Name = "rtbConOut"
			Me.rtbConOut.ShowSelectionMargin = True
			Me.rtbConOut.Size = New System.Drawing.Size(284, 547)
			Me.rtbConOut.TabIndex = 2
			Me.rtbConOut.Text = "Server V1"
			' 
			' toolStrip1
			' 
			Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
			Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.BtnNewClient})
			Me.toolStrip1.Location = New System.Drawing.Point(3, 0)
			Me.toolStrip1.Name = "toolStrip1"
			Me.toolStrip1.Size = New System.Drawing.Size(66, 25)
			Me.toolStrip1.TabIndex = 0
			' 
			' BtnNewClient
			' 
			Me.BtnNewClient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me.BtnNewClient.Image = My.Resources.company_overview_careers
			Me.BtnNewClient.ImageTransparentColor = System.Drawing.Color.Magenta
			Me.BtnNewClient.Name = "BtnNewClient"
			Me.BtnNewClient.Size = New System.Drawing.Size(23, 22)
			Me.BtnNewClient.Text = "toolStripButton1"
'			Me.BtnNewClient.Click += New System.EventHandler(Me.BtnNewClient_Click)
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(284, 594)
			Me.Controls.Add(Me.toolStripContainer1)
			Me.Controls.Add(Me.statusStrip1)
			Me.Name = "Form1"
			Me.Text = "Server"
			Me.statusStrip1.ResumeLayout(False)
			Me.statusStrip1.PerformLayout()
			Me.toolStripContainer1.ContentPanel.ResumeLayout(False)
			Me.toolStripContainer1.TopToolStripPanel.ResumeLayout(False)
			Me.toolStripContainer1.TopToolStripPanel.PerformLayout()
			Me.toolStripContainer1.ResumeLayout(False)
			Me.toolStripContainer1.PerformLayout()
			Me.toolStrip1.ResumeLayout(False)
			Me.toolStrip1.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private statusStrip1 As System.Windows.Forms.StatusStrip
		Private toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
		Private lblConnections As System.Windows.Forms.ToolStripStatusLabel
		Private toolStripContainer1 As System.Windows.Forms.ToolStripContainer
		Private rtbConOut As System.Windows.Forms.RichTextBox
		Private toolStrip1 As System.Windows.Forms.ToolStrip
		Private WithEvents BtnNewClient As System.Windows.Forms.ToolStripButton
	End Class
End Namespace

