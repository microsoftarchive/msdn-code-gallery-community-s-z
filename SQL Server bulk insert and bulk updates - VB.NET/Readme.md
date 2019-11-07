# SQL Server bulk insert and bulk updates - VB.NET
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- SQL
- SQL Server
- Class Library
- Windows Forms
- VB.Net
- SQL Merge
- SQL Bulk Copy
## Topics
- SQL
- SQL Server
- Bulk Update
- TSQL
- Bulk Insert
## Updated
- 10/02/2017
## Description

<h1>Description</h1>
<p><span style="font-size:small">This code sample shows the very basics for doing bulk inserts from data presented in a DataGridView that does not have it&rsquo;s data source set. Also demonstrates how to do a bulk operation on the same data where in a single
 operation the original data is upset (meaning if in the new data source a record was modified or deleted it&rsquo;s reflected in the source/original table) and additions are added to the source table.</span></p>
<p><span style="font-size:small"><strong>C# version</strong> is <a href="https://code.msdn.microsoft.com/SQL-Server-bulk-insert-and-8ba4b22a">
here</a>.</span></p>
<p><span style="font-size:small">So let&rsquo;s say you read from a text file into a DataGridView and now want to insert the data into our SQL-Server table most developers would use a connection and command objects coupled with parameters for the command object
 and use a for each to execute the method ExecuteNonQuery for each row of data which is time consuming. Instead in this code sample I use a method from SqlClient data provider (same as for connections and commands) to do a bulk insert via
<a href="https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlbulkcopy%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396">
SqlBulkCopy</a>.WriteToServer method which is an overloaded method.</span></p>
<p><br>
<span style="font-size:small">In the SqlBulkCopy I setup a transaction and allow you to control how many rows are written via BatchSize method of SqlBulkCopy. If there are issues/exceptions they can be presented to the caller via a special class which indicates
 there was an exception and also provides the exception message.</span></p>
<p><br>
<span style="font-size:small">Now let&rsquo;s pause for a second, a seasoned developer 99 percent of the time will load a DataGridView from a DataTable or a list of a concrete class. Well if you look closely at the code although I don&rsquo;t use the data source
 of the DataGridView when exporting I convert the data in the DataGridView to a list of a concrete class which in turn is pushed to a DataTable. So if you loaded data via a DataTable into a DataGridView you would skip the concrete class altogether as all we
 need is the DataTable.</span></p>
<p><br>
<span style="font-size:small">The second part of the code sample reads data that was just exported into a DataTable, presented to the user in another DataGridView which is editable. Make changes, add, delete, edit and they are sent to a SQL statement which
 will be pushed to a temp table then merge the changes back to the original &nbsp;table just imported from the DataGridView at the start of the project.</span></p>
<p><br>
<span style="font-size:small">Please note, the SqlBulkCopy pushes 5,000 plus records to the back end database while the merge operation uses only eight records (you can change that in DataOperations class by removal of TOP 8 in the SELECT statement). If you
 leave as is, TOP 8 the merge operation will leave 8 records because the merge operation will not find a match for the other records and remove them as one of the rules for the merge operation.&nbsp;</span></p>
<p><span style="font-size:small">TIPS</span></p>
<p><span style="font-size:small">Don't simply write the merge operation in code, first write the query either in SQL-Server Management Studio or by creating a text file in your project and giving it an extension of .sql to write the query.</span></p>
<p><span style="font-size:small">What I did was create the Person table, added data. Then made a copy into a table named Person1. Write the merge query and worked through the syntax until it was correct.</span></p>
<p><span style="font-size:small">Here is my working copy in SQL-Server Management Studio.</span></p>
<p><span style="font-size:small"><img id="179438" src="179438-1.jpg" alt="" width="335" height="378"><br>
</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">I then had two SELECT statement, one for Person and one for Person1 in the same query window using a semi-colon to separate them thus when executing them I could see the results top to bottom.</span></p>
<p><span style="font-size:small">Since we don't want to have a secondary table hanging around I modified for the code sample to use a temp table which is created, used then dropped e.g.</span></p>
<p><span style="font-size:small"><img id="179439" src="179439-2.jpg" alt="" width="357" height="373"><br>
</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Next up in regards to T-SQL MERGE, take time to read
<a href="https://docs.microsoft.com/en-us/sql/t-sql/statements/merge-transact-sql">
the documentation</a> as I've only given you an introduction to merging. SQL-Server 2008 is when the MERGE operation became available do older versions will not support it.</span></p>
<p><span style="font-size:small">In closing, I've focused on using the bulk copy and merge in a windows form application yet you can also use this in web applications also, even Entity Framework using the same methods or I know there are third party libraries
 on NuGet that support bulk operations for Entity Framework e.g. <a href="https://www.nuget.org/packages/Z.EntityFramework.Plus.EF6/">
Z.EntityFramework.Plus.EF6</a>.</span></p>
<h1><span style="font-size:small">Before running the code</span></h1>
<ol>
<li><span style="font-size:small">Create the database via the SQL script GenerateDatabase.sql
</span></li><li><span style="font-size:small">In DataOperations and PersonExporter classes modify the connection string &quot;Data Source&quot; from KARENS-PC to the name of your SQL-Server.</span>
</li></ol>
