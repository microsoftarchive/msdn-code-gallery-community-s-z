Namespace ArchiveManager
	Partial Public Class FileOperation
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
			Me.txtMessage = New System.Windows.Forms.TextBox()
			Me.btnFollowLink = New System.Windows.Forms.Button()
			Me.btnSkipAll = New System.Windows.Forms.Button()
			Me.btnOverwriteDiffSize = New System.Windows.Forms.Button()
			Me.btnOverwriteOlder = New System.Windows.Forms.Button()
			Me.btnOverwriteAll = New System.Windows.Forms.Button()
			Me.btnOverwrite = New System.Windows.Forms.Button()
			Me.btnRetry = New System.Windows.Forms.Button()
			Me.btnRename = New System.Windows.Forms.Button()
			Me.btnSkip = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' txtMessage
			' 
			Me.txtMessage.AcceptsReturn = True
			Me.txtMessage.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txtMessage.BackColor = System.Drawing.Color.White
			Me.txtMessage.Location = New System.Drawing.Point(7, 8)
			Me.txtMessage.Multiline = True
			Me.txtMessage.Name = "txtMessage"
			Me.txtMessage.ReadOnly = True
			Me.txtMessage.Size = New System.Drawing.Size(383, 269)
			Me.txtMessage.TabIndex = 0
			' 
			' btnFollowLink
			' 
			Me.btnFollowLink.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnFollowLink.Location = New System.Drawing.Point(396, 201)
			Me.btnFollowLink.Name = "btnFollowLink"
			Me.btnFollowLink.Size = New System.Drawing.Size(128, 24)
			Me.btnFollowLink.TabIndex = 8
			Me.btnFollowLink.Text = "Follow &Link"
			Me.btnFollowLink.Visible = False
'			Me.btnFollowLink.Click += New System.EventHandler(Me.btnFollowLink_Click)
			' 
			' btnSkipAll
			' 
			Me.btnSkipAll.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnSkipAll.Location = New System.Drawing.Point(396, 171)
			Me.btnSkipAll.Name = "btnSkipAll"
			Me.btnSkipAll.Size = New System.Drawing.Size(128, 24)
			Me.btnSkipAll.TabIndex = 7
			Me.btnSkipAll.Text = "S&kip All"
			Me.btnSkipAll.Visible = False
'			Me.btnSkipAll.Click += New System.EventHandler(Me.btnSkipAll_Click)
			' 
			' btnOverwriteDiffSize
			' 
			Me.btnOverwriteDiffSize.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnOverwriteDiffSize.Location = New System.Drawing.Point(396, 90)
			Me.btnOverwriteDiffSize.Name = "btnOverwriteDiffSize"
			Me.btnOverwriteDiffSize.Size = New System.Drawing.Size(128, 24)
			Me.btnOverwriteDiffSize.TabIndex = 4
			Me.btnOverwriteDiffSize.Text = "Overwrite &Different Files"
			Me.btnOverwriteDiffSize.Visible = False
'			Me.btnOverwriteDiffSize.Click += New System.EventHandler(Me.btnOverwriteDiffSize_Click)
			' 
			' btnOverwriteOlder
			' 
			Me.btnOverwriteOlder.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnOverwriteOlder.Location = New System.Drawing.Point(396, 62)
			Me.btnOverwriteOlder.Name = "btnOverwriteOlder"
			Me.btnOverwriteOlder.Size = New System.Drawing.Size(128, 24)
			Me.btnOverwriteOlder.TabIndex = 3
			Me.btnOverwriteOlder.Text = "Overwrite &Older Files"
			Me.btnOverwriteOlder.Visible = False
'			Me.btnOverwriteOlder.Click += New System.EventHandler(Me.btnOverwriteOlder_Click)
			' 
			' btnOverwriteAll
			' 
			Me.btnOverwriteAll.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnOverwriteAll.Location = New System.Drawing.Point(396, 34)
			Me.btnOverwriteAll.Name = "btnOverwriteAll"
			Me.btnOverwriteAll.Size = New System.Drawing.Size(128, 24)
			Me.btnOverwriteAll.TabIndex = 2
			Me.btnOverwriteAll.Text = "Overwrite &All"
			Me.btnOverwriteAll.Visible = False
'			Me.btnOverwriteAll.Click += New System.EventHandler(Me.btnOverwriteAll_Click)
			' 
			' btnOverwrite
			' 
			Me.btnOverwrite.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnOverwrite.Location = New System.Drawing.Point(396, 7)
			Me.btnOverwrite.Name = "btnOverwrite"
			Me.btnOverwrite.Size = New System.Drawing.Size(128, 24)
			Me.btnOverwrite.TabIndex = 1
			Me.btnOverwrite.Text = "&Overwrite"
			Me.btnOverwrite.Visible = False
'			Me.btnOverwrite.Click += New System.EventHandler(Me.btnOverwrite_Click)
			' 
			' btnRetry
			' 
			Me.btnRetry.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnRetry.Location = New System.Drawing.Point(396, 227)
			Me.btnRetry.Name = "btnRetry"
			Me.btnRetry.Size = New System.Drawing.Size(128, 24)
			Me.btnRetry.TabIndex = 9
			Me.btnRetry.Text = "Re&try"
			Me.btnRetry.Visible = False
'			Me.btnRetry.Click += New System.EventHandler(Me.btnRetry_Click)
			' 
			' btnRename
			' 
			Me.btnRename.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnRename.Location = New System.Drawing.Point(396, 118)
			Me.btnRename.Name = "btnRename"
			Me.btnRename.Size = New System.Drawing.Size(128, 24)
			Me.btnRename.TabIndex = 5
			Me.btnRename.Text = "&Rename..."
			Me.btnRename.Visible = False
'			Me.btnRename.Click += New System.EventHandler(Me.btnRename_Click)
			' 
			' btnSkip
			' 
			Me.btnSkip.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnSkip.Location = New System.Drawing.Point(396, 146)
			Me.btnSkip.Name = "btnSkip"
			Me.btnSkip.Size = New System.Drawing.Size(128, 24)
			Me.btnSkip.TabIndex = 6
			Me.btnSkip.Text = "&Skip"
			Me.btnSkip.Visible = False
'			Me.btnSkip.Click += New System.EventHandler(Me.btnSkip_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnCancel.Location = New System.Drawing.Point(396, 253)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(128, 24)
			Me.btnCancel.TabIndex = 10
			Me.btnCancel.Text = "&Cancel"
			Me.btnCancel.Visible = False
'			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click)
			' 
			' FileOperation
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(530, 286)
			Me.Controls.Add(Me.btnFollowLink)
			Me.Controls.Add(Me.btnSkipAll)
			Me.Controls.Add(Me.btnOverwriteDiffSize)
			Me.Controls.Add(Me.btnOverwriteOlder)
			Me.Controls.Add(Me.btnOverwriteAll)
			Me.Controls.Add(Me.btnOverwrite)
			Me.Controls.Add(Me.btnRetry)
			Me.Controls.Add(Me.btnRename)
			Me.Controls.Add(Me.btnSkip)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.txtMessage)
			Me.MinimumSize = New System.Drawing.Size(464, 313)
			Me.Name = "FileOperation"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "File Operation"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private txtMessage As System.Windows.Forms.TextBox
		Private WithEvents btnFollowLink As System.Windows.Forms.Button
		Private WithEvents btnSkipAll As System.Windows.Forms.Button
		Private WithEvents btnOverwriteDiffSize As System.Windows.Forms.Button
		Private WithEvents btnOverwriteOlder As System.Windows.Forms.Button
		Private WithEvents btnOverwriteAll As System.Windows.Forms.Button
		Private WithEvents btnOverwrite As System.Windows.Forms.Button
		Private WithEvents btnRetry As System.Windows.Forms.Button
		Private WithEvents btnRename As System.Windows.Forms.Button
		Private WithEvents btnSkip As System.Windows.Forms.Button
		Private WithEvents btnCancel As System.Windows.Forms.Button
	End Class
End Namespace