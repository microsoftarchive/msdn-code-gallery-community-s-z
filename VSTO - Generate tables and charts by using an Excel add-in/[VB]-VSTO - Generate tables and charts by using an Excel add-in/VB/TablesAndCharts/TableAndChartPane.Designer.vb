<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TableAndChartPane
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.chartDataSourceComboBox = New System.Windows.Forms.ComboBox()
        Me.ChartStyleComboBox = New System.Windows.Forms.ComboBox()
        Me.ChartColorThemeComboBox = New System.Windows.Forms.ComboBox()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.ListObjectHeaders = New System.Windows.Forms.CheckedListBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.dateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.GreenStyle = New System.Windows.Forms.RadioButton()
        Me.GrayStyle = New System.Windows.Forms.RadioButton()
        Me.OrangeStyle = New System.Windows.Forms.RadioButton()
        Me.BlueStyle = New System.Windows.Forms.RadioButton()
        Me.BlackStyle = New System.Windows.Forms.RadioButton()
        Me.ListObjectCheckBox = New System.Windows.Forms.CheckBox()
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.label4)
        Me.groupBox3.Controls.Add(Me.label3)
        Me.groupBox3.Controls.Add(Me.label2)
        Me.groupBox3.Controls.Add(Me.chartDataSourceComboBox)
        Me.groupBox3.Controls.Add(Me.ChartStyleComboBox)
        Me.groupBox3.Controls.Add(Me.ChartColorThemeComboBox)
        Me.groupBox3.Enabled = False
        Me.groupBox3.Location = New System.Drawing.Point(8, 428)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(200, 195)
        Me.groupBox3.TabIndex = 27
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Change chart settings"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(15, 128)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(63, 13)
        Me.label4.TabIndex = 19
        Me.label4.Text = "Color theme"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(15, 73)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(30, 13)
        Me.label3.TabIndex = 18
        Me.label3.Text = "Style"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(15, 20)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(65, 13)
        Me.label2.TabIndex = 17
        Me.label2.Text = "Data source"
        '
        'chartDataSourceComboBox
        '
        Me.chartDataSourceComboBox.FormattingEnabled = True
        Me.chartDataSourceComboBox.Location = New System.Drawing.Point(15, 44)
        Me.chartDataSourceComboBox.Name = "chartDataSourceComboBox"
        Me.chartDataSourceComboBox.Size = New System.Drawing.Size(121, 21)
        Me.chartDataSourceComboBox.TabIndex = 14
        Me.chartDataSourceComboBox.Text = "Close"
        '
        'ChartStyleComboBox
        '
        Me.ChartStyleComboBox.FormattingEnabled = True
        Me.ChartStyleComboBox.Location = New System.Drawing.Point(15, 96)
        Me.ChartStyleComboBox.Name = "ChartStyleComboBox"
        Me.ChartStyleComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ChartStyleComboBox.TabIndex = 15
        Me.ChartStyleComboBox.Text = "Line"
        '
        'ChartColorThemeComboBox
        '
        Me.ChartColorThemeComboBox.FormattingEnabled = True
        Me.ChartColorThemeComboBox.Location = New System.Drawing.Point(15, 154)
        Me.ChartColorThemeComboBox.Name = "ChartColorThemeComboBox"
        Me.ChartColorThemeComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ChartColorThemeComboBox.TabIndex = 16
        Me.ChartColorThemeComboBox.Text = "White background"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.ListObjectHeaders)
        Me.groupBox2.Enabled = False
        Me.groupBox2.Location = New System.Drawing.Point(8, 117)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(200, 177)
        Me.groupBox2.TabIndex = 26
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Show / hide table columns"
        '
        'ListObjectHeaders
        '
        Me.ListObjectHeaders.CheckOnClick = True
        Me.ListObjectHeaders.FormattingEnabled = True
        Me.ListObjectHeaders.Location = New System.Drawing.Point(15, 31)
        Me.ListObjectHeaders.Name = "ListObjectHeaders"
        Me.ListObjectHeaders.Size = New System.Drawing.Size(166, 139)
        Me.ListObjectHeaders.TabIndex = 11
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(5, 3)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(108, 13)
        Me.label1.TabIndex = 25
        Me.label1.Text = "Choose Starting Date"
        '
        'dateTimePicker1
        '
        Me.dateTimePicker1.Location = New System.Drawing.Point(3, 29)
        Me.dateTimePicker1.Name = "dateTimePicker1"
        Me.dateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.dateTimePicker1.TabIndex = 24
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.GreenStyle)
        Me.groupBox1.Controls.Add(Me.GrayStyle)
        Me.groupBox1.Controls.Add(Me.OrangeStyle)
        Me.groupBox1.Controls.Add(Me.BlueStyle)
        Me.groupBox1.Controls.Add(Me.BlackStyle)
        Me.groupBox1.Enabled = False
        Me.groupBox1.Location = New System.Drawing.Point(8, 311)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(200, 100)
        Me.groupBox1.TabIndex = 23
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Change the table color theme"
        '
        'GreenStyle
        '
        Me.GreenStyle.AutoSize = True
        Me.GreenStyle.Location = New System.Drawing.Point(98, 44)
        Me.GreenStyle.Name = "GreenStyle"
        Me.GreenStyle.Size = New System.Drawing.Size(54, 17)
        Me.GreenStyle.TabIndex = 4
        Me.GreenStyle.TabStop = True
        Me.GreenStyle.Text = "Green"
        Me.GreenStyle.UseVisualStyleBackColor = True
        '
        'GrayStyle
        '
        Me.GrayStyle.AutoSize = True
        Me.GrayStyle.Location = New System.Drawing.Point(98, 20)
        Me.GrayStyle.Name = "GrayStyle"
        Me.GrayStyle.Size = New System.Drawing.Size(47, 17)
        Me.GrayStyle.TabIndex = 3
        Me.GrayStyle.TabStop = True
        Me.GrayStyle.Text = "Gray"
        Me.GrayStyle.UseVisualStyleBackColor = True
        '
        'OrangeStyle
        '
        Me.OrangeStyle.AutoSize = True
        Me.OrangeStyle.Location = New System.Drawing.Point(7, 68)
        Me.OrangeStyle.Name = "OrangeStyle"
        Me.OrangeStyle.Size = New System.Drawing.Size(60, 17)
        Me.OrangeStyle.TabIndex = 2
        Me.OrangeStyle.TabStop = True
        Me.OrangeStyle.Text = "Orange"
        Me.OrangeStyle.UseVisualStyleBackColor = True
        '
        'BlueStyle
        '
        Me.BlueStyle.AutoSize = True
        Me.BlueStyle.Location = New System.Drawing.Point(7, 44)
        Me.BlueStyle.Name = "BlueStyle"
        Me.BlueStyle.Size = New System.Drawing.Size(46, 17)
        Me.BlueStyle.TabIndex = 1
        Me.BlueStyle.TabStop = True
        Me.BlueStyle.Text = "Blue"
        Me.BlueStyle.UseVisualStyleBackColor = True
        '
        'BlackStyle
        '
        Me.BlackStyle.AutoSize = True
        Me.BlackStyle.Location = New System.Drawing.Point(7, 20)
        Me.BlackStyle.Name = "BlackStyle"
        Me.BlackStyle.Size = New System.Drawing.Size(52, 17)
        Me.BlackStyle.TabIndex = 0
        Me.BlackStyle.TabStop = True
        Me.BlackStyle.Text = "Black"
        Me.BlackStyle.UseVisualStyleBackColor = True
        '
        'ListObjectCheckBox
        '
        Me.ListObjectCheckBox.AutoSize = True
        Me.ListObjectCheckBox.Location = New System.Drawing.Point(3, 74)
        Me.ListObjectCheckBox.Name = "ListObjectCheckBox"
        Me.ListObjectCheckBox.Size = New System.Drawing.Size(205, 17)
        Me.ListObjectCheckBox.TabIndex = 22
        Me.ListObjectCheckBox.Text = "Show price history for selected symbol"
        '
        'TableAndChartPane
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.dateTimePicker1)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.ListObjectCheckBox)
        Me.Name = "TableAndChartPane"
        Me.Size = New System.Drawing.Size(245, 646)
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents chartDataSourceComboBox As System.Windows.Forms.ComboBox
    Private WithEvents ChartStyleComboBox As System.Windows.Forms.ComboBox
    Private WithEvents ChartColorThemeComboBox As System.Windows.Forms.ComboBox
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents ListObjectHeaders As System.Windows.Forms.CheckedListBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents dateTimePicker1 As System.Windows.Forms.DateTimePicker
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents GreenStyle As System.Windows.Forms.RadioButton
    Private WithEvents GrayStyle As System.Windows.Forms.RadioButton
    Private WithEvents OrangeStyle As System.Windows.Forms.RadioButton
    Private WithEvents BlueStyle As System.Windows.Forms.RadioButton
    Private WithEvents BlackStyle As System.Windows.Forms.RadioButton
    Friend WithEvents ListObjectCheckBox As System.Windows.Forms.CheckBox

End Class
