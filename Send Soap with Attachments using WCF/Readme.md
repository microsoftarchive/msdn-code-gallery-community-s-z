# Send Soap with Attachments using WCF
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- WCF
## Topics
- WCF
- WCF Soap With Attachment
## Updated
- 11/09/2012
## Description

<h1>Introduction</h1>
<p><em>WCF doesnt have out of box features to send SOAP message with Attachments. The Austrian interoperablity council has provided a solution to add a custom message encoder in WCF to send SWA. However the solution can only be used to send PDF attachments
 with a SOAP Payload. I have added a configurable parameter to set the attachment type.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>You probably need VS 2010 for building this project and to test this solution, you need a service which accepts SOAP Payload with attachments.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Soap With attachments is a very old technique and is still used in lot of legacy systems. More new technologies has emerged like MTOM which is widely used within the WCF arena. That said, there is no out of the box support within WCF to send a SOAP message
 with attachments.</p>
<p>An Austrian Microsoft Interoperability Council had a challenge to consume a webservice which expects to send a SOAP message with attachments.</p>
<p>http://blogs.msdn.com/b/mszcool/archive/2009/10/19/windows-communication-foundation-and-soap-with-attachments-message-encoder-built-in-interop-lab-with-svc-sozialversicherungs-chipkarten-betriebs-und-errichtungsgesellschaft-m-b-h.aspx</p>
<p>They have developed a custom encoder which can add the zip message as an attachment in the outgoinh SOAP envelope.</p>
<p>However I had a different challenge in consuming a webservice which requires me to send a soap payload which has an XML attachment. So I had to modify the custom encoder in such a way that I can attach a XML document. I had lot more challenges. The webservice
 which I had to consume was written in Java and the field appears as xsd:hexBinary in the WSDL file. So there is no way I can add a service reference / web reference to my project. I did tried that, but when I tried to send the message, the server was rejecting
 the message. The reason for this is Visual studio when generating the client code for the service, puts the type as xsd:base64binary.</p>
<p>So, I had to code the datacontracts, messagecontracts and servicecontracts based on the WSDL. Then I plugged in the code to use the encoder to attach the XML message. There is no direct way to do this from BizTalk. I wrote this entire logic in a WCF Service
 which acts as a client to the Target web service and acts as a Server for BizTalk. BizTalk application will consume this WCF service and send the SOAP message with attachment.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public SwaEncoder(MessageEncoder innerEncoder, SwaEncoderFactory factory, string attachmentContentType)
        {
            //
            // Initialize general fields
            //
            _ContentType = &quot;multipart/related&quot;;
            _MediaType = _ContentType;

            //
            // Create owned objects
            //
            _Factory = factory;
            _InnerEncoder = innerEncoder;
            _MimeParser = new MimeParser();

            //
            // Create object for the mime content message
            // 
            _SoapMimeContent = new MimePart()
            {
                ContentType = &quot;text/xml&quot;,
                ContentId = &quot;&lt;EFD659EE6BD5F31EA7BC0D59403AF049&gt;&quot;,   // TODO: make content id dynamic or configurable?
                CharSet = &quot;UTF-8&quot;,                                  // TODO: make charset configurable?
                TransferEncoding = &quot;binary&quot;                         // TODO: make transfer-encoding configurable?
            };
            _AttachmentMimeContent = new MimePart()
            {
                ContentType = attachmentContentType,
                ContentId = &quot;&lt;UZE_26123_&gt;&quot;,                         // TODO: AttachmentMimeContent.ContentId configurable/dynamic?
                TransferEncoding = &quot;binary&quot;                         // TODO: AttachmentMimeContent.TransferEncoding dynamic/configurable?
            };
            _MyContent = new MimeContent()
            {
                Boundary = &quot;------=_Part_0_21714745.1249640163820&quot;  // TODO: MimeContent.Boundary configurable/dynamic?
            };
            _MyContent.Parts.Add(_SoapMimeContent);
            _MyContent.Parts.Add(_AttachmentMimeContent);
            _MyContent.SetAsStartPart(_SoapMimeContent);
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;SwaEncoder(MessageEncoder&nbsp;innerEncoder,&nbsp;SwaEncoderFactory&nbsp;factory,&nbsp;<span class="cs__keyword">string</span>&nbsp;attachmentContentType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Initialize&nbsp;general&nbsp;fields</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ContentType&nbsp;=&nbsp;<span class="cs__string">&quot;multipart/related&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_MediaType&nbsp;=&nbsp;_ContentType;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;owned&nbsp;objects</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_Factory&nbsp;=&nbsp;factory;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_InnerEncoder&nbsp;=&nbsp;innerEncoder;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_MimeParser&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MimeParser();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;object&nbsp;for&nbsp;the&nbsp;mime&nbsp;content&nbsp;message</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_SoapMimeContent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MimePart()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContentType&nbsp;=&nbsp;<span class="cs__string">&quot;text/xml&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContentId&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;EFD659EE6BD5F31EA7BC0D59403AF049&gt;&quot;</span>,&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;TODO:&nbsp;make&nbsp;content&nbsp;id&nbsp;dynamic&nbsp;or&nbsp;configurable?</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CharSet&nbsp;=&nbsp;<span class="cs__string">&quot;UTF-8&quot;</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;TODO:&nbsp;make&nbsp;charset&nbsp;configurable?</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TransferEncoding&nbsp;=&nbsp;<span class="cs__string">&quot;binary&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;TODO:&nbsp;make&nbsp;transfer-encoding&nbsp;configurable?</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_AttachmentMimeContent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MimePart()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContentType&nbsp;=&nbsp;attachmentContentType,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContentId&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;UZE_26123_&gt;&quot;</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;TODO:&nbsp;AttachmentMimeContent.ContentId&nbsp;configurable/dynamic?</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TransferEncoding&nbsp;=&nbsp;<span class="cs__string">&quot;binary&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;TODO:&nbsp;AttachmentMimeContent.TransferEncoding&nbsp;dynamic/configurable?</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_MyContent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MimeContent()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Boundary&nbsp;=&nbsp;<span class="cs__string">&quot;------=_Part_0_21714745.1249640163820&quot;</span>&nbsp;&nbsp;<span class="cs__com">//&nbsp;TODO:&nbsp;MimeContent.Boundary&nbsp;configurable/dynamic?</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_MyContent.Parts.Add(_SoapMimeContent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_MyContent.Parts.Add(_AttachmentMimeContent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_MyContent.SetAsStartPart(_SoapMimeContent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span>WcfHelpers.SoapAttachments.zip</span> </li></ul>
<h1>More Information</h1>
<p><em>For more information on this solution, please refer the below blog entry.</em></p>
<p>&nbsp;</p>
<p><em><a href="http://shankarsbiztalk.wordpress.com/2012/10/16/sending-soap-with-attachments-swa-using-biztalk/">http://shankarsbiztalk.wordpress.com/2012/10/16/sending-soap-with-attachments-swa-using-biztalk/</a><br>
</em></p>
