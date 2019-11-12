# Universal Touch Screen (Universal Windows C# ) - Multi Touch Drawing ...
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- universal windows app
- UWP
- windows phone 10
- multi-touch track-pad
- pen
## Topics
- C# Language Features
- universal windows app
- UWP
- windows phone 10
- multi-touch track-pad
- Lumia 950
## Updated
- 11/28/2017
## Description

<h1>Introduction</h1>
<p>Just in case,&nbsp;project works with SDK 10.0.10240</p>
<p><img id="148915" src="148915-build.png" alt="" width="320" height="170">&nbsp;&nbsp;</p>
<p>&nbsp;</p>
<p>If you have a problem with upload to WP (ask PIN) ... see&nbsp;link <a href="http://stackoverflow.com/questions/34114265/visual-studio-pin-is-required-to-establish-a-connection">
http://stackoverflow.com/questions/34114265/visual-studio-pin-is-required-to-establish-a-connection</a></p>
<p><em>Universal Windows App - Windows Phone/Store Application. Multi-touch screen example. GetIntermediatePoints, PointerDeviceType, PointerPointProperties. Show how to draw many lines with fingers. How to use the stylus, tap, mouse. Multiple input points
 (fingertips). &nbsp; How to use PointerPoint class ...&nbsp;<br>
<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Bring project, choose architecture X86, x64, ARM deploy and RUN/Debug</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Simple Application which shows how to use multiple fingertips to draw multiple lines ...</em></p>
<p><em>Below screenshot from Lumia 950XL</em></p>
<p>&nbsp;</p>
<p><span style="background-color:#ffff00">For use properties pressure please comment out (in code) line</span></p>
<p><span style="background-color:#ffff00">pressure&nbsp;=&nbsp;<span class="cs__number">1</span>;</span></p>
<p>&nbsp;</p>
<p><em><br>
</em></p>
<p><img id="148622" src="148622-lumia950xl.png" alt="" width="350" height="650"><em>&nbsp;</em></p>
<p>Screenshot's device emulator &nbsp;(using the mouse) ...</p>
<p><img id="148624" src="148624-deviceemulator.png" alt="" width="320" height="500"></p>
<p>This windows store application (Local PC)</p>
<p><img id="148625" src="148625-localpc.png" alt="" width="350" height="250"></p>
<p>&nbsp;</p>
<p><span style="font-size:small">In this example you find an answer how to use&nbsp;PointerPointProperties class,&nbsp;GetIntermediatePoints,&nbsp;It demonstrates how to using touch, mouse, and pen features. The application is written in C# and it designed
 for Windows 10 devices.&nbsp;</span></p>
<p><span style="font-size:small">The biggest advantages of touch interactions are the ability to use multiple input points (fingertips) at the same time.</span></p>
<p><span style="font-size:small">Application support Stylus Interaction (pressure propeties).</span></p>
<p><span style="font-size:small">Using Touch, Mouse, and Pen...</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>C#</span><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">xaml</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Runtime.InteropServices.WindowsRuntime.aspx" target="_blank" title="Auto generated link to System.Runtime.InteropServices.WindowsRuntime">System.Runtime.InteropServices.WindowsRuntime</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Windows.Input.aspx" target="_blank" title="Auto generated link to System.Windows.Input">System.Windows.Input</a>;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.UI;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.UI.Popups;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.Foundation;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.Foundation.Collections;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.UI.Xaml;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.UI.Xaml.Controls;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.UI.Xaml.Controls.Primitives;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.UI.Xaml.Data;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.UI.Xaml.Input;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.UI.Xaml.Media;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.UI.Xaml.Navigation;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.UI.Xaml.Shapes;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Windows.Devices.Input;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;UniversalTouchScreen&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Thanks&nbsp;ProfessorWeb.ru&nbsp;site&nbsp;-&nbsp;&gt;&nbsp;http://professorweb.ru/my/windows8/rt-ext/level1/1_4.php&nbsp;&nbsp;&nbsp;(please&nbsp;use&nbsp;Google&nbsp;Translate)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">sealed</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;MainPage&nbsp;:&nbsp;Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MainPage()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;SortedSet&lt;<span class="cs__keyword">uint</span>&gt;&nbsp;setId&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SortedSet&lt;<span class="cs__keyword">uint</span>&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;gridPad_PointerMoved(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;PointerRoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IList&lt;Windows.UI.Input.PointerPoint&gt;&nbsp;IlistPointer&nbsp;=&nbsp;e.GetIntermediatePoints(gridPad);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;intPointerCount&nbsp;=&nbsp;IlistPointer.Count();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;rgb&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[<span class="cs__number">3</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="cs__keyword">new</span>&nbsp;Random()).NextBytes(rgb);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Color&nbsp;color&nbsp;=&nbsp;Color.FromArgb(<span class="cs__number">255</span>,&nbsp;rgb[<span class="cs__number">0</span>],&nbsp;rgb[<span class="cs__number">1</span>],&nbsp;rgb[<span class="cs__number">2</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;blnIsMouse&nbsp;=&nbsp;e.Pointer.PointerDeviceType&nbsp;==&nbsp;PointerDeviceType.Mouse;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Pointer&nbsp;saved&nbsp;in&nbsp;reversed&nbsp;mode&nbsp;...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;intPointerCount&nbsp;-&nbsp;<span class="cs__number">1</span>;&nbsp;i&nbsp;&gt;=&nbsp;<span class="cs__number">0</span>;&nbsp;i--)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Windows.UI.Input.PointerPoint&nbsp;pointer&nbsp;=&nbsp;IlistPointer[i];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;User&nbsp;PointerId&nbsp;for&nbsp;identify&nbsp;sequence&nbsp;(line)&nbsp;-&nbsp;if&nbsp;needed</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;setId.Add(pointer.PointerId);&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;to&nbsp;Set&nbsp;-&nbsp;Set&nbsp;Automatically&nbsp;does&nbsp;not&nbsp;include&nbsp;duplicate&nbsp;Id&nbsp;...&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Point&nbsp;point&nbsp;=&nbsp;pointer.Position;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Prevent&nbsp;adding&nbsp;ellipse&nbsp;if&nbsp;mouse&nbsp;over&nbsp;grid&nbsp;and&nbsp;not&nbsp;left&nbsp;pressed&nbsp;...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(blnIsMouse&nbsp;&amp;&amp;&nbsp;!pointer.Properties.IsLeftButtonPressed)&nbsp;<span class="cs__keyword">continue</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Properties&nbsp;-&nbsp;&nbsp;https://msdn.microsoft.com/en-us/library/windows.ui.input.pointerpointproperties.aspx</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//if&nbsp;your&nbsp;devise&nbsp;has&nbsp;stylus&nbsp;...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">float</span>&nbsp;pressure&nbsp;=&nbsp;pointer.Properties.Pressure;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;48&nbsp;just&nbsp;randomly&nbsp;chosen&nbsp;value...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;value&nbsp;pressure&nbsp;always&nbsp;0.5&nbsp;if&nbsp;not&nbsp;pen&nbsp;(stylus)&nbsp;...</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Pay&nbsp;attention&nbsp;about&nbsp;simulator&nbsp;-&nbsp;pressure&nbsp;will&nbsp;be&nbsp;very&nbsp;small&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pressure&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;<span class="cs__com">//&nbsp;use&nbsp;for&nbsp;simulate</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;w&nbsp;=&nbsp;<span class="cs__number">48.0</span>&nbsp;*&nbsp;pressure;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;h&nbsp;=&nbsp;<span class="cs__number">48.0</span>&nbsp;*&nbsp;pressure;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(point.X&nbsp;&lt;&nbsp;w&nbsp;/&nbsp;<span class="cs__number">2.0</span>&nbsp;||&nbsp;point.X&nbsp;&gt;&nbsp;gridPad.ActualWidth&nbsp;-&nbsp;w&nbsp;/&nbsp;<span class="cs__number">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">continue</span>;&nbsp;&nbsp;<span class="cs__com">//&nbsp;add&nbsp;ellipse&nbsp;only&nbsp;on&nbsp;grid</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(point.Y&nbsp;&lt;&nbsp;h&nbsp;/&nbsp;<span class="cs__number">2.0</span>&nbsp;||&nbsp;point.Y&nbsp;&gt;&nbsp;gridPad.ActualHeight&nbsp;-&nbsp;h&nbsp;/&nbsp;<span class="cs__number">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">continue</span>;&nbsp;<span class="cs__com">//&nbsp;add&nbsp;ellipse&nbsp;only&nbsp;on&nbsp;grid</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;tr&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TranslateTransform();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tr.X&nbsp;=&nbsp;point.X&nbsp;-&nbsp;gridPad.ActualWidth&nbsp;/&nbsp;<span class="cs__number">2.0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tr.Y&nbsp;=&nbsp;point.Y&nbsp;-&nbsp;gridPad.ActualHeight&nbsp;/&nbsp;<span class="cs__number">2.0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ellipse&nbsp;el&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Ellipse()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Width&nbsp;=&nbsp;w,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Height&nbsp;=&nbsp;h,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Fill&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SolidColorBrush(color),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RenderTransform&nbsp;=&nbsp;tr,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Visibility&nbsp;=&nbsp;Visibility.Visible&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gridPad.Children.Add(el);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtInfo.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;setId.Count().ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;lines&nbsp;...&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;base.OnPointerMoved(e);&nbsp;//You&nbsp;can&nbsp;see&nbsp;differences&nbsp;if&nbsp;uncomment&nbsp;this&nbsp;line</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnClearAll_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(gridPad.Children.Count&nbsp;!=&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__com">//&nbsp;because&nbsp;below&nbsp;removed&nbsp;only&nbsp;first&nbsp;occurrence</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(UIElement&nbsp;uie&nbsp;<span class="cs__keyword">in</span>&nbsp;gridPad.Children)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gridPad.Children.Remove(uie);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;setId&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SortedSet&lt;<span class="cs__keyword">uint</span>&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtInfo.Text&nbsp;=&nbsp;<span class="cs__string">&quot;0&nbsp;-&nbsp;lines&nbsp;...&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//GestureRecognizer&nbsp;class&nbsp;-&nbsp;&gt;&nbsp;https://msdn.microsoft.com/library/windows/apps/br241937</span>&nbsp;
<span class="cs__com">//Some&nbsp;interesting&nbsp;idea&nbsp;&nbsp;&nbsp;-&nbsp;&gt;&nbsp;https://software.intel.com/en-us/articles/mixing-stylus-and-touch-input-on-windows-8</span>&nbsp;
</pre>
</div>
</div>
</div>
<h1>More Information</h1>
<p>Thanks ProfessorWeb.ru site - &gt; http://professorweb.ru/my/windows8/rt-ext/level1/1_4.php</p>
<p><em>//GestureRecognizer class - &gt; https://msdn.microsoft.com/library/windows/apps/br241937</em></p>
<p><em>//Some interesting idea &nbsp; - &gt; https://software.intel.com/en-us/articles/mixing-stylus-and-touch-input-on-windows-8</em></p>
