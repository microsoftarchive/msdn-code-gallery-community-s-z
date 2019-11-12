# Sorting a WPF ListView by clicking on the header (1)
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
- CollectionViewSource
- ListCollectionView
## Updated
- 01/22/2015
## Description

<h1>Introduction</h1>
<p>Sorting a ListView by clicking on the header in WPF is not a function that is already existing. So it have to implemented by yourself. There are several ways to do this. This sample shows how to do this using a GridView as View of the ListView, Model-View-ViewModel
 pattern (MVVM) and RelayCommand.<em><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p>There are no special requirements for building the sample.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>First we are looking at the XAML part, the View of the MVVM pattern.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;ListView</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;FirstResultDataView}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>.View<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridView</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridViewColumn</span>&nbsp;<span class="xaml__attr_name">DisplayMemberBinding</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ResultNumber}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridViewColumnHeader</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Number&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Command</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;SortCommand}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">CommandParameter</span>=<span class="xaml__attr_value">&quot;ResultNumber&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/GridViewColumn&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridViewColumn</span>&nbsp;<span class="xaml__attr_name">DisplayMemberBinding</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ResultOutput}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GridViewColumnHeader</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Output&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Command</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;SortCommand}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">CommandParameter</span>=<span class="xaml__attr_value">&quot;ResultOutput&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/GridViewColumn&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/GridView&gt;</span>&nbsp;
&nbsp;&nbsp;&lt;/ListView.View&gt;&nbsp;
<span class="xaml__tag_end">&lt;/ListView&gt;</span></pre>
</div>
</div>
</div>
<p>We have defined a ListView using a GridView. The ItemsSource is binded to the property FirstResultDataView in the ViewModel. The click event of each header is binded to the property SortCommand in the ViewModel by using
<a href="http://www.blogger.com/">RelayCommand</a>. The CommandParameter is the property name of an element of the ItemsSource.</p>
<p>The method Sort is connected to the SortCommand in the constructor of the ViewModel, so it is called after a header is clicked.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">SortCommand&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RelayCommand(Sort);</pre>
</div>
</div>
</div>
<div class="endscriptcode">Furthermore the property that is binded to the ItemsSource in the View and the Sort method are defined in the ViewModel.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;ObservableCollection&lt;ResultData&gt;&nbsp;_firstResultData;&nbsp;
<span class="cs__keyword">private</span>&nbsp;CollectionViewSource&nbsp;_firstResultDataView;&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;_sortColumn;&nbsp;
<span class="cs__keyword">private</span>&nbsp;ListSortDirection&nbsp;_sortDirection;&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">public</span>&nbsp;ICommand&nbsp;SortCommand&nbsp;
{&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">get</span>;&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;ObservableCollection&lt;ResultData&gt;&nbsp;FirstResultData&nbsp;
{&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_firstResultData;&nbsp;
&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_firstResultData&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_firstResultDataView&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CollectionViewSource();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_firstResultDataView.Source&nbsp;=&nbsp;_firstResultData;&nbsp;
&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;ListCollectionView&nbsp;FirstResultDataView&nbsp;
{&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;(ListCollectionView)_firstResultDataView.View;&nbsp;
&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Sort(<span class="cs__keyword">object</span>&nbsp;parameter)&nbsp;
{&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;column&nbsp;=&nbsp;parameter&nbsp;<span class="cs__keyword">as</span>&nbsp;<span class="cs__keyword">string</span>;&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_sortColumn&nbsp;==&nbsp;column)&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Toggle&nbsp;sorting&nbsp;direction</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_sortDirection&nbsp;=&nbsp;_sortDirection&nbsp;==&nbsp;ListSortDirection.Ascending&nbsp;?&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListSortDirection.Descending&nbsp;:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListSortDirection.Ascending;&nbsp;
&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_sortColumn&nbsp;=&nbsp;column;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_sortDirection&nbsp;=&nbsp;ListSortDirection.Ascending;&nbsp;
&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;_firstResultDataView.SortDescriptions.Clear();&nbsp;
&nbsp;&nbsp;_firstResultDataView.SortDescriptions.Add(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;SortDescription(_sortColumn,&nbsp;_sortDirection));&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">FirstResultDataView is the items source that is used in the view. It will be created if FirstResultData is set. The type of FirstResultDataView is
<a href="http://msdn.microsoft.com/en-us/library/system.windows.data.listcollectionview.aspx">
ListCollectionView</a> which can be used to sort, filter, or group data. It is derived from the View property of
<a href="http://msdn.microsoft.com/en-us/library/system.windows.data.collectionviewsource.aspx">
CollectionViewSource</a> by setting the source property to FirstResultData.
<p>The Sort method is called after a click on the column header is performed. It is adding a
<a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.sortdescription.aspx">
SortDescription</a> to the <a href="http://msdn.microsoft.com/en-us/library/system.windows.data.collectionviewsource.aspx">
CollectionViewSource</a>. The <a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.sortdescription.aspx">
SortDescription</a> gets the column that is to sort and direction of sorting by using
<a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.listsortdirection.aspx">
ListSortDirection</a>.</p>
</div>
<p>With that code&nbsp; you get a ListView that can be sorted by clicking on the header. The first click set the sort direction to ascending the second click to descending.</p>
<p><img alt=""></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name ResultData.cs - the Model.<br>
</em></li><li><em><em>source code file name SortingView.xaml - the View.</em></em> </li><li><em><em>source code file name SortingView.cs - code behind part of the View, setting of the DataContext.</em></em>
</li><li><em><em>source code file name SortingViewModel.cs - the ViewModel.</em></em> </li></ul>
<h1>More Information</h1>
<p><strong><em>For more information, see <a href="http://chrigas.blogspot.com/2013/12/sorting-evolution-1.html">
http://chrigas.blogspot.com/2013/12/sorting-evolution-1.html</a> on </em></strong></p>
<p><strong><em><a href="http://chrigas.blogspot.com/">http://chrigas.blogspot.com/</a></em></strong></p>
<p><em>For more information on sorting, see the <a href="http://code.msdn.microsoft.com/Sorting-a-WPF-ListView-by-5769086f">
second sample</a>, the <a href="http://code.msdn.microsoft.com/Sorting-a-WPF-ListView-by-ce9cf6d7">
third sample</a>, the <a href="http://code.msdn.microsoft.com/Sorting-a-WPF-ListView-by-cc714059">
fourth sample</a>, the <a href="http://code.msdn.microsoft.com/Sorting-a-WPF-ListView-by-922d983d">
fifth sample</a></em>, the <a href="https://code.msdn.microsoft.com/windowsdesktop/Sorting-a-WPF-ListView-by-a009edcb">
sixth sample</a>, the <a href="https://code.msdn.microsoft.com/Sorting-a-WPF-ListView-by-027e2303">
seventh sample</a>, and the <a href="https://code.msdn.microsoft.com/windowsdesktop/Sorting-a-WPF-ListView-by-7e9c5e4a">
eighth sample</a></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:1531px; width:1px; height:1px; overflow:hidden">
</div>
