'Define a simple wrapper for XElement which implements our message protocol
Public Class XMessage
    Const SOH As Byte = 1 'define a start sequence
    Const EOF As Byte = 4 'define a stop sequence
    Public Property Element As XElement 'declare the object to hold the actual message contents

    'define a method to check a series of bytes to determine if they conform to the protocol specification
    Public Shared Function IsMessageComplete(data As IEnumerable(Of Byte)) As Boolean
        Dim length As Integer = data.Count 'get the number of bytes
        If length > 5 Then 'ensure there are enough for at least the start, stop, and length
            If data(0) = SOH AndAlso data(length - 1) = EOF Then 'ensure the series begins and ends with start/stop identifiers
                Dim l As Integer = BitConverter.ToInt32(data.ToArray, 1) 'interpret the data length by reading bytes 1 through 4 and converting to integer
                Return (l = length - 6) 'ensure that the interpreted data length matches the number of bytes supplied
            End If
        End If
        Return False
    End Function

    'parse the XElement content from the supplied data according to the message protocol specification
    Public Shared Function FromByteArray(data() As Byte) As XMessage
        Return New XMessage(XElement.Parse(System.Text.Encoding.UTF8.GetString(data, 5, data.Length - 6)))
    End Function

    'serialize the XElement content into a byte array according to the message protocol specification
    Public Function ToByteArray() As Byte()
        Dim result As New List(Of Byte)
        Dim data() As Byte = System.Text.Encoding.UTF8.GetBytes(Element.ToString) 'encode the XML string
        result.Add(SOH) 'add the message start indicator
        result.AddRange(BitConverter.GetBytes(data.Length)) 'add the data length
        result.AddRange(data) 'add the message data
        result.Add(EOF) 'add the message stop indicator
        Return result.ToArray 'return the data array
    End Function

    Public Sub New(xml As XElement)
        Element = xml
    End Sub
End Class
