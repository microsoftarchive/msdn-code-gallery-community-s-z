Partial Class frmLogin
	''' <summary>
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary>
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(disposing As Boolean)
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
		Me.lblUserName = New Proshot.UtilityLib.Label()
		Me.txtUsetName = New Proshot.UtilityLib.TextBox()
		Me.btnEnter = New Proshot.UtilityLib.Button()
		Me.btnExit = New Proshot.UtilityLib.Button()
		Me.SuspendLayout()
		' 
		' lblUserName
		' 
		Me.lblUserName.AutoSize = True
		Me.lblUserName.BorderWidth = 1F
		Me.lblUserName.Location = New System.Drawing.Point(4, 9)
		Me.lblUserName.Name = "lblUserName"
		Me.lblUserName.Size = New System.Drawing.Size(74, 14)
		Me.lblUserName.TabIndex = 0
		Me.lblUserName.Text = "User Name :"
		' 
		' txtUsetName
		' 
		Me.txtUsetName.BorderWidth = 1F
		Me.txtUsetName.FloatValue = 0
		Me.txtUsetName.Location = New System.Drawing.Point(78, 6)
		Me.txtUsetName.MaxLength = 10
		Me.txtUsetName.Name = "txtUsetName"
		Me.txtUsetName.Size = New System.Drawing.Size(94, 22)
		Me.txtUsetName.TabIndex = 1
		' 
		' btnEnter
		' 
		Me.btnEnter.Location = New System.Drawing.Point(125, 34)
		Me.btnEnter.Name = "btnEnter"
		Me.btnEnter.Size = New System.Drawing.Size(48, 23)
		Me.btnEnter.TabIndex = 2
		Me.btnEnter.Text = "Enter"
		Me.btnEnter.UseVisualStyleBackColor = True
		AddHandler Me.btnEnter.Click, New System.EventHandler(AddressOf Me.btnEnter_Click)
		' 
		' btnExit
		' 
		Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnExit.Location = New System.Drawing.Point(77, 34)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(48, 23)
		Me.btnExit.TabIndex = 3
		Me.btnExit.Text = "Exit"
		Me.btnExit.UseVisualStyleBackColor = True
		AddHandler Me.btnExit.Click, New System.EventHandler(AddressOf Me.btnExit_Click)
		' 
		' frmLogin
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7F, 14F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(178, 70)
		Me.ControlBox = False
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.btnEnter)
		Me.Controls.Add(Me.txtUsetName)
		Me.Controls.Add(Me.lblUserName)
		Me.Font = New System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "frmLogin"
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		AddHandler Me.FormClosing, New System.Windows.Forms.FormClosingEventHandler(AddressOf Me.frmLogin_FormClosing)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private lblUserName As Proshot.UtilityLib.Label
	Private txtUsetName As Proshot.UtilityLib.TextBox
	Private btnEnter As Proshot.UtilityLib.Button
	Private btnExit As Proshot.UtilityLib.Button

End Class
