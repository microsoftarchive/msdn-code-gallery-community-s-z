<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.cbNumQueens = New System.Windows.Forms.ComboBox()
        Me.progressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnSolve = New System.Windows.Forms.Button()
        Me.chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbNumQueens
        '
        Me.cbNumQueens.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbNumQueens.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbNumQueens.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNumQueens.FormattingEnabled = True
        Me.cbNumQueens.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "13", "14", "15"})
        Me.cbNumQueens.Location = New System.Drawing.Point(13, 14)
        Me.cbNumQueens.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbNumQueens.Name = "cbNumQueens"
        Me.cbNumQueens.Size = New System.Drawing.Size(56, 32)
        Me.cbNumQueens.TabIndex = 10
        Me.cbNumQueens.Text = "12"
        '
        'progressBar1
        '
        Me.progressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progressBar1.Location = New System.Drawing.Point(198, 14)
        Me.progressBar1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(529, 35)
        Me.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.progressBar1.TabIndex = 9
        Me.progressBar1.Visible = False
        '
        'btnSolve
        '
        Me.btnSolve.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSolve.Location = New System.Drawing.Point(78, 14)
        Me.btnSolve.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSolve.Name = "btnSolve"
        Me.btnSolve.Size = New System.Drawing.Size(112, 35)
        Me.btnSolve.TabIndex = 8
        Me.btnSolve.Text = "Solve"
        Me.btnSolve.UseVisualStyleBackColor = True
        '
        'chart1
        '
        Me.chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chart1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter
        ChartArea3.AxisX.IsLabelAutoFit = False
        ChartArea3.AxisX.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        ChartArea3.AxisY.IsLabelAutoFit = False
        ChartArea3.AxisY.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        ChartArea3.AxisY.LabelStyle.Format = "F2"
        ChartArea3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        ChartArea3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft
        ChartArea3.BackSecondaryColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        ChartArea3.Name = "ChartArea1"
        Me.chart1.ChartAreas.Add(ChartArea3)
        Me.chart1.Location = New System.Drawing.Point(13, 56)
        Me.chart1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chart1.Name = "chart1"
        Me.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None
        Series3.BackSecondaryColor = System.Drawing.Color.MintCream
        Series3.ChartArea = "ChartArea1"
        Series3.CustomProperties = "DrawingStyle=Cylinder, LabelStyle=Top"
        Series3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Series3.Name = "chartSeries1"
        Series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[String]
        Series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Double]
        Me.chart1.Series.Add(Series3)
        Me.chart1.Size = New System.Drawing.Size(714, 420)
        Me.chart1.TabIndex = 7
        Me.chart1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 490)
        Me.Controls.Add(Me.cbNumQueens)
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.btnSolve)
        Me.Controls.Add(Me.chart1)
        Me.Name = "MainForm"
        Me.Text = "NQueens"
        CType(Me.chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents cbNumQueens As System.Windows.Forms.ComboBox
    Private WithEvents progressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents btnSolve As System.Windows.Forms.Button
    Private WithEvents chart1 As System.Windows.Forms.DataVisualization.Charting.Chart

End Class
