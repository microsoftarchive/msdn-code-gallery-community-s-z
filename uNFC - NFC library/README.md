# uNFC - NFC library
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- .NET Framework
- Windows Embedded Compact 7
- .NET Micro Framework
- .Net Compact Framework
- Windows Embedded Compact 2013
- .Net Gadgeteer
## Topics
- Near Field Proximity (NFP)
- nfc
- Embedded
## Updated
- 01/23/2014
## Description

<h1>Introduction</h1>
<p><em>uNFC library allow to use NFC integrated circuit connected to your PC (via serial) or to embedded system based on Windows Embedded Compact or .Net Micro Framework.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The Sample containg Visual Studio 2012 solution for building the library with following frameworks :</em></p>
<ul>
<li><em>.Net Framework 4.0;</em> </li><li><em>.Net Compact Framework 3.9 (for Windows Embedded Compact 2013);</em> </li><li><em>.Net Micro Framework 4.2 and 4.3</em> </li></ul>
<p>There is also a project for .Net Compact Framework 3.5 (Windows Embedded Compact 7) that you can compile creating a Visual Studio 2008 solution.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This librart supports all three types of .Net Framework :&nbsp; &nbsp;</em></p>
<ul>
<li>.Net Framework 4.0 for PC based on Windows 7 / 8 or embedded systems based on Windows Embedded Standard 7 and Windows Embedded 8 Standard;
</li><li>.Net Compact Framework 3.5 / 3.9 for embedded systems based on Windows Embedded Compact 7 and Windows Embedded Compact 2013;
</li><li>.Net Micro Framework 4.2 and 4.3 for embedded systems like Netduino boards and .Net Gadgeteed boards;
</li></ul>
<p>The library supports NXP PN532 chip but it also defines a little framework so that you can develop a managed driver for a new chip and change it without modifying the upper layers and interface to the user application. The support for PN532 chip provides
 all three possible communication channels for it : I2C, SPI and HSU. Tipically the HSU (High Speed UART) channel is used for connecting to a serial port on PC or Windows Embedded Compact based system. I2C and SPI connections are better for .Net Micro Framework
 based boards.</p>
<p>The development and testing was made using RFID/NFC Breakout board from Elecfreaks. More information here
<a href="http://www.elecfreaks.com/store/rfid-nfc-c-82.html">http://www.elecfreaks.com/store/rfid-nfc-c-82.html</a></p>
<p><br>
The reference for PN532 managed driver is the official NXP user manual available here
<a href="http://www.nxp.com/documents/user_manual/141520.pdf">http://www.nxp.com/documents/user_manual/141520.pdf</a></p>
<h1>Example</h1>
<p>Following a simple application example for Netduino Plus board.<br>
<br>
You have to choose the communication layer to use and create one of the classes that implements
<strong><em>IPN532CommunicationLayer </em></strong>interface.<br>
<br>
After that you have to pass this instance to <em><strong>NfcPN532Reader</strong></em> class constructor and you can register to
<em>TagDetected</em> and <em>TagLost</em> events raised when the chip detects and losts a tag.<br>
Last operation is to call <em>Open()</em> method on <em>NfcPN532Reader </em>class instance with tag type to detect.<br>
<br>
In the <em>TagDetected </em>event handler you can access the tag, using one of the classes that are based on
<em><strong>NfcTagConnection</strong></em> abstract class (eg. if you detected Mifare Classic 1K tag, you have to use
<em><strong>NfcMifareTagConnection</strong></em> class). You can get the connection to the tag from
<em><strong>NfcTagEventArgs </strong></em>inside your event handler. On the connection class you have Write and Read method and some other methods specific based for the tag detected.<br>
<br>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">private</span>&nbsp;INfcReader&nbsp;nfc;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;write&nbsp;your&nbsp;code&nbsp;here</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;HSU&nbsp;Communication&nbsp;layer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;MOSI/SDA&nbsp;(TX)&nbsp;--&gt;&nbsp;DIGITAL&nbsp;0&nbsp;(RX&nbsp;COM1)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;SCL/RX&nbsp;(RX)&nbsp;--&gt;&nbsp;DIGITAL&nbsp;1&nbsp;(TX&nbsp;COM1)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IPN532CommunicationLayer&nbsp;commLayer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PN532CommunicationHSU(SerialPorts.COM1);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;SPI&nbsp;Communication&nbsp;layer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;SCK&nbsp;--&gt;&nbsp;DIGITAL&nbsp;13</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;MISO&nbsp;--&gt;&nbsp;DIGITAL&nbsp;12</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;MOSI/SDA&nbsp;--&gt;&nbsp;DIGITAL&nbsp;11</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;SCL/RX&nbsp;-&gt;&nbsp;DIGITAL&nbsp;10</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;IRQ&nbsp;--&gt;&nbsp;DIGITAL&nbsp;8</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//IPN532CommunicationLayer&nbsp;commLayer&nbsp;=&nbsp;new&nbsp;PN532CommunicationSPI(SPI.SPI_module.SPI1,&nbsp;Pins.GPIO_PIN_D10,&nbsp;Pins.GPIO_PIN_D8);</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;I2C&nbsp;Communication&nbsp;layer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;MOSI/SDA&nbsp;--&gt;&nbsp;ANALOG&nbsp;4&nbsp;(SDA)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;SCL/RS&nbsp;--&gt;&nbsp;ANALOG&nbsp;5&nbsp;(SCL)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;IRQ&nbsp;--&gt;&nbsp;DIGITAL&nbsp;8</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//IPN532CommunicationLayer&nbsp;commLayer&nbsp;=&nbsp;new&nbsp;PN532CommunicationI2C(Pins.GPIO_PIN_D8);</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nfc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;NfcPN532Reader(commLayer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nfc.TagDetected&nbsp;&#43;=&nbsp;nfc_TagDetected;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nfc.TagLost&nbsp;&#43;=&nbsp;nfc_TagLost;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nfc.Open(NfcTagType.MifareUltralight);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InterruptPort&nbsp;button&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;InterruptPort(Pins.ONBOARD_SW1,&nbsp;<span class="cs__keyword">true</span>,&nbsp;Port.ResistorMode.Disabled,&nbsp;Port.InterruptMode.InterruptEdgeHigh);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button.OnInterrupt&nbsp;&#43;=&nbsp;button_OnInterrupt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thread.Sleep(Timeout.Infinite);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button_OnInterrupt(<span class="cs__keyword">uint</span>&nbsp;data1,&nbsp;<span class="cs__keyword">uint</span>&nbsp;data2,&nbsp;DateTime&nbsp;time)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nfc.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;nfc_TagLost(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;NfcTagEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Debug.Print(<span class="cs__string">&quot;LOST&nbsp;&quot;</span>&nbsp;&#43;&nbsp;HexToString(e.Connection.ID));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;nfc_TagDetected(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;NfcTagEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Debug.Print(<span class="cs__string">&quot;DETECTED&nbsp;&quot;</span>&nbsp;&#43;&nbsp;HexToString(e.Connection.ID));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;data;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(e.NfcTagType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;NfcTagType.MifareClassic1k:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NfcMifareTagConnection&nbsp;mifareConn&nbsp;=&nbsp;(NfcMifareTagConnection)e.Connection;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mifareConn.Authenticate(MifareKeyAuth.KeyA,&nbsp;0x08,&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;{&nbsp;0xFF,&nbsp;0xFF,&nbsp;0xFF,&nbsp;0xFF,&nbsp;0xFF,&nbsp;0xFF&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mifareConn.Read(0x08);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;byte16;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">byte</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;data.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;datai&nbsp;=&nbsp;i;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mifareConn.Write(0x08,&nbsp;data);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mifareConn.Read(0x08);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;NfcTagType.MifareUltralight:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NfcMifareUlTagConnection&nbsp;mifareUlConn&nbsp;=&nbsp;(NfcMifareUlTagConnection)e.Connection;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">byte</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="cs__number">16</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;read&nbsp;=&nbsp;mifareUlConn.Read(i);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mifareUlConn.Read(0x08);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;byte4;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">byte</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;data.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;datai&nbsp;=&nbsp;i;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mifareUlConn.Write(0x08,&nbsp;data);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mifareUlConn.Read(0x08);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">default</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;hexChars&nbsp;=&nbsp;<span class="cs__string">&quot;0123456789ABCDEF&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Convert&nbsp;hex&nbsp;byte&nbsp;array&nbsp;in&nbsp;a&nbsp;hex&nbsp;string</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;value&quot;&gt;Byte&nbsp;array&nbsp;with&nbsp;hex&nbsp;values&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;Hex&nbsp;string&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;HexToString(<span class="cs__keyword">byte</span>[]&nbsp;<span class="cs__keyword">value</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;hexString&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="cs__keyword">value</span>.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hexString.Append(hexChars[(<span class="cs__keyword">value</span>[i]&nbsp;&gt;&gt;&nbsp;<span class="cs__number">4</span>)&nbsp;&amp;&nbsp;0x0F]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hexString.Append(hexChars[<span class="cs__keyword">value</span>[i]&nbsp;&amp;&nbsp;0x0F]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;hexString.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
