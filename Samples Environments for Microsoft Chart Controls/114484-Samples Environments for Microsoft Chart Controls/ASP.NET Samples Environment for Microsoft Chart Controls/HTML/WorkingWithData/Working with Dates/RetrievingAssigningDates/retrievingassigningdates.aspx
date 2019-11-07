<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.RetrievingAssigningDates" CodeFile="RetrievingAssigningDates.aspx.cs" %>

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
		<%this.AfterLoad();%>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">
				This sample shows how to set minimum and maximum axis values using DateTime values.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" 
                            Width="413px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" 
                            BackColor="WhiteSmoke" BackSecondaryColor="White" BackGradientStyle="TopBottom" 
                            BorderlineDashStyle="Solid" palette="BrightPastel" BorderWidth="2" 
                            BorderColor="26, 59, 105">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="ChartArea1" XValueType="DateTime" Name="Series1" ChartType="Line" CustomProperties="LabelsRadialLineSize=1, LabelStyle=outside" BorderColor="180, 26, 59, 105" Color="80, 99, 129"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 enabled="False"></axisy2>
									<axisx2 enabled="False"></axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" IsStaggered="True" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>Minimum Date:</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="Mon1" runat="server" Width="55px" AutoPostBack="True">
										<asp:listitem Value="1">Jan</asp:listitem>
										<asp:listitem Value="2">Feb</asp:listitem>
										<asp:listitem Value="3">Mar</asp:listitem>
										<asp:listitem Value="4">Apr</asp:listitem>
										<asp:listitem Value="5">May</asp:listitem>
										<asp:listitem Value="6">Jun</asp:listitem>
										<asp:listitem Value="7">Jul</asp:listitem>
										<asp:listitem Value="8">Aug</asp:listitem>
										<asp:listitem Value="9">Sep</asp:listitem>
										<asp:listitem Value="10">Oct</asp:listitem>
										<asp:listitem Value="11">Nov</asp:listitem>
										<asp:listitem Value="12">Dec</asp:listitem>
									</asp:dropdownlist>
									<asp:dropdownlist id="Day1" runat="server" AutoPostBack="True">
										<asp:listitem Value="1">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
										<asp:listitem Value="4">4</asp:listitem>
										<asp:listitem Value="5">5</asp:listitem>
										<asp:listitem Value="6">6</asp:listitem>
										<asp:listitem Value="7">7</asp:listitem>
										<asp:listitem Value="8">8</asp:listitem>
										<asp:listitem Value="9">9</asp:listitem>
										<asp:listitem Value="10">10</asp:listitem>
										<asp:listitem Value="11">11</asp:listitem>
										<asp:listitem Value="12">12</asp:listitem>
										<asp:listitem Value="13">13</asp:listitem>
										<asp:listitem Value="14">14</asp:listitem>
										<asp:listitem Value="15">15</asp:listitem>
										<asp:listitem Value="16">16</asp:listitem>
										<asp:listitem Value="17">17</asp:listitem>
										<asp:listitem Value="18">18</asp:listitem>
										<asp:listitem Value="19">19</asp:listitem>
										<asp:listitem Value="20">20</asp:listitem>
										<asp:listitem Value="21">21</asp:listitem>
										<asp:listitem Value="22">22</asp:listitem>
										<asp:listitem Value="23">23</asp:listitem>
										<asp:listitem Value="24">24</asp:listitem>
										<asp:listitem Value="25">25</asp:listitem>
										<asp:listitem Value="26">26</asp:listitem>
										<asp:listitem Value="27">27</asp:listitem>
										<asp:listitem Value="28">28</asp:listitem>
										<asp:listitem Value="29">29</asp:listitem>
										<asp:listitem Value="30">30</asp:listitem>
										<asp:listitem Value="31">31</asp:listitem>
									</asp:dropdownlist>
									<asp:dropdownlist id="Year1" runat="server" AutoPostBack="True">
										<asp:ListItem Value="2001">2001</asp:ListItem>
										<asp:ListItem Value="2002">2002</asp:ListItem>
										<asp:ListItem Value="2003">2003</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>Maximum Date:</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="Day2" runat="server" AutoPostBack="True">
										<asp:listitem Value="1">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
										<asp:listitem Value="4">4</asp:listitem>
										<asp:listitem Value="5">5</asp:listitem>
										<asp:listitem Value="6">6</asp:listitem>
										<asp:listitem Value="7">7</asp:listitem>
										<asp:listitem Value="8">8</asp:listitem>
										<asp:listitem Value="9">9</asp:listitem>
										<asp:listitem Value="10">10</asp:listitem>
										<asp:listitem Value="11">11</asp:listitem>
										<asp:listitem Value="12">12</asp:listitem>
										<asp:listitem Value="13">13</asp:listitem>
										<asp:listitem Value="14">14</asp:listitem>
										<asp:listitem Value="15">15</asp:listitem>
										<asp:listitem Value="16">16</asp:listitem>
										<asp:listitem Value="17">17</asp:listitem>
										<asp:listitem Value="18">18</asp:listitem>
										<asp:listitem Value="19">19</asp:listitem>
										<asp:listitem Value="20">20</asp:listitem>
										<asp:listitem Value="21">21</asp:listitem>
										<asp:listitem Value="22">22</asp:listitem>
										<asp:listitem Value="23">23</asp:listitem>
										<asp:listitem Value="24">24</asp:listitem>
										<asp:listitem Value="25">25</asp:listitem>
										<asp:listitem Value="26">26</asp:listitem>
										<asp:listitem Value="27">27</asp:listitem>
										<asp:listitem Value="28">28</asp:listitem>
										<asp:listitem Value="29">29</asp:listitem>
										<asp:listitem Value="30">30</asp:listitem>
										<asp:listitem Value="31">31</asp:listitem>
									</asp:dropdownlist>
									<asp:dropdownlist id="Mon2" runat="server" Width="55px" AutoPostBack="True">
										<asp:listitem Value="1">Jan</asp:listitem>
										<asp:listitem Value="2">Feb</asp:listitem>
										<asp:listitem Value="3">Mar</asp:listitem>
										<asp:listitem Value="4">Apr</asp:listitem>
										<asp:listitem Value="5">May</asp:listitem>
										<asp:listitem Value="6">Jun</asp:listitem>
										<asp:listitem Value="7">Jul</asp:listitem>
										<asp:listitem Value="8">Aug</asp:listitem>
										<asp:listitem Value="9">Sep</asp:listitem>
										<asp:listitem Value="10">Oct</asp:listitem>
										<asp:listitem Value="11">Nov</asp:listitem>
										<asp:listitem Value="12">Dec</asp:listitem>
									</asp:dropdownlist>
									<asp:dropdownlist id="Year2" runat="server" AutoPostBack="True">
										<asp:ListItem Value="2004">2004</asp:ListItem>
										<asp:ListItem Value="2005" Selected="True">2005</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>&nbsp;<br/>
									Maximum Y value occurs on:</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:label id="Label1" runat="server" Width="242px" ForeColor="Red">Label</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p><br/>
										<asp:button id="Random1" runat="server" Text="Random Data" CommandArgument="5" width="160px" onclick="Button1_Click"></asp:button></p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
		</body>
</html>
