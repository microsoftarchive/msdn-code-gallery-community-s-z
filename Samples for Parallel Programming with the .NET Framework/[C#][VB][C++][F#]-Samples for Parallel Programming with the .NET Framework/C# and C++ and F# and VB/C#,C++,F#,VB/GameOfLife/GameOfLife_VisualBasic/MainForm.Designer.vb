Namespace GameOfLife
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
			Me.pictureBox1 = New PictureBox()
			Me.btnRun = New Button()
			Me.chkParallel = New CheckBox()
			Me.tbDensity = New TrackBar()
			Me.lblDensity = New Label()
			Me.lblFramesPerSecond = New Label()
			CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.tbDensity, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' pictureBox1
			' 
			Me.pictureBox1.Anchor = (CType((((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles))
			Me.pictureBox1.BackColor = Color.White
			Me.pictureBox1.BorderStyle = BorderStyle.Fixed3D
			Me.pictureBox1.Location = New Point(12, 41)
			Me.pictureBox1.Name = "pictureBox1"
			Me.pictureBox1.Size = New Size(464, 413)
			Me.pictureBox1.TabIndex = 0
			Me.pictureBox1.TabStop = False
			' 
			' btnRun
			' 
			Me.btnRun.Location = New Point(12, 12)
			Me.btnRun.Name = "btnRun"
			Me.btnRun.Size = New Size(75, 23)
			Me.btnRun.TabIndex = 1
			Me.btnRun.Text = "Start"
			Me.btnRun.UseVisualStyleBackColor = True
'			Me.btnRun.Click += New System.EventHandler(Me.btnRun_Click)
			' 
			' chkParallel
			' 
			Me.chkParallel.AutoSize = True
			Me.chkParallel.Location = New Point(93, 16)
			Me.chkParallel.Name = "chkParallel"
			Me.chkParallel.Size = New Size(66, 17)
			Me.chkParallel.TabIndex = 2
			Me.chkParallel.Text = "Parallel?"
			Me.chkParallel.UseVisualStyleBackColor = True
'			Me.chkParallel.CheckedChanged += New System.EventHandler(Me.chkParallel_CheckedChanged)
			' 
			' tbDensity
			' 
			Me.tbDensity.Anchor = (CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles))
			Me.tbDensity.Location = New Point(325, 12)
			Me.tbDensity.Maximum = 1000
			Me.tbDensity.Minimum = 1
			Me.tbDensity.Name = "tbDensity"
			Me.tbDensity.Size = New Size(151, 45)
			Me.tbDensity.TabIndex = 3
			Me.tbDensity.TickStyle = TickStyle.None
			Me.tbDensity.Value = 100
			' 
			' lblDensity
			' 
			Me.lblDensity.AutoSize = True
			Me.lblDensity.Location = New Point(250, 16)
			Me.lblDensity.Name = "lblDensity"
			Me.lblDensity.Size = New Size(69, 13)
			Me.lblDensity.TabIndex = 4
			Me.lblDensity.Text = "Initial Density"
			' 
			' lblFramesPerSecond
			' 
			Me.lblFramesPerSecond.Anchor = (CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles))
			Me.lblFramesPerSecond.AutoSize = True
			Me.lblFramesPerSecond.Location = New Point(13, 457)
			Me.lblFramesPerSecond.Name = "lblFramesPerSecond"
			Me.lblFramesPerSecond.Size = New Size(77, 13)
			Me.lblFramesPerSecond.TabIndex = 5
			Me.lblFramesPerSecond.Text = "Frames / Sec: "
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(488, 482)
			Me.Controls.Add(Me.lblFramesPerSecond)
			Me.Controls.Add(Me.lblDensity)
			Me.Controls.Add(Me.chkParallel)
			Me.Controls.Add(Me.btnRun)
			Me.Controls.Add(Me.pictureBox1)
			Me.Controls.Add(Me.tbDensity)
			Me.Name = "MainForm"
			Me.Text = "Conway's Game Of Life"
			CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.tbDensity, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private pictureBox1 As PictureBox
		Private WithEvents btnRun As Button
		Private WithEvents chkParallel As CheckBox
		Private tbDensity As TrackBar
		Private lblDensity As Label
		Private lblFramesPerSecond As Label
	End Class
End Namespace

