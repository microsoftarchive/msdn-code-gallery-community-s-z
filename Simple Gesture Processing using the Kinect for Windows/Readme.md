# Simple Gesture Processing using the Kinect for Windows
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Kinect SDK
## Topics
- Gestures
- Augmented Reality
## Updated
- 09/14/2012
## Description

<h1>Introduction</h1>
<p>Hi everyone. &nbsp;This sample will show you the basic components of a gesture processing system for the Microsoft Kinect for Windows. &nbsp;Gesture processing is one of the most powerful abiliities of an augmented reality application and the Kinect makes
 processing gestures straightforward. &nbsp;This sample is very rudimentary, but it demonstrates the basic gesture processing pipeline that you would have to implement in a real world application. &nbsp;In this case, the application is a simple Kinect controller
 for PowerPoint applications using keyboard shortcuts to control the PowerPoint application. &nbsp;Along the way, it also demonstrates some other useful concepts, like how to draw a skeleton from the Kinect depth stream. &nbsp;I hope you find this sample useful.
 &nbsp;Please leave any feedback or questions that you may have.</p>
<h1><span>Building the Sample</span></h1>
<p><span>To build this sample, you will need the Kinect SDK (Software Development Kit), which you can get&nbsp;<a href="http://www.microsoft.com/en-us/kinectforwindows/develop/developer-downloads.aspx">here</a>. I would suggest downloading and installing both
 the SDK and the Kinect Toolkit, because the toolkit contains lots of great code examples for the SDK, and also contains the KinectExplorer, which is a great application to use to calibrate your Kinect for the space that you plan to test within.</span></p>
<p><span>Once you have gathered up everything you need,&nbsp;install the Kinect SDK and Toolkit onto the computer.&nbsp; Also, be sure you have&nbsp;a Kinect device on the computer.</span></p>
<p><span>One tip about installing the Kinect. Plug it into a different USB hub than your mouse and keyboard if possible. For instance, if they are plugged into the back of your computer, try plugging the Kinect into the front of the computer, which is usually
 on a diferent hub. The Kinect is a USB bandwidth hog, and will work better on its own hub.</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample builds on the <a href="http://code.msdn.microsoft.com/Beginning-Kinect-for-a198d400">
Beginning Kinect for Windows Programming</a> sample. &nbsp;If you have not looked at that sample AND you are not familiar with Kinect for Windows programming, I would recommend that you start there first before tackling this sample. &nbsp;This sample assumes
 that you already have a Kinect test environment set up with all of the tools and technologies installed. &nbsp;If you do not have that, the previous sample will also help you with that. &nbsp;</p>
<p>When you are ready to proceed with this sample, open up the source code file that is attached and take a look at the gesture.cs file within the GestureFramework project. &nbsp;This simple gesture framework is based upon the relationships of skeletal joints
 to each other over some period of time. &nbsp;The enumeration JointRelationship describes the possible relationships of joints that are supported by the framework. &nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">    public enum JointRelationship
    {
        None,
        Above,
        Below,
        LeftOf,
        RightOf,
        AboveAndRight,
        BelowAndRight,
        AboveAndLeft,
        BelowAndLeft
    }
</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">enum</span>&nbsp;JointRelationship&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;None,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Above,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Below,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LeftOf,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RightOf,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AboveAndRight,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BelowAndRight,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AboveAndLeft,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BelowAndLeft&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>The framework has two major class hierarchies. &nbsp;One is a static description of the gestures, and the other is a really simple state engine that examines incoming skeletal information from the Kinect and tries to discern the relationships between joints
 that it is interested in using the static model. &nbsp;The figure below shows the relationships between the major classes in the framework.</p>
<p><img id="66154" src="66154-logical%20framework%20design.png" alt="" width="414" height="292">&nbsp;</p>
<p>Here are the descriptions of the major classes in the hierarchy:</p>
<p><strong>GestureComponent</strong> -Describes a single relationship between two joints. &nbsp; The relationship contains only two joints and has two temporal parts; a beginning relationship and an ending relationship.</p>
<p><strong>Gesture</strong> - Essentially this is a list of type <strong>GestureComponents
</strong>&nbsp;with a unique identifier and a description.</p>
<p><strong>GestureMap</strong> - Contains all of the utility functions to load a set of gestures from an XML file and manage their lifecycle.</p>
<p><strong>GestureComponentState</strong>&nbsp;- Tracks the state of the relationships for a GestureComponent.</p>
<p><strong>GestureState</strong> - Manages the state model for a set of GestureComponents and reports on the state. &nbsp;This class in our application also maps the keycode for the PowerPoint application to the gesture model, although this is probably sub-optimal
 design.</p>
<p><strong>GestureMapState</strong> - Rolls up the current state of all gestures and is the primary interface of the application into the gesture state model.</p>
<p>If you look through the above classes, you will see that there is absolutely no magic or rocket science inside of them. &nbsp;The gesture recognition that they provide is very primitive, but they provide a platform onto which you could build a much more
 sophisticated model if you desire.</p>
<p>&nbsp;</p>
<p>Turning to the application, We can see that in addition to the existing private variables from the orginal Kinect sample, we have added several more, including a list of
<strong>GestureMapState</strong> objects, a pointer to an external xml file that describes our gestures, and some identifiers to indicate the user that is in control of the application at any given time.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private GestureMap _gestureMap;
private Dictionary&lt;int, GestureMapState&gt; gestureMaps;
private const string GestureFileName = &quot;gestures.xml&quot;;

public int PlayerId;
public bool PlayerInControl;</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;GestureMap&nbsp;_gestureMap;&nbsp;
<span class="cs__keyword">private</span>&nbsp;Dictionary&lt;<span class="cs__keyword">int</span>,&nbsp;GestureMapState&gt;&nbsp;gestureMaps;&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GestureFileName&nbsp;=&nbsp;<span class="cs__string">&quot;gestures.xml&quot;</span>;&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;PlayerId;&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;PlayerInControl;</pre>
</div>
</div>
</div>
<div class="endscriptcode">In the Form_Load() method, we add code to load the <strong>
GestureMap</strong> object from the xml file above the existing code to start the Kinect.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void Form1_Load(object sender, EventArgs e)
{
    // First Load the XML File that contains the application configuration
    _gestureMap = new GestureMap();
    _gestureMap.LoadGesturesFromXml(GestureFileName);
    _chooser = new KinectSensorChooser();
    _chooser.KinectChanged &#43;= ChooserSensorChanged;
    _chooser.Start();
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Form1_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;First&nbsp;Load&nbsp;the&nbsp;XML&nbsp;File&nbsp;that&nbsp;contains&nbsp;the&nbsp;application&nbsp;configuration</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_gestureMap&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;GestureMap();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_gestureMap.LoadGesturesFromXml(GestureFileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_chooser&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;KinectSensorChooser();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_chooser.KinectChanged&nbsp;&#43;=&nbsp;ChooserSensorChanged;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_chooser.Start();&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">In the SensorAllFramesReady() method, we add code to grab messages out of the
<strong>GestureMapState</strong> engine and display them in our existing textbox, and we add a handler for the Skeleton stream coming from the Kinect.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">void SensorAllFramesReady(object sender, AllFramesReadyEventArgs e)
{
        if (_gestureMap.MessagesWaiting)
        {
            foreach (var msg in _gestureMap.Messages)
            {
                rtbMessages.AppendText(msg &#43; &quot;\r&quot;);
            }
            rtbMessages.ScrollToCaret();
            _gestureMap.MessagesWaiting = false;
        }
        SensorDepthFrameReady(e);
        SensorSkeletonFrameReady(e);
        video.Image = _bitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">void</span>&nbsp;SensorAllFramesReady(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;AllFramesReadyEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_gestureMap.MessagesWaiting)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;msg&nbsp;<span class="cs__keyword">in</span>&nbsp;_gestureMap.Messages)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtbMessages.AppendText(msg&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\r&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtbMessages.ScrollToCaret();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_gestureMap.MessagesWaiting&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SensorDepthFrameReady(e);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SensorSkeletonFrameReady(e);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;video.Image&nbsp;=&nbsp;_bitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The meat of the application processing is the addition of the new SensorSkeletonFrameReady() method. &nbsp;Inside this method, we acquire any skeletons that are in viewing range of the Kinect, and we look at those skeletons
 to see if they are making any gestures that we are interested in evaluating. &nbsp;There are several checks and balances in this method to ensure that we have a good skeleton to look at. &nbsp;In a more sophisticated application, we might use the TrackingId
 from the skeleton to ensure that only one player at a time is able to make gestures, but that is a topic for another day.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">void SensorSkeletonFrameReady(AllFramesReadyEventArgs e)
{
    using (SkeletonFrame skeletonFrameData = e.OpenSkeletonFrame())
    {
        if (skeletonFrameData == null)
        {
            return;
        }

        var allSkeletons = new Skeleton[skeletonFrameData.SkeletonArrayLength];
        skeletonFrameData.CopySkeletonDataTo(allSkeletons);

        foreach (Skeleton sd in allSkeletons)
        {
            // If this skeleton is no longer being tracked, skip it
            if (sd.TrackingState != SkeletonTrackingState.Tracked)
            {
                continue;
            }

            // If there is not already a gesture state map for this skeleton, then create one
            if (!_gestureMaps.ContainsKey(sd.TrackingId))
            {
                var mapstate = new GestureMapState(_gestureMap);
                _gestureMaps.Add(sd.TrackingId, mapstate);
            }


                var keycode = _gestureMaps[sd.TrackingId].Evaluate(sd, false, _bitmap.Width, _bitmap.Height);
                GetWaitingMessages(_gestureMaps);

                if (keycode != VirtualKeyCode.NONAME)
                {
                    rtbMessages.AppendText(&quot;Gesture accepted from player &quot; &#43; sd.TrackingId &#43; &quot;\r&quot;);
                    rtbMessages.ScrollToCaret();
                    rtbMessages.AppendText(&quot;Command passed to System: &quot; &#43; keycode &#43; &quot;\r&quot;);
                    rtbMessages.ScrollToCaret();
                    InputSimulator.SimulateKeyPress(keycode);
                    _gestureMaps[sd.TrackingId].ResetAll(sd);
                }

            PlayerId = sd.TrackingId;

            if (_bitmap != null)
                _bitmap = AddSkeletonToDepthBitmap(sd, _bitmap, false);
            
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">void</span>&nbsp;SensorSkeletonFrameReady(AllFramesReadyEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SkeletonFrame&nbsp;skeletonFrameData&nbsp;=&nbsp;e.OpenSkeletonFrame())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(skeletonFrameData&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;allSkeletons&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Skeleton[skeletonFrameData.SkeletonArrayLength];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;skeletonFrameData.CopySkeletonDataTo(allSkeletons);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Skeleton&nbsp;sd&nbsp;<span class="cs__keyword">in</span>&nbsp;allSkeletons)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;If&nbsp;this&nbsp;skeleton&nbsp;is&nbsp;no&nbsp;longer&nbsp;being&nbsp;tracked,&nbsp;skip&nbsp;it</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(sd.TrackingState&nbsp;!=&nbsp;SkeletonTrackingState.Tracked)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">continue</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;If&nbsp;there&nbsp;is&nbsp;not&nbsp;already&nbsp;a&nbsp;gesture&nbsp;state&nbsp;map&nbsp;for&nbsp;this&nbsp;skeleton,&nbsp;then&nbsp;create&nbsp;one</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!_gestureMaps.ContainsKey(sd.TrackingId))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;mapstate&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;GestureMapState(_gestureMap);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_gestureMaps.Add(sd.TrackingId,&nbsp;mapstate);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;keycode&nbsp;=&nbsp;_gestureMaps[sd.TrackingId].Evaluate(sd,&nbsp;<span class="cs__keyword">false</span>,&nbsp;_bitmap.Width,&nbsp;_bitmap.Height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GetWaitingMessages(_gestureMaps);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(keycode&nbsp;!=&nbsp;VirtualKeyCode.NONAME)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtbMessages.AppendText(<span class="cs__string">&quot;Gesture&nbsp;accepted&nbsp;from&nbsp;player&nbsp;&quot;</span>&nbsp;&#43;&nbsp;sd.TrackingId&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\r&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtbMessages.ScrollToCaret();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtbMessages.AppendText(<span class="cs__string">&quot;Command&nbsp;passed&nbsp;to&nbsp;System:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;keycode&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\r&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtbMessages.ScrollToCaret();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InputSimulator.SimulateKeyPress(keycode);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_gestureMaps[sd.TrackingId].ResetAll(sd);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PlayerId&nbsp;=&nbsp;sd.TrackingId;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_bitmap&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_bitmap&nbsp;=&nbsp;AddSkeletonToDepthBitmap(sd,&nbsp;_bitmap,&nbsp;<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The last big task to address is adding the skeleton to the image on the screen so that we can see it. &nbsp;That is pretty straightforward, although it is a lot of GDI drawing code. &nbsp;Here is snippet of that code from
 the AddSkeletonToBitmap() method.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private Bitmap AddSkeletonToDepthBitmap(Skeleton skeleton, Bitmap bitmap, bool isActive)
{
    Pen pen;

    var gobject = Graphics.FromImage(bitmap);
    if(isActive)
        pen = new Pen(Color.Green, 5);
    else
    {
        pen = new Pen(Color.DeepSkyBlue, 5);
    }

    var head = CalculateJointPosition(bitmap, skeleton.Joints[JointType.Head]);
    var neck = CalculateJointPosition(bitmap, skeleton.Joints[JointType.ShoulderCenter]);
...........

   gobject.DrawEllipse(pen, new Rectangle((int)head.X - 25, (int)head.Y -25, 50, 50));
    gobject.DrawEllipse(pen, new Rectangle((int)neck.X - 5, (int)neck.Y, 10, 10));
    gobject.DrawLine(pen, head.X, head.Y &#43; 25, neck.X, neck.Y);

...........

}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;Bitmap&nbsp;AddSkeletonToDepthBitmap(Skeleton&nbsp;skeleton,&nbsp;Bitmap&nbsp;bitmap,&nbsp;<span class="cs__keyword">bool</span>&nbsp;isActive)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Pen&nbsp;pen;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;gobject&nbsp;=&nbsp;Graphics.FromImage(bitmap);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(isActive)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pen&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Pen(Color.Green,&nbsp;<span class="cs__number">5</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pen&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Pen(Color.DeepSkyBlue,&nbsp;<span class="cs__number">5</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;head&nbsp;=&nbsp;CalculateJointPosition(bitmap,&nbsp;skeleton.Joints[JointType.Head]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;neck&nbsp;=&nbsp;CalculateJointPosition(bitmap,&nbsp;skeleton.Joints[JointType.ShoulderCenter]);&nbsp;
...........&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;gobject.DrawEllipse(pen,&nbsp;<span class="cs__keyword">new</span>&nbsp;Rectangle((<span class="cs__keyword">int</span>)head.X&nbsp;-&nbsp;<span class="cs__number">25</span>,&nbsp;(<span class="cs__keyword">int</span>)head.Y&nbsp;-<span class="cs__number">25</span>,&nbsp;<span class="cs__number">50</span>,&nbsp;<span class="cs__number">50</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;gobject.DrawEllipse(pen,&nbsp;<span class="cs__keyword">new</span>&nbsp;Rectangle((<span class="cs__keyword">int</span>)neck.X&nbsp;-&nbsp;<span class="cs__number">5</span>,&nbsp;(<span class="cs__keyword">int</span>)neck.Y,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">10</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;gobject.DrawLine(pen,&nbsp;head.X,&nbsp;head.Y&nbsp;&#43;&nbsp;<span class="cs__number">25</span>,&nbsp;neck.X,&nbsp;neck.Y);&nbsp;
&nbsp;
...........&nbsp;
&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;You might notice that there is also a utility method CalculateJointPosition() in the code. &nbsp;That just normalized the arbitrary joint locations in x,y,z coordinate space to the size dimensions of the bitmap.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Now, in order to run the program, we need an XML file that describes the gestures that we want to evaluate. &nbsp;The sample XML looks like this:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Gestures GestureResetTimeout=&quot;500&quot;&gt;
    &lt;Gesture Description=&quot;Previous Bullet&quot; MaxExecutionTime=&quot;1000&quot; MappedKeyCode=&quot;PRIOR&quot;&gt;
        &lt;GestureComponent FirstJoint=&quot;WristLeft&quot; SecondJoint=&quot;ShoulderLeft&quot; EndingRelationship=&quot;BelowAndLeft&quot; BeginningRelationship=&quot;AboveAndLeft&quot; /&gt;
    &lt;/Gesture&gt;
    &lt;Gesture Description=&quot;Next Bullet&quot; MaxExecutionTime=&quot;1000&quot; MappedKeyCode=&quot;NEXT&quot;&gt;
        &lt;GestureComponent FirstJoint=&quot;WristRight&quot; SecondJoint=&quot;ShoulderRight&quot; EndingRelationship=&quot;BelowAndRight&quot; BeginningRelationship=&quot;AboveAndRight&quot; /&gt;
    &lt;/Gesture&gt;
&lt;/Gestures&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Gestures</span>&nbsp;<span class="xml__attr_name">GestureResetTimeout</span>=<span class="xml__attr_value">&quot;500&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Gesture</span>&nbsp;<span class="xml__attr_name">Description</span>=<span class="xml__attr_value">&quot;Previous&nbsp;Bullet&quot;</span>&nbsp;<span class="xml__attr_name">MaxExecutionTime</span>=<span class="xml__attr_value">&quot;1000&quot;</span>&nbsp;<span class="xml__attr_name">MappedKeyCode</span>=<span class="xml__attr_value">&quot;PRIOR&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;GestureComponent</span>&nbsp;<span class="xml__attr_name">FirstJoint</span>=<span class="xml__attr_value">&quot;WristLeft&quot;</span>&nbsp;<span class="xml__attr_name">SecondJoint</span>=<span class="xml__attr_value">&quot;ShoulderLeft&quot;</span>&nbsp;<span class="xml__attr_name">EndingRelationship</span>=<span class="xml__attr_value">&quot;BelowAndLeft&quot;</span>&nbsp;<span class="xml__attr_name">BeginningRelationship</span>=<span class="xml__attr_value">&quot;AboveAndLeft&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Gesture&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Gesture</span>&nbsp;<span class="xml__attr_name">Description</span>=<span class="xml__attr_value">&quot;Next&nbsp;Bullet&quot;</span>&nbsp;<span class="xml__attr_name">MaxExecutionTime</span>=<span class="xml__attr_value">&quot;1000&quot;</span>&nbsp;<span class="xml__attr_name">MappedKeyCode</span>=<span class="xml__attr_value">&quot;NEXT&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;GestureComponent</span>&nbsp;<span class="xml__attr_name">FirstJoint</span>=<span class="xml__attr_value">&quot;WristRight&quot;</span>&nbsp;<span class="xml__attr_name">SecondJoint</span>=<span class="xml__attr_value">&quot;ShoulderRight&quot;</span>&nbsp;<span class="xml__attr_name">EndingRelationship</span>=<span class="xml__attr_value">&quot;BelowAndRight&quot;</span>&nbsp;<span class="xml__attr_name">BeginningRelationship</span>=<span class="xml__attr_value">&quot;AboveAndRight&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Gesture&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Gestures&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">With all of this in place, we can execute the sample code and we should see something like this:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="66157" src="66157-capture.png" alt="" width="818" height="656"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Now, if you start this program and put it in the background, and then you start a PowerPoint slide presentation and put it in presentation mode, you will see that when you raise and lower your right hand above and below your shoulder
 as defined in the xml file, the presentation advances one slide. &nbsp;Likewise, if you raise and lower your left hand, the presentation goes back one slide. &nbsp;Pretty cool, huh? &nbsp;If you put the programs side by side, you can actually watch the gestures
 being processed by the application in the text window.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">I hope you enjoy this sample. &nbsp;Please contact me with any questions or issues that you might have and have fun coding for the Kinect.</div>
</div>
</div>
</div>
</div>
<p></p>
