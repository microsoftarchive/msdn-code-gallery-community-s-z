<%@ Page Language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ChartAsTrigger"
    CodeFile="ChartAsTrigger.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Chart as a Trigger</title>
    <link media="all" href="../../../samples.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="ImageMapCustomTooltip" method="post" runat="server">
    <p class="dscr" style="height: 48px;">
        This sample demonstrates UpdatePanel with the Chart control as a trigger. Click on the chart series. Note
        that the table on the right is updated with detailed information on each data 
        point.
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <table class="sampleTable">
        <tr>
            <td class="tdchart">
                <asp:AccessDataSource ID="MasterSource" runat="server" DataFile="~/data/chartdata.mdb"
                    SelectCommand="SELECT REGIONS.RegionName, SUM(REPS_SALES.Sales) AS SumOfSales FROM (REPS_SALES INNER JOIN REGIONS ON REPS_SALES.RegionID = REGIONS.RegionID) GROUP BY REGIONS.RegionName">
                </asp:AccessDataSource>
                <asp:Chart ID="Chart1" runat="server" BackColor="#D3DFF0" Palette="BrightPastel"
                    ImageType="Png" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px"
                    borderlinestyle="Solid" backgradientendcolor="White" backgradienttype="TopBottom"
                    BorderlineWidth="2" BorderlineColor="26, 59, 105" DataSourceID="MasterSource"
                    OnClick="Chart1_Click">
                    <Titles>
                        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                            Text="Regional Sales" Alignment="TopLeft" ForeColor="26, 59, 105">
                        </asp:Title>
                    </Titles>
                    <Legends>
                        <asp:Legend Enabled="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold">
                            <Position Y="21" Height="22" Width="18" X="73"></Position>
                        </asp:Legend>
                    </Legends>
                    <BorderSkin SkinStyle="Emboss"></BorderSkin>
                    <Series>
                        <asp:Series Name="Sales" BorderColor="180, 26, 59, 105" XValueMember="RegionName"
                            YValueMembers="SumOfSales">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                            BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                            BackGradientStyle="TopBottom">
                            <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                                <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                            </AxisY>
                            <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                                <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:AccessDataSource ID="DetailSource" runat="server" DataFile="~/data/chartdata.mdb"
                            SelectCommand="SELECT REPS_SALES.Name, REPS_SALES.Sales FROM (REGIONS INNER JOIN REPS_SALES ON REGIONS.RegionID = REPS_SALES.RegionID) WHERE (REGIONS.RegionName = @RegionName)">
                            <SelectParameters>
                                <asp:Parameter DbType="String" DefaultValue="Central" Name="RegionName" />
                            </SelectParameters>
                        </asp:AccessDataSource>
                        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            DataSourceID="DetailSource" ForeColor="#333333" GridLines="None" Width="243px"
                            Caption="Central Region">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Sales" DataFormatString="{0:c}" HeaderText="Sales" ItemStyle-HorizontalAlign="Right">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Size="Smaller" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Chart1" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <p class="dscr" />
    </form>
</body>
</html>
