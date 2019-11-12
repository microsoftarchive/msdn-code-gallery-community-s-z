Namespace ArchiveManager
	Partial Public Class CreateNewArchive
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
			Me.cbxFileFormat = New System.Windows.Forms.ComboBox()
			Me.lblFormat = New System.Windows.Forms.Label()
			Me.btnOk = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' cbxFileFormat
			' 
			Me.cbxFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbxFileFormat.FormattingEnabled = True
			Me.cbxFileFormat.Items.AddRange(New Object() { "Zip", "Gzip", "Tar", "Tgz"})
			Me.cbxFileFormat.Location = New System.Drawing.Point(132, 12)
			Me.cbxFileFormat.Name = "cbxFileFormat"
			Me.cbxFileFormat.Size = New System.Drawing.Size(133, 21)
			Me.cbxFileFormat.TabIndex = 0
			' 
			' lblFormat
			' 
			Me.lblFormat.AutoSize = True
			Me.lblFormat.Location = New System.Drawing.Point(13, 16)
			Me.lblFormat.Name = "lblFormat"
			Me.lblFormat.Size = New System.Drawing.Size(100, 13)
			Me.lblFormat.TabIndex = 1
			Me.lblFormat.Text = "Archive File Format:"
			' 
			' btnOk
			' 
			Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnOk.Location = New System.Drawing.Point(110, 53)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 12
			Me.btnOk.Text = "&OK"
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(190, 53)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 13
			Me.btnCancel.Text = "&Cancel"
			' 
			' CreateNewArchive
			' 
			Me.AcceptButton = Me.btnOk
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(273, 86)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.lblFormat)
			Me.Controls.Add(Me.cbxFileFormat)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "CreateNewArchive"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "New Archive"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private cbxFileFormat As System.Windows.Forms.ComboBox
		Private lblFormat As System.Windows.Forms.Label
		Private btnOk As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
	End Class
End Namespace