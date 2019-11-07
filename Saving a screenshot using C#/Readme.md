# Saving a screenshot using C#
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- Graphics
- C#
- Console
- Image
- screenshot
- Bitmap
- Image Software
## Topics
- Graphics
- Image
- Console Window
- Bitmap
## Updated
- 09/09/2014
## Description

<h2>Introduction</h2>
<p>This article explains the entire scenario in creating the image that contains the screen content, like the windows and other details on the screen. No timer is set in this, each time the application will run, it will save the image inside your Documents
 folder where you can access it.</p>
<h2>Background</h2>
<p>Today I saw the article from a fellow CodeProject user, who tried his best to teach us how to save the screen shot from the screen. But it contained a few bugs and it was not much efficient since most of the part of the article was missing and he had not
 shown the code to the users.</p>
<h2>Assemblies Required</h2>
<p>This project, like all others require some assemblies, to include them to your project you make a reference to the Namespaces, you can use the Add Reference dialog from the Visual Studio to do so (I am not sure about other IDEs).</p>
<p>Required namespaces to be called for this project are as</p>
<pre id="pre0"><span class="code-keyword"></span><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden">using System.Drawing;
using System.IO;
using System.Windows.Forms;</pre>
<div class="preview">
<pre class="js">using&nbsp;System.Drawing;&nbsp;
using&nbsp;System.IO;&nbsp;
using&nbsp;System.Windows.Forms;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</pre>
<h4>System.Drawing</h4>
<p>This namespace is required for the Graphics, Bitmap etc. Without this they won't work and you will get an error by the IntelliSense saying this is not found.</p>
<h4>System.IO</h4>
<p>This namespace is required to save the (image) File. As the name states it is a namespace for the Input/Output commands. Saving, deleting files inside the file system is done using this!</p>
<p>The remaining code is just a simple Console application to check for the details on the screen and convert them to the Graphics to save inside a PNG file.&nbsp;</p>
<h2>Using the code</h2>
<p>The code for the project is as following,&nbsp;</p>
<pre id="pre1"><span class="code-keyword"></span></pre>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Test_Application_C_Sharp
{
    class Program
    {
        // a method to pause the console.
        // not a part of this project!
        public static void pause()
        {
            Console.Read();
        }

        static void Main(string[] args)
        {
            // Start the process...
            Console.WriteLine(&quot;Initializing the variables...&quot;);
            Console.WriteLine();
            Bitmap memoryImage;
            memoryImage = new Bitmap(1000, 900);
            Size s = new Size(memoryImage.Width, memoryImage.Height);

            // Create graphics
            Console.WriteLine(&quot;Creating Graphics...&quot;);
            Console.WriteLine();
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);

            // Copy data from screen
            Console.WriteLine(&quot;Copying data from screen...&quot;);
            Console.WriteLine();
            memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);

            //That's it! Save the image in the directory and this will work like charm.
            string str = &quot;&quot;;
            try
            {
                str = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) &#43;
                      @&quot;\Screenshot.png&quot;);
            }
            catch (Exception er)
            {
                Console.WriteLine(&quot;Sorry, there was an error: &quot; &#43; er.Message);
                Console.WriteLine();
            }

            // Save it!
            Console.WriteLine(&quot;Saving the image...&quot;);
            memoryImage.Save(str);

            // Write the message,
            Console.WriteLine(&quot;Picture has been saved...&quot;);
            Console.WriteLine();
            // Pause the program to show the message.
            Program.pause();
        }
    }
}
</pre>
<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;System.Collections.Generic;&nbsp;
using&nbsp;System.Linq;&nbsp;
using&nbsp;System.Text;&nbsp;
using&nbsp;System.Threading.Tasks;&nbsp;
using&nbsp;System.Drawing;&nbsp;
using&nbsp;System.IO;&nbsp;
&nbsp;
namespace&nbsp;Test_Application_C_Sharp&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;class&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;a&nbsp;method&nbsp;to&nbsp;pause&nbsp;the&nbsp;console.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;not&nbsp;a&nbsp;part&nbsp;of&nbsp;this&nbsp;project!</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;pause()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Read();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;Main(string[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Start&nbsp;the&nbsp;process...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;Initializing&nbsp;the&nbsp;variables...&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;memoryImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;memoryImage&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Bitmap(<span class="js__num">1000</span>,&nbsp;<span class="js__num">900</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Size&nbsp;s&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Size(memoryImage.Width,&nbsp;memoryImage.Height);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;graphics</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;Creating&nbsp;Graphics...&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Graphics&nbsp;memoryGraphics&nbsp;=&nbsp;Graphics.FromImage(memoryImage);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Copy&nbsp;data&nbsp;from&nbsp;screen</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;Copying&nbsp;data&nbsp;from&nbsp;screen...&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;memoryGraphics.CopyFromScreen(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;s);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//That's&nbsp;it!&nbsp;Save&nbsp;the&nbsp;image&nbsp;in&nbsp;the&nbsp;directory&nbsp;and&nbsp;this&nbsp;will&nbsp;work&nbsp;like&nbsp;charm.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;str&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str&nbsp;=&nbsp;string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@<span class="js__string">&quot;\Screenshot.png&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception&nbsp;er)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;Sorry,&nbsp;there&nbsp;was&nbsp;an&nbsp;error:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;er.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Save&nbsp;it!</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;Saving&nbsp;the&nbsp;image...&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;memoryImage.Save(str);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Write&nbsp;the&nbsp;message,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;Picture&nbsp;has&nbsp;been&nbsp;saved...&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Pause&nbsp;the&nbsp;program&nbsp;to&nbsp;show&nbsp;the&nbsp;message.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Program.pause();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>You can see that the code is really very interesting at some places.</p>
<p>You create the Graphics from the Image, that actually is a Bitmap of 1000x900 size. Once done, you take the pixels from the screen and paste them onto the graphics canvas like,&nbsp;</p>
<pre id="pre2"><span class="code-comment"></span><div class="endscriptcode">&nbsp;<div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden">// Create graphics from the Image (Bitmap)
Graphics memoryGraphics = Graphics.FromImage(memoryImage);

// Copy data from screen
memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;Create&nbsp;graphics&nbsp;from&nbsp;the&nbsp;Image&nbsp;(Bitmap)</span>&nbsp;
Graphics&nbsp;memoryGraphics&nbsp;=&nbsp;Graphics.FromImage(memoryImage);&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Copy&nbsp;data&nbsp;from&nbsp;screen</span>&nbsp;
memoryGraphics.CopyFromScreen(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;s);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</pre>
<p><em>Note: s is the Size of the Bitmap itself, see the code</em></p>
<p>I am using the size of the Bitmap image to create the graphics and then saving the number of content on the Graphics canvas.</p>
<pre id="pre3"><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden">Bitmap memoryImage;
memoryImage = new Bitmap(1000, 900);
Size s = new Size(memoryImage.Width, memoryImage.Height);</pre>
<div class="preview">
<pre class="js">Bitmap&nbsp;memoryImage;&nbsp;
memoryImage&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Bitmap(<span class="js__num">1000</span>,&nbsp;<span class="js__num">900</span>);&nbsp;
Size&nbsp;s&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Size(memoryImage.Width,&nbsp;memoryImage.Height);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</pre>
<p>Similarly, the Folder and the image name are now dynamic and will always point to your Documents folder, using the Special Folders on the .NET Framework.&nbsp;</p>
<pre id="pre4"><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden">Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) &#43; @&quot;\Screenshot.png&quot;</pre>
<div class="preview">
<pre class="js">Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)&nbsp;&#43;&nbsp;@<span class="js__string">&quot;\Screenshot.png&quot;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<span class="code-string"></span></pre>
<p>..will give you the folder, and the last string is the name of the image. That is &quot;screenshot.png&quot;.</p>
<p>After all this, you just call the Save method to save the Bitmap,&nbsp;</p>
<pre id="pre5"><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span><pre class="hidden">memoryImage.Save(str);</pre>
<div class="preview">
<pre class="js">memoryImage.Save(str);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</pre>
