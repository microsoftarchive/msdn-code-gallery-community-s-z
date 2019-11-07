# Uploading and Downloading in MVC Step-by-Step
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- ASP.NET MVC
- Visual C#
## Topics
- C#
- ASP.NET MVC
- Visual Studio
- Upload
- Download
## Updated
- 07/05/2016
## Description

<p><strong><span style="font-size:small">Using the code</span></strong></p>
<p><span style="font-size:small">Before moving further into the details, let us first list the key points we will explain in this article:</span></p>
<li><span style="font-size:small">Create a MVC application.</span> </li><li><span style="font-size:small">Create a controller.</span> </li><li><span style="font-size:small">Create View depending on the controller.</span>
</li><li><span style="font-size:small">Change the RouteConfig as needed.</span> </li><li><span style="font-size:small">Create ActionResult for the actions.</span> </li><li><span style="font-size:small">Create a folder where we need to save the downloaded files.</span>
<p><span style="font-size:small">Let us start with creating a controller called &ldquo;myAction&rdquo;.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_755429">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td class="gutter">
<div class="line number1 index0 alt2"></div>
</td>
<td class="code">
<div class="container"></div>
</td>
</tr>
</tbody>
</table>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace UploadDownloadInMVC.Controllers
{
    public class myActionController : Controller
    {
        //
        // GET: /myAction/
    }
}</pre>
<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;System.Collections.Generic;&nbsp;
using&nbsp;System.IO;&nbsp;
using&nbsp;System.Linq;&nbsp;
using&nbsp;System.Web;&nbsp;
using&nbsp;System.Web.Mvc;&nbsp;
namespace&nbsp;UploadDownloadInMVC.Controllers&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;myActionController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;/myAction/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">As you can see that the controller is empty; we will be writing the action results next.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_183526">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public ActionResult Index()
       {
           foreach (string upload in Request.Files)
           {
               if (Request.Files[upload].FileName != &ldquo;&rdquo;)
               {
                   string path = AppDomain.CurrentDomain.BaseDirectory &#43; &ldquo;/App_Data/uploads/&rdquo;;
                   string filename = Path.GetFileName(Request.Files[upload].FileName);
                   Request.Files[upload].SaveAs(Path.Combine(path, filename));
               }
           }
           return View(&ldquo;Upload&rdquo;);
       }</pre>
<div class="preview">
<pre class="js">public&nbsp;ActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(string&nbsp;upload&nbsp;<span class="js__operator">in</span>&nbsp;Request.Files)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(Request.Files[upload].FileName&nbsp;!=&nbsp;&ldquo;&rdquo;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;path&nbsp;=&nbsp;AppDomain.CurrentDomain.BaseDirectory&nbsp;&#43;&nbsp;&ldquo;<span class="js__reg_exp">/App_Data/</span>uploads/&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;filename&nbsp;=&nbsp;Path.GetFileName(Request.Files[upload].FileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Request.Files[upload].SaveAs(Path.Combine(path,&nbsp;filename));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View(&ldquo;Upload&rdquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">The action result shown above is for index. So, whenever the application loads, the action result will be fired. For that, the following changes should be done for RouteCofig.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_773437">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute(&ldquo;{resource}.axd/{*pathInfo}&rdquo;);
            routes.MapRoute(
                name: &ldquo;Default&rdquo;,
                url: &ldquo;{controller}/{action}/{id}&rdquo;,
                defaults: new { controller = &ldquo;myAction&rdquo;, action = &ldquo;Index&rdquo;, id = UrlParameter.Optional }
            );
        }
    }</pre>
<div class="preview">
<pre class="js">public&nbsp;class&nbsp;RouteConfig&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;RegisterRoutes(RouteCollection&nbsp;routes)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;routes.IgnoreRoute(&ldquo;<span class="js__brace">{</span>resource<span class="js__brace">}</span>.axd/<span class="js__brace">{</span>*pathInfo<span class="js__brace">}</span>&rdquo;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;routes.MapRoute(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name:&nbsp;&ldquo;Default&rdquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;&ldquo;<span class="js__brace">{</span>controller<span class="js__brace">}</span><span class="js__reg_exp">/{action}/</span><span class="js__brace">{</span>id<span class="js__brace">}</span>&rdquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;defaults:&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__brace">{</span>&nbsp;controller&nbsp;=&nbsp;&ldquo;myAction&rdquo;,&nbsp;action&nbsp;=&nbsp;&ldquo;Index&rdquo;,&nbsp;id&nbsp;=&nbsp;UrlParameter.Optional&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">As you can see in the Index Action, we are checking whether the request parameter contains the files. If it exists, we will save the selected file to the directory</span></p>
<p><span style="font-size:small"><em>/App_Data/uploads/</em>&nbsp;(that we need to manually create in our application). After returning to the view Upload, we need to set the Upload view.</span></p>
<p><strong><span style="font-size:small">Upload View</span></strong></p>
<p><span style="font-size:small">The following is the code for the Upload view.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_152127">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">@{
    ViewBag.Title = &ldquo;Upload&rdquo;;
}
&lt;h2&gt;Upload&lt;/h2&gt;
&lt;script src=&ldquo;~/Scripts/jquery-1.11.1.min.js&rdquo;&gt;&lt;/script&gt;
&lt;script&gt;
    $(document).ready(function () {
        $(&lsquo;#btnUploadFile&rsquo;).on(&lsquo;click&rsquo;, function () {
            var data = new FormData();
            var files = $(&ldquo;#fileUpload&rdquo;).get(0).files;
            // Add the uploaded image content to the form data collection
            if (files.length &gt; 0) {
                data.append(&ldquo;UploadedImage&rdquo;, files[0]);
            }
            // Make Ajax request with the contentType = false, and procesDate = false
            var ajaxRequest = $.ajax({
                type: &ldquo;POST&rdquo;,
                url: &ldquo;myAction/Index&rdquo;,
                contentType: false,
                processData: false,
                data: data
            });
            ajaxRequest.done(function (xhr, textStatus) {
                // Do other operation
            });
        });
    });
&lt;/script&gt;
&lt;input type=&ldquo;file&rdquo; name=&ldquo;FileUpload1&Prime; id=&ldquo;fileUpload&rdquo; /&gt;&lt;br /&gt;
&lt;input id=&ldquo;btnUploadFile&rdquo; type=&ldquo;button&rdquo; value=&ldquo;Upload File&rdquo; /&gt;
@Html.ActionLink(&ldquo;Documents&rdquo;, &ldquo;Downloads&rdquo;)</pre>
<div class="preview">
<pre class="js">@<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;&ldquo;Upload&rdquo;;&nbsp;
<span class="js__brace">}</span>&nbsp;
&lt;h2&gt;Upload&lt;/h2&gt;&nbsp;
&lt;script&nbsp;src=&ldquo;~<span class="js__reg_exp">/Scripts/</span>jquery<span class="js__num">-1.11</span><span class="js__num">.1</span>.min.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&lt;script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#btnUploadFile&rsquo;).on(&lsquo;click&rsquo;,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;data&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FormData();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;files&nbsp;=&nbsp;$(&ldquo;#fileUpload&rdquo;).get(<span class="js__num">0</span>).files;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Add&nbsp;the&nbsp;uploaded&nbsp;image&nbsp;content&nbsp;to&nbsp;the&nbsp;form&nbsp;data&nbsp;collection</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(files.length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.append(&ldquo;UploadedImage&rdquo;,&nbsp;files[<span class="js__num">0</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Make&nbsp;Ajax&nbsp;request&nbsp;with&nbsp;the&nbsp;contentType&nbsp;=&nbsp;false,&nbsp;and&nbsp;procesDate&nbsp;=&nbsp;false</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;ajaxRequest&nbsp;=&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;&ldquo;POST&rdquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;&ldquo;myAction/Index&rdquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contentType:&nbsp;false,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;processData:&nbsp;false,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;data&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ajaxRequest.done(<span class="js__operator">function</span>&nbsp;(xhr,&nbsp;textStatus)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Do&nbsp;other&nbsp;operation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&lt;/script&gt;&nbsp;
&lt;input&nbsp;type=&ldquo;file&rdquo;&nbsp;name=&ldquo;FileUpload1&Prime;&nbsp;id=&ldquo;fileUpload&rdquo;&nbsp;<span class="js__reg_exp">/&gt;&lt;br&nbsp;/</span>&gt;&nbsp;
&lt;input&nbsp;id=&ldquo;btnUploadFile&rdquo;&nbsp;type=&ldquo;button&rdquo;&nbsp;value=&ldquo;Upload&nbsp;File&rdquo;&nbsp;/&gt;&nbsp;
@Html.ActionLink(&ldquo;Documents&rdquo;,&nbsp;&ldquo;Downloads&rdquo;)</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">In the upload view, we have the following:</span></p>
</li><li><span style="font-size:small">File uploader</span> </li><li><span style="font-size:small">Upload button</span> </li><li><span style="font-size:small">Ajax call to the controller ( myAction/Index)</span>
<p><span style="font-size:small">Here, we are adding the uploaded image content to the form data collection.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_619248">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">var data = new FormData();
           var files = $(&ldquo;#fileUpload&rdquo;).get(0).files;
           // Add the uploaded image content to the form data collection
           if (files.length &gt; 0) {
               data.append(&ldquo;UploadedImage&rdquo;, files[0]);
           }</pre>
<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;data&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FormData();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;files&nbsp;=&nbsp;$(&ldquo;#fileUpload&rdquo;).get(<span class="js__num">0</span>).files;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Add&nbsp;the&nbsp;uploaded&nbsp;image&nbsp;content&nbsp;to&nbsp;the&nbsp;form&nbsp;data&nbsp;collection</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(files.length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data.append(&ldquo;UploadedImage&rdquo;,&nbsp;files[<span class="js__num">0</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Once the data is added to the form data collection, we will pass the data to the controller via ajax call. Sounds cool, right? If the procedure goes well, we will see the output as follows.</span></p>
<p><span style="font-size:small"><img src="-upload1.png" alt=""></span></p>
<p><span style="font-size:small"><img src="-upload2.png" alt=""></span></p>
<p><span style="font-size:small">When you choose the file and click upload, your selected file will be uploaded to the folder &ldquo;uploads&rdquo; as we have set it in the controller.</span></p>
<p><span style="font-size:small">We have finished the process of uploading files. We will now move to the downloading section. This is the right time to add the remaining actions to our controller. The following is the code.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_40999">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public ActionResult Downloads()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath(&ldquo;~/App_Data/uploads/&rdquo;));
            System.IO.FileInfo[] fileNames = dir.GetFiles(&ldquo;*.*&rdquo;); List&lt;string&gt; items = new List&lt;string&gt;();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }
        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = &ldquo;~/App_Data/uploads/&rdquo; &#43; ImageName;
            return File(FileVirtualPath, &ldquo;application/force-download&rdquo;, Path.GetFileName(FileVirtualPath));
        }</pre>
<div class="preview">
<pre class="js">public&nbsp;ActionResult&nbsp;Downloads()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;dir&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;System.IO.DirectoryInfo(Server.MapPath(&ldquo;~<span class="js__reg_exp">/App_Data/</span>uploads/&rdquo;));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.IO.FileInfo[]&nbsp;fileNames&nbsp;=&nbsp;dir.GetFiles(&ldquo;*.*&rdquo;);&nbsp;List&lt;string&gt;&nbsp;items&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;string&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(<span class="js__statement">var</span>&nbsp;file&nbsp;<span class="js__operator">in</span>&nbsp;fileNames)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;items.Add(file.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View(items);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;FileResult&nbsp;Download(string&nbsp;ImageName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;FileVirtualPath&nbsp;=&nbsp;&ldquo;~<span class="js__reg_exp">/App_Data/</span>uploads/&rdquo;&nbsp;&#43;&nbsp;ImageName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;File(FileVirtualPath,&nbsp;&ldquo;application/force-download&rdquo;,&nbsp;Path.GetFileName(FileVirtualPath));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Do you remember that we have set an action link in the &ldquo;Upload&rdquo; View?</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_173890">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">@Html.ActionLink(&ldquo;Documents&rdquo;, &ldquo;Downloads&rdquo;)
</pre>
<div class="preview">
<pre class="js">@Html.ActionLink(&ldquo;Documents&rdquo;,&nbsp;&ldquo;Downloads&rdquo;)&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Next, if we click on the &ldquo;Documents&rdquo; link, our Action Result Downloads will be fired, right? Now, the following code will explain what is happening here.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_648393">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var dir = new System.IO.DirectoryInfo(Server.MapPath(&ldquo;~/App_Data/uploads/&rdquo;));
            System.IO.FileInfo[] fileNames = dir.GetFiles(&ldquo;*.*&rdquo;); List&lt;string&gt; items = new List&lt;string&gt;();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);</pre>
<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;dir&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;System.IO.DirectoryInfo(Server.MapPath(&ldquo;~<span class="js__reg_exp">/App_Data/</span>uploads/&rdquo;));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.IO.FileInfo[]&nbsp;fileNames&nbsp;=&nbsp;dir.GetFiles(&ldquo;*.*&rdquo;);&nbsp;List&lt;string&gt;&nbsp;items&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;string&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(<span class="js__statement">var</span>&nbsp;file&nbsp;<span class="js__operator">in</span>&nbsp;fileNames)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;items.Add(file.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View(items);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">We are considering all the attached files, adding the file information to a list and returning this list to the view &ldquo;Download&rdquo;. Next, here&rsquo;s the need to set another view. The following code is for the Download
 View.</span></p>
<p><strong><span style="font-size:small">Download View</span></strong></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_578206">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">@{
    ViewBag.Title = &ldquo;Downloads&rdquo;;
}
&lt;h2&gt;Downloads&lt;/h2&gt;
@model List&lt;string&gt;
&lt;h2&gt;Downloads&lt;/h2&gt;
&lt;table&gt;
    &lt;tr&gt;
        &lt;th&gt;File Name&lt;/th&gt;
        &lt;th&gt;Link&lt;/th&gt;
    &lt;/tr&gt;
    @for (var i = 0; i &lt;= Model.Count &ndash; 1; i&#43;&#43;)
    {
        &lt;tr&gt;
            &lt;td&gt;@Model[i].ToString() &lt;/td&gt;
            &lt;td&gt;@Html.ActionLink(&ldquo;Download&rdquo;, &ldquo;Download&rdquo;, new { ImageName = @Model[i].ToString() }) &lt;/td&gt;
        &lt;/tr&gt;
    }
&lt;/table&gt;</pre>
<div class="preview">
<pre class="js">@<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;&ldquo;Downloads&rdquo;;&nbsp;
<span class="js__brace">}</span>&nbsp;
&lt;h2&gt;Downloads&lt;/h2&gt;&nbsp;
@model&nbsp;List&lt;string&gt;&nbsp;
&lt;h2&gt;Downloads&lt;/h2&gt;&nbsp;
&lt;table&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;File&nbsp;Name&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Link&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;=&nbsp;Model.Count&nbsp;&ndash;&nbsp;<span class="js__num">1</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;@Model[i].ToString()&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;@Html.ActionLink(&ldquo;Download&rdquo;,&nbsp;&ldquo;Download&rdquo;,&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__brace">{</span>&nbsp;ImageName&nbsp;=&nbsp;@Model[i].ToString()&nbsp;<span class="js__brace">}</span>)&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&lt;/table&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Here, we are taking the information (that we are sending from the controller) about the uploaded files and creating the Html.ActionLinks dynamically.</span></p>
<p><span style="font-size:small">Please note that we are adding the Image name to the action. Here is the output after performing the operations.</span></p>
<p><span style="font-size:small"><img src="-downloadwithframe.png" alt=""></span></p>
<p><span style="font-size:small">As in the preceding image, when you mouse over the link, it will show the image name along with the controller URL. Click on the link to download the file. So simple, right?</span></p>
<h1></h1>
</li>