<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblNumProcs = New System.Windows.Forms.Label()
        Me.tbNumProcs = New System.Windows.Forms.TrackBar()
        Me.chkShowThreads = New System.Windows.Forms.CheckBox()
        Me.chkParallel = New System.Windows.Forms.CheckBox()
        Me.btnStartStop = New System.Windows.Forms.Button()
        Me.pbRenderedImage = New System.Windows.Forms.PictureBox()
        CType(Me.tbNumProcs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbRenderedImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNumProcs
        '
        Me.lblNumProcs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNumProcs.AutoSize = True
        Me.lblNumProcs.Enabled = False
        Me.lblNumProcs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumProcs.Location = New System.Drawing.Point(294, 428)
        Me.lblNumProcs.Name = "lblNumProcs"
        Me.lblNumProcs.Size = New System.Drawing.Size(14, 13)
        Me.lblNumProcs.TabIndex = 29
        Me.lblNumProcs.Text = "1"
        '
        'tbNumProcs
        '
        Me.tbNumProcs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNumProcs.Enabled = False
        Me.tbNumProcs.Location = New System.Drawing.Point(303, 418)
        Me.tbNumProcs.Maximum = 24
        Me.tbNumProcs.Minimum = 1
        Me.tbNumProcs.Name = "tbNumProcs"
        Me.tbNumProcs.Size = New System.Drawing.Size(178, 45)
        Me.tbNumProcs.TabIndex = 28
        Me.tbNumProcs.Value = 1
        '
        'chkShowThreads
        '
        Me.chkShowThreads.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkShowThreads.AutoSize = True
        Me.chkShowThreads.Enabled = False
        Me.chkShowThreads.Location = New System.Drawing.Point(173, 423)
        Me.chkShowThreads.Name = "chkShowThreads"
        Me.chkShowThreads.Size = New System.Drawing.Size(95, 17)
        Me.chkShowThreads.TabIndex = 27
        Me.chkShowThreads.Text = "Show Threads"
        Me.chkShowThreads.UseVisualStyleBackColor = True
        '
        'chkParallel
        '
        Me.chkParallel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkParallel.AutoSize = True
        Me.chkParallel.Location = New System.Drawing.Point(107, 423)
        Me.chkParallel.Name = "chkParallel"
        Me.chkParallel.Size = New System.Drawing.Size(60, 17)
        Me.chkParallel.TabIndex = 26
        Me.chkParallel.Text = "Parallel"
        Me.chkParallel.UseVisualStyleBackColor = True
        '
        'btnStartStop
        '
        Me.btnStartStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnStartStop.Location = New System.Drawing.Point(12, 418)
        Me.btnStartStop.Name = "btnStartStop"
        Me.btnStartStop.Size = New System.Drawing.Size(88, 23)
        Me.btnStartStop.TabIndex = 25
        Me.btnStartStop.Text = "Start"
        Me.btnStartStop.UseVisualStyleBackColor = True
        '
        'pbRenderedImage
        '
        Me.pbRenderedImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbRenderedImage.BackColor = System.Drawing.Color.Black
        Me.pbRenderedImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pbRenderedImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbRenderedImage.Location = New System.Drawing.Point(12, 12)
        Me.pbRenderedImage.Name = "pbRenderedImage"
        Me.pbRenderedImage.Size = New System.Drawing.Size(469, 400)
        Me.pbRenderedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbRenderedImage.TabIndex = 24
        Me.pbRenderedImage.TabStop = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 459)
        Me.Controls.Add(Me.lblNumProcs)
        Me.Controls.Add(Me.tbNumProcs)
        Me.Controls.Add(Me.chkShowThreads)
        Me.Controls.Add(Me.chkParallel)
        Me.Controls.Add(Me.btnStartStop)
        Me.Controls.Add(Me.pbRenderedImage)
        Me.Name = "Main"
        Me.Text = "Ray Tracer"
        CType(Me.tbNumProcs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbRenderedImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblNumProcs As System.Windows.Forms.Label
    Private WithEvents tbNumProcs As System.Windows.Forms.TrackBar
    Friend WithEvents chkShowThreads As System.Windows.Forms.CheckBox
    Friend WithEvents chkParallel As System.Windows.Forms.CheckBox
    Private WithEvents btnStartStop As System.Windows.Forms.Button
    Private WithEvents pbRenderedImage As System.Windows.Forms.PictureBox
End Class
