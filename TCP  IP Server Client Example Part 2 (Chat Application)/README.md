# TCP / IP Server Client Example Part 2 (Chat Application)
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- .NET
- Windows Forms
- Windows Phone 7
- .NET Framework 4
- .NET Framework
- VB.Net
- .NET Framework 4.0
- Windows General
- Windows Phone
- C# Language
- WinForms
- Windows 8
- Visual Studio 2012
- Windows Phone 8
- Windows Store app
- .NET Development
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
- User Interface
- Games
- Windows Forms
- Graphics and 3D
- Serialization
- Architecture and Design
- Multithreading
- Navigation
- Microsoft Azure
- Data Access
- threading
- Images
- customization
- Media
- custom controls
- Web Services
- 2d graphics
- Parallel Programming
- Image manipulation
- Getting Started
- Image Gallery
- Printing
- Windows Phone
- Image
- .NET 4
- Drawing
- How to
- UI Design
- Generic C# resuable code
- Contacts
- File Systems
- Networking
- Image Optimization
- Windows 8
- Windows Forms Controls
- C# Language Features
- Language Samples
- Graphics Functions
- ASP.NET Web API
- Web API
- Audio and video
- User Experience
- BitmapImage
- Windows Store app
- Load Image
- data and storage
## Updated
- 12/17/2013
## Description

<div>
<h1>1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Introduction</h1>
</div>
<p>In this series we are going to be looking at TCP IP, Client / Servers and what a massive world of opportunities this knowledge opens up to us, Today we will be doing a Chat System!</p>
<div>
<h1>2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Building the Sample</h1>
</div>
<p>The sample is built in Visual Studio 2012 Ultimate as an x86 targeted application using .Net Framework 4. We will be using NuGet packages, a number of 3rd party libraries. All of which will be fully explained to you ensuring that the final compilation of
 your App will be hassle free. Oh! And the sample code is verbosely commented so you should have no problem in working out what the code does.</p>
<div>
<h1>3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Description</h1>
</div>
<p>Communication is fundamental to us all. But it is also fundamental to many programs. When your application connects with a database it has to communicate, when your browser connects to a website, it communicates and the vast majority of the communication
 that occurs on the internet is does through TCP communication. In this first example we will write a client and an &ldquo;echo server&rdquo; which simply replies with the message you sent &ndash; pretty much like the ping command. It doesn&rsquo;t sound like
 much but it is the basis that we will start from.</p>
<div>
<h1>4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Creating our Application</h1>
</div>
<p>Open Visual Studio 2012 and Create a New Project. Call the Project ChatApp. You will find in the Solution download a new .dll called NetComm it is a 3<sup>rd</sup> party library that we will be using for our communication. Or you can download it from the
 link below in the More Information section.</p>
<h2>4.1&nbsp;&nbsp;&nbsp; Server Design</h2>
<p>We have a single Toolstrip with a button which will create new Clients for us. This just makes things a little simpler for us at this stage.</p>
<p>We have a RichTextBox which shows what the Server is doing and</p>
<p>A StatusStrip which shows how many Connections (clients) are currently being processed by the Server.</p>
<p>I will leave you do build your own design, and that of the Clients.</p>
<h2>4.2&nbsp;&nbsp;&nbsp; How it works</h2>
<p>The Server is instantiated and a number of events are subscribed to. We then start the Server and wait for the Events to be fired so we can process them. The Events will only be fired when a client connects. You can simulate clients connecting by clicking
 on the button at the top of the Server window. You can have as many clients as you like and delete clients as you like as well.</p>
<p>All messages sent by the clients are sent through the server. At this point the server looks to see if it is a command or a simple message for other&rsquo;s to read. In this implementation a message sent by one client is displayed on all other connected
 clients screens. Later we will change this.</p>
<p>The only command the Server currently recognises is &ldquo;CLOSING&rdquo; which is sent from a client when it is going off line. The Clients also recognise a single command which is &ldquo;CList&rdquo; &ndash; this tells the client which friends are online
 &ndash; in this present version that is every client that is connected to the Server.</p>
<h2>4.3&nbsp;&nbsp;&nbsp; Source Code</h2>
<ul>
<li>Source Code Form1.cs &ndash; The Server application </li><li>Source Code Forms/FrmClient.cs &ndash; the Client Application(s) </li></ul>
<div>
<h1>5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; More Information</h1>
</div>
<p>To convert the solution to a previous version of Visual Studio you can use this free application:
<a href="http://vsprojectconverter.codeplex.com/"><em>http://vsprojectconverter.codeplex.com/</em></a> or download and use Visual Studio 2013 Express which is freely available from Microsoft from here:
<a href="http://www.visualstudio.com/downloads/download-visual-studio-vs"><em>http://www.visualstudio.com/downloads/download-visual-studio-vs</em></a>.</p>
<p>NetComm.dll: <a href="http://www.codeproject.com/Articles/118485/C-VB-NET-Multi-user-Communication-Library-TCP">
http://www.codeproject.com/Articles/118485/C-VB-NET-Multi-user-Communication-Library-TCP</a></p>
