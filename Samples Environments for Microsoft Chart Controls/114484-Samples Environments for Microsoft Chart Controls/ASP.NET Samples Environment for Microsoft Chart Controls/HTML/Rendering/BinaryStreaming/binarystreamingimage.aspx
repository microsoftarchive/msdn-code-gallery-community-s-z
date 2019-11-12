<%@ Page Language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.BinaryStreamingImage" CodeFile="BinaryStreamingImage.aspx.cs" %>
<asp:chart id="Chart1" runat="server" height="296px" width="412px" imagelocation="~/TempImages/ChartPic_#SEQ(300,3)"
    imagetype="Png" palette="BrightPastel" backcolor="#F3DFC1" rendertype="BinaryStreaming"
    BorderlineDashStyle="Solid" backgradientstyle="TopBottom" borderwidth="2" bordercolor="181, 64, 1">
    <titles>
        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Binary Streaming" ForeColor="26, 59, 105"></asp:Title>
    </titles>
    <legends>
        <asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
    </legends>
    <borderskin skinstyle="Emboss" />
    <series>
        <asp:Series XValueType="Double" Name="Series1" ChartType="SplineArea" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" YValueType="Double">
            <points>
                <asp:DataPoint YValues="6" />
                <asp:DataPoint YValues="9" />
                <asp:DataPoint YValues="3" />
                <asp:DataPoint YValues="5" />
                <asp:DataPoint YValues="2" />
                <asp:DataPoint YValues="7" />
                <asp:DataPoint YValues="8" />
                <asp:DataPoint YValues="1" />
            </points>
        </asp:Series>
    </series>
    <chartareas>
        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
            <area3dstyle Rotation="10" perspective="10" enable3d="True" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
            </area3dstyle>
            <axisy linecolor="64, 64, 64, 64">
                <labelstyle font="Trebuchet MS, 8.25pt, style=Bold"/>
                <majorgrid linecolor="64, 64, 64, 64"/>
            </axisy>

            <axisx IsMarginVisible="False" linecolor="64, 64, 64, 64">
                <labelstyle font="Trebuchet MS, 8.25pt, style=Bold"/>
                <majorgrid linecolor="64, 64, 64, 64"/>
            </axisx>
        </asp:ChartArea>
    </chartareas>
</asp:chart>
