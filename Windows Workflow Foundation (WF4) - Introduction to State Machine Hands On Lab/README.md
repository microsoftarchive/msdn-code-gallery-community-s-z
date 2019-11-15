# Windows Workflow Foundation (WF4) - Introduction to State Machine Hands On Lab
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Workflow
- WF4
## Topics
- State Machine
- Model View View/Model
## Updated
- 04/13/2012
## Description

<p>In&nbsp;this lab, you will learn how to build workflows using Windows Workflow Foundation (WF4) and the State Machine activity.&nbsp;</p>
<h3>Getting Started</h3>
<ol>
<li>Download and unzip the lab </li><li>Install the pre-requisites </li><li>Open the StateMachine.HOL.docx lab manual and start working through the exercises
</li></ol>
<h3><strong><object width="350" height="300" data="data:application/x-silverlight-2," type="application/x-silverlight-2"> <param name="source" value="/Content/Common/videoplayer.xap" /> <param name="initParams" value="deferredLoad=false,duration=0,m=http://i3.code.msdn.microsoft.com/windows-workflow-b4b808a8/image/file/21299/1/sm0.wmv,autostart=false,autohide=true,showembed=true"
 /> <param name="background" value="#00FFFFFF" /> <param name="minRuntimeVersion" value="3.0.40624.0" /> <param name="enableHtmlAccess" value="true" /> <param name="src" value="http://i3.code.msdn.microsoft.com/windows-workflow-b4b808a8/image/file/21299/1/sm0.wmv"
 /><span><a href="http://go.microsoft.com/fwlink/?LinkID=149156" style="text-decoration:none"><img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight" style="border-style:none"></a></span> </object>
<br>
<a id="http://i3.code.msdn.microsoft.com/windows-workflow-b4b808a8/image/file/21299/1/sm0.wmv" href="http://i3.code.msdn.microsoft.com/windows-workflow-b4b808a8/image/file/21299/1/sm0.wmv">Download video</a></strong></h3>
<h3><strong>Exercises</strong></h3>
<ul>
<li>Exercise 1 - States (<a href="http://channel9.msdn.com/Shows/Endpoint/endpointtv-WF4-State-Machine-Hands-On-Lab-Exercise-1">Video</a>)
</li><li>Exercise 2 - Card Inserted Scenario (<a href="http://channel9.msdn.com/Shows/Endpoint/endpointtv-WF4-State-Machine-Hands-On-Lab-Exercise-2">Video</a>)&nbsp;
</li><li>Exercise 3 - PIN Entry (<a href="http://channel9.msdn.com/Shows/Endpoint/endpointtv-WF4-State-Machine-Hands-On-Lab-Exercise-3">Video</a>)
</li><li>Exercise 4 - Implement the Main Menu (<a href="http://channel9.msdn.com/Shows/Endpoint/endpointtv-WF4-State-Machine-Hands-On-Lab-Exercise-4">Video</a>)
</li></ul>
<h3><strong>What is a State Machine?</strong></h3>
<div>
<p class="ppNote" style="padding-left:30px"><strong>&quot;</strong>It is a behavior model composed of a finite number of
<a title="State (computer science)" href="http://en.wikipedia.org/wiki/State_(computer_science)">
states</a>, transitions between those states, and actions, similar to a flow graph in which one can inspect the way
<a href="http://en.wikipedia.org/wiki/Logic">logic</a> runs when certain conditions are met.&quot;
<strong>- Wikipedia &ndash; </strong><a href="http://en.wikipedia.org/wiki/Finite-state_machine"><strong>Finite State Machine</strong></a></p>
</div>
<p>In Windows Workflow Foundation (WF4) a State Machine is a workflow activity that is best for scenarios where the workflow responds to events outside of itself.&nbsp; Throughout this lab, you will implement a State Machine that will direct the flow of the
 user interface for an Automated Teller Machine (ATM).&nbsp; The UI designers have done their analysis and come up with a set of scenarios that you will implement using the State Machine activity.</p>
<p><strong>&nbsp;</strong>The lab also includes pre-written code that implements a WPF UI using the Model-View-ViewModel pattern and unit tests to verify the behavior of the State Machine.&nbsp; Feel free to explore the Solution to learn how you can implement
 this pattern in your applications.</p>
<h3>Objectives</h3>
<ul>
<li>Understand the basics of the State Machine, States and Transitions </li><li>Create Entry and Exit Actions </li><li>Use Transitions and Triggers including Shared Triggers and Null Triggers </li></ul>
<h3>Pre-Requisites</h3>
<p>This lab assumes basic knowledge of Windows Workflow Foundation (WF4).&nbsp; If you are new to WF4, we suggest you complete the
<a href="http://visualstudiogallery.msdn.microsoft.com/7fe6f504-a58d-456e-8f55-e64bddc81a41/">
Introduction to WF4 Hands on Lab</a> prior to this lab.</p>
<h3>System Requirements</h3>
<p>You must have the following items to complete this lab:</p>
<ul>
<li><a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=75568aa6-8107-475d-948a-ef22627e57a5">Microsoft Visual Studio 2010 Service Pack 1</a>
</li><li><a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=e85a2f1b-031c-419c-95b2-0610e90bafd7">Microsoft .NET Framework 4 Platform Update 1 - Runtime Update (KB2478063)</a>
</li><li><a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=4863f88f-5519-4b66-a195-752746b4389a">Microsoft .NET Framework 4 Platform Update 1 &ndash; Design-time Update for Visual Studio 2010 SP1 (KB2495593)</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</li></ul>
<div>
<h3 class="ppListEnd">Starting Materials</h3>
</div>
<p>This Hands-On Lab includes the following starting materials.</p>
<ul>
<li><strong>Visual Studio Solutions. </strong>The lab provides the following Visual Studio Solutions that you can use as starting point for the exercises.
</li><li><strong>Assets.</strong> This lab includes activities, unit tests and a WPF application that will use the state machine you build.
</li><li><strong>Completed&nbsp;Solutions</strong> - Inside each exercise folder, you will find an
<strong>end</strong> folder containing a Solution with the completed lab exercise.
</li></ul>
<h3>Update History</h3>
<ul>
<li>4/22/11 - Minor doc updates for video links and fixes to solution files </li><li>12/3/11 - Updated namespace for Microsoft.Activities.Extensions </li></ul>
<p>&nbsp;</p>
<p><br>
<br>
</p>
<p><br>
<br>
</p>
