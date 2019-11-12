# Universal Windows App Communication between WebView and Application
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Javascript
- universal windows app
## Topics
- C#
- WebView
- universal app
## Updated
- 09/22/2015
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">Windows 10 introduces a new way to communicate between Application and Web Content.</span></p>
<p><span style="font-size:small">Now, you can call the new <a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.webview.addweballowedobject.aspx">
WebView.AddWebAllowedObject</a></span><span style="font-size:small"> method to inject a WinRT object into a XAML WebView, and then call its functions from trusted JavaScript hosted in that WebView.</span></p>
<p><span style="font-size:small">This allows several interesting scenarios.</span></p>
<p id="gt-input-tool" style="display:inline-block"><span style="font-size:small">It enables smooth interaction between the application and the WebView Control.</span></p>
<p style="display:inline-block"><span style="font-size:small">Now developers are able to directly inject a native C#/C&#43;&#43; object into the script engine.</span><span class="short_text" lang="en" style="font-size:small">&nbsp;</span><em><span class="short_text" lang="en" style="font-size:small">
<span class="hps">&nbsp;</span></span> </em></p>
<p><span style="font-size:small">This sample shows how expose a native Windows Runtime object as a global parameter in the context of the top level document inside of a WebView.</span></p>
<h1><span>Building the Sample</span></h1>
<p><em>It requires the latest&nbsp;CTP version of&nbsp;Visual Studio 2015 and the developer tools for Windows 10.
<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">Windows 10 improves the communication between Application and Web Content.</span></p>
<div class="O1"><span style="font-size:small">It enables smooth interaction between the application and the WebView Control.</span></div>
<div class="O1"><span style="font-size:small">Now developers are able to directly inject a native C#/C&#43;&#43; object into the script engine.</span></div>
<p>&nbsp;</p>
<p><span style="font-size:small">For a Windows Runtime object to be projected, it must implement the
<a href="https://msdn.microsoft.com/it-it/library/windows/apps/hh802476.aspx"><strong>IAgileObject</strong></a> interface and be decorated with the
<strong>AllowForWeb</strong> attribute. If the object doesn&rsquo;t implement <strong>
IAgileObject</strong> then the input is considered invalid.</span></p>
<h1><span style="font-size:small">Note:</span></h1>
<p><span style="font-size:small">In this sample I used local web content. <span style="font-size:small">
Conversely, you have to specify the URIs in Package.appxmanifest.xml. </span></span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml">&nbsp;<span class="xml__tag_start">&lt;uap</span><span class="xml__tag_start">:ApplicationContentUriRules&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;uap</span>:Rule&nbsp;<span class="xml__attr_name">Match</span>=<span class="xml__attr_value">&quot;https://*.something.com&quot;</span>&nbsp;<span class="xml__attr_name">Type</span>=<span class="xml__attr_value">&quot;include&quot;</span>&nbsp;<span class="xml__attr_name">WindowsRuntimeAccess</span>=<span class="xml__attr_value">&quot;all&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/uap:ApplicationContentUriRules&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><br>
<em>&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;[AllowForWeb]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">sealed</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SharedObject&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;getApplicationVersion()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PackageVersion&nbsp;version&nbsp;=&nbsp;Package.Current.Id.Version;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;String.Format(<span class="cs__string">&quot;{0}.{1}.{2}.{3}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;version.Major,&nbsp;version.Minor,&nbsp;version.Build,&nbsp;version.Revision);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;SharedObject&nbsp;communicationWinRT&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SharedObject();&nbsp;&nbsp;
&nbsp;
<span class="cs__keyword">this</span>.webViewControl.AddWebAllowedObject(<span class="cs__string">&quot;sharedObj&quot;</span>,&nbsp;communicationWinRT);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;reload()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'log'</span>).innerHTML&nbsp;=&nbsp;<span class="js__string">'Application&nbsp;Version:&nbsp;'</span>&nbsp;&#43;&nbsp;window.sharedObj.getApplicationVersion();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;log(string)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&lt;/script&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
More Information</h1>
<p><em>If you have any questions or suggestions please contact me u.felloni@gmail.com</em></p>
