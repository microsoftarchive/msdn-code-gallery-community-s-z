# SharePoint Rest API Sample
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- REST
- SharePoint
- OData
## Topics
- C#
- SharePoint
## Updated
- 06/28/2016
## Description

<h1>Introduction</h1>
<p><em>This sample contains a explaination on how to call the SharePoint Rest API's within C# and use Application Authentication with the help of the TokenHelper.&nbsp;</em></p>
<h2>SharePoint Rest API Handler</h2>
<p>SharePoint contains a lot of Rest API&rsquo;s that can be used for many scenario&rsquo;s. You could use them for example in desktop and windows phone applications. When using these API&rsquo;s you need to make sure authentication is handled before calling
 the API. For authenticating to these API&rsquo;s there a couple of options:</p>
<ul>
<li>Authenticate as a User. This is a registered user with a license within your Office 365 tenant or your on-premise AD.
</li><li>Authenticate as a Application. You can register a application within an SharePoint site by using the &ldquo;AppRegNew.aspx&rdquo; page and perform actions on behalf of a application.
</li></ul>
<p>The token that is received from the authentication request needs to be supplied in the header of the API call. In order to retrieve the token you can make use of the &ldquo;TokenHelper&rdquo; class that is added by default to SharePoint App projects.</p>
<p>With the token the API call can be made, this needs do be done in different ways. Example for this is getting items from SharePoint.</p>
<p>Getting items from a SharePoint list can be achieved by using a Http Get to the &ldquo;GetItems&rdquo; API method and supplying a Caml query in the URL.</p>
<ul>
<li>[siteurl]/_api/web/lists/GetByTitle('[listname]')/GetItems(<a href="mailto:query=@v1)?@v1={%22ViewXml%22:%22[camlquery">query=@v1)?@v1={&quot;ViewXml&quot;:&quot;[camlquery</a>]&quot;}
</li></ul>
<p>&nbsp;</p>
<p>Example for a Caml query is displayed below. Make sure you supply a query with the &ldquo;View&rdquo; and &ldquo;Query&rdquo; tag included.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;View&gt;
 &lt;ViewFields&gt;
  &lt;FieldRef Name='LinkFilename' /&gt;
 &lt;/ViewFields&gt;
 &lt;Query&gt;
  &lt;OrderBy&gt;
   &lt;FieldRef Name='Created' /&gt;
  &lt;/OrderBy&gt;
 &lt;/Query&gt;
&lt;/View&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;View</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;<span class="xml__tag_start">&lt;ViewFields</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;FieldRef</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">'LinkFilename'</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;<span class="xml__tag_end">&lt;/ViewFields&gt;</span>&nbsp;
&nbsp;<span class="xml__tag_start">&lt;Query</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;OrderBy</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;FieldRef</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">'Created'</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/OrderBy&gt;</span>&nbsp;
&nbsp;<span class="xml__tag_end">&lt;/Query&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/View&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p>The call that makes use of the SPAPIHandler is as followed:</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public string GetItems(string siteUrl, string list, string camlQuery) {
    string retVal = string.Empty;

    string data = camlJson.Replace(&quot;{0}&quot;, camlQuery);
    camlQuery = &quot;(query=@v1)?@v1={\&quot;ViewXml\&quot;:\&quot;{2}\&quot;}&quot;.Replace(&quot;{2}&quot;, camlQuery);
    string url =string.Format(CultureInfo.InvariantCulture, &quot;{0}/_api/web/lists/GetByTitle('{1}')/GetItems{2}&quot;, siteUrl, list, camlQuery);

    SPAPIHandler handler = new SPAPIHandler(ClientId, ClientSecret);
    retVal = handler.Post(url);

    return retVal;
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GetItems(<span class="cs__keyword">string</span>&nbsp;siteUrl,&nbsp;<span class="cs__keyword">string</span>&nbsp;list,&nbsp;<span class="cs__keyword">string</span>&nbsp;camlQuery)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;retVal&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;data&nbsp;=&nbsp;camlJson.Replace(<span class="cs__string">&quot;{0}&quot;</span>,&nbsp;camlQuery);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;camlQuery&nbsp;=&nbsp;<span class="cs__string">&quot;(query=@v1)?@v1={\&quot;ViewXml\&quot;:\&quot;{2}\&quot;}&quot;</span>.Replace(<span class="cs__string">&quot;{2}&quot;</span>,&nbsp;camlQuery);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;url&nbsp;=<span class="cs__keyword">string</span>.Format(CultureInfo.InvariantCulture,&nbsp;<span class="cs__string">&quot;{0}/_api/web/lists/GetByTitle('{1}')/GetItems{2}&quot;</span>,&nbsp;siteUrl,&nbsp;list,&nbsp;camlQuery);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SPAPIHandler&nbsp;handler&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SPAPIHandler(ClientId,&nbsp;ClientSecret);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;retVal&nbsp;=&nbsp;handler.Post(url);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;retVal;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p>The API calls are explicitly made by the so called SPAPIHandler.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class SPAPIHandler {

    private string contenttype = &quot;application/json;odata=verbose&quot;;

    private string acceptHeader = &quot;application/json;odata=verbose&quot;;

    /// &lt;summary&gt;
    /// Gets or sets the client identifier.
    /// &lt;/summary&gt;
    /// &lt;value&gt;
    /// The client identifier.
    /// &lt;/value&gt;
    private string ClientId { get; set; }

    /// &lt;summary&gt;
    /// Gets or sets the client secret.
    /// &lt;/summary&gt;
    /// &lt;value&gt;
    /// The client secret.
    /// &lt;/value&gt;
    private string ClientSecret { get; set; }

    public SPAPIHandler(string clientId, string clientSecret) {
        ClientId = clientId;
        ClientSecret = clientSecret;
    }

    public string Get(string url) {
        var accessToken = GetAccessTokenResponse(url);

        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        request.Method = &quot;GET&quot;;
        request.Accept = acceptHeader;
        request.Headers.Add(&quot;Authorization&quot;, accessToken.TokenType &#43; &quot; &quot; &#43; accessToken.AccessToken);

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();


        if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
            using (var reader = new System.IO.StreamReader(response.GetResponseStream())) {
                return reader.ReadToEnd();
            }
        }

        return null;
    }

    public string Post(string url) {
        var accessToken = GetAccessTokenResponse(url);

        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        request.Method = &quot;POST&quot;;
        request.ContentLength = 0;
        request.Accept = acceptHeader;
        request.Headers.Add(&quot;Authorization&quot;, accessToken.TokenType &#43; &quot; &quot; &#43; accessToken.AccessToken);

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();


        if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
            using (var reader = new System.IO.StreamReader(response.GetResponseStream())) {
                return reader.ReadToEnd();
            }
        }

        return (null);
    }

    public string Merge(string url, Document doc) {

        var accessToken = GetAccessTokenResponse(url);

        var postData = new JObject {
            [&quot;__metadata&quot;] = new JObject { [&quot;type&quot;] = &quot;SP.File&quot; }
        };

        foreach(string key in doc.MetaData.Keys) {
            postData.Add(key, doc.MetaData[key]);
        }

        byte[] listPostData = Encoding.ASCII.GetBytes(postData.ToString());

        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        request.Method = &quot;POST&quot;;
        request.ContentLength = postData.ToString().Length;
        request.ContentType = contenttype;
        request.Accept = acceptHeader;
        request.Headers.Add(&quot;Authorization&quot;, accessToken.TokenType &#43; &quot; &quot; &#43; accessToken.AccessToken);
        request.Headers.Add(&quot;If-Match&quot;, &quot;*&quot;);
        request.Headers.Add(&quot;X-Http-Method&quot;, &quot;MERGE&quot;);

        Stream listRequestStream = request.GetRequestStream();
        listRequestStream.Write(listPostData, 0, listPostData.Length);
        listRequestStream.Close();

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();


        if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
            using (var reader = new System.IO.StreamReader(response.GetResponseStream())) {
             return reader.ReadToEnd();
            }
        }

        return null;
    }

    public string PostDocument(string url, byte[] document) {
        var accessToken = GetAccessTokenResponse(url);

        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        request.Method = &quot;POST&quot;;
        request.ContentLength = document.Length;
        request.ContentType = contenttype;
        request.Accept = acceptHeader;
        request.Headers.Add(&quot;Authorization&quot;, accessToken.TokenType &#43; &quot; &quot; &#43; accessToken.AccessToken);

        Stream listRequestStream = request.GetRequestStream();
        listRequestStream.Write(document, 0, document.Length);
        listRequestStream.Close();

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();


        if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent) {
            using (var reader = new System.IO.StreamReader(response.GetResponseStream())) {
                return reader.ReadToEnd();
            }
        }

        return (null);
    }


    private OAuth2AccessTokenResponse GetAccessTokenResponse(string url) {
        Uri targetWeb = new Uri(url);
        string targetRealm = TokenHelper.GetRealmFromTargetUrl(targetWeb);
        var responseToken = TokenHelper.GetAppOnlyAccessToken(TokenHelper.SharePointPrincipal, targetWeb.Authority, targetRealm, ClientId, ClientSecret);

        return responseToken;
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SPAPIHandler&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;contenttype&nbsp;=&nbsp;<span class="cs__string">&quot;application/json;odata=verbose&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;acceptHeader&nbsp;=&nbsp;<span class="cs__string">&quot;application/json;odata=verbose&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Gets&nbsp;or&nbsp;sets&nbsp;the&nbsp;client&nbsp;identifier.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;value&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;The&nbsp;client&nbsp;identifier.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/value&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ClientId&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Gets&nbsp;or&nbsp;sets&nbsp;the&nbsp;client&nbsp;secret.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;value&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;The&nbsp;client&nbsp;secret.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/value&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ClientSecret&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;SPAPIHandler(<span class="cs__keyword">string</span>&nbsp;clientId,&nbsp;<span class="cs__keyword">string</span>&nbsp;clientSecret)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClientId&nbsp;=&nbsp;clientId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClientSecret&nbsp;=&nbsp;clientSecret;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Get(<span class="cs__keyword">string</span>&nbsp;url)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;accessToken&nbsp;=&nbsp;GetAccessTokenResponse(url);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebRequest&nbsp;request&nbsp;=&nbsp;(HttpWebRequest)HttpWebRequest.Create(url);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Method&nbsp;=&nbsp;<span class="cs__string">&quot;GET&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Accept&nbsp;=&nbsp;acceptHeader;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Headers.Add(<span class="cs__string">&quot;Authorization&quot;</span>,&nbsp;accessToken.TokenType&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;accessToken.AccessToken);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebResponse&nbsp;response&nbsp;=&nbsp;(HttpWebResponse)request.GetResponse();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(response.StatusCode&nbsp;==&nbsp;HttpStatusCode.OK&nbsp;||&nbsp;response.StatusCode&nbsp;==&nbsp;HttpStatusCode.NoContent)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.IO.StreamReader(response.GetResponseStream()))&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;reader.ReadToEnd();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Post(<span class="cs__keyword">string</span>&nbsp;url)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;accessToken&nbsp;=&nbsp;GetAccessTokenResponse(url);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebRequest&nbsp;request&nbsp;=&nbsp;(HttpWebRequest)HttpWebRequest.Create(url);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Method&nbsp;=&nbsp;<span class="cs__string">&quot;POST&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.ContentLength&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Accept&nbsp;=&nbsp;acceptHeader;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Headers.Add(<span class="cs__string">&quot;Authorization&quot;</span>,&nbsp;accessToken.TokenType&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;accessToken.AccessToken);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebResponse&nbsp;response&nbsp;=&nbsp;(HttpWebResponse)request.GetResponse();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(response.StatusCode&nbsp;==&nbsp;HttpStatusCode.OK&nbsp;||&nbsp;response.StatusCode&nbsp;==&nbsp;HttpStatusCode.NoContent)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.IO.StreamReader(response.GetResponseStream()))&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;reader.ReadToEnd();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;(<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Merge(<span class="cs__keyword">string</span>&nbsp;url,&nbsp;Document&nbsp;doc)&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;accessToken&nbsp;=&nbsp;GetAccessTokenResponse(url);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;postData&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;JObject&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<span class="cs__string">&quot;__metadata&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;JObject&nbsp;{&nbsp;[<span class="cs__string">&quot;type&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;SP.File&quot;</span>&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>(<span class="cs__keyword">string</span>&nbsp;key&nbsp;<span class="cs__keyword">in</span>&nbsp;doc.MetaData.Keys)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;postData.Add(key,&nbsp;doc.MetaData[key]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;listPostData&nbsp;=&nbsp;Encoding.ASCII.GetBytes(postData.ToString());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebRequest&nbsp;request&nbsp;=&nbsp;(HttpWebRequest)HttpWebRequest.Create(url);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Method&nbsp;=&nbsp;<span class="cs__string">&quot;POST&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.ContentLength&nbsp;=&nbsp;postData.ToString().Length;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.ContentType&nbsp;=&nbsp;contenttype;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Accept&nbsp;=&nbsp;acceptHeader;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Headers.Add(<span class="cs__string">&quot;Authorization&quot;</span>,&nbsp;accessToken.TokenType&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;accessToken.AccessToken);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Headers.Add(<span class="cs__string">&quot;If-Match&quot;</span>,&nbsp;<span class="cs__string">&quot;*&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Headers.Add(<span class="cs__string">&quot;X-Http-Method&quot;</span>,&nbsp;<span class="cs__string">&quot;MERGE&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stream&nbsp;listRequestStream&nbsp;=&nbsp;request.GetRequestStream();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listRequestStream.Write(listPostData,&nbsp;<span class="cs__number">0</span>,&nbsp;listPostData.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listRequestStream.Close();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebResponse&nbsp;response&nbsp;=&nbsp;(HttpWebResponse)request.GetResponse();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(response.StatusCode&nbsp;==&nbsp;HttpStatusCode.OK&nbsp;||&nbsp;response.StatusCode&nbsp;==&nbsp;HttpStatusCode.NoContent)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.IO.StreamReader(response.GetResponseStream()))&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;reader.ReadToEnd();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;PostDocument(<span class="cs__keyword">string</span>&nbsp;url,&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;document)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;accessToken&nbsp;=&nbsp;GetAccessTokenResponse(url);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebRequest&nbsp;request&nbsp;=&nbsp;(HttpWebRequest)HttpWebRequest.Create(url);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Method&nbsp;=&nbsp;<span class="cs__string">&quot;POST&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.ContentLength&nbsp;=&nbsp;document.Length;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.ContentType&nbsp;=&nbsp;contenttype;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Accept&nbsp;=&nbsp;acceptHeader;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Headers.Add(<span class="cs__string">&quot;Authorization&quot;</span>,&nbsp;accessToken.TokenType&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;accessToken.AccessToken);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stream&nbsp;listRequestStream&nbsp;=&nbsp;request.GetRequestStream();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listRequestStream.Write(document,&nbsp;<span class="cs__number">0</span>,&nbsp;document.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listRequestStream.Close();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebResponse&nbsp;response&nbsp;=&nbsp;(HttpWebResponse)request.GetResponse();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(response.StatusCode&nbsp;==&nbsp;HttpStatusCode.OK&nbsp;||&nbsp;response.StatusCode&nbsp;==&nbsp;HttpStatusCode.NoContent)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.IO.StreamReader(response.GetResponseStream()))&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;reader.ReadToEnd();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;(<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;OAuth2AccessTokenResponse&nbsp;GetAccessTokenResponse(<span class="cs__keyword">string</span>&nbsp;url)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;targetWeb&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(url);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;targetRealm&nbsp;=&nbsp;TokenHelper.GetRealmFromTargetUrl(targetWeb);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;responseToken&nbsp;=&nbsp;TokenHelper.GetAppOnlyAccessToken(TokenHelper.SharePointPrincipal,&nbsp;targetWeb.Authority,&nbsp;targetRealm,&nbsp;ClientId,&nbsp;ClientSecret);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;responseToken;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">The complete description can be found on my blog:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><a href="https://msftplayground.com/2016/07/sharepoint-rest-api-handler/">https://msftplayground.com/2016/07/sharepoint-rest-api-handler/</a></div>
<p>&nbsp;</p>
