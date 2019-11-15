# Windows 7 UI Automation Client API C# sample (focus tracking) Version 1.0
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Magnification API
- Windows 7 UI Automation API
## Topics
- UI Automation
- Magnification API
## Updated
- 05/03/2011
## Description

<p>I&rsquo;ve based this sample on my C# sample that uses the Windows 7 UI Automation Client API to interact with hyperlinks in a browser, (<a href="http://code.msdn.microsoft.com/Windows-7-UI-Automation-0625f55e">http://code.msdn.microsoft.com/Windows-7-UI-Automation-0625f55e</a>).</p>
<p>For this new sample, I&rsquo;ve pulled out all the link-processing code, and switched the structure changed event handler for a focus changed event handler. By doing that, the sample can now highlight which UI element has keyboard focus. I also call .NET
 Speech functionality to have the name of the element spoken when it&rsquo;s highlighted. (It takes a few seconds for the first name to be spoken.)</p>
<p>Note that the app is using the unmanaged Windows 7 UI Automation API. The sample has a custom build step:</p>
<p>&quot;%PROGRAMFILES%\Microsoft SDKs\Windows\v7.0A\bin\tlbimp.exe&quot; %windir%\system32\UIAutomationCore.dll /out:..\interop.UIAutomationCore.dll&quot;</p>
<p>&nbsp;</p>
<p>Using tlbimp.exe, an interop dll gets built and is referenced by the C# source files. If this doesn&rsquo;t build for you, you&rsquo;ll need to update the custom build action to specify where tlbimp.exe is on your computer. (It can be downloaded with the
 Windows SDK.)</p>
<p>Please note that the results of the magnification are only reliable when the sample is built with the same bitness as the target hardware. (So run a 32-bit exe on a 32-bit machine, and a 64-bit exe on a 64-bit machine. Running a 32-bit exe on a 64-bit machine
 will often result in the magnification window only showing blackness.)</p>
<p>There are quite a few changes I&rsquo;d need to make before the sample app is a useful tool in practice. For example, once an element gets focused and is magnified, the magnified results don&rsquo;t change until focus changes again. This means if the element
 is an editable text field, you can&rsquo;t see what you&rsquo;re typing. Also, there are times when the magnification window appears in the wrong place, or vanishes completely. I&rsquo;ve not looked into whether that's because I&rsquo;m losing some events,
 or the bounding rect is not being correctly reported by the provider, or the window&rsquo;s disappearing behind other top-most windows.</p>
<p>But as the sample stands, it shows how a focus changed event handler can be set up to get cached data about the element with focus. This means when the app gets the focus changed event, all the data it needs is supplied with the event, and no cross-process
 calls have to be made at that time to get any more data.</p>
<p>If you&rsquo;d like the sample updated to demo more actions, or to fix some of the cases where the magnification window isn&rsquo;t visible as expected, let me know.</p>
<p>Guy</p>
<p><img src="http://i3.code.msdn.microsoft.com/windows-7-ui-automation-6390614a/image/file/21457/1/sampleapp_focustracking.png" alt="" width="984" height="686"></p>
