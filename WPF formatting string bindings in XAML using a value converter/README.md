# WPF formatting string bindings in XAML using a value converter
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- XAML
## Topics
- Data Binding
- User Interface
- WPF
- XAML
- How to
## Updated
- 12/18/2014
## Description

<h1>Introduction</h1>
<p>WPF provides support for formatting strings when binding using <a href="http://msdn.microsoft.com/en-us/library/system.windows.data.bindingbase.stringformat.aspx" target="_blank">
StringFormat</a> or <a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.contentcontrol.contentstringformat.aspx" target="_blank">
ContentStringFormat</a>. However there are still scenarios where some extra coding is required to get the desired results.</p>
<p>For instance an application may have an alphanumeric order reference &quot;<strong>ON1029HH00CD</strong>&quot;. A requirement might be for the reference to be displayed in a TextBlock or Label in a more friendly format: &quot;<strong>ON:1029-HH00 CD</strong>&quot;.</p>
<p><img id="131394" src="131394-customstringformatexample.png" alt="" width="460" height="250"></p>
<p>This&nbsp;sample shows how&nbsp;to create a custom value converter that accepts a text mask parameter. This is then applied within the Convert method&nbsp;by a MaskTextProvider&nbsp;to format the bound string value.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>For a full description of how to implement the value converter and use it&nbsp;there is a&nbsp;Technet WIKI article to accompany this sample&nbsp;<a href="http://social.technet.microsoft.com/wiki/contents/articles/18623.formatting-string-binding-in-xaml-using-a-value-converter.aspx ">here</a>.
 The sample contains&nbsp;the&nbsp;value converter&nbsp;show below along with examples of how to use it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CustomStringFormatConverter&nbsp;:&nbsp;IValueConverter&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;Convert(<span class="cs__keyword">object</span>&nbsp;<span class="cs__keyword">value</span>,&nbsp;Type&nbsp;targetType,&nbsp;<span class="cs__keyword">object</span>&nbsp;parameter,&nbsp;System.Globalization.CultureInfo&nbsp;culture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;mask&nbsp;=&nbsp;parameter&nbsp;<span class="cs__keyword">as</span>&nbsp;<span class="cs__keyword">string</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;inString&nbsp;=&nbsp;<span class="cs__keyword">value</span>&nbsp;<span class="cs__keyword">as</span>&nbsp;<span class="cs__keyword">string</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(mask&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&nbsp;inString&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaskedTextProvider&nbsp;mtp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MaskedTextProvider(mask);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(mtp.Set(inString))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;mtp.ToDisplayString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;DependencyProperty.UnsetValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;ConvertBack(<span class="cs__keyword">object</span>&nbsp;<span class="cs__keyword">value</span>,&nbsp;Type&nbsp;targetType,&nbsp;<span class="cs__keyword">object</span>&nbsp;parameter,&nbsp;System.Globalization.CultureInfo&nbsp;culture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;NotImplementedException();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>To use the value converter first add a namespace declaration in the XAML to the namepsace it is under. Then add the value converter as a resource. After that you can use the Converrter in a binding declaration and set the ConverterParameter to a valid text
 mask. For more informaton on the masking format see MSDN <a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.maskedtextbox.mask.aspx">
here</a>. Examples are prodivded in the sample.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;TestString,&nbsp;Converter={StaticResource&nbsp;CustomStringFormat},ConverterParameter='AA:AAAA-AAAA&nbsp;AA',FallbackValue='format&nbsp;failed'}&quot;</span><span class="xaml__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<h1>Summary</h1>
<p>If you have any questions or suggestions for improvement regarding this sample please feel free to leave them in the Q and A section.</p>
