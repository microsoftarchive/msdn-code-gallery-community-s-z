# Storing and Fetching Objects from an ArrayList (C#)
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
- Data Access
- C# Language
- Visual Studio 2013
## Topics
- Arraylist
- C# Language Features
- Storing and Fetching Objects
## Updated
- 10/28/2014
## Description

<h1>Introduction</h1>
<p><em>If you are working in the financial/banking sector as a Software Developer then it might be possible that you have to build a software where you may need to save objects (with different properties) in ArrayList. Many modern developers will resent this
 practise and would recommend that it is better to save the object of a class as a List of its own such as List&lt;Class&gt;. But sometimes, you might not be sure how the actual class may be defined or what properties the class might have. Since, ArrayList
 can store any type of Objects in it (warning: ArrayList is not type safe, but using List&lt;T&gt; is) and sometimes in commercial software development ArrayLists are used quite often.</em></p>
<p><em>If you are a graduate software developer and need to develp this kind of software then this example gives you a walkthrough of how to appraoch this issue. Using this example you would understand the basics of storing the Object with different properties
 in the ArrayList and then retrieve the value of those properties of each object saved in the ArrayList and provide those as output.</em></p>
<p><em>Note: Although in this example the banking/financial software is of primary focus but this technqiue can be implemented in any software applications wherever and whenever required.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The sample was built and debugged using Visual Studio Professional 2013. So just download and run.</em></p>
<p><em>(Should work on other versions of Visual Studio as well.)</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Sometimes storing and fetching an Object from the ArrayList is tricky, but not impossible. :P</em></p>
<p><em>This is actually achieved by by 2 stages:</em></p>
<p><em>1) Storing:</em></p>
<p><em><span style="white-space:pre">&nbsp;</span>Storing the Object is easy. After the properties of the Object are saved are provided by the user, you just need to add them to the arraylist.&nbsp;</em></p>
<p><em>2) Fetching:</em></p>
<p><em><span style="white-space:pre">&nbsp;</span>To fetch the Object with its properties you need to type cast the ArrayList to that Object and then fetch the properties of the object required (so that you can provide that as output).</em></p>
<p>If we consider this example, which is a Windows Form Application, then the form application takes input of the properties of the object along with its name from the user, stores it in a combobox, and then when the user want to select the object he/she wishes
 to get details reagrding the properties of that object, from the combobox and see it. Fig.1 below shows the basic windows form application, which is more or less similar to the framework of few basic banking software form applications, which utilises storing
 and retrieving data (objects).</p>
<p><img id="127801" src="127801-capture1.png" alt="" width="562" height="314"></p>
<p>Fig.2 below shows the user's inputin the textboxes of the application. After the user presses the 'Save Object' button, the object with its properties are saved in the ArrayList, which is invisible from the user's eyes. But the properties of the Object can
 be fetched from the ArrayList by selecting the Object's name from the Combobox.</p>
<p><img id="127802" src="127802-capture2.png" alt="" width="565" height="315"></p>
<p>Fig.3 below shows how the properties of the selected Object is shown as output to the user by selecting the Object's name from the combobox dropdown list.</p>
<p><img id="127803" src="127803-capture3.png" alt="" width="565" height="315"></p>
<p>To store the main code snippet is:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">arraylist.Add((<span class="cs__keyword">object</span>)objectify);&nbsp;<span class="cs__com">//Objectify&nbsp;is&nbsp;the&nbsp;Object&nbsp;saved&nbsp;and&nbsp;arraylist&nbsp;is&nbsp;the&nbsp;ArrayList&nbsp;where&nbsp;the&nbsp;object&nbsp;is&nbsp;added&nbsp;to</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">To fetch, first you need to type cast the object onto the ArrayList as mentioned before and as shown in the example code snippet:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">Objectify&nbsp;Ob&nbsp;=&nbsp;(Objectify)arraylist[i];</pre>
</div>
</div>
</div>
<div class="endscriptcode">For more information regarding how to use them properly, refer to the code snippet provided below or download the code provided.</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode">The complete code snippet for the example:</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.aspx" target="_blank" title="Auto generated link to System.Collections">System.Collections</a>;&nbsp;<span class="cs__com">//important&nbsp;to&nbsp;use&nbsp;this&nbsp;class&nbsp;to&nbsp;access&nbsp;the&nbsp;ArrayList</span>&nbsp;
&nbsp;
<span class="cs__com">//&lt;summary&gt;</span>&nbsp;
<span class="cs__com">//This&nbsp;Example&nbsp;shows&nbsp;you&nbsp;how&nbsp;to&nbsp;use&nbsp;ArrayList&nbsp;to&nbsp;store&nbsp;many&nbsp;Objects&nbsp;with&nbsp;different&nbsp;properties</span>&nbsp;
<span class="cs__com">//And&nbsp;then&nbsp;fetch&nbsp;the&nbsp;properties&nbsp;of&nbsp;each&nbsp;Object&nbsp;stored&nbsp;in&nbsp;the&nbsp;ArrayList&nbsp;</span>&nbsp;
<span class="cs__com">//when&nbsp;required&nbsp;for&nbsp;further&nbsp;computational&nbsp;purposes.</span>&nbsp;
<span class="cs__com">//&lt;/summary&gt;</span>&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;WindowsFormsApplication1&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Declarng&nbsp;the&nbsp;ArrayList&nbsp;in&nbsp;the&nbsp;beginning&nbsp;(globally)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//so&nbsp;that&nbsp;it&nbsp;can&nbsp;be&nbsp;accessed&nbsp;by&nbsp;anything&nbsp;in&nbsp;the&nbsp;Form1&nbsp;class</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ArrayList&nbsp;arraylist&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ArrayList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;comboBox1.Items.Add(<span class="cs__string">&quot;NOT_SET&quot;</span>);&nbsp;<span class="cs__com">//set&nbsp;for&nbsp;default&nbsp;value&nbsp;in&nbsp;ComboBox</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;comboBox1_SelectedIndexChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//NOT_SET&nbsp;is&nbsp;default</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(comboBox1.SelectedItem==<span class="cs__string">&quot;NOT_SET&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;groupBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;No&nbsp;Object&nbsp;Selected&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label9.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Null&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label10.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Null&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label11.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Null&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label12.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Null&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//this&nbsp;for&nbsp;loop&nbsp;checks&nbsp;every&nbsp;Objects&nbsp;saved&nbsp;in&nbsp;the&nbsp;ArrayList</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//and&nbsp;the&nbsp;fetches&nbsp;the&nbsp;properties&nbsp;of&nbsp;each&nbsp;Object&nbsp;from&nbsp;that&nbsp;ArrayList.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//In&nbsp;order&nbsp;to&nbsp;print&nbsp;out&nbsp;the&nbsp;properties&nbsp;of&nbsp;the&nbsp;Object,&nbsp;which&nbsp;is&nbsp;the&nbsp;selected&nbsp;item&nbsp;from&nbsp;the&nbsp;ComboBox,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;it&nbsp;first&nbsp;compares&nbsp;the&nbsp;name&nbsp;of&nbsp;the&nbsp;Object&nbsp;saved&nbsp;in&nbsp;the&nbsp;ArrayList&nbsp;and&nbsp;the&nbsp;ComboBox&nbsp;selected&nbsp;item,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//and&nbsp;if&nbsp;the&nbsp;names&nbsp;are&nbsp;same&nbsp;then&nbsp;only&nbsp;prints&nbsp;that&nbsp;out&nbsp;to&nbsp;the&nbsp;user&nbsp;as&nbsp;the&nbsp;output</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;arraylist.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Objectify&nbsp;Ob&nbsp;=&nbsp;(Objectify)arraylist[i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(<span class="cs__keyword">string</span>.Compare(comboBox1.SelectedItem.ToString(),&nbsp;Ob.name,&nbsp;<span class="cs__keyword">true</span>)==<span class="cs__number">0</span>)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;groupBox1.Text&nbsp;=&nbsp;Ob.name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label9.Text&nbsp;=&nbsp;Ob.name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label10.Text&nbsp;=&nbsp;Ob.property1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label11.Text&nbsp;=&nbsp;Ob.property2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label12.Text&nbsp;=&nbsp;Ob.property3;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//creating&nbsp;a&nbsp;Class,&nbsp;of&nbsp;which&nbsp;the&nbsp;Object&nbsp;belongs&nbsp;to....</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//The&nbsp;class&nbsp;has&nbsp;3&nbsp;property's&nbsp;fields&nbsp;and&nbsp;a&nbsp;name&nbsp;for&nbsp;identification</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Objectify&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;property1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;property2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;property3;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//method&nbsp;to&nbsp;add&nbsp;the&nbsp;Object&nbsp;to&nbsp;the&nbsp;ArrayLst&nbsp;with&nbsp;its&nbsp;property's&nbsp;value,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//which&nbsp;are&nbsp;provided&nbsp;by&nbsp;the&nbsp;user</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddObject()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//to&nbsp;check&nbsp;whether&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(textBox1.Text&nbsp;==&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Can&nbsp;not&nbsp;create&nbsp;Objects&nbsp;with&nbsp;no&nbsp;name!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;((textBox2.Text&nbsp;==&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;&amp;&amp;&nbsp;(textBox3.Text&nbsp;==&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;&amp;&amp;&nbsp;(textBox4.Text&nbsp;==&nbsp;<span class="cs__string">&quot;&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Can&nbsp;not&nbsp;create&nbsp;Objects&nbsp;with&nbsp;no&nbsp;properties&nbsp;at&nbsp;all&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Creating&nbsp;Object&nbsp;of&nbsp;class&nbsp;Objectify&nbsp;and&nbsp;storing&nbsp;all&nbsp;properties&nbsp;of&nbsp;it&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//from&nbsp;user&nbsp;input&nbsp;textboxes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Objectify&nbsp;objectify&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Objectify();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objectify.name&nbsp;=&nbsp;textBox1.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objectify.property1&nbsp;=&nbsp;textBox2.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objectify.property2&nbsp;=&nbsp;textBox3.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objectify.property3&nbsp;=&nbsp;textBox4.Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//adding&nbsp;the&nbsp;Object&nbsp;with&nbsp;its&nbsp;properties&nbsp;in&nbsp;the&nbsp;ArrayList</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;arraylist.Add((<span class="cs__keyword">object</span>)objectify);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//adding&nbsp;this&nbsp;Object&nbsp;Name&nbsp;to&nbsp;the&nbsp;ComboBox&nbsp;so&nbsp;that</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//it&nbsp;can&nbsp;be&nbsp;accessed/referred&nbsp;easily&nbsp;from&nbsp;the</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//dropdown&nbsp;list</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;comboBox1.Items.Add(objectify.name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//method&nbsp;for&nbsp;Button&nbsp;Action&nbsp;when&nbsp;clicked</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//first&nbsp;adding&nbsp;the&nbsp;Object&nbsp;to&nbsp;the&nbsp;ArrayList</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddObject();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//After&nbsp;that&nbsp;clearing&nbsp;the&nbsp;input&nbsp;text&nbsp;fields</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox2.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox3.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox4.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file Form1.cs - main implemntation to the issue of ArrayList is provided here</em>
</li><li><em><em>source code file Form1.Designer.cs - Windows Form Desginer code file</em></em>
</li><li><em>source code file Program.cs - main program file with various main application initialisations</em>
</li></ul>
<h1>More Information</h1>
<h3><strong>Written by Somdip Dey, Software Engineer, Steanne Solutions Ltd., UK</strong></h3>
