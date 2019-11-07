# Skype Integration in WPF Applications
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- COM
- C#
- WPF
- ViewModel pattern (MVVM)
- XAML
- MVVM
## Topics
- Interop
- COM Interop
- WPF Data Binding
## Updated
- 04/07/2014
## Description

<p><strong><span style="font-size:medium">Introduction:</span></strong></p>
<p><span style="font-size:small">Skype has become one of the prominent application for video calling, messaging etc. Intefacing skype with other application has become a necessary feature these days for application that involves the capability to chat, call
 etc. Skype has a good support to integrate it with web applications. But when it comes to windows application the support is very minimal. This sample is developed to integrate skype with WPF application using a COM interface.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><strong style="font-size:medium">How to Run the Application:</strong></p>
<p><span style="font-size:small">1.)&nbsp;&nbsp;&nbsp; Install Skype. You can Download Skype from the following url:</span></p>
<p><span style="font-size:small"><a href="http://www.skype.com/en/download-skype/skype-for-computer/">http://www.skype.com/en/download-skype/skype-for-computer/</a></span></p>
<p><span style="font-size:small">2.)&nbsp;&nbsp;&nbsp; After installing the Skype Application. Locate the COM Component
<strong>Skype4Com</strong> in your machine. If you have Skype installed in C drive. It will be located in
<em>&ldquo;<strong>C:\Program Files (x86)\Common Files\Skype&rdquo; </strong></em></span></p>
<p><span style="font-size:small">3.)&nbsp;&nbsp;&nbsp; After Register the Component to Windows Machine using the following steps<strong><em>&nbsp;</em></strong></span></p>
<p><span style="font-size:small">For 32-bits OS:</span></p>
<ol>
<li><span style="font-size:small">copy&nbsp;<strong>Skype4COM.dll to your&nbsp;c:\windows\system32&nbsp;folder</strong></span>
</li><li><span style="font-size:small">Open an Elevated CMD.exe (right click cmd.exe and choose 'Run as Administrator')</span>
</li><li><span style="font-size:small">Set current Path to&nbsp;<strong>C:\Windows\System32</strong></span>
</li><li><span style="font-size:small">execute&nbsp;<strong>regsvr32.exe Skype4COM.dll</strong></span>
</li></ol>
<p><span style="font-size:small">For 64-bits OS:</span></p>
<ol>
<li><span style="font-size:small">Copy<strong> &nbsp;Skype4COM.dll to your&nbsp;c:\windows\SysWOW64&nbsp;folder</strong></span>
</li><li><span style="font-size:small">Open an Elevated CMD.exe (right click cmd.exe and choose 'Run as Administrator')</span>
</li><li><span style="font-size:small">Set current Path to&nbsp;<strong>C:\Windows\SysWOW64</strong></span>
</li><li><span style="font-size:small">execute&nbsp;<strong>regsvr32.exe Skype4COM.dll</strong></span>
</li></ol>
<p><span style="font-size:small"><strong><em>&nbsp;</em></strong></span></p>
<p><span style="font-size:small">4.)&nbsp;&nbsp;&nbsp; Now open the <strong>&ldquo;SkypeIntegration.sln&rdquo;</strong> in visual studio 2012. In the References section you will see the SKYPE4COMLib Missing. Now Right click &ldquo;<strong><em>References -&gt;
 Add Reference&rdquo;</em></strong></span></p>
<p><span style="font-size:small">5.)&nbsp;&nbsp;&nbsp; In the <strong><em>Reference Manager</em></strong> Dialog. Under
<strong><em>&ldquo;COM -&gt; Type Libraries&rdquo;</em></strong> Section you can see Skype component registered. Select the
<strong><em>&ldquo;Skype4Com 1.0 Type Library&rdquo; </em></strong>and Click <strong>
<em>OK</em></strong>.</span></p>
<p>&nbsp;</p>
<p><img id="101595" src="101595-capture.png" alt="" width="793" height="546"></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small">6.)&nbsp;&nbsp;&nbsp; Now Run the Application.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:medium"><strong>Screenshot:</strong></span></p>
<p><span style="font-size:medium"><strong><img id="101596" src="101596-capture123.png" alt="" width="861" height="528"></strong></span></p>
<p><span style="font-size:small"><strong>You can read the related wiki article here</strong></span></p>
<p><span style="font-size:medium"><span style="font-size:small"><a href="http://social.technet.microsoft.com/wiki/contents/articles/21733.skype-integration-in-wpf-applications.aspx">http://social.technet.microsoft.com/wiki/contents/articles/21733.skype-integration-in-wpf-applications.aspx</a></span><strong><br>
</strong></span></p>
