<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.Distributions" CodeFile="Distributions.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>CustomSortingOrder</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form id="CustomSortingOrder" method="post" runat="server">
			<p class="dscr">This sample demonstrates three statistical distribution formulas: 
                normal distribution, <i>t</i>-distribution (also called Student’s <i>t</i>-distribution) 
                and F-distribution. </p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Width="360px" Height="260px" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="WhiteSmoke" BorderColor="26, 59, 105" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" onload="Chart1_Load">
<legends>
<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far">
<position y="5" height="15" width="30" x="63">
</position>
</asp:Legend>
</legends>

<borderskin skinstyle="Emboss">
</borderskin>

<series>
<asp:Series Name="Distributions" ChartType="Area" CustomProperties="LabelStyle=&quot;down&quot;" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240"></asp:Series>
</series>

<chartareas>
<asp:ChartArea BackImageTransparentColor="White" Name="ChartArea1" BackImageWrapMode="Unscaled" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom" BackImageAlignment="Center">
<InnerPlotPosition y="2.99507" height="87.62751" width="88.8228" x="9.4162">
</InnerPlotPosition>

<axisy2 IsLabelAutoFit="False">
</axisy2>

<axisx2 IsLabelAutoFit="False">
</axisx2>

<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<position y="5.542373" height="87.64407" width="89.43796" x="4.824818">
</position>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisx>
</asp:ChartArea>
</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td><asp:label id="Label1" runat="server">Distribution Name:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="DropDownList" runat="server" Width="137px" AutoPostBack="True">
										<asp:listitem Value="Normal Distribution" Selected="True">Normal Distribution</asp:listitem>
										<asp:listitem Value="T Distribution">T Distribution</asp:listitem>
										<asp:listitem Value="F Distribution">F Distribution</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:label id="Label2" runat="server"> Probability:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="DropDownList1" tabIndex="1" runat="server" Width="136px" AutoPostBack="True">
										<asp:listitem Value="10">10</asp:listitem>
										<asp:listitem Value="20">20</asp:listitem>
										<asp:listitem Value="40">40</asp:listitem>
										<asp:listitem Value="60">60</asp:listitem>
										<asp:listitem Value="80">80</asp:listitem>
										<asp:listitem Value="90">90</asp:listitem>
										<asp:listitem Value="95" Selected="True">95</asp:listitem>
										<asp:listitem Value="99">99</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p><asp:checkbox id="CheckBox1" tabIndex="2" runat="server" AutoPostBack="True" Text="One Tail"></asp:checkbox></p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td><asp:label id="Label3" runat="server">Degree of freedom:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td valign="center" style="PADDING-LEFT: 68px">
									N:
									<asp:dropdownlist id="DropDownList2" tabIndex="3" runat="server" AutoPostBack="True">
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
										<asp:listitem Value="4">4</asp:listitem>
										<asp:listitem Value="5">5</asp:listitem>
										<asp:listitem Value="8">8</asp:listitem>
										<asp:listitem Value="10" Selected="True">10</asp:listitem>
										<asp:listitem Value="15">15</asp:listitem>
										<asp:listitem Value="20">20</asp:listitem>
										<asp:listitem Value="30">30</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td valign="center" style="PADDING-LEFT: 68px">
									M:
									<asp:dropdownlist id="DropDownList3" tabIndex="4" runat="server" AutoPostBack="True">
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
										<asp:listitem Value="5">5</asp:listitem>
										<asp:listitem Value="8">8</asp:listitem>
										<asp:listitem Value="10" Selected="True">10</asp:listitem>
										<asp:listitem Value="15">15</asp:listitem>
										<asp:listitem Value="20">20</asp:listitem>
										<asp:listitem Value="30">30</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td valign="center">
									<asp:label id="Label6" runat="server">Result Value:</asp:label>
									<asp:label id="ResultValue" runat="server" ForeColor="Red">Label</asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
