# Working with HTML5 local storage and use offline functionality
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- HTML5/JavaScript
## Topics
- local storage
## Updated
- 07/07/2013
## Description

<p>Recently I have done some research about HTML local storage and the offline functionality for websites in preparation for a project. All of the content discussed in this&nbsp;sample was tested in Google Chrome 27, Firefox 22, and Internet Explorer 10.</p>
<p>This sample will only show some aspects. For more information and examples have a look at the literature listed beneath.</p>
<h2>Local Storage</h2>
<p>In the past native applications had some capabilities which were missing in the web area. One of this capabilities was to store data on the client. A solution for this problem was the usage of cookies. This solution introduced some problems, especially if
 you have security in mind. An alternative proposed by the World Wide Web Consortium (W3C) is called Web Storage. In this section I want to discuss some of the basics of one approach coming from the Web Storage proposal: local storage. Local storage, which
 is sometimes referred to as DOM Storage, is a simple persistent key-value storage directly in the browser. An important advantage of local storage is that it is natively implemented in browsers, which means that it is available even when external plug-ins
 are not.</p>
<p><img class="mce-wp-more" title="Weiterlesen..." src="-trans.gif" alt=""></p>
<h3>Check the browser support</h3>
<p>Let us start with a simple check if local storage is available in your browser:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&nbsp;lang=<span class="js__string">&quot;en&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;charset=<span class="js__string">&quot;utf-8&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;Availability&nbsp;of&nbsp;local&nbsp;storage&lt;/title&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;window.addEventListener(<span class="js__string">'load'</span>,&nbsp;checkStorageSupport);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;checkStorageSupport()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'localstorage'</span>).innerHTML&nbsp;=&nbsp;<span class="js__string">'localStorage'</span>&nbsp;<span class="js__operator">in</span>&nbsp;window&nbsp;&amp;&amp;&nbsp;window[<span class="js__string">'localStorage'</span>]&nbsp;!==&nbsp;null&nbsp;?&nbsp;<span class="js__string">'Your&nbsp;browser&nbsp;supports&nbsp;local&nbsp;storage!'</span>&nbsp;:&nbsp;<span class="js__string">'Unfortunately&nbsp;your&nbsp;browser&nbsp;does&nbsp;not&nbsp;support&nbsp;local&nbsp;storage!'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&lt;/head&gt;&nbsp;
&nbsp;&nbsp;&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h1&gt;Browser&nbsp;support&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;id=<span class="js__string">&quot;localstorage&quot;</span>&gt;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&lt;/body&gt;&nbsp;
&lt;/html&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">First we declare an area in which we can write into if our browser supports local storage or not (line 18). In our JavaScript we subscribe first to the load event and react on it with the
<em>checkStorageSupport</em> function. It checks if local storage is available. If true it writes 'Your browser supports local storage!' to our span element. If not the message 'Unfortunately your browser does not support local storage!' will be displayed.</div>
<p>&nbsp;</p>
<p>After checking if local storage is supported we want to work with it. To demonstrate its capabilities I want to show you four things:</p>
<ul>
<li>Write a simple key-value pair to local storage </li><li>Read a simple key-value pair from local storage </li><li>Write a custom object to local storage </li><li>Read a custom object to local storage </li></ul>
<p>Before we start we should become familiar with the storage interface which is provided to us.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">interface&nbsp;Storage&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;getter&nbsp;any&nbsp;getItem(<span class="js__operator">in</span>&nbsp;DOMString&nbsp;key);&nbsp;
&nbsp;&nbsp;setter&nbsp;creator&nbsp;<span class="js__operator">void</span>&nbsp;setItem(<span class="js__operator">in</span>&nbsp;DOMString&nbsp;key,&nbsp;<span class="js__operator">in</span>&nbsp;any&nbsp;data);&nbsp;
<span class="js__brace">}</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Like shown above we have two functions to work with,
<em>getItem</em> and <em>setItem</em>. Like the name indicates with <em>getItem</em> and an appropriate key we can read a value from local storage. Writing into local storage is achieved with
<em>setItem</em>, which needs a key and a value.</div>
<p>&nbsp;</p>
<h3>Write and read a simple key-value pair to/from local storage</h3>
<p>Let us directly dive into the code for writing a key-value pair to local storage.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&nbsp;lang=<span class="js__string">&quot;en&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;charset=<span class="js__string">&quot;utf-8&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;Save&nbsp;data&nbsp;to&nbsp;local&nbsp;storage&lt;/title&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;sendData()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;key&nbsp;=&nbsp;document.getElementById(<span class="js__string">'key'</span>).value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;value&nbsp;=&nbsp;document.getElementById(<span class="js__string">'value'</span>).value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;localStorage.setItem(key,&nbsp;value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&lt;/head&gt;&nbsp;
&nbsp;&nbsp;&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;h1&gt;Save&nbsp;data&nbsp;to&nbsp;local&nbsp;storage&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;form&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;key&quot;</span>&gt;Key:&nbsp;&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;id=<span class="js__string">&quot;key&quot;</span>&nbsp;name=<span class="js__string">&quot;key&quot;</span>&nbsp;placeholder=<span class="js__string">&quot;Key&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;value&quot;</span>&gt;Value:&nbsp;&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;id=<span class="js__string">&quot;value&quot;</span>&nbsp;name=<span class="js__string">&quot;value&quot;</span>&nbsp;placeholder=<span class="js__string">&quot;Value&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;button&nbsp;type=<span class="js__string">&quot;submit&quot;</span>&nbsp;onclick=<span class="js__string">&quot;sendData()&quot;</span>&gt;Send&nbsp;data&lt;/button&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/form&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">In the HTML we define a simple form where the user can type into a key and a value. The key will be used as the storage key and the value as the storage value. In our JavaScript we first grab this two inputs and after that we save
 it into local storage with the provided <em>setItem</em> function.</div>
<p>&nbsp;</p>
<p>To check if our key-value pair is saved to local storage you can use the appropriate developer tools of your preferred browser. The following picture will show you how it will look like in Google Chrome.</p>
<p><a href="http://janatdevelopment.files.wordpress.com/2013/07/developerconsole.png"><img title="Developer Console" src="-developerconsole_thumb.png" border="0" alt="Developer Console" width="500" height="374" style="border:0px currentColor; display:inline"></a></p>
<p>There you see that I have typed <strong>Name</strong> as the key and<strong> Jan Hentschel</strong> as the value into the form.</p>
<p>After writing data to local storage we like to read it from local storage.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&nbsp;lang=<span class="js__string">&quot;en&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;charset=<span class="js__string">&quot;utf-8&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;Get&nbsp;data&nbsp;from&nbsp;local&nbsp;storage&lt;/title&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;getData()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;key&nbsp;=&nbsp;document.getElementById(<span class="js__string">'reqkey'</span>).value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;value&nbsp;=&nbsp;localStorage.getItem(key);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'requestedValue'</span>).innerHTML&nbsp;=&nbsp;value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&lt;/head&gt;&nbsp;
&nbsp;&nbsp;&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;h1&gt;Get&nbsp;data&nbsp;from&nbsp;local&nbsp;storage&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;reqkey&quot;</span>&gt;Requested&nbsp;key:&nbsp;&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;id=<span class="js__string">&quot;reqkey&quot;</span>&nbsp;name=<span class="js__string">&quot;reqkey&quot;</span>&nbsp;placeholder=<span class="js__string">&quot;Requested&nbsp;key&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;button&nbsp;type=<span class="js__string">&quot;submit&quot;</span>&nbsp;onclick=<span class="js__string">&quot;getData()&quot;</span>&gt;Get&nbsp;data&lt;/button&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&gt;Requested&nbsp;value:&nbsp;&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;id=<span class="js__string">&quot;requestedValue&quot;</span>&gt;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">What happens in this snippet? In our HTML we first define an area where the user can type in the key he wants to request (lines 20 and 21). On our submit button we will react on the click event which will call the JavaScript to
 read data from local storage. To display the retrieved value we define another area where we will output the value.<br>
The JavaScript to retrieve the value is pretty simple. First we retrieve the key from the input and with the
<em>getItem</em> function we read the value from the storage. After we have the value we write it to our output area.</div>
<p>&nbsp;</p>
<p>We have now seen how to work with simple key-value pairs. Now we come to something more complex, working with custom objects.</p>
<h3>Write and read a custom object to/from local storage</h3>
<p>Writing a custom object to local storage is similar to writing a simple key-value pair to it, but there is a small difference. In this example we want to write an address object to local storage. This object contains the street, the street number, and the
 city of a person. Let us have a look at the code.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&nbsp;lang=<span class="js__string">&quot;en&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;charset=<span class="js__string">&quot;utf-8&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;Save&nbsp;a&nbsp;custom&nbsp;object&nbsp;to&nbsp;local&nbsp;storage&lt;/title&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;address&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;street:&nbsp;<span class="js__object">String</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;number:&nbsp;<span class="js__object">Number</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;city:&nbsp;<span class="js__object">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;saveCustomObject()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;street&nbsp;=&nbsp;document.getElementById(<span class="js__string">'street'</span>).value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;number&nbsp;=&nbsp;<span class="js__object">Number</span>(document.getElementById(<span class="js__string">'number'</span>).value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;city&nbsp;=&nbsp;document.getElementById(<span class="js__string">'city'</span>).value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;address.street&nbsp;=&nbsp;street;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;address.number&nbsp;=&nbsp;number;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;address.city&nbsp;=&nbsp;city;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;localStorage.setItem(<span class="js__string">'address'</span>,&nbsp;JSON.stringify(address));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&lt;/head&gt;&nbsp;
&nbsp;&nbsp;&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;h1&gt;Save&nbsp;a&nbsp;custom&nbsp;object&nbsp;to&nbsp;local&nbsp;storage&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;form&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;street&quot;</span>&gt;Street:&nbsp;&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;id=<span class="js__string">&quot;street&quot;</span>&nbsp;name=<span class="js__string">&quot;street&quot;</span>&nbsp;placeholder=<span class="js__string">&quot;Street&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;number&quot;</span>&gt;<span class="js__object">Number</span>:&nbsp;&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;id=<span class="js__string">&quot;number&quot;</span>&nbsp;name=<span class="js__string">&quot;number&quot;</span>&nbsp;placeholder=<span class="js__string">&quot;Number&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&nbsp;<span class="js__statement">for</span>=<span class="js__string">&quot;city&quot;</span>&gt;City:&nbsp;&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;id=<span class="js__string">&quot;city&quot;</span>&nbsp;name=<span class="js__string">&quot;city&quot;</span>&nbsp;placeholder=<span class="js__string">&quot;City&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;button&nbsp;type=<span class="js__string">&quot;submit&quot;</span>&nbsp;onclick=<span class="js__string">&quot;saveCustomObject()&quot;</span>&gt;Save&nbsp;custom&nbsp;object&lt;/button&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/form&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Like said, we have an address which contains a street, a street number, and a city. With respect to that we define our HTML which contains three inputs and a submit button. In our JavaScript we define a simple address object at
 the beginning. The goal now is to save this object as JSON to our local storage. To achieve that we first retrieve our three input values and then assign them to our object. At last we use the
<em>setItem</em> function to write it to local storage. Notice that we use the <em>
JSON.stringify</em> function to pass the object as JSON to local storage.</div>
<p>&nbsp;</p>
<p>If all works well we will see the following in the Google Chrome developer console.</p>
<p><a href="http://janatdevelopment.files.wordpress.com/2013/07/writecustomobject.png"><img title="Write custom object" src="-writecustomobject_thumb.png" border="0" alt="Write custom object" width="674" height="280" style="border:0px currentColor; display:inline"></a></p>
<p>Now it is time to get that data back from local storage. The code looks like the following.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&nbsp;lang=<span class="js__string">&quot;en&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;charset=<span class="js__string">&quot;utf-8&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;Get&nbsp;custom&nbsp;object&nbsp;from&nbsp;local&nbsp;storage&lt;/title&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;address&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;street:&nbsp;<span class="js__object">String</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;number:&nbsp;<span class="js__object">Number</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;city:&nbsp;<span class="js__object">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;getCustomObject()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;v&nbsp;=&nbsp;localStorage.getItem(<span class="js__string">'address'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;address&nbsp;=&nbsp;JSON.parse(v);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;street&nbsp;=&nbsp;address.street;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;number&nbsp;=&nbsp;address.number;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;city&nbsp;=&nbsp;address.city;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'requestedStreet'</span>).innerHTML&nbsp;=&nbsp;street;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'requestedNumber'</span>).innerHTML&nbsp;=&nbsp;number;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'requestedCity'</span>).innerHTML&nbsp;=&nbsp;city;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&lt;/head&gt;&nbsp;
&nbsp;&nbsp;&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;h1&gt;Get&nbsp;custom&nbsp;object&nbsp;from&nbsp;local&nbsp;storage&lt;/h1&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;button&nbsp;onclick=<span class="js__string">&quot;getCustomObject()&quot;</span>&gt;Get&nbsp;custom&nbsp;object&lt;/button&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&gt;Street:&nbsp;&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;id=<span class="js__string">&quot;requestedStreet&quot;</span>&gt;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&gt;<span class="js__object">Number</span>:&nbsp;&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;id=<span class="js__string">&quot;requestedNumber&quot;</span>&gt;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;label&gt;City:&nbsp;&lt;/label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;id=<span class="js__string">&quot;requestedCity&quot;</span>&gt;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Similar to the other snippets we first define our HTML. The only things we need is a button the user can interact with and an area where we can write our output to. In our JavaScript we also have our address object from the last
 snippet. Reading a custom object is similar to reading a simple key-value pair, but remember that we have stored our object as JSON. To work with that JSON we use the
<em>JSON.parse</em> function on our retrieved value and save this to our address object. After the assignment is done we write the output to the appropriate output area.</div>
<p>&nbsp;</p>
<h3>Summary</h3>
<p>We have covered a lot of ground in the first part of this article. Let me summarize what we have done</p>
<ol>
<li>We have checked if our browser support local storage </li><li>We have written a simple key-value pair to local storage </li><li>We retrieved this simple key-value pair from local storage </li><li>We stored a custom address object to local storage </li><li>We retrieved our custom object from local storage </li></ol>
<p>This is just a starting point for working with local storage. Some things like error handling and reacting on storage events are missing. Also we have not talked about quotas. If you are interested in that I can highly recommend that you check the additional
 literature provided at the end of this article.</p>
<h2>Offline functionality</h2>
<p>Working with local storage is just one part if you want to prepare a website for offline functionality. You also have to provide an offline experience for the user. That means your site should be available even if the user is not connected to a network.
 A common scenario for that is that your user is working on your site during a long train travel. If you have ever travelled through Germany by train, you will know what I mean. There are some regions where you are not connected to a network. A simple solution
 for taking your site offline is the cache manifest. For this approach you will only need to declare a simple file with the resources which should be cached for the user. How does a cache manifest look like? For our scenario I have declared a small one.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">CACHE&nbsp;MANIFEST&nbsp;
&nbsp;&nbsp;
/index.html&nbsp;
/data.js&nbsp;
/update.html&nbsp;
/app.css</pre>
</div>
</div>
</div>
<div class="endscriptcode">A cache manifest file start with a simple <strong>CACHE MANIFEST</strong> line. In the rest of the file you declare the files which should be cached. In this case we have two HTML, one JavaScript, and one CSS file. How can we connect
 this file with our application? Nothing simple as that.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&nbsp;lang=<span class="js__string">&quot;en&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;manifest=<span class="js__string">&quot;/cache.manifest&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;...&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">The only thing you need to declare is the <em>manifest</em> attribute on the
<em>html</em> tag. The attribute takes the path to our manifest file as the value.</div>
</div>
<p>&nbsp;</p>
<h3>Summary</h3>
<p>Using a cache manifest is a simple way to take your website offline. I have to admit that I had some problems with caching websites in Google Chrome. Even if I clear the cache the source of the site was not refreshed. It needs some patience, but at the end
 it worked.<br>
One thing we have not covered it to check if the user is offline or online. I have not talked about this, because there is no solution which will work in every browser. The only browser where the sample worked was Internet Explorer, but IE does not implement
 this functionality like recommended by the W3C. To react on an online or offline event is currently a hard task and we have to wait if this will change in the future.</p>
<h2>Summary</h2>
<p>In this sample we have talked about working with local storage and how to use a cache manifest.</p>
<h2>Literature</h2>
<p>For more information about local storage and offline functionality have a look at the following sites.</p>
<ul>
<li><a href="http://www.w3.org/TR/webstorage/">W3C - Web Storage</a> </li><li><a href="http://diveintohtml5.info/storage.html">The past, present &amp; future of local storage for web applications</a>
</li><li><a href="http://diveintohtml5.info/offline.html">Let's take this offline</a> </li></ul>
