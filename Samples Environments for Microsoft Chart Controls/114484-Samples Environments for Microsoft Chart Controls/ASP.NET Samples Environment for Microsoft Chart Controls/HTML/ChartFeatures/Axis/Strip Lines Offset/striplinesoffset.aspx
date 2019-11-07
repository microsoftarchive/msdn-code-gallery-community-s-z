
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.StripLinesOffset" CodeFile="StripLinesOffset.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to set the offset, interval, strip 
				width, and width type of a StripLine object.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderlineDashStyle="Solid" palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#F3DFC1" BorderColor="181, 64, 1" imagetype="Png" enableviewstate="True">
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series YValuesPerPoint="4" Name="Default" ChartType="Stock" BorderColor="180, 26, 59, 105" Color="65, 140, 240" ShadowOffset="1"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2>
										<MajorGrid Enabled="False" />
									</axisy2>
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False" IntervalAutoMode="VariableCount">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsStaggered="True" Format="d MMM" />
										<MajorGrid LineColor="64, 64, 64, 64" />
										<StripLines>
											<asp:StripLine StripWidth="1" Interval="2" BackColor="128, 241, 185, 168"></asp:StripLine>
										</StripLines>
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server" Height="19px" Width="125px">Interval:</asp:label></td>
								<td>
									<asp:dropdownlist id="Interval" runat="server" AutoPostBack="True" width="75px">
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server" Height="19px" Width="125px">Interval Type:</asp:label>
								</td>
								<td>
									<asp:dropdownlist id="IntervalType" runat="server" AutoPostBack="True">
										<asp:listitem Value="Months">Months</asp:listitem>
										<asp:listitem Value="Weeks">Weeks</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server" Height="19px" Width="125px">Interval Offset:</asp:label></td>
								<td>
									<asp:dropdownlist id="IntervalOffset" runat="server" AutoPostBack="True" width="75px">
										<asp:listitem Value="0">0</asp:listitem>
										<asp:listitem Value="1">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label4" runat="server" Height="19" Width="155px">Interval Offset Type:</asp:label></td>
								<td>
									<asp:dropdownlist id="IntervalOffsetType" runat="server" AutoPostBack="True">
										<asp:listitem Value="Months">Months</asp:listitem>
										<asp:listitem Value="Weeks">Weeks</asp:listitem>
										<asp:listitem Value="Days">Days</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label5" runat="server" Height="19" Width="125">Strip Width:</asp:label></td>
								<td>
									<asp:dropdownlist id="StripWidth" runat="server" AutoPostBack="True" width="75px">
										<asp:listitem Value="0">0</asp:listitem>
										<asp:listitem Value="1" Selected="True">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label6" runat="server" Height="19" Width="125">Strip Width Type:</asp:label></td>
								<td>
									<asp:dropdownlist id="StripWidthType" runat="server" AutoPostBack="True">
										<asp:listitem Value="Weeks">Weeks</asp:listitem>
										<asp:listitem Value="Days">Days</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
