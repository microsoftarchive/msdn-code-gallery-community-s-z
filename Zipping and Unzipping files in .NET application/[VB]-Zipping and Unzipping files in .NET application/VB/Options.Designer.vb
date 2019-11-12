Namespace ArchiveManager
	Partial Public Class Options
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
			Me.lblLevel = New System.Windows.Forms.Label()
			Me.cbxLevel = New System.Windows.Forms.ComboBox()
			Me.chkRecursive = New System.Windows.Forms.CheckBox()
			Me.btnOK = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.cbxPath = New System.Windows.Forms.ComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.cbxCompressionMethod = New System.Windows.Forms.ComboBox()
			Me.lblMethod = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' lblLevel
			' 
			Me.lblLevel.AutoSize = True
			Me.lblLevel.Location = New System.Drawing.Point(6, 9)
			Me.lblLevel.Name = "lblLevel"
			Me.lblLevel.Size = New System.Drawing.Size(99, 13)
			Me.lblLevel.TabIndex = 0
			Me.lblLevel.Text = "Compression Level:"
			' 
			' cbxLevel
			' 
			Me.cbxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbxLevel.FormattingEnabled = True
			Me.cbxLevel.Items.AddRange(New Object() { "0 (Fastest)", "1", "2", "3", "4", "5", "6", "7", "8", "9 (Optimized for File Size)"})
			Me.cbxLevel.Location = New System.Drawing.Point(114, 6)
			Me.cbxLevel.Name = "cbxLevel"
			Me.cbxLevel.Size = New System.Drawing.Size(183, 21)
			Me.cbxLevel.TabIndex = 1
			' 
			' chkRecursive
			' 
			Me.chkRecursive.AutoSize = True
			Me.chkRecursive.Location = New System.Drawing.Point(114, 66)
			Me.chkRecursive.Name = "chkRecursive"
			Me.chkRecursive.Size = New System.Drawing.Size(74, 17)
			Me.chkRecursive.TabIndex = 3
			Me.chkRecursive.Text = "Recursive"
			' 
			' btnOK
			' 
			Me.btnOK.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnOK.Location = New System.Drawing.Point(141, 139)
			Me.btnOK.Name = "btnOK"
			Me.btnOK.Size = New System.Drawing.Size(75, 23)
			Me.btnOK.TabIndex = 20
			Me.btnOK.Text = "OK"
'			Me.btnOK.Click += New System.EventHandler(Me.btnOK_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(222, 139)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 21
			Me.btnCancel.Text = "Cancel"
			' 
			' cbxPath
			' 
			Me.cbxPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbxPath.FormattingEnabled = True
			Me.cbxPath.Items.AddRange(New Object() { "Do not store paths", "Store relative paths", "Store full paths", "Store full paths incl. the driver letter"})
			Me.cbxPath.Location = New System.Drawing.Point(114, 88)
			Me.cbxPath.Name = "cbxPath"
			Me.cbxPath.Size = New System.Drawing.Size(183, 21)
			Me.cbxPath.TabIndex = 8
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(6, 91)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(98, 13)
			Me.label1.TabIndex = 7
			Me.label1.Text = "Path Storing Mode:"
			' 
			' cbxCompressionMethod
			' 
			Me.cbxCompressionMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbxCompressionMethod.FormattingEnabled = True
			Me.cbxCompressionMethod.Items.AddRange(New Object() { "None", "Deflate", "BZIP2", "PPMd"})
			Me.cbxCompressionMethod.Location = New System.Drawing.Point(114, 33)
			Me.cbxCompressionMethod.Name = "cbxCompressionMethod"
			Me.cbxCompressionMethod.Size = New System.Drawing.Size(183, 21)
			Me.cbxCompressionMethod.TabIndex = 2
			' 
			' lblMethod
			' 
			Me.lblMethod.AutoSize = True
			Me.lblMethod.Location = New System.Drawing.Point(6, 36)
			Me.lblMethod.Name = "lblMethod"
			Me.lblMethod.Size = New System.Drawing.Size(109, 13)
			Me.lblMethod.TabIndex = 9
			Me.lblMethod.Text = "Compression Method:"
			' 
			' Options
			' 
			Me.AcceptButton = Me.btnOK
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(307, 174)
			Me.Controls.Add(Me.cbxCompressionMethod)
			Me.Controls.Add(Me.lblMethod)
			Me.Controls.Add(Me.cbxPath)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnOK)
			Me.Controls.Add(Me.chkRecursive)
			Me.Controls.Add(Me.cbxLevel)
			Me.Controls.Add(Me.lblLevel)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "Options"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "ZIP Options"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private lblLevel As System.Windows.Forms.Label
		Private cbxLevel As System.Windows.Forms.ComboBox
		Private chkRecursive As System.Windows.Forms.CheckBox
		Private WithEvents btnOK As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
		Private cbxPath As System.Windows.Forms.ComboBox
		Private label1 As System.Windows.Forms.Label
		Private cbxCompressionMethod As System.Windows.Forms.ComboBox
		Private lblMethod As System.Windows.Forms.Label
	End Class
End Namespace