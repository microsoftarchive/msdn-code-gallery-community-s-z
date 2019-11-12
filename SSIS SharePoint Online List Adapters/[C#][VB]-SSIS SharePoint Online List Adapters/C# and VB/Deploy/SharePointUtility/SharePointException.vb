Imports System.Runtime.Serialization

''' <summary>
''' Used for exceptions to mark unhandled SharePoint Errors
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class SharePointUnhandledException
    Inherits Exception

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal ex As Exception)
        MyBase.New(message, ex)
    End Sub

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class
