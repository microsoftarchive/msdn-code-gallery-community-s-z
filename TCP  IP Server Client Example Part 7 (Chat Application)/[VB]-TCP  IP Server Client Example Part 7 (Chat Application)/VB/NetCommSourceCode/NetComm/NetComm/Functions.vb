Imports System.Text
Module Functions
    Private MainEncoding As Encoding = ASCIIEncoding.GetEncoding("windows-1255")
    Public Structure ClientMsg
        Dim ID As String
        Dim Data() As Byte
        Public Sub New(ByVal ClientID As String, ByVal DataByte() As Byte)
            ID = ClientID
            Data = DataByte
        End Sub
        Public Shared Function GetBytes(ByVal c As ClientMsg) As Byte()
            If c.ID = Nothing Then c.ID = ""
            Dim EncryptedString As String = "!" & c.ID & "!" & c.Data.Length & "!"
            Return JoinBytes(MainEncoding.GetBytes(EncryptedString), c.Data)
        End Function
        Public Shared Function FromBytes(ByVal bytes() As Byte, Optional ByRef Start As Integer = 0) As ClientMsg
            Try
                Dim Msg As ClientMsg
                Dim Length_Start As Integer = Start 'Defines from where our ID starts (skip from useless '0')
                Do Until bytes(Length_Start) = 33
                    Length_Start += 1
                    If Length_Start >= bytes.Length - 1 Then Return New ClientMsg(Nothing, Nothing)
                Loop
                Dim Length_End As Integer = Length_Start + 1 'Defines from where our ID ends
                Do Until bytes(Length_End) = 33
                    Length_End += 1
                    If Length_End >= bytes.Length - 1 Then Return New ClientMsg(Nothing, Nothing)
                Loop
                Msg.ID = IIf(Length_End - Length_Start > 1, MainEncoding.GetString(ChopBytes(bytes, Length_Start + 1, Length_End - Length_Start - 1)), Nothing) 'Gets the ID within the "!" characters - if the length is 1 it means that the ID is nothing.
                Length_Start = Length_End 'The first "!" character is already the previous one
                Length_End = Length_Start + 1 'Gets the data length within the "!" characters
                Do Until bytes(Length_End) = 33
                    Length_End += 1
                    If Length_End >= bytes.Length - 1 Then Return New ClientMsg(Nothing, Nothing)
                Loop
                Dim DataLength As Integer
                DataLength = MainEncoding.GetString(ChopBytes(bytes, Length_Start + 1, Length_End - Length_Start - 1))
                Msg.Data = ChopBytes(bytes, Length_End + 1, DataLength)
                Start = Length_End + DataLength
                Return Msg
            Catch ex As Exception
                Return New ClientMsg(Nothing, Nothing)
            End Try
        End Function
    End Structure
    Public Function CheckPacket(ByVal bytes() As Byte) As Boolean
        For Each b As Byte In bytes
            If b <> 0 Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Structure EventArgs
        Dim EventP As Integer
        Dim Arg As Object
        Public Sub New(ByVal e As Integer, ByVal Argument As Object)
            EventP = e
            Arg = Argument
        End Sub
    End Structure
    Public Function JoinBytes(ByVal Original() As Byte, ByVal JoinPart() As Byte) As Byte()
        Dim JoinedBytes(Original.Length + JoinPart.Length - 1) As Byte
        Dim cnt As Integer = 0
        For Each b As Byte In Original
            JoinedBytes(cnt) = b
            cnt += 1
        Next
        For Each b As Byte In JoinPart
            JoinedBytes(cnt) = b
            cnt += 1
        Next
        Return JoinedBytes
    End Function
    Public Function ChopBytes(ByVal Original() As Byte, ByVal Start As Integer, Optional ByVal Length As Integer = Nothing) As Byte()
        If Length = Nothing Or Length < 1 Then
            Length = Original.Length - Start
        End If
        Dim ChoppedBytes(Length - 1) As Byte
        Dim cnt As Integer = 0
        For by = Start To Start + Length - 1
            ChoppedBytes(cnt) = Original(by)
            cnt += 1
        Next
        Return ChoppedBytes
    End Function
End Module
