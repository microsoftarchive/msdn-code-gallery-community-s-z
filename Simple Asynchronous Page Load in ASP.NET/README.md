# Simple Asynchronous Page Load in ASP.NET
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- AJAX
- ASP.NET
## Topics
- Async Data Load
## Updated
- 06/06/2012
## Description

<h1>Simple Asynchronous Page Load in ASP.NET</h1>
<p>Sometimes when you create a website it is necessary to load some part of the page asynchronously. This can be for various reason including cases when you refer to a different page (like: RSS Feeds, your tweets, and many more). Loading these contents when
 your page is loaded can have a huge impact on your site speed. Sometime it can completely prevent your site from opening (if your external content site is down, or connection cannot be established), or showing error to the users.</p>
<h1><span>Building the Sample</span></h1>
<p>To avoid this, it is good practice (at least I think so), to load these contents after your site has been loaded. This is asynchronous loading. There are many ways to achieve this, but they are hard to implement. This method which I will describe is very
 easy to implement.<br>
You don't need anything else than Microsoft Visual Studio to implement this. This tutorial is created by using Visual Studio 2010, but it won't differ on older versions.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>On the ASP.Net page of your web form add AJAX Script Manager, just below the form tag. Now from the AJAX Extensions Tab in the Toolbox add Timer, below script manager and inside the form tag. Add Tick event for your timer control. Make sure the timer is
 enabled, and set the Interval to 1 (note that the units are in milliseconds). Now the tick event of the timer will fire 1 millisecond after the page has been loaded.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;form1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:ScriptManager&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;ScriptManager1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/asp:ScriptManager&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:Timer&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;Timer1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">Interval</span>=<span class="html__attr_value">&quot;1&quot;</span>&nbsp;<span class="html__attr_name">OnTick</span>=<span class="html__attr_value">&quot;Timer1_Tick&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/asp:Timer&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//Add&nbsp;UpdatePanel&nbsp;here&nbsp;
<span class="html__tag_end">&lt;/form&gt;</span></pre>
</div>
</div>
</div>
<p><span>When the timer ticks, it reloads the whole page. To prevent full page reload, I will add an UpdatePanel inside form tag. On the UpdatePanel I will add a label which will indicate the state. To trigger the update of UpdatePanel1, I used the tick event
 of Timer1 for Asynchronous Post Back. Now when the timer ticks, it only refreshes UpdatePanel1 and not the whole page.</span></p>
<div class="endscriptcode"><span>All page content outside the UpdatePanel will be loaded on Page_Load event, and the content inside the UpdatePanel will be loaded 1 second after the page has been loaded (when the timer ticks).</span><br>
<br>
<span>Now on the timer tick event add your code to load your external content. In my case I loaded an external RSS Feed. The timer repeats&nbsp;continuously on the specified interval time, and this means that our external content will keep loading, in this
 case, every second. In order the timer tick event not to repeat, on the tick method I will disable the timer.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">Timer1.Enabled&nbsp;=&nbsp;false;</pre>
</div>
</div>
</div>
<div class="endscriptcode">When the timer will execute for the first time, it will disable itself and make sure it never runs again. Below that you can write your code, which doesn't have to load RSS or external content at all. It can be some report which
 takes longer to load, and you don't want users to think your page is not loading.</div>
<p><span><span>I also added error handling. If the RSS cannot be loaded, then it shows some friendly message to the users informing that something went wrong, and doesn't display error message.</span></span></p>
