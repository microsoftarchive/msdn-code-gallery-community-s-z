# Using Data Template Selector with WPF
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- Data Binding
- ValueConverters
- DataTemplates
- DataTemplateSelector
## Updated
- 10/26/2012
## Description

<h1>Introduction</h1>
<p><em>Have you ever had to put in the same list Persons &amp; Companies? If so, depends on the selected one, a different bunch of information has to be displayed. It's a kind of annoying to be done in the old Win Forms application, by controlling visible properties
 and so one. With WPF things has changed and it is easier then ever. Lets see it in practice.</em></p>
<p><em><img id="69321" src="69321-template_company.jpg" alt="" width="485" height="300"></em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Just download the example, build it and run.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>To achieve this object, I've used an Interface to sign Persons and Companies as Users from my system, so I've created the ISystemUser interface, with is implemented by the classes: Person and Enterprise. They shared the Name property but the other properties
 is implemented direct by Person and Enterprise individually, so Partners is a property that is held just by Enterprise.</em></p>
<p><em>In order to list all both, the constructor of my&nbsp;MVVW (Window1ViewModel) populates an IList&lt;ISystemUser&gt;, defining some people and some companies.</em></p>
<p><em>Once I have just one list, I binded it direct to my ListBox. In order to control the icon it generates I used an ValueConverter so if the implementation is a Person, it shows a Person. You can take a deep look at the class Class2IconConverter.</em></p>
<p><em>And just above the ListBox we have a ContentControl to show the detailed information about the selected item. Take a look at the XAML to see how this control is direct binded to the ListBox and in order to determine the template it will use, it takes
 advantage of ContentTemplateSelector, making the show happens.</em></p>
<p><em>&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">xaml</span>
<pre class="hidden">public class SystemUserTemplateSelection : DataTemplateSelector
{
    public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
    {
        DataTemplate dt = null;

        if (item is Person)
            dt = App.Current.MainWindow.FindResource(&quot;templatePerson&quot;) as DataTemplate;

        if (item is Enterprise)
            dt = App.Current.MainWindow.FindResource(&quot;templateCompany&quot;) as DataTemplate;

        return dt;
    }
}</pre>
<pre class="hidden">&lt;ListBox ItemsSource=&quot;{Binding Users}&quot; x:Name=&quot;myListBox&quot;&gt;
    &lt;ListBox.ItemTemplate&gt;
        &lt;DataTemplate&gt;
            &lt;Border Margin=&quot;5&quot; CornerRadius=&quot;5&quot; BorderThickness=&quot;1&quot; BorderBrush=&quot;Black&quot;&gt;
                &lt;Grid Width=&quot;80&quot;&gt;
                    &lt;Grid.RowDefinitions&gt;
                        &lt;RowDefinition Height=&quot;*&quot; /&gt;
                        &lt;RowDefinition Height=&quot;40&quot; /&gt;
                    &lt;/Grid.RowDefinitions&gt;
                    &lt;Image Source=&quot;{Binding ., Converter={StaticResource c2iConv}}&quot; /&gt;                            
                    &lt;TextBlock Grid.Row=&quot;1&quot; Margin=&quot;5&quot; Text=&quot;{Binding Name}&quot; TextWrapping=&quot;Wrap&quot; HorizontalAlignment=&quot;Center&quot; /&gt;
                &lt;/Grid&gt;
            &lt;/Border&gt;
        &lt;/DataTemplate&gt;
    &lt;/ListBox.ItemTemplate&gt;
    &lt;ListBox.ItemsPanel&gt;
        &lt;ItemsPanelTemplate&gt;
            &lt;StackPanel Orientation=&quot;Horizontal&quot; IsItemsHost=&quot;True&quot; /&gt;
        &lt;/ItemsPanelTemplate&gt;
    &lt;/ListBox.ItemsPanel&gt;
&lt;/ListBox&gt;

&lt;ContentControl Grid.Row=&quot;1&quot; Content=&quot;{Binding ElementName=myListBox, Path=SelectedItem}&quot; ContentTemplateSelector=&quot;{StaticResource systemUserTemplateSelector}&quot; /&gt;</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SystemUserTemplateSelection&nbsp;:&nbsp;DataTemplateSelector&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;System.Windows.DataTemplate&nbsp;SelectTemplate(<span class="cs__keyword">object</span>&nbsp;item,&nbsp;System.Windows.DependencyObject&nbsp;container)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataTemplate&nbsp;dt&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(item&nbsp;<span class="cs__keyword">is</span>&nbsp;Person)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt&nbsp;=&nbsp;App.Current.MainWindow.FindResource(<span class="cs__string">&quot;templatePerson&quot;</span>)&nbsp;<span class="cs__keyword">as</span>&nbsp;DataTemplate;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(item&nbsp;<span class="cs__keyword">is</span>&nbsp;Enterprise)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt&nbsp;=&nbsp;App.Current.MainWindow.FindResource(<span class="cs__string">&quot;templateCompany&quot;</span>)&nbsp;<span class="cs__keyword">as</span>&nbsp;DataTemplate;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;dt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
