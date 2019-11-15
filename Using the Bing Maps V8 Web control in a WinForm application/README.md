# Using the Bing Maps V8 Web control in a WinForm application
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Bing Maps
- WinForms
## Topics
- Bing Maps
- WinForms
## Updated
- 12/14/2016
## Description

<h1>Introduction</h1>
<p>This code sample shows how to load the Bing Maps V8 Web control inside of a WinForm application using a WebBrowser control. In addition to this is also provides an example of how to call JavaScript functions from the C# code to call functionality in the
 webpage, along with an example of how to call C# from JavaScript to update values in WinForm controls based on information in the map.</p>
<h1><span>Building the Sample</span></h1>
<p>In order to get the map to load correctly and be able to geocode search values, you must add your Bing Maps key to the Html\Map.html file where it says &quot;Your Bing Maps Key&quot;.</p>
<div>If you do not have a Bing Maps key you can get ne by first creating a Bing Maps account and then a key as documented here:</div>
<div></div>
<div><a href="http://msdn.microsoft.com/en-us/library/gg650598.aspx">http://msdn.microsoft.com/en-us/library/gg650598.aspx</a></div>
<div><a href="http://msdn.microsoft.com/en-us/library/ff428642.aspx">http://msdn.microsoft.com/en-us/library/ff428642.aspx</a><strong>&nbsp;</strong><em>&nbsp;</em></div>
<p>Alternatively,&nbsp;you can&nbsp;get a Bing Maps key through the Azure Marketplace here:
<a href="https://azure.microsoft.com/en-us/marketplace/partners/bingmaps/mapapis/">
https://azure.microsoft.com/en-us/marketplace/partners/bingmaps/mapapis/</a><strong>&nbsp;</strong><em>&nbsp;</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>When you run this application you will see a search box/button where you can enter in addresses or places to search for. Beside this information displaying the center latitude and longitude value and the zoom level of the map will be constantly updated as
 you move the map.</p>
<p><em><img id="165768" src="https://i1.code.msdn.s-msft.com/using-the-bing-maps-v8-web-07e21f3a/image/file/165768/1/v8winform.png" alt="" width="800" height="598" style="width:573px; height:438px"></em></p>
<h1>More Information</h1>
<p>Here are some additional resources about the Bing Maps V8 web control:</p>
<ul type="disc">
<li><a href="http://www.bing.com/api/maps/sdk/mapcontrol/isdk"><span><span style="color:#0563c1">Bing Maps V8 Interactive SDK</span></span></a>
</li><li><span><a href="https://msdn.microsoft.com/en-us/library/mt712542.aspx"><span><span style="color:#0563c1">Bing Maps V8 documentation</span></span></a></span>
</li><li><a href="https://github.com/Microsoft/Bing-Maps-V8-TypeScript-Definitions"><span><span style="color:#0563c1">Bing Maps V8 TypeScript Definitions</span></span></a>
</li></ul>
<p><strong>&nbsp;</strong><em>&nbsp;</em></p>
<p><em><br>
</em></p>
