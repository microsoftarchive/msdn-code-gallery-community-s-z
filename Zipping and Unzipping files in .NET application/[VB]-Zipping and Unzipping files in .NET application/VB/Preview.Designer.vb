Namespace ArchiveManager
	Partial Public Class Preview
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
			Me.lblPlaying = New System.Windows.Forms.Label()
			Me.txtPreview = New System.Windows.Forms.RichTextBox()
			Me.btnClose = New System.Windows.Forms.Button()
			Me.pbPreview = New System.Windows.Forms.PictureBox()
			CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' lblPlaying
			' 
			Me.lblPlaying.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblPlaying.Location = New System.Drawing.Point(170, 7)
			Me.lblPlaying.Name = "lblPlaying"
			Me.lblPlaying.Size = New System.Drawing.Size(99, 13)
			Me.lblPlaying.TabIndex = 7
			Me.lblPlaying.Text = "Playing Audio File..."
			'this.lblPlaying.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			Me.lblPlaying.Visible = False
			' 
			' txtPreview
			' 
			Me.txtPreview.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.txtPreview.Location = New System.Drawing.Point(6, 6)
			Me.txtPreview.Name = "txtPreview"
			Me.txtPreview.Size = New System.Drawing.Size(430, 288)
			Me.txtPreview.TabIndex = 6
			Me.txtPreview.Text = ""
			Me.txtPreview.Visible = False
			' 
			' btnClose
			' 
			Me.btnClose.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnClose.Location = New System.Drawing.Point(360, 300)
			Me.btnClose.Name = "btnClose"
			Me.btnClose.Size = New System.Drawing.Size(75, 23)
			Me.btnClose.TabIndex = 5
			Me.btnClose.Text = "Close"
			' 
			' pbPreview
			' 
			Me.pbPreview.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.pbPreview.Location = New System.Drawing.Point(6, 6)
			Me.pbPreview.Name = "pbPreview"
			Me.pbPreview.Size = New System.Drawing.Size(430, 288)
			Me.pbPreview.TabIndex = 8
			Me.pbPreview.TabStop = False
			Me.pbPreview.Visible = False
			' 
			' Preview
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(440, 330)
			Me.Controls.Add(Me.pbPreview)
			Me.Controls.Add(Me.lblPlaying)
			Me.Controls.Add(Me.txtPreview)
			Me.Controls.Add(Me.btnClose)
			Me.Name = "Preview"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Preview"
			CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private lblPlaying As System.Windows.Forms.Label
		Private txtPreview As System.Windows.Forms.RichTextBox
		Private btnClose As System.Windows.Forms.Button
		Private pbPreview As System.Windows.Forms.PictureBox
	End Class
End Namespace