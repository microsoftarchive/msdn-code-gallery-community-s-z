# WPF Automation - Loading webpages, auto-completing & submitting web forms
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- WebBrowser
- Webpage Automation
- IHTMLDocument2
- IHTMLElementCollection
- HTMLInputElement
## Updated
- 06/28/2013
## Description

<h1>Introduction</h1>
<p>A complete example of using WPF to automatically load a webpage, fill in a web form and submit the form. This sample uses the methods and properties provided by the IHTMLDocument2 interface to analyse the web page contents. With this, you can search for
 elements within, edit, remove and fiddle as much as you like.</p>
<p><img id="63052" src="http://i1.code.msdn.s-msft.com/wpf-automation-loading-6ae6c88a/image/file/63052/1/binsearch.png" alt="" width="644" height="632">&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p>Just download, unblock, unzip, open and run.</p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample is based around the WebBrowser control. To interract with the contents of the page, we use IHTMLDocument2. This interface and the other objects you see in this sample come from mshtml.dll COM componant, which you must include in the references
 of your project.</p>
<p>In this case we are finding, completing and submitting the query form on the Bing search page. The code below is used to find the first form element on the webpage:&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">IHTMLDocument2&nbsp;doc&nbsp;=&nbsp;(IHTMLDocument2)wb1.Document;&nbsp;
IHTMLElementCollection&nbsp;forms&nbsp;=&nbsp;doc.forms;&nbsp;
var&nbsp;ix&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
<span class="cs__keyword">foreach</span>&nbsp;(IHTMLFormElement&nbsp;f&nbsp;<span class="cs__keyword">in</span>&nbsp;forms)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ix&#43;&#43;&nbsp;==&nbsp;formNo)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;f;&nbsp;
&nbsp;
<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">null</span>;</pre>
</div>
</div>
</div>
<p>Once we have the form, we look for a form element with a specific name:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;element&nbsp;=&nbsp;form.item(name:&nbsp;name);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>Now if the element exists, we cast it back to the class that we want, and set it's properties, in this case &quot;value&quot;. The field we are looking for here is the HTMLInputElement</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">if</span>&nbsp;(element&nbsp;!=&nbsp;null)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;textarea&nbsp;=&nbsp;element&nbsp;as&nbsp;HTMLInputElement;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;textarea.value&nbsp;=&nbsp;text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;successful&nbsp;=&nbsp;true;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Finally, if all is well, we can submit the form as simply as this:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">form.submit();</pre>
</div>
</div>
</div>
<div class="endscriptcode">With these techniques of finding and casting webpage parts into solid classes, we can do just about anything with the webpage, including&nbsp;processing HTML5 web pages, canvases and storage, inject Javascript (like GreeseMonkey)
 and automate scraping or inputting form data.&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><strong>Other notes</strong></div>
</div>
<p>Watch out for the forms collection, make sure you are checking in the right form from the collection.</p>
<p>View the source and search/count the &lt;FORM&gt; tags to check which form you need. Webpages often have several.</p>
<p>&nbsp;</p>
<p><a href="http://msdn.microsoft.com/en-us/library/aa752038(v=vs.85)">MSHTML</a></p>
<p>The ultimate guide to webpage manipulation.</p>
<p>&nbsp;</p>
<p><a href="http://msdn.microsoft.com/en-us/library/aa752574(v=vs.85).aspx">IHTMLDocument2</a></p>
<p>Note also the &quot;elementFromPoint&quot; and &quot;all&quot; properties of IHTMLDocument2. &quot;All&quot; is a complete collection of tags from the webpage.</p>
<p>Ideally you can usually get to an element by name, as I show in the example, check the source of a page for the element names.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li>MainWindow.xaml - Starup window </li><li>MainWindow.xaml.cs - All the code for the sample </li></ul>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img src="http://213.163.64.28/aniThanks1.gif" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
