# Zipping and Unzipping files in .NET application
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- .NET
- zip
## Topics
- extract zip
- Compression
## Updated
- 06/24/2014
## Description

<h1>Introduction</h1>
<p>This example demonstrates how to Zip and Unzip multiple files with wildcard masks.<em><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p>In order to build the sample project, you need the commercial <a href="http://www.componentpro.com/zip.net/">
Ultimate ZIP</a> component which can be downloaded at <a href="http://www.componentpro.com/download/?name=UltimateZip">
Ultimate ZIP Download Page</a>.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The example demonstrates how to:</p>
<ul>
<li>Open an archive </li><li>List items within the archive </li><li>Extract files within the archive to local disk </li><li>Add files from the local disk to the archive </li><li>Save file as ZIP, ZIPX, GZip, Tar and TGZ </li><li>Create Self-extracting archive </li><li>Change encryption algorithm: AES128, AES192, AES256, and PKZip. </li></ul>
<p>It also demonstrates how to test an archive, add/extract files from/to another archive.
<a href="http://www.componentpro.com/doc/zip/ComponentPro.Compression.Zip.htm">Zip</a>,
<a href="http://www.componentpro.com/doc/zip/ComponentPro.Compression.Tar.htm">Tar</a>,
<a href="http://www.componentpro.com/doc/zip/ComponentPro.Compression.Tgz.htm">Tgz</a>,
<a href="http://www.componentpro.com/doc/zip/ComponentPro.Compression.Gzip.htm">Gzip</a> and
<a href="http://www.componentpro.com/doc/zip/ComponentPro.Compression.RealTimeZip.htm">
RealTimeZip</a> classes&nbsp;inherit from&nbsp;the <a href="http://www.componentpro.com/doc/zip/ComponentPro.IO.FileSystem.htm">
FileSystem</a> class which is very powerful and convenient for transferring files and folders.</p>
<p>UltimateZip supports AES encryption in two different strengths: 128-bit AES and 256-bit AES. These numbers refer to the size of the encryption keys that are used to encrypt the data. 256-bit AES is stronger than 128-bit AES, but both of them can provide
 significantly greater security than the standard Zip 3.0 method described below. An advantage of 128-bit AES is that it is slightly faster than 256-bit AES, that is, it takes less time to encrypt or decrypt a file.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;ComponentPro.Compression;&nbsp;
&nbsp;
...&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Create&nbsp;a&nbsp;new&nbsp;instance&nbsp;of&nbsp;the&nbsp;Zip&nbsp;class.</span>&nbsp;
Zip&nbsp;zip&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Zip();&nbsp;
<span class="cs__com">//&nbsp;Create&nbsp;a&nbsp;new&nbsp;zip&nbsp;file.</span>&nbsp;
zip.Create(<span class="cs__string">&quot;test.zip&quot;</span>);&nbsp;
<span class="cs__com">//&nbsp;Set&nbsp;encryption&nbsp;algorithm&nbsp;and&nbsp;password.</span>&nbsp;
zip.EncryptionAlgorithm&nbsp;=&nbsp;EncryptionAlgorithm.Aes256;&nbsp;
zip.Password&nbsp;=&nbsp;<span class="cs__string">&quot;abcabc&quot;</span>;&nbsp;
<span class="cs__com">//&nbsp;Add&nbsp;a&nbsp;file&nbsp;to&nbsp;the&nbsp;archive.&nbsp;The&nbsp;file&nbsp;will&nbsp;be&nbsp;protected&nbsp;with&nbsp;the&nbsp;specified&nbsp;password.</span>&nbsp;
zip.AddFile(<span class="cs__string">&quot;Test.txt&quot;</span>);&nbsp;
<span class="cs__com">//&nbsp;Close&nbsp;the&nbsp;zip&nbsp;file.</span>&nbsp;
zip.Close();</pre>
</div>
</div>
</div>
<ul>
</ul>
<h1>More Information</h1>
<p>For more information on Ultimate ZIP, please see the following resources:</p>
<ul>
<li><a href="http://www.componentpro.com/doc/zip/">Ultimate ZIP Documentation</a>
</li><li><a href="http://zipcomponent.net/">ZIP Blog</a> </li></ul>
