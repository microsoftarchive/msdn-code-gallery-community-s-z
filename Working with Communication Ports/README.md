# Working with Communication Ports
## Requires
- Visual Studio 2010
## License
- Custom
## Technologies
- Windows Forms
## Topics
- Interop
- threading
- Communication Ports
## Updated
- 06/22/2011
## Description

<h1>Introduction</h1>
<p><span id="ctl00_ctl00_Content_TabContentPanel_Content_wikiSourceLabel">Demonstrates how to control a communications (COM) port.</span></p>
<h1 class="heading"><span>Requirements</span></h1>
<div class="section" id="requirementsTitleSection">
<p>This application requires a modem installed on one of the COM ports.</p>
</div>
<h1><span>Building the Sample</span></h1>
<p>Press F5</p>
<h1>Description</h1>
<ul>
<li>
<p>How to determine which COM ports are available.</p>
</li><li>
<p>How to use a COM port to communicate with a modem.</p>
</li><li>
<p>How to use Win32 API calls to control communication with the COM port.</p>
</li></ul>
<h1>Screenshot</h1>
<p><img src="http://i1.code.msdn.s-msft.com/working-with-communication-7341881c/image/file/23083/1/screenshot.png" alt=""></p>
<h1>Sample Code<em><br>
</em></h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;IsPortAvailable(<span class="visualBasic__keyword">ByVal</span>&nbsp;ComPort&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CommPort.Open(ComPort,&nbsp;<span class="visualBasic__number">115200</span>,&nbsp;<span class="visualBasic__number">8</span>,&nbsp;RS232.DataParity.Parity_None,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RS232.DataStopBit.StopBit_1,&nbsp;<span class="visualBasic__number">4096</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;If&nbsp;it&nbsp;makes&nbsp;it&nbsp;to&nbsp;here,&nbsp;then&nbsp;the&nbsp;Comm&nbsp;Port&nbsp;is&nbsp;available.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CommPort.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;If&nbsp;it&nbsp;gets&nbsp;here,&nbsp;then&nbsp;the&nbsp;attempt&nbsp;to&nbsp;open&nbsp;the&nbsp;Comm&nbsp;Port</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;was&nbsp;unsuccessful.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><a class="browseFile" href="sourcecode?fileId=23081&pathId=1179583985">MainForm.Designer.vb</a>
</li><li><a class="browseFile" href="sourcecode?fileId=23081&pathId=788199196">MainForm.vb</a>
</li><li><a class="browseFile" href="sourcecode?fileId=23081&pathId=140506884">Rs232.vb</a>
</li></ul>
<h1>More Information</h1>
<p>For more information, see -</p>
<ul>
<li>How to: Dial Modems Attached to Serial Ports in Visual Basic: <a href="http://msdn.microsoft.com/en-us/library/7x7cdt5c.aspx" target="_blank">
http://msdn.microsoft.com/en-us/library/7x7cdt5c.aspx</a> </li><li>Accessing the Computer's Ports (Visual Basic): <a href="http://msdn.microsoft.com/en-us/library/1t0558fe.aspx" target="_blank">
http://msdn.microsoft.com/en-us/library/1t0558fe.aspx</a> </li></ul>
