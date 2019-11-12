# Using MySQL database with UWP
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Microsoft Azure
- MySQL
- UWP
## Topics
- data and storage
## Updated
- 01/24/2016
## Description

<h1><span style="font-size:medium"><strong>&nbsp;</strong></span></h1>
<p>Hey :) In this Sample we'll talk about Azure MySQL DB <a href="https://kinani95.wordpress.com/2015/08/06/using-your-free-mysql-database-from-dreamspark/" target="_blank">
(free for Studentns from Microsoft Imagine Access aka: Dreamspark )</a> How to design it, Basic
<a href="https://msdn.microsoft.com/en-us/library/windows/apps/dn726767.aspx" target="_blank">
UWP </a>todo demo \w/ In a <a href="https://kinani95.wordpress.com/2015/08/06/using-your-free-mysql-database-from-dreamspark/" target="_blank">
previous blog post</a> I talked about the DB creation process, how to obtain the DB info ( host name, username, password, connection string) And also how to connect it to a C# Console App. Now we'll continue assuming you have your DB info.</p>
<h2>Design MySQL DB</h2>
<p>We can use many tools to connect to the DB, but here we'll use the official <a href="http://www.mysql.com/products/workbench" target="_blank">
<strong>MySQL Workbench</strong></a> MySQL Workbench can be downloaded from <a href="http://dev.mysql.com/downloads/workbench/" target="_blank">
here</a> along with the Connectors, What's a Connector? A Connector is the DB driver that you include in your project to be able to interact and connect to your DB through your application. After Installing the Workbench with the default settings. We open it:
<a href="https://kinani95.files.wordpress.com/2016/01/workbenchmain1.png" rel="attachment wp-att-179">
<img class="alignnone wp-image-179" src=":-workbenchmain1.png" alt="workbenchMain" width="703" height="395"></a> &nbsp; Then we click the Add button to add a new DB:
<a href="https://kinani95.files.wordpress.com/2016/01/addbutton.png" rel="attachment wp-att-180">
<img class="alignnone wp-image-180" src=":-addbutton.png" alt="AddButton" width="707" height="397"></a> We insert the DB info then click Ok. Now we click the New DB to establish a connection.
<a href="https://kinani95.files.wordpress.com/2016/01/clickdb.png" rel="attachment wp-att-181">
<img class="alignnone wp-image-181" src=":-clickdb.png" alt="ClickDB" width="711" height="400"></a> Here you can do whatever you want to your DB. let's go and add a Table ( That's what you will usually do :D )
<a href="https://kinani95.files.wordpress.com/2016/01/createtable1.png" rel="attachment wp-att-182">
<img class="alignnone wp-image-182" src=":-createtable1.png" alt="createTable1" width="715" height="402"></a> Now we start adding the columns we need at our DB, in This case we'll need only two columns:</p>
<ul>
<li>idtodo : INT, Primary Key, Not Null, Unique, Auto Incremental </li><li>whatToDO: varchar(200) </li></ul>
<p><a href="https://kinani95.files.wordpress.com/2016/01/createtable2.png" rel="attachment wp-att-183"><img class="alignnone wp-image-183" src=":-createtable2.png" alt="createTable2" width="716" height="402"></a></p>
<p>And <a href="https://kinani95.files.wordpress.com/2016/01/createtable3.png" rel="attachment wp-att-184">
<img class="alignnone size-full x_x_x_x_x_wp-image-184" src=":-createtable3.png" alt="createTable3" width="509" height="428"></a> &nbsp; Then we click apply, wait for a little bit then we review or add any SQL
 Script wee need, Then click <strong>Apply </strong>in the wizard. Note: You can see the script for creating the table, you can absolutely go and execute your script directly without having to walkthrough what I did here.
<a href="https://kinani95.files.wordpress.com/2016/01/createtable4.png" rel="attachment wp-att-185">
<img class="alignnone wp-image-185" src=":-createtable4.png" alt="createTable4" width="712" height="400"></a> The table created successfully and ready to use!
<a href="https://kinani95.files.wordpress.com/2016/01/createtable5.png" rel="attachment wp-att-186">
<img class="alignnone wp-image-186" src=":-createtable5.png" alt="createTable5" width="691" height="388"></a></p>
<h2>UWP Demo (Basic Todo app)</h2>
<p>Before we begin please note that the Dreamspark free MySQL is limited to 4 concurrently connections. So it will be optimal for your private use or for testing purposes. What we'll do?</p>
<ul>
<li>Create the UWP Project </li><li>Reference the connector </li><li>Implementing our MVVM (Model-View-ViewModel) </li></ul>
<p><strong>Creating the project</strong> We click File -&gt; New Project -&gt; from the Installed List we click -&gt; Visual C# -&gt;Windows -&gt; Universal -&gt; then Pick the UWP Project: Blank App (Universal Windows)</p>
<p><strong>Reference the connector</strong></p>
<p><a href="https://kinani95.files.wordpress.com/2016/01/addref.png" rel="attachment wp-att-188"><img class="alignnone wp-image-188" src=":-addref.png" alt="addref" width="723" height="406"></a></p>
<p><strong><br>
</strong></p>
<p>Then we click browse and go to the following path, Please note that the &quot;Connector.NET 6.9&quot; version might differ by the time you're reading this so you should go and look it up yourself. C:\Program Files (x86)\MySQL\Connector.NET 6.9\Assemblies\RT We select
 the connector then we're ready to go.</p>
<p><strong>Implementing the MVVM</strong></p>
<p>We'll only create one page that contains a list of our Todo items, and a Text Box with a button to add the Text Box content as a new Todo.
<strong>Todo Model:</strong></p>
<p><strong>&nbsp;</strong></p>
<div class="scriptcode"><strong>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Todo&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;whatToDO&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Todo(<span class="cs__keyword">string</span>&nbsp;what)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;whatToDO&nbsp;=&nbsp;what;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</strong></div>
<p><strong><br>
</strong></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>ViewModel (TodoViewModel.cs):</strong></p>
<p>&nbsp;</p>
<p><strong>&nbsp;</strong></p>
<div class="scriptcode"><strong>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;TodoViewModel&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;TodoViewModel&nbsp;_todoViewModel&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TodoViewModel();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;ObservableCollection&lt;Todo&gt;&nbsp;_allToDos&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ObservableCollection&lt;Todo&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ObservableCollection&lt;Todo&gt;&nbsp;AllTodos&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_todoViewModel._allToDos;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;Todo&gt;&nbsp;GetTodos()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(MySqlConnection&nbsp;connection&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MySqlConnection(<span class="cs__string">&quot;Your&nbsp;connectionString&nbsp;&#43;&nbsp;SslMode=None&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MySqlCommand&nbsp;getCommand&nbsp;=&nbsp;connection.CreateCommand();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;getCommand.CommandText&nbsp;=&nbsp;<span class="cs__string">&quot;SELECT&nbsp;whatToDO&nbsp;FROM&nbsp;todo&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(MySqlDataReader&nbsp;reader&nbsp;=&nbsp;getCommand.ExecuteReader())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(reader.Read())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_todoViewModel._allToDos.Add(<span class="cs__keyword">new</span>&nbsp;Todo(reader.GetString(<span class="cs__string">&quot;whatToDO&quot;</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>(MySqlException)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Handle&nbsp;it&nbsp;:)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_todoViewModel.AllTodos;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;InsertNewTodo(<span class="cs__keyword">string</span>&nbsp;what)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Todo&nbsp;newTodo&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Todo(what);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Insert&nbsp;to&nbsp;the&nbsp;collection&nbsp;and&nbsp;update&nbsp;DB</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(MySqlConnection&nbsp;connection&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MySqlConnection(<span class="cs__string">&quot;Your&nbsp;connectionString&nbsp;&#43;&nbsp;SslMode=None&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MySqlCommand&nbsp;insertCommand&nbsp;=&nbsp;connection.CreateCommand();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;insertCommand.CommandText&nbsp;=&nbsp;<span class="cs__string">&quot;INSERT&nbsp;INTO&nbsp;todo(whatToDO)VALUES(@whatToDO)&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;insertCommand.Parameters.AddWithValue(<span class="cs__string">&quot;@whatToDO&quot;</span>,&nbsp;newTodo.whatToDO);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;insertCommand.ExecuteNonQuery();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_todoViewModel._allToDos.Add(newTodo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>(MySqlException)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Don't&nbsp;forget&nbsp;to&nbsp;handle&nbsp;it</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;TodoViewModel()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</strong></div>
<p><strong>&nbsp;</strong></p>
<div class="endscriptcode"><strong>&nbsp;</strong></div>
<p><strong><br>
</strong></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>What we did at GetTodos():</strong></p>
<ul>
<li>Established the connection </li><li>We opened it </li><li>Initializing the command ( Query ) </li><li>Execute the command </li><li>Read incoming values and initializing new Todo objects then adding it to our ObservableCollection for data binding later.
</li></ul>
<p><strong>What we did at InsertNewTodo(string what):</strong></p>
<ul>
<li>Started by creating new object of the Todo class &amp; initialize it. </li><li>Established the connection </li><li>We opened the connection </li><li>Initializing the command ( Query ) </li><li>Add the Query string </li><li>Add any parameters to the Query </li><li>Execute the command(Query) </li><li>Add the new Todo to the ObservableCollection </li></ul>
<div><strong>Note:</strong></div>
<div>MySQL API for WinRT is not supporting SSL connection, So you'll have to turn it off by adding
<strong>SslMode=None</strong> to your connection string.</div>
<div></div>
<div><strong>App.xaml.cs code:</strong></div>
<div>We just create a public static instance from our ViewModel to be consumed from all over the app.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;TodoViewModel&nbsp;TODO_VIEW_MODEL&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TodoViewModel();</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div></div>
<p><strong>MainPage.xaml Code:</strong> Within the Main Grid:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><strong><span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Vertical&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;Todos&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>.ItemTemplate<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;25&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;whatToDO}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView.ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ListView&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBox</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;NewTodoTxtBox&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;25&quot;</span>&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;New&nbsp;Todo:&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;InsertTodoBtn&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;InsertTodoBtn_Click&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Insert&nbsp;New&nbsp;Todo&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,20,0,0&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/StackPanel&gt;</span></strong></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>MainPage Code-Behind(MainPage Class):</strong></p>
<p><strong>&nbsp;</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><strong><span>C#</span></strong></div>
<div class="pluginLinkHolder"><strong><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></strong></div>
<strong><span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">sealed</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;MainPage&nbsp;:&nbsp;Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MainPage()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;InsertTodoBtn_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;App.TODO_VIEW_MODEL.InsertNewTodo(NewTodoTxtBox.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnNavigatedTo(NavigationEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Todos.ItemsSource&nbsp;=&nbsp;App.TODO_VIEW_MODEL.GetTodos();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</strong></div>
</div>
<div class="endscriptcode"><strong>&nbsp;</strong></div>
<p><strong><br>
</strong></p>
<p>&nbsp;</p>
<p>We're done!</p>
<p>&nbsp;</p>
<p><a href="https://kinani95.files.wordpress.com/2016/01/finalmysql.png" rel="attachment wp-att-187"><img class="alignnone size-full x_x_x_x_x_wp-image-187" src=":-finalmysql.png" alt="finalMySQL" width="776" height="415"></a></p>
&nbsp; &nbsp;