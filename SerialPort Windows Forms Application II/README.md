# SerialPort Windows Forms Application II
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- threading
- SerialPort
## Topics
- Windows Forms
## Updated
- 07/13/2012
## Description

<h1>Introduction</h1>
<p>In addition to my previous contribution (SerialPort Sample in VB.NET) I will now present a extended version.</p>
<p><a href="http://code.msdn.microsoft.com/vstudio/SerialPort-Sample-in-VBNET-fb040fb2">http://code.msdn.microsoft.com/vstudio/SerialPort-Sample-in-VBNET-fb040fb2</a></p>
<p>I have written that code as simple beginners code especially for those who come from VB6 and mscomm32.ocx control.<br>
This contribution based on the same technique SerialPort Class, <br>
but is has more features.</p>
<ul>
<li>working with a richtextbox control<br>
working with String.Split method<br>
working with dynamically created controls on the form<br>
working with bitwise operations </li></ul>
<p>But this code is not only mentioned to learn the SerialPort class. This program is a useful little tool to visualize data sent from a microcontroller or any other device.<br>
&nbsp;<br>
The features are:</p>
<ul>
<li>visualizing up to 20 measuring data<br>
visualizing up to 40 bits (IO or flags of the controller)<br>
supports a protocol log for every field<br>
supports log every minute <br>
reading timestamp from mcu<br>
storing logged data in a textfile<br>
labeling each field with custom text </li></ul>
<p>I use this tool very often in my house. A microcontroller sends 16 temperatur values and digital IO states from my heating system.&nbsp;</p>
<h1><br>
Building the sample</h1>
<p>There are no special requirements necessary. You need only one COM port on system.</p>
<h1><br>
Telegram specification</h1>
<p>The data from the external device must have this format:</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '&gt;00:42 45 18 18 18 45 45 18 18 18 18 45 18 24 18&#43;130 97 4 170&nbsp; &lt;carriage return&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '|&nbsp; |&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 ||&nbsp; max 5 bytes<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '|&nbsp; |&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 &#43;-- separator&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '|&nbsp; |&nbsp;&nbsp; &#43;&nbsp; values 1 .. max 20<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '|&nbsp; &#43; ---&nbsp; mcu time<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '&#43; ------&nbsp; this are measuring data</p>
<p>&nbsp;</p>
<p>As You can see I use spaces as delimiter. <br>
The delimiter &quot;&#43;&quot; is used to distinguish between value and byte section</p>
<p>The amount of values which You send can diverge from 1 to 20 (max). The character set depends on Your device.<br>
Windows uses internally Endcoding.Default when not otherwise specificated.<br>
&nbsp;<br>
Possible items are:</p>
<ul>
<li>100%<br>
-1.34<br>
4F<br>
Low </li></ul>
<p>Then we have the byte section. You can receive up to 5 bytes. The format must be 0 .. 255 decimal.&nbsp;
<br>
My code splites each byte into its representing bits b0 - b7 and visualize them in the controls.</p>
<p>Example: used frames in this sreenshot:</p>
<p>&gt;17:25 12 45 90 100%&#43;127 170<br>
&gt;17:25 12 45 90 100%&#43;127 85<br>
&gt;17:25 12 45 90 100%&#43;127 85</p>
<h1><br>
Description of the user inteface</h1>
<p>&nbsp;</p>
<p><img id="59477" src="59477-src1klein.jpg" alt="" width="637" height="385"></p>
<p>&nbsp;</p>
<p><br>
<strong>GroupBox: ComPort</strong></p>
<p>Here You can make Your com port settings. When the application starts it will retrieve all available COM ports from the System.</p>
<ul>
<li>choose a Com on combobox &quot;Port&quot; <br>
choose baudrate on combobox &quot;Baud&quot; <br>
press button &quot;Open&quot; to open the port<br>
press button &quot;Close&quot; to close the port </li></ul>
<p>8N1 are standard settings which You can only change in the code.<br>
(Databits 8, Pariity None, Stoppbits 1)</p>
<p><strong>GroupBox: MCU time</strong></p>
<p>Displays the actual time from the last received frame.</p>
<p><strong>GroupBox: send char to MCU</strong></p>
<p>A button array which sends its representing value as char to mcu &quot;1&quot;,....&quot;C&quot;,&quot;E&quot;</p>
<p><strong>GroupBox: log data options</strong></p>
<p>Checkbox: &quot;Log ON&quot; logging is enabled. Every frame is evaluated for log data<br>
Checkbox: &quot;every 1min&quot; only frames when minute has changed are evaluated</p>
<p><br>
<strong>GroupBox: Visualize data box</strong></p>
<p>Auto generated log lines. The values data every evaluated frame. <br>
The bits only when one has changed since the last frame.</p>
<p>Example:</p>
<p>17:25 temp_1 45 temp_P3 100% <br>
17:25 temp_1 45 temp_P3 100% <br>
17:25 line1 OFF<br>
17:25 line2 ON<br>
17:25 temp_1 45 temp_P3 100% <br>
17:25 line1 ON<br>
17:25 line2 OFF<br>
17:25 temp_1 45 temp_P3 111%</p>
<p>Here mcu has send 4 frames. Value temp_P3 has changed<br>
the bits line1 &amp; line2 have changed their logical state in each frame</p>
<p>Buttons: Save &amp; Clear</p>
<p>Clears the RichtextBox or save the content to a plaintext file.</p>
<p><br>
<strong>Display area</strong></p>
<p>As You see we have 20 Values fields and&nbsp;40 bit fields. <br>
when one or more of these checkboxes are checked this signal will be enabled for logging<br>
The default description of the field are &quot;Value_xx&quot; or IO_bitXX. <br>
To make Your own project specific descriptions, use the file settings.ini in the execution folder.</p>
<p>settings.ini has this format:</p>
<p>&lt;1&gt;<br>
temp_O<br>
temp_1<br>
temp_2<br>
temp_P3<br>
temp_Abgas<br>
flow control<br>
no <br>
level down<br>
overload <br>
&lt;2&gt;<br>
LED1<br>
LED2<br>
LED3<br>
Engine1<br>
drive0<br>
drive1<br>
drive3<br>
sun power<br>
Page0<br>
Page1<br>
line1<br>
line2<br>
Abgas_Flag<br>
Convert_busy<br>
Logging_flag<br>
WW_aktiv<br>
frei<br>
err_convert<br>
Temp_neg<br>
err_DS1820<br>
Bus_error<br>
free<br>
REL1<br>
Mode1<br>
Mode2<br>
Mode3<br>
prozess<br>
REL2<br>
time contol<br>
Flag1<br>
Change_Flag</p>
<h1><br>
Summary</h1>
<p>Working with label and Textboxes is only a suggestion. I think I have inspired You now. You can make many more: progressbars, bargraphs, usercontrols and graphic. Here a sample code:</p>
<p><a href="http://code.msdn.microsoft.com/GDI-Windows-Forms-Sample-II-65be90d8">http://code.msdn.microsoft.com/GDI-Windows-Forms-Sample-II-65be90d8</a>&nbsp;</p>
<p>OK so far. I think download it and be enjoyed. (And make Your own visualisation system now)<br>
To learn more about the datareceived event I refer to my other contribution.</p>
<p>regards Ellen</p>
<h1>Review</h1>
<p>Bug: No comport on system 2012-07-13</p>
