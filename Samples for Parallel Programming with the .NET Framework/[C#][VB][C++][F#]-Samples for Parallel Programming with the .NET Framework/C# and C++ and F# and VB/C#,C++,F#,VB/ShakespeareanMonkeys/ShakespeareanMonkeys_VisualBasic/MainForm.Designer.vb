Namespace ShakespeareanMonkeys
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
			Me.splitContainer1 = New SplitContainer()
			Me.lblGenPerSec = New Label()
			Me.label5 = New Label()
			Me.lblElapsedTime = New Label()
			Me.label4 = New Label()
			Me.lblGenerations = New Label()
			Me.label2 = New Label()
			Me.splitContainer2 = New SplitContainer()
			Me.txtBestMatch = New TextBox()
			Me.txtTarget = New TextBox()
			Me.btnRun = New Button()
			Me.txtMonkeysPerGeneration = New TextBox()
			Me.label1 = New Label()
			Me.timerElapsedTime = New Timer()
			Me.chkParallel = New CheckBox()
			Me.pictureBox1 = New PictureBox()
			CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.splitContainer1.Panel1.SuspendLayout()
			Me.splitContainer1.Panel2.SuspendLayout()
			Me.splitContainer1.SuspendLayout()
			CType(Me.splitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.splitContainer2.Panel1.SuspendLayout()
			Me.splitContainer2.Panel2.SuspendLayout()
			Me.splitContainer2.SuspendLayout()
			CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' splitContainer1
			' 
			Me.splitContainer1.Dock = DockStyle.Fill
			Me.splitContainer1.Location = New Point(0, 0)
			Me.splitContainer1.Name = "splitContainer1"
			' 
			' splitContainer1.Panel1
			' 
			Me.splitContainer1.Panel1.Controls.Add(Me.pictureBox1)
			' 
			' splitContainer1.Panel2
			' 
			Me.splitContainer1.Panel2.Controls.Add(Me.chkParallel)
			Me.splitContainer1.Panel2.Controls.Add(Me.lblGenPerSec)
			Me.splitContainer1.Panel2.Controls.Add(Me.label5)
			Me.splitContainer1.Panel2.Controls.Add(Me.lblElapsedTime)
			Me.splitContainer1.Panel2.Controls.Add(Me.label4)
			Me.splitContainer1.Panel2.Controls.Add(Me.lblGenerations)
			Me.splitContainer1.Panel2.Controls.Add(Me.label2)
			Me.splitContainer1.Panel2.Controls.Add(Me.splitContainer2)
			Me.splitContainer1.Panel2.Controls.Add(Me.btnRun)
			Me.splitContainer1.Panel2.Controls.Add(Me.txtMonkeysPerGeneration)
			Me.splitContainer1.Panel2.Controls.Add(Me.label1)
			Me.splitContainer1.Size = New Size(973, 389)
			Me.splitContainer1.SplitterDistance = 301
			Me.splitContainer1.TabIndex = 1
			' 
			' lblGenPerSec
			' 
			Me.lblGenPerSec.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
			Me.lblGenPerSec.AutoSize = True
			Me.lblGenPerSec.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, (CByte(0)))
			Me.lblGenPerSec.Location = New Point(601, 48)
			Me.lblGenPerSec.Name = "lblGenPerSec"
			Me.lblGenPerSec.Size = New Size(13, 17)
			Me.lblGenPerSec.TabIndex = 9
			Me.lblGenPerSec.Text = "-"
			' 
			' label5
			' 
			Me.label5.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
			Me.label5.AutoSize = True
			Me.label5.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(0)))
			Me.label5.Location = New Point(454, 48)
			Me.label5.Name = "label5"
			Me.label5.Size = New Size(144, 17)
			Me.label5.TabIndex = 8
			Me.label5.Text = "Generations / Sec:"
			' 
			' lblElapsedTime
			' 
			Me.lblElapsedTime.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
			Me.lblElapsedTime.AutoSize = True
			Me.lblElapsedTime.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, (CByte(0)))
			Me.lblElapsedTime.Location = New Point(601, 9)
			Me.lblElapsedTime.Name = "lblElapsedTime"
			Me.lblElapsedTime.Size = New Size(13, 17)
			Me.lblElapsedTime.TabIndex = 7
			Me.lblElapsedTime.Text = "-"
			' 
			' label4
			' 
			Me.label4.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
			Me.label4.AutoSize = True
			Me.label4.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(0)))
			Me.label4.Location = New Point(454, 9)
			Me.label4.Name = "label4"
			Me.label4.Size = New Size(48, 17)
			Me.label4.TabIndex = 6
			Me.label4.Text = "Time:"
			' 
			' lblGenerations
			' 
			Me.lblGenerations.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
			Me.lblGenerations.AutoSize = True
			Me.lblGenerations.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, (CByte(0)))
			Me.lblGenerations.Location = New Point(601, 29)
			Me.lblGenerations.Name = "lblGenerations"
			Me.lblGenerations.Size = New Size(13, 17)
			Me.lblGenerations.TabIndex = 5
			Me.lblGenerations.Text = "-"
			' 
			' label2
			' 
			Me.label2.Anchor = (CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles))
			Me.label2.AutoSize = True
			Me.label2.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, (CByte(0)))
			Me.label2.Location = New Point(454, 29)
			Me.label2.Name = "label2"
			Me.label2.Size = New Size(102, 17)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Generations:"
			' 
			' splitContainer2
			' 
			Me.splitContainer2.Anchor = (CType((((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles))
			Me.splitContainer2.Location = New Point(2, 68)
			Me.splitContainer2.Name = "splitContainer2"
			' 
			' splitContainer2.Panel1
			' 
			Me.splitContainer2.Panel1.Controls.Add(Me.txtBestMatch)
			' 
			' splitContainer2.Panel2
			' 
			Me.splitContainer2.Panel2.Controls.Add(Me.txtTarget)
			Me.splitContainer2.Size = New Size(666, 321)
			Me.splitContainer2.SplitterDistance = 325
			Me.splitContainer2.TabIndex = 3
			' 
			' txtBestMatch
			' 
			Me.txtBestMatch.Dock = DockStyle.Fill
			Me.txtBestMatch.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, (CByte(0)))
			Me.txtBestMatch.Location = New Point(0, 0)
			Me.txtBestMatch.Multiline = True
			Me.txtBestMatch.Name = "txtBestMatch"
			Me.txtBestMatch.Size = New Size(325, 321)
			Me.txtBestMatch.TabIndex = 3
			' 
			' txtTarget
			' 
			Me.txtTarget.Dock = DockStyle.Fill
			Me.txtTarget.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, (CByte(0)))
			Me.txtTarget.Location = New Point(0, 0)
			Me.txtTarget.Multiline = True
			Me.txtTarget.Name = "txtTarget"
			Me.txtTarget.Size = New Size(337, 321)
			Me.txtTarget.TabIndex = 0
			' 
			' btnRun
			' 
			Me.btnRun.Font = New Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, (CByte(0)))
			Me.btnRun.Location = New Point(17, 39)
			Me.btnRun.Name = "btnRun"
			Me.btnRun.Size = New Size(83, 26)
			Me.btnRun.TabIndex = 2
			Me.btnRun.Text = "Start"
			Me.btnRun.UseVisualStyleBackColor = True
'			Me.btnRun.Click += New System.EventHandler(Me.btnRun_Click)
			' 
			' txtMonkeysPerGeneration
			' 
			Me.txtMonkeysPerGeneration.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, (CByte(0)))
			Me.txtMonkeysPerGeneration.Location = New Point(225, 12)
			Me.txtMonkeysPerGeneration.Name = "txtMonkeysPerGeneration"
			Me.txtMonkeysPerGeneration.Size = New Size(50, 26)
			Me.txtMonkeysPerGeneration.TabIndex = 1
			Me.txtMonkeysPerGeneration.Text = "2000"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, (CByte(0)))
			Me.label1.Location = New Point(13, 13)
			Me.label1.Name = "label1"
			Me.label1.Size = New Size(206, 20)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Monkeys Per Generation"
			' 
			' timerElapsedTime
			' 
			Me.timerElapsedTime.Interval = 1000
'			Me.timerElapsedTime.Tick += New System.EventHandler(Me.timerElapsedTime_Tick)
			' 
			' chkParallel
			' 
			Me.chkParallel.AutoSize = True
			Me.chkParallel.Location = New Point(106, 45)
			Me.chkParallel.Name = "chkParallel"
			Me.chkParallel.Size = New Size(60, 17)
			Me.chkParallel.TabIndex = 10
			Me.chkParallel.Text = "Parallel"
			Me.chkParallel.UseVisualStyleBackColor = True
			' 
			' pictureBox1
			' 
			Me.pictureBox1.BackColor = Color.Transparent
			Me.pictureBox1.Dock = DockStyle.Fill
			Me.pictureBox1.Image = My.Resources.HamletMonkey
			Me.pictureBox1.Location = New Point(0, 0)
			Me.pictureBox1.Name = "pictureBox1"
			Me.pictureBox1.Size = New Size(301, 389)
			Me.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom
			Me.pictureBox1.TabIndex = 0
			Me.pictureBox1.TabStop = False
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.BackColor = Color.White
			Me.ClientSize = New Size(973, 389)
			Me.Controls.Add(Me.splitContainer1)
			Me.Name = "MainForm"
			Me.Text = "Shakespearean Monkeys"
			Me.splitContainer1.Panel1.ResumeLayout(False)
			Me.splitContainer1.Panel2.ResumeLayout(False)
			Me.splitContainer1.Panel2.PerformLayout()
			CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.splitContainer1.ResumeLayout(False)
			Me.splitContainer2.Panel1.ResumeLayout(False)
			Me.splitContainer2.Panel1.PerformLayout()
			Me.splitContainer2.Panel2.ResumeLayout(False)
			Me.splitContainer2.Panel2.PerformLayout()
			CType(Me.splitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.splitContainer2.ResumeLayout(False)
			CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

        Private pictureBox1 As PictureBox
		Private splitContainer1 As SplitContainer
		Private label1 As Label
		Private txtMonkeysPerGeneration As TextBox
		Private WithEvents btnRun As Button
		Private splitContainer2 As SplitContainer
		Private txtBestMatch As TextBox
		Private txtTarget As TextBox
		Private lblElapsedTime As Label
		Private label4 As Label
		Private lblGenerations As Label
		Private label2 As Label
		Private WithEvents timerElapsedTime As Timer
		Private lblGenPerSec As Label
		Private label5 As Label
		Private chkParallel As CheckBox
	End Class
End Namespace

