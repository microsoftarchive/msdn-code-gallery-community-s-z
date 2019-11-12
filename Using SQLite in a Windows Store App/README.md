# Using SQLite in a Windows Store App
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- XAML
- SQLite
- Windows Store app
## Topics
- Data Binding
- Data Access
- MVVM
- Windows Store app
- Using SQLite in Metro Style
## Updated
- 01/21/2013
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">In <a href="http://channel9.msdn.com/Shows/Visual-Studio-Toolbox/Using-SQLite-in-Windows-Store-Apps" target="_blank">
episode 52</a> of my Visual Studio Toolbox show, I showed a sample Windows Store app that uses SQLite. The app manages customers and their projects. This is the sample code for that app. The code shows you how you connect to a SQLite database, create tables
 and how to perform CRUD operations on data.</span></p>
<h1>Requirements</h1>
<ul>
<li><span style="font-size:small">Visual Studio 2012</span> </li><li><span style="font-size:small">Windows 8 </span></li><li><span style="font-size:small"><a href="http://visualstudiogallery.msdn.microsoft.com/23f6c55a-4909-4b1f-80b1-25792b11639e">SQLite for Windows Runtime</a></span>
</li><li><span style="font-size:small"><a href="https://nuget.org/packages/sqlite-net/1.0.5">sqlite-net</a></span>
</li></ul>
<h1><span>Building the Sample</span></h1>
<ol>
<li><span style="font-size:small">Open the SQLiteDemo project in Visual Studio. </span>
</li><li><span style="font-size:small">Select <strong>Tools|Extensions and Updates</strong>. In the Extensions and Updates dialog, select
<strong>Online</strong>. Type <strong>sqlite</strong> in the search box. You will see SQLite for Windows Runtime. This is the SQLite binaries packaged up by the SQLite team. Install this.</span>
</li><li><span style="font-size:small">Select Project|Add Reference. In the left side of the Reference Manager dialog, expand the Windows node and select Extensions. Select SQLite for Windows Runtime and Microsoft Visual C&#43;&#43; Runtime Package. Click OK.</span>
</li><li><span style="font-size:small">When you create a new C# or VB Windows Store project in Visual Studio, it supports all architectures (x86, x64 and ARM) by default. But since you added SQLite to the project, you can&rsquo;t build one package that targets all
 architectures. You have to build one target for each. Select <strong>Build|Configuration Manager</strong> and select
<strong>x86</strong>, <strong>x64</strong> or <strong>ARM</strong> from the Platform drop-down list.</span>
</li><li><span style="font-size:small">Select <strong>Tools|Library Package Manager|Package Manager Console</strong> and type
<strong>install-package sqlite-net</strong>. The sqlite-net package enables you to work with SQLite databases using a LINQ syntax. After you install it, you will see two new files in your project: SQLite.cs and SQLiteAsync.cs.</span>
</li><li><span style="font-size:small">Build the solution. </span></li></ol>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">This app uses a simple (Model-View-ViewModel) pattern. The Models folder contains classes for Customers and Projects. These are basic POCO classes.</span></p>
<p><span style="font-size:small">ViewModels represent data. They sit between the UI (views) and the actual data (models). The ViewModels folder contains a ViewModel for each entity (customer and project) and a ViewModel for each collection of entities (customers
 and projects).</span></p>
<p><span style="font-size:small">Views represent the user interface. The Views folder contains a XAML file for each page in the app.</span></p>
<h1>More Information</h1>
<p><span style="font-size:small">For a more detailed walkthrough that shows how to build this app from scratch, see
<a href="http://blogs.msdn.com/b/robertgreen/archive/2012/11/13/using-sqlite-in-windows-store-apps.aspx">
Using SQLite in Windows Store Apps</a>.</span></p>
