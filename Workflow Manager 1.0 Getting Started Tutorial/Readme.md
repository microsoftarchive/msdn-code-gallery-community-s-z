# Workflow Manager 1.0 Getting Started Tutorial
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- Windows Workflow Foundation
- Workflow Manager 1.0
## Topics
- Workflow Manager 1.0
- DynamicValue
- Microsoft.Workflow.Samples.Common
## Updated
- 04/09/2015
## Description

<p><strong>Note that the designer experience for some of the activities in this tutorial (such as the HttpSend activity) are part of the Workflow Manager Tools for Visual Studio. These tools were not released for Visual Studio 2013 except as part of the Office
 Tools installation. WFM workflow authoring using WFM tools in VS 2013 is not supported at this time, however Sharepoint workflow authoring and debugging using WFM Tools in VS 2013 is supported &nbsp;through office tools installation). Workflow Manager Tools
 is still supported for Visual Studio 2012, and you can still follow the tutorial successfully using VS 2012.</strong></p>
<p>This project contains the completed version of the <a href="https://msdn.microsoft.com/en-us/library/windowsazure/dn217859(v=azure.10).aspx">
Workflow Manager 1.0 Getting Started Tutorial</a>&nbsp;on MSDN. This tutorial provides an example of creating a custom activity that retrieves products from the Northwind sample database, and an example of creating a workflow that uses this activity to enumerate
 the returned products. It shows how to create a scope, publish the activity and the workflow to the scope, and then create a workflow client application that starts the workflow. This lab also provides a demo of the Workflow Explorer sample application which
 provides a graphical way to inspect the scopes and workflow artifacts of a Workflow Manager server.</p>
<p style="padding-left:30px"><strong>Important:</strong> If you download and run the accompanying sample, copy the sample to a new path or rename the path so that it does not have a # in the path. By default the sample will extract to &quot;Workflow Manager 1.0
 Getting Started Tutorial\C#\...&quot;. Before running the sample, copy the files to a new folder or rename the path so that the # is removed, for example &quot;Workflow Manager 1.0 Getting Started Tutorial\CSharp\...&quot;.</p>
<p>In step 1, <a href="https://msdn.microsoft.com/en-us/library/windowsazure/dn175762(v=azure.10).aspx">
How to: Create a Custom Activity for Workflow Manager 1.0</a>,&nbsp;a custom activity that retrieves products from the Northwind sample database hosted at
<a href="http://services.odata.org/Northwind/Northwind.svc">http://services.odata.org/Northwind/Northwind.svc</a> is created. This activity used in following steps in the tutorial.</p>
<p><object width="350" height="300" data="data:application/x-silverlight-2," type="application/x-silverlight-2"> <param name="source" value="/Content/Common/videoplayer.xap" /> <param name="initParams" value="deferredLoad=false,duration=0,m=https://i1.code.msdn.s-msft.com/workflow-manager-10-4d6b3c14/image/file/85514/1/workflow%20manager%201.0%20getting%20started%20tutorial%20step%201.wmv,autostart=false,autohide=true,showembed=true"
 /> <param name="background" value="#00FFFFFF" /> <param name="minRuntimeVersion" value="3.0.40624.0" /> <param name="enableHtmlAccess" value="true" /> <param name="src" value="https://i1.code.msdn.s-msft.com/workflow-manager-10-4d6b3c14/image/file/85514/1/workflow%20manager%201.0%20getting%20started%20tutorial%20step%201.wmv"
 /> <param name="id" value="85514" /> <param name="name" value="Workflow Manager 1.0 Getting Started Tutorial Step 1.wmv" /><span><a href="http://go.microsoft.com/fwlink/?LinkID=149156" style="text-decoration:none"><img src="-?linkid=108181" alt="Get Microsoft Silverlight" style="border-style:none"></a></span>
 </object> <br>
<a id="https://i1.code.msdn.s-msft.com/workflow-manager-10-4d6b3c14/image/file/85514/1/workflow%20manager%201.0%20getting%20started%20tutorial%20step%201.wmv" href="https://i1.code.msdn.s-msft.com/workflow-manager-10-4d6b3c14/image/file/85514/1/workflow%20manager%201.0%20getting%20started%20tutorial%20step%201.wmv">Download
 video</a></p>
<p style="padding-left:30px"><strong>Note:</strong> The Uri expression for the HttpSend activity is slightly different in this video than in the accompanying documentation and sample code. This is because the&nbsp;sample was written to consume the more verbose
 JSON returned by OData 2 services. The Northwind OData service now uses OData 3 which has a less verbose JSON format. This change to the Uri expression specifies the more verbose format which the sample was written to consume.</p>
<p>&nbsp;</p>
<p>In step 2, <a href="https://msdn.microsoft.com/en-us/library/windowsazure/dn217861(v=azure.10).aspx">
How to: Create a Workflow for Workflow Manager 1.0</a>, a workflow is created that uses the GetProducts activity to return a collection of products. The workflow iterates through the collection and extracts the product name for each returned product, adds it
 to a list, and sets a user status containing the name of the product. This status is read and displayed by the workflow client application, which is created in a subsequent task. After all products have been read, the workflow sets a user status containing
 the list of product names, and completes.</p>
<p><object width="350" height="300" data="data:application/x-silverlight-2," type="application/x-silverlight-2"> <param name="source" value="/Content/Common/videoplayer.xap" /> <param name="initParams" value="deferredLoad=false,duration=0,m=https://i1.code.msdn.s-msft.com/workflow-manager-10-4d6b3c14/image/file/85515/1/workflow%20manager%201.0%20getting%20started%20tutorial%20step%202.wmv,autostart=false,autohide=true,showembed=true"
 /> <param name="background" value="#00FFFFFF" /> <param name="minRuntimeVersion" value="3.0.40624.0" /> <param name="enableHtmlAccess" value="true" /> <param name="src" value="https://i1.code.msdn.s-msft.com/workflow-manager-10-4d6b3c14/image/file/85515/1/workflow%20manager%201.0%20getting%20started%20tutorial%20step%202.wmv"
 /> <param name="id" value="85515" /> <param name="name" value="Workflow Manager 1.0 Getting Started Tutorial Step 2.wmv" /><span><a href="http://go.microsoft.com/fwlink/?LinkID=149156" style="text-decoration:none"><img src="-?linkid=108181" alt="Get Microsoft Silverlight" style="border-style:none"></a></span>
 </object> <br>
<a id="https://i1.code.msdn.s-msft.com/workflow-manager-10-4d6b3c14/image/file/85515/1/workflow%20manager%201.0%20getting%20started%20tutorial%20step%202.wmv" href="https://i1.code.msdn.s-msft.com/workflow-manager-10-4d6b3c14/image/file/85515/1/workflow%20manager%201.0%20getting%20started%20tutorial%20step%202.wmv">Download
 video</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>In step 3, <a href="https://msdn.microsoft.com/en-us/library/windowsazure/dn217860(v=azure.10).aspx">
How to: Publish and Run a Workflow for Workflow Manager 1.0</a>, a workflow client application is created that creates a scope, publishes the activity and workflow, and then invokes the workflow. This step also demonstrates the Workflow Resource Browser sample.</p>
<p><object width="350" height="300" data="data:application/x-silverlight-2," type="application/x-silverlight-2"> <param name="source" value="/Content/Common/videoplayer.xap" /> <param name="initParams" value="deferredLoad=false,duration=0,m=https://i1.code.msdn.s-msft.com/workflow-manager-10-4d6b3c14/image/file/85516/1/workflow%20manager%201.0%20getting%20started%20tutorial%20step%203.wmv,autostart=false,autohide=true,showembed=true"
 /> <param name="background" value="#00FFFFFF" /> <param name="minRuntimeVersion" value="3.0.40624.0" /> <param name="enableHtmlAccess" value="true" /> <param name="src" value="https://i1.code.msdn.s-msft.com/workflow-manager-10-4d6b3c14/image/file/85516/1/workflow%20manager%201.0%20getting%20started%20tutorial%20step%203.wmv"
 /> <param name="id" value="85516" /> <param name="name" value="Workflow Manager 1.0 Getting Started Tutorial Step 3.wmv" /><span><a href="http://go.microsoft.com/fwlink/?LinkID=149156" style="text-decoration:none"><img src="-?linkid=108181" alt="Get Microsoft Silverlight" style="border-style:none"></a></span>
 </object> <br>
<a id="https://i1.code.msdn.s-msft.com/workflow-manager-10-4d6b3c14/image/file/85516/1/workflow%20manager%201.0%20getting%20started%20tutorial%20step%203.wmv" href="https://i1.code.msdn.s-msft.com/workflow-manager-10-4d6b3c14/image/file/85516/1/workflow%20manager%201.0%20getting%20started%20tutorial%20step%203.wmv">Download
 video</a></p>
