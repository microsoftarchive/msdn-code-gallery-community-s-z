Option Strict On
Option Infer On
Imports System.Xml.XmlConvert
Imports System.IO
''' <summary>
''' Serial Port demo II 
''' receive telegram from mcu and visualize data
''' </summary>
''' <remarks>update 2012-05-28</remarks>
Public Class MainForm

#Region "object declaratios"

    Private readBuffer As String = String.Empty
    Private StrMessage As String = String.Empty
    Private portname As String
    Private portBaud As Integer
    Private comOpen As Boolean
    Private startup As Boolean = True

    'const values for fields in the form
    Const MwCol As Integer = 4              ' Cols values fields (4 > 5 cols)
    Const MwRow As Integer = 3              ' rows values fields (3 > 4 rows)
    Const IOCol As Integer = 4              ' Cols IO fields (4 > 5 cols)
    Const IORow As Integer = 7              ' rows IO fields (7 > 8 rows)
    Const AnzMw As Integer = (MwCol + 1) * (MwRow + 1)
    Const AnzIO As Integer = (IOCol + 1) * (IORow + 1)

    'fields values & IO
    Private values As List(Of Label)
    Private IOstates As List(Of Label)
    'each field has its own checkbox
    Private Checkbox_values As List(Of CheckBox)
    Private Checkbox_IO As List(Of CheckBox)

#End Region

#Region "init form and close"

    Private Sub Form1_FormClosed(ByVal sender As System.Object, _
                                 ByVal e As System.Windows.Forms.FormClosedEventArgs) _
                                 Handles MyBase.FormClosed
        If comOpen Then SerialPort1.Close()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, _
                        ByVal e As System.EventArgs) _
                        Handles MyBase.Load

        'calculate coordinates of the dynamically created controls
        Const StepY As Integer = 25
        Const stepX As Integer = 170
        Dim xstart As Integer = 105
        Dim ystart As Integer = 210
        Dim xyloc As Point = Point.Empty
        Dim xyloc2 As Point = Point.Empty
        startup = True   ' only true when app starts


        'fields values & IO make instances
        values = New List(Of Label)
        IOstates = New List(Of Label)

        ' Checkboxes instances
        Checkbox_values = New List(Of CheckBox)
        Checkbox_IO = New List(Of CheckBox)

        Dim i As Integer

        Me.lblTime.Text = "--:--"
        Me.rtbRX.AppendText("ready" & vbCr)

        ' available COM ports, set comboboxes
        Dim Portnames As String() = System.IO.Ports.SerialPort.GetPortNames
        If Portnames.Length = 0 Then
            MsgBox("There are no comport detected")
            Me.Close()
            Exit Sub
        End If
        Me.cboPort.Text = Portnames(0)
        Me.cboBaud.Text = "9600"
        Me.cboPort.Items.Clear()
        Me.cboPort.Items.AddRange(Portnames)
        '
        '   create fields (values)
        '
        For n As Integer = 0 To MwCol
            xyloc.Y = ystart
            xyloc.X = xstart + n * stepX

            For m As Integer = 0 To MwRow
                ' 
                values.Add(New Label)
                Checkbox_values.Add(New CheckBox)

                ' coordinates values
                xyloc.Y = ystart + StepY * m
                i = m + (MwCol * n)
                ' coordinates Label
                xyloc2.Y = xyloc.Y
                xyloc2.X = xyloc.X - 105

                'set properties from Me.lblTime
                values(i).AutoSize = Me.lblTime.AutoSize
                values(i).BackColor = Me.lblTime.BackColor
                values(i).BorderStyle = Me.lblTime.BorderStyle
                values(i).Font = Me.lblTime.Font
                values(i).Size = Me.lblTime.Size
                values(i).TextAlign = Me.lblTime.TextAlign
                values(i).Location = xyloc
                values(i).Text = "xx"
                Me.Controls.Add(values(i))

                Checkbox_values(i).AutoSize = False
                Checkbox_values(i).Font = chkLog1min.Font
                Checkbox_values(i).TextAlign = ContentAlignment.MiddleLeft
                Checkbox_values(i).RightToLeft = Windows.Forms.RightToLeft.Yes
                Checkbox_values(i).Location = xyloc2
                Checkbox_values(i).Text = "Value_" & (i + 1).ToString
                Me.Controls.Add(Checkbox_values(i))
            Next
        Next

        ystart = xyloc.Y + 30
        i = 0
        '
        '     ok.. now IO fields:
        '
        For n As Integer = 0 To IOCol
            xyloc.Y = ystart
            xyloc.X = xstart + n * stepX

            For m As Integer = 0 To IORow

                IOstates.Add(New Label)
                Checkbox_IO.Add(New CheckBox)

                ' coordinates
                xyloc.Y = ystart + StepY * m
                i = m + ((IORow + 1) * n)
                xyloc2.Y = xyloc.Y - 1
                xyloc2.X = xyloc.X - 105

                'set properties
                IOstates(i).BackColor = MyBase.BackColor
                IOstates(i).BorderStyle = BorderStyle.None
                IOstates(i).Font = MyBase.Font
                IOstates(i).Size = New Size(20, 20)
                IOstates(i).TextAlign = ContentAlignment.MiddleRight
                IOstates(i).Location = xyloc
                IOstates(i).Image = My.Resources.ledCornerGray
                Me.Controls.Add(IOstates(i))

                Checkbox_IO(i).AutoSize = False
                Checkbox_IO(i).Font = chkLog1min.Font
                Checkbox_IO(i).TextAlign = ContentAlignment.MiddleLeft
                Checkbox_IO(i).RightToLeft = Windows.Forms.RightToLeft.Yes
                Checkbox_IO(i).Location = xyloc2
                Checkbox_IO(i).Text = "IO_bit" & (i + 1).ToString
                Me.Controls.Add(Checkbox_IO(i))
            Next
        Next
        '
        ' ready
        '
        loadSettings("settings.ini")

    End Sub
#End Region

#Region "ComPort"
 
    ''' <summary>
    ''' Button open Port
    ''' </summary>
    Private Sub Button_connect_Click(ByVal sender As System.Object, _
                                     ByVal e As System.EventArgs) _
                                     Handles btnOpenPort.Click
        Try
            ' set device params
            With SerialPort1
                .PortName = cboPort.Text
                .BaudRate = ToInt32(cboBaud.Text)
                .Parity = IO.Ports.Parity.None
                .DataBits = 8
                .StopBits = IO.Ports.StopBits.One
                .Handshake = IO.Ports.Handshake.None
                .RtsEnable = False
                .ReceivedBytesThreshold = 1
                ' last char in frame MUST be a CR
                .NewLine = vbCr
            End With

            ' try open
            SerialPort1.Open()
            comOpen = SerialPort1.IsOpen

        Catch ex As Exception
            MsgBox(ex.Message + " #ComOpen")
            comOpen = False
            pbxStatePort.BackColor = Color.Red
        End Try

        If comOpen Then
            pbxStatePort.BackColor = Color.Green
            cboPort.Enabled = False
            cboBaud.Enabled = False
        End If

    End Sub

    ''' <summary>
    '''   Button Close Port
    ''' </summary>
    Private Sub Button_Close_Click(ByVal sender As System.Object, _
                                   ByVal e As System.EventArgs) _
                                   Handles btnClosePort.Click
        Try
            SerialPort1.DiscardInBuffer()
            SerialPort1.Close()
        Catch ex As InvalidOperationException
            MsgBox(ex.Message + " #ComClose")
            Exit Sub
        End Try

        comOpen = False
        pbxStatePort.BackColor = Color.Red
        pbxDataReceived.BackColor = Color.Gray
        cboPort.Enabled = True
        cboBaud.Enabled = True
    End Sub

    ''' <summary>
    ''' reading COM port
    ''' </summary>
    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, _
                                         ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) _
                                         Handles SerialPort1.DataReceived
        If comOpen Then
            Try

                'Bytenumber = SerialPort1.BytesToRead
                readBuffer = SerialPort1.ReadLine()

            Catch ex As InvalidOperationException
                MsgBox(ex.Message & " #Readdata")
                Exit Sub
            End Try
            Me.Invoke(New EventHandler(AddressOf DoUpdate))
        End If
    End Sub

#End Region

#Region "Form events"

   
    ''' <summary>
    '''  Save Content of RichTextBox to file
    ''' </summary>
    Private Sub Button_save_MouseClick(ByVal sender As System.Object, _
                                       ByVal e As System.Windows.Forms.MouseEventArgs) _
                                       Handles btnSave.MouseClick
        SaveFileDialog1.DefaultExt = "*.TXT"
        SaveFileDialog1.Filter = " | *.TXT"
        If (SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) _
        And (SaveFileDialog1.FileName.Length) > 0 Then
            rtbRX.SaveFile(SaveFileDialog1.FileName, _
                                    RichTextBoxStreamType.PlainText)
        End If
    End Sub

    ''' <summary>
    ''' clear RTB
    ''' </summary>
    Private Sub Button_clear_Click(ByVal sender As System.Object, _
                                   ByVal e As System.EventArgs) _
                                   Handles btn_Richtextbox_clear.Click
        rtbRX.Clear()
    End Sub

    ''' <summary>
    ''' EXIT
    ''' </summary>
    Private Sub btnExit_Click(ByVal sender As System.Object, _
                                  ByVal e As System.EventArgs) _
                                  Handles btnExit.Click

        If comOpen Then
            ' Empfangspuffer löschen
            SerialPort1.DiscardInBuffer()
            SerialPort1.Close()
        End If
        comOpen = False
        Me.Close()

    End Sub

    ''' <summary>
    ''' get baudrate from Combobox
    ''' </summary>
    Private Sub ComboBox_Baud_SelectedIndexChanged(ByVal sender As System.Object, _
                                                   ByVal e As System.EventArgs) _
                                                   Handles cboBaud.SelectedIndexChanged
        portBaud = CInt(cboBaud.Text)

    End Sub

    ''' <summary>
    ''' get port from Combobox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBox_port_SelectedIndexChanged(ByVal sender As System.Object, _
                                                   ByVal e As System.EventArgs) _
                                                   Handles cboPort.SelectedIndexChanged
        portname = cboPort.Text

    End Sub
  
    ''' <summary>
    ''' keyboard panel code to mcu
    ''' </summary>
    Private Sub Tasten_Click(ByVal sender As System.Object, _
                             ByVal e As System.EventArgs) _
                             Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, _
                                     btn4.Click, btn5.Click, btn6.Click, btn7.Click, _
                                     btn8.Click, btn9.Click, btnEnter.Click, btnClear.Click
        If comOpen Then SerialPort1.Write(CType(sender, Button).Text)
    End Sub


    ''' <summary>
    ''' timer
    ''' </summary>
    Private Sub Timer1_Tick(ByVal sender As System.Object, _
                            ByVal e As System.EventArgs) Handles Timer1.Tick

 
        pbxDataReceived.BackColor = Color.Gray

        Timer1.Enabled = False
        
    End Sub

#End Region

#Region "utilities"

    ''' <summary>
    ''' load file and visualize text fields in the form
    ''' </summary>
    Private Sub Button_LoadSettings_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
                                               Handles btnLoadSettings.MouseClick

        OpenFileDialog1.Filter = (" | *.TXT")
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            Dim fnm As String = OpenFileDialog1.FileName()
            loadSettings(fnm)

        End If
    End Sub

    ''' <summary>
    ''' load the settings for all label
    ''' </summary>
    Private Sub loadSettings(ByVal fnm As String)
        Dim areMW As Boolean = False
        Dim arebytes As Boolean = False
        Dim index As Integer = 0
        Dim line As String
        Dim sr As StreamReader = New StreamReader(fnm)

        Do While sr.Peek >= 0
            line = sr.ReadLine
            If line.Contains("<1>") Then
                index = 0
                areMW = True
                arebytes = False
            ElseIf line.Contains("<2>") Then
                index = 0
                areMW = False
                arebytes = True
            ElseIf areMW Then
                Checkbox_values(index).Text = line
                index += 1
            ElseIf arebytes Then
                Checkbox_IO(index).Text = line
                index += 1
            End If
        Loop
        sr.Close()

    End Sub

    ''' <summary>
    ''' data of one frame to form
    ''' </summary>
    Public Sub DoUpdate(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim _str As String = String.Empty
        Dim ValueCount As Integer = 0           'count of found values un telegram
        Dim ByteCount As Integer = 0            'count found Bytes in telegram
        Dim thisBytes(IOCol) As Integer         'found Bytes converted to Integer:
        Static thisBytesLast(IOCol) As Integer  'found bytes previous frame
        Dim Bitpattern As Integer = &H1         'pattern for bitwise operation
        Static oldminute As Integer             'value of last minute
        Static minuteChanged As Boolean         'Flag minute has changed
        Dim minuteNow As Integer                'actual minute
        Dim buffer1() As String



        '>00:42 45 18 18 18 45 45 18 18 18 18 45 18 24 18+130 97 4 170  <carriage return>
        '|  |   |                                        || max 5 bytes
        '|  |   |                                        +-- separator  
        '|  |   +  values 1 .. max 20
        '|  + ---  mcu time
        '+ ------  this are measuring data

        If Not readBuffer.StartsWith(">") Then Exit Sub
        ' Bei der 1ten Ausführung von doUpdate nach Neustart noch keine Auswertung sinnoll
        If startup Then
            thisBytesLast = thisBytes
            startup = False
        End If

        'split readbuffer into the regions
        buffer1 = Me.readBuffer.Split(New String() {"+", ">"}, StringSplitOptions.RemoveEmptyEntries)
        'split region 1 - mcu time / values (max 20)
        Dim BufferValues() As String = buffer1(0).Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        'number received (zero based)
        ValueCount = BufferValues.Length - 1
        If ValueCount > AnzMw - 1 Then ValueCount = AnzMw - 1

        'now split bytes
        Dim ByteValues(4) As String     'max lenght is 5
        If buffer1.Length > 1 Then      'there are bytes
            ByteValues = buffer1(1).Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            ByteCount = ByteValues.Length
        Else
            ByteCount = 0
        End If

        ' mcu time
        Me.lblTime.Text = BufferValues(0)
    
        ' one minute has passed?
        minuteNow = CInt(bufferValues(0).Substring(3, 2))
        If minuteNow <> oldminute Then
            oldminute = minuteNow
            minuteChanged = True            ' we see us later
        Else
            minuteChanged = False
        End If
        '
        ' visualize values
        '
        For i As Integer = 1 To ValueCount
            values(i - 1).Text = BufferValues(i)
        Next
        '
        '    bytes to form
        '
        If ByteCount > 0 Then
            For i As Integer = 0 To ByteCount - 1
                thisBytes(i) = (CInt(ByteValues(i)) And &HFF)
            Next
            '
            '     bitwise operation
            '
            For i As Integer = 0 To ByteCount - 1
                For bits As Integer = 0 To IORow
                    If (thisBytes(i) And Bitpattern) > 0 Then
                        IOstates(8 * i + bits).Image = My.Resources.ledCornerGreen
                        _str = " ON"
                    Else
                        IOstates((IORow + 1) * i + bits).Image = My.Resources.ledCornerRed
                        _str = " OFF"
                    End If
                
                    If chkLogON.Checked Then               ' log ON
                        StrMessage = String.Empty
                        StrMessage = lblTime.Text & " "    ' set time

                        ' has bit changed since previous frame?
                        Dim IoStatesHasChanged As Boolean = False
                        If ((thisBytes(i) And Bitpattern) Xor (thisBytesLast(i) And Bitpattern)) > 0 Then IoStatesHasChanged = True

                        If IoStatesHasChanged And Checkbox_IO(8 * i + bits).Checked Then

                            StrMessage &= Checkbox_IO((IORow + 1) * i + bits).Text & _str
                            Me.rtbRX.ScrollToCaret()
                            Me.rtbRX.AppendText(StrMessage + vbCr)

                        End If
                    End If
                    ' next Bit
                    Bitpattern = Bitpattern << 1
                Next
                ' back to bit 0
                Bitpattern = &H1
            Next
            ' remember this last byte
            thisBytesLast = thisBytes
        End If
        '
        '    generate log data
        '
        If chkLogON.Checked And Not chkLog1min.Checked Then
            buildstring()
        End If

        If chkLogON.Checked And chkLog1min.Checked And minuteChanged Then
            minuteChanged = False
            buildstring()
        End If

        ' finished
        pbxDataReceived.BackColor = Color.AliceBlue
        Timer1.Enabled = True

    End Sub
 
 
    Private Sub buildstring()
        Dim dataOK As Boolean = False
        Me.StrMessage = Me.readBuffer.Substring(1, 5) & " "    ' Uhrzeit eintragen
        For i As Integer = 0 To (AnzMw - 1)
            If Checkbox_values(i).Checked Then
                dataOK = True                   ' Wert vorhanden
                Me.StrMessage &= Checkbox_values(i).Text & " " + values(i).Text & " "
            End If
        Next
        If dataOK Then
            Me.rtbRX.ScrollToCaret()
            Me.rtbRX.AppendText(StrMessage + vbCr)
        End If
    End Sub

#End Region
End Class
