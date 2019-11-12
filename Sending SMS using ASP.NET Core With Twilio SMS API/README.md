# Sending SMS using ASP.NET Core With Twilio SMS API
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- ASP.NET MVC
- jQuery
- ASP.NET Web API
- Twilio
- Visual Studio 2015
- ASP.NET Core
## Topics
- C#
- ASP.NET MVC
- jQuery
- ASP.NET Web API
- Twilio
- Visual Studio 2015
- ASP.NET Core
## Updated
- 12/07/2017
## Description

<h1>Introduction</h1>
<p><span>In this article, we will explain how to Send SMS using ASP.NET Core With Twilio SMS API. Twilio provides third party SMS API for sending sms over the global network. So we can learn a little bit through this article.</span></p>
<h1><span><strong>Package&nbsp;Installation</strong></span></h1>
<ol>
<li>Install-Package Twilio -Version 5.9.1 </li></ol>
<p><span>This package will install all the sms,video,etc related classes,methods and API&rsquo;s for twilio.</span></p>
<ol>
<li>Install-Package jQuery.Validation.Unobtrusive -Version 2.0.20710 </li></ol>
<p><span>This package will install all the bootstrap &amp; validation related Jquery libraries in our project.</span></p>
<h1><strong>Important Notes</strong></h1>
<p>1. <span>If you don&rsquo;t have any twilio account then you should register a free account using the following link</span>&nbsp;<a rel="noopener" href="https://www.twilio.com/try-twilio" target="_blank">Click here</a>&nbsp;&amp; I choose language as &ldquo;C#&rdquo;.</p>
<p><span>2.&nbsp;<span>Once registration is completed then we can access Dashboard and Console of our twilio account. We will get&nbsp;</span><em><strong>&ldquo;Account SID &amp; Auth Token Id&rdquo;</strong></em><span>&nbsp;from Dashboard for sending sms.</span></span></p>
<p><span>3. <span>We need a Twilio From number because that number has sent sms to the global network! So we need to enable Twilio SMS number ( This will send sms from ur &ldquo;To&rdquo; numbers ). Go to this link</span>&nbsp;</span><a rel="noopener" href="https://www.twilio.com/console/sms/getting-started/build" target="_blank">click
 here</a><span>&nbsp;<span>and Click on the &ldquo;Get a number&rdquo; button in the &ldquo;Programmble SMS Menu&rdquo; mentioned in the following screenshot.</span></span></p>
<p><span>4. <span>You have to get $15 for sending sms In the twilio trial account. I can see in my account they are charging $1 &#43; for each sms and after that you need to buy a paid plan.</span></span></p>
<h1><strong>Name Spaces</strong></h1>
<p><span>The following namespaces are providing&nbsp;</span><em>&ldquo;ASP.Net Core MVC&rdquo; &amp; &ldquo;Twilio SMS API&rdquo;</em><span>Classes &amp; Methods.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;Microsoft.AspNetCore.Mvc;&nbsp;
using&nbsp;RegistrationForm.ViewModels;&nbsp;
using&nbsp;Twilio;&nbsp;
using&nbsp;Twilio.Types;&nbsp;
using&nbsp;Twilio.Rest.Api.V2010.Account;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1><strong><strong>Code</strong></strong></h1>
<p><span><span>The following code help to send sms over the global network using ASP.Net Core With Twilio SMS API.</span></span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IActionResult&nbsp;Registration(RegistrationViewModel&nbsp;model)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="js__string">&quot;Message&quot;</span>]&nbsp;=&nbsp;<span class="js__string">&quot;Your&nbsp;registration&nbsp;page!.&quot;</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.SuccessMessage&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(model.Email.Contains(<span class="js__string">&quot;menoth.com&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ModelState.AddModelError(<span class="js__string">&quot;Email&quot;</span>,&nbsp;<span class="js__string">&quot;We&nbsp;don't&nbsp;support&nbsp;menoth&nbsp;Address&nbsp;!!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ModelState.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Find&nbsp;your&nbsp;Account&nbsp;Sid&nbsp;and&nbsp;Auth&nbsp;Token&nbsp;at&nbsp;twilio.com/user/account</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">const</span>&nbsp;string&nbsp;accountSid&nbsp;=&nbsp;<span class="js__string">&quot;AXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">const</span>&nbsp;string&nbsp;authToken&nbsp;=&nbsp;<span class="js__string">&quot;6XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TwilioClient.Init(accountSid,&nbsp;authToken);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;to&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PhoneNumber(<span class="js__string">&quot;&#43;91&quot;</span>&nbsp;&#43;&nbsp;model.Mobile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;message&nbsp;=&nbsp;MessageResource.Create(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;to,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;from:&nbsp;<span class="js__operator">new</span>&nbsp;PhoneNumber(<span class="js__string">&quot;&#43;18XXXXXXXXXX&quot;</span>),&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;From&nbsp;number,&nbsp;must&nbsp;be&nbsp;an&nbsp;SMS-enabled&nbsp;Twilio&nbsp;number&nbsp;(&nbsp;This&nbsp;will&nbsp;send&nbsp;sms&nbsp;from&nbsp;ur&nbsp;&quot;To&quot;&nbsp;numbers&nbsp;).</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;body:&nbsp;&nbsp;$<span class="js__string">&quot;Hello&nbsp;{model.Name}&nbsp;!!&nbsp;Welcome&nbsp;to&nbsp;Asp.Net&nbsp;Core&nbsp;With&nbsp;Twilio&nbsp;SMS&nbsp;API&nbsp;!!&quot;</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ModelState.Clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.SuccessMessage&nbsp;=&nbsp;<span class="js__string">&quot;Registered&nbsp;Successfully&nbsp;!!&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine($<span class="js__string">&quot;&nbsp;Registration&nbsp;Failure&nbsp;:&nbsp;{ex.Message}&nbsp;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h1><strong><strong>New Tag Helpers</strong></strong></h1>
<p><span>We used latest ASP.NET Core Tag Helpers in Registration page to access controller and actions, validation etc.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;div&nbsp;asp-validation-summary=<span class="js__string">&quot;All&quot;</span>&nbsp;class=<span class="js__string">&quot;text-danger&quot;</span>&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;
&lt;label&nbsp;asp-<span class="js__statement">for</span>=<span class="js__string">&quot;Name&quot;</span>&gt;&lt;/label&gt;&nbsp;&nbsp;&nbsp;
&lt;input&nbsp;asp-<span class="js__statement">for</span>=<span class="js__string">&quot;Name&quot;</span>&nbsp;class=<span class="js__string">&quot;form-control&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&lt;span&nbsp;asp-validation-<span class="js__statement">for</span>=<span class="js__string">&quot;Name&quot;</span>&nbsp;class=<span class="js__string">&quot;text-danger&quot;</span>&gt;&lt;/span&gt;&nbsp;&nbsp;&nbsp;
&lt;a&nbsp;asp-controller=<span class="js__string">&quot;Home&quot;</span>&nbsp;asp-action=<span class="js__string">&quot;Home&quot;</span>&nbsp;class=<span class="js__string">&quot;btn&nbsp;btn-info&quot;</span>&gt;Cancel&lt;/a&gt;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1><strong><strong>Inject Tag Helpers</strong></strong></h1>
<p><span>In the way given below, we can inject the Tag Helpers in our Application. Now, create the default &ldquo;_ViewImports.cshtml&rdquo; file in View Folder and add the code given below in that file.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">@addTagHelper&nbsp;<span class="js__string">&quot;*,Microsoft.AspNetCore.Mvc.TagHelpers&quot;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1><strong><strong>OutPut</strong></strong></h1>
<p><span>We will get a sms from the Twilio account, once we have registered successfully.</span></p>
<p><img id="183296" src="183296-output.png" alt="" width="500" height="888"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1><strong>Reference</strong></h1>
<ul>
<li><strong><a title="Twilio API Docs" href="https://www.twilio.com/docs/api">https://www.twilio.com/docs/api</a><br>
</strong></li><li><a title="Tech Blog Ref" href="https://rajeeshmenoth.wordpress.com/2017/12/06/sending-sms-using-asp-net-core-with-twilio-sms-api/" target="_blank">https://rajeeshmenoth.wordpress.com/2017/12/06/sending-sms-using-asp-net-core-with-twilio-sms-api/</a>
</li></ul>
<p><strong><br>
</strong></p>
