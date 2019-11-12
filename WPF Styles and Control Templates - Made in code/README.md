# WPF Styles and Control Templates - Made in code
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- Controls
- XAML Control Templates
- Styling WPF Controls
- WPF Control Templating
## Updated
- 09/19/2012
## Description

<h1>Introduction</h1>
<div><br>
This is an examination of many aspects of writing Styles and Control Templates in code.
<br>
The accompanying project contains all the code for recreating various controls, and a few solutions to common problems.</div>
<div><br>
I also list some of the common errors encountered and how to get round the limitations.<br>
<br>
<img id="62165" src="62165-controltemplating.png" alt="" width="601" height="415"></div>
<h1>Building the Sample</h1>
<div><br>
Just download, unblock, unzip, open and run!<br>
<br>
</div>
<h1>Description</h1>
<div><br>
A ControlTemplate is like a schematic, showing the relationships of the elements. Each element within has it's own blueprint. These are not actual controls.<br>
<br>
A control template is a design, waiting for you to print a hard copy<br>
<br>
When you see how the AppendChild method works, you realise difference between HTML and XAML markup formats. HTML places the item in the cell and uses a DOM to map items.<br>
<br>
Here is an example of a simple ControlTemplate in XAML.<br>
<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Window&nbsp;...snip&nbsp;...&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Window.Resources&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ControlTemplate&nbsp;x:Key=<span class="js__string">&quot;LabelAsGroupBox&quot;</span>&nbsp;TargetType=<span class="js__string">&quot;ContentControl&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GroupBox&nbsp;Header=<span class="js__string">&quot;{TemplateBinding&nbsp;Content}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ControlTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Window.Resources&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Label&nbsp;Content=<span class="js__string">&quot;Test&nbsp;this&quot;</span>&nbsp;Template=<span class="js__string">&quot;{StaticResource&nbsp;LabelAsGroupBox}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&lt;/Window&gt;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<br>
Below is a real and very pervasive Style and ControlTemplate:<br>
<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Style&nbsp;x:Key=<span class="js__string">&quot;Button<strong>FocusVisual</strong>&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;Control.Template&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter.Value&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ControlTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle&nbsp;Margin=<span class="js__string">&quot;2&quot;</span>&nbsp;SnapsToDevicePixels=<span class="js__string">&quot;true&quot;</span>&nbsp;Stroke=<span class="js__string">&quot;{DynamicResource&nbsp;{x:Static&nbsp;SystemColors.ControlTextBrushKey}}&quot;</span>&nbsp;StrokeThickness=<span class="js__string">&quot;1&quot;</span>&nbsp;StrokeDashArray=<span class="js__string">&quot;1&nbsp;2&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ControlTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Setter.Value&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Setter&gt;&nbsp;
&lt;/Style&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<br>
Notice it has no TargetType, as it is not changing any specialised properties, or control template properties.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Below is the coded equivalent:<br>
<br>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">Style&nbsp;MakeButtonFocusVisualStyle()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ControlTemplate&nbsp;template&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ControlTemplate();&nbsp;<span class="js__sl_comment">//Notice&nbsp;no&nbsp;TargetType</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;rec&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FrameworkElementFactory(<span class="js__operator">typeof</span>(Rectangle));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;rec.SetValue(FrameworkElement.MarginProperty,&nbsp;<span class="js__operator">new</span>&nbsp;Thickness(<span class="js__num">2</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;rec.SetValue(Shape.StrokeProperty,&nbsp;<span class="js__operator">new</span>&nbsp;DynamicResourceExtension(SystemColors.ControlTextBrushKey));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;rec.SetValue(Shape.StrokeThicknessProperty,&nbsp;<span class="js__num">1</span>.0D);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;rec.SetValue(Shape.StrokeDashArrayProperty,&nbsp;<span class="js__operator">new</span>&nbsp;DoubleCollection&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__num">1</span>.0D,&nbsp;<span class="js__num">2</span>.0D&nbsp;<span class="js__brace">}</span>);&nbsp;<span class="js__sl_comment">//this&nbsp;&nbsp;makes&nbsp;the&nbsp;focus&nbsp;visual&nbsp;dashes</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;template.VisualTree&nbsp;=&nbsp;rec;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;style&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Style();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;style.Setters.Add(<span class="js__operator">new</span>&nbsp;Setter(Control.TemplateProperty,&nbsp;template));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;style;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<h3>Removing VisualFocusStyle</h3>
<div>The standard VisualFocusStyle is defined in the Theme and applied to all controls by default. I only show it in my example to show how you can change it, how to apply it to resources and how to reference it from other controls. Microsoft recommends only
 changing this at Theme level, for giving the user a consistent effect to all controls, but if you have a heavily re-styled control, or are just sick of it, you can to strip it off, here are some examples of how to remove it.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//Direct access </span> 
myControl.VisualFocusStyle = null; 
 
<span class="js__sl_comment">//As used in templates (and direct) </span> 
myControl.SetValue(myControl.SetValue(Control.VisualFocusStyle, null);</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;!-- In a template --&gt;  
&lt;Setter Property=<span class="js__string">&quot;VisualFocusStyle&quot;</span> Value=<span class="js__string">&quot;{x:Null}&quot;</span> /&gt; 
 
&lt;!-- <span class="js__operator">in</span> the control's markup --&gt; 
&lt;Border VisualFocusStyle=<span class="js__string">&quot;{x:Null}&quot;</span> /&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
</div>
</div>
</div>
</div>
</div>
<h3>Style Setters</h3>
<div>Styles consist entirely of a bunch of <a href="http://msdn.microsoft.com/en-us/library/ms589786">
Setters</a>. These simply set the value of properties on an object. Setters do not only change colours and other basic control properties. Template is also a property of the control, so you can set the ControlTemplate from within a style, as shown above.<br>
<br>
</div>
<h3>FrameworkElementFactory</h3>
<div>This template has only one <a href="http://msdn.microsoft.com/en-us/library/system.windows.frameworkelementfactory.aspx">
FrameworkElementFactory</a> (FEF), which is like a blueprint, for a Rectangle. As the FEF is a generic control, it does not itself have the actual properties, so you can't set them directly. We use the FEF's
<a href="http://msdn.microsoft.com/en-us/library/system.windows.frameworkelementfactory.setvalue.aspx">
SetValue</a> method to &quot;line up&quot; the settings, for when the control is actually rendered. Like saying &quot;<em>This factory produces a Rectangle and when it does, here are it's properties</em>&quot;. To build up the
<a href="http://msdn.microsoft.com/en-us/library/ms753391.aspx#two_trees">VisualTree</a> of the control, we use
<a href="http://msdn.microsoft.com/en-us/library/system.windows.frameworkelementfactory.appendchild.aspx">
AppendChild</a> to add children factories to parent factories. The VisualTree is different from the
<a href="http://msdn.microsoft.com/en-us/library/ms753391.aspx#logical_tree">LogicalTree</a>. The VisualTree is interesting to understand because events travel along the VisualTree.<br>
<br>
</div>
<h3>Base or Derived Properties</h3>
<div>You will notice throughout this example project that I have taken properties right back to their base properties. For example, in the style above I use FrameworkElement.MarginProperty instead of derived Rectangle.MarginProperty. This makes no difference,
 which is interesting to know, as it makes it easier to cut and paste chunks of code when creating more controls, because for example, both a Rectangle and an Ellipse derive from FrameworkElement.</div>
<div>&nbsp;</div>
<h3>DynamicResourceExtension</h3>
<div>The template above uses a <a href="http://msdn.microsoft.com/en-us/library/system.windows.dynamicresourceextension.aspx">
<strong>DynamicResourceExtension</strong></a> object, which is a blueprint for the actual
<a href="http://msdn.microsoft.com/en-us/library/ms748942.aspx">DynamicResource Markup Extension</a> shown within the curly brackets, in the XAML version above. Dynamic resources are references to resources which the compiler defers until run-time. For example,
 system colours are user specific, so cannot be hard coded into the application. This kind of object uses the x:Key to find the resource.</div>
<div>&nbsp;</div>
<h3>StaticResourceExtension</h3>
<div>A <a href="http://msdn.microsoft.com/en-us/library/ms750950.aspx"><strong>StaticResourceExtension</strong></a> cannot be used in a setter value. For example, if you tried the following...</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">style.Setters.Add(<span class="js__operator">new</span>&nbsp;Setter(Button.FocusVisualStyleProperty,&nbsp;<span class="js__operator">new</span>&nbsp;StaticResourceExtension(<span class="js__string">&quot;ButtonFocusVisual&quot;</span>)));</pre>
</div>
</div>
</div>
<div class="endscriptcode">...you would get&nbsp;a top level exception:</div>
</div>
<div></div>
<div><span class="auto-style1" style="color:#ff0000"><strong>'The invocation of the constructor on type 'PEJL_WPF_Examples.MainWindow' that matches the specified binding constraints threw an exception.' Line number '4' and line position '55'.</strong></span></div>
<div></div>
<div>..with an inner exception of...</div>
<div></div>
<div><span class="auto-style1" style="color:#ff0000"><strong>'StaticResourceExtension' is no</strong></span><span class="auto-style1" style="color:#ff0000"><strong>t valid for Setter.Value. The only supported MarkupExtension types are DynamicResourceExtension
 and BindingBase or derived types.</strong></span></div>
<div>&nbsp;</div>
<h3>TemplateBindingExtension</h3>
<div>Another common object you will use to build and bind controls is the <strong>
TemplateBindingExtension</strong>, which creates the markup for binding to properties of the parent (templated) control, in this case a ButtonChrome.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">butt.SetValue(Control.BorderBrushProperty,&nbsp;<span class="js__operator">new</span>&nbsp;TemplateBindingExtension(Control.BorderBrushProperty));</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;This is the equivalant to this XAML:</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Microsoft_Windows_Themes:ButtonChrome&nbsp;...&nbsp;BorderBrush=<span class="js__string">&quot;{TemplateBinding&nbsp;BorderBrush}&quot;</span>&nbsp;...&nbsp;/&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;&nbsp;</div>
</div>
</div>
<h3>SetValue Mistakes &amp; Errors</h3>
<div>If StrokeProperty in the code above is a static resource, why can't we just change to this?</div>
<pre>rec.SetValue(Shape.StrokeProperty, SystemColors.ControlTextBrush);  //This is a static reference</pre>
<div>This is hard coding the colour, as it is on application start-up, instead of referring and monitoring it during runtime. If you were to change your Windows Theme, or the other system colours through Control Panel, then your application colour would not
 change. It is no longer a binding, and so it is not receiving PropertyChanged notifications from changes to Windows SystemColors.</div>
<div>SetValue is like very loose coupling, and a mistake will not show in the designer, or when you build. Only when the application actually creates the control will the error occur.</div>
<div>For example, if I were to change one line above to:</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">rec.SetValue(Shape.StrokeProperty,&nbsp;<span class="js__num">42</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">Then you get the following error:</div>
<div class="endscriptcode"></div>
</div>
<div class="auto-style1"><span style="color:#ff0000"><strong>'The invocation of the constructor on type 'PEJL_WPF_Examples.MainWindow' that matches the specified binding constraints threw an exception.' Line number '4' and line position '55'.</strong></span></div>
<div></div>
<div>A rather useless error, but one of the most common errors, when making control templates.</div>
<div>Whenever you get an error in WPF, if the exception message does not help, look for the
<a href="http://msdn.microsoft.com/en-us/library/system.exception.innerexception.aspx">
inner exception</a> by clicking &quot;<strong>View Detail...</strong>&quot;</div>
<div>&nbsp;<img id="62166" src="62166-xamlparseexception.png" alt="" width="599" height="583"></div>
<div class="auto-style1"><span style="color:#ff0000"><strong>'42' is not a valid value for property 'Stroke'.</strong></span></div>
<div><span style="font-size:medium"><strong><em>&nbsp;</em></strong></span>&nbsp;</div>
<div><span style="font-size:medium"><strong><em>&nbsp;</em></strong></span>&nbsp;</div>
<div><span style="font-size:medium"><strong><em>When dealing with WPF, especially XAML related problems, the inner exception is the most common place to find the actual error.</em></strong></span></div>
<div>&nbsp;</div>
<div>&nbsp;</div>
<h3><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Windows.Themes.aspx" target="_blank" title="Auto generated link to Microsoft.Windows.Themes">Microsoft.Windows.Themes</a></h3>
<div>Most WPF controls have a visual element. Themes are a set of styles that define the default appearance of a control. Themes only apply to the client area within a window. The window itself and many properties within your application are controlled by a
 different Win32 theme service.</div>
<div>For example, <strong><a href="http://msdn.microsoft.com/en-us/library/system.windows.systemcolors.windowtextbrushkey.aspx">SystemColors.WindowTextBrushKey</a></strong> is Win32 (changed through ControlPanel / Appearance and Personalisation / Change Window
 Colors &amp; Metrics (Titled: &quot;Window Colour &amp; Appearence&quot;).</div>
<div>However, <strong><a href="http://msdn.microsoft.com/en-us/library/system.windows.systemcolors.controltextbrushkey.aspx">SystemColors.ControlTextBrushKey</a></strong> is not listed there, it is part of the selected Theme (Aero, Luna, etc)</div>
<div><a href="http://msdn.microsoft.com/en-us/library/microsoft.windows.themes.aspx">Microsoft.Windows.Themes</a> are the base set of visuals that define the default look of your controls. You will notice from that link that there are not many. This is because
 they are not the control itself, just components used with the controls. So for example, a standard button uses a
<a href="http://msdn.microsoft.com/en-us/library/microsoft.windows.themes.buttonchrome.aspx">
ButtonChrome</a> as it's visual. From that link you will see that it does not inherit from Control or ButtonBase, but it does from FrameworkElement, like Control, so it has many similar properties, events and event handlers. The templated parent Button handles
 the actual Button events, and the ButtonChrome changes visually, in response to this. In other words, a button is the actual control, but how it looks and changes when interacted with is down to the ButtonChrome, or whatever button style you use.<br>
<br>
</div>
<h3>Event Handers</h3>
<div>Another useful method of the FrameworkElementFactory (and directly on UIElements) is the
<strong><a href="http://msdn.microsoft.com/en-us/library/ms522661">AddHandler</a></strong> method, for adding
<a href="http://msdn.microsoft.com/en-us/library/ms742806.aspx">RoutedEvent</a> handlers. This is one aspect of control coding that is more powerful than XAML. The XAML alternative would be to add and consume
<a href="http://msdn.microsoft.com/en-us/library/ms752308.aspx">Commands</a> instead. The example below shows how adding event handlers in code allows much more flexible authoring.</div>
<div>&nbsp;</div>
<h3>Tweak 1: DataGrid - DataGridColumnHeaderStyle</h3>
<div>Now that we have covered the basic features to control authoring, here are some examples of how control authoring in code can be more powerful than XAML markup.</div>
<div>In this example, we have taken the <a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.datagrid.columnheaderstyle(v=vs.95).aspx">
DataGridColumnHeaderStyle</a> and added an action on MouseEnter/Leave events.</div>
<div>If you wanted a control template to be usable throughout your application, you could place it in a shared resources file like App.xaml or Generic.xaml.</div>
<div>This works fine until you want to add a specific EventHandler. If the template is defined in Application.Resources, then it's THAT same application level where it expects to find the event handler, not on the page that uses the template. A common way around
 this is to use an <a href="http://adammills.wordpress.com/2011/02/14/eventtocommand-action-mvvm-glue/">
EventToCommand</a>, like used in the <a href="http://msdn.microsoft.com/en-us/library/system.windows.interactivity.eventtrigger(v=expression.40).aspx">
EventTrigger</a> in Expression Blend's <a href="http://msdn.microsoft.com/en-us/library/system.windows.interactivity(v=expression.40).aspx">
Interactivity library</a>. The problem with this is it does not easily pass the EventArgs. There are
<a href="http://weblogs.asp.net/alexeyzakharov/archive/2010/03/24/silverlight-commands-hacks-passing-eventargs-as-commandparameter-to-delegatecommand-triggered-by-eventtrigger.aspx">
hacks for it</a>, and <a href="http://mvvmlight.codeplex.com/">MVVMLite</a>'s implementation has an attribute for it (PassEventArgsToCommand=&quot;True&quot;).</div>
<div>However if you do not want to add Blend dlls or MVVMLite framework, then coding the template gives you all the flexibility you need.</div>
<div>In the demo project that accompanies this article, there is a <strong>DataGridFactory</strong> class, that has a
<strong>Make_ColumnHeaderAware_DataGrid</strong> method. In this example, I have passed in the IndicatorsViewModel, which the event handlers work on. You could of course pass in anything in, similar to
<a href="http://en.wikipedia.org/wiki/Dependency_injection">Dependency Injection</a>, to &quot;allow the players to use the stage&quot;, so to speak.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">class&nbsp;DataGridFactory&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IndicatorsViewModel&nbsp;indicatorsViewModel;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;DataGrid&nbsp;Make_ColumnHeaderAware_DataGrid(IndicatorsViewModel&nbsp;ivm)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;indicatorsViewModel&nbsp;=&nbsp;ivm;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;dg&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataGrid();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dg.ColumnHeaderStyle&nbsp;=&nbsp;MakeDataGridColumnHeaderStyle();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;dg;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...</pre>
</div>
</div>
</div>
<div class="endscriptcode">In this example, the IndicatorsViewModel is also shared with the page, where it displays which column header the mouse is over. So a MouseOver event in an obscure control template, deep within a DataGrid, has now updated a completely
 unrelated parent visual.</div>
</div>
<div>Below is a trimmed down version of the MakeDataGridColumnHeaderStyle method in the demo project, which creates a Style and ControlTemplate with custom event handlers.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">Style&nbsp;MakeDataGridColumnHeaderStyle()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ControlTemplate&nbsp;template&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ControlTemplate<span class="js__brace">{</span>TargetType&nbsp;=&nbsp;<span class="js__operator">typeof</span>(DataGridColumnHeader),<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;grid&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FrameworkElementFactory(<span class="js__operator">typeof</span>(Grid));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;border&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FrameworkElementFactory(<span class="js__operator">typeof</span>(DataGridHeaderBorder));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;border.SetValue(DataGridHeaderBorder.BorderBrushProperty,&nbsp;<span class="js__operator">new</span>&nbsp;TemplateBindingExtension(Control.BorderBrushProperty));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;...etc&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;contentPresenter&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FrameworkElementFactory(<span class="js__operator">typeof</span>(ContentPresenter));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;contentPresenter.SetValue(FrameworkElement.HorizontalAlignmentProperty,&nbsp;<span class="js__operator">new</span>&nbsp;TemplateBindingExtension(Control.HorizontalContentAlignmentProperty));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;...etc&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;contentPresenter.AddHandler(UIElement.MouseEnterEvent,&nbsp;<span class="js__operator">new</span>&nbsp;MouseEventHandler(ColumnHeader_MouseEnter));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;contentPresenter.AddHandler(UIElement.MouseLeaveEvent,&nbsp;<span class="js__operator">new</span>&nbsp;MouseEventHandler(ColumnHeader_MouseLeave));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;border.AppendChild(contentPresenter);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;thumb1&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FrameworkElementFactory(<span class="js__operator">typeof</span>(Thumb));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;...etc&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;thumb2&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FrameworkElementFactory(<span class="js__operator">typeof</span>(Thumb));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;...etc&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;grid.AppendChild(border);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;grid.AppendChild(thumb1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;grid.AppendChild(thumb2);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;template.VisualTree&nbsp;=&nbsp;grid;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;style&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Style()&nbsp;<span class="js__brace">{</span>&nbsp;TargetType&nbsp;=&nbsp;<span class="js__operator">typeof</span>(DataGridColumnHeader)&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;style.Setters.Add(<span class="js__operator">new</span>&nbsp;Setter(Control.TemplateProperty,&nbsp;template));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;...&nbsp;etc&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;style;&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div>
<ul>
<li>
<div class="endscriptcode">First we create the ControlTemplate with TargetType set to the Control type (in this case, it's DataGridColumnHeader).</div>
</li><li>
<div class="endscriptcode">Then we start building the visuals. In this case it is a Border that contains a ContentPresenter (added with border.AppendChild).</div>
</li><li>
<div class="endscriptcode">We also define a couple of EventTrigger handlers with contentPresenter.AddHandler.</div>
</li><li>
<div class="endscriptcode">Next we define a couple of Thumbs, and finally add all three to the grid with grid.AppendChild.</div>
</li><li>
<div class="endscriptcode">The Grid is the root control. This is added as the Template's VisualTree (template.VisualTree = grid).</div>
</li><li>
<div class="endscriptcode">The Template is then used by a new Style (also TargetType=DataGridColumnHeader).</div>
</li><li>
<div class="endscriptcode">The style sets the Template property of whatever control it is applied to.</div>
</li></ul>
</div>
<div>&nbsp;</div>
<div>&nbsp;</div>
<h3>Tweak 2: Buttons - DataTrigger, AttachedProperty &amp; Animation</h3>
<div>To include other aspects of control authoring, the attached project has a <strong>
ButtonFactory</strong> which creates a standard button. It also creates a &quot;flashy button&quot;, having an
<a href="http://msdn.microsoft.com/en-us/library/ms749011.aspx">AttachedProperty</a>, which is used by a Button's
<a href="http://msdn.microsoft.com/en-us/library/system.windows.datatrigger.aspx">
DataTrigger</a>, to run an <a href="http://msdn.microsoft.com/en-us/library/ms752312.aspx">
Animation</a>. If it is to be a FlashyButton, the attached property is wired in as follows:</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">butt.SetBinding(AttachedProperties.IsHighlightedProperty,&nbsp;<span class="js__operator">new</span>&nbsp;Binding&nbsp;<span class="js__brace">{</span>&nbsp;Source=ivm,&nbsp;Path=<span class="js__operator">new</span>&nbsp;PropertyPath(<span class="js__string">&quot;IsConfirmed&quot;</span>)&nbsp;<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">This in effect CREATES the attached property on the Button, and binds it to an &quot;IsConfirmed&quot; public property of the button's DataContext, which in this case is the Window itself.</div>
</div>
<div>The DataTrigger and it's <a href="http://msdn.microsoft.com/en-us/library/system.windows.data.binding.aspx">
Binding</a> are then added to the Button Style with this:</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;apBinding&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Binding(<span class="js__string">&quot;(local:AttachedProperties.IsHighlighted)&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;RelativeSource&nbsp;=&nbsp;RelativeSource.TemplatedParent&nbsp;<span class="js__brace">}</span>;&nbsp;
<span class="js__statement">var</span>&nbsp;apDataTrigger&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataTrigger&nbsp;<span class="js__brace">{</span>&nbsp;Binding&nbsp;=&nbsp;apBinding,&nbsp;Value&nbsp;=&nbsp;true&nbsp;<span class="js__brace">}</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">This is the listener for the AttachedProperty, and it is looking for it on the
<strong><a href="http://msdn.microsoft.com/en-us/library/system.windows.data.relativesource.templatedparent.aspx">RelativeSource.TemplatedParent</a></strong> (the actual Button Control where we put the AttachedProperty, not it's visual components). This DataTrigger
 will fire when the AttachedProperty changes to <strong>True</strong>.</div>
</div>
<div>We then create the animation. A simple <a href="http://msdn.microsoft.com/en-us/library/system.windows.media.animation.coloranimation.aspx">
ColorAnimation</a> on the new Border that we added to the ControlTemplate. This is added to a
<a>, which also defines which </a><a href="http://msdn.microsoft.com/en-us/library/system.windows.media.animation.storyboard.targetproperty.aspx">TargetProperty</a> to act on.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">var&nbsp;sb&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Storyboard();&nbsp;
var&nbsp;colAnim&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ColorAnimation(Colors.Transparent,&nbsp;Colors.Red,&nbsp;TimeSpan.FromMilliseconds(<span class="cs__number">250</span>));&nbsp;&nbsp;
colAnim.AutoReverse&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;&nbsp;
colAnim.RepeatBehavior&nbsp;=&nbsp;RepeatBehavior.Forever;&nbsp;&nbsp;
Storyboard.SetTargetProperty(colAnim,&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyPath(<span class="cs__string">&quot;(Background).(SolidColorBrush.Color)&quot;</span>));&nbsp;&nbsp;
colAnim.EasingFunction&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CubicEase&nbsp;{&nbsp;EasingMode&nbsp;=&nbsp;EasingMode.EaseOut&nbsp;};&nbsp;
sb.Children.Add(colAnim);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
We then create the <a href="http://msdn.microsoft.com/en-us/library/system.windows.triggerbase.enteractions.aspx">
EnterActions</a> and <a href="http://msdn.microsoft.com/en-us/library/system.windows.triggerbase.exitactions">
ExitActions</a> for the DataTrigger, which in this case are <a href="http://msdn.microsoft.com/en-us/library/system.windows.media.animation.beginstoryboard">
BeginStoryboard</a> and <a href="http://msdn.microsoft.com/en-us/library/system.windows.media.animation.stopstoryboard">
StopStoryboard</a></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">apDataTrigger.EnterActions.Add(<span class="js__operator">new</span>&nbsp;BeginStoryboard&nbsp;<span class="js__brace">{</span>&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;HighlightedAnimation&quot;</span>,&nbsp;Storyboard&nbsp;=&nbsp;sb&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;=&nbsp;sb&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;
apDataTrigger.ExitActions.Add(<span class="js__operator">new</span>&nbsp;StopStoryboard&nbsp;<span class="js__brace">{</span>&nbsp;BeginStoryboardName&nbsp;=&nbsp;<span class="js__string">&quot;HighlightedAnimation&quot;</span>&nbsp;<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">Then add the DataTrigger to the Style</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">style.Triggers.Add(apDataTrigger);&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;&nbsp;</div>
</div>
</div>
<div><strong>But there is one final gotcha!</strong></div>
<div>&nbsp;</div>
<div>Despite that all looking perfect, the Storyboard will not be found in your Style, causing the following error:</div>
<div>&nbsp;</div>
<div class="auto-style1"><span style="color:#ff0000"><strong>'HighlightedAnimation' name cannot be found in the name scope of '<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Style.aspx" target="_blank" title="Auto generated link to System.Windows.Style">System.Windows.Style</a>'.</strong></span></div>
<div>&nbsp;</div>
<div>The solution is to register it's name in the style itself with the <strong><a href="http://msdn.microsoft.com/en-us/library/system.windows.style.registername.aspx">RegisterName</a></strong> method:</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">style.RegisterName(<span class="js__string">&quot;HighlightedAnimation&quot;</span>,&nbsp;bsb);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div>&nbsp;</div>
<div>&nbsp;</div>
<h3>Tweak 3a: CheckBox &amp; RadioButton Bullet Problem</h3>
<div>If you spend much time trying to restyle your controls, you will inevitably come across a common issue with CheckBox and RadioButons..</div>
<div>&nbsp;</div>
<div>As you build up a Control Template, each visual is the child of another, added with AppendChild. The root element of the CheckBox VisualTree is a BulletDecorator. However, the&nbsp;actual Bullet itself is a property for the bullet visual, that shows as
 checked or unchecked. The Checkbox defers all responsibility for the visual representation of it's IsChecked state over to the Bullet. The Bullet property is therefore of type UIElement, as the Bullet is a fully fledged element that does stuff.</div>
<div>&nbsp;</div>
<div>Firstly, <strong>the Bullet property is a simple CLI object, not a DependancyProperty</strong>. So when you try to find it as below,<span style="color:#ff0000"> it isn't listed</span>:</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">bDecorator.SetValue(BulletDecorator.<span style="color:#ff0000">BulletProperty</span>,&nbsp;<span class="js__operator">new</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Windows.Themes.BulletChrome.aspx" target="_blank" title="Auto generated link to Microsoft.Windows.Themes.BulletChrome">Microsoft.Windows.Themes.BulletChrome</a>());&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">At this point, most people point to <a href="http://msdn.microsoft.com/en-us/library/system.windows.frameworkelementfactory.aspx">
Microsoft's own advice on the matter, regarding FrameworkElementFactory</a>:</div>
<div class="endscriptcode"><em>&nbsp;</em>&nbsp;</div>
<div class="endscriptcode"><strong><em>&quot;not all of the template functionality is available when you create a template using this class. The recommended way to programmatically create a template is to load XAML from a string or a memory stream using the
</em><a href="http://msdn.microsoft.com/en-us/library/system.windows.markup.xamlreader.load.aspx"><em>Load</em></a><em> method of the
</em><a href="http://msdn.microsoft.com/en-us/library/system.windows.markup.xamlreader.aspx"><em>XamlReader</em></a><em> class.&quot;</em></strong></div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div>&nbsp;</div>
<div>You can easily code up the BulletChrome FrameworkElementFactory as follows:</div>
<div>&nbsp;</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;bChrome&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FrameworkElementFactory(<span class="js__operator">typeof</span>(<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Windows.Themes.BulletChrome.aspx" target="_blank" title="Auto generated link to Microsoft.Windows.Themes.BulletChrome">Microsoft.Windows.Themes.BulletChrome</a>));&nbsp;
bChrome.SetValue(Control.BorderBrushProperty,&nbsp;<span class="js__operator">new</span>&nbsp;TemplateBindingExtension(Control.BorderBrushProperty));&nbsp;<span class="js__sl_comment">//&nbsp;Tested&nbsp;in&nbsp;MainWindow.xaml.cs</span>&nbsp;
bChrome.SetValue(Control.BackgroundProperty,&nbsp;<span class="js__operator">new</span>&nbsp;TemplateBindingExtension(Control.BackgroundProperty));&nbsp;
bChrome.SetValue(<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Windows.Themes.BulletChrome.RenderMouseOverProperty.aspx" target="_blank" title="Auto generated link to Microsoft.Windows.Themes.BulletChrome.RenderMouseOverProperty">Microsoft.Windows.Themes.BulletChrome.RenderMouseOverProperty</a>,&nbsp;<span class="js__operator">new</span>&nbsp;TemplateBindingExtension(UIElement.IsMouseOverProperty));&nbsp;
bChrome.SetValue(<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Windows.Themes.BulletChrome.RenderPressedProperty.aspx" target="_blank" title="Auto generated link to Microsoft.Windows.Themes.BulletChrome.RenderPressedProperty">Microsoft.Windows.Themes.BulletChrome.RenderPressedProperty</a>,&nbsp;<span class="js__operator">new</span>&nbsp;TemplateBindingExtension(ButtonBase.IsPressedProperty));&nbsp;
bChrome.SetValue(ToggleButton.IsCheckedProperty,&nbsp;<span class="js__operator">new</span>&nbsp;TemplateBindingExtension(ToggleButton.IsCheckedProperty));</pre>
</div>
</div>
</div>
<div class="endscriptcode">But we can't simply attach with AppendChild, as it is not a child, but a property.</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div>&nbsp;</div>
<div>So we can't use the standard BulletDecorator. We will need to make a new control that inherits from it, but adds a new DependancyProperty.</div>
<div>&nbsp;</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;object&nbsp;ActualBullet&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;(object)GetValue(ActualBulletProperty);&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;set&nbsp;<span class="js__brace">{</span>&nbsp;SetValue(ActualBulletProperty,&nbsp;value);&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
public&nbsp;static&nbsp;readonly&nbsp;DependencyProperty&nbsp;ActualBulletProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.Register(<span class="js__string">&quot;ActualBullet&quot;</span>,&nbsp;<span class="js__operator">typeof</span>(object),&nbsp;<span class="js__operator">typeof</span>(BulletDecoratorByCode),&nbsp;<span class="js__operator">new</span>&nbsp;UIPropertyMetadata(null,&nbsp;ActualBulletChanged));</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div>Now we can pass stuff in and set the Bullet property directly.</div>
<div></div>
<div>However, when we try to pass the Bullet control in with SetValue, we find a fundamental limitation of FrameWorkElementFactory:</div>
<div></div>
<div class="auto-style1"><span style="color:#ff0000"><strong>'<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Windows.Themes.BulletChrome.aspx" target="_blank" title="Auto generated link to Microsoft.Windows.Themes.BulletChrome">Microsoft.Windows.Themes.BulletChrome</a>' is not a valid value for 'FrameworkElementFactory.SetValue'; values derived from Visual or ContentElement are not supported.</strong></span></div>
<div></div>
<div>As this is all code,<strong> the solution is to defer the bullet creation to our new &quot;BulletDecoratorByCode&quot; class</strong>.</div>
<div></div>
<div>You can just pass a dummy value if you only need one BulletDecorator, then code the Bullet within.</div>
<div>&nbsp;</div>
<div>In this demo, I show several Bullet examples, so I use the ActualBullet DependancyProperty to pass in a simple string value of which Bullet type I want to use.</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">static&nbsp;<span class="js__operator">void</span>&nbsp;ActualBulletChanged(object&nbsp;obj,&nbsp;DependencyPropertyChangedEventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;bdec&nbsp;=&nbsp;obj&nbsp;as&nbsp;BulletDecoratorByCode;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;((string)e.NewValue&nbsp;==&nbsp;<span class="js__string">&quot;Microsoft.Windows.Themes.BulletChrome&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bdec.Bullet&nbsp;=&nbsp;BulletFactory.MakeBulletChrome(obj);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bdec.Bullet&nbsp;=&nbsp;BulletFactory.MakeBulletImage(obj,&nbsp;(string)e.NewValue);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img src="-anithanks1.gif" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
