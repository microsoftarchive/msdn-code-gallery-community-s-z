# Survey App Tutorial: Developing a SharePoint Application Using LightSwitch
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- SharePoint
- Visual Studio LightSwitch
- LightSwitch Extensibility
- apps for SharePoint
- SharePoint 2013
## Topics
- SharePoint
- Visual Studio LightSwitch
- Rapid Application Development
- apps for SharePoint
## Updated
- 07/03/2014
## Description

<h1><span style="font-size:20px; font-weight:bold">Introduction</span></h1>
<p><span style="font-size:small">LightSwitch now supports the ability to create SharePoint
</span><span style="font-size:small">applications that can be easily installed to and launched from a SharePoint
</span><span style="font-size:small">site. LightSwitch SharePoint applications automatically handle identity flow
</span><span style="font-size:small">between SharePoint and the LightSwitch application and provide a code
</span><span style="font-size:small">experience for interacting with SharePoint assets.</span></p>
<p><span style="font-size:small">The <em>Survey Application Tutorial: Developing a SharePoint Application Using LightSwitch
</em>will show you how to use LightSwitch to build a SharePoint application with an HTML client that runs on a variety of mobile devices</span><span><span style="font-size:x-small">.&nbsp;
</span></span></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small">Download either the VB or C# source files to a machine that has
<strong><em>Microsoft LightSwitch&nbsp;for Visual Studio 2012 Update 2 </em></strong>or
<strong><em>Visual Studio 2013 </em></strong>installed.&nbsp; </span><span style="font-size:small">Follow
</span><span style="font-size:small">the steps described in the <a href="http://code.msdn.microsoft.com/Survey-App-Tutorial-a70d0afd/file/70702/1/LightSwitchSurveyApplicationTutorial.zip">
<em>Survey Application Tutorial</em> </a>to build a LightSwitch SharePoint application using
</span><span style="font-size:small">these files.&nbsp; </span></p>
<p><span style="font-size:small">To post questions&nbsp;regarding this tutorial, refer to the
<a href="http://social.msdn.microsoft.com/Forums/en-US/lightswitch/threads">LightSwitch forum</a>.
</span><span style="font-size:small">For more information &amp; to download the HTML client see the
<a href="http://msdn.microsoft.com/en-us/lightswitch/htmlclient">HTML Client Resources Page on the Developer Center</a>.
</span></p>
<h1><span style="font-size:small"><span style="font-size:20px; font-weight:bold">Survey Application Overiew</span></span></h1>
<p><em><span style="font-size:small">Contoso Foods</span></em><span style="font-size:small"> is both a food manufacturer and distributor that sells a variety of products to grocery stores nationwide.&nbsp;
<em>Contoso Foods' </em>Sales Representatives play an important role in maintaining relationships with partner stores by frequently visiting each location to deliver products and conduct quality surveys.&nbsp; Quality surveys are completed for every product
 to measure the presence that the product has within the store.&nbsp; Typical survey data that&nbsp;is collected by Sales Representatives includes:</span></p>
<ul>
<li><span style="font-size:small">Cleanliness of the product display (ranging from &quot;very poor&quot; to &quot;excellent&quot;)</span>
</li><li><span style="font-size:small">Quality of the product display (also ranging from &quot;very poor&quot; to &quot;excellent&quot;)</span>
</li><li><span style="font-size:small">Product location within an aisle (middle of aisle, end of aisle, or aisle end-cap)</span>
</li><li><span style="font-size:small">Product shelf height position (top shelf, eye-level shelf, or bottom shelf)</span>
</li></ul>
<p><span style="font-size:small">In addition, as part of completing surveys, photos are taken of the product display to support the overall assessment.</span></p>
<p><span style="font-size:small">On a weekly basis, Sales Representatives visit store locations to take product surveys.&nbsp; Currently, survey data is captured using a clipboard and pen, but this method is slow and increases the likelihood of transcription
 errors.&nbsp; Also, this method makes it difficult to take and attach photos to surveys.&nbsp; To address these problems, the sales team has decided to create a Survey Application that Sales Representatives can access from their tablet devices to easily collect
 survey data and attach photos that have been taken using their device.&nbsp; Specifically, the Survey Application will be an Office 365 SharePoint application created using Visual Studio LightSwitch.&nbsp; Key reasons for this approach are:</span></p>
<ul>
<li><span style="font-size:small">The Sales team recently switched to Office 365 for internal email and collaboration, so Sales Representatives are already used to signing into the team's SharePoint Online site to view customer contact information, marketing
 material, and customer invoices.&nbsp; Based on this, the team's SharePoint sites is the logical place to host and launch the Survey Application.</span>
</li><li><span style="font-size:small">SharePoint Online offers easy access and management of images.&nbsp; SharePoint's Picture Library automatically creates thumbnail and web optimized versions of images which improves performance when displaying photos within
 the application.</span> </li></ul>
<p><span style="font-size:small">This tutorial will walk you through the steps for developing the Survey Application that
<em>Contoso Foods'</em>&nbsp; Sales Representatives will use for completing survey assessments.</span></p>
<p><span style="font-family:Calibri,Calibri; font-size:small">&nbsp;</span></p>
