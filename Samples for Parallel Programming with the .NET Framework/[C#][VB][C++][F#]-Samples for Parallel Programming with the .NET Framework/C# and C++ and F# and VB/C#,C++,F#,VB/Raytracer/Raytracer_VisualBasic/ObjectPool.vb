'Imports System.Collections.Concurrent

'Public Class ObjectPool(Of T)
'Private _objects As IProducerConsumerCollection(Of T)
'Private _valueSelector As Func(Of T)

'Public Sub New(ByVal valueSelector As Func(Of T))
'If valueSelector Is Nothing Then Throw New ArgumentNullException("valueSelector")
'_valueSelector = valueSelector
'_objects = New ConcurrentQueue(Of T)
'End Sub

'Public Function GetObject() As T
'Dim item As T
'If _objects.TryTake(item) Then
'Return item
'Else
'Return _valueSelector()
'End If
'End Function

'Public Sub PutObject(ByVal item As T)
'_objects.TryAdd(item)
'End Sub
'End Class
