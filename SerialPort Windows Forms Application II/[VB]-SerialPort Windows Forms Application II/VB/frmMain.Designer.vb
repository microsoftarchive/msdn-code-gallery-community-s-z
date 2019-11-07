<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label_port = New System.Windows.Forms.Label
        Me.btn_Richtextbox_clear = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.cboPort = New System.Windows.Forms.ComboBox
        Me.Label_Baud = New System.Windows.Forms.Label
        Me.cboBaud = New System.Windows.Forms.ComboBox
        Me.Label_COMasigns = New System.Windows.Forms.Label
        Me.btnOpenPort = New System.Windows.Forms.Button
        Me.btnClosePort = New System.Windows.Forms.Button
        Me.pbxStatePort = New System.Windows.Forms.PictureBox
        Me.Label_scale = New System.Windows.Forms.Label
        Me.pbxDataReceived = New System.Windows.Forms.PictureBox
        Me.Label_CCecho = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.rtbRX = New System.Windows.Forms.RichTextBox
        Me.lblTime = New System.Windows.Forms.Label
        Me.btn1 = New System.Windows.Forms.Button
        Me.btn2 = New System.Windows.Forms.Button
        Me.btn4 = New System.Windows.Forms.Button
        Me.btn3 = New System.Windows.Forms.Button
        Me.btn5 = New System.Windows.Forms.Button
        Me.btn6 = New System.Windows.Forms.Button
        Me.btn7 = New System.Windows.Forms.Button
        Me.btn8 = New System.Windows.Forms.Button
        Me.btn9 = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.btn0 = New System.Windows.Forms.Button
        Me.btnEnter = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.btnLoadSettings = New System.Windows.Forms.Button
        Me.chkLog1min = New System.Windows.Forms.CheckBox
        Me.chkLogON = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        CType(Me.pbxStatePort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxDataReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM2"
        '
        'Label_port
        '
        Me.Label_port.AutoSize = True
        Me.Label_port.Location = New System.Drawing.Point(9, 22)
        Me.Label_port.Name = "Label_port"
        Me.Label_port.Size = New System.Drawing.Size(32, 13)
        Me.Label_port.TabIndex = 0
        Me.Label_port.Text = "Port :"
        '
        'btn_Richtextbox_clear
        '
        Me.btn_Richtextbox_clear.Location = New System.Drawing.Point(579, 63)
        Me.btn_Richtextbox_clear.Name = "btn_Richtextbox_clear"
        Me.btn_Richtextbox_clear.Size = New System.Drawing.Size(44, 20)
        Me.btn_Richtextbox_clear.TabIndex = 4
        Me.btn_Richtextbox_clear.Text = "Clear"
        Me.btn_Richtextbox_clear.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(559, 35)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(84, 20)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'cboPort
        '
        Me.cboPort.FormattingEnabled = True
        Me.cboPort.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4"})
        Me.cboPort.Location = New System.Drawing.Point(40, 19)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Size = New System.Drawing.Size(65, 21)
        Me.cboPort.TabIndex = 8
        '
        'Label_Baud
        '
        Me.Label_Baud.AutoSize = True
        Me.Label_Baud.Location = New System.Drawing.Point(111, 22)
        Me.Label_Baud.Name = "Label_Baud"
        Me.Label_Baud.Size = New System.Drawing.Size(32, 13)
        Me.Label_Baud.TabIndex = 9
        Me.Label_Baud.Text = "Baud"
        '
        'cboBaud
        '
        Me.cboBaud.FormattingEnabled = True
        Me.cboBaud.Items.AddRange(New Object() {"9600", "38400", "115200"})
        Me.cboBaud.Location = New System.Drawing.Point(149, 19)
        Me.cboBaud.Name = "cboBaud"
        Me.cboBaud.Size = New System.Drawing.Size(66, 21)
        Me.cboBaud.TabIndex = 10
        '
        'Label_COMasigns
        '
        Me.Label_COMasigns.AutoSize = True
        Me.Label_COMasigns.Location = New System.Drawing.Point(221, 22)
        Me.Label_COMasigns.Name = "Label_COMasigns"
        Me.Label_COMasigns.Size = New System.Drawing.Size(27, 13)
        Me.Label_COMasigns.TabIndex = 11
        Me.Label_COMasigns.Text = "8N1"
        '
        'btnOpenPort
        '
        Me.btnOpenPort.Location = New System.Drawing.Point(245, 19)
        Me.btnOpenPort.Name = "btnOpenPort"
        Me.btnOpenPort.Size = New System.Drawing.Size(47, 20)
        Me.btnOpenPort.TabIndex = 12
        Me.btnOpenPort.Text = "Open"
        Me.btnOpenPort.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOpenPort.UseVisualStyleBackColor = True
        '
        'btnClosePort
        '
        Me.btnClosePort.CausesValidation = False
        Me.btnClosePort.Location = New System.Drawing.Point(298, 19)
        Me.btnClosePort.Name = "btnClosePort"
        Me.btnClosePort.Size = New System.Drawing.Size(47, 20)
        Me.btnClosePort.TabIndex = 13
        Me.btnClosePort.Text = "Close"
        Me.btnClosePort.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnClosePort.UseVisualStyleBackColor = True
        '
        'pbxStatePort
        '
        Me.pbxStatePort.BackColor = System.Drawing.SystemColors.Control
        Me.pbxStatePort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbxStatePort.InitialImage = CType(resources.GetObject("pbxStatePort.InitialImage"), System.Drawing.Image)
        Me.pbxStatePort.Location = New System.Drawing.Point(409, 19)
        Me.pbxStatePort.Name = "pbxStatePort"
        Me.pbxStatePort.Size = New System.Drawing.Size(20, 20)
        Me.pbxStatePort.TabIndex = 14
        Me.pbxStatePort.TabStop = False
        '
        'Label_scale
        '
        Me.Label_scale.AutoSize = True
        Me.Label_scale.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_scale.Location = New System.Drawing.Point(5, 19)
        Me.Label_scale.Name = "Label_scale"
        Me.Label_scale.Size = New System.Drawing.Size(568, 16)
        Me.Label_scale.TabIndex = 15
        Me.Label_scale.Text = "....|....1....|....2....|....3....|....4....|....5....|....6....|....7"
        '
        'pbxDataReceived
        '
        Me.pbxDataReceived.BackColor = System.Drawing.SystemColors.Control
        Me.pbxDataReceived.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbxDataReceived.Location = New System.Drawing.Point(480, 19)
        Me.pbxDataReceived.Name = "pbxDataReceived"
        Me.pbxDataReceived.Size = New System.Drawing.Size(20, 20)
        Me.pbxDataReceived.TabIndex = 16
        Me.pbxDataReceived.TabStop = False
        '
        'Label_CCecho
        '
        Me.Label_CCecho.AutoSize = True
        Me.Label_CCecho.Location = New System.Drawing.Point(444, 22)
        Me.Label_CCecho.Name = "Label_CCecho"
        Me.Label_CCecho.Size = New System.Drawing.Size(30, 13)
        Me.Label_CCecho.TabIndex = 17
        Me.Label_CCecho.Text = "Data"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'rtbRX
        '
        Me.rtbRX.BackColor = System.Drawing.SystemColors.ControlLight
        Me.rtbRX.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbRX.Location = New System.Drawing.Point(6, 38)
        Me.rtbRX.Name = "rtbRX"
        Me.rtbRX.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtbRX.Size = New System.Drawing.Size(567, 72)
        Me.rtbRX.TabIndex = 31
        Me.rtbRX.Text = ""
        '
        'lblTime
        '
        Me.lblTime.BackColor = System.Drawing.Color.Azure
        Me.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTime.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(14, 20)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(83, 21)
        Me.lblTime.TabIndex = 34
        Me.lblTime.Text = "00:00"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(18, 20)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(20, 20)
        Me.btn1.TabIndex = 18
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'btn2
        '
        Me.btn2.Location = New System.Drawing.Point(44, 20)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(20, 20)
        Me.btn2.TabIndex = 19
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'btn4
        '
        Me.btn4.Location = New System.Drawing.Point(18, 46)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(20, 20)
        Me.btn4.TabIndex = 20
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = True
        '
        'btn3
        '
        Me.btn3.Location = New System.Drawing.Point(70, 20)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(20, 20)
        Me.btn3.TabIndex = 21
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = True
        '
        'btn5
        '
        Me.btn5.Location = New System.Drawing.Point(44, 45)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(20, 20)
        Me.btn5.TabIndex = 22
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = True
        '
        'btn6
        '
        Me.btn6.Location = New System.Drawing.Point(70, 46)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(20, 20)
        Me.btn6.TabIndex = 23
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = True
        '
        'btn7
        '
        Me.btn7.Location = New System.Drawing.Point(18, 72)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(20, 20)
        Me.btn7.TabIndex = 24
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = True
        '
        'btn8
        '
        Me.btn8.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btn8.Location = New System.Drawing.Point(44, 71)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(20, 20)
        Me.btn8.TabIndex = 25
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = True
        '
        'btn9
        '
        Me.btn9.Location = New System.Drawing.Point(70, 72)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(20, 20)
        Me.btn9.TabIndex = 26
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(18, 98)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(20, 20)
        Me.btnClear.TabIndex = 27
        Me.btnClear.Text = "C"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btn0
        '
        Me.btn0.Location = New System.Drawing.Point(44, 97)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(20, 20)
        Me.btn0.TabIndex = 28
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = True
        '
        'btnEnter
        '
        Me.btnEnter.Location = New System.Drawing.Point(70, 98)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(20, 20)
        Me.btnEnter.TabIndex = 29
        Me.btnEnter.Text = "E"
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnEnter)
        Me.GroupBox1.Controls.Add(Me.btn0)
        Me.GroupBox1.Controls.Add(Me.btnClear)
        Me.GroupBox1.Controls.Add(Me.btn9)
        Me.GroupBox1.Controls.Add(Me.btn8)
        Me.GroupBox1.Controls.Add(Me.btn7)
        Me.GroupBox1.Controls.Add(Me.btn6)
        Me.GroupBox1.Controls.Add(Me.btn5)
        Me.GroupBox1.Controls.Add(Me.btn3)
        Me.GroupBox1.Controls.Add(Me.btn4)
        Me.GroupBox1.Controls.Add(Me.btn2)
        Me.GroupBox1.Controls.Add(Me.btn1)
        Me.GroupBox1.Location = New System.Drawing.Point(770, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(108, 128)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "send char to MCU"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(351, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Portstate:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(579, 38)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSave.Size = New System.Drawing.Size(44, 20)
        Me.btnSave.TabIndex = 38
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnLoadSettings
        '
        Me.btnLoadSettings.CausesValidation = False
        Me.btnLoadSettings.Location = New System.Drawing.Point(559, 9)
        Me.btnLoadSettings.Name = "btnLoadSettings"
        Me.btnLoadSettings.Size = New System.Drawing.Size(84, 20)
        Me.btnLoadSettings.TabIndex = 39
        Me.btnLoadSettings.Text = "load settings"
        Me.btnLoadSettings.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnLoadSettings.UseVisualStyleBackColor = True
        '
        'chkLog1min
        '
        Me.chkLog1min.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkLog1min.Location = New System.Drawing.Point(14, 32)
        Me.chkLog1min.Name = "chkLog1min"
        Me.chkLog1min.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkLog1min.Size = New System.Drawing.Size(83, 19)
        Me.chkLog1min.TabIndex = 40
        Me.chkLog1min.Text = "every 1min"
        Me.chkLog1min.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkLog1min.UseVisualStyleBackColor = True
        '
        'chkLogON
        '
        Me.chkLogON.AutoSize = True
        Me.chkLogON.Location = New System.Drawing.Point(14, 17)
        Me.chkLogON.Name = "chkLogON"
        Me.chkLogON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkLogON.Size = New System.Drawing.Size(59, 17)
        Me.chkLogON.TabIndex = 41
        Me.chkLogON.Text = "log ON"
        Me.chkLogON.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblTime)
        Me.GroupBox2.Location = New System.Drawing.Point(661, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(103, 52)
        Me.GroupBox2.TabIndex = 42
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "MCU time"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkLogON)
        Me.GroupBox3.Controls.Add(Me.chkLog1min)
        Me.GroupBox3.Location = New System.Drawing.Point(661, 67)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(103, 54)
        Me.GroupBox3.TabIndex = 43
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Log data options"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnClosePort)
        Me.GroupBox4.Controls.Add(Me.Label_port)
        Me.GroupBox4.Controls.Add(Me.cboPort)
        Me.GroupBox4.Controls.Add(Me.Label_Baud)
        Me.GroupBox4.Controls.Add(Me.cboBaud)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label_COMasigns)
        Me.GroupBox4.Controls.Add(Me.btnOpenPort)
        Me.GroupBox4.Controls.Add(Me.pbxStatePort)
        Me.GroupBox4.Controls.Add(Me.Label_CCecho)
        Me.GroupBox4.Controls.Add(Me.pbxDataReceived)
        Me.GroupBox4.Location = New System.Drawing.Point(14, 9)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(520, 54)
        Me.GroupBox4.TabIndex = 44
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "ComPort"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rtbRX)
        Me.GroupBox5.Controls.Add(Me.btn_Richtextbox_clear)
        Me.GroupBox5.Controls.Add(Me.Label_scale)
        Me.GroupBox5.Controls.Add(Me.btnSave)
        Me.GroupBox5.Location = New System.Drawing.Point(14, 80)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(629, 127)
        Me.GroupBox5.TabIndex = 45
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Visualize data box"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(900, 514)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnLoadSettings)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(600, 300)
        Me.Name = "MainForm"
        Me.Text = "ComPort Sample II - Ellen Ramcke 2012"
        CType(Me.pbxStatePort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxDataReceived, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label_port As System.Windows.Forms.Label
    Friend WithEvents btn_Richtextbox_clear As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents cboPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Baud As System.Windows.Forms.Label
    Friend WithEvents cboBaud As System.Windows.Forms.ComboBox
    Friend WithEvents Label_COMasigns As System.Windows.Forms.Label
    Friend WithEvents btnOpenPort As System.Windows.Forms.Button
    Friend WithEvents btnClosePort As System.Windows.Forms.Button
    Friend WithEvents pbxStatePort As System.Windows.Forms.PictureBox
    Friend WithEvents Label_scale As System.Windows.Forms.Label
    Friend WithEvents pbxDataReceived As System.Windows.Forms.PictureBox
    Friend WithEvents Label_CCecho As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents rtbRX As System.Windows.Forms.RichTextBox
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btn0 As System.Windows.Forms.Button
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnLoadSettings As System.Windows.Forms.Button
    Friend WithEvents chkLog1min As System.Windows.Forms.CheckBox
    Friend WithEvents chkLogON As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
End Class
