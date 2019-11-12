# Windows Service which can be controled over IPC from a desktop application
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Service
- Windows Forms
## Topics
- Windows Service
- IPC Remoting
## Updated
- 09/27/2012
## Description

<h1>Introduction</h1>
<p><em>Very simple Windows Service and a WinForms Application. The WinForms Application can send a command to the service and the Service process the command. A Library class is used for a Interface for remoting. For comunication is the IPCServerChannel and
 remoting used.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The sample contains 3 Projects:</em></p>
<ul>
<li><em>Interfaces: This contains an interface used for remoting</em> </li><li><em>RemoteIPC: This is a windows forms application which can send a command to the windows service</em>
</li><li><em>ServiceApp: This is the windows service. Waiting on a command.</em> </li></ul>
<p>To run the service you have to install it. You have to use InstallUtil.exe from Frameworkdirectory:</p>
<p>%windir%\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe ServiceApp.exe</p>
<p>After that you can start the service in the Services Management.&nbsp;</p>
<p>To unistall use also InstallUtil.exe ServiceApp.exe /u</p>
<p>&nbsp;</p>
<p>The ServiceApp opens a IPC Channel with PortName &quot;MyServicePort&quot; and the Channel type is IPC. The Channel is registered with the ControlClass which has the Interface IMyControler. This Interface provides the Method DoFunction which can be called over remoting.</p>
<p>The RemotingIPC Windows form Application connects to the IPC channel and call the DoFunction over Remoting. In the Sample the string parameter is writen into a file in &quot;C:\TEMP\&quot;.</p>
<h1><span>Source Code Files ServiceAPP</span></h1>
<ul>
<li><em>Installer.cs - In the Installer you can set Registry values when the Service is installed</em>
</li><li><em><em>WinService.cs - Here is the Code of the service itself.</em></em> </li></ul>
