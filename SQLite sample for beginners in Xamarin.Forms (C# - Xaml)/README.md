# SQLite sample for beginners in Xamarin.Forms (C# - Xaml)
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Xamarin.Forms
## Topics
- SQlite sample in Xamarin.Forms
## Updated
- 03/25/2018
## Description

<div>
<p><span style="font-size:small"><strong><span style="font-family:verdana,sans-serif">Introduction:</span></strong></span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">This article will show you step by step guide on how to use an SQLite database with a Xamarin.Forms application in Android and iOS.&nbsp;</span></p>
<p><strong><span style="font-family:verdana,sans-serif; font-size:small; color:#ff6600">You can read this article from my blog from
<a title="SQLiteSample" href="https://bsubramanyamraju.blogspot.com/2018/03/xamarinforms-mvvm-sqlite-sample-for.html" target="_blank">
here</a>.</span></strong></p>
<p class="separator"><span class="s1" style="font-family:verdana,sans-serif; font-size:small"><a href="https://1.bp.blogspot.com/-fiFM-_fgJ-k/WrXs5QBcDBI/AAAAAAAADsc/UwCojwyA1Iw2b8N2gIbBeg-pUNeqv5-kgCLcBGAs/s1600/sqlite-database-development.png"><img src="https://1.bp.blogspot.com/-fiFM-_fgJ-k/WrXs5QBcDBI/AAAAAAAADsc/UwCojwyA1Iw2b8N2gIbBeg-pUNeqv5-kgCLcBGAs/s1600/sqlite-database-development.png" border="0" alt=""></a></span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small"><br>
</span></p>
</div>
<div>
<p><span style="font-size:small"><strong><span style="font-family:verdana,sans-serif">Requirements:</span></strong></span></p>
</div>
<div></div>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">This article source code is prepared by using Visual Studio Community for Mac (7.4). And it is better to install latest visual studio updates from&nbsp;<a href="https://www.visualstudio.com/downloads/">here</a>.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">This sample project is Xamarin.Forms PCL project and tested in Android emulator and iOS simulators.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small"><strong>Storage:&nbsp;</strong>Used<strong>&nbsp;</strong>SQLite.Net-PCL Nuget package version<strong>&nbsp;is 3.1.1</strong></span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small"><strong>Validation</strong>: Used&nbsp;FluentValidation&nbsp;Nuget Package version is&nbsp;<strong>V7.5.2.</strong></span>
</li></ul>
<div>
<p><span style="font-size:small"><strong><span style="font-family:verdana,sans-serif">Description:</span></strong></span></p>
</div>
<div>
<div>
<div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">In this article we will take a sample that would helpful to understand SQLite operations in Xamarin.Forms and sample project will have below functionality.</span></p>
<ul>
<li><span style="font-size:small"><strong>Add Contact (AddContact, AddContactViewModel)</strong>: Insert new contact details to SQLite database.&nbsp;<span style="font-family:Verdana,sans-serif">Also will have a option to &quot;View All Contacts&quot; if contacts exist
 in database.</span></span> </li><li><span style="font-size:small"><span style="font-family:verdana,sans-serif"><strong>Contact List (ContactList,&nbsp;</strong></span><strong>ContactListViewModel)</strong>: Read all contacts from SQLite and displaying contact list.&nbsp;<span style="font-family:Verdana,sans-serif">Also
 will have a option to delete all/add the contact.</span></span> </li><li><span style="font-family:verdana,sans-serif; font-size:small"><strong>Contact Details</strong>:&nbsp;Read specific contact from SQLite and showing full information for the same. Also will have a option to delete/update the contact.</span>
</li></ul>
<p><span style="font-family:verdana,sans-serif; font-size:small">So this article can explain you below concepts:</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">1. How to create Xamarin.Forms PCL project with Visual Studio for Mac?</span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">2.&nbsp;</span><span style="font-family:verdana,sans-serif">How to setup SQLite and perform SQLite operations in Xamarin.Forms PCL project?</span></span></p>
<span style="font-size:small">3. How to validate Contact Details with&nbsp;<span style="font-family:verdana,sans-serif">Fluent Validation before data insert?</span></span></div>
<div>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">4. How to use default MVVM to create ViewModels in&nbsp;</span><span style="font-family:verdana,sans-serif">Xamarin.Forms app?</span></span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">5. How to bind Contact Views with ViewModels?</span></p>
</div>
</div>
<div>
<p><strong style="font-size:small"><span style="font-family:verdana,sans-serif">1.&nbsp;</span><span style="font-family:verdana,sans-serif">How to create Xamarin.Forms PCL project using Visual studio for Mac?</span></strong></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">First we need to create the new Xamarin.Forms project.&nbsp;</span></p>
</div>
<div>
<ul>
<li><span style="font-family:Verdana,sans-serif; font-size:small">Launch Visual Studio for Mac.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">On the File menu, select New Solution.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">The New Project dialog appears. The left pane of the dialog lets you select the type of templates to display. In the left pane, expand&nbsp;<strong>Multiplatform&nbsp;</strong>&gt;&nbsp;<strong>App&nbsp;</strong>&gt;&nbsp;<strong>Xamarin.Forms</strong>&nbsp;&gt;&nbsp;<strong>Blank&nbsp;Forms
 App&nbsp;</strong>and click on&nbsp;<strong>Next</strong>.
<p class="separator"><a href="https://1.bp.blogspot.com/-DIaz7my0XX0/Wq4SJTssw7I/AAAAAAAADnM/8SuZaGwqs2wFKZmWGN1DvCGAQ6uvRQoyQCLcBGAs/s1600/1.%2BNewProject.png"><img src="https://1.bp.blogspot.com/-DIaz7my0XX0/Wq4SJTssw7I/AAAAAAAADnM/8SuZaGwqs2wFKZmWGN1DvCGAQ6uvRQoyQCLcBGAs/s640/1.%2BNewProject.png" border="0" alt="" width="640" height="462"></a></p>
<p class="separator">&nbsp;</p>
</span></li><li>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">Enter your App Name (Ex:&nbsp;SQLiteSample). Select&nbsp;<strong>Target Platforms&nbsp;</strong>to Android and&nbsp;<strong>Shared Code</strong>&nbsp;to Portable Class Library
 &amp; iOS and click on&nbsp;<strong>Next</strong><span style="font-family:verdana,sans-serif">&nbsp;button.</span></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><span style="font-family:verdana,sans-serif"><a href="https://2.bp.blogspot.com/-PRrpKEwrIKI/WrX1nncmgUI/AAAAAAAADss/8Ex7vgNK2BsNIpglnoWXF_PJlYnfjMGDACLcBGAs/s1600/Screen%2BShot%2B2018-03-20%2Bat%2B9.54.42%2BPM.png"><img src="https://2.bp.blogspot.com/-PRrpKEwrIKI/WrX1nncmgUI/AAAAAAAADss/8Ex7vgNK2BsNIpglnoWXF_PJlYnfjMGDACLcBGAs/s640/Screen%2BShot%2B2018-03-20%2Bat%2B9.54.42%2BPM.png" border="0" alt="" width="640" height="464"></a></span></span></p>
</li><li>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">You can choose your project location like below and&nbsp;<strong>Create</strong>&nbsp;new project.</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://1.bp.blogspot.com/-B-3iaKi59pE/WrX15qIgg3I/AAAAAAAADsw/yiqDtBy70KsIZwooYFuDXotW9PQisoRPACLcBGAs/s1600/Screen%2BShot%2B2018-03-20%2Bat%2B9.55.17%2BPM.png"><img src="https://1.bp.blogspot.com/-B-3iaKi59pE/WrX15qIgg3I/AAAAAAAADsw/yiqDtBy70KsIZwooYFuDXotW9PQisoRPACLcBGAs/s640/Screen%2BShot%2B2018-03-20%2Bat%2B9.55.17%2BPM.png" border="0" alt="" width="640" height="464"></a></span></p>
<p>&nbsp;</p>
</li></ul>
</div>
</div>
<div>
<ul>
</ul>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><strong><span style="font-family:verdana,sans-serif">2.&nbsp;</span>How to setup SQLite and perform SQLite operations in Xamarin.Forms PCL project?</strong></span></p>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif">After creating Xamarin.Forms application, we need a managed way to access SQLite database. For that we need to add relevant nuget package name is&nbsp;</span>SQLite.Net-PCL
 to PCL, Android &amp; iOS projects.&nbsp;SQLite.Net-PCL<span style="font-family:verdana,sans-serif">&nbsp;is a .NET wrapper around SQLite that will allow us to access the native SQLite functionality from a Xamarin.Forms PCL or shared project.</span></span></p>
<p class="separator"><span style="font-size:small">So Right on your PCL project Packages and click on Add Packages.</span></p>
<p class="separator"><span style="font-size:small"><a href="https://4.bp.blogspot.com/-ibVN_C_K5CY/WrX4LESDHoI/AAAAAAAADtA/3-rDpVfrwgoYb01PtwyU--8UloPCqO_CQCLcBGAs/s1600/Screen%2BShot%2B2018-03-20%2Bat%2B9.55.33%2BPM.png"><img src="https://4.bp.blogspot.com/-ibVN_C_K5CY/WrX4LESDHoI/AAAAAAAADtA/3-rDpVfrwgoYb01PtwyU--8UloPCqO_CQCLcBGAs/s400/Screen%2BShot%2B2018-03-20%2Bat%2B9.55.33%2BPM.png" border="0" alt="" width="373" height="400"></a></span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small">After that Add Packages dialog windows will open, search for &quot;SQLite.Net-PCL&quot; and click on&nbsp;<strong>Add Package&nbsp;</strong>like below.</span></p>
<p class="separator"><span style="font-size:small"><a href="https://4.bp.blogspot.com/-UkF0maTWPlE/WrX5NkmMM0I/AAAAAAAADtM/WxoTWEsaoDIVP05ZMXYD_cVtcdi_5efTQCLcBGAs/s1600/Screen%2BShot%2B2018-03-20%2Bat%2B9.56.00%2BPM.png"><img src="https://4.bp.blogspot.com/-UkF0maTWPlE/WrX5NkmMM0I/AAAAAAAADtM/WxoTWEsaoDIVP05ZMXYD_cVtcdi_5efTQCLcBGAs/s640/Screen%2BShot%2B2018-03-20%2Bat%2B9.56.00%2BPM.png" border="0" alt="" width="640" height="422"></a></span></p>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small">After that above package will add to your Xamarin.PCL project like below.</span></p>
<p class="separator"><span style="font-size:small"><a href="https://2.bp.blogspot.com/-vsqE6SEmj7I/WrX6O7FJ7BI/AAAAAAAADtY/HyzI6-IUAv0tWzoq3gTrKH9eMpx1J9ZSwCLcBGAs/s1600/Screen%2BShot%2B2018-03-24%2Bat%2B12.40.12%2BPM.png"><img src="https://2.bp.blogspot.com/-vsqE6SEmj7I/WrX6O7FJ7BI/AAAAAAAADtY/HyzI6-IUAv0tWzoq3gTrKH9eMpx1J9ZSwCLcBGAs/s400/Screen%2BShot%2B2018-03-24%2Bat%2B12.40.12%2BPM.png" border="0" alt="" width="251" height="400"></a></span></p>
<p>&nbsp;<span style="font-family:Verdana,sans-serif">Also please add above package to&nbsp;</span><span style="font-size:small">SQLiteSample</span><span style="font-size:small">.Droid</span><span style="font-family:Verdana,sans-serif">&nbsp;and&nbsp;</span><span style="font-size:small">SQLiteSample</span><span style="font-size:small">.</span><span style="font-family:Verdana,sans-serif">iOS
 projects by&nbsp;following same above steps like SQLiteSample PCL project. And make sure SQLite.Net-PCL package should add to Android and iOS project Packages folder like below.</span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small"><a href="https://4.bp.blogspot.com/-jTBOpygE0pM/WrX7roBvnwI/AAAAAAAADto/g6FT3Cj0hlgevXvoGzSf3Ma40AKIOVFggCLcBGAs/s1600/Screen%2BShot%2B2018-03-24%2Bat%2B12.45.03%2BPM.png"><img src="https://4.bp.blogspot.com/-jTBOpygE0pM/WrX7roBvnwI/AAAAAAAADto/g6FT3Cj0hlgevXvoGzSf3Ma40AKIOVFggCLcBGAs/s320/Screen%2BShot%2B2018-03-24%2Bat%2B12.45.03%2BPM.png" border="0" alt="" width="205" height="320"></a><a href="https://4.bp.blogspot.com/-7-b6Iw_CnlU/WrX7rP7faPI/AAAAAAAADtk/-0q4Tji7sZkBrw2JsTgQT2KsCqOMfrscACLcBGAs/s1600/Screen%2BShot%2B2018-03-24%2Bat%2B12.45.21%2BPM.png"><img src="https://4.bp.blogspot.com/-7-b6Iw_CnlU/WrX7rP7faPI/AAAAAAAADtk/-0q4Tji7sZkBrw2JsTgQT2KsCqOMfrscACLcBGAs/s320/Screen%2BShot%2B2018-03-24%2Bat%2B12.45.21%2BPM.png" border="0" alt="" width="260" height="320"></a></span></p>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small">We completed the SQLite setup for our xamarin forms project.&nbsp;<span style="font-family:verdana,sans-serif">So it is time to perform all SQLite(Create, Read, Update, Delete, Insert) operations. But before
 that even tough the &quot;SQLite.Net-PCL&quot; package will provide us the functionality of manipulating the SQLite database, it can&rsquo;t automatically initialize the database connection object as the location of the database file varies on different platforms. So
 in order to solve this issue we will use dependency service to load the database file in connection object and please follow below few steps.</span></span></p>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif"><strong>Step 1:&nbsp;Create Interface (ISQLite)</strong></span><strong>&nbsp;in PCL.</strong></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">We are following default MVVM design pattern. And here we will place helpers in Helpers folder. So right click on your project name SQLiteSample =&gt; Add =&gt; New Folder
 name is &quot;Helpers&quot;. After that right click on your newly created the folder =&gt; Add =&gt; New File =&gt;&nbsp;General =&gt; Empty Inerface and name it ISQLite and add below code:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLite.Net;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.Helpers&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;ISQLite&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SQLiteConnection&nbsp;GetConnection();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<p class="endscriptcode"><span style="font-size:small">&nbsp;<strong>Step 2:&nbsp;Android Implementation for ISQLite</strong><strong>.</strong></span></p>
<p class="endscriptcode"><span style="font-size:small"><strong>&nbsp;</strong></span><span style="font-family:verdana,sans-serif; font-size:small">In SQLiteSample.Droid project, create folder &quot;Implementations&quot; and create class &quot;AndroidSQLite&quot;. After that
 below code:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLite.Net;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Droid.Implementaions;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Helpers;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
[assembly:&nbsp;Xamarin.Forms.Dependency(<span class="cs__keyword">typeof</span>(AndroidSQLite))]&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.Droid.Implementations&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;AndroidSQLite&nbsp;:&nbsp;ISQLite&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;SQLiteConnection&nbsp;GetConnection()&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;documentsPath&nbsp;=&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Environment.GetFolderPath.aspx" target="_blank" title="Auto generated link to System.Environment.GetFolderPath">System.Environment.GetFolderPath</a>(System.Environment.SpecialFolder.Personal);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Documents&nbsp;folder&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;path&nbsp;=&nbsp;Path.Combine(documentsPath,&nbsp;DatabaseHelper.DbFileName);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;plat&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;conn&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SQLiteConnection(plat,&nbsp;path);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Return&nbsp;the&nbsp;database&nbsp;connection&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;conn;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-family:verdana,sans-serif"><strong>Step 3:&nbsp;iOS Implementation for ISQLite</strong></span><strong>.</strong></div>
<p>&nbsp;</p>
<li>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">In SQLiteSample.iOS project, create folder &quot;Implementations&quot; and create class &quot;iOSSQLite&quot;. After that below code:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLite.Net;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Helpers;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.iOS.Implementaions;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
[assembly:&nbsp;Dependency(<span class="cs__keyword">typeof</span>(IOSSQLite))]&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.iOS.Implementations&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;IOSSQLite&nbsp;:&nbsp;ISQLite&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;SQLiteConnection&nbsp;GetConnection()&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;documentsPath&nbsp;=&nbsp;Environment.GetFolderPath(Environment.SpecialFolder.Personal);&nbsp;<span class="cs__com">//&nbsp;Documents&nbsp;folder&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;libraryPath&nbsp;=&nbsp;Path.Combine(documentsPath,&nbsp;<span class="cs__string">&quot;..&quot;</span>,&nbsp;<span class="cs__string">&quot;Library&quot;</span>);&nbsp;<span class="cs__com">//&nbsp;Library&nbsp;folder&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;path&nbsp;=&nbsp;Path.Combine(libraryPath,&nbsp;DatabaseHelper.DbFileName);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;the&nbsp;connection&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;plat&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;conn&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SQLiteConnection(plat,&nbsp;path);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Return&nbsp;the&nbsp;database&nbsp;connection&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;conn;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif"><strong>Step 4:&nbsp;</strong></span><span style="font-family:verdana,sans-serif"><strong>Performing</strong></span><strong>&nbsp;SQLite operations with&nbsp;</strong><strong>Database
 Helper class in PCL</strong></span></p>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif">In SQLiteSample PCL project, create a class in&nbsp;</span>Helpers folder&nbsp;that should have methods to perform SQLite operation (create, insert, delete, read,
 update).</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;SQLite.Net;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Models;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.Helpers&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DatabaseHelper&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;SQLiteConnection&nbsp;sqliteconnection;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;DbFileName&nbsp;=&nbsp;<span class="cs__string">&quot;Contacts.db&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DatabaseHelper()&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqliteconnection&nbsp;=&nbsp;DependencyService.Get&lt;ISQLite&gt;().GetConnection();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqliteconnection.CreateTable&lt;ContactInfo&gt;();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;All&nbsp;Contact&nbsp;data&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;ContactInfo&gt;&nbsp;GetAllContactsData()&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;(from&nbsp;data&nbsp;<span class="cs__keyword">in</span>&nbsp;sqliteconnection.Table&lt;ContactInfo&gt;()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;data).ToList();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;Specific&nbsp;Contact&nbsp;data&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ContactInfo&nbsp;GetContactData(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;sqliteconnection.Table&lt;ContactInfo&gt;().FirstOrDefault(t&nbsp;=&gt;&nbsp;t.Id&nbsp;==&nbsp;id);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Delete&nbsp;all&nbsp;Contacts&nbsp;Data&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteAllContacts()&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqliteconnection.DeleteAll&lt;ContactInfo&gt;();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Delete&nbsp;Specific&nbsp;Contact&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteContact(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqliteconnection.Delete&lt;ContactInfo&gt;(id);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Insert&nbsp;new&nbsp;Contact&nbsp;to&nbsp;DB&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;InsertContact(ContactInfo&nbsp;contact)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqliteconnection.Insert(contact);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Update&nbsp;Contact&nbsp;Data&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;UpdateContact(ContactInfo&nbsp;contact)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqliteconnection.Update(contact);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-family:verdana,sans-serif">In above SQLite helper class, we created queries for ContactInfo Table means that we need to create&nbsp;</span><strong>ContactInfo&nbsp;</strong>class that should have columns.</div>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small">So create&nbsp;<strong>Models</strong>&nbsp;folder in PCL and add below Table class.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLite.Net.Attributes;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.Models&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Table(<span class="cs__string">&quot;ContactInfo&quot;</span>)]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ContactInfo&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[PrimaryKey,&nbsp;AutoIncrement]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Age&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Gender&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;DOB&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Address&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;MobileNumber&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-family:verdana,sans-serif">Please note that in above class.&nbsp;The Id property is marked as the Primary Key and AutoIncrement which will helpful for contact row identification.</span></div>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif"><strong>Step 5: Create interface for ContactInfo tabel&nbsp;</strong></span><strong>operations</strong></span></p>
<p class="separator"><span style="font-size:small">We will create service that will talk to only ContactInfo Table. So create Services folder in PCL and add<span style="font-family:verdana,sans-serif">&nbsp;below IContactRepository interface</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Models;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.Servcies&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IContactRepository&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;ContactInfo&gt;&nbsp;GetAllContactsData();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;Specific&nbsp;Contact&nbsp;data&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactInfo&nbsp;GetContactData(<span class="cs__keyword">int</span>&nbsp;contactID);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Delete&nbsp;all&nbsp;Contacts&nbsp;Data&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteAllContacts();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Delete&nbsp;Specific&nbsp;Contact&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteContact(<span class="cs__keyword">int</span>&nbsp;contactID);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Insert&nbsp;new&nbsp;Contact&nbsp;to&nbsp;DB&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;InsertContact(ContactInfo&nbsp;contact);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Update&nbsp;Contact&nbsp;Data&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;UpdateContact(ContactInfo&nbsp;contact);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-family:Verdana,Arial,Helvetica,sans-serif">And after that create a class that should implement above interface.
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Helpers;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Models;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.Servcies&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ContactRepository&nbsp;:&nbsp;IContactRepository&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DatabaseHelper&nbsp;_databaseHelper;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ContactRepository(){&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_databaseHelper&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DatabaseHelper();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteContact(<span class="cs__keyword">int</span>&nbsp;contactID)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_databaseHelper.DeleteContact(contactID);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DeleteAllContacts()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_databaseHelper.DeleteAllContacts();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;ContactInfo&gt;&nbsp;GetAllContactsData()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_databaseHelper.GetAllContactsData();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ContactInfo&nbsp;GetContactData(<span class="cs__keyword">int</span>&nbsp;contactID)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_databaseHelper.GetContactData(contactID);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;InsertContact(ContactInfo&nbsp;contact)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_databaseHelper.InsertContact(contact);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;UpdateContact(ContactInfo&nbsp;contact)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_databaseHelper.UpdateContact(contact);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
</span></div>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small"><strong>3. How to validate Contact Details with&nbsp;<span style="font-family:verdana,sans-serif">Fluent Validation?</span></strong></span></p>
<p class="separator"><span style="font-size:small">It will be always good to validate details before save them to database. In this article we are validating ContactInfo table information before inserting into SQLite. Please read to understand how to validate
 particular class object with&nbsp;<span style="font-family:verdana,sans-serif">FluentValidation from this&nbsp;<a href="http://bsubramanyamraju.blogspot.in/2018/03/fluent-validation-how-to-validate.html" target="_blank">article</a>.</span></span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif">In SQLiteSample PCL project, we have to add&nbsp;</span><span style="font-size:small">ContactValidator class in Validator folder.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;FluentValidation;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Models;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.Validator&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ContactValidator&nbsp;:&nbsp;AbstractValidator&lt;ContactInfo&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ContactValidator()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RuleFor(c&nbsp;=&gt;&nbsp;c.Name).Must(n=&gt;ValidateStringEmpty(n)).WithMessage(<span class="cs__string">&quot;Contact&nbsp;name&nbsp;should&nbsp;not&nbsp;be&nbsp;empty.&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RuleFor(c&nbsp;=&gt;&nbsp;c.MobileNumber).NotNull().Length(<span class="cs__number">10</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RuleFor(c&nbsp;=&gt;&nbsp;c.Age).Must(a&nbsp;=&gt;&nbsp;ValidateStringEmpty(a)).WithMessage(<span class="cs__string">&quot;Contact&nbsp;Age&nbsp;should&nbsp;not&nbsp;be&nbsp;empty.&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RuleFor(c&nbsp;=&gt;&nbsp;c.Gender).Must(g&nbsp;=&gt;&nbsp;ValidateStringEmpty(g)).WithMessage(<span class="cs__string">&quot;Contact&nbsp;Gender&nbsp;should&nbsp;not&nbsp;be&nbsp;empty.&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RuleFor(c&nbsp;=&gt;&nbsp;c.DOB).Must(d&nbsp;=&gt;&nbsp;ValidateStringEmpty(d.ToString())).WithMessage(<span class="cs__string">&quot;Contact&nbsp;DOB&nbsp;should&nbsp;not&nbsp;be&nbsp;empty.&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RuleFor(c&nbsp;=&gt;&nbsp;c.Address).Must(a&nbsp;=&gt;&nbsp;ValidateStringEmpty(a)).WithMessage(<span class="cs__string">&quot;Contact&nbsp;Adress&nbsp;should&nbsp;not&nbsp;be&nbsp;empty.&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;ValidateStringEmpty(<span class="cs__keyword">string</span>&nbsp;stringValue){&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(stringValue))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong><span style="font-family:verdana,sans-serif">4. How to use default MVVM to create ViewModels in&nbsp;</span><span style="font-family:verdana,sans-serif">Xamarin.Forms app?</span></strong></div>
<p>&nbsp;</p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">It is best practices to write business login in view models before start to build views user interface. And we are adding functionality for the view models below.</span></p>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small"><strong>AddContactViewModel:</strong>&nbsp;Saving new contact details in database.&nbsp;</span>
</li><li><span style="font-size:small"><strong>ContactListViewModel:</strong>&nbsp;Read all contacts from database.</span>
</li><li><span style="font-size:small"><strong>DetailsViewModel</strong>: Read specific contact from database and delete/update same contact.</span>
</li></ul>
<p>&nbsp;</p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">Let's start write business logic to viewmodels</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><strong><span style="text-decoration:underline">AddContactViewModel</span></strong></span></p>
<p class="separator"><span style="font-size:small"><a href="https://1.bp.blogspot.com/-fh5v5mflTow/WrYLFb1TaDI/AAAAAAAADt8/q0SZHB5sUNcH2_pRKm7fxDNvsvt0sNY8QCLcBGAs/s1600/1.AndroidAddContact.png"><img src="https://1.bp.blogspot.com/-fh5v5mflTow/WrYLFb1TaDI/AAAAAAAADt8/q0SZHB5sUNcH2_pRKm7fxDNvsvt0sNY8QCLcBGAs/s640/1.AndroidAddContact.png" border="0" alt="" width="385" height="640"></a></span><span style="font-family:verdana,sans-serif">Above
 UI screen is for AddContactView. So&nbsp;</span><span style="font-size:small">ViewModel should have below properties and commands.</span></p>
<p class="separator"><span style="font-size:small"><strong>Properties:&nbsp;</strong><span style="font-family:verdana,sans-serif">Name, Mobile Number, Age, Gender, DOB, Address. And these properties will be the same for Contact DetailsViewModel. So we will
 these properties&nbsp;into common view model name is&nbsp;<strong>BaseContactViewModel</strong>.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.aspx" target="_blank" title="Auto generated link to System.ComponentModel">System.ComponentModel</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Runtime.CompilerServices.aspx" target="_blank" title="Auto generated link to System.Runtime.CompilerServices">System.Runtime.CompilerServices</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;FluentValidation;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Helpers;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Models;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Servcies;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.ViewModels&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;BaseContactViewModel&nbsp;:&nbsp;INotifyPropertyChanged&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ContactInfo&nbsp;_contact;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;INavigation&nbsp;_navigation;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IValidator&nbsp;_contactValidator;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IContactRepository&nbsp;_contactRepository;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;=&gt;&nbsp;_contact.Name;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contact.Name&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NotifyPropertyChanged(<span class="cs__string">&quot;Name&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;MobileNumber&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;=&gt;&nbsp;_contact.MobileNumber;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contact.MobileNumber&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NotifyPropertyChanged(<span class="cs__string">&quot;MobileNumber&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Age&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;=&gt;&nbsp;_contact.Age;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contact.Age&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NotifyPropertyChanged(<span class="cs__string">&quot;Age&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Gender&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;=&gt;&nbsp;_contact.Gender;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contact.Gender&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NotifyPropertyChanged(<span class="cs__string">&quot;Gender&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;DOB&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;=&gt;&nbsp;_contact.DOB;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contact.DOB&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NotifyPropertyChanged(<span class="cs__string">&quot;DOB&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;=&gt;&nbsp;_contact.Address;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contact.Address&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NotifyPropertyChanged(<span class="cs__string">&quot;Address&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;ContactInfo&gt;&nbsp;_contactList;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;ContactInfo&gt;&nbsp;ContactList&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;=&gt;&nbsp;_contactList;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contactList&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NotifyPropertyChanged(<span class="cs__string">&quot;ContactList&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;INotifyPropertyChanged</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">event</span>&nbsp;PropertyChangedEventHandler&nbsp;PropertyChanged;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;NotifyPropertyChanged([CallerMemberName]&nbsp;<span class="cs__keyword">string</span>&nbsp;propertyName&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>){&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PropertyChanged?.Invoke(<span class="cs__keyword">this</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyChangedEventArgs(propertyName));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-family:Verdana,Arial,Helvetica,sans-serif">In above&nbsp;</span><span style="font-family:verdana,sans-serif">BaseContactViewModel, we also added below</span><strong style="font-family:Verdana,Arial,Helvetica,sans-serif">&nbsp;</strong><span style="font-family:Verdana,Arial,Helvetica,sans-serif">common</span><strong style="font-family:Verdana,Arial,Helvetica,sans-serif">&nbsp;</strong><span style="font-family:Verdana,Arial,Helvetica,sans-serif">interfaces</span></div>
<p>&nbsp;</p>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">INavigation: For page navigation</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">IValidator: To validae contact object.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">IContactRepository: To access ContactInfo Table operations.</span>
</li></ul>
<p class="separator"><span style="font-size:small"><strong>Commands:&nbsp;</strong></span></p>
<ul>
<li><span style="font-family:Verdana,sans-serif; font-size:small">AddContactCommand(for Save Contact Button click)</span>
</li><li><span style="font-family:Verdana,sans-serif; font-size:small">ViewAllContactsCommand (View All Contacts Label tap).&nbsp;</span>
</li></ul>
<p><span style="font-family:verdana,sans-serif; font-size:small">So create ViewModels folder in PCL project and add below AddContactViewModel class.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Windows.Input.aspx" target="_blank" title="Auto generated link to System.Windows.Input">System.Windows.Input</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Helpers;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Models;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Servcies;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Validator;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Views;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.ViewModels&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;AddContactViewModel&nbsp;:&nbsp;BaseContactViewModel&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ICommand&nbsp;AddContactCommand&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ICommand&nbsp;ViewAllContactsCommand&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;AddContactViewModel(INavigation&nbsp;navigation){&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_navigation&nbsp;=&nbsp;navigation;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contactValidator&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ContactValidator();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contact&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ContactInfo();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contactRepository&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ContactRepository();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddContactCommand&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Command(async&nbsp;()&nbsp;=&gt;&nbsp;await&nbsp;AddContact());&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewAllContactsCommand&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Command(async&nbsp;()&nbsp;=&gt;&nbsp;await&nbsp;ShowContactList());&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;async&nbsp;Task&nbsp;AddContact()&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;validationResults&nbsp;=&nbsp;_contactValidator.Validate(_contact);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(validationResults.IsValid){&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;isUserAccept&nbsp;=&nbsp;await&nbsp;Application.Current.MainPage.DisplayAlert(<span class="cs__string">&quot;Add&nbsp;Contact&quot;</span>,&nbsp;<span class="cs__string">&quot;Do&nbsp;you&nbsp;want&nbsp;to&nbsp;save&nbsp;Contact&nbsp;details?&quot;</span>,&nbsp;<span class="cs__string">&quot;OK&quot;</span>,&nbsp;<span class="cs__string">&quot;Cancel&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(isUserAccept)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contactRepository.InsertContact(_contact);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;_navigation.PushAsync(<span class="cs__keyword">new</span>&nbsp;ContactList());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;Application.Current.MainPage.DisplayAlert(<span class="cs__string">&quot;Add&nbsp;Contact&quot;</span>,&nbsp;validationResults.Errors[<span class="cs__number">0</span>].ErrorMessage,&nbsp;<span class="cs__string">&quot;Ok&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;async&nbsp;Task&nbsp;ShowContactList(){&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;_navigation.PushAsync(<span class="cs__keyword">new</span>&nbsp;ContactList());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsViewAll&nbsp;=&gt;&nbsp;_contactRepository.GetAllContactsData().Count&nbsp;&gt;&nbsp;<span class="cs__number">0</span>&nbsp;?&nbsp;<span class="cs__keyword">true</span>&nbsp;:&nbsp;<span class="cs__keyword">false</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<span style="font-family:Verdana,sans-serif; font-size:small">In&nbsp;AddContact method, we are validating ContactInfo object with help of&nbsp;ContactValidator before insert new contact to database.&nbsp;</span>
<p>&nbsp;</p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small"><a href="https://1.bp.blogspot.com/-81K3eDJ2juw/WrYhfYaay7I/AAAAAAAADuM/Q2l7UYDJDnoVXjSZlhCWCBsjQ6AMpMZ1QCLcBGAs/s1600/Screen%2BShot%2B2018-03-24%2Bat%2B3.28.47%2BPM.png"><img src="https://1.bp.blogspot.com/-81K3eDJ2juw/WrYhfYaay7I/AAAAAAAADuM/Q2l7UYDJDnoVXjSZlhCWCBsjQ6AMpMZ1QCLcBGAs/s640/Screen%2BShot%2B2018-03-24%2Bat%2B3.28.47%2BPM.png" border="0" alt="" width="385" height="640"></a></span></p>
<p>&nbsp;</p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><br>
</span></p>
<p class="separator"><span style="font-size:small"><strong><span style="text-decoration:underline">ContactListViewModel</span></strong></span></p>
<p class="separator"><span style="font-size:small"><strong><span style="text-decoration:underline"><a href="https://4.bp.blogspot.com/-MbDctBmqVl8/WrYh07x5xoI/AAAAAAAADuQ/FNoFGWleI5Y4gmmH89ilM-rGO_NzZ1VZQCLcBGAs/s1600/Screen%2BShot%2B2018-03-24%2Bat%2B3.30.33%2BPM.png"><img src="https://4.bp.blogspot.com/-MbDctBmqVl8/WrYh07x5xoI/AAAAAAAADuQ/FNoFGWleI5Y4gmmH89ilM-rGO_NzZ1VZQCLcBGAs/s640/Screen%2BShot%2B2018-03-24%2Bat%2B3.30.33%2BPM.png" border="0" alt="" width="386" height="640"></a></span></strong></span></p>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif">Above UI screen is for ContactListView. So&nbsp;</span>ViewModel should have below properties and commands.</span></p>
<p class="separator"><span style="font-size:small"><strong><span style="font-family:Verdana,sans-serif">Properties:&nbsp;</span></strong><span style="font-family:Verdana,sans-serif">ContactList</span><span style="font-family:verdana,sans-serif">, SelectedContactItem</span></span></p>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif"><strong>Commands</strong>:&nbsp;</span>AddCommand,&nbsp;DeleteAllContactsCommand</span></p>
<p class="separator"><span style="font-size:small">In PCL project ViewModels folder,&nbsp;Add<span style="font-family:verdana,sans-serif">&nbsp;below ContactListViewModel&nbsp;class.
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Windows.Input.aspx" target="_blank" title="Auto generated link to System.Windows.Input">System.Windows.Input</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Models;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Servcies;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Views;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.ViewModels&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ContactListViewModel&nbsp;:&nbsp;BaseContactViewModel&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ICommand&nbsp;AddCommand&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ICommand&nbsp;DeleteAllContactsCommand&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ContactListViewModel(INavigation&nbsp;navigation)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_navigation&nbsp;=&nbsp;navigation;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contactRepository&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ContactRepository();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddCommand&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Command(async&nbsp;()&nbsp;=&gt;&nbsp;await&nbsp;ShowAddContact());&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DeleteAllContactsCommand&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Command(async&nbsp;()&nbsp;=&gt;&nbsp;await&nbsp;DeleteAllContacts());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FetchContacts();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;FetchContacts(){&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactList&nbsp;=&nbsp;_contactRepository.GetAllContactsData();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;async&nbsp;Task&nbsp;ShowAddContact()&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;_navigation.PushAsync(<span class="cs__keyword">new</span>&nbsp;AddContact());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;async&nbsp;Task&nbsp;DeleteAllContacts(){&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;isUserAccept&nbsp;=&nbsp;await&nbsp;Application.Current.MainPage.DisplayAlert(<span class="cs__string">&quot;Contact&nbsp;List&quot;</span>,&nbsp;<span class="cs__string">&quot;Delete&nbsp;All&nbsp;Contacts&nbsp;Details&nbsp;?&quot;</span>,&nbsp;<span class="cs__string">&quot;OK&quot;</span>,&nbsp;<span class="cs__string">&quot;Cancel&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(isUserAccept){&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contactRepository.DeleteAllContacts();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;_navigation.PushAsync(<span class="cs__keyword">new</span>&nbsp;AddContact());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;ShowContactDetails(<span class="cs__keyword">int</span>&nbsp;selectedContactID){&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;_navigation.PushAsync(<span class="cs__keyword">new</span>&nbsp;DetailsPage(selectedContactID));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactInfo&nbsp;_selectedContactItem;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ContactInfo&nbsp;SelectedContactItem&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;=&gt;&nbsp;_selectedContactItem;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;!=&nbsp;<span class="cs__keyword">null</span>){&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_selectedContactItem&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NotifyPropertyChanged(<span class="cs__string">&quot;SelectedContactItem&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShowContactDetails(<span class="cs__keyword">value</span>.Id);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong><span style="text-decoration:underline">DetailsViewModel</span></strong></span></p>
<p class="separator"><span style="font-size:small"><a href="https://1.bp.blogspot.com/-QH98tyt0dBg/WrYjT7dtb6I/AAAAAAAADug/LiSh9jEX_zo9OYLLNA0jSZdd1ySpeZRnwCLcBGAs/s1600/Screen%2BShot%2B2018-03-24%2Bat%2B3.36.53%2BPM.png"><img src="https://1.bp.blogspot.com/-QH98tyt0dBg/WrYjT7dtb6I/AAAAAAAADug/LiSh9jEX_zo9OYLLNA0jSZdd1ySpeZRnwCLcBGAs/s640/Screen%2BShot%2B2018-03-24%2Bat%2B3.36.53%2BPM.png" border="0" alt="" width="385" height="640"></a></span><span style="font-family:verdana,sans-serif">Above
 UI screen is for Contact DetailsView. So&nbsp;</span><span style="font-size:small">ViewModel should have below properties and commands.</span></p>
<p class="separator"><span style="font-size:small"><span style="font-family:Verdana,sans-serif"><strong>Properties:&nbsp;</strong>All properties of BaseContactViewModel as it is very similar to AddContactViewModel.</span></span></p>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif"><strong>Commands</strong>:&nbsp;</span><span style="font-family:verdana,sans-serif">UpdateContactCommand,&nbsp;DeleteContactCommand</span></span></p>
<p class="separator"><span style="font-size:small">In PCL project ViewModels folder,&nbsp;Add<span style="font-family:verdana,sans-serif">&nbsp;below&nbsp;</span>Details<span style="font-family:verdana,sans-serif">ViewModel&nbsp;class.
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Windows.Input.aspx" target="_blank" title="Auto generated link to System.Windows.Input">System.Windows.Input</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Helpers;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Models;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Servcies;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Validator;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.ViewModels&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DetailsViewModel:&nbsp;BaseContactViewModel&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ICommand&nbsp;UpdateContactCommand&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ICommand&nbsp;DeleteContactCommand&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DetailsViewModel(INavigation&nbsp;navigation,&nbsp;<span class="cs__keyword">int</span>&nbsp;selectedContactID)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_navigation&nbsp;=&nbsp;navigation;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contactValidator&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ContactValidator();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contact&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ContactInfo();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contact.Id&nbsp;=&nbsp;selectedContactID;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contactRepository&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ContactRepository();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UpdateContactCommand&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Command(async&nbsp;()&nbsp;=&gt;&nbsp;await&nbsp;UpdateContact());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DeleteContactCommand&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Command(async&nbsp;()&nbsp;=&gt;&nbsp;await&nbsp;DeleteContact());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FetchContactDetails();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;FetchContactDetails(){&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contact&nbsp;=&nbsp;_contactRepository.GetContactData(_contact.Id);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;async&nbsp;Task&nbsp;UpdateContact()&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;validationResults&nbsp;=&nbsp;_contactValidator.Validate(_contact);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(validationResults.IsValid)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;isUserAccept&nbsp;=&nbsp;await&nbsp;Application.Current.MainPage.DisplayAlert(<span class="cs__string">&quot;Contact&nbsp;Details&quot;</span>,&nbsp;<span class="cs__string">&quot;Update&nbsp;Contact&nbsp;Details&quot;</span>,&nbsp;<span class="cs__string">&quot;OK&quot;</span>,&nbsp;<span class="cs__string">&quot;Cancel&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(isUserAccept)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contactRepository.UpdateContact(_contact);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;_navigation.PopAsync();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;Application.Current.MainPage.DisplayAlert(<span class="cs__string">&quot;Add&nbsp;Contact&quot;</span>,&nbsp;validationResults.Errors[<span class="cs__number">0</span>].ErrorMessage,&nbsp;<span class="cs__string">&quot;Ok&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;async&nbsp;Task&nbsp;DeleteContact()&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;isUserAccept&nbsp;=&nbsp;await&nbsp;Application.Current.MainPage.DisplayAlert(<span class="cs__string">&quot;Contact&nbsp;Details&quot;</span>,&nbsp;<span class="cs__string">&quot;Delete&nbsp;Contact&nbsp;Details&quot;</span>,&nbsp;<span class="cs__string">&quot;OK&quot;</span>,&nbsp;<span class="cs__string">&quot;Cancel&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(isUserAccept)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_contactRepository.DeleteContact(_contact.Id);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;_navigation.PopAsync();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small"><strong>5.&nbsp;How to bind Contact Views with ViewModels?</strong></span></p>
<p class="separator"><span style="font-size:small">We completed the business logic in all above view models and now we can create UI in Views folder and need bind it to the view models.</span></p>
<p class="separator"><span style="font-size:small"><strong><span style="text-decoration:underline">Add Contact</span></strong></span></p>
<p class="separator"><span style="font-size:small">We need to create a page that can provide UI to insert new contact details.&nbsp;<span style="font-family:verdana,sans-serif">If we observe the above UI android screens, AddContact and Contacts Details UI
 is almost similar. So we can build common UI with help of ContentView and then reuse it in AddContact and Details Pages.</span></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><br>
</span></p>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif">So create Views folder in PCL and add below content view. Make sure UI elements should bind to relevant&nbsp;view model properties (</span>Name, Mobile Number,
 Age, Gender, DOB, Address). </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;?xml</span>&nbsp;<span class="xaml__attr_name">version</span>=<span class="xaml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xaml__attr_name">encoding</span>=<span class="xaml__attr_value">&quot;UTF-8&quot;</span><span class="xaml__tag_start">?&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_start">&lt;ContentView</span>&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://xamarin.com/schemas/2014/forms&quot;</span>&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2009/xaml&quot;</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;SQLiteSample.Views.ContactView&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackLayout</span>&nbsp;<span class="xaml__attr_name">Spacing</span>=<span class="xaml__attr_value">&quot;12&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;txtContactName&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Name}&quot;</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;40&quot;</span>&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;White&quot;</span>&nbsp;<span class="xaml__attr_name">Placeholder</span>=<span class="xaml__attr_value">&quot;Contact&nbsp;Name&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>&nbsp;&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;txtMobileNumber&quot;</span>&nbsp;<span class="xaml__attr_name">Keyboard</span>=<span class="xaml__attr_value">&quot;Telephone&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;MobileNumber}&quot;</span>&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;White&quot;</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;40&quot;</span>&nbsp;<span class="xaml__attr_name">Placeholder</span>=<span class="xaml__attr_value">&quot;Mobile&nbsp;Number&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackLayout</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;txtAge&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Age}&quot;</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;40&quot;</span>&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;White&quot;</span>&nbsp;<span class="xaml__attr_name">Placeholder</span>=<span class="xaml__attr_value">&quot;Age&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Picker</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;GenderPicker&quot;</span>&nbsp;<span class="xaml__attr_name">SelectedItem</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Gender}&quot;</span>&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;Gender&quot;</span>&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;White&quot;</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;40&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Picker</span>.ItemsSource<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;x</span>:Array&nbsp;<span class="xaml__attr_name">Type</span>=<span class="xaml__attr_value">&quot;{x:Type&nbsp;x:String}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;x</span><span class="xaml__tag_start">:String&gt;</span>Male<span class="xaml__tag_end">&lt;/x:String&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;x</span><span class="xaml__tag_start">:String&gt;</span>FeMale<span class="xaml__tag_end">&lt;/x:String&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/x:Array&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Picker.ItemsSource&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Picker&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackLayout&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DatePicker</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;txtDOB&quot;</span>&nbsp;<span class="xaml__attr_name">Date</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;DOB}&quot;</span>&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;White&quot;</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;40&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;txtAddress&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Address}&quot;</span>&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;White&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;40&quot;</span>&nbsp;<span class="xaml__attr_name">Placeholder</span>=<span class="xaml__attr_value">&quot;Address&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackLayout&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_end">&lt;/ContentView&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-family:verdana,sans-serif">Declare above ContentView name space in Xaml to reuse it in AddContact.
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;?xml</span>&nbsp;<span class="xaml__attr_name">version</span>=<span class="xaml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xaml__attr_name">encoding</span>=<span class="xaml__attr_value">&quot;UTF-8&quot;</span><span class="xaml__tag_start">?&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_start">&lt;ContentPage</span>&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://xamarin.com/schemas/2014/forms&quot;</span>&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2009/xaml&quot;</span>&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">local</span>=<span class="xaml__attr_value">&quot;clr-namespace:SQLiteSample.Views&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackLayout</span>&nbsp;<span class="xaml__attr_name">Padding</span>=<span class="xaml__attr_value">&quot;20&quot;</span>&nbsp;<span class="xaml__attr_name">Spacing</span>=<span class="xaml__attr_value">&quot;12&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:ContactView&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackLayout&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_end">&lt;/ContentPage&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-family:verdana,sans-serif">Now in Views folder create&nbsp;</span><span style="font-family:Verdana,Arial,Helvetica,sans-serif">AddContact.xaml page and&nbsp;add below xaml code
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="csharp">&lt;?xml&nbsp;version=<span class="cs__string">&quot;1.0&quot;</span>&nbsp;encoding=<span class="cs__string">&quot;UTF-8&quot;</span>?&gt;&nbsp;&nbsp;&nbsp;
&lt;ContentPage&nbsp;xmlns=<span class="cs__string">&quot;http://xamarin.com/schemas/2014/forms&quot;</span>&nbsp;Title=<span class="cs__string">&quot;Add&nbsp;Contact&quot;</span>&nbsp;BackgroundColor=<span class="cs__string">&quot;#D5E7FA&quot;</span>&nbsp;xmlns:x=<span class="cs__string">&quot;http://schemas.microsoft.com/winfx/2009/xaml&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;x:Class=<span class="cs__string">&quot;SQLiteSample.Views.AddContact&quot;</span>&nbsp;xmlns:local=<span class="cs__string">&quot;clr-namespace:SQLiteSample.Views&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;StackLayout&nbsp;Padding=<span class="cs__string">&quot;20&quot;</span>&nbsp;Spacing=<span class="cs__string">&quot;12&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;local:ContactView&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Button&nbsp;x:Name=<span class="cs__string">&quot;SubmitButton&quot;</span>&nbsp;Command=<span class="cs__string">&quot;{Binding&nbsp;AddContactCommand}&quot;</span>&nbsp;BorderRadius=<span class="cs__string">&quot;0&quot;</span>&nbsp;Text=<span class="cs__string">&quot;Save&nbsp;Contact&quot;</span>&nbsp;FontAttributes=<span class="cs__string">&quot;Bold&quot;</span>&nbsp;TextColor=<span class="cs__string">&quot;White&quot;</span>&nbsp;BackgroundColor=<span class="cs__string">&quot;#5989B5&quot;</span>/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Label&nbsp;Text=<span class="cs__string">&quot;View&nbsp;All&nbsp;Contacts&quot;</span>&nbsp;IsVisible=<span class="cs__string">&quot;{Binding&nbsp;IsViewAll}&quot;</span>&nbsp;x:Name=<span class="cs__string">&quot;ViewLbl&quot;</span>&nbsp;TextColor=<span class="cs__string">&quot;Black&quot;</span>&nbsp;HorizontalOptions=<span class="cs__string">&quot;EndAndExpand&quot;</span>&nbsp;FontSize=<span class="cs__string">&quot;15&quot;</span>&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Label.GestureRecognizers&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TapGestureRecognizer&nbsp;Command=<span class="cs__string">&quot;{Binding&nbsp;ViewAllContactsCommand}&quot;</span>&nbsp;NumberOfTapsRequired=<span class="cs__string">&quot;1&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Label.GestureRecognizers&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Label&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/StackLayout&gt;&nbsp;&nbsp;&nbsp;
&lt;/ContentPage&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Set BindingContext with view model like below
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;SQLiteSample.ViewModels;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.Views&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;AddContact&nbsp;:&nbsp;ContentPage&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;AddContact()&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BindingContext&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AddContactViewModel(Navigation);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="font-family:verdana,sans-serif"><span style="text-decoration:underline">Contact List</span></strong></div>
</div>
</span></div>
</span></div>
<p>&nbsp;</p>
</div>
<div>
<p><span style="font-size:small">We need to create a page that can display all contact details, also to add new contact details and delete all contacts.</span></p>
<p><span style="font-size:small">In Views folder, Create ContactList.xaml and add below code.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;?xml</span>&nbsp;<span class="xaml__attr_name">version</span>=<span class="xaml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xaml__attr_name">encoding</span>=<span class="xaml__attr_value">&quot;UTF-8&quot;</span><span class="xaml__tag_start">?&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_start">&lt;ContentPage</span>&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://xamarin.com/schemas/2014/forms&quot;</span>&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;Contact&nbsp;List&quot;</span>&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2009/xaml&quot;</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;SQLiteSample.Views.ContactList&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;<span class="xaml__attr_name">Padding</span>=<span class="xaml__attr_value">&quot;10,20,10,40&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;*&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.ColumnDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ColumnDefinition</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;*&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ColumnDefinition</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;*&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.ColumnDefinitions&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;New&nbsp;Contact&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Column</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">FontAttributes</span>=<span class="xaml__attr_value">&quot;Bold&quot;</span>&nbsp;<span class="xaml__attr_name">BorderRadius</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;40&quot;</span>&nbsp;<span class="xaml__attr_name">BorderColor</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;Transparent&quot;</span>&nbsp;<span class="xaml__attr_name">BorderWidth</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">TextColor</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">Command</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;AddCommand}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ContactListView&quot;</span>&nbsp;<span class="xaml__attr_name">HasUnevenRows</span>=<span class="xaml__attr_value">&quot;true&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">SeparatorColor</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ContactList}&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">SelectedItem</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;SelectedContactItem,&nbsp;Mode=TwoWay}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>.ItemTemplate<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ViewCell</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;&nbsp;<span class="xaml__attr_name">Padding</span>=<span class="xaml__attr_value">&quot;10&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.ColumnDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ColumnDefinition</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ColumnDefinition</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;*&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.ColumnDefinitions&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Name}&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">Font</span>=<span class="xaml__attr_value">&quot;20&quot;</span>&nbsp;<span class="xaml__attr_name">TextColor</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;MobileNumber}&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">Font</span>=<span class="xaml__attr_value">&quot;20&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Column</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;EndAndExpand&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalTextAlignment</span>=<span class="xaml__attr_value">&quot;End&quot;</span>&nbsp;<span class="xaml__attr_name">TextColor</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Address}&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Column</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span>&nbsp;<span class="xaml__attr_name">TextColor</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ViewCell&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView.ItemTemplate&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ListView&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Delete&nbsp;All&nbsp;Contacts&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;<span class="xaml__attr_name">BorderRadius</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalOptions</span>=<span class="xaml__attr_value">&quot;EndAndExpand&quot;</span>&nbsp;<span class="xaml__attr_name">FontAttributes</span>=<span class="xaml__attr_value">&quot;Bold&quot;</span>&nbsp;<span class="xaml__attr_name">TextColor</span>=<span class="xaml__attr_value">&quot;White&quot;</span>&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;#5989B5&quot;</span>&nbsp;<span class="xaml__attr_name">Command</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;DeleteAllContactsCommand}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_end">&lt;/ContentPage&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-family:Verdana,sans-serif">In Above xaml code we added</span></div>
<p>&nbsp;</p>
<ul>
<li><span style="font-family:Verdana,sans-serif; font-size:small">Two buttons (New Contact, Delete All Contacts)</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">ListView (Two display contacts list and to set ItemsSource ContactList)&nbsp;&nbsp;</span>
</li></ul>
<p><span style="font-family:Verdana,sans-serif">Now set BindingContext with viewmodel in&nbsp;</span><span style="font-family:verdana,sans-serif; font-size:small">ContactList.xaml.cs like below
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Helpers;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.Models;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SQLiteSample.ViewModels;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.Views&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;ContactList&nbsp;:&nbsp;ContentPage&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ContactList()&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnAppearing()&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.BindingContext&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ContactListViewModel(Navigation);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong><span style="text-decoration:underline">DetailsPage:</span></strong></div>
<p>&nbsp;</p>
<p><span style="font-family:verdana,sans-serif; font-size:small">We need to create a page that can display particular contact details, also to update/delete contact details.</span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">In Views folder, Create DetailsPage.xaml and add below code.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;?xml</span>&nbsp;<span class="xaml__attr_name">version</span>=<span class="xaml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xaml__attr_name">encoding</span>=<span class="xaml__attr_value">&quot;UTF-8&quot;</span><span class="xaml__tag_start">?&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_start">&lt;ContentPage</span>&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://xamarin.com/schemas/2014/forms&quot;</span>&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;Contact&nbsp;Details&quot;</span>&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;#D5E7FA&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2009/xaml&quot;</span>&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">local</span>=<span class="xaml__attr_value">&quot;clr-namespace:SQLiteSample.Views&quot;</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;SQLiteSample.Views.DetailsPage&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackLayout</span>&nbsp;<span class="xaml__attr_name">Padding</span>=<span class="xaml__attr_value">&quot;20&quot;</span>&nbsp;<span class="xaml__attr_name">Spacing</span>=<span class="xaml__attr_value">&quot;12&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:ContactView&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Update&quot;</span>&nbsp;<span class="xaml__attr_name">BorderRadius</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,30,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">FontAttributes</span>=<span class="xaml__attr_value">&quot;Bold&quot;</span>&nbsp;<span class="xaml__attr_name">TextColor</span>=<span class="xaml__attr_value">&quot;White&quot;</span>&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;#5989B5&quot;</span>&nbsp;<span class="xaml__attr_name">Command</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;UpdateContactCommand}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Delete&quot;</span>&nbsp;<span class="xaml__attr_name">BorderRadius</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,30,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">FontAttributes</span>=<span class="xaml__attr_value">&quot;Bold&quot;</span>&nbsp;<span class="xaml__attr_name">TextColor</span>=<span class="xaml__attr_value">&quot;White&quot;</span>&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;#5989B5&quot;</span>&nbsp;<span class="xaml__attr_name">Command</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;DeleteContactCommand}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackLayout&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_end">&lt;/ContentPage&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Please note that in above xaml, we are reusing the ContactView. Also we added two extra buttons (Delete, Update).</div>
<p>&nbsp;</p>
<p><span style="font-size:small"><span style="font-family:Verdana,sans-serif">Now set BindingContext with viewmodel in&nbsp;</span>DetailsPage.xaml.cs like below
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;SQLiteSample.ViewModels;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SQLiteSample.Views&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;DetailsPage&nbsp;:&nbsp;ContentPage&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DetailsPage(<span class="cs__keyword">int</span>&nbsp;contactID)&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.BindingContext&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DetailsViewModel(Navigation,&nbsp;contactID);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-family:verdana,sans-serif">Demo screens from iOS:</span></div>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small"><span style="font-family:verdana,sans-serif"><span style="text-decoration:underline"><a href="https://4.bp.blogspot.com/-OOZLH87Lcz8/WrYs0l6ShFI/AAAAAAAADuw/PEh2ohAZKEo9uhTNBJgEsXFU12d-0DJAwCLcBGAs/s1600/Screen%2BShot%2B2018-03-24%2Bat%2B4.15.48%2BPM.png"><img src="https://4.bp.blogspot.com/-OOZLH87Lcz8/WrYs0l6ShFI/AAAAAAAADuw/PEh2ohAZKEo9uhTNBJgEsXFU12d-0DJAwCLcBGAs/s400/Screen%2BShot%2B2018-03-24%2Bat%2B4.15.48%2BPM.png" border="0" alt="" width="231" height="400"></a></span></span><span style="text-decoration:underline"><a href="https://4.bp.blogspot.com/-VwAOTpiyQU4/WrYs6U86-BI/AAAAAAAADu0/8jSKS2wgf3AHkkSa-Yc0xaaZShii9vwIwCLcBGAs/s1600/Screen%2BShot%2B2018-03-24%2Bat%2B4.17.13%2BPM.png"><img src="https://4.bp.blogspot.com/-VwAOTpiyQU4/WrYs6U86-BI/AAAAAAAADu0/8jSKS2wgf3AHkkSa-Yc0xaaZShii9vwIwCLcBGAs/s400/Screen%2BShot%2B2018-03-24%2Bat%2B4.17.13%2BPM.png" border="0" alt="" width="231" height="400"></a></span></span></p>
<p class="separator"><span style="font-size:small"><a href="https://1.bp.blogspot.com/-5xFSXTu7HUU/WrYtKe7jyyI/AAAAAAAADu4/4jefxY7qZVYw-HVahRIxJwvvpWmfDUwUwCLcBGAs/s1600/Screen%2BShot%2B2018-03-24%2Bat%2B4.17.01%2BPM.png"><img src="https://1.bp.blogspot.com/-5xFSXTu7HUU/WrYtKe7jyyI/AAAAAAAADu4/4jefxY7qZVYw-HVahRIxJwvvpWmfDUwUwCLcBGAs/s400/Screen%2BShot%2B2018-03-24%2Bat%2B4.17.01%2BPM.png" border="0" alt="" width="231" height="400"></a></span></p>
</div>
<p class="separator"><span style="font-size:small"><strong>FeedBack Note:</strong>&nbsp;Please share your thoughts, what you think about this post, Is this post really helpful for you? I always welcome if you drop comments on this post and it would be impressive.</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><br>
</span></p>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">Follow me always at&nbsp;<a href="https://twitter.com/Subramanyam_B">@Subramanyam_B</a></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">Have a nice day by<span style="color:#000000">&nbsp;</span><a rel="author" href="http://bsubramanyamraju.blogspot.in/p/about-me.html">Subramanyam Raju</a><span style="color:#000000">&nbsp;:)</span></span></p>
</div>
</div>
</li></div>
</div>
