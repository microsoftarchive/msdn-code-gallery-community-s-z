<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcMusicStore.Models.Album>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Album - <%: Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        <%: Model.Title %>
    </h2>

    <p>
        <img alt="<%: Model.Title %>" src="<%: Model.AlbumArtUrl %>" />
    </p>

    <div id="album-details">
        <p>
            <em>Genre:</em>
            <%: Model.Genre.Name %>
        </p>
        <p>
            <em>Artist:</em>
            <%: Model.Artist.Name %>
        </p>
        <p>
            <em>Price:</em>
            <%: String.Format("{0:F}", Model.Price) %>
        </p>
        <p class="button">
            <%: Html.ActionLink("Add to cart", "AddToCart", "ShoppingCart", 
                new { id = Model.AlbumId }, "")%>
        </p>
    </div>

</asp:Content>
