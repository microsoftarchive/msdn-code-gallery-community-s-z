Introduction

Visual Studio Ultimate 2013 includes the Load Test feature that allows you to load test your app/website from the cloud. Load tests enable to you simulate many users hitting an application at the same time. The primary scenario for load testing is performance testing. How will the server respond to so many users? Will response times be unacceptably slow? Will error rates be acceptable? Another is scale testing.

To carry out a load test, you'll need to first create a Web Performance test. Web performance tests enable you to generate http requests and responses, test for correctness of the responses, and measure response times and throughput. You'll then use them in a load test to generate load against a web application and measure web application performance.

Load testing is traditionally a on-premise activity where you need to setup all the machines that would be used to generate the load from. Now however, you can do the same from cloud with Visual Studio Online.

Description

This is a simple project to get you started on Load Testing. This project is already preconfigured with default Load test settings (SampleLoadTest.loadtest) to allow you to run the load test from the cloud. It comes with a Web performance test (SampleWebTest.webtest) that you will need to update to point it to your App/website that you want to load test. After you've updated the URL you simply need to open up the LoadTest1.loadtest file and initiate the Load test run. 

Please note that Load Test feature is only available in Visual Studio Ultimate 2013 and you will need to connect to your Visual Studio online account to be able to perform the load test from the cloud.

If you would like to change the load test parameters, you can follow the excellent guide provided here http://msdn.microsoft.com/en-us/library/ee923685(v=vs.110).aspx

Instructions

1. Download the sample project & load up the sample project in VS Ultimate 2013

2. From the Solution Explorer, open SampleWebTest.webtest

3. Select the URL listed in SampleWebTest.webtest file. By default it points to www.bing.com

4. Go to the properties list and update the property labelled 'Url' to your app's/website's URL.

5.From the team explorer, please connect to your Visual Studio Online account.

6. Open the SampleLoadTest.loadtest file. From the 'Load Test' menu, select 'Run' -> 'Selected Test'

6. The Load test from the cloud will now start and show you graphs of how your application is performing during the load test.