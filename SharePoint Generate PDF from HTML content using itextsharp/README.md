# SharePoint: Generate PDF from HTML content using itextsharp
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- SharePoint
- SharePoint Server 2013
- SharePoint  2013
## Topics
- C#
- SharePoint
- Visual Web Parts
- exporting data
## Updated
- 03/19/2014
## Description

<p><em>Exporting to PDF of any document or page is one of the most frequently requested feature in web application. I will show you the simplest solution through which you can export any div content or litral value to PDF using iTextSharp.&nbsp;</em></p>
<h1><span>Building the Sample</span></h1>
<p>I have referenced the iTextSharp dll after placing it in solution folder and also configured it to GAC using solution package</p>
<p><img id="110868" src="110868-itextsharp%20folder.jpg" alt=""></p>
<p><img id="110869" src="110869-itextsharp%20to%20gac.jpg" alt=""></p>
<p>&nbsp;</p>
<p><em>In this sample, thw content of asp.net litral control have been exported as pdf. You can add the image properly using iTextSharp API but the trick I applying when passing html content is to set an img control having absolute url image support. This includes
 the image the passing the html to HTMLWorker.&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">ltExporttoPDF.Text&nbsp;=&nbsp;@&quot;&lt;div&nbsp;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This&nbsp;the&nbsp;the&nbsp;content&nbsp;which&nbsp;will&nbsp;be&nbsp;exported&nbsp;to&nbsp;pdf&nbsp;and&nbsp;it&nbsp;contains&nbsp;an&nbsp;image&nbsp;too&lt;br&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;img&nbsp;&nbsp;src=<span class="cs__string">'&quot;&#43;&nbsp;SPContext.Current.Web.Url&nbsp;&#43;@&quot;/_layouts/15/images/SPPDFGenerator/testImage.jpg'</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&quot;;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;PDF export code</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;Document&nbsp;pdfDoc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Document(PageSize.A4,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">10</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfWriter.GetInstance(pdfDoc,&nbsp;System.Web.HttpContext.Current.Response.OutputStream);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Open&nbsp;PDF&nbsp;Document&nbsp;to&nbsp;write&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfDoc.Open();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Assign&nbsp;Html&nbsp;content&nbsp;in&nbsp;a&nbsp;string&nbsp;to&nbsp;write&nbsp;in&nbsp;PDF</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;strContent&nbsp;=&nbsp;ltExporttoPDF.Text;&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Read&nbsp;string&nbsp;contents&nbsp;using&nbsp;stream&nbsp;reader&nbsp;and&nbsp;convert&nbsp;html&nbsp;to&nbsp;parsed&nbsp;conent</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;parsedHtmlElements&nbsp;=&nbsp;HTMLWorker.ParseToList(<span class="cs__keyword">new</span>&nbsp;StringReader(strContent),&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;each&nbsp;array&nbsp;values&nbsp;from&nbsp;parsed&nbsp;elements&nbsp;and&nbsp;add&nbsp;to&nbsp;the&nbsp;PDF&nbsp;document</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;htmlElement&nbsp;<span class="cs__keyword">in</span>&nbsp;parsedHtmlElements)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfDoc.Add(htmlElement&nbsp;<span class="cs__keyword">as</span>&nbsp;IElement);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Close&nbsp;your&nbsp;PDF</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfDoc.Close();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.ContentType&nbsp;=&nbsp;<span class="cs__string">&quot;application/pdf&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Set&nbsp;default&nbsp;file&nbsp;Name&nbsp;as&nbsp;current&nbsp;datetime</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.AddHeader(<span class="cs__string">&quot;content-disposition&quot;</span>,&nbsp;<span class="cs__string">&quot;attachment;&nbsp;filename=Test.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Web.HttpContext.Current.Response.Write(pdfDoc);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Flush();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.End();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(ex.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;I have used visual studio 2013 ultimate to create the attached sample. In the solution the itextsharp assembly and image has been included. A visual webpart has been created to show the feature of exporting html content to
 PDF.&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><strong>iTextSharp Overview</strong></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">iText is a PDF library that allows you to CREATE, ADAPT, INSPECT and MAINTAIN documents in the Portable Document Format (PDF):</div>
<div class="endscriptcode"><span>- Generate documents and reports based on data from an XML file or a database</span><br>
<span>- Create maps and books, exploiting numerous interactive features available in PDF</span><br>
<span>- Add bookmarks, page numbers, watermarks, and other features to existing PDF documents</span><br>
<span>- Split or concatenate pages from existing PDF files</span><br>
<span>- Fill out interactive forms</span><br>
<span>- Serve dynamically generated or manipulated PDF documents to a web browser</span><br>
<br>
<span>iText is used by Java, .NET, Android and GAE developers to enhance their applications with PDF functionality.&nbsp;</span><br>
<span>iTextSharp is the .NET port.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span><em>You can download the iTextSharp dll from&nbsp;<a title="iTextSharp, a .NET PDF library" href="http://sourceforge.net/projects/itextsharp/">here</a>.</em><br>
</span></div>
<div class="endscriptcode"></div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
