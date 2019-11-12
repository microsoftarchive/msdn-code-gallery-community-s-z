Namespace ChatApp.Forms
	Partial Public Class FrmClient
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
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.rtbConOut = New System.Windows.Forms.RichTextBox()
			Me.panel2 = New System.Windows.Forms.Panel()
			Me.btnSend = New System.Windows.Forms.Button()
			Me.tbInput = New System.Windows.Forms.TextBox()
			Me.panel1.SuspendLayout()
			Me.panel2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' panel1
			' 
			Me.panel1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.panel1.Controls.Add(Me.rtbConOut)
			Me.panel1.Location = New System.Drawing.Point(0, 0)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(365, 177)
			Me.panel1.TabIndex = 0
			' 
			' rtbConOut
			' 
			Me.rtbConOut.Dock = System.Windows.Forms.DockStyle.Fill
			Me.rtbConOut.Location = New System.Drawing.Point(0, 0)
			Me.rtbConOut.Name = "rtbConOut"
			Me.rtbConOut.ShowSelectionMargin = True
			Me.rtbConOut.Size = New System.Drawing.Size(365, 177)
			Me.rtbConOut.TabIndex = 0
			Me.rtbConOut.Text = ""
			' 
			' panel2
			' 
			Me.panel2.Controls.Add(Me.btnSend)
			Me.panel2.Controls.Add(Me.tbInput)
			Me.panel2.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel2.Location = New System.Drawing.Point(0, 179)
			Me.panel2.Name = "panel2"
			Me.panel2.Size = New System.Drawing.Size(365, 46)
			Me.panel2.TabIndex = 1
			' 
			' btnSend
			' 
			Me.btnSend.Dock = System.Windows.Forms.DockStyle.Right
			Me.btnSend.Location = New System.Drawing.Point(286, 0)
			Me.btnSend.Name = "btnSend"
			Me.btnSend.Size = New System.Drawing.Size(79, 46)
			Me.btnSend.TabIndex = 1
			Me.btnSend.Text = "Send"
			Me.btnSend.UseVisualStyleBackColor = True
'			Me.btnSend.Click += New System.EventHandler(Me.BtnSendClick)
			' 
			' tbInput
			' 
			Me.tbInput.Dock = System.Windows.Forms.DockStyle.Left
			Me.tbInput.Location = New System.Drawing.Point(0, 0)
			Me.tbInput.Multiline = True
			Me.tbInput.Name = "tbInput"
			Me.tbInput.Size = New System.Drawing.Size(280, 46)
			Me.tbInput.TabIndex = 0
'			Me.tbInput.KeyUp += New System.Windows.Forms.KeyEventHandler(Me.TbInputKeyUp)
			' 
			' FrmClient
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(365, 225)
			Me.Controls.Add(Me.panel2)
			Me.Controls.Add(Me.panel1)
			Me.Name = "FrmClient"
			Me.Text = "FrmClient"
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.FrmClient_FormClosing)
'			Me.Load += New System.EventHandler(Me.FrmClient_Load)
			Me.panel1.ResumeLayout(False)
			Me.panel2.ResumeLayout(False)
			Me.panel2.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private panel1 As System.Windows.Forms.Panel
		Private rtbConOut As System.Windows.Forms.RichTextBox
		Private panel2 As System.Windows.Forms.Panel
		Private WithEvents btnSend As System.Windows.Forms.Button
		Private WithEvents tbInput As System.Windows.Forms.TextBox
	End Class
End Namespace