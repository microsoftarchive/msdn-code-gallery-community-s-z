Option Strict On
Option Infer On

''' <summary>
''' Serial Port Demo Ellen Ramcke 2012
''' </summary>
''' <remarks></remarks>
Public Class mainForm

    Private readBuffer As String = String.Empty
    Private Bytenumber As Integer
    Private ByteToRead As Integer
    Private byteEnd(2) As Char
    Private comOpen As Boolean

#Region "form events"
    ''' <summary>
    ''' close application and COM Port
    ''' </summary>
    Private Sub Form1_FormClosed(ByVal sender As System.Object, _
                                 ByVal e As System.Windows.Forms.FormClosedEventArgs) _
                                 Handles MyBase.FormClosed
        If comOpen Then SerialPort1.Close()
    End Sub

    ''' <summary>
    ''' open Windows Form
    ''' </summary>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' read avaiable COM Ports:
        Dim Portnames As String() = System.IO.Ports.SerialPort.GetPortNames
        If Portnames Is Nothing Then
            MsgBox("There are no Com Ports detected!")
            Me.Close()
        End If
        cboComPort.Items.AddRange(Portnames)
        cboComPort.Text = Portnames(0)
        cboBaudRate.Text = "9600"

    End Sub

    ''' <summary>
    ''' Open Com Port here
    ''' </summary>
    Private Sub btnComOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComOpen.Click

        ' device params
        With SerialPort1

            .ParityReplace = &H3B                    ' replace ";" when parity error occurs
            .PortName = cboComPort.Text
            .BaudRate = CInt(cboBaudRate.Text)
            .Parity = IO.Ports.Parity.None
            .DataBits = 8
            .StopBits = IO.Ports.StopBits.One
            .Handshake = IO.Ports.Handshake.None
            .RtsEnable = False
            .ReceivedBytesThreshold = 1             'threshold: one byte in buffer > event is fired
            .NewLine = vbCr         ' CR must be the last char in frame. This terminates the SerialPort.readLine
            .ReadTimeout = 10000

        End With

        ' check whether device is avaiable:
        Try
            SerialPort1.Open()
            comOpen = SerialPort1.IsOpen
        Catch ex As Exception
            comOpen = False
            MsgBox("Error Open: " & ex.Message)
            picOpen.BackColor = Color.Red
        End Try

        If comOpen Then
            picOpen.BackColor = Color.Green
            cboComPort.Enabled = False
            cboBaudRate.Enabled = False
        End If

    End Sub

    ''' <summary>
    ''' close ComPort
    ''' </summary>
    Private Sub Button_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComClose.Click
        If comOpen Then
            ' clear input buffer
            SerialPort1.DiscardInBuffer()
            SerialPort1.Close()
        End If
        comOpen = False
        picOpen.BackColor = Color.Red
        picDataReceived.BackColor = Color.Gray
        cboComPort.Enabled = True
        cboBaudRate.Enabled = True
    End Sub

    ''' <summary>
    ''' clear TextBoxes
    ''' </summary>
    Private Sub Button_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        tbRx.Text = String.Empty
        tbTx.Text = String.Empty
    End Sub

    ''' <summary>
    ''' write content of Textbox to Port
    ''' </summary>
    Private Sub button_send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If comOpen Then SerialPort1.WriteLine(tbTx.Text)
    End Sub

    ''' <summary>
    ''' close app
    ''' </summary>
    Private Sub Button_ende_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If comOpen Then
            ' clear input buffer
            SerialPort1.DiscardInBuffer()
            SerialPort1.Close()
        End If
        comOpen = False
        Me.Close()
    End Sub

    ''' <summary>
    ''' send control panel key to com port
    ''' </summary>
    ''' <param name="sender">return key name</param>
    Private Sub Tasten_Click(ByVal sender As System.Object, _
                             ByVal e As System.EventArgs) _
                             Handles Button9.Click, Button8.Click, Button7.Click, _
                                     Button6.Click, Button5.Click, Button3.Click, _
                                     Button4.Click, Button2.Click, ButtonE.Click, _
                                     Button0.Click, ButtonC.Click, Button1.Click

        Dim key As String = CType(sender, Button).Text
        If comOpen Then SerialPort1.Write(key)

    End Sub

    ''' <summary>
    ''' Timer datareceived event
    ''' </summary>
    Private Sub Timer1_Tick(ByVal sender As System.Object, _
                            ByVal e As System.EventArgs) Handles Timer1.Tick
        picDataReceived.BackColor = Color.Gray
        Timer1.Enabled = False
    End Sub

#End Region

#Region "ComPort read data"

    ''' <summary>
    ''' async read on secondary thread
    ''' </summary>
    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, _
                                         ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) _
                                         Handles SerialPort1.DataReceived
        If comOpen Then
            Try
                byteEnd = SerialPort1.NewLine.ToCharArray

                ' get number off bytes in buffer
                Bytenumber = SerialPort1.BytesToRead

                ' read one byte from buffer
                'ByteToRead = SerialPort1.ReadByte()

                ' read one char from buffer
                'CharToRead = SerialPort1.ReadChar()

                ' read until string "90"
                'readBuffer1 = SerialPort1.ReadTo("90")

                ' read entire string until .Newline 
                readBuffer = SerialPort1.ReadLine()

                'data to UI thread
                Me.Invoke(New EventHandler(AddressOf DoUpdate))

            Catch ex As Exception
                MsgBox("read " & ex.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' update received string in UI
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DoUpdate(ByVal sender As Object, ByVal e As System.EventArgs)
        tbRx.Text = readBuffer
        picDataReceived.BackColor = Color.Green
        Timer1.Enabled = True
    End Sub

#End Region
End Class
