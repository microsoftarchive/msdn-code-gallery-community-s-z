<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="AsyncPageLoad.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Simple Asynchronous Page Load
    </h2>
    <p>
        Sometimes when you create a website it is necessary to load some part of the page
        asynchronously. This can be for various reason including cases when you refer to
        a different page (like: RSS Feeds, your tweets, and many more). Loading these contents
        when your page is loaded can have a huge impact on your site speed. Sometime it
        can completely prevent your site from opening (if your external content site is
        down, or connection cannot be established), or showing error to the users.
    </p>
</asp:Content>
