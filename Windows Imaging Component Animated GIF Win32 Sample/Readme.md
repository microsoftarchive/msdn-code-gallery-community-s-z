# Windows Imaging Component Animated GIF Win32 Sample
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- Direct2D
- Windows Imaging Component (WIC)
## Topics
- Graphics
- Imaging
## Updated
- 10/17/2014
## Description

<h1>Introduction</h1>
<p>This is the Windows Imaging Component animated GIF sample from the Windows 7 SDK, updated to use Visual Studio 2012.</p>
<p>This sample demonstrates decoding each frame from a GIF file, reading the appropriate animation metadata for each frame, composing frames, and rendering the animation with Direct2D.</p>
<h1>GIF Animation Overview</h1>
<p>In order to play a gif animation, raw frames (which are compressed frames directly retrieved from the image file) and image metadata are loaded and used to compose the frames that are actually displayed in the animation loop (which we call composed frames
 in this sample). Composed frames have the same sizes as the global gif image size, while raw frames can have their own sizes.</p>
<p>At the highest level, a gif animation contains a fixed or infinite number of animationloops, in which the animation will be displayed repeatedly frame by frame; once all loops are displayed, the animation will stop and the last frame will be displayed from
 that point.</p>
<p>In each loop, first the entire composed frame will be initialized with the background color retrieved from the image metadata. The very first raw frame then will be loaded and directly overlaid onto the previous composed frame (i.e. in this case, the frame
 cleared with background color) to produce the first &nbsp;composed frame, and this frame will then be displayed for a period that equals its delay. &nbsp;For any raw frame after the first raw frame (if there are any), the composed frame will first be disposed
 based on the disposal method associated with the previous raw frame. Then the next raw frame will be loaded and overlaid onto the result (i.e. the composed frame after disposal). &nbsp;These two steps (i.e. disposing the previous frame and overlaying the current
 frame) together 'compose' the next frame to be displayed. &nbsp;The composed frame then gets displayed. &nbsp;This process continues until the last frame in a loop is reached.</p>
<p>An exception is the zero delay intermediate frames, which are frames with 0 delay associated with them. &nbsp;These frames will be used to compose the next frame, but the difference is that the composed frame will not be displayed unless it's the last frame
 in the loop (i.e. we move immediately to composing the next composed frame).</p>
<h1><span style="font-size:10px">&nbsp;</span>Building the Sample</h1>
<p><span>This sample is built for Visual Studio 2012 and the Windows 7 SDK, but will work with&nbsp;Visual Studio 2013&nbsp;and newer versions of the Windows SDK without any issues.</span></p>
<p><span>You may need to upgrade the project to the version of Visual Studio installed on your system. You can do this by opening the .sln file, right clicking on the project in the Solution Explorer, and selecting Upgrade VC&#43;&#43; Compiler and Libraries.</span></p>
<h1>Running the Sample</h1>
<p><span>After the application is launched, load an image file by using the <strong>
Open </strong>command of the <strong>File </strong>menu. Window resizing is supported. An example animated GIF image is included with the sample.</span></p>
<h1>More Information</h1>
<p><span><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ee719902(v=vs.85).aspx">Windows Imaging Component</a></span></p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/dd370990(v=vs.85).aspx"><span>Direct2D</span></a></p>
