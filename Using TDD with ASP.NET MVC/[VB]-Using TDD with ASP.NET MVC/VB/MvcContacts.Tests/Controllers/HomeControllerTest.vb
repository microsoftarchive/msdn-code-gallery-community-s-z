Imports System
Imports System.Security
Imports System.Security.Principal
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Web.Security
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MvcContacts

<TestClass()> Public Class HomeControllerTest

    ' <snippet8>
    <TestMethod()>
    Public Sub Index_Get_AsksForIndexView()
        ' Arrange
        Dim controller = GetHomeController(New InMemoryContactRepository())
        ' Act
        Dim result As ViewResult = controller.Index()
        ' Assert
        Assert.AreEqual("Index", result.ViewName)
    End Sub
    ' </snippet8>
    ' <snippet4>
    <TestMethod()>
    Public Sub Index_Get_RetrievesAllContactsFromRepository()
        ' Arrange
        Dim contact1 As Contact = GetContactNamed(1, "Orlando", "Gee")
        Dim contact2 As Contact = GetContactNamed(2, "Keith", "Harris")
        Dim repository As New InMemoryContactRepository()
        repository.Add(contact1)
        repository.Add(contact2)
        Dim controller = GetHomeController(repository)

        ' Act
        Dim result = controller.Index()

        ' Assert
        Dim model = CType(result.ViewData.Model, IEnumerable(Of Contact))
        CollectionAssert.Contains(model.ToList(), contact1)
        CollectionAssert.Contains(model.ToList(), contact1)
    End Sub
    ' </snippet4>

    ' <snippet9>
    <TestMethod()>
    Public Sub Create_Post_PutsValidContactIntoRepository()
        ' Arrange
        Dim repository As New InMemoryContactRepository()
        Dim controller As HomeController = GetHomeController(repository)
        Dim con_tact As Contact = GetContactID_1()

        ' Act
        controller.Create(con_tact)

        ' Assert
        Dim contacts As IEnumerable(Of Contact) = repository.GetAllContacts()
        Assert.IsTrue(contacts.Contains(con_tact))
    End Sub
    ' </snippet9>

    <TestMethod()>
    Public Sub Create_Post_ReturnsRedirectOnSuccess()
        ' Arrange
        Dim controller As HomeController = GetHomeController(New InMemoryContactRepository())
        Dim model As Contact = GetContactID_1()

        ' Act
        Dim result = CType(controller.Create(model), RedirectToRouteResult)

        ' Assert
        Assert.AreEqual("Index", result.RouteValues("action"))
    End Sub

    ' <snippet6>
    <TestMethod()>
    Public Sub Create_Post_ReturnsViewIfModelStateIsNotValid()
        ' Arrange
        Dim controller As HomeController = GetHomeController(New InMemoryContactRepository())
        ' Simply executing a method during a unit test does just that - executes a method, and no more. 
        ' The MVC pipeline doesn't run, so binding and validation don't run.
        controller.ModelState.AddModelError("", "mock error message")
        Dim model As Contact = GetContactNamed(1, "", "")

        ' Act
        Dim result = CType(controller.Create(model), ViewResult)

        ' Assert
        Assert.AreEqual("Create", result.ViewName)
    End Sub
    ' </snippet6>

    ' <snippet7>
    <TestMethod()>
    Public Sub Create_Post_ReturnsViewIfRepositoryThrowsException()
        ' Arrange
        Dim repository As New InMemoryContactRepository()
        Dim exception_Renamed As New Exception()
        repository.ExceptionToThrow = exception_Renamed
        Dim controller As HomeController = GetHomeController(repository)
        Dim model As Contact = GetContactID_1()

        ' Act
        Dim result = CType(controller.Create(model), ViewResult)

        ' Assert
        Assert.AreEqual("Create", result.ViewName)
        Dim modelState_Renamed As ModelState = result.ViewData.ModelState("")
        Assert.IsNotNull(modelState_Renamed)
        Assert.IsTrue(modelState_Renamed.Errors.Any())
        Assert.AreEqual(exception_Renamed, modelState_Renamed.Errors(0).Exception)
    End Sub
    ' </snippet7>

    Private Function GetContactID_1() As Contact
        Return GetContactNamed(1, "Janet", "Gates")
    End Function

    Private Function GetContactNamed(ByVal id As Integer, ByVal fName As String, ByVal lName As String) As Contact
        Return New Contact With {.Id = id,
                                 .FirstName = fName,
                                 .LastName = lName,
                                 .Phone = "710-555-0173",
                                 .Email = "janet1@adventure-works.com"}

    End Function

    Private Shared Function GetHomeController(ByVal repository As IContactRepository) As HomeController
        Dim controller As New HomeController(repository)

        controller.ControllerContext = New ControllerContext() With
                                       {.Controller = controller,
                                         .RequestContext = New RequestContext(New MockHttpContext(),
                                        New RouteData())}
        Return controller
    End Function

    Private Class MockHttpContext
        Inherits HttpContextBase

        Private ReadOnly _user As IPrincipal = New GenericPrincipal(New GenericIdentity("someUser"), Nothing)

        Public Overrides Property User() As IPrincipal
            Get
                Return _user
            End Get
            Set(ByVal value As System.Security.Principal.IPrincipal)
                MyBase.User = value
            End Set
        End Property
    End Class
   
End Class

