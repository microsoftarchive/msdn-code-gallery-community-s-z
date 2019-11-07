' <snippet1>
Imports System.ComponentModel.DataAnnotations

Public Class ContactMD

    <ScaffoldColumn(False)>
    Public Property Id() As Object
    <Required()>
    Public Property FirstName() As Object
    <Required()>
    Public Property LastName() As Object
    <RegularExpression("^\d{3}-?\d{3}-?\d{4}$")>
    Public Property Phone() As Object

    <Required()>
    <DataType(DataType.EmailAddress)>
    <RegularExpression("^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")>
    Public Property Email() As Object

End Class

' </snippet1>

