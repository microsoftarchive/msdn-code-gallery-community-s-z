# SharePoint 2013: Get sites, groups and users from the site collection (JSOM)
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- jQuery
- Javascript
- Sharepoint Online
- SharePoint Server 2013
- SharePoint Foundation 2013
- apps for SharePoint
- SharePoint Add-ins
## Topics
- Data Binding
- GridView
- Cross Domain
- JSOM
## Updated
- 08/24/2016
## Description

<p><span id="docs-internal-guid-8125fb6c-be3f-70ed-e433-dbc678a66217"></p>
<p dir="ltr"><span style="font-size:small"><strong>Summary</strong>: Learn how to use the cross-domain library in apps for SharePoint to get groups and users in a grid from an app web.</span></p>
<br>
<p dir="ltr"><span style="font-size:small"><strong>Last modified</strong>: 8/24/2016</span></p>
<br>
<p dir="ltr"><span style="font-size:small">This sample SharePoint hosted app demonstrates how to use the cross-domain library in SharePoint 2013 to get user groups and users list in the app web. The app deploys an grid to the app web, and displays the subsites,
 groups and users by using the JavaScript object model (JSOM).</span></p>
<h2 dir="ltr"><span style="font-size:small">Description of the sample</span></h2>
<p dir="ltr"><span style="font-size:small">The code that uses the cross-domain library and a third party grid control provided by
<a href="http://www.jqwidgets.com/jquery-widgets-documentation/documentation/introduction/introduction.htm">
jQWidgets</a>. The control used in this sample is a trial version. The grid displays all the subsite, user groups of each subsite and users of each group. Grid features like grouping, sorting and filtering are enabled in this app.
</span></p>
<br>
<p dir="ltr"><span style="font-size:small">Figure 1. Browser window display the grid grouped by Web and Group.</span></p>
<br>
<p dir="ltr"><span style="font-size:small"><img src=":-a_l6_z1pnqebkbehhcwwc6pc4ofannkokot0hzaaaiogk2bdfsbpnzlfevkkzbf-tlq2yfwpgdetw79g-6d0ptc3uxvy8wgfmlsyozld-sj14uu5m09cxgi5ht3sadcrnqr0grfd" alt="" width="602" height="299"></span></p>
<p dir="ltr"><span style="font-size:small"></span></p>
<h2 dir="ltr"><span style="font-size:small">Prerequisites</span></h2>
<p dir="ltr"><span style="font-size:small">This sample requires the following:</span></p>
<ul>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">Visual Studio 2015</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Office Developer Tools for Visual Studio 2015</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">A SharePoint 2013 development environment</span></p>
</li></ul>
<br>
<p dir="ltr"><span style="font-size:small">For more information, see <a href="http://msdn.microsoft.com/library/jj163980.aspx">
Get started developing apps for SharePoint</a>.</span></p>
<h2 dir="ltr"><span style="font-size:small">Key components of the sample</span></h2>
<p dir="ltr"><span style="font-size:small">The sample contains the following:</span></p>
<ul>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">GetUserGroups project, which contains the AppManifest.xml file</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">GetUserGroups project</span></p>
<ul>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">Default.aspx file, which contains references to SharePoint JavaScript resource files</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">App.js file, which contains code to fetch data and display results</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">jQWidget folder, which contains all the required JavaScript files and images for grid control.</span></p>
</li></ul>
</li></ul>
<h2 dir="ltr"><span style="font-size:small">Configure the sample</span></h2>
<p dir="ltr"><span style="font-size:small">Follow these steps to configure the sample.</span></p>
<ul>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">Update the SiteUrl property of the solution with the URL of the home page of your SharePoint website.</span></p>
</li></ul>
<h2 dir="ltr"><span style="font-size:small">Run and test the sample</span></h2>
<p dir="ltr"><span style="font-size:small"></span></p>
<ol>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">Press F5 to build and deploy the app.</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Choose Trust It on the consent page to grant permissions to the app.</span></p>
</li></ol>
<p dir="ltr"><span style="font-size:small">You should see an HTML page that displays five announcements.</span></p>
<h2 dir="ltr"><span style="font-size:small">Troubleshooting</span></h2>
<p dir="ltr"><span style="font-size:small">For troubleshooting steps, visit the <a href="http://msdn.microsoft.com/library/bc37ff5c-1285-40af-98ae-01286696242d# SP15Accessdatafromremoteapp_Troubleshoot">
Troubleshooting the solution</a> table in the cross-domain library documentation article.</span></p>
<h2 dir="ltr"><span style="font-size:small">Change log</span></h2>
<ul>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">First version: Aug 24, 2016</span></p>
</li></ul>
</span>
<p></p>
<h1></h1>
