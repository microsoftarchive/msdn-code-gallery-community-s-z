# TCP / IP Server Client Example Part 5 (Chat Application)
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- SQL Server
- File System
- .NET
- Class Library
- ADO.NET
- Windows Forms
- Microsoft Azure
- Visual Studio 2010
- Windows Phone 7
- SQL Azure
- .NET Framework 4
- .NET 3.0
- Windows
- Visual Basic .NET
- Visual Basic.NET
- VB.Net
- .NET Framework 4.0
- Library
- Windows General
- Network
- Windows Phone
- C# Language
- Internet Explorer
- Async
- Windows Azure Storage
- WinForms
- Windows Phone Mango
- printer
- .NET Framework 4.5
- Windows 8
- .NET Framwork
- C# 3.0
- Graphics Functions
- HttpClient
- Image process
- Windows Azure SQL Database
- Visual Studio 2012
- .NET 4.5
- Windows Azure Mobile Services
- Windows Phone 8
- Windows Store app
- .NET Development
- Windows Phone Development
## Topics
- Controls
- Animation
- Graphics
- C#
- Data Binding
- Asynchronous Programming
- Security
- GDI+
- Authentication
- File System
- Class Library
- User Interface
- Games
- Windows Forms
- Graphics and 3D
- Architecture and Design
- Multithreading
- Navigation
- Microsoft Azure
- Data Access
- threading
- Images
- customization
- custom controls
- Web Services
- Windows Form Controls
- 2d graphics
- Visual Basic .NET
- Performance
- Parallel Programming
- Image manipulation
- Code Sample
- Printing
- Windows Phone
- Image
- WebBrowser
- .NET 4
- Imaging
- Drawing
- How to
- UI Design
- Generic C# resuable code
- File Systems
- Networking
- Storage
- Image Optimization
- general
- Windows Forms Controls
- C# Language Features
- Language Samples
- Graphics Functions
- Audio and video
- Devices and sensors
- Windows web services
- User Experience
- BitmapImage
- Windows Store app
- Load Image
- data and storage
## Updated
- 12/19/2013
## Description

<div>
<h1>1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Introduction</h1>
</div>
<p>Now that our users can Register and Login in &ndash; we need to do two things. Keep a record of registered users and a record of their friends. To day we will add the ability to keep a record of registered users.</p>
<div>
<h1>2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Building the Sample</h1>
</div>
<p>The sample is built in Visual Studio 2012 Ultimate as an x86 targeted application using .Net Framework 4. We will be using NuGet packages, a number of 3rd party libraries, as well as Windows Azure. All of which will be fully explained to you ensuring that
 the final compilation of your App will be hassle free. Oh! And the sample code is verbosely commented so you should have no problem in working out what the code does.</p>
<div>
<h1>3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Description</h1>
</div>
<p>Communication is fundamental to us all. Our Chat application is starting to take form. Previously you saw our Echo server, this time our server will remember who has registered and check that list so that returning users simply need to log in.</p>
<div>
<h1>4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Creating our Application</h1>
</div>
<p>Open your project in Visual Studio 2012. The first thing we need to do today is connect our application, server and client, to an azure sql database.</p>
<h2>4.1&nbsp;&nbsp;&nbsp; Windows Azure</h2>
<ol>
<li>Log into Windows Azure &ndash; create a trial account if you need to. </li><li>Create a new SQL Database called ChatApp </li><li>Click on the newly created Database </li><li>Click on Dashboard </li><li>Click on Show Connection Strings </li><li>Copy the ADO.NET connection string </li><li>Go back to Visual Studio DO NOT close your web page </li><li>Open your Server Explorer Window </li><li>Right Click on Data Connections and select Add Connection </li><li>Paste your connection string details into the Server Name box </li><li>Remove everything before the tcp: statement and after the ,1433 Mines looks like this: tcp:xxxxxxxxxx.database.windows.net,1433
</li><li>Select use SQL Server Authentication </li><li>Enter your User ID (User name) you can get that from your connection string </li><li>Type in your password </li><li>Click Save my password if you are not on a public computer </li><li>Click Test Connection button </li><li>If you get a message saying cannot connect client IP address is not allowed. You need to go back to the Windows Azure page
</li><li>At the bottom of the Connection Strings list you will see this:<img id="105765" src="105765-picture%202013-12-19%2009_29_11.png" alt="" width="263" height="51">
</li><li>Click on the link </li><li>Click the Add to the Allowed IP Addresses link. You don&rsquo;t have to do this for every computer that runs your application only for computers that have management control over your database.
</li><li>Click the Save button at the bottom of the page. </li><li>Go back to Visual Studio and Test Connection again &ndash; it will succeed now.
</li><li>Select ChatApp from the drop down list of Database names. </li><li>Click the Advanced button </li><li>Set Connect Time out to 30 </li><li>Set Encrypt to True </li><li>Click Ok </li><li>Test Connection once again &ndash; it may have jumped to Windows Authentication
</li><li>Click Ok &ndash; Your Server Explorer Window now shows your ChatApp database!
</li><li>Open the Database using the arrow to the left of the Database name </li><li>Right Click on Tables and Select Add New Table </li><li>Wait until the Design Surface is loaded. </li><li>Change the T-SQL code at the bottom of the screen to this: </li></ol>
<p>&nbsp;</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">Users</span>]&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Id</span>]&nbsp;<span class="sql__keyword">INT</span>&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>&nbsp;<span class="sql__keyword">PRIMARY</span>&nbsp;<span class="sql__keyword">KEY</span>&nbsp;<span class="sql__id">IDENTITY</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ScreenName</span>]&nbsp;<span class="sql__keyword">NVARCHAR</span>(<span class="sql__number">50</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">EmailAddress</span>]&nbsp;<span class="sql__keyword">NVARCHAR</span>(<span class="sql__id">MAX</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__keyword">Password</span>]&nbsp;<span class="sql__id">NTEXT</span>&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Online</span>]&nbsp;<span class="sql__keyword">BIT</span>&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>&nbsp;<span class="sql__keyword">DEFAULT</span>&nbsp;<span class="sql__number">0</span>&nbsp;
)</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<ol>
<li>Click Update which you will find at the top left of the Design Surface </li><li>Click Update Database on the dialog. </li><li>Add &nbsp;another new Table </li><li>And change the T-SQL to this: </li></ol>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">Friends</span>]&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Id</span>]&nbsp;<span class="sql__keyword">INT</span>&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ScreenName</span>]&nbsp;<span class="sql__keyword">NVARCHAR</span>(<span class="sql__number">50</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">EmailAddress</span>]&nbsp;<span class="sql__id">NTEXT</span>&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">CONSTRAINT</span>&nbsp;[<span class="sql__id">PK_Friends</span>]&nbsp;<span class="sql__keyword">PRIMARY</span>&nbsp;<span class="sql__keyword">KEY</span>&nbsp;([<span class="sql__id">Id</span>])&nbsp;
)</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p>38. Update the Database Again</p>
<p>&nbsp;</p>
<p>We have now created two tables &ldquo;Users&rdquo; and &ldquo;Friends&rdquo; on the Azure Cloud. What we will do is change the ChatApp so that when user&rsquo;s register their information is placed in the Users table and we can check that each time the login.
 Once logged in the User is told their ID number &ndash; which their ChatApp client uses to get a list of the user&rsquo;s friends and the Server will tell the client if they are online or not. But that is for the next in this series.</p>
<p>&nbsp;</p>
<p>Source Code</p>
<ul>
<li>Source Code Form1.cs &ndash; The Chat application(s) </li><li>Source Code Forms/FrmServer.cs &ndash; the Server Application </li><li>Source Code Forms/FrmLogin.cs &ndash; the login dialog for the Chat application
</li><li>Source Code Forms/FrmRegister.cs &ndash; the Registration dialog for the chat application.
</li><li>Source Code FriendsControl/UserControl1 &ndash; A custom control that will be used by the Chat application when the logged on user has a friends list.
</li><li>Azure SQL Tables &ldquo;Users&rdquo; &ndash; Hold&rsquo;s information about all registered users.
</li><li>Azure SQL Tables &ldquo;Friends&rdquo; &ndash; Hold&rsquo;s information about all registered user&rsquo;s friends.
</li></ul>
<div>
<h1>5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; More Information</h1>
</div>
<p>To convert the solution to a previous version of Visual Studio you can use this free application:
<a href="http://vsprojectconverter.codeplex.com/">http://vsprojectconverter.codeplex.com/</a> or download and use Visual Studio 2013 Express which is freely available from Microsoft from here:
<a href="http://www.visualstudio.com/downloads/download-visual-studio-vs">http://www.visualstudio.com/downloads/download-visual-studio-vs</a>.</p>
<p>NetComm.dll: <a href="http://www.codeproject.com/Articles/118485/C-VB-NET-Multi-user-Communication-Library-TCP">
http://www.codeproject.com/Articles/118485/C-VB-NET-Multi-user-Communication-Library-TCP</a></p>
<p>The Visual Basic version of this code was generated by the free tool: Instant VB from
<a href="http://www.tangiblesoftwaresolutions.com/">http://www.tangiblesoftwaresolutions.com/</a></p>
