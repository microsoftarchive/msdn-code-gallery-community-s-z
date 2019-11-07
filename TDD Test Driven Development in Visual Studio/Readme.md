# TDD Test Driven Development in Visual Studio
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Test Driven Development
- Unit Tests
## Topics
- Unit Testing
- Test Driven Development
## Updated
- 07/15/2016
## Description

<h1><img id="156634" src="156634-tdd_cycle.jpg" alt="" width="295" height="295" style="font-size:10px"></h1>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">Over the years I have seen developers write code without first writing formal requirements and designs to properly write a solution. At one point or another each of us at one time or another have fallen prey to sitting down
 and writing code on the fly. The problem may not be apparent until the developer runs into errors when running the program in the development stages or that exceptions are thrown when a customer runs your program. At this point the logical choice is to ask
 the customer questions to what they did to lead up to the exception being throw or you were thoughtful to write exceptions to a log file and perhaps in tangent with sending an email to yourself with details of the exception. You can also surmise that the error
 came from a particular section of code and begin setting break-points to see if you can reproduce the same error (which may not be possible if the issue is environmental).</span><br>
<br>
<span style="font-size:small">An alternate approach is TDD (Test Driven Development) along with formal requirements. This way you work off the requirements, write unit test for each operation. In the purest form you write a unit test with no regards to what
 is needed e.g. a class or classes, an input element etc., run the test, what are the failure points?</span><br>
<br>
<span style="font-size:small">For this demo we want to work with customers in a database. Here I created a SQL-Server database (named it Customers_TDD) with common fields in a Customer table, primary key of type integer, first and last name along with gender
 and country name.</span><br>
<br>
<span style="font-size:small">So now rather than writing code to access the table in the database we will write code from a unit test in Microsoft Visual Studio to work with the database.</span><br>
<br>
<span style="font-size:small">We create a new blank solution in Visual Studio, add a new C# test project named BackendUnitTest and a new C# class project named CustomersDataOperations (we could had left it named Class1 and generated CustomersDataOperations
 using Visual Studio too). In the class project rename the default class from Class1 to DataOperations.cs.</span><br>
<br>
<span style="font-size:small">Add a reference to CustomersDataOperations into the test project.</span><br>
<br>
<span style="font-size:small">Detach the database from SQL-Server, best done in SQL-Server Management Studio and place a copy of the database into the bin\Debug folder of the unit test project.</span><br>
<br>
<span style="font-size:small">In the unit test file UnitTest1.cs (feel free to rename this file) rename the method TestMethod1 to ConnectionTest.</span><br>
<br>
<span style="font-size:small">So we want to first have a method to get all customers, we will call this method in DataOperations class GetAllCustomers. To do TDD we write just enough code to perform a test, remember I am not going to the purest form which goes
 into more details such as checking the database connection string and if there is a method for obtaining our data.</span><br>
<br>
<span style="font-size:small">Here is all we need at this point, enough to test our connection.&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class DataOperations
{
    private string ConnectionString = $@&quot;Data Source=(LocalDB)\v11.0;AttachDbFilename={System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory)}\Northwind_Demo.mdf;Integrated Security=True;Connect Timeout=3&quot;;
    public bool GetAllCustomers()
    {
        using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
        {
            try
            {
                cn.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DataOperations&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ConnectionString&nbsp;=&nbsp;$@<span class="cs__string">&quot;Data&nbsp;Source=(LocalDB)\v11.0;AttachDbFilename={System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory)}\Northwind_Demo.mdf;Integrated&nbsp;Security=True;Connect&nbsp;Timeout=3&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;GetAllCustomers()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SqlConnection&nbsp;cn&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection()&nbsp;{&nbsp;ConnectionString&nbsp;=&nbsp;ConnectionString&nbsp;})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p><span style="font-size:small">Then in the unit test</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void ConnectionTest()
    {
        DataOperations da = new DataOperations();
        Assert.IsTrue(da.GetAllCustomers(), &quot;Connection failed&quot;);
    }
}
</pre>
<div class="preview">
<pre class="js">[TestClass]&nbsp;
public&nbsp;class&nbsp;UnitTest1&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[TestMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;ConnectionTest()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataOperations&nbsp;da&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataOperations();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsTrue(da.GetAllCustomers(),&nbsp;<span class="js__string">&quot;Connection&nbsp;failed&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">In Visual Studio with the Text Explorer window open (you get to this window from the IDE menu, Test, Windows, Test Explorer) press run all test or for the Enterprise edition you can run the test via
 CodeLens above the test method signature. After the test executes a red X appears and the error text is from the second parameter of IsTrue method. Hey wait a minute that should had worked. First thing to do is check the connection string. Oh there is the
 problem, a connection string was copied from another project without changing the database name. We could had check to see if the database physically existed in the DataOperations class but what if the database was attached to a server? Then we could write
 a unit test to check if the database exists on the server or assume your install program handled the database and if there were issues the installer would report the problem as a bad install and remove the program.</span><br>
<br>
<span style="font-size:small">So now that the connection string has been changed to point to the correct database, re-run the test again. This should then pass. If it does not pass you need to figure out why the database failed to open.</span><br>
<br>
<span style="font-size:small">Let&rsquo;s pause for a moment, geez, this is really slowing me down writing code, do I really want to stay on the path of TDD? Well some will argue that they don&rsquo;t have time to devote to writing unit test. Well the benefit
 is that tomorrow or a year from now there is an issue with database operations, rather than debug the problem we can simply run selected unit test or all unit test and look for failures which should more likely than not pinpoint the problem.</span><br>
<br>
<span style="font-size:small">Let&rsquo;s continue, sticking with the existing code add a property of type DataTable and a command object to hold the data.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class DataOperations
{
    private string ConnectionString = $@&quot;Data Source=(LocalDB)\v11.0;AttachDbFilename={System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory)}\Customers_TDD.mdf;Integrated Security=True;Connect Timeout=3&quot;;
    public DataTable CustomerTable  { get; set; }
    public bool GetAllCustomers()
    {
        using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
        {
            using (SqlCommand cmd = new SqlCommand() { Connection = cn, CommandText = &quot;SELECT * FROM Customers&quot; })
            {
                try
                {
                    cn.Open();
                    CustomerTable.Load(cmd.ExecuteReader());
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DataOperations&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ConnectionString&nbsp;=&nbsp;$@<span class="cs__string">&quot;Data&nbsp;Source=(LocalDB)\v11.0;AttachDbFilename={System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory)}\Customers_TDD.mdf;Integrated&nbsp;Security=True;Connect&nbsp;Timeout=3&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DataTable&nbsp;CustomerTable&nbsp;&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;GetAllCustomers()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SqlConnection&nbsp;cn&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection()&nbsp;{&nbsp;ConnectionString&nbsp;=&nbsp;ConnectionString&nbsp;})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SqlCommand&nbsp;cmd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand()&nbsp;{&nbsp;Connection&nbsp;=&nbsp;cn,&nbsp;CommandText&nbsp;=&nbsp;<span class="cs__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;Customers&quot;</span>&nbsp;})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomerTable.Load(cmd.ExecuteReader());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Run the test, it should fail, the reason is we have not initialized the DataTable but that may not be apparent to you. We add the following as the first line in GetAllCustomers</span>&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">CustomerTable = new DataTable();</pre>
<div class="preview">
<pre class="js">CustomerTable&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataTable();</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Rerun the test, this time success. Add a new unit test as per below that will work with the same method GetAllCustomers but this time we are checking to see if data came back e.g. testing our SQL statement
 as there are no rows in the database table. We know the test worked from the count of zero being returned. This test can be renamed and refactored as data is added e.g. Row.Count &gt;0.&nbsp;</span></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void ConnectionTest()
    {
        DataOperations da = new DataOperations();
        Assert.IsTrue(da.GetAllCustomers(), &quot;Connection failed&quot;);
    }
    [TestMethod]
    public void ReturnTableDataWithNoRecordsTest()
    {
        DataOperations da = new DataOperations();
        if (da.GetAllCustomers())
        {
            Assert.IsTrue((da.CustomerTable.Rows.Count == 0), &quot;No records found&quot;);
        }
    }
}
</pre>
<div class="preview">
<pre class="js">[TestClass]&nbsp;
public&nbsp;class&nbsp;UnitTest1&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[TestMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;ConnectionTest()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataOperations&nbsp;da&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataOperations();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsTrue(da.GetAllCustomers(),&nbsp;<span class="js__string">&quot;Connection&nbsp;failed&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[TestMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;ReturnTableDataWithNoRecordsTest()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataOperations&nbsp;da&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataOperations();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(da.GetAllCustomers())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsTrue((da.CustomerTable.Rows.Count&nbsp;==&nbsp;<span class="js__num">0</span>),&nbsp;<span class="js__string">&quot;No&nbsp;records&nbsp;found&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Let&rsquo;s get into another test to remove a customer by taking the last test and making a new one with a new name.</span>&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[TestMethod]
public void RemoveCustomerTest()
{
    DataOperations da = new DataOperations();
    if (da.GetAllCustomers())
    {
                
    }
}
</pre>
<div class="preview">
<pre class="js">[TestMethod]&nbsp;
public&nbsp;<span class="js__operator">void</span>&nbsp;RemoveCustomerTest()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DataOperations&nbsp;da&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataOperations();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(da.GetAllCustomers())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Change the method name as per below</span>&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[TestMethod]
public void RemoveCustomerTest()
{
    DataOperations da = new DataOperations();
    if (da.RemoveCustomer(Identifier))
    {
                
    }
}
</pre>
<div class="preview">
<pre class="js">[TestMethod]&nbsp;
public&nbsp;<span class="js__operator">void</span>&nbsp;RemoveCustomerTest()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DataOperations&nbsp;da&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataOperations();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(da.RemoveCustomer(Identifier))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Note that the method name is undefined as is the parameter Identifier. Hover over RemoveCustomer and Visual Studio presents a lightbulb. Select &ldquo;Show potential fixes&rdquo;. Select the option
 to generate the method. Do the same for Identifier but general a local variable. Since Identifier was undefined we must change it to a int for the method and variable.&nbsp;</span></div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">var Identifier = 1;
if (da.RemoveCustomer(Identifier))
{
    
}
</pre>
<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;Identifier&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;
<span class="js__statement">if</span>&nbsp;(da.RemoveCustomer(Identifier))&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">And</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public bool RemoveCustomer(int identifier)
{
    throw new NotImplementedException();
}
</pre>
<div class="preview">
<pre class="js">public&nbsp;bool&nbsp;RemoveCustomer(int&nbsp;identifier)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>&nbsp;<span class="js__operator">new</span>&nbsp;NotImplementedException();&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">We will remove the throw and use the following code.</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public bool RemoveCustomer(int identifier)
{
    using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
    {
        using (SqlCommand cmd = new SqlCommand() { Connection = cn, CommandText = &quot;DELETE FROM Customers WHERE ID = @ID&quot; })
        {
            cmd.Parameters.AddWithValue(&quot;@ID&quot;, identifier);
            try
            {
                cn.Open();

                return (cmd.ExecuteNonQuery() &gt; 0);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
</pre>
<div class="preview">
<pre class="js">public&nbsp;bool&nbsp;RemoveCustomer(int&nbsp;identifier)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(SqlConnection&nbsp;cn&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SqlConnection()&nbsp;<span class="js__brace">{</span>&nbsp;ConnectionString&nbsp;=&nbsp;ConnectionString&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(SqlCommand&nbsp;cmd&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SqlCommand()&nbsp;<span class="js__brace">{</span>&nbsp;Connection&nbsp;=&nbsp;cn,&nbsp;CommandText&nbsp;=&nbsp;<span class="js__string">&quot;DELETE&nbsp;FROM&nbsp;Customers&nbsp;WHERE&nbsp;ID&nbsp;=&nbsp;@ID&quot;</span>&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="js__string">&quot;@ID&quot;</span>,&nbsp;identifier);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;(cmd.ExecuteNonQuery()&nbsp;&gt;&nbsp;<span class="js__num">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Our test now.</div>
</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[TestMethod]
public void RemoveCustomerTest()
{
    DataOperations da = new DataOperations();
    var Identifier = 1;
    Assert.IsTrue(da.RemoveCustomer(Identifier), &quot;Record not removed or record did not exists&quot;);
}
</pre>
<div class="preview">
<pre class="js">[TestMethod]&nbsp;
public&nbsp;<span class="js__operator">void</span>&nbsp;RemoveCustomerTest()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DataOperations&nbsp;da&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataOperations();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;Identifier&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsTrue(da.RemoveCustomer(Identifier),&nbsp;<span class="js__string">&quot;Record&nbsp;not&nbsp;removed&nbsp;or&nbsp;record&nbsp;did&nbsp;not&nbsp;exists&quot;</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Run the test, this will be a failure because there are no records thus it&rsquo;s impossible to remove one or more records. At this point we need data and there are two direct methods, one enter data into the database table or add
 new records via code prior to attempting a delete then after the test completes remove all the rows just added. The parts are setup, act annihilation. This will be addressed in the next part of TDD along with refactoring the try/catches used so far. I am breaking
 parts down for easy consumption. Hopefully this part is useful enough to get you to consider using TDD. Later parts will go into using
<a href="https://qunitjs.com/cookbook/">QUnit test suite</a> for testing front end web apps.&nbsp;&nbsp;</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="156635" src="156635-guiltycode.png" alt="" width="200" height="200"></div>
</span></div>
</div>
<div class="endscriptcode"></div>
<ul>
</ul>
<h1>More Information</h1>
<p><span style="font-size:small"><em>The three rules of TDD&nbsp;</em></span></p>
<p><span style="font-size:small"><em><a href="http://butunclebob.com/ArticleS.UncleBob.TheThreeRulesOfTdd">http://butunclebob.com/ArticleS.UncleBob.TheThreeRulesOfTdd</a></em></span></p>
<p><em><br>
</em></p>
