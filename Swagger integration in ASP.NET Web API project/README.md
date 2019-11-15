# Swagger integration in ASP.NET Web API project
## Requires
- Visual Studio 2015
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- Visual C#
- ASP.NET Web API
- Swagger
## Topics
- ASP.NET
- ASP.NET Web API
- Swagger
## Updated
- 08/18/2017
## Description

<h1><span style="font-size:large">Introduction</span></h1>
<div>
<p><span style="font-family:Times,&quot;Times New Roman&quot;,serif; font-size:small"><em>When you create a new ASP.NET Web API project, &nbsp;you need to present your APIs in a simple and comprehensive way?&nbsp;You can use Swagger.</em></span></p>
</div>
<div>
<p><span style="font-family:Times,&quot;Times New Roman&quot;,serif; font-size:small">&ldquo;Swagger is a simple yet powerful representation of your RESTful API. With the largest ecosystem of API tooling on the planet, thousands of developers are supporting Swagger in
 almost every modern programming language and deployment environment. With a Swagger-enabled API, you get interactive documentation, client SDK generation and discoverability.&rdquo;</span></p>
</div>
<div>
<p><span style="font-family:Times,&quot;Times New Roman&quot;,serif">-<a href="http://swagger.io/">swagger.io</a></span></p>
</div>
<h1><span style="font-family:Times,&quot;Times New Roman&quot;,serif; font-size:large">Add Swagger to Web API&nbsp;Project</span></h1>
<div>
<p><span style="font-family:Times,&quot;Times New Roman&quot;,serif; font-size:small">To add Swagger to an ASP.NET Web API, we will install an open source project called&nbsp;<a href="https://www.nuget.org/packages/Swashbuckle/">Swashbuckle&nbsp;</a>via NuGet.</span></p>
</div>
<div>
<p><span style="font-family:Times,&quot;Times New Roman&quot;,serif"><img id="176684" src="https://code.msdn.microsoft.com/site/view/file/176684/1/swagger3.JPG" alt="" width="640" height="59"></span></p>
</div>
<div>
<p><span style="font-family:Times,&quot;Times New Roman&quot;,serif; font-size:small">When we install the package, a new config file was added: SwaggerConfig as mentioned in the picture below:</span></p>
<p class="separator"><a href="https://4.bp.blogspot.com/-_pK7L6uEnlQ/WZQ-wXzUrJI/AAAAAAAAMns/RruwnS0wmikTAQNhzHxcroBx5qMtcQqbwCLcBGAs/s1600/swaggerConfig.JPG"><img src="https://4.bp.blogspot.com/-_pK7L6uEnlQ/WZQ-wXzUrJI/AAAAAAAAMns/RruwnS0wmikTAQNhzHxcroBx5qMtcQqbwCLcBGAs/s320/swaggerConfig.JPG" border="0" alt="" width="320" height="313"></a></p>
</div>
<h1><span style="font-family:Times,&quot;Times New Roman&quot;,serif">Swagger configuration&nbsp;</span></h1>
<p><span style="font-family:Times,&quot;Times New Roman&quot;,serif"><span style="font-size:large"><span style="font-size:small">In the configuration file added, we find the minimum configuration needed to enable Swagger and Swagger UI :</span><br>
</span></span></p>
<div></div>
<p><a href="https://1.bp.blogspot.com/-LoZnrmMJ42Y/WZQ_haQ5JzI/AAAAAAAAMn0/sRyTBWTsdcYDj-qd6UkeVopCJjxh_LzLgCLcBGAs/s1600/swaggerConfigFile.JPG"><img src="https://1.bp.blogspot.com/-LoZnrmMJ42Y/WZQ_haQ5JzI/AAAAAAAAMn0/sRyTBWTsdcYDj-qd6UkeVopCJjxh_LzLgCLcBGAs/s640/swaggerConfigFile.JPG" border="0" alt="" width="640" height="379"></a></p>
<p><span style="font-size:small"><span style="font-family:Times,&quot;Times New Roman&quot;,serif">Now, when we start a new debugging&nbsp;session, we get the URI of our API and we navigate to Swagger:&nbsp;</span><span style="font-family:Times,&quot;Times New Roman&quot;,serif"><strong>http://localhost:[PORT_NUM]/swagger</strong></span></span></p>
<p><span style="font-size:small">And if we want to display our APIs :</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-family:Times,&quot;Times New Roman&quot;,serif">Now, when we start a new debugging&nbsp;session, we get the URI of our API and we navigate to Swagger:&nbsp;</span><span><span style="font-family:Times,&quot;Times New Roman&quot;,serif"><strong>http://localhost:[PORT_NUM]/swagger</strong></span></span></p>
<p><span><br>
</span></p>
<p><span>And if we want to display our APIs :</span></p>
<p class="separator"><a href="https://3.bp.blogspot.com/-J0qZiom7-JY/WZbGAexheJI/AAAAAAAAMtA/dVjn-7EX_n0gv6xHqtNxsDdGBufh82Q7wCLcBGAs/s1600/SwaggerDisplay.JPG"><img src="https://3.bp.blogspot.com/-J0qZiom7-JY/WZbGAexheJI/AAAAAAAAMtA/dVjn-7EX_n0gv6xHqtNxsDdGBufh82Q7wCLcBGAs/s640/SwaggerDisplay.JPG" border="0" alt="" width="640" height="220"></a></p>
<p><span><br>
</span></p>
<h1><span><span style="font-family:Times,&quot;Times New Roman&quot;,serif">So what about documentation?</span></span></h1>
<h1><span style="font-size:small"><span style="font-family:Times,&quot;Times New Roman&quot;,serif">If we commented our code, we can enable XML Comments to display it in Swagger.</span></span></h1>
<p><span style="font-family:Times,&quot;Times New Roman&quot;,serif; font-size:small">In&nbsp;<em>Solution Explorer,</em>&nbsp;right-click on the Web API project and click&nbsp;<em>Properties</em>.&nbsp;Click the&nbsp;<em>Build</em>&nbsp;tab and navigate to&nbsp;<em>Output</em>.
 Make sure&nbsp;<em>XML documentation file</em>&nbsp;is checked. You can leave the default file path. In my case it is&nbsp;<em>bin\SwaggerSolution.Services.XML</em></span></p>
<p><span style="font-size:small">After, we enable the comment in the configuration file of Swagger: SwaggerConfig</span></p>
<p class="separator"><a href="https://1.bp.blogspot.com/-wNkQVM4nP9U/WZRqw-_FJeI/AAAAAAAAMoU/QyzNUbrBWiUmdfem35GfutzSgFtaq1xRgCLcBGAs/s1600/swaggerDoc.JPG"><img src="https://1.bp.blogspot.com/-wNkQVM4nP9U/WZRqw-_FJeI/AAAAAAAAMoU/QyzNUbrBWiUmdfem35GfutzSgFtaq1xRgCLcBGAs/s640/swaggerDoc.JPG" border="0" alt="" width="640" height="612"></a></p>
<div></div>
<div><span style="font-family:Times,&quot;Times New Roman&quot;,serif"><span>Let's Run now the project and take a look :)</span></span></div>
<div><span><br>
</span></div>
<div><span>I added this project as an extension to be able to use it easier in your project.</span></div>
<p class="separator"><a href="https://2.bp.blogspot.com/-VD-1EpwSZpk/WZbGy-5Xv7I/AAAAAAAAMtM/8gyESRLQBmY2NxH5qTLY11_IdKn-6lZZgCLcBGAs/s1600/getallArticles.JPG"><img src="https://2.bp.blogspot.com/-VD-1EpwSZpk/WZbGy-5Xv7I/AAAAAAAAMtM/8gyESRLQBmY2NxH5qTLY11_IdKn-6lZZgCLcBGAs/s640/getallArticles.JPG" border="0" alt="" width="640" height="272"></a></p>
<p class="separator"><a href="https://3.bp.blogspot.com/-NZceLeQs9po/WZbGyqrqMYI/AAAAAAAAMtI/RHUGvfo6dXcZfzmeqD_wYs1PohINlWbSACEwYBhgL/s1600/getall2.JPG"><img src="https://3.bp.blogspot.com/-NZceLeQs9po/WZbGyqrqMYI/AAAAAAAAMtI/RHUGvfo6dXcZfzmeqD_wYs1PohINlWbSACEwYBhgL/s640/getall2.JPG" border="0" alt="" width="640" height="516"></a></p>
