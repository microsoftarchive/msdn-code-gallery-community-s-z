# WCF REST Message Inspector
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WCF
## Topics
- WCF
- WCF Extensibility
## Updated
- 04/12/2011
## Description

<p><em>This sample was provided as part of a blog series on WCF extensibility. The entry for this sample can be found at
<a href="http://blogs.msdn.com/b/carlosfigueira/archive/2011/04/19/wcf-extensibility-message-inspectors.aspx">
http://blogs.msdn.com/b/carlosfigueira/archive/2011/04/19/wcf-extensibility-message-inspectors.aspx</a>.</em></p>
<p>As I mentioned before, all WCF messages are XML-based &ndash; the message envelope is an XML Infoset represented in memory, with the (optional) header and the body as child XML elements of the envelope. A message can be directly written to a XML writer,
 and created based on a XML reader. This works quite well in the XML (including SOAP and POX) world. However, with the introduction of the WCF HTTP programming model in .NET Framework 3.5, WCF started accepting out-of-the-box more types of content (most notably
 JSON and binary content). But since the whole WCF stack is XML-based, sometimes the behavior of the messages can be counter-intuitive.</p>
<p>Take, for example, a simple message logger, which is typically implemented using the message inspectors described in this post. Let&rsquo;s say that we have a contact manager, which is implemented as a bunch of operations used primarily by web pages (thus
 using JSON as the primary message format):</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:885cd1a6-cb87-4cbd-9c37-176c6da76ff2" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[DataContract]
public class Contact
{
    [DataMember]
    public string Id { get; set; }
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public string Email { get; set; }
    [DataMember]
    public string[] Telephones { get; set; }
}
 
[ServiceContract]
public interface IContactManager
{
    [WebInvoke(
        Method = &quot;POST&quot;,
        UriTemplate = &quot;/Contacts&quot;,
        ResponseFormat = WebMessageFormat.Json)]
    string AddContact(Contact contact);
 
    [WebInvoke(
        Method = &quot;PUT&quot;,
        UriTemplate = &quot;/Contacts/{id}&quot;,
        ResponseFormat = WebMessageFormat.Json)]
    void UpdateContact(string id, Contact contact);
 
    [WebInvoke(
        Method = &quot;DELETE&quot;,
        UriTemplate = &quot;/Contacts/{id}&quot;,
        ResponseFormat = WebMessageFormat.Json)]
    void DeleteContact(string id);
    
    [WebGet(UriTemplate = &quot;/Contacts&quot;, ResponseFormat = WebMessageFormat.Json)]
    List&lt;Contact&gt; GetAllContacts();
    
    [WebGet(UriTemplate = &quot;/Contacts/{id}&quot;, ResponseFormat = WebMessageFormat.Json)]
    Contact GetContact(string id);
 
    [WebGet(UriTemplate = &quot;/ContactsAsText&quot;)]
    Stream GetContactsAsText();
}</pre>
<div class="preview">
<pre class="csharp">[DataContract]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Contact&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataMember]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataMember]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataMember]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Email&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataMember]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;Telephones&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}&nbsp;
&nbsp;&nbsp;
[ServiceContract]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IContactManager&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebInvoke(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Method&nbsp;=&nbsp;<span class="cs__string">&quot;POST&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UriTemplate&nbsp;=&nbsp;<span class="cs__string">&quot;/Contacts&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ResponseFormat&nbsp;=&nbsp;WebMessageFormat.Json)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;AddContact(Contact&nbsp;contact);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebInvoke(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Method&nbsp;=&nbsp;<span class="cs__string">&quot;PUT&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UriTemplate&nbsp;=&nbsp;<span class="cs__string">&quot;/Contacts/{id}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ResponseFormat&nbsp;=&nbsp;WebMessageFormat.Json)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;UpdateContact(<span class="cs__keyword">string</span>&nbsp;id,&nbsp;Contact&nbsp;contact);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebInvoke(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Method&nbsp;=&nbsp;<span class="cs__string">&quot;DELETE&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UriTemplate&nbsp;=&nbsp;<span class="cs__string">&quot;/Contacts/{id}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ResponseFormat&nbsp;=&nbsp;WebMessageFormat.Json)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteContact(<span class="cs__keyword">string</span>&nbsp;id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebGet(UriTemplate&nbsp;=&nbsp;<span class="cs__string">&quot;/Contacts&quot;</span>,&nbsp;ResponseFormat&nbsp;=&nbsp;WebMessageFormat.Json)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;List&lt;Contact&gt;&nbsp;GetAllContacts();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebGet(UriTemplate&nbsp;=&nbsp;<span class="cs__string">&quot;/Contacts/{id}&quot;</span>,&nbsp;ResponseFormat&nbsp;=&nbsp;WebMessageFormat.Json)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Contact&nbsp;GetContact(<span class="cs__keyword">string</span>&nbsp;id);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebGet(UriTemplate&nbsp;=&nbsp;<span class="cs__string">&quot;/ContactsAsText&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Stream&nbsp;GetContactsAsText();&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>Now let&rsquo;s say we send the following request to the service:</p>
<blockquote>
<p><span style="font-family:Consolas; font-size:x-small">POST /Contacts HTTP/1.1 <br>
Content-Type: application/json <br>
Host: my.host.name.com <br>
Content-Length: 90 <br>
Expect: 100-continue</span></p>
<p><span style="font-family:Consolas; font-size:x-small">{&quot;Name&quot;:&quot;Jane Roe&quot;, &quot;Email&quot;:&quot;jane@roe.com&quot;, &quot;Telephones&quot;:[&quot;202-555-4444&quot;, &quot;202-555-8888&quot;]}</span></p>
</blockquote>
<p>Inside the message inspector, we have a simple implementation which prints the message content:</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:550d2b15-5dfd-46b8-b30f-4a58addb90c8" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
{
    if (!request.IsEmpty)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(&quot;Incoming message:&quot;);
        Console.WriteLine(request);
        Console.ResetColor();
    }
 
    return null;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;AfterReceiveRequest(<span class="cs__keyword">ref</span>&nbsp;Message&nbsp;request,&nbsp;IClientChannel&nbsp;channel,&nbsp;InstanceContext&nbsp;instanceContext)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!request.IsEmpty)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ForegroundColor&nbsp;=&nbsp;ConsoleColor.Green;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Incoming&nbsp;message:&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(request);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ResetColor();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">null</span>;&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div></div>
</div>
<p>Easy, right? However, we&rsquo;re in the Message world, and that means XML, so instead of seeing the nice JSON request which was sent to the server, what ends up being printed is the message below:</p>
<blockquote>
<p><span style="font-family:Consolas; font-size:x-small">&lt;root type=&quot;object&quot;&gt;
<br>
&nbsp; &lt;Name type=&quot;string&quot;&gt;Jane Roe&lt;/Name&gt; <br>
&nbsp; &lt;Email type=&quot;string&quot;&gt;jane@roe.com&lt;/Email&gt; <br>
&nbsp; &lt;Telephones type=&quot;array&quot;&gt; <br>
&nbsp;&nbsp;&nbsp; &lt;item type=&quot;string&quot;&gt;202-555-4444&lt;/item&gt; <br>
&nbsp;&nbsp;&nbsp; &lt;item type=&quot;string&quot;&gt;202-555-8888&lt;/item&gt; <br>
&nbsp; &lt;/Telephones&gt; <br>
&lt;/root&gt;</span></p>
</blockquote>
<p>This throws quite a few people off-balance. What is being printed out is actually equivalent to the incoming JSON, by following the
<a href="http://msdn.microsoft.com/en-us/library/bb924435.aspx">mapping between JSON and XML</a> used in WCF. But that doesn&rsquo;t help for all the scenarios where one needs to log incoming messages, or even change the JSON in the message. The same would
 happen if the message was a &ldquo;raw&rdquo; message, for operations in which the return type or the operation parameter was of type
<a href="http://msdn.microsoft.com/en-us/library/system.io.stream.aspx">Stream</a> &ndash; see more information on the WCF raw programming model for
<a href="/b/carlosfigueira/archive/2008/04/17/wcf-raw-programming-model-web.aspx">
returning</a> or <a href="/b/carlosfigueira/archive/2008/04/17/wcf-raw-programming-model-receiving-arbitrary-data.aspx">
receiving</a> raw data &ndash; what would be printed would be the XML mapping of raw data (the base64binary data wrapped around a &lt;Binary&gt; XML element).</p>
<p>This example will show then how to read such content in a way that can be easily manipulated (the example simply logs it to a file, but it can easily be modified to change the message on the fly as well). And before I go further, the usual disclaimer &ndash;
 this is a sample for illustrating the topic of this post, this is not production-ready code. I tested it for a few contracts and it worked, but I cannot guarantee that it will work for all scenarios (please let me know if you find a bug or something missing).
 Also, for simplicity sake it doesn&rsquo;t have a lot of error handling which a production-level code would. Also, the contact manager is all stored in memory, a &ldquo;real&rdquo; one would have a backing database or something more &ldquo;persistent&rdquo;.</p>
<p>First, for completeness sake, the service which implements the contract shown before, which is shown below. The implementation is simple (all in memory), with a lock around operations with the &ldquo;repository&rdquo;.</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:187df72b-0bad-48eb-9843-a62a8f2f26ca" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class ContactManagerService : IContactManager
{
    static List&lt;Contact&gt; AllContacts = new List&lt;Contact&gt;();
    static int currentId = 0;
    static object syncRoot = new object();
 
    public string AddContact(Contact contact)
    {
        int contactId = Interlocked.Increment(ref currentId);
        contact.Id = contactId.ToString(CultureInfo.InvariantCulture);
        lock (syncRoot)
        {
            AllContacts.Add(contact);
            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Created;
        }
 
        return contact.Id;
    }
 
    public void UpdateContact(string id, Contact contact)
    {
        contact.Id = id;
        lock (syncRoot)
        {
            int index = this.FetchContact(id);
            if (index &gt;= 0)
            {
                AllContacts[index] = contact;
            }
        }
    }
 
    public void DeleteContact(string id)
    {
        lock (syncRoot)
        {
            int index = this.FetchContact(id);
            if (index &gt;= 0)
            {
                AllContacts.RemoveAt(index);
            }
        }
    }
 
    public List&lt;Contact&gt; GetAllContacts()
    {
        List&lt;Contact&gt; result;
        lock (syncRoot)
        {
            result = AllContacts.ToList();
        }
 
        return result;
    }
 
    public Contact GetContact(string id)
    {
        Contact result;
        lock (syncRoot)
        {
            int index = this.FetchContact(id);
            result = index &lt; 0 ? null : AllContacts[index];
        }
 
        return result;
    }
 
    public Stream GetContactsAsText()
    {
        StringBuilder sb = new StringBuilder();
        WebOperationContext.Current.OutgoingResponse.ContentType = &quot;text/plain&quot;;
        lock (syncRoot)
        {
            foreach (var contact in AllContacts)
            {
                sb.AppendLine(&quot;Contact &quot; &#43; contact.Id &#43; &quot;:&quot;);
                sb.AppendLine(&quot;  Name: &quot; &#43; contact.Name);
                sb.AppendLine(&quot;  Email: &quot; &#43; contact.Email);
                sb.AppendLine(&quot;  Telephones:&quot;);
                foreach (var phone in contact.Telephones)
                {
                    sb.AppendLine(&quot;    &quot; &#43; phone);
                }
            }
        }
 
        WebOperationContext.Current.OutgoingResponse.ContentType = &quot;text/plain; charset=utf-8&quot;;
        MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString()));
        return ms;
    }
 
    private int FetchContact(string id)
    {
        int result = -1;
        for (int i = 0; i &lt; AllContacts.Count; i&#43;&#43;)
        {
            if (AllContacts[i].Id == id)
            {
                result = i;
                break;
            }
        }
 
        if (result &lt; 0)
        {
            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
        }
 
        return result;
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ContactManagerService&nbsp;:&nbsp;IContactManager&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;List&lt;Contact&gt;&nbsp;AllContacts&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Contact&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;currentId&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;syncRoot&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">object</span>();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;AddContact(Contact&nbsp;contact)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;contactId&nbsp;=&nbsp;Interlocked.Increment(<span class="cs__keyword">ref</span>&nbsp;currentId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contact.Id&nbsp;=&nbsp;contactId.ToString(CultureInfo.InvariantCulture);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">lock</span>&nbsp;(syncRoot)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AllContacts.Add(contact);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebOperationContext.Current.OutgoingResponse.StatusCode&nbsp;=&nbsp;HttpStatusCode.Created;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;contact.Id;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;UpdateContact(<span class="cs__keyword">string</span>&nbsp;id,&nbsp;Contact&nbsp;contact)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contact.Id&nbsp;=&nbsp;id;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">lock</span>&nbsp;(syncRoot)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;index&nbsp;=&nbsp;<span class="cs__keyword">this</span>.FetchContact(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(index&nbsp;&gt;=&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AllContacts[index]&nbsp;=&nbsp;contact;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteContact(<span class="cs__keyword">string</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">lock</span>&nbsp;(syncRoot)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;index&nbsp;=&nbsp;<span class="cs__keyword">this</span>.FetchContact(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(index&nbsp;&gt;=&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AllContacts.RemoveAt(index);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;Contact&gt;&nbsp;GetAllContacts()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;Contact&gt;&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">lock</span>&nbsp;(syncRoot)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;AllContacts.ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Contact&nbsp;GetContact(<span class="cs__keyword">string</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Contact&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">lock</span>&nbsp;(syncRoot)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;index&nbsp;=&nbsp;<span class="cs__keyword">this</span>.FetchContact(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;index&nbsp;&lt;&nbsp;<span class="cs__number">0</span>&nbsp;?&nbsp;<span class="cs__keyword">null</span>&nbsp;:&nbsp;AllContacts[index];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Stream&nbsp;GetContactsAsText()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;sb&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebOperationContext.Current.OutgoingResponse.ContentType&nbsp;=&nbsp;<span class="cs__string">&quot;text/plain&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">lock</span>&nbsp;(syncRoot)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;contact&nbsp;<span class="cs__keyword">in</span>&nbsp;AllContacts)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendLine(<span class="cs__string">&quot;Contact&nbsp;&quot;</span>&nbsp;&#43;&nbsp;contact.Id&nbsp;&#43;&nbsp;<span class="cs__string">&quot;:&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendLine(<span class="cs__string">&quot;&nbsp;&nbsp;Name:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;contact.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendLine(<span class="cs__string">&quot;&nbsp;&nbsp;Email:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;contact.Email);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendLine(<span class="cs__string">&quot;&nbsp;&nbsp;Telephones:&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;phone&nbsp;<span class="cs__keyword">in</span>&nbsp;contact.Telephones)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendLine(<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;phone);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebOperationContext.Current.OutgoingResponse.ContentType&nbsp;=&nbsp;<span class="cs__string">&quot;text/plain;&nbsp;charset=utf-8&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MemoryStream&nbsp;ms&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream(Encoding.UTF8.GetBytes(sb.ToString()));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;ms;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;FetchContact(<span class="cs__keyword">string</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;result&nbsp;=&nbsp;-<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;AllContacts.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(AllContacts[i].Id&nbsp;==&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;i;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(result&nbsp;&lt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebOperationContext.Current.OutgoingResponse.StatusCode&nbsp;=&nbsp;HttpStatusCode.NotFound;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>Now for the inspector itself. I&rsquo;ll implement it as both an <a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.dispatcher.idispatchmessageinspector.aspx">
IDispatchMessageInspector</a> and an <a href="/controlpanel/blogs/posteditor.aspx/">
IEndpointBehavior</a> to make it easier for adding it to the endpoint I&rsquo;m interested in logging the messages for. It will contain a folder where to log the messages, plus a counter to create the file name where the messages will be logged. The IEndpointBehavior
 implementation is simple, only using the ApplyDispatchBehavior method to add that instance to the list of message inspectors in the dispatch runtime.</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:9037dad5-7cbb-43d6-8bd8-f1277cb7975b" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class IncomingMessageLogger : IDispatchMessageInspector, IEndpointBehavior
{
    const string MessageLogFolder = @&quot;c:\temp\&quot;;
    static int messageLogFileIndex = 0;
 
    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
    {
    }
 
    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
    }
 
    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
    {
        endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);
    }
 
    public void Validate(ServiceEndpoint endpoint)
    {
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;IncomingMessageLogger&nbsp;:&nbsp;IDispatchMessageInspector,&nbsp;IEndpointBehavior&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;MessageLogFolder&nbsp;=&nbsp;@&quot;c:\temp\&quot;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;messageLogFileIndex&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddBindingParameters(ServiceEndpoint&nbsp;endpoint,&nbsp;BindingParameterCollection&nbsp;bindingParameters)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ApplyClientBehavior(ServiceEndpoint&nbsp;endpoint,&nbsp;ClientRuntime&nbsp;clientRuntime)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ApplyDispatchBehavior(ServiceEndpoint&nbsp;endpoint,&nbsp;EndpointDispatcher&nbsp;endpointDispatcher)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;endpointDispatcher.DispatchRuntime.MessageInspectors.Add(<span class="cs__keyword">this</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Validate(ServiceEndpoint&nbsp;endpoint)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>Now for the message inspector implementation. For every incoming or outgoing message, we&rsquo;ll create a new file in the folder defined in the const field for the class.</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:f2236c09-e6cd-480c-93e0-9601133642ac" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
{
    string messageFileName = string.Format(&quot;{0}Log{1:000}_Incoming.txt&quot;, MessageLogFolder, Interlocked.Increment(ref messageLogFileIndex));
    Uri requestUri = request.Headers.To;
    using (StreamWriter sw = File.CreateText(messageFileName))
    {
        HttpRequestMessageProperty httpReq = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
 
        sw.WriteLine(&quot;{0} {1}&quot;, httpReq.Method, requestUri);
        foreach (var header in httpReq.Headers.AllKeys)
        {
            sw.WriteLine(&quot;{0}: {1}&quot;, header, httpReq.Headers[header]);
        }
 
        if (!request.IsEmpty)
        {
            sw.WriteLine();
            sw.WriteLine(this.MessageToString(ref request));
        }
    }
 
    return requestUri;
}
 
public void BeforeSendReply(ref Message reply, object correlationState)
{
    string messageFileName = string.Format(&quot;{0}Log{1:000}_Outgoing.txt&quot;, MessageLogFolder, Interlocked.Increment(ref messageLogFileIndex));
 
    using (StreamWriter sw = File.CreateText(messageFileName))
    {
        sw.WriteLine(&quot;Response to request to {0}:&quot;, (Uri)correlationState);
        HttpResponseMessageProperty httpResp = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
        sw.WriteLine(&quot;{0} {1}&quot;, (int)httpResp.StatusCode, httpResp.StatusCode);
 
        if (!reply.IsEmpty)
        {
            sw.WriteLine();
            sw.WriteLine(this.MessageToString(ref reply));
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;AfterReceiveRequest(<span class="cs__keyword">ref</span>&nbsp;Message&nbsp;request,&nbsp;IClientChannel&nbsp;channel,&nbsp;InstanceContext&nbsp;instanceContext)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;messageFileName&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;{0}Log{1:000}_Incoming.txt&quot;</span>,&nbsp;MessageLogFolder,&nbsp;Interlocked.Increment(<span class="cs__keyword">ref</span>&nbsp;messageLogFileIndex));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;requestUri&nbsp;=&nbsp;request.Headers.To;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(StreamWriter&nbsp;sw&nbsp;=&nbsp;File.CreateText(messageFileName))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpRequestMessageProperty&nbsp;httpReq&nbsp;=&nbsp;(HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine(<span class="cs__string">&quot;{0}&nbsp;{1}&quot;</span>,&nbsp;httpReq.Method,&nbsp;requestUri);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;header&nbsp;<span class="cs__keyword">in</span>&nbsp;httpReq.Headers.AllKeys)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine(<span class="cs__string">&quot;{0}:&nbsp;{1}&quot;</span>,&nbsp;header,&nbsp;httpReq.Headers[header]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!request.IsEmpty)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine(<span class="cs__keyword">this</span>.MessageToString(<span class="cs__keyword">ref</span>&nbsp;request));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;requestUri;&nbsp;
}&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;BeforeSendReply(<span class="cs__keyword">ref</span>&nbsp;Message&nbsp;reply,&nbsp;<span class="cs__keyword">object</span>&nbsp;correlationState)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;messageFileName&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;{0}Log{1:000}_Outgoing.txt&quot;</span>,&nbsp;MessageLogFolder,&nbsp;Interlocked.Increment(<span class="cs__keyword">ref</span>&nbsp;messageLogFileIndex));&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(StreamWriter&nbsp;sw&nbsp;=&nbsp;File.CreateText(messageFileName))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine(<span class="cs__string">&quot;Response&nbsp;to&nbsp;request&nbsp;to&nbsp;{0}:&quot;</span>,&nbsp;(Uri)correlationState);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessageProperty&nbsp;httpResp&nbsp;=&nbsp;(HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine(<span class="cs__string">&quot;{0}&nbsp;{1}&quot;</span>,&nbsp;(<span class="cs__keyword">int</span>)httpResp.StatusCode,&nbsp;httpResp.StatusCode);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!reply.IsEmpty)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine(<span class="cs__keyword">this</span>.MessageToString(<span class="cs__keyword">ref</span>&nbsp;reply));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>Now for the interesting part &ndash; the implementation of MessageToString. Incoming messages from the encoder used in the
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.webhttpbinding.aspx">
WebHttpBinding</a> are tagged with a property of type <a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.channels.webbodyformatmessageproperty.aspx">
WebBodyFormatMessageProperty</a>, which defines which of the inner encoders was used to decode the message (the encoder from that binding is actually composed of three encoders: one for XML content, one for JSON, and one for everything else). That property
 is also used on outgoing messages to tell the web encoder which of the inner encoders should be used to write the message to the wire. So we&rsquo;ll define a small helper method to retrieve the format from the message object.</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:58def131-f6c7-4670-bfff-281ce71b7710" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private WebContentFormat GetMessageContentFormat(Message message)
{
    WebContentFormat format = WebContentFormat.Default;
    if (message.Properties.ContainsKey(WebBodyFormatMessageProperty.Name))
    {
        WebBodyFormatMessageProperty bodyFormat;
        bodyFormat = (WebBodyFormatMessageProperty)message.Properties[WebBodyFormatMessageProperty.Name];
        format = bodyFormat.Format;
    }
 
    return format;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;WebContentFormat&nbsp;GetMessageContentFormat(Message&nbsp;message)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WebContentFormat&nbsp;format&nbsp;=&nbsp;WebContentFormat.Default;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(message.Properties.ContainsKey(WebBodyFormatMessageProperty.Name))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebBodyFormatMessageProperty&nbsp;bodyFormat;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bodyFormat&nbsp;=&nbsp;(WebBodyFormatMessageProperty)message.Properties[WebBodyFormatMessageProperty.Name];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;format&nbsp;=&nbsp;bodyFormat.Format;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;format;&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>And now for MessageToString (really this time). For XML and JSON messages, the implementation will write the message into a XmlWriter of the appropriate type. The writer created by the class
<a href="http://msdn.microsoft.com/en-us/library/system.runtime.serialization.json.jsonreaderwriterfactory.aspx">
JsonReaderWriterFactory</a> implements the mapping between JSON and XML I mentioned before, so we&rsquo;ll use it for JSON messages; for XML messages (or for messages which don&rsquo;t have the body format property) we&rsquo;ll use the &ldquo;normal&rdquo;
 XML writer from WCF; for raw messages we&rsquo;ll deal with them specifically in a separate method. After the message is written, it has been consumed, so we need to recreate it to pass it along the channel stack. Using a reader of the same type and creating
 a new message using the <a href="http://msdn.microsoft.com/en-us/library/ms586762.aspx">
Message.CreateMessage(XmlDictionaryReader, int, MessageVersion)</a> overload and copying the original message properties (which are not serialized when the message is written out).</p>
<p>For the raw messages, since the format is relatively simple (the binary data, written as base64Binary data, wrapped in a single &lt;Binary&gt; element), we can consume it directly &ndash; read the message body, skip the wrapping element then read the whole
 body at once. In this case I&rsquo;m always converting the binary data to text, in the general case that may not work (if the binary data is an image, for example), but that&rsquo;s beyond the scope for this post.</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:990e6f90-3d2a-404e-8505-2b02551483e4" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private string MessageToString(ref Message message)
{
    WebContentFormat messageFormat = this.GetMessageContentFormat(message);
    MemoryStream ms = new MemoryStream();
    XmlDictionaryWriter writer = null;
    switch (messageFormat)
    {
        case WebContentFormat.Default:
        case WebContentFormat.Xml:
            writer = XmlDictionaryWriter.CreateTextWriter(ms);
            break;
        case WebContentFormat.Json:
            writer = JsonReaderWriterFactory.CreateJsonWriter(ms);
            break;
        case WebContentFormat.Raw:
            // special case for raw, easier implemented separately
            return this.ReadRawBody(ref message);
    }
 
    message.WriteMessage(writer);
    writer.Flush();
    string messageBody = Encoding.UTF8.GetString(ms.ToArray());
 
    // Here would be a good place to change the message body, if so desired.
 
    // now that the message was read, it needs to be recreated.
    ms.Position = 0;
 
    // if the message body was modified, needs to reencode it, as show below
    // ms = new MemoryStream(Encoding.UTF8.GetBytes(messageBody));
 
    XmlDictionaryReader reader;
    if (messageFormat == WebContentFormat.Json)
    {
        reader = JsonReaderWriterFactory.CreateJsonReader(ms, XmlDictionaryReaderQuotas.Max);
    }
    else
    {
        reader = XmlDictionaryReader.CreateTextReader(ms, XmlDictionaryReaderQuotas.Max);
    }
 
    Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
    newMessage.Properties.CopyProperties(message.Properties);
    message = newMessage;
 
    return messageBody;
}
 
private string ReadRawBody(ref Message message)
{
    XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
    bodyReader.ReadStartElement(&quot;Binary&quot;);
    byte[] bodyBytes = bodyReader.ReadContentAsBase64();
    string messageBody = Encoding.UTF8.GetString(bodyBytes);
 
    // Now to recreate the message
    MemoryStream ms = new MemoryStream();
    XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(ms);
    writer.WriteStartElement(&quot;Binary&quot;);
    writer.WriteBase64(bodyBytes, 0, bodyBytes.Length);
    writer.WriteEndElement();
    writer.Flush();
    ms.Position = 0;
    XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(ms, XmlDictionaryReaderQuotas.Max);
    Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
    newMessage.Properties.CopyProperties(message.Properties);
    message = newMessage;
 
    return messageBody;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;MessageToString(<span class="cs__keyword">ref</span>&nbsp;Message&nbsp;message)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WebContentFormat&nbsp;messageFormat&nbsp;=&nbsp;<span class="cs__keyword">this</span>.GetMessageContentFormat(message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MemoryStream&nbsp;ms&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;XmlDictionaryWriter&nbsp;writer&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(messageFormat)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;WebContentFormat.Default:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;WebContentFormat.Xml:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;writer&nbsp;=&nbsp;XmlDictionaryWriter.CreateTextWriter(ms);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;WebContentFormat.Json:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;writer&nbsp;=&nbsp;JsonReaderWriterFactory.CreateJsonWriter(ms);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;WebContentFormat.Raw:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;special&nbsp;case&nbsp;for&nbsp;raw,&nbsp;easier&nbsp;implemented&nbsp;separately</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.ReadRawBody(<span class="cs__keyword">ref</span>&nbsp;message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;message.WriteMessage(writer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;writer.Flush();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;messageBody&nbsp;=&nbsp;Encoding.UTF8.GetString(ms.ToArray());&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Here&nbsp;would&nbsp;be&nbsp;a&nbsp;good&nbsp;place&nbsp;to&nbsp;change&nbsp;the&nbsp;message&nbsp;body,&nbsp;if&nbsp;so&nbsp;desired.</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;now&nbsp;that&nbsp;the&nbsp;message&nbsp;was&nbsp;read,&nbsp;it&nbsp;needs&nbsp;to&nbsp;be&nbsp;recreated.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ms.Position&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;if&nbsp;the&nbsp;message&nbsp;body&nbsp;was&nbsp;modified,&nbsp;needs&nbsp;to&nbsp;reencode&nbsp;it,&nbsp;as&nbsp;show&nbsp;below</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;ms&nbsp;=&nbsp;new&nbsp;MemoryStream(Encoding.UTF8.GetBytes(messageBody));</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;XmlDictionaryReader&nbsp;reader;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(messageFormat&nbsp;==&nbsp;WebContentFormat.Json)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader&nbsp;=&nbsp;JsonReaderWriterFactory.CreateJsonReader(ms,&nbsp;XmlDictionaryReaderQuotas.Max);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader&nbsp;=&nbsp;XmlDictionaryReader.CreateTextReader(ms,&nbsp;XmlDictionaryReaderQuotas.Max);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Message&nbsp;newMessage&nbsp;=&nbsp;Message.CreateMessage(reader,&nbsp;<span class="cs__keyword">int</span>.MaxValue,&nbsp;message.Version);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;newMessage.Properties.CopyProperties(message.Properties);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;message&nbsp;=&nbsp;newMessage;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;messageBody;&nbsp;
}&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ReadRawBody(<span class="cs__keyword">ref</span>&nbsp;Message&nbsp;message)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;XmlDictionaryReader&nbsp;bodyReader&nbsp;=&nbsp;message.GetReaderAtBodyContents();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bodyReader.ReadStartElement(<span class="cs__string">&quot;Binary&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;bodyBytes&nbsp;=&nbsp;bodyReader.ReadContentAsBase64();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;messageBody&nbsp;=&nbsp;Encoding.UTF8.GetString(bodyBytes);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Now&nbsp;to&nbsp;recreate&nbsp;the&nbsp;message</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MemoryStream&nbsp;ms&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;XmlDictionaryWriter&nbsp;writer&nbsp;=&nbsp;XmlDictionaryWriter.CreateBinaryWriter(ms);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;writer.WriteStartElement(<span class="cs__string">&quot;Binary&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;writer.WriteBase64(bodyBytes,&nbsp;<span class="cs__number">0</span>,&nbsp;bodyBytes.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;writer.WriteEndElement();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;writer.Flush();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ms.Position&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;XmlDictionaryReader&nbsp;reader&nbsp;=&nbsp;XmlDictionaryReader.CreateBinaryReader(ms,&nbsp;XmlDictionaryReaderQuotas.Max);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Message&nbsp;newMessage&nbsp;=&nbsp;Message.CreateMessage(reader,&nbsp;<span class="cs__keyword">int</span>.MaxValue,&nbsp;message.Version);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;newMessage.Properties.CopyProperties(message.Properties);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;message&nbsp;=&nbsp;newMessage;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;messageBody;&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>That&rsquo;s it. With this inspector we can log messages of all types for REST services, in their original format. Another way to implement it would be in a custom message encoder (coming up in this series), in which you can have access to the raw bytes
 coming from the wire, as well as the content-type of the HTTP request.</p>
<p>Now for some test code which sets up the service with that inspector, and sends some messages to it.</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:779a5282-e1e8-4034-8691-dfcf490459be" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class Program
{
    public static void Main(string[] args)
    {
        string baseAddress = &quot;http://&quot; &#43; Environment.MachineName &#43; &quot;:8000/Service&quot;;
        ServiceHost host = new ServiceHost(typeof(ContactManagerService), new Uri(baseAddress));
        ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IContactManager), new WebHttpBinding(), &quot;&quot;);
        endpoint.Behaviors.Add(new WebHttpBehavior());
        endpoint.Behaviors.Add(new IncomingMessageLogger());
        host.Open();
        Console.WriteLine(&quot;Host opened&quot;);

        string johnId = SendRequest(
            &quot;POST&quot;,
            baseAddress &#43; &quot;/Contacts&quot;,
            &quot;application/json&quot;,
            CreateJsonContact(null, &quot;John Doe&quot;, &quot;john@doe.com&quot;, &quot;206-555-3333&quot;));
        string janeId = SendRequest(
            &quot;POST&quot;,
            baseAddress &#43; &quot;/Contacts&quot;,
            &quot;application/json&quot;,
            CreateJsonContact(null, &quot;Jane Roe&quot;, &quot;jane@roe.com&quot;, &quot;202-555-4444 202-555-8888&quot;));

        Console.WriteLine(&quot;All contacts&quot;);
        SendRequest(&quot;GET&quot;, baseAddress &#43; &quot;/Contacts&quot;, null, null);

        Console.WriteLine(&quot;Updating Jane&quot;);
        SendRequest(
            &quot;PUT&quot;,
            baseAddress &#43; &quot;/Contacts/&quot; &#43; janeId,
            &quot;application/json&quot;,
            CreateJsonContact(janeId, &quot;Jane Roe&quot;, &quot;jane@roe.org&quot;, &quot;202-555-4444 202-555-8888&quot;));

        Console.WriteLine(&quot;All contacts, text format&quot;);
        SendRequest(&quot;GET&quot;, baseAddress &#43; &quot;/ContactsAsText&quot;, null, null);

        Console.WriteLine(&quot;Deleting John&quot;);
        SendRequest(&quot;DELETE&quot;, baseAddress &#43; &quot;/Contacts/&quot; &#43; johnId, null, null);

        Console.WriteLine(&quot;Is John still here?&quot;);
        SendRequest(&quot;GET&quot;, baseAddress &#43; &quot;/Contacts/&quot; &#43; johnId, null, null);

        Console.WriteLine(&quot;It also works with XML payloads:&quot;);
        string xmlPayload = @&quot;&lt;Contact&gt;
&lt;Email&gt;johnjr@doe.com&lt;/Email&gt;
&lt;Name&gt;John Doe Jr&lt;/Name&gt;
&lt;Telephones xmlns:a=&quot;&quot;http://schemas.microsoft.com/2003/10/Serialization/Arrays&quot;&quot;&gt;
&lt;a:string&gt;333-333-3333&lt;/a:string&gt;
&lt;/Telephones&gt;
&lt;/Contact&gt;&quot;;
        SendRequest(
            &quot;POST&quot;,
            baseAddress &#43; &quot;/Contacts&quot;,
            &quot;text/xml&quot;,
            xmlPayload);

        Console.WriteLine(&quot;All contacts:&quot;);
        SendRequest(&quot;GET&quot;, baseAddress &#43; &quot;/Contacts&quot;, null, null);
    }

    static string SendRequest(string method, string uri, string contentType, string body)
    {
        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
        req.Method = method;
        if (contentType != null)
        {
            req.ContentType = contentType;
        }

        if (body != null)
        {
            byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(bodyBytes, 0, bodyBytes.Length);
            reqStream.Close();
        }

        HttpWebResponse resp;
        try
        {
            resp = (HttpWebResponse)req.GetResponse();
        }
        catch (WebException e)
        {
            resp = (HttpWebResponse)e.Response;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(&quot;Response to request to {0} - {1}&quot;, method, uri);
        Console.WriteLine(&quot;HTTP/{0} {1} {2}&quot;, resp.ProtocolVersion, (int)resp.StatusCode, resp.StatusDescription);
        foreach (var headerName in resp.Headers.AllKeys)
        {
            Console.WriteLine(&quot;{0}: {1}&quot;, headerName, resp.Headers[headerName]);
        }

        Stream respStream = resp.GetResponseStream();
        string result = null;
        if (respStream != null)
        {
            result = new StreamReader(respStream).ReadToEnd();
            Console.WriteLine(result);
        }

        Console.WriteLine();
        Console.WriteLine(&quot;  -*-*-*-*-*-*-*-*&quot;);
        Console.WriteLine();

        Console.ResetColor();

        // Removing the string markers from results (for contact ids)
        if (result.StartsWith(&quot;\&quot;&quot;) &amp;&amp; result.EndsWith(&quot;\&quot;&quot;))
        {
            result = result.Substring(1, result.Length - 2);
        }

        return result;
    }

    static string CreateJsonContact(string id, string name, string email, string telephones)
    {
        string[] phoneNumbers = telephones.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder sb = new StringBuilder();
        sb.Append('{');
        if (id != null)
        {
            sb.AppendFormat(&quot;\&quot;Id\&quot;:\&quot;{0}\&quot;, &quot;, id);
        }

        sb.AppendFormat(&quot;\&quot;Name\&quot;:\&quot;{0}\&quot;, &quot;, name);
        sb.AppendFormat(&quot;\&quot;Email\&quot;:\&quot;{0}\&quot;, &quot;, email);
        sb.Append(&quot;\&quot;Telephones\&quot;:[&quot;);
        for (int i = 0; i &lt; phoneNumbers.Length; i&#43;&#43;)
        {
            if (i &gt; 0) sb.Append(&quot;, &quot;);
            sb.AppendFormat(&quot;\&quot;{0}\&quot;&quot;, phoneNumbers[i]);
        }

        sb.Append(']');
        sb.Append('}');
        return sb.ToString();
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;baseAddress&nbsp;=&nbsp;<span class="cs__string">&quot;http://&quot;</span>&nbsp;&#43;&nbsp;Environment.MachineName&nbsp;&#43;&nbsp;<span class="cs__string">&quot;:8000/Service&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceHost&nbsp;host&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServiceHost(<span class="cs__keyword">typeof</span>(ContactManagerService),&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(baseAddress));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceEndpoint&nbsp;endpoint&nbsp;=&nbsp;host.AddServiceEndpoint(<span class="cs__keyword">typeof</span>(IContactManager),&nbsp;<span class="cs__keyword">new</span>&nbsp;WebHttpBinding(),&nbsp;<span class="cs__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;endpoint.Behaviors.Add(<span class="cs__keyword">new</span>&nbsp;WebHttpBehavior());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;endpoint.Behaviors.Add(<span class="cs__keyword">new</span>&nbsp;IncomingMessageLogger());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;host.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Host&nbsp;opened&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;johnId&nbsp;=&nbsp;SendRequest(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;POST&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;baseAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/Contacts&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;application/json&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateJsonContact(<span class="cs__keyword">null</span>,&nbsp;<span class="cs__string">&quot;John&nbsp;Doe&quot;</span>,&nbsp;<span class="cs__string">&quot;john@doe.com&quot;</span>,&nbsp;<span class="cs__string">&quot;206-555-3333&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;janeId&nbsp;=&nbsp;SendRequest(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;POST&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;baseAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/Contacts&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;application/json&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateJsonContact(<span class="cs__keyword">null</span>,&nbsp;<span class="cs__string">&quot;Jane&nbsp;Roe&quot;</span>,&nbsp;<span class="cs__string">&quot;jane@roe.com&quot;</span>,&nbsp;<span class="cs__string">&quot;202-555-4444&nbsp;202-555-8888&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;All&nbsp;contacts&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendRequest(<span class="cs__string">&quot;GET&quot;</span>,&nbsp;baseAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/Contacts&quot;</span>,&nbsp;<span class="cs__keyword">null</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Updating&nbsp;Jane&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendRequest(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;PUT&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;baseAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/Contacts/&quot;</span>&nbsp;&#43;&nbsp;janeId,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;application/json&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateJsonContact(janeId,&nbsp;<span class="cs__string">&quot;Jane&nbsp;Roe&quot;</span>,&nbsp;<span class="cs__string">&quot;jane@roe.org&quot;</span>,&nbsp;<span class="cs__string">&quot;202-555-4444&nbsp;202-555-8888&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;All&nbsp;contacts,&nbsp;text&nbsp;format&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendRequest(<span class="cs__string">&quot;GET&quot;</span>,&nbsp;baseAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/ContactsAsText&quot;</span>,&nbsp;<span class="cs__keyword">null</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Deleting&nbsp;John&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendRequest(<span class="cs__string">&quot;DELETE&quot;</span>,&nbsp;baseAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/Contacts/&quot;</span>&nbsp;&#43;&nbsp;johnId,&nbsp;<span class="cs__keyword">null</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Is&nbsp;John&nbsp;still&nbsp;here?&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendRequest(<span class="cs__string">&quot;GET&quot;</span>,&nbsp;baseAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/Contacts/&quot;</span>&nbsp;&#43;&nbsp;johnId,&nbsp;<span class="cs__keyword">null</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;It&nbsp;also&nbsp;works&nbsp;with&nbsp;XML&nbsp;payloads:&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;xmlPayload&nbsp;=&nbsp;@&quot;&lt;Contact&gt;&nbsp;
&lt;Email&gt;johnjr@doe.com&lt;/Email&gt;&nbsp;
&lt;Name&gt;John&nbsp;Doe&nbsp;Jr&lt;/Name&gt;&nbsp;
&lt;Telephones&nbsp;xmlns:a=<span class="cs__string">&quot;&quot;</span>http:<span class="cs__com">//schemas.microsoft.com/2003/10/Serialization/Arrays&quot;&quot;&gt;</span>&nbsp;
&lt;a:<span class="cs__keyword">string</span>&gt;<span class="cs__number">333</span><span class="cs__number">-333</span><span class="cs__number">-3333</span>&lt;/a:<span class="cs__keyword">string</span>&gt;&nbsp;
&lt;/Telephones&gt;&nbsp;
&lt;/Contact&gt;&quot;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendRequest(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;POST&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;baseAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/Contacts&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;text/xml&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlPayload);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;All&nbsp;contacts:&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendRequest(<span class="cs__string">&quot;GET&quot;</span>,&nbsp;baseAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/Contacts&quot;</span>,&nbsp;<span class="cs__keyword">null</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;SendRequest(<span class="cs__keyword">string</span>&nbsp;method,&nbsp;<span class="cs__keyword">string</span>&nbsp;uri,&nbsp;<span class="cs__keyword">string</span>&nbsp;contentType,&nbsp;<span class="cs__keyword">string</span>&nbsp;body)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebRequest&nbsp;req&nbsp;=&nbsp;(HttpWebRequest)HttpWebRequest.Create(uri);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;req.Method&nbsp;=&nbsp;method;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(contentType&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;req.ContentType&nbsp;=&nbsp;contentType;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(body&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;bodyBytes&nbsp;=&nbsp;Encoding.UTF8.GetBytes(body);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stream&nbsp;reqStream&nbsp;=&nbsp;req.GetRequestStream();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reqStream.Write(bodyBytes,&nbsp;<span class="cs__number">0</span>,&nbsp;bodyBytes.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reqStream.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebResponse&nbsp;resp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resp&nbsp;=&nbsp;(HttpWebResponse)req.GetResponse();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(WebException&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resp&nbsp;=&nbsp;(HttpWebResponse)e.Response;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ForegroundColor&nbsp;=&nbsp;ConsoleColor.Cyan;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Response&nbsp;to&nbsp;request&nbsp;to&nbsp;{0}&nbsp;-&nbsp;{1}&quot;</span>,&nbsp;method,&nbsp;uri);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;HTTP/{0}&nbsp;{1}&nbsp;{2}&quot;</span>,&nbsp;resp.ProtocolVersion,&nbsp;(<span class="cs__keyword">int</span>)resp.StatusCode,&nbsp;resp.StatusDescription);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;headerName&nbsp;<span class="cs__keyword">in</span>&nbsp;resp.Headers.AllKeys)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;{0}:&nbsp;{1}&quot;</span>,&nbsp;headerName,&nbsp;resp.Headers[headerName]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stream&nbsp;respStream&nbsp;=&nbsp;resp.GetResponseStream();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(respStream&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamReader(respStream).ReadToEnd();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;&nbsp;&nbsp;-*-*-*-*-*-*-*-*&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ResetColor();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Removing&nbsp;the&nbsp;string&nbsp;markers&nbsp;from&nbsp;results&nbsp;(for&nbsp;contact&nbsp;ids)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(result.StartsWith(<span class="cs__string">&quot;\&quot;&quot;</span>)&nbsp;&amp;&amp;&nbsp;result.EndsWith(<span class="cs__string">&quot;\&quot;&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;result.Substring(<span class="cs__number">1</span>,&nbsp;result.Length&nbsp;-&nbsp;<span class="cs__number">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;CreateJsonContact(<span class="cs__keyword">string</span>&nbsp;id,&nbsp;<span class="cs__keyword">string</span>&nbsp;name,&nbsp;<span class="cs__keyword">string</span>&nbsp;email,&nbsp;<span class="cs__keyword">string</span>&nbsp;telephones)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>[]&nbsp;phoneNumbers&nbsp;=&nbsp;telephones.Split(<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">char</span>[]&nbsp;{&nbsp;<span class="cs__string">'&nbsp;'</span>&nbsp;},&nbsp;StringSplitOptions.RemoveEmptyEntries);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;sb&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="cs__string">'{'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(id&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendFormat(<span class="cs__string">&quot;\&quot;Id\&quot;:\&quot;{0}\&quot;,&nbsp;&quot;</span>,&nbsp;id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendFormat(<span class="cs__string">&quot;\&quot;Name\&quot;:\&quot;{0}\&quot;,&nbsp;&quot;</span>,&nbsp;name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendFormat(<span class="cs__string">&quot;\&quot;Email\&quot;:\&quot;{0}\&quot;,&nbsp;&quot;</span>,&nbsp;email);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="cs__string">&quot;\&quot;Telephones\&quot;:[&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;phoneNumbers.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(i&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;sb.Append(<span class="cs__string">&quot;,&nbsp;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.AppendFormat(<span class="cs__string">&quot;\&quot;{0}\&quot;&quot;</span>,&nbsp;phoneNumbers[i]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="cs__string">']'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="cs__string">'}'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;sb.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>One more thing: we had to deal with lots of different formats and translation between a &ldquo;XML&rdquo; message into its own format, which is not something very natural. Some good news is that among the new features coming in an upcoming version of WCF
 is a new HTTP pipeline, which will make it easier to implement a scenario such as this. And you can actually start using them right now, as there is a preview of the feature in the WCF Codeplex site at
<a href="http://wcf.codeplex.com">http://wcf.codeplex.com</a>.</p>
