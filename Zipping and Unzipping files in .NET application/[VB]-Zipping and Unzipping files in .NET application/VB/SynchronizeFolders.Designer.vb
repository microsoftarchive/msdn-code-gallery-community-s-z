Namespace ArchiveManager
	Partial Public Class SynchronizeFolders
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
			Me.btnOk = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.txtSearchPattern = New System.Windows.Forms.TextBox()
			Me.lblPattern = New System.Windows.Forms.Label()
			Me.cbxComparisonType = New System.Windows.Forms.ComboBox()
			Me.lblCompare = New System.Windows.Forms.Label()
			Me.chkRecursive = New System.Windows.Forms.CheckBox()
			Me.chkResumability = New System.Windows.Forms.CheckBox()
			Me.txtSourceDir = New System.Windows.Forms.TextBox()
			Me.lblSource = New System.Windows.Forms.Label()
			Me.btnSourceDir = New System.Windows.Forms.Button()
			Me.chkUpdateTime = New System.Windows.Forms.CheckBox()
			Me.chkUpdateAttributes = New System.Windows.Forms.CheckBox()
			Me.chkDeleteFiles = New System.Windows.Forms.CheckBox()
			Me.SuspendLayout()
			' 
			' btnOk
			' 
			Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnOk.Location = New System.Drawing.Point(194, 173)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 20
			Me.btnOk.Text = "&OK"
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(275, 173)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 21
			Me.btnCancel.Text = "&Cancel"
			' 
			' txtSearchPattern
			' 
			Me.txtSearchPattern.Location = New System.Drawing.Point(75, 12)
			Me.txtSearchPattern.Name = "txtSearchPattern"
			Me.txtSearchPattern.Size = New System.Drawing.Size(275, 20)
			Me.txtSearchPattern.TabIndex = 1
			' 
			' lblPattern
			' 
			Me.lblPattern.Location = New System.Drawing.Point(5, 15)
			Me.lblPattern.Name = "lblPattern"
			Me.lblPattern.Size = New System.Drawing.Size(55, 13)
			Me.lblPattern.TabIndex = 73
			Me.lblPattern.Text = "File Mask:"
			' 
			' cbxComparisonType
			' 
			Me.cbxComparisonType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbxComparisonType.FormattingEnabled = True
			Me.cbxComparisonType.Items.AddRange(New Object() { "Date Time", "File Content", "Name Only"})
			Me.cbxComparisonType.Location = New System.Drawing.Point(75, 142)
			Me.cbxComparisonType.Name = "cbxComparisonType"
			Me.cbxComparisonType.Size = New System.Drawing.Size(176, 21)
			Me.cbxComparisonType.TabIndex = 8
'			Me.cbxComparisonType.SelectedIndexChanged += New System.EventHandler(Me.cbxComparisonType_SelectedIndexChanged)
			' 
			' lblCompare
			' 
			Me.lblCompare.Location = New System.Drawing.Point(8, 146)
			Me.lblCompare.Name = "lblCompare"
			Me.lblCompare.Size = New System.Drawing.Size(66, 13)
			Me.lblCompare.TabIndex = 70
			Me.lblCompare.Text = "Compare by:"
			' 
			' chkRecursive
			' 
			Me.chkRecursive.Location = New System.Drawing.Point(76, 64)
			Me.chkRecursive.Name = "chkRecursive"
			Me.chkRecursive.Size = New System.Drawing.Size(74, 21)
			Me.chkRecursive.TabIndex = 4
			Me.chkRecursive.Text = "Recursive"
			' 
			' chkResumability
			' 
			Me.chkResumability.Location = New System.Drawing.Point(11, 169)
			Me.chkResumability.Name = "chkResumability"
			Me.chkResumability.Size = New System.Drawing.Size(139, 26)
			Me.chkResumability.TabIndex = 9
			Me.chkResumability.Text = "Check for resumability"
			' 
			' txtSourceDir
			' 
			Me.txtSourceDir.Location = New System.Drawing.Point(75, 38)
			Me.txtSourceDir.Name = "txtSourceDir"
			Me.txtSourceDir.Size = New System.Drawing.Size(245, 20)
			Me.txtSourceDir.TabIndex = 2
			' 
			' lblSource
			' 
			Me.lblSource.Location = New System.Drawing.Point(5, 41)
			Me.lblSource.Name = "lblSource"
			Me.lblSource.Size = New System.Drawing.Size(64, 13)
			Me.lblSource.TabIndex = 75
			Me.lblSource.Text = "Source Dir:"
			' 
			' btnSourceDir
			' 
			Me.btnSourceDir.Location = New System.Drawing.Point(324, 36)
			Me.btnSourceDir.Name = "btnSourceDir"
			Me.btnSourceDir.Size = New System.Drawing.Size(26, 23)
			Me.btnSourceDir.TabIndex = 3
			Me.btnSourceDir.Text = "..."
'			Me.btnSourceDir.Click += New System.EventHandler(Me.btnSourceDir_Click)
			' 
			' chkUpdateTime
			' 
			Me.chkUpdateTime.Location = New System.Drawing.Point(177, 64)
			Me.chkUpdateTime.Name = "chkUpdateTime"
			Me.chkUpdateTime.Size = New System.Drawing.Size(143, 21)
			Me.chkUpdateTime.TabIndex = 5
			Me.chkUpdateTime.Text = "Update Last Write Time"
			' 
			' chkUpdateAttributes
			' 
			Me.chkUpdateAttributes.Location = New System.Drawing.Point(76, 91)
			Me.chkUpdateAttributes.Name = "chkUpdateAttributes"
			Me.chkUpdateAttributes.Size = New System.Drawing.Size(143, 21)
			Me.chkUpdateAttributes.TabIndex = 6
			Me.chkUpdateAttributes.Text = "Update File Attributes"
			' 
			' chkDeleteFiles
			' 
			Me.chkDeleteFiles.Location = New System.Drawing.Point(76, 117)
			Me.chkDeleteFiles.Name = "chkDeleteFiles"
			Me.chkDeleteFiles.Size = New System.Drawing.Size(143, 21)
			Me.chkDeleteFiles.TabIndex = 7
			Me.chkDeleteFiles.Text = "Delete Files In Archive"
			' 
			' SynchronizeFolders
			' 
			Me.AcceptButton = Me.btnOk
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(357, 205)
			Me.Controls.Add(Me.chkDeleteFiles)
			Me.Controls.Add(Me.chkUpdateAttributes)
			Me.Controls.Add(Me.chkUpdateTime)
			Me.Controls.Add(Me.btnSourceDir)
			Me.Controls.Add(Me.txtSourceDir)
			Me.Controls.Add(Me.lblSource)
			Me.Controls.Add(Me.chkResumability)
			Me.Controls.Add(Me.chkRecursive)
			Me.Controls.Add(Me.txtSearchPattern)
			Me.Controls.Add(Me.lblPattern)
			Me.Controls.Add(Me.cbxComparisonType)
			Me.Controls.Add(Me.lblCompare)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.btnCancel)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "SynchronizeFolders"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Update/Synchronize files and directories"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private btnOk As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
		Private txtSearchPattern As System.Windows.Forms.TextBox
		Private lblPattern As System.Windows.Forms.Label
		Private WithEvents cbxComparisonType As System.Windows.Forms.ComboBox
		Private lblCompare As System.Windows.Forms.Label
		Private chkRecursive As System.Windows.Forms.CheckBox
		Private chkResumability As System.Windows.Forms.CheckBox
		Private txtSourceDir As System.Windows.Forms.TextBox
		Private lblSource As System.Windows.Forms.Label
		Private WithEvents btnSourceDir As System.Windows.Forms.Button
		Private chkUpdateTime As System.Windows.Forms.CheckBox
		Private chkUpdateAttributes As System.Windows.Forms.CheckBox
		Private chkDeleteFiles As System.Windows.Forms.CheckBox
	End Class
End Namespace