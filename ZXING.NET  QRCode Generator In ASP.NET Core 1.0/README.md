# ZXING.NET : QRCode Generator In ASP.NET Core 1.0
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- JSON
- Visual Studio 2015
- ASP.NET Core 1.0
- ASP.NET Core
- ASP.NET Core 1.0.1
- ASP.NET Core MVC
- Zxing.NET
## Topics
- QR codes
- QR Code Generator using Zxing.Net
## Updated
- 05/15/2017
## Description

<p>&nbsp;</p>
<h1>Introduction</h1>
<p><br>
In this article, we will explain how to create a QR Code Generator in ASP.NET Core 1.0, using Zxing.Net.<br>
<br>
</p>
<h1>Background</h1>
<p><br>
I tried to create a QR Code Generator in ASP.NET Core, using third party libraries but in most of the cases codes are not fully supported in ASP.NET Core because of some version issues etc. I searched a lot in Google but finally I found
<strong>&quot;Zxing.Net&quot;</strong> and it is a library, which supports decoding and generating of the barcodes. I had a discussion with
<em>&quot;MicJahn&quot;</em> and came up &nbsp;with a great solution.<br>
<br>
<span style="font-size:12.1px; background-color:#ffffff; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; color:#2a2a2a">Before reading this article, you must read the articles given below for ASP.NET Core knowledge.</span></p>
<ul style="font-size:12.1px">
<li><a title="ASP.NET CORE 1.0: Getting Started" href="https://social.technet.microsoft.com/wiki/contents/articles/36451.asp-net-core-1-0-getting-started.aspx" target="_blank">ASP.NET CORE 1.0: Getting Started</a>
</li><li><a title="ASP.NET Core 1.0: Project Layout" href="https://social.technet.microsoft.com/wiki/contents/articles/36490.asp-net-core-1-0-project-layout.aspx" target="_blank">ASP.NET Core 1.0: Project Layout</a>
</li><li><a title="ASP.NET Core 1.0: Middleware And Static files (Part 1)" href="https://social.technet.microsoft.com/wiki/contents/articles/36629.asp-net-core-1-0-middleware-and-static-files-part-1.aspx" target="_blank">ASP.NET Core 1.0: Middleware And Static files
 (Part 1)</a> </li><li><a title="Middleware And Staticfiles In ASP.NET Core 1.0 - Part Two" href="https://social.technet.microsoft.com/wiki/contents/articles/36727.middleware-and-staticfiles-in-asp-net-core-1-0-part-two.aspx" target="_blank">Middleware And Staticfiles In ASP.NET
 Core 1.0 - Part Two</a> </li></ul>
<h1>Zxing.Net</h1>
<p><br>
A library, which supports decoding and generating of the barcodes (Example: QR Code, PDF 417, EAN, UPC, Aztec, Data Matrix, Codabar) within the images.
<br>
<br>
</p>
<h1>Assemblies required</h1>
<p><br>
The assemblies given below are required for QR Code Generator.<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">Microsoft.AspNetCore.Razor.TagHelpers;&nbsp; </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">System;&nbsp; </code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp; </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">using</code>
<code style="color:#000000">ZXing.QrCode;</code></span></div>
</div>
<p>&nbsp;</p>
<h1>Packages required</h1>
<p><br>
We need the packages given below for drawing and creating QR Code Generator.<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:blue">&quot;CoreCompat.System.Drawing&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0-beta006&quot;</code><code style="color:#000000">,&nbsp;&nbsp;&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:blue">&quot;ZXing.Net&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;0.15.0&quot;</code></span></div>
</div>
<p>&nbsp;</p>
<h1>C#</h1>
<p><br>
QRCodeTagHelper class given below contains QR Code Generator methods etc.<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">namespace</code>
<code style="color:#000000">QRCodeApp {&nbsp; </code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">[HtmlTargetElement(</code><code style="color:blue">&quot;qrcode&quot;</code><code style="color:#000000">)]&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
QRCodeTagHelper: TagHelper {&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">override</code> <code style="color:#006699; font-weight:bold">
void</code> <code style="color:#000000">Process(TagHelperContext context, TagHelperOutput output) {&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">var QrcodeContent = context.AllAttributes[</code><code style="color:blue">&quot;content&quot;</code><code style="color:#000000">].Value.ToString();&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">var alt = context.AllAttributes[</code><code style="color:blue">&quot;alt&quot;</code><code style="color:#000000">].Value.ToString();&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">var width = 250;
</code><code style="color:#008200">// width of the Qr Code&nbsp;&nbsp;&nbsp; </code>
</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">var height = 250;
</code><code style="color:#008200">// height of the Qr Code&nbsp;&nbsp;&nbsp; </code>
</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">var margin = 0;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">var qrCodeWriter =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
ZXing.BarcodeWriterPixelData {&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">Format = ZXing.BarcodeFormat.QR_CODE,&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:60px!important"><code style="color:#000000">Options =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
QrCodeEncodingOptions {&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:72px!important"><code style="color:#000000">Height
 = height, Width = width, Margin = margin&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:60px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">};&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">var pixelData = qrCodeWriter.Write(QrcodeContent);&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#008200">// creating a bitmap from the raw pixel data; if only black
 and white colors are used it makes no difference&nbsp;&nbsp;&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#008200">// that the pixel data ist BGRA oriented and the bitmap is
 initialized with RGB&nbsp;&nbsp;&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">using</code><code style="color:#000000">(var
 bitmap = </code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.Bitmap.aspx" target="_blank" title="Auto generated link to System.Drawing.Bitmap">System.Drawing.Bitmap</a>(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#006699; font-weight:bold">using</code><code style="color:#000000">(var
 ms = </code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
MemoryStream()) {&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">var bitmapData = bitmap.LockBits(</code><code style="color:#006699; font-weight:bold">new</code>
<code style="color:#000000"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.Rectangle.aspx" target="_blank" title="Auto generated link to System.Drawing.Rectangle">System.Drawing.Rectangle</a>(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#006699; font-weight:bold">try</code>
<code style="color:#000000">{&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:60px!important"><code style="color:#008200">// we assume
 that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:60px!important"><code style="color:#000000"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Runtime.InteropServices.Marshal.Copy.aspx" target="_blank" title="Auto generated link to System.Runtime.InteropServices.Marshal.Copy">System.Runtime.InteropServices.Marshal.Copy</a>(pixelData.Pixels,
 0, bitmapData.Scan0, pixelData.Pixels.Length);&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">}
</code><code style="color:#006699; font-weight:bold">finally</code> <code style="color:#000000">
{&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:60px!important"><code style="color:#000000">bitmap.UnlockBits(bitmapData);&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#008200">// save to stream as PNG&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">bitmap.Save(ms, <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.Imaging.ImageFormat.Png.aspx" target="_blank" title="Auto generated link to System.Drawing.Imaging.ImageFormat.Png">System.Drawing.Imaging.ImageFormat.Png</a>);&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">output.TagName =
</code><code style="color:blue">&quot;img&quot;</code><code style="color:#000000">;&nbsp; </code>
</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">output.Attributes.Clear();&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">output.Attributes.Add(</code><code style="color:blue">&quot;width&quot;</code><code style="color:#000000">,
 width);&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">output.Attributes.Add(</code><code style="color:blue">&quot;height&quot;</code><code style="color:#000000">,
 height);&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">output.Attributes.Add(</code><code style="color:blue">&quot;alt&quot;</code><code style="color:#000000">,
 alt);&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">output.Attributes.Add(</code><code style="color:blue">&quot;src&quot;</code><code style="color:#000000">,
 String.Format(</code><code style="color:blue">&quot;data:image/png;base64,{0}&quot;</code><code style="color:#000000">, Convert.ToBase64String(ms.ToArray())));&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:36px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
<h1>Index.chtml</h1>
<p><br>
The code given below will display QR Code Generator.<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">@{&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">ViewData[&quot;Title&quot;] = &quot;Home&quot;;&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">h2</code><code style="color:#000000">&gt;@ViewData[&quot;Title&quot;].&lt;/</code><code style="color:#006699; font-weight:bold">h2</code><code style="color:#000000">&gt;&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">h3</code><code style="color:#000000">&gt;@ViewData[&quot;Message&quot;]&lt;/</code><code style="color:#006699; font-weight:bold">h3</code><code style="color:#000000">&gt;&nbsp;
</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">A library which supports decoding and generating of barcodes (like QR Code, PDF 417, EAN, UPC, Aztec, Data Matrix, Codabar) within images.&nbsp;
</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">qrcode</code>
<code style="color:#808080">alt</code><code style="color:#000000">=</code><code style="color:blue">&quot;QR Code&quot;</code>
<code style="color:#808080">content</code><code style="color:#000000">=</code><code style="color:blue">&quot;<a href="https://rajeeshmenoth.wordpress.com/">https://rajeeshmenoth.wordpress.com/</a>&quot;</code>
<code style="color:#000000">/&gt;&nbsp; </code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;</code><span style="margin-left:3px!important"><code style="color:#000000"><a href="https://rajeeshmenoth.wordpress.com/">https://rajeeshmenoth.wordpress.com/</a></code></span></span></div>
</div>
<p>&nbsp;</p>
<h1>_ViewImports.cshtml</h1>
<p><br>
The code Injecting TagHelper given below is in the entire Application.<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">@addTagHelper &quot;*, QRCodeApp&quot;</code></span></div>
</div>
<p>&nbsp;</p>
<h1>project.json</h1>
<p><br>
The dependencies given below are required to create QR Code Application.<br>
<br>
</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">{&nbsp;
</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;dependencies&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Diagnostics&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Mvc&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.1.2&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Mvc.Core&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.1.2&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Server.IISIntegration&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Server.Kestrel&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.1&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.StaticFiles&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.1.1&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.Extensions.Logging.Console&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;CoreCompat.System.Drawing&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0-beta006&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;ZXing.Net&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;0.15.0&quot;</code>&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;tools&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;Microsoft.AspNetCore.Server.IISIntegration.Tools&quot;</code><code style="color:#000000">:
</code><code style="color:blue">&quot;1.0.0-preview2-final&quot;</code>&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;frameworks&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;net452&quot;</code><code style="color:#000000">: { }&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;buildOptions&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;emitEntryPoint&quot;</code><code style="color:#000000">:
</code><code style="color:#006699; font-weight:bold">true</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;preserveCompilationContext&quot;</code><code style="color:#000000">:
</code><code style="color:#006699; font-weight:bold">true</code>&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;publishOptions&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;include&quot;</code><code style="color:#000000">: [&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;wwwroot&quot;</code><code style="color:#000000">,&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:18px!important"><code style="color:blue">&quot;web.config&quot;</code>&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#000000">]&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">},&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:9px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:blue">&quot;scripts&quot;</code><code style="color:#000000">: {&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:blue">&quot;postpublish&quot;</code><code style="color:#000000">: [
</code><code style="color:blue">&quot;dotnet publish-iis --publish-folder %publish:OutputPath% --framework %publish:FullTargetFramework%&quot;</code>
<code style="color:#000000">]&nbsp; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:6px!important"><code style="color:#000000">}&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
<h1>Output<br>
<br>
</h1>
<p><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/2117.QRCode-Generator.JPG"><img src=":-2117.qrcode-generator.jpg" alt="" style="border-width:0px; border-style:solid"></a></p>
<h1>Reference</h1>
<ul>
<li><a title="Micjahn/Zxing.Net" href="https://github.com/micjahn/ZXing.Net" target="_blank">Micjahn/Zxing.Net</a>
</li><li><a title="Discussion" href="https://forums.asp.net/p/2118971/6136214.aspx?Re&#43;How&#43;to&#43;create&#43;a&#43;Q&#43;R&#43;Code&#43;Generator&#43;in&#43;Asp&#43;Net&#43;Core" target="_blank">Discussion</a>
</li><li><a title="TechBlog Content" href="https://rajeeshmenoth.wordpress.com/2017/05/11/qr-code-generator-in-asp-net-core-using-zxing-net/" target="_blank">TechBlog Content</a>
</li></ul>
<h1>Downloads</h1>
<p><br>
You can download ASP.NET Core 1.0 source code from the MSDN Code, using the links, mentioned below.</p>
<ul>
<li><a title="Middleware And Staticfiles In ASP.NET Core 1.0 - Part One" href="https://code.msdn.microsoft.com/Middleware-And-Staticfiles-36a78e4a" target="_blank">Middleware And Staticfiles In ASP.NET Core 1.0 - Part One
<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" alt="Jump" style="border-width:0px; border-style:solid">
</a></li><li><a title="Middleware And Staticfiles In ASP.NET Core 1.0 - Part Two" href="https://code.msdn.microsoft.com/Middleware-And-Staticfiles-4be1c8d0" target="_blank">Middleware And Staticfiles In ASP.NET Core 1.0 - Part Two
<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" alt="Jump" style="border-width:0px; border-style:solid">
</a></li><li><a title="Create An Aurelia Single Page Application In ASP.NET Core 1.0" href="https://code.msdn.microsoft.com/Create-An-Aurelia-Single-dbffe00f" target="_blank">Create An Aurelia Single Page Application In ASP.NET Core 1.0
<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" alt="Jump" style="border-width:0px; border-style:solid">
</a></li><li><a title="Create Rest API Or Web API With ASP.NET Core 1.0" href="https://code.msdn.microsoft.com/Create-Rest-API-Or-Web-API-16cc5392" target="_blank">Create Rest API Or Web API With ASP.NET Core 1.0
<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" alt="Jump" style="border-width:0px; border-style:solid">
</a></li><li><a title="Adding A Configuration Source File In ASP.NET Core 1.0" href="https://code.msdn.microsoft.com/Adding-A-Configuration-efea86aa" target="_blank">Adding A Configuration Source File In ASP.NET Core 1.0
<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" alt="Jump" style="border-width:0px; border-style:solid">
</a></li><li><a title="Code First Migration - ASP.NET Core MVC With EntityFrameWork Core" href="https://gallery.technet.microsoft.com/Code-First-Migration-bfcbc518" target="_blank">Code First Migration - ASP.NET Core MVC With EntityFrameWork Core
<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" alt="Jump" style="border-width:0px; border-style:solid">
</a></li><li><a title="Building ASP.NET Core MVC Application Using EF Core and ASP.NET Core 1.0" href="https://gallery.technet.microsoft.com/Building-ASPNET-Core-MVC-ff103064" target="_blank">Building ASP.NET Core MVC Application Using EF Core and ASP.NET Core 1.0
<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" alt="Jump" style="border-width:0px; border-style:solid">
</a></li><li><a title="Send Email Using ASP.NET CORE 1.1 With MailKit In VisualStudio 2017" href="https://code.msdn.microsoft.com/Send-Email-Using-ASPNET-1c62bdfd" target="_blank">Send Email Using ASP.NET CORE 1.1 With MailKit In VisualStudio 2017</a>
</li></ul>
<h1>See Also</h1>
<p><br>
It's recommended to read more articles related to ASP.NET Core.</p>
<ul>
<li><a title="ASP.NET CORE 1.0: Getting Started" href="https://social.technet.microsoft.com/wiki/contents/articles/36451.asp-net-core-1-0-getting-started.aspx" target="_blank">ASP.NET CORE 1.0: Getting Started</a>
</li><li><a title="ASP.NET Core 1.0: Project Layout" href="https://social.technet.microsoft.com/wiki/contents/articles/36490.asp-net-core-1-0-project-layout.aspx" target="_blank">ASP.NET Core 1.0: Project Layout</a>
</li><li><a title="ASP.NET Core 1.0: Middleware And Static files (Part 1)" href="https://social.technet.microsoft.com/wiki/contents/articles/36629.asp-net-core-1-0-middleware-and-static-files-part-1.aspx" target="_blank">ASP.NET Core 1.0: Middleware And Static files
 (Part 1)</a> </li><li><a title="Middleware And Staticfiles In ASP.NET Core 1.0 - Part Two" href="https://social.technet.microsoft.com/wiki/contents/articles/36727.middleware-and-staticfiles-in-asp-net-core-1-0-part-two.aspx" target="_blank">Middleware And Staticfiles In ASP.NET
 Core 1.0 - Part Two</a> </li><li><a title="ASP.NET Core 1.0 Configuration: Aurelia Single Page Applications" href="https://social.technet.microsoft.com/wiki/contents/articles/36792.asp-net-core-1-0-configuration-aurelia-single-page-applications.aspx" target="_blank">ASP.NET Core 1.0 Configuration:
 Aurelia Single Page Applications</a> </li><li><a title="ASP.NET Core 1.0: Create An Aurelia Single Page Application" href="https://social.technet.microsoft.com/wiki/contents/articles/36799.asp-net-core-1-0-create-an-aurelia-single-page-application.aspx" target="_blank">ASP.NET Core 1.0: Create An Aurelia
 Single Page Application</a> </li><li><a title="Create Rest API Or Web API With ASP.NET Core 1.0" href="https://social.technet.microsoft.com/wiki/contents/articles/36887.create-rest-api-or-web-api-with-asp-net-core-1-0.aspx" target="_blank">Create Rest API Or Web API With ASP.NET Core 1.0</a>
</li><li><a title="ASP.NET Core 1.0: Adding A Configuration Source File" href="https://social.technet.microsoft.com/wiki/contents/articles/37101.asp-net-core-1-0-adding-a-configuration-source-file.aspx" target="_blank">ASP.NET Core 1.0: Adding A Configuration Source
 File</a> </li><li><a title="Code First Migration - ASP.NET Core MVC With EntityFrameWork Core" href="https://social.technet.microsoft.com/wiki/contents/articles/37272.code-first-migration-asp-net-core-mvc-with-entityframework-core.aspx" target="_blank">Code First Migration
 - ASP.NET Core MVC With EntityFrameWork Core</a> </li><li><a title="Building ASP.NET Core MVC Application Using EF Core and ASP.NET Core 1.0" href="https://social.technet.microsoft.com/wiki/contents/articles/37404.building-asp-net-core-mvc-application-using-ef-core-and-asp-net-core-1-0.aspx" target="_blank">Building
 ASP.NET Core MVC Application Using EF Core and ASP.NET Core 1.0</a> </li><li><a title="Send Email Using ASP.NET CORE 1.1 With MailKit In Visual Studio 2017" href="https://social.technet.microsoft.com/wiki/contents/articles/37534.send-email-using-asp-net-core-1-1-with-mailkit-in-visual-studio-2017.aspx" target="_blank">Send Email
 Using ASP.NET CORE 1.1 With MailKit In Visual Studio 2017</a> </li></ul>
