# Supporting different data and serialization formats in WCF
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
- 05/16/2012
## Description

<p><em>This sample was provided as part of a blog series on WCF extensibility. The entry for this sample can be found at
<a href="http://blogs.msdn.com/b/carlosfigueira/archive/2011/05/03/wcf-extensibility-message-formatters.aspx">
http://blogs.msdn.com/b/carlosfigueira/archive/2011/05/03/wcf-extensibility-message-formatters.aspx</a>.</em></p>
<p>The first version of WCF (.NET Framework 3.0) supported essentially SOAP endpoints &ndash; an XML payload following some rules defined in the SOAP specification (you actually could do POX/REST, but it was awfully hard). On the next version (.NET Framework
 3.5), the REST programming model was added and that started supporting a whole new set of formats, mostly notably POX (plain-old XML, no SOAP involved), JSON (based on the
<a href="http://msdn.microsoft.com/en-us/library/system.runtime.serialization.json.datacontractjsonserializer.aspx">
DataContractJsonSerializer</a>) and a special &ldquo;raw&rdquo; mode, where one could declare a single
<a href="http://msdn.microsoft.com/en-us/library/system.io.stream.aspx">Stream</a> parameter in an operation for
<a href="http://blogs.msdn.com/b/carlosfigueira/archive/2008/04/17/wcf-raw-programming-model-receiving-arbitrary-data.aspx">
receiving arbitrary data</a>, or returning a Stream value for <a href="http://blogs.msdn.com/b/carlosfigueira/archive/2008/04/17/wcf-raw-programming-model-web.aspx">
returning arbitrary data</a>. The raw mode can be used to support essentially all data and serialization formats, but that comes at a price that the operation itself has to deal with serializing / deserializing the parameters. Also, there are
<a href="http://social.msdn.microsoft.com/Forums/en-US/wcf/thread/220d3cec-2ea6-42a9-b9e9-dbd78fb26b83">
scenarios</a> (from the forums) where the user needs to expose the same operation in non-REST endpoints (or even non-HTTP, as in the scenario described in the forum post), where the Stream trick won&rsquo;t work. This example will expand on the answer to the
 forum question and provide formatters which will use a custom serializer (in this case, the JSON.NET one, available from codeplex at
<a href="http://json.codeplex.com">http://json.codeplex.com</a>).</p>
<p>And the usual disclaimer: this is a sample for illustrating the topic of this post, this is not production-ready code. I tested it for a few contracts and it worked, but I cannot guarantee that it will work for all scenarios (please let me know if you find
 a bug or something missing). Also, for simplicity sake it doesn&rsquo;t have a lot of error handling which a production-level code would, and it isn&rsquo;t fully integrated with the WCF REST pipeline (i.e., it doesn&rsquo;t support UriTemplates, it doesn&rsquo;t
 integrate with the REST help page, doesn&rsquo;t support out/ref parameters,, etc.).</p>
<p>First, some data contracts to set up the scenario. The service will process people and their pets. The data contracts are decorated both with WCF serialization attributes (<a href="http://msdn.microsoft.com/en-us/library/system.runtime.serialization.datacontractattribute.aspx">DataContract</a>,
<a href="http://msdn.microsoft.com/en-us/library/system.runtime.serialization.datamemberattribute.aspx">
DataMember</a>), and with the JSON.NET serialization attributes (<a href="http://james.newtonking.com/projects/json/help/html/T_Newtonsoft_Json_JsonObjectAttribute.htm">JsonObejct</a>,
<a href="http://james.newtonking.com/projects/json/help/html/T_Newtonsoft_Json_JsonPropertyAttribute.htm">
JsonProperty</a>, <a href="http://james.newtonking.com/projects/json/help/html/T_Newtonsoft_Json_JsonConverterAttribute.htm">
JsonConverter</a>) so that it can be mapped according to both formats.</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:df72f693-8bec-4d85-885f-9f03825d5186" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[DataContract]
[Newtonsoft.Json.JsonObject(MemberSerialization = Newtonsoft.Json.MemberSerialization.OptIn)]
public class Person
{
    [DataMember(Order = 1), Newtonsoft.Json.JsonProperty]
    public string FirstName;
    [DataMember(Order = 2), Newtonsoft.Json.JsonProperty]
    public string LastName;
    [DataMember(Order = 3),
        Newtonsoft.Json.JsonProperty,
        Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.IsoDateTimeConverter))]
    public DateTime BirthDate;
    [DataMember(Order = 4), Newtonsoft.Json.JsonProperty]
    public List&lt;Pet&gt; Pets;
    [DataMember(Order = 5), Newtonsoft.Json.JsonProperty]
    public int Id;
}
 
[DataContract, Newtonsoft.Json.JsonObject(MemberSerialization = Newtonsoft.Json.MemberSerialization.OptIn)]
public class Pet
{
    [DataMember(Order = 1), Newtonsoft.Json.JsonProperty]
    public string Name;
    [DataMember(Order = 2), Newtonsoft.Json.JsonProperty]
    public string Color;
    [DataMember(Order = 3), Newtonsoft.Json.JsonProperty]
    public string Markings;
    [DataMember(Order = 4), Newtonsoft.Json.JsonProperty]
    public int Id;
}</pre>
<div class="preview">
<pre class="csharp">[DataContract]&nbsp;
[Newtonsoft.Json.JsonObject(MemberSerialization&nbsp;=&nbsp;Newtonsoft.Json.MemberSerialization.OptIn)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Person&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataMember(Order&nbsp;=&nbsp;<span class="cs__number">1</span>),&nbsp;Newtonsoft.Json.JsonProperty]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;FirstName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataMember(Order&nbsp;=&nbsp;<span class="cs__number">2</span>),&nbsp;Newtonsoft.Json.JsonProperty]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;LastName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataMember(Order&nbsp;=&nbsp;<span class="cs__number">3</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Newtonsoft.Json.JsonProperty,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Newtonsoft.Json.JsonConverter(<span class="cs__keyword">typeof</span>(Newtonsoft.Json.Converters.IsoDateTimeConverter))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;BirthDate;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataMember(Order&nbsp;=&nbsp;<span class="cs__number">4</span>),&nbsp;Newtonsoft.Json.JsonProperty]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;Pet&gt;&nbsp;Pets;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataMember(Order&nbsp;=&nbsp;<span class="cs__number">5</span>),&nbsp;Newtonsoft.Json.JsonProperty]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id;&nbsp;
}&nbsp;
&nbsp;&nbsp;
[DataContract,&nbsp;Newtonsoft.Json.JsonObject(MemberSerialization&nbsp;=&nbsp;Newtonsoft.Json.MemberSerialization.OptIn)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Pet&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataMember(Order&nbsp;=&nbsp;<span class="cs__number">1</span>),&nbsp;Newtonsoft.Json.JsonProperty]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataMember(Order&nbsp;=&nbsp;<span class="cs__number">2</span>),&nbsp;Newtonsoft.Json.JsonProperty]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Color;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataMember(Order&nbsp;=&nbsp;<span class="cs__number">3</span>),&nbsp;Newtonsoft.Json.JsonProperty]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Markings;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DataMember(Order&nbsp;=&nbsp;<span class="cs__number">4</span>),&nbsp;Newtonsoft.Json.JsonProperty]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id;&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>Next the interface definition, and the service implementation. It&rsquo;s not very interesting, but I added operations using both GET and POST methods, and operations with single and multiple parameters (the goal of this sample is to demonstrate the formatter,
 not a specific service, so I think I can slack off on the service example a little :).</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:1ab7133b-4ce4-442a-8be7-190f7b2883a3" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[ServiceContract]
public interface ITestService
{
    [WebGet, OperationContract]
    Person GetPerson();
    [WebInvoke, OperationContract]
    Pet EchoPet(Pet pet);
    [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest), OperationContract]
    int Add(int x, int y);
}
 
public class Service : ITestService
{
    public Person GetPerson()
    {
        return new Person
        {
            FirstName = &quot;First&quot;,
            LastName = &quot;Last&quot;,
            BirthDate = new DateTime(1993, 4, 17, 2, 51, 37, 47, DateTimeKind.Local),
            Id = 0,
            Pets = new List&lt;Pet&gt;
            {
                new Pet { Name= &quot;Generic Pet 1&quot;, Color = &quot;Beige&quot;, Id = 0, Markings = &quot;Some markings&quot; },
                new Pet { Name= &quot;Generic Pet 2&quot;, Color = &quot;Gold&quot;, Id = 0, Markings = &quot;Other markings&quot; },
            },
        };
    }
 
    public Pet EchoPet(Pet pet)
    {
        return pet;
    }
 
    public int Add(int x, int y)
    {
        return x &#43; y;
    }
}</pre>
<div class="preview">
<pre class="csharp">[ServiceContract]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;ITestService&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebGet,&nbsp;OperationContract]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Person&nbsp;GetPerson();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebInvoke,&nbsp;OperationContract]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Pet&nbsp;EchoPet(Pet&nbsp;pet);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebInvoke(BodyStyle&nbsp;=&nbsp;WebMessageBodyStyle.WrappedRequest),&nbsp;OperationContract]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;Add(<span class="cs__keyword">int</span>&nbsp;x,&nbsp;<span class="cs__keyword">int</span>&nbsp;y);&nbsp;
}&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Service&nbsp;:&nbsp;ITestService&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Person&nbsp;GetPerson()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Person&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FirstName&nbsp;=&nbsp;<span class="cs__string">&quot;First&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LastName&nbsp;=&nbsp;<span class="cs__string">&quot;Last&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BirthDate&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DateTime(<span class="cs__number">1993</span>,&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">17</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">51</span>,&nbsp;<span class="cs__number">37</span>,&nbsp;<span class="cs__number">47</span>,&nbsp;DateTimeKind.Local),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Id&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pets&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Pet&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Pet&nbsp;{&nbsp;Name=&nbsp;<span class="cs__string">&quot;Generic&nbsp;Pet&nbsp;1&quot;</span>,&nbsp;Color&nbsp;=&nbsp;<span class="cs__string">&quot;Beige&quot;</span>,&nbsp;Id&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;Markings&nbsp;=&nbsp;<span class="cs__string">&quot;Some&nbsp;markings&quot;</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Pet&nbsp;{&nbsp;Name=&nbsp;<span class="cs__string">&quot;Generic&nbsp;Pet&nbsp;2&quot;</span>,&nbsp;Color&nbsp;=&nbsp;<span class="cs__string">&quot;Gold&quot;</span>,&nbsp;Id&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;Markings&nbsp;=&nbsp;<span class="cs__string">&quot;Other&nbsp;markings&quot;</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Pet&nbsp;EchoPet(Pet&nbsp;pet)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;pet;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Add(<span class="cs__keyword">int</span>&nbsp;x,&nbsp;<span class="cs__keyword">int</span>&nbsp;y)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;x&nbsp;&#43;&nbsp;y;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>Now the behavior which will set everything together. Since this is a REST endpoint, instead of writing a new endpoint, I&rsquo;ll simply inherit from
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.description.webhttpbehavior.aspx">
WebHttpBehavior</a>, and override the protected methods to return the client and server formatters. Notice that in some cases when there are no parameters or for GET requests (where the parameters are in the query string, not in the request body), so in those
 cases I&rsquo;ll simply reuse the default formatter from the base class. Another logic which is implemented at the behavior is validation &ndash; we know what our formatter doesn&rsquo;t support, so we&rsquo;ll simply throw while the service (or the client
 channel) is being opened, giving the user a clear message explaining why the behavior failed the validation (some of the validation code is not in the snippet below, but it can be found in the source code for this post).</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:888eb198-1581-425c-854e-848882962da6" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class NewtonsoftJsonBehavior : WebHttpBehavior
{
    public override void Validate(ServiceEndpoint endpoint)
    {
        base.Validate(endpoint);
 
        BindingElementCollection elements = endpoint.Binding.CreateBindingElements();
        WebMessageEncodingBindingElement webEncoder = elements.Find&lt;WebMessageEncodingBindingElement&gt;();
        if (webEncoder == null)
        {
            throw new InvalidOperationException(&quot;This behavior must be used in an endpoint with the WebHttpBinding (or a custom binding with the WebMessageEncodingBindingElement).&quot;);
        }
 
        foreach (OperationDescription operation in endpoint.Contract.Operations)
        {
            this.ValidateOperation(operation);
        }
    }
 
    protected override IDispatchMessageFormatter GetRequestDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
    {
        if (this.IsGetOperation(operationDescription))
        {
            // no change for GET operations
            return base.GetRequestDispatchFormatter(operationDescription, endpoint);
        }
 
        if (operationDescription.Messages[0].Body.Parts.Count == 0)
        {
            // nothing in the body, still use the default
            return base.GetRequestDispatchFormatter(operationDescription, endpoint);
        }
 
        return new NewtonsoftJsonDispatchFormatter(operationDescription, true);
    }
 
    protected override IDispatchMessageFormatter GetReplyDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
    {
        if (operationDescription.Messages.Count == 1 || operationDescription.Messages[1].Body.ReturnValue.Type == typeof(void))
        {
            return base.GetReplyDispatchFormatter(operationDescription, endpoint);
        }
        else
        {
            return new NewtonsoftJsonDispatchFormatter(operationDescription, false);
        }
    }
 
    protected override IClientMessageFormatter GetRequestClientFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
    {
        if (operationDescription.Behaviors.Find&lt;WebGetAttribute&gt;() != null)
        {
            // no change for GET operations
            return base.GetRequestClientFormatter(operationDescription, endpoint);
        }
        else
        {
            WebInvokeAttribute wia = operationDescription.Behaviors.Find&lt;WebInvokeAttribute&gt;();
            if (wia != null)
            {
                if (wia.Method == &quot;HEAD&quot;)
                {
                    // essentially a GET operation
                    return base.GetRequestClientFormatter(operationDescription, endpoint);
                }
            }
        }
 
        if (operationDescription.Messages[0].Body.Parts.Count == 0)
        {
            // nothing in the body, still use the default
            return base.GetRequestClientFormatter(operationDescription, endpoint);
        }
 
        return new NewtonsoftJsonClientFormatter(operationDescription, endpoint);
    }
 
    protected override IClientMessageFormatter GetReplyClientFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
    {
        if (operationDescription.Messages.Count == 1 || operationDescription.Messages[1].Body.ReturnValue.Type == typeof(void))
        {
            return base.GetReplyClientFormatter(operationDescription, endpoint);
        }
        else
        {
            return new NewtonsoftJsonClientFormatter(operationDescription, endpoint);
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;NewtonsoftJsonBehavior&nbsp;:&nbsp;WebHttpBehavior&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Validate(ServiceEndpoint&nbsp;endpoint)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.Validate(endpoint);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BindingElementCollection&nbsp;elements&nbsp;=&nbsp;endpoint.Binding.CreateBindingElements();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebMessageEncodingBindingElement&nbsp;webEncoder&nbsp;=&nbsp;elements.Find&lt;WebMessageEncodingBindingElement&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(webEncoder&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;InvalidOperationException(<span class="cs__string">&quot;This&nbsp;behavior&nbsp;must&nbsp;be&nbsp;used&nbsp;in&nbsp;an&nbsp;endpoint&nbsp;with&nbsp;the&nbsp;WebHttpBinding&nbsp;(or&nbsp;a&nbsp;custom&nbsp;binding&nbsp;with&nbsp;the&nbsp;WebMessageEncodingBindingElement).&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(OperationDescription&nbsp;operation&nbsp;<span class="cs__keyword">in</span>&nbsp;endpoint.Contract.Operations)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.ValidateOperation(operation);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;IDispatchMessageFormatter&nbsp;GetRequestDispatchFormatter(OperationDescription&nbsp;operationDescription,&nbsp;ServiceEndpoint&nbsp;endpoint)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.IsGetOperation(operationDescription))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;no&nbsp;change&nbsp;for&nbsp;GET&nbsp;operations</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.GetRequestDispatchFormatter(operationDescription,&nbsp;endpoint);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(operationDescription.Messages[<span class="cs__number">0</span>].Body.Parts.Count&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;nothing&nbsp;in&nbsp;the&nbsp;body,&nbsp;still&nbsp;use&nbsp;the&nbsp;default</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.GetRequestDispatchFormatter(operationDescription,&nbsp;endpoint);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;NewtonsoftJsonDispatchFormatter(operationDescription,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;IDispatchMessageFormatter&nbsp;GetReplyDispatchFormatter(OperationDescription&nbsp;operationDescription,&nbsp;ServiceEndpoint&nbsp;endpoint)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(operationDescription.Messages.Count&nbsp;==&nbsp;<span class="cs__number">1</span>&nbsp;||&nbsp;operationDescription.Messages[<span class="cs__number">1</span>].Body.ReturnValue.Type&nbsp;==&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">void</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.GetReplyDispatchFormatter(operationDescription,&nbsp;endpoint);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;NewtonsoftJsonDispatchFormatter(operationDescription,&nbsp;<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;IClientMessageFormatter&nbsp;GetRequestClientFormatter(OperationDescription&nbsp;operationDescription,&nbsp;ServiceEndpoint&nbsp;endpoint)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(operationDescription.Behaviors.Find&lt;WebGetAttribute&gt;()&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;no&nbsp;change&nbsp;for&nbsp;GET&nbsp;operations</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.GetRequestClientFormatter(operationDescription,&nbsp;endpoint);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebInvokeAttribute&nbsp;wia&nbsp;=&nbsp;operationDescription.Behaviors.Find&lt;WebInvokeAttribute&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(wia&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(wia.Method&nbsp;==&nbsp;<span class="cs__string">&quot;HEAD&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;essentially&nbsp;a&nbsp;GET&nbsp;operation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.GetRequestClientFormatter(operationDescription,&nbsp;endpoint);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(operationDescription.Messages[<span class="cs__number">0</span>].Body.Parts.Count&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;nothing&nbsp;in&nbsp;the&nbsp;body,&nbsp;still&nbsp;use&nbsp;the&nbsp;default</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.GetRequestClientFormatter(operationDescription,&nbsp;endpoint);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;NewtonsoftJsonClientFormatter(operationDescription,&nbsp;endpoint);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;IClientMessageFormatter&nbsp;GetReplyClientFormatter(OperationDescription&nbsp;operationDescription,&nbsp;ServiceEndpoint&nbsp;endpoint)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(operationDescription.Messages.Count&nbsp;==&nbsp;<span class="cs__number">1</span>&nbsp;||&nbsp;operationDescription.Messages[<span class="cs__number">1</span>].Body.ReturnValue.Type&nbsp;==&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">void</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.GetReplyClientFormatter(operationDescription,&nbsp;endpoint);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;NewtonsoftJsonClientFormatter(operationDescription,&nbsp;endpoint);&nbsp;
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
<p>On to the formatters. I&rsquo;ll start with the dispatch formatter. As the new formatter was only added for POST operations with at least one parameter, we can safely assume that the messages will not be empty, and the request will be stored in the message
 body. But the message body is always represented in XML, so in order to support a custom format, we need to either define a mapping between that format and XML (which is what was done internally for supporting JSON in 3.5) &ndash; and implement XML readers
 and writers to support this mapping &ndash; or reuse one of the existing formats for which we already have a mapping for. And as in the raw programming model, the raw format (described in the
<a href="http://blogs.msdn.com/b/carlosfigueira/archive/2011/04/19/wcf-extensibility-message-inspectors.aspx">
post about message inspectors</a>) is a great candidate for it &ndash; we can get the raw bytes from the request (and write raw bytes in the response) and parse them using our custom format. We must ensure, however, that the incoming message actually was read
 with the raw encoder (by default messages with JSON content type are read with the JSON encoder, we need a custom content type mapper to ensure that they are read as raw messages).</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:c2c6fb1f-ae0b-421e-927d-0bd6b3e61f93" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">class NewtonsoftJsonDispatchFormatter : IDispatchMessageFormatter
{
    OperationDescription operation;
    Dictionary&lt;string, int&gt; parameterNames;
    public NewtonsoftJsonDispatchFormatter(OperationDescription operation, bool isRequest)
    {
        this.operation = operation;
        if (isRequest)
        {
            int operationParameterCount = operation.Messages[0].Body.Parts.Count;
            if (operationParameterCount &gt; 1)
            {
                this.parameterNames = new Dictionary&lt;string, int&gt;();
                for (int i = 0; i &lt; operationParameterCount; i&#43;&#43;)
                {
                    this.parameterNames.Add(operation.Messages[0].Body.Parts[i].Name, i);
                }
            }
        }
    }
 
    public void DeserializeRequest(Message message, object[] parameters)
    {
        object bodyFormatProperty;
        if (!message.Properties.TryGetValue(WebBodyFormatMessageProperty.Name, out bodyFormatProperty) ||
            (bodyFormatProperty as WebBodyFormatMessageProperty).Format != WebContentFormat.Raw)
        {
            throw new InvalidOperationException(&quot;Incoming messages must have a body format of Raw. Is a ContentTypeMapper set on the WebHttpBinding?&quot;);
        }
 
        XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
        bodyReader.ReadStartElement(&quot;Binary&quot;);
        byte[] rawBody = bodyReader.ReadContentAsBase64();
        MemoryStream ms = new MemoryStream(rawBody);
 
        StreamReader sr = new StreamReader(ms);
        Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
        if (parameters.Length == 1)
        {
            // single parameter, assuming bare
            parameters[0] = serializer.Deserialize(sr, operation.Messages[0].Body.Parts[0].Type);
        }
        else
        {
            // multiple parameter, needs to be wrapped
            Newtonsoft.Json.JsonReader reader = new Newtonsoft.Json.JsonTextReader(sr);
            reader.Read();
            if (reader.TokenType != Newtonsoft.Json.JsonToken.StartObject)
            {
                throw new InvalidOperationException(&quot;Input needs to be wrapped in an object&quot;);
            }
 
            reader.Read();
            while (reader.TokenType == Newtonsoft.Json.JsonToken.PropertyName)
            {
                string parameterName = reader.Value as string;
                reader.Read();
                if (this.parameterNames.ContainsKey(parameterName))
                {
                    int parameterIndex = this.parameterNames[parameterName];
                    parameters[parameterIndex] = serializer.Deserialize(reader, this.operation.Messages[0].Body.Parts[parameterIndex].Type);
                }
                else
                {
                    reader.Skip();
                }
 
                reader.Read();
            }
 
            reader.Close();
        }
 
        sr.Close();
        ms.Close();
    }
 
    public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
    {
        byte[] body;
        Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
        using (MemoryStream ms = new MemoryStream())
        {
            using (StreamWriter sw = new StreamWriter(ms, Encoding.UTF8))
            {
                using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
                {
                    writer.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(writer, result);
                    sw.Flush();
                    body = ms.ToArray();
                }
            }
        }
 
        Message replyMessage = Message.CreateMessage(messageVersion, operation.Messages[1].Action, new RawBodyWriter(body));
        replyMessage.Properties.Add(WebBodyFormatMessageProperty.Name, new WebBodyFormatMessageProperty(WebContentFormat.Raw));
        HttpResponseMessageProperty respProp = new HttpResponseMessageProperty();
        respProp.Headers[HttpResponseHeader.ContentType] = &quot;application/json&quot;;
        replyMessage.Properties.Add(HttpResponseMessageProperty.Name, respProp);
        return replyMessage;
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;NewtonsoftJsonDispatchFormatter&nbsp;:&nbsp;IDispatchMessageFormatter&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;OperationDescription&nbsp;operation;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">int</span>&gt;&nbsp;parameterNames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;NewtonsoftJsonDispatchFormatter(OperationDescription&nbsp;operation,&nbsp;<span class="cs__keyword">bool</span>&nbsp;isRequest)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.operation&nbsp;=&nbsp;operation;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(isRequest)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;operationParameterCount&nbsp;=&nbsp;operation.Messages[<span class="cs__number">0</span>].Body.Parts.Count;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(operationParameterCount&nbsp;&gt;&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.parameterNames&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">int</span>&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;operationParameterCount;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.parameterNames.Add(operation.Messages[<span class="cs__number">0</span>].Body.Parts[i].Name,&nbsp;i);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DeserializeRequest(Message&nbsp;message,&nbsp;<span class="cs__keyword">object</span>[]&nbsp;parameters)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">object</span>&nbsp;bodyFormatProperty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!message.Properties.TryGetValue(WebBodyFormatMessageProperty.Name,&nbsp;<span class="cs__keyword">out</span>&nbsp;bodyFormatProperty)&nbsp;||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(bodyFormatProperty&nbsp;<span class="cs__keyword">as</span>&nbsp;WebBodyFormatMessageProperty).Format&nbsp;!=&nbsp;WebContentFormat.Raw)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;InvalidOperationException(<span class="cs__string">&quot;Incoming&nbsp;messages&nbsp;must&nbsp;have&nbsp;a&nbsp;body&nbsp;format&nbsp;of&nbsp;Raw.&nbsp;Is&nbsp;a&nbsp;ContentTypeMapper&nbsp;set&nbsp;on&nbsp;the&nbsp;WebHttpBinding?&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XmlDictionaryReader&nbsp;bodyReader&nbsp;=&nbsp;message.GetReaderAtBodyContents();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bodyReader.ReadStartElement(<span class="cs__string">&quot;Binary&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;rawBody&nbsp;=&nbsp;bodyReader.ReadContentAsBase64();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MemoryStream&nbsp;ms&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream(rawBody);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StreamReader&nbsp;sr&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamReader(ms);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Newtonsoft.Json.JsonSerializer&nbsp;serializer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Newtonsoft.Json.JsonSerializer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(parameters.Length&nbsp;==&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;single&nbsp;parameter,&nbsp;assuming&nbsp;bare</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;parameters[<span class="cs__number">0</span>]&nbsp;=&nbsp;serializer.Deserialize(sr,&nbsp;operation.Messages[<span class="cs__number">0</span>].Body.Parts[<span class="cs__number">0</span>].Type);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;multiple&nbsp;parameter,&nbsp;needs&nbsp;to&nbsp;be&nbsp;wrapped</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Newtonsoft.Json.JsonReader&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Newtonsoft.Json.JsonTextReader(sr);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Read();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader.TokenType&nbsp;!=&nbsp;Newtonsoft.Json.JsonToken.StartObject)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;InvalidOperationException(<span class="cs__string">&quot;Input&nbsp;needs&nbsp;to&nbsp;be&nbsp;wrapped&nbsp;in&nbsp;an&nbsp;object&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Read();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(reader.TokenType&nbsp;==&nbsp;Newtonsoft.Json.JsonToken.PropertyName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;parameterName&nbsp;=&nbsp;reader.Value&nbsp;<span class="cs__keyword">as</span>&nbsp;<span class="cs__keyword">string</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Read();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.parameterNames.ContainsKey(parameterName))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;parameterIndex&nbsp;=&nbsp;<span class="cs__keyword">this</span>.parameterNames[parameterName];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;parameters[parameterIndex]&nbsp;=&nbsp;serializer.Deserialize(reader,&nbsp;<span class="cs__keyword">this</span>.operation.Messages[<span class="cs__number">0</span>].Body.Parts[parameterIndex].Type);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Skip();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Read();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sr.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Message&nbsp;SerializeReply(MessageVersion&nbsp;messageVersion,&nbsp;<span class="cs__keyword">object</span>[]&nbsp;parameters,&nbsp;<span class="cs__keyword">object</span>&nbsp;result)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;body;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Newtonsoft.Json.JsonSerializer&nbsp;serializer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Newtonsoft.Json.JsonSerializer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(MemoryStream&nbsp;ms&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(StreamWriter&nbsp;sw&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamWriter(ms,&nbsp;Encoding.UTF8))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(Newtonsoft.Json.JsonWriter&nbsp;writer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Newtonsoft.Json.JsonTextWriter(sw))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;writer.Formatting&nbsp;=&nbsp;Newtonsoft.Json.Formatting.Indented;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serializer.Serialize(writer,&nbsp;result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.Flush();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;body&nbsp;=&nbsp;ms.ToArray();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Message&nbsp;replyMessage&nbsp;=&nbsp;Message.CreateMessage(messageVersion,&nbsp;operation.Messages[<span class="cs__number">1</span>].Action,&nbsp;<span class="cs__keyword">new</span>&nbsp;RawBodyWriter(body));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;replyMessage.Properties.Add(WebBodyFormatMessageProperty.Name,&nbsp;<span class="cs__keyword">new</span>&nbsp;WebBodyFormatMessageProperty(WebContentFormat.Raw));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessageProperty&nbsp;respProp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseMessageProperty();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;respProp.Headers[HttpResponseHeader.ContentType]&nbsp;=&nbsp;<span class="cs__string">&quot;application/json&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;replyMessage.Properties.Add(HttpResponseMessageProperty.Name,&nbsp;respProp);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;replyMessage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>When the formatter is serializing the reply of the message , it will create a new message using a &ldquo;raw&rdquo; body writer, which is a simple implementation of the
<a href="http://msdn.microsoft.com/en-us/library/system.servicemodel.channels.bodywriter.aspx">
BodyWriter</a> class. It will then set the body format property to ensure that the raw encoder will be used when converting that message into bytes on the wire.</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:ebb335bf-af5a-4f43-8803-f4d0b73c179f" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">class RawBodyWriter : BodyWriter
{
    byte[] content;
    public RawBodyWriter(byte[] content)
        : base(true)
    {
        this.content = content;
    }
 
    protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
    {
        writer.WriteStartElement(&quot;Binary&quot;);
        writer.WriteBase64(content, 0, content.Length);
        writer.WriteEndElement();
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;RawBodyWriter&nbsp;:&nbsp;BodyWriter&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;content;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;RawBodyWriter(<span class="cs__keyword">byte</span>[]&nbsp;content)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<span class="cs__keyword">base</span>(<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.content&nbsp;=&nbsp;content;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnWriteBodyContents(XmlDictionaryWriter&nbsp;writer)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;writer.WriteStartElement(<span class="cs__string">&quot;Binary&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;writer.WriteBase64(content,&nbsp;<span class="cs__number">0</span>,&nbsp;content.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;writer.WriteEndElement();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>The client formatter is similar to the service one. On reply, since it doesn&rsquo;t support multiple return values (no out/ref support implemented), it simply gets the bytes from the message and feeds them to the JSON.NET deserializer. When serializing
 the request, the formatter will either simply serialize a single parameter if it&rsquo;s the only one, or it will wrap it in a JSON object with properties named by the operation parameter name. The last thing it does on serialization is to again set the body
 format property (to ensure that the raw encoder will be used for that message) and also set the &ldquo;To&rdquo; header of the message (which is required for REST messages, since it uses manual addressing on the transport).</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:ec20db00-3bf9-48ee-9fee-f6cda2daf24f" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">class NewtonsoftJsonClientFormatter : IClientMessageFormatter
{
    OperationDescription operation;
    Uri operationUri;
    public NewtonsoftJsonClientFormatter(OperationDescription operation, ServiceEndpoint endpoint)
    {
        this.operation = operation;
        string endpointAddress = endpoint.Address.Uri.ToString();
        if (!endpointAddress.EndsWith(&quot;/&quot;))
        {
            endpointAddress = endpointAddress &#43; &quot;/&quot;;
        }
 
        this.operationUri = new Uri(endpointAddress &#43; operation.Name);
    }
 
    public object DeserializeReply(Message message, object[] parameters)
    {
        object bodyFormatProperty;
        if (!message.Properties.TryGetValue(WebBodyFormatMessageProperty.Name, out bodyFormatProperty) ||
            (bodyFormatProperty as WebBodyFormatMessageProperty).Format != WebContentFormat.Raw)
        {
            throw new InvalidOperationException(&quot;Incoming messages must have a body format of Raw. Is a ContentTypeMapper set on the WebHttpBinding?&quot;);
        }
 
        XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
        Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
        bodyReader.ReadStartElement(&quot;Binary&quot;);
        byte[] body = bodyReader.ReadContentAsBase64();
        using (MemoryStream ms = new MemoryStream(body))
        {
            using (StreamReader sr = new StreamReader(ms))
            {
                Type returnType = this.operation.Messages[1].Body.ReturnValue.Type;
                return serializer.Deserialize(sr, returnType);
            }
        }
    }
 
    public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
    {
        byte[] body;
        Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
        using (MemoryStream ms = new MemoryStream())
        {
            using (StreamWriter sw = new StreamWriter(ms, Encoding.UTF8))
            {
                using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
                {
                    writer.Formatting = Newtonsoft.Json.Formatting.Indented;
                    if (parameters.Length == 1)
                    {
                        // Single parameter, assuming bare
                        serializer.Serialize(sw, parameters[0]);
                    }
                    else
                    {
                        writer.WriteStartObject();
                        for (int i = 0; i &lt; this.operation.Messages[0].Body.Parts.Count; i&#43;&#43;)
                        {
                            writer.WritePropertyName(this.operation.Messages[0].Body.Parts[i].Name);
                            serializer.Serialize(writer, parameters[0]);
                        }
 
                        writer.WriteEndObject();
                    }
 
                    writer.Flush();
                    sw.Flush();
                    body = ms.ToArray();
                }
            }
        }
 
        Message requestMessage = Message.CreateMessage(messageVersion, operation.Messages[0].Action, new RawBodyWriter(body));
        requestMessage.Headers.To = operationUri;
        requestMessage.Properties.Add(WebBodyFormatMessageProperty.Name, new WebBodyFormatMessageProperty(WebContentFormat.Raw));
        HttpRequestMessageProperty reqProp = new HttpRequestMessageProperty();
        reqProp.Headers[HttpRequestHeader.ContentType] = &quot;application/json&quot;;
        requestMessage.Properties.Add(HttpRequestMessageProperty.Name, reqProp);
        return requestMessage;
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;NewtonsoftJsonClientFormatter&nbsp;:&nbsp;IClientMessageFormatter&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;OperationDescription&nbsp;operation;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;operationUri;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;NewtonsoftJsonClientFormatter(OperationDescription&nbsp;operation,&nbsp;ServiceEndpoint&nbsp;endpoint)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.operation&nbsp;=&nbsp;operation;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;endpointAddress&nbsp;=&nbsp;endpoint.Address.Uri.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!endpointAddress.EndsWith(<span class="cs__string">&quot;/&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;endpointAddress&nbsp;=&nbsp;endpointAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.operationUri&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(endpointAddress&nbsp;&#43;&nbsp;operation.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;DeserializeReply(Message&nbsp;message,&nbsp;<span class="cs__keyword">object</span>[]&nbsp;parameters)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">object</span>&nbsp;bodyFormatProperty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!message.Properties.TryGetValue(WebBodyFormatMessageProperty.Name,&nbsp;<span class="cs__keyword">out</span>&nbsp;bodyFormatProperty)&nbsp;||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(bodyFormatProperty&nbsp;<span class="cs__keyword">as</span>&nbsp;WebBodyFormatMessageProperty).Format&nbsp;!=&nbsp;WebContentFormat.Raw)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;InvalidOperationException(<span class="cs__string">&quot;Incoming&nbsp;messages&nbsp;must&nbsp;have&nbsp;a&nbsp;body&nbsp;format&nbsp;of&nbsp;Raw.&nbsp;Is&nbsp;a&nbsp;ContentTypeMapper&nbsp;set&nbsp;on&nbsp;the&nbsp;WebHttpBinding?&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XmlDictionaryReader&nbsp;bodyReader&nbsp;=&nbsp;message.GetReaderAtBodyContents();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Newtonsoft.Json.JsonSerializer&nbsp;serializer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Newtonsoft.Json.JsonSerializer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bodyReader.ReadStartElement(<span class="cs__string">&quot;Binary&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;body&nbsp;=&nbsp;bodyReader.ReadContentAsBase64();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(MemoryStream&nbsp;ms&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream(body))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(StreamReader&nbsp;sr&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamReader(ms))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type&nbsp;returnType&nbsp;=&nbsp;<span class="cs__keyword">this</span>.operation.Messages[<span class="cs__number">1</span>].Body.ReturnValue.Type;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;serializer.Deserialize(sr,&nbsp;returnType);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Message&nbsp;SerializeRequest(MessageVersion&nbsp;messageVersion,&nbsp;<span class="cs__keyword">object</span>[]&nbsp;parameters)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;body;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Newtonsoft.Json.JsonSerializer&nbsp;serializer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Newtonsoft.Json.JsonSerializer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(MemoryStream&nbsp;ms&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(StreamWriter&nbsp;sw&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamWriter(ms,&nbsp;Encoding.UTF8))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(Newtonsoft.Json.JsonWriter&nbsp;writer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Newtonsoft.Json.JsonTextWriter(sw))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;writer.Formatting&nbsp;=&nbsp;Newtonsoft.Json.Formatting.Indented;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(parameters.Length&nbsp;==&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Single&nbsp;parameter,&nbsp;assuming&nbsp;bare</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serializer.Serialize(sw,&nbsp;parameters[<span class="cs__number">0</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;writer.WriteStartObject();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="cs__keyword">this</span>.operation.Messages[<span class="cs__number">0</span>].Body.Parts.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;writer.WritePropertyName(<span class="cs__keyword">this</span>.operation.Messages[<span class="cs__number">0</span>].Body.Parts[i].Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serializer.Serialize(writer,&nbsp;parameters[<span class="cs__number">0</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;writer.WriteEndObject();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;writer.Flush();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.Flush();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;body&nbsp;=&nbsp;ms.ToArray();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Message&nbsp;requestMessage&nbsp;=&nbsp;Message.CreateMessage(messageVersion,&nbsp;operation.Messages[<span class="cs__number">0</span>].Action,&nbsp;<span class="cs__keyword">new</span>&nbsp;RawBodyWriter(body));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;requestMessage.Headers.To&nbsp;=&nbsp;operationUri;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;requestMessage.Properties.Add(WebBodyFormatMessageProperty.Name,&nbsp;<span class="cs__keyword">new</span>&nbsp;WebBodyFormatMessageProperty(WebContentFormat.Raw));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpRequestMessageProperty&nbsp;reqProp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpRequestMessageProperty();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reqProp.Headers[HttpRequestHeader.ContentType]&nbsp;=&nbsp;<span class="cs__string">&quot;application/json&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;requestMessage.Properties.Add(HttpRequestMessageProperty.Name,&nbsp;reqProp);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;requestMessage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>Now for testing the formatters. The first thing we need is the content type mapper, to ensure that all incoming requests will be read by the raw encoder. Its implementation is quite simple.</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:63c5bb2b-0f20-42e0-9d50-7a255936e564" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">class MyRawMapper : WebContentTypeMapper
{
    public override WebContentFormat GetMessageFormatForContentType(string contentType)
    {
        return WebContentFormat.Raw;
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;MyRawMapper&nbsp;:&nbsp;WebContentTypeMapper&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;WebContentFormat&nbsp;GetMessageFormatForContentType(<span class="cs__keyword">string</span>&nbsp;contentType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;WebContentFormat.Raw;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>Now for the test itself. I&rsquo;m using a helper method (SendRequest) to send arbitrary HTTP requests to the server, but I&rsquo;ll skip it here (it&rsquo;s just setting up HttpWebRequest and displaying the results from HttpWebResponse). The test code sets
 up a service and adds two endpoints, one &ldquo;normal&rdquo; (SOAP) and one JSON.NET enabled</p>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:7d13e0b3-3ba3-4030-b113-056e68c3cc68" style="margin:0px; display:inline; float:none; padding:0px">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">static void Main(string[] args)
{
    string baseAddress = &quot;http://&quot; &#43; Environment.MachineName &#43; &quot;:8000/Service&quot;;
    ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
    host.AddServiceEndpoint(typeof(ITestService), new BasicHttpBinding(), &quot;soap&quot;);
    WebHttpBinding webBinding = new WebHttpBinding();
    webBinding.ContentTypeMapper = new MyRawMapper();
    host.AddServiceEndpoint(typeof(ITestService), webBinding, &quot;json&quot;).Behaviors.Add(new NewtonsoftJsonBehavior());
    Console.WriteLine(&quot;Opening the host&quot;);
    host.Open();
 
    ChannelFactory&lt;ITestService&gt; factory = new ChannelFactory&lt;ITestService&gt;(new BasicHttpBinding(), new EndpointAddress(baseAddress &#43; &quot;/soap&quot;));
    ITestService proxy = factory.CreateChannel();
    Console.WriteLine(proxy.GetPerson());
 
    SendRequest(baseAddress &#43; &quot;/json/GetPerson&quot;, &quot;GET&quot;, null, null);
    SendRequest(baseAddress &#43; &quot;/json/EchoPet&quot;, &quot;POST&quot;, &quot;application/json&quot;, &quot;{\&quot;Name\&quot;:\&quot;Fido\&quot;,\&quot;Color\&quot;:\&quot;Black and white\&quot;,\&quot;Markings\&quot;:\&quot;None\&quot;,\&quot;Id\&quot;:1}&quot;);
    SendRequest(baseAddress &#43; &quot;/json/Add&quot;, &quot;POST&quot;, &quot;application/json&quot;, &quot;{\&quot;x\&quot;:111,\&quot;z\&quot;:null,\&quot;w\&quot;:[1,2],\&quot;v\&quot;:{\&quot;a\&quot;:1},\&quot;y\&quot;:222}&quot;);
 
    Console.WriteLine(&quot;Now using the client formatter&quot;);
    ChannelFactory&lt;ITestService&gt; newFactory = new ChannelFactory&lt;ITestService&gt;(webBinding, new EndpointAddress(baseAddress &#43; &quot;/json&quot;));
    newFactory.Endpoint.Behaviors.Add(new NewtonsoftJsonBehavior());
    ITestService newProxy = newFactory.CreateChannel();
    Console.WriteLine(newProxy.Add(444, 555));
    Console.WriteLine(newProxy.EchoPet(new Pet { Color = &quot;gold&quot;, Id = 2, Markings = &quot;Collie&quot;, Name = &quot;Lassie&quot; }));
    Console.WriteLine(newProxy.GetPerson());
 
    Console.WriteLine(&quot;Press ENTER to close&quot;);
    Console.ReadLine();
    host.Close();
    Console.WriteLine(&quot;Host closed&quot;);
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;baseAddress&nbsp;=&nbsp;<span class="cs__string">&quot;http://&quot;</span>&nbsp;&#43;&nbsp;Environment.MachineName&nbsp;&#43;&nbsp;<span class="cs__string">&quot;:8000/Service&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ServiceHost&nbsp;host&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServiceHost(<span class="cs__keyword">typeof</span>(Service),&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(baseAddress));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;host.AddServiceEndpoint(<span class="cs__keyword">typeof</span>(ITestService),&nbsp;<span class="cs__keyword">new</span>&nbsp;BasicHttpBinding(),&nbsp;<span class="cs__string">&quot;soap&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WebHttpBinding&nbsp;webBinding&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WebHttpBinding();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;webBinding.ContentTypeMapper&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MyRawMapper();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;host.AddServiceEndpoint(<span class="cs__keyword">typeof</span>(ITestService),&nbsp;webBinding,&nbsp;<span class="cs__string">&quot;json&quot;</span>).Behaviors.Add(<span class="cs__keyword">new</span>&nbsp;NewtonsoftJsonBehavior());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Opening&nbsp;the&nbsp;host&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;host.Open();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ChannelFactory&lt;ITestService&gt;&nbsp;factory&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ChannelFactory&lt;ITestService&gt;(<span class="cs__keyword">new</span>&nbsp;BasicHttpBinding(),&nbsp;<span class="cs__keyword">new</span>&nbsp;EndpointAddress(baseAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/soap&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ITestService&nbsp;proxy&nbsp;=&nbsp;factory.CreateChannel();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(proxy.GetPerson());&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SendRequest(baseAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/json/GetPerson&quot;</span>,&nbsp;<span class="cs__string">&quot;GET&quot;</span>,&nbsp;<span class="cs__keyword">null</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SendRequest(baseAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/json/EchoPet&quot;</span>,&nbsp;<span class="cs__string">&quot;POST&quot;</span>,&nbsp;<span class="cs__string">&quot;application/json&quot;</span>,&nbsp;<span class="cs__string">&quot;{\&quot;Name\&quot;:\&quot;Fido\&quot;,\&quot;Color\&quot;:\&quot;Black&nbsp;and&nbsp;white\&quot;,\&quot;Markings\&quot;:\&quot;None\&quot;,\&quot;Id\&quot;:1}&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SendRequest(baseAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/json/Add&quot;</span>,&nbsp;<span class="cs__string">&quot;POST&quot;</span>,&nbsp;<span class="cs__string">&quot;application/json&quot;</span>,&nbsp;<span class="cs__string">&quot;{\&quot;x\&quot;:111,\&quot;z\&quot;:null,\&quot;w\&quot;:[1,2],\&quot;v\&quot;:{\&quot;a\&quot;:1},\&quot;y\&quot;:222}&quot;</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Now&nbsp;using&nbsp;the&nbsp;client&nbsp;formatter&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ChannelFactory&lt;ITestService&gt;&nbsp;newFactory&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ChannelFactory&lt;ITestService&gt;(webBinding,&nbsp;<span class="cs__keyword">new</span>&nbsp;EndpointAddress(baseAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/json&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;newFactory.Endpoint.Behaviors.Add(<span class="cs__keyword">new</span>&nbsp;NewtonsoftJsonBehavior());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ITestService&nbsp;newProxy&nbsp;=&nbsp;newFactory.CreateChannel();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(newProxy.Add(<span class="cs__number">444</span>,&nbsp;<span class="cs__number">555</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(newProxy.EchoPet(<span class="cs__keyword">new</span>&nbsp;Pet&nbsp;{&nbsp;Color&nbsp;=&nbsp;<span class="cs__string">&quot;gold&quot;</span>,&nbsp;Id&nbsp;=&nbsp;<span class="cs__number">2</span>,&nbsp;Markings&nbsp;=&nbsp;<span class="cs__string">&quot;Collie&quot;</span>,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Lassie&quot;</span>&nbsp;}));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(newProxy.GetPerson());&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Press&nbsp;ENTER&nbsp;to&nbsp;close&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;host.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Host&nbsp;closed&quot;</span>);&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>And that&rsquo;s it for the formatter example!</p>
