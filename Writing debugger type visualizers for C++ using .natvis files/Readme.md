# Writing debugger type visualizers for C++ using .natvis files
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- Visual Studio Extensions
- Visual Studio 2012 RC
## Topics
- Debugger
- Debugger Extensibility
## Updated
- 07/09/2012
## Description

<h1>Introduction</h1>
<p style="text-align:justify">Visual Studio 2012 introduces a new type visualization framework (natvis) for customizing the way C&#43;&#43; types are displayed in debugger variable windows (watch, locals, data tips etc.). It replaces the
<strong>autoexp.dat</strong> file that has been used in earlier versions of Visual Studio, and offers xml syntax, better diagnostics, versioning and multiple file support.&nbsp;You can use this framework to enhance debugger's view of your custom data types.&nbsp;This
 sample page contains syntax reference and examples for visualizer xml elements, instructions for turning on diagnostics, and a simple project that demonstrates VSIX deployment of type visualizers.</p>
<p style="text-align:justify">&nbsp;</p>
<h1 style="text-align:justify">Building the Sample</h1>
<p style="text-align:justify">You need to have Visual Studio 2012 RC SDK in order to open and build the project in this sample. You can download it from&nbsp;<a href="http://www.microsoft.com/en-us/download/details.aspx?id=29930">http://www.microsoft.com/en-us/download/details.aspx?id=29930</a>.
 Note that this is necessary only if you are interested in learning more about VSIX deployment of visualizers. You can always manually copy the visualizer files to your Visual Studio installation. This is explained further below.</p>
<p style="text-align:justify">&nbsp;</p>
<h1 style="text-align:justify">Description</h1>
<h2>Natvis files</h2>
<p style="text-align:justify">Type visualizers for C&#43;&#43; types are specified in .natvis files. A natvis file is simply an xml file (with a .natvis extension) with its schema defined in &lt;VSINSTALLDIR&gt;\Xml\Schemas\natvis.xsd. A natvis file contains visualization
 rules for one or more types.&nbsp;Visual Studio ships with a few natvis files in &lt;VSINSTALLDIR&gt;\Common7\Packages\Debugger\Visualizers folder. These files contain visualization rules for many common types and can serve as examples when writing visualizers
 for new types.</p>
<p style="text-align:justify">The basic structure of a natvis file is as follows, where each 'Type' element represents a visualizer entry for a type whose fully qualified name is specified in the 'Name' attribute.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;AutoVisualizer xmlns=&quot;http://schemas.microsoft.com/vstudio/debugger/natvis/2010&quot;&gt;
  &lt;Type Name=&quot;MyNamespace::CFoo&quot;&gt;
    ...
  &lt;/Type&gt;
  &lt;Type Name=&quot;...&quot;&gt;
    ...
  &lt;/Type&gt;
&lt;/AutoVisualizer&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;?xml</span>&nbsp;<span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xml__attr_name">encoding</span>=<span class="xml__attr_value">&quot;utf-8&quot;</span><span class="xml__tag_start">?&gt;</span>&nbsp;
<span class="xml__tag_start">&lt;AutoVisualizer</span>&nbsp;<span class="xml__attr_name">xmlns</span>=<span class="xml__attr_value">&quot;http://schemas.microsoft.com/vstudio/debugger/natvis/2010&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;MyNamespace::CFoo&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;...&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Type&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;...&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;...&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Type&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/AutoVisualizer&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="text-align:justify">You can start writing a visualizer for your types by creating a natvis file having the above structure and dropping it into one of the locations below:</div>
<ul>
<li>%VSINSTALLDIR%\Common7\Packages\Debugger\Visualizers (requires admin access) </li><li>%USERPROFILE%\My Documents\Visual Studio 2012\Visualizers\ </li><li>VS extension folders (explained further below) </li></ul>
<p style="text-align:justify">At the start of each debugging session, Visual Studio will load and process every natvis file it can find in these locations (it is NOT necessary to restart Visual Studio). This makes writing new visualizers easy as you can stop
 debugging, make changes to your visualizer entries, save the natvis file and start debugging again to see the effects of your changes.</p>
<h2>Natvis diagnostics</h2>
<p style="text-align:justify">Natvis diagnostics is a very important tool that helps troubleshooting issues when writing new type visualizers. When the debugger encounters errors in a visualizer entry (e.g. xml schema errors, expression fails to parse), it
 will simply ignore it and display the type in its raw form or pick another suitable visualizer. To understand why a certain visualizer entry is ignored and to see what the underlying errors are, you can turn on visualization diagnostics which is controlled
 by the following registry value:</p>
<p style="text-align:justify">[HKEY_CURRENT_USER\Software\Microsoft\VisualStudio\11.0_Config\Debugger]</p>
<p style="text-align:justify">&quot;EnableNatvisDiagnostics&quot;=dword:00000001</p>
<p style="text-align:justify">When turned on, you will see diagnostic status messages (e.g. when a natvis file is parsed, an expression is successfully evaluated) and error messages (e.g. file parse errors, expression parse errors) in the output window in Visual
 Studio.</p>
<h2>Syntax Reference</h2>
<p>The structure of a basic visualizer entry looks like:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Type Name=&quot;[fully qualified type name]&quot;&gt;
  &lt;DisplayString Condition=&quot;[Boolean expression]&quot;&gt;[Display value]&lt;/DisplayString&gt;
  &lt;Expand&gt;
    ...
  &lt;/Expand&gt;
&lt;/Type&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;[fully&nbsp;qualified&nbsp;type&nbsp;name]&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span>&nbsp;<span class="xml__attr_name">Condition</span>=<span class="xml__attr_value">&quot;[Boolean&nbsp;expression]&quot;</span><span class="xml__tag_start">&gt;[</span>Display&nbsp;value]<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Expand</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;...&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Expand&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Type&gt;</span></pre>
</div>
</div>
</div>
<p style="text-align:justify">Most of the different xml elements that can be used to define type visualizers are explained in this section with examples.</p>
<h3>Condition attribute</h3>
<p style="text-align:justify">The optional condition attribute is available for many visualizer elements and specifies when a visualization rule should be used. If the expression inside the condition attribute is false, then the visualization rule specified
 by the element is not applied. If it&rsquo;s evaluated to true, or if there is no condition attribute then the visualization rule is applied to the type. You can use this attribute to have if-else logic in the visualization entries. For instance, the visualizer
 below defines two DisplayString elements for a smart pointer type:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Type Name=&quot;std::auto_ptr&amp;lt;*&amp;gt;&quot;&gt;
  &lt;DisplayString Condition=&quot;_Myptr == 0&quot;&gt;empty&lt;/DisplayString&gt;
  &lt;DisplayString&gt;auto_ptr {*_Myptr}&lt;/DisplayString&gt;
  &lt;Expand&gt;
    &lt;ExpandedItem&gt;_Myptr&lt;/ExpandedItem&gt;
  &lt;/Expand&gt;
&lt;/Type&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;std::auto_ptr&amp;lt;*&amp;gt;&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span>&nbsp;<span class="xml__attr_name">Condition</span>=<span class="xml__attr_value">&quot;_Myptr&nbsp;==&nbsp;0&quot;</span><span class="xml__tag_start">&gt;</span>empty<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span><span class="xml__tag_start">&gt;</span>auto_ptr&nbsp;{*_Myptr}<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Expand</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ExpandedItem</span><span class="xml__tag_start">&gt;</span>_Myptr<span class="xml__tag_end">&lt;/ExpandedItem&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Expand&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Type&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="text-align:justify">When _Myptr member is null, the condition of the first DisplayString element will be true, therefore that element takes effect. When the _Myptr member is not null, the condition evaluates to false and
 the second DisplayString element takes effect.</div>
<h3>DisplayString</h3>
<p style="text-align:justify">DisplayString node specifies the string to be shown as the value of the variable. It accepts arbitrary strings mixed with expressions. Everything inside curly braces is interpreted as an expression and gets evaluated. For instance:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title" style="text-align:left"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Type Name=&quot;CPoint&quot;&gt;
  &lt;DisplayString&gt;{{x={x} y={y}}}&lt;/DisplayString&gt;
&lt;/Type&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;CPoint&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span><span class="xml__tag_start">&gt;{</span>{x={x}&nbsp;y={y}}}<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Type&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;will result in variables of type CPoint to look like:</div>
<p><img id="60731" src="60731-displaystring.png" alt="" width="354" height="59" style="display:block; margin-left:auto; margin-right:auto"></p>
<p style="text-align:justify">Here, x and y, which are members of CPoint, are inside curly braces and their values are evaluated. Note that the example also shows you can escape a curly brace by using double curly braces (i.e. {{ or }}).</p>
<p style="text-align:justify">One important point to remember is DisplayString element is the only element that accepts arbitrary strings and the curly brace syntax. All other visualization elements accept only expressions that are evaluated by the debugger.</p>
<h3>StringView</h3>
<p>Adding a StringView element tells the debugger that this value can be viewed by a text visualizer:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Type Name=&quot;ATL::CStringT&amp;lt;wchar_t,*&amp;gt;&quot;&gt;
  &lt;DisplayString&gt;{m_pszData,su}&lt;/DisplayString&gt;
  &lt;StringView&gt;m_pszData,su&lt;/StringView&gt;
&lt;/Type&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;ATL::CStringT&amp;lt;wchar_t,*&amp;gt;&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span><span class="xml__tag_start">&gt;{</span>m_pszData,su}<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;StringView</span><span class="xml__tag_start">&gt;</span>m_pszData,su<span class="xml__tag_end">&lt;/StringView&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Type&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="text-align:justify">Notice the glass icon shown next to the value below. Clicking the icon will launch the text visualizer which will display the string that m_pszData points to.</div>
<p><img id="60833" src="60833-stringview.png" alt="" width="650" height="81" style="display:block; margin-left:auto; margin-right:auto"></p>
<h3>Expand</h3>
<p style="text-align:justify">Expand node is used to customize the children of the visualized type when the user expands it in the variable windows. It accepts a list of child nodes, which in turn define the child elements. It is important to know that Expand
 node is optional and if no Expand is specified in a visualizer entry, Visual Studio&rsquo;s default expansion rules will be used. If an expand node is specified with no child nodes under it, then the type won&rsquo;t be expandable in the debugger windows (i.e.
 no plus sign next to the variable name).</p>
<h4>Item Expansion</h4>
<p style="text-align:justify">The Item node, which is the most basic and most common node to be used under an Expand node, defines a single child element. For instance, if you have a CRect class with top, left, right, bottom as its fields and the following
 visualizer entry</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Type Name=&quot;CRect&quot;&gt;
  &lt;DisplayString&gt;{{top={top} bottom={bottom} left={left} right={right}}}&lt;/DisplayString&gt;
  &lt;Expand&gt;
    &lt;Item Name=&quot;Width&quot;&gt;right - left&lt;/Item&gt;
    &lt;Item Name=&quot;Height&quot;&gt;bottom - top&lt;/Item&gt;
  &lt;/Expand&gt;
&lt;/Type&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;CRect&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span><span class="xml__tag_start">&gt;{</span>{top={top}&nbsp;bottom={bottom}&nbsp;left={left}&nbsp;right={right}}}<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Expand</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Item</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;Width&quot;</span><span class="xml__tag_start">&gt;</span>right&nbsp;-&nbsp;left<span class="xml__tag_end">&lt;/Item&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Item</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;Height&quot;</span><span class="xml__tag_start">&gt;</span>bottom&nbsp;-&nbsp;top<span class="xml__tag_end">&lt;/Item&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Expand&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Type&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">then CRect type is going to look like below</div>
<p><img id="60732" src="60732-expand-item.png" alt="" width="564" height="87" style="display:block; margin-left:auto; margin-right:auto"></p>
<p style="text-align:justify">The expressions specified in Width and Height elements are evaluated and shown in the value column.&nbsp;An additional point to remember is if the expression of the item element points to a complex type then the Item node itself
 will be expandable.</p>
<h4>ArrayItems Expansion</h4>
<p>ArrayItems node can be used to have the debugger interpret the type as an array and display its individual elements. The visualizer for std::vector is a good example using this node:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Type Name=&quot;std::vector&amp;lt;*&amp;gt;&quot;&gt;
  &lt;DisplayString&gt;{{size = {_Mylast - _Myfirst}}}&lt;/DisplayString&gt;
  &lt;Expand&gt;
    &lt;Item Name=&quot;[size]&quot;&gt;_Mylast - _Myfirst&lt;/Item&gt;
    &lt;Item Name=&quot;[capacity]&quot;&gt;(_Myend - _Myfirst)&lt;/Item&gt;
    &lt;ArrayItems&gt;
      &lt;Size&gt;_Mylast - _Myfirst&lt;/Size&gt;
      &lt;ValuePointer&gt;_Myfirst&lt;/ValuePointer&gt;
    &lt;/ArrayItems&gt;
  &lt;/Expand&gt;
&lt;/Type&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;std::vector&amp;lt;*&amp;gt;&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span><span class="xml__tag_start">&gt;{</span>{size&nbsp;=&nbsp;{_Mylast&nbsp;-&nbsp;_Myfirst}}}<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Expand</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Item</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;[size]&quot;</span><span class="xml__tag_start">&gt;</span>_Mylast&nbsp;-&nbsp;_Myfirst<span class="xml__tag_end">&lt;/Item&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Item</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;[capacity]&quot;</span><span class="xml__tag_start">&gt;</span>(_Myend&nbsp;-&nbsp;_Myfirst)<span class="xml__tag_end">&lt;/Item&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ArrayItems</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Size</span><span class="xml__tag_start">&gt;</span>_Mylast&nbsp;-&nbsp;_Myfirst<span class="xml__tag_end">&lt;/Size&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ValuePointer</span><span class="xml__tag_start">&gt;</span>_Myfirst<span class="xml__tag_end">&lt;/ValuePointer&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/ArrayItems&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Expand&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Type&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">A std::vector shows its individual elements when expanded in the variable window:</div>
<p><img id="60834" src="60834-arrayitems.png" alt="" width="583" height="146" style="display:block; margin-left:auto; margin-right:auto"></p>
<p style="text-align:justify">At a minimum, the ArrayItems node must have the <strong>
'</strong>Size<strong>'</strong> expression (which must evaluate to an integer) for the debugger to understand the length of the array and the 'ValuePointer' expression that should point to the first element (which must be a pointer of the element type that
 is not void*). The array lower bound is assumed to be 0 which can be overridden by using 'LowerBound'&nbsp;node (examples of this can be found in the default natvis files shipped with Visual Studio).</p>
<p style="text-align:justify">Multi-dimensional arrays can also be specified. The debugger needs just a little bit more information to properly display child elements in that case:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Type Name=&quot;Concurrency::array&amp;lt;*,*&amp;gt;&quot;&gt;
  &lt;DisplayString&gt;extent = {_M_extent}&lt;/DisplayString&gt;
  &lt;Expand&gt;
    &lt;Item Name=&quot;extent&quot;&gt;_M_extent&lt;/Item&gt;
    &lt;ArrayItems Condition=&quot;_M_buffer_descriptor._M_data_ptr != 0&quot;&gt;
      &lt;Direction&gt;Forward&lt;/Direction&gt;
      &lt;Rank&gt;$T2&lt;/Rank&gt;
      &lt;Size&gt;_M_extent._M_base[$i]&lt;/Size&gt;
      &lt;ValuePointer&gt;($T1*) _M_buffer_descriptor._M_data_ptr&lt;/ValuePointer&gt;
    &lt;/ArrayItems&gt;
  &lt;/Expand&gt;
&lt;/Type&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;Concurrency::array&amp;lt;*,*&amp;gt;&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span><span class="xml__tag_start">&gt;</span>extent&nbsp;=&nbsp;{_M_extent}<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Expand</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Item</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;extent&quot;</span><span class="xml__tag_start">&gt;</span>_M_extent<span class="xml__tag_end">&lt;/Item&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ArrayItems</span>&nbsp;<span class="xml__attr_name">Condition</span>=<span class="xml__attr_value">&quot;_M_buffer_descriptor._M_data_ptr&nbsp;!=&nbsp;0&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Direction</span><span class="xml__tag_start">&gt;</span>Forward<span class="xml__tag_end">&lt;/Direction&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Rank</span><span class="xml__tag_start">&gt;$</span>T2<span class="xml__tag_end">&lt;/Rank&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Size</span><span class="xml__tag_start">&gt;</span>_M_extent._M_base[$i]<span class="xml__tag_end">&lt;/Size&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ValuePointer</span><span class="xml__tag_start">&gt;</span>($T1*)&nbsp;_M_buffer_descriptor._M_data_ptr<span class="xml__tag_end">&lt;/ValuePointer&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/ArrayItems&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Expand&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Type&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="text-align:justify">'Direction' specifies whether the array is row-major or column-major order. 'Rank'&nbsp;specifies the rank of the array. 'Size' element accepts the implicit '$i' parameter which it substitutes with dimension
 index to find the length of the array in that dimension. For instance, in the example above the expression _M_extent.M_base[0] should give the length of the 0<sup>th</sup> dimension, _M_extent._M_base[1] the 1<sup>st</sup> and so on.</div>
<h4>IndexListItems Expansion</h4>
<p style="text-align:justify">ArrayItems assume array elements are laid out contiguously in memory. Debugger gets to the next element by simply incrementing its pointer to the current element. To support cases where you need to manipulate the index to the value
 node, index list items can be used. Here&rsquo;s a visualizer using 'IndexListItems' node:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Type Name=&quot;Concurrency::multi_link_registry&amp;lt;*&amp;gt;&quot;&gt;
  &lt;DisplayString&gt;{{size = {_M_vector._M_index}}}&lt;/DisplayString&gt;
  &lt;Expand&gt;
    &lt;Item Name=&quot;[size]&quot;&gt;_M_vector._M_index&lt;/Item&gt;
    &lt;IndexListItems&gt;
      &lt;Size&gt;_M_vector._M_index&lt;/Size&gt;
      &lt;ValueNode&gt;*(_M_vector._M_array[$i])&lt;/ValueNode&gt;
    &lt;/IndexListItems&gt;
  &lt;/Expand&gt;
&lt;/Type&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;Concurrency::multi_link_registry&amp;lt;*&amp;gt;&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span><span class="xml__tag_start">&gt;{</span>{size&nbsp;=&nbsp;{_M_vector._M_index}}}<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Expand</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Item</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;[size]&quot;</span><span class="xml__tag_start">&gt;</span>_M_vector._M_index<span class="xml__tag_end">&lt;/Item&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;IndexListItems</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Size</span><span class="xml__tag_start">&gt;</span>_M_vector._M_index<span class="xml__tag_end">&lt;/Size&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ValueNode</span><span class="xml__tag_start">&gt;*</span>(_M_vector._M_array[$i])<span class="xml__tag_end">&lt;/ValueNode&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/IndexListItems&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Expand&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Type&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="text-align:justify">The only difference between ArrayItems and IndexListItems is that the 'ValueNode' expects the full expression to the i<sup>th</sup>&nbsp; element with the implicit '$i' parameter.</div>
<h4>LinkedListItems Expansion</h4>
<p style="text-align:justify">If the visualized type represents a linked list, debugger can be instructed to display its children via 'LinkedListItems' node. Here&rsquo;s the visualizer for the CAtlList type using this node:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Type Name=&quot;ATL::CAtlList&amp;lt;*,*&amp;gt;&quot;&gt;
  &lt;DisplayString&gt;{{Count = {m_nElements}}}&lt;/DisplayString&gt;
  &lt;Expand&gt;
    &lt;Item Name=&quot;Count&quot;&gt;m_nElements&lt;/Item&gt;
    &lt;LinkedListItems&gt;
      &lt;Size&gt;m_nElements&lt;/Size&gt;
      &lt;HeadPointer&gt;m_pHead&lt;/HeadPointer&gt;
      &lt;NextPointer&gt;m_pNext&lt;/NextPointer&gt;
      &lt;ValueNode&gt;m_element&lt;/ValueNode&gt;
    &lt;/LinkedListItems&gt;
  &lt;/Expand&gt;
&lt;/Type&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;ATL::CAtlList&amp;lt;*,*&amp;gt;&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span><span class="xml__tag_start">&gt;{</span>{Count&nbsp;=&nbsp;{m_nElements}}}<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Expand</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Item</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;Count&quot;</span><span class="xml__tag_start">&gt;</span>m_nElements<span class="xml__tag_end">&lt;/Item&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;LinkedListItems</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Size</span><span class="xml__tag_start">&gt;</span>m_nElements<span class="xml__tag_end">&lt;/Size&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;HeadPointer</span><span class="xml__tag_start">&gt;</span>m_pHead<span class="xml__tag_end">&lt;/HeadPointer&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;NextPointer</span><span class="xml__tag_start">&gt;</span>m_pNext<span class="xml__tag_end">&lt;/NextPointer&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ValueNode</span><span class="xml__tag_start">&gt;</span>m_element<span class="xml__tag_end">&lt;/ValueNode&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/LinkedListItems&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Expand&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Type&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="text-align:justify">'Size' expression refers to the length of the list, 'HeadPointer' points to the first element, 'NextPointer' refers to the next element, and 'ValueNode' refers to the value of the item. Two important points
 to remember with LinkedListItems node are:</div>
<div class="endscriptcode" style="text-align:justify">
<ol>
<li>'NextPointer' and 'ValueNode' expressions are evaluated under the context of the linked list node element and not the parent list type. In the example above, CAtlList has a CNode class (can be found in atlcoll.h) that represents a node of the linked list.
 m_pNext and m_element are fields of that CNode class and not of CAtlList class.&nbsp;
</li><li>'ValueNode' can be left empty or have 'this' to refer to the linked list node itself.
</li></ol>
</div>
<h4>TreeItems Expansion</h4>
<p style="text-align:justify">If the visualized type represents a tree, debugger can walk the tree and display its children via 'TreeItems'&nbsp;node. Here&rsquo;s the visualizer for the std::map type using this expansion:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Type Name=&quot;std::map&amp;lt;*&amp;gt;&quot;&gt;
  &lt;DisplayString&gt;{{size = {_Mysize}}}&lt;/DisplayString&gt;
  &lt;Expand&gt;
    &lt;Item Name=&quot;[size]&quot;&gt;_Mysize&lt;/Item&gt;
    &lt;Item Name=&quot;[comp]&quot;&gt;comp&lt;/Item&gt;
    &lt;TreeItems&gt;
      &lt;Size&gt;_Mysize&lt;/Size&gt;
      &lt;HeadPointer&gt;_Myhead-&amp;gt;_Parent&lt;/HeadPointer&gt;
      &lt;LeftPointer&gt;_Left&lt;/LeftPointer&gt;
      &lt;RightPointer&gt;_Right&lt;/RightPointer&gt;
      &lt;ValueNode Condition=&quot;!((bool)_Isnil)&quot;&gt;_Myval&lt;/ValueNode&gt;
    &lt;/TreeItems&gt;
  &lt;/Expand&gt;
&lt;/Type&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;std::map&amp;lt;*&amp;gt;&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span><span class="xml__tag_start">&gt;{</span>{size&nbsp;=&nbsp;{_Mysize}}}<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Expand</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Item</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;[size]&quot;</span><span class="xml__tag_start">&gt;</span>_Mysize<span class="xml__tag_end">&lt;/Item&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Item</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;[comp]&quot;</span><span class="xml__tag_start">&gt;</span>comp<span class="xml__tag_end">&lt;/Item&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;TreeItems</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Size</span><span class="xml__tag_start">&gt;</span>_Mysize<span class="xml__tag_end">&lt;/Size&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;HeadPointer</span><span class="xml__tag_start">&gt;</span>_Myhead-<span class="xml__entity">&amp;gt;</span>_Parent<span class="xml__tag_end">&lt;/HeadPointer&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;LeftPointer</span><span class="xml__tag_start">&gt;</span>_Left<span class="xml__tag_end">&lt;/LeftPointer&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;RightPointer</span><span class="xml__tag_start">&gt;</span>_Right<span class="xml__tag_end">&lt;/RightPointer&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ValueNode</span>&nbsp;<span class="xml__attr_name">Condition</span>=<span class="xml__attr_value">&quot;!((bool)_Isnil)&quot;</span><span class="xml__tag_start">&gt;</span>_Myval<span class="xml__tag_end">&lt;/ValueNode&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/TreeItems&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Expand&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Type&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="text-align:justify">The syntax is very similar to LinkedListItems node. 'LeftPointer', 'RightPointer', 'ValueNode' are evaluated under the context of the tree node class, and 'ValueNode' can be left empty or have &ldquo;this&rdquo;
 to refer to the tree node itself.</div>
<h4>ExpandedItem Expansion</h4>
<p style="text-align:justify">ExpandedItem can be used to generate an aggregated children view by having properties coming from base classes or data members displayed as if they were children of the visualized type. The specified expression is evaluated and
 the child nodes of the result are appended to the children list of the visualized type. For instance, suppose we have a smart pointer type auto_ptr&lt;vector&lt;int&gt;&gt; which will normally be displayed as:</p>
<p><img id="60835" src="60835-expanded-item1.png" alt="" width="624" height="127" style="display:block; margin-left:auto; margin-right:auto"></p>
<p style="text-align:justify">To see the values of the vector, we need to drill down two levels in the variable window passing through _Myptr member. Adding a visualizer entry using ExpandedItem element:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Type Name=&quot;std::auto_ptr&amp;lt;*&amp;gt;&quot;&gt;
  &lt;DisplayString&gt;auto_ptr {*_Myptr}&lt;/DisplayString&gt;
  &lt;Expand&gt;
    &lt;ExpandedItem&gt;_Myptr&lt;/ExpandedItem&gt;
  &lt;/Expand&gt;
&lt;/Type&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;std::auto_ptr&amp;lt;*&amp;gt;&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span><span class="xml__tag_start">&gt;</span>auto_ptr&nbsp;{*_Myptr}<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Expand</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ExpandedItem</span><span class="xml__tag_start">&gt;</span>_Myptr<span class="xml__tag_end">&lt;/ExpandedItem&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Expand&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Type&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">we can eliminate _Myptr variable from the hierarchy and directly view vector elements:</div>
<p><img id="60836" src="60836-expanded-item2.png" alt="" width="624" height="95" style="display:block; margin-left:auto; margin-right:auto"></p>
<h4>Synthetic Item Expansion</h4>
<p style="text-align:justify">'Synthetic' node allows one to create an artificial child element (i.e. one that is not a result of an expression) which might contain children elements on its own. The example below shows two such nodes which is, it is used to
 create an artificial node:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Type Name=&quot;Rectangle&quot;&gt; 
  &lt;Expand&gt; 
    &lt;Synthetic Name=&quot;Am I a square?&quot; Condition=&quot;height==width&quot;&gt; 
      &lt;DisplayString&gt;Yes I am. &lt;/DisplayString&gt;
    &lt;/Synthetic&gt; 
    &lt;Synthetic Name=&quot;Am I a square?&quot; Condition=&quot;height!=width&quot;&gt; 
      &lt;DisplayString&gt;No I am not.&lt;/DisplayString&gt;
    &lt;/Synthetic&gt; 
  &lt;/Expand&gt; 
&lt;/Type&gt; </pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;Rectangle&quot;</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Expand</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Synthetic</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;Am&nbsp;I&nbsp;a&nbsp;square?&quot;</span>&nbsp;<span class="xml__attr_name">Condition</span>=<span class="xml__attr_value">&quot;height==width&quot;</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span><span class="xml__tag_start">&gt;</span>Yes&nbsp;I&nbsp;am.&nbsp;<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Synthetic&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Synthetic</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;Am&nbsp;I&nbsp;a&nbsp;square?&quot;</span>&nbsp;<span class="xml__attr_name">Condition</span>=<span class="xml__attr_value">&quot;height!=width&quot;</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span><span class="xml__tag_start">&gt;</span>No&nbsp;I&nbsp;am&nbsp;not.<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Synthetic&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Expand&gt;</span>&nbsp;&nbsp;
<span class="xml__tag_end">&lt;/Type&gt;</span>&nbsp;</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">Visualizer &ndash; Type Matching</h2>
<p style="text-align:justify">Here are the general rules governing how visualizers are matched with types to be viewed in the debugger windows:</p>
<ul>
<li style="text-align:justify">A visualizer entry is applicable for the type specified in its name attribute AND for all the types that are derived from it. If there is a visualizer for both a base class and the derived class, the derived class visualizer takes
 precedence. </li><li style="text-align:justify">Name attribute of the Type element accepts &ldquo;*&rdquo; as a wildcard character that can be used for templated class names:
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Type Name=&quot;ATL::CAtlArray&amp;lt;*&amp;gt;&quot;&gt;
  &lt;DisplayString&gt;{{Count = {m_nSize}}}&lt;/DisplayString&gt;
&lt;/Type&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;ATL::CAtlArray&amp;lt;*&amp;gt;&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span><span class="xml__tag_start">&gt;{</span>{Count&nbsp;=&nbsp;{m_nSize}}}<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Type&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="text-align:justify">Here, the same visualizer will be used whether the object is a CAtlArray&lt;int&gt; or a CAtlArray&lt;float&gt;. If there is another visualizer entry for a &ldquo;CAtlArray&lt;float&gt;&rdquo; then it
 takes precedence over the generic one.&nbsp;</div>
<div class="endscriptcode" style="text-align:justify"></div>
<div class="endscriptcode" style="text-align:justify">Note that template parameters can be referenced in the visualizer entry by using macros
<strong>$T1, $T2</strong>&hellip; Please see the visualizer files shipped with Visual Studio to find examples of these.</div>
</li></ul>
<ul>
<li>If a visualizer entry fails to parse and validate then the next available visualizer is used.
</li></ul>
<h2>Versioning</h2>
<p style="text-align:justify">Visualizers can be scoped to specific modules and their versions so that name collisions can be minimized and different visualizers can be used for different versions of the types. The optional version element is used to specify
 this. For instance:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">  &lt;Type Name=&quot;DirectUI::Border&quot;&gt;
    &lt;Version Name=&quot;Windows.UI.Xaml.dll&quot; Min=&quot;1.0&quot; Max=&quot;1.5&quot;/&gt;
    &lt;DisplayString&gt;{{Name = {*(m_pDO-&amp;gt;m_pstrName)}}}&lt;/DisplayString&gt;
    &lt;Expand&gt;
      &lt;ExpandedItem&gt;*(CBorder*)(m_pDO)&lt;/ExpandedItem&gt;    &lt;/Expand&gt;
  &lt;/Type&gt;</pre>
<div class="preview">
<pre class="xml">&nbsp;&nbsp;<span class="xml__tag_start">&lt;Type</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;DirectUI::Border&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Version</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;Windows.UI.Xaml.dll&quot;</span>&nbsp;<span class="xml__attr_name">Min</span>=<span class="xml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xml__attr_name">Max</span>=<span class="xml__attr_value">&quot;1.5&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;DisplayString</span><span class="xml__tag_start">&gt;{</span>{Name&nbsp;=&nbsp;{*(m_pDO-<span class="xml__entity">&amp;gt;</span>m_pstrName)}}}<span class="xml__tag_end">&lt;/DisplayString&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Expand</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ExpandedItem</span><span class="xml__tag_start">&gt;*</span>(CBorder*)(m_pDO)<span class="xml__tag_end">&lt;/ExpandedItem&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Expand&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Type&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="text-align:justify"><span style="text-align:justify">Here, the visualizer is only applicable for the DirectUI::Border type found in the Windows.UI.Xaml.dll from version 1.0 to 1.5. Note that while adding version elements
 will scope visualizer entry to a particular module / version and reduce inadvertent matches, if a type is defined in a common header file that is used by different modules, it will prevent the visualizer from taking effect when the type is not in the specified
 module.</span></div>
<div class="endscriptcode" style="text-align:justify"><span style="text-align:justify"><br>
</span></div>
<h2 style="text-align:justify">VSIX deployment</h2>
<p style="text-align:justify">You can always manually copy natvis files to one of the predetermined locations for the debugger to discover and load them but you can make it easier for the developers using your visualizers to deploy them via VSIX.&nbsp;</p>
<p style="text-align:justify">The attached sample project shows how you can do this which is actually pretty simple and straightforward. Once you create your natvis file and add it to your project, you need to</p>
<ol>
<li>Include it in VSIX by going to the property tab for the natvis file and set 'Include in VSIX' attribute to 'True'.
</li><li>&nbsp;Declare it as a NativeVisualizer asset in the vsixmanifest: </li></ol>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;PackageManifest ...&gt;
  ...
  &lt;Assets&gt;
    &lt;Asset Type=&quot;NativeVisualizer&quot; Path=&quot;vector.natvis&quot;/&gt;
  &lt;/Assets&gt;
&lt;/PackageManifest&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;PackageManifest</span>&nbsp;...<span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;...&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Assets</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Asset</span>&nbsp;<span class="xml__attr_name">Type</span>=<span class="xml__attr_value">&quot;NativeVisualizer&quot;</span>&nbsp;<span class="xml__attr_name">Path</span>=<span class="xml__attr_value">&quot;vector.natvis&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Assets&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/PackageManifest&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode" style="text-align:justify">Once you build the attached project and install it, you can try viewing variables of type std::vector&lt;int&gt;. You should see 'CUSTOM VISUALIZER: ...' in the value column for them.</div>
