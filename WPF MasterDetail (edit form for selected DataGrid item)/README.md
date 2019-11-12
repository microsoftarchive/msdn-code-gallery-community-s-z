# WPF Master/Detail (edit form for selected DataGrid item)
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- DataGrid
- WPF
- WPF Basics
- WPF Data Binding
- Master/Detail
- Dependency Properties
## Updated
- 09/19/2012
## Description

<h1>Introduction</h1>
<p>This sample is just to demonstrate the basic concepts and wiring involved in a simple master/detail scenario, where you want to show an edit form for the currently selected item in a DataGrid.</p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p>Just download, unzip, open and run!</p>
<p>&nbsp;</p>
<h2><span style="font-size:20px">Description</span></h2>
<p>This sample shows how little code is needed to build a user interface, and bind to a collection of data.</p>
<p>In this example, the data is created as a collection in code and the DataContext of the page is itself, which exposes the property to direct binding, for the DataGrid ItemsSource.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;MyCollection&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;Person&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;Person&nbsp;<span class="js__brace">{</span>&nbsp;FirstName&nbsp;=&nbsp;<span class="js__string">&quot;Fred&quot;</span>,&nbsp;LastName=<span class="js__string">&quot;Smith&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;Person&nbsp;<span class="js__brace">{</span>&nbsp;FirstName&nbsp;=&nbsp;<span class="js__string">&quot;Tom&quot;</span>,&nbsp;LastName=<span class="js__string">&quot;Jones&quot;</span>&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DataContext&nbsp;=&nbsp;<span class="js__operator">this</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">In this sample, the Person class inherits from DependencyObject and exposes DependencyProperties, but it could just as easily implement INotifyPropertyChanged.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">The DataGrid binds two custom DataGridTextColumns to the class to display the data.</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataGrid&nbsp;x:Name=<span class="js__string">&quot;dataGrid&quot;</span>&nbsp;HorizontalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;VerticalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;ItemsSource=<span class="js__string">&quot;{Binding&nbsp;MyCollection}&quot;</span>&nbsp;AutoGenerateColumns=<span class="js__string">&quot;False&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataGrid.Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataGridTextColumn&nbsp;Header=<span class="js__string">&quot;First&nbsp;Name&quot;</span>&nbsp;Binding=<span class="js__string">&quot;{Binding&nbsp;FirstName}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataGridTextColumn&nbsp;Header=<span class="js__string">&quot;Last&nbsp;Name&quot;</span>&nbsp;Binding=<span class="js__string">&quot;{Binding&nbsp;LastName}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DataGrid.Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DataGrid&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode">You can actually click again on the DataGrid cell and enter editing mode, and chaneg the values directly, but&nbsp;you may often&nbsp;prefer more control, with your own details form.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">The details form, has it's DataContext&nbsp;bound to the SelectedItem of the DataGrid. The Selected item is the specific Person Class&nbsp;that we want to edit.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&nbsp;Margin=<span class="js__string">&quot;10&quot;</span>&nbsp;DataContext=<span class="js__string">&quot;{Binding&nbsp;SelectedItem,&nbsp;ElementName=dataGrid}&quot;</span>&nbsp;&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
The details form uses TextBoxes, which by default are two-way. We have also added UpdateSourceTrigger=PropertyChanged, so changes are instantly reflected back in the DataGrid.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBox&nbsp;Grid.Column=<span class="js__string">&quot;1&quot;</span>&nbsp;HorizontalAlignment=<span class="js__string">&quot;Left&quot;</span>&nbsp;TextWrapping=<span class="js__string">&quot;Wrap&quot;</span>&nbsp;Text=<span class="js__string">&quot;{Binding&nbsp;FirstName,&nbsp;UpdateSourceTrigger=PropertyChanged}&quot;</span>&nbsp;VerticalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;MinWidth=<span class="js__string">&quot;100&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBox&nbsp;Grid.Column=<span class="js__string">&quot;1&quot;</span>&nbsp;HorizontalAlignment=<span class="js__string">&quot;Left&quot;</span>&nbsp;TextWrapping=<span class="js__string">&quot;Wrap&quot;</span>&nbsp;Text=<span class="js__string">&quot;{Binding&nbsp;LastName,&nbsp;UpdateSourceTrigger=PropertyChanged}&quot;</span>&nbsp;VerticalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;Grid.Row=<span class="js__string">&quot;1&quot;</span>&nbsp;MinWidth=<span class="js__string">&quot;100&quot;</span>/&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainWindow.xaml - Startup window</em> </li><li><em>MainWindow.xaml.cs - Where the collection resides</em> </li><li><em>Person.cs - the person class</em> </li></ul>
<p>&nbsp;</p>
<p><em><span style="font-size:xx-small">This project was created as demonstration to answer to a
<a href="http://social.msdn.microsoft.com/Forums/en/wpf/thread/ac407d82-088a-4315-9d7e-9c1ba990968e">
forum question</a>.</span></em></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img src="-anithanks1.gif" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
