Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
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
            Me.bwColorize = New System.ComponentModel.BackgroundWorker()
            Me.tmRefresh = New Timer(Me.components)
            Me.toolStripContainer = New ToolStripContainer()
            Me.pbImage = New PictureBox()
            Me.toolStripMain = New ToolStrip()
            Me.btnLoadImage = New ToolStripButton()
            Me.btnSaveImage = New ToolStripButton()
            Me.separator1 = New ToolStripSeparator()
            Me.tbEpsilon = New Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.ToolStripTrackBar()
            Me.separator2 = New ToolStripSeparator()
            Me.btnParallel = New ToolStripButton()
            Me.btnInk = New ToolStripButton()
            Me.btnEraser = New ToolStripButton()
            Me.pbColorizing = New ToolStripProgressBar()
            Me.lblHuesSelected = New ToolStripLabel()
            Me.toolStripContainer.ContentPanel.SuspendLayout()
            Me.toolStripContainer.TopToolStripPanel.SuspendLayout()
            Me.toolStripContainer.SuspendLayout()
            CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.toolStripMain.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' bwColorize
            ' 
            Me.bwColorize.WorkerReportsProgress = True
            ' Me.bwColorize.DoWork += New System.ComponentModel.DoWorkEventHandler(Me.bwColorize_DoWork)
            ' Me.bwColorize.RunWorkerCompleted += New System.ComponentModel.RunWorkerCompletedEventHandler(Me.bwColorize_RunWorkerCompleted)
            ' Me.bwColorize.ProgressChanged += New System.ComponentModel.ProgressChangedEventHandler(Me.bwColorize_ProgressChanged)
            ' 
            ' tmRefresh
            ' 
            Me.tmRefresh.Interval = 1000
            '			Me.tmRefresh.Tick += New System.EventHandler(Me.tmRefresh_Tick)
            ' 
            ' toolStripContainer
            ' 
            ' 
            ' toolStripContainer.ContentPanel
            ' 
            Me.toolStripContainer.ContentPanel.Controls.Add(Me.pbImage)
            Me.toolStripContainer.ContentPanel.Size = New Size(619, 397)
            Me.toolStripContainer.Dock = DockStyle.Fill
            Me.toolStripContainer.Location = New Point(0, 0)
            Me.toolStripContainer.Name = "toolStripContainer"
            Me.toolStripContainer.Size = New Size(619, 422)
            Me.toolStripContainer.TabIndex = 10
            Me.toolStripContainer.Text = "toolStripContainer1"
            ' 
            ' toolStripContainer.TopToolStripPanel
            ' 
            Me.toolStripContainer.TopToolStripPanel.Controls.Add(Me.toolStripMain)
            ' 
            ' pbImage
            ' 
            Me.pbImage.Anchor = (CType((((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles))
            Me.pbImage.BorderStyle = BorderStyle.Fixed3D
            Me.pbImage.Cursor = Cursors.Default
            Me.pbImage.Location = New Point(3, 3)
            Me.pbImage.Name = "pbImage"
            Me.pbImage.Size = New Size(613, 391)
            Me.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
            Me.pbImage.TabIndex = 10
            Me.pbImage.TabStop = False
            ' Me.pbImage.DragDrop += New System.Windows.Forms.DragEventHandler(Me.pbImage_DragDrop)
            ' Me.pbImage.Resize += New System.EventHandler(Me.pbImage_Resize)
            ' Me.pbImage.MouseClick += New System.Windows.Forms.MouseEventHandler(Me.pbImage_MouseClick)
            ' Me.pbImage.DragEnter += New System.Windows.Forms.DragEventHandler(Me.pbImage_DragEnter)
            ' 
            ' toolStripMain
            ' 
            Me.toolStripMain.AllowItemReorder = True
            Me.toolStripMain.Dock = DockStyle.None
            Me.toolStripMain.Items.AddRange(New ToolStripItem() {Me.btnLoadImage, Me.btnSaveImage, Me.separator1, Me.tbEpsilon, Me.separator2, Me.btnParallel, _
                                                                 Me.btnInk, Me.btnEraser, Me.pbColorizing, Me.lblHuesSelected})
            Me.toolStripMain.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow
            Me.toolStripMain.Location = New Point(3, 0)
            Me.toolStripMain.Name = "toolStripMain"
            Me.toolStripMain.Size = New Size(616, 25)
            Me.toolStripMain.TabIndex = 9
            Me.toolStripMain.Text = "toolStrip1"
            ' 
            ' btnLoadImage
            ' 
            Me.btnLoadImage.Image = My.Resources.InsertPictureHS
            Me.btnLoadImage.ImageTransparentColor = Color.Magenta
            Me.btnLoadImage.Name = "btnLoadImage"
            Me.btnLoadImage.Size = New Size(89, 22)
            Me.btnLoadImage.Text = "&Load Image"
            ' Me.btnLoadImage.Click += New System.EventHandler(Me.btnLoadImage_Click)
            '
            ' btnSaveImage
            ' 
            Me.btnSaveImage.Image = My.Resources.saveHS
            Me.btnSaveImage.ImageTransparentColor = Color.Magenta
            Me.btnSaveImage.Name = "btnSaveImage"
            Me.btnSaveImage.Size = New Size(87, 22)
            Me.btnSaveImage.Text = "&Save Image"
            ' Me.btnSaveImage.Click += New System.EventHandler(Me.btnSaveImage_Click)
            ' 
            ' separator1
            ' 
            Me.separator1.Name = "separator1"
            Me.separator1.Size = New Size(6, 25)
            ' 
            ' tbEpsilon
            ' 
            Me.tbEpsilon.BackColor = SystemColors.Control
            Me.tbEpsilon.Maximum = 180
            Me.tbEpsilon.Name = "tbEpsilon"
            Me.tbEpsilon.Size = New Size(150, 22)
            Me.tbEpsilon.Text = "toolStripTrackBar1"
            Me.tbEpsilon.Value = 15
            ' Me.tbEpsilon.ValueChanged += New System.EventHandler(Me.tbEpsilon_ValueChanged)
            ' 
            ' separator2
            ' 
            Me.separator2.Name = "separator2"
            Me.separator2.Size = New Size(6, 25)
            ' 
            ' btnParallel
            ' 
            Me.btnParallel.CheckOnClick = True
            Me.btnParallel.DisplayStyle = ToolStripItemDisplayStyle.Image
            Me.btnParallel.Image = (CType(resources.GetObject("btnParallel.Image"), Image))
            Me.btnParallel.ImageTransparentColor = Color.Magenta
            Me.btnParallel.Name = "btnParallel"
            Me.btnParallel.Size = New Size(23, 22)
            Me.btnParallel.Text = "btnParallel"
            ' Me.btnParallel.CheckedChanged += New System.EventHandler(Me.btnParallel_CheckedChanged)
            ' 
            ' btnInk
            ' 
            Me.btnInk.DisplayStyle = ToolStripItemDisplayStyle.Image
            Me.btnInk.Enabled = False
            Me.btnInk.Image = My.Resources.pen
            Me.btnInk.ImageTransparentColor = Color.Magenta
            Me.btnInk.Name = "btnInk"
            Me.btnInk.Size = New Size(23, 22)
            Me.btnInk.Text = "btnInk"
            ' Me.btnInk.Click += New System.EventHandler(Me.btnInk_Click)
            ' 
            ' btnEraser
            ' 
            Me.btnEraser.DisplayStyle = ToolStripItemDisplayStyle.Image
            Me.btnEraser.Enabled = False
            Me.btnEraser.Image = My.Resources.eraser
            Me.btnEraser.ImageTransparentColor = Color.Magenta
            Me.btnEraser.Name = "btnEraser"
            Me.btnEraser.Size = New Size(23, 22)
            Me.btnEraser.Text = "btnEraser"
            ' Me.btnEraser.Click += New System.EventHandler(Me.btnEraser_Click)
            ' 
            ' pbColorizing
            ' 
            Me.pbColorizing.Alignment = ToolStripItemAlignment.Right
            Me.pbColorizing.Name = "pbColorizing"
            Me.pbColorizing.Overflow = ToolStripItemOverflow.Never
            Me.pbColorizing.Size = New Size(140, 22)
            Me.pbColorizing.Visible = False
            ' 
            ' lblHuesSelected
            ' 
            Me.lblHuesSelected.Name = "lblHuesSelected"
            Me.lblHuesSelected.Size = New Size(81, 15)
            Me.lblHuesSelected.Text = "Hues Selected"
            ' Me.lblHuesSelected.Click += New System.EventHandler(Me.lblHuesSelected_Click)
            ' 
            ' MainForm
            ' 
            Me.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.ClientSize = New Size(619, 422)
            Me.Controls.Add(Me.toolStripContainer)
            Me.Icon = (CType(resources.GetObject("$this.Icon"), Icon))
            Me.KeyPreview = True
            Me.Name = "MainForm"
            Me.Text = "Image Colorizer"
            ' Me.Load += New System.EventHandler(Me.MainForm_Load)
            Me.toolStripContainer.ContentPanel.ResumeLayout(False)
            Me.toolStripContainer.TopToolStripPanel.ResumeLayout(False)
            Me.toolStripContainer.TopToolStripPanel.PerformLayout()
            Me.toolStripContainer.ResumeLayout(False)
            Me.toolStripContainer.PerformLayout()
            CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
            Me.toolStripMain.ResumeLayout(False)
            Me.toolStripMain.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private WithEvents bwColorize As System.ComponentModel.BackgroundWorker
        Private WithEvents tmRefresh As Timer
        Private toolStripContainer As ToolStripContainer
        Private WithEvents pbImage As PictureBox
        Private toolStripMain As ToolStrip
        Private WithEvents btnLoadImage As ToolStripButton
        Private WithEvents btnSaveImage As ToolStripButton
        Private separator1 As ToolStripSeparator
        Private WithEvents tbEpsilon As ToolStripTrackBar
        Private separator2 As ToolStripSeparator
        Private WithEvents btnInk As ToolStripButton
        Private WithEvents btnEraser As ToolStripButton
        Private pbColorizing As ToolStripProgressBar
        Private WithEvents lblHuesSelected As ToolStripLabel
        Private WithEvents btnParallel As ToolStripButton
    End Class
End Namespace

