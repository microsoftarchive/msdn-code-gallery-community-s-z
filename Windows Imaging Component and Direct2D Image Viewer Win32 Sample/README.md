# Windows Imaging Component and Direct2D Image Viewer Win32 Sample
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- Direct2D
- Windows Imaging Component (WIC)
## Topics
- Graphics
- Imaging
## Updated
- 10/20/2014
## Description

<h1>Introduction</h1>
<p>This is the Windows Imaging Component and Direct2D image viewer sample from the Windows 7 SDK, updated to use Visual Studio 2012.</p>
<p>This sample demonstrates the basic image display pipeline you should use when building a Direct2D application that targets Windows 7 or the Windows Vista Platform Update. It shows how to decode the image, get the data into a Direct2D bitmap, and render the
 bitmap.</p>
<h1><span>Building the Sample</span></h1>
<p>This sample is built for Visual Studio 2012 and the Windows 7 SDK, but will work with&nbsp;Visual Studio 2013&nbsp;and newer versions of the Windows SDK without any issues.</p>
<p>You may need to upgrade the project to the version of Visual Studio installed on your system. You can do this by opening the .sln file, right clicking on the project in the Solution Explorer, and selecting Upgrade VC&#43;&#43; Compiler and Libraries.</p>
<h1>Running the Sample</h1>
<p>After the application is launched, load an image file by using the&nbsp;<strong>Open&nbsp;</strong>command of the&nbsp;<strong>File&nbsp;</strong>menu.</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li>resource.h - string resource header </li><li>sample.gif - a sample animated GIF image </li><li>WicAnimatedGif.cpp - main source code file for the sample </li><li>WicAnimatedGif.h </li><li>WicAnimatedGif.rc - string resource constants </li><li>WicAnimatedGif.sln - VS2012 solution file </li><li>WicAnimatedGif.vcxproj </li><li>WicAnimatedGif.vcxproj.filters </li></ul>
<h1>More Information</h1>
<p>This sample demonstrates how to use the following APIs:</p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ee719902(v=vs.85).aspx">Windows Imaging Component</a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/dd370990(v=vs.85).aspx">Direct2D</a></p>
