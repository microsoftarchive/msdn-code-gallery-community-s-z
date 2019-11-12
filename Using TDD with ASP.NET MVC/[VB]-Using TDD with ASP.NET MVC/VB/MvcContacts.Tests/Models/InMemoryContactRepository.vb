' <snippet5>

Class InMemoryContactRepository
    Implements IContactRepository

    Private _db As New List(Of Contact)()
    Public Property ExceptionToThrow() As Exception

    Public Function SaveChanges() As Integer Implements IContactRepository.SaveChanges
        Return 1
    End Function

    Public Sub Add(ByVal contactToAdd As Contact)
        _db.Add(contactToAdd)
    End Sub

    Public Function GetContactByID(ByVal id As Integer) As Contact Implements IContactRepository.GetContactByID
        Return _db.FirstOrDefault(Function(d) d.Id = id)
    End Function

    Public Sub CreateNewContact(ByVal contactToCreate As Contact) Implements IContactRepository.CreateNewContact
        If ExceptionToThrow IsNot Nothing Then
            Throw ExceptionToThrow
        End If

        _db.Add(contactToCreate)
    End Sub


    Public Function GetAllContacts() As IEnumerable(Of Contact) Implements IContactRepository.GetAllContacts
        Return _db.ToList()
    End Function


    Public Sub DeleteContact(ByVal id As Integer) Implements IContactRepository.DeleteContact
        _db.Remove(GetContactByID(id))
    End Sub

End Class

' </snippet5>
