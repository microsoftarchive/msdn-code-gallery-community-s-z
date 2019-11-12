
Public Class ServiceLocator
    Implements IServiceProvider

    Private services As New Dictionary(Of Type, Object)()

    Public Function GetService(Of T)() As T
        Return CType(GetService(GetType(T)), T)
    End Function

    Public Function RegisterService(Of T)(ByVal service As T, ByVal overwriteIfExists As Boolean) As Boolean
        SyncLock services
            If Not services.ContainsKey(GetType(T)) Then
                services.Add(GetType(T), service)
                Return True
            ElseIf overwriteIfExists Then
                services(GetType(T)) = service
                Return True
            End If
        End SyncLock
        Return False
    End Function

    Public Function RegisterService(Of T)(ByVal service As T) As Boolean
        Return RegisterService(Of T)(service, True)
    End Function

    Public Function GetService(ByVal serviceType As Type) As Object Implements IServiceProvider.GetService
        SyncLock services
            If services.ContainsKey(serviceType) Then
                Return services(serviceType)
            End If
        End SyncLock
        Return Nothing
    End Function
End Class
