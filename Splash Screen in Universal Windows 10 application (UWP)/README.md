# Splash Screen in Universal Windows 10 application (UWP)
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- XAML
- universal windows app
- Windows 10
- UWP
- windows phone 10
## Topics
- C#
- XAML
- Windows Phone
- universal app
- Windows 10
- UWP
## Updated
- 01/05/2016
## Description

<h1>Introduction</h1>
<p class="projectSummary" style="text-align:justify">This sample includes the app code example developed using one of the universal app templates available in Visual Studio. The solution of the universal app code example showing the splashscreen is structured
 so the code example can run on both Windows 10 and Windows Phone 10.</p>
<h1><span>Building the Sample</span></h1>
<p><em>Are there special requirements or instructions for building the sample?</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p style="text-align:justify">Display a <span style="background-color:#ffff00">splash screen</span> for more time by creating an extended splash screen for your app. This extended screen is the same splash screen shown when your app is launched, but can be
 customized. When you want to show real-time loading information or give your app more time to prepare its initial UI, an extended splash screen lets you define the launch experience.</p>
<p style="text-align:justify">Make sure your extended splash screen accurately imitates the default splash screen by following these recommendations:</p>
<ul>
<li style="text-align:justify">Your extended splash screen page should use a 620 x 300 pixel image that is consistent with the image specified for your splash screen in your app manifest. In Microsoft Visual Studio&nbsp;2015, splash screen settings are stored
 in the&nbsp;<strong>Splash Screen</strong>&nbsp;section of the&nbsp;<strong>Visual Assets</strong>&nbsp;tab in your app manifest (Package.appxmanifest file).
</li></ul>
<p><img id="146753" src="146753-20.png" alt="" width="922" height="422"></p>
<ul>
<li style="text-align:justify">The background color used by y<span>our extended splash screen should</span>&nbsp;consistent with the background color specified for your splash screen in your app manifest (your app's splash screen background).
</li></ul>
<p><em>This sample covers the basics of implementing a splashscreen for your application .</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Grid</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Canvas</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;extendedSplashImage&quot;</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;Assets/SplashScreen.png&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ProgressRing</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;splashProgressRing&quot;</span>&nbsp;<span class="xaml__attr_name">IsActive</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;40&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Center&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Canvas&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Center&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Bottom&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;DismissSplash&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Dismiss&nbsp;extended&nbsp;splash&nbsp;screen&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Center&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;DismissSplashButton_Click&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span></pre>
</div>
</div>
</div>
<h1><img id="146754" src="146754-splashscreen.png" alt=""></h1>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>ExtendedSplash.xaml&nbsp;</em> </li></ul>
<h1>More Information</h1>
<p>UWP apps take advantage of Azure services. You can also use many UWP concepts such as live tiles, that makes&nbsp;an amazing&nbsp;apps. You can take a look on y other
<a href="https://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&f%5B0%5D.Value=Chourouk%20Hjaiej">
samples</a>, they can help you and don`t forget to rate them ;)&nbsp;</p>
<p><em><em>Feel free to contact me on Twitter @CHJ_GeekGirl&nbsp;for any question about this and visit my blog for more code sample :&nbsp;http://hjaiejchourouk.com/</em></em></p>
