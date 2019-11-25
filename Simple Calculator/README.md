# Simple Calculator
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- XAML
- Visual Studio 2012
- .NET 4.5
## Topics
- Calculator
## Updated
- 08/15/2012
## Description

<h1>Introduction</h1>
<p><em>What I build is just a simple calculator that will show beginners how much easy it is to develop applications using the .NET Framework. Through this sample, they will see some most useful algorithmic operations. In addition they will understand how to
 program buttons and use its properties, specially the&nbsp;object sender which is the first parameter of any click event. In fact, the sender object encapsulate all the control's button properties. Just a casting operation to a Button control will give you
 access to these properties.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Are there special requirements or instructions for building the sample?</em></p>
<p><em>You will need to have Visual Studio 2012 Express installed or Visual Studio 2012, which you can download them from</em></p>
<p><em><a href="http://www.microsoft.com/visualstudio/en-us/try"></a><a href="http://www.microsoft.com/visualstudio/11/en-us/downloads#vs">http://www.microsoft.com/visualstudio/11/en-us/downloads#vs</a>.</em></p>
<p><em>When installed, all you need is to open the .sln file with visual studio and press F5 to run.</em></p>
<p><em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p style="text-align:center"><em><img id="63486" src="63486-houssem%20dellai%20calculator.jpg" alt="" width="237" height="311">&nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Button_Click_1(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Button&nbsp;b&nbsp;=&nbsp;(Button)&nbsp;sender;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tb.Text&nbsp;&#43;=&nbsp;b.Content.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Off_Click_1(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//to&nbsp;close&nbsp;the&nbsp;app</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.Current.Shutdown();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainWindow.xaml - contains the graphic properties of the user interface.</em>
</li><li><em><em><em>MainWindow.cs - contains busines logic of the application.</em></em></em>
</li></ul>
<h1>More Information</h1>
<p><em><em>For more information on this application, please feeel free to write in Q&amp;A or to email me via houssem.dellai@ieee.org.</em></em></p>
<h1>More Code</h1>
<p>You can see this same application running on Windows Phone in&nbsp;<a href="http://code.msdn.microsoft.com/Windows-Phone-Calculator-6f44a9f2">http://code.msdn.microsoft.com/Windows-Phone-Calculator-6f44a9f2</a>.</p>
<p>Just take a look at this link&nbsp;<a href="http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&f%5B0%5D.Value=Houssem%20Dellai">http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&amp;f%5B0%5D.Value=Houssem%20Dellai</a>&nbsp;.</p>
<p><em><em><br>
</em></em></p>
