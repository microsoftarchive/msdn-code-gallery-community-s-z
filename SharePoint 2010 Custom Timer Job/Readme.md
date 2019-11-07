# SharePoint 2010 Custom Timer Job
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- SharePoint 2010
## Topics
- Deployment
- event receivers
- TimerJob
- Sharepoint features
## Updated
- 07/12/2012
## Description

<h1>Introduction</h1>
<p>Based on my popular articel about Creating Custom Timer Job in Sharepoint 2010,I Have decide to upload the simple code&nbsp; on how to create Custom Timer Job in Sharepoint 2010 ,But first let us know more about Timer Job</p>
<ul>
<li>A timer job runs in a specific Windows service for SharePoint Server. </li><li>Timer jobs also perform infrastructure tasks for the Timer service, such as clearing the timer job history and recycling the Timer service; and tasks for Web applications, such as sending e-mail alerts.
</li><li>A timer job contains a definition of the service to run and specifies how frequently the service is started.
</li><li>The SharePoint 2010 Timer service (SPTimerv4) runs timer jobs. </li><li>Many features in SharePoint Server rely on timer jobs to run services according to a schedule.
</li></ul>
<h1><span>Building the Sample</span></h1>
<p>To run the sample you just need to open it in Visual Studio 2010 then deploy it to your test machine or you can package it to deploy it in Production environment.The solution itself will create list for you and try to fill it each five minutes.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Based on my knoladge Customer Timer job in sharepoint 2010 <em>is on of the most
</em>confused approch in SharePoint Many developer stuck at some point and they do not what to do to make it run correctly.So this sample will show you how to make it happent and run Custom Timer Job to achive you tasks in simple way.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">//Create class derived from SPJonDefinition Class
 class ListTimerJob : SPJobDefinition
    {
         public ListTimerJob()

            : base()
        {

        }

        public ListTimerJob(string jobName, SPService service, SPServer server, SPJobLockType targetType)

            : base(jobName, service, server, targetType)
        {

        }

        public ListTimerJob(string jobName, SPWebApplication webApplication)

            : base(jobName, webApplication, null, SPJobLockType.ContentDatabase)
        {

            this.Title = &quot;List Timer Job&quot;;

        }

        public override void Execute(Guid contentDbId)
        {

            // get a reference to the current site collection's content database

            SPWebApplication webApplication = this.Parent as SPWebApplication;

            SPContentDatabase contentDb = webApplication.ContentDatabases[contentDbId];

            // get a reference to the &quot;ListTimerJob&quot; list in the RootWeb of the first site collection in the content database

            SPList Listjob = contentDb.Sites[0].RootWeb.Lists[&quot;ListTimerJob&quot;];

            // create a new list Item, set the Title to the current day/time, and update the item

            SPListItem newList = Listjob.Items.Add();

            newList[&quot;Title&quot;] = DateTime.Now.ToString();

            newList.Update();

        }
}
//Add Event receiver at Feature Level 
[Guid(&quot;9a724fdb-e423-4232-9626-0cffc53fb74b&quot;)]
public class Feature1EventReceiver : SPFeatureReceiver
    {
        const string List_JOB_NAME = &quot;ListLogger&quot;;
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;

            // make sure the job isn't already registered

            foreach (SPJobDefinition job in site.WebApplication.JobDefinitions)
            {

                if (job.Name == List_JOB_NAME)

                    job.Delete();

            }

            // install the job

            ListTimerJob listLoggerJob = new ListTimerJob(List_JOB_NAME, site.WebApplication);

            SPMinuteSchedule schedule = new SPMinuteSchedule();

            schedule.BeginSecond = 0;

            schedule.EndSecond = 59;

            schedule.Interval = 5;

            listLoggerJob.Schedule = schedule;

            listLoggerJob.Update();

        }

        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;

            // delete the job

            foreach (SPJobDefinition job in site.WebApplication.JobDefinitions)
            {

                if (job.Name == List_JOB_NAME)

                    job.Delete();

            }

} 
//That's all</pre>
<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__com">//Create&nbsp;class&nbsp;derived&nbsp;from&nbsp;SPJonDefinition&nbsp;Class</span>&nbsp;
&nbsp;<span class="cs__keyword">class</span>&nbsp;ListTimerJob&nbsp;:&nbsp;SPJobDefinition&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ListTimerJob()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<span class="cs__keyword">base</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ListTimerJob(<span class="cs__keyword">string</span>&nbsp;jobName,&nbsp;SPService&nbsp;service,&nbsp;SPServer&nbsp;server,&nbsp;SPJobLockType&nbsp;targetType)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<span class="cs__keyword">base</span>(jobName,&nbsp;service,&nbsp;server,&nbsp;targetType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ListTimerJob(<span class="cs__keyword">string</span>&nbsp;jobName,&nbsp;SPWebApplication&nbsp;webApplication)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<span class="cs__keyword">base</span>(jobName,&nbsp;webApplication,&nbsp;<span class="cs__keyword">null</span>,&nbsp;SPJobLockType.ContentDatabase)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Title&nbsp;=&nbsp;<span class="cs__string">&quot;List&nbsp;Timer&nbsp;Job&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Execute(Guid&nbsp;contentDbId)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;get&nbsp;a&nbsp;reference&nbsp;to&nbsp;the&nbsp;current&nbsp;site&nbsp;collection's&nbsp;content&nbsp;database</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPWebApplication&nbsp;webApplication&nbsp;=&nbsp;<span class="cs__keyword">this</span>.Parent&nbsp;<span class="cs__keyword">as</span>&nbsp;SPWebApplication;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPContentDatabase&nbsp;contentDb&nbsp;=&nbsp;webApplication.ContentDatabases[contentDbId];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;get&nbsp;a&nbsp;reference&nbsp;to&nbsp;the&nbsp;&quot;ListTimerJob&quot;&nbsp;list&nbsp;in&nbsp;the&nbsp;RootWeb&nbsp;of&nbsp;the&nbsp;first&nbsp;site&nbsp;collection&nbsp;in&nbsp;the&nbsp;content&nbsp;database</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPList&nbsp;Listjob&nbsp;=&nbsp;contentDb.Sites[<span class="cs__number">0</span>].RootWeb.Lists[<span class="cs__string">&quot;ListTimerJob&quot;</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;create&nbsp;a&nbsp;new&nbsp;list&nbsp;Item,&nbsp;set&nbsp;the&nbsp;Title&nbsp;to&nbsp;the&nbsp;current&nbsp;day/time,&nbsp;and&nbsp;update&nbsp;the&nbsp;item</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPListItem&nbsp;newList&nbsp;=&nbsp;Listjob.Items.Add();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newList[<span class="cs__string">&quot;Title&quot;</span>]&nbsp;=&nbsp;DateTime.Now.ToString();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newList.Update();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
<span class="cs__com">//Add&nbsp;Event&nbsp;receiver&nbsp;at&nbsp;Feature&nbsp;Level&nbsp;</span>&nbsp;
[Guid(<span class="cs__string">&quot;9a724fdb-e423-4232-9626-0cffc53fb74b&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Feature1EventReceiver&nbsp;:&nbsp;SPFeatureReceiver&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;List_JOB_NAME&nbsp;=&nbsp;<span class="cs__string">&quot;ListLogger&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Uncomment&nbsp;the&nbsp;method&nbsp;below&nbsp;to&nbsp;handle&nbsp;the&nbsp;event&nbsp;raised&nbsp;after&nbsp;a&nbsp;feature&nbsp;has&nbsp;been&nbsp;activated.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;FeatureActivated(SPFeatureReceiverProperties&nbsp;properties)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPSite&nbsp;site&nbsp;=&nbsp;properties.Feature.Parent&nbsp;<span class="cs__keyword">as</span>&nbsp;SPSite;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;make&nbsp;sure&nbsp;the&nbsp;job&nbsp;isn't&nbsp;already&nbsp;registered</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(SPJobDefinition&nbsp;job&nbsp;<span class="cs__keyword">in</span>&nbsp;site.WebApplication.JobDefinitions)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(job.Name&nbsp;==&nbsp;List_JOB_NAME)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;job.Delete();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;install&nbsp;the&nbsp;job</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListTimerJob&nbsp;listLoggerJob&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ListTimerJob(List_JOB_NAME,&nbsp;site.WebApplication);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPMinuteSchedule&nbsp;schedule&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SPMinuteSchedule();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;schedule.BeginSecond&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;schedule.EndSecond&nbsp;=&nbsp;<span class="cs__number">59</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;schedule.Interval&nbsp;=&nbsp;<span class="cs__number">5</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listLoggerJob.Schedule&nbsp;=&nbsp;schedule;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listLoggerJob.Update();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Uncomment&nbsp;the&nbsp;method&nbsp;below&nbsp;to&nbsp;handle&nbsp;the&nbsp;event&nbsp;raised&nbsp;before&nbsp;a&nbsp;feature&nbsp;is&nbsp;deactivated.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;FeatureDeactivating(SPFeatureReceiverProperties&nbsp;properties)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPSite&nbsp;site&nbsp;=&nbsp;properties.Feature.Parent&nbsp;<span class="cs__keyword">as</span>&nbsp;SPSite;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;delete&nbsp;the&nbsp;job</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(SPJobDefinition&nbsp;job&nbsp;<span class="cs__keyword">in</span>&nbsp;site.WebApplication.JobDefinitions)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(job.Name&nbsp;==&nbsp;List_JOB_NAME)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;job.Delete();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}&nbsp;&nbsp;
<span class="cs__com">//That's&nbsp;all</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>SharePoint Project (CustomTimerJob) - contain List Instance so timer job can write on it.Also it contain class that derived from SPJobDefiniation as will as Event
</em>Receiver <em>Feature that will rise when you activate the feature<br>
</em></li></ul>
<h1>More Information</h1>
<p class="post-title"><a href="http://dotnetfinder.wordpress.com/2010/07/24/creatingcustomsharepointtimerjob2010/">Creating Custom Timer Job in SharePoint&nbsp;2010</a></p>
