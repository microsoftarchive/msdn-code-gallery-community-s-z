<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcMusicStore.Models.Album>" %>

<script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
<script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
<script src="/Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>

<div class="editor-label">
    <%: Html.LabelFor(model => model.GenreId) %>
</div>
<div class="editor-field">
    <%: Html.DropDownList("GenreId", new SelectList(ViewData["Genres"] as IEnumerable, "GenreId", "Name", Model.GenreId))%>
    <%: Html.ValidationMessageFor(model => model.GenreId) %>
</div>
            
<div class="editor-label">
    <%: Html.LabelFor(model => model.ArtistId) %>
</div>
<div class="editor-field">
    <%: Html.DropDownList("ArtistId", new SelectList(ViewData["Artists"] as IEnumerable, "ArtistId", "Name", Model.ArtistId))%>
    <%: Html.ValidationMessageFor(model => model.ArtistId) %>
</div>
            
<div class="editor-label">
    <%: Html.LabelFor(model => model.Title) %>
</div>
<div class="editor-field">
    <%: Html.TextBoxFor(model => model.Title) %>
    <%: Html.ValidationMessageFor(model => model.Title) %>
</div>
            
<div class="editor-label">
    <%: Html.LabelFor(model => model.Price) %>
</div>
<div class="editor-field">
    <%: Html.TextBoxFor(model => model.Price, String.Format("{0:F}", Model.Price)) %>
    <%: Html.ValidationMessageFor(model => model.Price) %>
</div>
            
<div class="editor-label">
    <%: Html.LabelFor(model => model.AlbumArtUrl) %>
</div>
<div class="editor-field">
    <%: Html.TextBoxFor(model => model.AlbumArtUrl) %>
    <%: Html.ValidationMessageFor(model => model.AlbumArtUrl) %>
</div>
