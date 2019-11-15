# WPF busy indicator implementation with Singleton Pattern
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WPF
- Singleton Pattern
- WPF Extended Toolkit
## Topics
- Singleton Pattern
- WPF Busy Indicator
## Updated
- 07/13/2013
## Description

<p><strong>What is Singleton pattern ?</strong></p>
<p>&nbsp;</p>
<div>
<p><strong>Singleton pattern ensure that a class has only one instance</strong>&nbsp;and provide a global point of access to that instance. Normally singleton object store data which is common to for all over the application.</p>
</div>
<div>
<p>&nbsp;</p>
</div>
<div>
<p>Using this pattern now we are going to implement a busy indicator which is going to be a common for your whole WPF application.</p>
</div>
<div>
<p>&nbsp;</p>
</div>
<div>
<p>Before start the development we need to download &nbsp;Extended WPF Toolkit and latest Microsoft Prism library and extract those folders to your hard drive. Download links are &nbsp;:</p>
</div>
<div>
<p>&nbsp; &nbsp; &nbsp;&nbsp;<a href="http://wpftoolkit.codeplex.com/releases/view/99072">Download Extended WPF Toolkit</a></p>
</div>
<div>
<p>&nbsp; &nbsp; &nbsp;&nbsp;<a href="http://www.microsoft.com/en-sg/download/details.aspx?id=28950">Download PRISM</a></p>
</div>
<div>
<p>&nbsp;</p>
</div>
<div>
<p>1. Create new WPF project named &nbsp;by BusyIndicatorExample.</p>
</div>
<div>
<p>&nbsp;</p>
</div>
<div>
<p>2. R<span style="font-family:Arial,Tahoma,Helvetica,FreeSans,sans-serif">ight click on project reference and add the desktop version of &nbsp;&quot;</span><span style="font-family:Arial,Tahoma,Helvetica,FreeSans,sans-serif; font-size:x-small"><span>Microsoft.Practices.Prism.dll</span></span><span style="font-family:Arial,Tahoma,Helvetica,FreeSans,sans-serif">&quot;
 from extracted prism libraries.</span></p>
</div>
<div>
<p><span style="font-family:Arial,Tahoma,Helvetica,FreeSans,sans-serif"><br>
</span></p>
</div>
<p class="separator"><a href="http://2.bp.blogspot.com/-kdddISdU3RY/UeIcqY6zAdI/AAAAAAAAAoI/D8JPYJJSKiE/s1600/1.JPG"><img src="http://2.bp.blogspot.com/-kdddISdU3RY/UeIcqY6zAdI/AAAAAAAAAoI/D8JPYJJSKiE/s400/1.JPG" border="0" alt="" width="256" height="400"></a></p>
<p class="separator">3. Now we will implement the singleton class which going to be a data context for our WPF BusyIndictor controller. To do that right click on project &nbsp;and create new class called BusyIndicatorManager. Implement the class as bellow.</p>
<p class="separator">&nbsp;</p>
<p class="separator"><span style="color:#0000ff">using <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Practices.Prism.ViewModel.aspx" target="_blank" title="Auto generated link to Microsoft.Practices.Prism.ViewModel">Microsoft.Practices.Prism.ViewModel</a>;</span></p>
<p class="separator"><span style="color:#0000ff">using <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;</span></p>
<p class="separator"><span style="color:#0000ff">using <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;</span></p>
<p class="separator">&nbsp;</p>
<p class="separator"><span style="color:#0000ff">namespace BusyIndicatorExample</span></p>
<p class="separator"><span style="color:#0000ff">{</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; public class BusyIndicatorManager : NotificationObject</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; {</span></p>
<p class="separator">&nbsp; &nbsp; &nbsp; &nbsp;<span style="color:#274e13">&nbsp;#region Membervariables</span></p>
<p class="separator">&nbsp;</p>
<p class="separator">&nbsp; &nbsp; &nbsp; &nbsp;<span style="color:#0000ff">&nbsp;private Dictionary&lt;int, string&gt; busyParameters;</span></p>
<p class="separator">&nbsp;</p>
<p class="separator"><span style="color:#274e13">&nbsp; &nbsp; &nbsp; &nbsp; #endregion</span></p>
<p class="separator"><span style="color:#274e13"><br>
</span></p>
<p class="separator"><span style="color:#274e13">&nbsp; &nbsp; &nbsp; &nbsp; #region Constructor</span></p>
<p class="separator">&nbsp;</p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; private BusyIndicatorManager()</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; isBusy = false;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; message = string.Empty;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; busyParameters = new Dictionary&lt;int, string&gt;();</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator">&nbsp;</p>
<p class="separator"><span style="color:#274e13">&nbsp; &nbsp; &nbsp; &nbsp; #endregion</span></p>
<p class="separator"><span style="color:#274e13"><br>
</span></p>
<p class="separator"><span style="color:#274e13">&nbsp; &nbsp; &nbsp; &nbsp; #region Singleton Implementation</span></p>
<p class="separator">&nbsp;</p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; private static BusyIndicatorManager instance;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; private static object syncRoot = new object();</span></p>
<p class="separator"><span style="color:#0000ff"><br>
</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; public static BusyIndicatorManager Instance</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; get</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; lock (syncRoot)</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; if (instance == null)</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; instance = new BusyIndicatorManager();</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return instance;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator">&nbsp;</p>
<p class="separator"><span style="color:#274e13">&nbsp; &nbsp; &nbsp; &nbsp; #endregion</span></p>
<p class="separator"><span style="color:#274e13"><br>
</span></p>
<p class="separator"><span style="color:#274e13">&nbsp; &nbsp; &nbsp; &nbsp; #region Public Properties</span></p>
<p class="separator">&nbsp;</p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; private bool isBusy;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; public bool IsBusy</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; get { return isBusy; }</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; private set</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; isBusy = value;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; RaisePropertyChanged(&quot;IsBusy&quot;);</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator"><span style="color:#0000ff"><br>
</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; private string message;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; public string Message</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; get { return message; }</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; private set</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; message = value;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; RaisePropertyChanged(&quot;Message&quot;);</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator">&nbsp;</p>
<p class="separator"><span style="color:#274e13">&nbsp; &nbsp; &nbsp; &nbsp; #endregion</span></p>
<p class="separator"><span style="color:#274e13"><br>
</span></p>
<p class="separator"><span style="color:#274e13">&nbsp; &nbsp; &nbsp; &nbsp; #region Public Methods</span></p>
<p class="separator">&nbsp;</p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; public void ShowBusy(int id, string busyMessage)</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; if (!busyParameters.ContainsKey(id))</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; busyParameters.Add(id, busyMessage);</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; IsBusy = true;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Message = busyMessage;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; else</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; busyParameters[id] = busyMessage;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; IsBusy = true;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Message = busyMessage;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator"><span style="color:#0000ff"><br>
</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; public void CloseBusy(int id)</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; if (busyParameters.ContainsKey(id))</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; busyParameters.Remove(id);</span></p>
<p class="separator"><span style="color:#0000ff"><br>
</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; if (busyParameters.Count == 0)</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; IsBusy = false;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Message = string.Empty;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; else</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; IsBusy = true;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Message = busyParameters.Last().Value;</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; &nbsp; &nbsp; }</span></p>
<p class="separator">&nbsp;</p>
<p class="separator">&nbsp; &nbsp; &nbsp; &nbsp;<span style="color:#274e13">&nbsp;#endregion</span></p>
<p class="separator"><span style="color:#0000ff">&nbsp; &nbsp; }</span></p>
<p class="separator"><span style="color:#0000ff">}</span></p>
<p class="separator"><span style="color:#0000ff"><br>
</span></p>
<p class="separator">Above this singleton implementation you can see that there are two public properties called<strong>&nbsp;IsBusy</strong>&nbsp;and&nbsp;<strong>Message ,&nbsp;</strong>So they are the going to be bind with WPF busy indicator control. Also
 you can call&nbsp;<strong>ShowBusy</strong>&nbsp;and&nbsp;<strong>CloseBusy</strong>&nbsp;methods from anywhere in you application using singleton instance.</p>
<p class="separator">&nbsp;</p>
<p class="separator">4. Now we will implement the our view for busy indicator. First add &quot;Xceed.Wpf.Toolkit.dll&quot; file as a reference from extracted&nbsp;<span>Extended WPF Toolkit&nbsp;</span>folder.</p>
<p class="separator">&nbsp;</p>
<p class="separator"><a href="http://2.bp.blogspot.com/-PCKrvrZzEaM/UeInaQIPieI/AAAAAAAAAoY/SD2ZW_8B88w/s1600/2.JPG"><img src="http://2.bp.blogspot.com/-PCKrvrZzEaM/UeInaQIPieI/AAAAAAAAAoY/SD2ZW_8B88w/s400/2.JPG" border="0" alt="" width="232" height="400"></a></p>
<p class="separator">&nbsp;</p>
<p class="separator">5. Now we will implement our MainPage.xaml view as bellow.</p>
<p class="separator">&nbsp;</p>
<p class="separator"><span style="color:#ff0000">&lt;Window x:Class=</span><span style="color:#0000ff">&quot;BusyIndicatorExample.MainWindow&quot;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; xmlns=</span><span style="color:#0000ff">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; xmlns:x=</span><span style="color:#0000ff">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; xmlns:xctk=</span><span style="color:#0000ff">&quot;http://schemas.xceed.com/wpf/xaml/toolkit&quot;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; Title=</span><span style="color:#00ffff">&quot;MainWindow&quot;</span><span style="color:#ff0000">&nbsp;Height=</span><span style="color:#0000ff">&quot;350&quot;</span><span style="color:#ff0000">&nbsp;Width=</span><span style="color:#0000ff">&quot;525&quot;</span><span style="color:#ff0000">&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &lt;Grid&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; &lt;Grid.RowDefinitions&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;RowDefinition Height=</span><span style="color:#0000ff">&quot;40&quot;</span><span style="color:#ff0000">/&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;RowDefinition Height=</span><span style="color:#0000ff">&quot;*&quot;</span><span style="color:#ff0000">/&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; &lt;/Grid.RowDefinitions&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; &lt;StackPanel Orientation=</span><span style="color:#0000ff">&quot;Horizontal&quot;</span><span style="color:#ff0000">&nbsp;HorizontalAlignment=</span><span style="color:#0000ff">&quot;Center&quot;</span><span style="color:#ff0000">&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Button Name=</span><span style="color:#0000ff">&quot;btnRunBusy&quot;</span><span style="color:#ff0000">&nbsp;Height=</span><span style="color:#0000ff">&quot;30&quot;</span><span style="color:#ff0000">&nbsp;Width=</span><span style="color:#0000ff">&quot;150&quot;</span><span style="color:#ff0000">&nbsp;Content=</span><span style="color:#0000ff">&quot;Run
 BusyIndicator&quot;</span><span style="color:#ff0000">&nbsp;Click=</span><span style="color:#0000ff">&quot;btnRunBusy_Click&quot;</span><span style="color:#ff0000">&nbsp;Margin=</span><span style="color:#0000ff">&quot;0,0,10,0&quot;</span><span style="color:#ff0000">/&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Button Name=</span><span style="color:#0000ff">&quot;btnCloseBusy&quot;</span><span style="color:#ff0000">&nbsp;Height=</span><span style="color:#0000ff">&quot;30&quot;</span><span style="color:#ff0000">&nbsp;Width=</span><span style="color:#0000ff">&quot;150&quot;</span><span style="color:#ff0000">&nbsp;Content=</span><span style="color:#0000ff">&quot;Close
 BusyIndicator&quot;&nbsp;</span><span style="color:#ff0000">Click=</span><span style="color:#0000ff">&quot;btnCloseBusy_Click&quot;</span><span style="color:#ff0000">/&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; &lt;/StackPanel&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; &lt;xctk:BusyIndicator Grid.Row=</span><span style="color:#0000ff">&quot;1&quot;</span><span style="color:#ff0000">&nbsp;Name=</span><span style="color:#0000ff">&quot;busyIndicator&quot;</span><span style="color:#ff0000">&nbsp;IsBusy=</span><span style="color:#0000ff">&quot;{</span><span style="color:#e06666">Binding</span><span style="color:#0000ff">&nbsp;</span><span style="color:#cc0000">IsBusy</span><span style="color:#0000ff">}&quot;</span><span style="color:#ff0000">&nbsp;BusyContent=</span><span style="color:#0000ff">&quot;{</span><span style="color:#e06666">Binding</span><span style="color:#0000ff">&nbsp;</span><span style="color:#cc0000">Message</span><span style="color:#0000ff">}&quot;</span><span style="color:#ff0000">&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Grid&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span></p>
<p class="separator"><span style="color:#ff0000"><br>
</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/Grid&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &nbsp; &nbsp; &lt;/xctk:BusyIndicator&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&nbsp; &nbsp; &lt;/Grid&gt;</span></p>
<p class="separator"><span style="color:#ff0000">&lt;/Window&gt;</span></p>
<p class="separator"><span style="color:#ff0000"><br>
</span></p>
<p class="separator">6. Now go to&nbsp;MainWindow.xaml.cs and modify the class implementation as bellow.</p>
<div>
<p>&nbsp;</p>
</div>
<div>
<p class="separator"><a href="http://1.bp.blogspot.com/-uNs7PU2qZeM/UeIuVuncXFI/AAAAAAAAAoo/WBd8HpCN0QQ/s1600/3.JPG"><img src="http://1.bp.blogspot.com/-uNs7PU2qZeM/UeIuVuncXFI/AAAAAAAAAoo/WBd8HpCN0QQ/s640/3.JPG" border="0" alt="" width="640" height="480"></a></p>
<p><span style="font-family:Arial,Tahoma,Helvetica,FreeSans,sans-serif; font-size:x-small"><span>In class constructor we assign busy indicator DataContext as singleton instance of BusyIndicatorManager.&nbsp;</span></span></p>
<p><span style="font-family:Arial,Tahoma,Helvetica,FreeSans,sans-serif; font-size:x-small"><span><br>
</span></span><span style="font-family:Arial,Tahoma,Helvetica,FreeSans,sans-serif; font-size:x-small"><span>7. Now Run the application and click on Run BusyIndicator button and then busy indicator will visible in our application.</span></span></p>
<p><span style="font-family:Arial,Tahoma,Helvetica,FreeSans,sans-serif; font-size:x-small"><span><br>
</span></span></p>
<p class="separator"><a href="http://1.bp.blogspot.com/-GwWppQARhXI/UeIvR9nqCKI/AAAAAAAAAo0/4IRCmPgEadU/s1600/4.JPG"><img src="http://1.bp.blogspot.com/-GwWppQARhXI/UeIvR9nqCKI/AAAAAAAAAo0/4IRCmPgEadU/s400/4.JPG" border="0" alt="" width="400" height="266"></a></p>
<p class="separator">&nbsp;</p>
<p class="separator">Here we call the ShowBusy method which is implemented in BusyIndicatorManager class, using it's singleton instance. Inside the method we will set IsBusy property into true and Message property with message which are &nbsp;bind to the
 BusyIndicator controller in our MainPage.xaml.</p>
<p class="separator">&nbsp;</p>
<p class="separator">8. Now click on the &quot;Close BusyIndicator&quot; button and then running &nbsp;busy indicator will disappear from the application. Because here we call the CloseBusy method which is implemented in BusyIndicatorManager class using it's singleton
 instance and Inside the method we set IsBusy property into &quot;False&quot;.</p>
<p class="separator">&nbsp;</p>
<p class="separator"><a href="https://docs.google.com/file/d/0B9Jqgbgv4v5LbjJMd3NBNXpqenc/edit?usp=sharing">Download Source Code.</a></p>
<p class="separator">&nbsp;</p>
<p class="separator">Happy Coding!!!!!!!!!!!!!!!!!!!</p>
</div>
