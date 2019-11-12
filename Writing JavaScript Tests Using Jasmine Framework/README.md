# Writing JavaScript Tests Using Jasmine Framework
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- jQuery
- Javascript
- Unit Test
- Visual Studio 2015
- Jasmine
## Topics
- jQuery
- Javascript
- Unit Testing
- Performance
- Performance testing
## Updated
- 10/08/2016
## Description

<p>In this post we will see how we can write unit test cases in&nbsp;<a href="http://sibeeshpassion.com/category/JavaScript/" target="_blank">JavaScript</a>. Here we are going to use a framework called Jasmine to write and test our unit test cases. Jasmine
 is a behavior driven development framework to test our JavaScript codes. The interesting things about Jasmine framework are, it doesn&rsquo;t even require a DOM, independent on any framework, clean and easy. Here I will show you how we can create and run our
 JavaScript tests. I am going to use&nbsp;<a href="http://sibeeshpassion.com/category/visual-studio/" target="_blank">Visual Studio</a>&nbsp;2015 for the development. I hope you will like this article.</p>
<p>Background</p>
<p>As a developer, we all writes JavaScript codes for our client side developments. Am I right? It is more important to check whether the codes we have written works well. So for that we developer usually do unit testing, few developers are doing a manual testing
 to just check whether the functionality is working or not. But most of the MNC&rsquo;s has set of rules to be followed while developing any functionalities, one of them is writing test cases, once the test cases passes, then only you will be allowed to move
 your codes to other environments. Here I will show you how we can write client side test cases with the help of a framework called Jasmine.</p>
<p><span>Setting up the project</span></p>
<p>To get started, please create an empty project in your Visual Studio.</p>
<div class="wp-caption x_alignnone" id="attachment_11904"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/10/Empty_Project-e1475921231766.png"><img class="size-full x_wp-image-11904" src="-empty_project-e1475921231766.png" alt="empty_project" width="650" height="507"></a>
<p class="wp-caption-text">empty_project</p>
</div>
<p>Now, we will install&nbsp;<a href="http://sibeeshpassion.com/category/jquery/" target="_blank">jQuery</a>,&nbsp;<a href="http://sibeeshpassion.com/category/jquery-ui/" target="_blank">jQueryUI&nbsp;</a>from Nuget package manager.</p>
<div class="wp-caption x_alignnone" id="attachment_11905"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/10/Nuget_Package_Manager.png"><img class="size-large x_wp-image-11905" src="-nuget_package_manager-1024x478.png" alt="nuget_package_manager" width="634" height="296"></a>
<p class="wp-caption-text">nuget_package_manager</p>
</div>
<p>We are all set to start our coding now.</p>
<p><span>Creating page and needed JS file</span></p>
<p>Next, we are going to create a page as preceding, with two text boxes and needed references.</p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_218826">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&gt;&nbsp;
&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;Writing&nbsp;JavaScript&nbsp;test&nbsp;cases&nbsp;<span class="js__statement">with</span>&nbsp;Jasmine&nbsp;framework&nbsp;-&nbsp;Sibeesh&nbsp;Passion&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;charset=<span class="js__string">&quot;utf-8&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;href=<span class="js__string">&quot;Content/themes/base/jquery-ui.min.css&quot;</span>&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;href=<span class="js__string">&quot;Content/themes/base/base.css&quot;</span>&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;Scripts/jquery-3.1.1.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;Scripts/jquery-ui-1.12.1.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;Scripts/Index.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;/head&gt;&nbsp;
&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Start&nbsp;<span class="js__object">Date</span>:&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;name=<span class="js__string">&quot;name&quot;</span>&nbsp;value=<span class="js__string">&quot;&quot;</span>&nbsp;id=<span class="js__string">&quot;dtStartDate&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;<span class="js__object">Date</span>:&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;name=<span class="js__string">&quot;name&quot;</span>&nbsp;value=<span class="js__string">&quot;&quot;</span>&nbsp;id=<span class="js__string">&quot;dtEndDate&quot;</span>&nbsp;/&gt;&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p>Now we can start writing our JavaScript codes in the file&nbsp;<em>Index.js</em>. We will start with a document ready function as preceding.</p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_924732">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#dtStartDate&quot;</span>).datepicker();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#dtEndDate&quot;</span>).datepicker();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#dtEndDate&quot;</span>).on(<span class="js__string">&quot;change&nbsp;leave&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p>Shall we create our validation functions? We will be creating a namespace indexPage and functions. You can see the validations below.</p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_785782">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;indexPage&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
indexPage.validationFunctions&nbsp;=&nbsp;(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;getStartDateSelectedValue:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$(<span class="js__string">&quot;#dtStartDate&quot;</span>).val();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;getEndDateSelectedValue:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$(<span class="js__string">&quot;#dtEndDate&quot;</span>).val();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isNullValue:&nbsp;<span class="js__operator">function</span>&nbsp;(selVal)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(selVal.trim()&nbsp;==&nbsp;<span class="js__string">&quot;&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isNullValueWithUIElements:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(indexPage.validationFunctions.isNullValue(indexPage.validationFunctions.getStartDateSelectedValue())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;&amp;&nbsp;indexPage.validationFunctions.isNullValue(indexPage.validationFunctions.getEndDateSelectedValue()))&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;The&nbsp;values&nbsp;can't&nbsp;be&nbsp;null!.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isEndDateGreaterStart:&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;startDate&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__object">Date</span>(indexPage.validationFunctions.getStartDateSelectedValue());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;endDate&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__object">Date</span>(indexPage.validationFunctions.getEndDateSelectedValue());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(startDate&nbsp;&lt;&nbsp;endDate)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;End&nbsp;date&nbsp;must&nbsp;be&nbsp;greater&nbsp;than&nbsp;start&nbsp;date!.&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>(jQuery));</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p>Hope you are able t understand the codes written. We are wrote some validations like Null value check, end date greater than start date etc&hellip;</p>
<p>Now please run your application and check whether the validations are working fine.</p>
<div class="wp-caption x_alignnone" id="attachment_11906"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/10/Null_validation_check.png"><img class="size-large x_wp-image-11906" src="-null_validation_check-1024x319.png" alt="null_validation_check" width="634" height="198"></a>
<p class="wp-caption-text">null_validation_check</p>
</div>
<div class="wp-caption x_alignnone" id="attachment_11907"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/10/Date_validation_check.png"><img class="size-large x_wp-image-11907" src="-date_validation_check-1024x319.png" alt="date_validation_check" width="634" height="198"></a>
<p class="wp-caption-text">date_validation_check</p>
</div>
<p>Now, here comes the real part.</p>
<p><span>Setting up Jasmine Framework</span></p>
<p>To set Jasmine, we will add a new project to our solution.</p>
<div class="wp-caption x_alignnone" id="attachment_11908"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/10/Add_new_project.png"><img class="size-large x_wp-image-11908" src="-add_new_project-1024x709.png" alt="add_new_project" width="634" height="439"></a>
<p class="wp-caption-text">add_new_project</p>
</div>
<p>Now install Jasmine from Nuget Package manager.</p>
<div class="wp-caption x_alignnone" id="attachment_11909"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/10/Jasmine_Nuget_Package.png"><img class="size-large x_wp-image-11909" src="-jasmine_nuget_package-1024x570.png" alt="jasmine_nuget_package" width="634" height="353"></a>
<p class="wp-caption-text">jasmine_nuget_package</p>
</div>
<p>Once you are done, the required files would be added to your project. We will be discussing about Jasmine once everything is set. So no worries.</p>
<p>Now please add a new HTML file on your Jasmine project, this is the page where we can see the test cases in actions, and add all the references as follows.</p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_328025">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&nbsp;&nbsp;
&lt;html&nbsp;lang=<span class="js__string">&quot;en&quot;</span>&nbsp;xmlns=<span class="js__string">&quot;http://www.w3.org/1999/xhtml&quot;</span>&gt;&nbsp;
&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;charset=<span class="js__string">&quot;utf-8&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;Jasmine&nbsp;Spec&nbsp;Runner&nbsp;-&nbsp;Sibeesh&nbsp;Passion&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;href=<span class="js__string">&quot;content/jasmine/jasmine.css&quot;</span>&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;http://localhost:12387/Scripts/jquery-3.1.1.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;http://localhost:12387/Scripts/jquery-ui-1.12.1.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;scripts/jasmine/jasmine.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;scripts/jasmine/jasmine-html.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;scripts/jasmine/console.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;scripts/jasmine/boot.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;scripts/indextests.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;http://localhost:12387/Scripts/Index.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;/head&gt;&nbsp;
&lt;body&gt;&nbsp;
&nbsp;&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<blockquote>
<p>Please do not forget to include the js files where we actually written the validations, jquery, jqueryui (if needed). Here indextests.js is the file where we are going to write the test cases.</p>
</blockquote>
<p>Normally this page is called as Spec Runner, Now you may be thinking what is a Spec? Before going further, there are some terms you must be aware of, there are listed below.</p>
<li>Suites
<p>A suit is the starting point of a Jasmine test cases, it actually calls the global jasmine function&nbsp;<em>describe</em>. It can have two parameters, a string value which describes the suit, and a function which implements the suit.</p>
</li><li>Spec
<p>Like suites, a spec starts with a string which can be the title of the suit and a function where we write the tests. A spec can contain one or more expectation that test the state of our code.</p>
</li><li>Expectation
<p>Value of an expectation is either true or false, an expectation starts with the function&nbsp;<em>expect</em>. It takes a value and call the actual one.</p>
<p>You can always read more&nbsp;<a href="http://jasmine.github.io/2.0/introduction.html" target="_blank">here</a>. Now please run your SpecRunner.html page. If everything is fine you can see a page as below.</p>
<div class="wp-caption x_alignnone" id="attachment_11910"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/10/Jasmine_Spec_Runner_Page.png"><img class="size-large x_wp-image-11910" src="-jasmine_spec_runner_page-1024x223.png" alt="jasmine_spec_runner_page" width="634" height="138"></a>
<p class="wp-caption-text">jasmine_spec_runner_page</p>
</div>
<p>So are you all set? Shall we go and write our test cases? Please go to your&nbsp;<em>IndexTest.js</em>&nbsp;file and create a suit and spec as preceding.</p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_7431">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">describe(<span class="js__string">&quot;Includes&nbsp;validations&nbsp;for&nbsp;index&nbsp;page&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;indexPage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;beforeEach(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;indexPage&nbsp;=&nbsp;window.indexPage.validationFunctions;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;it(<span class="js__string">&quot;Check&nbsp;for&nbsp;null&nbsp;values&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;We&nbsp;are&nbsp;going&nbsp;to&nbsp;pass&nbsp;&quot;&quot;&nbsp;(null)&nbsp;value&nbsp;to&nbsp;the&nbsp;function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;retVal&nbsp;=&nbsp;indexPage.isNullValue(<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;expect(retVal).toBeTruthy();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;
<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>Here the expectation is true and we give toBeTruthy(), now lets go and find whether the test is passed or not. Please run the SpecRunner.html page again.</p>
<div class="wp-caption x_alignnone" id="attachment_11911"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/10/Test_Jasmine_Specs.png"><img class="size-large x_wp-image-11911" src="-test_jasmine_specs-1024x199.png" alt="test_jasmine_specs" width="634" height="123"></a>
<p class="wp-caption-text">test_jasmine_specs</p>
</div>
<p>Now we will write test case for our function&nbsp;<em>isEndDateGreaterStart</em>, if you have noticed the function<em>isEndDateGreaterStart</em>, you can see that there are dependencies (UI elements). Inside of the function, we are getting the values from
 the UI elements.</p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_550587">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;startDate&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__object">Date</span>(indexPage.validationFunctions.getStartDateSelectedValue());&nbsp;
<span class="js__statement">var</span>&nbsp;endDate&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__object">Date</span>(indexPage.validationFunctions.getEndDateSelectedValue());&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>So in this case, we need to mock this values. It is known as &lsquo;Spy&rsquo; in Jasmine. We can use a function called<em>SpyOn</em>&nbsp;for this.</p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_925356">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">it(<span class="js__string">&quot;Spy&nbsp;call&nbsp;for&nbsp;datepicker&nbsp;date&nbsp;validation&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Start&nbsp;date&nbsp;as&nbsp;2015-03-25</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;spyOn(indexPage,&nbsp;<span class="js__string">&quot;getStartDateSelectedValue&quot;</span>).and.returnValue(<span class="js__string">&quot;2015-03-25&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//End&nbsp;date&nbsp;as&nbsp;2015-03-24</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;spyOn(indexPage,&nbsp;<span class="js__string">&quot;getEndDateSelectedValue&quot;</span>).and.returnValue(<span class="js__string">&quot;2015-03-24&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;retVal&nbsp;=&nbsp;indexPage.isEndDateGreaterStart();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;expect(retVal).toBeFalsy();&nbsp;
<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>Here we are giving start date as 2015-03-25 and end date as 2015-03-24 and we know 2015-03-25 &lt; 2015-03-24 is false, so here we are giving expectation as false (toBeFalsy()). Now you are getting an alert as follows right?<a href="http://sibeeshpassion.com/wp-content/uploads/2016/10/Alert_in_SpyOn_Jasmine-e1475924905278.png"><img class="size-full x_wp-image-11912" src="-alert_in_spyon_jasmine-e1475924905278.png" alt="alert_in_spyon_jasmine" width="766" height="571"></a>alert_in_spyon_jasmine[/caption]</p>
<p>But in testing framework we don&rsquo;t need any alerts right? To get rid of this, you must create a spy for window.alert function and add it to the&nbsp;<em>beforeEach</em>&nbsp;so that it can be used for each specs. You can do that as follows.</p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_746611">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">window.alert&nbsp;=&nbsp;jasmine.createSpy(<span class="js__string">&quot;alert&quot;</span>).and.callFake(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>Once after you add this code, alert message won&rsquo;t be thrown. Now please add an another spec with true values (Start date &ndash; 2015-03-25, End date &ndash; 2015-03-26), so that it will return true.</p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_588996">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">it(<span class="js__string">&quot;Spy&nbsp;call&nbsp;for&nbsp;datepicker&nbsp;date&nbsp;validation&nbsp;toBeTruthy&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Start&nbsp;date&nbsp;as&nbsp;2015-03-25</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;spyOn(indexPage,&nbsp;<span class="js__string">&quot;getStartDateSelectedValue&quot;</span>).and.returnValue(<span class="js__string">&quot;2015-03-25&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//End&nbsp;date&nbsp;as&nbsp;2015-03-26</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;spyOn(indexPage,&nbsp;<span class="js__string">&quot;getEndDateSelectedValue&quot;</span>).and.returnValue(<span class="js__string">&quot;2015-03-26&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;retVal&nbsp;=&nbsp;indexPage.isEndDateGreaterStart();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;expect(retVal).toBeTruthy();&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>Now you can see all of your specs are passed.</p>
<div class="wp-caption x_alignnone" id="attachment_11913"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/10/Run_all_specs_in_Jasmine.png"><img class="size-large x_wp-image-11913" src="-run_all_specs_in_jasmine-1024x217.png" alt="run_all_specs_in_jasmine" width="634" height="134"></a>
<p class="wp-caption-text">run_all_specs_in_jasmine</p>
</div>
<p>Happy coding!.</p>
</li>