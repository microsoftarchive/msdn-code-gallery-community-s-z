<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomAssembly.Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Using Custom Assemblies in Local Processing Mode</h1>
        <p>When targetting the .NET Framework 4 and running in local processing mode, the Visual Studio 2010 ReportViewer control runs 
           in the sandboxed application domain with the <strong>Execution</strong> permission by default. If you add a custom assembly to your RDLC report,
           you must also use the <strong>LocalReport.AddFullTrustModuleInSandboxAppDomain()</strong> method to add the assembly for use by the 
            <strong>LocalReport</strong> object. Also, if the custom assembly performs any action that requires special 
            permissions, you set these permissions using the <strong>
            LocalReport.SetBasePermissionsForSandboxAppDomain()</strong> method.</p>
        <p>This sample displays an RDLC report that uses the MyLibrary assembly to gets content from a file (which requires
            <strong>System.Security.Permissions.FileIOPermission</strong>) and from a Web 
            site (which requires <strong>System.Net.WebPermission</strong>). The source code 
            for the MyLibrary assembly is included in the solution within the MyLibrary 
            project. A reference to the MyLibrary.dll is added to the WebSamples project so 
            that it can be used by the ReportWithCustomAssembly.rdlc report.</p>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:reportviewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="800px">
            <LocalReport ReportPath="ReportWithCustomAssembly.rdlc">
            </LocalReport>
        </rsweb:reportviewer>

    </div>
    </form>
</body>
</html>
