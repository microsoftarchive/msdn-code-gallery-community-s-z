
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.StripLinesTitle" CodeFile="StripLinesTitle.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates how to set a StripLine object's title.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart" valign="top"><asp:chart id="Chart1" runat="server" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderlineDashStyle="Solid" palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#F3DFC1" BorderColor="181, 64, 1">
							<legends>
								<asp:legend Enabled="False" Name="Default" BackColor="Transparent"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series BorderWidth="3" XValueType="Double" Name="Default" ChartType="Line" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="400" />
										<asp:datapoint XValue="2" YValues="200" />
										<asp:datapoint XValue="3" YValues="700" />
										<asp:datapoint XValue="4" YValues="300" />
										<asp:datapoint XValue="5" YValues="450" />
									</points>
								</asp:series>
								<asp:series BorderWidth="3" Name="Series2" ChartType="Line">
									<points>
										<asp:datapoint XValue="1" YValues="200" />
										<asp:datapoint XValue="2" YValues="300" />
										<asp:datapoint XValue="3" YValues="350" />
										<asp:datapoint XValue="4" YValues="80" />
										<asp:datapoint XValue="5" YValues="400" />
									</points>
								</asp:series>
								<asp:series BorderWidth="3" Name="Series3" ChartType="Line">
									<points>
										<asp:datapoint XValue="1" YValues="500" />
										<asp:datapoint XValue="2" YValues="120" />
										<asp:datapoint XValue="3" YValues="300" />
										<asp:datapoint XValue="4" YValues="50" />
										<asp:datapoint XValue="5" YValues="130" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2>
										<majorgrid enabled="False" />
									</axisy2>
									<axisx2>
										<majorgrid enabled="False" />
									</axisx2>
									<area3dstyle pointgapdepth="0" Rotation="5" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
										<striplines>
											<asp:stripline StripWidth="2" Interval="3" IntervalOffset="0.5" BackColor="64, 191, 191, 191"></asp:stripline>
										</striplines>
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td colspan="2" nowrap align="right">
									<asp:textbox id="Title" runat="server" width="233px">Strip Lines Title</asp:textbox>
									<asp:button id="Set" runat="server" Text="Set"></asp:button>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server" Height="19px" Width="142px">Horizontal Alignment:</asp:label></td>
								<td>
									<asp:dropdownlist id="TextAlignment" runat="server" AutoPostBack="True" Height="22px" Width="115px" cssclass="spaceright"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server" Height="19px" Width="127px"> Vertical Alignment:</asp:label></td>
								<td>
									<asp:dropdownlist id="TextLineAlignment" runat="server" AutoPostBack="True" Height="22px" Width="115px" cssclass="spaceright"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server" Height="19px" Width="127px">Title Angle:</asp:label></td>
								<td>
									<asp:dropdownlist id="TextOrientation" runat="server" AutoPostBack="True" Height="22px" Width="115px" cssclass="spaceright">
										<asp:listitem Value="0">0</asp:listitem>
										<asp:listitem Value="90">90</asp:listitem>
										<asp:listitem Value="180">180</asp:listitem>
										<asp:listitem Value="270">270</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label4" runat="server" Height="19px" Width="127px">Title Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="Color1" runat="server" AutoPostBack="True" Height="22px" Width="115px" cssclass="spaceright">
										<asp:listitem Value="Red">Red</asp:listitem>
										<asp:listitem Value="Green">Green</asp:listitem>
										<asp:listitem Value="Blue">Blue</asp:listitem>
										<asp:listitem Value="Yellow">Yellow</asp:listitem>
										<asp:listitem Value="Brown">Brown</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label5" runat="server" Height="19" Width="127">Title Font:</asp:label></td>
								<td>
									<asp:dropdownlist id="Font1" runat="server" AutoPostBack="True" Height="22px" Width="115px" cssclass="spaceright"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label6" runat="server" Height="19" Width="127">Title Font Size:</asp:label></td>
								<td>
									<asp:dropdownlist id="TitleSize" runat="server" AutoPostBack="True" Height="22" Width="115" cssclass="spaceright">
										<asp:listitem Value="8">8</asp:listitem>
										<asp:listitem Value="10">10</asp:listitem>
										<asp:listitem Value="12">12</asp:listitem>
										<asp:listitem Value="14">14</asp:listitem>
										<asp:listitem Value="16">16</asp:listitem>
										<asp:listitem Value="18">18</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Italic:</td>
								<td>
									<asp:checkbox id="Italic" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Bold:</td>
								<td>
									<asp:checkbox id="Bold" runat="server" AutoPostBack="True" checked="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Underline:</td>
								<td>
									<asp:checkbox id="Underline" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Strikeout:</td>
								<td>
									<asp:checkbox id="Strikeout" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
