# Using Google Time Zone API to Convert DateTime between Geo Locations in C#
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- Google API
## Topics
- Google Time Zone API
## Updated
- 09/08/2015
## Description

<div align="justify">It is extremely important that any application where the users are from different geographic locations handle date and time in a meaningful way. For an example, let&rsquo;s say the application has users ranging from United States to Australia
 and right now, a user from Sydney, Australia creates a record in the database. So through out the application if we have only considered Sydney time, the created time for that particular record will be in Sydney time. If a user from Seattle, United States
 sees that record created time, it definitely is confusing because that time has not yet arrived to Seattle.
<br>
<br>
</div>
<div align="justify">So in a world wide application, it is important to consider users&rsquo; time zones when maintaining date and times. There are variety of SDK for this such as
<a href="http://nodatime.org/" target="_blank">Noda Time</a>. But in this post, let&rsquo;s see how we can consider not the time zones, but the geographic locations when converting the date time. For that we can use
<strong>Google Time Zone API</strong> to convert date and time between geographic locations considering locations&rsquo; geographic coordinates.<br>
<br>
</div>
<div align="justify">Please note that to use Google Time Zone API, you will need to have a API key which can be acquired for free. Free API will have some request limitations, but it is more than enough to evaluate the functionality. In here, I am not going
 to explain how you can obtain the API key, please read <a href="https://developers.google.com/maps/documentation/timezone/#api_key" target="_blank">
this</a> post to know how you can do it.<br>
<br>
</div>
<div align="justify">After getting the API key, next is to use it. Google Time Zone API expects following parameters.</div>
<ul>
<li>
<div align="justify">Timestamp</div>
<ul>
<li>
<div align="justify">Timestamp specifies the given time as seconds since midnight, January 1, 1970 UTC. The Time Zone API uses the timestamp to determine whether or not Daylight Savings should be applied.</div>
</li></ul>
</li><li>
<div align="justify">Location's geographic coordinates</div>
</li><li>
<div align="justify">API Key</div>
</li><li>
<div align="justify">Language (optional)</div>
</li></ul>
<div align="justify"><br>
If the request to Google TimeZone API gets succeeded, it will return a result containing details such as the offset for daylight-savings time in seconds (<strong>dstOffset</strong>), the offset from UTC in seconds for the given location(<strong>rawOffset</strong>),&nbsp;
 time zone name etc. The converted time of a given location is the sum of the <strong>
timestamp</strong> parameter,&nbsp; <strong>dstOffset</strong> and <strong>rawOffset</strong>. Since it is again a Timestamp, we need to convert it back to DateTime value.<br>
<br>
</div>
<div align="justify">I am creating a console application and I am creating a class named &ldquo;GoogleTimeZone&rdquo;. There I have couple of local variables.</div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:1000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">public</span> <span style="color:blue">class</span> GoogleTimeZone</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">private</span> <span style="color:blue">string</span> apiKey;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">private</span> GeoLocation location;</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">private</span> <span style="color:blue">string</span> previousAddress = <span style="color:blue">string</span>.Empty;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> GoogleTimeZone(<span style="color:blue">string</span> apiKey)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    {</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        <span style="color:blue">this</span>.apiKey = apiKey;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    }</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
</div>
</div>
<p>Now let's create following helper methods.<br>
<br>
First method is a method to return the Timestamp of a given DateTime.</p>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:1000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">private</span> <span style="color:blue">long</span> GetUnixTimeStampFromDateTime(DateTime dt)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    DateTime epochDate = <span style="color:blue">new</span> DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    TimeSpan ts = dt - epochDate;</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">return</span> (<span style="color:blue">int</span>)ts.TotalSeconds;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
</div>
</div>
<p>Then the following method will do the opposite which is converting of Timestamp to DateTime.</p>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:1000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">private</span> DateTime GetDateTimeFromUnixTimeStamp(<span style="color:blue">double</span> unixTimeStamp)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    DateTime dt = <span style="color:blue">new</span> DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    dt = dt.AddSeconds(unixTimeStamp);</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">return</span> dt;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
</div>
</div>
<div align="justify"></div>
<p>Now the following method will return the coordinates for a given location. We can get the geographic coordinates by calling the Google Geocoding API.</p>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:1000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">private</span> GeoLocation GetCoordinatesByLocationName(<span style="color:blue">string</span> address)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">string</span> requestUri = <span style="color:blue">string</span>.Format(<span style="color:#006080">&quot;https://maps.googleapis.com/maps/api/geocode/xml?address={0}&amp;key={1}&quot;</span>, Uri.EscapeDataString(address), <span style="color:blue">this</span>.apiKey);<span style="background-color:#f4f4f4; font-size:8pt; line-height:12pt">&nbsp;</span></pre>
&lt;!--CRLF--&gt;<br>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    XDocument xdoc = GetXmlResponse(requestUri);<span style="background-color:#f4f4f4; font-size:8pt; line-height:12pt">&nbsp;</span></pre>
&lt;!--CRLF--&gt;<br>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    XElement status = xdoc.Element(<span style="color:#006080">&quot;GeocodeResponse&quot;</span>).Element(<span style="color:#006080">&quot;status&quot;</span>);</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    XElement result = xdoc.Element(<span style="color:#006080">&quot;GeocodeResponse&quot;</span>).Element(<span style="color:#006080">&quot;result&quot;</span>);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    XElement locationElement = result.Element(<span style="color:#006080">&quot;geometry&quot;</span>).Element(<span style="color:#006080">&quot;location&quot;</span>);</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    XElement lat = locationElement.Element(<span style="color:#006080">&quot;lat&quot;</span>);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    XElement lng = locationElement.Element(<span style="color:#006080">&quot;lng&quot;</span>);</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">return</span> <span style="color:blue">new</span> GeoLocation()</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    {</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        Latitude = Convert.ToDouble(lat.Value),</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        Longitude = Convert.ToDouble(lng.Value)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    };</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
</div>
</div>
<div align="justify">I have the following helper class to hold coordinates.</div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:1000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">class</span> GeoLocation</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">double</span> Latitude { get; set; }</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">double</span> Longitude { get; set; }</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
</div>
</div>
<div align="justify">We now have the location and the time stamp. Following method will call the Google Time Zone API and get the converted time zone result.</div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:1000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">private</span> GoogleTimeZoneResult GetConvertedDateTimeBasedOnAddress(GeoLocation location, <span style="color:blue">long</span> timestamp)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">string</span> requestUri = <span style="color:blue">string</span>.Format(<span style="color:#006080">&quot;https://maps.googleapis.com/maps/api/timezone/xml?location={0},{1}&amp;timestamp={2}&amp;key={3}&quot;</span>, location.Latitude, location.Longitude, timestamp, <span style="color:blue">this</span>.apiKey);<span style="background-color:#f4f4f4; font-size:8pt; line-height:12pt">&nbsp;</span></pre>
&lt;!--CRLF--&gt;<br>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    XDocument xdoc = GetXmlResponse(requestUri);<span style="background-color:#f4f4f4; font-size:8pt; line-height:12pt">&nbsp;</span></pre>
&lt;!--CRLF--&gt;<br>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    XElement result = xdoc.Element(<span style="color:#006080">&quot;TimeZoneResponse&quot;</span>);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    XElement rawOffset = result.Element(<span style="color:#006080">&quot;raw_offset&quot;</span>);</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    XElement dstOfset = result.Element(<span style="color:#006080">&quot;dst_offset&quot;</span>);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    XElement timeZoneId = result.Element(<span style="color:#006080">&quot;time_zone_id&quot;</span>);</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    XElement timeZoneName = result.Element(<span style="color:#006080">&quot;time_zone_name&quot;</span>);<span style="background-color:#f4f4f4; font-size:8pt; line-height:12pt">&nbsp;</span></pre>
&lt;!--CRLF--&gt;<br>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">return</span> <span style="color:blue">new</span> GoogleTimeZoneResult()</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    {</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        DateTime = GetDateTimeFromUnixTimeStamp(Convert.ToDouble(timestamp) &#43; Convert.ToDouble(rawOffset.Value) &#43; Convert.ToDouble(dstOfset.Value)),</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        TimeZoneId = timeZoneId.Value,</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        TimeZoneName = timeZoneName.Value</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    };</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
&lt;!--CRLF--&gt;</div>
</div>
<p>I am grouping up the result to a class named&nbsp;GoogleTimeZoneResult as follows.</p>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:1000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">public</span> <span style="color:blue">class</span> GoogleTimeZoneResult</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> DateTime DateTime { get; set; }</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">string</span> TimeZoneId { get; set; }</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">public</span> <span style="color:blue">string</span> TimeZoneName { get; set; }</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
</div>
</div>
<div align="justify">Finally I have the following public method which will trigger all the above methods.</div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:1000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">public</span> GoogleTimeZoneResult GetConvertedDateTimeBasedOnAddress(<span style="color:blue">string</span> address, DateTime dateTime)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">long</span> timestamp = GetUnixTimeStampFromDateTime(TimeZoneInfo.ConvertTimeToUtc(dateTime));</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">if</span> (previousAddress != address)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    {</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        <span style="color:blue">this</span>.location = GetCoordinatesByLocationName(address);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        previousAddress = address;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        <span style="color:blue">if</span> (<span style="color:blue">this</span>.location == <span style="color:blue">null</span>)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        {</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">            <span style="color:blue">return</span> <span style="color:blue">null</span>;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">        }</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    }<span style="background-color:#f4f4f4; font-size:8pt; line-height:12pt">&nbsp;</span></pre>
&lt;!--CRLF--&gt;<br>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">return</span> GetConvertedDateTimeBasedOnAddress(<span style="color:blue">this</span>.location, timestamp);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
</div>
</div>
<div style="text-align:justify">That&rsquo;s it. now let&rsquo;s test the functionality using some test DateTime and calling the above public method from the Main.</div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:1000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">static</span> <span style="color:blue">void</span> Main(<span style="color:blue">string</span>[] args)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    GoogleTimeZone googleTimeZone = <span style="color:blue">new</span> GoogleTimeZone(<span style="color:#006080">&quot;your api key&quot;</span>);<span style="background-color:#f4f4f4; font-size:8pt; line-height:12pt">&nbsp;</span></pre>
&lt;!--CRLF--&gt;<br>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">string</span> timeString = <span style="color:#006080">&quot;2015-01-01T08:00:00.000&#43;05:30&quot;</span>;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    DateTime dt = DateTime.Parse(timeString);</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:green">//string location = &quot;Colombo, Sri Lanka&quot;;</span></pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:green">//string location = &quot;Sydney, Australia&quot;;</span></pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    <span style="color:blue">string</span> location = <span style="color:#006080">&quot;Seattle, United States&quot;</span>;</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    GoogleTimeZoneResult googleTimeZoneResult = googleTimeZone.GetConvertedDateTimeBasedOnAddress(location, dt);</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    Console.WriteLine(<span style="color:#006080">&quot;DateTime on the server : &quot;</span> &#43; dt);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    Console.WriteLine(<span style="color:#006080">&quot;Server time in particular to : &quot;</span> &#43; location);</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    Console.WriteLine(<span style="color:#006080">&quot;TimeZone Id : &quot;</span> &#43; googleTimeZoneResult.TimeZoneId);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    Console.WriteLine(<span style="color:#006080">&quot;TimeZone Name : &quot;</span> &#43; googleTimeZoneResult.TimeZoneName);</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    Console.WriteLine(<span style="color:#006080">&quot;Converted DateTime : &quot;</span> &#43; googleTimeZoneResult.DateTime);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
&lt;!--CRLF--&gt;</div>
</div>
<p><br>
<strong><span style="text-decoration:underline">Colombo, Sri Lanka</span></strong><br>
<br>
</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="margin-left:auto; margin-right:auto; text-align:center">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh3.ggpht.com/-z96K_KxADAk/VLjjSB_mZ6I/AAAAAAAAC5g/3LcRmmreh5k/s1600-h/image10.png" style="margin-left:auto; margin-right:auto"><img title="image" src="http://lh3.ggpht.com/-qGZ6uiLxEUc/VLjjTnh8N8I/AAAAAAAAC5o/C-ndBWkjNSk/image_thumb4.png?imgmax=800" border="0" alt="image" width="502" height="104" style="border-width:0px; display:block; float:none; margin-left:auto; margin-right:auto; padding-left:0px; padding-right:0px; padding-top:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Colombo, Sri Lanka</td>
</tr>
</tbody>
</table>
<p><strong><span style="text-decoration:underline">Sydney, Australia</span></strong><br>
<br>
</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="margin-left:auto; margin-right:auto; text-align:center">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh3.ggpht.com/-G4imld2BSlk/VLjjUd4tfSI/AAAAAAAAC5w/PMJT-0BIFUU/s1600-h/image12.png" style="margin-left:auto; margin-right:auto"><img title="image" src="http://lh5.ggpht.com/-uccUmdklRqs/VLjjVbLnW8I/AAAAAAAAC54/RuZw55vN_sE/image_thumb6.png?imgmax=800" border="0" alt="image" width="505" height="104" style="border-width:0px; display:block; float:none; margin-left:auto; margin-right:auto; padding-left:0px; padding-right:0px; padding-top:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Sydney, Australia</td>
</tr>
</tbody>
</table>
<p><strong><span style="text-decoration:underline">Seattle, United States</span></strong><br>
<br>
</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="margin-left:auto; margin-right:auto; text-align:center">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh4.ggpht.com/-caqXqvBmNvc/VLjjWM1ffnI/AAAAAAAAC6A/TjTnvkJHoD0/s1600-h/image%25255B4%25255D.png" style="margin-left:auto; margin-right:auto"><img title="image" src="http://lh4.ggpht.com/-J7TKJ-MbNR0/VLjjW080yHI/AAAAAAAAC6I/7oyuvPcWKSU/image_thumb%25255B2%25255D.png?imgmax=800" border="0" alt="image" width="535" height="103" style="border:0px; display:block; float:none; margin-left:auto; margin-right:auto; padding-left:0px; padding-right:0px; padding-top:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Seattle, United States</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
<div></div>
<div>Happy Coding.</div>
