# Visual Studio Load Testing
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- load testing
## Topics
- Performance
## Updated
- 09/10/2014
## Description

<h1>Introduction</h1>
<p><em><span style="font-size:small">Using Visual Studio Ultimate 2013 and Visual Studio Online, you can perform cloud-based load testing. Check for performance issues on your web site when you expect an increased user load. No need to use resources and set
 up your own machines to create this load. You can use cloud-based load testing to provide virutal machines that generate the load of many users accesing your web site at the same time.<br>
</span></em></p>
<p><em><span style="font-size:small">To create a&nbsp;load test, you'll need to first create a Web Performance test. Web performance tests enable you to generate http requests and responses, test for correctness of the responses, and measure response times
 and throughput. You'll then use them in a load test to generate load against a web application and measure web application performance.
<br>
</span></em></p>
<p><em><span style="font-size:small">Load testing is traditionally an on-premise activity where you need to setup all the machines that would be used to generate the load. Now, however, you can do the same from cloud with Visual Studio Online.
</span></em></p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em><span style="font-size:small"><em>This is a simple project to get you started on Load Testing. This project is already preconfigured with default Load test settings (SampleLoadTest.loadtest) to allow you to run the load test from the cloud. It comes
 with a Web performance test (S<em>ample<span style="font-size:small"><em>WebTest.webtest) that
</em></span></em>you will need to update to point it to your App/website that you want to load test. After you've updated the URL you simply need to open up the SampleLoadTest.loadtest file and initiate the Load test run.</em>&nbsp;</span></em></p>
<p>&nbsp;</p>
<p><em><span style="font-size:small">Please note that cloud-based load testing&nbsp;is only available in Visual Studio Ultimate 2013 and you will need to connect to your Visual Studio online account to be able to run the load test from the cloud.<br>
</span></em></p>
<p>&nbsp;</p>
<p><em><span style="font-size:small">If you would like to change the load test parameters, you can follow the excellent guide provided here http://msdn.microsoft.com/en-us/library/ee923685(v=vs.110).aspx</span></em></p>
<p><em><span style="font-size:small"><br>
</span></em></p>
<p><span style="font-size:20px; font-weight:bold">Instructions</span></p>
<p><span style="font-size:20px"><em><span style="font-size:small"><em>1. Download the sample project &amp; l<span style="font-size:20px"><em><span style="font-size:small"><em>oad up the sample project in VS Ultimate 2013</em></span></em></span></em></span></em></span></p>
<p><span style="font-size:20px"><em><span style="font-size:small"><em>2. From the Solution Explorer, open SampleWebTest.webtest</em></span></em></span></p>
<p><span style="font-size:20px"><em><span style="font-size:small"><em>3. Select the URL listed in SampleWebTest.webtest file.
</em></span></em></span></p>
<p><span style="font-size:20px"><em><span style="font-size:small"><em>4. Go to the properties list and update the property labelled 'Url' to your app's/website's URL.</em></span></em></span></p>
<p><span style="font-size:20px"><em><span style="font-size:small"><em>5.From the team explorer, please connect to your Visual Studio Online account.<br>
</em></span></em></span></p>
<p><span style="font-size:20px"><em><span style="font-size:small"><em>6. Open the SampleLoadTest.loadtest file. From the 'Load Test' menu, select 'Run' -&gt; 'Selected Test'</em></span></em></span></p>
<p><span style="font-size:20px"><em><span style="font-size:small"><em>6. The Load test from the cloud will now start and show you graphs of how your application is performing during the load test.<br>
</em></span></em></span></p>
