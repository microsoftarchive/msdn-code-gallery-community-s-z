Imports System.Data.Entity
Imports MvcMovie

Namespace MvcMovie
    Public Class MoviesController
        Inherits System.Web.Mvc.Controller

        Private db As MovieDBContext = New MovieDBContext

        Private Function GetPerson(ByVal id As Integer) As Person
            Dim p = New Person With {.ID = 1, .FirstName = "Joe", .LastName = "Smith", .Phone = "123-456", .HomeAddress = New Address With {.City = "Great Falls", .StreetAddress = "1234 N 57th St", .PostalCode = "95045"}}
            Return p
        End Function

        Public Function PersonDetail(Optional ByVal id As Integer = 0) As ActionResult
            Return View(GetPerson(id))
        End Function

        'Public Function SearchIndex(ByVal searchString As String) As ActionResult
        '    Dim movies = From m In db.Movies
        '                 Select m

        '    If Not String.IsNullOrEmpty(searchString) Then
        '        movies = movies.Where(Function(s) s.Title.Contains(searchString))
        '    End If

        '    Return View(movies)
        'End Function

        '<HttpPost()>
        'Public Function SearchIndex(ByVal fc As FormCollection, ByVal searchString As String) As String
        '    Return "<h3> From [HttpPost]SearchIndex: " & searchString & "</h3>"
        'End Function

Public Function SearchIndex(ByVal movieGenre As String, ByVal searchString As String) As ActionResult
    Dim GenreLst = New List(Of String)()

    Dim GenreQry = From d In db.Movies
                   Order By d.Genre
                   Select d.Genre
    GenreLst.AddRange(GenreQry.Distinct())
    ViewBag.movieGenre = New SelectList(GenreLst)

    Dim movies = From m In db.Movies
                 Select m

    If Not String.IsNullOrEmpty(searchString) Then
        movies = movies.Where(Function(s) s.Title.Contains(searchString))
    End If

    If String.IsNullOrEmpty(movieGenre) Then
        Return View(movies)
    Else
        Return View(movies.Where(Function(x) x.Genre = movieGenre))
    End If

End Function

        '
        ' GET: /Movies/

        Function Index() As ViewResult
            Return View(db.Movies.ToList())
        End Function

        '
        ' GET: /Movies/Details/5

Public Function Details(Optional ByVal id As Integer = 0) As ActionResult
    Dim movie As Movie = db.Movies.Find(id)
    If movie Is Nothing Then
        Return HttpNotFound()
    End If
    Return View(movie)
End Function

'
' GET: /Movies/Create

Function Create() As ViewResult
    Return View()
End Function

'
' POST: /Movies/Create

<HttpPost()>
Function Create(movie As Movie) As ActionResult
    If ModelState.IsValid Then
        db.Movies.Add(movie)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End If

    Return View(movie)
End Function

        '
        ' GET: /Movies/Edit/5

        Public Function Edit(Optional ByVal id As Integer = 0) As ActionResult
            Dim movie As Movie = db.Movies.Find(id)
            If movie Is Nothing Then
                Return HttpNotFound()
            End If
            Return View(movie)
        End Function

        '
        ' POST: /Movies/Edit/5

        <HttpPost()>
        Function Edit(movie As Movie) As ActionResult
            If ModelState.IsValid Then
                db.Entry(movie).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(movie)
        End Function

' GET: /Movies/Delete/5

 Public Function Delete(Optional ByVal id As Integer = 0) As ActionResult
     Dim movie As Movie = db.Movies.Find(id)
     If movie Is Nothing Then
         Return HttpNotFound()
     End If
     Return View(movie)
 End Function

 '
 ' POST: /Movies/Delete/5

 <HttpPost(), ActionName("Delete")>
 Public Function DeleteConfirmed(Optional ByVal id As Integer = 0) As ActionResult
     Dim movie As Movie = db.Movies.Find(id)
     If movie Is Nothing Then
         Return HttpNotFound()
     End If
     db.Movies.Remove(movie)
     db.SaveChanges()
     Return RedirectToAction("Index")
 End Function

    End Class
End Namespace