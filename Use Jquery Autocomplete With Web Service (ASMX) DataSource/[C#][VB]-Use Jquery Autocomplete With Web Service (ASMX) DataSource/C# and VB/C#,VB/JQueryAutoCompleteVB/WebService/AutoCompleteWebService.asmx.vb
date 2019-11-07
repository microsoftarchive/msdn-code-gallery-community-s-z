Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Services

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class AutoCompleteWebService
    Inherits System.Web.Services.WebService

    ''' <summary>
    ''' Gets the random strings.
    ''' </summary>
    ''' <param name="Value">The value.</param>
    ''' <returns>GetRandomStringsResult)</returns>
    ''' <author>Luca Congiu (25/05/2013)</author>
    ''' <includesource>yes</includesource>
    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Function GetRandomStrings(ByVal Value As String) As List(Of GetRandomStringsResult)
        Dim result As New List(Of GetRandomStringsResult)
        'Generate Random Strings
        For i As Integer = 97 To 122
            result.Add(New GetRandomStringsResult(Value + Chr(i), i.ToString))
        Next

        Return result

    End Function


End Class
''' <summary>
''' Result Class for json
''' </summary>
''' <author>LCO (28/06/2011)</author>
''' <includesource>yes</includesource>
Public Class GetRandomStringsResult
    Public Sub New()

    End Sub
    Public Sub New(ByVal Name As String, ByVal Value As String)
        Me.Name = Name
        Me.Value = Value
    End Sub
    Public Property Name As String
    Public Property Value As String


End Class
