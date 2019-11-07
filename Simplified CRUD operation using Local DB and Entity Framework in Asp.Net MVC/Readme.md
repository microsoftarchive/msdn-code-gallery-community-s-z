# Simplified CRUD operation using Local DB and Entity Framework in Asp.Net MVC.
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- ASP.NET MVC
## Topics
- crud operations in mvc4
## Updated
- 09/04/2016
## Description

<h1>Introduction</h1>
<p><em>In this code sample we will see CRUD operation using Local DB</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>You need to instal visual studio 2010 or above. For my project i am using Visual studio 2013</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Open this project using Visual studio&nbsp; and then diretcly go to the BookController and inside book contoller you find all the action method. To the corresponidg page you can right on action method and click on go to view page; then it will navigate you
 to that page.</p>
<p>If you want to see local db file inside solution explorer then click on show on file on the top. Because it by defult in hidden mode.</p>
<p>Inside the project i am using Book.cs file as my model and using that class i am doing all database operation.</p>
<p>Inside that class also you find the BookDB Datacontext class.</p>
<p>The DataContext class used in this project to do the operation using code first approch using entity framewok</p>
<p>In this project we are usiing code first database migration for our local DB .</p>
<p>This project comes with migration enabled.</p>
<p>Inside the project use of BookDBContextClass is to make DB operations using that class object. Due to this class inherited from DbContext class it&rsquo;s allows us to access all the method of Dbcontext class.</p>
<p>DbContext class is specially designed for to work with DB operation using Codefirst approach.</p>
<p>&nbsp;</p>
<p>Note :-Here We inherited BookDBContext class Explicilty form DbContext class because we are not going to use any Entity Framework template to generate the code implicitly.So we write all the code manually.</p>
<p>I am going to publish articles on this very soon. If you unable to understand what i am doing inside the project then wait for few days i am going to publish a articles which guide you.</p>
<p>Inside BookDBContext class we have BookLst property of type Dbset which going to return list of Book.</p>
<p>Now Build your project -&gt; <strong>Ctrl&#43;shift&#43;B</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDDemo.Models
{
    public class BookModel
    {
public int Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public DateTime PublishDate { get; set; }
    }
    //BookDBContext inherited form DBContext Class.
    //This Class helps us to work with LocalDatabase.
    //Remember the localDB connnectiostring by deuflt congigured with application once you created the DBContext Class.
    //This connctions string present under Configure.cs file.
    
    public class BookDBContext : DbContext
    {
        public DbSet&lt;BookModel&gt; BookLst { get; set; }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.Entity;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;CRUDDemo.Models&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;BookModel&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;BookName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;AuthorName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;PublishDate&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//BookDBContext&nbsp;inherited&nbsp;form&nbsp;DBContext&nbsp;Class.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//This&nbsp;Class&nbsp;helps&nbsp;us&nbsp;to&nbsp;work&nbsp;with&nbsp;LocalDatabase.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Remember&nbsp;the&nbsp;localDB&nbsp;connnectiostring&nbsp;by&nbsp;deuflt&nbsp;congigured&nbsp;with&nbsp;application&nbsp;once&nbsp;you&nbsp;created&nbsp;the&nbsp;DBContext&nbsp;Class.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//This&nbsp;connctions&nbsp;string&nbsp;present&nbsp;under&nbsp;Configure.cs&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;BookDBContext&nbsp;:&nbsp;DbContext&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DbSet&lt;BookModel&gt;&nbsp;BookLst&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
