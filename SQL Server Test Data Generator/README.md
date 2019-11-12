# SQL Server Test Data Generator
## License
- MIT
## Technologies
- SQL
- SQL Server
- Testing
- SQL database
## Topics
- SQL
- SQL Server
- Performance testing
- Databases
- Testing
## Updated
- 12/06/2016
## Description

<h1><strong>Building the Sample</strong></h1>
<p>Works for SQL Server 2012 and latest.</p>
<p><a title="dbForge Studio for SQL Server" href="https://www.devart.com/dbforge/sql/studio/" target="_blank">dbForge Studio for SQL Server</a>&nbsp;is used for writing and executing T-SQL code.</p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p>Software testing plays an important role in the development of any software product.&nbsp;The database testing is as much important as the application code testing.&nbsp;However,without test data in the test environment, it is quite impossible to predict
 the way the database will behave after the release. The following example demonstrates, &nbsp;how to generate test data to be used in the test environment.In this example we will use the power of T-SQL syntax, to generate random test data for your database
 table. Later, we will see how to transform randomly generated data set to the meaningful one.<br>
First, we need to create a test databse. The database contains only one test table. The table contains the following columns: CustomerID, Fullname, Email, Phone.</p>
<p>Here is the T-SQL code that creates the demo database with the demo table:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Из&#1084;енение сценария</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">USE</span>&nbsp;[<span class="sql__keyword">master</span>]&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">IF</span>&nbsp;<span class="sql__id">DB_ID</span>(<span class="sql__string">'data_generator_demo'</span>)&nbsp;<span class="sql__keyword">IS</span>&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>&nbsp;
<span class="sql__keyword">BEGIN</span>&nbsp;
&nbsp;&nbsp;<span class="sql__keyword">ALTER</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">data_generator_demo</span>]&nbsp;<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">SINGLE_USER</span>&nbsp;<span class="sql__keyword">WITH</span>&nbsp;<span class="sql__keyword">ROLLBACK</span>&nbsp;<span class="sql__id">IMMEDIATE</span>&nbsp;
&nbsp;&nbsp;<span class="sql__keyword">DROP</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">data_generator_demo</span>]&nbsp;
<span class="sql__keyword">END</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;[<span class="sql__id">data_generator_demo</span>]&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">USE</span>&nbsp;[<span class="sql__id">data_generator_demo</span>]&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;<span class="sql__id">dbo</span>.<span class="sql__id">test</span>&nbsp;(&nbsp;
&nbsp;&nbsp;[<span class="sql__id">CustomerID</span>]&nbsp;<span class="sql__keyword">INT</span>&nbsp;<span class="sql__id">IDENTITY</span>&nbsp;<span class="sql__keyword">PRIMARY</span>&nbsp;<span class="sql__keyword">KEY</span>&nbsp;
&nbsp;,[<span class="sql__id">FullName</span>]&nbsp;<span class="sql__keyword">NVARCHAR</span>(<span class="sql__number">150</span>)&nbsp;
&nbsp;,[<span class="sql__id">Email</span>]&nbsp;<span class="sql__keyword">VARCHAR</span>(<span class="sql__number">50</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>&nbsp;
&nbsp;,[<span class="sql__id">Phone</span>]&nbsp;<span class="sql__keyword">VARCHAR</span>(<span class="sql__number">50</span>)&nbsp;
)&nbsp;
<span class="sql__id">GO</span>&nbsp;
</pre>
</div>
</div>
</div>
<p>The following script will generate the random data set for the table:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Из&#1084;енение сценария</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">DECLARE&nbsp;@obj&nbsp;INT&nbsp;=&nbsp;OBJECT_ID(<span class="js__string">'dbo.test'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;@sql&nbsp;NVARCHAR(MAX)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;@cnt&nbsp;INT&nbsp;=&nbsp;<span class="js__num">10</span>&nbsp;
&nbsp;
;WITH&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;E1(N)&nbsp;AS&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;*&nbsp;FROM&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VALUES&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;t(N)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;E2(N)&nbsp;AS&nbsp;(SELECT&nbsp;<span class="js__num">1</span>&nbsp;FROM&nbsp;E1&nbsp;a,&nbsp;E1&nbsp;b),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;E4(N)&nbsp;AS&nbsp;(SELECT&nbsp;<span class="js__num">1</span>&nbsp;FROM&nbsp;E2&nbsp;a,&nbsp;E2&nbsp;b),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;E8(N)&nbsp;AS&nbsp;(SELECT&nbsp;<span class="js__num">1</span>&nbsp;FROM&nbsp;E4&nbsp;a,&nbsp;E4&nbsp;b)&nbsp;
SELECT&nbsp;@sql&nbsp;=&nbsp;'&nbsp;
DELETE&nbsp;FROM&nbsp;'&nbsp;&#43;&nbsp;QUOTENAME(OBJECT_SCHEMA_NAME(@obj))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;<span class="js__string">'.'</span>&nbsp;&#43;&nbsp;QUOTENAME(OBJECT_NAME(@obj))&nbsp;&#43;&nbsp;'&nbsp;
&nbsp;
;WITH&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;E1(N)&nbsp;AS&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;*&nbsp;FROM&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VALUES&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;t(N)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;E2(N)&nbsp;AS&nbsp;(SELECT&nbsp;<span class="js__num">1</span>&nbsp;FROM&nbsp;E1&nbsp;a,&nbsp;E1&nbsp;b),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;E4(N)&nbsp;AS&nbsp;(SELECT&nbsp;<span class="js__num">1</span>&nbsp;FROM&nbsp;E2&nbsp;a,&nbsp;E2&nbsp;b),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;E8(N)&nbsp;AS&nbsp;(SELECT&nbsp;<span class="js__num">1</span>&nbsp;FROM&nbsp;E4&nbsp;a,&nbsp;E4&nbsp;b)&nbsp;
INSERT&nbsp;INTO&nbsp;'&nbsp;&#43;&nbsp;QUOTENAME(OBJECT_SCHEMA_NAME(@obj))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;<span class="js__string">'.'</span>&nbsp;&#43;&nbsp;QUOTENAME(OBJECT_NAME(@obj))&nbsp;&#43;&nbsp;<span class="js__string">'('</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;STUFF((&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;<span class="js__string">',&nbsp;'</span>&nbsp;&#43;&nbsp;QUOTENAME(name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FROM&nbsp;sys.columns&nbsp;c&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WHERE&nbsp;c.[object_id]&nbsp;=&nbsp;@obj&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AND&nbsp;c.is_identity&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AND&nbsp;c.is_computed&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FOR&nbsp;XML&nbsp;PATH(<span class="js__string">''</span>),&nbsp;TYPE).value(<span class="js__string">'.'</span>,&nbsp;<span class="js__string">'NVARCHAR(MAX)'</span>),&nbsp;<span class="js__num">1</span>,&nbsp;<span class="js__num">2</span>,&nbsp;<span class="js__string">''</span>)&nbsp;
&#43;&nbsp;')&nbsp;
SELECT&nbsp;TOP(<span class="js__string">'&nbsp;&#43;&nbsp;CAST(@cnt&nbsp;AS&nbsp;VARCHAR(10))&nbsp;&#43;&nbsp;'</span>)&nbsp;'&nbsp;&#43;&nbsp;
STUFF((&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;'&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;<span class="js__string">'&nbsp;&#43;&nbsp;QUOTENAME(name)&nbsp;&#43;&nbsp;'</span>&nbsp;=&nbsp;'&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CASE&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WHEN&nbsp;TYPE_NAME(c.system_type_id)&nbsp;IN&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'varchar'</span>,&nbsp;<span class="js__string">'char'</span>,&nbsp;<span class="js__string">'nvarchar'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'nchar'</span>,&nbsp;<span class="js__string">'ntext'</span>,&nbsp;<span class="js__string">'text'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;THEN&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;STUFF((&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;TOP(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CASE&nbsp;WHEN&nbsp;max_length&nbsp;=&nbsp;-<span class="js__num">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;THEN&nbsp;CAST(RAND()&nbsp;*&nbsp;<span class="js__num">10000</span>&nbsp;AS&nbsp;INT)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ELSE&nbsp;max_length&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;END&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CASE&nbsp;WHEN&nbsp;TYPE_NAME(c.system_type_id)&nbsp;IN&nbsp;(<span class="js__string">'nvarchar'</span>,&nbsp;<span class="js__string">'nchar'</span>,&nbsp;<span class="js__string">'ntext'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;THEN&nbsp;<span class="js__num">2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ELSE&nbsp;<span class="js__num">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;END&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;<span class="js__string">'&#43;SUBSTRING(x,&nbsp;(ABS(CHECKSUM(NEWID()))&nbsp;%&nbsp;80)&nbsp;&#43;&nbsp;1,&nbsp;1)'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FROM&nbsp;E8&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FOR&nbsp;XML&nbsp;PATH(<span class="js__string">''</span>),&nbsp;TYPE).value(<span class="js__string">'.'</span>,&nbsp;<span class="js__string">'NVARCHAR(MAX)'</span>),&nbsp;<span class="js__num">1</span>,&nbsp;<span class="js__num">1</span>,&nbsp;<span class="js__string">''</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WHEN&nbsp;TYPE_NAME(c.system_type_id)&nbsp;=&nbsp;<span class="js__string">'tinyint'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;THEN&nbsp;<span class="js__string">'50&nbsp;&#43;&nbsp;CRYPT_GEN_RANDOM(10)&nbsp;%&nbsp;50'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WHEN&nbsp;TYPE_NAME(c.system_type_id)&nbsp;IN&nbsp;(<span class="js__string">'int'</span>,&nbsp;<span class="js__string">'bigint'</span>,&nbsp;<span class="js__string">'smallint'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;THEN&nbsp;<span class="js__string">'CRYPT_GEN_RANDOM(10)&nbsp;%&nbsp;25000'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WHEN&nbsp;TYPE_NAME(c.system_type_id)&nbsp;=&nbsp;<span class="js__string">'uniqueidentifier'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;THEN&nbsp;<span class="js__string">'NEWID()'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WHEN&nbsp;TYPE_NAME(c.system_type_id)&nbsp;IN&nbsp;(<span class="js__string">'decimal'</span>,&nbsp;<span class="js__string">'float'</span>,&nbsp;<span class="js__string">'money'</span>,&nbsp;<span class="js__string">'smallmoney'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;THEN&nbsp;<span class="js__string">'ABS(CAST(NEWID()&nbsp;AS&nbsp;BINARY(6))&nbsp;%&nbsp;1000)&nbsp;*&nbsp;RAND()'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WHEN&nbsp;TYPE_NAME(c.system_type_id)&nbsp;IN&nbsp;(<span class="js__string">'datetime'</span>,&nbsp;<span class="js__string">'smalldatetime'</span>,&nbsp;<span class="js__string">'datetime2'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;THEN&nbsp;'DATEADD(MINUTE,&nbsp;RAND(CHECKSUM(NEWID()))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__num">1</span>&nbsp;&#43;&nbsp;DATEDIFF(MINUTE,&nbsp;<span class="js__string">''</span><span class="js__num">20000101</span><span class="js__string">''</span>,&nbsp;GETDATE())),&nbsp;<span class="js__string">''</span><span class="js__num">20000101</span><span class="js__string">''</span>)'&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WHEN&nbsp;TYPE_NAME(c.system_type_id)&nbsp;=&nbsp;<span class="js__string">'bit'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;THEN&nbsp;<span class="js__string">'ABS(CHECKSUM(NEWID()))&nbsp;%&nbsp;2'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WHEN&nbsp;TYPE_NAME(c.system_type_id)&nbsp;IN&nbsp;(<span class="js__string">'varbinary'</span>,&nbsp;<span class="js__string">'image'</span>,&nbsp;<span class="js__string">'binary'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;THEN&nbsp;<span class="js__string">'CRYPT_GEN_RANDOM(5)'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ELSE&nbsp;<span class="js__string">'NULL'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;END&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FROM&nbsp;sys.columns&nbsp;c&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WHERE&nbsp;c.[object_id]&nbsp;=&nbsp;@obj&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AND&nbsp;c.is_identity&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AND&nbsp;c.is_computed&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FOR&nbsp;XML&nbsp;PATH(<span class="js__string">''</span>),&nbsp;TYPE).value(<span class="js__string">'.'</span>,&nbsp;<span class="js__string">'NVARCHAR(MAX)'</span>),&nbsp;<span class="js__num">1</span>,&nbsp;<span class="js__num">8</span>,&nbsp;'&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;')&nbsp;
&nbsp;&#43;&nbsp;'&nbsp;
FROM&nbsp;E8&nbsp;
CROSS&nbsp;APPLY&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;x&nbsp;=&nbsp;<span class="js__string">''</span><span class="js__num">0123456789</span>-ABCDEFGHIJKLMNOPQRSTUVWXYZ&nbsp;abcdefghijklmnopqrstuvwxyz<span class="js__string">''</span>&nbsp;
)&nbsp;t'&nbsp;
&nbsp;
EXEC&nbsp;sys.sp_executesql&nbsp;@sql&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Here is the result:</div>
<p><img id="165430" src="165430-sample.png" alt="" width="321" height="276"></p>
<p>As you can see, it doesn't look like real data. To fix the problem, we can use the following code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Из&#1084;енение сценария</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">DECLARE&nbsp;@cnt&nbsp;INT&nbsp;=&nbsp;<span class="js__num">10</span>&nbsp;
&nbsp;
DELETE&nbsp;FROM&nbsp;dbo.test&nbsp;
&nbsp;
;WITH&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;E1(N)&nbsp;AS&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;*&nbsp;FROM&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VALUES&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>),(<span class="js__num">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;t(N)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;E2(N)&nbsp;AS&nbsp;(SELECT&nbsp;<span class="js__num">1</span>&nbsp;FROM&nbsp;E1&nbsp;a,&nbsp;E1&nbsp;b),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;E4(N)&nbsp;AS&nbsp;(SELECT&nbsp;<span class="js__num">1</span>&nbsp;FROM&nbsp;E2&nbsp;a,&nbsp;E2&nbsp;b),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;E8(N)&nbsp;AS&nbsp;(SELECT&nbsp;<span class="js__num">1</span>&nbsp;FROM&nbsp;E4&nbsp;a,&nbsp;E4&nbsp;b)&nbsp;
INSERT&nbsp;INTO&nbsp;dbo.test&nbsp;(FullName,&nbsp;Email,&nbsp;Phone)&nbsp;
SELECT&nbsp;TOP(@cnt)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[FullName]&nbsp;=&nbsp;txt&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;[Email]&nbsp;=&nbsp;LOWER(txt)&nbsp;&#43;&nbsp;LEFT(ABS(CHECKSUM(NEWID())),&nbsp;<span class="js__num">3</span>)&nbsp;&#43;&nbsp;<span class="js__string">'@gmail.com'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;[Phone]&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'&#43;38&nbsp;('</span>&nbsp;&#43;&nbsp;LEFT(ABS(CHECKSUM(NEWID())),&nbsp;<span class="js__num">3</span>)&nbsp;&#43;&nbsp;<span class="js__string">')&nbsp;'</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;STUFF(STUFF(LEFT(ABS(CHECKSUM(NEWID())),&nbsp;<span class="js__num">9</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;<span class="js__num">4</span>,&nbsp;<span class="js__num">1</span>,&nbsp;<span class="js__string">'-'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;<span class="js__num">7</span>,&nbsp;<span class="js__num">1</span>,&nbsp;<span class="js__string">'-'</span>)&nbsp;
FROM&nbsp;E8&nbsp;
CROSS&nbsp;APPLY&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;TOP(CAST(RAND(N)&nbsp;*&nbsp;<span class="js__num">10</span>&nbsp;AS&nbsp;INT))&nbsp;txt&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FROM&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VALUES&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(N<span class="js__string">'Boris_the_Blade'</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(N<span class="js__string">'John'</span>),&nbsp;(N<span class="js__string">'Steve'</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(N<span class="js__string">'Mike'</span>),&nbsp;(N<span class="js__string">'Phil'</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(N<span class="js__string">'Sarah'</span>),&nbsp;(N<span class="js__string">'Ann'</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(N<span class="js__string">'Andrey'</span>),&nbsp;(N<span class="js__string">'Liz'</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(N<span class="js__string">'Stephanie'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;t(txt)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ORDER&nbsp;BY&nbsp;NEWID()&nbsp;
)&nbsp;t&nbsp;
</pre>
</div>
</div>
</div>
<p class="endscriptcode">And now the result looks much better:</p>
<p><img id="165431" src="165431-sample2.png" alt="" width="407" height="301"></p>
<p>&nbsp;</p>
<p>This example demonstrates a simple approach of test data generation in SQL Server databases.</p>
