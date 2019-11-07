Namespace ServerApp
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
			Me.rtbServer = New System.Windows.Forms.RichTextBox()
			Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
			Me.lblNumberOfConnections = New System.Windows.Forms.ToolStripStatusLabel()
			Me.statusStrip1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' statusStrip1
			' 
			Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.toolStripStatusLabel1, Me.lblNumberOfConnections})
			Me.statusStrip1.Location = New System.Drawing.Point(0, 259)
			Me.statusStrip1.Name = "statusStrip1"
			Me.statusStrip1.Size = New System.Drawing.Size(621, 22)
			Me.statusStrip1.TabIndex = 0
			Me.statusStrip1.Text = "statusStrip1"
			' 
			' rtbServer
			' 
			Me.rtbServer.BackColor = System.Drawing.Color.RoyalBlue
			Me.rtbServer.Dock = System.Windows.Forms.DockStyle.Fill
			Me.rtbServer.Location = New System.Drawing.Point(0, 0)
			Me.rtbServer.Name = "rtbServer"
			Me.rtbServer.Size = New System.Drawing.Size(621, 259)
			Me.rtbServer.TabIndex = 1
			Me.rtbServer.Text = ""
			' 
			' toolStripStatusLabel1
			' 
			Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
			Me.toolStripStatusLabel1.Size = New System.Drawing.Size(135, 17)
			Me.toolStripStatusLabel1.Text = "Number of Connections"
			' 
			' lblNumberOfConnections
			' 
			Me.lblNumberOfConnections.Name = "lblNumberOfConnections"
			Me.lblNumberOfConnections.Size = New System.Drawing.Size(13, 17)
			Me.lblNumberOfConnections.Text = "0"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(621, 281)
			Me.Controls.Add(Me.rtbServer)
			Me.Controls.Add(Me.statusStrip1)
			Me.Name = "Form1"
			Me.Text = "Server"
			Me.statusStrip1.ResumeLayout(False)
			Me.statusStrip1.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private statusStrip1 As System.Windows.Forms.StatusStrip
		Private toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
		Private lblNumberOfConnections As System.Windows.Forms.ToolStripStatusLabel
		Private rtbServer As System.Windows.Forms.RichTextBox
	End Class
End Namespace

