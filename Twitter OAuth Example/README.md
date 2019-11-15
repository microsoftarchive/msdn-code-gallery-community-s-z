# Twitter OAuth Example
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- XAML
- Twitter
- HttpClient
- OAuth
## Topics
- Authentication
## Updated
- 03/09/2013
## Description

<p><span style="text-decoration:underline"><strong><span style="font-size:large">Introduction</span></strong></span></p>
<p><span style="font-size:small">&nbsp;An example showing how&nbsp;OAuth Twitter API works step by step. (Updated for Twitter API v1.1 and query parameter support)</span></p>
<p><span style="text-decoration:underline"><strong><span style="font-size:large">Description</span></strong></span></p>
<p><span style="font-size:small">Twitter is using a strict OAuth 1.0a and requires HTTP Header-based Authorization. Before we start coding, let&rsquo;s talk briefly what our application (i.e., Twitter consumer) has to do to be able to consume Twitter information
 with user authorization.</span></p>
<p><span style="font-size:small">1. Our application has to have a Twitter consumer key and consumer secret key. We can get it by registering your app through
<a href="http://dev.twitter.com">http://dev.twitter.com</a>.</span></p>
<p><span style="font-size:small">2. Our application starts talking with Twitter by asking Twitter for a request token (and request token secret key). In this step, our application has to give Twitter , the consumer key and other OAuth parameters like nonce,
 signature method, version, and so on. The application also needs to provide a signature which is signed with the consumer secret key.</span></p>
<p><span style="font-size:small">3. Twitter gives us the request token and the request token secret key only (unlike LinkedIn), so we have to combined tokens and Twitter authorize url to let our user authorize our application.</span></p>
<p><span style="font-size:small">4. As our application is not a web application (callback url was not specified), our application has to provide a way for user to enter a PIN code that Twitter gives the user in authorization process.</span></p>
<p><span style="font-size:small">5. Now our application should have the request token, the request token secret key, the PIN code (oauth_verifier). Our application will use above information to request Twitter for an access token and an access token secret
 key. The application also needs to provide a signature which is signed with the consumer secret and request token secret keys .</span></p>
<p><span style="font-size:small">6. Once our application has the access token and the access token secret key, then our application can make Twitter API call and get information from Twitter.</span></p>
<p><span style="font-size:small">To see how signature is created, please go to <a href="https://dev.twitter.com/docs/auth/creating-signature">
https://dev.twitter.com/docs/auth/creating-signature</a>.</span></p>
<p><span style="font-size:small">Here are screenshots of the app.</span></p>
<p>&nbsp;</p>
<p><img id="77429" src="http://i1.code.msdn.s-msft.com/windowsapps/twitter-oauth-example-3a99967f/image/file/77429/1/oauthtwitter-001.jpg" alt="" width="767" height="408"></p>
<p><img id="77430" src="http://i1.code.msdn.s-msft.com/windowsapps/twitter-oauth-example-3a99967f/image/file/77430/1/oauthtwitter-002.jpg" alt="" width="767" height="424"></p>
<p><img id="77432" src="http://i1.code.msdn.s-msft.com/windowsapps/twitter-oauth-example-3a99967f/image/file/77432/1/oauthtwitter-003.jpg" alt="" width="769" height="405"></p>
<p><img id="77433" src="http://i1.code.msdn.s-msft.com/windowsapps/twitter-oauth-example-3a99967f/image/file/77433/1/oauthtwitter-004.jpg" alt="" width="771" height="413"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>How parameter base strings have been created:</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;getParamsBaseString(<span class="cs__keyword">string</span>&nbsp;queryParamsString,&nbsp;<span class="cs__keyword">string</span>&nbsp;nonce,&nbsp;<span class="cs__keyword">string</span>&nbsp;timeStamp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;these&nbsp;parameters&nbsp;are&nbsp;required&nbsp;in&nbsp;every&nbsp;request&nbsp;api</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;baseStringParams&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">string</span>&gt;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="cs__string">&quot;oauth_consumer_key&quot;</span>,&nbsp;consumerKey.Text},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="cs__string">&quot;oauth_nonce&quot;</span>,&nbsp;nonce},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="cs__string">&quot;oauth_signature_method&quot;</span>,&nbsp;<span class="cs__string">&quot;HMAC-SHA1&quot;</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="cs__string">&quot;oauth_timestamp&quot;</span>,&nbsp;timeStamp},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="cs__string">&quot;oauth_token&quot;</span>,&nbsp;accessToken.Text},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="cs__string">&quot;oauth_verifier&quot;</span>,&nbsp;oAuthVerifier.Text},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="cs__string">&quot;oauth_version&quot;</span>,&nbsp;<span class="cs__string">&quot;1.0&quot;</span>},&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;put&nbsp;each&nbsp;parameter&nbsp;into&nbsp;dictionary</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;queryParams&nbsp;=&nbsp;queryParamsString&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Split(<span class="cs__string">'&amp;'</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ToDictionary(p&nbsp;=&gt;&nbsp;p.Substring(<span class="cs__number">0</span>,&nbsp;p.IndexOf(<span class="cs__string">'='</span>)),&nbsp;p&nbsp;=&gt;&nbsp;p.Substring(p.IndexOf(<span class="cs__string">'='</span>)&#43;<span class="cs__number">1</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;kv&nbsp;<span class="cs__keyword">in</span>&nbsp;queryParams)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;baseStringParams.Add(kv.Key,&nbsp;kv.Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;The&nbsp;OAuth&nbsp;spec&nbsp;says&nbsp;to&nbsp;sort&nbsp;lexigraphically,&nbsp;which&nbsp;is&nbsp;the&nbsp;default&nbsp;alphabetical&nbsp;sort&nbsp;for&nbsp;many&nbsp;libraries.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;ret&nbsp;=&nbsp;baseStringParams&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.OrderBy(kv&nbsp;=&gt;&nbsp;kv.Key)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Select(kv&nbsp;=&gt;&nbsp;kv.Key&nbsp;&#43;&nbsp;<span class="cs__string">&quot;=&quot;</span>&nbsp;&#43;&nbsp;kv.Value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Aggregate((i,&nbsp;j)&nbsp;=&gt;&nbsp;i&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&amp;&quot;</span>&nbsp;&#43;&nbsp;j);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;ret;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">How the request has been done:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;requestTwitterApi(<span class="cs__keyword">string</span>&nbsp;url)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;nonce&nbsp;=&nbsp;oAuthUtil.GetNonce();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;timeStamp&nbsp;=&nbsp;oAuthUtil.GetTimeStamp();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpClient&nbsp;httpClient&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpClient.MaxResponseContentBufferSize&nbsp;=&nbsp;<span class="cs__keyword">int</span>.MaxValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpClient.DefaultRequestHeaders.ExpectContinue&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpRequestMessage&nbsp;requestMsg&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpRequestMessage();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;requestMsg.Method&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpMethod(<span class="cs__string">&quot;GET&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;qParams&nbsp;=&nbsp;QueryParams.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;urlWithParams&nbsp;=&nbsp;url&nbsp;&#43;&nbsp;<span class="cs__string">&quot;?&quot;</span>&nbsp;&#43;&nbsp;qParams;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;HttpClient&nbsp;uses&nbsp;full&nbsp;url</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;requestMsg.RequestUri&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(urlWithParams);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;paramsBaseString&nbsp;=&nbsp;getParamsBaseString(qParams,&nbsp;nonce,&nbsp;timeStamp);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;sigBaseString&nbsp;=&nbsp;<span class="cs__string">&quot;GET&amp;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;signature&nbsp;base&nbsp;string&nbsp;uses&nbsp;base&nbsp;url</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sigBaseString&nbsp;&#43;=&nbsp;Uri.EscapeDataString(url)&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&amp;&quot;</span>&nbsp;&#43;&nbsp;Uri.EscapeDataString(paramsBaseString);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;signature&nbsp;=&nbsp;oAuthUtil.GetSignature(sigBaseString,&nbsp;consumerSecretKey.Text,&nbsp;accessTokenSecretKey.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;data&nbsp;=&nbsp;<span class="cs__string">&quot;oauth_consumer_key=\&quot;&quot;</span>&nbsp;&#43;&nbsp;consumerKey.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;\&quot;,&nbsp;oauth_nonce=\&quot;&quot;</span>&nbsp;&#43;&nbsp;nonce&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;\&quot;,&nbsp;oauth_signature=\&quot;&quot;</span>&nbsp;&#43;&nbsp;Uri.EscapeDataString(signature)&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;\&quot;,&nbsp;oauth_signature_method=\&quot;HMAC-SHA1\&quot;,&nbsp;oauth_timestamp=\&quot;&quot;</span>&nbsp;&#43;&nbsp;timeStamp&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;\&quot;,&nbsp;oauth_token=\&quot;&quot;</span>&nbsp;&#43;&nbsp;accessToken.Text&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;\&quot;,&nbsp;oauth_verifier=\&quot;&quot;</span>&nbsp;&#43;&nbsp;oAuthVerifier.Text&nbsp;&#43;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;\&quot;,&nbsp;oauth_version=\&quot;1.0\&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;requestMsg.Headers.Authorization&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AuthenticationHeaderValue(<span class="cs__string">&quot;OAuth&quot;</span>,&nbsp;data);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;await&nbsp;httpClient.SendAsync(requestMsg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;text&nbsp;=&nbsp;await&nbsp;response.Content.ReadAsStringAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebViewHost.Visibility&nbsp;=&nbsp;Windows.UI.Xaml.Visibility.Collapsed;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TwitterResponse.Visibility&nbsp;=&nbsp;Windows.UI.Xaml.Visibility.Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TwitterResponse.Text&nbsp;=&nbsp;text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;Err)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
