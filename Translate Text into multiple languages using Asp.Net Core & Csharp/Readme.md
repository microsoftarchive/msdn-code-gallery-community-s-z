# Translate Text into multiple languages using Asp.Net Core & Csharp
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- Microsoft Azure
- Javascript
- ASP.NET Web API
- AI
- ASP.NET Core
- Cognitive Services
- Microsoft Cognitive Services
- Language API
## Topics
- C#
- Microsoft Azure
- Javascript
- ASP.NET Web API
- AI
- ASP.NET Core
- Cognitive Services
- Microsoft Cognitive Services
- Language API
## Updated
- 09/30/2018
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">In this article, we are going to learn how to translate text into multiple languages using one of the important Cognitive Services API called Microsoft Translate Text API ( One of the API in Language API ). It's a simple&nbsp;cloud-based
 machine translation service and obviously we can test through simple Rest API call. Microsoft is using a new standard for high-quality AI-powered machine translations known as&nbsp;Neural Machine Translation (NMT).</span></p>
<h1>Interface</h1>
<p><span style="font-size:small">The &quot;ITranslateText&quot; contains one signature for translating text content based on the given input. So we have injected this interface in the ASP.NET Core &quot;Startup.cs&quot; class as a &quot;AddTransient&quot;.</span></p>
<h1><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.Threading.Tasks;

namespace TranslateTextApp.Business_Layer.Interface
{
    interface ITranslateText
    {
        Task&lt;string&gt; Translate(string uri, string text, string key);
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;TranslateTextApp.Business_Layer.Interface&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">interface</span>&nbsp;ITranslateText&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;<span class="cs__keyword">string</span>&gt;&nbsp;Translate(<span class="cs__keyword">string</span>&nbsp;uri,&nbsp;<span class="cs__keyword">string</span>&nbsp;text,&nbsp;<span class="cs__keyword">string</span>&nbsp;key);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
</span>Translator Text API Service</h1>
<p><span style="font-size:small">We can add the valid Translator Text API Subscription Key into the following code.</span></p>
<h1><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TranslateTextApp.Business_Layer.Interface;

namespace TranslateTextApp.Business_Layer
{
    public class TranslateTextService : ITranslateText
    {
        /// &lt;summary&gt;
        /// Translate the given text in to selected language.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;uri&quot;&gt;Request uri&lt;/param&gt;
        /// &lt;param name=&quot;text&quot;&gt;The text is given for translation&lt;/param&gt;
        /// &lt;param name=&quot;key&quot;&gt;Subscription key&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public async Task&lt;string&gt; Translate(string uri, string text, string key)
        {
            System.Object[] body = new System.Object[] { new { Text = text } };
            var requestBody = JsonConvert.SerializeObject(body);
            
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(requestBody, Encoding.UTF8, &quot;application/json&quot;);
                request.Headers.Add(&quot;Ocp-Apim-Subscription-Key&quot;, key);

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody), Formatting.Indented);
                
                return result;
            }
        }
    }
}
</pre>
<div class="preview">
<pre class="js">using&nbsp;Newtonsoft.Json;&nbsp;
using&nbsp;System;&nbsp;
using&nbsp;System.Net.Http;&nbsp;
using&nbsp;System.Text;&nbsp;
using&nbsp;System.Threading.Tasks;&nbsp;
using&nbsp;TranslateTextApp.Business_Layer.Interface;&nbsp;
&nbsp;
namespace&nbsp;TranslateTextApp.Business_Layer&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;TranslateTextService&nbsp;:&nbsp;ITranslateText&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span><span class="js__sl_comment">///&nbsp;Translate&nbsp;the&nbsp;given&nbsp;text&nbsp;in&nbsp;to&nbsp;selected&nbsp;language.</span><span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span><span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;uri&quot;&gt;Request&nbsp;uri&lt;/param&gt;</span><span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;text&quot;&gt;The&nbsp;text&nbsp;is&nbsp;given&nbsp;for&nbsp;translation&lt;/param&gt;</span><span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;key&quot;&gt;Subscription&nbsp;key&lt;/param&gt;</span><span class="js__sl_comment">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;async&nbsp;Task&lt;string&gt;&nbsp;Translate(string&nbsp;uri,&nbsp;string&nbsp;text,&nbsp;string&nbsp;key)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.<span class="js__object">Object</span>[]&nbsp;body&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;System.<span class="js__object">Object</span>[]&nbsp;<span class="js__brace">{</span><span class="js__operator">new</span><span class="js__brace">{</span>&nbsp;Text&nbsp;=&nbsp;text&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;requestBody&nbsp;=&nbsp;JsonConvert.SerializeObject(body);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;client&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;HttpClient())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;request&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;HttpRequestMessage())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Method&nbsp;=&nbsp;HttpMethod.Post;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.RequestUri&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Uri(uri);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Content&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;StringContent(requestBody,&nbsp;Encoding.UTF8,&nbsp;<span class="js__string">&quot;application/json&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.Headers.Add(<span class="js__string">&quot;Ocp-Apim-Subscription-Key&quot;</span>,&nbsp;key);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;response&nbsp;=&nbsp;await&nbsp;client.SendAsync(request);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;responseBody&nbsp;=&nbsp;await&nbsp;response.Content.ReadAsStringAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dynamic&nbsp;result&nbsp;=&nbsp;JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody),&nbsp;Formatting.Indented);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
</span></h1>
<h1>Output</h1>
<p><span style="font-size:small">The given text is translated into desired language listed in a drop-down list using Microsoft Translator API.</span></p>
<p><span style="font-size:small"><img id="215562" src="215562-rajeeshmenoth_gif.gif" alt="" width="1366" height="369"><br>
</span></p>
<h1>Reference</h1>
<h1><span style="font-size:small">
<div class="endscriptcode">
<ul>
<li><strong><a title="Translator Text API Documentation" href="https://docs.microsoft.com/en-in/azure/cognitive-services/translator/" target="_blank">&nbsp;https://docs.microsoft.com/en-in/azure/cognitive-services/translator/</a></strong>
</li></ul>
</div>
</span>Summary</h1>
<p><span style="font-size:small">From this article we have learned translate a text(typed in english) in to different languages as per the API documentation using one of the important Cognitive Services API ( Translator Text API is a part of Language API ).
 I hope this article is useful for all Azure Cognitive Services API beginners.</span></p>
