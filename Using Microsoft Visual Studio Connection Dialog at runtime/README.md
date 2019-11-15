# Using Microsoft Visual Studio Connection Dialog at runtime
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- SQL
- SQL Server
- Windows Forms
- Data Access
- Microsoft Visual Studio Connection Dialog
## Topics
- SQL Server
- Data Access
- Microsoft Visual Studio Connection Dialog
## Updated
- 03/12/2017
## Description

<h1>Description</h1>
<p><span style="font-size:small">In Visual Studio when a developer wants to create strong typed classes for database tables either for the conventional TableAdapter or Entity Framework there is a place in the process where a dialog is displayed as shown below.
 I will show you how to do this at runtime and a bit more.</span></p>
<p><img id="170914" src="170914-figure1.jpg" alt="" width="390" height="533"></p>
<p>&nbsp;</p>
<p><span style="font-size:small">This code sample will show you the basics of using this dialog by working with the source code. In the next screenshot I have modified the source code so that any time SQL-Server data provider is used and it's my login I get
 a context menu item that allows me to auto fill the Server Name.</span></p>
<p><img id="170915" src="170915-figure2.jpg" alt="" width="390" height="533"></p>
<p><span style="font-size:small">That is cool but we will now take advantage of this dialog so that (in this code sample) can create a SQL SELECT statement or create a CSV file for a table.</span></p>
<p><span style="font-size:small">To&nbsp;demonstrate this I created a simple windows forms project with the following interface to select a server, select a table, select columns. After making these selections pressing &quot;Generate SQL SELECT&quot; you get the following
 in the second image below.</span></p>
<p><span style="font-size:small"><img id="170916" src="170916-figure3.jpg" alt="" width="565" height="296"></span></p>
<p><span style="font-size:small">From Generate SQL SELECT (this logic can start you on other ideas with this simple example)</span></p>
<p><span style="font-size:small"><img id="170917" src="170917-figure4.jpg" alt="" width="389" height="152"></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Pressing &quot;Export CSV&quot; takes the SQL SELECT statement and passes it off to a process which uses
<a href="https://msdn.microsoft.com/en-us/library/ms162773.aspx?f=255&MSPPError=-2147217396">
SQLCMD.EXE</a>. My Exporter class takes information obtained from the Connection Dialog and selections done in the form to create a CSV file.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.aspx" target="_blank" title="Auto generated link to System.Diagnostics">System.Diagnostics</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
&nbsp;
namespace&nbsp;WindowsFormsApplication1_cs&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;Exporter&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;ToCsv(string&nbsp;ServerName,&nbsp;string&nbsp;DatabaseName,&nbsp;string&nbsp;SelectStatement,&nbsp;string&nbsp;FileName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;DoubleQuote&nbsp;=&nbsp;((char)(<span class="js__num">34</span>)).ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;QueryToExceute&nbsp;=&nbsp;DoubleQuote&nbsp;&#43;&nbsp;SelectStatement&nbsp;&#43;&nbsp;DoubleQuote;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;ExportFileName&nbsp;=&nbsp;DoubleQuote&nbsp;&#43;&nbsp;FileName&nbsp;&#43;&nbsp;DoubleQuote;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;Process&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Process();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Process.StartInfo.UseShellExecute&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Process.StartInfo.RedirectStandardOutput&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Process.StartInfo.RedirectStandardError&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Process.StartInfo.CreateNoWindow&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Process.StartInfo.FileName&nbsp;=&nbsp;<span class="js__string">&quot;SQLCMD.EXE&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Process.StartInfo.Arguments&nbsp;=&nbsp;<span class="js__string">&quot;-S&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ServerName&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;-d&nbsp;&quot;</span>&nbsp;&#43;&nbsp;DatabaseName&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;-E&nbsp;-Q&nbsp;&quot;</span>&nbsp;&#43;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QueryToExceute&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;-o&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ExportFileName&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;&nbsp;-h-1&nbsp;-s\&quot;,\&quot;&nbsp;-w&nbsp;700&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine($<span class="js__string">&quot;SQLCMD.EXE&nbsp;{Process.StartInfo.Arguments}&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Process.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Process.WaitForExit();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.File.Exists.aspx" target="_blank" title="Auto generated link to System.IO.File.Exists">System.IO.File.Exists</a>(FileName))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;contents&nbsp;=&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.File.ReadAllLines.aspx" target="_blank" title="Auto generated link to System.IO.File.ReadAllLines">System.IO.File.ReadAllLines</a>(FileName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Where(line&nbsp;=&gt;&nbsp;!line.ToLower().Contains(<span class="js__string">&quot;rows&nbsp;affected&quot;</span>)&nbsp;&amp;&amp;&nbsp;!string.IsNullOrWhiteSpace(line)).ToArray();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.File.WriteAllLines.aspx" target="_blank" title="Auto generated link to System.IO.File.WriteAllLines">System.IO.File.WriteAllLines</a>(FileName,&nbsp;contents);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">The command for SQLCMD in this case is</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">SQLCMD.EXE -S KARENS-PC -d NorthWindAzure -E -Q &quot;SELECT [ProductID],[ProductName],[UnitsInStock] FROM Products&quot; -o &quot;C:\Data\test.csv&quot; &nbsp;-h-1 -s&quot;,&quot; -w 700</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Partial contents of the file generate</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="170918" src="170918-figure5.jpg" alt="" width="581" height="105"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">How to use in your project</h1>
<div class="endscriptcode"><span style="font-size:small">Looking at the Visual Studio solution, the highlighted in yellow get compiled. Unload the projects in grey.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Open your Visual Studio solution, add a reference to the DLL created in the solution above and now you can use them.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">The project WindowsFormsApplication1_cs shows how to use the dialog and also how to do exporting.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="170925" src="https://i1.code.msdn.s-msft.com/using-visual-studio-a7e740f8/image/file/170925/1/06.jpg" alt="" width="392" height="302"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="170919" src="170919-sampleproject.jpg" alt="" width="258" height="279"></div>
<h1 class="endscriptcode">IMPORTANT</h1>
<div class="endscriptcode"><span style="font-size:small">Things to watch out for concerning
<a href="https://msdn.microsoft.com/en-us/library/ms162773.aspx?f=255&MSPPError=-2147217396">
SQLCMD.EXE</a>, if you attempt to create a export file and get error messages the common reason is that there is an authenication issue which you need to figure out the login and security which is outside the scope of this code sample.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Note in Operations class, GetConnection that the optional parameter SaveConfiguration is false, setting it to true will create a xml file names DataConnections.xml which save the last data provider
 used and will be the default each time until you change it.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="170920" src="170920-43.jpg" alt="" width="593" height="682"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">The two things the connection dialog is good for is when writing code in development and also for when a user at runtime needs to select an alternate server. Needless to say there are many possibilities
 here.</span></div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">Copyrights</h1>
<div class="endscriptcode"><span style="font-size:small">As I did not create the classes for the Connection Dialog they are copyrighted to Microsoft as each class has a copyright notice within.</span></div>
