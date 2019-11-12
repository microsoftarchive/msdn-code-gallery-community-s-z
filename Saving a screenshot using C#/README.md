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
<pre id="pre0"><span class="code-keyword"></span><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span>
<div class="preview">
<pre class="js">using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</pre>
<h4><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a></h4>
<p>This namespace is required for the Graphics, Bitmap etc. Without this they won't work and you will get an error by the IntelliSense saying this is not found.</p>
<h4><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a></h4>
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

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;
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
<pre id="pre2"><span class="code-comment"></span><div class="endscriptcode">&nbsp;<div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span>
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
<pre id="pre3"><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span>
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
<pre id="pre4"><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span>
<div class="preview">
<pre class="js">Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)&nbsp;&#43;&nbsp;@<span class="js__string">&quot;\Screenshot.png&quot;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<span class="code-string"></span></pre>
<p>..will give you the folder, and the last string is the name of the image. That is &quot;screenshot.png&quot;.</p>
<p>After all this, you just call the Save method to save the Bitmap,&nbsp;</p>
<pre id="pre5"><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>C#</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">csharp</span>
<div class="preview">
<pre class="js">memoryImage.Save(str);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</pre>
