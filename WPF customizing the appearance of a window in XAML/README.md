# WPF customizing the appearance of a window in XAML
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- WPF
- XAML
## Topics
- WPF
- XAML
- WPF Commanding
- XAML Control Templates
- Window
- XAML Styles
- WPF Styling
- Attached Behavior
- custom window
- window template
## Updated
- 09/18/2015
## Description

<h1>Introduction</h1>
<p>This sample shows how to fully style a window in WPF in XAML alone whilst still providing all the default window functionality. It does so without having to resort to code behind or creating a custom window class derived from the Window class.</p>
<h1>Description</h1>
<p><img id="138896" src="138896-standardwindow.png" alt="" width="350" height="250"></p>
<p>In a WPF application the window itself outside the client area cannot be styled. The only option is to remove the default window completely by setting the Window properties&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.windows.window.windowstyle(v=vs.110).aspx" target="_blank">WindowStyle</a>
 and <a href="https://msdn.microsoft.com/en-us/library/system.windows.window.allowstransparency%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396" target="_blank">
AllowsTransparency</a>&nbsp;to <strong>None</strong> and <strong>True</strong> respectively.</p>
<p><img id="138897" src="138897-emptywindow.png" alt="" width="350" height="250"></p>
<p>This will result in a fully styleable client are but there will be a lot of work to get back to working window as all the standard elements have being removed:</p>
<ul>
<li>application icon </li><li>minimize button </li><li>maximize button </li><li>close button </li><li>title bar </li><li>window border </li></ul>
<p>Also the following functionality will no longer be available</p>
<ul>
<li>resizing on window edges </li><li>resizing on window corners </li><li>double click title bar window maximize </li><li>double click title bar on maximized window return to normal size </li><li>left click window icon shows system menu </li><li>double click window icon closes window </li><li>right click title bar shows system menu </li><li>left click held on title bar allows the window to be dragged </li><li>left click held on window borders allows horizontal or vertical resizing </li><li>left click held on window corners allows&nbsp;horizontal and vertical resizing
</li></ul>
<p>To make this achievable in XAML 7 custom behaviors and commands are provided in the sample under
<strong>./StyleableWindow</strong>.&nbsp;</p>
<ol>
<li>ControlDoubleClickBehavior </li><li>ShowSystemMenuBehavior </li><li>WindowCloseCommand </li><li>WindowDragBehavior </li><li>WindowMaximizeCommand </li><li>WindowMinimizeCommand </li><li>WindowResizeBehavior </li></ol>
<p>These are then used to help create a control template <strong>WindowTemplate</strong>&nbsp;(in
<strong>App.xaml</strong>) that can be used to style be window. As an example the style below (also in
<strong>App.xaml</strong>)&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Style</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;CustomWindow&quot;</span>&nbsp;<span class="xaml__attr_name">TargetType</span>=<span class="xaml__attr_value">&quot;{x:Type&nbsp;Window}&quot;</span><span class="xaml__tag_start">&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Setter</span>&nbsp;<span class="css__element">Property</span>=&quot;<span class="css__element">WindowStyle</span>&quot;&nbsp;<span class="css__element">Value</span>=&quot;<span class="css__element">None</span>&quot;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Setter</span>&nbsp;<span class="css__element">Property</span>=&quot;<span class="css__element">AllowsTransparency</span>&quot;&nbsp;<span class="css__element">Value</span>=&quot;<span class="css__element">True</span>&quot;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Setter</span>&nbsp;<span class="css__element">Property</span>=&quot;<span class="css__element">MinWidth</span>&quot;&nbsp;<span class="css__element">Value</span>=&quot;<span class="css__element">100</span>&quot;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Setter</span>&nbsp;<span class="css__element">Property</span>=&quot;<span class="css__element">MinHeight</span>&quot;&nbsp;<span class="css__element">Value</span>=&quot;<span class="css__element">46</span>&quot;/&gt;&nbsp;&lt;!--<span class="css__element">CaptionHeight</span>&nbsp;&#43;&nbsp;<span class="css__element">ResizeBorderThickness</span>&nbsp;*&nbsp;<span class="css__element">2</span>--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Setter</span>&nbsp;<span class="css__element">Property</span>=&quot;<span class="css__element">Background</span>&quot;&nbsp;<span class="css__element">Value</span>=&quot;<span class="css__element">Yellow</span>&quot;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Setter</span>&nbsp;<span class="css__element">Property</span>=&quot;<span class="css__element">BorderBrush</span>&quot;&nbsp;<span class="css__element">Value</span>=&quot;<span class="css__element">Green</span>&quot;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Setter</span>&nbsp;<span class="css__element">Property</span>=&quot;<span class="css__element">BorderThickness</span>&quot;&nbsp;<span class="css__element">Value</span>=&quot;<span class="css__element">5</span>&quot;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Setter</span>&nbsp;<span class="css__element">Property</span>=&quot;<span class="css__element">Foreground</span>&quot;&nbsp;<span class="css__element">Value</span>=&quot;<span class="css__element">DarkRed</span>&quot;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Setter</span>&nbsp;<span class="css__element">Property</span>=&quot;<span class="css__element">Template</span>&quot;&nbsp;<span class="css__element">Value</span>=&quot;{StaticResource&nbsp;WindowTemplate}&quot;/&gt;&nbsp;
<span class="xaml__tag_end">&lt;/Style&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<p>when applied to the window..</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Window</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;WpfStylableWindow.MainWindow&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;MainWindow&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;350&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;525&quot;</span>&nbsp;<span class="xaml__attr_name">Style</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;RedWindow}&quot;</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;testw&quot;</span>&nbsp;<span class="xaml__attr_name">Icon</span>=<span class="xaml__attr_value">&quot;App.ico&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Center&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Center&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;32&quot;</span><span class="xaml__tag_start">&gt;</span>client&nbsp;area<span class="xaml__tag_end">&lt;/TextBlock&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Window&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<p>will produce the following window.</p>
<p><img id="138898" src="https://i1.code.msdn.s-msft.com/wpf-styling-a-window-in-fcf4e4ce/image/file/138898/1/customwindow.png" alt="" width="392" height="284"></p>
<p>Please note this is deliberately horribly styled with the corner thumbs left visible, to show the different elements of the template.</p>
<p>Also note that where possible the template respects the Window properties (Background, BorderThickness, Foreground etc.), and will apply these if they are set explicitly on the Window.</p>
<p>For a slightly more realistic style try applying the RedWindow style to the MainWindow in the sample project and swapping out the existing brushes for the red window brushes in
<strong>App.xaml</strong>.</p>
<p><img id="138899" src="https://i1.code.msdn.s-msft.com/wpf-styling-a-window-in-fcf4e4ce/image/file/138899/1/redwindow.png" alt="" width="284" height="243"></p>
<h2>Summary</h2>
<p>The easiest way to understand the code is to step through it. There isn't really enough room here to go over&nbsp;the&nbsp;code behind the behaviors and commands in detail but if you have any questions or suggestions please feel free to leave them in the
 Q and A section.</p>
