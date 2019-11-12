# WPF Rating User Control
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- WPF
- XAML
- .NET Framework
## Topics
- Controls
- WPF
- UserControls
## Updated
- 10/28/2012
## Description

<h1>Introduction</h1>
<p><em>This sample shows how you can build WPF User controls. This sample show how to build lightweight and simple rating control with another user control.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>There is no additional requirements other than that sample is created with Visual Studio 2012 and uses .NET Framework 4.5. To use control in your own project, just build the sample and reference MasaSam.Controls library or copy code to your own project.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample contains two user controls a Star and Rating. </em></p>
<p><em>Star is just an simple UI control that draws star with two states: On or Off. It also has two color properties OfColor and OnColor that match the state of the star and are used to fill star depending on its state. It also has one additional event beside
 UserControl events and that is StateChanged event that notifies when state of the star is changed. State change occurs whenever left mouse button is release over the star. What's implemented in Star is the state change and setting appropriate color and mouse
 hover by changing the color.<br>
</em></p>
<p><em>Rating is the main user control of this sample and it uses the Star control to create the rating stars so familiar from several applications or web sites. Rating has few properties like Minimum, the non-rated value, Maximum, how many stars there is,
 Value, the current rating and On and Off colors of the stars. What's implemented in Rating is the indication of how many stars is currently selected, the drawing the required amount of stars, changing the star states if rating already set changes, and one
 additional event RatingChanged that notifies when the value of the Value property has changed.<br>
</em></p>
<p>&nbsp;</p>
<p><em>Sample application Windows is in following screenshot.</em></p>
<p><em><img id="69910" src="69910-rating_screenshot.jpg" alt="" width="400" height="200"><br>
</em></p>
<p>Using the control is simple as following snippet from MainWindow XAML shows.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:Rating&nbsp;<span class="xaml__attr_name">Maximum</span>=<span class="xaml__attr_value">&quot;15&quot;</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;rtFifteen&quot;</span>&nbsp;<span class="xaml__attr_name">StarOffColor</span>=<span class="xaml__attr_value">&quot;Pink&quot;</span>&nbsp;<span class="xaml__attr_name">StarOnColor</span>=<span class="xaml__attr_value">&quot;Red&quot;</span>&nbsp;<span class="xaml__attr_name">RatingChanged</span>=<span class="xaml__attr_value">&quot;rtFifteen_RatingChanged&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ElementName=rtFifteen,&nbsp;Path=Value}&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;18,0,0,0&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/StackPanel&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Star.xaml and Star.xaml.cs contains the classes and enumeration used by Star user control.<br>
</em></li><li><em><em>Rating.xaml and Rating.xaml.cs contains the classes used by Rating user control.</em></em>
</li><li><em>MainWindow.xaml and MainWindow.xaml.cs contains small windows demonstrating the usage.</em>
</li></ul>
<p>&nbsp;</p>
