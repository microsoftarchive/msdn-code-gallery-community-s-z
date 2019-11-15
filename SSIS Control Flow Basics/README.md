# SSIS Control Flow Basics
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
- 07/01/2012
## Description

<h1>Introduction</h1>
<p>This sample introduces the fundamental concepts of the control flow. This lesson starts from the package created in the &quot;My First Integration Services Solution&quot; sample (<a href="http://code.msdn.microsoft.com/My-First-Integration-fa41c0b1">http://code.msdn.microsoft.com/My-First-Integration-fa41c0b1</a>).
 If you skipped that lesson, you can download the sample there before starting this lesson.</p>
<p>This lesson enhances the control flow by simulating integration with an external process. A common technique for integrating a system like SSIS into an external orchestration process is through the use of semaphore files. This sample demonstrates how to
 create such files using the SSIS control flow.</p>
<p>The solution attached to this sample represents what you'll create if you follow along with the steps in the video.</p>
<h1><em><object width="350" height="300" data="data:application/x-silverlight-2," type="application/x-silverlight-2"> <param name="source" value="/Content/Common/videoplayer.xap" /> <param name="initParams" value="deferredLoad=false,duration=0,m=http://code.msdn.microsoft.com/site/view/file/60428/1/Control%20Flow%20Basics.wmv,autostart=false,autohide=true,showembed=true"
 /> <param name="background" value="#00FFFFFF" /> <param name="minRuntimeVersion" value="3.0.40624.0" /> <param name="enableHtmlAccess" value="true" /> <param name="src" value="/site/view/file/60428/1/Control%20Flow%20Basics.wmv" /> <param name="id" value="60428"
 /> <param name="name" value="Control Flow Basics.wmv" /><span><a href="http://go.microsoft.com/fwlink/?LinkID=149156" style="text-decoration:none"><img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight" style="border-style:none"></a></span>
 </object> <br>
<a id="x_/site/view/file/60428/1/Control%20Flow%20Basics.wmv" href="http://code.msdn.microsoft.com/site/view/file/60428/1/Control%20Flow%20Basics.wmv">Download video</a></em></h1>
<p>&nbsp;</p>
<h1>Prerequisites</h1>
<p>Before attempting to follow along with the video you'll need to perform a few steps of configuration:</p>
<ul>
<li>Copy a data file to c:\SSIS . The file is named Product data.csv, and is contained within the sample archive.
</li><li>Copy the folder Semaphores from the sample archive to c:\SSIS\Control Flow Basics\Semaphores
</li><li>Create the directory c:\SSIS\Control Flow Basics\Result </li><li>Create a table in a SQL Server database into which you have permission to insert data.
</li></ul>
<p>&nbsp;The table can be created by executing the following SQL in the context of the database:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">Products</span>](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ProductCode</span>]&nbsp;[<span class="sql__keyword">int</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ShippingWeight</span>]&nbsp;[<span class="sql__keyword">float</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ShippingLength</span>]&nbsp;[<span class="sql__keyword">float</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ShippingWidth</span>]&nbsp;[<span class="sql__keyword">float</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ShippingHeight</span>]&nbsp;[<span class="sql__keyword">float</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">UnitCost</span>]&nbsp;[<span class="sql__keyword">float</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">PerOrder</span>]&nbsp;[<span class="sql__keyword">tinyint</span>]&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>&nbsp;
)&nbsp;<span class="sql__keyword">ON</span>&nbsp;[<span class="sql__keyword">PRIMARY</span>]&nbsp;
&nbsp;
<span class="sql__id">GO</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h1>Transcript</h1>
<p>If you'd prefer to read along rather than listen to the video, a rough transcipt is below:<br>
&nbsp;<br>
In this lesson I&rsquo;ll add some control flow to the package I created in the lesson titled My First Integration Services Solution.</p>
<p>To simulate integrating the execution of the SSIS Package into an external system I&rsquo;ll make the package create some semaphore files that indicate whether it succeeded or failed.</p>
<p>I&rsquo;ll start by adding a File System task to the Control Flow of the package.</p>
<p>I double-click the task to open its editor.</p>
<p>As I select each property I can remind myself what it is by reading the description in the bottom of the page.</p>
<p>The first value I need to set is the Destination Connection.<br>
&nbsp;<br>
In SSIS connections to resources outside of the package are managed by &ldquo;Connection Managers&rdquo;. Tasks in the control flow as well as components in the data flow make use of Connection Managers. There are different types of connection managers. One
 type of connection manager is for Flat Files, another type is for connections to Sql Server, and there are many others.</p>
<p>The File System task I&rsquo;m creating will copy a file, so it uses a File Connection Manager.</p>
<p>I can define a new File Connection manager from within the editor for this File System task, as follows.</p>
<p>I click the drop down in the DestinationConnection property</p>
<p><br>
I select New connection</p>
<p>In this case I&rsquo;ll be creating a new file in the destination folder, so I select Create file.</p>
<p>I browse to the location I want the file to be created in.</p>
<p>I&rsquo;ll change the overwrite setting to true so that I can run this package repeatedly. If this were set to false, SSIS would respect the file that was already present and halt the package rather than overwrite it.</p>
<p>I note that the operation of this task is already set to Copy File.</p>
<p>I now create another connection manager for the source file that will be copied.</p>
<p>In this case the file will already exist, so I leave the Usage Type set to Existing File.</p>
<p>I pick the folder that contains the file I&rsquo;ll copy to the destination location I previously specified.</p>
<p>Before I close the editor, note these two connection manager names.</p>
<p>Now, when I close the editor, you can see these are the two connection managers that I created during the previous steps.</p>
<p>&nbsp;<br>
If I open up one, you can see that I can edit its properties here.<br>
&nbsp;<br>
These are just the default names based on the name of the file I&rsquo;m using. I&rsquo;ll rename them so the names are a little more clear.</p>
<p>I&rsquo;ll also rename the Data Flow task and File System task while I&rsquo;m at it.</p>
<p>If I were to run the package at this point, how would SSIS know which task to run first? Should the Data Flow start first, or should the File System Task start first?</p>
<p>Actually, SSIS would start them both at the same time. In SSIS, any number of tasks can be running concurrently.</p>
<p>In this case, that&rsquo;s not what I want. I only want the File System task to run after the Data Flow task has succeeded, so I&rsquo;ll create a constraint between these two tasks.</p>
<p>I select the Data Flow task. Note the arrow that appeared. I click this arrow, and then click the file system task to create the constraint.</p>
<p>The green color of the arrow indicates that this is an &ldquo;On Success&rdquo; constraint. The File System Task will only start executing after the Data Flow task has completed, and then only if the data flow task didn&rsquo;t encounter errors.</p>
<p>I&rsquo;ll now add logic to handle the case that the Data Flow encounters an error.</p>
<p>This time, for purposes of illustration, I&rsquo;ll first create the connection managers before configuring the file system task that uses them.</p>
<p>First I&rsquo;ll create the connection manager for the failure semaphore source file.</p>
<p>I start by right clicking in the connection manager pane.</p>
<p>I select New File connection.</p>
<p>I pick the file.</p>
<p>I&rsquo;ll now rename the connection manager so it&rsquo;s more clear.</p>
<p>I&rsquo;ll now create the connection manager for the failure semaphore destination file.</p>
<p>In this case the file is being created, so I change the usage type to Create File.</p>
<p>Again, I rename the connection manager so its name is more clear.</p>
<p>Now I add a new File System task to the surface, and give it a more specific name.</p>
<p>I open its editor.</p>
<p>I pick the connection managers that I just created.</p>
<p>Just as was the case previously, I need to create a constraint between the data flow task and this file system task.</p>
<p>If I were to run the package now, assuming that the data flow task completed successfully, which of the file system tasks would SSIS run? The answer is both! SSIS would start both tasks concurrently.</p>
<p>In SSIS a task in the control flow starts running as soon as the constraints placed upon it are satisfied, regardless of what else is running in the control flow.</p>
<p>In this case, I want the new file system task to only run after the data flow task has completed and failed.</p>
<p>I therefore right-click on the constraint and change the constraint type to On Failure.</p>
<p>You can see that the color of the constraint changes to indicate this setting.</p>
<p><br>
Review</p>
<p>This lesson covered the following fundamental concepts in SSIS:</p>
<p>Connection managers are used for resources external to the package</p>
<p>Constraints define the order in which tasks execute</p>
<p>A task can have multiple constraints to and from it</p>
<p>Tasks only execute when the constraints pointing to them are satisfied.</p>
<p>Tasks which have no constraints pointing to them are therefore the first to execute</p>
<p>Constraints can be &ldquo;On Failure&rdquo; or &ldquo;On Success&rdquo;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
