# Using MVC3 and jQuery to allow inline creation of dependent entities.
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- jQuery
- ASP.NET MVC 3
## Topics
- AJAX
## Updated
- 11/19/2014
## Description

<h2>Introduction</h2>
<p>While building a new website for a band recently, I came across a small problem.&nbsp; The model defined two entities, Gig and Venue, and that each Gig must have a Venue &ndash; which implies that the Venue must exist before the gig.&nbsp; Of course, the
 only time a venue will be added is when a Gig for that Venue is created.</p>
<p>I didn't want the band members, all of whom could add a gig, to have to consider the logical constraints of the model before using the website to add a Gig but neither did I want to break the model.&nbsp; Historically this might have been addressed using
 a 'wizard' where the user would select or create a venue first but I don't like wizards (outside of installation routines) and they don't seem very, well, MVC-ish.</p>
<p>What I wanted was some way to allow a user, while creating a Gig to select a Venue or, in the event that it didn't exist, create a new Venue.&nbsp; Liking to think of myself as a modern web developer, the solution should:</p>
<ul>
<li>not be implementation specific (should not be limited to Gigs and Venues) </li><li>not impede the existing functionality (like validation) </li><li>adhere to the principles of Progressive Enhancement. </li></ul>
<h2>Building the Sample</h2>
<p>This sample extends the MvcMusicStore MVC3 application (v3.0b), all prerequisites are the same.</p>
<p>If you are trying to follow the steps in this sample start from the MvcMusicStore download, you'll need to update the jQuery reference in the _Layouts.cshtml file under Views &gt; Shared.</p>
<p>change...</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;script&nbsp;src=<span class="js__string">&quot;@Url.Content(&quot;</span>~<span class="js__reg_exp">/Scripts/</span>jQuery<span class="js__num">-1.4</span><span class="js__num">.4</span>.min.js<span class="js__string">&quot;)&quot;</span>&nbsp;type=<span class="js__string">&quot;text/Javascript&quot;</span>&gt;&lt;/script&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;to..</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;script&nbsp;src=<span class="js__string">&quot;@Url.Content(&quot;</span>~<span class="js__reg_exp">/Scripts/</span>jQuery<span class="js__num">-1.5</span><span class="js__num">.1</span>.min.js<span class="js__string">&quot;)&quot;</span>&nbsp;type=<span class="js__string">&quot;text/Javascript&quot;</span>&gt;&lt;/script&gt; <br></pre>
</div>
</div>
</div>
<div class="endscriptcode"><br>
<h2>Description</h2>
<p>This sample demonstrates one approach to dealing with completing form where a dependent entity does not yet exist.&nbsp; In the case of the MVCMusicStore, I'm going to apply this functionality to the Create Album form within the Admin which have Genre and
 Artist related entities.</p>
<p>To access the Create Album form, click on the Admin link at the top right which will prompt you to login (username = Administrator, password = password123!) and then click the Create New link above the list of Albums.</p>
<h2>Identifying the elements</h2>
<p>Applying this feature to all dropdown lists would be overkill so we need a filter mechanism.&nbsp; It makes sense that the dropdown lists where this would be most appropriate are those that are mandatory and, using Entity Framework, MVC3 and jQuery, this
 is almost done for you.</p>
</div>
<div class="endscriptcode">First, we need to update the Album model class to make the Genre property a required field.
<p>Open the Album.cs file under Models and add the [Required] attribute to the GenreId property.</p>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">[DisplayName(<span class="js__string">&quot;Genre&quot;</span>)]&nbsp;
<span style="background-color:#ffff99">[Required]</span>&nbsp;
public&nbsp;int&nbsp;GenreId&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<p>Now update the Create View for the StoreManager.</p>
<p>Open the Create file under Views &gt; StoreManager and update to match the following snippet.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;div&nbsp;class=<span class="js__string">&quot;editor-field&quot;</span>&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;@Html.Dropdown&nbsp;list&nbsp;For(model&nbsp;=&gt;&nbsp;model.GenreId,&nbsp;((IEnumerable&lt;MvcMusicStore.Models.Genre&gt;)ViewBag.PossibleGenres).Select(option&nbsp;=&gt;&nbsp;<span class="js__operator">new</span>&nbsp;SelectListItem&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;(option&nbsp;==&nbsp;null&nbsp;?&nbsp;<span class="js__string">&quot;None&quot;</span>&nbsp;:&nbsp;option.Name),&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value&nbsp;=&nbsp;option.GenreId.ToString(),&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Selected&nbsp;=&nbsp;(Model&nbsp;!=&nbsp;null)&nbsp;&amp;&amp;&nbsp;(option.GenreId&nbsp;==&nbsp;Model.GenreId)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>),&nbsp;<span class="js__string">&quot;Choose...&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;@Html.ValidationMessageFor(model&nbsp;=&gt;&nbsp;model.GenreId)&nbsp;&nbsp;
&lt;/div&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<p>The Dropdown list For helper method is aware of the DataAnnotation attributes, like Required, and will automatically add html attributes representing the DataAnnotation attributes. It doesn&rsquo;t, however, accept a SelectList object as an argument, so
 we need to modify the Controller so that it will pass all the possible Genres to the View.</p>
<p>Open the StoreManagerController.cs file under Controllers and change the Create action method as shown below.</p>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;GET:&nbsp;/StoreManager/Create</span>&nbsp;
&nbsp;
public&nbsp;ActionResult&nbsp;Create()&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;ViewBag.PossibleGenres&nbsp;=&nbsp;db.Genres.ToList();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;ViewBag.ArtistId&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SelectList(db.Artists,&nbsp;<span class="js__string">&quot;ArtistId&quot;</span>,&nbsp;<span class="js__string">&quot;Name&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View();&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<p>Now when the View is rendered, the select element will have a number of html5 data-* attributes representing validation information.</p>
</div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;select&nbsp;name=<span class="js__string">&quot;GenreId&quot;</span>&nbsp;class=<span class="js__string">&quot;input-validation-error&quot;</span>id=<span class="js__string">&quot;GenreId&quot;</span>&nbsp;data-val-required=<span class="js__string">&quot;The&nbsp;Genre&nbsp;field&nbsp;is&nbsp;required.&quot;</span>&nbsp;data-val=<span class="js__string">&quot;true&quot;</span>&nbsp;data-val-number=<span class="js__string">&quot;The&nbsp;field&nbsp;Genre&nbsp;must&nbsp;be&nbsp;a&nbsp;number.&quot;</span>&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<h2>Creating the client side script</h2>
<p>Add a new Javascript file to the Scripts folder and name it &quot;MvcMusicStore.js&quot;.</p>
</div>
<div class="endscriptcode">
<p>The blank Javascript file will be opened.&nbsp; Add the following code to the file.</p>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">(<span class="js__operator">function</span>&nbsp;(MvcMusicStore,&nbsp;$,&nbsp;<span class="js__property">undefined</span>)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="js__brace">}</span>)(window.MvcMusicStore&nbsp;=&nbsp;window.MvcMusicStore&nbsp;||&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>,&nbsp;jQuery);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><br>
<p>This is the basic self-executing anonymous function, a common mechanism to add script to your site without contaminating the global namespace.</p>
<p>Add a function and call it when the after the page has finished loading.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">(<span class="js__operator">function</span>&nbsp;(MvcMusicStore,&nbsp;$,&nbsp;<span class="js__property">undefined</span>)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;declare&nbsp;function&nbsp;on&nbsp;our&nbsp;MvcMusicStore&nbsp;object&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;MvcMusicStore.AppendAddButtons&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;woohoo!&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="js__brace">}</span>)(window.MvcMusicStore&nbsp;=&nbsp;window.MvcMusicStore&nbsp;||&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>,&nbsp;jQuery);&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="js__sl_comment">//&nbsp;call&nbsp;function&nbsp;after&nbsp;document&nbsp;has&nbsp;finished&nbsp;loading&nbsp;</span>&nbsp;
$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;MvcMusicStore.AppendAddButtons();&nbsp;&nbsp;
<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Update the&nbsp;Create View for the StoreManager folder file to include a reference to the Javascript file</div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">@model&nbsp;MvcMusicStore.Models.Album&nbsp;&nbsp;
&nbsp;&nbsp;
@<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;<span class="js__string">&quot;Create&quot;</span>;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&lt;h2&gt;Create&lt;/h2&gt;&nbsp;&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;@Url.Content(&quot;</span>~<span class="js__reg_exp">/Scripts/</span>jQuery.validate.min.js<span class="js__string">&quot;)&quot;</span>&nbsp;type=<span class="js__string">&quot;text/Javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;@Url.Content(&quot;</span>~<span class="js__reg_exp">/Scripts/</span>jQuery.validate.unobtrusive.min.js<span class="js__string">&quot;)&quot;</span>&nbsp;type=<span class="js__string">&quot;text/Javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;@Url.Content(&quot;</span>~<span class="js__reg_exp">/Scripts/</span>MvcMusicStore.js<span class="js__string">&quot;)&quot;</span>&nbsp;type=<span class="js__string">&quot;text/Javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;&nbsp;
&nbsp;&nbsp;
@using&nbsp;(Html.BeginForm())&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
...&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
Run the site to check everything is working and you should see an alert box confirming the function is running.</div>
</div>
<p><img src="57018-snag-0012.png" alt="" width="664" height="394"></p>
<p>&nbsp;</p>
<p>Replace the line &quot;alert(&quot;woohoo!&quot;);&quot; with the highlighted code below which will use jQuery to create and append a button to the matched elements.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">(<span class="js__operator">function</span>&nbsp;(MvcMusicStore,&nbsp;$,&nbsp;<span class="js__property">undefined</span>)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;MvcMusicStore.AppendAddButtons&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;find&nbsp;select&nbsp;elements&nbsp;with&nbsp;a&nbsp;data-val-required&nbsp;attribute&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;select[data-val-required]&quot;</span>).each(<span class="js__operator">function</span>&nbsp;(index,&nbsp;element)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).after(&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;&lt;input/&gt;&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.attr(<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;type&quot;</span>:&nbsp;<span class="js__string">&quot;button&quot;</span>,&nbsp;<span class="js__string">&quot;value&quot;</span>:&nbsp;<span class="js__string">&quot;Add&quot;</span>&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.addClass(<span class="js__string">&quot;button&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.css(<span class="js__brace">{</span><span class="js__string">&quot;margin-left&quot;</span>:<span class="js__num">5</span><span class="js__brace">}</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="js__brace">}</span>)(window.MvcMusicStore&nbsp;=&nbsp;window.MvcMusicStore&nbsp;||&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>,&nbsp;jQuery);&nbsp;&nbsp;
&nbsp;&nbsp;
$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;MvcMusicStore.AppendAddButtons();&nbsp;&nbsp;
<span class="js__brace">}</span>);&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">and the web page should now look like this</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="67982" src="67982-snag-0013.png" alt="" width="642" height="442"></div>
<p>&nbsp;</p>
<p><strong>Displaying a form</strong></p>
<p>Ok, so now we have a button beside each of our manadatory select elements.&nbsp; Now we need to have it respond to a click.&nbsp; jQuery comes to our aid once again, providing both a simple method of attaching an event handler using the click method and
 displaying a dialog.</p>
<p>The jQuery dialog requires the jQuery UI library, so add a reference to the jQueryUi library and stylesheet to the _Layouts.cshtml file.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;@ViewBag.Title&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;href=<span class="js__string">&quot;@Url.Content(&quot;</span>~<span class="js__reg_exp">/Content/</span>Site.css<span class="js__string">&quot;)&quot;</span>&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type=<span class="js__string">&quot;text/css&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;@Url.Content(&quot;</span>~<span class="js__reg_exp">/Scripts/</span>jQuery<span class="js__num">-1.5</span><span class="js__num">.1</span>.min.js<span class="js__string">&quot;)&quot;</span>&nbsp;type=<span class="js__string">&quot;text/Javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&lt;!--&nbsp;jQuery&nbsp;ui&nbsp;--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;@Url.Content(&quot;</span>~<span class="js__reg_exp">/Scripts/</span>jQuery-ui<span class="js__num">-1.8</span><span class="js__num">.11</span>.min.js<span class="js__string">&quot;)&quot;</span>&nbsp;type=<span class="js__string">&quot;text/Javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;link&nbsp;href=<span class="js__string">&quot;@Url.Content(&quot;</span>~<span class="js__reg_exp">/Content/</span>themes/base/jQuery.ui.all.css<span class="js__string">&quot;)&quot;</span>&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;type=<span class="js__string">&quot;text/css&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;
&lt;/head&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Update the MvcMusicStore .js file to show a dialog.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;find&nbsp;select&nbsp;elements&nbsp;with&nbsp;a&nbsp;data-val-required&nbsp;attribute&nbsp;</span>&nbsp;
$(<span class="js__string">&quot;select[data-val-required]&quot;</span>).each(<span class="js__operator">function</span>&nbsp;(index,&nbsp;element)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).after(&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;&lt;input/&gt;&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.attr(<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;type&quot;</span>:&nbsp;<span class="js__string">&quot;button&quot;</span>,&nbsp;<span class="js__string">&quot;value&quot;</span>:&nbsp;<span class="js__string">&quot;Add&quot;</span>&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.addClass(<span class="js__string">&quot;button&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.css(<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;margin-left&quot;</span>:&nbsp;<span class="js__num">5</span>&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;newDialog&nbsp;=&nbsp;$(<span class="js__string">&quot;&lt;div&gt;&lt;/div&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newDialog.dialog(<span class="js__brace">{</span><span class="js__string">&quot;width&quot;</span>:<span class="js__num">320</span><span class="js__brace">}</span>);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Now the click button will open a dialog window.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="67983" src="67983-snag-0014.png" alt="" width="644" height="372"></div>
<div class="endscriptcode"></div>
We want to populate the dialog with a form for a new Genre &ndash; MvcMusicStore doesn&rsquo;t have any capability for managing Genres so we have to create this from scratch.<span>&nbsp;
</span>Visual Studio will, helpfully, create all the views for us.<span> </span>
<p>&nbsp;</p>
</div>
<div class="endscriptcode">Add a Controller for the Genre entity.</div>
<div class="endscriptcode"><img id="67984" src="67984-snag-0015.png" alt="" width="829" height="610"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">The Add Controller dialog will be displayed.<span>&nbsp;
</span>Complete the dialog as shown below</div>
<div class="endscriptcode"><img id="67985" src="67985-snag-0016.png" alt="" width="604" height="394"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Click Add.&nbsp;Visual Studio will generate and add a GenreController.cs file under Controllers and several .cshtml files in a Genre folder under Views.</div>
<p><img id="67986" src="67986-snag-0018.png" alt="" width="315" height="539" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>Now that we have a Controller and some Views for the Genre entity, we can request the View via Ajax and populate the dialog.<br>
<br>
Update the MvcMusicStore.js as show below.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;find&nbsp;select&nbsp;elements&nbsp;with&nbsp;a&nbsp;data-val-required&nbsp;attribute&nbsp;</span>&nbsp;
$(<span class="js__string">&quot;select[data-val-required]&quot;</span>).each(<span class="js__operator">function</span>&nbsp;(index,&nbsp;element)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).after(&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;&lt;input/&gt;&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.attr(<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;type&quot;</span>:&nbsp;<span class="js__string">&quot;button&quot;</span>,&nbsp;<span class="js__string">&quot;value&quot;</span>:&nbsp;<span class="js__string">&quot;Add&quot;</span>&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.addClass(<span class="js__string">&quot;button&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.css(<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;margin-left&quot;</span>:&nbsp;<span class="js__num">5</span>&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;/Genre/Create&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;type&quot;</span>:&nbsp;<span class="js__string">&quot;GET&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;contentType&quot;</span>:&nbsp;<span class="js__string">&quot;text/html;&nbsp;charset=utf-8&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;success&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(data,&nbsp;textStatus,&nbsp;jqXHR)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;newDialog&nbsp;=&nbsp;$(<span class="js__string">&quot;&lt;div&gt;&lt;/div&gt;&quot;</span>),&nbsp;newDialogContent&nbsp;=&nbsp;$(<span class="js__string">&quot;&lt;div&gt;&lt;/div&gt;&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newDialog.append(newDialogContent);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newDialogContent.html($(<span class="js__string">&quot;&lt;form&gt;&lt;/form&gt;&quot;</span>).html(data));&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newDialog.dialog(<span class="js__brace">{</span><span class="js__string">&quot;width&quot;</span>:<span class="js__num">320</span><span class="js__brace">}</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;statusCode&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">401</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unauthorised&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">404</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Not&nbsp;found&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;error&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(jqXHR,&nbsp;textStatus,&nbsp;errorThrown)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>&nbsp;&amp;&amp;&nbsp;jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>)<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unhandled&nbsp;error:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;errorThrown);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">If you run the application now, you will notice that the entire page is loaded, including the title and navigation, when all we really want is the form itself.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="67987" src="67987-snag-0019.png" alt="" width="664" height="577"></div>
<p>To fix this, we need to create a partial class for the View and modify the Genre Controller.</p>
<p>Create a PartialView for the Genre Controller.</p>
<p><img id="67988" src="67988-snag-0020.png" alt="" width="664" height="552"></p>
<p>The Add View Dialog will be displayed.&nbsp; Complete the dialog as shown below</p>
<p><img id="67989" src="67989-snag-0021.png" alt="" width="511" height="502" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>Click Add.&nbsp; Visual Studio will generate and add a _Create.cshtml file under Views.&nbsp; This file will be opened and will look like this:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">@model&nbsp;MvcMusicStore.Models.Genre&nbsp;
&nbsp;
@using&nbsp;(Html.BeginForm())&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Html.ValidationSummary(true)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;fieldset&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;legend&gt;Genre&lt;/legend&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;editor-label&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.LabelFor(model&nbsp;=&gt;&nbsp;model.Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;editor-field&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.EditorFor(model&nbsp;=&gt;&nbsp;model.Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.ValidationMessageFor(model&nbsp;=&gt;&nbsp;model.Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;editor-label&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.LabelFor(model&nbsp;=&gt;&nbsp;model.Description)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;editor-field&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.EditorFor(model&nbsp;=&gt;&nbsp;model.Description)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.ValidationMessageFor(model&nbsp;=&gt;&nbsp;model.Description)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;submit&quot;</span>&nbsp;value=<span class="js__string">&quot;Create&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/fieldset&gt;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Html.ActionLink(<span class="js__string">&quot;Back&nbsp;to&nbsp;List&quot;</span>,&nbsp;<span class="js__string">&quot;Index&quot;</span>)&nbsp;
&lt;/div&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">However, we&rsquo;ve now got two different forms for creating a Genre which may be changed independently.&nbsp; To avoid this, change the PartialView to look like this&hellip;</div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">@model&nbsp;MvcMusicStore.Models.Genre&nbsp;&nbsp;
&nbsp;
&lt;div&nbsp;class=<span class="js__string">&quot;editor-label&quot;</span>&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;@Html.LabelFor(model&nbsp;=&gt;&nbsp;model.Description)&nbsp;&nbsp;
&lt;/div&gt;&nbsp;&nbsp;
&lt;div&nbsp;class=<span class="js__string">&quot;editor-field&quot;</span>&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;@Html.EditorFor(model&nbsp;=&gt;&nbsp;model.Description)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;@Html.ValidationMessageFor(model&nbsp;=&gt;&nbsp;model.Description)&nbsp;&nbsp;
&lt;/div&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&hellip;and then change the Create View to look like this:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">@model&nbsp;MvcMusicStore.Models.Genre&nbsp;&nbsp;
&nbsp;&nbsp;
@<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;<span class="js__string">&quot;Create&quot;</span>;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&lt;h2&gt;Create&lt;/h2&gt;&nbsp;&nbsp;
&nbsp;&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;@Url.Content(&quot;</span>~<span class="js__reg_exp">/Scripts/</span>jQuery.validate.min.js<span class="js__string">&quot;)&quot;</span>&nbsp;type=<span class="js__string">&quot;text/Javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;&nbsp;
&lt;script&nbsp;src=<span class="js__string">&quot;@Url.Content(&quot;</span>~<span class="js__reg_exp">/Scripts/</span>jQuery.validate.unobtrusive.min.js<span class="js__string">&quot;)&quot;</span>&nbsp;type=<span class="js__string">&quot;text/Javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;&nbsp;
&nbsp;&nbsp;
@using&nbsp;(Html.BeginForm())&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Html.ValidationSummary(true)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;fieldset&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;legend&gt;Genre&lt;/legend&gt;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.Partial(<span class="js__string">&quot;_Create&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;submit&quot;</span>&nbsp;value=<span class="js__string">&quot;Create&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/p&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/fieldset&gt;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&lt;div&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;@Html.ActionLink(<span class="js__string">&quot;Back&nbsp;to&nbsp;List&quot;</span>,&nbsp;<span class="js__string">&quot;Index&quot;</span>)&nbsp;&nbsp;
&lt;/div&gt;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
</div>
<div class="endscriptcode">Now that we have a PartialView, we can request just the PartialView from the Controller.&nbsp; Modify the controller as follows</div>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;GET:&nbsp;/Genre/Create&nbsp;</span>&nbsp;
&nbsp;&nbsp;
public&nbsp;ActionResult&nbsp;Create()&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(Request.IsAjaxRequest())&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;PartialView(<span class="js__string">&quot;_Create&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View();&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Using the IsAjaxRequest method on the Request object allows us to differentiate between a standard request and an Ajax request.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Save, Build and Run the application.&nbsp; Now when you click the Add button, you should see the following</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img src="57033-snag-0024.png" alt="" style="display:block; margin-left:auto; margin-right:auto"></div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="67990" src="67990-snag-0024.png" alt="" width="664" height="423"></div>
<p class="endscriptcode">&nbsp;</p>
<h2>Saving the form</h2>
<p>The form is displayed correctly in the dialog but, having altered the PartialView, we have no method of submitting the form.&nbsp; This isn&rsquo;t so bad as we want to manage the saving of this form and whether it succeeded or not.<br>
<br>
The jQuery dialog allows buttons to be added along with functions to manage the click event of these buttons.</p>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$.ajax(&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;/Genre/Create&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;type&quot;</span>:&nbsp;<span class="js__string">&quot;GET&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;contentType&quot;</span>:&nbsp;<span class="js__string">&quot;text/html;&nbsp;charset=utf-8&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;success&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(data,&nbsp;textStatus,&nbsp;jqXHR)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;newDialog&nbsp;=&nbsp;$(<span class="js__string">&quot;&lt;div&gt;&lt;/div&gt;&quot;</span>),&nbsp;newDialogContent&nbsp;=&nbsp;$(<span class="js__string">&quot;&lt;div&gt;&lt;/div&gt;&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newDialog.append(newDialogContent);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newDialogContent.html($(<span class="js__string">&quot;&lt;form&gt;&lt;/form&gt;&quot;</span>).html(data));&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;dialogButtons&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;save&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;save&nbsp;button&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;cancel&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;cancel&nbsp;button&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newDialog.dialog(<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;width&quot;</span>:&nbsp;<span class="js__num">335</span>,&nbsp;buttons:&nbsp;dialogButtons<span class="js__brace">}</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;statusCode&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">401</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unauthorised&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">404</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Not&nbsp;found&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;error&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(jqXHR,&nbsp;textStatus,&nbsp;errorThrown)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>&nbsp;&amp;&amp;&nbsp;jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>)<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unhandled&nbsp;error:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;errorThrown);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">This will add two buttons, save and cancel, to the dialog.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="67991" src="67991-snag-0025.png" alt="" width="664" height="356"></div>
<div class="endscriptcode">Using jQuery, we can retrieve and serialize the form data and then, using the same $.ajax method as before, POST it back to the webserver to be saved.&nbsp;
<br>
<br>
Update the dialogButtons object definition as show below:</div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;dialogButtons&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;save&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;form&nbsp;=&nbsp;$(<span class="js__operator">this</span>).dialog(<span class="js__string">&quot;widget&quot;</span>).find(<span class="js__string">&quot;form&quot;</span>),&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;postData&nbsp;=&nbsp;form.serialize();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dialog&nbsp;=&nbsp;<span class="js__operator">this</span>;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__string">&quot;/Genre/Create&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;type&quot;</span>:&nbsp;<span class="js__string">&quot;POST&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;postData,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;success&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(data,&nbsp;textStatus,&nbsp;jqXHR)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Save&nbsp;succeeded!&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;statusCode&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">404</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Not&nbsp;found&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">401</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unauthorised&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;error&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(jqXHR,&nbsp;textStatus,&nbsp;errorThrown)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>&nbsp;&amp;&amp;&nbsp;jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>)<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unhandled&nbsp;error:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;errorThrown);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;cancel&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).dialog(<span class="js__string">&quot;close&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><img id="67993" src="67993-snag-0028.png" alt="" width="664" height="354"></div>
<div class="endscriptcode">Opening a new browser window / tab confirms the new Genre has been saved</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="67994" src="67994-snag-0029.png" alt="" width="664" height="36"></div>
<div class="endscriptcode"></div>
</div>
<p><img id="67995" src="67995-snag-0030.png" alt="" width="566" height="392"></p>
<h2>Processing the response</h2>
<p>Having created our new genre, we want to be able to select it from the Genre dropdown list but it's not there.&nbsp; We need to add an option to the dropdown list and it needs to represent the genre we've just created.<br>
<br>
We can use the IsAjaxRequest() method again to tailor the response from the Create action for Ajax requests to return a json representation of the newly created entity&hellip;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;POST:&nbsp;/Genre/Create&nbsp;</span>&nbsp;
&nbsp;&nbsp;
[HttpPost]&nbsp;&nbsp;
<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Create(Genre&nbsp;genre)&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ModelState.IsValid)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Genres.Add(genre);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.SaveChanges();&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Request.IsAjaxRequest())&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Json(genre);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(genre);&nbsp;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&hellip;which is passed to the success function in our Ajax request.&nbsp; We can now create an option in the dropdown list&nbsp; for our new entity.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$.ajax(<span class="js__string">&quot;/Genre/Create&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;type&quot;</span>:&nbsp;<span class="js__string">&quot;POST&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;postData,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;success&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(data,&nbsp;textStatus,&nbsp;jqXHR)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;element&nbsp;is&nbsp;the&nbsp;dropdown&nbsp;list&nbsp;passed&nbsp;as&nbsp;an&nbsp;argument&nbsp;to&nbsp;the&nbsp;each&nbsp;function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;data&nbsp;is&nbsp;whatever&nbsp;the&nbsp;request&nbsp;returns,&nbsp;in&nbsp;this&nbsp;case,&nbsp;a&nbsp;JSON&nbsp;representation&nbsp;of&nbsp;a&nbsp;genre&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;create&nbsp;a&nbsp;new&nbsp;option&nbsp;and&nbsp;add&nbsp;it&nbsp;to&nbsp;the&nbsp;list&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(element).append($(<span class="js__string">&quot;&lt;option&gt;&lt;/option&gt;&quot;</span>).attr(<span class="js__string">&quot;value&quot;</span>,&nbsp;data[element.name]).text(data.Name));&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;default&nbsp;the&nbsp;dropdown&nbsp;list&nbsp;to&nbsp;the&nbsp;new&nbsp;option</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(element).val(data[element.name]);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;close&nbsp;the&nbsp;dialog</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(dialog).dialog(<span class="js__string">&quot;close&quot;</span>);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;statusCode&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">404</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Not&nbsp;found&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">401</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unauthorised&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;error&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(jqXHR,&nbsp;textStatus,&nbsp;errorThrown)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>&nbsp;&amp;&amp;&nbsp;jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>)<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unhandled&nbsp;error:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;errorThrown);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;&nbsp; <object width="350" height="300" data="data:application/x-silverlight-2," type="application/x-silverlight-2"> <param name="source" value="/Content/Common/videoplayer.xap" /> <param name="initParams" value="deferredLoad=false,duration=0,m=https://i1.code.msdn.s-msft.com/adding-entities-on-the-fly-61fe68ad/image/file/129907/1/adding%20entity%20-%20updating%20select%20list.wmv,autostart=false,autohide=true,showembed=true"
 /> <param name="background" value="#00FFFFFF" /> <param name="minRuntimeVersion" value="3.0.40624.0" /> <param name="enableHtmlAccess" value="true" /> <param name="src" value="https://i1.code.msdn.s-msft.com/adding-entities-on-the-fly-61fe68ad/image/file/129907/1/adding%20entity%20-%20updating%20select%20list.wmv"
 /> <param name="id" value="129907" /> <param name="name" value="Adding Entity - Updating Select List.wmv" /><span><a href="http://go.microsoft.com/fwlink/?LinkID=149156" style="text-decoration:none"><img src="-?linkid=108181" alt="Get Microsoft Silverlight" style="border-style:none"></a></span>
 </object> </div>
<p>Pretty cool, no?</p>
<h2>Validation</h2>
<p>We can use the same approach for managing errors that we used for returning our new entities.&nbsp; The Genre model doesn't enforce any properties but the application will break if the name is blank.&nbsp; By simply annotating the model, we can enforce some
 validation.</p>
<p>Add the [Required] attribute to the Name property on the Genre model (you'll need to add a reference to the <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a> namespace also)</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a>;&nbsp;
&nbsp;
namespace&nbsp;MvcMusicStore.Models&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;public&nbsp;partial&nbsp;class&nbsp;Genre&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;GenreId&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Name&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Description&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;List&lt;Album&gt;&nbsp;Albums&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Modify the Create action on the Genre Controller to return a JSON representation of any model errors.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;POST:&nbsp;/Genre/Create</span>&nbsp;
&nbsp;
[HttpPost]&nbsp;
public&nbsp;ActionResult&nbsp;Create(Genre&nbsp;genre)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ModelState.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Genres.Add(genre);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.SaveChanges();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(Request.IsAjaxRequest())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Json(genre);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;RedirectToAction(<span class="js__string">&quot;Index&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(Request.IsAjaxRequest())&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Json(<span class="js__operator">new</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;errors&nbsp;=&nbsp;ModelState.Where(modelState&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;modelState.Value.Errors.Count&nbsp;&gt;&nbsp;<span class="js__num">0</span>).ToDictionary(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;kvp&nbsp;=&gt;&nbsp;kvp.Key,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;kvp&nbsp;=&gt;&nbsp;kvp.Value.Errors.Take(<span class="js__num">1</span>).Select(e&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.ErrorMessage).ToArray()[<span class="js__num">0</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View(genre);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Again, we&rsquo;re identifying the type of request using the IsAjaxRequest() method and returning a JSON object rather than a View, only this time we&rsquo;re creating an object that has an errors property which contains an array
 of any model validation errors.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">These errors are returned to the success function defined in the Ajax method call (success refers to the success of the request, not the operation at the other end).&nbsp; Checking for the presence of the errors property allows
 us to determine whether the request was successful and if not, what went wrong.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Update the success function of the Ajax post request to check for an errors property.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$.ajax(&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;/Genre/Create&quot;</span>,&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;type&quot;</span>:&nbsp;<span class="js__string">&quot;POST&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;postData,&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;success&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(data,&nbsp;textStatus,&nbsp;jqXHR)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(!data.errors)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(element).append($(<span class="js__string">&quot;&lt;option&gt;&lt;/option&gt;&quot;</span>).attr(<span class="js__string">&quot;value&quot;</span>,&nbsp;data[element.name]).text(data.Name));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(element).val(data[element.name]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(dialog).dialog(<span class="js__string">&quot;close&quot;</span>);&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;dialog</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;process&nbsp;errors</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;statusCode&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">404</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Not&nbsp;found&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">401</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unauthorised&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;error&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(jqXHR,&nbsp;textStatus,&nbsp;errorThrown)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>&nbsp;&amp;&amp;&nbsp;jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>)<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unhandled&nbsp;error:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;errorThrown);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">If the jQuery client validation scripts have been loaded, we can pass the json object directly to the showErrors of the validator object.&nbsp; The Create View for the StoreManager Controller doesn&rsquo;t include these scripts,
 so add these now&hellip;</div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html">@model&nbsp;MvcMusicStore.Models.Album&nbsp;&nbsp;
&nbsp;&nbsp;
@{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;&quot;Create&quot;;&nbsp;&nbsp;
}&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="html__tag_start">&lt;h2</span><span class="html__tag_start">&gt;</span>Create<span class="html__tag_end">&lt;/h2&gt;</span>&nbsp;&nbsp;
<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;@Url.Content(&quot;</span>~/Scripts/jQuery.validate.min.js&quot;)&quot;&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/Javascript&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;@Url.Content(&quot;</span>~/Scripts/jQuery.validate.unobtrusive.min.js&quot;)&quot;&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/Javascript&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;@Url.Content(&quot;</span>~/Scripts/MvcMusicStore.js&quot;)&quot;&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/Javascript&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;
@using&nbsp;(Html.BeginForm())&nbsp;{&nbsp;&nbsp;
...&nbsp;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;&hellip;and pass the errors to the validation showErrors() method.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$.ajax(<span class="js__string">&quot;/Genre/Create&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;type&quot;</span>:&nbsp;<span class="js__string">&quot;POST&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;postData,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;success&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(data,&nbsp;textStatus,&nbsp;jqXHR)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(!data.errors)<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;element&nbsp;is&nbsp;the&nbsp;dropdown&nbsp;list&nbsp;passed&nbsp;as&nbsp;an&nbsp;argument&nbsp;to&nbsp;the&nbsp;each&nbsp;function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;data&nbsp;is&nbsp;whatever&nbsp;the&nbsp;request&nbsp;returns,&nbsp;in&nbsp;this&nbsp;case,&nbsp;a&nbsp;JSON&nbsp;representation&nbsp;of&nbsp;a&nbsp;genre&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;create&nbsp;a&nbsp;new&nbsp;option&nbsp;and&nbsp;add&nbsp;it&nbsp;to&nbsp;the&nbsp;list&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(element).append($(<span class="js__string">&quot;&lt;option&gt;&lt;/option&gt;&quot;</span>).attr(<span class="js__string">&quot;value&quot;</span>,&nbsp;data[element.name]).text(data.Name));&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;default&nbsp;the&nbsp;dropdown&nbsp;list&nbsp;to&nbsp;the&nbsp;new&nbsp;option</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(element).val(data[element.name]);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;close&nbsp;the&nbsp;dialog</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(dialog).dialog(<span class="js__string">&quot;close&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;get&nbsp;a&nbsp;reference&nbsp;to&nbsp;the&nbsp;validator</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;validator&nbsp;=&nbsp;form.validate();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;pass&nbsp;errors&nbsp;to&nbsp;showErrors&nbsp;method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;validator.showErrors(data.errors);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;statusCode&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">404</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Not&nbsp;found&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">401</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unauthorised&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;error&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(jqXHR,&nbsp;textStatus,&nbsp;errorThrown)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>&nbsp;&amp;&amp;&nbsp;jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>)<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unhandled&nbsp;error:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;errorThrown);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">This will highlight the fields with validation errors.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="67998" src="67998-snag-0031.png" alt="" width="664" height="338"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">If we attempt to create an entity but we fail validation the user is presented with some meaningful feedback, even if we're using Ajax.</div>
</div>
</div>
<p>The client validation scripts have been loaded to process validation messages returned from the server but the same scripts can be used to validate the form before posting any data to the server.&nbsp; However, the dynamically loaded form does not contain
 the html5 data-* attributes used to identify each fields validation properties.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!--&nbsp;&nbsp;ajax&nbsp;loaded&nbsp;html&nbsp;--&gt;&nbsp;
&nbsp;
&lt;div&nbsp;class=<span class="js__string">&quot;editor-label&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;Name&quot;</span>&gt;Name&lt;/label&gt;&nbsp;
&lt;/div&gt;&nbsp;
&lt;div&nbsp;class=<span class="js__string">&quot;editor-field&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;input&nbsp;id=<span class="js__string">&quot;Name&quot;</span>&nbsp;class=<span class="js__string">&quot;text-box&nbsp;single-line&nbsp;error&quot;</span>&nbsp;name=<span class="js__string">&quot;Name&quot;</span>&nbsp;value=<span class="js__string">&quot;&quot;</span>&nbsp;type=<span class="js__string">&quot;text&quot;</span>&gt;&lt;label&nbsp;class=<span class="js__string">&quot;error&quot;</span>&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;Name&quot;</span>&nbsp;generated=<span class="js__string">&quot;true&quot;</span>&gt;The&nbsp;Name&nbsp;field&nbsp;is&nbsp;required.&lt;/label&gt;&nbsp;
&lt;/div&gt;&nbsp;
&nbsp;
&lt;div&nbsp;class=<span class="js__string">&quot;editor-label&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;Description&quot;</span>&gt;Description&lt;/label&gt;&nbsp;
&lt;/div&gt;&nbsp;
&lt;div&nbsp;class=<span class="js__string">&quot;editor-field&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;input&nbsp;id=<span class="js__string">&quot;Description&quot;</span>&nbsp;class=<span class="js__string">&quot;text-box&nbsp;single-line&quot;</span>&nbsp;name=<span class="js__string">&quot;Description&quot;</span>&nbsp;value=<span class="js__string">&quot;&quot;</span>&nbsp;type=<span class="js__string">&quot;text&quot;</span>&gt;&nbsp;
&lt;/div&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">In order for attributes to be added to the element html, a FormContext needs to be available and since our PartialView does not call Html.BeginForm, we have no context.&nbsp; Thankfully, it&rsquo;s pretty easy to workaround.&nbsp;
 Add a new class to your project and copy the code below.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">namespace&nbsp;System.Web.Mvc.Html&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;class&nbsp;MvcExtensions&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;RegisterFormContextForValidation(<span class="js__operator">this</span>&nbsp;HtmlHelper&nbsp;helper)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(helper.ViewContext.FormContext&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;helper.ViewContext.FormContext&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FormContext();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">This code adds an extension method to the HtmlHelper class, accessed in Views and PartialViews through the Html property.&nbsp; As you can see, the method simply checks for a FormContext and if it doesn&rsquo;t exist, it creates
 one.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">We can now update our PartialView to call this method.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">@model&nbsp;MvcMusicStore.Models.Genre&nbsp;
&nbsp;
@<span class="js__brace">{</span>Html.RegisterFormContextForValidation();&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&lt;div&nbsp;class=<span class="js__string">&quot;editor-label&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;@Html.LabelFor(model&nbsp;=&gt;&nbsp;model.Name)&nbsp;
&lt;/div&gt;&nbsp;
&lt;div&nbsp;class=<span class="js__string">&quot;editor-field&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;@Html.EditorFor(model&nbsp;=&gt;&nbsp;model.Name)&nbsp;
&nbsp;&nbsp;&nbsp;@Html.ValidationMessageFor(model&nbsp;=&gt;&nbsp;model.Name)&nbsp;
&lt;/div&gt;&nbsp;
&nbsp;
&lt;div&nbsp;class=<span class="js__string">&quot;editor-label&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;@Html.LabelFor(model&nbsp;=&gt;&nbsp;model.Description)&nbsp;
&lt;/div&gt;&nbsp;
&lt;div&nbsp;class=<span class="js__string">&quot;editor-field&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;@Html.EditorFor(model&nbsp;=&gt;&nbsp;model.Description)&nbsp;
&nbsp;&nbsp;&nbsp;@Html.ValidationMessageFor(model&nbsp;=&gt;&nbsp;model.Description)&nbsp;
&lt;/div&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Now our PartialView will always have a FormContext and will render validation attributes as required.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__comment">&lt;!--&nbsp;ajax&nbsp;loaded&nbsp;html&nbsp;--&gt;</span>&nbsp;
&nbsp;
<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;editor-label&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;Name&quot;</span><span class="html__tag_start">&gt;</span>Name<span class="html__tag_end">&lt;/label&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;editor-field&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;Name&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;text-box&nbsp;single-line&quot;</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;Name&quot;</span>&nbsp;<span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span>&nbsp;<span class="html__attr_name">data-val-required</span>=<span class="html__attr_value">&quot;The&nbsp;Name&nbsp;field&nbsp;is&nbsp;required.&quot;</span>&nbsp;<span class="html__attr_name">data-val</span>=<span class="html__attr_value">&quot;true&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;field-validation-valid&quot;</span>&nbsp;<span class="html__attr_name">data-valmsg-replace</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">data-valmsg-for</span>=<span class="html__attr_value">&quot;Name&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;editor-label&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;Description&quot;</span><span class="html__tag_start">&gt;</span>Description<span class="html__tag_end">&lt;/label&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;editor-field&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;Description&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;text-box&nbsp;single-line&quot;</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;Description&quot;</span>&nbsp;<span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;field-validation-valid&quot;</span>&nbsp;<span class="html__attr_name">data-valmsg-replace</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">data-valmsg-for</span>=<span class="html__attr_value">&quot;Description&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Now that the validation scripts loaded and we the elements have validation attributes, we can validate the form before sending the request.&nbsp; All that is required is to notify the client validator of the form (as it was created
 dynamically from an Ajax request, the client side validator is unaware of it) using the parse method.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Once the validator is aware of the form it can be validated prior to making a request by calling form.valid().&nbsp; This will return a Boolean indicating whether validation succeeded or not.&nbsp; In the event that the form is
 not valid, validation messages will be displayed.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$.validator.unobtrusive.parse(form);&nbsp;
&nbsp;
<span class="js__statement">if</span>&nbsp;(form.valid())&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;$.ajax(&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;/Genre/Create&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;type&quot;</span>:&nbsp;<span class="js__string">&quot;POST&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;postData,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;success&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(data,&nbsp;textStatus,&nbsp;jqXHR)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(!data.errors)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(element).append($(<span class="js__string">&quot;&lt;option&gt;&lt;/option&gt;&quot;</span>).attr(<span class="js__string">&quot;value&quot;</span>,&nbsp;data[element.name]).text(data.Name));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(element).val(data[element.name]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(dialog).dialog(<span class="js__string">&quot;close&quot;</span>);&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;dialog</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;process&nbsp;errors</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;validator&nbsp;=&nbsp;form.validate();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;validator.showErrors(data.errors);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;statusCode&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">404</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Not&nbsp;found&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">401</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unauthorised&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;error&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(jqXHR,&nbsp;textStatus,&nbsp;errorThrown)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>&nbsp;&amp;&amp;&nbsp;jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>)<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unhandled&nbsp;error:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;errorThrown);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Now when we click Save before meeting all validation criteria, the non-valid fields are highlighted and a message displayed before any request sent.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img src="57044-snag-0031a.png" alt="" width="664" height="348"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Finally. We need to address the hard coded url &ndash; the code as it stands will create buttons for each and every required dropdown list but they&rsquo;ll all load the Genre form.&nbsp; So, we need a way to identify the correct
 entity, and therefore Controller from the dropdown list itself.<br>
<br>
The dropdown list&nbsp; element is passed to the .each() function as the element parameter but is also accessible from the &lsquo;this&rsquo; object.&nbsp; Once we have a reference to the dropdown list element, we can infer the entity name.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(<span class="js__string">&quot;select[data-val-required]&quot;</span>).each(<span class="js__operator">function</span>&nbsp;(index,&nbsp;element)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;input&nbsp;=&nbsp;<span class="js__operator">this</span>,&nbsp;entityName&nbsp;=&nbsp;input.name.replace(<span class="js__string">&quot;Id&quot;</span>,&nbsp;<span class="js__string">&quot;&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).after(...);&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">And then replace the hardcoded urls with urls constructed with the entity name and even add an entity specific title to the dialog.</div>
</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$.ajax(&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;/&quot;</span>&nbsp;&#43;&nbsp;entityName&nbsp;&#43;&nbsp;<span class="js__string">&quot;/Create&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">&quot;GET&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contentType:&nbsp;<span class="js__string">&quot;text/html;&nbsp;charset=utf-8&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>&nbsp;(data,&nbsp;textStatus,&nbsp;jqXHR)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;newDialog&nbsp;=&nbsp;$(<span class="js__string">&quot;&lt;div&gt;&lt;/div&gt;&quot;</span>),&nbsp;newDialogContent&nbsp;=&nbsp;$(<span class="js__string">&quot;&lt;div&gt;&lt;/div&gt;&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newDialog.append(newDialogContent);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newDialogContent.html($(<span class="js__string">&quot;&lt;form&gt;&lt;/form&gt;&quot;</span>).html(data));&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;dialogButtons&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;save&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;form&nbsp;=&nbsp;$(<span class="js__operator">this</span>).dialog(<span class="js__string">&quot;widget&quot;</span>).find(<span class="js__string">&quot;form&quot;</span>),&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;postData&nbsp;=&nbsp;form.serialize();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dialog&nbsp;=&nbsp;<span class="js__operator">this</span>;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;/&quot;</span>&nbsp;&#43;&nbsp;entityName&nbsp;&#43;&nbsp;<span class="js__string">&quot;/Create&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;type&quot;</span>:&nbsp;<span class="js__string">&quot;POST&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;postData,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;success&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(data,&nbsp;textStatus,&nbsp;jqXHR)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(element).append($(<span class="js__string">&quot;&lt;option&gt;&lt;/option&gt;&quot;</span>).attr(<span class="js__string">&quot;value&quot;</span>,&nbsp;data[element.name]).text(data.Name));&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(element).val(data[element.name]);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).dialog(<span class="js__string">&quot;close&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;statusCode&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">404</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Not&nbsp;found&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__num">401</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unauthorised&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;error&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;(jqXHR,&nbsp;textStatus,&nbsp;errorThrown)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>&nbsp;&amp;&amp;&nbsp;jqXHR.statusCode&nbsp;!=&nbsp;<span class="js__num">401</span>)<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unhandled&nbsp;error:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;errorThrown);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;cancel&quot;</span>:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).dialog(<span class="js__string">&quot;close&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newDialog.dialog(<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;width&quot;</span>:&nbsp;<span class="js__num">335</span>,&nbsp;<span class="js__string">&quot;buttons&quot;</span>:&nbsp;dialogButtons,&nbsp;<span class="js__string">&quot;title&quot;</span>:&nbsp;<span class="js__string">&quot;Create&nbsp;&quot;</span>&nbsp;&#43;&nbsp;entityName<span class="js__brace">}</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error:&nbsp;<span class="js__operator">function</span>&nbsp;(jqXhr,&nbsp;textStatus,&nbsp;errorThrown)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;boo!&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
);&nbsp;
</pre>
</div>
</div>
</div>
</div>
<div class="endscriptcode">In this example I&rsquo;ve simply trimmed the Id from the element name which works as my controllers have the same name as the entity &ndash; if your controllers aren't named exactly the same (i.e. pluralised) then you may require
 a more robust solution.</div>
<h2 class="endscriptcode">Recursive Implementation</h2>
<div class="endscriptcode">The purpose of this sample was to demonstrate how to enhance forms by allowing the user to create required entities prior to submission and without leaving the current page.&nbsp; In doing so, however, we have introduced a new form.&nbsp;
 What if the Genre entity also had a dropdown list from which an option must be selected?</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">In fact, it&rsquo;s very easy to make this happen, all we need is a couple of tweaks.&nbsp; First, we&rsquo;re going to add a container argument to the MvcMusicStore.AppendAddButtons function...</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">MvcMusicStore.AppendAddButtons&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(container)&nbsp;<span class="js__brace">{</span>..<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;&hellip;and update the jQuery method that locates our select items to find matching elements within the supplied container&hellip;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(container).find(<span class="js__string">&quot;select[data-val-required]&quot;</span>).each(<span class="js__operator">function</span>&nbsp;(index,&nbsp;element)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//...</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;&hellip;and in the function call when the document has loaded.</div>
</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;MvcMusicStore.AppendAddButtons(document);&nbsp;
<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Then simply call the function on our Ajax loaded form after it's been added to the DOM.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&hellip;</span>&nbsp;
&nbsp;
newDialogContent.html($(<span class="js__string">&quot;&lt;form&gt;&lt;/form&gt;&quot;</span>).html(data));&nbsp;
&nbsp;
MvcMusicStore.AppendAddButtons(newDialogContent);&nbsp;
&nbsp;
<span class="js__sl_comment">//&hellip;</span>&nbsp;
</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">Summary</h2>
<div class="endscriptcode">In order to modify your existing MVC3 application, you need to do the following:</div>
<div class="endscriptcode"><br>
&bull;&nbsp;&nbsp; &nbsp;Update your model properties with appropriate DataAnnotation attributes<br>
&bull;&nbsp;&nbsp; &nbsp;Amend each Create action method on each Controller to return Json objects when responding to an Ajax request.<br>
&bull;&nbsp;&nbsp; &nbsp;Refactor each Create View, moving the fields of the form into a PartialView
<br>
&bull;&nbsp;&nbsp; &nbsp;Add in references to the jQuery validation scripts to each View<br>
&bull;&nbsp;&nbsp; &nbsp;Update the PartialViews so a FormContext always available on the ViewContext.<br>
&bull;&nbsp;&nbsp; &nbsp;Add a Javascript file with the client code as demonstrated to the project and reference from each Create View</div>
<div class="endscriptcode"></div>
<h2 class="endscriptcode">Additional options</h2>
<div class="endscriptcode">For a more flexible solution, the AppendAddButton function might also want to accept as arguments a jQuery selector string for identifying elements, a function for determining the Entity name from a given control and a function
 to process the return result or any combination thereof.<br>
<br>
</div>
</div>
<h2 class="endscriptcode">More Information</h2>
<div class="endscriptcode">MvcMusicStore</div>
<div class="endscriptcode"><a href="http://mvcmusicstore.codeplex.com/" target="_blank">http://mvcmusicstore.codeplex.com</a></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Self-Executing Anonymous Functions<br>
<a href="http://www.andismith.com/blog/2011/10/self-executing-anonymous-revealing-module-pattern/" target="_blank">http://www.andismith.com/blog/2011/10/self-executing-anonymous-revealing-module-pattern</a></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">FormContext:<br>
<a href="http://stackoverflow.com/questions/6401033/editorfor-not-rendering-data-validation-attributes-without-beginform" target="_blank">http://stackoverflow.com/questions/6401033/editorfor-not-rendering-data-validation-attributes-without-beginform</a></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Progressive Enhancement:<br>
<a href="http://en.wikipedia.org/wiki/Progressive_enhancement">http://en.wikipedia.org/wiki/Progressive_enhancement</a><br>
<br>
</div>
</div>
</div>
</div>
</div>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:0px; width:1px; height:1px; overflow:hidden">
<div style="border:solid #D9D9D9 1.0pt; padding:1.0pt 4.0pt 1.0pt 4.0pt; background:#F2F2F2">
<p class="Code">&nbsp;</p>
<p class="Code">&nbsp;</p>
<p class="Code">&lt;script&nbsp;src=&quot;@Url.Content(&quot;~/Scripts/jQuery-1.5.1.min.js&quot;)&quot;&nbsp;type=&quot;text/Javascript&quot;&gt;&lt;/script&gt;&nbsp;</p>
</div>
</div>
