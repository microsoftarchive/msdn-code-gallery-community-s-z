# Weather Add-In for SharePoint
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Javascript
- Sharepoint Online
- apps for SharePoint
- SharePoint Add-ins
## Topics
- Javascript
- Sharepoint Online
- apps for SharePoint
## Updated
- 08/01/2017
## Description

<h1>Introduction</h1>
<p><em>SharePoint weather Add-In can be added on the SharePoint home page (dashboard), &nbsp;this add-in automatically retrieve the current location. And based on the location it will retrieve the Temperature, humidity and wind speed etc...&nbsp;you can see
 the step by step instructions to develop this SharePoint Add-In.</em></p>
<p><img id="176410" src="176410-weather%20addin.jpg" alt="" width="611" height="519"></p>
<p><strong>Solution Compatibility</strong></p>
<p>This sample is tested with SharePoint Online</p>
<p>This sample also compatible with SharePoint 2013 and SharePoint 2016</p>
<p><br>
<strong>To Modify and deploy this solution</strong></p>
<p>Open visual studio 2015</p>
<p>On the file menu select Open -&gt; Project (Ctrl &#43; Shift &#43; o)</p>
<p>In the Open Project window navigate the directory and select solution file (.sln)</p>
<p>Open solution explorer windows and select project solution and click (F4) to open project properties change the site URL property on the property window&nbsp;</p>
<p>Edit the code if required and click play button or (F5) in visual studio&nbsp;</p>
<p>&nbsp;</p>
<p><strong>To add new resource file (.js or .css or Images) into project</strong></p>
<p>Select a folder from solution explorer based on your file type (Images or Scripts or Content for CSS)</p>
<p>Right click and select &ldquo;Open Folder in File Explorer&rdquo; option</p>
<p>Now paste your files into the folder again in the solution explorer window at the top, click &ldquo;Show All Files&rdquo; icon</p>
<p>Now you can find the file without active icon, right click and select &ldquo;Include in Project&rdquo; Option</p>
<h1><em style="font-size:10px">&nbsp;I have used the Local-weather <a rel="noopener" href="https://github.com/joshuadelosreyes/local-weather/" target="_blank">
GitHub&nbsp;</a>project to implement this Add-In, In the project, you can find the script in the ASPX file.</em></h1>
<p>*****************************************************************************************************</p>
<p>Hope you find this sample helpful, check out my other samples too.</p>
<p>Give five stars if you wish to appreciate my work.</p>
<p>Facebook page URL:&nbsp;<a title="https://www.facebook.com/sptechnet2016/" href="https://www.facebook.com/sptechnet2016/" target="_blank">https://www.facebook.com/sptechnet2016/</a></p>
<p>Blog URL:&nbsp;<a title="ravichandran.blog" href="https://code.msdn.microsoft.com/Text-to-speech-Add-In-for-af5abf7f/ravichandran.blog" target="_blank">https://ravichandran.blog/</a></p>
<p>*****************************************************************************************************</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span><span class="hidden">html</span>


<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;get&nbsp;location&nbsp;from&nbsp;user's&nbsp;IP&nbsp;address</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.getJSON(<span class="js__string">'https://ipinfo.io'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(info)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;locString&nbsp;=&nbsp;info.loc.split(<span class="js__string">',&nbsp;'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;latitude&nbsp;=&nbsp;<span class="js__function">parseFloat</span>(locString[<span class="js__num">0</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;longitude&nbsp;=&nbsp;<span class="js__function">parseFloat</span>(locString[<span class="js__num">1</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#location'</span>).html(<span class="js__string">'Location:&nbsp;'</span>&nbsp;&#43;&nbsp;info.city&nbsp;&#43;&nbsp;<span class="js__string">',&nbsp;'</span>&nbsp;&#43;&nbsp;info.region&nbsp;&#43;&nbsp;<span class="js__string">',&nbsp;'</span>&nbsp;&#43;&nbsp;info.country)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;get&nbsp;weather&nbsp;using&nbsp;OpenWeatherMap&nbsp;API</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.getJSON(<span class="js__string">'https://cors.5apps.com/?uri=http://api.openweathermap.org/data/2.5/weather?lat='</span>&nbsp;&#43;&nbsp;latitude&nbsp;&#43;&nbsp;<span class="js__string">'&amp;lon='</span>&nbsp;&#43;&nbsp;longitude&nbsp;&#43;&nbsp;<span class="js__string">'&amp;units=metric&amp;APPID=c3e00c8860695fd6096fe32896042eda'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;windSpeedkmh&nbsp;=&nbsp;<span class="js__object">Math</span>.round(data.wind.speed&nbsp;*&nbsp;<span class="js__num">3.6</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;Celsius&nbsp;=&nbsp;<span class="js__object">Math</span>.round(data.main.temp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;iconId&nbsp;=&nbsp;data.weather[<span class="js__num">0</span>].icon;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;weatherURL&nbsp;=&nbsp;<span class="js__string">&quot;http://openweathermap.org/img/w/&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iconId&nbsp;&#43;&nbsp;<span class="js__string">&quot;.png&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;iconImg&nbsp;=&nbsp;<span class="js__string">&quot;&lt;img&nbsp;src='&quot;</span>&nbsp;&#43;&nbsp;weatherURL&nbsp;&#43;&nbsp;<span class="js__string">&quot;'&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#sky-image'</span>).html(iconImg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#weather-id'</span>).html(<span class="js__string">'Skies:&nbsp;'</span>&nbsp;&#43;&nbsp;data.weather[<span class="js__num">0</span>].description);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#temperature'</span>).html(Celsius);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#toFahrenheit'</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#temperature'</span>).html(<span class="js__object">Math</span>.round((<span class="js__num">9</span>&nbsp;/&nbsp;<span class="js__num">5</span>)&nbsp;*&nbsp;Celsius&nbsp;&#43;&nbsp;<span class="js__num">32</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#wind-speed'</span>).html(<span class="js__object">Math</span>.round(windSpeedkmh&nbsp;*&nbsp;<span class="js__num">0.621</span>)&nbsp;&#43;&nbsp;<span class="js__string">'&nbsp;mph'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#toCelsius'</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#temperature'</span>).html(Celsius);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#wind-speed'</span>).html(windSpeedkmh&nbsp;&#43;&nbsp;<span class="js__string">'&nbsp;km/hr'</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#wind-speed'</span>).html(windSpeedkmh&nbsp;&#43;&nbsp;<span class="js__string">'&nbsp;km/h'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#humidity'</span>).html(<span class="js__string">'Humidity:&nbsp;'</span>&nbsp;&#43;&nbsp;data.main.humidity&nbsp;&#43;&nbsp;<span class="js__string">'&nbsp;%'</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;</pre>
</div>
</div>
</div>
