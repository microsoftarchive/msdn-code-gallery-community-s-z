# SIMD Sample
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- .NET Framework
- SIMD
## Topics
- Graphics
- C#
- Graphics and 3D
- Performance
## Updated
- 04/03/2014
## Description

<h1>Introduction</h1>
<p>This sample contains two applications that demonstrate how to leverage SIMD from C# with, and without, explicit vectorization.</p>
<h1>Prerequisites</h1>
<p>In order to use SIMD, you need to perform the following steps:</p>
<ol>
<li><strong>Download and install the latest preview of RyuJIT</strong>. You can get it from
<a href="http://aka.ms/RyuJIT">http://aka.ms/RyuJIT</a> </li><li><strong>Enable SIMD for the current user</strong>. This will make it easy for you to run &amp; debug the sample apps. In order to enable SIMD, run the
<a href="http://code.msdn.microsoft.com/SIMD-Sample-f2c8c35a/sourcecode?fileId=112212&pathId=236213298">
enable-jit.cmd</a> batch file. </li><li><strong>Don&rsquo;t forget to disable the JIT when you&rsquo;re done</strong>. Otherwise all managed 64 bit apps will use the new JIT, which may not work for all apps. For example, the JIT is currently known to not being able to handle PowerShell.exe correctly.
 You can disable the SIMD support by running the <a href="http://code.msdn.microsoft.com/SIMD-Sample-f2c8c35a/sourcecode?fileId=112212&pathId=400305368">
disable-jit.cmd</a> batch file. </li></ol>
<h1>Debugging</h1>
<p>In order to ensure a great debugging experience the JIT will normally suppress all optimizations when a debugger is attached, even for binaries compiled in release mode. This also includes the support for SIMD.</p>
<p>If you want to debug your binary with SIMD intrinsics enabled, you need to disable the setting that causes the JIT to suppress optimizations:</p>
<ul>
<li>Go to <strong>Tools</strong> | <strong>Options</strong> | <strong>Debugging</strong> |
<strong>General</strong> </li><li>Uncheck the checkbox named <strong>Suppress JIT optimization on module load</strong>
</li></ul>
<h1>Description</h1>
<p>The JIT support for SIMD is provided by <a href="http://aka.ms/RyuJIT">RyuJIT</a>. The SIMD APIs are exposed via the
<a href="http://nuget.org/packages/Microsoft.Bcl.Simd">Microsoft.Bcl.Simd</a> NuGet package.</p>
<p>The NuGet package exposes two programming models, each of which is covered by a single sample application:</p>
<ol>
<li><strong>Vectors with a fixed size</strong> (Ray Tracer) </li><li><strong>Vectors with a hardware dependent size</strong> (Mandelbrot) </li></ol>
<h2>Using vectors with a fixed size</h2>
<p>The NuGet package provides the following fixed size vectors:</p>
<ul>
<li>System.Numerics.Vector2f </li><li>System.Numerics.Vector3f </li><li>System.Numerics.Vector4f </li></ul>
<p>They are modeled after the most common vector types that frequently occur in games and graphics programing. They usual represent points and vectors in 3D space. The operations on those types, for example, addition and multiplication, are accelerated using
 SIMD.</p>
<p>The types are explicitly designed to be drop-in replacements for the data types that these kind of apps already use.</p>
<p>The Ray Tracer sample demonstrates this capability. Imagine you would have defined a 3-dimensional vector type to represent the rays and points of the scene that is rendered. The idea is that you simply add a reference to the NuGet package and delete your
 type. After fixing all call sites to refer to System.Numerics.Vector3f, your application will use SIMD instructions for all vector operations. Good examples of these basic vector operations include all the scene objects such as
<a href="http://code.msdn.microsoft.com/SIMD-Sample-f2c8c35a/sourcecode?fileId=112212&pathId=622129966">
Disk.cs</a> and <a href="http://code.msdn.microsoft.com/SIMD-Sample-f2c8c35a/sourcecode?fileId=112212&pathId=12348343">
Plane.cs</a>.</p>
<p>Except for porting the usages from your vector type to Vector3f no major algorithmic changes are required. In particular it doesn&rsquo;t require explicit vectorization.</p>
<h2>Using vectors with a hardware dependent size</h2>
<p>While the fixed size vector types are convenient to use, their maximum degree of parallelization is limited by the number of components. For example, an application that uses Vector2f can get a speed-up of at most a factor of two &ndash; even if the hardware
 would be capable of performing operations on eight elements at a time.</p>
<p>In order for an application to scale with the hardware capabilities, you have to
<em>vectorize</em> the algorithm. Vectorizing an algorithm means that you need to break the input into a set of vectors whose size is hardware-dependent. On a machine with SSE2, this means the app could operate over vectors of four 32-bit floating point values.
 This allows later versions of the JIT to leverage newer SIMD implementations, such as AVX (please note that AVX support isn&rsquo;t included with our preview yet).</p>
<p>The hardware-dependent vector type is:</p>
<ul>
<li>System.Numerics.Vector&lt;T&gt; </li></ul>
<p>The Mandelbrot sample demonstrates how this approach would look. In particular, compare the scalar version against the vectorized version:</p>
<ul>
<li><strong>Scalar version</strong>. <a href="http://code.msdn.microsoft.com/SIMD-Sample-f2c8c35a/sourcecode?fileId=112212&pathId=2111576458">
ScalarFloat.cs</a>, method RenderSingleThreadedWithADT. Note how the algorithm is defined using simple for loops and scalar floats.
</li><li><strong>Vectorized version</strong>. <a href="http://code.msdn.microsoft.com/SIMD-Sample-f2c8c35a/sourcecode?fileId=112212&pathId=88533163">
VectorFloat.cs</a>, method RenderSingleThreadedWithADT. Note how the same same algorithm is now vectorized. It still uses for loops but it uses Vector&lt;float&gt; instead of scalar floats.
</li></ul>
<h1>Known Issues</h1>
<p>Because the JIT is still in preview you need to expect some rough corners. For example, PowerShell is known to not be able to successfully run on the new JIT. If you experience any issues, make sure to disable the JIT. You can do this via the
<a href="http://code.msdn.microsoft.com/SIMD-Sample-f2c8c35a/sourcecode?fileId=112212&pathId=400305368">
disable-jit.cmd</a> batch file.</p>
