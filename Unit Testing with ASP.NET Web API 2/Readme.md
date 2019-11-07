# Unit Testing with ASP.NET Web API 2
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- Entity Framework
- ASP.NET Web API 2
## Topics
- Unit Testing
## Updated
- 06/05/2014
## Description

<h1>Introduction</h1>
<p>This&nbsp;sample demonstrates how to create unit tests for your Web API 2 application. It shows how to&nbsp;create test objects for working with&nbsp;the Entity Framework, and how to add&nbsp;test methods that check the returned values from a controller
 method.</p>
<h1><span>Building the Sample</span></h1>
<p>You must restore the NuGet packages for the sampel to work. Starting with NuGet 2.7, the packages are restored by default when you build the project for the first time. This first build will take extra time as the packages are restored.</p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p>This sample includes code from two topics - <a href="http://www.asp.net/web-api/raw-content/tutorials/testing-and-debugging/unit-testing-aspnet-web-api">
Unit Testing ASP.NET Web API 2</a> and <a href="http://www.asp.net/web-api/overview/testing-and-debugging/mocking-entity-framework-when-unit-testing-aspnet-web-api-2">
Mocking Entity Framework when Unit Testing ASP.NET Web API</a>. It shows a simple data scenario through the SimpleProductController.cs&nbsp;file and the TestSimpleProductController.cs file. This scenario is less complicated because it does not involve mocking
 Entity Framework object<em>.</em></p>
<p>&nbsp;A more complicated example is shown in the ProductController.cs file and the TestProductController.cs file. These files show how to unit test an application that uses Entity Framework.</p>
<p>The solution includes two projects. StoreApp is the main application and the one being testing. StoreApp.Tests is the test project and includes the code required for unit testing the application.</p>
<h1>For More&nbsp;Information</h1>
<p>This tutorial assumes you are familiar with the basic concepts of ASP.NET Web API. For an introductory tutorial, see
<a href="http://beta-asp.neudesic.com/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api">
Getting Started with ASP.NET Web API 2</a>.&nbsp;</p>
