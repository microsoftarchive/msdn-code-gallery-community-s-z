# SIDCloner - add sIDHistory from PowerShell
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Active Directory
## Topics
- Security
## Updated
- 12/06/2014
## Description

<p>This&nbsp;sample is managed class library that implements single class: SIDCloner. It is built around native API and allows to migrate SID history.</p>
<p>Sample is standalone; ADMT is not required to be installed. So as to migrate SID history, certain prerequisites must be met - see
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms677982(v=vs.85).aspx">
http://msdn.microsoft.com/en-us/library/windows/desktop/ms677982(v=vs.85).aspx</a>&nbsp;for details.</p>
<p>Sample makes use of DsAddSidHistory function (for details, see <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms675918(v=vs.85).aspx">
http://msdn.microsoft.com/en-us/library/windows/desktop/ms675918(v=vs.85).aspx</a>) and demonstrates the following:</p>
<ul>
<li>how to create necessary structures so as to successfully call DsAddSidHistory()
</li><li>how to get password from SecureString </li></ul>
<p>Class library is ready to use in PowerShell or in any .NET application. Code sample below demostrates how to use it in own script.</p>
<p>UPDATE 6/12/2014</p>
<ul>
<li>Attached compiled binaries to this article (VS2012, .NET Framework 4.5) </li></ul>
<p>UPDATE 8/9/2013: v1.0.2</p>
<ul>
<li>Added&nbsp;CloneSid()&nbsp;overload that allows specify source and target&nbsp;DCs without specifying source and target credentials
</li></ul>
<p>---</p>
<p>PowerShell sample below is modified&nbsp;real-life script that migrated SID history for 10K users in one session. It demonstrates various methods provided by SIDCloner class. Format of input CSV file is shown in identities.csv - see source code attached
 to this article.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PowerShell</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">powershell</span>

<div class="preview">
<pre class="powershell"><span class="powerShell__keyword">param</span>(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[parameter(Mandatory&nbsp;=&nbsp;<span class="powerShell__variable">$false</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[String]<span class="powerShell__variable">$inFile</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="powerShell__variable">$errorPreference</span>=<span class="powerShell__string">'Continue'</span>&nbsp;
&nbsp;
<span class="powerShell__com">#constants</span>&nbsp;
<span class="powerShell__variable">$targetDomain</span>=<span class="powerShell__string">&quot;target.test.cz&quot;</span>&nbsp;
&nbsp;
<span class="powerShell__variable">$cwd</span>=(<span class="powerShell__cmdlets">Get-Item</span>&nbsp;.).FullName&nbsp;
[<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Reflection.Assembly.aspx" target="_blank" title="Auto generated link to System.Reflection.Assembly">System.Reflection.Assembly</a>]::LoadFile(<span class="powerShell__string">&quot;$cwd\SIDCloner.dll&quot;</span>)&nbsp;<span class="powerShell__operator">|</span>&nbsp;<span class="powerShell__cmdlets">Out-Null</span>&nbsp;
&nbsp;
<span class="powerShell__com">#process&nbsp;parameters</span>&nbsp;
<span class="powerShell__com">#customize&nbsp;file/folder&nbsp;names</span>&nbsp;
<span class="powerShell__keyword">if</span>([String]::IsNullOrEmpty(<span class="powerShell__variable">$inFile</span>))&nbsp;{&nbsp;<span class="powerShell__variable">$inFile</span>&nbsp;=&nbsp;<span class="powerShell__string">&quot;.\Data\identities.csv&quot;</span>&nbsp;}&nbsp;
&nbsp;
<span class="powerShell__com">#clear&nbsp;the&nbsp;log&nbsp;file</span>&nbsp;
<span class="powerShell__keyword">if</span>([<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.File.aspx" target="_blank" title="Auto generated link to System.IO.File">System.IO.File</a>]::Exists(<span class="powerShell__string">&quot;.\Log\CloneFailed.csv&quot;</span>))&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__cmdlets">Remove-Item</span>&nbsp;<span class="powerShell__operator">-</span>path&nbsp;<span class="powerShell__string">&quot;.\Log\CloneFailed.csv&quot;</span>&nbsp;
}&nbsp;
<span class="powerShell__variable">$data</span>=<span class="powerShell__cmdlets">import-csv</span>&nbsp;<span class="powerShell__variable">$inFile</span>&nbsp;
&nbsp;
<span class="powerShell__com">##&nbsp;authenticate&nbsp;using&nbsp;implicit&nbsp;credentials</span>&nbsp;
<span class="powerShell__variable">$i</span>=<span class="powerShell__operator">-</span>1&nbsp;
<span class="powerShell__keyword">foreach</span>(<span class="powerShell__variable">$record</span>&nbsp;<span class="powerShell__keyword">in</span>&nbsp;<span class="powerShell__variable">$data</span>)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__keyword">try</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$i</span><span class="powerShell__operator">&#43;</span><span class="powerShell__operator">&#43;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$percentComplete</span>=[<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Convert.aspx" target="_blank" title="Auto generated link to System.Convert">System.Convert</a>]::ToInt32(<span class="powerShell__variable">$i</span><span class="powerShell__operator">/</span>(<span class="powerShell__variable">$data</span>.count)<span class="powerShell__operator">*</span>100)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__cmdlets">Write-Progress</span>&nbsp;<span class="powerShell__operator">-</span>Activity&nbsp;<span class="powerShell__string">&quot;Cloning&nbsp;users&quot;</span>&nbsp;<span class="powerShell__operator">-</span>PercentComplete&nbsp;<span class="powerShell__variable">$percentComplete</span>&nbsp;<span class="powerShell__operator">-</span>CurrentOperation&nbsp;<span class="powerShell__string">&quot;Processing&nbsp;user:&nbsp;$($record.sourceDomain)\$($record.sourceSAMAccountName)&quot;</span>&nbsp;<span class="powerShell__operator">-</span>Status&nbsp;<span class="powerShell__string">&quot;Completed:&nbsp;$percentComplete`%&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__com">#uses&nbsp;credentials&nbsp;of&nbsp;logged-on&nbsp;user&nbsp;(or&nbsp;credentials&nbsp;stored&nbsp;in&nbsp;Credentials&nbsp;Manager);&nbsp;works&nbsp;against&nbsp;PDC&nbsp;in&nbsp;both&nbsp;domains</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[wintools.sidcloner]::CloneSid(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$record</span>.sourceSAMAccountName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$record</span>.sourceDomain,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$record</span>.targetSAMAccountName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$targetDomain</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write<span class="powerShell__operator">-</span>Host&nbsp;<span class="powerShell__string">&quot;Account&nbsp;$($record.sourceDomain)\$($record.sourceSAMAccountName)&nbsp;cloned&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__keyword">catch</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__cmdlets">Write-Warning</span>&nbsp;<span class="powerShell__operator">-</span>message:<span class="powerShell__string">&quot;Account&nbsp;$($record.sourceDomain)\$($record.sourceSAMAccountName)&nbsp;failed&nbsp;to&nbsp;clone`n`tError:$($($_.Exception).Message)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__string">&quot;$($record.sourceSAMAccountName),$($record.sourceDomain),$($record.targetSAMAccountName)&quot;</span>&nbsp;&gt;&gt;&nbsp;<span class="powerShell__string">&quot;.\Log\CloneFailed.csv&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="powerShell__com">#explicit&nbsp;DC&nbsp;and&nbsp;credentials&nbsp;for&nbsp;source&nbsp;domain</span>&nbsp;
<span class="powerShell__variable">$sourceCredential</span>=<span class="powerShell__cmdlets">Get-Credential</span>&nbsp;
<span class="powerShell__variable">$sourceDC</span>=Get<span class="powerShell__operator">-</span>DC&nbsp;<span class="powerShell__operator">-</span>domain:<span class="powerShell__variable">$record</span>.sourceDomain&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__com">#not&nbsp;implemented&nbsp;here</span>&nbsp;
<span class="powerShell__variable">$i</span>=<span class="powerShell__operator">-</span>1&nbsp;
<span class="powerShell__keyword">foreach</span>(<span class="powerShell__variable">$record</span>&nbsp;<span class="powerShell__keyword">in</span>&nbsp;<span class="powerShell__variable">$data</span>)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__keyword">try</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$i</span><span class="powerShell__operator">&#43;</span><span class="powerShell__operator">&#43;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$percentComplete</span>=[<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Convert.aspx" target="_blank" title="Auto generated link to System.Convert">System.Convert</a>]::ToInt32(<span class="powerShell__variable">$i</span><span class="powerShell__operator">/</span>(<span class="powerShell__variable">$data</span>.count)<span class="powerShell__operator">*</span>100)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__cmdlets">Write-Progress</span>&nbsp;<span class="powerShell__operator">-</span>Activity&nbsp;<span class="powerShell__string">&quot;Cloning&nbsp;users&quot;</span>&nbsp;<span class="powerShell__operator">-</span>PercentComplete&nbsp;<span class="powerShell__variable">$percentComplete</span>&nbsp;<span class="powerShell__operator">-</span>CurrentOperation&nbsp;<span class="powerShell__string">&quot;Processing&nbsp;user:&nbsp;$($record.sourceDomain)\$($record.sourceSAMAccountName)&quot;</span>&nbsp;<span class="powerShell__operator">-</span>Status&nbsp;<span class="powerShell__string">&quot;Completed:&nbsp;$percentComplete`%&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[wintools.sidcloner]::CloneSid(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$record</span>.sourceSAMAccountName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$record</span>.sourceDomain,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$sourceDC</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$sourceCredential</span>.UserName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$sourceCredential</span>.Password,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$record</span>.targetSAMAccountName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$targetDomain</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write<span class="powerShell__operator">-</span>Host&nbsp;<span class="powerShell__string">&quot;Account&nbsp;$($record.sourceDomain)\$($record.sourceSAMAccountName)&nbsp;cloned&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__keyword">catch</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__cmdlets">Write-Warning</span>&nbsp;<span class="powerShell__operator">-</span>message:<span class="powerShell__string">&quot;Account&nbsp;$($record.sourceDomain)\$($record.sourceSAMAccountName)&nbsp;failed&nbsp;to&nbsp;clone`n`tError:$($($_.Exception).Message)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__string">&quot;$($record.sourceSAMAccountName),$($record.sourceDomain),$($record.targetSAMAccountName)&quot;</span>&nbsp;&gt;&gt;&nbsp;<span class="powerShell__string">&quot;.\Log\CloneFailed.csv&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="powerShell__com">#explicit&nbsp;DC&nbsp;and&nbsp;credentials&nbsp;for&nbsp;both&nbsp;domains</span>&nbsp;
<span class="powerShell__variable">$targetCredential</span>=<span class="powerShell__cmdlets">Get-Credential</span>&nbsp;
<span class="powerShell__variable">$targetDC</span>=Get<span class="powerShell__operator">-</span>DC&nbsp;<span class="powerShell__operator">-</span>domain:<span class="powerShell__variable">$targetDomain</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__com">#not&nbsp;implemented&nbsp;here</span>&nbsp;
<span class="powerShell__variable">$i</span>=<span class="powerShell__operator">-</span>1&nbsp;
<span class="powerShell__keyword">foreach</span>(<span class="powerShell__variable">$record</span>&nbsp;<span class="powerShell__keyword">in</span>&nbsp;<span class="powerShell__variable">$data</span>)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__keyword">try</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$i</span><span class="powerShell__operator">&#43;</span><span class="powerShell__operator">&#43;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$percentComplete</span>=[<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Convert.aspx" target="_blank" title="Auto generated link to System.Convert">System.Convert</a>]::ToInt32(<span class="powerShell__variable">$i</span><span class="powerShell__operator">/</span>(<span class="powerShell__variable">$data</span>.count)<span class="powerShell__operator">*</span>100)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__cmdlets">Write-Progress</span>&nbsp;<span class="powerShell__operator">-</span>Activity&nbsp;<span class="powerShell__string">&quot;Cloning&nbsp;users&quot;</span>&nbsp;<span class="powerShell__operator">-</span>PercentComplete&nbsp;<span class="powerShell__variable">$percentComplete</span>&nbsp;<span class="powerShell__operator">-</span>CurrentOperation&nbsp;<span class="powerShell__string">&quot;Processing&nbsp;user:&nbsp;$($record.sourceDomain)\$($record.sourceSAMAccountName)&quot;</span>&nbsp;<span class="powerShell__operator">-</span>Status&nbsp;<span class="powerShell__string">&quot;Completed:&nbsp;$percentComplete`%&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[wintools.sidcloner]::CloneSid(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$record</span>.sourceSAMAccountName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$record</span>.sourceDomain,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$sourceDC</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$sourceCredential</span>.UserName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$sourceCredential</span>.Password,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$record</span>.targetSAMAccountName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$targetDomain</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$targetDC</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$targetCredential</span>.UserName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__variable">$targetCredential</span>.Password&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write<span class="powerShell__operator">-</span>Host&nbsp;<span class="powerShell__string">&quot;Account&nbsp;$($record.sourceDomain)\$($record.sourceSAMAccountName)&nbsp;cloned&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__keyword">catch</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__cmdlets">Write-Warning</span>&nbsp;<span class="powerShell__operator">-</span>message:<span class="powerShell__string">&quot;Account&nbsp;$($record.sourceDomain)\$($record.sourceSAMAccountName)&nbsp;failed&nbsp;to&nbsp;clone`n`tError:$($($_.Exception).Message)&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="powerShell__string">&quot;$($record.sourceSAMAccountName),$($record.sourceDomain),$($record.targetSAMAccountName)&quot;</span>&nbsp;&gt;&gt;&nbsp;<span class="powerShell__string">&quot;.\Log\CloneFailed.csv&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>How to make use of this sample</span></h1>
<p>Build binaries for win32 or amd64 platform</p>
<p>For use in your C# project, add reference to the assembly in Visual Studio</p>
<p>For use from PowerShell,&nbsp;load the assembly into PowerShell session as shown in sample above.</p>
