@ModelType MvcMovie.Movie

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Movie</legend>

    <div class="display-label">Title</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Title)
    </div>

    <div class="display-label">ReleaseDate</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.ReleaseDate)
    </div>

    <div class="display-label">Genre</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Genre)
    </div>

    <div class="display-label">Price</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Price)
    </div>
</fieldset>
@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
