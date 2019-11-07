<%@ Page Language="C#" Inherits="System.Web.UI.Page"    %> <%@ Assembly Name="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Import Namespace="Microsoft.SharePoint.Utilities" %> <%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="Microsoft.SharePoint.WebControls" %>
<%@ Import Namespace="Microsoft.SharePoint.Administration" %>
<% SPSite spServer = SPControl.GetContextSite(Context); SPWeb spWeb = SPControl.GetContextWeb(Context); %>
<% Response.ContentType = "text/xml"; %>
<discovery xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.xmlsoap.org/disco/">
  <contractRef  ref=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(spWeb.Url + "/_vti_bin/CustomWS/CustomService.asmx?wsdl"),Response.Output); %> docRef=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(spWeb.Url + "/_vti_bin/CustomWS/CustomService.asmx"),Response.Output); %> xmlns="http://schemas.xmlsoap.org/disco/scl/" />
  <discoveryRef ref=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(spWeb.Url + "/_vti_bin/CustomWS/CustomService.asmx?disco"),Response.Output); %> xmlns="http://schemas.xmlsoap.org/disco/" />
</discovery>
