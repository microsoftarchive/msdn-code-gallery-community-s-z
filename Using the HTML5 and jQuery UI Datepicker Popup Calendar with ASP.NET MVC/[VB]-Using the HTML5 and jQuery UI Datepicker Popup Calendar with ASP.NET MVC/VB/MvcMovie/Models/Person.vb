Public Class Address
    Public Property StreetAddress() As String
    Public Property City() As String
    Public Property PostalCode() As String
End Class

Public Class Person
    Public Property ID() As Integer
    Public Property FirstName() As String
    Public Property LastName() As String
    Public Property Phone() As String
    Public HomeAddress As Address
End Class