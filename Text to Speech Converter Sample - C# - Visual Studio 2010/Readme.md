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
<p><span style="font-size:small; font-family:arial black,avant garde">Microsoft .NET framework provides System.Speech.Synthesis for voice synthesis.</span><em>&nbsp;</em></p>
<p><img src="23820-text_2_speech_screen.png" alt="" width="543" height="339"></p>
<h1><span style="color:#ff0000">Building the Sample</span></h1>
<p><span style="font-family:arial black,avant garde; font-size:small">You must have Visual Studio 2010 to build and run the sample.</span><em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold; color:#ff0000">Description</span></p>
<p><span style="font-size:small">To convert text to speech , which is called voice synthesis, you must include<strong> &quot;System.Speech&quot;
</strong>reference in your project. It contains functions for both speech synthesis and recognition</span></p>
<p><span style="font-size:small">After adding System.speech reference you have to use
<strong>System.Speech.Synthesis</strong> in your project which conatins various function for voice synthesis.</span></p>
<p><span style="font-size:small"><span style="text-decoration:underline"><strong><span style="color:#ff0000">Creating object of SpeechSynthesizer class.</span></strong></span>
</span></p>
<p><span style="font-size:small">The first step is to create an object of SpeechSynthesizer class (e.g. &quot;reader&quot; in my sample)</span><em>&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">SpeechSynthesizer reader = new SpeechSynthesizer();</pre>
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
<pre class="hidden"> reader.Speak(&quot;This is my first speech project&quot;);</pre>
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
<pre class="hidden"> reader.SpeakAsync(&quot;Speaking text asynchronously&quot;);</pre>
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
<pre class="hidden"> if (reader.State == SynthesizerState.Speaking)
   {
                    reader.Pause();
   }</pre>
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
<pre class="hidden"> if (reader.State == SynthesizerState.Paused)
   {
                    reader.Resume();
  }</pre>
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
<pre class="hidden">if( reader!= null )
{
     reader.Dispose();
}

</pre>
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
<pre class="hidden">using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;

namespace text_to_speech
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer reader; //declare the object
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            reader = new SpeechSynthesizer(); //create new object
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            textBox1.ScrollBars = ScrollBars.Both;
        }

        //SPEAK TEXT
        private void button1_Click(object sender, EventArgs e)
        {
            reader.Dispose();
            if (textBox1.Text != &quot;&quot;)    //if text area is not empty
            {

                reader = new SpeechSynthesizer();
                reader.SpeakAsync(textBox1.Text);
                label2.Text = &quot;SPEAKING&quot;;
                button2.Enabled = true;
                button4.Enabled = true;
                reader.SpeakCompleted &#43;= new EventHandler&lt;SpeakCompletedEventArgs&gt;(reader_SpeakCompleted);
            }
            else
            {
                MessageBox.Show(&quot;Please enter some text in the textbox&quot;, &quot;Message&quot;, MessageBoxButtons.OK);
            }
        }

        //event handler
        void reader_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            label2.Text = &quot;IDLE&quot;;
        }

        //PAUSE
        private void button2_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Speaking)
                {
                    reader.Pause();
                    label2.Text = &quot;PAUSED&quot;;
                    button3.Enabled = true;

                }
            }
        }

        //RESUME
        private void button3_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Paused)
                {
                    reader.Resume();
                    label2.Text = &quot;SPEAKING&quot;;
                }
                button3.Enabled = false;
            }
        }

        //STOP
        private void button4_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.Dispose();
                label2.Text = &quot;IDLE&quot;;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        //load data from text file button
        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //copy data from text file and load it to textbox
            textBox1.Text =  File.ReadAllText(openFileDialog1.FileName.ToString());

        }

     }
}
</pre>
<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;System.ComponentModel;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;System.Data;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;System.Drawing;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;System.Windows.Forms;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;System.Speech.Synthesis;&nbsp;<br><span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;<br>&nbsp;<br><span class="cs__keyword">namespace</span>&nbsp;text_to_speech&nbsp;<br>{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SpeechSynthesizer&nbsp;reader;&nbsp;<span class="cs__com">//declare&nbsp;the&nbsp;object</span><span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;Form1_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SpeechSynthesizer();&nbsp;<span class="cs__com">//create&nbsp;new&nbsp;object</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button2.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button3.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button4.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.ScrollBars&nbsp;=&nbsp;ScrollBars.Both;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//SPEAK&nbsp;TEXT</span><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Dispose();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(textBox1.Text&nbsp;!=&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//if&nbsp;text&nbsp;area&nbsp;is&nbsp;not&nbsp;empty</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SpeechSynthesizer();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.SpeakAsync(textBox1.Text);&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label2.Text&nbsp;=&nbsp;<span class="cs__string">&quot;SPEAKING&quot;</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button2.Enabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button4.Enabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.SpeakCompleted&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EventHandler&lt;SpeakCompletedEventArgs&gt;(reader_SpeakCompleted);&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Please&nbsp;enter&nbsp;some&nbsp;text&nbsp;in&nbsp;the&nbsp;textbox&quot;</span>,&nbsp;<span class="cs__string">&quot;Message&quot;</span>,&nbsp;MessageBoxButtons.OK);&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//event&nbsp;handler</span><span class="cs__keyword">void</span>&nbsp;reader_SpeakCompleted(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;SpeakCompletedEventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label2.Text&nbsp;=&nbsp;<span class="cs__string">&quot;IDLE&quot;</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//PAUSE</span><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;button2_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader.State&nbsp;==&nbsp;SynthesizerState.Speaking)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Pause();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label2.Text&nbsp;=&nbsp;<span class="cs__string">&quot;PAUSED&quot;</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button3.Enabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//RESUME</span><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;button3_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader.State&nbsp;==&nbsp;SynthesizerState.Paused)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Resume();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label2.Text&nbsp;=&nbsp;<span class="cs__string">&quot;SPEAKING&quot;</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button3.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//STOP</span><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;button4_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Dispose();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label2.Text&nbsp;=&nbsp;<span class="cs__string">&quot;IDLE&quot;</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button2.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button3.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;button4.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//load&nbsp;data&nbsp;from&nbsp;text&nbsp;file&nbsp;button</span><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;button5_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;openFileDialog1.ShowDialog();&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;openFileDialog1_FileOk(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;CancelEventArgs&nbsp;e)&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//copy&nbsp;data&nbsp;from&nbsp;text&nbsp;file&nbsp;and&nbsp;load&nbsp;it&nbsp;to&nbsp;textbox</span>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox1.Text&nbsp;=&nbsp;&nbsp;File.ReadAllText(openFileDialog1.FileName.ToString());&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br>}&nbsp;<br></pre>
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
