@ModelType MvcMovie.Person

@Code
    ViewData("Title") = "PersonDetail"
End Code

<h2>PersonDetail</h2>

@Html.DisplayForModel()
     @Html.DisplayFor(Function(modelItem) modelItem.HomeAddress)
