Namespace ChatClient
	Partial Public Class FrmLogin
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
			Me.llRegister = New System.Windows.Forms.LinkLabel()
			Me.btnLogin = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.tbPassword = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.tbEmailAddress = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' llRegister
			' 
			Me.llRegister.AutoSize = True
			Me.llRegister.Location = New System.Drawing.Point(15, 101)
			Me.llRegister.Name = "llRegister"
			Me.llRegister.Size = New System.Drawing.Size(46, 13)
			Me.llRegister.TabIndex = 20
			Me.llRegister.TabStop = True
			Me.llRegister.Text = "Register"
'			Me.llRegister.LinkClicked += New System.Windows.Forms.LinkLabelLinkClickedEventHandler(Me.llRegister_LinkClicked)
			' 
			' btnLogin
			' 
			Me.btnLogin.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnLogin.Location = New System.Drawing.Point(279, 135)
			Me.btnLogin.Name = "btnLogin"
			Me.btnLogin.Size = New System.Drawing.Size(75, 23)
			Me.btnLogin.TabIndex = 19
			Me.btnLogin.Text = "Login"
			Me.btnLogin.UseVisualStyleBackColor = True
'			Me.btnLogin.Click += New System.EventHandler(Me.btnLogin_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(15, 135)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 18
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
'			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click)
			' 
			' tbPassword
			' 
			Me.tbPassword.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbPassword.Location = New System.Drawing.Point(15, 74)
			Me.tbPassword.Name = "tbPassword"
			Me.tbPassword.PasswordChar = "*"c
			Me.tbPassword.Size = New System.Drawing.Size(339, 20)
			Me.tbPassword.TabIndex = 17
			Me.tbPassword.Text = "pass"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 58)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(56, 13)
			Me.label2.TabIndex = 16
			Me.label2.Text = "Password:"
			' 
			' tbEmailAddress
			' 
			Me.tbEmailAddress.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbEmailAddress.Location = New System.Drawing.Point(15, 26)
			Me.tbEmailAddress.Name = "tbEmailAddress"
			Me.tbEmailAddress.Size = New System.Drawing.Size(339, 20)
			Me.tbEmailAddress.TabIndex = 15
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(76, 13)
			Me.label1.TabIndex = 14
			Me.label1.Text = "Email Address:"
			' 
			' FrmLogin
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(367, 169)
			Me.Controls.Add(Me.llRegister)
			Me.Controls.Add(Me.btnLogin)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.tbPassword)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.tbEmailAddress)
			Me.Controls.Add(Me.label1)
			Me.Name = "FrmLogin"
			Me.Text = "Login"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents llRegister As System.Windows.Forms.LinkLabel
		Private WithEvents btnLogin As System.Windows.Forms.Button
		Private WithEvents btnCancel As System.Windows.Forms.Button
		Private tbPassword As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private tbEmailAddress As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
	End Class
End Namespace