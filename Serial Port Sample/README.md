# Serial Port Sample
## Requires
- Visual Studio 2005
## License
- Apache License, Version 2.0
## Technologies
- Win32
## Topics
- Serial Port
## Updated
- 11/14/2017
## Description

<h1><span style="font-size:medium">Introduction</span></h1>
<p><span style="font-size:medium"><em>This Sample program contains code which opens two UART COM port to send and recieve data via serial UART.&nbsp;</em><em>&nbsp;</em></span></p>
<p><span style="font-size:medium"><strong><em><br>
T</em>o know more about serial port communications and its software implementation details such as API calls in different platforms, you can vist the following links.</strong></span></p>
<p>&nbsp;</p>
<p><span style="font-size:medium"><strong><a href="http://gopinaths.gitlab.io/post/serial_uart/">http://gopinaths.gitlab.io/post/serial_uart/</a></strong></span></p>
<p><span style="font-size:medium"><em><br>
</em></span></p>
<h1><span style="font-size:medium">Building the Sample</span></h1>
<p><span style="font-size:medium">You can build the source code by selecting &quot;<a rel="noreferrer" href="http://msdn.microsoft.com/en-us/library/s2h6xst1.aspx">Rebuild solution</a>&quot;&nbsp;option in Visaual Studio.&nbsp;</span></p>
<p>&nbsp;</p>
<h1><span style="font-size:medium">Testing the Sample</span></h1>
<p><span style="font-size:medium"><em>Once you have complied the this win32 application successfully, you can test this UART serial sample progarm by any one of the following method.</em></span></p>
<p>&nbsp;</p>
<p><span style="font-size:medium"><em><strong>Method 1: </strong>You need two windows PC with this sample application running on the both side. Then you need to connect normal UART cable &nbsp;between two commputers. (You may need serial UART to USB converter
 for this). Now open the corresponding COM port and configure the settings from the test application. T<em>ype any character in keyboard under particular port to transmit via other port.&nbsp;</em>&nbsp;</em></span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:medium"><em><em><strong>Method 2: &nbsp;</strong>This method you just need one PC. &nbsp;Connect the two end of UART cable using UART to USB converter to two USB ports of the PC.
<strong>Make sure you are using UART cross over cable. </strong>(RX and TX swapped &amp; RTS and CTS swppped). Now open the application and open the corresponding COM port to send and receive data over UART.&nbsp;</em></em></span></p>
<p>&nbsp;</p>
<p><strong><span style="font-size:medium"><em><em>Note: </em></em></span></strong></p>
<p><span style="font-size:medium"><em><em>This application is just a sample program to ddemonstrate serial UART programing in win32 . This is not fully optimized code. You may need to optimize it accosrindg to your use case like &nbsp;handling the send and
 receive process &nbsp;in a separate threads for better perfomance.&nbsp;</em></em></span></p>
<p><span style="font-size:medium"><em><em><br>
</em></em></span></p>
