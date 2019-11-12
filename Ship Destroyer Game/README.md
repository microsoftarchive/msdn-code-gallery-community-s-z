# Ship Destroyer Game
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Win32
- Windows Forms
- Visual Studio 2010
- C++
- .NET Framework
- .NET Framework 4.0
- Windows Runtime
## Topics
- Controls
- Animation
- Graphics
- User Interface
- Windows Forms
- Architecture and Design
- Image manipulation
## Updated
- 10/21/2014
## Description

<p><img id="126552" src="126552-shipdestroyercapture2.jpg" alt="" width="487" height="370"></p>
<h1>Introduction</h1>
<p><em>This is a simple game to demonstrate animation capabilities of Visual Studio 2010 Express.
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em><em>Visual Studio 2010 Express. </em></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>How does this sample solve the problem? It solves the problem perfect way.....</em></p>
<p><strong>&quot;Animation</strong> is the process of creating <a title="Motion (physics)" href="http://en.wikipedia.org/wiki/Motion_%28physics%29">
motion</a> and shape change<sup id="cite_ref-1" class="reference"><a href="http://en.wikipedia.org/wiki/Animation#cite_note-1"><span style="font-size:x-small">[</span><span style="font-size:x-small">Note 1</span><span style="font-size:x-small">]</span></a></sup>
<a title="Illusion" href="http://en.wikipedia.org/wiki/Illusion">illusion</a> by means of the rapid display of a sequence of static images that minimally differ from each other. The illusion&mdash;as in motion pictures in general&mdash;is thought to rely on
 the <a title="Phi phenomenon" href="http://en.wikipedia.org/wiki/Phi_phenomenon">
phi phenomenon</a>. <a title="Animator" href="http://en.wikipedia.org/wiki/Animator">
Animators</a> are artists who specialize in the creation of animation.</p>
<p>Animations can be <a title="Recording" href="http://en.wikipedia.org/wiki/Recording">
recorded</a> on either analogue media, such as a <a title="Flip book" href="http://en.wikipedia.org/wiki/Flip_book">
flip book</a>, <a title="Motion picture film" href="http://en.wikipedia.org/wiki/Motion_picture_film" class="mw-redirect">
motion picture film</a>, video tape, or on <a title="Digital media" href="http://en.wikipedia.org/wiki/Digital_media">
digital media</a>, including formats such as <a title="Animated GIF" href="http://en.wikipedia.org/wiki/Animated_GIF" class="mw-redirect">
animated GIF</a>, <a title="Flash animation" href="http://en.wikipedia.org/wiki/Flash_animation">
Flash animation</a> or digital video. To display it, a <a title="Digital camera" href="http://en.wikipedia.org/wiki/Digital_camera">
digital camera</a>, computer, or <a title="Image projector" href="http://en.wikipedia.org/wiki/Image_projector" class="mw-redirect">
projector</a> are used.</p>
<p>Animation creation methods include the <a title="Traditional animation" href="http://en.wikipedia.org/wiki/Traditional_animation">
traditional animation</a> creation method and those involving <a title="Stop motion animation" href="http://en.wikipedia.org/wiki/Stop_motion_animation" class="mw-redirect">
stop motion animation</a> of two and three-dimensional objects, such as <a title="Cutout animation" href="http://en.wikipedia.org/wiki/Cutout_animation">
paper cutouts</a>, <a title="Puppets" href="http://en.wikipedia.org/wiki/Puppets" class="mw-redirect">
puppets</a> and <a title="Clay animation" href="http://en.wikipedia.org/wiki/Clay_animation">
clay figures</a>. Images are displayed in a rapid succession, usually 24, 25, 30, or 60 frames per second.&quot;</p>
<p><em>&nbsp;&nbsp;Wikipedia.org</em></p>
<p>&quot;</p>
<p><strong>Computer animation</strong>, or <strong>CGI animation</strong>, is the process used for generating
<a title="Animation" href="http://en.wikipedia.org/wiki/Animation">animated images</a> by using
<a title="Computer graphics" href="http://en.wikipedia.org/wiki/Computer_graphics">
computer graphics</a>. The more general term <a title="Computer-generated imagery" href="http://en.wikipedia.org/wiki/Computer-generated_imagery">
computer-generated imagery</a> encompasses both static scenes and dynamic images while computer animation
<em>only</em> refers to moving images.</p>
<p><a title="Virtual cinematography" href="http://en.wikipedia.org/wiki/Virtual_cinematography">Modern computer animation</a> usually uses
<a title="3D computer graphics" href="http://en.wikipedia.org/wiki/3D_computer_graphics">
3D&nbsp;computer graphics</a>, although <a title="2D computer graphics" href="http://en.wikipedia.org/wiki/2D_computer_graphics">
2D&nbsp;computer graphics</a> are still used for stylistic, low bandwidth, and faster
<a title="Real-time rendering" href="http://en.wikipedia.org/wiki/Real-time_rendering">
real-time renderings</a>. Sometimes, the target of the animation is the computer itself, but sometimes the target is another
<a title="Recording medium" href="http://en.wikipedia.org/wiki/Recording_medium" class="mw-redirect">
medium</a>, such as <a title="Film" href="http://en.wikipedia.org/wiki/Film">film</a>.</p>
<p>Computer animation is essentially a digital successor to the <a title="Stop motion" href="http://en.wikipedia.org/wiki/Stop_motion">
stop motion</a> techniques used in <a title="Traditional animation" href="http://en.wikipedia.org/wiki/Traditional_animation">
traditional animation</a> with 3D models and frame-by-frame animation of 2D illustrations. Computer-generated animations are more controllable than other more physically based processes, such as constructing
<a title="Miniature effect" href="http://en.wikipedia.org/wiki/Miniature_effect">
miniatures</a> for effects shots or hiring <a title="Extra (actor)" href="http://en.wikipedia.org/wiki/Extra_%28actor%29" class="mw-redirect">
extras</a> for crowd scenes, and because it allows the creation of images that would not be feasible using any other technology. It can also allow a single graphic artist to produce such content without the use of actors, expensive set pieces, or
<a title="Theatrical property" href="http://en.wikipedia.org/wiki/Theatrical_property">
props</a>.</p>
<p>To create the illusion of movement, an image is displayed on the <a title="Computer monitor" href="http://en.wikipedia.org/wiki/Computer_monitor">
computer monitor</a> and repeatedly replaced by a new image that is similar to it, but advanced slightly in time (usually at a rate of 24 or 30 frames/second). This technique is identical to how the illusion of movement is achieved with
<a title="Television" href="http://en.wikipedia.org/wiki/Television">television</a> and
<a title="Film" href="http://en.wikipedia.org/wiki/Film">motion pictures</a>.</p>
<p>For 3D animations, objects (models) are built on the computer monitor (modeled) and 3D figures are rigged with a virtual skeleton. For 2D figure animations, separate objects (illustrations) and separate transparent layers are used with or without a
<a title="Skeletal animation" href="http://en.wikipedia.org/wiki/Skeletal_animation">
virtual skeleton</a>. Then the limbs, eyes, mouth, clothes, etc. of the figure are moved by the animator on
<a title="Key frame" href="http://en.wikipedia.org/wiki/Key_frame">key frames</a>. The differences in appearance between key frames are automatically calculated by the computer in a process known as
<a title="Inbetweening" href="http://en.wikipedia.org/wiki/Inbetweening">tweening</a> or
<a title="Morphing" href="http://en.wikipedia.org/wiki/Morphing">morphing</a>. Finally, the animation is
<a title="Rendering (computer graphics)" href="http://en.wikipedia.org/wiki/Rendering_%28computer_graphics%29">
rendered</a>.</p>
<p>For 3D animations, all frames must be rendered after the modeling is complete. For 2D vector animations, the rendering process is the key frame illustration process, while tweened frames are rendered as needed. For pre-recorded presentations, the rendered
 frames are transferred to a different format or medium, such as film or digital video. The frames may also be rendered in real time as they are presented to the end-user audience. Low bandwidth animations transmitted via the internet (e.g.&nbsp;<a title="Adobe Flash" href="http://en.wikipedia.org/wiki/Adobe_Flash">2D&nbsp;Flash</a>,
<a title="X3D" href="http://en.wikipedia.org/wiki/X3D">X3D</a>) often use software on the end-users computer to render in real time as an alternative to
<a title="Streaming media" href="http://en.wikipedia.org/wiki/Streaming_media">streaming</a> or pre-loaded high bandwidth animations.&quot;</p>
<p>Wikipedia.org</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus">Click&nbsp;#pragma&nbsp;once&nbsp;
&nbsp;
<span class="cpp__keyword">namespace</span>&nbsp;timer2&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;System;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;System::ComponentModel;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;System::Collections;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;System::Windows::Forms;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;System::Data;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;System::Drawing;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">using</span>&nbsp;<span class="cpp__keyword">namespace</span>&nbsp;System::Media;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//global&nbsp;counters&nbsp;to&nbsp;count&nbsp;destroyed&nbsp;ships&nbsp;and&nbsp;number&nbsp;of&nbsp;shots</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;ShipsDestroyed&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;Shots&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">///&nbsp;Summary&nbsp;for&nbsp;Form1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>&nbsp;ref&nbsp;<span class="cpp__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;<span class="cpp__keyword">public</span>&nbsp;System::Windows::Forms::Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Form1(<span class="cpp__keyword">void</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//TODO:&nbsp;Add&nbsp;the&nbsp;constructor&nbsp;code&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">///&nbsp;Clean&nbsp;up&nbsp;any&nbsp;resources&nbsp;being&nbsp;used.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;~Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(components)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">delete</span>&nbsp;components;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Windows::Forms::Label^&nbsp;&nbsp;label1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">protected</span>:&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Windows::Forms::Timer^&nbsp;&nbsp;timer1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Windows::Forms::PictureBox^&nbsp;&nbsp;pictureBox1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Windows::Forms::PictureBox^&nbsp;&nbsp;pictureBox2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Windows::Forms::PictureBox^&nbsp;&nbsp;pictureBox3;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::ComponentModel::BackgroundWorker^&nbsp;&nbsp;backgroundWorker1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Windows::Forms::Button^&nbsp;&nbsp;button1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Windows::Forms::PictureBox^&nbsp;&nbsp;pictureBox4;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Windows::Forms::PictureBox^&nbsp;&nbsp;pictureBox5;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Windows::Forms::Timer^&nbsp;&nbsp;timer2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Windows::Forms::Label^&nbsp;&nbsp;label2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Windows::Forms::Label^&nbsp;&nbsp;label3;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Windows::Forms::Label^&nbsp;&nbsp;label4;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Windows::Forms::Label^&nbsp;&nbsp;label5;&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::ComponentModel::IContainer^&nbsp;&nbsp;components;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">///&nbsp;Required&nbsp;designer&nbsp;variable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">///&nbsp;&lt;/summary&gt;</span><span class="cpp__preproc">&nbsp;
&nbsp;
&nbsp;
#pragma&nbsp;region&nbsp;Windows&nbsp;Form&nbsp;Designer&nbsp;generated&nbsp;code</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">///&nbsp;Required&nbsp;method&nbsp;for&nbsp;Designer&nbsp;support&nbsp;-&nbsp;do&nbsp;not&nbsp;modify</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">///&nbsp;the&nbsp;contents&nbsp;of&nbsp;this&nbsp;method&nbsp;with&nbsp;the&nbsp;code&nbsp;editor.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">void</span>&nbsp;InitializeComponent(<span class="cpp__keyword">void</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;components&nbsp;=&nbsp;(gcnew&nbsp;System::ComponentModel::Container());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System::ComponentModel::ComponentResourceManager^&nbsp;&nbsp;resources&nbsp;=&nbsp;(gcnew&nbsp;System::ComponentModel::ComponentResourceManager(Form1::<span class="cpp__keyword">typeid</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label1&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::Label());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;timer1&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::Timer(<span class="cpp__keyword">this</span>-&gt;components));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox1&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::PictureBox());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox2&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::PictureBox());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox3&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::PictureBox());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;backgroundWorker1&nbsp;=&nbsp;(gcnew&nbsp;System::ComponentModel::BackgroundWorker());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;button1&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::Button());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox4&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::PictureBox());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox5&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::PictureBox());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;timer2&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::Timer(<span class="cpp__keyword">this</span>-&gt;components));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label2&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::Label());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label3&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::Label());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label4&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::Label());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label5&nbsp;=&nbsp;(gcnew&nbsp;System::Windows::Forms::Label());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(cli::safe_cast&lt;System::ComponentModel::ISupportInitialize^&nbsp;&nbsp;&gt;(<span class="cpp__keyword">this</span>-&gt;pictureBox1))-&gt;BeginInit();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(cli::safe_cast&lt;System::ComponentModel::ISupportInitialize^&nbsp;&nbsp;&gt;(<span class="cpp__keyword">this</span>-&gt;pictureBox2))-&gt;BeginInit();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(cli::safe_cast&lt;System::ComponentModel::ISupportInitialize^&nbsp;&nbsp;&gt;(<span class="cpp__keyword">this</span>-&gt;pictureBox3))-&gt;BeginInit();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(cli::safe_cast&lt;System::ComponentModel::ISupportInitialize^&nbsp;&nbsp;&gt;(<span class="cpp__keyword">this</span>-&gt;pictureBox4))-&gt;BeginInit();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(cli::safe_cast&lt;System::ComponentModel::ISupportInitialize^&nbsp;&nbsp;&gt;(<span class="cpp__keyword">this</span>-&gt;pictureBox5))-&gt;BeginInit();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;SuspendLayout();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;label1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label1-&gt;AutoSize&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label1-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cpp__number">59</span>,&nbsp;<span class="cpp__number">50</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label1-&gt;Name&nbsp;=&nbsp;L<span class="cpp__string">&quot;label1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label1-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">13</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label1-&gt;TabIndex&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;timer1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;timer1-&gt;Tick&nbsp;&#43;=&nbsp;gcnew&nbsp;System::EventHandler(<span class="cpp__keyword">this</span>,&nbsp;&amp;Form1::Timer_Tik);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;pictureBox1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox1-&gt;Image&nbsp;=&nbsp;(cli::safe_cast&lt;System::Drawing::Image^&nbsp;&nbsp;&gt;(resources-&gt;GetObject(L<span class="cpp__string">&quot;pictureBox1.Image&quot;</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox1-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cpp__number">140</span>,&nbsp;<span class="cpp__number">102</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox1-&gt;Name&nbsp;=&nbsp;L<span class="cpp__string">&quot;pictureBox1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox1-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cpp__number">100</span>,&nbsp;<span class="cpp__number">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox1-&gt;SizeMode&nbsp;=&nbsp;System::Windows::Forms::PictureBoxSizeMode::StretchImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox1-&gt;TabIndex&nbsp;=&nbsp;<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox1-&gt;TabStop&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox1-&gt;LocationChanged&nbsp;&#43;=&nbsp;gcnew&nbsp;System::EventHandler(<span class="cpp__keyword">this</span>,&nbsp;&amp;Form1::pictureBox1_LocationChanged);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;pictureBox2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox2-&gt;Image&nbsp;=&nbsp;(cli::safe_cast&lt;System::Drawing::Image^&nbsp;&nbsp;&gt;(resources-&gt;GetObject(L<span class="cpp__string">&quot;pictureBox2.Image&quot;</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox2-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cpp__number">31</span>,&nbsp;<span class="cpp__number">90</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox2-&gt;Name&nbsp;=&nbsp;L<span class="cpp__string">&quot;pictureBox2&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox2-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cpp__number">209</span>,&nbsp;<span class="cpp__number">139</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox2-&gt;SizeMode&nbsp;=&nbsp;System::Windows::Forms::PictureBoxSizeMode::StretchImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox2-&gt;TabIndex&nbsp;=&nbsp;<span class="cpp__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox2-&gt;TabStop&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;pictureBox3</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox3-&gt;Image&nbsp;=&nbsp;(cli::safe_cast&lt;System::Drawing::Image^&nbsp;&nbsp;&gt;(resources-&gt;GetObject(L<span class="cpp__string">&quot;pictureBox3.Image&quot;</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox3-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cpp__number">700</span>,&nbsp;<span class="cpp__number">42</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox3-&gt;Name&nbsp;=&nbsp;L<span class="cpp__string">&quot;pictureBox3&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox3-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cpp__number">217</span>,&nbsp;<span class="cpp__number">208</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox3-&gt;SizeMode&nbsp;=&nbsp;System::Windows::Forms::PictureBoxSizeMode::StretchImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox3-&gt;TabIndex&nbsp;=&nbsp;<span class="cpp__number">3</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox3-&gt;TabStop&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox3-&gt;Visible&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;backgroundWorker1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;backgroundWorker1-&gt;DoWork&nbsp;&#43;=&nbsp;gcnew&nbsp;System::ComponentModel::DoWorkEventHandler(<span class="cpp__keyword">this</span>,&nbsp;&amp;Form1::backgroundWorker1_DoWork_1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;button1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;button1-&gt;Font&nbsp;=&nbsp;(gcnew&nbsp;System::Drawing::Font(L<span class="cpp__string">&quot;Microsoft&nbsp;Sans&nbsp;Serif&quot;</span>,&nbsp;<span class="cpp__number">14</span>.25F,&nbsp;System::Drawing::FontStyle::Regular,&nbsp;System::Drawing::GraphicsUnit::Point,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static_cast</span>&lt;System::Byte&gt;(<span class="cpp__number">0</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;button1-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cpp__number">450</span>,&nbsp;<span class="cpp__number">270</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;button1-&gt;Name&nbsp;=&nbsp;L<span class="cpp__string">&quot;button1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;button1-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cpp__number">75</span>,&nbsp;<span class="cpp__number">41</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;button1-&gt;TabIndex&nbsp;=&nbsp;<span class="cpp__number">4</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;button1-&gt;Text&nbsp;=&nbsp;L<span class="cpp__string">&quot;Fire!!!&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;button1-&gt;UseVisualStyleBackColor&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;button1-&gt;Click&nbsp;&#43;=&nbsp;gcnew&nbsp;System::EventHandler(<span class="cpp__keyword">this</span>,&nbsp;&amp;Form1::button1_Click);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;pictureBox4</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox4-&gt;Dock&nbsp;=&nbsp;System::Windows::Forms::DockStyle::Fill;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox4-&gt;Image&nbsp;=&nbsp;(cli::safe_cast&lt;System::Drawing::Image^&nbsp;&nbsp;&gt;(resources-&gt;GetObject(L<span class="cpp__string">&quot;pictureBox4.Image&quot;</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox4-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox4-&gt;Name&nbsp;=&nbsp;L<span class="cpp__string">&quot;pictureBox4&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox4-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cpp__number">958</span>,&nbsp;<span class="cpp__number">333</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox4-&gt;SizeMode&nbsp;=&nbsp;System::Windows::Forms::PictureBoxSizeMode::StretchImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox4-&gt;TabIndex&nbsp;=&nbsp;<span class="cpp__number">5</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox4-&gt;TabStop&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;pictureBox5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox5-&gt;Image&nbsp;=&nbsp;(cli::safe_cast&lt;System::Drawing::Image^&nbsp;&nbsp;&gt;(resources-&gt;GetObject(L<span class="cpp__string">&quot;pictureBox5.Image&quot;</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox5-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cpp__number">720</span>,&nbsp;<span class="cpp__number">42</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox5-&gt;Name&nbsp;=&nbsp;L<span class="cpp__string">&quot;pictureBox5&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox5-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cpp__number">214</span>,&nbsp;<span class="cpp__number">155</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox5-&gt;SizeMode&nbsp;=&nbsp;System::Windows::Forms::PictureBoxSizeMode::StretchImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox5-&gt;TabIndex&nbsp;=&nbsp;<span class="cpp__number">6</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;pictureBox5-&gt;TabStop&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;timer2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;timer2-&gt;Enabled&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;timer2-&gt;Tick&nbsp;&#43;=&nbsp;gcnew&nbsp;System::EventHandler(<span class="cpp__keyword">this</span>,&nbsp;&amp;Form1::timer2_Tick);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;label2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label2-&gt;AutoSize&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label2-&gt;BackColor&nbsp;=&nbsp;System::Drawing::Color::White;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label2-&gt;Font&nbsp;=&nbsp;(gcnew&nbsp;System::Drawing::Font(L<span class="cpp__string">&quot;Microsoft&nbsp;Sans&nbsp;Serif&quot;</span>,&nbsp;<span class="cpp__number">12</span>,&nbsp;System::Drawing::FontStyle::Regular,&nbsp;System::Drawing::GraphicsUnit::Point,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static_cast</span>&lt;System::Byte&gt;(<span class="cpp__number">0</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label2-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cpp__number">41</span>,&nbsp;<span class="cpp__number">50</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label2-&gt;Name&nbsp;=&nbsp;L<span class="cpp__string">&quot;label2&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label2-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cpp__number">130</span>,&nbsp;<span class="cpp__number">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label2-&gt;TabIndex&nbsp;=&nbsp;<span class="cpp__number">7</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label2-&gt;Text&nbsp;=&nbsp;L<span class="cpp__string">&quot;Ships&nbsp;Destroyed:&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label2-&gt;Click&nbsp;&#43;=&nbsp;gcnew&nbsp;System::EventHandler(<span class="cpp__keyword">this</span>,&nbsp;&amp;Form1::label2_Click);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;label3</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label3-&gt;AutoSize&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label3-&gt;BackColor&nbsp;=&nbsp;System::Drawing::Color::White;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label3-&gt;Font&nbsp;=&nbsp;(gcnew&nbsp;System::Drawing::Font(L<span class="cpp__string">&quot;Microsoft&nbsp;Sans&nbsp;Serif&quot;</span>,&nbsp;<span class="cpp__number">18</span>,&nbsp;System::Drawing::FontStyle::Regular,&nbsp;System::Drawing::GraphicsUnit::Point,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static_cast</span>&lt;System::Byte&gt;(<span class="cpp__number">0</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label3-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cpp__number">177</span>,&nbsp;<span class="cpp__number">50</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label3-&gt;Name&nbsp;=&nbsp;L<span class="cpp__string">&quot;label3&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label3-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">29</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label3-&gt;TabIndex&nbsp;=&nbsp;<span class="cpp__number">8</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;label4</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label4-&gt;AutoSize&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label4-&gt;BackColor&nbsp;=&nbsp;System::Drawing::Color::White;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label4-&gt;Font&nbsp;=&nbsp;(gcnew&nbsp;System::Drawing::Font(L<span class="cpp__string">&quot;Microsoft&nbsp;Sans&nbsp;Serif&quot;</span>,&nbsp;<span class="cpp__number">12</span>,&nbsp;System::Drawing::FontStyle::Regular,&nbsp;System::Drawing::GraphicsUnit::Point,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static_cast</span>&lt;System::Byte&gt;(<span class="cpp__number">0</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label4-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cpp__number">103</span>,&nbsp;<span class="cpp__number">9</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label4-&gt;Name&nbsp;=&nbsp;L<span class="cpp__string">&quot;label4&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label4-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cpp__number">68</span>,&nbsp;<span class="cpp__number">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label4-&gt;TabIndex&nbsp;=&nbsp;<span class="cpp__number">9</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label4-&gt;Text&nbsp;=&nbsp;L<span class="cpp__string">&quot;Shots&nbsp;#:&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;label5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label5-&gt;AutoSize&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label5-&gt;BackColor&nbsp;=&nbsp;System::Drawing::Color::White;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label5-&gt;Font&nbsp;=&nbsp;(gcnew&nbsp;System::Drawing::Font(L<span class="cpp__string">&quot;Microsoft&nbsp;Sans&nbsp;Serif&quot;</span>,&nbsp;<span class="cpp__number">18</span>,&nbsp;System::Drawing::FontStyle::Regular,&nbsp;System::Drawing::GraphicsUnit::Point,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static_cast</span>&lt;System::Byte&gt;(<span class="cpp__number">0</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label5-&gt;Location&nbsp;=&nbsp;System::Drawing::Point(<span class="cpp__number">177</span>,&nbsp;<span class="cpp__number">9</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label5-&gt;Name&nbsp;=&nbsp;L<span class="cpp__string">&quot;label5&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label5-&gt;Size&nbsp;=&nbsp;System::Drawing::Size(<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">29</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;label5-&gt;TabIndex&nbsp;=&nbsp;<span class="cpp__number">10</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Form1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;AutoScaleDimensions&nbsp;=&nbsp;System::Drawing::SizeF(<span class="cpp__number">6</span>,&nbsp;<span class="cpp__number">13</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;AutoScaleMode&nbsp;=&nbsp;System::Windows::Forms::AutoScaleMode::Font;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;ClientSize&nbsp;=&nbsp;System::Drawing::Size(<span class="cpp__number">958</span>,&nbsp;<span class="cpp__number">333</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cpp__keyword">this</span>-&gt;label5);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cpp__keyword">this</span>-&gt;label4);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cpp__keyword">this</span>-&gt;label3);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cpp__keyword">this</span>-&gt;label2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cpp__keyword">this</span>-&gt;pictureBox5);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cpp__keyword">this</span>-&gt;pictureBox3);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cpp__keyword">this</span>-&gt;pictureBox2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cpp__keyword">this</span>-&gt;pictureBox1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cpp__keyword">this</span>-&gt;button1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cpp__keyword">this</span>-&gt;label1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;Controls-&gt;Add(<span class="cpp__keyword">this</span>-&gt;pictureBox4);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;Name&nbsp;=&nbsp;L<span class="cpp__string">&quot;Form1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;Text&nbsp;=&nbsp;L<span class="cpp__string">&quot;Ship&nbsp;Destroyer&nbsp;by&nbsp;Yegor&nbsp;Isakov&nbsp;LTD&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(cli::safe_cast&lt;System::ComponentModel::ISupportInitialize^&nbsp;&nbsp;&gt;(<span class="cpp__keyword">this</span>-&gt;pictureBox1))-&gt;EndInit();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(cli::safe_cast&lt;System::ComponentModel::ISupportInitialize^&nbsp;&nbsp;&gt;(<span class="cpp__keyword">this</span>-&gt;pictureBox2))-&gt;EndInit();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(cli::safe_cast&lt;System::ComponentModel::ISupportInitialize^&nbsp;&nbsp;&gt;(<span class="cpp__keyword">this</span>-&gt;pictureBox3))-&gt;EndInit();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(cli::safe_cast&lt;System::ComponentModel::ISupportInitialize^&nbsp;&nbsp;&gt;(<span class="cpp__keyword">this</span>-&gt;pictureBox4))-&gt;EndInit();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(cli::safe_cast&lt;System::ComponentModel::ISupportInitialize^&nbsp;&nbsp;&gt;(<span class="cpp__keyword">this</span>-&gt;pictureBox5))-&gt;EndInit();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;ResumeLayout(<span class="cpp__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">this</span>-&gt;PerformLayout();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__preproc">&nbsp;
#pragma&nbsp;endregion</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;cycle&nbsp;of&nbsp;ship&nbsp;cruises&nbsp;&nbsp;controlled&nbsp;by&nbsp;Timer2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Void&nbsp;timer2_Tick(System::Object^&nbsp;&nbsp;sender,&nbsp;System::EventArgs^&nbsp;&nbsp;e)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox3-&gt;Left&nbsp;-=<span class="cpp__number">5</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox5-&gt;Left&nbsp;-=<span class="cpp__number">5</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;as&nbsp;ship&nbsp;come&nbsp;too&nbsp;close&nbsp;ship&nbsp;movement&nbsp;reset&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(pictureBox3-&gt;Location&nbsp;==&nbsp;Point(<span class="cpp__number">320</span>,&nbsp;<span class="cpp__number">42</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{timer2-&gt;Enabled&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox3-&gt;Location&nbsp;=&nbsp;Point(<span class="cpp__number">720</span>,&nbsp;<span class="cpp__number">42</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox3-&gt;Visible&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox5-&gt;Visible&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox5-&gt;Location&nbsp;=&nbsp;Point(<span class="cpp__number">700</span>,&nbsp;<span class="cpp__number">42</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer2-&gt;Enabled&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;canon&nbsp;set&nbsp;up&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Void&nbsp;button1_Click(System::Object^&nbsp;&nbsp;sender,&nbsp;System::EventArgs^&nbsp;&nbsp;e)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox5-&gt;Visible&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox3-&gt;Visible&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox1-&gt;Location&nbsp;=&nbsp;Point(<span class="cpp__number">220</span>,&nbsp;<span class="cpp__number">102</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer1-&gt;Enabled&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shots&nbsp;=&nbsp;Shots&nbsp;&#43;<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label5-&gt;Text&nbsp;=System::Convert::ToString(Shots);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;canon&nbsp;fire&nbsp;controled&nbsp;by&nbsp;Timer&nbsp;1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Void&nbsp;Timer_Tik(System::Object^&nbsp;&nbsp;sender,&nbsp;System::EventArgs^&nbsp;&nbsp;e)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox1-&gt;Left&nbsp;&#43;=<span class="cpp__number">50</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">private</span>:&nbsp;System::Void&nbsp;pictureBox1_LocationChanged(System::Object^&nbsp;&nbsp;sender,&nbsp;System::EventArgs^&nbsp;&nbsp;e)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;((pictureBox1-&gt;Location&nbsp;==&nbsp;Point(<span class="cpp__number">320</span>,&nbsp;<span class="cpp__number">102</span>)||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox1-&gt;Location&nbsp;==&nbsp;Point(<span class="cpp__number">420</span>,&nbsp;<span class="cpp__number">102</span>)||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox1-&gt;Location&nbsp;==&nbsp;Point(<span class="cpp__number">520</span>,&nbsp;<span class="cpp__number">102</span>))&nbsp;&amp;&amp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(pictureBox3-&gt;Location&nbsp;==&nbsp;Point(<span class="cpp__number">320</span>,&nbsp;<span class="cpp__number">42</span>)||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox3-&gt;Location&nbsp;==&nbsp;Point(<span class="cpp__number">325</span>,&nbsp;<span class="cpp__number">42</span>)||&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox3-&gt;Location&nbsp;==&nbsp;Point(<span class="cpp__number">330</span>,&nbsp;<span class="cpp__number">42</span>)||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox3-&gt;Location&nbsp;==&nbsp;Point(<span class="cpp__number">420</span>,&nbsp;<span class="cpp__number">42</span>)||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox3-&gt;Location&nbsp;==&nbsp;Point(<span class="cpp__number">425</span>,&nbsp;<span class="cpp__number">42</span>)||&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox3-&gt;Location&nbsp;==&nbsp;Point(<span class="cpp__number">520</span>,&nbsp;<span class="cpp__number">42</span>)||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox3-&gt;Location&nbsp;==&nbsp;Point(<span class="cpp__number">525</span>,&nbsp;<span class="cpp__number">42</span>)||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox3-&gt;Location&nbsp;==&nbsp;Point(<span class="cpp__number">530</span>,&nbsp;<span class="cpp__number">42</span>)||&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox3-&gt;Location&nbsp;==&nbsp;Point(<span class="cpp__number">650</span>,&nbsp;<span class="cpp__number">42</span>)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backgroundWorker1-&gt;RunWorkerAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer1-&gt;Enabled&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer2-&gt;Enabled&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox3-&gt;Visible&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox5-&gt;Visible&nbsp;=&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timer2-&gt;Enabled&nbsp;=&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShipsDestroyed&nbsp;=&nbsp;&nbsp;ShipsDestroyed&nbsp;&#43;<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label3-&gt;Text&nbsp;=System::Convert::ToString(ShipsDestroyed);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cpp__com">//background&nbsp;worker&nbsp;to&nbsp;play&nbsp;sound&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;
<span class="cpp__keyword">private</span>:&nbsp;System::Void&nbsp;backgroundWorker1_DoWork_1(System::Object^&nbsp;&nbsp;sender,&nbsp;System::ComponentModel::DoWorkEventArgs^&nbsp;&nbsp;e)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SoundPlayer^&nbsp;player&nbsp;=&nbsp;gcnew&nbsp;SoundPlayer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;player-&gt;SoundLocation&nbsp;=&nbsp;<span class="cpp__string">&quot;c:\\windows\\media\\tada.wav&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&quot;c:\\Users\\yegoris\\Desktop\\bomb.waw&quot;;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;player-&gt;Load();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;player-&gt;PlaySync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
<span class="cpp__keyword">private</span>:&nbsp;System::Void&nbsp;label2_Click(System::Object^&nbsp;&nbsp;sender,&nbsp;System::EventArgs^&nbsp;&nbsp;e)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
};&nbsp;
}&nbsp;
&nbsp;
&nbsp;
here&nbsp;to&nbsp;add&nbsp;your&nbsp;code&nbsp;snippet.</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
