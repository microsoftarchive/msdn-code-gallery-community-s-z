# TCP / IP Server Client Example Part 3 (Chat Application)
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- GDI+
- SQL Server
- ASP.NET
- File System
- .NET
- LINQ
- Windows Forms
- Microsoft Azure
- Visual Studio 2010
- Windows Phone 7
- .NET Framework 4
- .NET Framework
- Visual Basic .NET
- VB.Net
- .NET Framework 4.0
- Windows General
- Windows Phone
- C# Language
- WinForms
- Windows 8
- Graphics Functions
- Visual Studio 2012
- Windows Phone 7.5
- .NET 4.5
- Windows Store app
- .NET Development
- Windows Phone Development
## Topics
- Controls
- Animation
- Graphics
- C#
- Data Binding
- Asynchronous Programming
- Security
- GDI+
- Authentication
- ASP.NET
- Azure
- REST
- File System
- Class Library
- Reflection
- User Interface
- Windows Forms
- Graphics and 3D
- Architecture and Design
- Multithreading
- Navigation
- Microsoft Azure
- Data Access
- threading
- events
- Images
- customization
- ImageViewer
- custom controls
- Web Services
- UI Layout
- Windows Form Controls
- 2d graphics
- Audio
- Visual Basic .NET
- Performance
- Phone application development
- Parallel Programming
- Image manipulation
- Code Sample
- Automation
- UAC
- Getting Started
- Image Gallery
- Service Bus
- Printing
- Download
- Windows Phone
- Image
- Windows Azure and WCF
- Inter-process Communication
- Globalization
- Event Handling
- .NET 4
- Imaging
- Messaging
- Notifications
- How to
- UI Design
- Generic C# resuable code
- Metro UI
- File Systems
- Files
- Networking
- Image Optimization
- general
- Design Patterns
- Windows 8
- Windows Azure Service Bus
- Windows Forms Controls
- C# Language Features
- Language Samples
- Graphics Functions
- Audio and video
- Devices and sensors
- User Control
- Windows web services
- User Experience
- Windows Azure Mobile Services
- BitmapImage
- Windows Phone 8
- Windows Store app
- Load Image
- Dynamically Image
- data and storage
## Updated
- 12/17/2013
## Description

<div>
<h1>1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Introduction</h1>
</div>
<p>Today we redesign our chat system and create a login system which we can then associate friends lists to. There is quite a lot to do so let&rsquo;s get on with it.</p>
<div>
<h1>2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Building the Sample</h1>
</div>
<p>The sample is built in Visual Studio 2012 Ultimate as an x86 targeted application using .Net Framework 4. We will be using NuGet packages, a number of 3rd party libraries. All of which will be fully explained to you ensuring that the final compilation of
 your App will be hassle free. Oh! And the sample code is verbosely commented so you should have no problem in working out what the code does.</p>
<div>
<h1>3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Description</h1>
</div>
<p>Communication is fundamental to us all. Our Chat application is starting to take form. Previously you saw our Echo server, this time we are building a chat client server application pair that permits logging into the server and registering an account all
 from the client.</p>
<div>
<h1>4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Creating our Application</h1>
</div>
<p>Open Visual Studio 2012 and Create a New Project. Call the Project ChatApp. You will find in the Solution download a new .dll called NetComm it is a 3<sup>rd</sup> party library that we will be using for our communication. Or you can download it from the
 link below in the More Information section.</p>
<h2>4.1&nbsp;&nbsp;&nbsp; Server Design</h2>
<p>I will not go into too much detail behind the design for the server and clients &ndash; you can work that out from the solution, or design your own! However, this is how my design currently looks:</p>
<p><img id="104166" src="104166-picture%202013-12-06%2019_16_59.png" alt="" width="314" height="634" style="float:left"></p>
<p><img id="104165" src="104165-picture%202013-12-06%2019_07_24.png" alt="" width="274" height="653"></p>
<p><img id="104164" src="104164-picture%202013-12-06%2019_07_01.png" alt="" width="378" height="201" style="float:left"></p>
<p>&nbsp;<img id="104163" src="104163-picture%202013-12-06%2019_06_46.png" alt="" width="380" height="215"></p>
<p>&nbsp;</p>
<h2>4.2&nbsp;&nbsp;&nbsp; How it works</h2>
<p>You run the solution and under the Server menu click Start. When the server is running the red circle at the bottom will change to green. You can now click the second button in the control bar to open clients.</p>
<p>You click the first little yellow icon in the control bar of the clients to log in or register. When the red circle of the client application turns green it means you have successfully logged in.</p>
<p>That&rsquo;s all there is to this for today because there is quite a bit of code to explain, before we add the facility of adding friends.</p>
<p>Our Server now has three commands that it understands, these are CLOSING, REGISTRATION, and LOGIN. The Server processes these commands internally and responds to the client that sent the command.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void Server_DataReceived(string iD, byte[] data)
        {
            string message = ConvertBytesToString(data);
            if (iD == &quot;0&quot;)
            {
                DisplayInformation(&quot;Received Command From Client &quot; &#43; iD &#43; &quot; for this Server&quot;);


                if (message.StartsWith(&quot;CLOSING&quot;))
                {
                    loggedInUsers.Remove(iD);
                    lblConnections.Text = loggedInUsers.Count.ToString();
                    DisplayInformation(&quot;Client &quot; &#43; iD &#43; &quot; is Closing&quot;);
                }
                else if (message.StartsWith(&quot;REGISTRATION&quot;))
                {
                    // Message = REGISTRATION:&lt;USERNAME&gt;:&lt;PASSWORD&gt;
                    if (registeredUsers.ContainsKey(message.Split(':')[1].ToString()))
                    {
                        server.SendData(iD, ConvertStringToBytes(&quot;ERROR:That email is already registered.&quot;));
                        DisplayInformation(&quot;Client &quot; &#43; iD &#43;  &quot;ERROR:That email is already registered.&quot;);
                    }
                    else
                    {
                        registeredUsers.Add(message.Split(':')[1].ToString(), message.Split(':')[2].ToString());
                        loggedInUsers.Add(iD, DateTime.Now.ToString());
                        lblConnections.Text = loggedInUsers.Count.ToString();
                        server.SendData(iD, ConvertStringToBytes(&quot;SUCCESS&quot;));
                        DisplayInformation(&quot;Client &quot; &#43; iD &#43; &quot;SUCCESS registered.&quot;);
                    }
                }
                else if (message.StartsWith(&quot;LOGIN&quot;))
                {
                    // Message = LOGIN:&lt;USERNAME&gt;:&lt;PASSWORD&gt;
                    if (registeredUsers.ContainsKey(message.Split(':')[1].ToString()))
                    {
                        string res = &quot;&quot;;
                        if (registeredUsers.TryGetValue(iD, out res))
                        {
                            // Successfully logged in
                            int newSenderId = (loggedInUsers.Count &#43; 1);
                            server.SendData(iD, ConvertStringToBytes(&quot;ID:&quot; &#43; newSenderId.ToString()));
                            loggedInUsers.Add(newSenderId.ToString(), DateTime.Now.ToString());
                            lblConnections.Text = loggedInUsers.Count.ToString();
                            DisplayInformation(&quot;Client &quot; &#43; iD &#43; &quot;SUCCESS Logged in.&quot;);
                        }
                    }
                    else
                    {
                        server.SendData(iD, ConvertStringToBytes(&quot;ERROR:Login Details Not Recognized&quot;));
                        DisplayInformation(&quot;Client &quot; &#43; iD &#43; &quot;ERROR:Login Details Not Recognized&quot;);
                    }
                }
                else
                {
                    DisplayInformation(&quot;Received Command From Client &quot; &#43; iD &#43; &quot; for this Server: &quot; &#43; message);
                }


            }
            else
            {
                DisplayInformation(&quot;Received Command From Client &quot; &#43; iD &#43; &quot; for this Server: &quot; &#43; message);
            }
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Server_DataReceived(<span class="cs__keyword">string</span>&nbsp;iD,&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;data)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;message&nbsp;=&nbsp;ConvertBytesToString(data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(iD&nbsp;==&nbsp;<span class="cs__string">&quot;0&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisplayInformation(<span class="cs__string">&quot;Received&nbsp;Command&nbsp;From&nbsp;Client&nbsp;&quot;</span>&nbsp;&#43;&nbsp;iD&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;for&nbsp;this&nbsp;Server&quot;</span>);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(message.StartsWith(<span class="cs__string">&quot;CLOSING&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;loggedInUsers.Remove(iD);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblConnections.Text&nbsp;=&nbsp;loggedInUsers.Count.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisplayInformation(<span class="cs__string">&quot;Client&nbsp;&quot;</span>&nbsp;&#43;&nbsp;iD&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;is&nbsp;Closing&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(message.StartsWith(<span class="cs__string">&quot;REGISTRATION&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Message&nbsp;=&nbsp;REGISTRATION:&lt;USERNAME&gt;:&lt;PASSWORD&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(registeredUsers.ContainsKey(message.Split(<span class="cs__string">':'</span>)[<span class="cs__number">1</span>].ToString()))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;server.SendData(iD,&nbsp;ConvertStringToBytes(<span class="cs__string">&quot;ERROR:That&nbsp;email&nbsp;is&nbsp;already&nbsp;registered.&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisplayInformation(<span class="cs__string">&quot;Client&nbsp;&quot;</span>&nbsp;&#43;&nbsp;iD&nbsp;&#43;&nbsp;&nbsp;<span class="cs__string">&quot;ERROR:That&nbsp;email&nbsp;is&nbsp;already&nbsp;registered.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;registeredUsers.Add(message.Split(<span class="cs__string">':'</span>)[<span class="cs__number">1</span>].ToString(),&nbsp;message.Split(<span class="cs__string">':'</span>)[<span class="cs__number">2</span>].ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;loggedInUsers.Add(iD,&nbsp;DateTime.Now.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblConnections.Text&nbsp;=&nbsp;loggedInUsers.Count.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;server.SendData(iD,&nbsp;ConvertStringToBytes(<span class="cs__string">&quot;SUCCESS&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisplayInformation(<span class="cs__string">&quot;Client&nbsp;&quot;</span>&nbsp;&#43;&nbsp;iD&nbsp;&#43;&nbsp;<span class="cs__string">&quot;SUCCESS&nbsp;registered.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(message.StartsWith(<span class="cs__string">&quot;LOGIN&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Message&nbsp;=&nbsp;LOGIN:&lt;USERNAME&gt;:&lt;PASSWORD&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(registeredUsers.ContainsKey(message.Split(<span class="cs__string">':'</span>)[<span class="cs__number">1</span>].ToString()))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;res&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(registeredUsers.TryGetValue(iD,&nbsp;<span class="cs__keyword">out</span>&nbsp;res))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Successfully&nbsp;logged&nbsp;in</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;newSenderId&nbsp;=&nbsp;(loggedInUsers.Count&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;server.SendData(iD,&nbsp;ConvertStringToBytes(<span class="cs__string">&quot;ID:&quot;</span>&nbsp;&#43;&nbsp;newSenderId.ToString()));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;loggedInUsers.Add(newSenderId.ToString(),&nbsp;DateTime.Now.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblConnections.Text&nbsp;=&nbsp;loggedInUsers.Count.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisplayInformation(<span class="cs__string">&quot;Client&nbsp;&quot;</span>&nbsp;&#43;&nbsp;iD&nbsp;&#43;&nbsp;<span class="cs__string">&quot;SUCCESS&nbsp;Logged&nbsp;in.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;server.SendData(iD,&nbsp;ConvertStringToBytes(<span class="cs__string">&quot;ERROR:Login&nbsp;Details&nbsp;Not&nbsp;Recognized&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisplayInformation(<span class="cs__string">&quot;Client&nbsp;&quot;</span>&nbsp;&#43;&nbsp;iD&nbsp;&#43;&nbsp;<span class="cs__string">&quot;ERROR:Login&nbsp;Details&nbsp;Not&nbsp;Recognized&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisplayInformation(<span class="cs__string">&quot;Received&nbsp;Command&nbsp;From&nbsp;Client&nbsp;&quot;</span>&nbsp;&#43;&nbsp;iD&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;for&nbsp;this&nbsp;Server:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisplayInformation(<span class="cs__string">&quot;Received&nbsp;Command&nbsp;From&nbsp;Client&nbsp;&quot;</span>&nbsp;&#43;&nbsp;iD&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;for&nbsp;this&nbsp;Server:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>The Clients understand three commands, but they only process two at the moment, the missing command is &ldquo;SUCCESS&rdquo;. The two commands / Messages that the clients understand are both Error messages &ndash; one stating that you can&rsquo;t register
 a particular email as it is already registered and the other stating that the password is incorrect.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> void ClientDataReceived(byte[] data, string iD)
        {
            string message = ConvertBytesToString(data);

            if (iD == null) // Message from the server
            {
                if (message == &quot;ERROR:That email is already registered.&quot;)
                {
                    MessageBox.Show(message);
                }
                else if (message == &quot;ERROR:Login Details Not Recognized&quot;)
                {
                    MessageBox.Show(message);
                }
            }
            else
            {
                // Message from a friend
            }
        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">void</span>&nbsp;ClientDataReceived(<span class="cs__keyword">byte</span>[]&nbsp;data,&nbsp;<span class="cs__keyword">string</span>&nbsp;iD)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;message&nbsp;=&nbsp;ConvertBytesToString(data);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(iD&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;<span class="cs__com">//&nbsp;Message&nbsp;from&nbsp;the&nbsp;server</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(message&nbsp;==&nbsp;<span class="cs__string">&quot;ERROR:That&nbsp;email&nbsp;is&nbsp;already&nbsp;registered.&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(message&nbsp;==&nbsp;<span class="cs__string">&quot;ERROR:Login&nbsp;Details&nbsp;Not&nbsp;Recognized&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Message&nbsp;from&nbsp;a&nbsp;friend</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>This is not how you would do things in a production environment because to beat this system all we do is try to log in using a whole bunch of different emails &ndash; when we get the password incorrect response we know we have someone&rsquo;s account ID
 and only need to work out their password which is surprisingly simple in most cases. Another problem with this is we are sending the log in details in plain text meaning anyone who has access to your internet communication know you private log on details.
 These problems will all be addressed later.</p>
<p>&nbsp;</p>
<h2>4.3&nbsp;&nbsp;&nbsp; Source Code</h2>
<ul>
<li>Source Code Form1.cs &ndash; The Chat application(s) </li><li>Source Code Forms/FrmServer.cs &ndash; the Server Application </li><li>Source Code Forms/FrmLogin.cs &ndash; the login dialog for the Chat application
</li><li>Source Code Forms/FrmRegister.cs &ndash; the Registration dialog for the chat application.
</li><li>Source Code FriendsControl/UserControl1 &ndash; A custom control that will be used by the Chat application when the logged on user has a friends list.
</li></ul>
<p>If you like my samples then please nominate me for an MVP. <a href="http://mvp.microsoft.com/en-us/nominate-an-mvp.aspx">
http://mvp.microsoft.com/en-us/nominate-an-mvp.aspx</a>. Leave me a message if you nominated me!</p>
<div>
<h1>5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; More Information</h1>
</div>
<p>To convert the solution to a previous version of Visual Studio you can use this free application:
<a href="http://vsprojectconverter.codeplex.com/">http://vsprojectconverter.codeplex.com/</a> or download and use Visual Studio 2013 Express which is freely available from Microsoft from here:
<a href="http://www.visualstudio.com/downloads/download-visual-studio-vs">http://www.visualstudio.com/downloads/download-visual-studio-vs</a>.</p>
<p>NetComm.dll: <a href="http://www.codeproject.com/Articles/118485/C-VB-NET-Multi-user-Communication-Library-TCP">
http://www.codeproject.com/Articles/118485/C-VB-NET-Multi-user-Communication-Library-TCP</a></p>
