Imports System.Collections.ObjectModel
Imports System.Data
Imports WpfEfDAL

Public MustInherit Class MyBaseCollection(Of T)
    Inherits ObservableCollection(Of T)

    Private _isLoading As Boolean = False
    Public ReadOnly Property IsLoading() As Boolean
        Get
            Return _isLoading
        End Get
    End Property

    Public ReadOnly Property HasChanges() As Boolean
        Get
            Dim changed = _context.ObjectStateManager.GetObjectStateEntries( _
                                                      EntityState.Added Or _
                                                      EntityState.Deleted Or _
                                                      EntityState.Modified)

            Dim entityChanged = From o In changed Where TypeOf o.Entity Is T
            Return (entityChanged IsNot Nothing AndAlso entityChanged.Count > 0)
        End Get
    End Property

    Private _context As OMSEntities
    Public ReadOnly Property Context() As OMSEntities
        Get
            Return _context
        End Get
    End Property

    Protected Sub New(ByVal query As IEnumerable(Of T), ByVal context As OMSEntities)
        _isLoading = True
        _context = context

        If query IsNot Nothing Then
            For Each o In query
                Me.Add(o)
            Next
        End If
        _isLoading = False
    End Sub

End Class
