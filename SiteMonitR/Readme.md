# SiteMonitR
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Microsoft Azure
- Windows Azure Storage
- Windows Azure Web Sites
- SignalR
- ASP.NET Web API 2
- WebJobs
## Topics
- Microsoft Azure
- Windows Azure Storage
- Windows Azure Web Sites
- SignalR
## Updated
- 06/17/2014
## Description

<h1>SiteMonitR Sample</h1>
<p>The SiteMonitR scheduled WebJob pings all of the sites in a list of sites stored in Microsoft Azure Storage. As each site's status is obtained a message is sent to a storage queue. A WebJob running in a Web Site picks up the results of each site's status
 check and saves the log entry to a storage table. Hosted in a Web Site in Azure, a Web API controller receives messages from the WebJobs when sites are pinged. The Web API controller then sends updates to the SiteMonitR dashboard via a SignalR Hub. The result
 is a web-based web site monitoring tool.</p>
<h3><a class="anchor" name="prerequisites" href="#prerequisites"></a>Prerequisites</h3>
<ul>
<li><a href="http://www.microsoft.com/visualstudio/en-us/products">Visual Studio 2013</a>
</li><li><a href="http://www.windowsazure.com/en-us/develop/net/">Windows Azure SDK for .NET 2.2</a>
</li></ul>
<h3><a class="anchor" name="setting-up-the-sample" href="#setting-up-the-sample"></a>Setting up the Sample</h3>
<p>The instructions below will walk you through the process of setting up SiteMonitR both locally on your development workstation and for getting it running live in Microsoft Azure.</p>
<ol>
<li>Download the code </li><li>Open the solution in Visual Studio and compile it. NuGet package restore should pull down all of the required NuGet packages automatically
</li><li>Go to the <strong>bin/Debug</strong> folder of the SiteMonitR.WebJobs.EventDriven project. Zip all of the files (excluding .PDB and .XML files or any file with the term
<strong>vshost</strong>). Rename the zip file to <strong>EventDriven.zip</strong> and copy it to your desktop.
</li><li>Go to the <strong>bin/Debug</strong> folder of the SiteMonitR.WebJobs.Scheduled project. Zip all of the files (excluding .PDB and .XML files or any file with the term
<strong>vshost</strong>). Rename the zip file to <strong>Scheduled.zip</strong> and copy it to your desktop.
</li><li>Publish the SiteMonitR.Web web project into a new Windows Azure Web Site </li><li>If you don't have any Storage accounts in your Azure subscription, create one in the Azure portal.
</li><li>
<p>Copy the storage account's name and primary (or secondary) keys, and build a string representing the storage account connection string. The format of this string looks like this:</p>
<p>DefaultEndpointsProtocol=https;AccountName=[YOUR ACCOUNT NAME];AccountKey=[YOUR ACCOUNT KEY]</p>
</li><li>
<p>Go to the Web Site's <strong>Configure</strong> tab in the Management Portal</p>
</li><li>Create a new Connection String for the web site <strong>using the Azure Management Portal</strong>
<em>(just setting the value in your Web.config file won't work, you need to set this using the portal)</em> you just deployed named
<strong>AzureJobsDashboard</strong> and paste the connection string as the value of the Connection String.
</li><li>Create a new Connection String for the web site <strong>using the Azure Management Portal</strong>
<em>(just setting the value in your Web.config file won't work, you need to set this using the portal)</em> you just deployed named
<strong>AzureJobsStorage</strong> and paste the connection string as the value of the Connection String.
</li><li>Create a new App Setting for the web site <strong>using the Azure Management Portal</strong>. The name of the App Setting should be set to
<strong>SiteMonitR.DashboardUrl</strong> and the value should be your web site's root URL (i.e.,
<a href="http://sitemonitr.azurewebsites.net">http://sitemonitr.azurewebsites.net</a>)
</li><li>Go to the <strong>WebJobs</strong> tab for the Web Site in the Management Portal
</li><li>Click the <strong>Add a Job</strong> link </li><li>Name the job &quot;Event Driven&quot; and upload the <strong>EventDriven.zip</strong> file from your desktop. Select
<strong>Run Continuously</strong> from the <strong>How to Run</strong> drop-down menu.
</li><li>Go to the <strong>WebJobs</strong> tab for the Web Site in the Management Portal
</li><li>Click the <strong>Add</strong> button at the bottom of the Management Portal </li><li>Name the job <strong>Scheduled</strong> and upload the <strong>Scheduled.zip</strong> file from your desktop. Select
<strong>Run on a Schedule</strong> from the <strong>How to Run</strong> drop-down menu.
</li><li>Set the schedule for the Scheduled WebJob per your liking. A suggestion is to set it to run every 15 minutes, but you can specify it for however often you prefer for your sites to be pinged.
</li><li>Restart the web site </li><li>Click the <strong>Browse</strong> button from within the Management Portal to browse the site.
</li><li>Add sites you wish to monitor. </li><li>If you'd like to force the WebJob to ping the sites you add from the SiteMonitR Web Dashboard, select the
<strong>Scheduled</strong> WebJob and click the <strong>Run</strong> button at the bottom of the Management Portal.
</li></ol>
