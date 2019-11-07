<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Home.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ReportViewer Samples Environment</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Welcome to the ReportViewer Samples Environment!</h1>
        <p>
        This solution contains projects that demonstrates how to utilize some of the new 
        features of the Visual Studio 2010 ReportViewer control, such as the AJAX 
        functionalities. It also demonstrates how to implement some common programmatic 
        scenarios.</p>
        <h3>To Run Samples that use Server Reports</h3>
        <ol>
            <li>Install 
            <a href="http://go.microsoft.com/fwlink/?LinkId=181016">SQL Server 2008 Express with 
            Advanced Services</a>. Skip this step if you 
                have an existing report server instance of SQL Server 2008 Reporting Services.</li>
            <li>Install the
            <a href="http://codeplex.com/MSFTDBProdSamples/Release/ProjectReleases.aspx">
            AdventureWorks 2008 Sample Databases</a> in your SQL Server instance.</li>
            <li>Install the
                <a href="http://msftrsprodsamples.codeplex.com/wikipage?title=SS2008%21AdventureWorks%20Sample%20Reports">AdventureWorks 2008 Sample Reports</a> 
                and publish them to your report server.</li>
            <li>In the root solution directory, open <strong>Global.config</strong> and specify the URL of your 
                report server and the folder path that contains the sample reports.</li>
        </ol>

        <h3>To Get Help</h3>
        <ul>
            <li>Read the
                <a href="http://msdn.microsoft.com/en-us/library/bb885185(v=VS.100).aspx">Visual 
                Studio 2010 ReportViewer</a> documentation</li>
            <li>Ask a question on the 
                <a href="http://social.msdn.microsoft.com/forums/en-US/vsreportcontrols/threads/">
                Visual Studio Report Controls</a> forum</li>
        </ul>
        <h3>Samples List</h3>
        <asp:PlaceHolder ID="PlaceholderLinks" runat="server"></asp:PlaceHolder>
    </div>
    </form>

</body>
</html>
