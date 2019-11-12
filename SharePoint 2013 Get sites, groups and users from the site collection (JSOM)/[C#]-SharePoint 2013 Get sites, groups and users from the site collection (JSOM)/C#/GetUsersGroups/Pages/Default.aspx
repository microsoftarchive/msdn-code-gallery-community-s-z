<%-- The following 4 lines are ASP.NET directives needed when using SharePoint components --%>

<%@ Page Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" MasterPageFile="~masterurl/default.master" Language="C#" %>

<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%-- The markup and script in the following Content element will be placed in the <head> of the page --%>
<asp:Content ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script src="//ajax.aspnetcdn.com/ajax/4.0/1/MicrosoftAjax.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.12.2.min.js"></script>


    <!-- Add your CSS styles to the following file -->
    <link rel="Stylesheet" type="text/css" href="../Content/App.css" />

    <!-- Add your JavaScript to the following file -->
    <script type="text/javascript" src="../Scripts/App.js"></script>


    <!-- This is the Javascript file of jqGrid -->   
   
    <!-- A link to a jQuery UI ThemeRoller theme, more than 22 built-in and many more custom -->
    <link rel="stylesheet" type="text/css" media="screen" href="../Styles/css/jquery-ui.css" />
    <link rel="stylesheet" href="../Scripts/jqwidgets/styles/jqx.base.css" type="text/css" />
    <script type="text/javascript" src="../Scripts/jqwidgets/jqxcore.js"></script>
    <script type="text/javascript" src="../Scripts/jqwidgets/jqxbuttons.js"></script>
    <script type="text/javascript" src="../Scripts/jqwidgets/jqxscrollbar.js"></script>
    <script type="text/javascript" src="../Scripts/jqwidgets/jqxmenu.js"></script>
    <script type="text/javascript" src="../Scripts/jqwidgets/jqxgrid.js"></script>
    <script type="text/javascript" src="../Scripts/jqwidgets/jqxgrid.grouping.js"></script>
    <script type="text/javascript" src="../Scripts/jqwidgets/jqxgrid.selection.js"></script>
    <script type="text/javascript" src="../Scripts/jqwidgets/jqxdata.js"></script>
    <script type="text/javascript" src="../Scripts/jqwidgets/jqxlistbox.js"></script>
    <script type="text/javascript" src="../Scripts/jqwidgets/jqxdropdownlist.js"></script>
    <script type="text/javascript" src="../Scripts/jqwidgets/jqxgrid.sort.js"></script>
    <script type="text/javascript" src="../Scripts/jqwidgets/jqxgrid.columnsresize.js"></script>
    <script type="text/javascript" src="../Scripts/jqwidgets/jqxgrid.filter.js"></script>
</asp:Content>

<%-- The markup in the following Content element will be placed in the TitleArea of the page --%>
<asp:Content ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    User groups and Users in Site Collection
</asp:Content>

<%-- The markup and script in the following Content element will be placed in the <body> of the page --%>
<asp:Content ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div>
      
            <!-- The following content will be replaced with the user name when you run the app - see App.js -->
            <h2 id="HostwebTitle">This app retrieves all user groups and users from each site under the site collection.</h2>

        <p id="ErrorMessage">
            <!-- The following content will be replaced with the error message -->

        </p>
         <h3><b>Groups List</b></h3>

        <div id="GroupsList">
            <ul></ul>
        </div>


        <div class="default">
            <div id='jqxWidget' style="font-size: 13px; font-family: Verdana; float: left;">
                <div id="jqxgrid"></div>
            </div>
        </div>
    </div>



</asp:Content>
