# Send Email with Exchange Web services Managed API
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Exchange
## Topics
- Send Email
## Updated
- 01/26/2012
## Description

<p>This Sample creates a simple send email dialog that is used to demonstrate how to use the Exchange Web services Managed API.&nbsp;</p>
<p>This sample has&nbsp;one important section <span>of</span> code on the event handler for send message button.&nbsp; This code creates a new instance of the ExchangeService and uses the autodiscover api to discover your service endpoint.&nbsp; It then constructs
 an email message and applies the values in each of the UI fields to the message.&nbsp; Finally it provides a confirmation the message was sent and clears the dialog.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">privatevoid&nbsp;sendButton_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExchangeService&nbsp;service&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ExchangeService();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;service.AutodiscoverUrl(<span class="cs__string">&quot;youremailaddress@yourdomain.com&quot;</span>);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EmailMessage&nbsp;message&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EmailMessage(service);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.Subject&nbsp;=&nbsp;subjectTextbox.Text;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.Body&nbsp;=&nbsp;bodyTextbox.Text;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.ToRecipients.Add(recipientTextbox.Text);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.Save();&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.SendAndSaveCopy();&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.MessageBox.Show.aspx" target="_blank" title="Auto generated link to System.Windows.MessageBox.Show">System.Windows.MessageBox.Show</a>(<span class="cs__string">&quot;Message&nbsp;sent!&quot;</span>);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;recipientTextbox.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;subjectTextbox.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bodyTextbox.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">This simple sample shows you how to get started using the Exchange web services.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">The Microsoft Exchange Web Services (EWS) Managed API 1.1 provides a managed interface for developing client applications that use Exchange Web Services. The EWS Managed API simplifies the implementation of applications that communicate
 with Microsoft Exchange Server 2007 Service Pack 1 (SP1) and later versions of Microsoft Exchange. Built on the Exchange Web Services SOAP protocol and Autodiscover, the EWS Managed API provides a .NET interface to EWS that is easy to learn, use, and maintain.</div>
<div class="endscriptcode">For more information about working with the Exchange Web Services API you can go to the MSDN Library and read more.</div>
<div class="endscriptcode"><a href="http://msdn.microsoft.com/en-us/library/dd633709.aspx">http://msdn.microsoft.com/en-us/library/dd633709.aspx</a></div>
<div class="endscriptcode">You can download the Exchange Web Services API from the Microsoft Download Center.</div>
<div class="endscriptcode"><a href="http://www.microsoft.com/download/en/details.aspx?id=13480">http://www.microsoft.com/download/en/details.aspx?id=13480</a></div>
<div class="endscriptcode"></div>
