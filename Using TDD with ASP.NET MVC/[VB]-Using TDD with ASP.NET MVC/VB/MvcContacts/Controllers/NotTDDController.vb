Namespace MvcContacts
    ' <snippet22>
    Public Class NotTDDController
        Inherits System.Web.Mvc.Controller

        Private _db As New ContactEntities()

        Public Function Index() As ActionResult
            ViewData("ControllerName") = Me.ToString()
            Dim dn = _db.Contacts
            Return View(dn)
        End Function

        Public Function Edit(ByVal id As Integer) As ActionResult
            Dim prd As Contact = _db.Contacts.FirstOrDefault(Function(d) d.Id = id)
            Return View(prd)
        End Function

        <HttpPost()>
        Public Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Dim prd As Contact = _db.Contacts.FirstOrDefault(Function(d) d.Id = id)
            UpdateModel(prd)
            _db.SaveChanges()
            Return RedirectToAction("Index")
        End Function
    End Class
    ' </snippet22>
End Namespace