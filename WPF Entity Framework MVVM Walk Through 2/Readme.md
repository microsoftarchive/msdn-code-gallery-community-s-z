# WPF: Entity Framework MVVM Walk Through 2
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- WPF
## Topics
- MVVM
- Architecture
## Updated
- 07/05/2017
## Description

<p>This article is the second in a series about architecting a Line of Business MVVM WPF application, using Entity Framework for data access.</p>
<p>You will want to read the first one and take a look at the code there if you haven&rsquo;t done so before now.</p>
<p>These things take an awful lot of work to do. This is a project of itself - complete with bugs and everything :^)</p>
<p><span style="color:#ff00ff">If you like it or learn something then please click the 5th star in the rating above. (Thanks.)</span></p>
<h1><span>Work in Progress</span></h1>
<p>This article is provisional and far from complete. &nbsp;There&rsquo;s much more to follow. The sample is of course complete.</p>
<h1>Requirements</h1>
<p>These match the previous article:</p>
<p>VS2013; EF6; MVVM Light; SQL Server ( Express will do ).</p>
<h1>SetUp</h1>
<p>You should already have the database set up from v1.&nbsp; If not then use the script in this zip file and follow the instructions from v1 to create your database.</p>
<p>If you downloaded version 1 early on then be aware that the database schema has changed slightly.&nbsp; If in doubt then drop (delete) the old database and follow the instructions in the previous article to create the database using the .sql file you will
 find in the zip file for this sample.</p>
<h1>Read These First</h1>
<p>The first step had an awful lot of content in it, mostly not too complicated but a lot to understand in one go. &nbsp;That was because you need a fair bit of code before an application can be anything like a real world WPF business application. &nbsp;Step
 1 cuts some serious corners as it is - cutting much more would have made it a bit pointless.</p>
<p>Step 2 introduces some rather more complicated coding as well as a number of structural changes. This is great because you get to see more functionality but a steeper learning curve.</p>
<p>In order to try and make all this rather easier to understand there are a couple of articles broken out which each focus on explaining an aspect of the UI design. &nbsp;Read these first and you will hopefully flatten the learning curve. &nbsp;Or at least
 avoid the need for climbing ropes and pitons to get up it.</p>
<p>Editing data works in a somewhat different way &ndash; the user works with a list of properties rather than straight in the datagrid.</p>
<p>The approach used is explained here:</p>
<p><a href="https://code.msdn.microsoft.com/Property-List-Editing-9c366b70">Property List Editing</a>.</p>
<p>CRUD usercontrols all have similar functionality in that the editing will take place in a panel.</p>
<p>Conversion errors need to be passed from view to viewmodel for it to know anything about them. All edit panels have the same base functionality which they get from a template and base viewmodel.</p>
<p>This approach is explained here:</p>
<p><a href="https://code.msdn.microsoft.com/Keeping-your-MVVM-View-DRY-00688583">Keeping Your MVVM Views DRY</a></p>
<p>&nbsp;</p>
<h1>Changes</h1>
<p>There are numerous changes between step 1 and this.</p>
<h2>Major Changes</h2>
<p>The main thing introduced in this version is simple validation.&nbsp; As you will see, the code in the base classes enabling this is far from simple.&nbsp; The good news is that base classes can be re-used in your application without having to really understand
 the detail of what&rsquo;s going on.</p>
<p>In v1 the user edited directly in the Datagrid.&nbsp;&nbsp; In practice this introduces a number of edge cases a user can leverage to mess things up in &ldquo;interesting&rdquo; ways.</p>
<p>V2 forces the user to choose a record to work on and commit or abandon that work before they are allowed to go edit some other record.</p>
<p>Users edit data in a panel which appears over the DataGrid in the parent window which whilst they work.</p>
<p>&nbsp;</p>
<h2>Minor Changes</h2>
<p>Instead of organising all ViewModels in one folder, both go under a Views folder.&nbsp; Each area of Views and their viewmodels are placed together in a folder.&nbsp; This alternative way of organising the projects is preferred by many developers.&nbsp;
 It is particularly useful for larger projects with many views where developers can easily find related components.&nbsp; Others argue that functionality built into Visual Studio now makes it so easy to find a class that there is little advantage.&nbsp; The
 convenience of browsing a folder structure comes at a very low price in overhead.</p>
<p>If you create a view or viewmodel in a folder directly then Visual Studio will use the folder structure to allocate a namespace.&nbsp; You could go with this but it will mean you have a lot of namespaces in a large project and this is often considered a
 bit of a nuisance.</p>
<p>In this project the views and viewmodels were created in the root of the project and then dragged into their folder.&nbsp; Either is valid and it&rsquo;s a matter of taste which approach you adopt. Choose one convention and stick to it.</p>
<p>&nbsp;</p>
<h1>Short Cuts</h1>
<p>This is still step 2 in a series rather than the finished enterprise ready product. &nbsp;It is still simplifying things. &nbsp;If you're a beginner you might look at the solution and think &quot;this is simple?&quot; but trust me on this one, there are still corners
 being cut. &nbsp;The layout on these forms is pretty basic. &nbsp;They're fine for static admin screens but you wouldn't use this for raising invoices or reviewing orders.</p>
