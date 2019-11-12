# Send SMS using C#
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
## Topics
- Send SMS
## Updated
- 08/10/2011
## Description

<h1>Introduction</h1>
<p>This sample demonstrates how to use HTTPWebRequest/Response to send the SMS through a SMS gateway.</p>
<p>In order to send a SMS, you need an account with a SMS gateway.&nbsp;To send a SMS, we need to pass all required parameters. These parameters may vary gateway to gateway. Please check with your SMS gateway for more details.&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p>The following steps walk through a demonstration of using HTTPWebRequest/Response to send SMS from a SMS gateway.</p>
<p>Step 1: Register an account with a SMS gateway</p>
<p>Step 2: Add/Replace SMS gateway detail in AppSettings section of the Web.config<br>
&nbsp;&nbsp;&nbsp; &lt;!-- SMS Gateway Settings --&gt;<br>
&nbsp;&nbsp;&nbsp; &lt;add key=&quot;SMSGatewayUserID&quot; value=&quot;UserID&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp; &lt;add key=&quot;SMSGatewayPassword&quot; value=&quot;Password&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp; &lt;add key=&quot;SMSGatewayGSMSenderID&quot; value=&quot;SenderID-If-Any&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp; &lt;add key=&quot;SMSGatewayPostURL&quot; value=&quot;<a href="http://SomeGateway/">http://SomeGateway/</a>&quot; /&gt;&nbsp;</p>
<p>Step 3: Add/Replace parameters (Please refer to your SMS gateway API)<br>
&nbsp;&nbsp; // Prepare POST data <br>
&nbsp;&nbsp; postData.Append(&quot;action=send&quot;);<br>
&nbsp;&nbsp; postData.Append(&quot;&amp;username=&quot; &#43; userId);<br>
&nbsp;&nbsp; postData.Append(&quot;&amp;passphrase=&quot; &#43; pwd);<br>
&nbsp;&nbsp; postData.Append(&quot;&amp;phone=&quot; &#43; sendTo);<br>
&nbsp;&nbsp; postData.Append(&quot;&amp;message=&quot; &#43; smsText);</p>
<p>Step 4: Build and run the sample web site in Visual Studio 2010</p>
<p>Step 5: Enter a valid Mobile no in the &lsquo;Mobile no&rsquo; input box, a message in the &lsquo;Message&rsquo; box and click on &lsquo;Send SMS&rsquo; button which will send the request to the SMS gateway.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Sample code&nbsp;using HTTPWebRequest/Response to send&nbsp;SMS</em><em>&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SendSMS(<span class="cs__keyword">string</span>&nbsp;smsText,&nbsp;<span class="cs__keyword">string</span>&nbsp;sendTo)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Variables</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;userId&nbsp;=&nbsp;ConfigurationManager.AppSettings[<span class="cs__string">&quot;SMSGatewayUserID&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;pwd&nbsp;=&nbsp;ConfigurationManager.AppSettings[<span class="cs__string">&quot;SMSGatewayPassword&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;postURL&nbsp;=&nbsp;ConfigurationManager.AppSettings[<span class="cs__string">&quot;SMSGatewayPostURL&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;postData&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;responseMessage&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebRequest&nbsp;request&nbsp;=&nbsp;<span class="cs__keyword">null</span>;<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Prepare&nbsp;POST&nbsp;data&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;postData.Append(<span class="cs__string">&quot;action=send&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;postData.Append(<span class="cs__string">&quot;&amp;username=&quot;</span>&nbsp;&#43;&nbsp;userId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;postData.Append(<span class="cs__string">&quot;&amp;passphrase=&quot;</span>&nbsp;&#43;&nbsp;pwd);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;postData.Append(<span class="cs__string">&quot;&amp;phone=&quot;</span>&nbsp;&#43;&nbsp;sendTo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;postData.Append(<span class="cs__string">&quot;&amp;message=&quot;</span>&nbsp;&#43;&nbsp;smsText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;data&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Text.ASCIIEncoding.aspx" target="_blank" title="Auto generated link to System.Text.ASCIIEncoding">System.Text.ASCIIEncoding</a>().GetBytes(postData.ToString());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Prepare&nbsp;web&nbsp;request</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request&nbsp;=&nbsp;(HttpWebRequest)WebRequest.Create(postURL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Method&nbsp;=&nbsp;<span class="cs__string">&quot;POST&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.ContentType&nbsp;=&nbsp;<span class="cs__string">&quot;application/x-www-form-urlencoded&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.ContentLength&nbsp;=&nbsp;data.Length;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Write&nbsp;data&nbsp;to&nbsp;stream</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(Stream&nbsp;newStream&nbsp;=&nbsp;request.GetRequestStream())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newStream.Write(data,&nbsp;<span class="cs__number">0</span>,&nbsp;data.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Send&nbsp;the&nbsp;request&nbsp;and&nbsp;get&nbsp;a&nbsp;response</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>(HttpWebResponse&nbsp;&nbsp;response&nbsp;=&nbsp;(HttpWebResponse)request.GetResponse())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Read&nbsp;the&nbsp;response</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(StreamReader&nbsp;srResponse&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamReader(response.GetResponseStream()))&nbsp;

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;responseMessage&nbsp;=&nbsp;srResponse.ReadToEnd();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Logic&nbsp;to&nbsp;interpret&nbsp;response&nbsp;from&nbsp;your&nbsp;gateway&nbsp;goes&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(String.Format(<span class="cs__string">&quot;Response&nbsp;from&nbsp;gateway:&nbsp;{0}&quot;</span>,&nbsp;responseMessage));&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;objException)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(objException.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>SendSMS.zip&nbsp;- Sample web site built in Visual Studio 2010.</em> </li></ul>
<h1>More Information</h1>
<p><em>How to: Send Data Using the WebRequest Class<br>
<a href="http://msdn.microsoft.com/en-us/library/debx8sh9.aspx">http://msdn.microsoft.com/en-us/library/debx8sh9.aspx</a></em></p>
