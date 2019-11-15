# Thread.Sleep vs. Task.Delay
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C# Language
## Topics
- Threads
- Task Parallelism
## Updated
- 05/19/2014
## Description

<div align="justify">We use both Thread.Sleep() and Task.Delay() to suspend the execution of a program for some given time. But are we actually suspending the execution? What is the difference between these two? How to abort from a Sleeping thread or from a
 delaying task. Those are some of the questions I believe most of us have. Hopefully I am trying to answer all the questions above.<br>
<br>
</div>
<div align="justify">Let&rsquo;s go by an example. I have a very simple windows forms application which has the following form.<br>
<br>
</div>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="margin-left:auto; margin-right:auto; text-align:center">
<tbody>
<tr>
<td style="text-align:center"><a href="http://lh4.ggpht.com/-b5p0IwY4RCA/UnCA0I5nD-I/AAAAAAAAB5Y/99lZSo0VSBM/s1600-h/pic1242.jpg" style="margin-left:auto; margin-right:auto"><img title="pic1" src="http://lh5.ggpht.com/-1TD-fBa6aBI/UnCA02RRb8I/AAAAAAAAB5g/LOEhntVDvPs/pic1_thumb235.jpg?imgmax=800" border="0" alt="pic1" width="320" height="273" style="border-width:0px; display:block; float:none; margin-left:auto; margin-right:auto; padding-left:0px; padding-right:0px; padding-top:0px"></a></td>
</tr>
<tr>
<td class="tr-caption" style="text-align:center">Form</td>
</tr>
</tbody>
</table>
<div align="justify">I have the following two basic helper methods and I am calling these two methods from my &ldquo;Thread Sleep&rdquo; and &ldquo;Task Delay&rdquo; button.</div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:2000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">void</span> PutThreadSleep()</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    Thread.Sleep(5000);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">&nbsp;</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">async Task PutTaskDelay()</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    await Task.Delay(5000, tokenSource.Token);</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}<span style="background-color:#f4f4f4; font-size:8pt; line-height:12pt">&nbsp;</span></pre>
<br>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">private</span> <span style="color:blue">void</span> btnThreadSleep_Click(<span style="color:blue">object</span> sender, EventArgs e)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    PutThreadSleep();</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    MessageBox.Show(<span style="color:#006080">&quot;I am back&quot;</span>);</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}<span style="background-color:#f4f4f4; font-size:8pt; line-height:12pt">&nbsp;</span></pre>
<br>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">private</span> async <span style="color:blue">void</span> btnTaskDelay_Click(<span style="color:blue">object</span> sender, EventArgs e)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    await PutTaskDelay();</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    MessageBox.Show(<span style="color:#006080">&quot;I am back&quot;</span>);</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
</div>
</div>
<div style="text-align:justify">Basically there is nothing to describe about the code up there (I am not going to explain what async and await here, you can find many articles in MSDN and one of my
<a href="http://jaliyaudagedara.blogspot.com/2012/03/whats-new-in-c-50.html" target="_blank">
previous post</a> explaining async/await). When I clicked both these buttons, the message boxes will be displayed after 5 seconds. But there are significant differences between these two ways. Let&rsquo;s find out what.<br>
<br>
</div>
<h2>Thread.Sleep()</h2>
<div style="text-align:justify">This is the classical way of suspending a execution. This method will suspend the current thread until the elapse of giving time.When you put the Thread.Sleep in the above way, there is nothing you can do to abort this except
 by waiting till the time elapses or by restarting the application. That&rsquo;s because this suspends the main thread the program is running. And because of that the UI is not responsive.<br>
<br>
</div>
<h2>Task.Delay()</h2>
<div style="text-align:justify">When comparing to Thread.Sleep(), Task.Delay() acts in a different way. Basically Task.Delay() will create a task which will complete after a time delay. This task will be running in a different thread, UI is responsive, and
 that's because Task.Delay() is not blocking the main thread.</div>
<p>&nbsp;</p>
<div align="justify">Behind the scene what is happening is there is a timer ticking till the specified time. Since there is a timer, anytime we can cancel the task delay by stopping the timer. To cancel, I am modifying the above PutTaskDelay() method as follows.</div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:2000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">CancellationTokenSource tokenSource = <span style="color:blue">new</span> CancellationTokenSource();<span style="background-color:#f4f4f4; font-size:8pt; line-height:12pt">&nbsp;</span></pre>
<br>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">async Task PutTaskDelay()</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{ </pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">   <span style="color:blue">try</span></pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">   {</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">       await Task.Delay(5000, tokenSource.Token);</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">   }</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">   <span style="color:blue">catch</span> (TaskCanceledException ex)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">   {</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">       </pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">   }</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">   <span style="color:blue">catch</span> (Exception ex)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">   { </pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">   </pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">   }</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
</div>
</div>
<div align="justify">Here when the task got cancelled, it will be throwing me a <a href="http://msdn.microsoft.com/en-us/library/system.threading.tasks.taskcanceledexception.aspx" target="_blank">
TaskCanceledException</a>.&nbsp;I am just catching the exception and suppressing it, because &nbsp;don't want to show any message about that.<br>
<br>
So in my &ldquo;Cancel Task Delay&rdquo; button click event, I am asking the task to be cancelled.</div>
<div id="codeSnippetWrapper" style="background-color:#f4f4f4; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:20px 0px 10px; max-height:2000px; overflow:auto; text-align:left; width:97.5%; border:silver 1px solid; padding:4px">
<div id="codeSnippet" style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px"><span style="color:blue">private</span> <span style="color:blue">void</span> btnCancelTaskDelay_Click(<span style="color:blue">object</span> sender, EventArgs e)</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">{</pre>
<pre style="background-color:white; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">    tokenSource.Cancel();</pre>
<pre style="background-color:#f4f4f4; color:black; direction:ltr; font-family:'Courier New',courier,monospace; font-size:8pt; line-height:12pt; margin:0em; overflow:visible; text-align:left; width:100%; border-style:none; padding:0px">}</pre>
</div>
</div>
<div align="justify">Once the task has been cancelled, the control returns immediately to the next line and message box will be shown.</div>
