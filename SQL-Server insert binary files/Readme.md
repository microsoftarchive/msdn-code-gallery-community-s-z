# SQL-Server insert binary files
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Data Access
- Data Platform
## Topics
- SQL
- SQL Server
- Windows Forms
- Entity Framework
- access data from SQL server
## Updated
- 05/29/2019
## Description

<h1>Description</h1>
<p><span style="font-size:small">This code sample shows how to write physical files from disk to SQL-Server database. Most of the code was created using SqlClient data provider as many developers are using this provider to interface with SQL-Server databases
 but have included the basics for writing physical files using Microsoft Entity Framework 6. Now before continuing I would like to mention there are some examples on the web but are partial examples used to provide less than what I'm presenting here. What I'm
 presenting are more than enough for you as a developer to learn how to write to a database, read and write back to disk.</span></p>
<p><span style="font-size:small">The first example using the following simple table. We have id as our primary key, FileContents field stores the byte array for our file and FileName for the original file name.</span></p>
<p><span style="font-size:small">FileName may or may not be needed but we do need the first two fields, id and FileContents. You will see id used in the sample code to get a specific file and write back to disk.</span></p>
<p><span style="font-size:small"><img id="162428" src="162428-fig1.jpg" alt="" width="478" height="241"></span></p>
<p><span style="font-size:small">The second example will work with two tables, one table for events e.g. Events table holds names of courses while EventAttachments files associated with the courses.</span></p>
<p><img id="162434" src="162434-fig2.jpg" alt="" width="312" height="484"></p>
<p><span style="font-size:small">Data</span></p>
<p><img id="162435" src="162435-fig3.jpg" alt="" width="720" height="117"></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">SELECT  EventAttachments.id ,
        Events.Description ,
        EventAttachments.FileBaseName &#43; 
		EventAttachments.FileExtention AS FileName ,
        convert(varchar(20),Events.StartDate,0) AS Start ,
        EventAttachments.FileContent
FROM    EventAttachments
        INNER JOIN Events ON EventAttachments.EventId = Events.id;
</pre>
<div class="preview">
<pre class="mysql"><span class="sql__keyword">SELECT</span>&nbsp;&nbsp;<span class="sql__id">EventAttachments</span>.<span class="sql__id">id</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">Events</span>.<span class="sql__id">Description</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">EventAttachments</span>.<span class="sql__id">FileBaseName</span>&nbsp;&#43;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">EventAttachments</span>.<span class="sql__id">FileExtention</span>&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__id">FileName</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">convert</span>(<span class="sql__keyword">varchar</span>(<span class="sql__number">20</span>),<span class="sql__keyword">Events</span>.<span class="sql__id">StartDate</span>,<span class="sql__number">0</span>)&nbsp;<span class="sql__keyword">AS</span>&nbsp;<span class="sql__keyword">Start</span>&nbsp;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">EventAttachments</span>.<span class="sql__id">FileContent</span>&nbsp;
<span class="sql__keyword">FROM</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">EventAttachments</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">INNER</span>&nbsp;<span class="sql__keyword">JOIN</span>&nbsp;<span class="sql__keyword">Events</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;<span class="sql__id">EventAttachments</span>.<span class="sql__id">EventId</span>&nbsp;=&nbsp;<span class="sql__keyword">Events</span>.<span class="sql__id">id</span>;&nbsp;
</pre>
</div>
</div>
</div>
<p><span style="font-size:small">Hopefully that paints a picture for our data.</span></p>
<p><span style="font-size:small">About the code, everything for working with the data is within a class. The first method gets a HTML file from the app folder, converts it to a byte array followed by using SqlClient connection and command objects to insert
 the file.&nbsp;</span></p>
<p><span style="font-size:small">The following code from our first method is responsible for obtaining bytes to represent our file in the database.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">byte[] fileByes;

using (var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
{
    using (var reader = new BinaryReader(stream))
    {
        fileByes = reader.ReadBytes((int)stream.Length);
    }
}</pre>
<div class="preview">
<pre class="js">byte[]&nbsp;fileByes;&nbsp;
&nbsp;
using&nbsp;(<span class="js__statement">var</span>&nbsp;stream&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FileStream(FilePath,&nbsp;FileMode.Open,&nbsp;FileAccess.Read))&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;reader&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;BinaryReader(stream))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fileByes&nbsp;=&nbsp;reader.ReadBytes((int)stream.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">The next point is the SQL INSERT statement, the first part does the insert while the last part gets us the new primary key while in the Entity Framework example this is done for us.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">INSERT INTO Table1 (FileContents,FileName) VALUES (@FileContents,@FileName);SELECT CAST(scope_identity() AS int);</pre>
<div class="preview">
<pre class="js">INSERT&nbsp;INTO&nbsp;Table1&nbsp;(FileContents,FileName)&nbsp;VALUES&nbsp;(@FileContents,@FileName);SELECT&nbsp;CAST(scope_identity()&nbsp;AS&nbsp;int);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"><span style="font-size:small">The method used returns the a bool indicating if the insert was successfull, if not I wrapped the code in a try/catch and push the exception message to a property ExceptionMessage back to the caller
 while if successful we can use the new key passed in by ref.</span></div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var ops = new DataOperations();
var Identifier = 0;
var fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, &quot;Dogma1.html&quot;);

if (ops.FilePutSimple(fileName, ref Identifier, &quot;Dogma1.html&quot;))
{
    MessageBox.Show($&quot;Id is {Identifier}&quot;);
}
else
{
    MessageBox.Show($&quot;Failed: {ops.ExceptionMessage}&quot;);
}</pre>
<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;ops&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataOperations();&nbsp;
<span class="js__statement">var</span>&nbsp;Identifier&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
<span class="js__statement">var</span>&nbsp;fileName&nbsp;=&nbsp;System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,&nbsp;<span class="js__string">&quot;Dogma1.html&quot;</span>);&nbsp;
&nbsp;
<span class="js__statement">if</span>&nbsp;(ops.FilePutSimple(fileName,&nbsp;ref&nbsp;Identifier,&nbsp;<span class="js__string">&quot;Dogma1.html&quot;</span>))&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show($<span class="js__string">&quot;Id&nbsp;is&nbsp;{Identifier}&quot;</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
<span class="js__statement">else</span>&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show($<span class="js__string">&quot;Failed:&nbsp;{ops.ExceptionMessage}&quot;</span>);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Screen shot for the above</div>
<div class="endscriptcode"><img id="162440" src="162440-screen1.jpg" alt="" width="583" height="272">&nbsp;</div>
<br>
</span></div>
<div class="endscriptcode"><span style="font-size:small">Screen shot for Entity Framework example</span></div>
<div class="endscriptcode"><img id="162442" src="162442-screen2.jpg" alt="" width="709" height="278"></div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;</span></div>
<div class="endscriptcode"><span style="font-size:small">I did much less in Entity Framework as most Windows Desktop developers are more into SqlClient but that should not hold you back once you see the code it's easy to add in the write back to disk if you
 follow the pattern used in the first example,</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><strong><span style="font-size:small">IMPORTANT</span></strong></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"><span style="font-size:small">I did not include the database but did include a script to create the database, tables and relational schema. Lines 11 and 13 may need to be altered, they are used to create the database in the default
 install folder for SQL-Server professional, if you have Express edition then more likely than not the path will need to change.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:x-small"><span style="font-size:small">If you have SQL-Server Management Studio, run the script there, if not simple open the script, attach to your server and run the script</span>.</span></div>
<div class="endscriptcode"><span style="font-size:x-small"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:x-small"><img id="162450" src="162450-22.jpg" alt="" width="510" height="113"><br>
</span></div>
<div class="endscriptcode"><span style="font-size:x-small"><br>
</span></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><em><em>.</em></em></p>
<p><span style="font-size:small">Script to create database with data</span></p>
<p><em><em><a href="https://1drv.ms/u/s!AtGAgKKpqdWjjTKecmCgkCL2nk6Z">https://1drv.ms/u/s!AtGAgKKpqdWjjTKecmCgkCL2nk6Z</a><br>
</em></em></p>
<h1>More Information</h1>
<p><span style="font-size:small">Some of my other code samples on working with databases and note they all (like this code sample) use parameters when interacting with database tables and one shows working with Stored Procedures.</span></p>
<p><span style="font-size:small"><a href="https://code.msdn.microsoft.com/DataGridView-add-update-7eda9f61?redir=0">DataGridView add, update, delete via SqlClient data provider C#</a>.</span></p>
<p><span style="font-size:small"><a href="https://code.msdn.microsoft.com/Adding-new-records-into-bff5eaaf?redir=0">Adding new records into SQL-Server table and update a DataGridView in real time</a>.</span></p>
<p><span style="font-size:small"><a href="https://code.msdn.microsoft.com/Adding-new-records-into-53ce3eb1?redir=0">Adding new records into Microsoft Access tables and display in a DataGridView</a>.</span></p>
<p><span style="font-size:small"><a href="https://code.msdn.microsoft.com/Reading-and-writing-to-MS-945a0615?redir=0">Reading and writing images to MS-Access 2007 and higher databases</a>.</span></p>
<p><span style="font-size:small"><a href="https://code.msdn.microsoft.com/SQL-stored-procedures-1384f04c?redir=0">SQL stored procedures primer</a>.</span></p>
<p><span style="font-size:small"><a href="https://code.msdn.microsoft.com/Reveal-parameter-values-28725e53?redir=0">Reveal parameter values from a Command object</a>.</span></p>
<p><span style="font-size:small"><a href="https://code.msdn.microsoft.com/Entity-Framework-in-764fa5ba?redir=0">Entity Framework in Windows forms part 4</a>.</span></p>
<p><span style="font-size:small"><a href="https://code.msdn.microsoft.com/INSERT-Image-into-SQL-29dfc8ee?redir=0">INSERT Image into SQL-Server using stored procedures</a>.</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:small"><br>
</span></p>
