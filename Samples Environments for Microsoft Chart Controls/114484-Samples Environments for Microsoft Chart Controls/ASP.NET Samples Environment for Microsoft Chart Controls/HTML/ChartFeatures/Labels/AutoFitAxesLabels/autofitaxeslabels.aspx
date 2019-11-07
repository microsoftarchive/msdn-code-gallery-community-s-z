
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.AutoFitAxesLabels" CodeFile="AutoFitAxesLabels.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LabelsKeywords</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="LabelsKeywords" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to automatically fit labels along an 
				axis.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderColor="26, 59, 105" Palette="BrightPastel" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#D3DFF0">
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="ChartArea1" XValueType="DateTime" Name="Series1" BorderColor="180, 26, 59, 105">
									<points>
										<asp:DataPoint XValue="37622" YValues="345" />
										<asp:DataPoint XValue="37623" YValues="634" />
										<asp:DataPoint XValue="37624" YValues="154" />
										<asp:DataPoint XValue="37625" YValues="765" />
										<asp:DataPoint XValue="37626" YValues="376" />
										<asp:DataPoint XValue="37627" YValues="600" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 Enabled="False"></axisy2>
									<axisx2 Enabled="False"></axisx2>
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt" Format="C" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False" IntervalAutoMode="VariableCount">
										<LabelStyle Font="Trebuchet MS, 8.25pt" Format="ddd, MMM dd" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>
									<asp:checkbox id="checkBoxAutoFit" runat="server" AutoPostBack="True" Text="X Axis Labels Automatic Fitting" oncheckedchanged="checkBoxAutoFit_CheckedChanged"></asp:checkbox></td>
							</tr>
							<tr>
								<td colspan="2">&nbsp;&nbsp; Automatic Fitting Style:</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:checkbox id="CheckBoxFontSize" runat="server" AutoPostBack="True" Text="Modify Font Size" Checked="True" Enabled="False" oncheckedchanged="CheckBoxFontSize_CheckedChanged"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:checkbox id="CheckBoxOffset" runat="server" AutoPostBack="True" Text="Use Offset Labels" Checked="True" Enabled="False" oncheckedchanged="CheckBoxOffset_CheckedChanged"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:checkbox id="checkBoxWordWrap" runat="server" AutoPostBack="True" Text="Use Word Wrap" Checked="True" Enabled="False" oncheckedchanged="checkBoxWordWrap_CheckedChanged"></asp:checkbox></td>
							</tr>
							<tr>
								<td colspan="2">
									&nbsp;&nbsp;&nbsp;Possible Labels Angle:
									<asp:dropdownlist id="DropDownListAngles" runat="server" AutoPostBack="True" Enabled="False" onselectedindexchanged="DropDownListAngles_SelectedIndexChanged">
										<asp:listitem Value="Not Changed">Not Changed</asp:listitem>
										<asp:listitem Value="0-30-60-90" Selected="True">0-30-60-90</asp:listitem>
										<asp:listitem Value="0-45-90">0-45-90</asp:listitem>
										<asp:listitem Value="0-90">0-90</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">For more information on this sample, 
				Click the Overview tab at the top of this frame.</p>
		</form>
	</body>
</html>
