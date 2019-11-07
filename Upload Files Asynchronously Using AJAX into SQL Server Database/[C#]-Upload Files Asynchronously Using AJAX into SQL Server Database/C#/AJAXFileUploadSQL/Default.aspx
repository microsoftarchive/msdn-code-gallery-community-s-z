<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AJAXFileUploadSQL._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style>
        .ajax__fileupload_button
        {
            background-color: blue;
        }
    </style>
    <script type="text/javascript">
        function onClientUploadComplete(sender, e) {
            var id = e.get_fileId();
            onImageValidated("TRUE", e);
        }

        function onImageValidated(arg, context) {

            var test = document.getElementById("testuploaded");
            test.style.display = 'block';

            var fileList = document.getElementById("fileList");
            var item = document.createElement('div');
            item.style.padding = '4px';

            if (arg == "TRUE") {
                var url = context.get_postedUrl();
                url = url.replace('&amp;', '&');
                item.appendChild(createThumbnail(context, url));
            } else {
                item.appendChild(createFileInfo(context));
            }

            fileList.appendChild(item);

        }

        function createFileInfo(e) {
            var holder = document.createElement('div');
            holder.appendChild(document.createTextNode(e.get_fileName() + ' with size ' + e.get_fileSize() + ' bytes'));

            return holder;
        }

        function createThumbnail(e, url) {
            var holder = document.createElement('div');
            var img = document.createElement("img");
            img.style.width = '80px';
            img.style.height = '80px';
            img.setAttribute("src", url);

            holder.appendChild(createFileInfo(e));
            holder.appendChild(img);

            return holder;
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Upload Files Asynchronously Using AJAX into SQL Server Database
    </h2>
    <br />
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div>
        <asp:Label runat="server" ID="myThrobber" Style="display: none;"><img align="absmiddle" alt="" src="uploading.gif"/></asp:Label>
        <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" padding-bottom="4"
            padding-left="2" padding-right="1" padding-top="4" ThrobberID="myThrobber" OnClientUploadComplete="onClientUploadComplete"
            OnUploadComplete="AjaxFileUpload1_OnUploadComplete" />
        <br />
        <div id="testuploaded" style="display: none; padding: 4px; border: gray 1px solid;">
            <h4>
                Uploaded files:</h4>
            <hr />
            <div id="fileList">
            </div>
        </div>
    </div>
</asp:Content>
