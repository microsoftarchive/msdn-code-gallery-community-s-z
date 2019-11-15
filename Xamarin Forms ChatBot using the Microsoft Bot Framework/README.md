# Xamarin Forms ChatBot using the Microsoft Bot Framework
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- Xamarin.Android
- Xamarin.iOS
- Xamarin.Forms
- UWP
- Microsoft Bot Framework
- Bots
## Topics
- Xamarin.Forms
- Microsoft Bot Framework
## Updated
- 06/10/2017
## Description

<p><span id="docs-internal-guid-2646162d-90eb-f328-ca36-12a7ca2294b6">&nbsp;</span></p>
<h1 dir="ltr">Introduction:</h1>
<p dir="ltr"><span style="font-size:small">The Bots Framework that run inside skype ,web chat , Facebook ,Message ,etc. Users can interact with bots by sending them messages, commands and&nbsp;inline requests. You control your bots using HTTPS requests to our&nbsp;bot
 API.</span></p>
<p dir="ltr"><span style="font-size:small">In this article, how you can integrate a bot right into your Xamarin.Forms application via the Microsoft Bot Framework Web bots.</span></p>
<p dir="ltr"><span style="font-size:small"><img id="174299" src="174299-t6g5bojnm5.gif" alt="" width="376" height="489"><br>
</span></p>
<h1 dir="ltr"><span>Create new bot Application:</span></h1>
<p dir="ltr"><span style="font-size:small">You can read my previous article for Getting Started with Bots Using Visual Studio 2017 from following URL&nbsp;</span></p>
<p dir="ltr"><span style="font-size:small"><a href="https://code.msdn.microsoft.com/Getting-Started-with-4ae6fdb0?redir=0">1.Getting Started with Building Bots using Visual Studio 2017</a></span></p>
<h1 dir="ltr"><span>Publish Bot Application to Azure:</span></h1>
<p dir="ltr"><span style="font-size:small">You can read my previous articles for publish bot application to azure from following URL&nbsp;</span></p>
<p dir="ltr"><a href="https://code.msdn.microsoft.com/Getting-Started-Deploy-a-cfc825ad?redir=0"><span style="font-size:small">1.Getting Started Deploy a bot to Azure using Visual studio 2017</span></a></p>
<p dir="ltr">&nbsp;</p>
<h1 dir="ltr"><span>Generate Web Chat Code:</span></h1>
<p dir="ltr"><span style="font-size:small">After publish you bots into azure, you can generate web Chat html code from bots portal as per below
</span></p>
<p dir="ltr"><span style="font-size:small"><strong>Step 1</strong><br class="kix-line-break">
Sign in to the Bot framework Portal - https://dev.botframework.com/</span></p>
<p dir="ltr"><span style="font-size:small"><strong>Step 2</strong><br class="kix-line-break">
Click My Bots </span></p>
<p dir="ltr"><span style="font-size:small"><strong>Step 3</strong><br class="kix-line-break">
Select your bot that you want to generate code</span></p>
<p dir="ltr"><strong><span style="font-size:small">Step 4:</span></strong></p>
<p dir="ltr"><span style="font-size:small">Click on Get bot embed Codes &gt; Click on Web Chat icon &gt; Click on (Click here to open Web Chat configuration page)</span></p>
<p dir="ltr"><span><img src="https://lh4.googleusercontent.com/Q5IA-2gTPHhQNTqGuHFQV8wUQ5jkmM3KRLv__ETBr2KlUyCqnl5-34jNWC8R9I_ytr8cnirg_PB99mfUCzIVG4z09Qv_ENAUURPOeaLqJI-d-FyAY7OvtHdKcxuh2KgzPOt1_tdR7FFyO3vdEg" alt="" width="623" height="147"></span></p>
<p dir="ltr"><strong><span style="font-size:small">Step 5:</span></strong></p>
<p dir="ltr"><span style="font-size:small">It will navigate to new web page for configuration and click on &#43; Add New Site &gt; Provide site or application name &gt; Click on Done</span></p>
<p dir="ltr"><span><img src="https://lh3.googleusercontent.com/LEm8-IQuPI_jUT9uVOIg976kWE-_4-5GbYdByHaQFSSrb-nv54VKFKXjKhacjNNrC8Z4VuDP1AQaMvGDpx4shCpcXRCY16PMZIdTO5Bed_x67C6GuNoeAdpwa7w3b_H4XOxdwxQYYDmL8zllNg" alt="" width="624" height="378"></span></p>
<p dir="ltr"><strong><span style="font-size:small">Step 6:</span></strong></p>
<p dir="ltr"><span style="font-size:small">You can copy your secret keys and embed code for integrate to xamarin forms application
</span></p>
<p dir="ltr"><span><img src="https://lh6.googleusercontent.com/eN6kNv0MvB34TYPz1gAqtT6fOmUlbtx2NNYhtCmtgXskiU3kV9n5MIYKYTgoe1QbK_t7PBmRdsLFzhEm-P1q6CsEHMyMGUTC1aSDiyymiZxBm87fC6XbcG93SvcXzr5TGuDSx78AeG8SAymwVw" alt="" width="624" height="395"></span></p>
<h1 dir="ltr"><strong>Create new Xamarin .Forms Application :</strong></h1>
<p dir="ltr"><span style="font-size:small">Go to Run (Windows key &#43;R) &gt; type Devenv.exe or select from Windows Application list and select New project from File menu &gt; New Project (ctrl &#43;Shift&#43;N) or click More project template from VS Start screen.</span></p>
<p dir="ltr"><span><img src="https://lh6.googleusercontent.com/vtWVGrpd0Ln4VWxByKmLYtCbC9XbWY5KbbcuXnAenXlIyRf1ipzVlOAE_wqa89A3AToM5dLTyXWtnD6UpIDt0TytyPice7We4Q1pJnGw4P5dUBdKIsHyx6WNsora6bWJ4B9Oi8sfKqfHsZV2rQ" alt="" width="409" height="285"></span></p>
<p dir="ltr"><span style="font-size:small">New Project &gt;select Cross -Platform from Template &gt; Cross platform App(Xamarin.Forms or native). It will show the screen, as shown below.</span></p>
<p dir="ltr"><span><img src="https://lh6.googleusercontent.com/D6w8BXIn3UHbYab58QZfC0Mnbq1iKpN4DB_Ff5T9tEwzt_prhosiMpyYDeLEM3mNV_PTYInCN_kxyrSYxu_Gx1fh2GtLHBHVzoAkdpDTuAMj5KIr7q5LvANb7XZNLbzpNHU-K-vtY7pCbyGnEg" alt="" width="596" height="326"></span></p>
<p dir="ltr"><span style="font-size:small">You can find above screen only on VS 2017. Select Blank apps &gt; select Xamarin.Forms &nbsp;&gt; Select PCL and click on Ok .it will generate all the mobile platform project with PC</span></p>
<p dir="ltr"><span><img src="https://lh3.googleusercontent.com/XbTPLygITopjvBwppA7YQakRbDCX2HIY0jfgxlOStrMzcVfOUzkjj7Xm1cSPo9783ebZ0-61PZGqO26DvFtLyK0uBojGdbWQgwqSNjFi9Lq8t4C33CtEtnw0VVzTWrSxnobBiywpU5wpqh3aXQ" alt="" width="356" height="286"></span></p>
<p dir="ltr"><span style="font-size:small">Open your MainPage.xaml file add webview control with following code for web chat enable</span></p>
<p dir="ltr"><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml">&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackLayout</span>&nbsp;<span class="xaml__attr_name">WidthRequest</span>=<span class="xaml__attr_value">&quot;300&quot;</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;500&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;profile.png&quot;</span>&nbsp;<span class="xaml__attr_name">WidthRequest</span>=<span class="xaml__attr_value">&quot;200&quot;</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;200&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/Image&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Live&nbsp;Chat&nbsp;with&nbsp;Suthahar&nbsp;via&nbsp;C&nbsp;Sharp&nbsp;corner&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;20&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/Label&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;WebView</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;webview&quot;</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;https://webchat.botframework.com/embed/DevEnvExeBot?s=8XGcUROXkAA.cwA.pZo.8pJ-6oQ3sJRpxq0tqIo9uLPji4oxBQuz2pW5qWobw2c&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">WidthRequest</span>=<span class="xaml__attr_value">&quot;300&quot;</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;&nbsp;300&quot;</span><span class="xaml__tag_start">&gt;</span><span class="xaml__tag_end">&lt;/WebView&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackLayout&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p dir="ltr"><span style="font-size:small">Now you can run the application in windows ,Android and iOS</span></p>
<p dir="ltr"><span><img src="https://lh4.googleusercontent.com/9ZpxC9EyECja6fp8fRv7iv-ScfyeOeNDaDeG7nFAoY4LzDe5Dc5iKzZjOAnwPODv83G7qH4LbnTL6anU9dd2bKP4C8IRDeudups2JBw4OFJGc_-hxTvtPMaCL2aKwFlX9gb2uiZLFM_JC5OZRw" alt="" width="198" height="404"></span><span><img src="https://lh4.googleusercontent.com/dkG8sTaXUiPPPLaE5EXjRPnsIn6rUQpPl_qCXk-ZP5kTk_SSFGTpavNPGhVHbI7jIVzhJspFh7pHQCiuL_rc5TikuRT6VRbYEMyI2mm67Noot0mbXP98iygQ4K8uslwO-cpYAiwp8j11ZPLdgw" alt="" width="212" height="396"></span><span><img src="https://lh4.googleusercontent.com/doGiNM_E54M8zKCBNFIxGvqZ1rIZ7g0dExCkZPu_yjbwbQUFbJSL4ElqmHOvNxXT9Ph5ENype-96T6itam0X5SfP7dBr0YOJz01u2v2TTX2CgdIVjQCfersDFtsAgmnShRgJpM_PCTML3STipg" alt="" width="195" height="398"></span></p>
<p dir="ltr">&nbsp;</p>
<h1 dir="ltr"><span>Summary</span></h1>
<p dir="ltr"><span style="font-size:small">In this article, your learned how to create a Bot application, publish Bot to Azure and bot implementation to Xamarin Forms using Visual Studio 2017. If you have any questions/ feedback/ issues, please write in the
 comment box.</span></p>
<p dir="ltr">&nbsp;</p>
<p dir="ltr">&nbsp;</p>
<p dir="ltr">&nbsp;</p>
<div></div>
