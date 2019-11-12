# Webcam Capture
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- Windows Forms
- .NET Framework 4
- .NET Framework
## Topics
- using webcam
## Updated
- 04/04/2013
## Description

<h2>Introduction</h2>
<p>For a long time, I have been looking for a good way to capture images without too much trouble. All you need to do is call one method to get the image.</p>
<p>I have used Windows Image Acquisition (WIA) to capture images. WIA provides a great deal of compatibility with webcams already running on Microsoft Windows XP.</p>
<p>This is my first posting on The Code Project, please do not hesitate to comment or give any suggestions. I would be very thankful if you provide any feedback.</p>
<h2>Improved Image Capture Technologies: WIA</h2>
<p>Windows XP supports still-image devices through Windows Image Acquisition (WIA), which uses the Windows Driver Model (WDM) architecture. WIA provides robust communication between applications and image-capture devices, allowing you to capture images efficiently
 and transfer them to your computer for editing and use.</p>
<p>WIA supports small computer system interface (SCSI), IEEE 1394, USB, and serial digital still image devices. Support for infrared, parallel, and serial still-image devices&mdash;which are connected to standard COM ports&mdash;comes from the existing infrared,
 parallel, and serial interfaces. Image scanners and digital cameras are examples of still image devices. WIA also supports Microsoft DirectShow&reg;-based webcams and digital video (DV) camcorders to capture frames from video.</p>
<h3>Windows Image Acquisition Architecture</h3>
<p>WIA architecture is both an Application Programming Interface (API) and a Device Driver Interface (DDI). The WIA architecture includes components provided by the software and hardware vendor, as well as by Microsoft. Figure 1 below illustrates the WIA architecture.</p>
<p>&nbsp;</p>
<p><img src="-hwspxp01.gif" border="0" alt="Figure 1: The components of WIA architecture." width="335" height="418"></p>
<h2>The DLL Fix</h2>
<p>I have included all the required references in the source code. You don't need to do this, but if you wish to know how you may read this section.</p>
<p><img src="-reference.jpg" border="0" alt="Reference" hspace="0" width="640" height="346"></p>
<p>You want to add a reference to Microsoft Windows Image Acquisition type library.</p>
<p><img src="-reference2.jpg" border="0" alt="Reference2" hspace="0" width="640" height="342"></p>
<p>You also want to add a reference to WiaVideo Type Library. However, after some trouble I read about a bug and its fix that occurs while importing the type library.</p>
<p>Use ILDASM to dump the type library&nbsp;<em>Interop.WIAVIDEOLib.dll</em>, then use Notepad to replace occurrences of<code>valuetype _RemotableHandle&amp;</code>&nbsp;to&nbsp;<code>native int</code>. Then compile the iL dump file you fixed using&nbsp;<code>ILASM&nbsp;</code>in
 the CMD&nbsp;<code>ilasm /DLL WIAVIDEOLib.il</code>. Add a reference to the new DLL and you are set to go.</p>
<p>&nbsp;</p>
<p><a href="http://www.codeproject.com/Articles/15219/WebCam-Fast-Image-Capture-Service-using-WIA">http://www.codeproject.com/Articles/15219/WebCam-Fast-Image-Capture-Service-using-WIA</a></p>
<p><a href="http://blog.marcio-pulcinelli.com/2011/06/05/acessando-webcam-com-c/">http://blog.marcio-pulcinelli.com/2011/06/05/acessando-webcam-com-c/</a></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__preproc">#region&nbsp;API&nbsp;Declarations</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Abaixo&nbsp;tremos&nbsp;todas&nbsp;as&nbsp;chamadas&nbsp;das&nbsp;APIs&nbsp;do&nbsp;Sistema&nbsp;Operacional&nbsp;Windows.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Essas&nbsp;chamadas&nbsp;fazem&nbsp;a&nbsp;interface&nbsp;do&nbsp;nosso&nbsp;controle&nbsp;com&nbsp;a&nbsp;WebCam&nbsp;e&nbsp;com&nbsp;o&nbsp;SO.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Esta&nbsp;chamada&nbsp;&eacute;&nbsp;uma&nbsp;das&nbsp;mais&nbsp;importantes&nbsp;e&nbsp;&eacute;&nbsp;vital&nbsp;para&nbsp;o&nbsp;funcionamento&nbsp;do&nbsp;SO.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32&quot;</span>,&nbsp;EntryPoint&nbsp;=&nbsp;<span class="cs__string">&quot;SendMessage&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;SendMessage(<span class="cs__keyword">int</span>&nbsp;hWnd,&nbsp;<span class="cs__keyword">uint</span>&nbsp;Msg,&nbsp;<span class="cs__keyword">int</span>&nbsp;wParam,&nbsp;<span class="cs__keyword">int</span>&nbsp;lParam);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Esta&nbsp;API&nbsp;cria&nbsp;a&nbsp;inst&acirc;ncia&nbsp;da&nbsp;webcam&nbsp;para&nbsp;que&nbsp;possamos&nbsp;acessa-la.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;avicap32.dll&quot;</span>,&nbsp;EntryPoint&nbsp;=&nbsp;<span class="cs__string">&quot;capCreateCaptureWindowA&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;capCreateCaptureWindowA(<span class="cs__keyword">string</span>&nbsp;lpszWindowName,&nbsp;<span class="cs__keyword">int</span>&nbsp;dwStyle,&nbsp;<span class="cs__keyword">int</span>&nbsp;x,&nbsp;<span class="cs__keyword">int</span>&nbsp;y,&nbsp;<span class="cs__keyword">int</span>&nbsp;nWidth,&nbsp;<span class="cs__keyword">int</span>&nbsp;nHeight,&nbsp;<span class="cs__keyword">int</span>&nbsp;hwndParent,&nbsp;<span class="cs__keyword">int</span>&nbsp;nID);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Esta&nbsp;API&nbsp;abre&nbsp;a&nbsp;&aacute;rea&nbsp;de&nbsp;tranfer&ecirc;ncia&nbsp;para&nbsp;que&nbsp;possamos&nbsp;buscar&nbsp;os&nbsp;dados&nbsp;da&nbsp;webcam.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32&quot;</span>,&nbsp;EntryPoint&nbsp;=&nbsp;<span class="cs__string">&quot;OpenClipboard&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;OpenClipboard(<span class="cs__keyword">int</span>&nbsp;hWnd);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Esta&nbsp;API&nbsp;limpa&nbsp;a&nbsp;&aacute;rea&nbsp;de&nbsp;transfer&ecirc;ncia.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32&quot;</span>,&nbsp;EntryPoint&nbsp;=&nbsp;<span class="cs__string">&quot;EmptyClipboard&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;EmptyClipboard();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Esta&nbsp;API&nbsp;fecha&nbsp;a&nbsp;&aacute;rea&nbsp;de&nbsp;tranfer&ecirc;ncia&nbsp;ap&oacute;s&nbsp;utiliza&ccedil;&atilde;o.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32&quot;</span>,&nbsp;EntryPoint&nbsp;=&nbsp;<span class="cs__string">&quot;CloseClipboard&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;CloseClipboard();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Esta&nbsp;API&nbsp;recupera&nbsp;os&nbsp;dados&nbsp;da&nbsp;&aacute;rea&nbsp;de&nbsp;tranfer&ecirc;ncia&nbsp;para&nbsp;a&nbsp;utiliza&ccedil;&atilde;o.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32.dll&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;IntPtr&nbsp;GetClipboardData(<span class="cs__keyword">uint</span>&nbsp;uFormat);<span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;
&nbsp;#region&nbsp;API&nbsp;Constants</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Esas&nbsp;constantes&nbsp;s&atilde;o&nbsp;predefinidas&nbsp;pelo&nbsp;SO</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;WM_USER&nbsp;=&nbsp;<span class="cs__number">1024</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;WM_CAP_CONNECT&nbsp;=&nbsp;<span class="cs__number">1034</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;WM_CAP_DISCONNECT&nbsp;=&nbsp;<span class="cs__number">1035</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;WM_CAP_GT_FRAME&nbsp;=&nbsp;<span class="cs__number">1084</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;WM_CAP_COPY&nbsp;=&nbsp;<span class="cs__number">1054</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;WM_CAP_START&nbsp;=&nbsp;WM_USER;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;WM_CAP_DLG_VIDEOFORMAT&nbsp;=&nbsp;WM_CAP_START&nbsp;&#43;&nbsp;<span class="cs__number">41</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;WM_CAP_DLG_VIDEOSOURCE&nbsp;=&nbsp;WM_CAP_START&nbsp;&#43;&nbsp;<span class="cs__number">42</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;WM_CAP_DLG_VIDEODISPLAY&nbsp;=&nbsp;WM_CAP_START&nbsp;&#43;&nbsp;<span class="cs__number">43</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;WM_CAP_GET_VIDEOFORMAT&nbsp;=&nbsp;WM_CAP_START&nbsp;&#43;&nbsp;<span class="cs__number">44</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;WM_CAP_SET_VIDEOFORMAT&nbsp;=&nbsp;WM_CAP_START&nbsp;&#43;&nbsp;<span class="cs__number">45</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;WM_CAP_DLG_VIDEOCOMPRESSION&nbsp;=&nbsp;WM_CAP_START&nbsp;&#43;&nbsp;<span class="cs__number">46</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;WM_CAP_SET_PREVIEW&nbsp;=&nbsp;WM_CAP_START&nbsp;&#43;&nbsp;<span class="cs__number">50</span>;<span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span></pre>
</div>
</div>
</div>
