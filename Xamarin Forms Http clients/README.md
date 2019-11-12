# Xamarin Forms Http clients
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Android
- iOS
- PCL
- Xamarin
- Xamarin.Forms
## Topics
- Web Services
- Mobile
- cross platform
- Native apps
## Updated
- 03/05/2015
## Description

<h1>Introduction</h1>
<p><em>What problem does the sample solve?</em></p>
<p><em>Xamarin.Forms is a great technology for building native cross platform applications. It uses C# and Visual Studio, that .NET developers already know to deliver apps for iOS, Android and Windows Phone based on one shared code base for both business logic
 and views. In addition to that, it uses almost the 'same' technology as XAML, that means making MVVM apps even easier.</em></p>
<p><em>This sample will show you how to leverage the strengthness of this technology to build mobile apps that connects to HTTP web services (<a href="http://intilaqemployees.azurewebsites.net/api/employeesapi" target="_blank">http://intilaqemployees.azurewebsites.net/api/employeesapi</a>)
 to perform CRUD operations.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Are there special requirements or instructions for building the sample?</em></p>
<p><em>This application requires Visual Studio 2013.</em></p>
<p><em>You can download it from&nbsp;<a href="http://www.microsoft.com/visualstudio/11/en-us"></a><a href="http://www.visualstudio.com/downloads/download-visual-studio-vs">http://www.visualstudio.com/downloads/download-visual-studio-vs</a>.</em></p>
<p><em>And Xamarin platform:&nbsp;<a href="http://xamarin.com/platform" target="_blank">http://xamarin.com/platform</a>.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The following picture shows the application running on Windows Phone Emulator listing all data from the web service.</em></p>
<p><em><br>
</em></p>
<p><img id="134641" src="134641-wp.png" alt="" width="359" height="649" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>&nbsp;</p>
<p>The following image shows the page dedicated for adding, editing and removing data from the web services.</p>
<p>&nbsp;</p>
<p><img id="134642" src="134642-wp2.png" alt="" width="363" height="651" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DataServices&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;BaseUrl&nbsp;=&nbsp;<span class="cs__string">&quot;http://intilaqemployees.azurewebsites.net/api/employeesapi/&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;List&lt;Employee&gt;&gt;&nbsp;GetEmployeesAsync()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;httpClient&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;jsonResponse&nbsp;=&nbsp;await&nbsp;httpClient.GetStringAsync(BaseUrl);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;employeesList&nbsp;=&nbsp;await&nbsp;JsonConvert.DeserializeObjectAsync&lt;List&lt;Employee&gt;&gt;(jsonResponse);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;employeesList;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>(Exception&nbsp;exc)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&nbsp;AddEmployeeAsync(Employee&nbsp;employee)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;httpClient&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;jsonEmployee&nbsp;=&nbsp;await&nbsp;JsonConvert.SerializeObjectAsync(employee);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContent&nbsp;httpContent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringContent(jsonEmployee);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpContent.Headers.ContentType&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MediaTypeHeaderValue(<span class="cs__string">&quot;application/json&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpClient.DefaultRequestHeaders.Accept&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Add(<span class="cs__keyword">new</span>&nbsp;MediaTypeWithQualityHeaderValue(<span class="cs__string">&quot;application/json&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;await&nbsp;httpClient.PostAsync(<span class="cs__keyword">new</span>&nbsp;Uri(BaseUrl),&nbsp;httpContent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&nbsp;DeleteEmmployeeAsync(Employee&nbsp;employee)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;httpClient&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;await&nbsp;httpClient.DeleteAsync(BaseUrl&nbsp;&#43;&nbsp;employee.Id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&nbsp;EditEmployeeAsync(Employee&nbsp;employee)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;httpClient&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;jsonEmployee&nbsp;=&nbsp;await&nbsp;JsonConvert.SerializeObjectAsync(employee);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;httpContent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringContent(jsonEmployee);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpContent.Headers.ContentType&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MediaTypeHeaderValue(<span class="cs__string">&quot;application/json&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpClient.DefaultRequestHeaders.Accept&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Add(<span class="cs__keyword">new</span>&nbsp;MediaTypeWithQualityHeaderValue(<span class="cs__string">&quot;application/json&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;await&nbsp;httpClient.PutAsync(BaseUrl&nbsp;&#43;&nbsp;employee.Id,&nbsp;httpContent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<ul>
</ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
<p><em>You may find an updated version on Github:&nbsp;<a href="https://github.com/HoussemDellai/RestfulApplicationXamarinForms" target="_blank">https://github.com/HoussemDellai/RestfulApplicationXamarinForms</a>.</em></p>
<p><em>For more information, y<em>ou can post on the Q&amp;A area or contact me on: houssem.dellai@live.com.</em></em></p>
<address>Please don't forget to rate my sample and to&nbsp;<a href="http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&f%5B0%5D.Value=Houssem%20Dellai" target="_blank">see my other samples here</a>.</address>
<p><em><br>
</em></p>
