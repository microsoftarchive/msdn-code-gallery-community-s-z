# Secure Login Form Example
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- Visual Basic .NET
## Topics
- Security
- Cryptography
- Hash
## Updated
- 12/06/2011
## Description

<h1>Introduction</h1>
<p>This example application uses MD5 hash encryption to protect login usernames and passwords from being found as plaintext. In this example, I used read and write functions to check for usernames and passwords from text files.&nbsp;You can modify this example
 to work with a database, server, website, or whatever your needs are to create users and login. This sample is written in VB.NET.</p>
<h1><span>Building the Sample</span></h1>
<p>To run this program, simply unzip the download file and open the Solution (.sln) file with Visual Basic 2010 Express or higher versions.</p>
<p>To see the example work, you must first create a user then attempt to login. Type in any username and password and click &quot;Create New&quot;. Login by placing the user and password credentials in the respective fields and click &quot;OK&quot;. If you have placed the correct
 credentials, you will see a message that shows that you have sucessfully &quot;logged in&quot;.&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This example application uses MD5 hash encryption to protect login usernames and passwords from being found as plaintext. In the example, I use read and write functions to check for usernames and passwords from text files. You can modify this example to
 work with a database, server, website, or whatever your needs are to create users and login. This sample is written in VB.NET.</p>
<p>The full source is commented neatly and is written with Option Strict and Option Explicit On for safe programming.</p>
<p>This program should be used a base to work on. It provides a general example that can be modified easily with the VB.NET language.</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li>Form1.vb - Contains the full code for the program. </li></ul>
<p>&nbsp;</p>
<p>MD5 Hash function:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">private string StringtoMD5(string Content)
{
	System.Security.Cryptography.MD5CryptoServiceProvider M5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
	byte[] ByteString = System.Text.Encoding.ASCII.GetBytes(Content);
	ByteString = M5.ComputeHash(ByteString);
	string FinalString = null;
	foreach (byte bt in ByteString) {
		FinalString &#43;= bt.ToString(&quot;x2&quot;);
	}
	return FinalString.ToUpper();
}</pre>
<pre class="hidden"> Private Function StringtoMD5(ByVal Content As String) As String
        Dim M5 As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim ByteString() As Byte = System.Text.Encoding.ASCII.GetBytes(Content)
        ByteString = M5.ComputeHash(ByteString)
        Dim FinalString As String = Nothing
        For Each bt As Byte In ByteString
            FinalString &amp;= bt.ToString(&quot;x2&quot;)
        Next
        Return FinalString.ToUpper()
    End Function</pre>
<div class="preview">
<pre class="js">private&nbsp;string&nbsp;StringtoMD5(string&nbsp;Content)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;System.Security.Cryptography.MD5CryptoServiceProvider&nbsp;M5&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;System.Security.Cryptography.MD5CryptoServiceProvider();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;byte[]&nbsp;ByteString&nbsp;=&nbsp;System.Text.Encoding.ASCII.GetBytes(Content);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ByteString&nbsp;=&nbsp;M5.ComputeHash(ByteString);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;FinalString&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(byte&nbsp;bt&nbsp;<span class="js__operator">in</span>&nbsp;ByteString)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FinalString&nbsp;&#43;=&nbsp;bt.ToString(<span class="js__string">&quot;x2&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;FinalString.ToUpper();&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<h1>Update Log</h1>
<p>11/18/2011 - Initial Release</p>
<p>12/6/2011 - Updated Create New Function to write set the file attributes to hidden along with encrypting the filename for added security.</p>
