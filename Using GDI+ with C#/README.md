# Using GDI+ with C#
## Requires
- Visual Studio 2002
## License
- Apache License, Version 2.0
## Technologies
- GDI+
## Topics
- Drawing
## Updated
- 08/23/2011
## Description

<h1>Introduction</h1>
<p class="Text">Before Visual Studio .NET, programming the Graphics Device Interface (GDI) was primarily the domain of Visual C&#43;&#43; developers. Today GDI&#43; is exposed to developers through the .NET Framework. To developers just starting out with GDI&#43;, the breadth
 and depth of the interface can be daunting. This example contains code written in Visual C# .NET that uses GDI&#43; through the .NET Framework to create a Windows form that has a shaped appearance and a user control that displays a pie chart or bar graph based
 on supplied data.</p>
<h1>How to Use</h1>
<p class="Text">Open the&nbsp;CircularForm.sln&nbsp;solution file. This will open the project in Visual Studio .NET. In order to see the background texture of the form, copy the image file in the Misc directory to the build directory (e.g. Code\Bin\Debug).</p>
<h1>Description</h1>
<p class="Text">The two main files of the example are CircForm.cs and GraphDisplay.cs that define the main application Windows form and the user control that displays the graph, respectively.</p>
<p class="Text">The easiest way to shape a Windows form is to remove the Windows form border (Form.FormBorderStyle = None), make the background color of the form the same as the form&rsquo;s TransparencyKey property and then use the GDI&#43; drawing functionality
 exposed in the <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a> namespace and child namespaces to draw the desired area of the form. To draw the form, it is necessary to override the OnPaint method inherited from the Form class and do the drawing within that method. It is easiest to use a
 single GraphicsPath object to define the borders of the shaped form and the clipping (i.e. visible) area of the form.</p>
<p class="Text">The .NET Framework provides a wealth of drawing facilities. The example contains a user control that draws a graph based on the values supplied. The graph is refreshed whenever the parent of the control instance changes the data supplied,
 the graph type (e.g. pie chart or bar graph), or the colors to be used in the graph. This is accomplished by calling the Control.Refresh method of the user control from within the set accessor of those properties. The Refresh method invalidates the control
 causing it to be redrawn. Again, the OnPaint method of the control is overridden in order to define how the control is drawn.</p>
<p class="Text">The OnPaint method of the control calls either DrawPieChart or DrawBarGraph. Both methods use the Graphics object passed from the OnPaint method to draw on the control. DrawPieChart determines the center of the pie (circle) and draws a line
 along the x-axis to the edge of the circle, and then an arc clockwise for a percentage of the circle (based on the values). It then calls the CloseAllFigures method to close of the &ldquo;slice&rdquo; of the pie just drawn. This continues for each data value.
 Similarly, the DrawBarGraph method uses Rectangle objects to define each data value.</p>
