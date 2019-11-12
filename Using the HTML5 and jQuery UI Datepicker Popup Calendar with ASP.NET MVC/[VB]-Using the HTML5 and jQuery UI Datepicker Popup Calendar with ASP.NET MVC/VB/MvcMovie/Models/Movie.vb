Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations

Public Class Movie
    Public Property ID() As Integer

    <Required(ErrorMessage:="Title is required")>
    Public Property Title() As String

    '  <DisplayFormat(DataFormatString:="{0:d}")>

    '<UIHint("LoudDateTime")>
    <DataType(DataType.Date)>
    <Required(ErrorMessage:="Date is required")>
    Public Property ReleaseDate() As Date

    <Required(ErrorMessage:="Genre must be specified")>
    Public Property Genre() As String


    '<DisplayFormat(DataFormatString:="{0:c}")>
    <DataType(DataType.Currency)>
    <Required(ErrorMessage:="Price Required"), Range(1, 100, ErrorMessage:="Price must be between $1 and $100")>
     Public Property Price() As Decimal

    <StringLength(5)>
    Public Property Rating() As String
End Class

Public Class MovieDBContext
    Inherits DbContext
    Public Property Movies() As DbSet(Of Movie)
End Class