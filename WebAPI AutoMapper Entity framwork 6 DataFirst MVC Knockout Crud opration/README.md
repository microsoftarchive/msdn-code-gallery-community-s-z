# WebAPI AutoMapper Entity framwork 6 DataFirst MVC Knockout Crud opration
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- SQL Server
- ADO.NET Entity Framework
- Class Library
- Entity Framework
- ASP.NET MVC 4
- ASP.NET Web API
- knockout.js
- automapper
## Topics
- Code Access Security
- ObservableCollection
- REST/JSON Web Services Communication
- N-tier application
- ViewModel pattern (MVVM) Knockout
## Updated
- 02/18/2015
## Description

<h1>Introduction</h1>
<p><em>In this sample we will make restfull webapi.through the knockout.js we will create the crud opration in to the data base . we have used the automapper for mapping the entiframwork models to Viewmodel. its working fine in to the IE becuase some jquery
 problem in javascript its not working in chrom and mozila.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>this sample have devide in to the multipal projects for futur inhancement and reusablity of the code and libraries in other miscrosoft .net technology. before execute the sample you have to configure your sqlserver database .please run the script in
 sqlserver query window.</em></p>
<p><em>create the table script</em></p>
<p><em>CREATE DATABASE [Testy]</em></p>
<p>&nbsp;</p>
<p><em>create the doctor table</em></p>
<p><em><br>
CREATE TABLE [dbo].[doctor](<span> </span>[id] [int] IDENTITY(1,1) NOT NULL,<span>
</span>[phone] [varchar](50) NULL,<span> </span>[address] [varchar](50) NULL,<span>
</span>[email] [varchar](50) NULL,<span> </span>[user_id] [int] NULL,&nbsp;CONSTRAINT [PK_doctor] PRIMARY KEY CLUSTERED&nbsp;(<span>
</span>[id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]</em></p>
<p>&nbsp;</p>
<p><em>create the user table</em></p>
<p><em><br>
CREATE TABLE [dbo].[user](<span> </span>[user_id] [int] IDENTITY(1,1) NOT NULL,<span>
</span>[user_name] [varchar](50) NULL,<span> </span>[fname] [varchar](50) NULL,<span>
</span>[lname] [varchar](50) NULL,&nbsp;CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED&nbsp;(<span>
</span>[user_id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>1)first we have create class library of Application.data where you have to create your database first approach entityframwork .edmx .</em></p>
<p><em><img id="133958" src="133958-2.png" alt="" width="1366" height="768"><br>
</em></p>
<p>&nbsp;</p>
<p><img id="133960" src="133960-1.png" alt="" width="1366" height="768"></p>
<p>&nbsp;</p>
<p><em>2)now you have to create application.Modelview where you will create the modelview according to the view .</em></p>
<p><em>3)Now you have to create new class library application.BLL .Its the buisness logic layer where we have done the all the basic crud opration with your data context.</em></p>
<p>&nbsp;</p>
<p><img id="133962" src="133962-3.png" alt="" width="1366" height="768"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><em>So you have to give reference of the application.data.</em></p>
<p>&nbsp;</p>
<p><em><br>
</em></p>
<p><em>this is the final view in IE please execute the application becuase its not working in chrom and mozila some jquery problem.</em></p>
<p><em><br>
</em></p>
<p><img id="133964" src="133964-4.png" alt="" width="1366" height="768"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><em>This is the some usefull code which is required. &nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Doctor&nbsp;view&nbsp;model</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;doctorVM&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>?&nbsp;user_id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;phone&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;address&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;email&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;public&nbsp;DateTime?&nbsp;created_date&nbsp;{&nbsp;get;&nbsp;set;&nbsp;}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;public&nbsp;DateTime?&nbsp;update_date&nbsp;{&nbsp;get;&nbsp;set;&nbsp;}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;public&nbsp;virtual&nbsp;user&nbsp;user&nbsp;{&nbsp;get;&nbsp;set;&nbsp;}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;user&nbsp;view&nbsp;model</span>&nbsp;
&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;userVM&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;user_id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;user_name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;fname&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;lname&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
<span class="cs__com">//auto&nbsp;mapper&nbsp;view&nbsp;to&nbsp;model</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DomainToViewModelMap&nbsp;:&nbsp;AutoMapper.Profile&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ProfileName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;ViewModelToDomainMappings&quot;</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Configure()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mapper.CreateMap&lt;doctor,&nbsp;doctorVM&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mapper.CreateMap&lt;user,&nbsp;userVM&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;automaper&nbsp;model&nbsp;to&nbsp;view</span>&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ViewModelToDomainMap&nbsp;:&nbsp;AutoMapper.Profile&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ProfileName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;ViewModelToDomainMappings&quot;</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Configure()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mapper.CreateMap&lt;doctorVM,&nbsp;doctor&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mapper.CreateMap&lt;userVM,&nbsp;user&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
<span class="cs__com">//automapper&nbsp;configuration</span>&nbsp;
&nbsp;
&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;AutoMapperConfiguration&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Configure()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mapper.Initialize(x&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x.AddProfile&lt;DomainToViewModelMap&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x.AddProfile&lt;ViewModelToDomainMap&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
<span class="cs__com">//configer&nbsp;automapper&nbsp;in&nbsp;global.asax&nbsp;in&nbsp;mvc&nbsp;web&nbsp;application</span>&nbsp;
&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Application_Start()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AreaRegistration.RegisterAllAreas();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebApiConfig.Register(GlobalConfiguration.Configuration);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RouteConfig.RegisterRoutes(RouteTable.Routes);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BundleConfig.RegisterBundles(BundleTable.Bundles);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CSdotnetWebTesty.BLL.AutoMapperConfiguration.Configure();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<h1><span style="font-size:10px"><em><span>&nbsp;</span>doctorBLL.cs</em></span></h1>
<p><span style="font-size:10px"><em>using AutoMapper;using CSdotnetWebTesty.Data;using CSdotnetWebTestyViewModel;using System;using <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;using <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;using <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;<br>
namespace CSdotnetWebTesty.BLL{&nbsp; public &nbsp;class doctorBLL&nbsp; &nbsp; {&nbsp; &nbsp; &nbsp; &nbsp; public IEnumerable&lt;doctorVM&gt; Get()&nbsp; &nbsp; &nbsp; &nbsp; {&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; TestyEntities _dbContext = new TestyEntities();&nbsp;
 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; List&lt;doctorVM&gt; query = new List&lt;doctorVM&gt;();&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var test = _dbContext.doctors.ToList();&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; foreach (var item in test)&nbsp; &nbsp; &nbsp;
 &nbsp; &nbsp; &nbsp; {&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var temp = Mapper.Map&lt;doctor, doctorVM&gt;(item);&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; query.Add(temp);&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }&nbsp; &nbsp;
 &nbsp; &nbsp; &nbsp; &nbsp; return query.AsQueryable();&nbsp; &nbsp; &nbsp; &nbsp; }&nbsp; &nbsp; &nbsp; &nbsp; public bool Create(doctorVM obj)&nbsp; &nbsp; &nbsp; &nbsp; {&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var doctorMap = Mapper.Map&lt;doctorVM, doctor&gt;(obj);&nbsp;
 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; TestyEntities _db = new TestyEntities();&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; _db.doctors.Add(doctorMap);&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; if (_db.SaveChanges() ==
 0)&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; { return true; }&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return false;&nbsp; &nbsp; &nbsp; &nbsp; }&nbsp; &nbsp; &nbsp; &nbsp; public bool Update(doctorVM obj)&nbsp; &nbsp; &nbsp; &nbsp; {&nbsp; &nbsp; &nbsp; &nbsp;
 &nbsp; &nbsp; var _db = new TestyEntities();&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var doctor = _db.doctors.Where(tem =&gt; tem.id == obj.id &amp;&amp; tem.user_id == obj.user_id).FirstOrDefault();&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; if (doctor !=
 null)&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; doctor.address = obj.address;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; //doctor.created_date = obj.created_date;&nbsp; &nbsp; &nbsp; &nbsp;
 &nbsp; &nbsp; &nbsp; &nbsp; doctor.email = obj.email;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; doctor.phone = obj.phone;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; //_db.doctors.Add(doctor);&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; if (_db.SaveChanges() == 1)&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return true;&nbsp; &nbsp;
 &nbsp; &nbsp; &nbsp; &nbsp; }&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return false;&nbsp; &nbsp; &nbsp; &nbsp; }&nbsp; &nbsp; &nbsp; &nbsp; public bool Delete(int Id)&nbsp; &nbsp; &nbsp; &nbsp; {&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var _db = new TestyEntities();&nbsp;
 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var doctor = _db.doctors.Where(tem =&gt; tem.id == Id).FirstOrDefault();&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; _db.doctors.Remove(doctor);&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; if (_db.SaveChanges() == 0)&nbsp; &nbsp;
 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return true;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return false;&nbsp; &nbsp; &nbsp; &nbsp; }&nbsp; &nbsp; &nbsp; &nbsp; public doctorVM GetbyId(int Id)&nbsp; &nbsp; &nbsp; &nbsp; {&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
 &nbsp; var _db = new TestyEntities();&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; var doctorVeiw = _db.doctors.Where(doct =&gt; doct.id == Id).FirstOrDefault();&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; return Mapper.Map&lt;doctor, doctorVM&gt;(doctorVeiw);&nbsp;
 &nbsp; &nbsp; &nbsp; }&nbsp; &nbsp; }}<br>
</em></span></p>
<h1>More Information</h1>
<p><em>for more information you can contact me at prmdpandit@gmail.com</em></p>
