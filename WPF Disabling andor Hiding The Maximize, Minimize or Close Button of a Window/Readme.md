# WPF: Disabling and/or Hiding The Maximize, Minimize or Close Button of a Window
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- WPF
## Topics
- WPF
- WPF Control Templating
## Updated
- 11/30/2014
## Description

<h1>Introduction</h1>
<p>This solution provides an example of how you can disable or hide the minimize, maximize and close button of a WPF window using P/Invoke and the SetWindowLong and EnableMenuItem native Win32 methods.</p>
<h1><span>Building the Sample</span></h1>
<p>You should be able to build the sample code in Visual Studio by just open the solution file that is included in the .zip file and compile the project. You don't need to change any settings before you run the application.</p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p>The sample code includes a WPF Custom Control Library with a CustomWindow class that extends the built-in System.Windows.Window class and adds methods for disabling, enabling and hiding the minimize, maximize and close button of the window.</p>
<p><br>
It also includes a sample WPF application project which uses an instance of the CustomWindow class in the class libary as its MainWindow. The MainWindow consists of a couple of buttons with click event handlers that simply calls the methods that are defined
 in the CustomWindow base class.&nbsp;&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<p><span>The solution consists of two projects; a sample WPF application with a single window and a couple of Button elements, and a WPF Custom Control Library where the custom window class is implemented.<br>
</span></p>
<h1>More Information</h1>
<p>For more information, refer to the following blog post:&nbsp;http://blog.magnusmontin.net/2014/11/30/disabling-or-hiding-the-minimize-maximize-or-close-button-of-a-wpf-window/.</p>
<p><em><br>
</em></p>
<p><em><br>
</em></p>
