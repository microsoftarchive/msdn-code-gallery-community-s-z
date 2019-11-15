# SSIS Data Flow Basics
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SSIS
- SQL Server Integration Services
- SSIS 2012
- SQL Server Integration Services 2012
## Topics
- Getting Started
## Updated
- 07/02/2012
## Description

<h1>Introduction</h1>
<p>This sample introduces the fundamental concepts of the data flow. This lesson starts from the package created in the &quot;SSIS Control Flow Basics&quot; sample (<a href="http://code.msdn.microsoft.com/SSIS-Control-Flow-Basics-16bd36d0">http://code.msdn.microsoft.com/SSIS-Control-Flow-Basics-16bd36d0</a>).
 If you skipped that lesson, you can download the sample there before starting this lesson.<br>
&nbsp;<br>
This lesson enhances the data flow by splitting the rows read from the CSV file into two streams. One of these streams continues to be loaded into the original table, but the second is loaded into a different table. Additionally, an error output is configured
 so the good data can be loaded even if there's some bad data.<br>
&nbsp;<br>
The solution attached to this sample represents what you'll create if you follow along with the steps in the video.</p>
<p>&nbsp;</p>
<p><object width="350" height="300" data="data:application/x-silverlight-2," type="application/x-silverlight-2"> <param name="source" value="/Content/Common/videoplayer.xap" /> <param name="initParams" value="deferredLoad=false,duration=0,m=http://code.msdn.microsoft.com/site/view/file/60432/1/Data%20Flow%20Basics.wmv,autostart=false,autohide=true,showembed=true"
 /> <param name="background" value="#00FFFFFF" /> <param name="minRuntimeVersion" value="3.0.40624.0" /> <param name="enableHtmlAccess" value="true" /> <param name="src" value="/site/view/file/60432/1/Data%20Flow%20Basics.wmv" /> <param name="id" value="60432"
 /> <param name="name" value="Data Flow Basics.wmv" /><span><a href="http://go.microsoft.com/fwlink/?LinkID=149156" style="text-decoration:none"><img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight" style="border-style:none"></a></span>
 </object> <br>
<a id="x_/site/view/file/60432/1/Data%20Flow%20Basics.wmv" href="http://code.msdn.microsoft.com/site/view/file/60432/1/Data%20Flow%20Basics.wmv">Download video</a></p>
<p>&nbsp;</p>
<h1>Prerequisites</h1>
<p>Before attempting to follow along with the video you'll need to perform a few steps of configuration:<br>
&bull;Copy a data file to c:\SSIS . The file is named Product data.csv, and is contained within the sample archive.<br>
&bull;Copy the folder Semaphores from the sample archive to c:\SSIS\Control Flow Basics\Semaphores<br>
&bull;Create the directory c:\SSIS\Control Flow Basics\Result <br>
&bull;Create two tables in a SQL Server database into which you have permission to insert data.</p>
<p>The tables can be created by executing the following SQL in the context of the database:</p>
<p>&nbsp;</p>
<h1>Transcript</h1>
<p>If you'd prefer to read along rather than listen to the video, a rough transcipt is below:</p>
<p>This lesson extends the package created in the lesson titled Control Flow Basics.</p>
<p>I&rsquo;ll change the package to send the data from the CSV file to two tables instead of one.</p>
<p>First I open the data flow.</p>
<p>I&rsquo;m going to be placing a transformation between the source and destination adapters, so I&rsquo;ll make a little more room.</p>
<p>I delete the existing path.</p>
<p>I&rsquo;ll add a conditional split transformation to the canvas.</p>
<p>You can read the description of the conditional split at the bottom of the toolbox.</p>
<p>I&rsquo;ll use this conditional split to send expensive products to a different table from the normal products.</p>
<p>Before editing the conditional split I connect it to the upstream data source.</p>
<p>I now configure the conditional split transform.</p>
<p>I&rsquo;ll build an expression that identifies expensive products.</p>
<p>I&rsquo;ll give the output a descriptive name</p>
<p>I also change the name of the default output to a more descriptive name.</p>
<p>This component now has two outputs. A row that enters this component will only leave through one of its outputs.</p>
<p>In this case, I only have two categories of products: Normal and expensive, so I only need one condition: If a product isn&rsquo;t expensive, it&rsquo;s normal.</p>
<p>I now need to connect the output of the conditional split to the destination adapter.</p>
<p>The existing destination adapter is configured for the normal products table, so I pick that output.</p>
<p>I&rsquo;ll give the destination adapter a more descriptive name so it won&rsquo;t be confusing when I add a second destination.</p>
<p>I now add the second destination.</p>
<p>I&rsquo;ll use the Destination assistant, again.</p>
<p>Since I&rsquo;m loading data into another table in the same database, in this case I can reuse the existing connection manager.</p>
<p>I configure the destination adapter.</p>
<p>My package will now run.</p>
<p>However, when I configured the conditional split transform I used an arithmetic expression that contained a division operation.</p>
<p>If there was some bad data in the input file, say, one of the rows had a zero in the Per Order column, this would trigger a divide by zero error during the middle of the data transfer.</p>
<p>This would stop the package at that point, leaving the data after that point in the file out of the database.</p>
<p>If I want the load to continue, and I want to handle the bad rows myself after the transfer is complete, I can configure the error output of the conditional split transform.</p>
<p>Most components in the data flow have an error output. By default, the component is configured such that if any row would use the error output the component generates an error at run time, which typically causes the package to halt with an error.<br>
&nbsp;<br>
To configure the error output I click that button.</p>
<p>I change the Error and Truncation handling conditions to Redirect Row, indicating that I want the bad rows to be sent out the error output rather than failing the component or being silently discarded.</p>
<p>There is now a warning on the conditional split.</p>
<p>SSIS notices that I went to the trouble of configuring the error output, but haven&rsquo;t connected anything to it, yet. This means that the rows will still be lost, and SSIS wants to make sure I&rsquo;m aware of this fact.</p>
<p>Thanks, SSIS!</p>
<p>I&rsquo;ll send the rows that cause errors into a file on disk so they can be reviewed later when someone&rsquo;s available to figure out what went wrong.</p>
<p>Rather than use the destination assistant, in this case I&rsquo;ll add the Flat File destination adapter directly from the toolbox.</p>
<p>I connect the error output of the conditional split to the flat file destination adapter.</p>
<p>SSIS gives me a chance to change the error output configuration, here, but I&rsquo;m happy with it the way it is.</p>
<p>I now configure the destination for the error rows.</p>
<p>I&rsquo;ll use a delimited file.<br>
&nbsp;<br>
I&rsquo;ll give the connection manager a more descriptive name.</p>
<p>I&rsquo;ll specify the file I want to use.</p>
<p>I&rsquo;ll switch to the mappings page to review the mappings.</p>
<p>SSIS has established all the mappings for me.</p>
<p>My package is complete.</p>
<p><br>
Review</p>
<p>This lesson covered several fundamental concepts in SSIS. In review, they are:</p>
<p>Transformations are placed between sources and destinations</p>
<p>Transformations are where the &ldquo;work&rdquo; of the data flow takes place.</p>
<p>Components in the dataflow can have multiple outputs, some of which can be Error outputs.</p>
<p>A data flow can have multiple destinations and multiple sources.</p>
