Namespace ChatApp1._2.Forms
	Partial Public Class FrmRegister
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmRegister))
			Me.btnLogin = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.tbPassword = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.tbEmailAddress = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.tbConfirmPassword = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' btnLogin
			' 
			Me.btnLogin.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnLogin.Location = New System.Drawing.Point(282, 142)
			Me.btnLogin.Name = "btnLogin"
			Me.btnLogin.Size = New System.Drawing.Size(75, 23)
			Me.btnLogin.TabIndex = 12
			Me.btnLogin.Text = "Register"
			Me.btnLogin.UseVisualStyleBackColor = True
'			Me.btnLogin.Click += New System.EventHandler(Me.BtnLoginClick)
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(18, 142)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 11
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
'			Me.btnCancel.Click += New System.EventHandler(Me.BtnCancelClick)
			' 
			' tbPassword
			' 
			Me.tbPassword.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbPassword.Location = New System.Drawing.Point(18, 73)
			Me.tbPassword.Name = "tbPassword"
			Me.tbPassword.PasswordChar = "*"c
			Me.tbPassword.Size = New System.Drawing.Size(339, 20)
			Me.tbPassword.TabIndex = 10
			Me.tbPassword.Text = "pass"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(18, 57)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(56, 13)
			Me.label2.TabIndex = 9
			Me.label2.Text = "Password:"
			' 
			' tbEmailAddress
			' 
			Me.tbEmailAddress.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbEmailAddress.Location = New System.Drawing.Point(18, 25)
			Me.tbEmailAddress.Name = "tbEmailAddress"
			Me.tbEmailAddress.Size = New System.Drawing.Size(339, 20)
			Me.tbEmailAddress.TabIndex = 8
			Me.tbEmailAddress.Text = "myemail@email.com"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(18, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(76, 13)
			Me.label1.TabIndex = 7
			Me.label1.Text = "Email Address:"
			' 
			' tbConfirmPassword
			' 
			Me.tbConfirmPassword.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbConfirmPassword.Location = New System.Drawing.Point(18, 112)
			Me.tbConfirmPassword.Name = "tbConfirmPassword"
			Me.tbConfirmPassword.PasswordChar = "*"c
			Me.tbConfirmPassword.Size = New System.Drawing.Size(339, 20)
			Me.tbConfirmPassword.TabIndex = 15
			Me.tbConfirmPassword.Text = "pass"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(18, 96)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(94, 13)
			Me.label3.TabIndex = 14
			Me.label3.Text = "Confirm Password:"
			' 
			' FrmRegister
			' 
			Me.AcceptButton = Me.btnLogin
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(367, 177)
			Me.Controls.Add(Me.tbConfirmPassword)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.btnLogin)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.tbPassword)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.tbEmailAddress)
			Me.Controls.Add(Me.label1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "FrmRegister"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Register"
			Me.TopMost = True
'			Me.Load += New System.EventHandler(Me.FrmRegister_Load)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btnLogin As System.Windows.Forms.Button
		Private WithEvents btnCancel As System.Windows.Forms.Button
		Private tbPassword As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private tbEmailAddress As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private tbConfirmPassword As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
	End Class
End Namespace