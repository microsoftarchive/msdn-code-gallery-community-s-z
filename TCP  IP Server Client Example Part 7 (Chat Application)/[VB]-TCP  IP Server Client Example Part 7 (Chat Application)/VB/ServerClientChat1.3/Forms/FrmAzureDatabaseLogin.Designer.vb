Namespace ServerClientChat1._3.Forms
	Partial Public Class FrmAzureDatabaseLogin
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
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmAzureDatabaseLogin))
			Me.label1 = New System.Windows.Forms.Label()
			Me.tbServername = New System.Windows.Forms.TextBox()
			Me.tbUsername = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.tbPassword = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.btnConnect = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.errorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
			Me.cbRememberForThisSession = New System.Windows.Forms.CheckBox()
			Me.btnLoad = New System.Windows.Forms.Button()
			DirectCast(Me.errorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(123, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Azure SQL Server Name"
			' 
			' tbServername
			' 
			Me.tbServername.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbServername.Location = New System.Drawing.Point(15, 26)
			Me.tbServername.Name = "tbServername"
			Me.tbServername.Size = New System.Drawing.Size(309, 20)
			Me.tbServername.TabIndex = 0
'			Me.tbServername.Validating += New System.ComponentModel.CancelEventHandler(Me.tbServername_Validating)
			' 
			' tbUsername
			' 
			Me.tbUsername.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbUsername.Location = New System.Drawing.Point(15, 66)
			Me.tbUsername.Name = "tbUsername"
			Me.tbUsername.Size = New System.Drawing.Size(309, 20)
			Me.tbUsername.TabIndex = 1
'			Me.tbUsername.Validating += New System.ComponentModel.CancelEventHandler(Me.tbUsername_Validating)
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 49)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(114, 13)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Azure SQL User Name"
			' 
			' tbPassword
			' 
			Me.tbPassword.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbPassword.Location = New System.Drawing.Point(15, 106)
			Me.tbPassword.Name = "tbPassword"
			Me.tbPassword.PasswordChar = "#"c
			Me.tbPassword.Size = New System.Drawing.Size(309, 20)
			Me.tbPassword.TabIndex = 2
'			Me.tbPassword.Validating += New System.ComponentModel.CancelEventHandler(Me.tbPassword_Validating)
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(12, 89)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(107, 13)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Azure SQL Password"
			' 
			' btnConnect
			' 
			Me.btnConnect.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnConnect.Location = New System.Drawing.Point(268, 153)
			Me.btnConnect.Name = "btnConnect"
			Me.btnConnect.Size = New System.Drawing.Size(75, 23)
			Me.btnConnect.TabIndex = 3
			Me.btnConnect.Text = "Connect"
			Me.btnConnect.UseVisualStyleBackColor = True
'			Me.btnConnect.Click += New System.EventHandler(Me.btnConnect_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(15, 153)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 4
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
'			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click)
			' 
			' errorProvider1
			' 
			Me.errorProvider1.ContainerControl = Me
			' 
			' cbRememberForThisSession
			' 
			Me.cbRememberForThisSession.AutoSize = True
			Me.cbRememberForThisSession.Location = New System.Drawing.Point(15, 133)
			Me.cbRememberForThisSession.Name = "cbRememberForThisSession"
			Me.cbRememberForThisSession.Size = New System.Drawing.Size(149, 17)
			Me.cbRememberForThisSession.TabIndex = 5
			Me.cbRememberForThisSession.Text = "Remember for this session"
			Me.cbRememberForThisSession.UseVisualStyleBackColor = True
'			Me.cbRememberForThisSession.CheckedChanged += New System.EventHandler(Me.cbRememberForThisSession_CheckedChanged)
			' 
			' btnLoad
			' 
			Me.btnLoad.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnLoad.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnLoad.Enabled = False
			Me.btnLoad.Location = New System.Drawing.Point(187, 153)
			Me.btnLoad.Name = "btnLoad"
			Me.btnLoad.Size = New System.Drawing.Size(75, 23)
			Me.btnLoad.TabIndex = 6
			Me.btnLoad.Text = "Load"
			Me.btnLoad.UseVisualStyleBackColor = True
			Me.btnLoad.Visible = False
'			Me.btnLoad.Click += New System.EventHandler(Me.btnLoad_Click)
			' 
			' FrmAzureDatabaseLogin
			' 
			Me.AcceptButton = Me.btnConnect
			Me.AccessibleDescription = "Connect to Database Button"
			Me.AccessibleName = "Connect to Database Button"
			Me.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(355, 188)
			Me.ControlBox = False
			Me.Controls.Add(Me.btnLoad)
			Me.Controls.Add(Me.cbRememberForThisSession)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnConnect)
			Me.Controls.Add(Me.tbPassword)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.tbUsername)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.tbServername)
			Me.Controls.Add(Me.label1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.Name = "FrmAzureDatabaseLogin"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Azure SQL Login"
			Me.TopMost = True
			DirectCast(Me.errorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private WithEvents tbServername As System.Windows.Forms.TextBox
		Private WithEvents tbUsername As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private WithEvents tbPassword As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents btnConnect As System.Windows.Forms.Button
		Private WithEvents btnCancel As System.Windows.Forms.Button
		Private errorProvider1 As System.Windows.Forms.ErrorProvider
		Private WithEvents cbRememberForThisSession As System.Windows.Forms.CheckBox
		Private WithEvents btnLoad As System.Windows.Forms.Button
	End Class
End Namespace