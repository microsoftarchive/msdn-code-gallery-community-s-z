# Samples for Parallel Programming with the .NET Framework
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- PLINQ
- .NET Framework
- Parallel Programming
- Parallel Computing Platform
- Parallel Extensions
- Task Parallel Library
## Topics
- Parallel Programming
## Updated
- 09/27/2011
## Description

<p>The .NET Framework 4 includes significant advancements for developers writing parallel and concurrent applications, including Parallel LINQ (PLINQ), the Task Parallel Library (TPL), new thread-safe collections, and a variety of new coordination and synchronization
 data structures.</p>
<p>This sample includes example applications and library functionality that demonstrate, utilize, and augment this support (it is not production quality). This sample is a single .zip containing a single Visual Studio .sln file, which then contains multiple
 Visual Studio projects that highlight key capabilities provided by the .NET Framework 4 and the parallel programming support it provides. Below are descriptions of the included examples.</p>
<p>(For discussions of Parallel Extensions and/or these samples, visit the forums at
<a href="http://social.msdn.microsoft.com/Forums/en-US/parallelextensions/threads">
http://social.msdn.microsoft.com/Forums/en-US/parallelextensions/threads</a>. For documentation on the parallelism constructs in .NET 4, see
<a href="http://msdn.microsoft.com/en-us/library/dd460693(VS.100).aspx">http://msdn.microsoft.com/en-us/library/dd460693(VS.100).aspx</a>. For information direct from the Parallel Extensions team, subscribe to the team blog at
<a href="http://blogs.msdn.com/pfxteam">http://blogs.msdn.com/pfxteam</a>. For videos/articles on parallelism and Parallel Extensions, visit the Parallel Computing Developer Center at
<a href="http://msdn.com/concurrency">http://msdn.com/concurrency</a>.)</p>
<table border="0" cellspacing="0" cellpadding="2" width="525">
<tbody>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_2.png"><img title="image" src="-image_thumb.png" border="0" alt="image" width="147" height="117" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>AcmePizza&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This simple and somewhat silly application demonstrates using concurrent collections with WPF.&nbsp; The collections are wrapped with observable facades, such that multiple threads may modify the collections concurrently, and those
 updates are safely propagated to UI controls.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_B06A/image_2.png"><img title="image" src="-image_thumb.png" border="0" alt="image" width="147" height="118" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>Antisocial Robots&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> Demonstrates doing a computationally-intensive operation many times per second, as a bunch of &ldquo;robots&rdquo; try to get as far away from each other as possible.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_4.png"><img title="image" src="-image_thumb_1.png" border="0" alt="image" width="146" height="100" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>BabyNames&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This is one of the first applications we ever built to use Parallel LINQ.&nbsp; Using LINQ and PLINQ, it queries a data set of baby name popularity information, sorts the results, and displays the results in a simplistic WPF user
 interface.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_6.png"><img title="image" src="-image_thumb_2.png" border="0" alt="image" width="147" height="57" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>BlendImages&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> A demo of very simple image manipulation using a Parallel.For loop.&nbsp; The application allows the user to load up two images and blends them together into a single, new image.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_B06A/image_10.png"><img title="image" src="-image_thumb_4.png" border="0" alt="image" width="145" height="102" style="border:0px currentColor; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>Boids&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> An implementation of a classic flocking algorithm, utilizing WPF for pretty 3D visualization of the &ldquo;boids&rdquo;, whose next positions and velocities are computing in parallel.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_8.png"><img title="image" src="-image_thumb_3.png" border="0" alt="image" width="146" height="91" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>ComputePi&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> A console application that estimates the value of <a href="http://en.wikipedia.org/wiki/Pi">
PI</a> using a variety of both serial and parallel implementations, the latter done with both PLINQ and the Parallel class.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_10.png"><img title="image" src="-image_thumb_4.png" border="0" alt="image" width="147" height="149" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>DiningPhilosophers&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> A WPF application that demonstrates the classic &ldquo;<a href="http://en.wikipedia.org/wiki/Dining_philosophers">Dining Philosophers</a>&rdquo; synchronization problem.&nbsp; The application implements several solutions, including
 one based on asynchronous techniques using Tasks.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_12.png"><img title="image" src="-image_thumb_5.png" border="0" alt="image" width="147" height="78" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>EditDistance&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> A console application that uses Tasks to parallelize a dynamic programming problem, that of computing the &ldquo;<a href="http://en.wikipedia.org/wiki/Edit_distance">edit distance</a>&rdquo; between two strings.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_14.png"><img title="image" src="-image_thumb_6.png" border="0" alt="image" width="148" height="126" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>GameOfLife&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This application provides an implementation of <a href="http://en.wikipedia.org/wiki/Conway%27s_Game_of_Life">
Conway&rsquo;s Game of Life</a>, using the Parallel class to parallelize the processing of the cellular automata.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_16.png"><img title="image" src="-image_thumb_7.png" border="0" alt="image" width="148" height="127" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>ImageColorizer&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This application manipulates an image by converting the majority of the image to grayscale, except for portions of the image containing user-selected hues.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_18.png"><img title="image" src="-image_thumb_8.png" border="0" alt="image" width="148" height="112" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>LINQRayTracer&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> Based on <a href="http://blogs.msdn.com/lukeh/archive/2007/10/01/taking-linq-to-objects-to-extremes-a-fully-linqified-raytracer.aspx">
Luke Hoban</a>&rsquo;s LINQ implementation of a ray tracer, this application parallelizes a computationally intensive LINQ query using PLINQ.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_20.png"><img title="image" src="-image_thumb_9.png" border="0" alt="image" width="148" height="115" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>MandelbrotFractals&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, C&#43;&#43;/CLI&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This application provides an implementation of the classic
<a href="http://en.wikipedia.org/wiki/Mandelbrot_set">Mandelbrot</a> fractal, parallelizing the processing of the fractal using the Parallel class.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_22.png"><img title="image" src="-image_thumb_10.png" border="0" alt="image" width="148" height="102" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>Morph&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> Implements a <a href="http://en.wikipedia.org/wiki/Morphing">
morphing</a> algorithm between two images.&nbsp; Parallelization is done using the Parallel class.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_B06A/image_8.png"><img title="image" src="-image_thumb_3.png" border="0" alt="image" width="149" height="119" style="border:0px currentColor; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>NBodySimulation&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, F#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> Implements a classic n-body simulation using C# and WPF for the UI and using F# for the core computation. Parallelism is achieved using the Parallel class.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_24.png"><img title="image" src="-image_thumb_11.png" border="0" alt="image" width="149" height="108" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>NQueens&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This application implements a solution to the <a href="http://en.wikipedia.org/wiki/Eight_queens_puzzle">
N-Queens</a> problem, using both LINQ and PLINQ.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_42.png"><img title="image" src="-image_thumb_20.png" border="0" alt="image" width="149" height="68" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>OptionPricing&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This Excel <a href="http://msdn.microsoft.com/en-us/vsto/default.aspx">
VSTO</a> application utilizes PLINQ to price <a href="http://en.wikipedia.org/wiki/Asian_option">
Asian Options</a>.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_26.png"><img title="image" src="-image_thumb_12.png" border="0" alt="image" width="148" height="89" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>ParallelGrep&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This console application implements &ldquo;<a href="http://en.wikipedia.org/wiki/Grep">grep</a>&rdquo; functionality across a file system using PLINQ.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_B06A/image_12.png"><img title="image" src="-image_thumb_5.png" border="0" alt="image" width="149" height="77" style="border:0px currentColor; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>PlinqKnobs&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> A simple console application that demonstrates some of the ways execution of a PLINQ query may be controlled and configured.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_28.png"><img title="image" src="-image_thumb_13.png" border="0" alt="image" width="148" height="125" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>Raytracer&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic, F#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This Windows application provides an animated, ray-traced bouncing ball.&nbsp; Sequential and parallel implementations are provided, as is a special parallel implementation that colors the animated image based on which thread was
 used to calculate which regions.</td>
</tr>
<tr>
<td width="148" valign="top"><img src="44486-reversi-thumnail.jpg" alt="" width="148" height="98"></td>
<td width="375" valign="top"><strong><strong>Project Name: </strong></strong>Raytracer&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<strong><br>
<strong>Languages:</strong> </strong>C#<strong>&nbsp;&nbsp;&nbsp;&nbsp; <br>
<strong>Description:</strong> </strong>This WPF application is a Reversi game.&nbsp; The AI algorithms are minimax with alpha-beta pruning, and the parallel AI (light player) uses Tasks and CancellationTokens to achieve speedup via parallelism.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_30.png"><img title="image" src="-image_thumb_14.png" border="0" alt="image" width="149" height="89" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>ShakespeareanMonkeys&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This application implements and parallelizes a <a href="http://en.wikipedia.org/wiki/Genetic_algorithm">
genetic algorithm</a> for breeding monkeys able to speak text from Hamlet.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_32.png"><img title="image" src="-image_thumb_15.png" border="0" alt="image" width="148" height="110" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>SpellChecker&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This application implements and parallelizes a spellchecking algorithm based on the same edit distance calculation in the Edit Distance sample.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_34.png"><img title="image" src="-image_thumb_16.png" border="0" alt="image" width="148" height="116" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>Strassens&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This application implements several algorithms for performing and parallelizing matrix multiplication, including the
<a href="http://en.wikipedia.org/wiki/Strassen_algorithm">Strassen algorithm</a>.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_36.png"><img title="image" src="-image_thumb_17.png" border="0" alt="image" width="149" height="129" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>Sudoku&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This is a fun application that provides a full Sudoku experience, including on-demand puzzle generation and solving.&nbsp; Unlike many Sudoku demos which parallelize the solver, this implementation parallelizes the generator, using
 PLINQ.&nbsp; It also demonstrates a use for speculative execution.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_38.png"><img title="image" src="-image_thumb_18.png" border="0" alt="image" width="149" height="123" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong>VisualizePartitioning&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Languages:</strong> C#, Visual Basic&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This application demonstrates various approaches to partitioning as employed by both Parallel and PLINQ.</td>
</tr>
<tr>
<td width="148" valign="top"><a href="http://blogs.msdn.com/blogfiles/pfxteam/WindowsLiveWriter/ATourThroughtheParallelProgrammingS.NET4_A55F/image_40.png"><img title="image" src="-image_thumb_19.png" border="0" alt="image" width="148" height="125" style="border-width:0px; display:inline"></a></td>
<td width="375" valign="top"><strong>Project Name: </strong><a href="http://blogs.msdn.com/pfxteam/archive/2010/04/04/9990342.aspx">ParallelExtensionsExtras</a><br>
<strong>Languages:</strong> C#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
<strong>Description:</strong> This class library provides a plethora of interesting and useful extensions to take advantage of and complement the functionality available in the .NET Framework 4 for parallel programming.</td>
</tr>
</tbody>
</table>
