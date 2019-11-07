Namespace ArchiveManager
	Partial Public Class NewNamePrompt
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
			Me.txtNewName = New System.Windows.Forms.TextBox()
			Me.groupBox = New System.Windows.Forms.GroupBox()
			Me.btnOk = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.groupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' lbl
			' 
			Me.lbl.Location = New System.Drawing.Point(7, 21)
			Me.lbl.Name = "lbl"
			Me.lbl.Size = New System.Drawing.Size(71, 16)
			Me.lbl.TabIndex = 0
			Me.lbl.Text = "New Name:"
			' 
			' txtNewName
			' 
			Me.txtNewName.Location = New System.Drawing.Point(89, 21)
			Me.txtNewName.Name = "txtNewName"
			Me.txtNewName.Size = New System.Drawing.Size(248, 20)
			Me.txtNewName.TabIndex = 1
			' 
			' groupBox
			' 
			Me.groupBox.Controls.Add(Me.lbl)
			Me.groupBox.Location = New System.Drawing.Point(6, 3)
			Me.groupBox.Name = "groupBox"
			Me.groupBox.Size = New System.Drawing.Size(342, 53)
			Me.groupBox.TabIndex = 0
			Me.groupBox.TabStop = False
			' 
			' btnOk
			' 
			Me.btnOk.Location = New System.Drawing.Point(193, 62)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 10
			Me.btnOk.Text = "&OK"
'			Me.btnOk.Click += New System.EventHandler(Me.btnOk_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(273, 62)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 11
			Me.btnCancel.Text = "&Cancel"
			' 
			' NewNamePrompt
			' 
			Me.AcceptButton = Me.btnOk
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(355, 94)
			Me.Controls.Add(Me.txtNewName)
			Me.Controls.Add(Me.groupBox)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.btnCancel)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "NewNamePrompt"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Enter new name"
			Me.groupBox.ResumeLayout(False)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private lbl As System.Windows.Forms.Label
		Private txtNewName As System.Windows.Forms.TextBox
		Private groupBox As System.Windows.Forms.GroupBox
		Private WithEvents btnOk As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
	End Class
End Namespace