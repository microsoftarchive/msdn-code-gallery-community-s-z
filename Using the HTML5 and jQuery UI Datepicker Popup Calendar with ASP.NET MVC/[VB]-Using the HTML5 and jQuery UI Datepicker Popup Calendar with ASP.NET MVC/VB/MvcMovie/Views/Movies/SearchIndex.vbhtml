@ModelType IEnumerable(Of MvcMovie.Movie)

<h2>SearchIndex</h2>

<p>
    @Html.ActionLink("Create New", "Create")
    @Code
    ViewData("Title") = "SearchIndex"
    Using (Html.BeginForm())
         @<p> Genre: @Html.DropDownList("movieGenre", "All")
         Title: @Html.TextBox("SearchString") 
         <input type="submit" value="Filter" /></p>
        End Using
End Code
</p>
<table>
    <tr>
        <th>
            Title
        </th>
        <th>
            ReleaseDate
        </th>
        <th>
            Genre
        </th>
        <th>
            Price
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Title)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.ReleaseDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Genre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Price)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.ID})
        </td>
    </tr>
Next

</table>
