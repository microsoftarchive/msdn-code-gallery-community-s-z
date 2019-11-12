# Speech To Text Bot using Microsoft Bot Framework and Cognitive Services [C#]
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Bing Speech
- Microsoft Bot Framework
- Cognitive Services
## Topics
- Bing Speech
- Microsoft Bot Framework
- Cognitive Services
- Bots
## Updated
- 11/18/2016
## Description

<h1>Speech To Text Bot Sample</h1>
<p>A sample bot that illustrates how to use the Microsoft Cognitive Services Bing Speech API to analyze an audio file and convert the audio stream to text. This Sample code could also be found in&nbsp;<a href="https://github.com/Microsoft/BotBuilder-Samples/tree/master/CSharp/intelligence-SpeechToText">Github</a>.</p>
<h1>Prerequisites</h1>
<p><em>The minimum prerequisites to run this sample are:</em></p>
<ul>
<li>The latest update of Visual Studio 2015. You can download the community version&nbsp;<a href="http://www.visualstudio.com/">here</a>&nbsp;for free.
</li></ul>
<ul>
<li>The Bot Framework Emulator. To install the Bot Framework Emulator, download it from&nbsp;<a href="https://aka.ms/bf-bc-emulator">here</a>. Please refer to&nbsp;<a href="https://docs.botframework.com/en-us/csharp/builder/sdkreference/gettingstarted.html#emulator">this
 documentation article</a>&nbsp;to know more about the Bot Framework Emulator. </li><li>Bing Speech Api Key. You can obtain one from&nbsp;<a href="https://www.microsoft.com/cognitive-services/en-us/subscriptions?productId=/products/Bing.Speech.Preview">Microsoft Cognitive Services Subscriptions Page</a>.
</li><li>This sample currently uses a free trial Microsoft Cognitive service key with limited QPS. Please subscribe to Bing Speech Api services
<span><a href="https://www.microsoft.com/cognitive-services/en-us/subscriptions">here</a></span>&nbsp;and update the
<strong>MicrosoftSpeechApiKey</strong>&nbsp;key in key in the <em>Web.config</em>&nbsp;file to try it out further.
</li></ul>
<h1>Usage</h1>
<p>Attach an audio file (wav format) and send an optional command as text.&nbsp;</p>
<p>Supported Commands:</p>
<ul>
<li>WORD - Counts the number of words. </li><li>CHARACTER - Counts the number of characters excluding spaces. </li><li>SPACE - Counts the number of spaces. </li><li>VOWEL - Counts the number of vowels. </li><li>Any other word will count the occurrences of that word in the transcribed text
</li></ul>
<h1>Code Highlights</h1>
<p>Microsoft Cognitive Services provides a Speech Recognition API to convert audio into text. Check out&nbsp;<a href="https://www.microsoft.com/cognitive-services/en-us/speech-api">Bing Speech API</a>&nbsp;for a complete reference of Speech APIs available.
 In this sample we are using the Speech Recognition API using the&nbsp;<a href="https://www.microsoft.com/cognitive-services/en-us/Speech-api/documentation/API-Reference-REST/BingVoiceRecognition">REST API</a>.</p>
<p>In this sample we are using the API to get the text and send it back to the user. Check out the use of the&nbsp;<em>MicrosoftCognitiveSpeechService.GetTextFromAudioAsync()</em>&nbsp;method in the
<em>Controllers/MessagesController.cs</em> class.</p>
<div class="scriptcode">
<div class="scriptcode">
<div class="scriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">var&nbsp;audioAttachment&nbsp;=&nbsp;activity.Attachments?.FirstOrDefault(a&nbsp;=&gt;&nbsp;a.ContentType.Equals(<span class="cs__string">&quot;audio/wav&quot;</span>));&nbsp;
<span class="cs__keyword">if</span>&nbsp;(audioAttachment&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;stream&nbsp;=&nbsp;await&nbsp;client.GetStreamAsync(audioAttachment.ContentUrl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;text&nbsp;=&nbsp;await&nbsp;<span class="cs__keyword">this</span>.speechService.GetTextFromAudioAsync(stream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message&nbsp;=&nbsp;ProcessText(activity.Text,&nbsp;text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
</div>
</div>
</div>
<p>and here is the implementation of <em>MicrosoftCognitiveSpeechService.GetTextFromAudioAsync()</em> in
<em>Services/MicrosoftCognitiveSpeechService.cs</em></p>
<div class="scriptcode">
<div class="scriptcode">
<div class="scriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">````C#&nbsp;
<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Gets&nbsp;text&nbsp;from&nbsp;an&nbsp;audio&nbsp;stream.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;audiostream&quot;&gt;&lt;/param&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;returns&gt;Transcribed&nbsp;text.&nbsp;&lt;/returns&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;<span class="cs__keyword">string</span>&gt;&nbsp;GetTextFromAudioAsync(Stream&nbsp;audiostream)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;requestUri&nbsp;=&nbsp;@<span class="cs__string">&quot;https://speech.platform.bing.com/recognize?scenarios=smd&amp;appid=D4D52672-91D7-4C74-8AD8-42B1D98141A5&amp;locale=en-US&amp;device.os=bot&amp;version=3.0&amp;format=json&amp;instanceid=565D69FF-E928-4B7E-87DA-9A750B96D9E3&amp;requestid=&quot;</span>&nbsp;&#43;&nbsp;Guid.NewGuid();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;token&nbsp;=&nbsp;Authentication.Instance.GetAccessToken();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.DefaultRequestHeaders.Add(<span class="cs__string">&quot;Authorization&quot;</span>,&nbsp;<span class="cs__string">&quot;Bearer&nbsp;&quot;</span>&nbsp;&#43;&nbsp;token.access_token);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;binaryContent&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ByteArrayContent(StreamToBytes(audiostream)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;binaryContent.Headers.TryAddWithoutValidation(<span class="cs__string">&quot;content-type&quot;</span>,&nbsp;<span class="cs__string">&quot;audio/wav;&nbsp;codec=\&quot;audio/pcm\&quot;;&nbsp;samplerate=16000&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;await&nbsp;client.PostAsync(requestUri,&nbsp;binaryContent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;responseString&nbsp;=&nbsp;await&nbsp;response.Content.ReadAsStringAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dynamic&nbsp;data&nbsp;=&nbsp;JsonConvert.DeserializeObject(responseString);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;data.header.name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
</div>
</div>
</div>
<h1>Outcome</h1>
<p>You will see the following when connecting the Bot to the Emulator and send it an audio file and a command:</p>
<p>Input:</p>
<p>Audio file:&nbsp;audio/whatstheweatherlike.wav</p>
<p>Output:</p>
<p><img id="163715" src="163715-outcome-emulator.png" alt="" width="1010" height="761"></p>
<h1>More Information</h1>
<p>To get more information about how to get started in Bot Builder for .NET and Microsoft Cognitive Services Bing Speech API please review the following resources:</p>
<ul>
<li><a href="https://docs.botframework.com/en-us/csharp/builder/sdkreference/index.html"></a><a href="https://docs.botframework.com/en-us/node/builder/overview/#navtitle"></a><a href="https://docs.botframework.com/en-us/node/builder/overview/#navtitle"></a><a href="https://docs.botframework.com/en-us/csharp/builder/sdkreference/index.html">Bot
 Builder for .NET</a> </li><li><a href="https://github.com/Microsoft/Cognitive-vision-windows"></a><a href="https://www.microsoft.com/cognitive-services/en-us/computer-vision-api"></a><a href="https://www.microsoft.com/cognitive-services/en-us/speech-api">Microsoft Cognitive Services
 Bing Speech API</a> </li></ul>
