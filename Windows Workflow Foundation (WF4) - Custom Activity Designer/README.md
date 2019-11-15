# Windows Workflow Foundation (WF4) - Custom Activity Designer
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Workflow
- WF
- Windows Workflow Foundation
- WF4
## Topics
- Designer
- Activity Designer
## Updated
- 10/16/2011
## Description

<h1>How to create a Custom Activity Designer with Windows Workflow Foundation (WF4)</h1>
<p>This sample demonstrates how you can build an activity and activity designer.&nbsp; It includes three projects</p>
<ol>
<li>MyActivityLibrary - The activity library project </li><li>MyActivityLibrary.Design - The activity designer project </li><li>DesignerWorkbench - A rehosted designer project useful for testing the activity
</li></ol>
<p>Update: The video is slightly out of sync with the current sample but mostly applies still.</p>
<h4><br>
<object width="350" height="300" data="data:application/x-silverlight-2," type="application/x-silverlight-2"> <param name="source" value="/Content/Common/videoplayer.xap" /> <param name="initParams" value="deferredLoad=false,duration=0,m=http://i1.code.msdn.s-msft.com/windows-workflow-9e867448/image/file/45191/1/appfabriccustomactivitydsgn_2mb_ch9.wmv,autostart=false,autohide=true,showembed=true"
 /> <param name="background" value="#00FFFFFF" /> <param name="minRuntimeVersion" value="3.0.40624.0" /> <param name="enableHtmlAccess" value="true" /> <param name="src" value="http://i1.code.msdn.s-msft.com/windows-workflow-9e867448/image/file/45191/1/appfabriccustomactivitydsgn_2mb_ch9.wmv"
 /><span><a href="http://go.microsoft.com/fwlink/?LinkID=149156" style="text-decoration:none"><img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight" style="border-style:none"></a></span> </object>
<br>
<a id="http://i1.code.msdn.s-msft.com/windows-workflow-9e867448/image/file/45191/1/appfabriccustomactivitydsgn_2mb_ch9.wmv" href="http://i1.code.msdn.s-msft.com/windows-workflow-9e867448/image/file/45191/1/appfabriccustomactivitydsgn_2mb_ch9.wmv">Download
 video</a></h4>
<h1><span>Step 1: Create the Activity<br>
</span></h1>
<p>The first step is to build your activity.&nbsp; Don't create a designer until you are satisifed with the interface to your activity in terms of arguments and properties.&nbsp; This sample includes a native activity named MyActivity which simply returns a
 string with the activity values.</p>
<p>The activity includes an InArgument and two properties including an enumerated value so you can see how to use these with your activity designer.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">sealed</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MyActivity&nbsp;:&nbsp;NativeActivity&lt;<span class="cs__keyword">string</span>&gt;&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MyEnum&nbsp;Option&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;TestCode&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DefaultValue(<span class="cs__keyword">null</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;InArgument&lt;<span class="cs__keyword">string</span>&gt;&nbsp;Text&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Execute(NativeActivityContext&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Result.Set(context,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;Text&nbsp;is&nbsp;{0},&nbsp;TestCode&nbsp;is&nbsp;{1},&nbsp;Option&nbsp;is&nbsp;{2}&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.GetValue(<span class="cs__keyword">this</span>.Text),&nbsp;<span class="cs__keyword">this</span>.TestCode,&nbsp;<span class="cs__keyword">this</span>.Option));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1 class="endscriptcode">Step 2: Add the Design Project</h1>
<p>Visual Studio uses a naming convention to locate an associated designer project.&nbsp; Since our assembly is named MyActivity.dll, Visual Studio will attempt to load MyActivity.Design.dll.</p>
<p>&nbsp;</p>
<ol>
<li>Select File / Add / New Project </li><li>Choose the Activity Designer Library project template </li><li>Name the project <strong>MyActivityLibrary.Design</strong> </li></ol>
<p><img src="http://i1.code.msdn.s-msft.com/windows-workflow-9e867448/image/file/44543/1/solution.png" alt="" width="241" height="129"></p>
<p>Step 3: Set the Output Directory</p>
<p>The Workflow Designer looks for the *.Design dll in the same directory as the activity assembly.&nbsp; Modify the build output so that it builds in that folder.&nbsp; Be sure to modify both Debug and Release settings.</p>
<p><img src="http://i1.code.msdn.s-msft.com/windows-workflow-9e867448/image/file/44544/1/buildoutput.png" alt="" width="519" height="97"></p>
<h1>Step 3: Add RegisterMetadata method</h1>
<p>The activity designer class should include a method to register the metadata for that designer.</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;MyActivityDesigner&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MyActivityDesigner()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;RegisterMetadata(AttributeTableBuilder&nbsp;builder)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;builder.AddCustomAttributes(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">typeof</span>(MyActivity),&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;DesignerAttribute(<span class="cs__keyword">typeof</span>(MyActivityDesigner)),&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;DescriptionAttribute(<span class="cs__string">&quot;My&nbsp;sample&nbsp;activity&quot;</span>),&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;ToolboxBitmapAttribute(<span class="cs__keyword">typeof</span>(MyActivity),&nbsp;<span class="cs__string">&quot;QuestionMark.png&quot;</span>}&nbsp;
</pre>
</div>
</div>
</div>
Step 4: Add Metadata Class</h1>
<p>Add a class that implements <strong><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Activities.Presentation.Metadata.IRegisterMetadata.aspx" target="_blank" title="Auto generated link to System.Activities.Presentation.Metadata.IRegisterMetadata">System.Activities.Presentation.Metadata.IRegisterMetadata</a></strong>. This class will be invoked at runtime to add attributes to the activity class. In the sample, I've added a static method called RegisterAll() which will
 register all of the activities contained in this library.&nbsp; This method is called from the test designer.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">sealed</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MyActivityLibraryMetadata&nbsp;:&nbsp;IRegisterMetadata&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Register()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RegisterAll();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;RegisterAll()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;builder&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AttributeTableBuilder();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyActivityDesigner.RegisterMetadata(builder);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;TODO:&nbsp;Other&nbsp;activities&nbsp;can&nbsp;be&nbsp;added&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MetadataStore.AddAttributeTable(builder.CreateTable());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1 class="endscriptcode">Step 5: Add an activity image to your Design Project</h1>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="endscriptcode">Your designer should include a 16x16 ToolBox image.&nbsp; The sample application includes the image
<strong>QuestionMark.png</strong> in the&nbsp; activity library.&nbsp; The <strong>
Build Action</strong> for this file should be set to <strong>Resource</strong></div>
<p>&nbsp;</p>
<p><img src="41355-buildactionresource.png" alt="" width="338" height="137"></p>
<h1>Step 6: Add the ToolboxBitmap</h1>
<p>To support a Toolbox Bitmp you will need to add the activity image to your activity library project also and set the
<strong>Build Action </strong>to <strong>Embedded Resource.&nbsp; </strong>The sample application has included the file QuestionMark.png as a linked file from the design project.</p>
<p><img src="41356-buildactionembedded.png" alt="" width="339" height="165"></p>
<p>Optionally, add the ToolboxBitmap attribute to your activity class.&nbsp;&nbsp; However the DesignerMetadata can add the attribute without causing your Activity library to have a reference to System.Drawing.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;MyActivity&nbsp;is&nbsp;a&nbsp;sample&nbsp;to&nbsp;show&nbsp;you&nbsp;how&nbsp;to&nbsp;create&nbsp;the&nbsp;designer</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;remarks&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;TODO:&nbsp;Be&nbsp;sure&nbsp;the&nbsp;build&nbsp;action&nbsp;for&nbsp;your&nbsp;bitmap&nbsp;is&nbsp;set&nbsp;to&nbsp;Embedded&nbsp;Resource&nbsp;</span>&nbsp;
<span class="cs__com">///&nbsp;&nbsp;&nbsp;NOTE:&nbsp;The&nbsp;bitmap&nbsp;must&nbsp;be&nbsp;at&nbsp;the&nbsp;same&nbsp;location&nbsp;as&nbsp;the&nbsp;class</span>&nbsp;
<span class="cs__com">///&nbsp;&nbsp;&nbsp;NOTE:&nbsp;If&nbsp;you&nbsp;use&nbsp;ToolboxBitmap&nbsp;here&nbsp;your&nbsp;activity&nbsp;assembly&nbsp;and&nbsp;those&nbsp;who&nbsp;use&nbsp;it&nbsp;will&nbsp;have&nbsp;to&nbsp;reference&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a></span>&nbsp;
<span class="cs__com">///&nbsp;&nbsp;&nbsp;Instead&nbsp;you&nbsp;can&nbsp;add&nbsp;the&nbsp;ToolboxBitmapAttribute&nbsp;when&nbsp;you&nbsp;register&nbsp;the&nbsp;metadata&nbsp;to&nbsp;avoid&nbsp;this.</span>&nbsp;
<span class="cs__com">///&nbsp;[ToolboxBitmap(typeof(MyActivity),&nbsp;&quot;QuestionMark.png&quot;)]</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/remarks&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">sealed</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MyActivity&nbsp;:&nbsp;NativeActivity&lt;<span class="cs__keyword">string</span>{&nbsp;
</pre>
</div>
</div>
</div>
<h1 class="endscriptcode">Step 7: Create The Designer</h1>
<div class="endscriptcode">The XAML in the Activity Designer Library template is for a simple designer.&nbsp; This sample includes a designer with support for Expand/Collapse and an activity image as well as a drop down list with enumerated values.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Here is the collapsed view where you would show only the most important values</div>
<div class="endscriptcode"><img src="41357-collapsed.png" alt="" width="357" height="79"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">And this is the expanded view where you can add more commonly access properties.&nbsp; Remember the property grid allows access to other properties that are not included on the design surface.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img src="41358-expanded.png" alt="" width="438" height="137"></div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">Step 8: Configure the Designer project for debugging</h1>
<p>There are two options for debugging your designer project.&nbsp; The recommended approach is to debug with a re-hosted designer application such as the one included with this application.&nbsp; Set the project properties as shown for debugging support.</p>
<p><img src="http://i1.code.msdn.s-msft.com/windows-workflow-9e867448/image/file/44555/1/startaction.png" alt="" width="492" height="121"></p>
<p>&nbsp;</p>
<p>To test with Visual Studio it is best to use the Experimental Instance option.&nbsp; Debugging with Visual Studio can take a long time so it is best to test by starting without debugging.</p>
<p><img src="41360-vsdebug.png" alt="" width="504" height="247"></p>
