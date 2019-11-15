# Visual Studio 3D Starter Kit (Windows 8.1)
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- Native Code
- C++
- DirectX
- Direct3D
- XAML with C++
- Windows Store app
- Windows 8.1
## Topics
- Animation
- Graphics
- Games
- Graphics and 3D
- XAML
- Direct3D
- Pixel Shader
- Image
- 3D
- Multi-Sample Anti-Aliasing
- 3D Graphics
- double buffer
- Windows 8.1
## Updated
- 04/02/2014
## Description

<h1><img id="70098" src="http://i1.code.msdn.s-msft.com/visual-studio-3d-starter-455a15f1/image/file/70098/1/starterkit_screenshot.png" alt="" width="500" height="313"></h1>
<h1>Introduction</h1>
<p>This sample&nbsp;demonstrates several&nbsp;features of Visual Studio&nbsp;useful in game development. It&nbsp;contains the starting point for a basic Direct3D game for Windows Store.</p>
<h1>Requirements</h1>
<p>This sample requires&nbsp;<strong>Visual Studio 2013 Express for Windows Store&nbsp;Update 1
</strong>or higher.</p>
<h1>Other versions of the Starter Kit</h1>
<p>This version of the Starter Kit is for Windows 8.1 only.</p>
<p>You can get the&nbsp;<strong>full version of the Starter Kit for VS2013 Update 2&nbsp;</strong>that shows how to share code between Windows 8.1 and Windows Phone 8.1 apps here:&nbsp;<a href="http://aka.ms/vs3dkit">http://aka.ms/vs3dkit</a></p>
<p>If you have Visual Studio 2012 Professional, you can get the&nbsp;<strong>full version of the Starter Kit for VS2012&nbsp;</strong>that shows how to share code between Windows 8.0 and Windows Phone 8 apps here:&nbsp;<a href="http://aka.ms/vs3dkit80">http://aka.ms/vs3dkit80</a></p>
<p>The previous version of the <strong>Starter Kit for VS2012/Windows 8.0</strong> is still available at
<a href="http://aka.ms/vs3dkitwin80">http://aka.ms/vs3dkitwin80</a></p>
<p>If you have Visual Studio 2012 Express for Windows Phone, get the <strong>Phone 8.0 only version
</strong>of the kit here: <a href="http://aka.ms/vs3dkitphone">http://aka.ms/vs3dkitphone</a></p>
<h1><span>Building the Sample</span></h1>
<ol>
<li>Start Visual Studio 2013 and select <strong>File</strong> &gt;<strong>Open</strong> &gt;<strong>Project/Solution</strong>.
</li><li>Go to the directory in which you unzipped the sample. Go to the directory named<br>
for the sample, and double-click the Visual Studio&nbsp;2013 Solution (.sln) file.
</li><li>Press F6 or use <strong>Build</strong> &gt; <strong>Build Solution</strong> to build the sample.
</li></ol>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample contains the starting point for a basic game.</p>
<p>It demonstrates using the Visual Studio&nbsp;Graphics tools for asset manipulation, along with using an MSBUILD task for converting the included assets to a format suitable for runtime consumption.</p>
<p>The sample contains a &ldquo;Starter Kit&rdquo; which provides basic support for consuming the runtime assets produced by the MSBUILD task. This includes loading and rendering assets (including animated meshes),&nbsp;along with other functionality to enabled
 developers to work with the assets at runtime.</p>
<p>The sample also demonstrates using XAML to implement a simple 2D HUD over the 3D scene, and how to implement support for ARM devices&nbsp;and older graphics cards through the use of fallback shaders.</p>
<h3>Viewing Assets</h3>
<p>To view the included assets, open the Assets folder in Visual Studio 2013. Double click on any of the assets included in the Assets folder.</p>
<h3>Including the Assets in the Build</h3>
<p>The assets included with this sample have been set up to be converted by the MSBUILD task to a runtime format at build time. For an example on how this is set up, right click on the GameLevel.fbx file, and select &ldquo;Properties&rdquo; from the context
 menu. Select &ldquo;General&rdquo; from the Configuration properties on the left. Notice how the &ldquo;Item Type&rdquo; has been set to &ldquo;Mesh Content Pipeline&rdquo;. The Visual Studio Graphics tools contain 3 different build types related to assets:
 Mesh Content, Shader Content, and Image Content.</p>
<p>In this example, the mesh is converted at build time to a file named &ldquo;GameLevel.cmo&rdquo;.</p>
<h3>Using the Starter Kit</h3>
<p>The sample includes the header VSD3DStarter.h, which contains code for getting started with the content produced by the build task described above.&nbsp;It also contains the header Animation.h, which shows how to render meshes that contain bone animations.</p>
<p>An example of using the Starter Kit to load and render the GameLevel can be found in the Game.cpp file.</p>
<p>To learn more about the Visual Studio DirectX templates&nbsp;(which serve as base for this sample), please visit
<a href="http://msdn.microsoft.com/en-us/library/windows/apps/dn481536.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/dn481536.aspx</a></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li>StarterKit project - Main project for Windows 8.1, developed with C&#43;&#43;
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
<li>DirectXTex/DDSTextureLoader.cpp/.h &ndash;&nbsp;Shows how to load textures from DDS files. This code is&nbsp;part of the
<a href="http://directxtex.codeplex.com/">DirectXTex library</a> </li><li>App.xaml/.h/.cpp &ndash; Application file for XAML app </li></ul>
<ul>
<li>DirectXPage.xaml/.h/.cpp &ndash; Used for hosting Direct3D content in a XAML app
</li></ul>
<ul>
<li>Game.cpp/.h &ndash; Game logic that demonstrates&nbsp;a&nbsp;use of the &ldquo;Starter Kit&rdquo;
</li><li>HitTestingHelpers.h &ndash;&nbsp;Contains static methods to execute hit testing on Starter Kit Mesh objects
</li><li>ppltasks_extra.h&nbsp;&ndash; Helper methods to create different types of asynchronous tasks. Adapted from the
<a href="http://code.msdn.microsoft.com/windowsapps/Windows-8-Asynchronous-08009a0d/">
Windows 8 Asynchronous Operations in C&#43;&#43; with PPL sample</a> </li><li>StarterKitMain.cpp/.h&nbsp;&ndash; Main class for the DirectX code, included with the VS2013 templates. Initializes and updates the renderers.
</li><li>VSD3DStarter.h &ndash; &ldquo;Starter Kit&rdquo;. Provides runtime support for working with the assets in this<br>
sample </li></ul>
</li></ul>
<h1>More Information</h1>
<p>Please submit bugs found in this sample via <a href="http://connect.microsoft.com/VisualStudio">
Microsoft Connect</a>.&nbsp; Please use the <a href="http://social.msdn.microsoft.com/Forums/en-US/vcgeneral/threads">
Visual C&#43;&#43; Forum</a> on MSDN for questions or discussion about this sample.</p>
<h1>Version History</h1>
<ul>
<li style="padding-bottom:10px"><strong>4/2/2014 -&nbsp;</strong>Added link to the new version of the Starter Kit for Windows 8.1 and Windows Phone 8.1 using the new universal project.
</li><li style="padding-bottom:10px"><strong>1/21/2014</strong> -&nbsp;Minor update to deploy correct shaders to Feature Level 9 devices.
</li><li><strong>10/28/2013 </strong>- First version for Windows 8.1, with numerous bug fixes and improvements, such as using the new VS2013 templates, improved bone animation support and asynchronous resource loading.
</li><li><strong>2/12/2013 - </strong>Initial release for Windows Store only </li></ul>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:661px; width:1px; height:1px; overflow:hidden">
<a href="http://msdn.microsoft.com/en-us/library/windows/apps/dn481536.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/dn481536.aspx</a></div>
