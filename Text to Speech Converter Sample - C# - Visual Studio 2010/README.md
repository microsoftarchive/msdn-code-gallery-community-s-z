# Text to Speech Converter Sample - C# - Visual Studio 2010
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- System.Speech Namespace
## Topics
- Speech Synthesis
- Text to Speech Conversion
## Updated
- 09/11/2011
## Description

<div class="endscriptcode">&nbsp;</div>
<h1><span style="color:#ff0000">Introduction</span></h1>
<p><span style="font-size:small; font-family:arial black,avant garde">The demo below explains how to convert text to speech using C# in Visual Studio 2010 using System.Speech Library.</span></p>
<p><span style="font-size:small; font-family:arial black,avant garde">Microsoft .NET framework provides <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Speech.Synthesis.aspx" target="_blank" title="Auto generated link to System.Speech.Synthesis">System.Speech.Synthesis</a> for voice synthesis.</span><em>&nbsp;</em></p>
<p><img src="23820-text_2_speech_screen.png" alt="" width="543" height="339"></p>
<h1><span style="color:#ff0000">Building the Sample</span></h1>
<p><span style="font-family:arial black,avant garde; font-size:small">You must have Visual Studio 2010 to build and run the sample.</span><em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold; color:#ff0000">Description</span></p>
<p><span style="font-size:small">To convert text to speech , which is called voice synthesis, you must include<strong> &quot;System.Speech&quot;
</strong>reference in your project. It contains functions for both speech synthesis and recognition</span></p>
<p><span style="font-size:small">After adding System.speech reference you have to use
<strong><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Speech.Synthesis.aspx" target="_blank" title="Auto generated link to System.Speech.Synthesis">System.Speech.Synthesis</a></strong> in your project which conatins various function for voice synthesis.</span></p>
<p><span style="font-size:small"><span style="text-decoration:underline"><strong><span style="color:#ff0000">Creating object of SpeechSynthesizer class.</span></strong></span>
</span></p>
<p><span style="font-size:small">The first step is to create an object of SpeechSynthesizer class (e.g. &quot;reader&quot; in my sample)</span><em>&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">SpeechSynthesizer&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SpeechSynthesizer();</pre>
</div>
</div>
</div>
<h1><span style="text-decoration:underline"><span style="font-size:small"><strong><span style="color:#ff0000">Calling Speak() function :</span></strong></span></span><span style="font-size:small"><br>
</span></h1>
<p><span style="font-size:small"><strong><span style="color:#ff0000">&nbsp;</span></strong>The next step is to call the &quot;Speak()&quot; function by passing the text to to spoken as string.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="js">&nbsp;reader.Speak(<span class="js__string">&quot;This&nbsp;is&nbsp;my&nbsp;first&nbsp;speech&nbsp;project&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p><span style="font-size:small">The problem with the speak() function is that it is not threaded. It means that you cannot perform any other function in your windows form until the &quot;reader&quot; object has completed the speech.</span></p>
<p><span style="font-size:small">So it is better to use<strong> &quot;SpeakAsync()</strong>&quot; function. I have also used SpeakAsync() in the sample.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp">&nbsp;reader.SpeakAsync(<span class="cs__string">&quot;Speaking&nbsp;text&nbsp;asynchronously&quot;</span>);</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1><span style="text-decoration:underline"><span style="font-size:small"><strong><span style="color:#ff0000">Using Pause() and Resume() function :</span></strong></span></span><span style="font-size:small">&nbsp;</span></h1>
<p><span style="font-size:small">You can also detect the state of the &quot;reader&quot; object by using
<strong>&quot;SynthesizerState&quot;</strong> property. And using that you can also <strong>
&quot;Pause&quot;</strong> or <strong>&quot;Resume&quot;</strong> the narration.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="js"><span class="js__statement">if</span>&nbsp;(reader.State&nbsp;==&nbsp;SynthesizerState.Speaking)&nbsp;<br><span class="js__brace">{</span><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Pause();&nbsp;<br><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="js"><span class="js__statement">if</span>&nbsp;(reader.State&nbsp;==&nbsp;SynthesizerState.Paused)&nbsp;<br><span class="js__brace">{</span><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Resume();&nbsp;<br><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1><span style="text-decoration:underline"><span style="font-size:small"><strong><span style="color:#ff0000">Using Dispose() function :</span></strong></span></span><span style="font-size:small">&nbsp;</span></h1>
<p><span style="font-size:small">You can use Dispose() function to stop narration and dispose the &quot;reader&quot; object.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">if</span>(&nbsp;reader!=&nbsp;<span class="cs__keyword">null</span>&nbsp;)&nbsp;<br>{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Dispose();&nbsp;<br>}&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<p><span style="font-size:small">The are some of the basic operations. You can also change voice, volume , rate and other parameters. You can also save the spoken audio stream directly into a &quot;wave&quot; file.</span></p>
<p><span style="font-size:small">The sample also show some other features such as using event handlers to detect speech progress and display status of synthesizer.</span></p>
<p><span style="font-size:small">Below is the compelete code for speech synthesis.</span></p>
<p><strong><span style="font-size:small">COMMENTS and QUESTIONS are most welcome......HAPPY CODING!!!!</span></strong></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.ComponentModel.aspx" target="_blank" title="Auto generated link to System.ComponentModel">System.ComponentModel</a>;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Data.aspx" target="_blank" title="Auto generated link to System.Data">System.Data</a>;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Speech.Synthesis.aspx" target="_blank" title="Auto generated link to System.Speech.Synthesis">System.Speech.Synthesis</a>;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;<br>&nbsp;<br><span class="cs__keyword">namespace</span>&nbsp;text_to_speech&nbsp;<br>{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SpeechSynthesizer&nbsp;reader;&nbsp;<span class="cs__com">//declare&nbsp;the&nbsp;object</span><span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;Form1_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SpeechSynthesizer();&nbsp;<span class="cs__com">//create&nbsp;new&nbsp;object</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button2.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button3.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button4.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.ScrollBars&nbsp;=&nbsp;ScrollBars.Both;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//SPEAK&nbsp;TEXT</span><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Dispose();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(textBox1.Text&nbsp;!=&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//if&nbsp;text&nbsp;area&nbsp;is&nbsp;not&nbsp;empty</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SpeechSynthesizer();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.SpeakAsync(textBox1.Text);&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label2.Text&nbsp;=&nbsp;<span class="cs__string">&quot;SPEAKING&quot;</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button2.Enabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button4.Enabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.SpeakCompleted&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EventHandler&lt;SpeakCompletedEventArgs&gt;(reader_SpeakCompleted);&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Please&nbsp;enter&nbsp;some&nbsp;text&nbsp;in&nbsp;the&nbsp;textbox&quot;</span>,&nbsp;<span class="cs__string">&quot;Message&quot;</span>,&nbsp;MessageBoxButtons.OK);&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//event&nbsp;handler</span><span class="cs__keyword">void</span>&nbsp;reader_SpeakCompleted(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;SpeakCompletedEventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label2.Text&nbsp;=&nbsp;<span class="cs__string">&quot;IDLE&quot;</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//PAUSE</span><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;button2_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader.State&nbsp;==&nbsp;SynthesizerState.Speaking)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Pause();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label2.Text&nbsp;=&nbsp;<span class="cs__string">&quot;PAUSED&quot;</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button3.Enabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//RESUME</span><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;button3_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader.State&nbsp;==&nbsp;SynthesizerState.Paused)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Resume();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label2.Text&nbsp;=&nbsp;<span class="cs__string">&quot;SPEAKING&quot;</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button3.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//STOP</span><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;button4_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Dispose();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label2.Text&nbsp;=&nbsp;<span class="cs__string">&quot;IDLE&quot;</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button2.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button3.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button4.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//load&nbsp;data&nbsp;from&nbsp;text&nbsp;file&nbsp;button</span><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;button5_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openFileDialog1.ShowDialog();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;openFileDialog1_FileOk(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;CancelEventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//copy&nbsp;data&nbsp;from&nbsp;text&nbsp;file&nbsp;and&nbsp;load&nbsp;it&nbsp;to&nbsp;textbox</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;&nbsp;File.ReadAllText(openFileDialog1.FileName.ToString());&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>}&nbsp;<br></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<h1><span style="text-decoration:underline; font-family:arial black,avant garde"><span style="font-size:small"><strong><span style="color:#ff0000">Adding SYSTEM.SPEECH Reference</span></strong></span></span></h1>
<p><span style="text-decoration:underline"><span style="font-size:small"><strong><span style="color:#ff0000"><img src="23821-img1.png" alt=""></span></strong></span></span></p>
<p>&nbsp;</p>
<p><span style="text-decoration:underline"><span style="font-size:small"><strong><span style="color:#ff0000"><img src="23822-img2.png" alt="" width="597" height="498"><br>
</span></strong></span></span></p>
<p><span style="font-size:small"><br>
</span></p>
