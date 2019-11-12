# Xml Parsing Sample in Xamarin.Forms (C# - Xaml)
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- Xamarin
- Xamarin.Forms
- UWP
## Topics
- How to create Xamarin.Forms project with VS 2017
- Check network status from Xamarin.Forms app
- Consuming webservice from Xamarin.Forms
- XML parsing in Xamarin.Forms
- ListView Databinding in Xamarin.Forms
## Updated
- 04/17/2017
## Description

<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>Introduction:</strong></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">It is a very common scenario to consuming web-service from the mobile app and from the server you will get XML/JSON response. This article demonstrates how to consume a RESTful web service and
 how to parse the XML response from a Xamarin.Forms application.</span></p>
<p><strong><span style="font-family:verdana,sans-serif; font-size:small; color:#ff0000">You can also read this article from my original blog
<a title="MyBlog" href="http://bsubramanyamraju.blogspot.in/2017/04/xamarinforms-consuming-rest-webserivce.html" target="_blank">
here</a>.</span></strong></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://2.bp.blogspot.com/-m4AaPX97L1U/WPN4KpDZUZI/AAAAAAAADKg/5Fe5mCdaC209S55p9KO9ZsnVWEwN_e0qgCLcB/s1600/Webservice_Diagram.png"><img src=":-webservice_diagram.png" border="0" alt="" width="640" height="480"></a></span></p>
<p><strong style="font-size:small">Requirements:</strong></p>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">This article source code is prepared by using Visual Studio 2017 Enterprise. And it is better to install latest visual studio updates from&nbsp;<a href="https://www.visualstudio.com/downloads/">here</a>.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">This article is prepared on a Windows 10 machine.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">This sample project is Xamarin.Forms PCL project.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">This sample app is targeted for Android, iOS &amp; Windows 10 UWP. And tested for Android &amp; UWP only. Hope this sample source code would work for iOS as well.</span>
</li></ul>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>Description:</strong></span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">This article can explain you below topics:</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">1. How to create Xamarin.Forms PCL project with Visual studio 2017?</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">2. How to check network status from Xamarin.Forms app?</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">3. How to consuming&nbsp;webservice&nbsp;from Xamarin.Forms?</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">4. How to parse XML string?</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">5. How to bind XML&nbsp;response to ListView?</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">Let's learn how to use Visual Studio 2017 to&nbsp;create Xamarin.Forms project.</span></p>
<p><strong style="font-family:verdana,sans-serif; font-size:small">1. How to create Xamarin.Forms PCL project with Visual studio 2017?</strong></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">Before to consume&nbsp;webservice, first we need to create the new project.&nbsp;</span></p>
</div>
<div>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">Launch Visual Studio 2017/2015.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">On the File menu, select New &gt; Project.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">The New Project dialog appears. The left pane of the dialog lets you select the type of templates to display. In the left pane, expand&nbsp;<strong>Installed&nbsp;</strong>&gt;&nbsp;<strong>Templates&nbsp;</strong>&gt;&nbsp;<strong>Visual
 C#</strong>&nbsp;&gt;&nbsp;<strong>Cross-Platform</strong>. The dialog's center pane displays a list of project templates for Xamarin cross platform apps.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">In the center pane, select the Cross Platform App (Xamarin.Forms or Native) template.&nbsp;In the Name text box, type &quot;RestDemo&quot;. Click OK to create the project.
<p class="separator"><a href="https://3.bp.blogspot.com/-pZyeveTtr5M/WPOA9dlKmbI/AAAAAAAADK4/BoIiYokrxhEnZ7ehTc74A5WUg0Srml5XACLcB/s1600/RestDemo.PNG"><img src=":-restdemo.png" border="0" alt="" width="640" height="390"></a></p>
<p class="separator">And in next dialog, select Blank App=&gt;Xamarin.Forms=&gt;PCL.The selected App template creates a minimal mobile app that compiles and runs but contains no user interface controls or data. You add controls to the app over the course
 of this tutorial.</p>
</span></li><li>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://4.bp.blogspot.com/-s_hyRg8XJIk/WPOB5upXjBI/AAAAAAAADLE/-a2NZ_I8ZmAUBWW9RRIm2AZ4Wefy_QUDACLcB/s1600/RestDemo2.PNG"><img src=":-restdemo2.png" border="0" alt="" width="640" height="350"></a></span></p>
</li><li>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">Next dialog will ask for you to confirm that your UWP app support min &amp; target versions. For this sample, I target the app with minimum version 10.0.10240 like below:</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://2.bp.blogspot.com/-9V31M3qBhKY/WPODrp0VAYI/AAAAAAAADLQ/iNRmZu_ALI0g7bqlpAUOPjMo2pxN9S61QCLcB/s1600/2.UWPTargetVersion.PNG"><img src=":-2.uwptargetversion.png" border="0" alt=""></a></span></p>
</li></ul>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>2. How to check network status from Xamarin.Forms app?</strong></span></p>
</div>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">Before call&nbsp;webservice,&nbsp;first&nbsp;we need to check internet connectivity of a device, which can be either mobile data or Wi-Fi. In Xamarin.Forms, we are creating&nbsp;cross platform&nbsp;apps,
 so the different platforms have different implementations.&nbsp;</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">So to check the internet connection in Xamarin.Forms app, we need to follow the steps given below.</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>Step 1:</strong></span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">Go to solution explorer and right click on your solution=&gt;Manage NuGet Packages for&nbsp;solution.</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://1.bp.blogspot.com/-1h7KogxhiYI/WPOHOXIZ8tI/AAAAAAAADLg/82sUUgL6Kc4FIeVKcMizaUuHhm5uycC9QCLcB/s1600/Nuget.PNG"><img src=":-nuget.png" border="0" alt="" width="640" height="498"></a></span></p>
<span style="font-family:verdana,sans-serif; font-size:small">
<p class="separator">Now search for&nbsp;<strong>Xam.Plugin.Connectivity</strong>&nbsp;NuGet package. On the right side, make sure select all platform projects&nbsp;and install it.</p>
<p class="separator"><a href="https://1.bp.blogspot.com/-05PDB_TLAME/WPOHCfHY-MI/AAAAAAAADLc/pX4cTPcWSQMvjHV6YqUzrsDVPdFdfgVmQCLcB/s1600/Xam.Plugin.Connectivity.PNG"><img src=":-xam.plugin.connectivity.png" border="0" alt="" width="640" height="220"></a></p>
<p class="separator"><strong>Step 2:</strong><span style="font-family:Verdana,Arial,Helvetica,sans-serif; font-size:10px">&nbsp;</span></p>
</span></div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">In Android platform, you have to allow the user permission to check internet connectivity. For this, use the steps given below.</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">Right click on&nbsp;<strong>RestDemo.Android</strong>&nbsp;Project and select Properties =&gt; Android Manifest option. Select ACCESS_NETWORK_STATE and INTERNET permission under Required permissions.</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://3.bp.blogspot.com/-NcOCdkpY7pw/WPOKXm9teRI/AAAAAAAADLs/_UYnRdjDJpYguWeEt4-NKOXCVwSNc2_KACLcB/s1600/AndroidManifest.PNG"><img src=":-androidmanifest.png" border="0" alt="" width="640" height="532"></a></span></p>
<span style="font-family:verdana,sans-serif; font-size:small">
<p class="separator"><span style="font-family:verdana,sans-serif"><strong>Step 3:</strong></span></p>
<span style="font-family:verdana,sans-serif">
<p class="separator">Create a class name &quot;NetworkCheck.cs&quot;, and here I placed it in the&nbsp;Model&nbsp;folder. After creating class, add below method to find network status.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;RestDemo.Model&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;NetworkCheck&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsInternet()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(CrossConnectivity.Current.IsConnected)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;write&nbsp;your&nbsp;code&nbsp;if&nbsp;there&nbsp;is&nbsp;no&nbsp;Internet&nbsp;available&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>3. How to consuming&nbsp;webservice&nbsp;from Xamarin.Forms?</strong></div>
<p>&nbsp;</p>
<p class="separator">We can consume webservice&nbsp;in Xamarin using&nbsp;HttpClient. But it is not directly available, and so we need to add &quot;<strong>Microsoft.Net.Http</strong>&quot; from Nuget.</p>
<p class="separator"><strong>Step 1:&nbsp;</strong>Go to solution explorer and right click on your solution=&gt;Manage NuGet Packages for a solution =&gt; search for&nbsp;<strong>Microsoft.Net.Http</strong>&nbsp;NuGet Package=&gt;on the right side, make sure
 select all platform projects&nbsp;and install it.</p>
<p class="separator"><a href="https://4.bp.blogspot.com/-UafKBM4cYhk/WPOOthksRoI/AAAAAAAADL4/TD5xK8Imr9o623r84Kd7E_qkiNNlJy5yQCLcB/s1600/Microsoft.Net.Http.PNG"><img src=":-microsoft.net.http.png" border="0" alt="" width="640" height="220"></a></p>
<p class="separator">&nbsp;</p>
<p class="separator"><strong>Note:&nbsp;</strong>To add &quot;<strong>Microsoft.Net.Http</strong>&quot;, you must install &quot;Microsoft.Bcl.Build&quot; from Nuget. Otherwise, you will get an error like &quot;Could not install package 'Microsoft.Bcl.Build 1.0.14'. You are trying
 to install this package into a project that targets 'Xamarin.iOS,Version=v1.0', but the package does not contain any assembly references or content files that are compatible with that framework.&quot;</p>
<p class="separator"><a href="https://1.bp.blogspot.com/-H5O_tqwYU2A/WPOPsrknnXI/AAAAAAAADME/7MuwzS6ZKIEUCTq758K5i7cNh_XgvaAoACLcB/s1600/Microsoft.Bcl.Build.PNG"><img src=":-microsoft.bcl.build.png" border="0" alt="" width="640" height="218"></a></p>
<p class="separator">&nbsp;</p>
<p class="separator"><strong>Step 2:</strong></p>
<p class="separator">Now it is time to use HttpClient for consuming&nbsp;webservice&nbsp;and before that we need to check the network connection. Please note that In below code you need to replace your&nbsp;URL, or you can also find the demo webservice url
 from the source code given below about this article.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;GetXml()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Check&nbsp;network&nbsp;status&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(NetworkCheck.IsInternet())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;geturi&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;REPLACE&nbsp;YOUR&nbsp;URL&quot;</span>);&nbsp;<span class="cs__com">//replace&nbsp;your&nbsp;xml&nbsp;url&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;responseGet&nbsp;=&nbsp;await&nbsp;client.GetAsync(geturi);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;response&nbsp;=&nbsp;await&nbsp;responseGet.Content.ReadAsStringAsync();<span class="cs__com">//Getting&nbsp;response&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>4. How to parse XML response string in Xamarin.Forms?</strong></div>
<p>&nbsp;</p>
<p class="separator">Generally, we will get a response from webservice in the form of XML/JSON. And we need to parse them to show them on mobile app UI. Let's assume, in the above code we will get below sample XML response.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;menu</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
<span class="xml__tag_start">&lt;item</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
<span class="xml__tag_start">&lt;id</span><span class="xml__tag_start">&gt;</span>1<span class="xml__tag_end">&lt;/id&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;name</span><span class="xml__tag_start">&gt;</span>Margherita<span class="xml__tag_end">&lt;/name&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;cost</span><span class="xml__tag_start">&gt;</span>155<span class="xml__tag_end">&lt;/cost&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;description</span><span class="xml__tag_start">&gt;</span>Single&nbsp;cheese&nbsp;topping<span class="xml__tag_end">&lt;/description&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_end">&lt;/item&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_end">&lt;/menu&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;So to parse above xml, first we need to create class name(XmlPizzaDetails.cs) with relavent properties(id, name, cost &amp; description) like below.
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;XmlPizzaDetails&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;cost&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;description&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;And finally, write below code to parse above XML response.
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;GetXML()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Check&nbsp;network&nbsp;status&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(NetworkCheck.IsInternet())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;geturi&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;REPLACE&nbsp;YOUR&nbsp;URL&quot;</span>);&nbsp;<span class="cs__com">//replace&nbsp;your&nbsp;xml&nbsp;url&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;responseGet&nbsp;=&nbsp;await&nbsp;client.GetAsync(geturi);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;response&nbsp;=&nbsp;await&nbsp;responseGet.Content.ReadAsStringAsync();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Xml&nbsp;Parsing&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;XmlPizzaDetails&gt;&nbsp;ObjPizzaList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;XmlPizzaDetails&gt;();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XDocument&nbsp;doc&nbsp;=&nbsp;XDocument.Parse(response);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;item&nbsp;<span class="cs__keyword">in</span>&nbsp;doc.Descendants(<span class="cs__string">&quot;item&quot;</span>))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XmlPizzaDetails&nbsp;ObjPizzaItem&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XmlPizzaDetails();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjPizzaItem.id&nbsp;=&nbsp;item.Element(<span class="cs__string">&quot;id&quot;</span>).Value.ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjPizzaItem.name&nbsp;=&nbsp;item.Element(<span class="cs__string">&quot;name&quot;</span>).Value.ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjPizzaItem.cost&nbsp;=&nbsp;item.Element(<span class="cs__string">&quot;cost&quot;</span>).Value.ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjPizzaItem.description&nbsp;=&nbsp;item.Element(<span class="cs__string">&quot;description&quot;</span>).Value.ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjPizzaList.Add(ObjPizzaItem);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Binding&nbsp;listview&nbsp;with&nbsp;server&nbsp;response&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listviewPizza.ItemsSource&nbsp;=&nbsp;ObjPizzaList;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;DisplayAlert(<span class="cs__string">&quot;XmlParsing&quot;</span>,<span class="cs__string">&quot;No&nbsp;network&nbsp;is&nbsp;available.&quot;</span>,<span class="cs__string">&quot;Ok&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Hide&nbsp;loader&nbsp;after&nbsp;server&nbsp;response&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProgressLoader.IsRunning&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>5. How to bind XML&nbsp;response to ListView?</strong></div>
</div>
</div>
</span><span style="font-family:verdana,sans-serif">
<p class="separator">Generally, it is very common scenario is showing a list of items in ListView from the server response.</p>
<p class="separator">Let's assume we have below xml response from the server via webservice.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;menu</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
<span class="xml__tag_start">&lt;item</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
<span class="xml__tag_start">&lt;id</span><span class="xml__tag_start">&gt;</span>1<span class="xml__tag_end">&lt;/id&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;name</span><span class="xml__tag_start">&gt;</span>Margherita<span class="xml__tag_end">&lt;/name&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;cost</span><span class="xml__tag_start">&gt;</span>155<span class="xml__tag_end">&lt;/cost&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;description</span><span class="xml__tag_start">&gt;</span>Single&nbsp;cheese&nbsp;topping<span class="xml__tag_end">&lt;/description&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_end">&lt;/item&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;item</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
<span class="xml__tag_start">&lt;id</span><span class="xml__tag_start">&gt;</span>2<span class="xml__tag_end">&lt;/id&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;name</span><span class="xml__tag_start">&gt;</span>Double&nbsp;Cheese&nbsp;Margherita<span class="xml__tag_end">&lt;/name&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;cost</span><span class="xml__tag_start">&gt;</span>225<span class="xml__tag_end">&lt;/cost&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;description</span><span class="xml__tag_start">&gt;</span>Loaded&nbsp;with&nbsp;Extra&nbsp;Cheese<span class="xml__tag_end">&lt;/description&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_end">&lt;/item&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;item</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
<span class="xml__tag_start">&lt;id</span><span class="xml__tag_start">&gt;</span>3<span class="xml__tag_end">&lt;/id&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;name</span><span class="xml__tag_start">&gt;</span>Fresh&nbsp;Veggie<span class="xml__tag_end">&lt;/name&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;cost</span><span class="xml__tag_start">&gt;</span>110<span class="xml__tag_end">&lt;/cost&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_start">&lt;description</span><span class="xml__tag_start">&gt;</span>Oninon&nbsp;and&nbsp;Crisp&nbsp;capsicum<span class="xml__tag_end">&lt;/description&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_end">&lt;/item&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xml__tag_end">&lt;/menu&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">See there is 3 different items in above xml response and if we want to plan for showing them in ListView first we need to add below Xaml code in your ContentPage(<strong>XmlParsingPage.xaml</strong>).
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;?xml</span>&nbsp;<span class="xaml__attr_name">version</span>=<span class="xaml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xaml__attr_name">encoding</span>=<span class="xaml__attr_value">&quot;utf-8&quot;</span>&nbsp;<span class="xaml__tag_start">?&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_start">&lt;ContentPage</span>&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://xamarin.com/schemas/2014/forms&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2009/xaml&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;RestDemo.XmlParsingPage&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;*&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;10&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Xml&nbsp;Parsing&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;25&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;listviewPizza&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span>&nbsp;<span class="xaml__attr_name">HasUnevenRows</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>.ItemTemplate<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ViewCell</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span>&nbsp;<span class="xaml__attr_name">Padding</span>=<span class="xaml__attr_value">&quot;10&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;name}&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;StartAndExpand&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">TextColor</span>=<span class="xaml__attr_value">&quot;Blue&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">FontAttributes</span>=<span class="xaml__attr_value">&quot;Bold&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;cost}&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;StartAndExpand&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">TextColor</span>=<span class="xaml__attr_value">&quot;Orange&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">FontAttributes</span>=<span class="xaml__attr_value">&quot;Bold&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;description}&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;StartAndExpand&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;<span class="xaml__attr_name">TextColor</span>=<span class="xaml__attr_value">&quot;Gray&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">FontAttributes</span>=<span class="xaml__attr_value">&quot;Bold&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;BoxView</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,10,10,0&quot;</span>&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;Gray&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;3&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ViewCell&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView.ItemTemplate&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ListView&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ActivityIndicator</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ProgressLoader&quot;</span>&nbsp;<span class="xaml__attr_name">IsRunning</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_end">&lt;/ContentPage&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-family:verdana,sans-serif">See in above code there is a ListView which was binded with relevant propeties (name, cost, description) which was mentioned in our class name called&nbsp;</span><strong>XmlPizzaDetails.cs</strong>.</div>
</div>
</span>
<p class="separator"><span>Finally, we need to bind our ListView with list like below:(</span><strong>Please find which was already mentioned in the 4th section of GetXML method at 25th line</strong><span>)</span></p>
<ol class="dp-c">
<li><span style="color:#000000"><span class="comment" style="color:#008200">&nbsp;&nbsp;//Binding&nbsp;listview&nbsp;with&nbsp;server&nbsp;response</span><span>&nbsp;&nbsp;</span></span>
</li><li class="alt"><span style="color:#000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listviewPizza.ItemsSource&nbsp;=&nbsp;ObjPizzaList; &nbsp;</span>
</li></ol>
<span style="font-family:verdana,sans-serif">
<p class="separator"><strong><span style="text-decoration:underline">Demo Screens from Android:</span></strong></p>
<p class="separator"><a href="https://2.bp.blogspot.com/-uI7FGAc5Lz4/WPOXu3hI43I/AAAAAAAADMU/UiCnJiWHBb4YFugOdkg1u9kboR71YVmugCLcB/s1600/XmlParsing.PNG"><img src=":-xmlparsing.png" border="0" alt=""></a></p>
<p class="separator"><a href="https://4.bp.blogspot.com/-VFHXQOgQJkE/WPOX3kdn_-I/AAAAAAAADMY/ztQgdMmeWRc1oPsMPYmcTth5FG6h_JLUgCLcB/s1600/XmlParsingDetails.PNG"><img src=":-xmlparsingdetails.png" border="0" alt=""></a></p>
<p class="separator">&nbsp;</p>
<p class="separator"><strong><span style="text-decoration:underline">Demo Screens from Windows10 UWP:</span></strong></p>
<p class="separator"><a href="https://2.bp.blogspot.com/-6SCLp0iocdc/WPOZKapF3rI/AAAAAAAADMk/_cYZJwA7q3QN6Nfr6NZBHVL8QJHwJ4VUwCLcB/s1600/UWPScreen.PNG"><img src=":-uwpscreen.png" border="0" alt="" width="640" height="505"></a></p>
<br>
<p class="separator"><a href="https://4.bp.blogspot.com/-aqpUi1nemiU/WPOZL_AP4iI/AAAAAAAADMo/idzMy9C6JT4qx8Jo6KKsmnyZ4UG2ToYYACLcB/s1600/UWPScreen2.PNG"><img src=":-uwpscreen2.png" border="0" alt="" width="640" height="504"></a></p>
<p class="separator"><span style="color:#ff0000"><strong><strong>You can also read this article from my original blog&nbsp;<a title="MyBlog" href="http://bsubramanyamraju.blogspot.in/2017/04/xamarinforms-consuming-rest-webserivce.html" target="_blank">here</a>.</strong></strong></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif"><strong><strong><span>&nbsp;</span></strong>FeedBack Note:</strong></span><span style="font-family:verdana,sans-serif">&nbsp;Please share your thoughts, what you think about this post, Is this
 post really helpful for you? Otherwise, it would be very&nbsp;happy, if&nbsp;you have any thoughts for to implement this requirement in any other way? I always welcome if you drop comments on this post and it would be impressive.</span></p>
<div>
<p><span>Follow me always at&nbsp;<a href="https://twitter.com/Subramanyam_B">@Subramanyam_B</a></span></p>
<p><span><a href="https://twitter.com/Subramanyam_B"></a></span><span style="font-family:verdana,sans-serif">Have a nice day by</span><span style="color:#000000; font-family:verdana,sans-serif">&nbsp;</span><a rel="author" href="http://bsubramanyamraju.blogspot.in/p/about-me.html">Subramanyam
 Raju</a><span style="color:#000000; font-family:verdana,sans-serif">&nbsp;:)</span></p>
</div>
</span></span></div>
