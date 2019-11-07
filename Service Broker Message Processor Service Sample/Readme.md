# Service Broker Message Processor Service Sample
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- SQL Server
- SQL Server Service Broker
## Topics
- Service Broker Programming
## Updated
- 01/15/2013
## Description

<h1>Introduction</h1>
<div>&nbsp;</div>
<div><em>This sample illustrates how to build a Windows Service to process Service Broker Messages in C#.&nbsp; This approach is an alternative to the &quot;Service Broker External Activator&quot;, which I find overly complex and not terribly helpful.&nbsp; It's overly
 complex as it uses Service Broker Notification, instead of simply doing a blocking read on the target queue.&nbsp; And it's not overly helpful, as it still requires you to code all the message processing plumbing.</em></div>
<h1><em>&nbsp;</em>&nbsp;</h1>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<div><em>This sample includes a simple Windows Service, and shows how to&nbsp;start one or more threads to process a Service Broker queue.&nbsp; Each target queue you want to process will get its own dedicated listener thread (you can also use multiple threads
 per queue).&nbsp;&nbsp;Code in the sample will&nbsp;RECEIVE messages from the queue and&nbsp;pass them to a method that you implement.</em>&nbsp;</div>
<div>&nbsp;</div>
<div>You crate one QueueListenerConfig object for each listener thread you want, like this:</div>
<div>&nbsp;</div>
<div>The MessageProcessor and FailedMessageProcessor are just Action&lt;byte[]&gt;, so just wire them up to custom methods that will recieve the message body and do something useful.</div>
<div><em>
<h1 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">      var l = new QueueListenerConfig();
      l.QueueName = &quot;Inbound&quot;;  //The name of the service broker queue
      l.Threads = 1;
      l.EnlistMessageProcessor = false;  //Don't call the message processor in the context of the RECEIVE transaction
      l.MessageProcessor = InboundMessageProcessor.ProcessMessage;  //Wire up the message processors
      l.FailedMessageProcessor = InboundMessageProcessor.SaveFailedMessage;
      l.ConnectionString = &quot;Data Source=(local);Initial Catalog=test;Integrated Security=true&quot;;
      QueueSettings.Add(l);</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;l&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;QueueListenerConfig();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.QueueName&nbsp;=&nbsp;<span class="cs__string">&quot;Inbound&quot;</span>;&nbsp;&nbsp;<span class="cs__com">//The&nbsp;name&nbsp;of&nbsp;the&nbsp;service&nbsp;broker&nbsp;queue</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Threads&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.EnlistMessageProcessor&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;&nbsp;<span class="cs__com">//Don't&nbsp;call&nbsp;the&nbsp;message&nbsp;processor&nbsp;in&nbsp;the&nbsp;context&nbsp;of&nbsp;the&nbsp;RECEIVE&nbsp;transaction</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.MessageProcessor&nbsp;=&nbsp;InboundMessageProcessor.ProcessMessage;&nbsp;&nbsp;<span class="cs__com">//Wire&nbsp;up&nbsp;the&nbsp;message&nbsp;processors</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.FailedMessageProcessor&nbsp;=&nbsp;InboundMessageProcessor.SaveFailedMessage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.ConnectionString&nbsp;=&nbsp;<span class="cs__string">&quot;Data&nbsp;Source=(local);Initial&nbsp;Catalog=test;Integrated&nbsp;Security=true&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QueueSettings.Add(l);</pre>
</div>
</div>
</h1>
<address class="endscriptcode">&nbsp;
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<div><em>When the messages are RECEIVEd from Service Broker, any End Converversation messages are handled automatically.&nbsp; If you want to add special handling for other system messages, like errors or conversation timer messages, that's where it would go.&nbsp;
 Consider extending QueueListenerConfig to add Action&lt;&gt; delegates for those additional message types.&nbsp; Here's the Service Broker Recive method:
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">    public static byte[]  GetMessage(string queueName, SqlConnection con, TimeSpan timeout)
    {
      using (SqlDataReader r = GetMessageBatch(queueName, con, timeout,1))
      {
        if (r == null || !r.HasRows  )
          return null;
        r.Read();
        Guid conversation_handle = r.GetGuid(r.GetOrdinal(&quot;conversation_handle&quot;));
        string messageType = r.GetString(r.GetOrdinal(&quot;message_type_name&quot;));
        if (messageType == &quot;http://schemas.microsoft.com/SQL/ServiceBroker/EndDialog&quot;)
        {
          EndConversation(conversation_handle, con);
          return null;
        }
        var body = r.GetSqlBinary(r.GetOrdinal(&quot;message_body&quot;));
        return body.Value;

      }
    }</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;byte[]&nbsp;&nbsp;GetMessage(string&nbsp;queueName,&nbsp;SqlConnection&nbsp;con,&nbsp;TimeSpan&nbsp;timeout)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(SqlDataReader&nbsp;r&nbsp;=&nbsp;GetMessageBatch(queueName,&nbsp;con,&nbsp;timeout,<span class="js__num">1</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(r&nbsp;==&nbsp;null&nbsp;||&nbsp;!r.HasRows&nbsp;&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Read();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Guid&nbsp;conversation_handle&nbsp;=&nbsp;r.GetGuid(r.GetOrdinal(<span class="js__string">&quot;conversation_handle&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;messageType&nbsp;=&nbsp;r.GetString(r.GetOrdinal(<span class="js__string">&quot;message_type_name&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(messageType&nbsp;==&nbsp;<span class="js__string">&quot;http://schemas.microsoft.com/SQL/ServiceBroker/EndDialog&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndConversation(conversation_handle,&nbsp;con);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;body&nbsp;=&nbsp;r.GetSqlBinary(r.GetOrdinal(<span class="js__string">&quot;message_body&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;body.Value;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</em></div>
</address>
<div>And the GetMessageBatch looks like this:</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">    static SqlDataReader GetMessageBatch(string queueName, SqlConnection con, TimeSpan timeout, int maxMessages)
    {
      string SQL = string.Format(@&quot;
            waitfor( 
                RECEIVE top (@count) conversation_handle,service_name,message_type_name,message_body,message_sequence_number 
                FROM [{0}] 
                    ), timeout @timeout&quot;, queueName);
      SqlCommand cmd = new SqlCommand(SQL, con);

      SqlParameter pCount = cmd.Parameters.Add(&quot;@count&quot;, SqlDbType.Int);
      pCount.Value = maxMessages;

      SqlParameter pTimeout = cmd.Parameters.Add(&quot;@timeout&quot;, SqlDbType.Int);

      if (timeout == TimeSpan.MaxValue)
      {
        pTimeout.Value = -1;
      }
      else
      {
        pTimeout.Value = (int)timeout.TotalMilliseconds;
      }

      cmd.CommandTimeout = 0; //honor the RECIEVE timeout, whatever it is.


      return cmd.ExecuteReader();
    }</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;SqlDataReader&nbsp;GetMessageBatch(<span class="cs__keyword">string</span>&nbsp;queueName,&nbsp;SqlConnection&nbsp;con,&nbsp;TimeSpan&nbsp;timeout,&nbsp;<span class="cs__keyword">int</span>&nbsp;maxMessages)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;SQL&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(@&quot;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;waitfor(&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RECEIVE&nbsp;top&nbsp;(@count)&nbsp;conversation_handle,service_name,message_type_name,message_body,message_sequence_number&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FROM&nbsp;[{<span class="cs__number">0</span>}]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;),&nbsp;timeout&nbsp;@timeout&quot;,&nbsp;queueName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;cmd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(SQL,&nbsp;con);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlParameter&nbsp;pCount&nbsp;=&nbsp;cmd.Parameters.Add(<span class="cs__string">&quot;@count&quot;</span>,&nbsp;SqlDbType.Int);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pCount.Value&nbsp;=&nbsp;maxMessages;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlParameter&nbsp;pTimeout&nbsp;=&nbsp;cmd.Parameters.Add(<span class="cs__string">&quot;@timeout&quot;</span>,&nbsp;SqlDbType.Int);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(timeout&nbsp;==&nbsp;TimeSpan.MaxValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pTimeout.Value&nbsp;=&nbsp;-<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pTimeout.Value&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)timeout.TotalMilliseconds;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandTimeout&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;<span class="cs__com">//honor&nbsp;the&nbsp;RECIEVE&nbsp;timeout,&nbsp;whatever&nbsp;it&nbsp;is.</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;cmd.ExecuteReader();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</em>
<div></div>
<address class="endscriptcode"></address>
</div>
