# Watermarked TextBox and PasswordBox
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- TextBox
- AttachedProperties
- AttachedBehaviours
- PasswordBox
- Watermarking
## Updated
- 09/19/2012
## Description

<h1>Introduction</h1>
<p>This project contains watermark solutions for the TextBox and the PasswordBox. There is a WatermarkTextBox in the Extended WPF Toolkit, there&nbsp;is (to date)&nbsp;no solution for the PasswordBox.&nbsp;Also, I prefer to keep my projects as light as possible,
 so here is a very simple solution to a commonly requested pair of controls.</p>
<p>&nbsp;</p>
<p><img id="62170" src="62170-watermarked.png" alt="" width="271" height="197" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1><span>&nbsp;</span></h1>
<h1><span>Building the Sample</span></h1>
<p>Just download, unblock, unzip, load &amp; run!</p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The purpose of a watermark is to convey a message behind the control. In the case of this demonstration, the watermark also dissappear after you start typing text, so they are more like a field &quot;hint&quot; telling you what is expected.</p>
<p>&nbsp;</p>
<p>To achieve this, we turn to a regular WPF solution provider, the AttachedProperty. AttachedProperties allow you to add extra properties to any control. You can also extend it into an Attachedbehaviour, where you are making the control react to changes to
 the property.</p>
<p>&nbsp;</p>
<p>In this example, we use two attached properties. The first &quot;WaterrmarkProperty&quot;&nbsp;to take the watermark value and initialise the control:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GetWatermark(DependencyObject&nbsp;obj)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;(<span class="cs__keyword">string</span>)obj.GetValue(WatermarkProperty);&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SetWatermark(DependencyObject&nbsp;obj,&nbsp;<span class="cs__keyword">string</span>&nbsp;<span class="cs__keyword">value</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;obj.SetValue(WatermarkProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;DependencyProperty&nbsp;WatermarkProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.RegisterAttached(<span class="cs__string">&quot;Watermark&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">string</span>),&nbsp;<span class="cs__keyword">typeof</span>(TextBoxHelper),&nbsp;<span class="cs__keyword">new</span>&nbsp;UIPropertyMetadata(<span class="cs__keyword">null</span>,&nbsp;WatermarkChanged));</pre>
</div>
</div>
</div>
<p>The second attached property is to notify whether there is a value in the box, which the template binds to and hides or shows the watermark.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;static&nbsp;bool&nbsp;GetShowWatermark(DependencyObject&nbsp;obj)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;(bool)obj.GetValue(ShowWatermarkProperty);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
public&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;SetShowWatermark(DependencyObject&nbsp;obj,&nbsp;bool&nbsp;value)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;obj.SetValue(ShowWatermarkProperty,&nbsp;value);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
public&nbsp;static&nbsp;readonly&nbsp;DependencyProperty&nbsp;ShowWatermarkProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.RegisterAttached(<span class="js__string">&quot;ShowWatermark&quot;</span>,&nbsp;<span class="js__operator">typeof</span>(bool),&nbsp;<span class="js__operator">typeof</span>(TextBoxHelper),&nbsp;<span class="js__operator">new</span>&nbsp;UIPropertyMetadata(false));</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>For the TextBoxHelper, whenever the text is changed,&nbsp;the watermark is shown or hidden as follows:</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;CheckShowWatermark(TextBox&nbsp;box)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;box.SetValue(TextBoxHelper.ShowWatermarkProperty,&nbsp;box.Text&nbsp;==&nbsp;string.Empty);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">This is controlled by the ControlTemplate:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;ControlTemplate&nbsp;x:Key=<span class="js__string">&quot;WatermarkedTextBoxTemplate&quot;</span>&nbsp;TargetType=<span class="js__string">&quot;{x:Type&nbsp;TextBox}&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Microsoft_Windows_Themes:ListBoxChrome&nbsp;x:Name=<span class="js__string">&quot;Bd&quot;</span>&nbsp;BorderBrush=<span class="js__string">&quot;{TemplateBinding&nbsp;BorderBrush}&quot;</span>&nbsp;BorderThickness=<span class="js__string">&quot;{TemplateBinding&nbsp;BorderThickness}&quot;</span>&nbsp;Background=<span class="js__string">&quot;{TemplateBinding&nbsp;Background}&quot;</span>&nbsp;RenderMouseOver=<span class="js__string">&quot;{TemplateBinding&nbsp;IsMouseOver}&quot;</span>&nbsp;RenderFocused=<span class="js__string">&quot;{TemplateBinding&nbsp;IsKeyboardFocusWithin}&quot;</span>&nbsp;SnapsToDevicePixels=<span class="js__string">&quot;true&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock&nbsp;Text=<span class="js__string">&quot;{Binding&nbsp;Path=(local:TextBoxHelper.Watermark),&nbsp;RelativeSource={RelativeSource&nbsp;TemplatedParent}}&quot;</span>&nbsp;Opacity=<span class="js__string">&quot;.5&quot;</span>&nbsp;FontWeight=<span class="js__string">&quot;Bold&quot;</span>&nbsp;Visibility=<span class="js__string">&quot;{Binding&nbsp;(local:TextBoxHelper.ShowWatermark),&nbsp;Converter={StaticResource&nbsp;BooleanToVisibilityConverter},&nbsp;RelativeSource={RelativeSource&nbsp;TemplatedParent}}&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ScrollViewer&nbsp;x:Name=<span class="js__string">&quot;PART_ContentHost&quot;</span>&nbsp;SnapsToDevicePixels=<span class="js__string">&quot;{TemplateBinding&nbsp;SnapsToDevicePixels}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Microsoft_Windows_Themes:ListBoxChrome&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;ControlTemplate.Triggers&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Trigger&nbsp;Property=<span class="js__string">&quot;IsEnabled&quot;</span>&nbsp;Value=<span class="js__string">&quot;false&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;Background&quot;</span>&nbsp;TargetName=<span class="js__string">&quot;Bd&quot;</span>&nbsp;Value=<span class="js__string">&quot;{DynamicResource&nbsp;{x:Static&nbsp;SystemColors.ControlBrushKey}}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="js__string">&quot;Foreground&quot;</span>&nbsp;Value=<span class="js__string">&quot;{DynamicResource&nbsp;{x:Static&nbsp;SystemColors.GrayTextBrushKey}}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Trigger&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ControlTemplate.Triggers&gt;&nbsp;
&lt;/ControlTemplate&gt;</pre>
</div>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainWindow.xaml - Startup window &amp; example controls</em> </li><li><em>App.xaml - Control templates for both control types</em> </li></ul>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img src="-anithanks1.gif" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
