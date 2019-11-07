Namespace ClientApp
	Partial Public Class Form1
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
			Me.rtbClient = New System.Windows.Forms.RichTextBox()
			Me.SuspendLayout()
			' 
			' rtbClient
			' 
			Me.rtbClient.BackColor = System.Drawing.Color.RoyalBlue
			Me.rtbClient.Dock = System.Windows.Forms.DockStyle.Fill
			Me.rtbClient.Location = New System.Drawing.Point(0, 0)
			Me.rtbClient.Name = "rtbClient"
			Me.rtbClient.Size = New System.Drawing.Size(557, 283)
			Me.rtbClient.TabIndex = 2
			Me.rtbClient.Text = ""
'			Me.rtbClient.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.RtbClientKeyDown)
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(557, 283)
			Me.Controls.Add(Me.rtbClient)
			Me.Name = "Form1"
			Me.Text = "Client"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents rtbClient As System.Windows.Forms.RichTextBox
	End Class
End Namespace

