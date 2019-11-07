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
<pre class="hidden">using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;

using Windows.UI;
using Windows.UI.Popups;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.UI.Xaml.Shapes;
using Windows.Devices.Input;

namespace UniversalTouchScreen
{
    // Thanks ProfessorWeb.ru site - &gt; http://professorweb.ru/my/windows8/rt-ext/level1/1_4.php   (please use Google Translate)
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private SortedSet&lt;uint&gt; setId = new SortedSet&lt;uint&gt;();

        private void gridPad_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            IList&lt;Windows.UI.Input.PointerPoint&gt; IlistPointer = e.GetIntermediatePoints(gridPad);
            int intPointerCount = IlistPointer.Count();

            byte[] rgb = new byte[3];
            (new Random()).NextBytes(rgb);
            Color color = Color.FromArgb(255, rgb[0], rgb[1], rgb[2]);

            var blnIsMouse = e.Pointer.PointerDeviceType == PointerDeviceType.Mouse;

            //Pointer saved in reversed mode ...
            for (int i = intPointerCount - 1; i &gt;= 0; i--)
            {
                Windows.UI.Input.PointerPoint pointer = IlistPointer[i];

                // User PointerId for identify sequence (line) - if needed
                setId.Add(pointer.PointerId); // Add to Set - Set Automatically does not include duplicate Id ... 

                Point point = pointer.Position;

                // Prevent adding ellipse if mouse over grid and not left pressed ...
                if (blnIsMouse &amp;&amp; !pointer.Properties.IsLeftButtonPressed) continue; 
                
                //Properties -  https://msdn.microsoft.com/en-us/library/windows.ui.input.pointerpointproperties.aspx
                //if your devise has stylus ...
                float pressure = pointer.Properties.Pressure;

                // 48 just randomly chosen value...
                // value pressure always 0.5 if not pen (stylus) ...


                // Pay attention about simulator - pressure will be very small 
                 pressure = 1; // use for simulate

                double w = 48.0 * pressure;
                double h = 48.0 * pressure;

                if (point.X &lt; w / 2.0 || point.X &gt; gridPad.ActualWidth - w / 2)
                {
                    continue;  // add ellipse only on grid
                }

                if (point.Y &lt; h / 2.0 || point.Y &gt; gridPad.ActualHeight - h / 2)
                {
                    continue; // add ellipse only on grid
                }

                var tr = new TranslateTransform();
                tr.X = point.X - gridPad.ActualWidth / 2.0;
                tr.Y = point.Y - gridPad.ActualHeight / 2.0;

                Ellipse el = new Ellipse()
                {
                    Width = w,
                    Height = h,
                    Fill = new SolidColorBrush(color),
                    RenderTransform = tr,
                    Visibility = Visibility.Visible
                };

                gridPad.Children.Add(el);

            }

            txtInfo.Text = &quot; &quot; &#43; setId.Count().ToString() &#43; &quot; lines ...&quot;;

            // base.OnPointerMoved(e); //You can see differences if uncomment this line
        }

        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            while (gridPad.Children.Count != 0) // because below removed only first occurrence
            {
                foreach (UIElement uie in gridPad.Children)
                {
                    gridPad.Children.Remove(uie);
                }
            }

            setId = new SortedSet&lt;uint&gt;();
            txtInfo.Text = &quot;0 - lines ...&quot;;

        }

    }
}

//GestureRecognizer class - &gt; https://msdn.microsoft.com/library/windows/apps/br241937
//Some interesting idea   - &gt; https://software.intel.com/en-us/articles/mixing-stylus-and-touch-input-on-windows-8
</pre>
<pre class="hidden">&lt;Page
    x:Class=&quot;UniversalTouchScreen.MainPage&quot;
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    xmlns:local=&quot;using:UniversalTouchScreen&quot;
    xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
    xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
    mc:Ignorable=&quot;d&quot;  &gt;

    &lt;Grid Background=&quot;{ThemeResource ApplicationPageBackgroundThemeBrush}&quot;&gt;
        &lt;Grid.ColumnDefinitions&gt;
            &lt;ColumnDefinition /&gt;
            &lt;ColumnDefinition /&gt;
        &lt;/Grid.ColumnDefinitions&gt;
        &lt;Grid.RowDefinitions&gt;
            &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
            &lt;RowDefinition Height=&quot;*&quot;/&gt;
            &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
            &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
        &lt;/Grid.RowDefinitions&gt;


        &lt;Button x:Name=&quot;btnClearAll&quot;  Margin=&quot;12,0&quot; Grid.Row=&quot;0&quot; Grid.ColumnSpan=&quot;2&quot; VerticalAlignment=&quot;Top&quot; HorizontalAlignment=&quot;Stretch&quot; Content=&quot;Clear All&quot; Click=&quot;btnClearAll_Click&quot;  /&gt;
       
        &lt;Grid
            Name=&quot;gridPad&quot; Grid.ColumnSpan=&quot;2&quot; Grid.Row=&quot;1&quot; Margin=&quot;10&quot; Background=&quot;#FFEAE9E9&quot;  PointerMoved=&quot;gridPad_PointerMoved&quot; /&gt;
        &lt;TextBlock x:Name=&quot;txtInfo&quot; Text=&quot;MultiTouch &quot;  Margin=&quot;10,0,12,0&quot; Grid.Row=&quot;2&quot; Grid.ColumnSpan=&quot;2&quot; /&gt;

    &lt;/Grid&gt;
&lt;/Page&gt;
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Runtime.InteropServices.WindowsRuntime;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Windows.Input;&nbsp;
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
