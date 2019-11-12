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
            Dim EncryptedString As String = "!" & c.ID.Length & "!" & c.Data.Length & "!" & c.ID
            Return JoinBytes(MainEncoding.GetBytes(EncryptedString), c.Data)
        End Function
        Public Shared Function FromBytes(ByVal bytes() As Byte, Optional ByRef Start As Integer = 0) As ClientMsg
            Try
                Dim Length_Start As Integer = Start 'Define from where our ID length data starts (skip from useless '0')
                Do Until bytes(Length_Start) = 33
                    Length_Start += 1
                    If Length_Start >= bytes.Length - 1 Then Return New ClientMsg(Nothing, Nothing)
                Loop
                Dim Length_End As Integer = Length_Start + 1 'Defines from where our ID length data ends, skip the previous entry by adding 1.
                Do Until bytes(Length_End) = 33
                    Length_End += 1
                    If Length_End >= bytes.Length - 1 Then Return New ClientMsg(Nothing, Nothing)
                Loop
                Dim Msg As ClientMsg
                Dim IDLength, DataLength As Integer 'Our ID and data length
                IDLength = MainEncoding.GetString(ChopBytes(bytes, Length_Start + 1, Length_End - Length_Start - 1)) 'Get our ID length
                Length_Start = Length_End
                Length_End = Length_Start + 1 'Defines from where our Data length data ends, skip the previous entry by adding 1.
                Do Until bytes(Length_End) = 33
                    Length_End += 1
                    If Length_End >= bytes.Length - 1 Then Return New ClientMsg(Nothing, Nothing)
                Loop
                DataLength = MainEncoding.GetString(ChopBytes(bytes, Length_Start + 1, Length_End - Length_Start - 1))
                If IDLength > 0 Then
                    Msg.ID = MainEncoding.GetString(ChopBytes(bytes, Length_End + 1, IDLength))
                Else
                    Msg.ID = Nothing
                End If
                Msg.Data = ChopBytes(bytes, Length_End + IDLength + 1, DataLength)
                Start = Length_End + IDLength + DataLength
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
