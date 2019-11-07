# TAPI 3 in C# - Get Lines and make a call, see calls incomming
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
## Topics
- TAPI in C#
## Updated
- 03/08/2012
## Description

<h1>Introduction</h1>
<p><em>Very simple Sample how to use TAPI</em></p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p><em>This sample shows how you can use TAPI3.0 in Csharp to make Calls and to see incoming calls. First all lines are read into a combobox and there you can select a line and register for use.</em></p>
<p>To use the TAPI library in your own project you have to Add Reference -&gt; COM Object -&gt; Microsoft TAPI3.0 Type Library. After adding this reference right click the TAPI3Lib reference in the References and click Properties. Disable &quot;Embed&nbsp;Interop
 Types&quot;</p>
<p>From now you can use the Tapi Classes interfaces and constants in your Project.</p>
<p>Source Description:</p>
<p>In the constructor of Form1 there is first the tapi class created (new TAPI3Lib.TAPIClass())</p>
<p>Very Important is the EventFilter. There you can set which kind of Events you what to see in the eventhandler registered in the next line.</p>
<p>In the button1_Click event the line you have selected in the combobox is seached an Registered for Callnotification. From that moment you get callbacks if your phone is called. Important is, that the callbacks are not in your UI Thread. So if you interact
 with your form you have to use Invoke or BeginInvoke</p>
<p>More Information</p>
<p>A more detailed example you can find on codeproject:</p>
<p><a href="http://www.codeproject.com/Articles/10994/TAPI-3-0-Application-development-using-C-NET">http://www.codeproject.com/Articles/10994/TAPI-3-0-Application-development-using-C-NET</a></p>
