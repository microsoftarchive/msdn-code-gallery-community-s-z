Namespace ChatClient
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
			Me.tbConfirmPassword = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.btnLogin = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.tbPassword = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.tbEmailAddress = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' tbConfirmPassword
			' 
			Me.tbConfirmPassword.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbConfirmPassword.Location = New System.Drawing.Point(12, 114)
			Me.tbConfirmPassword.Name = "tbConfirmPassword"
			Me.tbConfirmPassword.PasswordChar = "*"c
			Me.tbConfirmPassword.Size = New System.Drawing.Size(338, 20)
			Me.tbConfirmPassword.TabIndex = 31
			Me.tbConfirmPassword.Text = "pass"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(12, 98)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(94, 13)
			Me.label3.TabIndex = 30
			Me.label3.Text = "Confirm Password:"
			' 
			' btnLogin
			' 
			Me.btnLogin.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnLogin.Location = New System.Drawing.Point(276, 149)
			Me.btnLogin.Name = "btnLogin"
			Me.btnLogin.Size = New System.Drawing.Size(75, 23)
			Me.btnLogin.TabIndex = 29
			Me.btnLogin.Text = "Register"
			Me.btnLogin.UseVisualStyleBackColor = True
'			Me.btnLogin.Click += New System.EventHandler(Me.btnLogin_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(12, 149)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 28
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
'			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click)
			' 
			' tbPassword
			' 
			Me.tbPassword.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbPassword.Location = New System.Drawing.Point(12, 75)
			Me.tbPassword.Name = "tbPassword"
			Me.tbPassword.PasswordChar = "*"c
			Me.tbPassword.Size = New System.Drawing.Size(338, 20)
			Me.tbPassword.TabIndex = 27
			Me.tbPassword.Text = "pass"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 59)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(56, 13)
			Me.label2.TabIndex = 26
			Me.label2.Text = "Password:"
			' 
			' tbEmailAddress
			' 
			Me.tbEmailAddress.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbEmailAddress.Location = New System.Drawing.Point(12, 27)
			Me.tbEmailAddress.Name = "tbEmailAddress"
			Me.tbEmailAddress.Size = New System.Drawing.Size(338, 20)
			Me.tbEmailAddress.TabIndex = 25
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 11)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(76, 13)
			Me.label1.TabIndex = 24
			Me.label1.Text = "Email Address:"
			' 
			' FrmRegister
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(362, 182)
			Me.Controls.Add(Me.tbConfirmPassword)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.btnLogin)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.tbPassword)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.tbEmailAddress)
			Me.Controls.Add(Me.label1)
			Me.Name = "FrmRegister"
			Me.Text = "Register"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private tbConfirmPassword As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents btnLogin As System.Windows.Forms.Button
		Private WithEvents btnCancel As System.Windows.Forms.Button
		Private tbPassword As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private tbEmailAddress As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
	End Class
End Namespace