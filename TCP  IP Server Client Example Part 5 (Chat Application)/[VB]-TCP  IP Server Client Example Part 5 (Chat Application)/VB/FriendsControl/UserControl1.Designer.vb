Namespace FriendsControl
	Partial Public Class Friends
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

		#Region "Component Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.pbFriendsImage = New System.Windows.Forms.PictureBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.lblName = New System.Windows.Forms.Label()
			DirectCast(Me.pbFriendsImage, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' pbFriendsImage
			' 
			Me.pbFriendsImage.Dock = System.Windows.Forms.DockStyle.Left
			Me.pbFriendsImage.Location = New System.Drawing.Point(0, 0)
			Me.pbFriendsImage.Name = "pbFriendsImage"
			Me.pbFriendsImage.Size = New System.Drawing.Size(38, 34)
			Me.pbFriendsImage.TabIndex = 0
			Me.pbFriendsImage.TabStop = False
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(44, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(38, 13)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Name:"
			' 
			' lblName
			' 
			Me.lblName.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblName.Location = New System.Drawing.Point(88, 9)
			Me.lblName.Name = "lblName"
			Me.lblName.Size = New System.Drawing.Size(169, 13)
			Me.lblName.TabIndex = 2
			Me.lblName.Text = "..."
			' 
			' Friends
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.Color.Transparent
			Me.Controls.Add(Me.lblName)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.pbFriendsImage)
			Me.Name = "Friends"
			Me.Size = New System.Drawing.Size(260, 34)
			DirectCast(Me.pbFriendsImage, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private pbFriendsImage As System.Windows.Forms.PictureBox
		Private label1 As System.Windows.Forms.Label
		Private lblName As System.Windows.Forms.Label
	End Class
End Namespace
