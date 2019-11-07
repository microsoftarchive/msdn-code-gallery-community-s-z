# TDD With MVC 5 and Entity Framework and Repository pattern
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- SQL Server
- Entity Framework Code First
- Unity
- ASP.NET MVC 5
- Entity Framework 6
- Moq
## Topics
- Unit Testing
- Repository Pattern
- TDD in .NET
- TDD with MVC 5
- TDD with service layer
- Moq with MVC 5
## Updated
- 09/07/2015
## Description

<h1>Introduction</h1>
<p><em>This Code sample illustrates how we can use Test driven developement with MVC and Entity frame work (services)</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>We Just need to resolve missing dependencies using nuget packagemanager, update database path in webconfig.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>&nbsp;<span>Test-driven development</span><span>&nbsp;(</span><span>TDD</span><span>) is a software development process that relies on the repetition of a very short development cycle: first the developer writes an (initially failing) automated test
 case that defines a desired improvement or new function, then produces the minimum amount of code to pass that test.</span></em></p>
<p><em><span><span>ASP.NET MVC application provide a very good support for TDD because we can write unit test directly against our controllers without needing any web server in seperate project.</span><br>
</span></em></p>
<div><strong><em>What we can test in controller :</em></strong></div>
<p><em><span>&nbsp;Whether a controller action returns a particular view, returns a particular set of data, or returns a different type of action result,&nbsp;<span>whether or not one controller action redirects you to a second controller action.</span></span></em></p>
<p>&nbsp;</p>
<p><em>This sample includes following :</em></p>
<ul>
<li><em>&nbsp;TDD with MVC (using inbuilt templates provided by VS2013).</em> </li><li><em>&nbsp;TDD for service layer (using moq).</em> </li><li><em>&nbsp;Repository pattern with MVC framework</em> </li><li><em>&nbsp;Onion architecture &nbsp;sample&nbsp;with MVC and entity framework.</em>
</li></ul>
<p><em>&nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">//////// Service layer///// 

[TestMethod]
        public void GetContact_Given_id_ExpectContactReturned()
        {
            int id = 2;
            var stubData = (new List&lt;Contact&gt;
            {
                new Contact()
                {
                    Id = 1,
                    FirstName = &quot;Rohit&quot;,
                    LastName = &quot;Jain&quot;
                },
                new Contact()
                {
                    Id = 2,
                    FirstName = &quot;Arun&quot;,
                    LastName = &quot;Khanna&quot;
                }
            }).AsQueryable();
            SetupTestData(stubData, _mockContacts);

            var actual = _contactService.GetContact(id);

            Assert.AreEqual(stubData.ToList()[1], actual);
        }


/////////////////Controller////////////////////

 [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">////////&nbsp;Service&nbsp;layer/////&nbsp;</span>&nbsp;
&nbsp;
[TestMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;GetContact_Given_id_ExpectContactReturned()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;id&nbsp;=&nbsp;<span class="cs__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;stubData&nbsp;=&nbsp;(<span class="cs__keyword">new</span>&nbsp;List&lt;Contact&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Contact()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Id&nbsp;=&nbsp;<span class="cs__number">1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FirstName&nbsp;=&nbsp;<span class="cs__string">&quot;Rohit&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LastName&nbsp;=&nbsp;<span class="cs__string">&quot;Jain&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Contact()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Id&nbsp;=&nbsp;<span class="cs__number">2</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FirstName&nbsp;=&nbsp;<span class="cs__string">&quot;Arun&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LastName&nbsp;=&nbsp;<span class="cs__string">&quot;Khanna&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AsQueryable();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetupTestData(stubData,&nbsp;_mockContacts);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;actual&nbsp;=&nbsp;_contactService.GetContact(id);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(stubData.ToList()[<span class="cs__number">1</span>],&nbsp;actual);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
<span class="cs__com">/////////////////Controller////////////////////</span>&nbsp;
&nbsp;
&nbsp;[TestMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Arrange</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HomeController&nbsp;controller&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HomeController();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Act</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewResult&nbsp;result&nbsp;=&nbsp;controller.Index()&nbsp;<span class="cs__keyword">as</span>&nbsp;ViewResult;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Assert</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsNotNull(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<h3><strong><span style="font-size:2em">More Information</span></strong></h3>
<p><em>Useful links :</em></p>
<p><em>&nbsp;</em></p>
<ul>
<li><em><em><a href="http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application">Entity Framework 6 Code First using MVC 5</a></em></em>
</li><li><em><em><a href="http://www.asp.net/mvc/overview/older-versions-1/unit-testing/creating-unit-tests-for-asp-net-mvc-applications-cs">Unit Tests for ASP.NET MVC Applications</a></em></em>
</li><li><em><a href="https://visualstudiomagazine.com/articles/2015/05/20/tdd-asp-net-mvc-part-3.aspx">TDD for ASP.NET MVC
</a></em></li></ul>
<p><em>&nbsp;</em></p>
<p>&nbsp;</p>
<p><em><br>
</em></p>
