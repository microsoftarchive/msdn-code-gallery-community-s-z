# Serial Communication with arduino in c#
## Requires
- Visual Studio 2015
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- .NET Framework
- arduino
- Visual C#
- Visual Studio 2015
## Topics
- arduino
- SerialPort
- serial communication
- arduino interfacing
## Updated
- 06/04/2017
## Description

<h1>Introduction</h1>
<p><span>This is just simple application that shows how you can communicate with other hardware device using serial port. Here I&rsquo;m using Arduino Uno. I had uploaded Arduino sketch (code) with the visual studio code file.</span><strong>&nbsp;</strong><em>&nbsp;</em></p>
<h1><span>Building the Sample</span></h1>
<p><span>Just download this file.</span> </p>
<li><span>Extract it</span> </li><li><span>Upload code to Arduino</span> </li><li><span>Open visual studio </span></li><li><span>Build windows form application </span></li><li><span>Write com port at which Arduino is connected and then click button to turn led on/ off,</span>
<strong>&nbsp;</strong><em>&nbsp;</em>
<p></p>
<p><span><strong>Note: Led is connected to pin 13 by default</strong>.</span><strong></strong><em></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span>In visual c# windows form applictaion, we use following reference</span></p>
<p><span>using System.IO.Ports;</span></p>
<p><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.IO.Ports
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System.IO.Ports&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>&nbsp;</span>&nbsp;</div>
<p>&nbsp;</p>
<p><span>In designer view add serialPort module</span></p>
<p>&nbsp;</p>
<p><span><img id="173998" src="173998-s1.png" alt="" width="711" height="408"><br>
</span></p>
<p><span><br>
</span></p>
<p><span><span>then we</span> need to define following things while communicating via serialPort:</span></p>
<ul>
<li><span>PortName</span> </li><li><span>BaudRate</span> </li><li><span>DataBits</span> </li><li><span>Parity</span> </li><li><span>StopBits</span> </li><li><span>Handshake</span> </li><li><span>Encoding</span> </li></ul>
<p>&nbsp;</p>
<p><span>Port name can be different, you can check it from arduino IDE at which port your arduino is connected or you may check it from DeviceManager under ports option (this option is available when some device is connected to com port).</span></p>
<p><span>Here in this sample i'm using foreach loop that finds all available com ports</span></p>
<p>&nbsp;</p>
<p><span>by default we use BaudRate 9600,</span></p>
<p><span>databits 8,</span></p>
<p><span>parity =None</span></p>
<p><span>stopbits =1</span></p>
<p><span>handshake =none</span></p>
<p><span>and encoding to default encoding</span></p>
<p>&nbsp;</p>
<p><img id="173999" src="173999-s2.png" alt="" width="382" height="121"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span>To send command ,let say we need to write in serialPort and which is to be read by other end</span></p>
<p><span>We use following command:</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">serialPort1.Write(&quot;1&quot;);</pre>
<div class="preview">
<pre class="js">serialPort1.Write(<span class="js__string">&quot;1&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p><span>But first we need to open port</span></p>
<p><span>Then write</span></p>
<p><span>And then close that port again</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">serialPort1.Open();
serialPort1.Write(&quot;1&quot;);
serialPort1.Close();</pre>
<div class="preview">
<pre class="csharp">serialPort1.Open();&nbsp;
serialPort1.Write(<span class="cs__string">&quot;1&quot;</span>);&nbsp;
serialPort1.Close();</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span>if you have any query,&nbsp; regarding this sample feel free to give feedback</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span>umairnadeem20@hotmail.com</span></div>
<div class="endscriptcode"></div>
</li>