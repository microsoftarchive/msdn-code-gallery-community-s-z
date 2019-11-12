# Simple UDP Listener
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Visual Basic .NET
## Topics
- threading
- DateTime
- backgroundworker
- UDP
## Updated
- 11/21/2013
## Description

<h1>Introduction</h1>
<p><em>Using Visual Basic to create a simple Windows Form Application, this sample opens UDP port and IP address and display.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Are there special requirements or instructions for building the sample?</em></p>
<p><em>Current version does not require any specific instruction, just download, and use Visual Studio to open it.</em></p>
<p><em>Personally, I wrote this in Visual Studio 2013</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This is sample of Window.Net.Socket, BackgroundWorker</em></p>
<h1>Using the code</h1>
<ol>
<li>Import Socket to enable UDP Client:<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System.Net&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.Sockets.aspx" target="_blank" title="Auto generated link to System.Net.Sockets">System.Net.Sockets</a></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</li><li>
<div class="endscriptcode">Import Thread and Component Model<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Imports&nbsp;System.Threading&nbsp;
Imports&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.ComponentModel.aspx" target="_blank" title="Auto generated link to System.ComponentModel">System.ComponentModel</a></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;</div>
</li><li>
<div class="endscriptcode">You can Drag and Drop BackgroundWork from Toolbox. Then go to Properties and set to TRUE these compenents:&nbsp;WorkerReportsProgress and&nbsp;WorkerSupportsCancellation.<br>
However, you can enable in source code:<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb">BackgroundWorker1.WorkerReportsProgress&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
BackgroundWorker1.WorkerSupportsCancellation&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;</div>
</li><li>
<div class="endscriptcode">To start a BackgroundWorker, use&nbsp;RunWorkerAsync<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;BackgroundWorker1.IsBusy&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundWorker1.RunWorkerAsync()&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;</div>
</li><li>
<div class="endscriptcode">Avoid to use another Threading, that can cause an error.</div>
</li><li>
<div class="endscriptcode">Create handle such as<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Private&nbsp;Sub&nbsp;BackgroundWorker1_DoWork(sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;e&nbsp;As&nbsp;DoWorkEventArgs)&nbsp;Handles&nbsp;BackgroundWorker1.DoWork</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;</div>
</li><li>
<div class="endscriptcode">To listen from UDP<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Dim</span>&nbsp;listener&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;UdpClient(listenPort)&nbsp;
<span class="visualBasic__keyword">Dim</span>&nbsp;groupEP&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;IPEndPoint(HostIP,&nbsp;listenPort)&nbsp;
&nbsp;
<span class="visualBasic__keyword">Dim</span>&nbsp;bytes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Byte</span>()&nbsp;=&nbsp;listener.Receive(groupEP)</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;</div>
</li><li>
<div class="endscriptcode">Report the progress<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Dim</span>&nbsp;worker&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;BackgroundWorker&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(sender,&nbsp;BackgroundWorker)&nbsp;
&nbsp;
worker.ReportProgress(<span class="visualBasic__number">0</span>,&nbsp;mystring)</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;</div>
</li><li>
<div class="endscriptcode">Update the progress<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Private&nbsp;Sub&nbsp;BackgroundWorker1_ProgressChanged(sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;e&nbsp;As&nbsp;ProgressChangedEventArgs)&nbsp;Handles&nbsp;BackgroundWorker1.ProgressChanged</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;</div>
</li><li>
<div class="endscriptcode">To stop the BackgroundWorker, use&nbsp;CancelAsync<br>
&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">BackgroundWorker1.CancelAsync()</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</li><li>
<div class="endscriptcode">And place the Cancelling flag in the DoWork<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">If</span>&nbsp;BackgroundWorker1.CancellationPending&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
<span class="visualBasic__com">'&nbsp;Do&nbsp;something&nbsp;before&nbsp;stopping&nbsp;the&nbsp;BackgroundWorker</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;</div>
</li></ol>
<ul>
</ul>
<h1>Using software</h1>
<ol>
<li>Open Execution file, leave the IP address if you use Broadcast IP </li><li>You must know and enter the correct UDP port that the source is sending </li><li>Click on Start to listen your UDP packet </li><li>Clock Stop to release UDP port </li></ol>
<h1>More Information</h1>
<p><em>For more information, please contact me.</em></p>
<p>&nbsp;</p>
<h1 id="6">Abuse</h1>
<div>
<h2 id="6.1">What is abuse?</h2>
<div class="answer">Anything that violates the&nbsp;<a href="http://msdn.microsoft.com/en-us/cc300389.aspx">MSDN Terms of Use</a>&nbsp;is considered abuse. This may include offensive language, copyright violations, and spam.</div>
</div>
<div>
<h2 id="6.0">How can I report abuse?</h2>
<div class="answer">Each sample project has a Report Abuse to Microsoft link. Once you click the report abuse link we ask you to provide us with a short description on why the sample should be removed.</div>
</div>
<p><em><br>
</em></p>
