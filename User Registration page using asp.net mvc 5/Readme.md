# User Registration page using asp.net mvc 5
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- ASP.NET MVC 5
## Topics
- Authentication
## Updated
- 04/08/2015
## Description

<h1>Introduction</h1>
<p>In this article I will explain how to build a simple user registration form that will allow user to register using&nbsp;ASP.Net mvc5.</p>
<p>User will fill up the registration form with details such as username, password, email address, etc. and these details will be saved in the database table.</p>
<p><span style="font-size:2em">Building the Sample</span></p>
<p>For this article I have created a new database named&nbsp;<span style="text-decoration:underline">Users&nbsp;</span>which contains the following table named Demo_Registration&nbsp;in it.</p>
<p><strong>STEP-1: CREATE TABLE FOR SAVE DATA.</strong></p>
<p>Open Database &gt; Right Click on Table &gt; Add New Table &gt; Add Columns &gt; Save &gt; Enter table name &gt; Ok.&nbsp;<br>
In this example, I have used one tables as below</p>
<p><img id="136118" src="136118-dara.png" alt="" width="446" height="322"></p>
<p><strong>STEP-2: ADD ENTITY DATA MODEL.</strong></p>
<p>Go to Solution Explorer &gt; Right Click on Project name form Solution Explorer &gt; Add &gt; New item &gt; Select ADO.net Entity Data Model under data &gt; Enter model name &gt; Add.<br>
A popup window will come (Entity Data Model Wizard) &gt; Select Generate from database &gt; Next &gt;<br>
Chose your data connection &gt; select your database &gt; next &gt; Select tables &gt; enter Model Namespace &gt; Finish.&nbsp;</p>
<p>&nbsp;</p>
<p><strong>STEP-3: CREATE A CONTROLLER .</strong></p>
<p>Go to Solution Explorer &gt; Right Click on Controllers folder form Solution Explorer &gt; Add &gt; Controller &gt; Enter Controller name &gt; Select Templete &quot;empty MVC Controller&quot;&gt; Add.</p>
<div class="scriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifier&nbsp;le&nbsp;script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace RegisterMVC5.Controllers 
{ 
    public class UserController : Controller 
    { 
        // 
        // GET: /User/ 
        public ActionResult Register() 
        { 
            return View(); 
        }
</pre>
<div class="preview">
<pre class="js">namespace&nbsp;RegisterMVC5.Controllers&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;UserController&nbsp;:&nbsp;Controller&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;/User/&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ActionResult&nbsp;Register()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<p><strong>STEP-4: ADD NEW ACTION INTO YOUR CONTROLLER FOR GET METHOD</strong></p>
<p>Here I have added &quot;Register&quot; Action into &quot;User&quot; Controller.</p>
<p><strong>STEP-5: ADD VIEW FOR YOUR ACTION (REGISTER) &amp; DESIGN FOR CREATE REGISTER FORM</strong></p>
<p><img id="136115" src="136115-sss.png" alt="" width="502" height="447"></p>
<p><strong>STEP-6: ADD NEW ACTION INTO YOUR CONTROLLER FOR POST METHOD (FOR REGISTER)</strong></p>
<p>Here I have added &quot;Register&quot; Action with Model Parameter (here &quot;User&quot;) into &quot;User&quot; Controller.</p>
<div>
<p>using&nbsp;System;&nbsp;</p>
<p>using&nbsp;System.Collections.Generic;&nbsp;</p>
<p>using&nbsp;System.Linq;&nbsp;</p>
<p>using&nbsp;System.Web;&nbsp;</p>
<p>using&nbsp;System.Web.Mvc;&nbsp;</p>
<p>&nbsp;</p>
<p>namespace&nbsp;RegisterMVC5.Controllers&nbsp;</p>
<p>{&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;publicclass&nbsp;UserController&nbsp;:&nbsp;Controller&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;////&nbsp;GET:&nbsp;/User/public&nbsp;ActionResult&nbsp;Register()&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;View();&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ValidateAntiForgeryToken]&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ActionResult&nbsp;Register(Demo_Registration&nbsp;U)&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if&nbsp;(ModelState.IsValid)&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(UsersEntities&nbsp;dc&nbsp;=&nbsp;new&nbsp;UsersEntities())&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dc.Demo_Registration.Add(U);&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dc.SaveChanges();&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ModelState.Clear();&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;U&nbsp;=&nbsp;null;&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Message&nbsp;=&nbsp;&quot;Successfully&nbsp;Registration&nbsp;Done&quot;;&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;View(U);&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</p>
<p>}</p>
</div>
<p><strong>STEP-7: RUN APPLICATION.</strong></p>
<p>&nbsp;<img id="136116" src="136116-capture.png" alt=""></p>
<p>Now try to verify if the user has been added or no ??</p>
<p>&nbsp;<img id="136117" src="136117-capture1.png" alt=""></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>Closing Notes</strong></p>
<p><em>I hope you enjoyed this article. I tried to make this as simple as I can. If you like this article, please rate it and share it to share the knowledge.</em></p>
<p>BARHOUMI Haythem</p>
<p>&nbsp;</p>
</div>
</div>
<h1>Source Code Files</h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em>source code file name #2 - summary for this source code file.</em> </li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
