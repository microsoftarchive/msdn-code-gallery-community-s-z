# Unit testing sending emails
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Unit Test
- eml conversion
- Email Processing in C#
## Topics
- C#
- Unit Testing
- eml conversion
## Updated
- 06/21/2017
## Description

<h1>Description</h1>
<p><span style="font-size:small">This code sample is about unit testing email operations. &nbsp;</span></p>
<p><span style="font-size:small">IMPORTANT: Before jumping into this please understand that it may take some time to properly this up for your solution. High level, you don't need the two projects MsgKit and MsgReader in your solution but instead install them.
 What you do need is a single project which is EmailConverters (which use both MsgKit and MsgReader).</span></p>
<p><span style="color:#ffffff; font-size:small">.</span></p>
<p><strong><span style="font-size:small">UPDATE 1&nbsp;</span></strong><span style="font-size:small">I have re-uploaded the solution without MsgKit and MsgReader source project, added in the packages which I exlcuded the first time as this made the download
 smaller but caused issues upon compiling as the packages where not being restored. Have tested this upload and works fine.</span></p>
<p><span style="font-size:small">.</span></p>
<p><span style="font-size:small"><strong>UPDATE 2</strong> Working on extracting attachments from .eml files, coming soon.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">To install the packages below, in your solution, select Tools menu in Visual Studio, select Package Manager Console and enter the commands below.</span></p>
<p><span style="font-size:small"><img id="174282" src="174282-1111.jpg" alt="" width="622" height="71"><br>
</span></p>
<p><span style="font-size:small">MsgReader:&nbsp;Install-Package MSGReader -Version 2.0.11</span></p>
<p><span style="font-size:small">MsgKit:&nbsp;Install-Package MsgKit -Version 1.0.0</span></p>
<p><span style="font-size:small">NOTE: MimeKit and OpenMcDf packages will be installed by the above.</span></p>
<p><br>
<span style="font-size:small">A simple unit test would be to send email messages using SmtpClient and MailMessage classes where you would setup DeliveryMethod and PickupDirectoryLocation for the SmtpClient, send the message, open the pickup location, open the
 .eml file generated and validate the information is correct or just do a file count of the folder to ensure there is a .eml file.</span></p>
<p><br>
<span style="font-size:small">One step up is to send the message as per above then open the file via the .NET File class and search for information e.g. from, to, cc, subject, body.</span></p>
<p><br>
<span style="font-size:small">Here I&rsquo;ve notice over the years many developers struggle with reading .eml files, it&rsquo;s messy and takes a good deal of code.</span></p>
<p><span style="font-size:small">&nbsp;</span><br>
<span style="font-size:small">What I&rsquo;m presenting uses two libraries found on GitHub, both are from the same author. The first, MsgKit creates (for this code sample) .msg message files which then are read using strong typed classes from the other library
 MsgReader.</span></p>
<p><br>
<span style="font-size:small">I take both libraries and incorporate them into a class project which makes creating a folder of .eml files into .msg files then parse the email files, in some cases down to HTML elements in the message body using yet another library
 HTML Agility pack.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Let's run through what is included (excluding the MsgKit and MsgReader), DesktopCreateEmlFiles is a desktop forms project. Here you can see the pattern for generating .eml files which are placed into a folder below the executable
 folder. The top CheckedListBox is for the TO address, the second for CC. They are followed by Subject, From and to the right creating a simple body. Press the Send button to create the .eml file. Press the Folder button to open the folder.</span></p>
<p><span style="font-size:small"><img id="174283" src="174283-222.jpg" alt="" width="680" height="352"><br>
</span></p>
<p><span style="font-size:small">In regards to the folder where the .eml files are generated, I use a Post build command to ensure the folder exists.</span></p>
<p><span style="font-size:small"><img id="174284" src="174284-333.jpg" alt="" width="430" height="101"></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>IMPORTANT</strong>: You would not use a forms project to generate your email messages but instead write unit test against your production services. In your class responsible for sending email messages you could check
 for the existance of a folder such as MailDrop, if it exists, use the setup I have in MailOperations and if the folder does not exists actually send the mail.&nbsp;</span></p>
<p><span style="font-size:small">Our team has such a class which is to complicated to use in this code sample as it relies on NInject and several custom base repositories.</span></p>
<p><span style="font-size:small">Okay, all data is stored in SQL-Server where I include a script to generate the database and two tables.</span></p>
<p><span style="font-size:small"><img id="174285" src="174285-4444.jpg" alt="" width="184" height="276"><br>
</span></p>
<p><span style="font-size:small">After generating the data via Script.sql, alter the server in DataOperations e.g. I have it set to KARENS-PC, you might change it to say .\SQLEXPRESS&nbsp;</span></p>
<p><span style="font-size:x-small"><img id="174286" src="174286-55555.jpg" alt="" width="340" height="113"><br>
</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<p><span style="font-size:small">Next I will focus on the conversion from eml to msg file via the following class. There is a good deal of code but there is one line that does the magic, the rest is reading the folder, getting file names (we generally will
 create one to 30 email files in a single unit test), generate the msg files and remove the eml files to keep things clean (there is another class dedicated to cleaning house).</span></p>
<p><span style="font-size:small">The magic line</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">MsgKit.Converter.ConvertEmlToMsg(file,&nbsp;Path.ChangeExtension(file,&nbsp;<span class="js__string">&quot;.msg&quot;</span>));</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;In FromEml class (which the above line is from) I've set it up so that if there are failures you can get them via properties if a method returns ToMsgResult for errors.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;enum&nbsp;ToMsgResult&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Success,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FailedWithException,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FolderNotFound&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">There is a good deal going on in this class and one might wonder, is this slow? I converted 30 .eml files in 178ms, not bad and as mentioned above there are clean up methods to clean up both eml and
 msg messages when running your unit test.</span></div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<div class="endscriptcode"><img id="174287" src="174287-66666.jpg" alt="" width="313" height="119"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">For demoing the above I created only four test (that's plenty once you look them over). To keep things easy to follow I created .eml files in different folders, some with meaningful names (which you
 can't do in a real unit test).</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Generated by unit test.</span></div>
<div class="endscriptcode"><span style="font-size:small"><img id="174288" src="174288-77777.jpg" alt="" width="273" height="75"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Should have shown this before, what a .eml looks like raw.</span></div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">X-Sender:&nbsp;WEBDEV.webdev@somewhere.com&nbsp;
X-Receiver:&nbsp;first@comcast.net&nbsp;
MIME-Version:&nbsp;<span class="js__num">1.0</span>&nbsp;
From:&nbsp;WEBDEV.webdev@somewhere.com&nbsp;
To:&nbsp;first@comcast.net&nbsp;
<span class="js__object">Date</span>:&nbsp;<span class="js__num">25</span>&nbsp;May&nbsp;<span class="js__num">2017</span>&nbsp;<span class="js__num">14</span>:<span class="js__num">15</span>:<span class="js__num">49</span>&nbsp;-<span class="js__num">0700</span>&nbsp;
Subject:&nbsp;Class&nbsp;completion&nbsp;notification&nbsp;
Content-Type:&nbsp;text/html;&nbsp;charset=us-ascii&nbsp;
Content-Transfer-Encoding:&nbsp;quoted-printable&nbsp;
&nbsp;
&lt;p&gt;Martha&nbsp;Adams&nbsp;has&nbsp;been&nbsp;completed&nbsp;the&nbsp;course&nbsp;Tuna&nbsp;Apprasing&nbsp;on&nbsp;t=&nbsp;
he&nbsp;following&nbsp;dates.&lt;<span class="js__reg_exp">/p&gt;&lt;ul&gt;&lt;li&gt;Sunday,&nbsp;February&nbsp;12,&nbsp;2017&lt;/</span>li&gt;&lt;li&gt;=&nbsp;
Thursday,&nbsp;May&nbsp;<span class="js__num">25</span>,&nbsp;<span class="js__num">2017</span>&lt;<span class="js__reg_exp">/li&gt;&lt;/</span>ul&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
Not pretty, .msg file is binary so I will not show it here.<br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">When and if you get deep enough to parse the body of an email using HTML Agility pack trust me, the debugger and local window are your friends to traverse the elements and figure out where things are.
 The following code exempifies this as I would had not gotten this without the local window.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">HtmlAgilityPack.HtmlDocument&nbsp;htmlDoc&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;HtmlAgilityPack.HtmlDocument();&nbsp;
htmlDoc.LoadHtml(singleMailInformation.BodyAsHTML);&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Validate&nbsp;the&nbsp;link</span>&nbsp;
Assert.IsTrue(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlDoc.DocumentNode.ChildNodes.FirstOrDefault()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ChildNodes.FirstOrDefault().NextSibling.OuterHtml&nbsp;==&nbsp;expectedLink);</pre>
</div>
</div>
</div>
<div class="endscriptcode">In closing, I hope this provides those looking for a better way to validate what is in an .eml file and better method. And this is not simply for unit test, you might need to do some sort of mass folder conversion and this would
 be helpful for that too.&nbsp;</div>
<br>
</span></div>
</div>
<div class="endscriptcode"><span style="font-size:small"><br>
</span></div>
<p>&nbsp;</p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
