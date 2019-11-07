<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainChat
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbout = New System.Windows.Forms.ListBox
        Me.tbin = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbx_remoteIP = New System.Windows.Forms.TextBox
        Me.tbx_remotePort = New System.Windows.Forms.TextBox
        Me.tbx_hostPort = New System.Windows.Forms.TextBox
        Me.tbx_hostIP = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btn_Disconnect = New System.Windows.Forms.Button
        Me.btn_Connect = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.StatusLabel_adapter = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusLabel_send = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusLabel_receive = New System.Windows.Forms.ToolStripStatusLabel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btn_clear = New System.Windows.Forms.Button
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbout
        '
        Me.lbout.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbout.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbout.FormattingEnabled = True
        Me.lbout.ItemHeight = 14
        Me.lbout.Location = New System.Drawing.Point(0, 0)
        Me.lbout.MinimumSize = New System.Drawing.Size(359, 228)
        Me.lbout.Name = "lbout"
        Me.lbout.Size = New System.Drawing.Size(454, 228)
        Me.lbout.TabIndex = 0
        '
        'tbin
        '
        Me.tbin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbin.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tbin.Location = New System.Drawing.Point(3, 3)
        Me.tbin.Name = "tbin"
        Me.tbin.Size = New System.Drawing.Size(448, 20)
        Me.tbin.TabIndex = 1
        Me.tbin.Text = "type message here and press <enter>"
        '
        'Label1
        '
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(11, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "remote IP  address"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(11, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "remote Port"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbx_remoteIP
        '
        Me.tbx_remoteIP.Location = New System.Drawing.Point(119, 29)
        Me.tbx_remoteIP.Name = "tbx_remoteIP"
        Me.tbx_remoteIP.Size = New System.Drawing.Size(110, 20)
        Me.tbx_remoteIP.TabIndex = 4
        '
        'tbx_remotePort
        '
        Me.tbx_remotePort.Location = New System.Drawing.Point(119, 53)
        Me.tbx_remotePort.Name = "tbx_remotePort"
        Me.tbx_remotePort.Size = New System.Drawing.Size(110, 20)
        Me.tbx_remotePort.TabIndex = 5
        '
        'tbx_hostPort
        '
        Me.tbx_hostPort.Location = New System.Drawing.Point(119, 103)
        Me.tbx_hostPort.Name = "tbx_hostPort"
        Me.tbx_hostPort.Size = New System.Drawing.Size(110, 20)
        Me.tbx_hostPort.TabIndex = 9
        '
        'tbx_hostIP
        '
        Me.tbx_hostIP.Location = New System.Drawing.Point(119, 79)
        Me.tbx_hostIP.Name = "tbx_hostIP"
        Me.tbx_hostIP.Size = New System.Drawing.Size(110, 20)
        Me.tbx_hostIP.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(11, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "host listening Port"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(11, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "host socket IP"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_Disconnect
        '
        Me.btn_Disconnect.Location = New System.Drawing.Point(245, 89)
        Me.btn_Disconnect.Name = "btn_Disconnect"
        Me.btn_Disconnect.Size = New System.Drawing.Size(105, 25)
        Me.btn_Disconnect.TabIndex = 10
        Me.btn_Disconnect.Text = "disconnect socket"
        Me.btn_Disconnect.UseVisualStyleBackColor = True
        '
        'btn_Connect
        '
        Me.btn_Connect.Location = New System.Drawing.Point(245, 58)
        Me.btn_Connect.Name = "btn_Connect"
        Me.btn_Connect.Size = New System.Drawing.Size(105, 25)
        Me.btn_Connect.TabIndex = 11
        Me.btn_Connect.Text = "connect socket"
        Me.btn_Connect.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel_adapter, Me.StatusLabel_send, Me.StatusLabel_receive})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 371)
        Me.StatusStrip1.MinimumSize = New System.Drawing.Size(361, 22)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(456, 22)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusLabel_adapter
        '
        Me.StatusLabel_adapter.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.StatusLabel_adapter.Image = Global.TCPchat.My.Resources.Resources.ledCornerGray
        Me.StatusLabel_adapter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.StatusLabel_adapter.Name = "StatusLabel_adapter"
        Me.StatusLabel_adapter.Size = New System.Drawing.Size(90, 17)
        Me.StatusLabel_adapter.Text = "adapter name"
        Me.StatusLabel_adapter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusLabel_send
        '
        Me.StatusLabel_send.AutoSize = False
        Me.StatusLabel_send.Image = Global.TCPchat.My.Resources.Resources.ledCornerGray
        Me.StatusLabel_send.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.StatusLabel_send.Name = "StatusLabel_send"
        Me.StatusLabel_send.Size = New System.Drawing.Size(70, 17)
        Me.StatusLabel_send.Text = "send data"
        '
        'StatusLabel_receive
        '
        Me.StatusLabel_receive.AutoSize = False
        Me.StatusLabel_receive.Image = Global.TCPchat.My.Resources.Resources.ledCornerGray
        Me.StatusLabel_receive.Name = "StatusLabel_receive"
        Me.StatusLabel_receive.Size = New System.Drawing.Size(70, 17)
        Me.StatusLabel_receive.Text = "receive"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbout)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_clear)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbx_hostIP)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbin)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_Connect)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn_Disconnect)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbx_remoteIP)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbx_hostPort)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbx_remotePort)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Size = New System.Drawing.Size(456, 371)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 13
        '
        'btn_clear
        '
        Me.btn_clear.Location = New System.Drawing.Point(245, 29)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(105, 23)
        Me.btn_clear.TabIndex = 12
        Me.btn_clear.Text = "clear listbox"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'mainChat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 393)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "mainChat"
        Me.Text = "TCP Chat V1.0 - Ellen Ramcke 2011"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbout As System.Windows.Forms.ListBox
    Friend WithEvents tbin As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbx_remoteIP As System.Windows.Forms.TextBox
    Friend WithEvents tbx_remotePort As System.Windows.Forms.TextBox
    Friend WithEvents tbx_hostPort As System.Windows.Forms.TextBox
    Friend WithEvents tbx_hostIP As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_Disconnect As System.Windows.Forms.Button
    Friend WithEvents btn_Connect As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents StatusLabel_adapter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusLabel_send As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusLabel_receive As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btn_clear As System.Windows.Forms.Button

End Class
