Partial Class frmPrivate
	''' <summary>
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary>
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(disposing As Boolean)
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
		Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(frmPrivate))
		Me.txtNewMessage = New Proshot.UtilityLib.TextBox()
		Me.lblNewMessage = New Proshot.UtilityLib.Label()
		Me.btnSend = New Proshot.UtilityLib.Button()
		Me.imgList = New System.Windows.Forms.ImageList(Me.components)
		Me.mnuMain = New Proshot.UtilityLib.MenuStrip()
		Me.mniChat = New System.Windows.Forms.ToolStripMenuItem()
		Me.mniSave = New System.Windows.Forms.ToolStripMenuItem()
		Me.mniExit = New System.Windows.Forms.ToolStripMenuItem()
		Me.txtMessages = New System.Windows.Forms.RichTextBox()
		Me.mnuMain.SuspendLayout()
		Me.SuspendLayout()
		' 
		' txtNewMessage
		' 
		Me.txtNewMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtNewMessage.BorderWidth = 1F
		Me.txtNewMessage.FloatValue = 0
		Me.txtNewMessage.Location = New System.Drawing.Point(65, 223)
		Me.txtNewMessage.Name = "txtNewMessage"
		Me.txtNewMessage.Size = New System.Drawing.Size(203, 21)
		Me.txtNewMessage.TabIndex = 1
		' 
		' lblNewMessage
		' 
		Me.lblNewMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblNewMessage.AutoSize = True
		Me.lblNewMessage.BorderWidth = 1F
		Me.lblNewMessage.Location = New System.Drawing.Point(3, 226)
		Me.lblNewMessage.Name = "lblNewMessage"
		Me.lblNewMessage.Size = New System.Drawing.Size(56, 13)
		Me.lblNewMessage.TabIndex = 2
		Me.lblNewMessage.Text = "Message :"
		' 
		' btnSend
		' 
		Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnSend.ImageKey = "SendMessage.ico"
		Me.btnSend.ImageList = Me.imgList
		Me.btnSend.Location = New System.Drawing.Point(276, 222)
		Me.btnSend.Name = "btnSend"
		Me.btnSend.Size = New System.Drawing.Size(67, 23)
		Me.btnSend.TabIndex = 3
		Me.btnSend.Text = "Send"
		Me.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnSend.UseVisualStyleBackColor = True
		AddHandler Me.btnSend.Click, New System.EventHandler(AddressOf Me.btnSend_Click)
		' 
		' imgList
		' 
		Me.imgList.ImageStream = DirectCast(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imgList.TransparentColor = System.Drawing.Color.Transparent
		Me.imgList.Images.SetKeyName(0, "Smiely.ico")
		Me.imgList.Images.SetKeyName(1, "Private.ico")
		Me.imgList.Images.SetKeyName(2, "SendMessage.ico")
		Me.imgList.Images.SetKeyName(3, "Enter.ico")
		Me.imgList.Images.SetKeyName(4, "Exit.ico")
		' 
		' mnuMain
		' 
		Me.mnuMain.BackgroundImage = DirectCast(resources.GetObject("mnuMain.BackgroundImage"), System.Drawing.Image)
		Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniChat})
		Me.mnuMain.Location = New System.Drawing.Point(0, 0)
		Me.mnuMain.Name = "mnuMain"
		Me.mnuMain.Size = New System.Drawing.Size(346, 24)
		Me.mnuMain.TabIndex = 7
		' 
		' mniChat
		' 
		Me.mniChat.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniSave, Me.mniExit})
		Me.mniChat.Name = "mniChat"
		Me.mniChat.Size = New System.Drawing.Size(42, 20)
		Me.mniChat.Text = "Chat"
		' 
		' mniSave
		' 
		Me.mniSave.Image = DirectCast(resources.GetObject("mniSave.Image"), System.Drawing.Image)
		Me.mniSave.Name = "mniSave"
		Me.mniSave.Size = New System.Drawing.Size(152, 22)
		Me.mniSave.Text = "Save"
		AddHandler Me.mniSave.Click, New System.EventHandler(AddressOf Me.mniSave_Click)
		' 
		' mniExit
		' 
		Me.mniExit.Image = DirectCast(resources.GetObject("mniExit.Image"), System.Drawing.Image)
		Me.mniExit.Name = "mniExit"
		Me.mniExit.Size = New System.Drawing.Size(152, 22)
		Me.mniExit.Text = "Exit"
		AddHandler Me.mniExit.Click, New System.EventHandler(AddressOf Me.mniExit_Click)
		' 
		' txtMessages
		' 
		Me.txtMessages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtMessages.Location = New System.Drawing.Point(2, 27)
		Me.txtMessages.Name = "txtMessages"
		Me.txtMessages.Size = New System.Drawing.Size(343, 185)
		Me.txtMessages.TabIndex = 8
		Me.txtMessages.Text = ""
		' 
		' frmPrivate
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(346, 258)
		Me.Controls.Add(Me.txtMessages)
		Me.Controls.Add(Me.btnSend)
		Me.Controls.Add(Me.lblNewMessage)
		Me.Controls.Add(Me.txtNewMessage)
		Me.Controls.Add(Me.mnuMain)
		Me.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(177))
		Me.MinimumSize = New System.Drawing.Size(354, 292)
		Me.Name = "frmPrivate"
		Me.ShowIcon = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Private Chat"
		AddHandler Me.Deactivate, New System.EventHandler(AddressOf Me.frmPrivate_Deactivate)
        'AddHandler Me.Activated, New System.EventHandler(AddressOf Me.frmPrivate_Activated)
		AddHandler Me.FormClosing, New System.Windows.Forms.FormClosingEventHandler(AddressOf Me.frmPrivate_FormClosing)
		AddHandler Me.Load, New System.EventHandler(AddressOf Me.frmPrivate_Load)
		Me.mnuMain.ResumeLayout(False)
		Me.mnuMain.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private txtNewMessage As Proshot.UtilityLib.TextBox
	Private lblNewMessage As Proshot.UtilityLib.Label
	Private btnSend As Proshot.UtilityLib.Button
	Private imgList As System.Windows.Forms.ImageList
	Private mnuMain As Proshot.UtilityLib.MenuStrip
	Private mniChat As System.Windows.Forms.ToolStripMenuItem
	Private mniSave As System.Windows.Forms.ToolStripMenuItem
	Private mniExit As System.Windows.Forms.ToolStripMenuItem
	Private txtMessages As System.Windows.Forms.RichTextBox
End Class

