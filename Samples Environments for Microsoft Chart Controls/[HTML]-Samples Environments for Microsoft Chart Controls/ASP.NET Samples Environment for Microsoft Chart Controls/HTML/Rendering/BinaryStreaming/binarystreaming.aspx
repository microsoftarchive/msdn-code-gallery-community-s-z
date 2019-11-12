<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.BinaryStreaming" CodeFile="BinaryStreaming.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>BinaryStreaming</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../samples.css" type="text/css" rel="stylesheet" />
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates the&nbsp;binary streaming rendering 
				method.&nbsp;The first page contains the Chart control, and the second page an 
                Image element with its ImageUrl attribute set to the first page.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:image id="Image1" runat="server" ImageUrl="binarystreamingimage.aspx" width="412px" height="296px"></asp:image></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
		</form>
	</body>
</html>
