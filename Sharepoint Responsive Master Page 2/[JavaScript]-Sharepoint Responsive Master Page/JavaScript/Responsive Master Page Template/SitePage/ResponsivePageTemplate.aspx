
<%@ Page language="C#" MasterPageFile=    ../../_catalogs/masterpage/bootstrap/bootstrap.master meta:progid="SharePoint.WebPartPage.Document" 
inherits=""  %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %><%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<asp:Content ID="Content1" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:encodedliteral ID="EncodedLiteral1" runat="server" text="View Request" EncodeMethod="HtmlEncode"/>&nbsp;
	- 
	<SharePoint:projectproperty ID="ProjectProperty1" Property="Title" runat="server"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageImage" runat="server"><img src="/_layouts/images/blank.gif" width='1' height='1' alt="" /></asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderMain" runat="server">



	
</asp:Content>






