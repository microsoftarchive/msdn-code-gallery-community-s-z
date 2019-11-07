# Windows Store Apps: How to load local html file in WebView control (C#-Xaml)
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- WinRT
- Windows Store app
- Windows Phone 8.1
## Topics
- Load html file in windows store apps C#
- Display local html file in windows phone 8.1 c#
## Updated
- 01/06/2016
## Description

<p><span style="font-size:small"><strong><span style="font-family:Verdana,sans-serif">Introduction:</span></strong></span></p>
<p><span style="font-size:small"><strong><span style="font-family:Verdana,sans-serif">&nbsp;</span></strong><span style="font-family:Verdana,sans-serif">Some times we may need to load local html file in webview, and fortunately we can easily load html file
 in window phone (in both silverlight &amp; winrt). However this article will explain how to a load local html file in web view control using different ways.</span><span style="color:#222426; font-family:Verdana,sans-serif">&nbsp;:)</span></span></p>
<p class="separator"><span style="font-size:small"><a href="http://4.bp.blogspot.com/-kPvlQMXCxWI/Vop7oxfrSHI/AAAAAAAACOU/KrJY3FFbKNQ/s1600/WindowsSeries.png"><span style="font-family:Verdana,sans-serif"><img src=":-windowsseries.png" border="0" alt="" width="640" height="240"></span></a></span></p>
<p><span style="font-size:small"><strong><span style="font-family:verdana,sans-serif">Requirements:</span></strong></span></p>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">This sample is targeted for windows phone winrt 8.1 OS,So make sure you&rsquo;ve downloaded and installed the Windows Phone 8.1 SDK. For more information, see&nbsp;<a href="https://dev.windowsphone.com/en-us/downloadsdk">Get
 the SDK</a>. </span></li><li><span style="font-family:verdana,sans-serif; font-size:small">I assumes that you&rsquo;re going to test your app on the Windows Phone emulator. If you want to test your app on a phone, you have to take some additional steps. For more info, see&nbsp;<a href="http://msdn.microsoft.com/en-us/library/windowsphone/develop/dn614128.aspx">Register
 your Windows Phone device for development</a>. </span></li><li><span style="font-family:verdana,sans-serif; font-size:small">This post assumes&nbsp;you&rsquo;re using&nbsp;<strong>Microsoft Visual Studio Express&nbsp;2013 for Windows or Later.</strong></span>
</li></ul>
<p><span style="font-size:small"><strong><span style="font-family:verdana,sans-serif">Description:</span></strong></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">Previously in silverlight platfrom(WP8.0/WP8.1), we are using below code to load html content in&nbsp;WebBrowser control with different ways.</span></p>
<p><span style="font-size:small"><strong>Silverlight WindowsPhone: </strong></span></p>
<div class="scriptcode"><span style="font-size:small"><strong>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">//Load local html file using 'Source' property 
WebBrowserName.Source = new Uri(&quot;LocalHTMLPage.html&quot;, UriKind.Relative); 

//Load local html file using 'Navigate' method  
WebBrowserName.Navigate(new Uri(&quot;LocalHTMLPage.html&quot;, UriKind.Relative));  

//Load html string using 'NavigateToString' method  
 WebBrowserName.NavigateToString(&quot;&lt;Html&gt;&lt;Body&gt;&lt;h1&gt;Load local html string in windows phone silverlight app.&lt;h1&gt;&lt;Body&gt;&lt;/Html&gt;&quot;);  </pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//Load&nbsp;local&nbsp;html&nbsp;file&nbsp;using&nbsp;'Source'&nbsp;property&nbsp;</span>&nbsp;
WebBrowserName.Source&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;LocalHTMLPage.html&quot;</span>,&nbsp;UriKind.Relative);&nbsp;&nbsp;
&nbsp;
<span class="cs__com">//Load&nbsp;local&nbsp;html&nbsp;file&nbsp;using&nbsp;'Navigate'&nbsp;method&nbsp;&nbsp;</span>&nbsp;
WebBrowserName.Navigate(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;LocalHTMLPage.html&quot;</span>,&nbsp;UriKind.Relative));&nbsp;&nbsp;&nbsp;
&nbsp;
<span class="cs__com">//Load&nbsp;html&nbsp;string&nbsp;using&nbsp;'NavigateToString'&nbsp;method&nbsp;&nbsp;</span>&nbsp;
&nbsp;WebBrowserName.NavigateToString(<span class="cs__string">&quot;&lt;Html&gt;&lt;Body&gt;&lt;h1&gt;Load&nbsp;local&nbsp;html&nbsp;string&nbsp;in&nbsp;windows&nbsp;phone&nbsp;silverlight&nbsp;app.&lt;h1&gt;&lt;Body&gt;&lt;/Html&gt;&quot;</span>);&nbsp;&nbsp;</pre>
</div>
</div>
</strong></span></div>
<p><span style="font-size:small"><strong>&nbsp;</strong><strong><strong>WinRT WindowsPhone:</strong></strong></span></p>
<p><span style="font-size:small"><strong><strong></strong></strong><span style="font-family:Verdana,sans-serif">Now lets start to write code for&nbsp;</span>load html content in&nbsp;WebView control with different ways.</span></p>
<p class="separator"><span style="font-size:small">1. Open Microsoft Visual Studio Express 2013 for Windows (or) later.</span></p>
<p><span style="font-family:Verdana,sans-serif; font-size:small">2. Create new windows phone winrt project using the &quot;Blank App&quot; template available under Visual C# -&gt; Store Apps -&gt; Windows Phone Apps. (for example project name :WindwsCsharpvsJavascript)</span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small"><a href="http://4.bp.blogspot.com/-v5KwpWTYUDA/VozFISglMcI/AAAAAAAACOk/oyEcTzFMx5E/s1600/NewProject.PNG"><img src=":-newproject.png" border="0" alt="" width="640" height="390"></a></span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small">3. And lets add below code in&nbsp;<strong>MainPage.xaml</strong>, which is having one WebView control is for&nbsp;displaying html conent , and one Button is for loading html
 on Click event. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">XAML</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">xaml </span>
<pre class="hidden"><span style="font-size:small">&lt;Grid  Background=&quot;LightBlue&quot;&gt;
       &lt;Grid x:Name=&quot;LayoutRoot&quot; Margin=&quot;5&quot;&gt;  
           &lt;Grid.RowDefinitions&gt;  
               &lt;RowDefinition Height=&quot;Auto&quot;/&gt;  
               &lt;RowDefinition Height=&quot;Auto&quot;/&gt;  
           &lt;/Grid.RowDefinitions&gt;  
           &lt;WebView Name=&quot;WebBrowserName&quot; Grid.Row=&quot;0&quot; Height=&quot;272&quot; Margin=&quot;5&quot; /&gt;  
           &lt;Button Name=&quot;BtnLoadHtml&quot; Foreground=&quot;Black&quot; Grid.Row=&quot;1&quot; HorizontalAlignment=&quot;Stretch&quot; Content=&quot;Load local html file&quot; Click=&quot;BtnLoadHtml_Click&quot; /&gt;
       &lt;/Grid&gt;  
   &lt;/Grid&gt;  </span></pre>
<div class="preview">
<pre class="xaml"><span style="font-size:small"><span class="xaml__tag_start">&lt;Grid</span>&nbsp;&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;LightBlue&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;LayoutRoot&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;WebView</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;WebBrowserName&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;272&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;BtnLoadHtml&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Stretch&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Load&nbsp;local&nbsp;html&nbsp;file&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;BtnLoadHtml_Click&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;4. In general, in WinRT we have following ways to load html content in WebView control
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void BtnLoadHtml_Click(object sender, RoutedEventArgs e)  

       {  
 //Load local file using 'Source' property  
           WebBrowserName.Source = new Uri(&quot;ms-appx-web:///HTMLPage.html&quot;);  

 //Load local file using 'Navigate' method  
           WebBrowserName.Navigate(new Uri(&quot;ms-appx-web:///HTMLPage.html&quot;)); 

 //Load html string using 'NavigateToString' method
           WebBrowserName.NavigateToString(&quot;&lt;Html&gt;&lt;Body&gt;&lt;h1&gt;Load local html string in windows phone winrt app.&lt;h1&gt;&lt;Body&gt;&lt;/Html&gt;&quot;);  

       }  </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;BtnLoadHtml_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;<span class="cs__com">//Load&nbsp;local&nbsp;file&nbsp;using&nbsp;'Source'&nbsp;property&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebBrowserName.Source&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;ms-appx-web:///HTMLPage.html&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;<span class="cs__com">//Load&nbsp;local&nbsp;file&nbsp;using&nbsp;'Navigate'&nbsp;method&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebBrowserName.Navigate(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;ms-appx-web:///HTMLPage.html&quot;</span>));&nbsp;&nbsp;
&nbsp;
&nbsp;<span class="cs__com">//Load&nbsp;html&nbsp;string&nbsp;using&nbsp;'NavigateToString'&nbsp;method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebBrowserName.NavigateToString(<span class="cs__string">&quot;&lt;Html&gt;&lt;Body&gt;&lt;h1&gt;Load&nbsp;local&nbsp;html&nbsp;string&nbsp;in&nbsp;windows&nbsp;phone&nbsp;winrt&nbsp;app.&lt;h1&gt;&lt;Body&gt;&lt;/Html&gt;&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>Note:</strong>&nbsp;in WinRT WebView can load content from the application&rsquo;s package using ms-appx-web://, from the network using http/https, or from a string using NavigateToString. It cannot load content from the
 application&rsquo;s data storage. To access the intranet, the corresponding capability must be turned on in the application manifest.</div>
</span></div>
<p>&nbsp;</p>
<p><span style="font-family:verdana,sans-serif; font-size:small">5. And also we have another way to load local html file in WinRT WebView control is using&nbsp;<a href="https://msdn.microsoft.com/library/windows/apps/dn299344" target="_blank">NavigateToLocalStreamUri&nbsp;</a>we
 can load local web content of application. This method can be used in both windows store(8.1) and windows phone 8.1 [<strong>Windows Runtime apps only</strong>].</span></p>
<p><span style="font-size:small"><strong style="font-family:Verdana,sans-serif; font-size:small">5.1 How to load local html file in WebView control using NavigateToLocalStreamUri:</strong></span></p>
<p><span style="font-size:small"><strong style="font-family:Verdana,sans-serif; font-size:small">&nbsp;</strong><strong style="font-size:small">5.1.1&nbsp;</strong><span style="font-family:Verdana,sans-serif"><strong>Why&nbsp;NavigateToLocalStreamUri?</strong></span></span></p>
<p><span style="font-family:Verdana,sans-serif; font-size:small">We can also use NavigateToString to navigate to static HTML content, but does not provide a way to generate these resources programmatically.(Ex: we can't load local html files with NavigateToString
 method). So we can handle it from NavigateToLocalStreamUri &nbsp;method.</span></p>
<p><span style="font-size:small"><span style="font-family:Verdana,sans-serif">Okay lets follow below steps to use&nbsp;</span>NavigateToLocalStreamUri &nbsp;</span></p>
<p><span style="font-size:small"><strong>Step 1:</strong>Right click on project and create helper class name is '<span style="font-family:Verdana,sans-serif"><strong>StreamUriWinRTResolver</strong>' and it should&nbsp;implement&nbsp;'<strong>IUriToStreamResolver</strong>'
 interface&nbsp;that translates a URI pattern into a content stream. </span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">csharp </span>
<pre class="hidden"><span style="font-size:small">public sealed class StreamUriWinRTResolver : IUriToStreamResolver
    {
        public IAsyncOperation&lt;IInputStream&gt; UriToStreamAsync(Uri uri)
        {
            if (uri == null)
            {
                throw new Exception();
            }
            string path = uri.AbsolutePath;

            // Because of the signature of the this method, it can't use await, so we 
            // call into a seperate helper method that can use the C# await pattern.
            return GetContent(path).AsAsyncOperation();
        }

        private async Task&lt;IInputStream&gt; GetContent(string path)
        {
            // We use a package folder as the source, but the same principle should apply
            // when supplying content from other locations
            try
            {
                Uri localUri = new Uri(&quot;ms-appx://&quot; &#43; path);
                StorageFile f = await StorageFile.GetFileFromApplicationUriAsync(localUri);
                IRandomAccessStream stream = await f.OpenAsync(FileAccessMode.Read);
                return stream;
            }
            catch (Exception) { throw new Exception(&quot;Invalid path&quot;); }
        }
    }</span></pre>
<div class="preview">
<pre class="csharp"><span style="font-size:small"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">sealed</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;StreamUriWinRTResolver&nbsp;:&nbsp;IUriToStreamResolver&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IAsyncOperation&lt;IInputStream&gt;&nbsp;UriToStreamAsync(Uri&nbsp;uri)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(uri&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Exception();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;path&nbsp;=&nbsp;uri.AbsolutePath;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Because&nbsp;of&nbsp;the&nbsp;signature&nbsp;of&nbsp;the&nbsp;this&nbsp;method,&nbsp;it&nbsp;can't&nbsp;use&nbsp;await,&nbsp;so&nbsp;we&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;call&nbsp;into&nbsp;a&nbsp;seperate&nbsp;helper&nbsp;method&nbsp;that&nbsp;can&nbsp;use&nbsp;the&nbsp;C#&nbsp;await&nbsp;pattern.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;GetContent(path).AsAsyncOperation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;async&nbsp;Task&lt;IInputStream&gt;&nbsp;GetContent(<span class="cs__keyword">string</span>&nbsp;path)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;We&nbsp;use&nbsp;a&nbsp;package&nbsp;folder&nbsp;as&nbsp;the&nbsp;source,&nbsp;but&nbsp;the&nbsp;same&nbsp;principle&nbsp;should&nbsp;apply</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;when&nbsp;supplying&nbsp;content&nbsp;from&nbsp;other&nbsp;locations</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;localUri&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;ms-appx://&quot;</span>&nbsp;&#43;&nbsp;path);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StorageFile&nbsp;f&nbsp;=&nbsp;await&nbsp;StorageFile.GetFileFromApplicationUriAsync(localUri);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IRandomAccessStream&nbsp;stream&nbsp;=&nbsp;await&nbsp;f.OpenAsync(FileAccessMode.Read);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;stream;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception)&nbsp;{&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Exception(<span class="cs__string">&quot;Invalid&nbsp;path&quot;</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small"><strong>Step 2:</strong></span></div>
<div class="endscriptcode"><span style="font-size:small"><strong>&nbsp;</strong>On Button click event, use above helper class like below:
</span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">csharp </span>
<pre class="hidden"><span style="font-size:small">private void BtnLoadHtml_Click(object sender, RoutedEventArgs e)
        {
            //Load local file using 'NavigateToLocalStreamUri' method
            Uri url = WebBrowserName.BuildLocalStreamUri(&quot;MyTag&quot;, &quot;HTMLPage.html&quot;);
            StreamUriWinRTResolver myResolver = new StreamUriWinRTResolver();

            // Pass the resolver object to the navigate call.
            WebBrowserName.NavigateToLocalStreamUri(url, myResolver);
        }</span></pre>
<div class="preview">
<pre class="csharp"><span style="font-size:small"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;BtnLoadHtml_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Load&nbsp;local&nbsp;file&nbsp;using&nbsp;'NavigateToLocalStreamUri'&nbsp;method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;url&nbsp;=&nbsp;WebBrowserName.BuildLocalStreamUri(<span class="cs__string">&quot;MyTag&quot;</span>,&nbsp;<span class="cs__string">&quot;HTMLPage.html&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StreamUriWinRTResolver&nbsp;myResolver&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamUriWinRTResolver();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Pass&nbsp;the&nbsp;resolver&nbsp;object&nbsp;to&nbsp;the&nbsp;navigate&nbsp;call.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebBrowserName.NavigateToLocalStreamUri(url,&nbsp;myResolver);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;<strong>6. Output:</strong></span><strong style="font-family:Verdana,sans-serif; font-size:small">&nbsp;</strong></div>
</div>
<p class="separator"><span style="font-size:small"><strong><a href="http://1.bp.blogspot.com/-Z6MvC5h1Td4/VozvoCoVNGI/AAAAAAAACO0/dCZHeYNv1NA/s1600/Output.png"><img src=":-output.png" border="0" alt="" width="360" height="640"></a></strong></span></p>
<p><span style="font-size:small"><strong>&nbsp;</strong></span><strong style="font-size:small"><span style="font-family:Verdana,sans-serif">Important Notes:</span></strong></p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small">1.&nbsp;In this article, we learn about new method called 'NavigateToLocalStreamUri' and your helper class should implement a interface called 'IUriToStreamResolver'.</span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small">2. WebView control in windows phone WinRT is used for displaying html content, and in silverlight windows phone we called it as 'WebBrowser' control.</span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small">3.&nbsp;This sample will be work on all above windows phone 8.0 OS devices. and this sample was tested in Nokia Lumia 735 device &amp; Microsoft 535.</span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small">You can also read this article at my original blog from&nbsp;<a href="http://bsubramanyamraju.blogspot.com/2016/01/windows-store-apps-how-to-load-local.html" target="_blank">here.</a>&nbsp;<br>
</span></p>
<p class="separator"><span style="font-size:small"><strong>Help me with feedback:</strong></span></p>
<p class="separator"><span style="font-size:small"><strong>&nbsp;</strong>Thank you for reading my article. Drop all your questions/comments in QA tab give me your feedback with&nbsp;<img id="67168" src="67168-ratings.png" alt="" width="74" height="15">&nbsp;star
 rating (1 Star - Very Poor, 5&nbsp;Star -&nbsp;Very Nice). &nbsp;</span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small"><span style="color:#000000">Follow me always at&nbsp;&nbsp;</span><a class="account-group x_x_x_js-account-group x_x_x_js-action-profile x_x_x_js-user-profile-link x_x_x_js-nav" href="https://twitter.com/Subramanyam_B"><span class="username js-action-profile-name" style="color:#8899a6"><span style="color:#b1bbc3">@</span>Subramanyam_B</span>&nbsp;</a></span></p>
<p class="separator"><span style="font-size:small"><span style="font-family:Verdana,sans-serif"><a class="account-group x_x_x_js-account-group x_x_x_js-action-profile x_x_x_js-user-profile-link x_x_x_js-nav" href="https://twitter.com/Subramanyam_B"></a></span><span style="font-family:Verdana,sans-serif">Have
 a nice day by</span><span style="color:#000000">&nbsp;</span><a href="http://bsubramanyamraju.blogspot.in/p/about-me.html" style="font-family:Verdana,sans-serif; font-size:small">Subramanyam Raju</a><span style="color:#000000">&nbsp;:)</span></span></p>
