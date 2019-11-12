# Send Email Using ASP.NET CORE 1.1 With MailKit In VisualStudio 2017
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- NuGet
- C# 7.0
- ASP.NET Core 1.1
- Visual Studio 2017
- MailKit
## Topics
- C#
- NuGet
- C# 7.0
- ASP.NET Core 1.1
- Visual Studio 2017
- MailKit
## Updated
- 03/22/2017
## Description

<p>&nbsp;</p>
<h1><span style="font-family:Verdana">Introduction</span></h1>
<p>We are familiar with Sending Email Using ASP.NET With C#. But today, we are going to teach you how to send email using ASP.NET Core 1.1 with MailKit. We can implement it in ASP.Net Core very easily as compared to the previous versions of ASP.NET.<br>
<br>
<span style="font-size:12.1px">Before reading this article, you must read the articles given below for ASP.NET Core knowledge.</span><br style="font-size:12.1px">
</p>
<ul style="font-size:12.1px">
<li><a title="ASP.NET CORE 1.0: Getting Started" href="https://social.technet.microsoft.com/wiki/contents/articles/36451.asp-net-core-1-0-getting-started.aspx" target="_blank">ASP.NET CORE 1.0: Getting Started</a>
</li><li><a title="ASP.NET Core 1.0: Project Layout" href="https://social.technet.microsoft.com/wiki/contents/articles/36490.asp-net-core-1-0-project-layout.aspx" target="_blank">ASP.NET Core 1.0: Project Layout</a>
</li><li><a title="ASP.NET Core 1.0: Middleware And Static files (Part 1)" href="https://social.technet.microsoft.com/wiki/contents/articles/36629.asp-net-core-1-0-middleware-and-static-files-part-1.aspx" target="_blank">ASP.NET Core 1.0: Middleware And Static files
 (Part 1)</a> </li><li><a title="Middleware And Staticfiles In ASP.NET Core 1.0 - Part Two" href="https://social.technet.microsoft.com/wiki/contents/articles/36727.middleware-and-staticfiles-in-asp-net-core-1-0-part-two.aspx" target="_blank">Middleware And Staticfiles In ASP.NET
 Core 1.0 - Part Two</a> </li></ul>
<h1><span style="font-family:Verdana">MailKit</span></h1>
<p><br>
MailKit is a cross-platform mail client library built on top of MimeKit. That means we get all the mail sending libraries from MailKit, such as - Simple Mail Transfer Protocol (SMTP) etc.<br>
<br>
</p>
<h1><span style="font-family:Verdana">Simple Mail Transfer Protocol (SMTP)</span></h1>
<p><br>
Simple Mail Transfer Protocol (SMTP) is a TCP/IP protocol used in sending and receiving e-mail. Most e-mail systems that send mail over the Internet use SMTP to send messages from one server to another.The messages can then be retrieved with an e-mail client
 using either POP or IMAP.<br>
<br>
The following is a list of SMTP Server and Port Numbers.<br>
<br>
</p>
<table border="1" cellspacing="1" width="100%" style="background-color:#ffffff">
<tbody>
<tr>
<td align="center"><strong>Sl.No</strong></td>
<td align="center"><strong>Mail Server</strong></td>
<td align="center"><strong>SMTP Server( Host )</strong></td>
<td align="center"><strong>Port Number</strong></td>
</tr>
<tr>
<td>1</td>
<td>Gmail</td>
<td>smtp.gmail.com</td>
<td>587</td>
</tr>
<tr>
<td>2</td>
<td>Outlook</td>
<td>smtp.live.com</td>
<td>587</td>
</tr>
<tr>
<td>3</td>
<td>Yahoo Mail</td>
<td>smtp.mail.yahoo.com</td>
<td>465</td>
</tr>
<tr>
<td>4</td>
<td>Yahoo Mail Plus</td>
<td>plus.smtp.mail.yahoo.com</td>
<td>465</td>
</tr>
<tr>
<td>5</td>
<td>Hotmail</td>
<td>smtp.live.com</td>
<td>465</td>
</tr>
<tr>
<td>6</td>
<td>Office365.com</td>
<td>smtp.office365.com</td>
<td>587</td>
</tr>
<tr>
<td>7</td>
<td>zoho Mail</td>
<td>smtp.zoho.com</td>
<td>465</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
<h1>Output</h1>
<p><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/6560.gmail.png"><img src=":-6560.gmail.png" alt="" style="border-width:0px; border-style:solid"></a><br>
<br>
</p>
<div id="radePasteHelper" style="left:-10000px; border:0px solid red; top:200px; width:1px; height:1px; overflow:hidden">
<table border="1" cellspacing="1" width="100%" style="font-family:'open sans',sans-serif; font-size:14px; outline:0px; border-collapse:collapse; background-color:#ffffff">
<tbody style="outline:0px">
<tr>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
<br>
</td>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
Plus</td>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
plus.smtp.mail.yahoo.com</td>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
465</td>
</tr>
<tr>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
5</td>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
Hotmail</td>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
smtp.live.com</td>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
465</td>
</tr>
<tr>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
6</td>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
Office365.com</td>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
smtp.office365.com</td>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
587</td>
</tr>
<tr>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
7</td>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
zoho Mail</td>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
smtp.zoho.com</td>
<td style="border-right:1px dashed #ababab; border-bottom:1px dashed #ababab; border-top-color:#ababab; border-left-color:#ababab">
465</td>
</tr>
</tbody>
</table>
</div>
