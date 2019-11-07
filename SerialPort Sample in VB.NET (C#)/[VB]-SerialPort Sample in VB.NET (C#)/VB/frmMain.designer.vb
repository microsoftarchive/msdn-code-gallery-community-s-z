<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label_port = New System.Windows.Forms.Label
        Me.tbRx = New System.Windows.Forms.TextBox
        Me.tbTx = New System.Windows.Forms.TextBox
        Me.btnSend = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.Label_Rx = New System.Windows.Forms.Label
        Me.Label_TX = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.cboComPort = New System.Windows.Forms.ComboBox
        Me.Label_Baud = New System.Windows.Forms.Label
        Me.cboBaudRate = New System.Windows.Forms.ComboBox
        Me.Label_COMasigns = New System.Windows.Forms.Label
        Me.btnComOpen = New System.Windows.Forms.Button
        Me.btnComClose = New System.Windows.Forms.Button
        Me.picOpen = New System.Windows.Forms.PictureBox
        Me.Label_scale = New System.Windows.Forms.Label
        Me.picDataReceived = New System.Windows.Forms.PictureBox
        Me.Label_CCecho = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.ButtonE = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button0 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.ButtonC = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        CType(Me.picOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDataReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM2"
        Me.SerialPort1.ReceivedBytesThreshold = 30
        '
        'Label_port
        '
        Me.Label_port.AutoSize = True
        Me.Label_port.Location = New System.Drawing.Point(1, 9)
        Me.Label_port.Name = "Label_port"
        Me.Label_port.Size = New System.Drawing.Size(32, 13)
        Me.Label_port.TabIndex = 0
        Me.Label_port.Text = "Port :"
        '
        'tbRx
        '
        Me.tbRx.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRx.Location = New System.Drawing.Point(31, 48)
        Me.tbRx.Name = "tbRx"
        Me.tbRx.Size = New System.Drawing.Size(605, 26)
        Me.tbRx.TabIndex = 1
        '
        'tbTx
        '
        Me.tbTx.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTx.Location = New System.Drawing.Point(30, 80)
        Me.tbTx.Name = "tbTx"
        Me.tbTx.Size = New System.Drawing.Size(606, 26)
        Me.tbTx.TabIndex = 2
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(32, 112)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(95, 20)
        Me.btnSend.TabIndex = 3
        Me.btnSend.Text = "send TX Box"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(133, 112)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(105, 20)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label_Rx
        '
        Me.Label_Rx.AutoSize = True
        Me.Label_Rx.Location = New System.Drawing.Point(3, 54)
        Me.Label_Rx.Name = "Label_Rx"
        Me.Label_Rx.Size = New System.Drawing.Size(22, 13)
        Me.Label_Rx.TabIndex = 5
        Me.Label_Rx.Text = "RX"
        '
        'Label_TX
        '
        Me.Label_TX.AutoSize = True
        Me.Label_TX.Location = New System.Drawing.Point(1, 86)
        Me.Label_TX.Name = "Label_TX"
        Me.Label_TX.Size = New System.Drawing.Size(21, 13)
        Me.Label_TX.TabIndex = 6
        Me.Label_TX.Text = "TX"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(246, 112)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(108, 20)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'cboComPort
        '
        Me.cboComPort.FormattingEnabled = True
        Me.cboComPort.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4"})
        Me.cboComPort.Location = New System.Drawing.Point(32, 6)
        Me.cboComPort.Name = "cboComPort"
        Me.cboComPort.Size = New System.Drawing.Size(65, 21)
        Me.cboComPort.TabIndex = 8
        '
        'Label_Baud
        '
        Me.Label_Baud.AutoSize = True
        Me.Label_Baud.Location = New System.Drawing.Point(103, 9)
        Me.Label_Baud.Name = "Label_Baud"
        Me.Label_Baud.Size = New System.Drawing.Size(32, 13)
        Me.Label_Baud.TabIndex = 9
        Me.Label_Baud.Text = "Baud"
        '
        'cboBaudRate
        '
        Me.cboBaudRate.FormattingEnabled = True
        Me.cboBaudRate.Items.AddRange(New Object() {"9600", "38400", "115200"})
        Me.cboBaudRate.Location = New System.Drawing.Point(141, 6)
        Me.cboBaudRate.Name = "cboBaudRate"
        Me.cboBaudRate.Size = New System.Drawing.Size(66, 21)
        Me.cboBaudRate.TabIndex = 10
        '
        'Label_COMasigns
        '
        Me.Label_COMasigns.AutoSize = True
        Me.Label_COMasigns.Location = New System.Drawing.Point(213, 9)
        Me.Label_COMasigns.Name = "Label_COMasigns"
        Me.Label_COMasigns.Size = New System.Drawing.Size(27, 13)
        Me.Label_COMasigns.TabIndex = 11
        Me.Label_COMasigns.Text = "8N1"
        '
        'btnComOpen
        '
        Me.btnComOpen.Location = New System.Drawing.Point(246, 7)
        Me.btnComOpen.Name = "btnComOpen"
        Me.btnComOpen.Size = New System.Drawing.Size(89, 20)
        Me.btnComOpen.TabIndex = 12
        Me.btnComOpen.Text = "Open Port"
        Me.btnComOpen.UseVisualStyleBackColor = True
        '
        'btnComClose
        '
        Me.btnComClose.Location = New System.Drawing.Point(341, 7)
        Me.btnComClose.Name = "btnComClose"
        Me.btnComClose.Size = New System.Drawing.Size(81, 20)
        Me.btnComClose.TabIndex = 13
        Me.btnComClose.Text = "Close Port"
        Me.btnComClose.UseVisualStyleBackColor = True
        '
        'picOpen
        '
        Me.picOpen.BackColor = System.Drawing.SystemColors.Control
        Me.picOpen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picOpen.InitialImage = CType(resources.GetObject("picOpen.InitialImage"), System.Drawing.Image)
        Me.picOpen.Location = New System.Drawing.Point(437, 7)
        Me.picOpen.Name = "picOpen"
        Me.picOpen.Size = New System.Drawing.Size(20, 20)
        Me.picOpen.TabIndex = 14
        Me.picOpen.TabStop = False
        '
        'Label_scale
        '
        Me.Label_scale.AutoSize = True
        Me.Label_scale.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_scale.Location = New System.Drawing.Point(28, 30)
        Me.Label_scale.Name = "Label_scale"
        Me.Label_scale.Size = New System.Drawing.Size(608, 18)
        Me.Label_scale.TabIndex = 15
        Me.Label_scale.Text = "....|....1....|....2....|....3....|....4....|....5....|....6"
        '
        'picDataReceived
        '
        Me.picDataReceived.BackColor = System.Drawing.SystemColors.Control
        Me.picDataReceived.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picDataReceived.InitialImage = CType(resources.GetObject("picDataReceived.InitialImage"), System.Drawing.Image)
        Me.picDataReceived.Location = New System.Drawing.Point(619, 7)
        Me.picDataReceived.Name = "picDataReceived"
        Me.picDataReceived.Size = New System.Drawing.Size(20, 20)
        Me.picDataReceived.TabIndex = 16
        Me.picDataReceived.TabStop = False
        '
        'Label_CCecho
        '
        Me.Label_CCecho.AutoSize = True
        Me.Label_CCecho.Location = New System.Drawing.Point(539, 9)
        Me.Label_CCecho.Name = "Label_CCecho"
        Me.Label_CCecho.Size = New System.Drawing.Size(74, 13)
        Me.Label_CCecho.TabIndex = 17
        Me.Label_CCecho.Text = "dataReceived"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.ButtonE)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button0)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.ButtonC)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.Button9)
        Me.GroupBox1.Location = New System.Drawing.Point(653, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(86, 122)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "send Char"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(34, 44)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(20, 20)
        Me.Button5.TabIndex = 22
        Me.Button5.Text = "5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ButtonE
        '
        Me.ButtonE.Location = New System.Drawing.Point(60, 96)
        Me.ButtonE.Name = "ButtonE"
        Me.ButtonE.Size = New System.Drawing.Size(20, 20)
        Me.ButtonE.TabIndex = 29
        Me.ButtonE.Text = "E"
        Me.ButtonE.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(34, 18)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(20, 20)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(8, 44)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(20, 20)
        Me.Button4.TabIndex = 20
        Me.Button4.Text = "4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button0
        '
        Me.Button0.Location = New System.Drawing.Point(34, 96)
        Me.Button0.Name = "Button0"
        Me.Button0.Size = New System.Drawing.Size(20, 20)
        Me.Button0.TabIndex = 28
        Me.Button0.Text = "0"
        Me.Button0.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(60, 18)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(20, 20)
        Me.Button3.TabIndex = 21
        Me.Button3.Text = "3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(60, 44)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(20, 20)
        Me.Button6.TabIndex = 23
        Me.Button6.Text = "6"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'ButtonC
        '
        Me.ButtonC.Location = New System.Drawing.Point(8, 96)
        Me.ButtonC.Name = "ButtonC"
        Me.ButtonC.Size = New System.Drawing.Size(20, 20)
        Me.ButtonC.TabIndex = 27
        Me.ButtonC.Text = "C"
        Me.ButtonC.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(8, 70)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(20, 20)
        Me.Button7.TabIndex = 24
        Me.Button7.Text = "7"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Button8.Location = New System.Drawing.Point(34, 70)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(20, 20)
        Me.Button8.TabIndex = 25
        Me.Button8.Text = "8"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(60, 70)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(20, 20)
        Me.Button9.TabIndex = 26
        Me.Button9.Text = "9"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 137)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label_CCecho)
        Me.Controls.Add(Me.picDataReceived)
        Me.Controls.Add(Me.Label_scale)
        Me.Controls.Add(Me.picOpen)
        Me.Controls.Add(Me.btnComClose)
        Me.Controls.Add(Me.btnComOpen)
        Me.Controls.Add(Me.Label_COMasigns)
        Me.Controls.Add(Me.cboBaudRate)
        Me.Controls.Add(Me.Label_Baud)
        Me.Controls.Add(Me.cboComPort)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label_TX)
        Me.Controls.Add(Me.Label_Rx)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.tbTx)
        Me.Controls.Add(Me.tbRx)
        Me.Controls.Add(Me.Label_port)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "mainForm"
        Me.Text = "SerialPort Demo "
        CType(Me.picOpen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDataReceived, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_port As System.Windows.Forms.Label
    Friend WithEvents tbTx As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label_Rx As System.Windows.Forms.Label
    Friend WithEvents Label_TX As System.Windows.Forms.Label
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Public WithEvents tbRx As System.Windows.Forms.TextBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents cboComPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Baud As System.Windows.Forms.Label
    Friend WithEvents cboBaudRate As System.Windows.Forms.ComboBox
    Friend WithEvents Label_COMasigns As System.Windows.Forms.Label
    Friend WithEvents btnComOpen As System.Windows.Forms.Button
    Friend WithEvents btnComClose As System.Windows.Forms.Button
    Friend WithEvents picOpen As System.Windows.Forms.PictureBox
    Friend WithEvents Label_scale As System.Windows.Forms.Label
    Friend WithEvents picDataReceived As System.Windows.Forms.PictureBox
    Friend WithEvents Label_CCecho As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ButtonE As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button0 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents ButtonC As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
End Class
