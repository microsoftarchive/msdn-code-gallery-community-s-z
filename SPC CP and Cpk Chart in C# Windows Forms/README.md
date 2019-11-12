# SPC CP and Cpk Chart in C# Windows Forms
## Requires
- Visual Studio 2010
## License
- MIT
## Technologies
- C#
- WinForms
- SPC Chart
- winformUserControl
## Topics
- C#
- WinForms
- SPC Chart
## Updated
- 12/08/2015
## Description

<h1>Introduction</h1>
<p><img id="145741" src="145741-shanucpcpk.gif" alt="" width="550" height="391"></p>
<p>In this article we can see in detail about how to create a simple&nbsp;<strong>SPC (Statistical Process Control) Cp,CPk Chart.</strong></p>
<p>I have been working on several automation projects. Nowadays automobile industry&nbsp;is interested in automated measuring machines to ensure quality and to compete in the global industry. The main part of any automation software is to get the accurate result
 with Quality check, for this purpose we use the SPC (Statistical Process Control) to find the quality result.</p>
<ul>
</ul>
<p>Capability is to get the continues data from any part and compare the result with&nbsp;<strong>Cp, Cpk, Pp</strong>&nbsp;and&nbsp;<strong>Ppk</strong>. Where<strong>Cp</strong>&nbsp;,&nbsp;<strong>Cpk</strong>&nbsp;are Process Capability and&nbsp;&nbsp;<strong>Pp</strong>&nbsp;,&nbsp;<strong>Ppk&nbsp;</strong>are
 &nbsp;process performance. Let&rsquo;s consider one of my real time project, which is using in a Manufacturing Automation Measuring machines. Let&rsquo;s consider now Camshaft, Crankshaft or any part of Car Engine which need to be check with Quality control.
 The check part will be measured using some kind for Sensors for example in our project we use a digital sensor for measuring Camshaft and Crankshaft. Using the sensor we get continues data and the real time data will be check with SPC Cp,Cpk,Pp and Ppk charts.
 Display the final output to the operator and to the Quality control Engineer. Here is my real time project screen. All the Measurement data was been received from the Digital Sensor.</p>
<p>For the SPC chart in the market there is very few Third party chart controls are available and there is no any free chart for SPC Cp,Cpk,Pp and Ppk. I thought to&nbsp; create a simple SPC Cp,Cpk,Pp and Ppk chart .As a result after a long study about SPC
 and all its functionality I have created a simple SPC Cp,Cpk,Pp and Ppk chart. Hope you all will like it.</p>
<p>I have created the SPC chart as a User Control .You can just add my User Control dll to the project and use it.</p>
<p><strong>Shanu CpCpkChart User control Features:</strong></p>
<ul>
<li>Display chart with Sum, Mean and Range values. </li><li>Cp, Cpk, Pp, Ppk with alert result text warning with Red for NG and green for OK result.
</li><li>Mean (XBAR) and Range (RBAR) chart with Alert image with Red for NG and green for OK result.
</li><li>Automatic Calculate and display UCL(Upper Control Limit),LCL(Lower Control Limit) Value with both XBAR and RBAR value.
</li><li>Save Chart as Image (Note to save the Chart image double click the chart or right click and save as Image).
</li><li>Real Time data Gathering and display in the Chart. </li><li>User can add Chart Watermark text. </li></ul>
<p>First let&rsquo;s see what is Cp and Cpk</p>
<p><strong>Cp and Cpk - &gt;Process Capability</strong></p>
<ul>
<li><strong>Cp -</strong>- measures how well the data&nbsp;<strong>fits within</strong>&nbsp;the spec limits (USL, LSL)
</li><li><strong>Cpk -</strong>&nbsp;measures how centered the data is between the spec limits.
</li></ul>
<p><strong>Cp and Cpk formula</strong></p>
<p><img id="145742" src="145742-cp-cpk-formulas.jpg" alt="" width="159" height="155"></p>
<p>Cp=(USL-LSL/6SIGMA) -&gt; USL-LSL/6*RBAR/d2</p>
<p>Cpk=min(USL-XBAR/3Sigma,LSL-XBAR/3Sigma)</p>
<p>&nbsp;</p>
<p>&nbsp;<strong>Pp and Ppk -&gt; Process Performance</strong></p>
<ul>
<li><strong>Pp -</strong>&nbsp;measures how well the data&nbsp;<strong>fits within</strong>&nbsp;the spec limits (USL, LSL)
</li><li><strong>&nbsp;Ppk&nbsp;</strong><strong>-</strong>&nbsp;measures how centered the data is between the spec limits.
</li></ul>
<p>Pp,Ppk formula</p>
<p><img id="145743" src="145743-pp-ppk-formulas.jpg" alt="" width="157" height="159"></p>
<p>Pp=(USL-LSL/6SIGMA) -&gt; USL-LSL/6 STDEV</p>
<p>Ppk=min(USL-XBAR/3STDEV,LSL-XBAR/3STDEV)</p>
<p><em><strong>Reference websites</strong></em></p>
<div><em>
<div>&nbsp;</div>
<a href="http://www.isixsigma.com/tools-templates/capability-indices-process-capability/cp-cpk-pp-and-ppk-know-how-and-when-use-them/" target="_blank">http://www.isixsigma.com/tools-templates/capability-indices-process-capability/cp-cpk-pp-and-ppk-know-how-and-when-use-them/</a>&nbsp;<br>
</em></div>
<p><em></em></p>
<div><em><a href="http://www.qimacros.com/process-capability-analysis/cp-cpk-formula/" target="_blank">http://www.qimacros.com/process-capability-analysis/cp-cpk-formula/</a></em></div>
<h1><span>Building the Sample</span></h1>
<div>
<p>Now let&rsquo;s see how I have created a SPC Cp, Cpk chart. My main aim is to make a very simple SPC Chart which can be used by the end users.</p>
<p>I have created a SPC Cp,Cpk Chart &nbsp;as a User Control so that it can be used easily in all projects.</p>
<p>In this article i have attached zip file named as&nbsp;ShanuSPCCpCpkChart.zip. Which contain&rsquo;s my SPC chart user control Source and a Demo program.</p>
<p>1) &quot; ShanuCPCPKChart.dll&quot; You can use this user controls in your project and pass the data as DataTable to userCotnrol.</p>
<p>In the user control I will get the DataTable value and calculate the result to display as</p>
<ul>
<li>Sum </li><li>Mean </li><li>Range </li><li>Cp </li><li>Cpk </li><li>Pp </li><li>Ppk </li></ul>
<p>Bind all the result to the chart with smiley alert image. If the data is good then display the green smiley and if the data is NG(Not Good).Using the mean and Range values I will plot the result as Mean and Range chart with Alert Image.</p>
<p>User can pass the&nbsp;<strong>USL</strong>&nbsp;(upper Specification Limit),&nbsp;<strong>LSL&nbsp;</strong>(lower Specification Limit)&nbsp;<strong>Cpk</strong>&nbsp;Limit values to the<strong>ShanuCPCPKChart</strong>&nbsp;user control. Using the USL,LSL
 and Cpk value the result will be calculated and display the appropriate alert with red if NG for Cp, Cpk ,Pp, Ppk values .If the result is good then green text will be displayed to Cp, Cpk, Pp, Ppk in the chart.</p>
<p>2) &quot; ShanuSPCCpCPK_Demo &quot; Folder (This folder contains the Demo program which includes the ShanuCPCPKChart user control with Random Data sample).</p>
<p>Note : I have used DataTable as the data input for the User Control .From the windows form we need to pass the DataTable to User control to plot the Cp,Cpk ,Pp and Ppk result with SPC Range Chart.</p>
<p><strong>Save Chart&nbsp;</strong>User can save the Chart by double clicking on the chart control or by right click the chart and click save.</p>
<img id="145745" src="145745-31.jpg" alt="" width="550" height="340"></div>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<div><span><span>
<h1>SPC User Control program</h1>
</span></span>
<p>First we will start with the User Control .To Create a user control .</p>
<p>1. &nbsp;Create a new Windows Control Library project.</p>
<p>2. &nbsp;Set the Name of Project and Click Ok(here my user control name is ShanuCPCPKChart).</p>
<p>3. &nbsp;Add all the controls which is needed.</p>
<p>4. &nbsp;In code behind declare all the public variables and Public Method.In User control I have added one panel and one Picture Box Control.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;DataTable&nbsp;dt&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataTable();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Font&nbsp;f12&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Font(<span class="cs__string">&quot;arial&quot;</span>,&nbsp;<span class="cs__number">12</span>,&nbsp;FontStyle.Bold,&nbsp;GraphicsUnit.Pixel);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pen&nbsp;B1pen&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Pen(Color.Black,&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pen&nbsp;B2pen&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Pen(Color.Black,&nbsp;<span class="cs__number">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;XDoublkeBAR&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;RBAR&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;XBARUCL&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;XBARLCL&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;RANGEUCL&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;RANGELCL&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double[]&nbsp;intMeanArrayVals;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double[]&nbsp;intRangeArrayVals;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double[]&nbsp;intSTDEVArrayVals;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double[]&nbsp;intXBARArrayVals;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;First_chartDatarectHeight&nbsp;=&nbsp;<span class="cs__number">80</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Font&nbsp;f10&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Font(<span class="cs__string">&quot;arial&quot;</span>,&nbsp;<span class="cs__number">10</span>,&nbsp;FontStyle.Bold,&nbsp;GraphicsUnit.Pixel);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LinearGradientBrush&nbsp;a2&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;LinearGradientBrush(<span class="cs__keyword">new</span>&nbsp;RectangleF(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">100</span>,&nbsp;<span class="cs__number">19</span>),&nbsp;Color.DarkGreen,&nbsp;Color.Green,&nbsp;LinearGradientMode.Horizontal);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LinearGradientBrush&nbsp;a3&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;LinearGradientBrush(<span class="cs__keyword">new</span>&nbsp;RectangleF(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">100</span>,&nbsp;<span class="cs__number">19</span>),&nbsp;Color.DarkRed,&nbsp;Color.Red,&nbsp;LinearGradientMode.Horizontal);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LinearGradientBrush&nbsp;a1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;LinearGradientBrush(<span class="cs__keyword">new</span>&nbsp;RectangleF(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">100</span>,&nbsp;<span class="cs__number">19</span>),&nbsp;Color.Blue,&nbsp;Color.DarkBlue,&nbsp;LinearGradientMode.Horizontal);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Once declared the variable I have created a public function as Bindgrid.This function will be used from windows form to pass the DataTable.In this function I will check for the DataTable and if the DataTable is not null
 I refresh the PictureBox which will call the PictureBox paint method to Plot all new values for SPC Chart.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;<span class="js__operator">void</span>&nbsp;Bindgrid(DataTable&nbsp;dtnew)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(dtnew&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt&nbsp;=&nbsp;dtnew;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PicBox.Refresh();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>In PictureBox paint event I will check for the DataTable data .using the data I calculate and draw the result of all Sum,Mean,Range,Cp,Cpk,Pp and Ppk to the SPC Chart. Using this information I have created&nbsp;</span><strong>UCL&nbsp;</strong><span>and&nbsp;</span><strong>LCL&nbsp;</strong><span>by
 Standard formula .for details about UCL and LCL calculation kindly check the above links. After all the values are calculated I will draw the SPC chart in PictureBox using GDI&#43; and display the result to the end user.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;PicBox_Paint(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;PaintEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(dt.Rows.Count&nbsp;&lt;=&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;opacity&nbsp;=&nbsp;<span class="cs__number">68</span>;&nbsp;<span class="cs__com">//&nbsp;50%&nbsp;opaque&nbsp;(0&nbsp;=&nbsp;invisible,&nbsp;255&nbsp;=&nbsp;fully&nbsp;opaque)</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(ChartWaterMarkText,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Font(<span class="cs__string">&quot;Arial&quot;</span>,&nbsp;<span class="cs__number">72</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;SolidBrush(Color.FromArgb(opacity,&nbsp;Color.OrangeRed)),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">80</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PicBox.Height&nbsp;/&nbsp;<span class="cs__number">2</span>&nbsp;-&nbsp;<span class="cs__number">15</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;NoofTrials&nbsp;=&nbsp;dt.Rows.Count;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;NoofParts&nbsp;=&nbsp;dt.Columns.Count&nbsp;-&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;intMeanArrayVals&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Double[NoofParts];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;intRangeArrayVals&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Double[NoofParts];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;intSTDEVArrayVals&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Double[NoofParts];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;intXBARArrayVals&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Double[NoofParts];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(dt.Rows.Count&nbsp;&lt;=&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PicBox.Width&nbsp;=&nbsp;dt.Columns.Count&nbsp;*&nbsp;<span class="cs__number">50</span>&nbsp;&#43;&nbsp;<span class="cs__number">40</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;1)&nbsp;For&nbsp;the&nbsp;Chart&nbsp;Data&nbsp;Display&nbsp;---------</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawRectangle(Pens.Black,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">10</span>,&nbsp;PicBox.Width&nbsp;-&nbsp;<span class="cs__number">20</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">78</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;for&nbsp;the&nbsp;chart&nbsp;data&nbsp;Horizontal&nbsp;Line&nbsp;Display</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(B1pen,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">25</span>,&nbsp;PicBox.Width&nbsp;-&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">25</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(B1pen,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">45</span>,&nbsp;PicBox.Width&nbsp;-&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">45</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(B1pen,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">65</span>,&nbsp;PicBox.Width&nbsp;-&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">65</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(B1pen,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">85</span>,&nbsp;PicBox.Width&nbsp;-&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">85</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(B1pen,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">105</span>,&nbsp;PicBox.Width&nbsp;-&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">105</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(B1pen,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">125</span>,&nbsp;PicBox.Width&nbsp;-&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">125</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(B1pen,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">145</span>,&nbsp;PicBox.Width&nbsp;-&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">145</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;e.Graphics.DrawLine(B1pen,&nbsp;10,&nbsp;165,&nbsp;PicBox.Width&nbsp;-&nbsp;10,&nbsp;165);</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;for&nbsp;the&nbsp;chart&nbsp;data&nbsp;Vertical&nbsp;Line&nbsp;Display</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(B1pen,&nbsp;<span class="cs__number">60</span>,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">60</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">87</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(B1pen,&nbsp;<span class="cs__number">110</span>,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">110</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">87</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//-------------</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;DrawItemEventArgs&nbsp;String</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;SUM&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">14</span>,&nbsp;<span class="cs__number">10</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;MEAN&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">14</span>,&nbsp;<span class="cs__number">30</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;Range&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">14</span>,&nbsp;<span class="cs__number">50</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;Cp&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">14</span>,&nbsp;<span class="cs__number">70</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;Cpk&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">14</span>,&nbsp;<span class="cs__number">90</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;Pp&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">14</span>,&nbsp;<span class="cs__number">110</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;Ppk&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">14</span>,&nbsp;<span class="cs__number">130</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;load&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Outer&nbsp;Loop&nbsp;for&nbsp;Columns&nbsp;count</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;xLineposition&nbsp;=&nbsp;<span class="cs__number">110</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;xStringDrawposition&nbsp;=&nbsp;<span class="cs__number">14</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double[]&nbsp;locStdevarr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;iCol&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;iCol&nbsp;&lt;=&nbsp;dt.Columns.Count&nbsp;-&nbsp;<span class="cs__number">1</span>;&nbsp;iCol&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//inner&nbsp;Loop&nbsp;for&nbsp;Rows&nbsp;count</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;Sumresult&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;Meanresult&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;Rangeresult&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;minRangeValue&nbsp;=&nbsp;<span class="cs__keyword">int</span>.MaxValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;maxRangeValue&nbsp;=&nbsp;<span class="cs__keyword">int</span>.MinValue;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;locStdevarr&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Double[NoofTrials];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;iRow&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;iRow&nbsp;&lt;&nbsp;dt.Rows.Count;&nbsp;iRow&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sumresult&nbsp;=&nbsp;Sumresult&nbsp;&#43;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Convert.ToDouble.aspx" target="_blank" title="Auto generated link to System.Convert.ToDouble">System.Convert.ToDouble</a>(dt.Rows[iRow][iCol].ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;accountLevel&nbsp;=&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Convert.ToDouble.aspx" target="_blank" title="Auto generated link to System.Convert.ToDouble">System.Convert.ToDouble</a>(dt.Rows[iRow][iCol].ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;minRangeValue&nbsp;=&nbsp;Math.Min(minRangeValue,&nbsp;accountLevel);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;maxRangeValue&nbsp;=&nbsp;Math.Max(maxRangeValue,&nbsp;accountLevel);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;locStdevarr[iRow]&nbsp;=&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Convert.ToDouble.aspx" target="_blank" title="Auto generated link to System.Convert.ToDouble">System.Convert.ToDouble</a>(dt.Rows[iRow][iCol].ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xLineposition&nbsp;=&nbsp;xLineposition&nbsp;&#43;&nbsp;<span class="cs__number">50</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xStringDrawposition&nbsp;=&nbsp;xStringDrawposition&nbsp;&#43;&nbsp;<span class="cs__number">50</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(B1pen,&nbsp;xLineposition,&nbsp;<span class="cs__number">10</span>,&nbsp;xLineposition,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">87</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Sum&nbsp;Data&nbsp;Display</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(Math.Round(Sumresult,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f10,&nbsp;a2,&nbsp;xStringDrawposition,&nbsp;<span class="cs__number">12</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//MEAN&nbsp;Data&nbsp;Display</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Meanresult&nbsp;=&nbsp;Sumresult&nbsp;/&nbsp;NoofTrials;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(Math.Round(Meanresult,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f10,&nbsp;a2,&nbsp;xStringDrawposition,&nbsp;<span class="cs__number">30</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//RANGE&nbsp;Data&nbsp;Display</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Rangeresult&nbsp;=&nbsp;maxRangeValue&nbsp;-&nbsp;minRangeValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(Math.Round(Rangeresult,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f10,&nbsp;a2,&nbsp;xStringDrawposition,&nbsp;<span class="cs__number">50</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//XDoubleBar&nbsp;used&nbsp;to&nbsp;display&nbsp;in&nbsp;chart</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XDoublkeBAR&nbsp;=&nbsp;XDoublkeBAR&nbsp;&#43;&nbsp;Meanresult;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//RBAR&nbsp;used&nbsp;to&nbsp;display&nbsp;in&nbsp;chart</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RBAR&nbsp;=&nbsp;RBAR&nbsp;&#43;&nbsp;Rangeresult;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;intMeanArrayVals[iCol&nbsp;-&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;Meanresult;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;intRangeArrayVals[iCol&nbsp;-&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;Rangeresult;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;intSTDEVArrayVals[iCol&nbsp;-&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;StandardDeviation(locStdevarr);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//End&nbsp;1&nbsp;)&nbsp;-------------------</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;2)&nbsp;--------------------------</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;XdoubleBAr/RBAR/UCL&nbsp;and&nbsp;LCL&nbsp;Calculation.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//XDoubleBar&nbsp;used&nbsp;to&nbsp;display&nbsp;in&nbsp;chart</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XDoublkeBAR&nbsp;=&nbsp;XDoublkeBAR&nbsp;/&nbsp;NoofParts;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//RBAR&nbsp;used&nbsp;to&nbsp;display&nbsp;in&nbsp;chart</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RBAR&nbsp;=&nbsp;RBAR&nbsp;/&nbsp;NoofParts;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//XBARUCL&nbsp;to&nbsp;display&nbsp;in&nbsp;chart</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XBARUCL&nbsp;=&nbsp;XDoublkeBAR&nbsp;&#43;&nbsp;UCLLCLTYPE(<span class="cs__string">&quot;A2&quot;</span>,&nbsp;RBAR,&nbsp;NoofTrials);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//XBARLCL&nbsp;to&nbsp;display&nbsp;in&nbsp;chart</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XBARLCL&nbsp;=&nbsp;XDoublkeBAR&nbsp;-&nbsp;UCLLCLTYPE(<span class="cs__string">&quot;A2&quot;</span>,&nbsp;RBAR,&nbsp;NoofTrials);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//XBARUCL&nbsp;to&nbsp;display&nbsp;in&nbsp;chart</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RANGEUCL&nbsp;=&nbsp;UCLLCLTYPE(<span class="cs__string">&quot;D4&quot;</span>,&nbsp;RBAR,&nbsp;NoofTrials);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//XBARLCL&nbsp;to&nbsp;display&nbsp;in&nbsp;chart</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RANGELCL&nbsp;=&nbsp;UCLLCLTYPE(<span class="cs__string">&quot;D3&quot;</span>,&nbsp;RBAR,&nbsp;NoofTrials);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//2.1)&nbsp;Status&nbsp;Display&nbsp;inside&nbsp;pic&nbsp;grid&nbsp;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;XCirclegDrawposition&nbsp;=&nbsp;<span class="cs__number">24</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;YCirclegDrawposition&nbsp;=&nbsp;<span class="cs__number">147</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xStringDrawposition&nbsp;=&nbsp;<span class="cs__number">14</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;intMeanArrayVals.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Color&nbsp;pointColor&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Color();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pointColor&nbsp;=&nbsp;Color.YellowGreen;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XCirclegDrawposition&nbsp;=&nbsp;XCirclegDrawposition&nbsp;&#43;&nbsp;<span class="cs__number">50</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Point&nbsp;p1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Point();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p1.X&nbsp;=&nbsp;XCirclegDrawposition;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p1.Y&nbsp;=&nbsp;YCirclegDrawposition;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(intMeanArrayVals[i]&nbsp;&lt;&nbsp;XBARLCL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pointColor&nbsp;=&nbsp;Color.Red;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(intMeanArrayVals[i]&nbsp;&gt;&nbsp;XBARUCL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pointColor&nbsp;=&nbsp;Color.Red;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pen&nbsp;pen&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Pen(Color.SeaGreen);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawPie(pen,&nbsp;p1.X,&nbsp;p1.Y,&nbsp;<span class="cs__number">18</span>,&nbsp;<span class="cs__number">18</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">360</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.FillPie(<span class="cs__keyword">new</span>&nbsp;SolidBrush(pointColor),&nbsp;p1.X,&nbsp;p1.Y,&nbsp;<span class="cs__number">18</span>,&nbsp;<span class="cs__number">18</span>,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">360</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pen&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Pen(Color.Black);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawPie(pen,&nbsp;p1.X&nbsp;&#43;&nbsp;<span class="cs__number">3</span>,&nbsp;p1.Y&nbsp;&#43;&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">360</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawPie(pen,&nbsp;p1.X&nbsp;&#43;&nbsp;<span class="cs__number">11</span>,&nbsp;p1.Y&nbsp;&#43;&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">360</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawPie(pen,&nbsp;p1.X&nbsp;&#43;&nbsp;<span class="cs__number">5</span>,&nbsp;p1.Y&nbsp;&#43;&nbsp;<span class="cs__number">12</span>,&nbsp;<span class="cs__number">8</span>,&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">180</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;1)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Cp&nbsp;Calculation&nbsp;(((((((((((((((((((((((((((</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Cp=(USL-LSL/6SIGMA)&nbsp;-&gt;&nbsp;USL-LSL/6*RBAR/d2</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;d2&nbsp;=&nbsp;d2Return(NoofTrials);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;USLResult&nbsp;=&nbsp;USLs&nbsp;-&nbsp;LSLs;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;RBARS&nbsp;=&nbsp;intRangeArrayVals[i]&nbsp;/&nbsp;NoofTrials;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;Sigma&nbsp;=&nbsp;RBARS&nbsp;/&nbsp;d2;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;CpResult&nbsp;=&nbsp;USLResult&nbsp;/&nbsp;<span class="cs__number">6</span>&nbsp;*&nbsp;Sigma;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xStringDrawposition&nbsp;=&nbsp;xStringDrawposition&nbsp;&#43;&nbsp;<span class="cs__number">50</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(Math.Round(CpResult,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f10,&nbsp;a2,&nbsp;xStringDrawposition,&nbsp;<span class="cs__number">70</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//End&nbsp;Cp&nbsp;Calculation&nbsp;&nbsp;))))))))))))))</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;2)</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Cpk&nbsp;Calculation&nbsp;\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Cpk=min(USL-XBAR/3Sigma,LSL-XBAR/3Sigma)</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;CpU&nbsp;=&nbsp;USLs&nbsp;-&nbsp;intMeanArrayVals[i]&nbsp;/&nbsp;<span class="cs__number">3</span>&nbsp;*&nbsp;Sigma;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;CpL&nbsp;=&nbsp;intMeanArrayVals[i]&nbsp;-&nbsp;LSLs&nbsp;/&nbsp;<span class="cs__number">3</span>&nbsp;*&nbsp;Sigma;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;CpkResult&nbsp;=&nbsp;Math.Min(CpU,&nbsp;CpL);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(CpkResult&nbsp;&lt;&nbsp;CpkPpKAcceptanceValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(Math.Round(CpkResult,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f10,&nbsp;a3,&nbsp;xStringDrawposition,&nbsp;<span class="cs__number">90</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(Math.Round(CpkResult,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f10,&nbsp;a2,&nbsp;xStringDrawposition,&nbsp;<span class="cs__number">90</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//End&nbsp;Cpk&nbsp;Calculation&nbsp;&nbsp;\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;3)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Pp&nbsp;Calculation&nbsp;{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Pp=(USL-LSL/6SIGMA)&nbsp;-&gt;&nbsp;USL-LSL/6&nbsp;STDEV</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;PpResult&nbsp;=&nbsp;USLResult&nbsp;/&nbsp;<span class="cs__number">6</span>&nbsp;*&nbsp;intSTDEVArrayVals[i];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(Math.Round(PpResult,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f10,&nbsp;a2,&nbsp;xStringDrawposition,&nbsp;<span class="cs__number">110</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//End&nbsp;Pp&nbsp;Calculation&nbsp;&nbsp;}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;4)</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//PpK&nbsp;Calculation&nbsp;``````````````````````````````````````````````````````</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//PpK=min(USL-XBAR/3STDEV,LSL-XBAR/3STDEVa)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;PpU&nbsp;=&nbsp;USLs&nbsp;-&nbsp;intMeanArrayVals[i]&nbsp;/&nbsp;<span class="cs__number">3</span>&nbsp;*&nbsp;intSTDEVArrayVals[i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;PpL&nbsp;=&nbsp;intMeanArrayVals[i]&nbsp;-&nbsp;LSLs&nbsp;/&nbsp;<span class="cs__number">3</span>&nbsp;*&nbsp;intSTDEVArrayVals[i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;PpkResult&nbsp;=&nbsp;Math.Min(PpU,&nbsp;PpL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(PpkResult&nbsp;&lt;&nbsp;CpkPpKAcceptanceValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(Math.Round(PpkResult,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f10,&nbsp;a3,&nbsp;xStringDrawposition,&nbsp;<span class="cs__number">130</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(Math.Round(PpkResult,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f10,&nbsp;a2,&nbsp;xStringDrawposition,&nbsp;<span class="cs__number">130</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;end&nbsp;of&nbsp;Ppk&nbsp;`````````````````````````````````````````````````````````````</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//end&nbsp;of&nbsp;2.1)&nbsp;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;&#43;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//---------------------------------</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//3)&nbsp;Average&nbsp;chart&nbsp;Display&nbsp;---------------</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;e.Graphics.DrawRectangle(Pens.Black,&nbsp;10,&nbsp;10,&nbsp;picSpcChart.Width&nbsp;-&nbsp;20,&nbsp;First_chartDatarectHeight);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;chartAvarageDatarectHeight&nbsp;=&nbsp;<span class="cs__number">18</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawRectangle(Pens.Black,&nbsp;<span class="cs__number">10</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">96</span>,&nbsp;PicBox.Width&nbsp;-&nbsp;<span class="cs__number">20</span>,&nbsp;chartAvarageDatarectHeight);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(B2pen,&nbsp;<span class="cs__number">476</span>,&nbsp;<span class="cs__number">194</span>,&nbsp;<span class="cs__number">480</span>,&nbsp;<span class="cs__number">176</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;MEAN&nbsp;CHART&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">14</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;XBarS:&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">160</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;e.Graphics.DrawString(Math.Round(XDoublkeBAR,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f12,&nbsp;a2,&nbsp;<span class="cs__number">202</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;UCL:&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">300</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;e.Graphics.DrawString(Math.Round(XBARUCL,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f12,&nbsp;a2,&nbsp;<span class="cs__number">330</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;LCL:&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">400</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;e.Graphics.DrawString(Math.Round(XBARLCL,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f12,&nbsp;a2,&nbsp;<span class="cs__number">430</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;RANGE&nbsp;CHART&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">490</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;RBar&nbsp;:&nbsp;&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">600</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;&nbsp;e.Graphics.DrawString(Math.Round(RBAR,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f12,&nbsp;a2,&nbsp;<span class="cs__number">638</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;UCL&nbsp;:&nbsp;&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">700</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
e.Graphics.DrawString(Math.Round(RANGEUCL,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f12,&nbsp;a2,&nbsp;<span class="cs__number">734</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;LCL&nbsp;:&nbsp;&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">800</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
e.Graphics.DrawString(Math.Round(RANGELCL,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f12,&nbsp;a2,&nbsp;<span class="cs__number">834</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;vertical&nbsp;Line</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawLine(B2pen,&nbsp;<span class="cs__number">860</span>,&nbsp;<span class="cs__number">194</span>,&nbsp;<span class="cs__number">866</span>,&nbsp;<span class="cs__number">176</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;USL&nbsp;:&nbsp;&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">880</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;&nbsp;e.Graphics.DrawString(Math.Round(USLs,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f12,&nbsp;a2,&nbsp;<span class="cs__number">910</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__string">&quot;LSL&nbsp;:&nbsp;&quot;</span>,&nbsp;f12,&nbsp;a1,&nbsp;<span class="cs__number">960</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;&nbsp;e.Graphics.DrawString(Math.Round(LSLs,&nbsp;<span class="cs__number">3</span>).ToString(),&nbsp;f12,&nbsp;a2,&nbsp;<span class="cs__number">990</span>,&nbsp;First_chartDatarectHeight&nbsp;&#43;&nbsp;<span class="cs__number">98</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Mean&nbsp;Line&nbsp;Chart</span>&nbsp;
&nbsp;&nbsp;&nbsp;DrawLineChart(e.Graphics,&nbsp;intMeanArrayVals,&nbsp;XBARUCL,&nbsp;XBARLCL,&nbsp;PicBox.Width&nbsp;-&nbsp;<span class="cs__number">70</span>,&nbsp;<span class="cs__number">154</span>,&nbsp;<span class="cs__number">60</span>,&nbsp;<span class="cs__number">170</span>,&nbsp;<span class="cs__string">&quot;MEAN&quot;</span>,&nbsp;XDoublkeBAR);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DrawLineChart(e.Graphics,&nbsp;intRangeArrayVals,&nbsp;RANGEUCL,&nbsp;RANGELCL,&nbsp;PicBox.Width&nbsp;-&nbsp;<span class="cs__number">70</span>,&nbsp;<span class="cs__number">154</span>,&nbsp;<span class="cs__number">60</span>,&nbsp;<span class="cs__number">340</span>,&nbsp;<span class="cs__string">&quot;RANGE&quot;</span>,&nbsp;RBAR);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//End&nbsp;3)---------------------</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:2em">Demo Program</span></div>
</div>
<div><span>We have used Visual Studio 2010.&nbsp;</span>Create a Windows application and add and test our &quot;ShanuCPCPKChart&quot; User Control.</div>
<div>
<ol>
<li>Create a new Windows project. </li><li>Open your form and then from<strong>&nbsp;Toolbox &gt; right-click &gt; choose items &gt;&nbsp;</strong>browse to select your user control DLL and add.
</li><li>Drag the User Control to your Windows Forms form. </li><li>Call the &quot;Bindgrid&quot; method of the user control and pass the DataTable to the User Control and check the result.&nbsp;
</li></ol>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">/Global&nbsp;variable&nbsp;Declaration&nbsp;&nbsp;&nbsp;
#region&nbsp;Local&nbsp;Vairables&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataTable&nbsp;dt&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataTable();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;static&nbsp;readonly&nbsp;Random&nbsp;random&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Random();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;gridMinvalue&nbsp;=&nbsp;<span class="js__num">1.2</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;gridMaxvalue&nbsp;=&nbsp;<span class="js__num">2.4</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;totalColumntoDisplay&nbsp;=&nbsp;<span class="js__num">20</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;USLs&nbsp;=&nbsp;<span class="js__num">2.27</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;LSLs&nbsp;=&nbsp;<span class="js__num">1.26</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Double&nbsp;CpkPpkAcceptanceValue&nbsp;=&nbsp;<span class="js__num">1.33</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Form Load event</strong>
<div align="left">In the Form Load event call the<strong>&nbsp;loadGridColumn()</strong>&nbsp;method. In this function I add the columns for the Data Table. I have used 20 columns for adding 20 sample data with 5 trials.</div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">/Create&nbsp;Datatable&nbsp;&nbsp;Colums.&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;loadGridColums()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(<span class="cs__string">&quot;No&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;jval&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;jval&nbsp;&lt;=&nbsp;totalColumntoDisplay;&nbsp;jval&#43;&#43;)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(jval.ToString());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Next in the Form Load event I call the&nbsp;</span><strong>loadgrid</strong><span>() method. In this method I generate sample random numbers for 20 columns to plot our chart.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;loadgrid()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Clear();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Clear();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;i&nbsp;&lt;=&nbsp;<span class="cs__number">5</span>;&nbsp;i&#43;&#43;)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
DataRow&nbsp;row&nbsp;=&nbsp;dt.NewRow();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row[<span class="cs__string">&quot;NO&quot;</span>]&nbsp;=&nbsp;i.ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;jval&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;jval&nbsp;&lt;=&nbsp;totalColumntoDisplay;&nbsp;jval&#43;&#43;)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row[jval.ToString()]&nbsp;=&nbsp;RandomNumberBetween(gridMinvalue,&nbsp;gridMaxvalue);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(row);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataGridView1.AutoResizeColumns();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataGridView1.DataSource&nbsp;=&nbsp;dt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataGridView1.AutoResizeColumns();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Next in the form load I have passed the USL, LSL&nbsp;and Cpk values and DataTable to &ldquo;</span><strong>shanuCPCPKChart&rdquo;&nbsp;</strong><span>User Control to generate XBAR and Range Chart with Cp, Cpk, Pp and
 Ppk results.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Form1_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;loadGridColums();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;loadgrid();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;USLs&nbsp;=&nbsp;Convert.ToDouble(txtusl.Text);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LSLs&nbsp;=&nbsp;Convert.ToDouble(txtLSL.Text);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CpkPpkAcceptanceValue&nbsp;=&nbsp;Convert.ToDouble(txtData.Text);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuCPCPKChart.USL&nbsp;=&nbsp;USLs;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuCPCPKChart.LSL&nbsp;=&nbsp;LSLs;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuCPCPKChart.CpkPpKAcceptanceValue&nbsp;=&nbsp;CpkPpkAcceptanceValue;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuCPCPKChart.Bindgrid(dt);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>To display the real-time data chart result ,here I have used the timer and can bind the data using random data and pass all the results to the User Control to refresh and display the result.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;timer1_Tick(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;loadgrid();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;USLs&nbsp;=&nbsp;Convert.ToDouble(txtusl.Text);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LSLs&nbsp;=&nbsp;Convert.ToDouble(txtLSL.Text);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CpkPpkAcceptanceValue&nbsp;=&nbsp;Convert.ToDouble(txtData.Text);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuCPCPKChart.USL&nbsp;=&nbsp;USLs;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuCPCPKChart.LSL&nbsp;=&nbsp;LSLs;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuCPCPKChart.CpkPpKAcceptanceValue&nbsp;=&nbsp;CpkPpkAcceptanceValue;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuCPCPKChart.Bindgrid(dt);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span>ShanuCPCPKChart.zip</span> </li></ul>
<h1>More Information</h1>
<p><em>You can find both the demo project and Chart Source program with attached Zip File.</em></p>
