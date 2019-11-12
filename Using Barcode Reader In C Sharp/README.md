# Using Barcode Reader In C Sharp
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework 4.0
- Visual C Sharp
## Topics
- threading
- ports
## Updated
- 02/16/2012
## Description

<h1>Introduction</h1>
<p style="text-align:justify"><em>This problem solving is for using the barcode reader to be interfaced to the Serial Port of the PC and using the same to read through code in C#.</em></p>
<h1><span>Building the Sample</span></h1>
<p style="text-align:justify"><em>Just copy the code in the New C# Windows Application Form with a textbox named Textbox1 and play the rest....</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p style="text-align:justify">This example of the barcode reader is used to interface a barcode reader via the serial port and read the barcode through C# code attached below in a control placed over the windows form as textbox.&nbsp; The code is a simple one
 with a delegate SetTextDeleg taking the string as an argument and the load event of the form declaring and initializig various serialport flags with SerialPort.open() method to open the serial port for reading. The form's load event with sender object and
 evenargs object initializes the new serial port with name &quot;COM1&quot;, parity bit as none and stopbits as one.&nbsp; There is no handshake as indicated by Handshake.None, the datarececeived delegate executes the method sp_DataReceived as the event where the Readtimeout
 is set as 500 and Writetimeout is set as 500.&nbsp; Now we open the serial port using the method Open syntaxed as _SerialPort.Open().&nbsp; To start the event we make use of a button to scan the barcode and check if the serialport is open or not, if it is
 open we just write to the port else we open the port.</p>
<p style="text-align:justify"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SerialPort&nbsp;_serialPort;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">delegate</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SetTextDeleg(<span class="cs__keyword">string</span>&nbsp;text);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Form1_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SerialPort(<span class="cs__string">&quot;COM1&quot;</span>,&nbsp;<span class="cs__number">19200</span>,&nbsp;Parity.None,&nbsp;<span class="cs__number">8</span>,&nbsp;StopBits.One);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort.Handshake&nbsp;=&nbsp;Handshake.None;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort.DataReceived&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SerialDataReceivedEventHandler(sp_DataReceived);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort.ReadTimeout&nbsp;=&nbsp;<span class="cs__number">500</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort.WriteTimeout&nbsp;=&nbsp;<span class="cs__number">500</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort.Open();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnStart_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(!_serialPort.IsOpen)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort.Open();&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort.Write(<span class="cs__string">&quot;SI\r\n&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Error&nbsp;opening/writing&nbsp;to&nbsp;serial&nbsp;port&nbsp;::&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ex.Message,&nbsp;<span class="cs__string">&quot;Error!&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;sp_DataReceived(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;SerialDataReceivedEventArgs&nbsp;e)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thread.Sleep(<span class="cs__number">500</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;data&nbsp;=&nbsp;_serialPort.ReadLine();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.BeginInvoke(<span class="cs__keyword">new</span>&nbsp;SetTextDeleg(si_DataReceived),&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">object</span>[]&nbsp;{&nbsp;data&nbsp;});&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;si_DataReceived(<span class="cs__keyword">string</span>&nbsp;data)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;data.Trim();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
