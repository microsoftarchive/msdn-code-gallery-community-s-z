# Testing XPath queries in .NET with a tool
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- .NET
- XML
- BizTalk Server
## Topics
- XML
- Xpath
- BizTalk
## Updated
- 09/26/2015
## Description

<h1>Introduction</h1>
<p>XPath is a query language for selecting nodes from a XML document but you can also use it for example to compute values (e.g., strings, numbers, or Boolean values) from the content of a XML document.</p>
<p>In BizTalk you can use XPath queries for example in Business Rules, in a Map, or in an Orchestration to read and write information in a message with the xpath() function.</p>
<p>There are several tools available that you can use to test XPath queries. Both paid like and free but with XPath.Hero you get also the source code so you can modify it to your own needs!</p>
<p>The tool is a .NET Forms application written in Visual Studio 2013. It is completely resizable so you can make it as big or small as you want. You can use it to select nodes but you can also use functions.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The following steps are needed to test a XPath query in the tool:</p>
<p>- Select a XML file</p>
<p>- Enter a XPath query</p>
<p>- Click on the &quot;Check&quot; button</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<em>&nbsp;</em></p>
<h3><em>Select nodes</em></h3>
<p><em>The following example selects all the ItemId nodes in the SalesOrder document.</em></p>
<p><em><img id="142950" src="142950-xpath%20expression%20to%20select%20nodes.png" alt="" width="611" height="610">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</em></p>
<p><em>&nbsp;&nbsp; </em></p>
<h3><em><em>Number functions</em></em></h3>
<p><em><em>The following example counts all the ItemId nodes in the SalesOrder document.</em></em></p>
<p><img id="142949" src="142949-xpath%20count%20function.png" alt="" width="611" height="610">&nbsp;</p>
<p>&nbsp;</p>
<h2>Code Snippets</h2>
<p>&nbsp;The following code snippet shows how the XPathNavigator class in .NET works.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">XPathNavigator navigator = document.CreateNavigator();

XPathExpression expression = XPathExpression.Compile(xpath);

switch (expression.ReturnType)
{
	case XPathResultType.Number:

		result = String.Format(&quot;Result: {0}&quot;, navigator.Evaluate(expression));
		break;

	case XPathResultType.NodeSet:

		StringBuilder resultBldr = new StringBuilder();

		XPathNodeIterator nodes = navigator.Select(expression);

		//Move to first selected node
		nodes.MoveNext();                        

		switch (nodes.Current.NodeType)
		{
			case XPathNodeType.Attribute:

				resultBldr.AppendFormat(&quot;Result: {0} Attribute(s) selected&quot;, nodes.Count);
				break;
			case XPathNodeType.Element:

				resultBldr.AppendFormat(&quot;Result: {0} Element(s) selected&quot;, nodes.Count);
				break;
		}
		
		resultBldr.AppendFormat(&quot;\n\n&quot;);                     

		do
		{
			resultBldr.AppendFormat(&quot;{0}\n&quot;, nodes.Current.OuterXml);
		} while (nodes.MoveNext());

		result = resultBldr.ToString();

		break;

	case XPathResultType.Boolean:

		bool blnResult = (bool)navigator.Evaluate(expression);
		result = String.Format(&quot;Result: {0}&quot;, blnResult.ToString());

		break;

	case XPathResultType.String:

		result = String.Format(&quot;Result: {0}&quot;, navigator.Evaluate(expression));
		break;
}</pre>
<div class="preview">
<pre class="csharp">XPathNavigator&nbsp;navigator&nbsp;=&nbsp;document.CreateNavigator();&nbsp;
&nbsp;
XPathExpression&nbsp;expression&nbsp;=&nbsp;XPathExpression.Compile(xpath);&nbsp;
&nbsp;
<span class="cs__keyword">switch</span>&nbsp;(expression.ReturnType)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;XPathResultType.Number:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;String.Format(<span class="cs__string">&quot;Result:&nbsp;{0}&quot;</span>,&nbsp;navigator.Evaluate(expression));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;XPathResultType.NodeSet:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;resultBldr&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XPathNodeIterator&nbsp;nodes&nbsp;=&nbsp;navigator.Select(expression);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Move&nbsp;to&nbsp;first&nbsp;selected&nbsp;node</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nodes.MoveNext();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(nodes.Current.NodeType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;XPathNodeType.Attribute:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBldr.AppendFormat(<span class="cs__string">&quot;Result:&nbsp;{0}&nbsp;Attribute(s)&nbsp;selected&quot;</span>,&nbsp;nodes.Count);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;XPathNodeType.Element:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBldr.AppendFormat(<span class="cs__string">&quot;Result:&nbsp;{0}&nbsp;Element(s)&nbsp;selected&quot;</span>,&nbsp;nodes.Count);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBldr.AppendFormat(<span class="cs__string">&quot;\n\n&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">do</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBldr.AppendFormat(<span class="cs__string">&quot;{0}\n&quot;</span>,&nbsp;nodes.Current.OuterXml);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cs__keyword">while</span>&nbsp;(nodes.MoveNext());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;resultBldr.ToString();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;XPathResultType.Boolean:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;blnResult&nbsp;=&nbsp;(<span class="cs__keyword">bool</span>)navigator.Evaluate(expression);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;String.Format(<span class="cs__string">&quot;Result:&nbsp;{0}&quot;</span>,&nbsp;blnResult.ToString());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;XPathResultType.String:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;String.Format(<span class="cs__string">&quot;Result:&nbsp;{0}&quot;</span>,&nbsp;navigator.Evaluate(expression));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<h1><em><em>&nbsp;</em></em></h1>
<h1>More Information</h1>
<p><em>For more information on XPath, see <a title="XPath Functions" href="https://msdn.microsoft.com/en-us/library/ms256138.aspx">
XPath Functions</a></em></p>
