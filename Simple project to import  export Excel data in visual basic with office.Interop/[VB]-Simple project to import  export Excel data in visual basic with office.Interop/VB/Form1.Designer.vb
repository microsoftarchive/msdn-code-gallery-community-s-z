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
        Me.BtnReadExcel = New System.Windows.Forms.Button
        Me.PnlButtons = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtTotalColumns = New System.Windows.Forms.TextBox
        Me.PnlDGV = New System.Windows.Forms.Panel
        Me.BtnWriteExcel = New System.Windows.Forms.Button
        Me.PnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnReadExcel
        '
        Me.BtnReadExcel.Location = New System.Drawing.Point(8, 3)
        Me.BtnReadExcel.Name = "BtnReadExcel"
        Me.BtnReadExcel.Size = New System.Drawing.Size(127, 47)
        Me.BtnReadExcel.TabIndex = 0
        Me.BtnReadExcel.Text = "Read Excel file"
        Me.BtnReadExcel.UseVisualStyleBackColor = True
        '
        'PnlButtons
        '
        Me.PnlButtons.Controls.Add(Me.BtnWriteExcel)
        Me.PnlButtons.Controls.Add(Me.Label1)
        Me.PnlButtons.Controls.Add(Me.TxtTotalColumns)
        Me.PnlButtons.Controls.Add(Me.BtnReadExcel)
        Me.PnlButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlButtons.Location = New System.Drawing.Point(0, 0)
        Me.PnlButtons.Name = "PnlButtons"
        Me.PnlButtons.Size = New System.Drawing.Size(691, 53)
        Me.PnlButtons.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(175, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Total columns in file"
        '
        'TxtTotalColumns
        '
        Me.TxtTotalColumns.Location = New System.Drawing.Point(150, 27)
        Me.TxtTotalColumns.Name = "TxtTotalColumns"
        Me.TxtTotalColumns.Size = New System.Drawing.Size(158, 20)
        Me.TxtTotalColumns.TabIndex = 0
        '
        'PnlDGV
        '
        Me.PnlDGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDGV.Location = New System.Drawing.Point(0, 53)
        Me.PnlDGV.Name = "PnlDGV"
        Me.PnlDGV.Size = New System.Drawing.Size(691, 455)
        Me.PnlDGV.TabIndex = 2
        '
        'BtnWriteExcel
        '
        Me.BtnWriteExcel.Location = New System.Drawing.Point(361, 3)
        Me.BtnWriteExcel.Name = "BtnWriteExcel"
        Me.BtnWriteExcel.Size = New System.Drawing.Size(127, 47)
        Me.BtnWriteExcel.TabIndex = 3
        Me.BtnWriteExcel.Text = "Write to Excel file"
        Me.BtnWriteExcel.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 508)
        Me.Controls.Add(Me.PnlDGV)
        Me.Controls.Add(Me.PnlButtons)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.PnlButtons.ResumeLayout(False)
        Me.PnlButtons.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnReadExcel As System.Windows.Forms.Button
    Friend WithEvents PnlButtons As System.Windows.Forms.Panel
    Friend WithEvents PnlDGV As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalColumns As System.Windows.Forms.TextBox
    Friend WithEvents BtnWriteExcel As System.Windows.Forms.Button

End Class
