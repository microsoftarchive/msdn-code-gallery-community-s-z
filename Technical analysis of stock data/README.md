# Technical analysis of stock data
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Razor
- Silverlight 5
## Topics
- Graphics and 3D
- ViewModel pattern (MVVM)
- Charts
- Financial
## Updated
- 10/05/2012
## Description

<h1>Introduction</h1>
<p>The example solves a problem of how to display electronic trading data in a nice and readable manner using Silverlight and Asp.net. It shows that Silverlight can be a good alternative to Java Script for presentation of data in charts. Additionally it shows
 how to enhance Silverlight toolkit to create custom series (candlestick and stockbar).</p>
<h1><span>Building the Sample</span></h1>
<p>The sample requires VS2010, Silverlight 5 and Silverlight 5 SDK for VS2010 and Asp.net MVC3 plugin available from asp.net/mvc. For more advanced Silverlight users an evaluation version of Expression Blend 5 can be helpful. When VS 2010 fails to build, it
 may be because certain DLLs are blocked. You can right click on these reported DLLs in Windows explorer and unblock them using 'Unblock' button.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The sample shows how to:</p>
<ul>
<li>pass parameters from Asp.net to Silverlight, </li><li>localize a web application in Asp.net and Silverlight, </li><li>take advantage of JQuery to localize calendar control, </li><li>host a Silverlight application in Asp.net, </li><li>use MVVM pattern for Silverlight app, </li><li>use MVC pattern for Asp.net app, </li><li>modify Silverlight toolkit to create custom graphs, </li><li>display stocks data in Silverlight, </li><li>add interactivity to your chart applications, </li><li>calculate most popular technical analysis indexes. </li></ul>
<h1>More Information</h1>
<p>If you are more interested in how to display stocks data in Silverlight it encouraged to study Finance.Siliverlight.Graphs library and how they take advance of new StockBarSeries and CandlestickSeries classes which are enhancing our custom Silverlight charting
 toolkit library. We also show how to display dates in linear axes using a simple trick of custom converter.&nbsp;</p>
<p>For more information on this project, see <a href="http://silesiaresearch.com/Finance">
http://silesiaresearch.com/Finance</a></p>
<h1>Sample screenshot</h1>
<p>&nbsp;</p>
<p><em><em><img id="67496" src="http://i1.code.msdn.s-msft.com/silverlight/technical-analysis-of-8714a87f/image/file/67496/1/stocks.jpg" alt="" width="657" height="500">.</em></em></p>
