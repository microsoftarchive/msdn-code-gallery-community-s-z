Namespace ChatClient
	Partial Public Class FrmAddFriend
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmAddFriend))
			Me.label1 = New System.Windows.Forms.Label()
			Me.tbFriendsEmailAddress = New System.Windows.Forms.TextBox()
			Me.btnAdd = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(13, 13)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(137, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Your Friend's Email Address"
			' 
			' tbFriendsEmailAddress
			' 
			Me.tbFriendsEmailAddress.Location = New System.Drawing.Point(16, 30)
			Me.tbFriendsEmailAddress.Name = "tbFriendsEmailAddress"
			Me.tbFriendsEmailAddress.Size = New System.Drawing.Size(320, 20)
			Me.tbFriendsEmailAddress.TabIndex = 1
			' 
			' btnAdd
			' 
			Me.btnAdd.Location = New System.Drawing.Point(261, 77)
			Me.btnAdd.Name = "btnAdd"
			Me.btnAdd.Size = New System.Drawing.Size(75, 23)
			Me.btnAdd.TabIndex = 2
			Me.btnAdd.Text = "Add"
			Me.btnAdd.UseVisualStyleBackColor = True
'			Me.btnAdd.Click += New System.EventHandler(Me.btnAdd_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.Location = New System.Drawing.Point(16, 77)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 3
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
'			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click)
			' 
			' FrmAddFriend
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(348, 112)
			Me.ControlBox = False
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnAdd)
			Me.Controls.Add(Me.tbFriendsEmailAddress)
			Me.Controls.Add(Me.label1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.Name = "FrmAddFriend"
			Me.Text = "Add A Friend"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private tbFriendsEmailAddress As System.Windows.Forms.TextBox
		Private WithEvents btnAdd As System.Windows.Forms.Button
		Private WithEvents btnCancel As System.Windows.Forms.Button
	End Class
End Namespace