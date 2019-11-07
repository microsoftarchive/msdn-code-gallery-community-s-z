Namespace DataObject
    ''' <summary>
    ''' Data Object for SharePoint View Information
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ViewData

        Private _displayName As String
        Private _name As String

        ''' <summary>
        ''' The SharePoint ID for the column
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Name() As String
            Get
                Return _name
            End Get
            Friend Set(ByVal value As String)
                _name = value
            End Set
        End Property

        ''' <summary>
        ''' The SharePoint Display Name for the column
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DisplayName() As String
            Get
                Return _displayName
            End Get
            Friend Set(ByVal value As String)
                _displayName = value
            End Set
        End Property
    End Class
End Namespace
