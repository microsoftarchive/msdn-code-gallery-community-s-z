# VSTO - Deploy an Office Add-in by using Windows Installer
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
- 09/09/2014
## Description

<h1>Introduction</h1>
<p>Learn how to create a Windows Installer file (.msi) for your Office 2013 or Office 2010 add-in by using Visual Studio 2012.</p>
<p>When you deploy a solution by using Windows Installer, you distribute a setup program to users. Users install the solution by using that program. The setup program can install a solution for all users of a computer, rather than the current user only. You
 also have a bit more control over options that appear to users when they install your solution. For example, you can show a EULA or enable users to install specific components of a solution.</p>
<h1><span>Building the Sample</span></h1>
<ol>
<li>Copy the Visual Studio 2010 Tools for Office Runtime.prq file from the OfficeAddInSetup folder of this sample to one of the following directories on your computer:
<ul>
<li>For 32-bit operating systems: %ProgramFiles%\InstallShield\2013LE\SetupPrerequisites\
</li><li>For 64-bit operating systems: %ProgramFiles(x86)%\2013LE\SetupPrerequisites\ </li></ul>
</li><li>On the menu bar, choose <strong>Build</strong>, <strong>Build OfficeAddInSetup</strong>.
</li></ol>
<p style="padding-left:30px">After the build completes, you can locate the <strong>
setup.exe </strong>file of the <strong>OfficeAddInSetup</strong> project at the following location:
<em>OfficeAddInSetupProjectRoot\OfficeAddInSetup\Express\SingleImage\DiskImages\DISK1\</em></p>
<p style="padding-left:30px"><strong>Note - </strong>This sample is intended to be used for reference only.&nbsp;To create an installer for your solution, refer to the guidance in the&nbsp;following article on MSDN:
<a href="http://msdn.microsoft.com/en-us/library/cc442767.aspx">Deploying an Office Solution by using Windows Installer</a>.&nbsp; If you want to run this sample you'll have to&nbsp;update file paths in the project.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample shows you how to use InstallShield Limited Edition (ISLE) to create a Windows Installer&nbsp;program for your Office add-in.&nbsp;ISLE is free for Visual Studio developers and replaces the functionality of the project templates in Visual Studio
 for setup and deployment.</p>
<p>This sample is used as the basis of the following article on MSDN: <a href="http://msdn.microsoft.com/en-us/library/cc442767.aspx">
Deploying an Office Solution by using Windows Installer</a>.</p>
<p>To view a sample that shows you how to create a Windows Installer to deploy a document-level customization, see the following sample:
<a href="http://go.microsoft.com/fwlink/?LinkID=275493">VSTO - Deploy a Customization by using Windows Installer (Visual Studio 2012)</a>.</p>
