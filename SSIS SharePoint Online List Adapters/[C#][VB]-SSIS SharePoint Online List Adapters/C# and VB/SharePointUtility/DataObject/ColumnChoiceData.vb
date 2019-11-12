Namespace DataObject
    ''' <summary>
    ''' Data Object for SharePoint Field Choices
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ColumnChoiceData

        Private _name As String
        Private _id As String
        Private _initialValue As String

        ''' <summary>
        ''' Set the value for the choice data, setting an ID if the name contains it or else just the name
        ''' </summary>
        ''' <param name="dataString"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal dataString As String)
            _initialValue = dataString
            Dim valArray = dataString.Split({";#"}, StringSplitOptions.None)
            If (valArray.Length >= 2) Then
                _id = valArray(0)
                _name = valArray(1)
            Else
                _id = ""
                _name = dataString
            End If
        End Sub

        ''' <summary>
        ''' Name of a choice among choices specified by the user in SharePoint
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
        ''' Name of a choice among choices specified by the user in SharePoint
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ID() As String
            Get
                Return _id
            End Get
            Friend Set(ByVal value As String)
                _id = value
            End Set
        End Property

        ''' <summary>
        ''' Spits out the original string
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return _initialValue
        End Function
    End Class
End Namespace