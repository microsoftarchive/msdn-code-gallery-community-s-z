<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SendSMS._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>    
            <td>
                Mobile no    
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtMobileNo" MaxLength="10" onkeypress="return NumericOnlyInput(event);"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td>
                Message
            </td>
            <td>
                <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine"></asp:TextBox><br />       
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button runat="server" ID="btnSend" Text="Send SMS" onclick="btnSend_Click"></asp:Button>
            </td>
        </tr>
    </table>                
    </form>
<script language="javascript" type="text/javascript">
    function NumericOnlyInput(e) {
        var unicode = e.charCode ? e.charCode : e.keyCode;        
        if (unicode == 8 || unicode == 9 || (unicode >= 48 && unicode <= 57)) {
            return true;
        }
        else {            
            return false;
        }
    }
</script>
</body>
</html>
