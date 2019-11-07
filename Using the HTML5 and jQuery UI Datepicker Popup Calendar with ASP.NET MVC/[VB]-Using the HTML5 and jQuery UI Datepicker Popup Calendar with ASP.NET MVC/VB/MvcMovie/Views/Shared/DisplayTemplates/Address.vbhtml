@ModelType MvcMovie.Address

<fieldset>
    <legend>Address</legend>

    <div class="display-label">StreetAddress</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.StreetAddress)
    </div>

    <div class="display-label">City</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.City)
    </div>

    <div class="display-label">PostalCode</div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.PostalCode)
    </div>
</fieldset>
