# Simple Azure Website with WebJobs using the WebJobs SDK
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Microsoft Azure
## Topics
- Microsoft Azure
## Updated
- 02/11/2015
## Description

<h1>Introduction</h1>
<p>The purpose of the sample is to provide a quick introduction to the Azure WebJobs SDK. The application is an advertising bulletin board. Users create an ad by entering text and uploading an image. They can see a list of ads with thumbnail images, and they
 can see the full size image when they select an ad to see the details. A background process running in a worker role creates thumbnails of the uploaded images. Here's a screenshot and an architecture diagram.</p>
<p><img id="114261" src="114261-list.png" alt="" width="717" height="583"></p>
<p><img id="122144" src="122144-apparchitecture.png" alt="" width="536" height="392"></p>
<h1><span>Building the Sample</span></h1>
<ol>
<li>Download and unzip the completed solution. </li><li>Make sure that you have installed the Azure .NET SDK version 2.4 or later. </li><li>Start Visual Studio. </li><li>From the File menu choose Open Project, navigate to where you downloaded the solution, and then open the solution file.
</li><li>Press CTRL&#43;SHIFT&#43;B to build the solution. By default, Visual Studio automatically restores the NuGet package content, which was not included in the .zip file. If the packages don't restore, install them manually by going to the Manage NuGet Packages for
 Solution dialog and clicking the Restore button at the top right. </li><li>In Solution Explorer, make sure that ContosoAdsWeb is selected as the startup project.
</li><li>Edit the web project Web.config and the WebJob project App.config, and replace the placeholders with your storage account name and access key.
</li><li>Press CTRL&#43;F5 to run the web site. </li><li>Right-click the WebJob project, and then click Debug &gt; Start new instance.
</li></ol>
<h1>More Information</h1>
<p>For a step-by-step tutorial that explains the code and shows how to build, test, and deploy the application, see
<a href="http://azure.microsoft.com/en-us/documentation/articles/websites-dotnet-webjobs-sdk-get-started/">
Get Started with the Azure WebJobs SDK</a>.</p>
