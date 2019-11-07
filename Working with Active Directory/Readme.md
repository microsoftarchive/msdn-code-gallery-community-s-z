# Working with Active Directory
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- Active Directory
- .NET Framework 4.0
## Topics
- Active Directory
## Updated
- 08/26/2013
## Description

<h1>Introduction</h1>
<p><em>Thi<span>s sample will help in connecting to the Active Directory, Authentication the user on the defined Active Directory and get all the users present in the defined groups in Active Directory. This code contains plug and play classes which can be
 directly placed into an application and can be used. On can also customize&nbsp;them according to th</span>e needs.</em></p>
<h1><span><span>Description</span></span></h1>
<p><em>This sample to be working you need .Net Framework 4.0. It contains one class library project and one Web site to show the demonstration.
</em></p>
<p><em>Class Library project contains one class named &quot;LDAP.cs&quot;, this is the class which is actually interacting with the Active Directory. This project needs a reference of &quot;System.DirectoryServices&quot;, so if one wants to interact with Active Directory then
 the library which will be interacting&nbsp;with Active Directory should have reference to this .Net DLL(s). &quot;LDAP.cs&quot; contains two public methods, one of which authenticates the user and other one helps in retrieving all the users from the Directory. Other
 class which is present in this library project is the &quot;User.cs&quot; this is the custom class created so as to get the user details from the Active Directory then fill in the details into this class, so as to keep the solution generic as every application has one
 User Entity of its own.</em></p>
<p><em>Website contains a sample page and one class which is <em>interacting&nbsp;</em>with the class library.</em></p>
<p><em>Sample page will demonstrate the Authentication logic along with the logic of getting users from the Active Directory in a particular group. Last is the application settings key added into &quot;Web.config&quot;.</em></p>
<p><em>First one is &quot;ActiveDirectoryPath&quot; &nbsp;- This will contain the path to your Active Directory</em></p>
<p><em>Second is &quot;DomainName&quot; - This is the domain on which your Active Directory is present.</em></p>
<p><em>Third and the last is the &quot;ActiveDirectoryGroups&quot; - This will contain&nbsp;all the groups for which you want to retrieve users from Active Directory. If you have multiple groups then you can give the Group name(s) as pipe(&quot;|&quot;) separated.</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;appSettings&gt;
    &lt;!--Active Directory Path  --&gt;
    &lt;add key=&quot;ActiveDirectoryPath&quot; value=&quot;&quot;/&gt;
    &lt;!--Domain Name  --&gt;
    &lt;add key=&quot;DomainName&quot; value=&quot;&quot;/&gt;
    &lt;!--User Groups for which search needs to be performed, User groups are Pipe Separated. example: &quot;Admin|Guest&quot; --&gt;
    &lt;add key=&quot;ActiveDirectoryGroups&quot; value=&quot;&quot;/&gt;
&lt;/appSettings&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;appSettings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__comment">&lt;!--Active&nbsp;Directory&nbsp;Path&nbsp;&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;ActiveDirectoryPath&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__comment">&lt;!--Domain&nbsp;Name&nbsp;&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;DomainName&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__comment">&lt;!--User&nbsp;Groups&nbsp;for&nbsp;which&nbsp;search&nbsp;needs&nbsp;to&nbsp;be&nbsp;performed,&nbsp;User&nbsp;groups&nbsp;are&nbsp;Pipe&nbsp;Separated.&nbsp;example:&nbsp;&quot;Admin|Guest&quot;&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;ActiveDirectoryGroups&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/appSettings&gt;</span></pre>
</div>
</div>
</div>
<p><em>So to get it working you just need to make changes in Web.Config and the sample will be running....</em></p>
<p>I welcome some valuable feedback.</p>
