# Shared Access Signature authentication with Service Bus
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Service Bus
- Windows Azure Service Bus
## Topics
- Service Bus
- Windows Azure Service Bus
## Updated
- 05/29/2013
## Description

<h1>Shared Access Signature (SAS) authentication with Service Bus</h1>
<div><span style="line-height:107%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-size:medium"><span style="line-height:107%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Shared Access Signature (SAS) authentication allows applications to authenticate to Windows Azure Service
 Bus using an access key configured on the namespace or the entity with specific rights associated with it. This key can then be used to generate a Shared Access Signature token that clients can use to authenticate to Service Bus.</span></span></div>
<div><span style="line-height:107%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-size:medium">Authorization rules for SAS can be configured on a Service Bus namespace or a queue, topic or notification hub. This authorization rule consists of a KeyName, a Primary
 Key, a Secondary Key and associated access rights.</span></div>
<div><span style="line-height:107%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-size:medium">For more details on using SAS authentication, please see:</span></div>
<ul>
<li><span style="line-height:107%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-size:medium"><a href="http://msdn.microsoft.com/en-us/library/dn170477.aspx">Shared Access Signature Authentication with Service Bus</a></span>
</li><li><span style="line-height:107%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-size:medium"><a href="http://msdn.microsoft.com/en-us/library/dn205161.aspx" target="_blank">How to use Shared Access Signature Authentication with Service Bus</a></span>
</li></ul>
<div>&nbsp;</div>
<h2>Prerequisites for using this sample:</h2>
<div>
<li style="padding-left:30px"><span style="font-size:small">A valid subscription to Windows Azure is required.</span>
</li><li style="padding-left:30px"><span style="font-size:small"><span style="font-size:small">Operations on the Service Bus namespace require certificate authentication. You will need to upload a management certificate for your Windows Azure subscription. You can
 upload a management certificate&nbsp;by selecting Settings in the left panel of the Windows Azure portal.&nbsp;(For details on Windows Azure Management Certificates, please see
<a href="http://msdn.microsoft.com/en-us/library/windowsazure/gg981929.aspx">http://msdn.microsoft.com/en-us/library/windowsazure/gg981929.aspx</a>.)</span></span>
</li></div>
<div>&nbsp;</div>
<h2><span>Building this sample:</span></h2>
<ul>
<li><span style="font-size:small">This sample requires Windows Azure SDK for .NET version 2.0 or later.
</span></li><li><span style="font-size:small">Install&nbsp;the <strong><em>Json.NET </em></strong>NuGet package through Visual Studio.</span>
</li><li><span style="font-size:small">Build the sample.</span> </li></ul>
<p><span style="font-size:small"></span></p>
<div><span style="font-size:20px; font-weight:bold">Details</span></div>
<div><span style="font-size:small">This sample&nbsp;demonstrates the use of Shared Access Signature authentication and authorization with Service Bus. It includes:</span></div>
<ul>
<li><span style="font-size:small">Operations on the Service Bus namespace&nbsp;to create, read and delete shared access authorization rules.
</span></li><li><span style="font-size:small">Operations on the Service Bus namespace to roll the keys for a shared access authorization rule.
</span></li><li><span style="font-size:small">Operations on&nbsp;a Service&nbsp;Bus entity to create, read and delete shared access authorization rules.
</span></li><li><span style="font-size:small">Runtime operations to send to &amp; receive from a Service Bus queue using a SharedAccessSignatureTokenProvider.
</span></li><li><span style="font-size:small">Runtime operations to send to &amp; receive from a Service Bus queue using a SharedAccessSignature token in a HTTP header.
</span></li></ul>
<div>&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Code&nbsp;snippet&nbsp;for&nbsp;generating&nbsp;a&nbsp;SAS&nbsp;token&nbsp;for&nbsp;authorization&nbsp;with&nbsp;Service&nbsp;Bus</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;TimeSpan&nbsp;sinceEpoch&nbsp;=&nbsp;DateTime.UtcNow&nbsp;-&nbsp;<span class="cs__keyword">new</span>&nbsp;DateTime(<span class="cs__number">1970</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;expiry&nbsp;=&nbsp;Convert.ToString((<span class="cs__keyword">int</span>)sinceEpoch.TotalSeconds&nbsp;&#43;&nbsp;<span class="cs__number">3600</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;stringToSign&nbsp;=&nbsp;HttpUtility.UrlEncode(resourceUri)&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&quot;</span>&nbsp;&#43;&nbsp;expiry;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HMACSHA256&nbsp;hmac&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HMACSHA256(Encoding.UTF8.GetBytes(key));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;signature&nbsp;=&nbsp;Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;sasToken&nbsp;=&nbsp;String.Format(CultureInfo.InvariantCulture,&nbsp;<span class="cs__string">&quot;SharedAccessSignature&nbsp;sr={0}&amp;sig={1}&amp;se={2}&amp;skn={3}&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpUtility.UrlEncode(resourceUri),&nbsp;HttpUtility.UrlEncode(signature),&nbsp;expiry,&nbsp;keyName);&nbsp;
</pre>
</div>
</div>
</div>
<h1><em>&nbsp;</em></h1>
