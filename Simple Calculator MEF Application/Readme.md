# Simple Calculator MEF Application
## Requires
- Visual Studio 2010
## License
- Custom
## Technologies
- .NET Framework 4
## Topics
- Managed Extensibility Framework
## Updated
- 03/07/2011
## Description

<p>The simplest way to see what MEF can do is to build a simple MEF application. In this example, you build a very simple calculator named SimpleCalculator. The goal of SimpleCalculator is to create a console application that accepts basic arithmetic commands,
 in the form &quot;5&#43;3&quot; or &quot;6-2&quot;, and returns the correct answers. Using MEF, you will be able to add new operators without changing the application code.</p>
<table border="0" style="background-color:#fcfec5">
<tbody>
<tr>
<td>
<p><strong><img src="18842-note.png" alt="" width="16" height="16">&nbsp;Note</strong></p>
<p>The purpose of SimpleCalculator is to demonstrate the concepts and syntax of MEF, rather than to necessarily provide a realistic scenario for its use. Many of the applications that would benefit most from the power of MEF are more complex than SimpleCalculator.
 For more extensive examples, see <a href="http://go.microsoft.com/fwlink/?LinkId=144282">
Managed Extensibility Framework</a>&nbsp;samples.</p>
</td>
</tr>
</tbody>
</table>
<h2>Compile and Run</h2>
<p>To compile and run this project, you will need to specify the path to the Extensions folder.</p>
<p>1. Open the main code file (Module1.vb or Program.cs).</p>
<p>2. In the constructor, specify the path to the Extensions folder on your local computer.</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp; catalog.Catalogs.Add(New DirectoryCatalog(&quot;C:\\Users\\SomeUser\\Documents\\Visual Studio 2010\\Projects\\SimpleCalculator2\\SimpleCalculator2\\Extensions&quot;))</p>
<p>&nbsp;</p>
<h2>Test The Sample&nbsp;</h2>
<p>To test this project, perform the following steps:</p>
<p>1. Run the project.</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp; A command window appears.</p>
<p>2. Type addition or subtraction commands.</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp; 1&#43;1</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp; 1-2</p>
<p>3. Try to type multiplication or division commands.</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp; 1*2</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp; 1/2</p>
<p>&nbsp;&nbsp; The following message is displayed.</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp; Operation not found!</p>
