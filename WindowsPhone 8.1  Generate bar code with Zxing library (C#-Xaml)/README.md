# WindowsPhone 8.1 : Generate bar code with Zxing library (C#-Xaml)
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- Windows Store app
- Windows Phone 8.1
## Topics
- Generating QR code with ZXing in WindowsPhone 8.1
- BarCodes in WP8.1 c#
## Updated
- 02/03/2015
## Description

<h2><span style="font-family:Verdana,sans-serif; font-size:small">Introduction:</span></h2>
<p><span style="font-family:Verdana,sans-serif; font-size:small">In WindowsPhone 8.1,The&nbsp;<a href="https://www.nuget.org/packages/ZXing.Net/" target="_blank">ZXing.Net</a>(0.14.0.1) Library provides the&nbsp;<strong>IBarcodeWriter</strong>&nbsp;interface
 defined in the ZXing namespace which lets you to generate the barcode. The developers can also define the format of the barcode via the&nbsp;<strong>'Format</strong>' property of the BarcodeWriter. The Write method of the BarcodeWriter is used to define the
 string to be encoded for the barcode.</span></p>
<p><span style="font-size:small"><span style="font-family:Verdana,sans-serif"><strong>Note:</strong></span><a href="https://zxingnet.codeplex.com/documentation" target="_blank">ZXing.Net</a><span style="font-family:Verdana,sans-serif">&nbsp;library is also&nbsp;available&nbsp;for&nbsp;previous
 windowsphone&nbsp;os versions(8.0/7.1/7.0)</span></span>&nbsp;</p>
<h2><span style="font-family:Verdana,sans-serif; font-size:small">Requirements:</span></h2>
<div>
<ul>
<li><span style="font-family:Verdana,sans-serif; font-size:small">This sample is targeted for windowsphone store 8.1 OS,So make sure you&rsquo;ve downloaded and installed the Windows Phone 8.1 SDK. For more information, see&nbsp;<a href="https://dev.windowsphone.com/en-us/downloadsdk">Get
 the SDK</a>.</span> </li><li><span style="font-family:Verdana,sans-serif; font-size:small">I assumes that you&rsquo;re going to test your app on the Windows Phone emulator. If you want to test your app on a phone, you have to take some additional steps. For more info, see&nbsp;<a href="http://msdn.microsoft.com/en-us/library/windowsphone/develop/dn614128.aspx">Register
 your Windows Phone device for development</a>.</span> </li><li><span style="font-family:Verdana,sans-serif; font-size:small">This post assumes&nbsp;you&rsquo;re using&nbsp;<strong>Microsoft Visual Studio Express&nbsp;2013 for Windows.</strong></span>
</li></ul>
</div>
<h2><span style="font-family:Verdana,sans-serif; font-size:small">Description:</span></h2>
<div><span style="font-family:Verdana,sans-serif; font-size:small">
<div>To generate the QR code in your Windows Phone store 8.1 App using ZXing.Net Library, follow the below steps.</div>
<div><strong>1)Installing Zxing library from Nuget:</strong></div>
<div>
<p class="separator"><span style="font-family:Verdana,sans-serif">Install the&nbsp;</span>&nbsp;<a href="https://www.nuget.org/packages/ZXing.Net/" target="_blank">ZXing.Net</a>&nbsp;<span style="font-family:Verdana,sans-serif">nuget package into the solution
 by starting the Package Manager&nbsp;PowerShell by following:</span></p>
<p><span style="font-family:Verdana,sans-serif">&nbsp;</span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif">Tools-&gt;Library Package Manager-&gt;Package Manager console</span></p>
<span style="font-family:Verdana,sans-serif">
<p class="separator"><a href="http://3.bp.blogspot.com/-JfXGl3hawUA/VKPGSsoJgCI/AAAAAAAABcI/O9QfvAG6okU/s1600/Nuget1.PNG"><img src=":-proxy?url=http%3a%2f%2f3.bp.blogspot.com%2f-jfxgl3hawua%2fvkpgssojgci%2faaaaaaaabci%2fo9qfvag6oku%2fs1600%2fnuget1.png&container=blogger&gadget=a&rewritemime=image%2f*" border="0" alt="" width="640" height="308"></a></p>
<p class="separator">Once the powershell command prompt is running, type the following command</p>
<p class="separator">&nbsp;</p>
<p class="separator">Install-Package ZXing.Net&nbsp;</p>
<p class="separator"><a href="http://1.bp.blogspot.com/-xGSsQu08hQM/VNCR8lddVTI/AAAAAAAABnc/rXuEGOR5JTU/s1600/Nuget.PNG"><img src=":-proxy?url=http%3a%2f%2f1.bp.blogspot.com%2f-xgssqu08hqm%2fvncr8lddvti%2faaaaaaaabnc%2frxuegor5jtu%2fs1600%2fnuget.png&container=blogger&gadget=a&rewritemime=image%2f*" border="0" alt="" width="640" height="123"></a></p>
<p>&nbsp;This will add ZXing library in the current project like below:</p>
</span></div>
<p class="separator"><a href="http://4.bp.blogspot.com/-F7vnZN0asb0/VNCSwi4ZOuI/AAAAAAAABnk/dm9sgOG3358/s1600/References.PNG"><img src=":-proxy?url=http%3a%2f%2f4.bp.blogspot.com%2f-f7vnzn0asb0%2fvncswi4zoui%2faaaaaaaabnk%2fdm9sgog3358%2fs1600%2freferences.png&container=blogger&gadget=a&rewritemime=image%2f*" border="0" alt="" width="320" height="291"></a></p>
<p class="separator"><strong>2)Generate QR code with ZXing:</strong></p>
<p class="separator">Lets add image control in MainPage.xaml,to display generated QR code image</p>
<p class="separator"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Page</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;QRCodeWP8._1.MainPage&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">local</span>=<span class="xaml__attr_value">&quot;using:QRCodeWP8._1&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">d</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/expression/blend/2008&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">mc</span>=<span class="xaml__attr_value">&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mc:<span class="xaml__attr_name">Ignorable</span>=<span class="xaml__attr_value">&quot;d&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;{ThemeResource&nbsp;ApplicationPageBackgroundThemeBrush}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;QrCodeImg&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_end">&lt;/Page&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;In '<strong>OnNavigatedTo</strong>' event add following code to generation of the QR code and showing it in the Image control (QrCodeImg).</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//Generating&nbsp;barcode&nbsp;with&nbsp;ZXing&nbsp;libary&nbsp;in&nbsp;WP8.1&nbsp;&nbsp;</span>&nbsp;
&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnNavigatedTo(NavigationEventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IBarcodeWriter&nbsp;writer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BarcodeWriter&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Format&nbsp;=&nbsp;BarcodeFormat.QR_CODE,<span class="cs__com">//Mentioning&nbsp;type&nbsp;of&nbsp;bar&nbsp;code&nbsp;generation&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Options&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ZXing.Common.EncodingOptions&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Height&nbsp;=&nbsp;<span class="cs__number">300</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Width&nbsp;=&nbsp;<span class="cs__number">300</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Renderer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ZXing.Rendering.PixelDataRenderer()&nbsp;{&nbsp;Foreground&nbsp;=&nbsp;Colors.Black}<span class="cs__com">//Adding&nbsp;color&nbsp;QR&nbsp;code&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;result&nbsp;=&nbsp;writer.Write(<span class="cs__string">&quot;http://www.bsubramanyamraju.blogspot.com&nbsp;&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;wb&nbsp;=&nbsp;result.ToBitmap()&nbsp;<span class="cs__keyword">as</span>&nbsp;WriteableBitmap;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Displaying&nbsp;QRCode&nbsp;Image&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QrCodeImg.Source&nbsp;=&nbsp;wb;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;In above code ,i am trying to generate QR code for my blog link '<a href="http://www.bsubramanyamraju.blogspot.com/">http://www.bsubramanyamraju.blogspot.com</a>'</div>
</div>
<p></p>
<div>We can also add color for QR code like this:</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">Renderer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ZXing.Rendering.PixelDataRenderer()&nbsp;{&nbsp;Foreground&nbsp;=&nbsp;Colors.RosyBrown&nbsp;}<span class="cs__com">//Adding&nbsp;color&nbsp;QR&nbsp;code&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<a href="http://3.bp.blogspot.com/-Min7OUeVHGA/VNCXeloUe-I/AAAAAAAABoE/_8hlnG99zgM/s1600/ColorChange.PNG"><img src=":-proxy?url=http%3a%2f%2f3.bp.blogspot.com%2f-min7ouevhga%2fvncxeloue-i%2faaaaaaaaboe%2f_8hlng99zgm%2fs1600%2fcolorchange.png&container=blogger&gadget=a&rewritemime=image%2f*" border="0" alt="" width="223" height="400"></a></div>
</div>
</span><span style="font-family:Verdana,sans-serif; font-size:small">
<div><strong>3)Output:</strong></div>
<div>Press 'F5' to launch the Application and you should see the QR code generated and displayed in the image control.
<p class="separator"><a href="http://3.bp.blogspot.com/-9Ml7z4TPTmI/VNCVDFaOjEI/AAAAAAAABnw/VLQ4OdYOz-s/s1600/Default.PNG"><img src=":-proxy?url=http%3a%2f%2f3.bp.blogspot.com%2f-9ml7z4tptmi%2fvncvdfaojei%2faaaaaaaabnw%2fvlq4odyoz-s%2fs1600%2fdefault.png&container=blogger&gadget=a&rewritemime=image%2f*" border="0" alt="" width="223" height="400"></a></p>
<p class="separator"><strong>4)Scanning generated QR code:</strong></p>
<p class="separator">In your Windows Phone 8/8.1 physical device, tap the search hardware button to open the Bing search and then tap the Vision Icon in the Application Bar and then bring the focus to the generated barcode which should identify the string
 within the barcode as shown below.</p>
<p class="separator"><a href="http://1.bp.blogspot.com/-I_L3l8otxRg/VNCVxPXcgbI/AAAAAAAABn4/MzGS7D51huU/s1600/wp_ss_20150203_0002.png"><img src=":-proxy?url=http%3a%2f%2f1.bp.blogspot.com%2f-i_l3l8otxrg%2fvncvxpxcgbi%2faaaaaaaabn4%2fmzgs7d51huu%2fs1600%2fwp_ss_20150203_0002.png&container=blogger&gadget=a&rewritemime=image%2f*" border="0" alt="" width="240" height="400"></a></p>
<p class="separator">If you tap on&nbsp;<a href="http://www.bsubramanyamraju.blogspot.com/" target="_blank">link</a>&nbsp;founded from the scanner,it will redirect to specified website.</p>
<p class="separator">This article is also available at my original <a title="MyBlogReference" href="http://bsubramanyamraju.blogspot.com/2015/02/windowsphone-81-generate-qr-code-with.html">
blog</a></p>
</div>
</span><span style="font-family:Verdana,sans-serif">
<div>
<pre class="csharp"><p><span style="font-size:small"><strong>Help me with feedback:</strong></span></p></pre>
</div>
</span><span style="font-family:Verdana,sans-serif">
<div>
<pre class="csharp"><span style="font-size:small">Thank you for reading my article. Drop all your questions/comments in QA tab give me your feedback with&nbsp;<img id="67168" src="67168-ratings.png" alt="" width="74" height="15">&nbsp;star rating (1 Star - Very Poor, 5&nbsp;Star -&nbsp;Very Nice). &nbsp;</span></pre>
</div>
</span><span style="font-family:Verdana,sans-serif; font-size:small">
<div>
<pre class="csharp"><div><span><br></span></div></pre>
<p class="separator">&nbsp;</p>
<p class="separator">&nbsp;</p>
<p class="separator">&nbsp;</p>
<p class="separator">&nbsp;</p>
</div>
</span></div>
