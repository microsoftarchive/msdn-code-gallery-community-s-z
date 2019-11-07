# Using Crystal Report in ASP.net MVC and creating generic report viewer
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- ASP.NET MVC 3
- Crystal Report
## Topics
- Using Crystal Report in ASP.net MVC
## Updated
- 01/17/2012
## Description

<h1>Introduction</h1>
<p><em>A sample VS 2010 project which will show how to use crystal report from ASP.net MVC project. This also shows how to create a generic/ common report viewer for showing crystal report.<br>
</em></p>
<h1><span>Prerequisite</span></h1>
<p><em>To build and run this sample, you must have Visual Studio 2010 SP1, ASP.net MVC 3 and Crystal Report 13.0.2000.0.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This project illustrates the following topics:<br>
1. Showing crystal report using ASP.net web forms in MVC.<br>
&nbsp;A. In same window<br>
&nbsp;B. In different window<br>
2. Showing crystal report from Controller/action (by generating PDF on fly).<br>
&nbsp;A. In same window<br>
&nbsp;B. In different window<br>
3. Creating Generic/Common report viewer<br>
&nbsp;A. Create Generic Report Viewer Form for showing crystal report through asp.net (*.aspx) page<br>
&nbsp; i. In same window<br>
&nbsp; ii. In different window<br>
&nbsp;B. Create Generic Report Controller class for showing crystal report by pdf on fly.<br>
&nbsp; i. In same window<br>
&nbsp;ii. In different window</p>
<p><img src="46215-cr1.jpg" alt="" width="587" height="141"><br>
Fig: Showing simple report from ASP.net MVC3 Project</p>
<p><img src="46216-cr3.jpg" alt=""></p>
<p>Fig: Showing Crystal Report from ASP.net MVC Project with generic report viewer form</p>
<h1><span>Source Code Files</span></h1>
<p>&gt;CR_With_MVC : This is Solution<br>
&gt;AspNetForms : Here we putted aspx pages<br>
&gt;&gt;&nbsp;aspnetgeneric.aspx : This aspx page is used for showing simple report<br>
&gt;&gt;&nbsp;aspnetsimple.aspx : This aspx page is used for showing common report which consist of data<br>
&gt;Content : holds css file<br>
&gt;Controllers : holds controller classes<br>
&gt;&gt;FromMvcController.cs: This controller is used for showing report from MVC<br>
&gt;&gt;GenericReportViewerController.cs : This is generic/Common controller used fro showing report on pdf<br>
&gt;&gt;UsingWebFormController.cs : This is used for showing crystal report using aspx page<br>
&gt;Models : holds entity classes<br>
&gt;&gt;&nbsp;Student.cs<br>
&gt;Rpts: Holds Crystal Reports<br>
&gt;&gt;generic.rpt <br>
&gt;&gt;simple.rpt<br>
&gt;Scripts : Holds script files<br>
&gt;Views : Holds Views<br>
&gt;&gt;FromMvc<br>
&gt;&gt;&gt;&nbsp;Index.cshtml<br>
&gt;&gt;UsingWebForm<br>
&gt;&gt;&gt;Index.cshtml</p>
<h1>More Information</h1>
<p><em>Please visit <a href="http://hasibulhaque.com/?p=244">http://hasibulhaque.com/?p=244</a>&nbsp;Here i have described all the steps.</em></p>
<p>&nbsp;</p>
<h1><em><em>&nbsp;</em></em>&nbsp;</h1>
