<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomSkin.Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Customizing the ReportViewer Skin</h1>
        <p>This sample demonstrates how to change the skin of the ReportViewer by setting the public properties.</p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table>
            <tr>
                <td class="style2">
                    <rsweb:reportviewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" ProcessingMode="Remote" 
                        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" EnableTheming="True" >
                    </rsweb:reportviewer>
                </td>
                <td class="style3">
                    <asp:Button ID="ButtonApply" runat="server" Text="Apply Settings" />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Back Color"></asp:Label>
                    <asp:DropDownList ID="DropDownBackColor" runat="server" 
                        onselectedindexchanged="DropDownBackColor_SelectedIndexChanged" >
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Border Color"></asp:Label>
                    <asp:DropDownList ID="DropDownBorderColor" runat="server" 
                        onselectedindexchanged="DropDownBorderColor_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Border Style"></asp:Label>
                    <asp:DropDownList ID="DropDownBorderStyle" runat="server" 
                        onselectedindexchanged="DropDownBorderStyle_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Border Width"></asp:Label>
                    <asp:TextBox ID="TextBoxBorderWidth" runat="server" Width="50px" 
                        ontextchanged="TextBoxBorderWidth_TextChanged"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Font"></asp:Label>
                    <asp:DropDownList ID="DropDownFont" runat="server" 
                        onselectedindexchanged="DropDownFont_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="Size"></asp:Label>
                    <asp:TextBox ID="TextBoxSize" runat="server" Width="50px" 
                        ontextchanged="TextBoxSize_TextChanged"></asp:TextBox>
                    <br />
                    <asp:CheckBox ID="CheckBoxBold" runat="server" Text="Bold" 
                        oncheckedchanged="CheckBoxBold_CheckedChanged" />
                    <br />
                    <asp:CheckBox ID="CheckBoxItalic" runat="server" Text="Italic" 
                        oncheckedchanged="CheckBoxItalic_CheckedChanged" />
                    <br />
                    <asp:CheckBox ID="CheckBoxOverLine" runat="server" Text="Overline" 
                        oncheckedchanged="CheckBoxOverLine_CheckedChanged" />
                    <br />
                    <asp:CheckBox ID="CheckBoxStrikeout" runat="server" Text="Strikeout" 
                        oncheckedchanged="CheckBoxStrikeout_CheckedChanged" />
                    <br />
                    <asp:CheckBox ID="CheckBoxUnderline" runat="server" Text="Underline" 
                        oncheckedchanged="CheckBoxUnderline_CheckedChanged" />
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="Internal Border Color"></asp:Label>
                    <asp:DropDownList ID="DropDownInternalBorderColor" runat="server" 
                        onselectedindexchanged="DropDownInternalBorderColor_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label14" runat="server" Text="Internal Border Style"></asp:Label>
                    <asp:DropDownList ID="DropDownInternalBorderStyle" runat="server" 
                        onselectedindexchanged="DropDownInternalBorderStyle_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label15" runat="server" Text="Internal Border Width"></asp:Label>
                    <asp:TextBox ID="TextBoxInternalBorderWidth" runat="server" Width="50px" 
                        ontextchanged="TextBoxInternalBorderWidth_TextChanged"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="Link Active Color"></asp:Label>
                    <asp:DropDownList ID="DropDownListActiveColor" runat="server" 
                        onselectedindexchanged="DropDownListActiveColor_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label17" runat="server" Text="Link Active Hover Color"></asp:Label>
                    <asp:DropDownList ID="DropDownListActiveHoverColor" runat="server" 
                        onselectedindexchanged="DropDownListActiveHoverColor_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label18" runat="server" Text="Link Disabled Color"></asp:Label>
                    <asp:DropDownList ID="DropDownListDisabledColor" runat="server" 
                        onselectedindexchanged="DropDownListDisabledColor_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label19" runat="server" Text="Splitter Back Color"></asp:Label>
                    <asp:DropDownList ID="DropDownSplitterBackColor" runat="server" 
                        onselectedindexchanged="DropDownSplitterBackColor_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label20" runat="server" Text="Wait Message Font"></asp:Label>
                    <asp:DropDownList ID="DropDownWaitMessageFont" runat="server" 
                        onselectedindexchanged="DropDownWaitMessageFont_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label23" runat="server" Text="Wait Message Size"></asp:Label>
                    <asp:TextBox ID="TextBoxWaitMessageSize" runat="server" Width="50px" 
                        ontextchanged="TextBoxWaitMessageSize_TextChanged"></asp:TextBox>
                    <br />
                    <asp:CheckBox ID="CheckBoxWaitMessageBold" runat="server" 
                        Text="Wait Message Bold" 
                        oncheckedchanged="CheckBoxWaitMessageBold_CheckedChanged" />
                    <br />
                    <asp:CheckBox ID="CheckBoxWaitMessageItalic" runat="server" 
                        Text="Wait Message Italic" 
                        oncheckedchanged="CheckBoxWaitMessageItalic_CheckedChanged" />
                    <br />
                    <asp:CheckBox ID="CheckBoxWaitMessageOverLine" runat="server" 
                        Text="Wait Message Overline" 
                        oncheckedchanged="CheckBoxWaitMessageOverLine_CheckedChanged" />
                    <br />
                    <asp:CheckBox ID="CheckBoxWaitMessageStrikeout" runat="server" 
                        Text="Wait Message Strikeout" 
                        oncheckedchanged="CheckBoxWaitMessageStrikeout_CheckedChanged" />
                    <br />
                    <asp:CheckBox ID="CheckBoxWaitMessageUnderline" runat="server" 
                        Text="Wait Message Underline" 
                        oncheckedchanged="CheckBoxWaitMessageUnderline_CheckedChanged" />
                </td>
            </tr>
        </table>

    </div>
    </form>
</body>
</html>
