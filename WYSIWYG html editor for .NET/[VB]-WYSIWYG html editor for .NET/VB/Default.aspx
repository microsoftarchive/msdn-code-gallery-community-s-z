<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" ValidateRequest="false" EnableViewState="false" AutoEventWireup="false" Inherits="_Default" CodeFile="Default.aspx.vb" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title>WYSIWYG Text editor</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<style>body,[type=submit]{background-size:cover;background-image:linear-gradient(to bottom right, #FFFFFF 0%, #D0EF9B 100%);font-family:Verdana;font-size:120%;color:#00544A}
[type=submit]{background:#65a9d7; color: white;border-color:#65a9d7}
a:link{color: brown}
a:visited{color: brown}
a:hover{color: red}
</style>
</head>
<body>
<form id="form1" runat="server">
<h1>WYSIWYG Text editor</h1>
<textarea rows="1" cols="1" id="TextArea1" name="TextArea1" runat="server" style="width: 100%; height: 500px;" spellcheck="true"></textarea>
<br /><br />
<asp:Button ID="Button1" runat="server" Text="Save" />
</form>
</body>
</html>