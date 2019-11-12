# UWP Youtube Downloader
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Silverlight
- Windows Forms
- WPF
- Microsoft Azure
- XAML
- .NET Framework
- .NET Framework 4.0
- Windows Runtime
- Windows Phone 8
- Windows Store app
## Topics
- Controls
- C#
- User Interface
- Microsoft Azure
- Data Access
- XAML
- Networking
- C# Language Features
- Windows Store app
- data and storage
- universal app
## Updated
- 08/07/2016
## Description

<h2>What is YouTube Downloader?</h2>
<p>YouTube Downloader is software that allows you to download videos from YouTube and many others and convert them to other video formats for free.<br>
The program is easy to use, just specify the URL for the video you want to download and click the Ok button!<br>
You can use YouTube Downloader to download the videos of your choice from home, at the office or in school.<br>
Download YouTube Downloader now and get started downloading your favorite videos from YouTube.<br>
Enjoy!</p>
<p><strong>YouTube</strong>&nbsp;is a global&nbsp;<a title="Video hosting service" href="https://en.wikipedia.org/wiki/Video_hosting_service">video-sharing</a>&nbsp;<a title="Website" href="https://en.wikipedia.org/wiki/Website">website</a>&nbsp;headquartered
 in&nbsp;<a title="San Bruno, California" href="https://en.wikipedia.org/wiki/San_Bruno,_California">San Bruno, California</a>, United States.</p>
<p>The service was created by three former&nbsp;<a title="PayPal" href="https://en.wikipedia.org/wiki/PayPal">PayPal</a>&nbsp;employees in February 2005. In November 2006, it was bought by&nbsp;<a title="Google" href="https://en.wikipedia.org/wiki/Google">Google</a>&nbsp;for
 US$1.65 billion.<sup id="cite_ref-4" class="reference"><a href="https://en.wikipedia.org/wiki/YouTube#cite_note-4">[4]</a></sup>&nbsp;YouTube now operates as one of Google's&nbsp;<a title="Subsidiary" href="https://en.wikipedia.org/wiki/Subsidiary">subsidiaries</a>.<sup id="cite_ref-5" class="reference"><a href="https://en.wikipedia.org/wiki/YouTube#cite_note-5">[5]</a></sup>&nbsp;The
 site allows users to upload, view, rate, share, and comment on videos, and it makes use of&nbsp;<a title="WebM" href="https://en.wikipedia.org/wiki/WebM">WebM</a>,&nbsp;<a title="H.264/MPEG-4 AVC" href="https://en.wikipedia.org/wiki/H.264/MPEG-4_AVC">H.264/MPEG-4
 AVC</a>, and&nbsp;<a title="Adobe Systems" href="https://en.wikipedia.org/wiki/Adobe_Systems">Adobe</a>&nbsp;<a title="Flash Video" href="https://en.wikipedia.org/wiki/Flash_Video">Flash Video</a>&nbsp;technology to display a wide variety of&nbsp;<a title="User-generated content" href="https://en.wikipedia.org/wiki/User-generated_content">user-generated</a>&nbsp;and&nbsp;<a title="Corporate media" href="https://en.wikipedia.org/wiki/Corporate_media">corporate
 media</a>video. Available content includes&nbsp;<a title="Video clip" href="https://en.wikipedia.org/wiki/Video_clip">video clips</a>, TV clips,&nbsp;<a title="Music video" href="https://en.wikipedia.org/wiki/Music_video">music videos</a>,&nbsp;<a title="Trailer (promotion)" href="https://en.wikipedia.org/wiki/Trailer_(promotion)">movie
 trailers</a>, and other content such as&nbsp;<a title="Video blog" href="https://en.wikipedia.org/wiki/Video_blog">video blogging</a>, short original videos, and educational videos.</p>
<p>Most of the content on YouTube has been uploaded by individuals, but media corporations including&nbsp;<a title="CBS" href="https://en.wikipedia.org/wiki/CBS">CBS</a>, the&nbsp;<a title="BBC" href="https://en.wikipedia.org/wiki/BBC">BBC</a>,&nbsp;<a title="Vevo" href="https://en.wikipedia.org/wiki/Vevo">Vevo</a>,&nbsp;<a title="Hulu" href="https://en.wikipedia.org/wiki/Hulu">Hulu</a>,
 and other organizations offer some of their material via YouTube, as part of the YouTube partnership program.<sup id="cite_ref-6" class="reference"><a href="https://en.wikipedia.org/wiki/YouTube#cite_note-6">[6]</a></sup>&nbsp;Unregistered users can watch
 videos, and registered users are permitted to upload an unlimited number of videos and add comments to videos. Videos deemed potentially offensive are available only to registered users affirming themselves to be at least 18 years old.</p>
<p>&nbsp;</p>
<h1><img id="157851" src="157851-untitled.png" alt="" width="1207" height="865"></h1>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&lt;Grid&nbsp;Background=<span class="cs__string">&quot;{ThemeResource&nbsp;ApplicationPageBackgroundThemeBrush}&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;Height=<span class="cs__string">&quot;*&quot;</span>&gt;&lt;/RowDefinition&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;Height=<span class="cs__string">&quot;2*&quot;</span>&gt;&lt;/RowDefinition&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&nbsp;Grid.Row=<span class="cs__string">&quot;0&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock&nbsp;Text=<span class="cs__string">&quot;YOUTUBE&nbsp;DOWNLOADER&quot;</span>&nbsp;FontSize=<span class="cs__string">&quot;20&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Center&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;0,30,0,0&quot;</span>&gt;&lt;/TextBlock&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;AutoSuggestBox&nbsp;x:Name=<span class="cs__string">&quot;SearchBox&quot;</span>&nbsp;Width=<span class="cs__string">&quot;400&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PlaceholderText=<span class="cs__string">&quot;Please&nbsp;input&nbsp;the&nbsp;link&nbsp;of&nbsp;youtube&nbsp;video&nbsp;here&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Margin=<span class="cs__string">&quot;0,80,0,0&quot;</span>&nbsp;TextChanged=<span class="cs__string">&quot;SearchBox_TextChanged&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QueryIcon=<span class="cs__string">&quot;Find&quot;</span>&nbsp;QuerySubmitted=<span class="cs__string">&quot;SearchBox_QuerySubmitted&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&gt;&lt;/AutoSuggestBox&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&nbsp;x:Name=<span class="cs__string">&quot;gridRoot&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ListView&nbsp;x:Name=<span class="cs__string">&quot;lstDownload&quot;</span>&nbsp;LayoutUpdated=<span class="cs__string">&quot;lstDownload_LayoutUpdated&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ListView.ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid.ColumnDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ColumnDefinition&nbsp;Width=<span class="cs__string">&quot;170&quot;</span>&gt;&lt;/ColumnDefinition&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ColumnDefinition&nbsp;Width=<span class="cs__string">&quot;300&quot;</span>&gt;&lt;/ColumnDefinition&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ColumnDefinition&nbsp;Width=<span class="cs__string">&quot;*&quot;</span>&gt;&lt;/ColumnDefinition&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.ColumnDefinitions&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&nbsp;Grid.Column=<span class="cs__string">&quot;0&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Image&nbsp;Source=<span class="cs__string">&quot;{Binding&nbsp;Thumbail}&quot;</span>&nbsp;Width=<span class="cs__string">&quot;100&quot;</span>&nbsp;Height=<span class="cs__string">&quot;80&quot;</span>&gt;&lt;/Image&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&nbsp;Grid.Column=<span class="cs__string">&quot;1&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock&nbsp;Text=<span class="cs__string">&quot;{Binding&nbsp;Title}&quot;</span>&nbsp;VerticalAlignment=<span class="cs__string">&quot;Center&quot;</span>&gt;&lt;/TextBlock&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&nbsp;Grid.Column=<span class="cs__string">&quot;2&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;StackPanel&nbsp;Orientation=<span class="cs__string">&quot;Horizontal&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock&nbsp;Text=<span class="cs__string">&quot;{Binding&nbsp;Downloaded}&quot;</span>&nbsp;FontSize=<span class="cs__string">&quot;12&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;10,0,0,0&quot;</span>&gt;&lt;/TextBlock&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ProgressBar&nbsp;Value=<span class="cs__string">&quot;{Binding&nbsp;Percentage}&quot;</span>&nbsp;Width=<span class="cs__string">&quot;500&quot;</span>&gt;&lt;/ProgressBar&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/StackPanel&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DataTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView.ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;</pre>
</div>
</div>
</div>
<ul class="redTick">
<li>You do not appreciate ads and other distractions when you&rsquo;re trying to watch a video.
</li><li>You have a slow internet connection or you&rsquo;re viewing HD video, which causes buffering delays while streaming video.
</li><li>You want to make sure you don&rsquo;t lose the video when it&rsquo;s removed or altered by YouTube or by the author.
</li><li>You&rsquo;re only interested in a specific part of the video and you&rsquo;d like to cut out any parts you don&rsquo;t need.
</li></ul>
