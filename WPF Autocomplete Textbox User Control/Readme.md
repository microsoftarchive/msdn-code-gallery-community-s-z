# WPF Autocomplete Textbox User Control
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- Controls
- User Controls
- custom controls
## Updated
- 01/11/2012
## Description

<h1>Introduction</h1>
<p style="text-align:justify">This sample is used to create an autocomplete textbox which can be used in Windows Presentation Foundation application as a user control of type textbox which consists of autocompleting entries that can be populated either manually
 by codebehind file with .cs extension or by using the database table column.</p>
<h1><span>Building the Sample</span></h1>
<p style="text-align:justify"><em><em><span style="color:black; line-height:115%">For building the sample download the entire project or create a new project add all files named AutoCompleteEntry.cs, AutoCompleteTextbox.xaml, AutoCompleteTextbox.xaml.cs, Window1.xaml
 and Window1.xaml.cs.</span></em></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p style="text-align:justify"><em>In this project we are creating a class file named AutoCompleteEntry.cs which consists of properties KeywordStrings as a readonly property to get the autocomplete strings. DisplayName that is used to either get or set the value
 to the property, Autocompleteentry method that contains two parameters one of type string and othe param arrya of type string which sets the displayname and keywords to be identified in Autocomplete. The ToString() method is overrided to return the DisplayString
 variable which is the identified automatic word that is achieved as the characters are typed in the Textbox. We have a file AutoCompleteTextbox.xaml which is a canvas of certain width and height that is used as a user control in the form of a textbox. The
 codebehind file contains the entire code to convert the canvas and render it as an Autocomplete Textbox and provide inputs as strings which come on top as characters are typed over. The Window1.xaml is used to use and test the control and Window1.xaml.cs is
 the codebehind file that is used to add items in the Textbox manually in this project but you can use the Database table columnn values and use the enjoyable autocomplete feature. Clear button is used to empty the textbox.</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!--AutoCompleteTextbox.xaml file --&gt; 
&lt;Canvas x:Class=&quot;WPFAutoCompleteTextbox.AutoCompleteTextBox&quot; 
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot; 
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot; Height=&quot;300&quot; Width=&quot;300&quot;&gt; 
&lt;/Canvas&gt; 
 
 
 
&lt;!-- Window1.xaml file --&gt; 
&lt;Window x:Class=&quot;WPFAutoCompleteTextbox.Window1&quot; 
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot; 
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot; 
    xmlns:local=&quot;clr-namespace:WPFAutoCompleteTextbox&quot;         
    Title=&quot;WPF AutoCompleteTextBox&quot; Height=&quot;200&quot; Width=&quot;300&quot;&gt; 
    &lt;StackPanel Background=&quot;SteelBlue&quot;&gt; 
        &lt;Button Name=&quot;button1&quot; Height=&quot;23&quot; Width=&quot;75&quot; Margin=&quot;20&quot; Click=&quot;button1_Click&quot; HorizontalAlignment=&quot;Left&quot;&gt;Clear&lt;/Button&gt; 
        &lt;local:AutoCompleteTextBox Height=&quot;23&quot; Width=&quot;240&quot; x:Name=&quot;textBox1&quot; DelayTime=&quot;500&quot; Threshold=&quot;2&quot;/&gt; 
    &lt;/StackPanel&gt; 
&lt;/Window&gt; 
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__comment">&lt;!--AutoCompleteTextbox.xaml&nbsp;file&nbsp;--&gt;</span>&nbsp;&nbsp;
<span class="xaml__tag_start">&lt;Canvas</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;WPFAutoCompleteTextbox.AutoCompleteTextBox&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;300&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;300&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Canvas&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="xaml__comment">&lt;!--&nbsp;Window1.xaml&nbsp;file&nbsp;--&gt;</span>&nbsp;&nbsp;
<span class="xaml__tag_start">&lt;Window</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;WPFAutoCompleteTextbox.Window1&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">local</span>=<span class="xaml__attr_value">&quot;clr-namespace:WPFAutoCompleteTextbox&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;WPF&nbsp;AutoCompleteTextBox&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;200&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;300&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;SteelBlue&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;button1&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;23&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;75&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;20&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;button1_Click&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span><span class="xaml__tag_start">&gt;</span>Clear<span class="xaml__tag_end">&lt;/Button&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:AutoCompleteTextBox&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;23&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;240&quot;</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;textBox1&quot;</span>&nbsp;<span class="xaml__attr_name">DelayTime</span>=<span class="xaml__attr_value">&quot;500&quot;</span>&nbsp;<span class="xaml__attr_name">Threshold</span>=<span class="xaml__attr_value">&quot;2&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;&nbsp;
<span class="xaml__tag_end">&lt;/Window&gt;</span>&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<p>&nbsp;</p>
<ul>
<li style="text-align:justify"><em>AutoCompleteEntry.cs - Class file that is used to complete the autocomplete entry of a textbox in the form of properties and methods.</em>
</li><li style="text-align:justify"><em>AutoCompleteTextbox.xaml - Usercontrol designer xaml file</em>
</li><li style="text-align:justify"><em>AutoCompleteTextbox.xaml.cs - File that is used to render the usercontrol as a textbox on the WPF Window along with the properties and methods that is used to provide the Autocomplete functionality.</em>
</li><li><em>Window1.xaml - WPF Window with a user control autocomplete textbox and a button</em>
</li><li style="text-align:justify"><em>Window1.xaml.cs - Implementation of the autocomplete textbox control on WPF Window</em>
</li></ul>
