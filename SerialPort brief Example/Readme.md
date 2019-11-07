# SerialPort brief Example
## Requires
- Visual Studio 2008
## License
- MS-LPL
## Technologies
- System.IO.Ports
## Topics
- Serial Port
## Updated
- 01/06/2012
## Description

<h1>Introduction</h1>
<p>This sample is to accompany the blog at :</p>
<p><a href="http://charpcoder.wordpress.com/2011/12/21/serial-port-programming-part-1a-very-brief-introduction/">http://charpcoder.wordpress.com/2011/12/21/serial-port-programming-part-1a-very-brief-introduction/</a></p>
<p>It will be updated more or less daily until completion. If you'd like any particular questions addressed please let me know.</p>
<p>The blog article and following sample code was primary created to address various questions from the Forums. It seems that there's some confusion on how to interact with the serial ports. In my experience with serial ports the simpler the better.</p>
<p>There are two very important items that always need to be addressed while interacting with the serial port:</p>
<p>How do I know that I've received all the data I need and not more?</p>
<p style="padding-left:30px">In the code example a string is used to accumelate data and check to see if the EOT character is removed. In subsequent updates this will get more complex and offer more choices.</p>
<p>There is no way to accurately predict how many bytes you will receive until you actually read from the serial buffer.</p>
<p style="padding-left:30px">That's why in the example below this line is used:</p>
<pre style="padding-left:30px"><br>&nbsp;//There is no accurate method for checking how many bytes are read&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</pre>
<pre style="padding-left:30px"> //unless you check the return from the Read method&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</pre>
<pre style="padding-left:30px"> int bytesRead = _serialPort.Read(buffer, 0, buffer.Length);<br></pre>
<h1>Question/Comments</h1>
<p>Please ask or comment in the Q &amp; A section. I'll be back and making updates to this after new year's. I welcom and hope for comments and ideas to improve the class.</p>
<h1>Changes</h1>
<p>December 21/2011 - Updated code to include a lot of comments. Mostly to satisfy StyleCop</p>
<p>December 21/2011 - Added the new classes and a Windows Forms project as examples on how to manipulate the different settings. Plese see for more details.&nbsp;</p>
<p>December 22/2011 - Added send method as well as a textbox for receiving and send information. Please see&nbsp;<a href="http://charpcoder.wordpress.com/">http://charpcoder.wordpress.com/</a>&nbsp;for details.&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.IO.Ports;
using System.Text;

namespace SerialPortExample
{
    /// &lt;summary&gt;
    /// Interfaces with a serial port. There should only be one instance
    /// of this class for each serial port to be used.
    /// &lt;/summary&gt;
    public class SerialPortInterface
    {
        private SerialPort _serialPort = new SerialPort();
        private int _baudRate = 9600;
        private int _dataBits = 8;
        private Handshake _handshake = Handshake.None;
        private Parity _parity = Parity.None;
        private string _portName = &quot;COM1&quot;;
        private StopBits _stopBits = StopBits.One;

        /// &lt;summary&gt;
        /// Holds data received until we get a terminator.
        /// &lt;/summary&gt;
        private string tString = string.Empty;
        /// &lt;summary&gt;
        /// End of transmition byte in this case EOT (ASCII 4).
        /// &lt;/summary&gt;
        private byte _terminator = 0x4;

        public int BaudRate { get { return _baudRate; } set { _baudRate = value; } }
        public int DataBits { get { return _dataBits; } set { _dataBits = value; } }
        public Handshake Handshake { get { return _handshake; } set { _handshake = value; } }
        public Parity Parity { get { return _parity; } set { _parity = value; } }
        public string PortName { get { return _portName; } set { _portName = value; } }
        public bool Open()
        {
            try
            {
                _serialPort.BaudRate = _baudRate;
                _serialPort.DataBits = _dataBits;
                _serialPort.Handshake = _handshake;
                _serialPort.Parity = _parity;
                _serialPort.PortName = _portName;
                _serialPort.StopBits = _stopBits;
                _serialPort.DataReceived &#43;= new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            }
            catch { return false; }
            return true;
        }

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Initialize a buffer to hold the received data
            byte[] buffer = new byte[_serialPort.ReadBufferSize];

            //There is no accurate method for checking how many bytes are read
            //unless you check the return from the Read method
            int bytesRead = _serialPort.Read(buffer, 0, buffer.Length);

            //For the example assume the data we are received is ASCII data.
            tString &#43;= Encoding.ASCII.GetString(buffer, 0, bytesRead);
            //Check if string contains the terminator 
            if (tString.IndexOf((char)_terminator) &gt; -1)
            {
                //If tString does contain terminator we cannot assume that it is the last character received
                string workingString = tString.Substring(0, tString.IndexOf((char)_terminator));
                //Remove the data up to the terminator from tString
                tString = tString.Substring(tString.IndexOf((char)_terminator));
                //Do something with workingString
                Console.WriteLine(workingString);
            }
        }

    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO.Ports;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SerialPortExample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Interfaces&nbsp;with&nbsp;a&nbsp;serial&nbsp;port.&nbsp;There&nbsp;should&nbsp;only&nbsp;be&nbsp;one&nbsp;instance</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;of&nbsp;this&nbsp;class&nbsp;for&nbsp;each&nbsp;serial&nbsp;port&nbsp;to&nbsp;be&nbsp;used.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SerialPortInterface&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;SerialPort&nbsp;_serialPort&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SerialPort();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;_baudRate&nbsp;=&nbsp;<span class="cs__number">9600</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;_dataBits&nbsp;=&nbsp;<span class="cs__number">8</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Handshake&nbsp;_handshake&nbsp;=&nbsp;Handshake.None;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Parity&nbsp;_parity&nbsp;=&nbsp;Parity.None;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;_portName&nbsp;=&nbsp;<span class="cs__string">&quot;COM1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;StopBits&nbsp;_stopBits&nbsp;=&nbsp;StopBits.One;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Holds&nbsp;data&nbsp;received&nbsp;until&nbsp;we&nbsp;get&nbsp;a&nbsp;terminator.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;tString&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;End&nbsp;of&nbsp;transmition&nbsp;byte&nbsp;in&nbsp;this&nbsp;case&nbsp;EOT&nbsp;(ASCII&nbsp;4).</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">byte</span>&nbsp;_terminator&nbsp;=&nbsp;0x4;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;BaudRate&nbsp;{&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_baudRate;&nbsp;}&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;_baudRate&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;}&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;DataBits&nbsp;{&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_dataBits;&nbsp;}&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;_dataBits&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;}&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Handshake&nbsp;Handshake&nbsp;{&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_handshake;&nbsp;}&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;_handshake&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;}&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Parity&nbsp;Parity&nbsp;{&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_parity;&nbsp;}&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;_parity&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;}&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;PortName&nbsp;{&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_portName;&nbsp;}&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;_portName&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;}&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort.BaudRate&nbsp;=&nbsp;_baudRate;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort.DataBits&nbsp;=&nbsp;_dataBits;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort.Handshake&nbsp;=&nbsp;_handshake;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort.Parity&nbsp;=&nbsp;_parity;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort.PortName&nbsp;=&nbsp;_portName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort.StopBits&nbsp;=&nbsp;_stopBits;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_serialPort.DataReceived&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SerialDataReceivedEventHandler(_serialPort_DataReceived);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;_serialPort_DataReceived(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;SerialDataReceivedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Initialize&nbsp;a&nbsp;buffer&nbsp;to&nbsp;hold&nbsp;the&nbsp;received&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;buffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[_serialPort.ReadBufferSize];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//There&nbsp;is&nbsp;no&nbsp;accurate&nbsp;method&nbsp;for&nbsp;checking&nbsp;how&nbsp;many&nbsp;bytes&nbsp;are&nbsp;read</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//unless&nbsp;you&nbsp;check&nbsp;the&nbsp;return&nbsp;from&nbsp;the&nbsp;Read&nbsp;method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;bytesRead&nbsp;=&nbsp;_serialPort.Read(buffer,&nbsp;<span class="cs__number">0</span>,&nbsp;buffer.Length);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//For&nbsp;the&nbsp;example&nbsp;assume&nbsp;the&nbsp;data&nbsp;we&nbsp;are&nbsp;received&nbsp;is&nbsp;ASCII&nbsp;data.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tString&nbsp;&#43;=&nbsp;Encoding.ASCII.GetString(buffer,&nbsp;<span class="cs__number">0</span>,&nbsp;bytesRead);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Check&nbsp;if&nbsp;string&nbsp;contains&nbsp;the&nbsp;terminator&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(tString.IndexOf((<span class="cs__keyword">char</span>)_terminator)&nbsp;&gt;&nbsp;-<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//If&nbsp;tString&nbsp;does&nbsp;contain&nbsp;terminator&nbsp;we&nbsp;cannot&nbsp;assume&nbsp;that&nbsp;it&nbsp;is&nbsp;the&nbsp;last&nbsp;character&nbsp;received</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;workingString&nbsp;=&nbsp;tString.Substring(<span class="cs__number">0</span>,&nbsp;tString.IndexOf((<span class="cs__keyword">char</span>)_terminator));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Remove&nbsp;the&nbsp;data&nbsp;up&nbsp;to&nbsp;the&nbsp;terminator&nbsp;from&nbsp;tString</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tString&nbsp;=&nbsp;tString.Substring(tString.IndexOf((<span class="cs__keyword">char</span>)_terminator));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Do&nbsp;something&nbsp;with&nbsp;workingString</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(workingString);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
