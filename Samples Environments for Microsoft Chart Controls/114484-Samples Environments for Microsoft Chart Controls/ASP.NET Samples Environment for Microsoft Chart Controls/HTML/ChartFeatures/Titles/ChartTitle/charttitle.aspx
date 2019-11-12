<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ChartTitle" CodeFile="ChartTitle.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ChartTitle</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">
				This sample shows how to set the chart title's text, font and color. Note that 
				the PrePaint and PostPaint events allow for custom drawing of the chart's 
				title.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="Pastel" BackColor="#D3DFF0" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" Text="Sales Report\nYear 2001" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend Enabled="False" Name="Default" BackColor="Transparent"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series XValueType="Double" Name="Series1" ChartType="SplineArea" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" YValueType="Double">
									<points>
										<asp:DataPoint XValue="1" YValues="400" />
										<asp:DataPoint XValue="2" YValues="200" />
										<asp:DataPoint XValue="3" YValues="700" />
										<asp:DataPoint XValue="4" YValues="300" />
										<asp:DataPoint XValue="5" YValues="450" />
									</points>
								</asp:Series>
								<asp:Series Name="Series2" ChartType="SplineArea" BorderColor="64, 0, 0, 0" Color="220, 252, 180, 65">
									<points>
										<asp:DataPoint XValue="1" YValues="200" />
										<asp:DataPoint XValue="2" YValues="300" />
										<asp:DataPoint XValue="3" YValues="350" />
										<asp:DataPoint XValue="4" YValues="80" />
										<asp:DataPoint XValue="5" YValues="400" />
									</points>
								</asp:Series>
								<asp:Series Name="Series3" ChartType="SplineArea" BorderColor="64, 0, 0, 0" Color="220, 224, 64, 10">
									<points>
										<asp:DataPoint XValue="1" YValues="500" />
										<asp:DataPoint XValue="2" YValues="120" />
										<asp:DataPoint XValue="3" YValues="300" />
										<asp:DataPoint XValue="4" YValues="50" />
										<asp:DataPoint XValue="5" YValues="130" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2>
										<MajorGrid Enabled="False" />
									</axisy2>
									<axisx2>
										<MajorGrid Enabled="False" />
									</axisx2>
									<area3dstyle PointGapDepth="0" Rotation="5" Perspective="10" Enable3D="True" LightStyle="Realistic" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx TitleFont="Microsoft Sans Serif, 10pt, style=Bold" IsMarginVisible="False" LineColor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Title:</td>
								<td><asp:TextBox id="TitleText" runat="server" Width="175px" AutoPostBack="True">Sales Report\nYear 2001</asp:TextBox></td>
							</tr>
							<tr>
								<td class="label">Tooltip:</td>
								<td><asp:TextBox id="Tooltip" runat="server" Width="175px" Height="24" AutoPostBack="True">Title Tooltip</asp:TextBox></td>
							</tr>
							<tr>
								<td class="label" style="HEIGHT: 25px"></td>
								<td style="HEIGHT: 20px">
									<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button id="Button1" runat="server" Width="98px" Text="Set"></asp:Button><br/>
										<br/>
									</p>
								</td>
							</tr>
							<tr>
								<td class="label">Font Face:</td>
								<td><asp:DropDownList id="FontNameList" runat="server" AutoPostBack="True" Width="175px" Height="24px">
										<asp:ListItem Value="Trebuchet MS" Selected="True">Trebuchet MS</asp:ListItem>
										<asp:ListItem Value="Arial">Arial</asp:ListItem>
										<asp:ListItem Value="Courier New">Courier New</asp:ListItem>
										<asp:ListItem Value="Microsoft Sans Serif">Microsoft Sans Serif</asp:ListItem>
										<asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
										<asp:ListItem Value="Verdana">Verdana</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Font Size:</td>
								<td><asp:DropDownList id="FontSizeList" runat="server" Width="134px" Height="24px" AutoPostBack="True">
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="14" Selected="True">14</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Font Color:</td>
								<td><asp:DropDownList id="ForeColorList" runat="server" Width="134px" Height="24px" AutoPostBack="True">
										<asp:ListItem Value="Black">Black</asp:ListItem>
										<asp:ListItem Value="Blue">Blue</asp:ListItem>
										<asp:ListItem Value="Red">Red</asp:ListItem>
										<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
										<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
										<asp:ListItem Value="MidnightBlue" Selected="True">MidnightBlue</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Border Color:</td>
								<td><asp:DropDownList id="BorderColor" runat="server" Width="134px" Height="24px" AutoPostBack="True">
										<asp:ListItem Value="Black">Black</asp:ListItem>
										<asp:ListItem Value="Blue">Blue</asp:ListItem>
										<asp:ListItem Value="Red">Red</asp:ListItem>
										<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
										<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
										<asp:ListItem Value="Transparent" Selected="True">Transparent</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Back Color:</td>
								<td><asp:DropDownList id="BackColor" runat="server" Width="134px" Height="24px" AutoPostBack="True">
										<asp:ListItem Value="Black">Black</asp:ListItem>
										<asp:ListItem Value="Blue">Blue</asp:ListItem>
										<asp:ListItem Value="Red">Red</asp:ListItem>
										<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
										<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
										<asp:ListItem Value="Transparent" Selected="True">Transparent</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Alignment:</td>
								<td><asp:DropDownList id="Alignment" runat="server" Width="134px" Height="24px" AutoPostBack="True">
										<asp:ListItem Value="Left">Left</asp:ListItem>
										<asp:ListItem Value="Center" Selected="True">Center</asp:ListItem>
										<asp:ListItem Value="Right">Right</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
