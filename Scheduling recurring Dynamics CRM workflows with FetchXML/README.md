# Scheduling recurring Dynamics CRM workflows with FetchXML
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- Dynamics CRM
- Microsoft Dynamics CRM 2011
- Microsoft Dynamics CRM 2013
- Microsoft Dynamics CRM 2015
## Topics
- Microsoft Dynamics CRM SDK
## Updated
- 12/25/2014
## Description

<p><span style="color:#ff0000">Updated Dec. 15, 2014 - This sample now includes a CRM 2013 version of the solution as well as the original CRM 2011 solution.<br>
</span></p>
<h1>Introduction</h1>
<p>This code sample builds a Dynamics CRM custom workflow activity that takes a FetchXML query and a workflow (lookup) object as input parametrs, and then it executes that workflow for each record returned by the query. I use this custom workflow activity for
 scheduling recurring workflows in CRM as I described in my <a href="http://www.alexanderdevelopment.net/post/2013/05/19/Scheduling-recurring-Dynamics-CRM-workflows-with-FetchXML" target="_blank">
&quot;Scheduling recurring Dynamics CRM workflows with FetchXML&quot; blog post</a>.</p>
<p>My solution for scheduling recurring workflows consists of three components:</p>
<ol>
<li>A custom workflow activity (StartScheduledWorkflows) that can execute a supplied FetchXML query and initiate the workflow for each retrieved record.
</li><li>A custom entity (Scheduled Process) to hold the FetchXML query and scheduling details.
</li><li>A workflow (Scheduled Workflow Runner) to run the StartScheduledWorkflows activity on a recurring schedule.
</li></ol>
<p><img id="82332" src="http://i1.code.msdn.s-msft.com/executing-dynamics-crm-93f3b52a/image/file/82332/1/scheduled_workflow_process.png" alt=""></p>
<h1><span>Building the Sample</span></h1>
<p><span>Visual Studio 2012/.Net 4.5 is required as is the Microsoft Dynamics CRM SDK. No other non-System assemblies are required. Additionally, you must sign the assembly to register it in the CRM sandbox, but I have not included my .snk file in this sample,
 so you will have to supply your own.</span></p>
<h1>Source Code Files</h1>
<p>The sample contains the&nbsp;StartScheduledWorkflows class required to build the custom workflow activity as well as the&nbsp;ScheduledRecurringWorkflows CRM unmanaged solution export (ScheduledRecurringWorkflows_1_0_0_0.zip). The solution export archive
 contains a&nbsp;<span>built assembly with the custom workflow activity ready for registration in your CRM system.</span></p>
