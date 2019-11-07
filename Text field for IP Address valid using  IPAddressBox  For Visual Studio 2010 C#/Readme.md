# Text field for IP Address valid using  IPAddressBox  For Visual Studio 2010 C#
## Requires
- Visual Studio 2010
## License
- MIT
## Technologies
- Windows Forms
- TCP/IP
- MaskedTextBox
## Topics
- IP Address
## Updated
- 09/24/2015
## Description

<h1>Introduction</h1>
<p><em>MaskedTextBox For IP Address, an additional toolbox for IP Address filed. For programmers who need a Windows form that has filed vaidasi sangant IP Address toolbox to be used.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>private void button1_Click(object sender, EventArgs e)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; label4.Text = ipAddressControl1.IPAddress.ToString();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>nstallation Method:</p>
<ol>
<li>Inport MaskedTextBox IP Address into the Toolbox, </li><li>Select the tab Firemework .Net Components, </li><li>Inport IPAddressControl.dll (Click Browse .. get IPAddressControl.dll file) </li><li>.Net Framework ComponentsPada search tool toolbox IPAddressControl use this tool as the IP Address field.
</li></ol>
<p><em><img id="142912" src="142912-maskedtextbox_ip_address3.png" alt="" width="317" height="185">&nbsp;
<br>
</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void button1_Click(object sender, EventArgs e) 
  {            
     label4.Text = IpAddressControl1.IPAddress.ToString();        
  }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;
&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label4.Text&nbsp;=&nbsp;IpAddressControl1.IPAddress.ToString();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
</ul>
<p>&nbsp;[StructLayout(LayoutKind.Sequential)]<br>
&nbsp;&nbsp;&nbsp; public struct Nmhdr<br>
&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public IntPtr HWndFrom;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public UIntPtr IdFrom;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public int Code;<br>
&nbsp;&nbsp;&nbsp; }<br>
<br>
&nbsp;&nbsp;&nbsp; [StructLayout(LayoutKind.Sequential)]<br>
&nbsp;&nbsp;&nbsp; public struct NmIPAddress<br>
&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public Nmhdr Hdr;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public int Field;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public int Value;<br>
&nbsp;&nbsp;&nbsp; }<br>
<br>
&nbsp;&nbsp;&nbsp; [StructLayout(LayoutKind.Sequential)]<br>
&nbsp;&nbsp;&nbsp; public struct InitCommonControlsEX<br>
&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public int Size;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public int Icc;<br>
&nbsp;&nbsp;&nbsp; }<br>
<br>
&nbsp;&nbsp;&nbsp; public enum IPField<br>
&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OctetOne = 0,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OctetTwo = 1,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OctetThree = 2,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OctetFour = 3<br>
&nbsp;&nbsp;&nbsp; }</p>
<ul>
</ul>
<h1>More Information</h1>
<p><em><em>MaskedTextBox For IP Address, an additional toolbox for IP Address filed. For programmers who need a Windows form that has filed vaidasi sangant IP Address toolbox to be used.</em></em></p>
