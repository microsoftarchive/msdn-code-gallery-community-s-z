# VSTO - Deploy a Customization by using Windows Installer (Visual Studio 2012)
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- Excel
- VSTO
- Excel 2010
- Excel 2013
## Topics
- VSTO
- Add-in Deployment
## Updated
- 11/20/2013
## Description

<h1>Introduction</h1>
<p>Learn how to create a Windows Installer file (.msi) for your Office 2013 or Office 2010 document-level customization by using Visual Studio 2012.</p>
<p>When you deploy a solution by using Windows Installer, you distribute a setup program to users. Users install the solution by using that program. The setup program can install a solution for all users of a computer, rather than the current user only. You
 also have a bit more control over options that appear to users when they install your solution. For example, you can show a EULA or enable users to install specific components of a solution.</p>
<h1><span>Building the Sample</span></h1>
<ol>
<li>On the menu bar, choose Build, Build OfficeAddInSetup. </li></ol>
<p style="padding-left:30px">After the build completes, you can locate the <strong>
setup.exe </strong>file of the <strong>OfficeAddInSetup</strong> project at the following location:<em>OfficeAddInSetupProjectRoot\OfficeAddInSetup\Express\SingleImage\DiskImages\DISK1\</em></p>
<p style="padding-left:30px"><strong>Note - </strong>This sample is intended to be used for reference only.&nbsp;To create an installer for your solution, refer to the guidance in the&nbsp;following article on MSDN:
<a href="http://msdn.microsoft.com/en-us/library/cc442767.aspx">Deploying an Office Solution by using Windows Installer</a>.&nbsp; If you want to run this sample you'll have to&nbsp;update file paths in the project.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample shows you how to use InstallShield Limited Edition (ISLE) to create a Windows Installer program for your workbook customization that you create by using Office tools in Visual Studio 2012. ISLE is free for Visual Studio developers and replaces
 the functionality of the project templates in Visual Studio for setup and deployment.</p>
<p>This sample is used as the basis of the following article on MSDN: <a href="http://msdn.microsoft.com/en-us/library/cc442767.aspx">
Deploying an Office Solution by using Windows Installer</a></p>
<p>To view a sample that shows you how to create a Windows Installer to deploy an application-level add-in, see the following sample:
<a href="http://go.microsoft.com/fwlink/?LinkID=275492">VSTO - Deploy an Office Add-in by using Windows Installer (Visual Studio 2012)</a>.</p>
