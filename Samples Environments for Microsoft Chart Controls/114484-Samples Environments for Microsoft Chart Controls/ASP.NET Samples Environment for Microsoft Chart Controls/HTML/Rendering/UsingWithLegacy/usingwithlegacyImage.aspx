<%@ Page Language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.UsingWithLegacyImage" CodeFile="usingwithlegacyImage.aspx.cs" %>
<asp:Chart ID="Chart1" runat="server" Height="296px" Width="412px" ImageType="Png"
    Palette="BrightPastel" BackColor="#F3DFC1" RenderType="BinaryStreaming" BackGradientStyle="TopBottom"
    BorderColor="181, 64, 1" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BorderlineDashStyle="Solid"
    BorderWidth="2"  >
    <Titles>
        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
            Text="ASP.NET Chart on Legacy HTML Page" ForeColor="26, 59, 105">
        </asp:Title>
    </Titles>
    <Legends>
        <asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent"
            Font="Trebuchet MS, 8.25pt, style=Bold">
        </asp:Legend>
    </Legends>
    <BorderSkin SkinStyle="Emboss"></BorderSkin>
    <Series>
        <asp:Series XValueType="Double" Name="Series1" ChartType="Bar" BorderColor="180, 26, 59, 105"
            Color="220, 65, 140, 240" YValueType="Double">
            <Points>
                <asp:DataPoint YValues="6" />
                <asp:DataPoint YValues="9" />
                <asp:DataPoint YValues="3" />
                <asp:DataPoint YValues="5" />
                <asp:DataPoint YValues="2" />
                <asp:DataPoint YValues="7" />
                <asp:DataPoint YValues="8" />
                <asp:DataPoint YValues="1" />
            </Points>
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
            BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
            <Area3DStyle Rotation="10" Perspective="10" Enable3D="True" Inclination="15" IsRightAngleAxes="False"
                WallWidth="0" IsClustered="False"></Area3DStyle>
            <AxisY LineColor="64, 64, 64, 64">
                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
            </AxisY>
            <AxisX LineColor="64, 64, 64, 64">
                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
            </AxisX>
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>
