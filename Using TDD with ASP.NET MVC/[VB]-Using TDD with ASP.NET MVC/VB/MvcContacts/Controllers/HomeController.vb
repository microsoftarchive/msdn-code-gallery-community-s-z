<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private _repository As IContactRepository

    Public Sub New()
        Me.New(New EF_ContactRepository())
    End Sub

    Public Sub New(ByVal repository As IContactRepository)
        _repository = repository
    End Sub

    Public Function Index() As ViewResult
        ViewData("ControllerName") = Me.ToString()
        Return View("Index", _repository.GetAllContacts())
    End Function
    '
    ' GET: /Home/Details/5

    Public Function Details(ByVal id? As Integer) As ActionResult
        Dim idx As Integer = If(id.HasValue, CInt(Fix(id)), 0)
        Dim cnt As Contact = _repository.GetContactByID(idx)
        Return View("Details", cnt)
    End Function
    '
    ' GET: /Home/Create

    Public Function Create() As ActionResult
        Return View("Create")
    End Function

    '
    ' POST: /Home/Create

    <HttpPost()>
    Public Function Create(<Bind(Exclude:="Id")> ByVal contactToCreate As Contact) As ActionResult
        Try
            If ModelState.IsValid Then
                _repository.CreateNewContact(contactToCreate)
                Return RedirectToAction("Index")
            End If
        Catch ex As Exception
            ModelState.AddModelError("", ex)
            ViewData("CreateError") = "Unable to create; view innerexception"
        End Try

        Return View("Create")

    End Function

    '
    ' GET: /Home/Edit/5

    Public Function Edit(ByVal id As Integer) As ActionResult
        Dim contactToEdit = _repository.GetContactByID(id)

        Return View(contactToEdit)
    End Function

    '
    ' POST: /Home/Edit/5

    <HttpPost()>
    Public Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult

        Dim cnt As Contact = _repository.GetContactByID(id)

        Try
            If TryUpdateModel(cnt) Then
                _repository.SaveChanges()

                Return RedirectToAction("Index")
            End If ' For Demo purpose only
        Catch ex As Exception
            ' Production apps should not display exception data.
            If ex.InnerException IsNot Nothing Then
                ViewData("EditError") = ex.InnerException.ToString()
            Else
                ViewData("EditError") = ex.ToString()
            End If
        End Try

        ' For security reasons, only throw model errors in debug/development.
        ' To test this, 
        ' see the sample download Walkthrough: Using Templated Helpers to Display Data in ASP.NET MVC
        ' at http://msdn.microsoft.com/en-us/library/ee308450.aspx
        '#If DEBUG Then
        '			For Each modelState In ModelState.Values
        '				For Each [error] In modelState.Errors
        '					If [error].Exception IsNot Nothing Then
        '						Throw modelState.Errors(0).Exception
        '					End If
        '				Next [error]
        '			Next modelState
        '#End If

        Return View(cnt)
    End Function

    '
    ' GET: /Home/Delete/5

    Public Function Delete(ByVal id As Integer) As ActionResult
        Dim conToDel = _repository.GetContactByID(id)
        Return View(conToDel)
    End Function

    '
    ' POST: /Home/Delete/5

    <HttpPost()>
    Public Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            _repository.DeleteContact(id)
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function
End Class


'<HandleError()> _
'Public Class HomeController
'    Inherits System.Web.Mvc.Controller

'    Private _repository As IContactRepository

'    Public Sub New()
'        Me.New(New EF_ContactRepository())
'    End Sub

'    Public Sub New(ByVal repository As IContactRepository)
'        _repository = repository
'    End Sub

'    Public Function Index() As ViewResult
'        Throw New NotImplementedException()
'        Return View()
'    End Function
'End Class