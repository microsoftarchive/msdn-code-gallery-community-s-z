'This class provides a simple collection of clients where each can be accessed by
'unique id or index in the collection.  This is to facilitate working with connected
'clients from your actual application, if needed, and could be replaced with a simple
'List(Of ConnectedClient) if your application will not need to access individual clients
'by their unique id.  Typically though this kind of collection will be useful when
'writing your server application.  The list of client tasks could also be extrapolated
'from this collection rather than being stored in a seperate list.
Public Class ConnectedClientCollection
    Inherits System.Collections.ObjectModel.KeyedCollection(Of String, ConnectedClient)

    Protected Overrides Function GetKeyForItem(item As ConnectedClient) As String
        Return item.Id
    End Function
End Class