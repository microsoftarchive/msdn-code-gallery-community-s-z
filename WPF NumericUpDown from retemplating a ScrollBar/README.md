# WPF NumericUpDown from retemplating a ScrollBar
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- XAML Control Templates
- WPF Control Templating
- NumericUpDown
- ScrollBar
- TemplateBinding
- RangeBase
## Updated
- 09/19/2012
## Description

<h1>Introduction</h1>
<p>This project shows how to easily make a NumericUpDown control out of a ScrollBar control.</p>
<p><img id="65288" src="http://i1.code.msdn.s-msft.com/wpf-numericupdown-from-15a7f578/image/file/65288/1/numericupdown.png" alt="" width="256" height="198" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1><span>Building the Sample</span></h1>
<p>Just download, unzip, open and run!</p>
<p>&nbsp;</p>
<h2><span style="font-size:20px">Description</span></h2>
<p>A control that is missing from the original set of WPF controls, but much used, is the&nbsp;NumericUpDown control. It is a&nbsp;neat way to get users to select a number from a fixed&nbsp;range, in a small area. A slider could be used, but for compact forms
 with little horizontal real-estate, the NumericUpDown is essential.</p>
<p>There are several commercial and codeplex versions around, but both involve installing 3rd party dlls and overheads to your project. Far simpler to build your own, and a aimple way to do that is with the ScrollBar.</p>
<p>A vertical ScrollBar with no Thumb (just the repeater buttons) is in fact just what we want. It inherits rom
<a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.primitives.rangebase.aspx">
RangeBase</a>, so it has all the properties we need, like Min, Max, and SmallChange (set to 1, to restrict it to Integer values)</p>
<p>So we change the ScrollBar <strong>ControlTemplate</strong>. First we remove the Thumb and Horizontal trigger actions. Then we&nbsp;group the remains into a grid and add a TextBlock for the number:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Grid&nbsp;Margin=<span class="js__string">&quot;2&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid.ColumnDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ColumnDefinition/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ColumnDefinition&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.ColumnDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock&nbsp;VerticalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;FontSize=<span class="js__string">&quot;20&quot;</span>&nbsp;MinWidth=<span class="js__string">&quot;25&quot;</span>&nbsp;Text=<span class="js__string">&quot;{Binding&nbsp;Value,&nbsp;RelativeSource={RelativeSource&nbsp;TemplatedParent}}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&nbsp;Grid.Column=<span class="js__string">&quot;1&quot;</span>&nbsp;x:Name=<span class="js__string">&quot;GridRoot&quot;</span>&nbsp;Width=<span class="js__string">&quot;{DynamicResource&nbsp;{x:Static&nbsp;SystemParameters.VerticalScrollBarWidthKey}}&quot;</span>&nbsp;Background=<span class="js__string">&quot;{TemplateBinding&nbsp;Background}&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;MaxHeight=<span class="js__string">&quot;18&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;Height=<span class="js__string">&quot;0.00001*&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;MaxHeight=<span class="js__string">&quot;18&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RepeatButton&nbsp;x:Name=<span class="js__string">&quot;DecreaseRepeat&quot;</span>&nbsp;Command=<span class="js__string">&quot;ScrollBar.LineDownCommand&quot;</span>&nbsp;Focusable=<span class="js__string">&quot;False&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Path&nbsp;x:Name=<span class="js__string">&quot;DecreaseArrow&quot;</span>&nbsp;Stroke=<span class="js__string">&quot;{TemplateBinding&nbsp;Foreground}&quot;</span>&nbsp;StrokeThickness=<span class="js__string">&quot;1&quot;</span>&nbsp;Data=<span class="js__string">&quot;M&nbsp;0&nbsp;4&nbsp;L&nbsp;8&nbsp;4&nbsp;L&nbsp;4&nbsp;0&nbsp;Z&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/RepeatButton&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RepeatButton&nbsp;Grid.Row=<span class="js__string">&quot;2&quot;</span>&nbsp;x:Name=<span class="js__string">&quot;IncreaseRepeat&quot;</span>&nbsp;Command=<span class="js__string">&quot;ScrollBar.LineUpCommand&quot;</span>&nbsp;Focusable=<span class="js__string">&quot;False&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Path&nbsp;x:Name=<span class="js__string">&quot;IncreaseArrow&quot;</span>&nbsp;Stroke=<span class="js__string">&quot;{TemplateBinding&nbsp;Foreground}&quot;</span>&nbsp;StrokeThickness=<span class="js__string">&quot;1&quot;</span>&nbsp;Data=<span class="js__string">&quot;M&nbsp;0&nbsp;0&nbsp;L&nbsp;4&nbsp;4&nbsp;L&nbsp;8&nbsp;0&nbsp;Z&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/RepeatButton&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;If you wanted to be able to type numbers in, the TextBlock could be a TextBox.</div>
&nbsp;
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainWindow.xaml - Startup window, including the Scrollbar style</em> </li></ul>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img src="http://213.163.64.28/aniThanks1.gif" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
