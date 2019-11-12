# Sorting a WPF ListView by clicking on the header (2) - Sort Direction Indicators
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- XAML
- .NET Framework
- MVVM
## Topics
- GridView
- ListView
- Sorting
- Sorting Direction
## Updated
- 01/22/2015
## Description

<h1>Introduction</h1>
<p>Sorting a ListView by clicking on the header in WPF is not a function that is already existing. So it have to implemented by yourself. There are several ways to do this. This sample shows how to do this using a GridView as View of the ListView. This sample
 is build up on the <a href="http://code.msdn.microsoft.com/Sorting-a-WPF-ListView-by-209a7d45">
first sample</a> adding the ability to indicate the sorting direction in the header by small arrow glyphs. Therefore the sorting method is moved from ViewModel to View.<em><em><br>
</em></em></p>
<h1><span>Building the Sample</span></h1>
<p>There are no special requirements for building the sample.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>At first the small arrow glyphs that are used to indicate the sorting directions are defined.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;UserControl.Resources&gt;&nbsp;
&nbsp;&nbsp;&lt;DataTemplate&nbsp;x:Key=<span class="js__string">&quot;ArrowUp&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;DockPanel&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock&nbsp;HorizontalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text=<span class="js__string">&quot;{Binding}&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Path&nbsp;VerticalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Fill=<span class="js__string">&quot;Black&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data=<span class="js__string">&quot;M&nbsp;5,5&nbsp;15,5&nbsp;10,0&nbsp;5,5&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DockPanel&gt;&nbsp;
&nbsp;&nbsp;&lt;/DataTemplate&gt;&nbsp;
&nbsp;&nbsp;&lt;DataTemplate&nbsp;x:Key=<span class="js__string">&quot;ArrowDown&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;DockPanel&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock&nbsp;HorizontalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text=<span class="js__string">&quot;{Binding}&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Path&nbsp;VerticalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Fill=<span class="js__string">&quot;Black&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data=<span class="js__string">&quot;M&nbsp;5,0&nbsp;10,5&nbsp;15,0&nbsp;5,0&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DockPanel&gt;&nbsp;
&nbsp;&nbsp;&lt;/DataTemplate&gt;&nbsp;
&lt;/UserControl.Resources&gt;</pre>
</div>
</div>
</div>
<p class="endscriptcode">A click event handler is added to the ListView.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;ListView</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;SecondResultData&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;SecondResultData}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GridViewColumnHeader.<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;SecondResultDataViewClick&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>.View<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridView</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridViewColumn</span>&nbsp;<span class="xaml__attr_name">DisplayMemberBinding</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ResultNumber}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridViewColumnHeader</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Number&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/GridViewColumn&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridViewColumn</span>&nbsp;<span class="xaml__attr_name">DisplayMemberBinding</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ResultOutput}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridViewColumnHeader</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Output&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/GridViewColumn&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/GridView&gt;</span>&nbsp;
&nbsp;&nbsp;&lt;/ListView.View&gt;&nbsp;
<span class="xaml__tag_end">&lt;/ListView&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">The ItemsSource is binded to the property SecondResultData.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;ObservableCollection&lt;ResultData&gt;&nbsp;SecondResultData&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}</pre>
</div>
</div>
</div>
<p>The click event handler is implemented in code behind.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;ListSortDirection&nbsp;_sortDirection;&nbsp;
private&nbsp;GridViewColumnHeader&nbsp;_sortColumn;&nbsp;
&nbsp;&nbsp;
private&nbsp;<span class="js__operator">void</span>&nbsp;SecondResultDataViewClick(object&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;GridViewColumnHeader&nbsp;column&nbsp;=&nbsp;e.OriginalSource&nbsp;as&nbsp;GridViewColumnHeader;&nbsp;
&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(column&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(_sortColumn&nbsp;==&nbsp;column)&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Toggle&nbsp;sorting&nbsp;direction</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_sortDirection&nbsp;=&nbsp;_sortDirection&nbsp;==&nbsp;ListSortDirection.Ascending&nbsp;?&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListSortDirection.Descending&nbsp;:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListSortDirection.Ascending;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Remove&nbsp;arrow&nbsp;from&nbsp;previously&nbsp;sorted&nbsp;header</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(_sortColumn&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_sortColumn.Column.HeaderTemplate&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_sortColumn.Column.Width&nbsp;=&nbsp;_sortColumn.ActualWidth&nbsp;-&nbsp;<span class="js__num">20</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_sortColumn&nbsp;=&nbsp;column;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_sortDirection&nbsp;=&nbsp;ListSortDirection.Ascending;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;column.Column.Width&nbsp;=&nbsp;column.ActualWidth&nbsp;&#43;&nbsp;<span class="js__num">20</span>;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(_sortDirection&nbsp;==&nbsp;ListSortDirection.Ascending)&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;column.Column.HeaderTemplate&nbsp;=&nbsp;Resources[<span class="js__string">&quot;ArrowUp&quot;</span>]&nbsp;as&nbsp;DataTemplate;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;column.Column.HeaderTemplate&nbsp;=&nbsp;Resources[<span class="js__string">&quot;ArrowDown&quot;</span>]&nbsp;as&nbsp;DataTemplate;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;string&nbsp;header&nbsp;=&nbsp;string.Empty;&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;if&nbsp;binding&nbsp;is&nbsp;used&nbsp;and&nbsp;property&nbsp;name&nbsp;doesn't&nbsp;match&nbsp;header&nbsp;content</span>&nbsp;
&nbsp;&nbsp;Binding&nbsp;b&nbsp;=&nbsp;_sortColumn.Column.DisplayMemberBinding&nbsp;as&nbsp;Binding;&nbsp;
&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(b&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;header&nbsp;=&nbsp;b.Path.Path;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;ICollectionView&nbsp;resultDataView&nbsp;=&nbsp;CollectionViewSource.GetDefaultView(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SecondResultData.ItemsSource);&nbsp;
&nbsp;&nbsp;resultDataView.SortDescriptions.Clear();&nbsp;
&nbsp;&nbsp;resultDataView.SortDescriptions.Add(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;SortDescription(header,&nbsp;_sortDirection));&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">The click event handler set the HeaderTemplate of the columns. Therefore the previously defined glyphs are used. The column that is used to sort gets an arrow that indicates the sorting direction. The arrow is removed from previously
 sorted column, if necessary.</div>
<h1><span>Source Code Files</span></h1>
<ul>
</ul>
<ul>
<li><em>source code file name ResultData.cs - the Model.<br>
</em></li><li><em><em>source code file name SortingView.xaml - the View.</em></em> </li><li><em><em>source code file name SortingView.cs - code behind part of the View, setting of the DataContext.</em></em>
</li><li><em><em>source code file name SortingViewModel.cs - the ViewModel.</em></em> </li></ul>
<ul>
</ul>
<h1>More Information</h1>
<p><strong><em>For more information, see <a href="http://chrigas.blogspot.com/2013/12/sorting-evolution-2.html">
http://chrigas.blogspot.com/2013/12/sorting-evolution-2.html</a> on </em></strong></p>
<p><strong><em><a href="http://chrigas.blogspot.com/">http://chrigas.blogspot.com/</a></em></strong></p>
<p><em><em>For more information on sorting, see the <a href="http://code.msdn.microsoft.com/Sorting-a-WPF-ListView-by-209a7d45">
first sample</a>, the <a href="http://code.msdn.microsoft.com/Sorting-a-WPF-ListView-by-ce9cf6d7">
third sample</a>, the <a href="http://code.msdn.microsoft.com/Sorting-a-WPF-ListView-by-cc714059">
fourth sample</a>, the <a href="http://code.msdn.microsoft.com/Sorting-a-WPF-ListView-by-922d983d">
fifth sample</a>, the <a href="https://code.msdn.microsoft.com/windowsdesktop/Sorting-a-WPF-ListView-by-a009edcb">
sixth sample</a>, the <a href="https://code.msdn.microsoft.com/Sorting-a-WPF-ListView-by-027e2303">
seventh sample</a>, and the <a href="https://code.msdn.microsoft.com/windowsdesktop/Sorting-a-WPF-ListView-by-7e9c5e4a">
eighth sample</a></em></em></p>
