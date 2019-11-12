<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkflowHostForm
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
        Me.NewGame = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumberRange = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.WorkflowType = New System.Windows.Forms.ComboBox()
        Me.WorkflowVersion = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.WorkflowStatus = New System.Windows.Forms.TextBox()
        Me.QuitGame = New System.Windows.Forms.Button()
        Me.EnterGuess = New System.Windows.Forms.Button()
        Me.Guess = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.InstanceId = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NewGame
        '
        Me.NewGame.Location = New System.Drawing.Point(13, 13)
        Me.NewGame.Name = "NewGame"
        Me.NewGame.Size = New System.Drawing.Size(75, 23)
        Me.NewGame.TabIndex = 0
        Me.NewGame.Text = "New Game"
        Me.NewGame.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(94, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Guess a number from 1 to"
        '
        'NumberRange
        '
        Me.NumberRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NumberRange.FormattingEnabled = True
        Me.NumberRange.Items.AddRange(New Object() {"10", "100", "1000"})
        Me.NumberRange.Location = New System.Drawing.Point(228, 12)
        Me.NumberRange.Name = "NumberRange"
        Me.NumberRange.Size = New System.Drawing.Size(143, 21)
        Me.NumberRange.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Workflow type"
        '
        'WorkflowType
        '
        Me.WorkflowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WorkflowType.FormattingEnabled = True
        Me.WorkflowType.Items.AddRange(New Object() {"StateMachineNumberGuessWorkflow", "FlowchartNumberGuessWorkflow", "SequentialNumberGuessWorkflow", "StateMachineNumberGuessWorkflow v1", "FlowchartNumberGuessWorkflow v1", "SequentialNumberGuessWorkflow v1"})
        Me.WorkflowType.Location = New System.Drawing.Point(94, 40)
        Me.WorkflowType.Name = "WorkflowType"
        Me.WorkflowType.Size = New System.Drawing.Size(277, 21)
        Me.WorkflowType.TabIndex = 4
        '
        'WorkflowVersion
        '
        Me.WorkflowVersion.AutoSize = True
        Me.WorkflowVersion.Location = New System.Drawing.Point(13, 362)
        Me.WorkflowVersion.Name = "WorkflowVersion"
        Me.WorkflowVersion.Size = New System.Drawing.Size(89, 13)
        Me.WorkflowVersion.TabIndex = 5
        Me.WorkflowVersion.Text = "Workflow version"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.WorkflowStatus)
        Me.GroupBox1.Controls.Add(Me.QuitGame)
        Me.GroupBox1.Controls.Add(Me.EnterGuess)
        Me.GroupBox1.Controls.Add(Me.Guess)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.InstanceId)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(358, 287)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Game"
        '
        'WorkflowStatus
        '
        Me.WorkflowStatus.Location = New System.Drawing.Point(10, 73)
        Me.WorkflowStatus.Multiline = True
        Me.WorkflowStatus.Name = "WorkflowStatus"
        Me.WorkflowStatus.ReadOnly = True
        Me.WorkflowStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.WorkflowStatus.Size = New System.Drawing.Size(338, 208)
        Me.WorkflowStatus.TabIndex = 6
        '
        'QuitGame
        '
        Me.QuitGame.Location = New System.Drawing.Point(274, 42)
        Me.QuitGame.Name = "QuitGame"
        Me.QuitGame.Size = New System.Drawing.Size(75, 23)
        Me.QuitGame.TabIndex = 5
        Me.QuitGame.Text = "Quit"
        Me.QuitGame.UseVisualStyleBackColor = True
        '
        'EnterGuess
        '
        Me.EnterGuess.Location = New System.Drawing.Point(121, 42)
        Me.EnterGuess.Name = "EnterGuess"
        Me.EnterGuess.Size = New System.Drawing.Size(75, 23)
        Me.EnterGuess.TabIndex = 4
        Me.EnterGuess.Text = "Enter Guess"
        Me.EnterGuess.UseVisualStyleBackColor = True
        '
        'Guess
        '
        Me.Guess.Location = New System.Drawing.Point(50, 44)
        Me.Guess.Name = "Guess"
        Me.Guess.Size = New System.Drawing.Size(65, 20)
        Me.Guess.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Guess"
        '
        'InstanceId
        '
        Me.InstanceId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.InstanceId.FormattingEnabled = True
        Me.InstanceId.Location = New System.Drawing.Point(121, 17)
        Me.InstanceId.Name = "InstanceId"
        Me.InstanceId.Size = New System.Drawing.Size(227, 21)
        Me.InstanceId.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Workflow Instance Id"
        '
        'WorkflowHostForm
        '
        Me.AcceptButton = Me.EnterGuess
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 382)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.WorkflowVersion)
        Me.Controls.Add(Me.WorkflowType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumberRange)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NewGame)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "WorkflowHostForm"
        Me.Text = "WorkflowHostForm"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NewGame As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumberRange As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents WorkflowType As System.Windows.Forms.ComboBox
    Friend WithEvents WorkflowVersion As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents WorkflowStatus As System.Windows.Forms.TextBox
    Friend WithEvents QuitGame As System.Windows.Forms.Button
    Friend WithEvents EnterGuess As System.Windows.Forms.Button
    Friend WithEvents Guess As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents InstanceId As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
