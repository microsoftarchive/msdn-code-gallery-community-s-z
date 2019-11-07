Namespace ArchiveManager
	Partial Public Class Password
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
			Me.grbPass = New System.Windows.Forms.GroupBox()
			Me.txtReenter = New System.Windows.Forms.TextBox()
			Me.lblRetype = New System.Windows.Forms.Label()
			Me.txtPassword = New System.Windows.Forms.TextBox()
			Me.lblPassword = New System.Windows.Forms.Label()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.cboEncryption = New System.Windows.Forms.ComboBox()
			Me.btnOK = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.grbPass.SuspendLayout()
			Me.SuspendLayout()
			' 
			' grbPass
			' 
			Me.grbPass.Controls.Add(Me.txtReenter)
			Me.grbPass.Controls.Add(Me.lblRetype)
			Me.grbPass.Controls.Add(Me.txtPassword)
			Me.grbPass.Controls.Add(Me.lblPassword)
			Me.grbPass.Location = New System.Drawing.Point(5, 2)
			Me.grbPass.Name = "grbPass"
			Me.grbPass.Size = New System.Drawing.Size(335, 68)
			Me.grbPass.TabIndex = 0
			Me.grbPass.TabStop = False
			' 
			' txtReenter
			' 
			Me.txtReenter.Location = New System.Drawing.Point(107, 39)
			Me.txtReenter.Name = "txtReenter"
			Me.txtReenter.PasswordChar = "*"c
			Me.txtReenter.Size = New System.Drawing.Size(218, 20)
			Me.txtReenter.TabIndex = 3
			' 
			' lblRetype
			' 
			Me.lblRetype.AutoSize = True
			Me.lblRetype.Location = New System.Drawing.Point(12, 42)
			Me.lblRetype.Name = "lblRetype"
			Me.lblRetype.Size = New System.Drawing.Size(48, 13)
			Me.lblRetype.TabIndex = 2
			Me.lblRetype.Text = "Reenter:"
			' 
			' txtPassword
			' 
			Me.txtPassword.Location = New System.Drawing.Point(107, 13)
			Me.txtPassword.Name = "txtPassword"
			Me.txtPassword.PasswordChar = "*"c
			Me.txtPassword.Size = New System.Drawing.Size(218, 20)
			Me.txtPassword.TabIndex = 1
			' 
			' lblPassword
			' 
			Me.lblPassword.AutoSize = True
			Me.lblPassword.Location = New System.Drawing.Point(12, 16)
			Me.lblPassword.Name = "lblPassword"
			Me.lblPassword.Size = New System.Drawing.Size(56, 13)
			Me.lblPassword.TabIndex = 0
			Me.lblPassword.Text = "Password:"
			' 
			' Label1
			' 
			Me.Label1.AutoSize = True
			Me.Label1.Location = New System.Drawing.Point(17, 79)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(87, 13)
			Me.Label1.TabIndex = 22
			Me.Label1.Text = "Encryption Type:"
			' 
			' cboEncryption
			' 
			Me.cboEncryption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cboEncryption.Items.AddRange(New Object() { "PkzipClassic", "Aes128Bit", "Aes192Bit", "Aes256Bit"})
			Me.cboEncryption.Location = New System.Drawing.Point(112, 76)
			Me.cboEncryption.Name = "cboEncryption"
			Me.cboEncryption.Size = New System.Drawing.Size(109, 21)
			Me.cboEncryption.TabIndex = 21
			' 
			' btnOK
			' 
			Me.btnOK.Location = New System.Drawing.Point(184, 104)
			Me.btnOK.Name = "btnOK"
			Me.btnOK.Size = New System.Drawing.Size(75, 23)
			Me.btnOK.TabIndex = 23
			Me.btnOK.Text = "OK"
'			Me.btnOK.Click += New System.EventHandler(Me.btnOK_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(265, 104)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 24
			Me.btnCancel.Text = "Cancel"
			' 
			' Password
			' 
			Me.AcceptButton = Me.btnOK
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(348, 137)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnOK)
			Me.Controls.Add(Me.Label1)
			Me.Controls.Add(Me.cboEncryption)
			Me.Controls.Add(Me.grbPass)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "Password"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Password"
			Me.grbPass.ResumeLayout(False)
			Me.grbPass.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private grbPass As System.Windows.Forms.GroupBox
		Private txtReenter As System.Windows.Forms.TextBox
		Private lblRetype As System.Windows.Forms.Label
		Private txtPassword As System.Windows.Forms.TextBox
		Private lblPassword As System.Windows.Forms.Label
		Friend Label1 As System.Windows.Forms.Label
		Friend cboEncryption As System.Windows.Forms.ComboBox
		Private WithEvents btnOK As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
	End Class
End Namespace