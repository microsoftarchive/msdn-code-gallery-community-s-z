<%@ Page language="c#" CodeFile="HeaderSupplemental.aspx.cs" AutoEventWireup="false" Inherits="System.Web.UI.DataVisualization.Charting.Samples.HeaderSupplemental" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>HeaderSupplemental</title>
    <script type="text/javascript">
        function onResize() {
            // Update position of the background image
            var imageLeft = document.body.clientWidth - document.getElementById("BackImage").offsetWidth;
            var imageLeftMost = 370 - parent.parent.document.getElementById("navigationFrame").offsetWidth;
            imageLeftMost = imageLeftMost - 2; // Adjust for the frame spacing
            if (imageLeft < imageLeftMost) {
                imageLeft = imageLeftMost;
            }
            document.getElementById("BackImage").style.left = imageLeft;
        }		
    </script>

</head>
<body scroll="no" unselectable="on" leftmargin="0" topmargin="0" rightmargin="0" ms_positioning="GridLayout" onresize="onResize();" onload="onResize();">
    <form id="HeaderSupplementalForm" method="post" runat="server">
    <div nowrap unselectable="on">
        <asp:Label scroll="no" unselectable="on" ID="LabelTitle" Style="z-index: 102; left: 20px;
            position: absolute; top: 0px" runat="server" ForeColor="#1A3B69" Font-Bold="True"
            Font-Size="16pt" Font-Names="Verdana">Chart Control for .Net Framework</asp:Label>
        <asp:Image scroll="no" unselectable="on" ID="BackImage" Style="z-index: 101; left: 0px;
            position: absolute; top: 0px" runat="server" ImageUrl="Images/HeaderRight2.bmp">
        </asp:Image>
    </div>
    </form>
</body>
</html>
