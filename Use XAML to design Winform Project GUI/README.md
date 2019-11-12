# Use XAML to design Winform Project GUI
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- XAML
## Topics
- Windows Forms
- XAML
- Windows Forms Design
## Updated
- 09/12/2011
## Description

<p><img src="42398-untitled.png" alt=""></p>
<p>&nbsp;</p>
<p>Like the above screenshot, we can use XAML code to design the Winform Form, same as Silverlight Page&nbsp;and WPF Window.</p>
<p>Ok, this sample <span style="color:black; font-family:">introduces </span>how to use XAML code to design the Winform Forms.</p>
<p>We know, XAML code is used to map the CLR objects in the XML format code. So it can be used in all .Net projects to serialize the CLR objects, and deserialize the XAML to CLR objects. For WPF and Silverlight, Visual Studio IDE has the designer surppots them
 to show the content of the XAML real-time. But the XAML is not limited in designing the SL and WPF content. We can use it to design the Windows Forms project forms. Just deserialize the classes in the namespace
<a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.aspx" target="_blank">
System.Windows.Forms</a>.</p>
<h1>Steps:</h1>
<ul>
<li>Create an empty .Net solution, add the references to project:
<ul>
<li>PresentationCore </li><li>PresentationFramework </li><li><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a> </li><li><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Xaml.aspx" target="_blank" title="Auto generated link to System.Xaml">System.Xaml</a> </li><li><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Xml.aspx" target="_blank" title="Auto generated link to System.Xml">System.Xml</a> </li><li>WindowsBase </li></ul>
</li><li>Add an XAML file in the project, named &quot;Winform.xaml&quot;, a &quot;App.cs&quot; file and a &quot;Winform.cs&quot;. The first one is the Winform XAML code file, the second is the application class, and the last one is the partial class of the Winform class. Change the output type
 of the project properties&nbsp;to <strong>Windows Applciation.</strong> </li><li>Code your Application class as: </li></ul>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">namespace&nbsp;XAMLForWinform&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;static&nbsp;class&nbsp;App&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[STAThread]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;Main()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.EnableVisualStyles();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.SetCompatibleTextRenderingDefault(false);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Winform&nbsp;form&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Winform();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.Run(form);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<ul>
<li>Add the XML namespace mapping in the XAML file, map the <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a> namespace into the XAML:
<span style="color:red">xmlns</span><span style="color:blue">=</span><span style="color:blue">&quot;clr-namespace:<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>;assembly=System.Windows.Forms&quot;</span> design the Winform Form XAML as:
</li></ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Form&nbsp;x:Class=<span class="js__string">&quot;XAMLForWinform.Winform&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns=<span class="js__string">&quot;clr-namespace:<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>;assembly=System.Windows.Forms&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns:x=<span class="js__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaximizeBox=<span class="js__string">&quot;False&quot;</span>&nbsp;MinimizeBox=<span class="js__string">&quot;False&quot;</span>&nbsp;Text=<span class="js__string">&quot;A&nbsp;Form&quot;</span>&nbsp;Width=<span class="js__string">&quot;300&quot;</span>&nbsp;Height=<span class="js__string">&quot;150&quot;</span>&nbsp;BackColor=<span class="js__string">&quot;AliceBlue&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Form.Controls&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GroupBox&nbsp;x:Name=<span class="js__string">&quot;ctlGroupBox&quot;</span>&nbsp;Text=<span class="js__string">&quot;My&nbsp;Winform&nbsp;Application&quot;</span>&nbsp;Dock=<span class="js__string">&quot;Fill&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;GroupBox.Controls&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Label&nbsp;x:Name=<span class="js__string">&quot;ctlLabel&quot;</span>&nbsp;AutoSize=<span class="js__string">&quot;True&quot;</span>&nbsp;Text=<span class="js__string">&quot;Message:&quot;</span>&nbsp;Location=<span class="js__string">&quot;12,&nbsp;31&quot;</span>&nbsp;Size=<span class="js__string">&quot;36,&nbsp;13&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Button&nbsp;x:Name=<span class="js__string">&quot;ctlButton&quot;</span>&nbsp;Text=<span class="js__string">&quot;Show&nbsp;Message&quot;</span>&nbsp;UseVisualStyleBackColor=<span class="js__string">&quot;True&quot;</span>&nbsp;Location=<span class="js__string">&quot;179,&nbsp;54&quot;</span>&nbsp;Size=<span class="js__string">&quot;93,&nbsp;23&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Click=<span class="js__string">&quot;Button_Click&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBox&nbsp;x:Name=<span class="js__string">&quot;ctlTextBox&quot;</span>&nbsp;Location=<span class="js__string">&quot;70,&nbsp;28&quot;</span>&nbsp;Size=<span class="js__string">&quot;200,&nbsp;20&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/GroupBox.Controls&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/GroupBox&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Form.Controls&gt;&nbsp;
&lt;/Form&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">We know, the x:Class was used to specified the&nbsp;behind&nbsp;class. And VS will generate the hide for this XAML and the&nbsp;behind class. Please check it in the &quot;obj/&quot; folder. Such as my sample, VS generate the &quot;obj\x86\Debug\Winform.g.cs&quot;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">......&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Diagnostics.DebuggerNonUserCodeAttribute.aspx" target="_blank" title="Auto generated link to System.Diagnostics.DebuggerNonUserCodeAttribute">System.Diagnostics.DebuggerNonUserCodeAttribute</a>()]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;InitializeComponent()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(_contentLoaded)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contentLoaded&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Uri&nbsp;resourceLocater&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Uri.aspx" target="_blank" title="Auto generated link to System.Uri">System.Uri</a>(<span class="js__string">&quot;/XAMLForWinform;component/winform.xaml&quot;</span>,&nbsp;System.UriKind.Relative);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#line&nbsp;<span class="js__num">1</span>&nbsp;<span class="js__string">&quot;..\..\..\Winform.xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Application.LoadComponent.aspx" target="_blank" title="Auto generated link to System.Windows.Application.LoadComponent">System.Windows.Application.LoadComponent</a>(<span class="js__operator">this</span>,&nbsp;resourceLocater);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#line&nbsp;<span class="js__statement">default</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#line&nbsp;hidden&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
......</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"></div>
<ul>
<li>
<div class="endscriptcode">&nbsp;You will find, we could specify the event handler in the XAML for Winform Controls&nbsp;also, and use the x:Name as the control name in XAML, same with it in the WPF/SL designer. So please add the event handler in the partial
 class:</div>
</li></ul>
<p class="endscriptcode"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;Button_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(ctlTextBox.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<h1 class="endscriptcode">Comment</h1>
<p class="endscriptcode">XAML code for Winform project is not recommend, since VS does not implement its designer, and it is hard to control the position, size of the control in the form. Hope there is a good designer for this scenario in the future.</p>
