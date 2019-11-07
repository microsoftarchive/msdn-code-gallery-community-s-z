# WPF Messagebox
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- XAML
- .NET Framework
## Topics
- Animation
- C#
- User Interface
- WPF
- XAML
- Language Samples
## Updated
- 02/05/2013
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">If you ever used the standard .NET messagebox I'm sure, like me, you found it to be a lacking and cumbersome. My main goal in writing this was simplifying&nbsp;the messagebox'es use, and adding some needed functionality (in
 my opinion) while keeping it's original API to allow smooth transition from the standard messagebox.</span></p>
<p style="text-align:justify"><span style="font-size:small">I came about to write this messagebox after twice having to write it in two seperate projects I was a part of. After having to write the same code for the second time, I thought I would upload it so
 developers (including myself) won't have to fuss with the WPF messagebox again.</span></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small">This sample is written in .Net 4.0, just build and run it.</span></p>
<p style="text-align:justify"><span style="font-size:small">I wrote it in .Net 4 so I would be able to use default parameter values, to save me writing all the different overloads I needed. It could work with .Net 3.5 if all of these were converted to normal
 overloads.</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p style="text-align:justify"><span style="font-size:small">As I stated in the introduction, in this project, I wanted to both simplify the use of the messagebox and add functionality. To simplify the use of the messagebox, I added multiple Show methods, There
 are different Show methods for each type of common use.&nbsp;These new Show methods do not allow to customize the messagebox like the old show methods, but are intended to be used as presets. The different methods are:</span></p>
<ul>
<li><span style="font-size:small">ShowInformation</span> </li></ul>
<p><span style="font-size:small"><img id="67857" src="67857-info.png" alt="" width="147" height="85"></span></p>
<ul>
<li><span style="font-size:small">ShowQuestion</span> </li></ul>
<p><span style="font-size:small"><img id="67860" src="67860-question.png" alt="" width="180" height="115"></span></p>
<ul>
<li><span style="font-size:small">ShowWarning</span> </li></ul>
<p><span style="font-size:small"><img id="67859" src="67859-warning.png" alt="" width="400" height="131"></span></p>
<ul>
<li><span style="font-size:small">ShowError</span> </li></ul>
<p><span style="font-size:small"><img id="67861" src="67861-error.png" alt="" width="147" height="85"></span></p>
<p><span style="font-size:small">And of course the old Show method.</span></p>
<p style="text-align:justify"><span style="font-size:small">While the new Show methods can't be customized like the old show methods, they do have some options other than the message. They allow the addition of a cancel button, and a details section, which
 takes me to my next point.</span></p>
<p style="text-align:justify"><span style="font-size:small">My other goal in writing this was to add some functionality I thought is missing. The first and most obvious change is that i deleted the title. My experience taught&nbsp;me that a messagebox title
 is redundant, so I decided to just drop it.</span></p>
<p style="text-align:justify"><span style="font-size:small">Another significant change is the addition of a details section. This is a section that's added when the details parameter recieves a value. It's main purpose is to allow copying information from the
 message, which leads me to my last point.</span></p>
<p style="text-align:justify"><span style="font-size:small">The ShowError message is unique among the others in that it can recieve an exception, and parse it to the messagebox. when an exception is passed to the messagebox, the exception's message would be
 placed in the message text, while the entire exception's ToString would pass to the details section (only if the project was build in debug). so all you need to do is this:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">try
{
  throw new Exception(&quot;FUUUUUUUUUUUU!!!!!!!&quot;);
}
catch (Exception ex)
{
  MessageBox.ShowError(ex);
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">try</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Exception(<span class="cs__string">&quot;FUUUUUUUUUUUU!!!!!!!&quot;</span>);&nbsp;
}&nbsp;
<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
{&nbsp;
&nbsp;&nbsp;MessageBox.ShowError(ex);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small; text-align:justify">I found this to be very useful when trying to interpret&nbsp;and debug exception at the client.</span></div>
<h1>Credits</h1>
<p><span style="font-size:small">I can't take all the credits for this project, first of all, the different Show methods were the idea of my team leader, so I'd like to thank him.</span></p>
<p><span style="font-size:small">Second, I borrowed an idea from this StackOverflow thread:&nbsp;<a href="http://stackoverflow.com/questions/1127647/convert-system-drawing-icon-to-system-media-imagesource">http://stackoverflow.com/questions/1127647/convert-system-drawing-icon-to-system-media-imagesource</a></span></p>
