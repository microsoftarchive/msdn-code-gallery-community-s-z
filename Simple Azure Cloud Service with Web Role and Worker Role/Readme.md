# Simple Azure Cloud Service with Web Role and Worker Role
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Microsoft Azure
- Windows Azure Storage
- Windows Azure Storage Queues
- Windows Azure Storage Blobs
## Topics
- Microsoft Azure
- Windows Azure Cloud Services
## Updated
- 12/28/2015
## Description

<h1>Introduction</h1>
<p>The purpose of the sample is to provide a quick introduction to Azure Cloud Services using&nbsp;.NET. The application is an advertising bulletin board. Users create an ad by entering text and uploading an image. They can see a list of ads with thumbnail
 images, and they can see the full size image when they select an ad to see the details. A background process running in a worker role creates thumbnails of the uploaded images. Here's a screenshot and an architecture diagram.</p>
<p><img id="114261" src="114261-list.png" alt="" width="717" height="583"></p>
<p>&nbsp;</p>
<p><img id="122143" src="122143-apparchitecturecloudservice.png" alt="" width="536" height="392"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p><span>The sample&nbsp;was built using Visual Studio 2013 and the Azure SDK for .NET version 2.7.1. It has been tested and works with Visual Studio 2015 and SDK version 2.8.1.&nbsp; See the More Information section for a link to the tutorial which specifies
 SQL Database connection string changes required to use the sample with Visual Studio 2015.<br>
</span></p>
<ol>
<li>Download and unzip the completed solution. </li><li>Start Visual Studio. </li><li>From the File menu choose Open Project, navigate to where you downloaded the solution, and then open the solution file.
</li><li>Press CTRL&#43;SHIFT&#43;B to build the solution. By default, Visual Studio automatically restores the NuGet package content, which was not included in the .zip file. If the packages don't restore, install them manually by going to the Manage NuGet Packages for
 Solution dialog and clicking the Restore button at the top right. </li><li>In Solution Explorer, make sure that ContosoAdsCloudService is selected as the startup project.
</li><li>Press CTRL&#43;F5 to run the application. </li></ol>
<h1>More Information</h1>
<p>For a step-by-step tutorial that explains the code and shows how to build, test, and deploy the application, see
<a href="http://azure.microsoft.com/en-us/documentation/articles/cloud-services-dotnet-get-started/">
Get Started with Azure Cloud Services and ASP.NET</a>.</p>
