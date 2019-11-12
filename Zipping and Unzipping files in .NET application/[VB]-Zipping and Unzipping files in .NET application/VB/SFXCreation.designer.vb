Namespace ArchiveManager
	Partial Public Class SFXCreation
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
			Me.lbl = New System.Windows.Forms.Label()
			Me.txtName = New System.Windows.Forms.TextBox()
			Me.groupBox = New System.Windows.Forms.GroupBox()
			Me.lblSfx = New System.Windows.Forms.Label()
			Me.txtSfx = New System.Windows.Forms.TextBox()
			Me.btnBrowseSfx = New System.Windows.Forms.Button()
			Me.btnStubFile = New System.Windows.Forms.Button()
			Me.btnOk = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.groupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' lbl
			' 
			Me.lbl.Location = New System.Drawing.Point(7, 21)
			Me.lbl.Name = "lbl"
			Me.lbl.Size = New System.Drawing.Size(83, 16)
			Me.lbl.TabIndex = 0
			Me.lbl.Text = "SFX Stub File:"
			' 
			' txtName
			' 
			Me.txtName.Location = New System.Drawing.Point(107, 21)
			Me.txtName.Name = "txtName"
			Me.txtName.Size = New System.Drawing.Size(204, 20)
			Me.txtName.TabIndex = 1
			' 
			' groupBox
			' 
			Me.groupBox.Controls.Add(Me.lblSfx)
			Me.groupBox.Controls.Add(Me.txtSfx)
			Me.groupBox.Controls.Add(Me.btnBrowseSfx)
			Me.groupBox.Controls.Add(Me.btnStubFile)
			Me.groupBox.Controls.Add(Me.lbl)
			Me.groupBox.Location = New System.Drawing.Point(6, 3)
			Me.groupBox.Name = "groupBox"
			Me.groupBox.Size = New System.Drawing.Size(342, 81)
			Me.groupBox.TabIndex = 0
			Me.groupBox.TabStop = False
			' 
			' lblSfx
			' 
			Me.lblSfx.Location = New System.Drawing.Point(7, 49)
			Me.lblSfx.Name = "lblSfx"
			Me.lblSfx.Size = New System.Drawing.Size(88, 16)
			Me.lblSfx.TabIndex = 5
			Me.lblSfx.Text = "SFX Output File:"
			' 
			' txtSfx
			' 
			Me.txtSfx.Location = New System.Drawing.Point(101, 46)
			Me.txtSfx.Name = "txtSfx"
			Me.txtSfx.Size = New System.Drawing.Size(204, 20)
			Me.txtSfx.TabIndex = 3
			' 
			' btnBrowseSfx
			' 
			Me.btnBrowseSfx.Location = New System.Drawing.Point(308, 44)
			Me.btnBrowseSfx.Name = "btnBrowseSfx"
			Me.btnBrowseSfx.Size = New System.Drawing.Size(25, 23)
			Me.btnBrowseSfx.TabIndex = 4
			Me.btnBrowseSfx.Text = "..."
'			Me.btnBrowseSfx.Click += New System.EventHandler(Me.btnBrowseSfx_Click)
			' 
			' btnStubFile
			' 
			Me.btnStubFile.Location = New System.Drawing.Point(308, 17)
			Me.btnStubFile.Name = "btnStubFile"
			Me.btnStubFile.Size = New System.Drawing.Size(25, 23)
			Me.btnStubFile.TabIndex = 2
			Me.btnStubFile.Text = "..."
'			Me.btnStubFile.Click += New System.EventHandler(Me.btnStubFile_Click)
			' 
			' btnOk
			' 
			Me.btnOk.Location = New System.Drawing.Point(193, 90)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 10
			Me.btnOk.Text = "&OK"
'			Me.btnOk.Click += New System.EventHandler(Me.btnOk_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(273, 90)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 11
			Me.btnCancel.Text = "&Cancel"
			' 
			' SFXCreation
			' 
			Me.AcceptButton = Me.btnOk
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(355, 121)
			Me.Controls.Add(Me.txtName)
			Me.Controls.Add(Me.groupBox)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.btnCancel)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "SFXCreation"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Create SFX"
			Me.groupBox.ResumeLayout(False)
			Me.groupBox.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private lbl As System.Windows.Forms.Label
		Private txtName As System.Windows.Forms.TextBox
		Private groupBox As System.Windows.Forms.GroupBox
		Private WithEvents btnOk As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
		Private WithEvents btnStubFile As System.Windows.Forms.Button
		Private lblSfx As System.Windows.Forms.Label
		Private txtSfx As System.Windows.Forms.TextBox
		Private WithEvents btnBrowseSfx As System.Windows.Forms.Button
	End Class
End Namespace