Imports System.Collections.ObjectModel
Imports WpfEfDAL

Public Class CustomerCollection
    Inherits MyBaseCollection(Of Customer)

    ''' <summary>
    ''' Return true if any customer in this collection has a validation error
    ''' </summary>
    Public ReadOnly Property HasErrors() As Boolean
        Get
            Return (Aggregate cust In Me Where cust.HasErrors Into Count()) > 0
        End Get
    End Property

    Sub New(ByVal customers As IEnumerable(Of Customer), ByVal context As OMSEntities)
        MyBase.New(customers, context)
    End Sub

    Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As Customer)
        If Not Me.IsLoading Then
            'Tell the ObjectContext to start tracking this customer entity
            Me.Context.AddToCustomers(item)
        End If
        MyBase.InsertItem(index, item)
    End Sub

    Protected Overrides Sub RemoveItem(ByVal index As Integer)
        'Tell the ObjectContext to delete this customer entity
        Me.Context.DeleteObject(Me(index))
        MyBase.RemoveItem(index)
    End Sub

End Class
