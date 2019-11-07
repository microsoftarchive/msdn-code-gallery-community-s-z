# Visual Studio 3D Starter Kit
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- Interop
- C#
- Native Code
- C++
- DirectX
- Direct3D
- XAML with C++
- Windows Store app
- Windows 8.1
- Windows Phone 8.1
## Topics
- Interop
- Animation
- Graphics
- Games
- Graphics and 3D
- XAML
- Cross Platform Code Reuse
- Direct3D
- Pixel Shader
- Image
- 3D
- Multi-Sample Anti-Aliasing
- 3D Graphics
- double buffer
## Updated
- 04/02/2014
## Description

<h1><img id="70098" src="70098-starterkit_screenshot.png" alt="" width="500" height="313"></h1>
<h1>Introduction</h1>
<p>This sample&nbsp;demonstrates several&nbsp;features of Visual Studio&nbsp;useful in game development. It&nbsp;contains the starting point for a basic Direct3D game that shares code between Windows 8.1 and&nbsp;Windows Phone 8.1 using the new Universal app
 model.</p>
<h1>Requirements</h1>
<p>This sample requires <strong>Visual Studio 2013 Update 2 RC&nbsp;</strong>in order to be built.</p>
<h1>Other versions of the Starter Kit</h1>
<p>This is the latest version of the Starter Kit, and it is only supported on <strong>
Visual Studio 2013 Update 2 RC&nbsp;</strong>or higher.</p>
<p>You can get the&nbsp;<strong>latest version of the Starter Kit for VS2013 RTM/Windows 8.1 only&nbsp;</strong>at&nbsp;<a href="http://aka.ms/vs3dkitwin">http://aka.ms/vs3dkitwin</a></p>
<p>If you have Visual Studio 2012 Professional or higher, we highly recommend updating to Visual Studio 2013 Express and getting the latest version on the link above. The previous&nbsp;<strong>VS2012/Windows 8.0 only version&nbsp;</strong>of the kit is still
 available here:&nbsp;<a href="http://aka.ms/vs3dkitwin80">http://aka.ms/vs3dkitwin80</a></p>
<p>If you have Visual Studio 2012 Express for Windows 8, the previous <strong>VS2012/Windows 8.0 only version
</strong>of the kit is still available here: <a href="http://aka.ms/vs3dkitwin80">
http://aka.ms/vs3dkitwin80</a></p>
<p>If you have Visual Studio 2012 Express for Windows Phone, get the <strong>Phone 8.0 only version
</strong>of the kit here: <a href="http://aka.ms/vs3dkitphone">http://aka.ms/vs3dkitphone</a></p>
<h1><span>Building the Sample</span></h1>
<ol>
<li>Start Visual Studio 2013 Update 2 and select <strong>File</strong> &gt;<strong>Open</strong> &gt;<strong>Project/Solution</strong>.
</li><li>Go to the directory in which you unzipped the sample. Go to the directory named<br>
for the sample, and double-click the Visual Studio&nbsp;2013 Solution (.sln) file.
</li><li>Press F6 or use <strong>Build</strong> &gt; <strong>Build Solution</strong> to build the sample.
</li></ol>
<p>&nbsp;<span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample contains the starting point for a basic game.</p>
<p>It demonstrates using the Visual Studio&nbsp;Graphics tools for asset manipulation, along with using an MSBUILD task for converting the included assets to a format suitable for runtime consumption.</p>
<p>The sample contains a &ldquo;Starter Kit&rdquo; which provides basic support for consuming the runtime assets produced by the MSBUILD task. This includes loading and rendering assets (including animated meshes),&nbsp;along with other functionality to enabled
 developers to work with the assets at runtime.</p>
<p>The sample also demonstrates using XAML to implement a simple 2D HUD over the 3D scene, and how to implement support for ARM devices,&nbsp;Windows Phone and older graphics cards through the use of fallback shaders.</p>
<h3>Viewing Assets</h3>
<p>To view the included assets, open the Assets folder in Visual Studio 2013, under the StarterKit.Shared project. Double click on any of the assets included in the Assets folder.</p>
<h3>Including the Assets in the Build</h3>
<p>The assets included with this sample have been set up to be converted by the MSBUILD task to a runtime format at build time. For an example on how this is set up, right click on the GameLevel.fbx file, and select &ldquo;Properties&rdquo; from the context
 menu. Select &ldquo;General&rdquo; from the Configuration properties on the left. Notice how the &ldquo;Item Type&rdquo; has been set to &ldquo;Mesh Content Pipeline&rdquo;. The Visual Studio Graphics tools contain 3 different build types related to assets:
 Mesh Content, Shader Content, and Image Content.</p>
<p>In this example, the mesh is converted at build time to a file named &ldquo;GameLevel.cmo&rdquo;.</p>
<h3>Using the Starter Kit</h3>
<p>The sample includes the header VSD3DStarter.h, which contains code for getting started with the content produced by the build task described above.&nbsp;It also contains the header Animation.h, which shows how to render meshes that contain bone animations.</p>
<p>An example of using the Starter Kit to load and render the GameLevel can be found in the Game.cpp file.</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li>StarterKit.Shared/ folder&nbsp;- Contains files that can be shared between Windows Store and Windows Phone apps
<ul>
<li>Animation/Animation.h &ndash;&nbsp;Shows how to render an animated mesh exported through the Visual Studio Mesh Content Task
</li><li>Animation/SkinningVertexShader.hlsl &ndash;&nbsp;Vertex shader that demonstrates how to account for bone animations when rendering a mesh
</li><li>Assets/GlowEffect.hlsl - A fallback shader based on GlowEffect.dgsl for use in ARM devices and older graphics cards (D3D Feature Level 9.1/9.3)
</li><li>Common/DeviceResources.cpp/.h &ndash;&nbsp;Shows how to initialize and manage the DirectX resources for your app. This version of DeviceResources builds on top of the default VS2013 template by adding Multi-Sample Anti-Aliasing support
</li></ul>
<ul>
<li>Common/DirectXHelper.h &ndash; DirectX helper code </li></ul>
<ul>
<li>Common/StepTimer.h &ndash; A basic implementation of a timer that comes with the VS2013 templates
</li></ul>
<ul>
<li>Content/SampleFPSTextRenderer.cpp/.h &ndash;&nbsp;Shows how to render a simple Direct2D FPS counter. This is part of the default DirectX templates that come with VS2013.
</li></ul>
<ul>
<li>DirectXTex/DDSTextureLoader.cpp/.h &ndash;&nbsp;Shows how to load textures from DDS files. This code is&nbsp;part of the<a href="http://directxtex.codeplex.com/">DirectXTex library</a>
</li></ul>
<ul>
</ul>
<ul>
<li>Game.cpp/.h &ndash; Game logic that demonstrates&nbsp;a&nbsp;use of the &ldquo;Starter Kit&rdquo;
</li><li>HitTestingHelpers.h &ndash;&nbsp;Contains static methods to execute hit testing on Starter Kit Mesh objects
</li><li>ppltasks_extra.h&nbsp;&ndash; Helper methods to create different types of asynchronous tasks. Adapted from the&nbsp;<a href="http://code.msdn.microsoft.com/windowsapps/Windows-8-Asynchronous-08009a0d/">Windows 8 Asynchronous Operations in C&#43;&#43; with PPL sample</a>
</li><li>StarterKitMain.cpp/.h&nbsp;&ndash; Main class for the DirectX code, included with the VS2013 templates. Initializes and updates the renderers.
</li><li>VSD3DStarter.h &ndash; &ldquo;Starter Kit&rdquo;. Provides runtime support for working with the assets in this<br>
sample </li></ul>
</li><li>StarterKit.Windows project - Main project for the Windows Store, developed with C&#43;&#43;
<ul>
<li>App.xaml/.h/.cpp &ndash; Application file for XAML app </li><li>DirectXPage.xaml/.h/.cpp &ndash; Used for hosting Direct3D content in a XAML app
</li></ul>
</li><li>StarterKit.WindowsPhonePhone project - Main project for the Windows Phone, developed with C&#43;&#43;
<ul>
<li>App.xaml/.h/.cpp &ndash; Application file for XAML app </li><li>DirectXPage.xaml/.h/.cpp &ndash; Used for hosting Direct3D content in a XAML app
</li></ul>
</li></ul>
<h1>More Information</h1>
<p>Please submit bugs found in this sample via <a href="http://connect.microsoft.com/VisualStudio">
Microsoft Connect</a>.&nbsp; Please use the <a href="http://social.msdn.microsoft.com/Forums/en-US/vcgeneral/threads">
Visual C&#43;&#43; Forum</a> on MSDN for questions or discussion about this sample.</p>
<h1>Version History</h1>
<ul>
<li><strong>4/2/2014 -&nbsp;</strong>New version of the Starter Kit for Windows 8.1 and Windows Phone 8.1 using the new universal project.
</li><li><strong>10/28/2013 </strong>- Added link to new version of the Starter Kit for Windows 8.1 with many improvements and bug fixes.
</li><li><strong>2/12/2013 </strong>&ndash; Second major version of the Starter Kit with support for sharing code between Windows Phone and Windows Store apps. Improvements to the texture loader and code cleanup
</li><li><strong>12/20/2012</strong> - Better device orientation support, correct MaxAnisotropy for devices with D3D_FEATURE_LEVEL_9_1
</li><li><strong>12/3/2012</strong> - Includes full source for the default vertex shader in the comments; tile, splash and store images changed to RGBA format
</li><li><strong>11/20/2012</strong> - Includes support for bone animations and support for ARM devices/older graphics cards through the use of fallback shaders
</li><li><strong>11/1/2012</strong> - Initial release </li></ul>
