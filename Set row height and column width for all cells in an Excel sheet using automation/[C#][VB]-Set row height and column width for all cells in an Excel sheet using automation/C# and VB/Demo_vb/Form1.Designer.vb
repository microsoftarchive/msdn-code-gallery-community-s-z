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
        Me.setRowColumnButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDownRowHeight = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownColumn = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.NumericUpDownRowHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'setRowColumnButton
        '
        Me.setRowColumnButton.Location = New System.Drawing.Point(12, 21)
        Me.setRowColumnButton.Name = "setRowColumnButton"
        Me.setRowColumnButton.Size = New System.Drawing.Size(197, 23)
        Me.setRowColumnButton.TabIndex = 0
        Me.setRowColumnButton.Text = "Set row height and column width"
        Me.setRowColumnButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Row height"
        '
        'NumericUpDownRowHeight
        '
        Me.NumericUpDownRowHeight.Location = New System.Drawing.Point(96, 60)
        Me.NumericUpDownRowHeight.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDownRowHeight.Name = "NumericUpDownRowHeight"
        Me.NumericUpDownRowHeight.Size = New System.Drawing.Size(69, 20)
        Me.NumericUpDownRowHeight.TabIndex = 2
        Me.NumericUpDownRowHeight.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'NumericUpDownColumn
        '
        Me.NumericUpDownColumn.Location = New System.Drawing.Point(96, 95)
        Me.NumericUpDownColumn.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDownColumn.Name = "NumericUpDownColumn"
        Me.NumericUpDownColumn.Size = New System.Drawing.Size(69, 20)
        Me.NumericUpDownColumn.TabIndex = 4
        Me.NumericUpDownColumn.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Column width"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(236, 134)
        Me.Controls.Add(Me.NumericUpDownColumn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumericUpDownRowHeight)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.setRowColumnButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.NumericUpDownRowHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownColumn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents setRowColumnButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownRowHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownColumn As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
