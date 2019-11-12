<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="AJAXFileUploadSQL.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Upload Files Asynchronously Using AJAX into SQL Server Database
    </h2>
    <p>
        This sample code uses AjaxFileUpload control to upload multiple files to the database
        asynchronously. The project supports drag-and-drop to save multiple files to the
        database by dragging them into the page. Also, you can select multiple files to
        upload by using the SHIFT key or CTRL key when selecting files on the file upload
        dialog.
    </p>
</asp:Content>
