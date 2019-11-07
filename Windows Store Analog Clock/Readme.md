# Windows Store Analog Clock
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
- XAML
- Visual Basic .NET
- Windows Store app
## Topics
- Windows Store app
## Updated
- 12/24/2013
## Description

<h1>Introduction</h1>
<p><em>Create a Analog Clock in a windows store application</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>You can build this application with Visual Studio 2013 on a computer using Windows 8.1 as the operating system</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample uses xaml and c# to create an analog clock in a windows store application. &nbsp;Xaml allows you to vary the angle of lines when drawn on the screen.&nbsp;</em><em>I used an ellipse as the background of the clock.&nbsp;</em><em>We will draw
 3 lines for the hour, seconds, and minute hand on an analog clock. &nbsp;A rotate transform turns a line into the second, minute and hour hand. &nbsp;The transform will draw the line from the center of a circle at the angle needed to represent the time. For
 seconds and minutes multiply the value by 6 to get the angle for the clocks hand transform. &nbsp;For hours multiply the hour by 30 to get the angle needed for the hour hand transform. &nbsp; I use a dispatch timer to update angle of the hands based on the
 current time. &nbsp;The dispatch timer will fire an event every second which we use to update the angle of the clocks hand.&nbsp;</em><em>&nbsp; The clock could be improved by using a clock image instead of an ellipse. &nbsp;</em></p>
<p>Additional work would need to be done to be able to submit the app to the store. &nbsp; If ads were added you would need to give the app permission to access the internet. &nbsp;Any app that has access to the internet would require a privacy policy.</p>
<p>&nbsp;</p>
<p>Sample updated to work with windows 8.1 and vs 2013 on 12/24/2013. Also included a Visual Basic version</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span><span class="hidden">xaml</span>
<pre class="hidden">    Dim timer As New DispatcherTimer


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        timer.Interval = TimeSpan.FromSeconds(1)
        AddHandler timer.Tick, AddressOf Timer_Tick

        timer.Start()
    End Sub

    Public Sub Timer_Tick(sender As Object, e As EventArgs)
        secondHand.Angle = DateTime.Now.Second * 6
        minuteHand.Angle = DateTime.Now.Minute * 6
        hourHand.Angle = (DateTime.Now.Hour * 30) &#43; (DateTime.Now.Minute * 0.5)
    End Sub</pre>
<pre class="hidden">        DispatcherTimer timer = new DispatcherTimer();

        public MainPage()
        {
            this.InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick &#43;= timer_Tick;
            timer.Start(); 
        }
        
        void timer_Tick(object sender, object e)
        {
            secondHand.Angle = DateTime.Now.Second * 6;
            minuteHand.Angle = DateTime.Now.Minute * 6;
            hourHand.Angle = (DateTime.Now.Hour * 30) &#43; (DateTime.Now.Minute * 0.5);
        }</pre>
<pre class="hidden">   &lt;Grid Background=&quot;{StaticResource ApplicationPageBackgroundThemeBrush}&quot;&gt;
        &lt;Grid Width=&quot;300&quot; Height=&quot;300&quot;&gt;
            &lt;Ellipse Width=&quot;300&quot; Height=&quot;300&quot; Fill=&quot;Blue&quot;&gt;&lt;/Ellipse&gt;
            &lt;!-- Second  --&gt;
            &lt;Rectangle Margin=&quot;150,0,149,150&quot; Name=&quot;rectangleSecond&quot; 
        Stroke=&quot;White&quot; Height=&quot;120&quot; VerticalAlignment=&quot;Bottom&quot;&gt;
                &lt;Rectangle.RenderTransform&gt;
                    &lt;RotateTransform x:Name=&quot;secondHand&quot; CenterX=&quot;0&quot; 
                CenterY=&quot;120&quot; Angle=&quot;0&quot; /&gt;
                &lt;/Rectangle.RenderTransform&gt;
            &lt;/Rectangle&gt;
            &lt;!----&gt;
        
        &lt;!-- Minute  --&gt;
            &lt;Rectangle Margin=&quot;150,49,149,151&quot; Name=&quot;rectangleMinute&quot; 
        Stroke=&quot;LightGreen&quot;&gt;
                &lt;Rectangle.RenderTransform&gt;
                    &lt;RotateTransform x:Name=&quot;minuteHand&quot; CenterX=&quot;0&quot; 
                CenterY=&quot;100&quot; Angle=&quot;0&quot; /&gt;
                &lt;/Rectangle.RenderTransform&gt;
            &lt;/Rectangle&gt;
            &lt;!----&gt;
        
        &lt;!-- Hour  --&gt;
            &lt;Rectangle Margin=&quot;150,80,149,150&quot; Name=&quot;rectangleHour&quot; 
        Stroke=&quot;LightYellow&quot;&gt;
                &lt;Rectangle.RenderTransform&gt;
                    &lt;RotateTransform x:Name=&quot;hourHand&quot; CenterX=&quot;0&quot; 
                CenterY=&quot;70&quot; Angle=&quot;0&quot; /&gt;
                &lt;/Rectangle.RenderTransform&gt;
            &lt;/Rectangle&gt;
            &lt;!----&gt;
        
    &lt;/Grid&gt;
    &lt;/Grid&gt;</pre>
<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;timer&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DispatcherTimer&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;This&nbsp;call&nbsp;is&nbsp;required&nbsp;by&nbsp;the&nbsp;designer.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Add&nbsp;any&nbsp;initialization&nbsp;after&nbsp;the&nbsp;InitializeComponent()&nbsp;call.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer.Interval&nbsp;=&nbsp;TimeSpan.FromSeconds(<span class="visualBasic__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">AddHandler</span>&nbsp;timer.Tick,&nbsp;<span class="visualBasic__keyword">AddressOf</span>&nbsp;Timer_Tick&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer.Start()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Timer_Tick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;secondHand.Angle&nbsp;=&nbsp;DateTime.Now.Second&nbsp;*&nbsp;<span class="visualBasic__number">6</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;minuteHand.Angle&nbsp;=&nbsp;DateTime.Now.Minute&nbsp;*&nbsp;<span class="visualBasic__number">6</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hourHand.Angle&nbsp;=&nbsp;(DateTime.Now.Hour&nbsp;*&nbsp;<span class="visualBasic__number">30</span>)&nbsp;&#43;&nbsp;(DateTime.Now.Minute&nbsp;*&nbsp;<span class="visualBasic__number">0.5</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<ul>
</ul>
