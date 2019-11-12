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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.game = New tetris.GameGrid()
        Me.ShapePreview1 = New tetris.ShapePreview()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.game, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShapePreview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'game
        '
        Me.game.AllowUserToAddRows = False
        Me.game.AllowUserToDeleteRows = False
        Me.game.AllowUserToResizeColumns = False
        Me.game.AllowUserToResizeRows = False
        Me.game.BackgroundColor = System.Drawing.Color.Black
        Me.game.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.game.ColumnHeadersVisible = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.game.DefaultCellStyle = DataGridViewCellStyle1
        Me.game.GridColor = System.Drawing.Color.Black
        Me.game.Location = New System.Drawing.Point(62, 62)
        Me.game.Name = "game"
        Me.game.RowHeadersVisible = False
        Me.game.Size = New System.Drawing.Size(303, 453)
        Me.game.TabIndex = 0
        '
        'ShapePreview1
        '
        Me.ShapePreview1.AllowUserToAddRows = False
        Me.ShapePreview1.AllowUserToDeleteRows = False
        Me.ShapePreview1.AllowUserToResizeColumns = False
        Me.ShapePreview1.AllowUserToResizeRows = False
        Me.ShapePreview1.BackgroundColor = System.Drawing.Color.Black
        Me.ShapePreview1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ShapePreview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ShapePreview1.ColumnHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ShapePreview1.DefaultCellStyle = DataGridViewCellStyle2
        Me.ShapePreview1.GridColor = System.Drawing.Color.Black
        Me.ShapePreview1.Location = New System.Drawing.Point(383, 394)
        Me.ShapePreview1.Name = "ShapePreview1"
        Me.ShapePreview1.RowHeadersVisible = False
        Me.ShapePreview1.Size = New System.Drawing.Size(91, 91)
        Me.ShapePreview1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(366, 275)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 26)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Score:"
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.ForeColor = System.Drawing.Color.Silver
        Me.lblScore.Location = New System.Drawing.Point(388, 334)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(84, 26)
        Me.lblScore.TabIndex = 3
        Me.lblScore.Text = "000000"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.ForeColor = System.Drawing.Color.Silver
        Me.Button1.Location = New System.Drawing.Point(418, 523)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "New Game"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(551, 561)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapePreview1)
        Me.Controls.Add(Me.game)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "tetris"
        CType(Me.game, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShapePreview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents game As GameGrid
    Friend WithEvents ShapePreview1 As ShapePreview
    Friend WithEvents Label1 As Label
    Friend WithEvents lblScore As Label
    Friend WithEvents Button1 As Button
End Class
