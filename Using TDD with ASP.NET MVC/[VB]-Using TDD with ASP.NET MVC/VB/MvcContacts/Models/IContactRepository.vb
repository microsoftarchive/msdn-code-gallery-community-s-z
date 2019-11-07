' <snippet2>
Public Interface IContactRepository
    Sub CreateNewContact(ByVal contactToCreate As Contact)
    Sub DeleteContact(ByVal id As Integer)
    Function GetContactByID(ByVal id As Integer) As Contact
    Function GetAllContacts() As IEnumerable(Of Contact)
    Function SaveChanges() As Integer
End Interface
' </snippet2>
