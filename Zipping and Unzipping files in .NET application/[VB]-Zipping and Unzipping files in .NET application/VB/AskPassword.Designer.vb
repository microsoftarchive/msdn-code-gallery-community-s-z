Namespace ArchiveManager
	Partial Public Class AskPassword
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
			Me.chkUpdateArchivePassword = New System.Windows.Forms.CheckBox()
			Me.txtPassword = New System.Windows.Forms.TextBox()
			Me.lblPassword = New System.Windows.Forms.Label()
			Me.btnOK = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.lbl = New System.Windows.Forms.Label()
			Me.lblFile = New System.Windows.Forms.Label()
			Me.btnSkip = New System.Windows.Forms.Button()
			Me.grbPass.SuspendLayout()
			Me.SuspendLayout()
			' 
			' grbPass
			' 
			Me.grbPass.Controls.Add(Me.chkUpdateArchivePassword)
			Me.grbPass.Controls.Add(Me.txtPassword)
			Me.grbPass.Controls.Add(Me.lblPassword)
			Me.grbPass.Location = New System.Drawing.Point(5, 35)
			Me.grbPass.Name = "grbPass"
			Me.grbPass.Size = New System.Drawing.Size(335, 69)
			Me.grbPass.TabIndex = 0
			Me.grbPass.TabStop = False
			' 
			' chkUpdateArchivePassword
			' 
			Me.chkUpdateArchivePassword.AutoSize = True
			Me.chkUpdateArchivePassword.Location = New System.Drawing.Point(15, 43)
			Me.chkUpdateArchivePassword.Name = "chkUpdateArchivePassword"
			Me.chkUpdateArchivePassword.Size = New System.Drawing.Size(212, 17)
			Me.chkUpdateArchivePassword.TabIndex = 26
			Me.chkUpdateArchivePassword.Text = "Use this password for the entire archive"
			Me.chkUpdateArchivePassword.UseVisualStyleBackColor = True
			' 
			' txtPassword
			' 
			Me.txtPassword.Location = New System.Drawing.Point(107, 17)
			Me.txtPassword.Name = "txtPassword"
			Me.txtPassword.PasswordChar = "*"c
			Me.txtPassword.Size = New System.Drawing.Size(218, 20)
			Me.txtPassword.TabIndex = 1
			' 
			' lblPassword
			' 
			Me.lblPassword.AutoSize = True
			Me.lblPassword.Location = New System.Drawing.Point(12, 20)
			Me.lblPassword.Name = "lblPassword"
			Me.lblPassword.Size = New System.Drawing.Size(56, 13)
			Me.lblPassword.TabIndex = 0
			Me.lblPassword.Text = "Password:"
			' 
			' btnOK
			' 
			Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnOK.Location = New System.Drawing.Point(109, 111)
			Me.btnOK.Name = "btnOK"
			Me.btnOK.Size = New System.Drawing.Size(75, 23)
			Me.btnOK.TabIndex = 23
			Me.btnOK.Text = "OK"
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(265, 111)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 24
			Me.btnCancel.Text = "Cancel"
			' 
			' lbl
			' 
			Me.lbl.AutoSize = True
			Me.lbl.Location = New System.Drawing.Point(5, 5)
			Me.lbl.Name = "lbl"
			Me.lbl.Size = New System.Drawing.Size(182, 13)
			Me.lbl.TabIndex = 25
			Me.lbl.Text = "Enter password for the encrypted file:"
			' 
			' lblFile
			' 
			Me.lblFile.AutoSize = True
			Me.lblFile.Location = New System.Drawing.Point(5, 22)
			Me.lblFile.Name = "lblFile"
			Me.lblFile.Size = New System.Drawing.Size(23, 13)
			Me.lblFile.TabIndex = 26
			Me.lblFile.Text = "File"
			' 
			' btnSkip
			' 
			Me.btnSkip.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnSkip.Location = New System.Drawing.Point(186, 111)
			Me.btnSkip.Name = "btnSkip"
			Me.btnSkip.Size = New System.Drawing.Size(75, 23)
			Me.btnSkip.TabIndex = 27
			Me.btnSkip.Text = "Skip"
'			Me.btnSkip.Click += New System.EventHandler(Me.btnSkip_Click)
			' 
			' AskPassword
			' 
			Me.AcceptButton = Me.btnOK
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(348, 145)
			Me.Controls.Add(Me.btnSkip)
			Me.Controls.Add(Me.lblFile)
			Me.Controls.Add(Me.lbl)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnOK)
			Me.Controls.Add(Me.grbPass)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "AskPassword"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Password"
			Me.grbPass.ResumeLayout(False)
			Me.grbPass.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private grbPass As System.Windows.Forms.GroupBox
		Private txtPassword As System.Windows.Forms.TextBox
		Private lblPassword As System.Windows.Forms.Label
		Private btnOK As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
		Private lbl As System.Windows.Forms.Label
		Private lblFile As System.Windows.Forms.Label
		Private chkUpdateArchivePassword As System.Windows.Forms.CheckBox
		Private WithEvents btnSkip As System.Windows.Forms.Button
	End Class
End Namespace