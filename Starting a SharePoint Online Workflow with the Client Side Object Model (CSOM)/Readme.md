# Starting a SharePoint Online Workflow with the Client Side Object Model (CSOM)
## Requires
- Visual Studio 2015
## License
- Apache License, Version 2.0
## Technologies
- C#
- SharePoint
- Sharepoint Online
- CSOM
## Topics
- SharePoint
- Sharepoint Online
- SharePoint client object model (CSOM)
- CSOM
## Updated
- 01/26/2016
## Description

<h1>Introduction</h1>
<p><em>With the use of this sample you have a starting point in order to start workflows in for example SharePoint online by using CSOM C#.</em></p>
<h1>Building the Sample</h1>
<p>The required NuGet packages should be included in the zip package. If not download the following NuGet package:</p>
<p>- OfficeDevPnpCore16</p>
<h1><span>Description</span></h1>
<p>There are situations were you would like to start a workflow by using&nbsp; code. In one of my last projects there was that kind of situation, in that project we needed to start a workflow on every item in a SharePoint list. In the past I had done this kind
 of work many times with the server object model but since this was a SharePoint Online instance I was not able to use the server object model.</p>
<p>As you are unable to use the server object model you need to use the Client Side Object Model (CSOM).&nbsp; In the upcoming article I will walk you trough the code step by step. Make sure that before you start that you add the OfficeDevPpPCore16 nuget package
 to your application.</p>
<p>First thing you need to do when using the client side object model is getting the client context for the site. The URL that you use for the context will need to be the absolute URL of the site on which you want to start the Workflow.&nbsp; In order to build
 the client context you need the login name of the user, his password and the site URL.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Console.WriteLine(&quot;Enter the Office 365 Login Name&quot;);
string loginId = Console.ReadLine();
string pwd = GetInput(&quot;Password&quot;, true);
 
Console.WriteLine(&quot;Web Url:&quot;);
string webUrl = Console.ReadLine();
 
Console.WriteLine(&quot;List Name:&quot;);
string listName = Console.ReadLine();
 
Console.WriteLine(&quot;Workflow Name&quot;);
string workflowName = Console.ReadLine();
 
var passWord = new SecureString();
foreach (char c in pwd.ToCharArray()) passWord.AppendChar(c);
 
using (var ctx = new ClientContext(webUrl)) {
    ctx.Credentials = new SharePointOnlineCredentials(loginId, passWord);
}
</pre>
<div class="preview">
<pre class="csharp">Console.WriteLine(<span class="cs__string">&quot;Enter&nbsp;the&nbsp;Office&nbsp;365&nbsp;Login&nbsp;Name&quot;</span>);&nbsp;
<span class="cs__keyword">string</span>&nbsp;loginId&nbsp;=&nbsp;Console.ReadLine();&nbsp;
<span class="cs__keyword">string</span>&nbsp;pwd&nbsp;=&nbsp;GetInput(<span class="cs__string">&quot;Password&quot;</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;&nbsp;
Console.WriteLine(<span class="cs__string">&quot;Web&nbsp;Url:&quot;</span>);&nbsp;
<span class="cs__keyword">string</span>&nbsp;webUrl&nbsp;=&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;
Console.WriteLine(<span class="cs__string">&quot;List&nbsp;Name:&quot;</span>);&nbsp;
<span class="cs__keyword">string</span>&nbsp;listName&nbsp;=&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;
Console.WriteLine(<span class="cs__string">&quot;Workflow&nbsp;Name&quot;</span>);&nbsp;
<span class="cs__keyword">string</span>&nbsp;workflowName&nbsp;=&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;
var&nbsp;passWord&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SecureString();&nbsp;
<span class="cs__keyword">foreach</span>&nbsp;(<span class="cs__keyword">char</span>&nbsp;c&nbsp;<span class="cs__keyword">in</span>&nbsp;pwd.ToCharArray())&nbsp;passWord.AppendChar(c);&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;(var&nbsp;ctx&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ClientContext(webUrl))&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx.Credentials&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SharePointOnlineCredentials(loginId,&nbsp;passWord);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>In the above code the is a reference to a method called &ldquo;GetInput&rdquo; We use this method for getting the password of the user without seeing what the user is typing in the console window.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private static string GetInput(string label, bool isPassword) {
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(&quot;{0} : &quot;, label);
    Console.ForegroundColor = ConsoleColor.Gray;
 
    string strPwd = &quot;&quot;;
 
    for (ConsoleKeyInfo keyInfo = Console.ReadKey(true); keyInfo.Key != ConsoleKey.Enter; keyInfo = Console.ReadKey(true)) {
        if (keyInfo.Key == ConsoleKey.Backspace) {
            if (strPwd.Length &gt; 0) {
                strPwd = strPwd.Remove(strPwd.Length - 1);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write(&quot; &quot;);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        } else if (keyInfo.Key != ConsoleKey.Enter) {
            if (isPassword) {
                Console.Write(&quot;*&quot;);
            } else {
                Console.Write(keyInfo.KeyChar);
            }
            strPwd &#43;= keyInfo.KeyChar;
 
        }
 
    }
    Console.WriteLine(&quot;&quot;);
 
    return strPwd;
}
</pre>
<div class="preview">
<pre class="js">private&nbsp;static&nbsp;string&nbsp;GetInput(string&nbsp;label,&nbsp;bool&nbsp;isPassword)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.ForegroundColor&nbsp;=&nbsp;ConsoleColor.White;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="js__string">&quot;{0}&nbsp;:&nbsp;&quot;</span>,&nbsp;label);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.ForegroundColor&nbsp;=&nbsp;ConsoleColor.Gray;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;strPwd&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(ConsoleKeyInfo&nbsp;keyInfo&nbsp;=&nbsp;Console.ReadKey(true);&nbsp;keyInfo.Key&nbsp;!=&nbsp;ConsoleKey.Enter;&nbsp;keyInfo&nbsp;=&nbsp;Console.ReadKey(true))&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(keyInfo.Key&nbsp;==&nbsp;ConsoleKey.Backspace)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(strPwd.Length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;strPwd&nbsp;=&nbsp;strPwd.Remove(strPwd.Length&nbsp;-&nbsp;<span class="js__num">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.SetCursorPosition(Console.CursorLeft&nbsp;-&nbsp;<span class="js__num">1</span>,&nbsp;Console.CursorTop);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="js__string">&quot;&nbsp;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.SetCursorPosition(Console.CursorLeft&nbsp;-&nbsp;<span class="js__num">1</span>,&nbsp;Console.CursorTop);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__statement">if</span>&nbsp;(keyInfo.Key&nbsp;!=&nbsp;ConsoleKey.Enter)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(isPassword)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="js__string">&quot;*&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(keyInfo.KeyChar);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;strPwd&nbsp;&#43;=&nbsp;keyInfo.KeyChar;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;strPwd;&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>When the client context is setup we can start with the actions we need to perform. The first action we will perform is getting a reference to all required workflow components.components</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var workflowServicesManager = new WorkflowServicesManager(ctx, ctx.Web);
var workflowInteropService = workflowServicesManager.GetWorkflowInteropService();
var workflowSubscriptionService = workflowServicesManager.GetWorkflowSubscriptionService();
var workflowDeploymentService = workflowServicesManager.GetWorkflowDeploymentService();
var workflowInstanceService = workflowServicesManager.GetWorkflowInstanceService();
</pre>
<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;workflowServicesManager&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;WorkflowServicesManager(ctx,&nbsp;ctx.Web);&nbsp;
<span class="js__statement">var</span>&nbsp;workflowInteropService&nbsp;=&nbsp;workflowServicesManager.GetWorkflowInteropService();&nbsp;
<span class="js__statement">var</span>&nbsp;workflowSubscriptionService&nbsp;=&nbsp;workflowServicesManager.GetWorkflowSubscriptionService();&nbsp;
<span class="js__statement">var</span>&nbsp;workflowDeploymentService&nbsp;=&nbsp;workflowServicesManager.GetWorkflowDeploymentService();&nbsp;
<span class="js__statement">var</span>&nbsp;workflowInstanceService&nbsp;=&nbsp;workflowServicesManager.GetWorkflowInstanceService();&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>This above components are all needed in order to start a workflow. The component we will use first is the deployment service, this service will be used to get all published workflow definitions on the site.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var publishedWorkflowDefinitions = workflowDeploymentService.EnumerateDefinitions(true);
ctx.Load(publishedWorkflowDefinitions);
ctx.ExecuteQuery();
 
var def = from defs in publishedWorkflowDefinitions
          where defs.DisplayName == workflowName
          select defs;
 
WorkflowDefinition workflow = def.FirstOrDefault();
 
if(workflow != null) {
 
}
</pre>
<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;publishedWorkflowDefinitions&nbsp;=&nbsp;workflowDeploymentService.EnumerateDefinitions(true);&nbsp;
ctx.Load(publishedWorkflowDefinitions);&nbsp;
ctx.ExecuteQuery();&nbsp;
&nbsp;&nbsp;
<span class="js__statement">var</span>&nbsp;def&nbsp;=&nbsp;from&nbsp;defs&nbsp;<span class="js__operator">in</span>&nbsp;publishedWorkflowDefinitions&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;defs.DisplayName&nbsp;==&nbsp;workflowName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;defs;&nbsp;
&nbsp;&nbsp;
WorkflowDefinition&nbsp;workflow&nbsp;=&nbsp;def.FirstOrDefault();&nbsp;
&nbsp;&nbsp;
<span class="js__statement">if</span>(workflow&nbsp;!=&nbsp;null)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>As you can see in the above code the workflow definitions are retrieved from the site. In this collection we try to find our workflow definition we need by using the workflow name.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// get all workflow associations
var workflowAssociations = workflowSubscriptionService.EnumerateSubscriptionsByDefinition(workflow.Id);
ctx.Load(workflowAssociations);
ctx.ExecuteQuery();
 
// find the first association
var firstWorkflowAssociation = workflowAssociations.First();
 
// start the workflow
var startParameters = new Dictionary&lt;string, object&gt;();
 
if (ctx.Web.ListExists(listName)) {
    List list = ctx.Web.GetListByTitle(listName);
 
    CamlQuery query = CamlQuery.CreateAllItemsQuery();
    ListItemCollection items = list.GetItems(query);
 
    // Retrieve all items in the ListItemCollection from List.GetItems(Query).
    ctx.Load(items);
    ctx.ExecuteQuery();
    foreach (ListItem listItem in items) {
        Console.WriteLine(&quot;Starting workflow for item: &quot; &#43; listItem.Id);
        workflowInstanceService.StartWorkflowOnListItem(firstWorkflowAssociation, listItem.Id, startParameters);
        ctx.ExecuteQuery();
    }
}
</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;get&nbsp;all&nbsp;workflow&nbsp;associations</span><span class="js__statement">var</span>&nbsp;workflowAssociations&nbsp;=&nbsp;workflowSubscriptionService.EnumerateSubscriptionsByDefinition(workflow.Id);&nbsp;
ctx.Load(workflowAssociations);&nbsp;
ctx.ExecuteQuery();&nbsp;
&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;find&nbsp;the&nbsp;first&nbsp;association</span><span class="js__statement">var</span>&nbsp;firstWorkflowAssociation&nbsp;=&nbsp;workflowAssociations.First();&nbsp;
&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;start&nbsp;the&nbsp;workflow</span><span class="js__statement">var</span>&nbsp;startParameters&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Dictionary&lt;string,&nbsp;object&gt;();&nbsp;
&nbsp;&nbsp;
<span class="js__statement">if</span>&nbsp;(ctx.Web.ListExists(listName))&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;List&nbsp;list&nbsp;=&nbsp;ctx.Web.GetListByTitle(listName);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CamlQuery&nbsp;query&nbsp;=&nbsp;CamlQuery.CreateAllItemsQuery();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ListItemCollection&nbsp;items&nbsp;=&nbsp;list.GetItems(query);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Retrieve&nbsp;all&nbsp;items&nbsp;in&nbsp;the&nbsp;ListItemCollection&nbsp;from&nbsp;List.GetItems(Query).</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx.Load(items);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx.ExecuteQuery();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(ListItem&nbsp;listItem&nbsp;<span class="js__operator">in</span>&nbsp;items)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;Starting&nbsp;workflow&nbsp;for&nbsp;item:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;listItem.Id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workflowInstanceService.StartWorkflowOnListItem(firstWorkflowAssociation,&nbsp;listItem.Id,&nbsp;startParameters);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.ExecuteQuery();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>When the correct definition is loaded we need to association&nbsp; to be able to start the workflow. Together with the association you also need start parameters to start the workflow, because in our situation we do not have any start parameters we pass
 in a empty dictionary.&nbsp; If the list exists we create a CAML query to retrieve all the items in the list.</p>
<p>As last step we can iterate trough the list items and start the workflow for each item by calling the &ldquo;StartWorkflowOnListItem&rdquo; method.</p>
<p>&nbsp;</p>
<h1>Source Code Files</h1>
<ul>
<li><em>Program.cs&nbsp;- Execution of the Console&nbsp;application.</em> </li></ul>
<h1>More Information</h1>
<p>More information can be found on my <a title="blog" href="https://msftplayground.com">
blog</a>:</p>
<p><a title="Starting a Workflow with CSOM" href="https://msftplayground.com/2015/08/starting-a-workflow-with-csom/">https://msftplayground.com/2015/08/starting-a-workflow-with-csom/<br>
</a></p>
<p>&nbsp;</p>
<h1></h1>
<p>&nbsp;</p>
