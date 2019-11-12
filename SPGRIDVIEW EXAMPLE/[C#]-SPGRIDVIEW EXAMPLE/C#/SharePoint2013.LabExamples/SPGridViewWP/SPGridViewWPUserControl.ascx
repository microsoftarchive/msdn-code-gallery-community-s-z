<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SPGridViewWPUserControl.ascx.cs" Inherits="SharePoint2013.LabExamples.SPGridViewWP.SPGridViewWPUserControl" %>
<table>
    <tr>
        <td>
            <SharePoint:SPGridView ID="gvICSSDocuments" runat="server" AutoGenerateColumns="false" Width="850px">
                <RowStyle BackColor="#D0D8E8" Height="30px" HorizontalAlign="Left" />
                <AlternatingRowStyle BackColor="#E9EDF4" Height="30px" HorizontalAlign="Left" />
                <HeaderStyle HorizontalAlign="Left" CssClass="ms-viewheadertr" />
                <Columns>
                    <asp:TemplateField HeaderText="Year" ControlStyle-Width="100px" SortExpression="Year" HeaderStyle-CssClass="ms-viewheadertr">
                        <ItemTemplate>
                            <asp:Label ID="lblCreated" runat="server" Text='<%# Eval("Year") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title" ControlStyle-Width="250px" SortExpression="Title" HeaderStyle-CssClass="ms-viewheadertr">
                        <ItemTemplate>
                            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" ControlStyle-Width="300px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="ms-viewheadertr">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Attachment" ControlStyle-Width="200px" SortExpression="Name" HeaderStyle-CssClass="ms-viewheadertr">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlnkDocument" runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("Url") %>'
                                Target="_blank"></asp:HyperLink>
                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lblNoAccess" Text="No documents available" runat="server" CssClass="emptyDataLabel"></asp:Label>
                </EmptyDataTemplate>
            </SharePoint:SPGridView>
        </td>
    </tr>
</table>

