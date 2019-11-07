# UWP Custom On Screen Keyboard for IoT
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Windows Univeral App
- UWP
- Windows IoT
## Topics
- On-screen keyboard
## Updated
- 04/18/2016
## Description

<h1>Introduction</h1>
<p><em>As of April 2016, Windows 10 IoT does not include an on screen keyboard.<br>
The <a href="https://ms-iot.github.io/content/en-US/win10/samples/DigitalSignage.htm" target="_blank">
DigitalSignage UWP sample</a> app contains a custom on screen keyboard, but I found that is has multiple bugs and is inconvenient to use in code.<br>
In this sample, you can find an improved version of the on screen keyboard.</em></p>
<p><span style="background-color:#ffff00"><em><strong>UPDATE:</strong> <span style="background-color:#ffffff">
More information <a href="https://github.com/michaelosthege/TCD.Controls.Keyboard">
now also on GitHub</a></span></em></span></p>
<h1><span>Building the Sample</span></h1>
<p><em>You need Visual Studio 2015 with UWP support.</em></p>
<p><em>If you want to modify the keyboard, be warned: It has a really nice look and behaviour, but the MVVM that powers it is a bit wtf.. Changing colors &amp; keyboard layout should be no problem though.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The OnScreenKeyboard control from the DigitalSignage sample was taken and improved.<br>
<br>
<br>
<strong>Bugs that were adressed:</strong><br>
</em></p>
<ul>
<li><em>injects input directly into target TextBox/PasswordBox instead of OutputString property</em>
</li><li><em>the Content property of the [ key was fixed</em> </li><li><em>symbols for Tab, Capslock, Shift, Backspace, Return</em> </li><li><em>spacing between keys subtituted with black margin to prevent unwanted unfocusing</em>
</li><li><em>IsTabStop=&quot;False&quot; on all keys causes focus to remain at the TextBox</em> </li></ul>
<p><em>&nbsp;<br>
<strong>Shortcomings / known bugs:</strong><br>
</em></p>
<ul>
<li><em>caret positioning &amp; selection does not work on PasswordBoxes (because the PasswordBox does not expose this property)</em>
</li><li><em>the space between the keys is not transparent (adjust border color accordingly)</em>
</li></ul>
<p>&nbsp;</p>
<p>This is what is looks like:</p>
<p><img id="151009" src="151009-ss1.png" alt="" width="494" height="309"></p>
<p><em><br>
</em></p>
<p>For all TextBox and PasswordBox controls, you have to subscribe the keyboard:</p>
<p><em>&nbsp; <br>
</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// in your MainPage constructor
keyboard.RegisterTarget(textBox1);
keyboard.RegisterTarget(textBox2);
keyboard.RegisterTarget(passwordBox1);
// keyboard being the instance of the OnScreenKeyboard</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;in&nbsp;your&nbsp;MainPage&nbsp;constructor</span>&nbsp;
keyboard.RegisterTarget(textBox1);&nbsp;
keyboard.RegisterTarget(textBox2);&nbsp;
keyboard.RegisterTarget(passwordBox1);&nbsp;
<span class="cs__com">//&nbsp;keyboard&nbsp;being&nbsp;the&nbsp;instance&nbsp;of&nbsp;the&nbsp;OnScreenKeyboard</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>OSKSample.zip - source code of the sample application</em> </li></ul>
<h1>More Information</h1>
<p><em>https://github.com/michaelosthege/TCD.Controls.Keyboard</em></p>
