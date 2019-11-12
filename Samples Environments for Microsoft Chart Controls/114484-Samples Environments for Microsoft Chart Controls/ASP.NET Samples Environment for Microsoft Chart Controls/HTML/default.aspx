<%@ Page Language="c#" CodeFile="default.aspx.cs" AutoEventWireup="false" Inherits="System.Web.UI.DataVisualization.Charting.Samples.IndexPage" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Chart for ASP.NET Samples</title>

    <script type="text/javascript">
        var infoPagesFrameRows = "*,40%";
    </script>

</head>
<frameset rows="400,*" id="mainFrameSet" framespacing="0" frameborder="0">
		<frame noresize scrolling="no" id="headerFrame" src="Header.htm">
		<frameset cols="256,*" id="topFrameSet" framespacing="2" frameborder="0">
			<frame scrolling="no" id="navigationFrame" src="NavigationFrameset.htm">
			<frame scrolling="no" id="sampleContentFrame" src="SampleContentFrameset.htm">
		</frameset>
		<noframes>
				<p>This page uses frames, but your browser doesn't support them.</p>
		</noframes>
	</frameset>
</html>
