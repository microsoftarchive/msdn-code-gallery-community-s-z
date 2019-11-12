# Simple WebBrowser
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Web Browser
## Topics
- Web Browser Control
- Web Browser
- Internet Browser
## Updated
- 06/21/2017
## Description

<h1>Introduction</h1>
<p><span style="font-size:small"><em>T</em><em>his sample demostrates how to build a simple web browser that is able to load websites, and do some basic stuff. &nbsp;</em></span></p>
<h1><span>Building the Sample</span></h1>
<ul>
<li><span style="font-size:small"><em>donwload this sample ,</em><em>unzip it</em></span>
</li><li><span style="font-size:small"><em>open solution&nbsp;</em></span> </li><li><span style="font-size:small"><em>build and run</em></span> </li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>&nbsp;</p>
<h1><span style="font-size:small">this web browser application was created in WPF , this is simplest one web browser able to do basic stuff, like loading webistes, navigating backward and forrward, refreshing page</span></h1>
<h1><span style="font-size:small">you can explore and modify it , or add new features in it.</span></h1>
<h1></h1>
<h1><span style="font-size:small">I have used following controls in this application:</span></h1>
<ul>
<li>
<h1><span style="font-size:small">buttons</span></h1>
</li><li>
<h1><span style="font-size:small">textBox</span></h1>
</li><li>
<h1><span style="font-size:small">webBrowser&nbsp;</span></h1>
</li></ul>
<h1></h1>
<h1><span style="font-size:small">webBrowser control was named as &quot;webBrowser1&quot;</span></h1>
<p><strong><br>
<img id="174678" src="174678-browserscreenshot2.png" alt=""><br>
<br>
</strong></p>
<p><span style="font-size:small">to open websites we first check URL, and make sure that url is complete&nbsp;</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">for proper URL validation and opening URL here is the function:</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div><span style="color:#0000ff"><em>&nbsp;private void openLink(string url)</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {&nbsp;</em></span></div>
<div><span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if(!url.StartsWith(&quot;http://&quot;) &amp;&amp; !url.StartsWith(&quot;https://&quot;))</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; url = &quot;http:\\&quot; &#43; url;</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webBrowser1.Navigate(new Uri(url));</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch(<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.UriFormatException.aspx" target="_blank" title="Auto generated link to System.UriFormatException">System.UriFormatException</a>)</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return;</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</em></span><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
<span style="color:#0000ff"><em>&nbsp; &nbsp; &nbsp; }</em></span></div>
<div></div>
<div></div>
<div><strong><span style="font-size:small">and function for navigating forward is:</span></strong></div>
<div></div>
<div>&nbsp;<span style="color:#0000ff">&nbsp; <em>private void btnForward_Click(object sender, RoutedEventArgs e)</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (webBrowser1.CanGoForward)</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webBrowser1.GoForward();</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</em></span></div>
<div></div>
<div></div>
<div><strong><span style="font-size:small">function for navigating backward is :</span></strong></div>
<div></div>
<div><span style="color:#0000ff"><em>&nbsp;private void btnBackward_Click(object sender, RoutedEventArgs e)</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (webBrowser1.CanGoBack)</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webBrowser1.GoBack();</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</em></span></div>
<div></div>
<div><strong><span style="font-size:small">function for refreshing page is :</span></strong></div>
<div></div>
<div><span style="color:#0000ff"><em>&nbsp;private void btnRefresh_Click(object sender, RoutedEventArgs e)</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webBrowser1.Refresh();</em></span><br>
<span style="color:#0000ff"><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }&nbsp;</em></span></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>feel free to give feedback at :</p>
<p><strong>umairnadeem20@hotmail.com</strong></p>
