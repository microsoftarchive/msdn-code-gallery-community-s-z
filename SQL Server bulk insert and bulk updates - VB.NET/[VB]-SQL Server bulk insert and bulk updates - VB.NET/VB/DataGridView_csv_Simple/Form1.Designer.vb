<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.exportButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.FirstNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GenderColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BirthDayColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.label1 = New System.Windows.Forms.Label()
        Me.numericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.truncateCheckBox = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        CType(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'exportButton
        '
        Me.exportButton.Location = New System.Drawing.Point(12, 13)
        Me.exportButton.Name = "exportButton"
        Me.exportButton.Size = New System.Drawing.Size(75, 23)
        Me.exportButton.TabIndex = 0
        Me.exportButton.Text = "Export"
        Me.exportButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FirstNameColumn, Me.LastNameColumn, Me.GenderColumn, Me.BirthDayColumn})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(475, 214)
        Me.DataGridView1.TabIndex = 2
        '
        'FirstNameColumn
        '
        Me.FirstNameColumn.HeaderText = "First"
        Me.FirstNameColumn.Name = "FirstNameColumn"
        '
        'LastNameColumn
        '
        Me.LastNameColumn.HeaderText = "Last"
        Me.LastNameColumn.Name = "LastNameColumn"
        '
        'GenderColumn
        '
        Me.GenderColumn.HeaderText = "Gender"
        Me.GenderColumn.Name = "GenderColumn"
        '
        'BirthDayColumn
        '
        Me.BirthDayColumn.HeaderText = "Birth day"
        Me.BirthDayColumn.Name = "BirthDayColumn"
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Controls.Add(Me.numericUpDown1)
        Me.panel1.Controls.Add(Me.truncateCheckBox)
        Me.panel1.Controls.Add(Me.exportButton)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel1.Location = New System.Drawing.Point(0, 214)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(475, 48)
        Me.panel1.TabIndex = 3
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(337, 21)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(58, 13)
        Me.label1.TabIndex = 3
        Me.label1.Text = "Batch Size"
        '
        'numericUpDown1
        '
        Me.numericUpDown1.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numericUpDown1.Location = New System.Drawing.Point(253, 16)
        Me.numericUpDown1.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.numericUpDown1.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numericUpDown1.Name = "numericUpDown1"
        Me.numericUpDown1.Size = New System.Drawing.Size(78, 20)
        Me.numericUpDown1.TabIndex = 2
        Me.numericUpDown1.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'truncateCheckBox
        '
        Me.truncateCheckBox.AutoSize = True
        Me.truncateCheckBox.Checked = True
        Me.truncateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.truncateCheckBox.Location = New System.Drawing.Point(93, 17)
        Me.truncateCheckBox.Name = "truncateCheckBox"
        Me.truncateCheckBox.Size = New System.Drawing.Size(142, 17)
        Me.truncateCheckBox.TabIndex = 1
        Me.truncateCheckBox.Text = "Truncate database table"
        Me.truncateCheckBox.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 262)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents exportButton As Button
    Public WithEvents DataGridView1 As DataGridView
    Friend WithEvents FirstNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents LastNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents GenderColumn As DataGridViewTextBoxColumn
    Friend WithEvents BirthDayColumn As DataGridViewTextBoxColumn
    Private WithEvents panel1 As Panel
    Private WithEvents label1 As Label
    Private WithEvents numericUpDown1 As NumericUpDown
    Private WithEvents truncateCheckBox As CheckBox
End Class
