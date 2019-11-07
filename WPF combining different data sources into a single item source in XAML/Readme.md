# WPF combining different data sources into a single item source in XAML
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- XAML
- WPF Data Binding
## Topics
- User Interface
- WPF
- XAML
- WPF Basics
- WPF Data Binding
- WPF Binding
## Updated
- 05/20/2015
## Description

<h3><span style="font-size:2em">Introduction</span></h3>
<p>This sample shows how to combine separate collections of unrelated&nbsp;types into a single CompositeCollection of CollectionViewSources&nbsp;that can then be bound to an items control (ListBox, ListView etc.). It also shows how to use data templates to
 allow a control to display items of different types.</p>
<p><img id="130797" src="130797-screenshot.png" alt="" width="446" height="421"></p>
<p>This approach is XAML based, making it a good option if you are worried about sticking to MVVM and keeping all presentation logic in the view.<em><br>
</em></p>
<h3><span style="font-size:20px; font-weight:bold">Description</span></h3>
<p>In the sample there are 3 ObservableCollections in the MainWindowViewModel. Each of these is for a different class (Movie, Book and Album).</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        public ObservableCollection&lt;Movie&gt; Movies { get; set; }

        public ObservableCollection&lt;Book&gt; Books { get; set; }

        public ObservableCollection&lt;Album&gt; Albums { get; set; }</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ObservableCollection&lt;Movie&gt;&nbsp;Movies&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ObservableCollection&lt;Book&gt;&nbsp;Books&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ObservableCollection&lt;Album&gt;&nbsp;Albums&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}</pre>
</div>
</div>
</div>
<p>The observable collections are declared as&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.windows.data.collectionviewsource(v=vs.110).aspx" target="_blank">CollectionViewSources</a>&nbsp;as a window level resource in the MainWindow. They are
 combined into a <a href="http://msdn.microsoft.com/en-us/library/system.windows.data.compositecollection(v=vs.110).aspx">
CompositeCollection</a>,&nbsp;which can be used as an item source for any items control you want.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Window.Resources&gt;
    &lt;!--Collection views for the ObservableCollections in the view model or code behind.--&gt;
    &lt;CollectionViewSource x:Key=&quot;BooksViewSource&quot; Source=&quot;{Binding Books}&quot;/&gt;
    &lt;CollectionViewSource x:Key=&quot;MoviesViewSource&quot; Source=&quot;{Binding Movies}&quot;/&gt;
    &lt;CollectionViewSource x:Key=&quot;AlbumsViewSource&quot; Source=&quot;{Binding Albums}&quot;/&gt;
        
    &lt;!--Combine the collection views into a single composite collection--&gt;
    &lt;CompositeCollection x:Key=&quot;CombinedCollection&quot;&gt;            
        &lt;CollectionContainer Collection=&quot;{Binding Source={StaticResource BooksViewSource}}&quot; /&gt;
        &lt;CollectionContainer Collection=&quot;{Binding Source={StaticResource MoviesViewSource}}&quot; /&gt;
        &lt;CollectionContainer Collection=&quot;{Binding Source={StaticResource AlbumsViewSource}}&quot; /&gt;
    &lt;/CompositeCollection&gt;             
&lt;/Window.Resources&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Window</span>.Resources<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--Collection&nbsp;views&nbsp;for&nbsp;the&nbsp;ObservableCollections&nbsp;in&nbsp;the&nbsp;view&nbsp;model&nbsp;or&nbsp;code&nbsp;behind.--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;CollectionViewSource</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;BooksViewSource&quot;</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Books}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;CollectionViewSource</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;MoviesViewSource&quot;</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Movies}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;CollectionViewSource</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;AlbumsViewSource&quot;</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Albums}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--Combine&nbsp;the&nbsp;collection&nbsp;views&nbsp;into&nbsp;a&nbsp;single&nbsp;composite&nbsp;collection--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;CompositeCollection</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;CombinedCollection&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;CollectionContainer</span>&nbsp;<span class="xaml__attr_name">Collection</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Source={StaticResource&nbsp;BooksViewSource}}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;CollectionContainer</span>&nbsp;<span class="xaml__attr_name">Collection</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Source={StaticResource&nbsp;MoviesViewSource}}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;CollectionContainer</span>&nbsp;<span class="xaml__attr_name">Collection</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Source={StaticResource&nbsp;AlbumsViewSource}}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/CompositeCollection&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&lt;/Window.Resources&gt;</pre>
</div>
</div>
</div>
<p>MainWindow has a TabControl containing 3 examples of how to use the combined collection with different item controls:</p>
<h4>Listbox example</h4>
<h4 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;ListBox ItemsSource=&quot;{StaticResource CombinedCollection}&quot;&gt;
    &lt;ListBox.Resources&gt;
        &lt;!-- data templates which will be applied by type (Album,Movie,Book) --&gt;
        &lt;DataTemplate DataType=&quot;{x:Type local:Album}&quot;&gt;
            &lt;StackPanel Orientation=&quot;Horizontal&quot;&gt;
                &lt;Image Source=&quot;{StaticResource AlbumImg}&quot;/&gt;
                &lt;TextBlock Text=&quot;{Binding Path=Artist}&quot;/&gt;
                &lt;TextBlock Text=&quot;{Binding Path=Title}&quot;/&gt;
            &lt;/StackPanel&gt;
        &lt;/DataTemplate&gt;
        &lt;DataTemplate DataType=&quot;{x:Type local:Movie}&quot;&gt;
            &lt;StackPanel Orientation=&quot;Horizontal&quot;&gt;
                &lt;Image Source=&quot;{StaticResource MovieImg}&quot;/&gt;
                &lt;TextBlock Text=&quot;{Binding Path=Director}&quot;/&gt;
                &lt;TextBlock Text=&quot;{Binding Path=Title}&quot;/&gt;
            &lt;/StackPanel&gt;
        &lt;/DataTemplate&gt;
        &lt;DataTemplate DataType=&quot;{x:Type local:Book}&quot;&gt;
            &lt;StackPanel Orientation=&quot;Horizontal&quot;&gt;
                &lt;Image Source=&quot;{StaticResource BookImg}&quot;/&gt;
                &lt;TextBlock Text=&quot;{Binding Path=Author}&quot;/&gt;
                &lt;TextBlock Text=&quot;{Binding Path=Title}&quot;/&gt;
            &lt;/StackPanel&gt;
        &lt;/DataTemplate&gt;
    &lt;/ListBox.Resources&gt;
&lt;/ListBox&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;ListBox</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;CombinedCollection}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListBox</span>.Resources<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--&nbsp;data&nbsp;templates&nbsp;which&nbsp;will&nbsp;be&nbsp;applied&nbsp;by&nbsp;type&nbsp;(Album,Movie,Book)&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span>&nbsp;<span class="xaml__attr_name">DataType</span>=<span class="xaml__attr_value">&quot;{x:Type&nbsp;local:Album}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;AlbumImg}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=Artist}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=Title}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span>&nbsp;<span class="xaml__attr_name">DataType</span>=<span class="xaml__attr_value">&quot;{x:Type&nbsp;local:Movie}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;MovieImg}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=Director}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=Title}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span>&nbsp;<span class="xaml__attr_name">DataType</span>=<span class="xaml__attr_value">&quot;{x:Type&nbsp;local:Book}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;BookImg}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=Author}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=Title}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListBox.Resources&gt;&nbsp;
<span class="xaml__tag_end">&lt;/ListBox&gt;</span></pre>
</div>
</div>
</h4>
<h4>&nbsp;ListView example</h4>
<h4 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;ListView ItemsSource=&quot;{StaticResource CombinedCollection}&quot;&gt;
    &lt;ListView.Resources&gt;
        &lt;!-- data templates which will be applied by type (Album,Movie,Book) --&gt;
        &lt;DataTemplate DataType=&quot;{x:Type local:Album}&quot;&gt;
            &lt;StackPanel Orientation=&quot;Horizontal&quot;&gt;
                &lt;Image Source=&quot;{StaticResource AlbumImg}&quot;/&gt;
                &lt;TextBlock Text=&quot;{Binding Path=Artist}&quot;/&gt;
                &lt;TextBlock Text=&quot;{Binding Path=Title}&quot;/&gt;
            &lt;/StackPanel&gt;
        &lt;/DataTemplate&gt;
        &lt;DataTemplate DataType=&quot;{x:Type local:Movie}&quot;&gt;
            &lt;StackPanel Orientation=&quot;Horizontal&quot;&gt;
                &lt;Image Source=&quot;{StaticResource MovieImg}&quot;/&gt;
                &lt;TextBlock Text=&quot;{Binding Path=Director}&quot;/&gt;
                &lt;TextBlock Text=&quot;{Binding Path=Title}&quot;/&gt;
            &lt;/StackPanel&gt;
        &lt;/DataTemplate&gt;
        &lt;DataTemplate DataType=&quot;{x:Type local:Book}&quot;&gt;
            &lt;StackPanel Orientation=&quot;Horizontal&quot;&gt;
                &lt;Image Source=&quot;{StaticResource BookImg}&quot;/&gt;
                &lt;TextBlock Text=&quot;{Binding Path=Author}&quot;/&gt;
                &lt;TextBlock Text=&quot;{Binding Path=Title}&quot;/&gt;
            &lt;/StackPanel&gt;
        &lt;/DataTemplate&gt;
    &lt;/ListView.Resources&gt;
&lt;/ListView&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;ListView</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;CombinedCollection}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>.Resources<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--&nbsp;data&nbsp;templates&nbsp;which&nbsp;will&nbsp;be&nbsp;applied&nbsp;by&nbsp;type&nbsp;(Album,Movie,Book)&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span>&nbsp;<span class="xaml__attr_name">DataType</span>=<span class="xaml__attr_value">&quot;{x:Type&nbsp;local:Album}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;AlbumImg}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=Artist}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=Title}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span>&nbsp;<span class="xaml__attr_name">DataType</span>=<span class="xaml__attr_value">&quot;{x:Type&nbsp;local:Movie}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;MovieImg}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=Director}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=Title}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span>&nbsp;<span class="xaml__attr_name">DataType</span>=<span class="xaml__attr_value">&quot;{x:Type&nbsp;local:Book}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;BookImg}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=Author}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=Title}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView.Resources&gt;&nbsp;
<span class="xaml__tag_end">&lt;/ListView&gt;</span></pre>
</div>
</div>
</h4>
<h4>GridView example</h4>
<p>The final tab shows how to use a ListView with a GridView. In this case a CellTemplateSeletor (<strong>ByDataTemplateSelector</strong>)&nbsp;is required to handle the property names which are not shared between the classes (Author, Director and Artist).</p>
<h3 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;ListView ItemsSource=&quot;{StaticResource CombinedCollection}&quot;&gt;                                        
    &lt;ListView.Resources&gt;
        &lt;!-- data templates which will be applied by type (Album,Movie,Book) to show the icon --&gt;
        &lt;DataTemplate DataType=&quot;{x:Type local:Album}&quot;&gt;
            &lt;Image Source=&quot;{StaticResource AlbumImg}&quot;/&gt;
        &lt;/DataTemplate&gt;
        &lt;DataTemplate DataType=&quot;{x:Type local:Book}&quot;&gt;
            &lt;Image Source=&quot;{StaticResource BookImg}&quot;/&gt;
        &lt;/DataTemplate&gt;
        &lt;DataTemplate DataType=&quot;{x:Type local:Movie}&quot;&gt;
            &lt;Image Source=&quot;{StaticResource MovieImg}&quot;/&gt;
        &lt;/DataTemplate&gt;

        &lt;!--the cell template selector to choose the template to use when displaying: Artist, Author or Director--&gt;
        &lt;local:ByDataTemplateSelector x:Key=&quot;ByDataTemplateSelector&quot;/&gt;

        &lt;!--the cell templates to select from--&gt;
        &lt;DataTemplate x:Key=&quot;AuthorTemplate&quot;&gt;
            &lt;TextBlock Text=&quot;{Binding Author}&quot;/&gt;
        &lt;/DataTemplate&gt;
        &lt;DataTemplate x:Key=&quot;DirectorTemplate&quot;&gt;
            &lt;TextBlock Text=&quot;{Binding Director}&quot;/&gt;
        &lt;/DataTemplate&gt;
        &lt;DataTemplate x:Key=&quot;ArtistTemplate&quot;&gt;
            &lt;TextBlock Text=&quot;{Binding Artist}&quot;/&gt;
        &lt;/DataTemplate&gt;
    &lt;/ListView.Resources&gt;
    &lt;ListView.View&gt;                    
        &lt;GridView&gt;                
            &lt;GridViewColumn/&gt;
            &lt;GridViewColumn Header=&quot;Title&quot;&gt;
                &lt;GridViewColumn.CellTemplate&gt;
                    &lt;DataTemplate&gt;
                        &lt;TextBlock Text=&quot;{Binding Title}&quot;/&gt;
                    &lt;/DataTemplate&gt;
                &lt;/GridViewColumn.CellTemplate&gt;
            &lt;/GridViewColumn&gt;
            &lt;GridViewColumn Header=&quot;By&quot; CellTemplateSelector=&quot;{StaticResource ByDataTemplateSelector}&quot;/&gt;
        &lt;/GridView&gt;                
    &lt;/ListView.View&gt;
&lt;/ListView&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;ListView</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;CombinedCollection}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>.Resources<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--&nbsp;data&nbsp;templates&nbsp;which&nbsp;will&nbsp;be&nbsp;applied&nbsp;by&nbsp;type&nbsp;(Album,Movie,Book)&nbsp;to&nbsp;show&nbsp;the&nbsp;icon&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span>&nbsp;<span class="xaml__attr_name">DataType</span>=<span class="xaml__attr_value">&quot;{x:Type&nbsp;local:Album}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;AlbumImg}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span>&nbsp;<span class="xaml__attr_name">DataType</span>=<span class="xaml__attr_value">&quot;{x:Type&nbsp;local:Book}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;BookImg}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span>&nbsp;<span class="xaml__attr_name">DataType</span>=<span class="xaml__attr_value">&quot;{x:Type&nbsp;local:Movie}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;MovieImg}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--the&nbsp;cell&nbsp;template&nbsp;selector&nbsp;to&nbsp;choose&nbsp;the&nbsp;template&nbsp;to&nbsp;use&nbsp;when&nbsp;displaying:&nbsp;Artist,&nbsp;Author&nbsp;or&nbsp;Director--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:ByDataTemplateSelector&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;ByDataTemplateSelector&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--the&nbsp;cell&nbsp;templates&nbsp;to&nbsp;select&nbsp;from--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;AuthorTemplate&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Author}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;DirectorTemplate&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Director}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;ArtistTemplate&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Artist}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView.Resources&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>.View<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridView</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridViewColumn</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridViewColumn</span>&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;Title&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridViewColumn</span>.CellTemplate<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Title}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/GridViewColumn.CellTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/GridViewColumn&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridViewColumn</span>&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;By&quot;</span>&nbsp;<span class="xaml__attr_name">CellTemplateSelector</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;ByDataTemplateSelector}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/GridView&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView.View&gt;&nbsp;
<span class="xaml__tag_end">&lt;/ListView&gt;</span></pre>
</div>
</div>
</h3>
<h3>Summary</h3>
<p>If you have any questions or suggestions for improvement regarding this sample please feel free to leave them in the Q and A section.</p>
<div id="_mcePaste" class="mcePaste" style="left:-10000px; top:0px; width:1px; height:1px; overflow:hidden">
</div>
