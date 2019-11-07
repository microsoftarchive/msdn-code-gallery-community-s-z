# Windows Azure Inter-Role Communication Using Service Bus Topics & Subscriptions
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Microsoft Azure
- Service Bus
## Topics
- Messaging
- Inter-role Communication
## Updated
- 10/03/2011
## Description

<p>The sample demonstrates how Windows Azure developers can leverage the Windows Azure Service Bus to enable asynchronous inter-role communication in cloud-based solutions using Service Bus topics and subscriptions. The code sample offer a complete solution,
 one that enables simplified, scalable, loosely coupled communication between role instances on the Windows Azure platform.</p>
<h2>Step-By-Step Implementation Guide<a name="implementation"></a></h2>
<p>Below is&nbsp;a step-by-step instruction on how to enable a Windows Azure solution to support the inter-role communication mechanism discussed in this post.</p>
<h3>Step 1: Create a Service Bus Namespace<a name="step1"></a></h3>
<p>You will first need to <a href="https://windows.azure.com" target="_blank">provision a Service Bus namespace</a>. If you already have an existing namespace, it can be reused for inter-role communication. In either case, you will need to note down the three
 key elements: namespace name, issuer name and issuer secret.</p>
<p><img title="7-12-2011 3-53-17 PM111" src="-7-12-2011-3-53-17-pm1116.png" border="0" alt="7-12-2011 3-53-17 PM111" width="624" height="527" style="border-width:0px; padding-top:0px; padding-right:0px; padding-left:0px; margin-right:auto; margin-left:auto; float:none; display:block"></p>
<p>The three highlighted parameters will be required for configuring the inter-role communication component in
<a href="#step3">step 3</a>.</p>
<h3>Step 2: Add an Inter-Role Communication Component to a Window Azure Solution<a name="step2"></a></h3>
<p>In this step, you will add a reference to <em><a href="http://code.msdn.microsoft.com/Windows-Azure-Inter-Role-9935c439" target="_blank">Microsoft.AzureCAT.Samples.InterRoleCommunication.dll</a></em> assembly to every project implementing either web or worker
 roles in a Visual Studio solution. In addition, add a reference to <em>Microsoft.ServiceBus.dll</em> from the AppFabric SDK. The location of this assembly depends on the version of the SDK installed on your machine. For example, the
<a href="http://www.microsoft.com/download/en/details.aspx?id=27421" target="_blank">
Windows Azure AppFabric SDK v1.5</a>&nbsp;resides in <em>%ProgramFiles%\Windows Azure AppFabric SDK\V1.5\Assemblies\NET4.0\</em>.</p>
<table class="note">
<tbody>
<tr valign="top">
<td class="notetitle"><span><img title="ImpNoteNoBg" src="-impnotenobg1.png" border="0" alt="ImpNoteNoBg" width="25" height="17" style="border-width:0px; padding-top:0px; padding-right:0px; padding-left:0px; display:inline">Important</span></td>
</tr>
<tr>
<td valign="top">It is very important to set the <strong><span style="font-family:Segoe UI">Copy Local</span></strong> property of the respective assembly references to
<strong><span style="font-family:Segoe UI">True</span></strong>. Otherwise, the role instances may not initialize and spin themselves off successfully when deployed on Windows Azure.</td>
</tr>
</tbody>
</table>
<h3>Step 3:&nbsp; Configure the Inter-Role Communication Component<a name="step3"></a></h3>
<p>Once a reference to the assembly containing the IRC component has been added to the respective projects, the next step is to provide some configuration information to enable the IRC component to connect to the target Service Bus topic. Such a configuration
 will need to be supplied in the <em>app.config</em> file in each Visual Studio project implementing a web or worker role. The respective
<em>app.config</em> file is to be modified as shown:</p>
<pre class="csharpcode"><span class="kwrd">&lt;</span><span class="html">configuration</span><span class="kwrd">&gt;</span>
  <span class="kwrd">&lt;</span><span class="html">configSections</span><span class="kwrd">&gt;</span>
    <span class="rem">&lt;!-- Add this line into your own app.config --&gt;
    <span class="kwrd">&lt;</span><span class="html">section</span> <span class="attr">name</span><span class="kwrd">=&quot;ServiceBusConfiguration&quot;</span> <span class="attr">type</span><span class="kwrd">=&quot;Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration.ServiceBusConfigurationSettings, Microsoft.AzureCAT.Samples.InterRoleCommunication&quot;</span> <span class="kwrd">/&gt;</span>
  <span class="kwrd">&lt;/</span><span class="html">configSections</span><span class="kwrd">&gt;</span>

  <span class="rem">&lt;!-- Add this entire section into your own app.config --&gt;
  <span class="kwrd">&lt;</span><span class="html">ServiceBusConfiguration</span> <span class="attr">defaultEndpoint</span><span class="kwrd">=&quot;IRC&quot;</span><span class="kwrd">&gt;</span>
    <span class="kwrd">&lt;</span><span class="html">add</span> <span class="attr">name</span><span class="kwrd">=&quot;IRC&quot;</span> <span class="attr">serviceNamespace</span><span class="kwrd">=&quot;<span style="background-color:#ffff00">irc-test</span>&quot;</span> <span class="attr">endpointType</span><span class="kwrd">=&quot;Topic&quot;</span> <span class="attr">topicName</span><span class="kwrd">=&quot;<span style="background-color:#ffff00">InterRoleCommunication</span>&quot;</span> <span class="attr">issuerName</span><span class="kwrd">=&quot;<span style="background-color:#ffff00">owner</span>&quot;</span> <span class="attr">issuerSecret</span><span class="kwrd">=&quot;<span style="background-color:#ffff00">wjc/h98iL95XudZPJ1txaDB...</span>&quot;</span> <span class="kwrd">/&gt;</span>
  <span class="kwrd">&lt;/</span><span class="html">ServiceBusConfiguration</span><span class="kwrd">&gt;</span>
<span class="kwrd">&lt;/</span><span class="html">configuration</span><span class="kwrd">&gt;</span></span></span></pre>
<p>In your version of <em>app.config</em> file, 3 parameters in the above fragment will have to be modified:</p>
<ol>
<li>
<div align="justify">Service Bus namespace (see <a href="#step1">step 1</a>).</div>
</li><li>
<div align="justify">Issuer name (see <a href="#step1">step 1</a>).</div>
</li><li>
<div align="justify">Issuer secret (see <a href="#step1">step 1</a>)</div>
</li></ol>
<p>If required, you can also modify the name of the Service Bus topic that will be used to exchange the IRC events.</p>
<table class="note">
<tbody>
<tr valign="top">
<td class="notetitle"><span><img title="Double Quote" src="-double-quote1.png" border="0" alt="Double Quote" width="24" height="16" style="border-width:0px; padding-top:0px; padding-right:0px; padding-left:0px; display:inline">&nbsp;
 Note</span></td>
</tr>
<tr>
<td valign="top">If you have multiple Visual Studio projects implementing web/worker roles which need to participate in the inter-role communication, you will need to ensure that the
<em>app.config</em> file is present in each project. Instead of creating multiple copies of
<em>app.config</em> and placing them in each individual project, you can add <em>
app.config</em> as a link rather than directly adding the file to your projects. Linked project items in Solution Explorer can be identified by the link indicator in its icon (a small arrow in the lower left corner). By linking to a file, you can capture ongoing
 changes to the configuration file without having to manually update a copy whenever changes are made. To create a link to a file, select the target project, open the
<strong><span style="font-family:Segoe UI">Add Existing Item</span></strong> dialog box, locate and select the master
<em>app.config</em> file you want to link. From the <strong><span style="font-family:Segoe UI">Open</span></strong> button drop-down list, select
<strong><span style="font-family:Segoe UI">Add As Link</span></strong>.</td>
</tr>
</tbody>
</table>
<p>In addition to configuration settings expressed inside an <em>app.config</em> file, the IRC component supports several useful runtime settings that are intended to be programmatically modified if their default values are not sufficient. These runtime settings
 are combined in the <em>InterRoleCommunicationSettings</em> object and are listed below:</p>
<table border="1" cellspacing="0" cellpadding="5" bgcolor="#ffffff" style="width:98%">
<tbody>
<tr bgcolor="#f2f2f2">
<td width="10%"><strong>Setting</strong></td>
<td><strong>Description</strong></td>
<td width="10%"><strong>Default Value</strong></td>
</tr>
<tr>
<td><strong>EventTimeToLive</strong></td>
<td>Specifies a custom time-to-live (TTL) value for inter-role communication events. Events older than their TTL will be removed before they can reach the subscribers.</td>
<td>10 minutes</td>
</tr>
<tr>
<td><strong>EventWaitTimeout</strong></td>
<td>Specifies a custom time value indicating how long Service Bus messaging API will keep a communication channel open while waiting for a new event.</td>
<td>30 seconds</td>
</tr>
<tr>
<td><strong>EventLockDuration</strong></td>
<td>Specifies a custom duration in which the inter-role communication events that are being processed remain marked as &ldquo;in-flight&rdquo; and invisible to other competing consumers (if any).</td>
<td>5 minutes</td>
</tr>
<tr>
<td><strong>EnableAsyncPublish</strong></td>
<td>Enables publishing the inter-role communication events in an asynchronous, non-blocking fashion eliminating the need to wait until events are put into a topic.</td>
<td>False</td>
</tr>
<tr>
<td><strong>EnableAsyncDispatch</strong></td>
<td>Enables dispatching the inter-role communication events to their subscribers immediately as soon as a new event arrives, without waiting until the previous event is processed.</td>
<td>True</td>
</tr>
<tr>
<td><strong>EnableParallelDispatch</strong></td>
<td>Enables dispatching the inter-role communication events to multiple subscribers in parallel without serializing execution of subscribers.</td>
<td>True</td>
</tr>
<tr>
<td><strong>EnableCarbonCopy</strong></td>
<td>Enables the publishing role instances to receive their own events as carbon copies.</td>
<td>False</td>
</tr>
<tr>
<td><strong>UseCompetingConsumers</strong></td>
<td>Enables multiple role instances to receive the inter-role communication events from the same subscription with the guarantee that each event is consumed only by one of the role instances.</td>
<td>False</td>
</tr>
<tr>
<td><strong>RetryPolicy</strong></td>
<td>Specifies a retry policy that will be used for ensuring reliable access to the underlying messaging infrastructure.</td>
<td>Fixed Interval</td>
</tr>
</tbody>
</table>
<h3>Step 4: Initialize the Inter-Role Communication Component<a name="step4"></a></h3>
<p>In this step, you will extend the startup logic of your web or worker role implementation with a code snippet that is responsible for initializing the IRC component. The following example demonstrates how to initialize the IRC component from within a worker
 role.</p>
<pre class="csharpcode"><span class="kwrd">using</span> Microsoft.AzureCAT.Samples.InterRoleCommunication;
<span class="kwrd">using</span> Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration;

<span class="kwrd">public</span> <span class="kwrd">class</span> <span style="color:#408080">SampleWorkerRole</span> : <span style="color:#408080">RoleEntryPoint</span>
{
    <span style="background-color:#ffff00"><span class="kwrd">private</span> <span style="color:#408080">IInterRoleCommunicationExtension</span> interRoleCommunicator;</span>

    <span class="rem">/// &lt;summary&gt;</span>
    <span class="rem">/// Called by Windows Azure service runtime to initialize the role instance.</span>
    <span class="rem">/// &lt;/summary&gt;</span>
    <span class="rem">/// &lt;returns&gt;Return true if initialization succeeds, otherwise returns false.&lt;/returns&gt;</span>
    <span class="kwrd">public</span> <span class="kwrd">override</span> <span class="kwrd">bool</span> OnStart()
    {
        <span class="rem">// ...There is usually some code here...</span>

        <span class="kwrd">try</span>
        {
            <span class="rem">// Read the configuration settings from app.config.</span>
            <span style="color:#0000ff">var </span>serviceBusSettings = <span style="color:#408080">ConfigurationManager</span>.GetSection(<span style="color:#408080">ServiceBusConfigurationSettings</span>.SectionName) <span class="kwrd">as</span> <span style="color:#408080">ServiceBusConfigurationSettings</span>;

            <span class="rem">// Resolve the Service Bus topic that will be used for inter-role communication.</span>
            <span style="color:#0000ff">var </span>topicEndpoint = serviceBusSettings.Endpoints.Get(serviceBusSettings.DefaultEndpoint);

            <span class="rem">// Initialize the IRC component with the specified topic endpoint.</span>
            <span class="rem">// Instantiating the IRC component inside the OnStart method ensures that IRC component is a singleton.</span>
            <span class="rem">// The Singleton pattern prevents the creation of competing consumers for the same IRC events.</span>
            <span style="background-color:#ffff00"><span class="kwrd">this</span>.interRoleCommunicator = <span class="kwrd">new</span> <span style="color:#408080">InterRoleCommunicationExtension</span>(topicEndpoint);</span>
        }
        <span class="kwrd">catch</span> (<span style="color:#408080">Exception</span> ex)
        {
            <span class="rem">// Report on the error through default logging/tracing infrastructure.</span>
            <span style="color:#408080">Trace</span>.TraceError(<span style="color:#408080">String</span>.Join(ex.Message, <span style="color:#408080">Environment</span>.NewLine, ex.StackTrace));

            <span class="rem">// Request that the current role instance is to be stopped and restarted.</span>
            <span style="color:#408080">RoleEnvironment</span>.RequestRecycle();
        }

        <span class="rem">// ...There is usually some more code here...</span>
        <span class="kwrd">return</span> <span class="kwrd">true</span>;
    }

   <span class="rem">// ...There is usually some more code here...</span>
}</pre>
<p>In summary, you will need to add a private field of type <em>IInterRoleCommunicationExtension</em> which will be initialized with an instance of the IRC component using the configuration information loaded from
<em>app.config</em>.</p>
<p>In web roles, the IRC component initialization logic must be placed into the <em>
Global.asax.cs</em> file, most specifically into its <em>Application_Start</em> method. The
<em>Application_Start</em> method is called only once during the lifecycle of the IIS application pool that belongs to the web role instance. Another popular approach is to implement a
<a href="http://msdn.microsoft.com/en-us/library/dd997286.aspx" target="_blank">lazy initialization</a> whereby the IRC component instance will only be created when it&rsquo;s first accessed as shown in the example below:</p>
<pre class="csharpcode"><span class="kwrd">public</span> <span class="kwrd">class</span> <span style="color:#408080; background-color:#ffff00">Global</span> : System.Web.<span style="color:#408080">HttpApplication</span>
{
    <span class="kwrd">private</span> <span class="kwrd">static</span> <span style="background-color:#ffff00"><span style="color:#408080">Lazy</span>&lt;<span style="color:#408080">IInterRoleCommunicationExtension</span>&gt;</span> ircLazyLoader = <span class="kwrd">new</span> <span style="color:#408080">Lazy</span>&lt;<span style="color:#408080">IInterRoleCommunicationExtension</span>&gt;(() =&gt;
    {
        <span style="color:#0000ff">var</span> serviceBusSettings = <span style="color:#408080">ConfigurationManager</span>.GetSection(<span style="color:#408080">ServiceBusConfigurationSettings</span>.SectionName) <span class="kwrd">as</span> <span style="color:#408080">ServiceBusConfigurationSettings</span>;
        <span style="color:#0000ff">var</span> topicEndpoint = serviceBusSettings.Endpoints.Get(serviceBusSettings.DefaultEndpoint);

        <span class="kwrd">return</span> <span class="kwrd">new</span> <span style="color:#408080">InterRoleCommunicationExtension</span>(topicEndpoint);
    },
    LazyThreadSafetyMode.ExecutionAndPublication);

    <span class="kwrd">public</span> <span class="kwrd">static</span> <span style="color:#408080">IInterRoleCommunicationExtension</span> InterRoleCommunicator
    {
        <span style="color:#0000ff">get</span> { <span class="kwrd">return</span> ircLazyLoader.Value; }
    }

    <span class="rem">// ...There is usually some more code here...</span>
}</pre>
<table class="note">
<tbody>
<tr valign="top">
<td class="notetitle"><span><img title="ImpNoteNoBg" src="-impnotenobg1.png" border="0" alt="ImpNoteNoBg" width="25" height="17" style="border-width:0px; padding-top:0px; padding-right:0px; padding-left:0px; display:inline">Important</span></td>
</tr>
<tr>
<td valign="top">It is recommended that the IRC component is not to be instantiated by a role instance more than once per single topic. Under the hood, the component maintains a messaging client with an active subscription affinitized to a particular role instance
 ID. Multiple instances of the IRC component created by a role instance for the same topic will share the same subscription. This will create competing consumers for the subscription and may result in inter-role communication events being consumed by incorrect
 instances of the IRC component. Therefore, an instance of the <em>InterRoleCommunicationExtension</em> class must always be a singleton for a given topic. Make sure you implement a
<a href="http://msdn.microsoft.com/en-us/library/ff650316.aspx" target="_blank">Singleton pattern</a> when creating an instance of this class. Note that multiple instances of the IRC component in a single role instance are allowed, provided that you initialize
 the IRC component instances using different topic endpoints.</td>
</tr>
</tbody>
</table>
<h3>Step 5: Subscribe to Inter-Role Communication Events<a name="step5"></a></h3>
<p>In order to start receiving inter-role communication events, you will need to implement and activate a subscriber to these events. The subscriber is a class implementing the
<em><a href="http://msdn.microsoft.com/en-us/library/dd783449.aspx" target="_blank">IObserver&lt;InterRoleCommunicationEvent&gt;</a></em> interface with 3 methods:
<a href="http://msdn.microsoft.com/en-us/library/dd782792.aspx" target="_blank"><em>OnNext</em></a>,
<a href="http://msdn.microsoft.com/en-us/library/dd782982.aspx" target="_blank"><em>OnCompleted</em></a> and
<a href="http://msdn.microsoft.com/en-us/library/dd781657.aspx" target="_blank"><em>OnError</em></a>. The following code is an example of the IRC event subscriber:</p>
<pre class="csharpcode"><span class="rem">/// &lt;summary&gt;</span>
<span class="rem">/// Implements a subscriber for inter-role communication (IRC) events.</span>
<span class="rem">/// &lt;/summary&gt;</span>
<span class="kwrd">public</span> <span class="kwrd">class</span> <span style="color:#408080">InterRoleCommunicationEventSubscriber</span> : <span style="color:#408080">IObserver</span>&lt;<span style="color:#408080">InterRoleCommunicationEvent</span>&gt;
{
    <span class="rem">/// &lt;summary&gt;</span>
    <span class="rem">/// Receives a notification when a new inter-role communication event occurs.</span>
    <span class="rem">/// &lt;/summary&gt;</span>
    <span class="kwrd">public</span> <span class="kwrd">void</span> <span style="background-color:#ffff00">OnNext(<span style="color:#408080">InterRoleCommunicationEvent</span> e)</span>
    {
        <span class="rem"><span style="background-color:#ffff00">// Put your custom logic here to handle an IRC event.</span></span>
    }

    <span class="rem">/// &lt;summary&gt;</span>
    <span class="rem">/// Gets notified that the IRC component has successfully finished notifying all observers.</span>
    <span class="rem">/// &lt;/summary&gt;</span>
    <span class="kwrd">public</span> <span class="kwrd">void</span> <span style="background-color:#ffff00">OnCompleted()</span>
    {
        <span class="rem">// Doesn't have to do anything upon completion.</span>
    }

    <span class="rem">/// &lt;summary&gt;</span>
    <span class="rem">/// Gets notified that the IRC component has experienced an error condition.</span>
    <span class="rem">/// &lt;/summary&gt;</span>
    <span class="kwrd">public</span> <span class="kwrd">void</span> <span style="background-color:#ffff00">OnError(<span style="color:#408080">Exception</span> error)</span>
    {
        <span class="rem">// Report on the error through default logging/tracing infrastructure.</span>
        <span style="color:#408080">Trace</span>.TraceError(<span style="color:#408080">String</span>.Join(error.Message, <span style="color:#408080">Environment</span>.NewLine, error.StackTrace));
    }
}</pre>
<p>Once a subscriber is implemented, the next step is to register it with the IRC component by letting the
<em>Subscribe</em> method do all the heavy lifting behind the scene:</p>
<pre class="csharpcode"><span class="kwrd">public</span> <span class="kwrd">class</span> <span style="color:#408080">SampleWorkerRole</span> : <span style="color:#408080">RoleEntryPoint</span>
{
    <span style="background-color:#ffff00"><span class="kwrd">private</span> <span style="color:#408080">IObserver</span>&lt;<span style="color:#408080">InterRoleCommunicationEvent</span>&gt; ircEventSubscriber;</span>
    <span style="background-color:#ffff00"><span class="kwrd">private</span> <span style="color:#408080">IDisposable</span> ircSubscription;</span>

    <span class="rem">/// &lt;summary&gt;</span>
    <span class="rem">/// Called by Windows Azure after the role instance has been initialized. </span>
    <span class="rem">/// This method serves as the main thread of execution for your role.</span>
    <span class="rem">/// &lt;/summary&gt;</span>
    <span class="kwrd">public</span> <span class="kwrd">override</span> <span class="kwrd">void</span> Run()
    {
        <span class="rem">// ...There is usually some code here...</span>

        <span class="rem">// Create an instance of the component which will be receiving the IRC events.</span>
        <span style="background-color:#ffff00"><span class="kwrd">this</span>.ircEventSubscriber = <span class="kwrd">new</span> <span style="color:#408080">InterRoleCommunicationEventSubscriber</span>();</span>

        <span class="rem">// Register the subscriber for receiving inter-role communication events.</span>
        <span style="background-color:#ffff00"><span class="kwrd">this</span>.ircSubscription = <span class="kwrd">this</span>.interRoleCommunicator.Subscribe(<span class="kwrd">this</span>.ircEventSubscriber);</span>

        <span class="rem">// ...There is usually some more code here...</span>
    }
}</pre>
<p>At this point, everything is ready to go for the very first inter-role communication event to be published. Let&rsquo;s start with multicasting an IRC event to all active role instances.</p>
<h3>Step 6: Publishing Multicast Inter-Role Communication Events<a name="step6"></a></h3>
<p>Publishing an IRC event requires creating an instance of the <em>InterRoleCommunicationEvent</em> class with the specified event payload, which can be either a simple .NET type or a custom DataContract-serializable object. The following fragment depicts
 a simplistic use case in which a string-based payload is packaged as an IRC event and published to all role instances participating in the IRC event exchange:</p>
<pre class="csharpcode"><span class="rem">// Create an instance of the IRC event using a string-based payload.</span>
<span style="color:#408080">InterRoleCommunicationEvent</span> e = <span class="kwrd">new</span> <span style="color:#408080">InterRoleCommunicationEvent</span>(<span class="str"><span style="color:#800000">&quot;This is a test multicast event&quot;</span></span>);

<span class="rem">// Publish the event. That was easy.</span>
<span class="kwrd">this</span>.interRoleCommunicator.Publish(e);</pre>
<p>In most cases, you will be publishing complex, strongly typed events carrying a lot more than a string. That is covered in
<a href="#step8">step 8</a>.</p>
<h3>Step 7: Publishing Unicast Inter-Role Communication Events<a name="step7"></a></h3>
<p>To publish an IRC event that needs to be received by a specific role instance, you will need to know its
<a href="http://msdn.microsoft.com/en-us/library/microsoft.windowsazure.serviceruntime.roleinstance.id.aspx" target="_blank">
role instance ID</a>. If the target role instance resides in another hosted service deployment regardless of the datacenter location, you will also need to be in a possession of its
<a href="http://msdn.microsoft.com/en-us/library/microsoft.windowsazure.serviceruntime.roleenvironment.deploymentid.aspx" target="_blank">
deployment ID</a>. To resolve the ID of a particular role instance that needs to receive an IRC event, you can query the
<a href="http://msdn.microsoft.com/en-us/library/microsoft.windowsazure.serviceruntime.roleenvironment.roles.aspx" target="_blank">
<em>Roles</em></a> collection and walk through the list of <a href="http://msdn.microsoft.com/en-us/library/microsoft.windowsazure.serviceruntime.roleinstance.aspx" target="_blank">
instances</a> for each role to find the recipient&rsquo;s role instance ID.</p>
<p>The following code snippet is an example of how to send a unicast IRC event to the next instance succeeding the current instance in the role collection:</p>
<pre class="csharpcode"><span class="kwrd">using</span> System.Linq;

<span class="rem">// Find a role instance that sits next to the role instance in which the code is currently running.</span>
<span style="color:#0000ff">var</span> targetInstance = <span style="color:#408080">RoleEnvironment</span>.Roles.Where(r =&gt; { <span class="kwrd">return</span> r.Value == <span style="color:#408080">RoleEnvironment</span>.CurrentRoleInstance.Role; }).
                        SelectMany(i =&gt; i.Value.Instances).
                        SkipWhile(instance =&gt; { <span class="kwrd">return</span> instance != <span style="color:#408080">RoleEnvironment</span>.CurrentRoleInstance; }).
                        Skip(1).
                        FirstOrDefault();

<span class="kwrd">if</span> (targetInstance != <span class="kwrd">null</span>)
{
    <span class="rem">// Create an instance of the IRC event using a string-based payload.</span>
    <span style="color:#408080">InterRoleCommunicationEvent</span> e = <span class="kwrd">new</span> <span style="color:#408080">InterRoleCommunicationEvent</span>(<span class="str"><span style="color:#800000">&quot;This is a test multicast event&quot;</span></span>, <span style="background-color:#ffff00">roleInstanceID: </span><span style="background-color:#ffff00">targetInstance.Id</span>);

    <span class="rem">// Publish the event. That was also easy.</span>
    <span class="kwrd">this</span>.interRoleCommunicator.Publish(e);
}</pre>
<p>If an IRC event needs to be received by a role instance that resides outside the current deployment &ndash; for instance, in another datacenter or in a different hosted service &ndash; you will need to resolve its deployment ID and specify it when creating
 the <em>InterRoleCommunicationEvent</em> object (see the class constructor&rsquo;s signature for more details).</p>
<table class="note">
<tbody>
<tr valign="top">
<td class="notetitle"><span><img title="ImpNoteNoBg" src="-impnotenobg1.png" border="0" alt="ImpNoteNoBg" width="25" height="17" style="border-width:0px; padding-top:0px; padding-right:0px; padding-left:0px; display:inline">Important</span></td>
</tr>
<tr>
<td valign="top">The Windows Azure Managed Library defines a <em><a href="http://msdn.microsoft.com/en-us/library/microsoft.windowsazure.serviceruntime.role.aspx" target="_blank">Role</a></em> class that represents a role. The
<em><a href="http://msdn.microsoft.com/en-us/library/microsoft.windowsazure.serviceruntime.role.instances.aspx" target="_blank">Instances</a></em> property of a
<em>Role</em> object returns a collection of <em><a href="http://msdn.microsoft.com/en-us/library/microsoft.windowsazure.serviceruntime.roleinstance.aspx" target="_blank">RoleInstance</a></em> objects, each representing an instance of the role. The collection
 returned by the <em>Instances</em> property always contains the current instance. Other role instances will be available via this collection only if you defined an internal endpoint for the role, as this internal endpoint is required for the role&rsquo;s instances
 to be discoverable.</td>
</tr>
</tbody>
</table>
<h3>Step 8: Publishing Strongly Typed Inter-Role Communication Events<a name="step8"></a></h3>
<p>As noted in <a href="#step7">step 7</a>, most real-world scenarios for inter-role communication will involve exchanging complex events carrying a lot more than just a single piece of data. For these reasons,&nbsp; we have enabled you to specify an instance
 of any custom type as a payload for the IRC events. You will need to decorate your custom type with a
<a href="http://msdn.microsoft.com/en-us/library/system.runtime.serialization.datacontractattribute.aspx" target="_blank">
<em>DataContract</em></a> attribute with every member of the type to be marked as serializable using a
<a href="http://msdn.microsoft.com/en-us/library/system.runtime.serialization.datamemberattribute.aspx" target="_blank">
<em>DataMember</em></a> attribute unless certain members should not be passed through the wire. Below is an example of a custom type that can be used as an IRC event payload:</p>
<pre class="csharpcode"><span class="rem">/// &lt;summary&gt;</span>
<span class="rem">/// Implements an IRC event payload indicating that a new work item was put in a queue.</span>
<span class="rem">/// &lt;/summary&gt;</span>
<span style="background-color:#ffff00">[<span style="color:#408080">DataContract</span>]
</span><span class="kwrd">public</span> <span class="kwrd">class</span> <span style="color:#408080">CloudQueueWorkDetectedTriggerEvent</span>
{
    <span class="rem">/// &lt;summary&gt;</span>
    <span class="rem">/// Returns the name of the storage account on which the queue is located.</span>
    <span class="rem">/// &lt;/summary&gt;</span>
    <span style="background-color:#ffff00">[<span style="color:#408080">DataMember</span>]</span>
    <span class="kwrd">public</span> <span class="kwrd">string</span> StorageAccount { get; set; }

    <span class="rem">/// &lt;summary&gt;</span>
    <span class="rem">/// Returns a name of the queue where the payload was put.</span>
    <span class="rem">/// &lt;/summary&gt;</span>
    <span style="background-color:#ffff00">[<span style="color:#408080">DataMember</span>]</span>
    <span class="kwrd">public</span> <span class="kwrd">string</span> QueueName { get; set; }

    <span class="rem">/// &lt;summary&gt;</span>
    <span class="rem">/// Returns a size of the queue's payload (e.g. the size of a message or the number of messages).</span>
    <span class="rem">/// &lt;/summary&gt;</span>
    <span style="background-color:#ffff00">[<span style="color:#408080">DataMember</span>]</span>
    <span class="kwrd">public</span> <span class="kwrd">long</span> PayloadSize { get; set; }
}</pre>
<p>To publish a strongly typed event, create a new <em>InterRoleCommunicationEvent</em> passing the instance of the custom type and then invoke the
<em>Publish</em> method as follows:</p>
<pre class="csharpcode"><span style="color:#0000ff">var</span> ircEventBody = <span class="kwrd">new</span> <span style="color:#408080">CloudQueueWorkDetectedTriggerEvent</span>() { QueueName = <span class="str"><span style="color:#800000">&quot;MyQueue&quot;</span></span> };
<span style="color:#0000ff">var</span> ircEvent = <span class="kwrd">new</span> <span style="color:#408080">InterRoleCommunicationEvent</span>(<span style="background-color:#ffff00">ircEventBody</span>);

<span class="kwrd">this</span>.interRoleCommunicator.Publish(ircEvent);</pre>
<p>Strongly typed events require custom types to be shared between publishers and consumers. In other words, the respective .NET types need to be in a possession by the consumer so that it can successfully deserialize the event payload.</p>
<table class="note">
<tbody>
<tr valign="top">
<td class="notetitle"><span><img title="ImpNoteNoBg" src="-impnotenobg1.png" border="0" alt="ImpNoteNoBg" width="25" height="17" style="border-width:0px; padding-top:0px; padding-right:0px; padding-left:0px; display:inline">Important</span></td>
</tr>
<tr>
<td valign="top">The maximum size of a serialized IRC event must not exceed the maximum message size allowed by the Service Bus messaging infrastructure. As of writing, this message size limit is 256KB. To stay up-to-date with the latest limits and other important
 technical constraints that may apply, please visit the <a href="http://msdn.microsoft.com/en-us/library/hh304493.aspx#BKMK_FAQ5" target="_blank">
Windows Azure Service Bus FAQ</a> on MSDN.</td>
</tr>
</tbody>
</table>
<h3>Step 9: Dispose the Inter-Role Communication Component<a name="step9"></a></h3>
<p>The implementation of the IRC component relies on messaging APIs provided by the Service Bus. Under the hood, the component instantiates and maintains communication objects which provide access to the underlying messaging infrastructure. These objects require
 being disposed in a graceful and controlled manner. You will need to ensure that the IRC component is explicitly told to shut itself down by invoking its
<em>Dispose</em> method.</p>
<p>The following code sample disposes the IRC component upon termination of the hosting role instance:</p>
<pre class="csharpcode"><span class="kwrd">public</span> <span class="kwrd">class</span> <span style="color:#408080">SampleWorkerRole</span> : <span style="color:#408080">RoleEntryPoint</span>
{
    <span class="rem">// ...There is usually some code here...</span>

    <span class="rem">/// &lt;summary&gt;</span>
    <span class="rem">/// Called by Windows Azure when the role instance is to be stopped.</span>
    <span class="rem">/// &lt;/summary&gt;</span>
    <span class="kwrd">public</span> <span class="kwrd">override</span> <span class="kwrd">void</span> OnStop()
    {
        <span class="kwrd">if</span> (<span class="kwrd">this</span>.interRoleCommunicator != <span class="kwrd">null</span>)
        {
            <span class="rem">// Dispose the IRC component so that it gets a chance to gracefully clean up internal resources.</span>
            <span style="background-color:#ffff00"><span class="kwrd">this</span>.interRoleCommunicator.Dispose();</span>
            <span class="kwrd">this</span>.interRoleCommunicator = <span class="kwrd">null</span>;
        }
    }

    <span class="rem">// ...There is usually some more code here...</span>
}</pre>
<p>The disposal of the IRC component is guaranteed not to throw any runtime exceptions; hence it&rsquo;s safe to call into the
<em>Dispose</em> method without any special precautions.</p>
