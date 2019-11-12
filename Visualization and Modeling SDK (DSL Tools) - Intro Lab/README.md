# Visualization and Modeling SDK (DSL Tools) - Intro Lab
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- Visualization and Modeling SDK
## Topics
- DSL definition and customization
- Creating a domain-specific language
## Updated
- 06/17/2011
## Description

<p>This is an introduction to the Visual Studio&nbsp;<a href="http://msdn.microsoft.com/library/bb126259.aspx" target="_blank">Visualization and Modeling SDK (DSL Tools).
</a>By following the steps described in the PDF files, you will create a domain-specific language and use it to generate code.</p>
<p><span style="color:#0000ff"><strong>The main content of this sample is in the PDF files, which are in the solution folder in the VS solution.</strong></span></p>
<p><span style="color:#0000ff"><strong>Download the solution and open the PDF files in Adobe Reader. The lab is in six chapters.</strong></span></p>
<p>For a sample of more advanced techniques, see <a href="http://code.msdn.microsoft.com/Visualization-Modeling-SDK-763778e8" target="_blank">
Circuit Diagrams Sample</a>.</p>
<p>Please post questions and suggestions in the <a href="http://social.msdn.microsoft.com/Forums/en-US/dslvsarchx/threads?prof=required" target="_blank">
Visualization and Modeling SDK Forum</a>.</p>
<p><strong>Objective of this Lab</strong>.<br>
The objective of this Lab is to create a specialized language by using the domain-specific language (DSL) Tools, and to customize it by using code that is based on the Visual Studio SDK. The DSL Tools are especially beneficial when you want to create a vertical
 language that is suitable for your business, and from the models that the language manipulates, generate the code for your business Framework. Nevertheless, because it is difficult to ensure that everyone who takes this training knows the professional tasks
 that are addressed by the targeted business Framework, we will settle for a horizontal (that is, technical) DSL that lets us learn how to use different aspects of DSL Tools.<br>
<br>
As an example, with the DSL for state machines that you'll create, you'll be able to express the creation of a Line, taking into account the creation from the center and one extremity rather than from both extremities when the user presses the 'C' key:</p>
<p><img src="19027-statemachinesample.jpg" alt="" width="995" height="460"></p>
<p>In addition to providing training, this document also shows an approach to DSL design.<br>
<br>
<strong>Prerequisites</strong><br>
Before you start this Lab, ensure that these items are installed on your computer:</p>
<ul>
<li><a class="externalLink" href="http://msdn.microsoft.com/vstudio">Visual Studio 2010</a>
</li><li><a class="externalLink" href="http://msdn.microsoft.com/vstudio">Visual Studio 2010 SDK</a>
</li><li><a class="externalLink" href="http://archive.msdn.microsoft.com/vsvmsdk">Visual Studio 2010 Visualization and Modeling SDK</a>
</li><li>The&nbsp;PDF files in the code files in this lab.&nbsp; </li></ul>
<p><br>
If you have <strong>Visual Studio 2008 or 2005</strong>, download instead:</p>
<ul>
<li><a class="externalLink" href="http://msdn.com/vsx">Visual Studio Extensibility</a> which includes DSL Tools
</li><li><a class="externalLink" href="https://archive.msdn.microsoft.com/Release/ProjectReleases.aspx?ProjectName=DSLToolsLab&ReleaseId=1698">2008 version of this Lab</a>
</li></ul>
<p><br>
In addition, to simplify the creation of your code generators, download and install a T4 editor from
<a class="externalLink" href="http://www.t4editor.net/">http://www.t4editor.net/</a>. A T4 editor provides syntactic coloring to aid in the editing of your T4 templates, including IntelliSense for the professional version of it.<br>
<br>
<strong>Feedback and discussion</strong><br>
Please post comments and questions to the <a class="externalLink" href="http://social.msdn.microsoft.com/Forums/en-US/dslvsarchx/">
Visualization and Modeling SDK Forum</a>.</p>
<h1>Related Items</h1>
<ul>
<li><a href="http://code.msdn.microsoft.com/VMSDK-DSL-Tools-MSI-Setup-ac289d07" target="_blank">Deploy DSLs in an MSI</a>&nbsp;
</li></ul>
<div class="mcePaste" id="_mcePaste" style="width:1px; height:1px; overflow:hidden; top:0px; left:-10000px">
&#65279;</div>
