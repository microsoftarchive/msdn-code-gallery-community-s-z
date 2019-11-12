<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GoogleMaps.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script language="javascript" type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>

    <script language="javascript" type="text/javascript">
        var markers = [
            <asp:Repeater ID="rptMarkers" runat="server">
                <ItemTemplate>
                    {
                        "title": '<%# Eval("Name") %>',
                        "lat": '<%# Eval("Latitude") %>',
                        "lng": '<%# Eval("Longitude") %>',
                        "description": '<%# Eval("Description") %>'
                    }
                </ItemTemplate>
                <SeparatorTemplate>,</SeparatorTemplate>
            </asp:Repeater>
        ];
    </script>

    <script language="javascript" type="text/javascript" src="Scripts/googleMaps.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="dvMap" style="width: 1330px; height: 700px">
        </div>
    </form>
</body>
</html>
