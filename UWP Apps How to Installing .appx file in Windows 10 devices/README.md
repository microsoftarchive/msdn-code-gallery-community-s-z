# UWP Apps: How to Installing .appx file in Windows 10 devices
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Windows SDK
- Windows Runtime
- Windows 10
- Windows UWP
## Topics
- .AppX deployment in Windows 10 UWP
- Hello World sample in Windows 10 UWP c#
- How to generate .Appx file in Windows 10 C#
- How to install windows 10 app
## Updated
- 03/05/2016
## Description

<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>Introduction:</strong></span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">In&nbsp;</span><a href="http://bsubramanyamraju.blogspot.com/2014/04/windowsphone-81-how-to-deploy-appx-file.html">prev</a><span style="font-family:verdana,sans-serif">&nbsp;post
 i was explained about how to deploy .appx file in WinRT windows phone. During development you typically deploy and run your app from Visual Studio.&nbsp;</span><span style="font-family:verdana,sans-serif">Optionally in WinRT/Silverlight windows phone, you
 can also use the stand-alone Application Deployment tool to deploy your app to the emulator or to a registered device.&nbsp;</span><span style="font-family:verdana,sans-serif">But in Windows 10&nbsp;Universal Windows Platform(UWP),&nbsp;With Windows 10 SDK
 Preview Build 10166, Microsoft was introduce the Windows 10 Application Deployment (WinAppDeployCmd.exe) tool.&nbsp;</span></span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">You can also read this article from my original
<a title="SubramanyamRaju WindowsPhone Tutorials" href="http://bsubramanyamraju.blogspot.com/2016/02/windows-10-uwp-apps-how-to-deploy-appx.html" target="_blank">
blog</a>.</span></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://4.bp.blogspot.com/-kfTftSA2v6c/VsARZR_3ZsI/AAAAAAAACZI/oq_TGmLis80/s1600/Intro.png"><img src="https://4.bp.blogspot.com/-kfTftSA2v6c/VsARZR_3ZsI/AAAAAAAACZI/oq_TGmLis80/s640/Intro.png" border="0" alt="" width="640" height="480"></a></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">The Windows 10 Application Deployment (WinAppDeployCmd) is a command line utility that can be utilized to deploy a Universal Windows app from a Windows 10 PC to any Windows 10 mobile device. It
 allows users to deploy an .AppX to a device connected through USB or available on the same subnet without requiring access to the complete Visual Studio solution.</span></p>
<div>
<p><strong style="font-size:small">Requirements:</strong></p>
<div>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">This article is targeted for windows 10 Universal Windows Platform(#UWP) , so make sure you&rsquo;ve downloaded and installed the latest Windows 10 SDK from&nbsp;<a href="https://dev.windows.com/en-us/downloads">here</a>.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">I assumes that you&rsquo;re going to test your app on the Windows Phone emulator. If you want to test your app on a phone, you have to take some additional steps. For more info, see&nbsp;<a href="http://msdn.microsoft.com/en-us/library/windowsphone/develop/dn614128.aspx">Register
 your Windows Phone device for development</a>.</span> </li><li><span style="font-family:verdana,sans-serif; font-size:small">This post assumes&nbsp;you&rsquo;re using&nbsp;<strong>Microsoft Visual Studio 2015 or Later.</strong></span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">This article is developed on windows 8.1 machine. So Visual Studio settings may differ from windows 10 OS VS.</span>
</li></ul>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif"><strong>Note:</strong>&nbsp;Windows 10 SDK works best on the Windows 10 operating system. And it is&nbsp;</span><span style="font-family:verdana,sans-serif">also supported on: Windows
 8.1, Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2, but n</span><span style="font-family:verdana,sans-serif">ot all tools are supported on these operating systems.</span></span></p>
<p><strong style="font-family:verdana,sans-serif; font-size:small">Description:</strong></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">This article can explain you about below topics</span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">1. Why .Appx Deployment?</span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">2. What are prerequisites to deploy .AppX file</span><span style="font-family:verdana,sans-serif">?</span></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">3. How to use&nbsp;Application Deployment (WinAppDeployCmd.exe) tool?</span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>1. Why .AppX Deployment?</strong></span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">Often when you write a Windows Phone &nbsp;application you do not want to give users the full source code. In such cases it is possible to share only the build file and deploy it
 to a device or emulator. You can accomplish this using the Windows Phone Application Deployment tool that comes with the RTM version of Windows Phone Developer Tools</span><span style="font-family:verdana,sans-serif">.</span></span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif"><strong>2.&nbsp;</strong></span><strong><span style="font-family:verdana,sans-serif">What are prerequisites to deploy .AppX file</span><span style="font-family:verdana,sans-serif">?</span></strong></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">WinAppDeployCmd is a stand-alone tool that comes as part of the Windows 10 SDK installation. To use it we need to follow below steps.</span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">Go into the Settings of a Windows 10 phone device and search for&nbsp;Update &amp; Security category and turn on&nbsp;<a href="https://msdn.microsoft.com/en-us/library/windows/apps/dn706236.aspx">Developer
 Mode</a>.</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://1.bp.blogspot.com/-NQVaWG5r4KA/Vr9XOniFByI/AAAAAAAACWM/S9PM36ZCrdE/s1600/5.UpdateSecurty.PNG"><img src="https://1.bp.blogspot.com/-NQVaWG5r4KA/Vr9XOniFByI/AAAAAAAACWM/S9PM36ZCrdE/s400/5.UpdateSecurty.PNG" border="0" alt="" width="212" height="400"></a></span></p>
<p>&nbsp;</p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://1.bp.blogspot.com/-LqPr7q5gtm4/Vr9XQthuaDI/AAAAAAAACWQ/FneThRjkzZs/s1600/4.DeveloperMode.PNG"><img src="https://1.bp.blogspot.com/-LqPr7q5gtm4/Vr9XQthuaDI/AAAAAAAACWQ/FneThRjkzZs/s400/4.DeveloperMode.PNG" border="0" alt="" width="212" height="400"></a></span></p>
<p class="separator"><strong style="font-family:verdana,sans-serif; font-size:small">3. How to use&nbsp;Application Deployment (WinAppDeployCmd.exe) tool?</strong></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">Before .AppX deployment, first we need to generate .AppX file from our existing project. So first create new project name is (Ex: Hello World)</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://3.bp.blogspot.com/-YO1t3VvK22g/Vr9ecMhXSwI/AAAAAAAACWg/N418sZn22eA/s1600/1.NewProject.PNG"><img src="https://3.bp.blogspot.com/-YO1t3VvK22g/Vr9ecMhXSwI/AAAAAAAACWg/N418sZn22eA/s640/1.NewProject.PNG" border="0" alt="" width="640" height="390"></a></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">If you want to add some code in xaml page, lets add below code in MainPage.xaml.</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Page</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;Hello_World.MainPage&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">local</span>=<span class="xaml__attr_value">&quot;using:Hello_World&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">d</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/expression/blend/2008&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">mc</span>=<span class="xaml__attr_value">&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mc:<span class="xaml__attr_name">Ignorable</span>=<span class="xaml__attr_value">&quot;d&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;{ThemeResource&nbsp;ApplicationPageBackgroundThemeBrush}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--Title--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Hello&nbsp;World&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;12&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;25&quot;</span>&nbsp;<span class="xaml__attr_name">FontWeight</span>=<span class="xaml__attr_value">&quot;Bold&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;A&nbsp;sample&nbsp;for&nbsp;understanding&nbsp;Windows&nbsp;10&nbsp;.Appx&nbsp;file&nbsp;deployment&nbsp;with&nbsp;Application&nbsp;Deployment&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(WinAppDeployCmd.exe)&nbsp;tool&quot;</span>&nbsp;<span class="xaml__attr_name">TextWrapping</span>=<span class="xaml__attr_value">&quot;Wrap&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;12&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_end">&lt;/Page&gt;</span>&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Press F5 to run project, and now its time to generate .AppX file, so please follow below steps for it.</div>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif"><strong>Step 1:&nbsp;</strong></span><span style="font-family:verdana,sans-serif">Right click on your Project=&gt;Store=&gt;Create App Packages</span></span></p>
<p class="separator"><span style="font-size:small"><a href="https://2.bp.blogspot.com/-A-yF2xkLqfA/Vr9gVOKHn0I/AAAAAAAACWs/_yipmTCgrRY/s1600/3.CreateAppx.PNG"><img src="https://2.bp.blogspot.com/-A-yF2xkLqfA/Vr9gVOKHn0I/AAAAAAAACWs/_yipmTCgrRY/s640/3.CreateAppx.PNG" border="0" alt="" width="640" height="344"></a></span></p>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small"><strong>Step2:&nbsp;</strong><span style="font-family:verdana,sans-serif">In the Create App Packages wizard, select 'No' If you want to create a local package</span></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://4.bp.blogspot.com/-OMiqlGaAafY/Vr9hITbyzWI/AAAAAAAACWw/3PdkElu9p38/s1600/8.Appx1.PNG"><img src="https://4.bp.blogspot.com/-OMiqlGaAafY/Vr9hITbyzWI/AAAAAAAACWw/3PdkElu9p38/s640/8.Appx1.PNG" border="0" alt="" width="640" height="520"></a></span></p>
<p><strong style="font-size:small">Step3:&nbsp;</strong><span style="font-family:verdana,sans-serif">The next dialog provides a choice of processor platforms to target. However, if you are using platform specific binaries in your app, you&rsquo;ll need to build
 separate packages for each platform.&nbsp;</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://4.bp.blogspot.com/-JssKIQkAXyw/Vr9kd3j4RrI/AAAAAAAACXU/JPGSWAgNA3U/s1600/9.Appx2.PNG"><img src="https://4.bp.blogspot.com/-JssKIQkAXyw/Vr9kd3j4RrI/AAAAAAAACXU/JPGSWAgNA3U/s640/9.Appx2.PNG" border="0" alt="" width="640" height="520"></a></span></p>
<p><span style="font-family:verdana,sans-serif">I</span><span style="font-family:verdana,sans-serif">n this article, we selected the 'ARM' platform and now press the &ldquo;Create&rdquo; button. T</span><span style="font-size:small">hen wizard gives us a link
 to where the package was created.</span></p>
<p class="separator"><span style="font-size:small"><a href="https://3.bp.blogspot.com/-fUbXSor4Qec/Vr_4dQsYbAI/AAAAAAAACXs/GAkyi9_5g4U/s1600/12.Appx6.PNG"><img src="https://3.bp.blogspot.com/-fUbXSor4Qec/Vr_4dQsYbAI/AAAAAAAACXs/GAkyi9_5g4U/s640/12.Appx6.PNG" border="0" alt="" width="640" height="520"></a></span></p>
<p><span style="font-size:small">So now you can get the path where .AppX has been created like below:</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://4.bp.blogspot.com/-i5PKbbD8BlA/Vr9ktUUZQMI/AAAAAAAACXY/QrklU_-7Fe0/s1600/12.Appx5.PNG"><img src="https://4.bp.blogspot.com/-i5PKbbD8BlA/Vr9ktUUZQMI/AAAAAAAACXY/QrklU_-7Fe0/s1600/12.Appx5.PNG" border="0" alt=""></a></span></p>
<p><span style="font-family:Verdana,sans-serif; font-size:small">Please copy above .Appx file path, which we need to use it in deployment.&nbsp;</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif">Okay, now it's time to .AppX deployment with&nbsp;</span><span style="font-size:small">WinAppDeployCmd&nbsp;tool,&nbsp;</span><span style="font-family:verdana,sans-serif">which is&nbsp;</span><span style="font-family:verdana,sans-serif">located
 from the&nbsp;C:\Program Files (x86)\Windows Kits\10\bin\x86\&nbsp;directory&nbsp;(based on your installation path for the SDK)</span><span style="font-family:verdana,sans-serif">. So open command prompt and change directory path to this.</span></p>
<p class="separator"><a href="https://1.bp.blogspot.com/-dNINfBw26Ok/Vr_7soafDQI/AAAAAAAACX4/Kjk0qe_a4BI/s1600/13.1.Cmd.PNG" style="font-family:verdana,sans-serif; font-size:small"><img src="https://1.bp.blogspot.com/-dNINfBw26Ok/Vr_7soafDQI/AAAAAAAACX4/Kjk0qe_a4BI/s640/13.1.Cmd.PNG" border="0" alt="" width="640" height="324"></a></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">We can also list all the available target devices on the network using same subnet and use respective IP Address for specific device.</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://3.bp.blogspot.com/-qGxVa1bM0Ek/Vr_822TUCrI/AAAAAAAACYE/5W_8jZS2L9c/s1600/13.2.Cmd.PNG"><img src="https://3.bp.blogspot.com/-qGxVa1bM0Ek/Vr_822TUCrI/AAAAAAAACYE/5W_8jZS2L9c/s640/13.2.Cmd.PNG" border="0" alt="" width="640" height="324"></a></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">Below syntax is common possibility that you can used to install .appx with WinAppDeployCmd.exe</span></p>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">WinAppDeployCmd install -file &lt;Appx file path&gt; -ip &lt;address&gt; -pin &lt;p&gt;</span>
</li></ul>
<p class="separator"><span style="font-size:small"><a href="https://msdn.microsoft.com/en-us/library/cda52e06-f452-4f7b-be05-4c6eac2a9100.aspx" target="_blank">He<span id="goog_1119771344">&nbsp;</span><span id="goog_1119771345">&nbsp;</span>re</a>&nbsp;we
 can&nbsp;read list of possible syntax of WinAppDeployCmd.exe.</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">Now install the our &quot;Hello World_1.0.0.0_ARM_Debug.appx&quot; app package to a Windows 10 phone device with an IP address of 127.0.0.1, with a PIN of A1B2C3.</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">For example:</span><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">WinAppDeployCmd install -file &quot;D:\Windows Phone\Subbu\UWP\Hello World\Hello World\AppPackages\Hello World_1.0.0.0_ARM_Debug_Test\Hello World_1.0.0.0_ARM_Debug.appx&quot; -ip&nbsp;127.0.0.1&nbsp;-pin&nbsp;A1B2C3</span></p>
<div><span style="font-family:verdana,sans-serif"><strong>Note:&nbsp;</strong></span><span style="font-family:verdana,sans-serif">A pin if it is required to establish a connection with the target device. (You will be prompted to retry with the -pin option if
 authentication is required.)</span></div>
<div><span style="font-family:verdana,sans-serif; font-size:small"><br>
</span></div>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://2.bp.blogspot.com/-JKHRhm6ESLY/VsAEZ0dvD8I/AAAAAAAACYU/HW39He--uJg/s1600/13.3.Cmd.PNG"><img src="https://2.bp.blogspot.com/-JKHRhm6ESLY/VsAEZ0dvD8I/AAAAAAAACYU/HW39He--uJg/s640/13.3.Cmd.PNG" border="0" alt="" width="640" height="436"></a></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">Now we can found installed app on device/emulator like below:</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://1.bp.blogspot.com/-YIKO3EY09Kk/VsAGj2o8M0I/AAAAAAAACYk/Ptn0-li4z7k/s1600/6.1.AppInstall.png"><img src="https://1.bp.blogspot.com/-YIKO3EY09Kk/VsAGj2o8M0I/AAAAAAAACYk/Ptn0-li4z7k/s400/6.1.AppInstall.png" border="0" alt="" width="212" height="400"></a></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">One we tap on our app icon from app list, the screen could be like below:</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://2.bp.blogspot.com/-_PMa2_0xGvA/VsAHa-IcE3I/AAAAAAAACY0/L83L5wyRseY/s1600/7.1.Output.png"><img src="https://2.bp.blogspot.com/-_PMa2_0xGvA/VsAHa-IcE3I/AAAAAAAACY0/L83L5wyRseY/s400/7.1.Output.png" border="0" alt="" width="225" height="400"></a></span></p>
<p><strong style="font-size:small"><span style="font-family:verdana,sans-serif">Important Notes:</span></strong></p>
<div>
<p><span style="font-size:small">1.&nbsp;<span style="font-family:verdana,sans-serif">Make sure to enable developer mode for windows 10 devices, before .appx deployment</span>. Otherwise you will get below error</span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">&quot;Error : DEP0001 : Unexpected Error: To install this application you need either a Windows developer license or a sideloading-enabled system. (Exception from HRESULT: 0x80073CFF)&quot;</span></p>
<p class="separator"><span style="font-size:small"><a href="https://3.bp.blogspot.com/-ZCHVFcb9N6U/VsAU4l_zAVI/AAAAAAAACZU/dtjrNn-qD_Y/s1600/Error.PNG"><img src="https://3.bp.blogspot.com/-ZCHVFcb9N6U/VsAU4l_zAVI/AAAAAAAACZU/dtjrNn-qD_Y/s640/Error.PNG" border="0" alt="" width="640" height="126"></a></span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">2. This sample will be work on all window 10 devices OS devices. And this sample was tested in Lumia 735 device with Windows 10 OS (</span>version 1511).</span></p>
<p><span style="font-size:small">3. W<span style="font-family:verdana,sans-serif">indows 10 SDK works best on the Windows 10 operating system. And it is&nbsp;</span><span style="font-family:verdana,sans-serif">also supported on: Windows 8.1, Windows 8, Windows
 7, Windows Server 2012, Windows Server 2008 R2, but n</span><span style="font-family:verdana,sans-serif">ot all tools are supported on these operating systems</span></span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">4.&nbsp;</span>This article is developed on windows 8.1 OS with 64 bit.&nbsp;</span></p>
<p class="separator"><span style="font-size:small"><strong>Help me with feedback:</strong></span></p>
<p class="separator"><span style="font-size:small"><strong>&nbsp;</strong>Thank you for reading my article. Drop all your questions/comments in QA tab give me your feedback with&nbsp;<img id="67168" src="http://i1.code.msdn.s-msft.com/oops-principles-solid-7a4e69bf/image/file/67168/1/ratings.png" alt="" width="74" height="15">&nbsp;star
 rating (1 Star - Very Poor, 5&nbsp;Star -&nbsp;Very Nice). &nbsp;</span></p>
<p><span style="font-size:small"><br>
</span></p>
</div>
<h2>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><span style="color:#000000">Follow me always at&nbsp;&nbsp;</span><a class="account-group x_x_x_x_x_x_js-account-group x_x_x_x_x_x_js-action-profile x_x_x_x_x_x_js-user-profile-link x_x_x_x_x_x_js-nav" href="https://twitter.com/Subramanyam_B"><span class="username js-action-profile-name" style="color:#8899a6"><span style="color:#b1bbc3">@</span>Subramanyam_B</span>&nbsp;</a></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">Have a nice day by<span style="color:#000000">&nbsp;</span><a href="http://bsubramanyamraju.blogspot.in/p/about-me.html">Subramanyam Raju</a><span style="color:#000000">&nbsp;:)</span></span></p>
</h2>
<p class="separator"><span style="font-family:verdana,sans-serif"><br>
</span></p>
</div>
</div>
