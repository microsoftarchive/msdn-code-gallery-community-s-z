' <snippet3>

Public Class EF_ContactRepository
    Implements IContactRepository

    Private _db As New ContactEntities()

    Public Function GetContactByID(ByVal id As Integer) As Contact Implements IContactRepository.GetContactByID
        Return _db.Contacts.FirstOrDefault(Function(d) d.Id = id)
    End Function

    Public Function GetAllContacts() As IEnumerable(Of Contact) Implements IContactRepository.GetAllContacts
        Return _db.Contacts.ToList()
    End Function

    Public Sub CreateNewContact(ByVal contactToCreate As Contact) Implements IContactRepository.CreateNewContact
        _db.AddToContacts(contactToCreate)
        _db.SaveChanges()
        '   return contactToCreate;
    End Sub

    Public Function SaveChanges() As Integer Implements IContactRepository.SaveChanges
        Return _db.SaveChanges()
    End Function

    Public Sub DeleteContact(ByVal id As Integer) Implements IContactRepository.DeleteContact
        Dim conToDel = GetContactByID(id)
        _db.Contacts.DeleteObject(conToDel)
        _db.SaveChanges()
    End Sub

End Class

' </snippet3>
