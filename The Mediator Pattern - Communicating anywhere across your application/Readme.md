# The Mediator Pattern - Communicating anywhere across your application
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- Communication
- MVVM
- Messaging
- The Mediator Pattern
- Eventing
- Multi-cast
- Low Coupling
## Updated
- 09/19/2012
## Description

<h1>Introduction</h1>
<p>This project is an introduction to the <a href="http://en.wikipedia.org/wiki/Mediator_pattern">
Mediator Pattern</a>, a coding method for communicating anywhere across an application. It helps provide cross-class messaging and
<a href="http://en.wikipedia.org/wiki/Coupling_(computer_science)">low coupling</a></p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p>Just download, unblock, unzip, load and run!</p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The Mediator Pattern describes the use of a central repository where listeners are registered. When a message is sent, if there are any listeners for that token, their method delegates will be called.</p>
<p><strong>Below is an example&nbsp;of a mediator that will cover most common usages.
</strong></p>
<p>It is a basically a &quot;multi-cast&quot; eventing class, that is based on a dictionary. The key is the token, and the value is a list of method delegates that have been registered against that key/token.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        static IDictionary&lt;string, List&lt;Action&lt;object&gt;&gt;&gt; pl_dict = new Dictionary&lt;string, List&lt;Action&lt;object&gt;&gt;&gt;();

        static public void Register(string token, Action&lt;object&gt; callback)
        {
            if (!pl_dict.ContainsKey(token))
            {
                var list = new List&lt;Action&lt;object&gt;&gt;();
                list.Add(callback);
                pl_dict.Add(token, list);
            }
            else
            {
                bool found = false;
                foreach (var item in pl_dict[token])
                    if (item.Method.ToString() == callback.Method.ToString())
                        found = true;
                if (!found)
                    pl_dict[token].Add(callback);
            }
        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;IDictionary&lt;<span class="cs__keyword">string</span>,&nbsp;List&lt;Action&lt;<span class="cs__keyword">object</span>&gt;&gt;&gt;&nbsp;pl_dict&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;List&lt;Action&lt;<span class="cs__keyword">object</span>&gt;&gt;&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Register(<span class="cs__keyword">string</span>&nbsp;token,&nbsp;Action&lt;<span class="cs__keyword">object</span>&gt;&nbsp;callback)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!pl_dict.ContainsKey(token))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;list&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Action&lt;<span class="cs__keyword">object</span>&gt;&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;list.Add(callback);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pl_dict.Add(token,&nbsp;list);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;found&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;item&nbsp;<span class="cs__keyword">in</span>&nbsp;pl_dict[token])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(item.Method.ToString()&nbsp;==&nbsp;callback.Method.ToString())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;found&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!found)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pl_dict[token].Add(callback);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>This static class can be reached from anywhere in your application.&nbsp;You simply fire off a message from anywhere with the NotifyColleagues method, and any registered method delegates get executed.</p>
<p>&nbsp;</p>
<p>Below are some examples of it's use:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public MainWindow()
{
    InitializeComponent();
    Mediator.Register(&quot;Try1&quot;, MyMethod1);
    Mediator.Register(&quot;Try1&quot;, MyMethod1); // Does not get added

    Mediator.Register(&quot;Try1&quot;, MyMethod2); //Same key, different delegate

    Mediator.Register(&quot;Try1&quot;, MyMethod3);
    Mediator.Unregister(&quot;Try1&quot;, MyMethod3); //To test if unregister worked

    Mediator.Register(&quot;Try4&quot;, MyMethod4); // This key is never called
}

static void MyMethod1(object args)
{
    MessageBox.Show(&quot;MyMethod1 - &quot; &#43; args.ToString());
}

static void MyMethod2(object args)
{
    MessageBox.Show(&quot;MyMethod2 - &quot; &#43; args.ToString());
}

static void MyMethod3(object args)
{
    MessageBox.Show(&quot;MyMethod3 - &quot; &#43; args.ToString());
}

static void MyMethod4(object args)
{
    MessageBox.Show(&quot;MyMethod4 - &quot; &#43; args.ToString());
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;MainWindow()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Mediator.Register(<span class="cs__string">&quot;Try1&quot;</span>,&nbsp;MyMethod1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Mediator.Register(<span class="cs__string">&quot;Try1&quot;</span>,&nbsp;MyMethod1);&nbsp;<span class="cs__com">//&nbsp;Does&nbsp;not&nbsp;get&nbsp;added</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Mediator.Register(<span class="cs__string">&quot;Try1&quot;</span>,&nbsp;MyMethod2);&nbsp;<span class="cs__com">//Same&nbsp;key,&nbsp;different&nbsp;delegate</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Mediator.Register(<span class="cs__string">&quot;Try1&quot;</span>,&nbsp;MyMethod3);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Mediator.Unregister(<span class="cs__string">&quot;Try1&quot;</span>,&nbsp;MyMethod3);&nbsp;<span class="cs__com">//To&nbsp;test&nbsp;if&nbsp;unregister&nbsp;worked</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Mediator.Register(<span class="cs__string">&quot;Try4&quot;</span>,&nbsp;MyMethod4);&nbsp;<span class="cs__com">//&nbsp;This&nbsp;key&nbsp;is&nbsp;never&nbsp;called</span>&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;MyMethod1(<span class="cs__keyword">object</span>&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;MyMethod1&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;args.ToString());&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;MyMethod2(<span class="cs__keyword">object</span>&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;MyMethod2&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;args.ToString());&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;MyMethod3(<span class="cs__keyword">object</span>&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;MyMethod3&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;args.ToString());&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;MyMethod4(<span class="cs__keyword">object</span>&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;MyMethod4&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;args.ToString());&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">This is an extemely useful technique that will help you out of a sticky situation. A popular use is when communicating between ViewModels, in an MVVM achitecture application. When there is no VisualTree to traverse with bindings,
 this method is a quick way to send notifications between different ViewModels.</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainWindow.xaml.cs - some examples od usage</em> </li><li><em>Mediator.cs - The magic class</em> </li></ul>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img src="-anithanks1.gif" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
