# Upload files using a WCF REST Service
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WCF
- REST
- WPF
- SQL Server Compact
## Topics
- Upload
- Download
- Files
## Updated
- 01/21/2012
## Description

<h1>Upload files using a WCF REST&nbsp;Service</h1>
<div>A&nbsp;WCF REST Service that allows to upload (and&nbsp;download)&nbsp;images to&nbsp;(and from)&nbsp;a remote server. Images are stored in a SQL Server Compact 4.0 database. The service exposes also a method to obtain the list of all images, along with
 their name and description, and a method to delete an image.</div>
<p>&nbsp;</p>
<div>
<h1>Building the Sample</h1>
<div>The code you can download from this page contains the WCF REST&nbsp;Service, named&nbsp;<strong>PhotoService</strong>, and a WPF Application,
<strong>PhotoServiceClient</strong>,&nbsp;that shows how to call&nbsp;its methods. Inside the ZIP file you'll find a single&nbsp;Solution&nbsp;that includes&nbsp;both the service and the client.</div>
<div>To&nbsp;debug these projects, first right click on&nbsp;<strong>PhotoService</strong> in the Solution Explorer, then select the
<strong>Debug | Start new instance</strong> command from the context menu. Repeat this action for the
<strong>PhotoServiceClient</strong>. In this way, you can execute both the service and the client within the same instance of Visual Studio and, of course, you can insert breakpoints in any point of the code.</div>
<div>&nbsp;</div>
<div>Ensure that, in the project properties of <strong>PhotoService</strong>, under the
<strong>Web </strong>tag, the <em>Specific port</em> radio button is checked. You might modify the
<em>app.config</em> file in the <strong>PhotoServiceClient</strong> project to set the correct URL for the service in the
<strong>ServiceUrl </strong>tag.</div>
<div>&nbsp;</div>
<div>
<h1>Description</h1>
<div>The WCF REST&nbsp;Service has been created using the <a href="http://visualstudiogallery.msdn.microsoft.com/fbc7e5c1-a0d2-41bd-9d7b-e54c845394cd" target="_blank">
WCF REST Service Template 40 (CS)</a>.&nbsp;It simplifies a lot the process of creating the service files and making the right configuration in
<em>web.config</em>. Working with this file, in fact, can be quite difficult, but this template&nbsp;creates a basic configuration that is perfect to start with.</div>
<div>&nbsp;</div>
<div>One of the most important settings that must be adjust in the <em>web.config</em> file regards the
<strong>standardEnpoint </strong>tag. To make the service accept large files upload, you must add a
<strong>maxReceivedMessageSize </strong>attribute, that specifies the maximun length, in bytes, of a message that can be sent by a client. In the
<strong>PhotoService </strong>service, this tag is set to 4 MB.</div>
<div>&nbsp;</div>
<div>
<div class="endscriptcode">Once uploaded, the files are saved in a SQL Server Compact 4.0, that is accessed using ADO .NET Entity Framework via an Entity Data Model.</div>
</div>
<div>&nbsp;</div>
<div>After you have started the debug of the service, you can see all the methods that are exposed, along with input parameters and example of return messages, visiting the page
<a href="http://localhost:2557/photos/help">http://localhost:&lt;port_number&gt;/photos/help</a>.</div>
<div>&nbsp;</div>
<div>Using the service is straightforward. You can use make a standard HttpWebRequest to invoke its methods. For example, see the following code, taken from the
<strong>PhotoServiceClient</strong>, to upload the specified image to the server:</div>
</div>
</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(requestUrl), HttpWebRequest)
request.Method = &quot;POST&quot;
request.ContentType = &quot;text/plain&quot;

Dim fileToSend As Byte() = File.ReadAllBytes(txtFileName.Text)
' txtFileName contains the name of the file to upload.
request.ContentLength = fileToSend.Length

Using requestStream As Stream = request.GetRequestStream()
	' Send the file as body request.
	requestStream.Write(fileToSend, 0, fileToSend.Length)
	requestStream.Close()
End Using

Using response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
	Console.WriteLine(&quot;HTTP/{0} {1} {2}&quot;, response.ProtocolVersion, CInt(response.StatusCode), response.StatusDescription)
End Using</pre>
<pre class="hidden">HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
request.Method = &quot;POST&quot;;
request.ContentType = &quot;text/plain&quot;;

byte[] fileToSend = File.ReadAllBytes(txtFileName.Text);  // txtFileName contains the name of the file to upload.
request.ContentLength = fileToSend.Length;

using (Stream requestStream = request.GetRequestStream())
{
    // Send the file as body request.
    requestStream.Write(fileToSend, 0, fileToSend.Length);
    requestStream.Close();
}

using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    Console.WriteLine(&quot;HTTP/{0} {1} {2}&quot;, response.ProtocolVersion, (int)response.StatusCode, response.StatusDescription);</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Dim</span>&nbsp;request&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;HttpWebRequest&nbsp;=&nbsp;<span class="visualBasic__keyword">DirectCast</span>(HttpWebRequest.Create(requestUrl),&nbsp;HttpWebRequest)&nbsp;
request.Method&nbsp;=&nbsp;<span class="visualBasic__string">&quot;POST&quot;</span>&nbsp;
request.ContentType&nbsp;=&nbsp;<span class="visualBasic__string">&quot;text/plain&quot;</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">Dim</span>&nbsp;fileToSend&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Byte</span>()&nbsp;=&nbsp;File.ReadAllBytes(txtFileName.Text)&nbsp;
<span class="visualBasic__com">'&nbsp;txtFileName&nbsp;contains&nbsp;the&nbsp;name&nbsp;of&nbsp;the&nbsp;file&nbsp;to&nbsp;upload.</span>&nbsp;
request.ContentLength&nbsp;=&nbsp;fileToSend.Length&nbsp;
&nbsp;
<span class="visualBasic__keyword">Using</span>&nbsp;requestStream&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Stream&nbsp;=&nbsp;request.GetRequestStream()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Send&nbsp;the&nbsp;file&nbsp;as&nbsp;body&nbsp;request.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;requestStream.Write(fileToSend,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;fileToSend.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;requestStream.Close()&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">Using</span>&nbsp;response&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;HttpWebResponse&nbsp;=&nbsp;<span class="visualBasic__keyword">DirectCast</span>(request.GetResponse(),&nbsp;HttpWebResponse)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;HTTP/{0}&nbsp;{1}&nbsp;{2}&quot;</span>,&nbsp;response.ProtocolVersion,&nbsp;<span class="visualBasic__keyword">CInt</span>(response.StatusCode),&nbsp;response.StatusDescription)&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span></pre>
</div>
</div>
</div>
</div>
<div></div>
<div>And this is the code to download the&nbsp;image with ID 123 and save it in a BitmapImage object:</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">' Create the REST request.
Dim url As String = ConfigurationManager.AppSettings(&quot;serviceUrl&quot;)
Dim requestUrl As String = String.Format(&quot;{0}/GetPhoto/123&quot;)
Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(requestUrl), HttpWebRequest)

' Get response  
Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
	Using stream As Stream = response.GetResponseStream()
		Dim buffer As Byte() = New Byte(32767) {}
		Dim ms As New MemoryStream()
		Dim bytesRead As Integer, totalBytesRead As Integer = 0
		Do
			bytesRead = stream.Read(buffer, 0, buffer.Length)
			totalBytesRead &#43;= bytesRead

			ms.Write(buffer, 0, bytesRead)
		Loop While bytesRead &gt; 0

		ms.Position = 0
		Dim bmp As New BitmapImage()
		bmp.BeginInit()
		bmp.StreamSource = ms
		bmp.EndInit()

		imgPhoto.Source = bmp
	End Using
End Using</pre>
<pre class="hidden">// Create the REST request.
string url = ConfigurationManager.AppSettings[&quot;serviceUrl&quot;];
string requestUrl = string.Format(&quot;{0}/GetPhoto/123&quot;);
HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);

// Get response  
using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
{
    using (Stream stream = response.GetResponseStream())
    {
        byte[] buffer = new byte[32768];
        MemoryStream ms = new MemoryStream();
        int bytesRead, totalBytesRead = 0;
        do
        {
            bytesRead = stream.Read(buffer, 0, buffer.Length);
            totalBytesRead &#43;= bytesRead;

            ms.Write(buffer, 0, bytesRead);
        } while (bytesRead &gt; 0);

        ms.Position = 0;
        BitmapImage bmp = new BitmapImage();
        bmp.BeginInit();
        bmp.StreamSource = ms;
        bmp.EndInit();

        imgPhoto.Source = bmp;
    }
}</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__com">'&nbsp;Create&nbsp;the&nbsp;REST&nbsp;request.</span>&nbsp;
<span class="visualBasic__keyword">Dim</span>&nbsp;url&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;ConfigurationManager.AppSettings(<span class="visualBasic__string">&quot;serviceUrl&quot;</span>)&nbsp;
<span class="visualBasic__keyword">Dim</span>&nbsp;requestUrl&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;{0}/GetPhoto/123&quot;</span>)&nbsp;
<span class="visualBasic__keyword">Dim</span>&nbsp;request&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;HttpWebRequest&nbsp;=&nbsp;<span class="visualBasic__keyword">DirectCast</span>(HttpWebRequest.Create(requestUrl),&nbsp;HttpWebRequest)&nbsp;
&nbsp;
<span class="visualBasic__com">'&nbsp;Get&nbsp;response&nbsp;&nbsp;</span>&nbsp;
<span class="visualBasic__keyword">Using</span>&nbsp;response&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;HttpWebResponse&nbsp;=&nbsp;<span class="visualBasic__keyword">TryCast</span>(request.GetResponse(),&nbsp;HttpWebResponse)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;stream&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Stream&nbsp;=&nbsp;response.GetResponseStream()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;buffer&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Byte</span>()&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Byte</span>(<span class="visualBasic__number">32767</span>)&nbsp;{}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ms&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;MemoryStream()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;bytesRead&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;totalBytesRead&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Do</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bytesRead&nbsp;=&nbsp;stream.Read(buffer,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;buffer.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;totalBytesRead&nbsp;&#43;=&nbsp;bytesRead&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Write(buffer,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;bytesRead)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Loop</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;bytesRead&nbsp;&gt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Position&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;bmp&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;BitmapImage()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmp.BeginInit()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmp.StreamSource&nbsp;=&nbsp;ms&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmp.EndInit()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgPhoto.Source&nbsp;=&nbsp;bmp&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">As the service works with standard REST calls, if you prefer you can also use a third-party library to communicate with it. For example, you can refert to RestSharp, that is available at
<a href="http://restsharp.org">http://restsharp.org</a>.</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">Finally, notice that this example allows to upload, manage and download JPEG, GIF, BMP and PNG images, but the code can be easily adapted to support any file type.</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div></div>
<h1>More Information</h1>
<ul>
<li><a href="http://msdn.microsoft.com/en-us/magazine/dd315413.aspx" target="_blank">An Introduction To RESTful Services With WCF</a>
</li><li><a href="http://visualstudiogallery.msdn.microsoft.com/fbc7e5c1-a0d2-41bd-9d7b-e54c845394cd" target="_blank">WCF REST Service Template 40 (CS)</a>
</li><li><a href="http://restsharp.org/" target="_blank">RestSharp</a> </li></ul>
<div></div>
<div></div>
