# Sending Emails with HTML Body in C#
## Requires
- Visual Studio 2015
## License
- MS-LPL
## Technologies
- C#
- SMTP
- Email Processing in C#
- Spire.Email for .NET
## Topics
- Sending Email Using SMTP
- Email C#
- Email with Html Body
## Updated
- 07/16/2017
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This sample presents how to send an email with HTML body using Spire.Email in C#. Spire.Email<span>&nbsp;is a professional .NET Email library specially designed for developers to create, read and manipulate emails from any .NET
 (C#, VB.NET, ASP.NET) platform with fast and high quality performance.&nbsp;</span></span></p>
<p><span style="font-size:small"><strong>Tools we need:</strong></span></p>
<p><span style="font-size:small">- Spire.Email(This dll is available in the package attached.)</span><br>
<span style="font-size:small">- Visual Studio</span></p>
<p><span style="font-size:small; font-weight:bold">Code Snippet:</span></p>
<p><span style="font-size:small; color:#333333; background-color:#ff9900">Step 1: Create an instance of MailMessage class and specify From, To.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">MailAddress addressFrom = new MailAddress(&quot;sender@outlook.com&quot;, &quot;Sender Name&quot;);
MailAddress addressTo = new MailAddress(&quot;recipient@outlook.com&quot;);
MailMessage message = new MailMessage(addressFrom, addressTo);

</pre>
<div class="preview">
<pre class="csharp">MailAddress&nbsp;addressFrom&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailAddress(<span class="cs__string">&quot;sender@outlook.com&quot;</span>,&nbsp;<span class="cs__string">&quot;Sender&nbsp;Name&quot;</span>);&nbsp;
MailAddress&nbsp;addressTo&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailAddress(<span class="cs__string">&quot;recipient@outlook.com&quot;</span>);&nbsp;
MailMessage&nbsp;message&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailMessage(addressFrom,&nbsp;addressTo);&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<ul>
</ul>
<p><span style="font-size:small; background-color:#ff9900">Step 2: Specify data, subject and BodyHtml content.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">message.Date = DateTime.Now;
message.Subject = &quot;Sending Email with HTML Body&quot;;
string htmlString = @&quot;&lt;html&gt;
                      &lt;body&gt;
                      &lt;p&gt;Dear xxxx,&lt;/p&gt;
                      &lt;p&gt;It has been long since we...&lt;/p&gt;
                      &lt;p&gt;Sincerely,&lt;br&gt;Scott&lt;/br&gt;&lt;/p&gt;
                      &lt;/body&gt;
                      &lt;/html&gt;
                     &quot;;   
message.BodyHtml = htmlString;
</pre>
<div class="preview">
<pre class="csharp">message.Date&nbsp;=&nbsp;DateTime.Now;&nbsp;
message.Subject&nbsp;=&nbsp;<span class="cs__string">&quot;Sending&nbsp;Email&nbsp;with&nbsp;HTML&nbsp;Body&quot;</span>;&nbsp;
<span class="cs__keyword">string</span>&nbsp;htmlString&nbsp;=&nbsp;@&quot;&lt;html&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;Dear&nbsp;xxxx,&lt;/p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;It&nbsp;has&nbsp;been&nbsp;<span class="cs__keyword">long</span>&nbsp;since&nbsp;we...&lt;/p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;Sincerely,&lt;br&gt;Scott&lt;/br&gt;&lt;/p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/html&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;;&nbsp;&nbsp;&nbsp;&nbsp;
message.BodyHtml&nbsp;=&nbsp;htmlString;&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><span style="font-size:small; background-color:#ff9900">Step 3: Create a SmtpClient instance with host, port, username and password, and send the email using SendOne medthod.</span></p>
<p><span style="font-size:small; background-color:#ff9900">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">SmtpClient client = new SmtpClient();
client.Host = &quot;smtp.outlook.com&quot;;
client.Port = 587;
client.Username = addressFrom.Address;
client.Password = &quot;password&quot;;
client.ConnectionProtocols = ConnectionProtocols.Ssl;
client.SendOne(message);
Console.WriteLine(&quot;Sent Successfully!&quot;);
</pre>
<div class="preview">
<pre class="js">SmtpClient&nbsp;client&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SmtpClient();&nbsp;
client.Host&nbsp;=&nbsp;<span class="js__string">&quot;smtp.outlook.com&quot;</span>;&nbsp;
client.Port&nbsp;=&nbsp;<span class="js__num">587</span>;&nbsp;
client.Username&nbsp;=&nbsp;addressFrom.Address;&nbsp;
client.Password&nbsp;=&nbsp;<span class="js__string">&quot;password&quot;</span>;&nbsp;
client.ConnectionProtocols&nbsp;=&nbsp;ConnectionProtocols.Ssl;&nbsp;
client.SendOne(message);&nbsp;
Console.WriteLine(<span class="js__string">&quot;Sent&nbsp;Successfully!&quot;</span>);&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1><span style="color:#000000"><strong><span style="font-size:small">More Information</span></strong></span></h1>
<p><span style="font-size:small">Spire.Email for .NET is a totally independent .NET Email library which doesn't require Microsoft Outlook installed on system.&nbsp;</span><span style="font-size:small">When creating and sending emails, Spire.Email for .NET enables
 developers to create, send and receive emails using SMTP, POP3 MIME and IMAP protocols. Developers could use Spire.Email to add, extract and remove the attachments from the email message. Developers can also manage the folders to arrange the emails, such as
 create new folder, rename folder, get folder information and delete folder.</span></p>
<p><span style="font-size:small"><strong>Related Links:</strong></span></p>
<p><span style="font-size:small"><strong>&nbsp;</strong>Website:&nbsp;<a href="http://www.e-iceblue.com/">http://www.e-iceblue.com/</a></span></p>
<p><span style="font-size:small">Download:&nbsp;<a href="https://www.e-iceblue.com/Download/email-for-net.html">Download Spire.Email</a></span></p>
<p><em><br>
</em></p>
